---
title: مدیریت سلول‌های جدول در ارائه‌ها با C++
linktitle: مدیریت سلول‌ها
type: docs
weight: 30
url: /fa/cpp/manage-cells/
keywords:
- سلول جدول
- ادغام سلول‌ها
- حذف حاشیه
- تقسیم سلول
- تصویر در سلول
- رنگ پس‌زمینه
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "مدیریت سلول‌های جدول PowerPoint در C++: شناسایی سلول‌های ترکیب‌شده، حذف حاشیه‌ها، تقسیم سلول‌ها و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای C++."
---
## **نمای کلی**

Aspose.Slides به شما امکان دسترسی و ویرایش سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد که چگونه سلول‌های جدول ترکیب‌شده را شناسایی کنید، حاشیه‌های سلول را حذف کنید، پس از ترکیب یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و تصویری را داخل یک سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق خواص سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

Aspose.Slides از ایندکس‌های صفر‑مبنای برای دسترسی به سلول‌های جدول به ترتیب `(ستون، ردیف)` استفاده می‌کند.

## **شناسایی یک سلول جدول ترکیب‌شده**

مثال یک ارائه موجود را باز می‌کند و شکل اول در اسلاید اول را به‌عنوان جدول دسترسی می‌یابد. فرض می‌شود که اسلاید و شکل وجود دارند و شکل یک جدول است. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) برای شناسایی سلول‌های در نواحی ترکیب‌شده استفاده می‌کند. برای هر تطبیق، مختصات سلول را به ترتیب `row;column` چاپ می‌کند، [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)، [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)، و مختصات شروع ناحیه را با [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) و [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) نمایش می‌دهد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **حذف حاشیه‌های سلول جدول**

یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید و یک جدول را به اسلاید اول آن با [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول بر حسب نقطه مشخص می‌شوند. مثال تمام چهار حاشیه سلول را به [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **افزودن حاشیه‌های مورب سلول**

از [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) برای کشیدن خطی از گوشه بالا‑چپ به پایین‑راست و از [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) برای کشیدن خطی از گوشه پایین‑چپ به بالا‑راست استفاده کنید. یک قطر می‌تواند سرعنوان گوشه‌ای را نشان دهد؛ هر دو قطر می‌توانند یک X شکل دهند تا سلول را به عنوان غیرقابل اعمال نشان دهند.

هر قطر یک [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/) است. از [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) برای دسترسی به پرکننده آن استفاده کنید، سپس با [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) مقدار [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) را تنظیم کرده و رنگ را از طریق [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/) انتخاب کنید. عرض خط را با [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) به نقطه تنظیم کنید.

مثال سه سلول در یک ردیف ایجاد می‌کند: یک قطر پایین‌روند قرمز، یک قطر بالاروند آبی، و هر دو قطر. حاشیه‌های بالا، پایین، چپ و راست سلول دست نخورده باقی می‌مانند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

یک قطر یک ویژگی قالب‌بندی است، نه تقسیم سلول. هر سلول یک چارچوب متن واحد دارد که از طریق [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) دسترسی می‌شود؛ نواحی هر دو سمت یک قطر نمی‌توانند به‌صورت مستقل ویرایش شوند.

جدولی که ذخیره شده و در Microsoft PowerPoint رندر می‌شود:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*از چپ به راست: قطر پایین‌روند (قرمز، 3 pt)، قطر بالاروند (آبی، 5 pt) و هر دو قطر.*

## **ادغام سلول‌های جدول**

از [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشهٔ بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی تعیین می‌کند که آیا ادغام می‌تواند شامل سلول‌های خارج از بازه مشخص شده باشد؛ `false` ادغام را در همان بازه نگه می‌دارد.

مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70‑نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ادغام می‌کند. سلول حاصل دو ستون و دو ردیف را در بر می‌گیرد، در حالی که شبکهٔ زیرین جدول همچنان چهار ستون و چهار ردیف دارد. برای دسترسی به محتوای یا قالب‌بندی سلول ترکیب‌شده، از موقعیت گوشهٔ بالا‑چپ آن استفاده کنید: `table->idx_get(1, 1)` در این مثال. سایر موقعیت‌های بازهٔ ترکیب‌شده همچنان بخشی از شبکه جدول هستند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **تقسیم سلول‌های جدول**

ادغام سلول‌ها در مثال قبلی ساختار شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و ایندکس‌های ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکه جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول 4×4 با ستون‌ها و ردیف‌های 70‑نقطه‌ای ایجاد می‌کند و بر روی سلول `(1, 1)` متد [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) را فرا می‌خواند. نصف عرض 70‑نقطه‌ای سلول به‌منظور ایجاد دو سلول با عرض مساوی پاس داده می‌شود.

پس از این تقسیم، دو نیمه به صورت `table->idx_get(1, 1)` و `table->idx_get(2, 1)` قابل دسترسی‌اند. شبکه جدول حالا پنج ستون دارد: سلول‌هایOriginally در ستون‌های 2 و 3 به ستون‌های 3 و 4 منتقل می‌شوند. ایندکس‌های ردیف بدون تغییر می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این ایندکس‌های به‌روزرسانی‌شده استفاده کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

<!-- visual-explanation:manage-cells:start -->
[![یک سلول 70‑نقطه‌ای که ترکیب نشده به دو سلول 35‑نقطه‌ای تقسیم می‌شود، یک ستون پنجم به شبکه اضافه می‌کند و ایندکس‌های سمت راست آن را جابه‌جا می‌کند.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسیم عرض بر سلول (1, 1) تأثیر می‌گذارد، با استفاده از ایندکس‌های صفر‑مبنای (ستون، ردیف). سایر ردیف‌ها یک سلول دارند که هر دو موقعیت ستون جدید را پوشش می‌دهد.*
<!-- visual-explanation:manage-cells:end -->

### **تقسیم سلول‌های ترکیب‌شده بر اساس گستره ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ترکیب‌شده برای پر کردن داده‌ها، از [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) برای تقسیم بر مبنای مرز ردیفی موجود، یا از [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) برای تقسیم بر مبنای مرز ستونی استفاده کنید.

آرگومان `index` تعداد ردیف‌ها در بخش بالایی یا ستون‌ها در بخش چپ تقسیم را می‌شمارد؛ نسبی به منطقه ترکیب‌شده است:

- تقسیم ردیف: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- تقسیم ستون: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

مثال انتظار دارد که ارائه‌ای دارای جدولی به‌عنوان اولین شکل در اولین اسلاید داشته باشد، به‌طوری که سلول‌های `(1, 2)` و `(1, 3)` به‌صورت عمودی ترکیب شده باشند. از موقعیت پایین شروع می‌کند، با استفاده از [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) و [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) مبدأ را پیدا می‌کند و هر دو گستره را بررسی می‌نماید. `SplitByRowSpan(1)` سپس ردیف‌های 2 و 3 را برای نام محصولات جدا می‌کند. برای یک ترکیب افقی دو ستونی، به‌جای آن از `SplitByColSpan(1)` استفاده کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // سلول‌های به دست آمده را پس از تقسیم از جدول بازیابی کنید.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

شبکه جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را بر حسب مختصاتشان بازیابی کنید؛ در اینجا هر دو دارای گستره 1 هستند و [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) مقدار `False` را برمی‌گرداند. نواحی بزرگ‌تر می‌توانند پس از یک تقسیم بخشی ترکیب‌شده بمانند.

متن اصلی و قالب‌بندی آن در سلول بالایی (یا چپ) باقی می‌مانند؛ سلول جدید خالی است اما قالب‌بندی سلول مانند پرکننده، حاشیه‌ها و حاشیه داخلی را به ارث می‌برد. پس از تقسیم سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را به‌صورت صریح تنظیم کنید.

ارائهٔ ذخیره‌شده شامل سلول‌های جداگانهٔ «Product A» و «Product B» است که قالب‌بندی سلول قالب حفظ شده است. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) مراجعه کنید.

### **تقسیم یک سلول به ارتفاع مشخص**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) ارتفاع بخش بالایی را بر حسب نقطه می‌گیرد. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) تعداد ردیف‌های موجود در بخش بالایی را می‌گیرد. برای مرکز کردن یک سلول 40‑نقطه‌ای در ستون سمت راست، 40 را از ارتفاع واقعی سلول کم کنید و فضای باقی‌مانده را به‌صورت مساوی بالای و پایین آن تقسیم کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

تقسیم اول یک ردیف شبکه اضافه می‌کند و 90‑نقطه پایین را در `(1, 1)` باقی می‌گذارد. تقسیم دوم همان سلول را هدف گرفته و ردیف دیگری زیر آن اضافه می‌کند. ستون سمت راست اکنون شامل `(1, 0)` با 50 نقطه (`margin`) ، `(1, 1)` با 40 نقطه و `(1, 2)` با 50 نقطه (`margin`) است. سلول چپ تمام سه ردیف را با ارتفاع اصلی 140 نقطه پوشش می‌دهد.

![سلول سمت چپ تمام ارتفاع جدول را در کنار سه سلول با متن Middle در مرکز می‌پوشاند.](split-by-height.png)

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال یک جدول با ستون‌های 150‑نقطه‌ای و ردیف‌های 50‑نقطه‌ای ایجاد می‌کند. از [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) برای انتخاب پرکنندهٔ ثابت و از [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) برای دسترسی به رنگ پرکننده استفاده می‌کند و آن را برای سلول `(2, 3)` که در ستون سوم و ردیف چهارم قرار دارد، به رنگ قرمز تنظیم می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **افزودن تصویر داخل یک سلول جدول**

قبل از اجرای این مثال، تصویر ورودی را در پوشهٔ کاری قرار دهید. تصویر را با [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) بارگذاری می‌کند و با [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) به مجموعهٔ تصاویر ارائه اضافه می‌کند. سپس تصویر را به پرکنندهٔ تصویری سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌دهد.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کش می‌دهد، که ممکن است نسبت تصویر را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها بر حسب نقطه است. پس از افزودن به ارائه تصویر بارگذاری‌شده آزاد (disposed) می‌شود.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**آیا می‌توانم ضخامت‌ها و سبک‌های خط متفاوتی برای هر یک از چهار طرف یک سلول تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) دارای ویژگی‌های جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینهٔ سلول، اندازهٔ ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بسته به [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) متفاوت است. در حالت کشش، تصویر با سلول جدید تنظیم می‌شود؛ در حالت کاشی، کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم یک پیوند (hyperlink) را به تمام محتوای یک سلول اختصاص دهم؟**

[Hyperlinks](/slides/fa/cpp/manage-hyperlinks/) در سطح بخشی از متن داخل چارچوب متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، پیوند را به یک بخش یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی را داخل یک سلول تنظیم کنم؟**

بله. چارچوب متن یک سلول از [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل — خانوادهٔ فونت، سبک، اندازه و رنگ — پشتیبانی می‌کند.