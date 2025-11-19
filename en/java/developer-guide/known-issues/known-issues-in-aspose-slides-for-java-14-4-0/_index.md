---
title: Known Issues in Aspose.Slides for Java 14.4.0
type: docs
weight: 30
url: /java/known-issues-in-aspose-slides-for-java-14-4-0/
keywords:
- known issue
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Review known issues in Aspose.Slides for Java 14.4.0 to ensure accurate work with PowerPoint and OpenDocument files and avoid surprises in your presentations."
---

{{% alert color="primary" %}} 

Aspose.Slides for Java 14.4.0 provides new decision for PowerPoint documents processing. There are some restrictions and known issues, which will be removed in coming releases:

- Some shapes have wrong geometry in serialized PPT documents (arc, circular arrow, callouts).
- Not all PPTX text formatting features are supported in PPT serialization (tabulation, indentation and paragraph formatting limitations).
- Info about text language and spelling settings is not present in serialized PPT documents.
- Not all PPTX theme features are supported in PPT serialization (only serialization of fill formats, line formats and font).
- There are known issues in OLE/ActiveX PPT serialization to PPT.
- WordArt serialization and rendering are not supported.

{{% /alert %}}
