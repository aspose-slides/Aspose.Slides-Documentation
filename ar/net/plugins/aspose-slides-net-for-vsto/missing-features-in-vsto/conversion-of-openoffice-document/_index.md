---
title: تحويل مستند OpenOffice
type: docs
weight: 30
url: /ar/net/conversion-of-openoffice-document/
---

توفر Aspose.Slides لـ .NET فئة **Presentation** التي تمثل ملف عرض تقديمي. يمكن الآن لفئة **Presentation** الوصول أيضًا إلى **ODP** من خلال مُنشئ Presentation عندما يتم إنشاء الكائن.

فيما يلي مثال لتحويل من ODP إلى PPT/PPTX.
## **مثال**
```

 //إنشاء كائن Presentation يمثل ملف عرض تقديمي

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //حفظ العرض التقديمي PPTX إلى تنسيق PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

فيما يلي مثال لتحويل من PPT/PPTX إلى ODP.
## **مثال**
``` 

 //إنشاء كائن Presentation يمثل ملف عرض تقديمي

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //حفظ العرض التقديمي PPTX إلى تنسيق PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **تنزيل مثال عملي**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تنزيل كود العينة**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)