---
title: تحويل مستند OpenOffice
type: docs
weight: 30
url: /ar/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET تقدم فئة **Presentation** التي تمثل ملف عرض تقديمي. يمكن الآن لفئة **Presentation** أيضًا الوصول إلى **ODP** عبر منشئ Presentation عند إنشاء الكائن.

فيما يلي مثال على التحويل من ODP إلى PPT/PPTX.
## **مثال**
```

 //Instantiate a Presentation object that represents a presentation file

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

فيما يلي مثال على التحويل من PPT/PPTX إلى ODP.
## **مثال**
``` 

 //Instantiate a Presentation object that represents a presentation file

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **تنزيل المثال التشغيلي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)