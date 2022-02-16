---
title: Open Existing Presentation in Aspose.Slides vs pptx4j
type: docs
weight: 60
url: /java/open-existing-presentation-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Open Existing Presentation**
Using Aspose.Slides for Java, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones.

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

// Save presentation with chart

pres.save(dataDir + "Aspose-Duplicate.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **pptx4j - Open Existing Presentation**
Below example shows how existing presentation can be opened and then saved after any kind of modifications using pptx4j.

**Java**

{{< highlight java >}}

 String inputfilepath = dataDir + "presentation.pptx";

PresentationMLPackage presentationMLPackage =

	(PresentationMLPackage)OpcPackage.load(new java.io.File(inputfilepath));

System.out.println("\n\n saving .. \n\n");

presentationMLPackage.save(new java.io.File(dataDir + "Pptx4j-Duplicate.pptx"));

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Opening a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Opening+a+Presentation) and [Saving a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation).

{{% /alert %}}
