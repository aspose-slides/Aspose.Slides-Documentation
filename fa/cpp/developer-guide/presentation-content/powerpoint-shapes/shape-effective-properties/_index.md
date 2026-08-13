---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در C++
linktitle: ویژگی‌های مؤثر
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
description: "کشف کنید که Aspose.Slides برای C++ چگونه ویژگی‌های مؤثر شکل را برای رندر دقیق PowerPoint محاسبه و اعمال می‌کند."
---
## **بررسی کلی**

این موضوع تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی، مقادیری هستند که مستقیماً در سطح خاصی از قالب‌بندی تنظیم می‌شوند، مانند:

1. ویژگی‌های بخش (portion) در یک اسلاید.  
1. سبک‌های متنی شکل نمونه (prototype) در یک طرح‌بندی یا اسلاید اصلی، زمانی که شکل قاب متن بخش دارای آن باشد.  
1. تنظیمات متن سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. وقتی Aspose.Slides به قالب‌بندی نهایی «همان‌گونه که رندر می‌شود» نیاز دارد، زنجیره ارث‌بری را حل می‌کند و مقادیر **موثر** را برمی‌گرداند. می‌توانید با صدا زدن متد `GetEffective` بر روی شیء قالب‌بندی محلی، این مقادیر را دریافت کنید.

مثال زیر نشان می‌دهد چگونه مقادیر موثر را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) با یک قاب متن و حداقل یک بخش باشد.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
داده‌های قالب‌بندی مؤثر، نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال ارث‌بری هستند. در پیاده‌سازی فعلی، برخی از اشیای داده مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformateffectivedata/)، ممکن است به‌صورت داخلی کش شوند. صدا زدن دوبارهٔ `GetEffective` پس از تغییر قالب‌بندی والد یا ارث‌بری می‌تواند کش را تازه‌سازی کند و شیء قبلاً به‌دست‌آمده ممکن است دیگر وضعیت قبلی را نشان ندهد. اگر نیاز دارید مقادیر مؤثر را برای استفادهٔ بعدی حفظ کنید، ویژگی‌های مورد نیاز (مانند ارتفاع قلم، رنگ پر، سبک قلم یا alignment) را در شیء دادهٔ خود کپی کنید.
{{% /alert %}}

## **دریافت ویژگی‌های مؤثر یک دوربین**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک دوربین را دریافت کنید. رابط [ICameraEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icameraeffectivedata/) یک شیء غیرقابل تغییر را نشان می‌دهد که شامل ویژگی‌های مؤثر دوربین است. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icameraeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformateffectivedata/) در دسترس است که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) را ارائه می‌دهد.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر برای دوربین را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

## **دریافت ویژگی‌های مؤثر یک نورپردازی (Light Rig)**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک نورپردازی را دریافت کنید. رابط [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilightrigeffectivedata/) یک شیء غیرقابل تغییر را نشان می‌دهد که شامل ویژگی‌های مؤثر نورپردازی است. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilightrigeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformateffectivedata/) در دسترس است که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) را ارائه می‌دهد.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر برای نورپردازی را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

## **دریافت ویژگی‌های مؤثر یک برجستگی (Bevel) شکل**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک برجستگی شکل را دریافت کنید. رابط [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapebeveleffectivedata/) یک شیء غیرقابل تغییر را نشان می‌دهد که شامل ویژگی‌های مؤثر برجستگی برای یک شکل است. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapebeveleffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformateffectivedata/) در دسترس است که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) را ارائه می‌دهد.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر برای برجستگی بالایی یک شکل را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

## **دریافت ویژگی‌های مؤثر یک قاب متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک قاب متن را دریافت کنید. رابط [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformateffectivedata/) شامل ویژگی‌های مؤثر قالب‌بندی قاب متن است.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر قالب‌بندی قاب متن را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) با یک قاب متن باشد.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

## **دریافت ویژگی‌های مؤثر یک سبک متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک سبک متن را دریافت کنید. رابط [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextstyleeffectivedata/) شامل ویژگی‌های مؤثر سبک متن است.

کد نمونهٔ زیر نشان می‌دهد چگونه ویژگی‌های مؤثر سبک متن را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) با یک قاب متن باشد.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

## **دریافت مقدار مؤثر ارتفاع قلم**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم مؤثر را دریافت کنید. کد زیر نشان می‌دهد چگونه ارتفاع قلم مؤثر یک بخش پس از تنظیم مقادیر محلی ارتفاع قلم در سطوح مختلف ساختار ارائه تغییر می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **دریافت قالب‌بندی پر کردن مؤثر برای یک جدول**

