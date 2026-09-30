---
title: مدیریت جداول ارائه در C++
linktitle: مدیریت جدول
type: docs
weight: 10
url: /fa/cpp/manage-table/
keywords:
- افزودن جدول
- ایجاد جدول
- دسترسی به جدول
- نسبت ابعاد
- تراز متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای C++. نمونه‌های کد ساده‌ای را کشف کنید تا جریان کار جداول خود را بهینه کنید."
---
## **مقدمه**

جدول‌ها در PowerPoint اطلاعات را در ردیف‌ها و ستون‌ها سازماندهی می‌کنند و خواندن و مقایسه مقادیر را آسان‌تر می‌سازند.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) ، اینترفیس [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ، کلاس [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) ، اینترفیس [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) و انواع دیگر را فراهم می‌کند تا بتوانید جدول‌ها را در ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید.

## **ایجاد یک جدول از ابتدا**

یک جدول را با تعیین موقعیت، عرض ستون‌ها و ارتفاع ردیف‌ها ایجاد کنید. پس از افزودن آن به یک اسلاید، می‌توانید حاشیه‌های سلول‌ها را قالب‌بندی کنید، سلول‌ها را ادغام کنید و متن وارد کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
2. یک ارجاع به اسلاید را بر اساس ایندکس آن دریافت کنید.
3. یک آرایه از عرض ستون‌ها بر حسب پوینت تعریف کنید.
4. یک آرایه از ارتفاع ردیف‌ها بر حسب پوینت تعریف کنید.
5. یک شیء [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) را با استفاده از متد [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) به اسلاید اضافه کنید.
6. از هر [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) عبور کنید تا قالب‌بندی حاشیه‌های بالا، پایین، راست و چپ را اعمال کنید.
7. دو سلول اول ردیف اول جدول را ادغام کنید.
8. از سلول ادغام شده از طریق متد [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) دسترسی پیدا کنید.
9. متن را در سلول ادغام شده تنظیم کنید.
10. ارائه تغییر یافته را ذخیره کنید.

مثال زیر یک جدول با سه ستون و پنج ردیف در موقعیت (100, 50) پوینت ایجاد می‌کند. حاشیه‌های قرمز با عرض 5 پوینت اعمال می‌شود، دو سلول اول ردیف اول ادغام می‌شود و نتیجه به صورت `table.pptx` ذخیره می‌شود.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **شماره‌گذاری در یک جدول استاندارد**

در یک جدول استاندارد، شاخص‌های سلول صفر مبنا هستند و به ترتیب (ستون، ردیف) استفاده می‌شوند. اولین سلول با (0, 0) شماره‌گذاری می‌شود.

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این صورت شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این مثال جدول 4 × 4 نشان‌داده‌شده در بالا را با عرض ستون‌ها و ارتفاع ردیف‌ها برابر 70 پوینت و حاشیه‌های سلول قرمز با عرض 5 پوینت ایجاد می‌کند. مختصات شاخص‌های سلول را نشان می‌دهند؛ مثال سلول‌ها را خالی می‌گذارد و جدول را به صورت `StandardTables_out.pptx` ذخیره می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **دسترسی به یک جدول موجود**

جدول‌ها در مجموعه شکل‌های اسلاید ذخیره می‌شوند. از اشکال عبور کنید تا یک جدول را پیدا کنید، سپس از اینترفیس [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) برای خواندن یا به‌روزرسانی سلول‌های آن استفاده کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) بارگیری کنید.
2. یک ارجاع به اسلاید حاوی جدول را بر اساس ایندکس آن دریافت کنید.
3. از اشیای [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) عبور کنید و زمانی که جدول یافت شد متوقف شوید. اگر اسلاید چندین جدول داشته باشد، از [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) برای شناسایی جدول مورد نیاز استفاده کنید.
4. متن در سلول هدف را به‌روز کنید.
5. ارائه تغییر یافته را ذخیره کنید.

مثال زیر فایل `UpdateExistingTable.pptx` را باز می‌کند و اولین جدول در اولین اسلاید را پیدا می‌کند. سلول در ستون 0، ردیف 1 را به `New` تنظیم می‌کند و نتیجه را به صورت `table1_out.pptx` ذخیره می‌کند. ورودی باید حداقل یک اسلاید داشته باشد و اولین جدول در آن اسلاید باید حداقل یک ستون و دو ردیف داشته باشد.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

