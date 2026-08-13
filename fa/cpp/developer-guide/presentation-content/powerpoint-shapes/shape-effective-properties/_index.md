---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در C++
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/cpp/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- سیستم نور
- شکل لبه‌دار
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر کردن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "با یادگیری نحوه استفاده از Aspose.Slides برای C++ برای تشخیص قالب‌بندی محلی، ارث‌بری و مؤثر اشکال در ارائه‌های PowerPoint."
---
## **درک مقادیر محلی، ارث‌بری و مؤثر**

قالب‌بندی PowerPoint می‌تواند از چند منبع مختلف بیاید. مقداری که مستقیماً بر روی یک شیء ذخیره می‌شود، **مقدار محلی** آن است. اگر آن مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد نگاه می‌کند، مانند پیش‌فرض پاراگراف، سبک متن، طرح‌بندی یا اسلاید اصلی، تم یا پیش‌فرض‌های سطح ارائه. این مقادیر **مقدارهای ارث‌بری** هستند. مقداری که پس از حل سراسری تمام سلسله‌مراتب باقی می‌ماند، **مقدار مؤثر** است — مقداری که برای رندر کردن شیء استفاده می‌شود.

به عنوان مثال، ممکن است یک بخش متن ارتفاع قلم خود را تعریف نکند. ارتفاع قلم محلی آن سپس [ارتفاع قلم](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/) برابر `std::numeric_limits<float>::quiet_NaN()` است که به معنای «در اینجا تنظیم نشده» است. این بخش می‌تواند ارتفاعی را از پاراگراف، سبک متن پیش‌فرض ارائه یا منبع قابل اعمال دیگری به ارث ببرد. فراخوانی [GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/) بر روی فرمت بخش، ارتفاع نهایی حل‌شده را بر می‌گرداند.

از دو نوع داده قالب‌بندی برای مقاصد مختلف استفاده کنید:

- یک شیء قالب‌بندی محلی را بخوانید یا تغییر دهید، مانند [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/)، زمانی که نیاز به کنترل مکان تعریف مقدار دارید.
- یک شیء داده مؤثر را بخوانید، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformateffectivedata/)، زمانی که به نتیجه نهایی و رندر شده نیاز دارید. داده‌های مؤثر فقط‑خواندنی هستند.

## **مقایسه مقادیر محلی، ارث‌بری و مؤثر**

مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع‌های قلم را در سطوح ارائه، پاراگراف و بخش اعمال می‌نماید. هر گام مقادیر تعریف‌شده در آن سطوح و مقدار مؤثر حاصل برای همان بخش متن را چاپ می‌کند. همچنین نشان می‌دهد چرا پس از تغییرات قالب‌بندی باید داده‌های مؤثر دوباره خوانده شوند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// مقادیر ارث‌بری را در دو سطح مختلف تعریف کنید.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // داده‌های مؤثر را پس از تغییرات قبلی بخوانید.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// یک مقدار محلی در بخش هر دو مقدار ارث‌بری را نادیده می‌گیرد.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// تغییر مقدار ارث‌بری، مقدار محلی موجود را نادیده نمی‌گیرد.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// مقدار محلی را پاک کنید. حالا بخش دوباره از پاراگراف ارث می‌برد.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// مقدار پاراگراف را پاک کنید. پیش‌فرض ارائه اکنون نتیجه را فراهم می‌کند.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

اولویت در این مثال قالب‌بندی محلی بخش، سپس قالب‌بندی پاراگراف و در نهایت پیش‌فرض ارائه است. اشیاء دیگر می‌توانند زنجیره ارث‌بری متفاوتی داشته باشند، اما اصل همان است: مقدار صریح و خاص‌تری برنده می‌شود و [GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/) نتیجه نهایی را بر می‌گرداند.

## **دریافت ویژگی‌های متن مؤثر**

قالب‌بندی متن در چند شیء تقسیم شده است:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/) ویژگی‌های فریم متن مانند حاشیه‌ها، تکیه‌گاه، خود‑پوشانی و جهت متن عمودی را حل می‌کند.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextstyle/) قالب‌بندی پاراگراف برای هر سطح سبک متن را حل می‌کند.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/) ویژگی‌های پاراگراف مانند تراز، تو رفتگی و علامت‌گذاری را حل می‌کند.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/) ویژگی‌های کاراکتر مانند ارتفاع قلم، نوع فونت، رنگ، بولد و ایتالیک را حل می‌کند.

برای مثال بعدی، `text-formatting.pptx` باید دست‌کم یک اسلاید و یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) با فریم متن غیرخالی داشته باشد. IAutoShape می‌تواند در هر موقعیتی از مجموعه شکل‌ها ظاهر شود؛ کد یک شیء مناسب را جستجو و قبل از استفاده اعتبارسنجی می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **دریافت ویژگی‌های سه‌بعدی مؤثر**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) یک شیء [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformateffectivedata/) بر می‌گرداند که تمام تنظیمات سه‌بعدی حل‌شده را گروه‌بندی می‌کند. داده‌های [دوربین](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icameraeffectivedata/)، [سیستم نور](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilightrigeffectivedata/)، [لبه بالا](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapebeveleffectivedata/) و [لبه پایین](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapebeveleffectivedata/) تنظیمات مؤثر متناظر را نشان می‌دهند. خواندن این تنظیمات مرتبط به‌صورت ترکیبی، درک ظاهر نهایی سه‌بعدی یک شکل را ساده‌تر می‌کند.

