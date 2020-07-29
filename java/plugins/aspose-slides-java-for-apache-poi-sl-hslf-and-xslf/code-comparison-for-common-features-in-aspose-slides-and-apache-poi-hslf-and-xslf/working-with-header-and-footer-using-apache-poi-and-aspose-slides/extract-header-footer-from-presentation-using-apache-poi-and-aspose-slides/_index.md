---
title: Extract Header Footer from Presentation using Apache POI and Aspose.Slides
type: docs
weight: 20
url: /java/extract-header-footer-from-presentation-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Extract Header Footer from Presentation**
getHeaderFooterManager gives you access to Headers and Footers using Aspose.Slides API.

**Java**

{{< highlight java >}}

 System.out.println(sourcePres.getHeaderFooterManager().isDateTimeVisible());

System.out.println(sourcePres.getHeaderFooterManager().isFooterVisible());

System.out.println(sourcePres.getHeaderFooterManager().isSlideNumberVisible());

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Extract Header Footer from Presentation**
HeadersFooters class getters to access header and footer using Apache POI SL - HSLF XSLF

**Java**

{{< highlight java >}}

 //presentation-scope headers / footers

 HeadersFooters hdd = ppt.getSlideHeadersFooters();

 if(hdd.isFooterVisible()) {

     String footerText = hdd.getFooterText();

 }

 //per-slide headers / footers

 for (int i=0; i < slides.length; i++){

     HeadersFooters hdd2 = slides[i].getHeadersFooters();

     if(hdd2.isFooterVisible()) {

         String footerText = hdd2.getFooterText();

         System.out.println(footerText + footerText);

     }

     if(hdd2.isUserDateVisible()) {

        String customDate = hdd2.getDateTimeText();

        System.out.println(customDate + customDate);

     }

     if(hdd2.isSlideNumberVisible()){

         int slideNUm = slides[i].getSlideNumber();

         System.out.println(slideNUm + slideNUm);

     }

 }

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/extractheaderfooter/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/extractheaderfooter)

{{% alert color="primary" %}} 

For more details, visit [How to Add Header Footer in a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/How+to+Add+Header+Footer+in+a+Presentation).

{{% /alert %}}
