---
title: Extract Header Footer from Presentation using Apache POI and Aspose.Slides
type: docs
weight: 20
url: /java/slides-poi/extract-header-footer-from-presentation/
---

## **Aspose.Slides - Extract Header Footer from Presentation**
The method [getHeaderFooterManager()](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#getHeaderFooterManager--) gives you access to Headers and Footers using Aspose.Slides API.

```java
sourcePres.getSlides().get_Item(0).getHeaderFooterManager().isDateTimeVisible();
sourcePres.getSlides().get_Item(0).getHeaderFooterManager().isFooterVisible();
sourcePres.getSlides().get_Item(0).getHeaderFooterManager().isSlideNumberVisible();
```

## **Apache POI SL - HSLF XSLF - Extract Header Footer from Presentation**
HeadersFooters class getters to access header and footer using Apache POI SL - HSLF XSLF

```java
 //presentation-scope headers / footers
 HeadersFooters hdd = ppt.getSlideHeadersFooters();

 if(hdd.isFooterVisible()) 
 {
     String footerText = hdd.getFooterText();
 }

 //per-slide headers / footers
 for (int i=0; i < slides.length; i++)
 {
     HeadersFooters hdd2 = slides[i].getHeadersFooters();
     if(hdd2.isFooterVisible()) 
	 {
         String footerText = hdd2.getFooterText();
         System.out.println(footerText + footerText);
     }

     if(hdd2.isUserDateVisible()) 
	 {
        String customDate = hdd2.getDateTimeText();
        System.out.println(customDate + customDate);
     }

     if(hdd2.isSlideNumberVisible())
	 {
         int slideNUm = slides[i].getSlideNumber();
         System.out.println(slideNUm + slideNUm);
     }
}
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/extractheaderfooter)

{{% alert color="primary" %}} 

For more details, visit [How to Add Header Footer in a Presentation](https://docs.aspose.com/slides/java/presentation-header-and-footer/).

{{% /alert %}}
