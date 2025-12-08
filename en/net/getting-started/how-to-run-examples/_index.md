---
title: How to Run Examples
type: docs
weight: 130
url: /net/how-to-run-examples/
keywords:
- examples
- software requirements
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Run Aspose.Slides for .NET examples fast: clone the repo, restore packages, then build and test features for PPT, PPTX and ODP."
---

## **Software Requirements**
Before you download and run the examples, please check and confirm that your setup meets these requirements: 

- Visual Studio 2010 or higher.
- NuGet Package Manager installed in Visual Studio. Verify that the latest NuGet API version is installed in Visual Studio. 

For instructions on installing the NuGet package manager, go to this page: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Go through **Tools** > **Options** > **NuGet Package Manager**.

1. Expand **NuGet Package Manager** (by double-clicking on it) and then select **Package Sources**. 

1. Check and confirm that the nuget.org parameter is selected. 

   The example project uses the NuGet Automatic Package Restore feature, so you need to have an active internet connection. 

   If you do not have an active internet connection on the machine where you intend to execute examples, please check [Installation](https://docs.aspose.com/slides/net/installation/) and (manually) add a reference to Aspose.Slides.dll in the example project.
## **Download Aspose.Slides from GitHub**
All Aspose.Slides for .NET examples are hosted on [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

You can either clone the repository using your favorite GitHub client or download the ZIP file [here](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. If you download the ZIP file, you have to extract its contents to a folder on your computer. 

All the examples are stored in the **Examples** folder.

There is a C# Visual Studio solution file. The projects are created in Visual Studio 2013, but the solution files are compatible with Visual Studio 2010 SP1 and higher.

2. Open the solution file in Visual Studio and build the project.

   On the first run, the dependencies are automatically downloaded via NuGet.

The **Data** folder at the root folder of **Examples** contains input files used in the C# examples. You have to download the **Data** folder alongside the examples project.

3. Open the RunExamples.cs file. All the examples are called from here.

4. Uncomment the examples you want to run within the project.

Please feel free to reach out using our forums if you have issues setting up things or running the examples.
## **Contribute**
You can contribute to the project by adding or improving an example. All examples and showcase projects in the repository are open-source, so you (and other people) can use them freely in applications.

To contribute, you can fork the repository, edit the source code, and create a pull request. We will review the changes. If we find them useful, we will add them to the repository.