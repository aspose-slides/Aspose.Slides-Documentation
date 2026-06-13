---
title: دریافت ویژگی‌های موثر شکل از ارائه‌ها در C++
linktitle: ویژگی‌های موثر
type: docs
weight: 50
url: /fa/cpp/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- شکل برجسته
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر کردن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides برای C++ ویژگی‌های موثر شکل را محاسبه و اعمال می‌کند تا نمایش دقیق PowerPoint فراهم شود."
---
## **بررسی کلی**

این موضوع تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی، مقادیری هستند که مستقیماً در سطح خاصی از قالب‌بندی تنظیم می‌شوند، مانند:

1. ویژگی‌های بخشی در یک اسلاید.
1. سبک‌های متن شکل الگو در یک طرح‌بندی یا اسلاید اصلی، هنگامی که شکل قاب متن بخش دارای آن باشد.
1. تنظیمات متنی سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. وقتی Aspose.Slides به قالب‌بندی نهایی «به صورت رندر شده» نیاز دارد، زنجیره ارث‌بری را حل می‌کند و مقادیر **موثر** را برمی‌گرداند. می‌توانید این مقادیر را با فراخوانی متد `GetEffective` بر روی شیء فرمت محلی دریافت کنید.

مثال زیر نشان می‌دهد چگونه مقادیر موثر را به دست آورید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) با یک قاب متن و حداقل یک بخش است.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
داده‌های قالب‌بندی موثر، نمایانگر قالب‌بندی محاسبه‌شده فعلی پس از اعمال ارث‌بری هستند. در پیاده‌سازی فعلی، برخی از اشیاء داده موثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformateffectivedata/)، ممکن است به صورت داخلی کش شوند. فراخوانی مجدد `GetEffective` پس از تغییر قالب‌بندی والد یا ارث‌بری می‌تواند داده‌های کش‌شده را تازه‌سازی کند و شیء قبلاً دریافت‌شده ممکن است دیگر نشانگر حالت قبلی نباشد. اگر نیاز به حفظ مقادیر موثر برای استفاده‌های بعدی دارید، ویژگی‌های مورد نیاز (مانند ارتفاع قلم، رنگ پر، سبک قلم یا تراز) را در شیء داده خود کپی کنید.
{{% /alert %}}

## **دریافت ویژگی‌های موثر دوربین**

Aspose.Slides به شما امکان دریافت ویژگی‌های موثر یک دوربین را می‌دهد. اینترفیس [ICameraEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icameraeffectivedata/) نمایانگر یک شیء غیرقابل تغییر است که ویژگی‌های موثر دوربین را شامل می‌شود. یک نمونه از [ICameraEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icameraeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformateffectivedata/) ارائه می‌شود که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) را فراهم می‌کند.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر دوربین را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3 بعدی باشد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **دریافت ویژگی‌های موثر چراغ روشن‌کننده**

Aspose.Slides به شما امکان دریافت ویژگی‌های موثر یک چراغ روشن‌کننده را می‌دهد. اینترفیس [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilightrigeffectivedata/) نمایانگر یک شیء غیرقابل تغییر است که ویژگی‌های موثر چراغ روشن‌کننده را شامل می‌شود. یک نمونه از [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilightrigeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformateffectivedata/) ارائه می‌شود که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) را فراهم می‌کند.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر چراغ روشن‌کننده را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3 بعدی باشد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **دریافت ویژگی‌های موثر برجستگی شکل**

Aspose.Slides به شما امکان دریافت ویژگی‌های موثر یک برجستگی شکل را می‌دهد. اینترفیس [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapebeveleffectivedata/) نمایانگر یک شیء غیرقابل تغییر است که ویژگی‌های موثر برجستگی برای یک شکل را شامل می‌شود. یک نمونه از [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapebeveleffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformateffectivedata/) ارائه می‌شود که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) را فراهم می‌کند.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر برجستگی بالایی یک شکل را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3 بعدی باشد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **دریافت ویژگی‌های موثر قاب متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های موثر یک قاب متن را دریافت کنید. اینترفیس [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformateffectivedata/) شامل ویژگی‌های قالب‌بندی موثر قاب متن است.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های قالب‌بندی موثر قاب متن را به دست آورید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) با یک قاب متن باشد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **دریافت ویژگی‌های موثر سبک متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های موثر یک سبک متن را دریافت کنید. اینترفیس [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextstyleeffectivedata/) شامل ویژگی‌های موثر سبک متن است.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر سبک متن را به دست آورید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) با یک قاب متن باشد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **دریافت مقدار ارتفاع قلم موثر**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم موثر را دریافت کنید. کد زیر نشان می‌دهد چگونه ارتفاع قلم موثر یک بخش پس از تنظیم مقادیر ارتفاع قلم محلی در سطوح مختلف ساختار ارائه تغییر می‌کند.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دریافت قالب پر کردن موثر برای جدول**

