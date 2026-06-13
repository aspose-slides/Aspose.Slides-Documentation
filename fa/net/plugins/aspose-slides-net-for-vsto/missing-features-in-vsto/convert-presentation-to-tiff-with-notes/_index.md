---
title: تبدیل ارائه به Tiff با یادداشت‌ها
type: docs
weight: 50
url: /fa/net/convert-presentation-to-tiff-with-notes/
---
TIFF یکی از چندین قالب تصویر به‌طور گسترده مورد استفاده است که Aspose.Slides برای .NET از آن پشتیبانی می‌کند تا یک ارائه همراه با یادداشت‌ها را به تصویر تبدیل کند. همچنین می‌توانید تصویرهای بندانگشتی اسلاید را در نمای اسلاید یادداشت‌ها تولید کنید. در ادامه دو قطعه کد نشان می‌دهند چگونه می‌توان تصاویر TIFF یک ارائه را در نمای اسلاید یادداشت‌ها ایجاد کرد.

متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) می‌تواند برای تبدیل کل ارائه در نمای اسلاید یادداشت‌ها به TIFF استفاده شود. همچنین می‌توانید تصویر بندانگشتی یک اسلاید را در نمای اسلاید یادداشت‌ها برای اسلایدهای فردی تولید کنید.
## **مثال**

``` 

  //یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است

 Presentation pres = new Presentation("Conversion.pptx");

 //ذخیره ارائه به فرمت TIFF با یادداشت‌ها

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);
``` 
## **بارگیری مثال اجرایی**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **بارگیری کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

برای جزئیات بیشتر، مراجعه کنید به [تبدیل ارائه‌های پاورپوینت به TIFF با یادداشت‌ها در .NET](/slides/fa/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}