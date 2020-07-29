---
title: Count Number of Slides using Apache POI and Aspose.Slides
type: docs
weight: 20
url: /java/count-number-of-slides-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Count Number of Slides**
Slides can be counted by calling size method after getting all slides of presentation.

**Java**

{{< highlight java >}}

 //Instantiate a PresentationEx object that represents a PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

System.out.println("Total Slides in Count: " + pres.getSlides().size());

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Count Number of Slides**
Slides can be counted by accessing length property after getting all slides of presentation.

**Java**

{{< highlight java >}}

 SlideShow ppt = new SlideShow(new FileInputStream("presentation.ppt"));

System.out.println("Total Slides Count: " + ppt.getSlides().length);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/countslides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/countslides)

{{% alert color="primary" %}} 

For more details, visit [Working with Slides in Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Working+with+Slides+in+Presentation).

{{% /alert %}}
