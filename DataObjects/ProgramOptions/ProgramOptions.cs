﻿using CommandLine;
using System;

namespace AppDynamics.Dexter
{
    public class ProgramOptions
    {
        // ETL
        [Option('j', "job-file", Required = true, SetName = "etl", HelpText = "Input file defining the parameters of the ETL job to process.\nDefines the name of the folder for the report, unless explicit job name is passed.")]
        public string InputETLJobFilePath { get; set; }

        [Option('n', "job-name", Required = false, SetName = "etl", HelpText = "Job name to use instead of being automatically defined based on the name of the job file.")]
        public string JobName { get; set; }

        // Individual Snapshots
        [Option('i', "request-ids", Required = true, SetName = "individualsnapshots", HelpText = "Comma-separated list of Snapshot RequestIDs to process for Individual Snapshots list.")]
        public string RequestIDs { get; set; }

        [Option('r', "report-folder", Required = true, SetName = "individualsnapshots", HelpText = "Report folder where to look for list of list of Snapshots.")]
        public string ReportFolderPath { get; set; }

        // Compare States
        //[Option('c', "compare-states-file", Required = true, SetName = "compare", HelpText = "Compare file defining the mappings of the state comparison to perform.")]
        public string InputCompareJobFilePath { get; set; }

        //[Option('l', "left-from-state-folder", Required = true, SetName = "compare", HelpText = "Folder of the ETL job to use as a left side/reference/from comparison.")]
        public string CompareReportReferenceFolderPath { get; set; }

        //[Option('r', "right-to-state-folder", Required = true, SetName = "compare", HelpText = "Folder of the ETL job to use as a right side/difference/to comparison.")]
        public string CompareReportDifferenceFolderPath { get; set; }

        // Common
        [Option('o', "output-folder", Required = false, HelpText = "Output folder where to store results of processing.\nDefaults to C:\\AppD.Dexter.Out on Windows and %HOME% on Mac/Linux.")]
        public string OutputFolderPath { get; set; }

        [Option('d', "delete-previous-job-output", Required = false, HelpText = "If true, delete any results of previous processing.")]
        public bool DeletePreviousJobOutput { get; set; }

        [Option('s', "sequential-processing", Required = false, HelpText = "If true, process certain items during extraction and conversion sequentially.")]
        public bool ProcessSequentially { get; set; }

        // Version check
        [Option('v', "skip-version-check", Required = false, HelpText = "If true, skips the version check against GitHub repository.")]
        public bool SkipVersionCheck { get; set; }


        public string OutputJobFolderPath { get; set; }

        public string OutputJobFilePath { get; set; }

        public string ProgramLocationFolderPath { get; set; }

        public JobOutput LicensedReports { get; set; }

        public string IndividualSnapshotsNonDefaultReportFolderName { get; set; }

        public override string ToString()
        {
            return String.Format(
@"ProgramOptions:
InputJobFilePath='{0}'
InputJobFilePath='{11}'
RestartJobFromBeginning='{1}'
OutputFolderPath='{2}'
OutputJobFolderPath='{3}'
OutputJobFilePath='{4}'
ProcessSequentially='{5}'
ProgramLocationFolderPath='{6}'
CompareFilePath='{7}'
ReferenceJobFolderPath='{8}'
DifferenceJobFolderPath='{9}'
SkipVersionCheck='{10}',
JobName='{11}',
RequestIDs='{12}',
ReportFolderPath='{13}'",
                this.InputETLJobFilePath, 
                this.DeletePreviousJobOutput, 
                this.OutputFolderPath, 
                this.OutputJobFolderPath, 
                this.OutputJobFilePath,
                this.ProcessSequentially, 
                this.ProgramLocationFolderPath,
                this.InputCompareJobFilePath, 
                this.CompareReportReferenceFolderPath, 
                this.CompareReportDifferenceFolderPath,
                this.SkipVersionCheck,
                this.JobName,
                this.RequestIDs,
                this.ReportFolderPath);
        }
    }
}
