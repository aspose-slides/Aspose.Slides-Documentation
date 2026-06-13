---
title: افزودن فریم تصویر به ارائه
type: docs
weight: 50
url: /fa/net/add-picture-frame-to-presentation/
---
## **VSTO**
در ادامه کد افزودن تصویر به ارائه VSTO آورده شده است:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
برای افزودن یک فریم تصویر ساده به اسلاید خود، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از اندیس آن دریافت کنید.
1. یک شیء Image ایجاد کنید به‌وسیله افزودن یک تصویر به مجموعه Images مرتبط با شیء Presentation که برای پر کردن Shape استفاده می‌شود.
1. عرض و ارتفاع تصویر را محاسبه کنید.
1. یک PictureFrame مطابق با عرض و ارتفاع تصویر ایجاد کنید با استفاده از متد AddPictureFrame که توسط شیء Shapes مرتبط با اسلاید مورد اشاره ارائه می‌شود.
1. یک فریم تصویر (شامل تصویر) را به اسلاید اضافه کنید.
1. ارائه ویرایش‌شده را به‌صورت فایل PPTX ذخیره کنید.

مراحل فوق در مثال زیر پیاده‌سازی شده‌اند.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //ایجاد نمونه‌ای از کلاس Presentation که نمایانگر PPTX است
  Presentation pres = new Presentation();

  //دریافت اولین اسلاید
  ISlide sld = pres.Slides[0];

  //ایجاد نمونه‌ای از کلاس ImageEx
  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //افزودن فریم تصویر با ارتفاع و عرض معادل تصویر
  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)