برای تغییر اندازه یک ردیف در جدول موجود و درک اینکه چرا ارتفاع واقعی آن می‌تواند از حداقل درخواست‌شده بیشتر باشد، به [کنترل ارتفاع ردیف](/slides/fa/cpp/manage-rows-and-columns/#control-row-height) مراجعه کنید.

## **یافتن سلولی که چارچوب متن را مالک است**

هنگامی که کد عمومی پردازش متن یک [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) را از یک جدول دریافت می‌کند، از [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) برای بازیابی [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) مالک استفاده کنید. برای چارچوب متن سلول جدول، [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) مالک را برمی‌گرداند و [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr` می‌دهد، حتی اگر جدول به عنوان یک شکل باشد.

مختصات سلول از طریق متدهای فقط‑خواندنی [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) و [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) در دسترس است. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) همچنین ناوبری فقط‑خواندنی را فراهم می‌کند: مالک را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. همیشه قبل از استفاده، سلول برگشتی را برای `nullptr` بررسی کنید.

برای مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله شکل‌های مرتبط با گره‌های SmartArt، به [جستجو و جایگذاری متن](/slides/fa/cpp/search-and-replace-text/) مراجعه کنید.

## **تراز کردن متن در جدول**

می‌توانید لنگرنگی عمودی و جهت متن سلول‌های فردی جدول را کنترل کنید. مثال در این بخش متن را در اولین سلول وسط‌چین می‌کند و به اندازه 270 درجه می‌چرخاند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
2. یک ارجاع به اسلاید را بر اساس ایندکس آن دریافت کنید.
3. یک شیء [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) را به اسلاید اضافه کنید.
4. از جدول یک شیء [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) دریافت کنید.
5. اولین [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) را دریافت کنید و متن و رنگ آن را تنظیم کنید.
6. با استفاده از [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) و [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) لنگرنگی عمودی سلول و جهت متن را تنظیم کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این مثال جدول 4 × 4 با عرض ستون‌های 120 پوینت و ارتفاع ردیف‌های 100 پوینت ایجاد می‌کند. متن در سلول (0, 0) قالب‌بندی می‌شود، مقادیر به سلول‌های باقی‌مانده در ردیف اول افزوده می‌شود و نتیجه به صورت `Vertical_Align_Text_out.pptx` ذخیره می‌شود.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **تنظیم قالب‌بندی متن در سطح جدول**

از [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) برای اعمال قالب‌بندی متن به همه سلول‌های یک جدول استفاده کنید. بارگذاری‌های آن می‌توانند قالب‌بندی بخش، پاراگراف و چارچوب متن را بپذیرند، بنابراین می‌توانید این ویژگی‌ها را بدون عبور از سلول‌های فردی تنظیم کنید.

1. ارائه را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) بارگیری کنید.
2. یک ارجاع به اسلاید را بر اساس ایندکس آن دریافت کنید.
3. از اسلاید یک شیء [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) دریافت کنید.
4. برای متن اندازه قلم را با استفاده از [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) تنظیم کنید.
5. تراز پاراگراف و حاشیه راست را با استفاده از [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) تنظیم کنید.
6. جهت متن را با استفاده از [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) تنظیم کنید.
7. ارائه تغییر یافته را ذخیره کنید.

مثال زیر فایل `table.pptx` را باز می‌کند که باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. اندازه قلم را به 25 پوینت تنظیم می‌کند، پاراگراف‌ها را راست‌تراز و حاشیه راست را 20 پوینت می‌کند و متن را عمودی می‌سازد. ارائه قالب‌بندی شده به صورت `result.pptx` ذخیره می‌شود.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

از [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) برای خواندن سبک پیش‌تنظیم‌شده جدول و از [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) برای اختصاص آن استفاده کنید. این مثال [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) را به یک جدول اعمال می‌کند، نام پیش‌تنظیم را چاپ می‌کند و همان پیش‌تنظیم را به جدول دوم اختصاص می‌دهد. هر دو جدول در `table-style.pptx` ذخیره می‌شوند.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **قفل کردن نسبت ابعاد جدول**

نسبت ابعاد یک جدول، نسبت عرض آن به ارتفاعش است. از [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) برای قفل کردن این نسبت برای یک جدول استفاده کنید.

مثال زیر فایل `pres.pptx` را باز می‌کند که باید حداقل یک اسلاید با جدول به عنوان اولین شکل داشته باشد. وضعیت قفل فعلی را چاپ می‌کند، قفل نسبت ابعاد را فعال می‌سازد، وضعیت به‌روز شده (`True`) را چاپ می‌کند و نتیجه را به صورت `pres-out.pptx` ذخیره می‌کند.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **سؤالات متداول**

**آیا می‌توانم جهت خواندن راست به چپ (RTL) را برای یک جدول کامل و متن داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) را فراهم می‌کند و پاراگراف‌ها متد [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) دارند. استفاده از هر دو اطمینان می‌دهد که ترتیب RTL صحیح است و رندرینگ داخل سلول‌ها به درستی انجام می‌شود.

**چگونه می‌توانم کاربران را از جابه‌جایی یا تغییر اندازه جدول در فایل نهایی منع کنم؟**

از [قفل‌های شکل](/slides/fa/cpp/applying-protection-to-presentation/) برای غیرفعال‌سازی جابه‌جایی، تغییر اندازه، انتخاب و غیره استفاده کنید. این قفل‌ها بر روی جدول‌ها نیز اعمال می‌شوند.

**آیا قرار دادن تصویر به‌عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) تنظیم کنید؛ تصویر بر حسب حالت انتخابی (کشیده یا کاشی) ناحیه سلول را پوشش می‌دهد.