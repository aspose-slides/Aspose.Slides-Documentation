---
title: افزودن اشکال به ارائه
type: docs
weight: 30
url: /fa/net/adding-shapes-to-presentation/
---
## **VSTO**
در زیر کد نمونه برای افزودن شکل خط آورده شده است:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

```
## **Aspose.Slides**
برای افزودن یک خط ساده به اسلاید انتخاب شده از ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع یک اسلاید را با استفاده از اندیس آن دریافت کنید
- یک AutoShape از نوع Line را با استفاده از متد AddAutoShape که توسط شیء Shapes باز شده است اضافه کنید
- ارائه‌ی اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید

در مثال زیر، یک خط به اسلاید اول ارائه اضافه کرده‌ایم.

``` csharp

   //یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است ایجاد کنید

  Presentation pres = new Presentation();

  //دریافت اولین اسلاید

  ISlide slide = pres.Slides[0];

  //یک AutoShape از نوع خط اضافه کنید

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

```
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)