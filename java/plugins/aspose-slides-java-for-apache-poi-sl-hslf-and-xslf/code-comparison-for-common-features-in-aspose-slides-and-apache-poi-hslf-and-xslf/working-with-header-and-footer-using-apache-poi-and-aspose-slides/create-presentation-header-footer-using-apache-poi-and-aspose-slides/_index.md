---
title: Create Presentation Header Footer using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/create-presentation-header-footer-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Create Presentation Header Footer**
getHeaderFooterManager gives you access to Headers and Footers using Aspose.Slides API.

**Java**

{{< highlight java >}}

 //Show date time placeholder

sourcePres.getHeaderFooterManager().setDateTimeVisible(true);

//Show the footer place holder

sourcePres.getHeaderFooterManager().setFooterVisible(true);

//Show Slide Number

sourcePres.getHeaderFooterManager().setSlideNumberVisible(true);

//Set the  header footer visibility on Title Slide

sourcePres.getHeaderFooterManager().setVisibilityOnTitleSlide(true);

sourcePres.getHeaderFooterManager().setFooterText("Aspose Slides");

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Create Presentation Header Footer**
HeadersFooters class getters to access header and footer using Apache POI SL - HSLF XSLF

**Java**

{{< highlight java >}}

 //presentation-scope headers / footers

HeadersFooters hf = ppt.getSlideHeadersFooters();

hf.setSlideNumberVisible(true);

hf.setFootersText("Created by POI-HSLF");

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createheaderfooter/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createheaderfooter)

{{% alert color="primary" %}} 

For more details, visit [How to Add Header Footer in a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/How+to+Add+Header+Footer+in+a+Presentation).

{{% /alert %}}
