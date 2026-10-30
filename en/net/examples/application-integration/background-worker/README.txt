# Process Presentations in a Background Worker

Pinned .NET SDK 8.0.427/net8.0, Aspose.Slides.NET 26.10.0 and locked dependencies.
Set ASPOSE_LICENSE_PATH to your file license for unrestricted output. No license is included.
The .NET Worker Service snapshots an input folder of PPTX files and queues jobs through a bounded channel. Two consumers each own and dispose a presentation. Every input receives a succeeded, failed or cancelled entry in the final manifest; a corrupt file does not stop later jobs. The loader explicitly requires PPTX rather than treating an arbitrary text file as another supported input format.

Pass input and output folder paths to run your own batch. Add --self-test to generate three valid decks and one corrupt file, process them through a real Generic Host, then start a second host and request graceful shutdown after the first completed item. Inspect normal-output and shutdown-output manifests. This local queue is held in memory; the manifest identifies unstarted/cancelled jobs for an application-managed retry. It is not a durable message broker.

Run: dotnet run --project Example.csproj --configuration Release -- --self-test
