---
title: بهبود پردازش تصویر با API مدرن
linktitle: API مدرن
type: docs
weight: 280
url: /fa/cpp/modern-api/
keywords:
- System.Drawing
- API مدرن
- رسم
- بندانگشتی اسلاید
- تبدیل اسلاید به تصویر
- بندانگشتی شکل
- تبدیل شکل به تصویر
- بندانگشتی ارائه
- تبدیل ارائه به تصاویر
- افزودن تصویر
- افزودن عکس
- C++
- Aspose.Slides
description: "پردازش تصویر اسلاید را با جایگزینی APIهای منسوخ تصویری با API مدرن C++ برای خودکارسازی یکپارچه PowerPoint و OpenDocument به‌روز کنید."
---
## **مقدمه**

در حال حاضر، کتابخانه Aspose.Slides برای C++ وابستگی‌هایی در API عمومی خود به کلاس‌های زیر از System::Drawing دارد:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/fa/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/fa/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/fa/cpp/system.drawing/bitmap/)

از نسخه 24.4 به بعد، این API عمومی به‌عنوان منسوخ اعلام شده است.

برای حذف وابستگی‌های API عمومی به System::Drawing، ما به اصطلاح "API مدرن" را اضافه کردیم. متدهایی که از [System::Drawing::Image](https://reference.aspose.com/slides/fa/cpp/system.drawing/image/) و [System::Drawing::Bitmap](https://reference.aspose.com/slides/fa/cpp/system.drawing/bitmap/) استفاده می‌کنند به‌عنوان منسوخ اعلام شده و باید با متدهای متناظر API مدرن جایگزین شوند. متدهایی که از [System::Drawing::Graphics](https://reference.aspose.com/slides/fa/cpp/system.drawing/graphics/) استفاده می‌کنند نیز منسوخ هستند و جایگزین مستقیم در API مدرن ندارند.

در نسخه‌های جاری، API عمومی که به انواع System::Drawing وابسته است را به‌عنوان قدیمی/منسوخ در نظر بگیرید. برای کدهای جدید و هنگام مهاجرت گردش کارهای پردازش تصویر موجود، از API مدرن استفاده کنید.

## **API مدرن**

کلاس‌ها و enum‌های زیر به API عمومی اضافه شد:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) - نمایانگر تصویر راستری یا برداری.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/) - نمایانگر قالب فایل تصویر.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/fa/cpp/aspose.slides/images/) - متدهایی برای ایجاد نمونه و کار با رابط [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/).

از `GetImage` برای رندر یک اسلاید یا شکل استفاده کنید. از `GetImages` برای رندر چندین اسلاید ارائه استفاده کنید. از متدهای [Images](https://reference.aspose.com/slides/fa/cpp/aspose.slides/images/) برای بارگذاری تصاویر، `AddImage` همراه با [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) برای افزودن آن‌ها به ارائه و `ReplaceImage` همراه با [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) برای بروزرسانی تصویر موجود در ارائه استفاده کنید.

یک سناریوی معمولی برای استفاده از API جدید به شکل زیر است:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// یک نمونه قابل حذف از IImage را از فایل روی دیسک ایجاد کنید.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// یک تصویر PowerPoint ایجاد کنید با افزودن یک نمونه IImage به تصاویر ارائه.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// یک شکل تصویر را بر روی اسلاید #1 اضافه کنید
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// یک نمونه از IImage که اسلاید #1 را نشان می‌دهد دریافت کنید.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// تصویر را روی دیسک ذخیره کنید.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **جایگزینی کد قدیمی با API مدرن**

برای تسهیل انتقال، رابط جدید [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) امضای جداگانهٔ کلاس‌های [System::Drawing::Image](https://reference.aspose.com/slides/fa/cpp/system.drawing/image/) و [System::Drawing::Bitmap](https://reference.aspose.com/slides/fa/cpp/system.drawing/bitmap/) را تکرار می‌کند. به‌طور کلی، تنها کافیست فراخوانی متد قدیمی که از System::Drawing استفاده می‌کند را با متد جدید جایگزین کنید.

### **دریافت تصویر بندانگشتی اسلاید**

API کهنه/منسوخ:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

API مدرن:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **دریافت تصویر بندانگشتی شکل**

API کهنه/منسوخ:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

API مدرن:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **دریافت تصویر بندانگشتی ارائه**

API کهنه/منسوخ:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

API مدرن:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **افزودن تصویر به ارائه**

API کهنه/منسوخ:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

API مدرن:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **متدها/ویژگی‌های منسوخ و جایگزین‌های آن‌ها در API مدرن**

### **کلاس Presentation**
|امضای متد|امضای متد جایگزین|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **کلاس Slide**
|امضای متد|امضای متد جایگزین|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **کلاس Shape**
|امضای متد|امضای متد جایگزین|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **کلاس ImageCollection**
|امضای متد|امضای متد جایگزین|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **کلاس PPImage**
|امضای متد|امضای متد جایگزین|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **کلاس PatternFormat**
|امضای متد|امضای متد جایگزین|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **کلاس IPatternFormatEffectiveData**
|امضای متد|امضای متد جایگزین|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **پشتیبانی API برای System::Drawing::Graphics**

متدهایی که از [System::Drawing::Graphics](https://reference.aspose.com/slides/fa/cpp/system.drawing/graphics/) استفاده می‌کنند به‌عنوان منسوخ اعلام شده و جایگزین مستقیم در API مدرن ندارند.

به‌جای API که به [System::Drawing::Graphics](https://reference.aspose.com/slides/fa/cpp/system.drawing/graphics/) رندر می‌کند، از متدهای رندر تصویر API مدرن استفاده کنید:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **سؤالات متداول**

**چرا [System::Drawing::Graphics](https://reference.aspose.com/slides/fa/cpp/system.drawing/graphics/) حذف شد؟**

پشتیبانی از [System::Drawing::Graphics](https://reference.aspose.com/slides/fa/cpp/system.drawing/graphics/) در API عمومی منسوخ شده است تا کار با رندر و تصاویر یکپارچه شود، وابستگی‌های خاص پلتفرم حذف شوند و به رویکردی چندپلتفرمی با استفاده از [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) سوئیچ شود. به‌جای رندر به [System::Drawing::Graphics](https://reference.aspose.com/slides/fa/cpp/system.drawing/graphics/) از `GetImage` یا `GetImages` استفاده کنید.

**مزیت عملی استفاده از [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) نسبت به [System::Drawing::Image](https://reference.aspose.com/slides/fa/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/fa/cpp/system.drawing/bitmap/) چیست؟**

[IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) کار با تصاویر رستر و برداری را یکپارچه می‌کند، ذخیره‌سازی به قالب‌های مختلف را از طریق [ImageFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/) ساده می‌سازد، وابستگی به `System::Drawing` را کاهش می‌دهد و کد را بین محیط‌ها قابل حمل می‌کند.

**آیا API مدرن بر عملکرد تولید تصویرهای بندانگشتی تأثیر خواهد گذاشت؟**

جایگزینی `GetThumbnail` با `GetImage` عملکرد را بدتر نمی‌کند: متدهای جدید همان قابلیت تولید تصویر با گزینه‌ها و اندازه‌ها را دارند و همچنان از گزینه‌های رندر پشتیبانی می‌کنند. سود یا کاهش خاص بسته به سناریو متفاوت است، اما از نظر عملکردی جایگزین‌ها برابرند.