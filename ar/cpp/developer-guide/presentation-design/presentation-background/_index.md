---
title: إدارة خلفيات العروض التقديمية في C++
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/cpp/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية الصورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للغة C++، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، والتدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في آن واحد).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي—حتى إذا كان العرض يستخدم شريحة رئيسية. يتطبق التغيير فقط على الشريحة المحددة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) خلفية الشريحة إلى `Solid`.
4. استخدام طريقة [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) على [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

```cpp
// إنشاء كائن من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ضبط لون خلفية الشريحة إلى اللون الأزرق.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// حفظ العرض التقديمي إلى القرص.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **تعيين خلفية بلون صلب لشريحة رئيسية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة الرئيسة في عرض تقديمي. شريحة الرئيسة تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذلك عندما تختار لونًا صلبًا لخلفية شريحة الرئيسة، يتم تطبيقه على كل شريحة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) لشريحة الرئيسة (عبر `get_Masters`) إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) خلفية شريحة الرئيسة إلى `Solid`.
4. استخدام طريقة [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

```cpp
// إنشاء كائن من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// تعيين لون خلفية الشريحة الرئيسية إلى اللون الأخضر الغابي.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// حفظ العرض التقديمي إلى القرص.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يتم إنشاؤه بتغير تدريجي في اللون. عند استخدامه كخلفية للشرائح، يمكن للتدرجات أن تجعل العروض التقديمية تبدو أكثر فنية واحترافية. تتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) خلفية الشريحة إلى `Gradient`.
4. استخدام طريقة [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) على [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. حفظ العرض التقديمي المعدل.

```cpp
// إنشاء كائن من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// تطبيق تأثير تدرج على الخلفية.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// حفظ العرض التقديمي إلى القرص.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **تعيين صورة كخلفية لشريحة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، تتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. تعيين [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) خلفية الشريحة إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشفرة.
5. إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
6. استخدام طريقة [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) على [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض التقديمي المعدل.

```cpp
// إنشاء كائن من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ضبط خصائص صورة الخلفية.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// تحميل الصورة.
auto image = Images::FromFile(u"Tulips.jpg");
// إضافة الصورة إلى مجموعة صور العرض التقديمي.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// حفظ العرض التقديمي إلى القرص.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


يعرض مثال الشيفرة التالي كيفية تعيين نوع تعبئة الخلفية إلى صورة مكررة وتعديل خصائص التكرار:
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
اقرأ المزيد: [**صورة مكررة كملمس**](/slides/ar/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز أكثر. يوضح الكود التالي بلغة C++ كيفية تغيير الشفافية لصورة خلفية الشريحة:
```cpp
auto transparencyValue = 30; // على سبيل المثال.

// الحصول على مجموعة عمليات تحويل الصورة.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// العثور على تأثير شفافية ثابت النسبة المئوية موجود.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// تعيين قيمة الشفافية الجديدة.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```


## **الحصول على قيمة خلفية الشريحة**

توفر Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعلية لخلفية الشريحة. تكشف هذه الواجهة عن [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) و[EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) الفعليين.

باستخدام طريقة `get_Background` في الفئة [BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية لشريحة.

```cpp
// إنشاء مثيل من فئة Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// استرجاع الخلفية الفعالة مع مراعاة الشريحة الرئيسة، التخطيط، والسمة.
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


## **الأسئلة المتكررة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**

نعم. أزل التعبئة المخصصة للشريحة، وسيتم توريث الخلفية مرة أخرى من شريحة [التخطيط](/slides/ar/cpp/slide-layout/)/[الرئيسية](/slides/ar/cpp/slide-master/) المقابلة (أي [خلفية السمة](/slides/ar/cpp/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت سمة العرض التقديمي لاحقًا؟**

إذا كان للشفرة تعبئة خاصة به، فستبقى بدون تغيير. إذا كانت الخلفية مُتورَّثة من شريحة [التخطيط](/slides/ar/cpp/slide-layout/)/[الرئيسية](/slides/ar/cpp/slide-master/)، فستُحدَّث لتطابق [السمة الجديدة](/slides/ar/cpp/presentation-theme/).