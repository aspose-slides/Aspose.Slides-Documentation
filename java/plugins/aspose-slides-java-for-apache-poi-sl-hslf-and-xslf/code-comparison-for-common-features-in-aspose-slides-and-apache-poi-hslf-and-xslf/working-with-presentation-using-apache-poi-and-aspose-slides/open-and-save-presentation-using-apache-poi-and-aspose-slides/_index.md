---
title: Open and Save Presentation using Apache POI and Aspose.Slides
type: docs
weight: 50
url: /java/open-and-save-presentation-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Open and Save Presentation**
Using Aspose.Slides for Java, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones.

**Java**

{{< highlight java >}}

 //Instantiate a PresentationEx object that represents a PPTX file

Presentation pres = new Presentation(dataDir + "presentation.ppt");

//Add the title slide

ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

//Save the presentation

pres.save(dataDir + "EditedPPT_Aspose.ppt", SaveFormat.Ppt);

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Open and Save Presentation**
FileInputStream can be passed to XMLSlideShow to open an existing presentation. Presentation can than later be saved using FileOutputStream.

**Java**

{{< highlight java >}}

 XMLSlideShow ppt = new XMLSlideShow(new FileInputStream(dataDir + "presentation.pptx"));

//append a new slide to the end

XSLFSlide blankSlide = ppt.createSlide();

//save changes in a file

FileOutputStream out = new FileOutputStream(dataDir + "EditedPPT_Apache.pptx");

ppt.write(out);

out.close();

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/openandsave/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/openandsave)

{{% alert color="primary" %}} 

For more details, visit [Opening a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Opening+a+Presentation) and [Saving a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation).

{{% /alert %}}
