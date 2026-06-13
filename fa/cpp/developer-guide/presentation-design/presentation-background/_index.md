---
title: مدیریت پس‌زمینه‌های ارائه در C++
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/cpp/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ ثابت
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- ویژگی‌های پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ تنظیم کنید، همراه با نکات کد برای ارتقای ارائه‌های خود."
---
## **مقدمه**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینهٔ اسلاید استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید عادی** (یک اسلاید واحد) یا یک **اسلاید اصلی** (به‌صورت همزمان برای چندین اسلاید اعمال می‌شود) تنظیم کنید.

![پس‌زمینهٔ پاورپوینت](powerpoint-background.png)

## **تنظیم پس‌زمینهٔ رنگ ثابت برای اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینهٔ اسلاید خاصی در یک ارائه تنظیم کنید — حتی اگر ارائه از اسلاید اصلی استفاده کند. این تغییر فقط بر روی اسلاید انتخاب شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینهٔ اسلاید را به `Solid` تنظیم کنید.
4. از متد [get_SolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_solidfillcolor/) در [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/) برای مشخص کردن رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک رنگ ثابت آبی را به‌عنوان پس‌زمینهٔ اسلاید عادی تنظیم کنید:

```cpp
// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// رنگ پس‌زمینهٔ اسلاید را به آبی تنظیم کنید.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم پس‌زمینهٔ رنگ ثابت برای اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینهٔ اسلاید اصلی در یک ارائه تنظیم کنید. اسلاید اصلی به عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌نماید، بنابراین وقتی یک رنگ ثابت را برای پس‌زمینهٔ اسلاید اصلی انتخاب کنید، برای همهٔ اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید اصلی (از طریق `get_Masters`) را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینهٔ اسلاید اصلی را به `Solid` تنظیم کنید.
4. از متد [get_SolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_solidfillcolor/) برای مشخص کردن رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک رنگ ثابت (سبز جنگلی) را به‌عنوان پس‌زمینهٔ اسلاید اصلی تنظیم کنید:

```cpp
// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// رنگ پس‌زمینهٔ اسلاید اصلی را به سبز جنگلی تنظیم کنید.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم پس‌زمینهٔ گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. وقتی به‌عنوان پس‌زمینهٔ اسلاید استفاده شود، می‌تواند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر نشان دهد. Aspose.Slides به شما امکان می‌دهد یک رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینهٔ اسلاید را به `Gradient` تنظیم کنید.
4. از متد [get_GradientFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_gradientformat/) در [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/) برای پیکربندی تنظیمات دلخواه گرادیان استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```cpp
// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// یک اثر گرادیان را به پس‌زمینه اعمال کنید.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم تصویر به‌عنوان پس‌زمینهٔ اسلاید**

علاوه بر پرکردن‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینهٔ اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینهٔ اسلاید را به `Picture` تنظیم کنید.
4. تصویری را که می‌خواهید به‌عنوان پس‌زمینهٔ اسلاید استفاده کنید بارگذاری کنید.
5. تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
6. از متد [get_PictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_picturefillformat/) در [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```cpp
// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// تنظیم خصوصیات تصویر پس‌زمینه.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// بارگذاری تصویر.
auto image = Images::FromFile(u"Tulips.jpg");
// افزودن تصویر به مجموعهٔ تصاویر ارائه.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// ذخیرهٔ ارائه روی دیسک.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نمونه کد زیر نشان می‌دهد چگونه نوع پرکردن پس‌زمینه را به تصویر کاشی‌شده تنظیم کنید و خصوصیات کاشی‌گذاری را اصلاح کنید:

```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
بیشتر بخوانید: [**کاشی تصویر به‌عنوان بافت**](/slides/fa/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید برجسته‌تر شود. کد زیر به زبان C++ نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```cpp
auto transparencyValue = 30; // برای مثال.

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **دریافت مقدار پس‌زمینهٔ اسلاید**

Aspose.Slides رابط [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibackgroundeffectivedata/) را برای دریافت مقادیر مؤثر پس‌زمینهٔ اسلاید فراهم می‌کند. این رابط، [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) و [EffectFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) مؤثر را در دسترس قرار می‌دهد.

با استفاده از متد `get_Background` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseslide/) می‌توانید پس‌زمینهٔ مؤثر یک اسلاید را بدست آورید.

مثال زیر به زبان C++ نشان می‌دهد چگونه مقدار پس‌زمینهٔ مؤثر یک اسلاید را دریافت کنید:

```cpp
// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// پس‌زمینهٔ مؤثر را بازیابی کنید، در نظر گرفتن اسلاید اصلی، چیدمان و تم.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **سوالات متداول**

**آیا می‌توانم پس‌زمینهٔ سفارشی را بازنشانی کنم و پس‌زمینهٔ تم/چیدمان را بازیابی نمایم؟**

بله. پرکردن سفارشی اسلاید را حذف کنید، و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/cpp/slide-layout/)/[master](/slides/fa/cpp/slide-master/) مربوطه (یعنی [theme background](/slides/fa/cpp/presentation-theme/)) به‌ارث می‌رسد.

**چه اتفاقی برای پس‌زمینه می‌افتد اگر بعداً تم ارائه را تغییر دهم؟**

اگر یک اسلاید پرکردن خود را داشته باشد، بدون تغییر می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/cpp/slide-layout/)/[master](/slides/fa/cpp/slide-master/) به‌ارث بریده باشد، برای مطابقت با [new theme](/slides/fa/cpp/presentation-theme/) به‌روز خواهد شد.