برای این مثال، `shape-3d.pptx` باید حداقل یک شکل در اسلاید اول خود داشته باشد. اگر می‌خواهید خروجی شامل مقادیری غیر از پیش‌فرض‌ها باشد، دوربین سه‌بعدی، نورپردازی یا تنظیمات لبه را به آن شکل اعمال کنید.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **دریافت قالب‌بندی جدول مؤثر**

قالب‌بندی جدول می‌تواند از سبک جدول و از قالب‌های اعمال‌شده به کل جدول، یک ستون، یک ردیف یا یک سلول فردی دریافت شود. در برخوردهای بین پر کردن‌های صریحاً تعریف‌شده، اولویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی استفاده‌شده برای رسم آن سلول است.

برای این مثال، `table-formatting.pptx` باید حداقل یک جدول در اسلاید اول خود داشته باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به‌جای فرض اینکه اولین شکل یک جدول است، به دنبال یک [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) می‌گردد.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

اگر به جای نوع پر کردن فقط رنگ نیاز دارید، ابتدا [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/) مؤثر را بررسی کنید، سپس ویژگی مربوط به آن نوع را بخوانید — برای مثال، [SolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/) برای پر کردن یکدست.

## **دوباره‌خواندن داده‌های مؤثر پس از تغییرات**

داده‌های مؤثر سلسله‌مراتب قالب‌بندی را در زمان حل توصیف می‌کنند. پس از تغییر هر چیزی که می‌تواند در آن سلسله‌مراتب شرکت کند، دوباره `GetEffective` را فراخوانی کنید، از جمله:

- قالب‌بندی محلی شیء؛
- پیش‌فرض‌های پاراگراف یا فریم متن؛
- قالب سبک جدول، جدول، ستون، ردیف یا سلول؛
- قالب‌بندی طرح‌بندی یا اسلاید اصلی؛
- داده‌های تم یا پیش‌فرض‌های سطح ارائه؛
- طرح‌بندی یا اسلاید اصلی اختصاص داده‌شده به یک اسلاید.

داده مؤثر را به‌عنوان یک تصویر ثابت نگه ندارید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی کش کند و فراخوانی بعدی `GetEffective` می‌تواند آن داده‌ها را تجدید کند. اگر نیاز به مقایسه مقادیر قبل و بعد از تغییر دارید، مقادیر اسکالر مورد نیاز خود — مانند ارتفاع قلم، رنگ، تراز یا عرض لبه — را قبل از اعمال تغییر در متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شیء قالب‌بندی محلی مناسب را به‌روزرسانی کنید و سپس `GetEffective` را فراخوانی کنید تا نتیجه را تأیید کنید. خود شیء داده‌های مؤثر فقط‑خواندنی هستند.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که کدام سطح مقدار مؤثر را فراهم کرده است؟**

داده‌های مؤثر فقط مقدار نهایی را در خود دارند، نه منبع آن. اشیاء محلی مربوطه را از سطح خاص‌ترین به سطح عمومی‌تر بررسی کنید. برای متن، این می‌تواند شامل بخش، پاراگراف، فریم متن، طرح‌بندی، اسلاید اصلی، تم و پیش‌فرض‌های ارائه باشد. مقادیر تعریف‌نشده مانند `std::numeric_limits<float>::quiet_NaN()` یا `nullptr` نشان می‌دهند که جستجو به سطح دیگری ادامه می‌یابد.

**اگر هیچ سطحی ویژگی‌ای را تعریف نکند چه می‌شود؟**

Aspose.Slides مقدار پیش‌فرض مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در داده مؤثر ظاهر می‌شود، حتی اگر هیچ شیء محلی به‌صراحت آن را تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر مقدار محلی می‌شود؟**

مقدار محلی محاسبهٔ ارث‌بری را برنده شده است. این رفتار زمانی رخ می‌دهد که ویژگی صریحاً بر روی شیء تنظیم شده و هیچ قانون خاص‌تری آن را بازنویسی نکرده باشد.

**چه زمانی باید به‌جای داده مؤثر از داده محلی استفاده کنم؟**

از داده محلی برای بررسی یا ویرایش سطح خاصی از قالب‌بندی استفاده کنید. از داده مؤثر وقتی که به ظاهر نهایی پس از اعمال ارث‌بری، قوانین تم و سبک‌های قابل اعمال نیاز دارید، استفاده کنید. مثال کامل مقایسه در بخش [مقایسه مقادیر محلی، ارث‌بری و مؤثر](#compare-local-inherited-and-effective-values) هر دو را در یک جریان کاری نشان می‌دهد.