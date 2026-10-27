---
title: Process presentations without PowerPoint
description: Create, edit and render presentations without installing PowerPoint.
type: docs
url: /features/without-powerpoint/
weight: 320
feature_id: without-powerpoint
feature_group: deployment
translationKey: slides-feature-without-powerpoint
feature_catalogue_version: 3
feature_guides:
- /slides/net/why-not-automation/
---

## **Overview**

Aspose.Slides processes presentation files directly. You can use it in background jobs, server applications and containers without automating a desktop PowerPoint or LibreOffice installation. Install the library's platform dependencies and the fonts needed by your documents.

## **Usage guidance**

A background worker can load a presentation, change its content and write a PDF using the installed library. The application still supplies fonts, writable output storage and the native dependencies for its selected package. For a runnable binding example, see [Use Slides from .NET](/slides/features/dotnet-api/) or [Use Slides from Python](/slides/features/python-api/).

## **FAQ**

### **Does a server need a desktop session?**

No PowerPoint desktop session is needed. Follow the installation and platform guidance for the library package you use.

### **Does the library need to send presentations to an Office service?**

No. Ordinary file processing runs in the application process using local files and resources. Optional AI workflows separately contact the model endpoint configured by the caller.

### **How does library rendering differ from automating the PowerPoint application?**

The library reads and writes document content through its own API. It does not drive the PowerPoint user interface or execute that application's macros and add-ins. Rendering uses the library and the available fonts; check the output when exact layout matters.

## **Guides**

- [Why Not Automation (.NET)](/slides/net/why-not-automation/)

Related feature: [Run Slides in Docker containers](/slides/features/docker/).
