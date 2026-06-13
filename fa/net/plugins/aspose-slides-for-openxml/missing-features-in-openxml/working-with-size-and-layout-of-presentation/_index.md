---
title: کار با اندازه و چیدمان ارائه
type: docs
weight: 90
url: /fa/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** و **SlideSize.Size** ویژگی‌های کلاس Presentation هستند که می‌توان آن‌ها را همان‌طور که در مثال زیر نشان داده شده تنظیم یا دریافت کرد.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//اندازه اسلاید ارائه‌های تولید شده را برابر با منبع تنظیم کنید

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//ارائه را روی دیسک ذخیره کنید

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **کد نمونه را دانلود کنید**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **مثال اجرایی را دانلود کنید**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

برای جزئیات بیشتر، به [تغییر اندازه اسلاید ارائه در .NET](/slides/fa/net/slide-size/) مراجعه کنید.

{{% /alert %}}