با استفاده از Aspose.Slides می‌توانید قالب‌بندی پر کردن مؤثر برای بخش‌های مختلف جدول را دریافت کنید. رابط [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/) شامل ویژگی‌های قالب‌بندی پر کردن مؤثر است. قالب‌بندی سلول اولویت بالاتری نسبت به قالب‌بندی ردیف دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون ترجیح دارد و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت دارد.

در نتیجه، ویژگی‌های [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icellformateffectivedata/) برای رسم سلول جدول استفاده می‌شوند. کد نمونهٔ زیر نشان می‌دهد چگونه قالب‌بندی پر کردن مؤثر برای بخش‌های مختلف جدول را دریافت کنیم. فرض می‌شود اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) باشد.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

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

### آیا `GetEffective` یک اسنپ‌شات برمی‌گرداند؟

همیشه نه. داده‌های مؤثر نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال ارث‌بری هستند، اما برخی از اشیای داده مؤثر ممکن است به‌صورت داخلی کش شوند. یک فراخوانی بعدی `GetEffective` ممکن است قالب‌بندی را دوباره محاسبه کند و داده‌های کش‌شده را تازه‌سازی کند، بنابراین شیء قبلاً به‌دست‌آمده نباید به‌عنوان یک اسنپ‌شات پایدار محسوب شود.

### چه زمانی باید دوباره ویژگی‌های مؤثر را بخوانم؟

بعد از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی طرح‌بندی، قالب‌بندی اصلی یا پیش‌فرض‌های سطح ارائه، `GetEffective` را دوباره صدا بزنید. فراخوانی بعدی سلسله‌مراتبی قالب‌بندی را بازنگری می‌کند و نتیجهٔ مؤثر فعلی را برمی‌گرداند.

### آیا تغییر یا حذف یک اسلاید طرح‌بندی/اصلی بر ویژگی‌های مؤثری که قبلاً دریافت شده‌اند تأثیر می‌گذارد؟

بله، اما تغییر در فراخوانی بعدی `GetEffective` منعکس می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های مؤثر قبلاً به‌دست‌آمده ممکن است منسوخ شوند. پس از صدا زدن دوباره `GetEffective`، Aspose.Slides درخت قالب‌بندی را دوباره ارزیابی می‌کند و فونت‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر ممکن است تغییر کنند.

### آیا می‌توانم مقادیر را از طریق اشیای داده مؤثر اصلاح کنم؟

نه. اشیای داده مؤثر فقط مقادیر محاسبه‌شده را نشان می‌دهند. برای تغییر، در اشیای قالب‌بندی محلی تغییرات را اعمال کنید و سپس مقادیر مؤثر را دوباره دریافت کنید.

### اگر یک ویژگی در سطح شکل، طرح‌بندی/اصلی یا تنظیمات سراسری تنظیم نشده باشد چه می‌شود؟

مقدار مؤثر توسط سازوکار پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides است. آن مقدار حل‌شده بخشی از دادهٔ مؤثر جاری می‌شود.

### از یک مقدار فونت مؤثر، آیا می‌توانم بفهمم که کدام سطح اندازه یا نوع‌face را فراهم کرده است؟

به‌طور مستقیم نه. داده‌های مؤثر مقدار نهایی را برمی‌گردانند. برای پیدا کردن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متن در سطوح طرح‌بندی، اصلی و ارائه بررسی کنید تا اولین تعریف صریح را شناسایی کنید.

### چرا گاهی مقادیر مؤثر شبیه به مقادیر محلی به نظر می‌رسند؟

چون مقدار محلی در نهایت نهایی شده (نیازی به ارث‌بری از سطح بالاتر نبود). در چنین مواردی مقدار مؤثر با مقدار محلی مطابقت دارد.

### چه وقت باید از ویژگی‌های مؤثر استفاده کنم و چه وقت فقط با ویژگی‌های محلی کار کنم؟

وقتی به نتیجهٔ «همان‌گونه که رندر می‌شود» پس از اعمال تمام ارث‌بری‌ها نیاز دارید (مثلاً برای هم‌ساز کردن رنگ‌ها، تورفتگی‌ها یا اندازه‌ها)، از داده‌های مؤثر استفاده کنید. اگر می‌خواهید این مقادیر را صرف‌نظر از تغییرات بعدی قالب‌بندی حفظ کنید، ویژگی‌های مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس در صورت نیاز داده‌های مؤثر را دوباره بخوانید تا نتیجهٔ نهایی را تأیید کنید.