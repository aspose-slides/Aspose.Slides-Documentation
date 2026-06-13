---
title: انتقال‌های اسلاید
type: docs
weight: 80
url: /fa/net/slide-transitions/
---
برای راحت‌تر فهمیدن، نحوه استفاده از Aspose.Slides برای .NET برای مدیریت انتقال‌های ساده اسلاید را نمایش داده‌ایم. توسعه‌دهندگان می‌توانند نه تنها افکت‌های مختلف انتقال اسلاید را بر روی اسلایدها اعمال کنند، بلکه رفتار این افکت‌های انتقال را نیز سفارشی‌سازی کنند. برای ایجاد یک افکت انتقال ساده اسلاید، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- یک نوع Slide Transition را بر روی اسلاید از میان افکت‌های انتقالی ارائه‌شده توسط Aspose.Slides برای .NET با استفاده از enum **TransitionType** اعمال کنید
- فایل ارائه تغییر یافته را بنویسید.

## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است

using (Presentation pres = new Presentation(FileName))

{

    //اعمال انتقال نوع دایره‌ای بر اسلاید 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //اعمال انتقال نوع شانه‌ای بر اسلاید 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //اعمال انتقال نوع بزرگ‌نمایی بر اسلاید 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //نوشتن ارائه بر روی دیسک

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **دانلود کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **دانلود مثال اجرایی**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
برای جزئیات بیشتر، به [مدیریت انتقال‌های اسلاید](/slides/fa/net/slide-transition/) مراجعه کنید.
{{% /alert %}}