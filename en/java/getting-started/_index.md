---
title: Getting Started
type: docs
weight: 10
url: /java/getting-started/
keywords:
- getting started
- system requirements
- installation
- first presentation
- Maven
- PPT processing
- PPTX processing
- ODP processing
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "The path from a new Java project to a first saved presentation with Aspose.Slides: check the requirements, add the library from Aspose's Maven repository, run a first program, and continue with common tasks."
---

## **Overview**

Work through the four steps below in order. Each step names what to do and links the article with the details. Evaluation, licensing, and support are covered after the steps.

## **Step 1: Check the System Requirements**

Aspose.Slides for Java is a single JAR file with no native code, so it runs on any operating system that has a supported Java runtime. [System Requirements](/slides/java/system-requirements/) lists the supported operating systems and Java versions. The project and commands in the next steps need JDK 11 or later and, for the Maven route, [Apache Maven](https://maven.apache.org/install.html).

## **Step 2: Add the Library to Your Project**

Aspose.Slides for Java is published in Aspose's own Maven repository, not in Maven Central. Choose one of these routes:

- With Maven: declare the repository `https://releases.aspose.com/java/repo/` in your *pom.xml* and add the dependency `com.aspose:aspose-slides` with the `jdk16` classifier.
- Without Maven: download the JAR file whose name ends in *-jdk16.jar* from the repository and put it on the class path.

On Linux, also install the fontconfig library and at least one font. Without them, saving a presentation fails with the error "Fontconfig head is null, check your fonts or fonts configuration".

[Installation](/slides/java/installation/) gives the *pom.xml* entries, the JAR download, and the Linux command.

## **Step 3: Create Your First Presentation**

The [quick start on the Aspose.Slides for Java home page](/slides/java/#your-first-presentation) is a complete Maven project: a *pom.xml* file and a program that adds a cloud shape with text to a slide and saves the presentation as a PPTX file. You run it with `mvn compile exec:java`. [Create Presentations](/slides/java/create-presentation/) explains the same program step by step. To open an existing presentation and save it in another format, see [Open Presentations](/slides/java/open-presentation/) and [Save Presentations](/slides/java/save-presentation/).

## **Step 4: Continue with Common Tasks**

- [Open a presentation](/slides/java/open-presentation/)
- [Save a presentation](/slides/java/save-presentation/)
- [Convert a presentation to PDF](/slides/java/convert-powerpoint-to-pdf/)
- [Render slides as images](/slides/java/convert-slide/)
- [Edit presentation text](/slides/java/manage-text/)
- [Examples by slide element](/slides/java/examples/)

## **Evaluate and License**

Without a license, Aspose.Slides runs in evaluation mode: it adds a watermark to every slide it saves and truncates text that your code reads from presentations.

- [Evaluate Aspose.Slides](/slides/java/evaluate-aspose-slides/) describes the evaluation limitations and how to request a temporary license.
- [Licensing](/slides/java/licensing/) shows how to apply a license from a file or a stream.
- [Metered Licensing](/slides/java/metered-licensing/) covers licensing that is billed by usage.
- [Supported File Formats](/slides/java/supported-file-formats/) lists the formats that Aspose.Slides can load and save.

## **Get Help**

[Technical Support](/slides/java/technical-support/) explains how to ask a question on the [free support forum](https://forum.aspose.com/c/slides/11) and what to include when you report a problem.

## **FAQ**

**Do I need Microsoft PowerPoint installed?**

No. Aspose.Slides reads and writes presentation files itself and does not use PowerPoint, so it also runs on servers and on Linux.

**Why does Maven not find Aspose.Slides for Java?**

The library is not in Maven Central. Declare Aspose's repository in your *pom.xml*, as shown in [Installation](/slides/java/installation/), and Maven downloads the library from there.

**Does the `jdk16` classifier mean that the library needs Java 16?**

No. The classifier selects the Java SE build of the library; the other build is for Android. The same build runs on current JDKs, such as JDK 21.