با استفاده از Aspose.Slides می‌توانید قالب پر کردن موثر برای بخش‌های مختلف جدول را دریافت کنید. اینترفیس [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/) شامل ویژگی‌های قالب پر کردن موثر است. قالب‌بندی سلول اولویت بالاتری نسبت به قالب‌بندی ردیف دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون اولویت دارد و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت دارد.

در نتیجه، ویژگی‌های [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icellformateffectivedata/) برای رسم سلول جدول استفاده می‌شوند. کد نمونه زیر نشان می‌دهد چگونه قالب پر کردن موثر برای بخش‌های مختلف جدول را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) باشد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **سوالات متداول**

**آیا `GetEffective` یک اسنپ‌شات برمی‌گرداند؟**

همیشه نیست. داده‌های موثر نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال ارث‌بری هستند، اما برخی از اشیاء داده موثر می‌توانند به صورت داخلی کش شوند. فراخوانی بعدی `GetEffective` ممکن است قالب‌بندی را مجدد محاسبه کند و داده‌های کش‌شده را تازه‌سازی نماید، بنابراین شیء قبلاً دریافت‌شده نباید به‌عنوان اسنپ‌شات دائمی در نظر گرفته شود.

**چه زمانی باید دوباره ویژگی‌های موثر را بخوانم؟**

بعد از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی طرح‌بندی، قالب‌بندی مستر یا پیش‌فرض‌های سطوح ارائه، `GetEffective` را دوباره صدا بزنید. فراخوانی بعدی سلسله‌مراتبی قالب‌بندی را باز ارزیابی کرده و نتیجهٔ موثر فعلی را برمی‌گرداند.

**آیا تغییر یا حذف یک اسلاید طرح‌بندی/مستر بر ویژگی‌های موثری که قبلاً بازیابی شده‌اند تأثیر می‌گذارد؟**

بله، اما این تغییر در فراخوانی بعدی `GetEffective` منعکس می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های موثر قبلاً دریافت‌شده ممکن است منسوخ شوند. پس از فراخوانی دوباره `GetEffective`، Aspose.Slides درخت قالب‌بندی را دوباره ارزیابی می‌کند و قلم‌ها، رنگ‌ها، اندازه‌ها یا سایر مقادیر ممکن است تغییر کنند.

**آیا می‌توانم مقادیر را از طریق اشیاء داده موثر تغییر دهم؟**

نه. اشیاء داده موثر فقط مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیاء قالب‌بندی محلی اعمال کنید و سپس مقادیر موثر را دوباره دریافت کنید.

**اگر یک ویژگی در سطح شکل، طرح‌بندی/مستر یا تنظیمات سراسری تنظیم نشده باشد چه می‌شود؟**

مقدار موثر توسط مکانیزم پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides است. آن مقدار حل‌شده بخشی از داده‌های موثر فعلی می‌شود.

**از یک مقدار فونت موثر، آیا می‌توانم تشخیص دهم کدام سطح اندازه یا نوع قلم را فراهم کرده است؟**

به‌صورت مستقیم نیست. داده‌های موثر مقدار نهایی را برمی‌گردانند. برای یافتن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متنی در سطوح طرح‌بندی، مستر و ارائه بررسی کنید تا اولین تعریف صریح را شناسایی کنید.

**چرا گاهی اوقات مقادیر موثر شبیه مقادیر محلی به نظر می‌رسند؟**

زیرا مقدار محلی در نهایت نهایی شده است (نیاز به ارث‌بری از سطوح بالاتر نداشته). در چنین مواردی، مقدار موثر با مقدار محلی مطابقت دارد.

**چه زمانی باید از ویژگی‌های موثر استفاده کنم و چه زمانی فقط با ویژگی‌های محلی کار کنم؟**

زمانی که به نتیجهٔ «به صورت رندر شده» پس از اعمال تمام ارث‌بری‌ها نیاز دارید (مثلاً برای هماهنگ‌سازی رنگ‌ها، تورفتگی‌ها یا اندازه‌ها) از داده‌های موثر استفاده کنید. اگر نیاز دارید این مقادیر را صرف‌نظر از تغییرات بعدی قالب‌بندی حفظ کنید، ویژگی‌های مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس، در صورت نیاز، داده‌های موثر را دوباره بخوانید تا نتیجه را تأیید کنید.