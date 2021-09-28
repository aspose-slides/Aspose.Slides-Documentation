---
title: PPT vs PPTX
type: docs
weight: 10
url: /java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Read about PPT vs PPTX differences in Aspose.Slides."
---


## **What is PPT?**
[**PPT**](https://wiki.fileformat.com/presentation/ppt/) is a binary file format, i.e. it is impossible to view its content without special tools. The first PowerPoint 97-2003 versions worked with PPT file format, however its expandability is limited. 
## **What is PPTX?**
[**PPTX**](https://wiki.fileformat.com/presentation/pptx/) is a new presentation file format, based on the Office Open XML (ISO 29500:2008-2016, ECMA-376) standard. PPTX is an archived set of XML and media files. PPTX format is easily expandable. For example, it is easy to add support for a new chart type or shape type, without changing PPTX format in every new PowerPoint version. PPTX format is used starting from PowerPoint 2007.
## **PPT vs PPTX**
Although PPTX provides much broader functionality, PPT remains quite popular. The necessity to convert from PPT to PPTX and vice versa is highy demanded.

However, conversion between old PPT and new PPTX format is the most complicated challenge among other Microsoft Office formats. Although the specification of PPT format is open, it is difficult to work with it. PowerPoint can create special parts (MetroBlob) in PPT files to store information from PPTX that is not supported by PPT format and can't be displayed in old PowerPoint versions. This information can be restored when a PPT file is loaded in a modern PowerPoint version or converted to PPTX format.

Aspose.Slides provides a common interface to work with all presentation formats. It allows converting from PPT to PPTX and PPTX to PPT in a very simple way. Aspose.Slides completely supports conversion from PPT to PPTX and also supports conversion from PPTX to PPT with some restrictions. We recommend using PPTX format wherever possible.

{{% alert color="primary" %}} 

Check the quality of PPT to PPTX and PPTX to PPT conversions with online [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```java
// Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// Saving the PPT presentation to PPTX format
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Read more [**How to Convert Presentations PPT to PPTX**.](/slides/java/convert-ppt-to-pptx/)
{{% /alert %}} 