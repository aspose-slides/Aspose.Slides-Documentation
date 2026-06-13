---
title: تبدیل سند OpenOffice
type: docs
weight: 30
url: /fa/net/conversion-of-openoffice-document/
---
Aspose.Slides برای .NET کلاس **Presentation** را ارائه می‌دهد که نمایانگر یک فایل ارائه است. حالا کلاس **Presentation** می‌تواند از طریق سازنده Presentation به **ODP** نیز دسترسی پیدا کند هنگامی که شیء ساخته می‌شود.

در زیر نمونه‌ای از تبدیل **ODP** به PPT/PPTX آورده شده است.
## **مثال**
```

 //یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //ذخیره ارائه PPTX به فرمت PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

در زیر نمونه‌ای از تبدیل PPT/PPTX به **ODP** آورده شده است.
## **مثال**
``` 
 //یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //ذخیره ارائه PPTX به فرمت ODP

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **دانلود نمونه اجرا**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **دانلود کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)