---
title: مدیریت سلول‌های جدول در ارائه‌ها با استفاده از C++
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
description: "مدیریت سلول‌های جدول PowerPoint در C++: شناسایی سلول‌های ترکیبی، حذف حاشیه‌ها، تقسیم سلول‌ها و تنظیم رنگ‌های پس‌زمینه و تصاویر با Aspose.Slides برای C++."
---
## **نمای کلی**

Aspose.Slides به شما امکان دسترسی و تغییر سلول‌های جدول در ارائه‌های PowerPoint را می‌دهد. این مقاله توضیح می‌دهد که چگونه سلول‌های ترکیبی جدول را شناسایی کنید، حاشیه‌های سلول را حذف کنید، پس از ترکیب یا تقسیم سلول‌ها با شماره‌گذاری سلول کار کنید، رنگ پس‌زمینه یک سلول را تغییر دهید و یک تصویر را داخل سلول جدول اضافه کنید. مثال‌ها نشان می‌دهند که چگونه یک ارائه را ایجاد یا باز کنید، جدول را از یک اسلاید دریافت کنید، قالب‌بندی سلول را از طریق ویژگی‌های سلول به‌روزرسانی کنید و ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره نمایید.

Aspose.Slides برای دسترسی به سلول‌های جدول از ایندکس‌های صفر مبنا به ترتیب `(ستون، ردیف)` استفاده می‌کند.

## **تشخیص سلول ترکیبی جدول**

مثال یک ارائه موجود را باز می‌کند و اولین شکل در اولین اسلاید را به‌عنوان جدول دسترسی می‌دهد. فرض می‌شود که اسلاید و شکل وجود دارند و شکل یک جدول است. سپس تمام ردیف‌ها و ستون‌ها را پیمایش می‌کند و از [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) برای شناسایی سلول‌های موجود در نواحی ترکیبی استفاده می‌کند. برای هر مطابقت، مختصات سلول را به ترتیب `row;column`، [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)، [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)، و مختصات شروع ناحیه، [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) و [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) چاپ می‌کند.

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

یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید و با استفاده از [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) یک جدول به اولین اسلاید آن اضافه کنید. عرض ستون‌ها، ارتفاع ردیف‌ها و موقعیت جدول برحسب نقطه (point) مشخص می‌شوند. مثال تمام چهار حاشیه سلول را به [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) تنظیم می‌کند تا نامرئی شوند.

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

## **ترکیب سلول‌های جدول**

از [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) برای ترکیب یک بازه مستطیلی از سلول‌های جدول به یک سلول استفاده کنید. سلول‌های گوشه بالا‑چپ و پایین‑راست بازه را مشخص کنید. آرگومان نهایی کنترل می‌کند که آیا ترکیب می‌تواند شامل سلول‌های خارج از بازه مشخص‌شده باشد؛ `false` ترکیب را در همان بازه نگه می‌دارد.

مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰‑نقطه‌ای ایجاد می‌کند، سپس چهار سلول مرکزی را از `(1, 1)` تا `(2, 2)` ترکیب می‌نماید. سلول حاصل دو ستون و دو ردیف را می‌پوشاند، در حالی که شبکه زیرین جدول همچنان چهار ستون و چهار ردیف را حفظ می‌کند. برای دسترسی به محتوای یا قالب‌بندی سلول ترکیبی، از موقعیت بالا‑چپ آن استفاده کنید: `table->idx_get(1, 1)` در این مثال. سایر موقعیت‌های موجود در بازه ترکیبی همچنان بخشی از شبکه جدول می‌باشند، بنابراین ایندکس‌های سلول‌های خارج از بازه تغییر نمی‌کنند.

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

ترکیب سلول‌ها در مثال قبلی شبکه جدول را حفظ می‌کند. تقسیم یک سلول می‌تواند یک ستون جدید به شبکه اضافه کند و ایندکس ستون‌های سمت راست آن را تغییر دهد. Aspose.Slides مدل شبکه جدول PowerPoint را دنبال می‌کند.

این مثال یک جدول ۴×۴ با ستون‌ها و ردیف‌های ۷۰‑نقطه‌ای ایجاد می‌کند و بر روی سلول `(1, 1)` متد [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) را فراخوانی می‌کند. نیمی از عرض ۷۰‑نقطه‌ای سلول به‌منظور ایجاد دو سلول با عرض مساوی ارسال می‌شود.

پس از این تقسیم، دو نصف به‌صورت `table->idx_get(1, 1)` و `table->idx_get(2, 1)` قابل دسترسی هستند. شبکه جدول اکنون پنج ستون دارد: سلول‌های قبلاً در ستون‌های ۲ و ۳ به ترتیب به ستون‌های ۳ و ۴ منتقل می‌شوند. ایندکس ردیف‌ها بدون تغییر باقی می‌مانند. هنگام دسترسی به سلول‌ها پس از تقسیم، از این ایندکس‌های به‌روز شده ستون استفاده کنید.

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

### **تقسیم سلول‌های ترکیبی بر حسب گستردگی ردیف یا ستون**

برای آماده‌سازی سلول‌های قالب ترکیبی جهت پر کردن داده، از [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) برای تقسیم بر حسب مرز ردیف موجود یا از [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) برای تقسیم بر حسب مرز ستون استفاده کنید.

آرگومان `index` ردیف‌های بخش بالایی یا ستون‌های بخش چپ تقسیم را می‌شمرد؛ این مقدار نسبت به ناحیه ترکیبی است:

- تقسیم ردیفی: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- تقسیم ستونی: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

مثال فرض می‌کند ارائه دارای یک جدول به‌عنوان اولین شکل در اولین اسلاید باشد، به‌طوری که سلول‌های `(1, 2)` و `(1, 3)` به‌صورت عمودی ترکیب شده باشند. از [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) و [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) برای یافتن مبدا استفاده می‌کند و هر دو گستردگی را بررسی می‌کند. `SplitByRowSpan(1)` سپس ردیف‌های ۲ و ۳ را برای نام محصولات جدا می‌کند. برای ترکیب افقی دو ستونی، به‌جای آن از `SplitByColSpan(1)` استفاده کنید.

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

    // دریافت سلول‌های حاصل از جدول پس از تقسیم.
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

شبکه جدول و ایندکس‌های سلول‌های اطراف بدون تغییر می‌مانند. سلول‌های حاصل را بر اساس مختصاتشان بازیابی کنید؛ در اینجا هر دو سلول دارای گستردگی ۱ هستند و [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) مقدار `False` را چاپ می‌کند. نواحی بزرگتر می‌توانند پس از یک تقسیم بخشی ترکیبی باقی بمانند.

متن اصلی و قالب‌بندی آن در سلول بالا (یا چپ) باقی می‌ماند؛ سلول جدید خالی است اما قالب‌بندی سلول از قبیل پرشدن، حاشیه‌ها و حاشیه داخلی را به ارث می‌برد. پس از تقسیم سلول‌ها را پر کنید و هر قالب‌بندی متنی مورد نیاز را به‌صورت صریح تنظیم کنید.

ارائه ذخیره‌شده شامل سلول‌های جداگانه «Product A» و «Product B» است که قالب‌بندی سلول قالب حفظ می‌شود. برای جزئیات بیشتر به [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) مراجعه کنید.

## **تغییر رنگ پس‌زمینه سلول جدول**

این مثال یک جدول با ستون‌های ۱۵۰‑نقطه‌ای و ردیف‌های ۵۰‑نقطه‌ای ایجاد می‌کند. از [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) برای انتخاب پرشدن ثابت و از [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) برای دسترسی به رنگ پرشدن استفاده می‌کند و آن را برای سلول `(2, 3)` (ستون سوم و ردیف چهارم) به رنگ قرمز تنظیم می‌نماید.

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

## **افزودن تصویر داخل سلول جدول**

قبل از اجرای این مثال، تصویر ورودی را در پوشه کاری قرار دهید. تصویر با [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) بارگذاری می‌شود و با [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) به مجموعه تصویرهای ارائه اضافه می‌گردد. سپس تصویر به پرشدن تصویر سلول `(0, 0)`، اولین سلول جدول، اختصاص می‌یابد.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) تصویر را برای پر کردن سلول کشیده می‌کند که ممکن است نسبت ابعاد آن را تغییر دهد. عرض ستون‌ها و ارتفاع ردیف‌ها برحسب نقطه است. تصویر بارگذاری‌شده پس از افزودن به ارائه آزاد (dispose) می‌شود.

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

## **سوالات متداول**

**آیا می‌توانم ضخامت و سبک خطوط متفاوتی برای طرف‌های مختلف یک سلول واحد تنظیم کنم؟**

بله. حاشیه‌های [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) دارای خصوصیات جداگانه‌ای هستند، بنابراین ضخامت و سبک هر طرف می‌تواند متفاوت باشد.

**اگر پس از تنظیم تصویر به‌عنوان پس‌زمینه سلول، اندازه ستون/ردیف را تغییر دهم، چه اتفاقی برای تصویر می‌افتد؟**

رفتار بستگی به [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) دارد. در حالت کشیده شدن (stretch)، تصویر با سلول جدید وفق می‌یابد؛ در حالت کاشی (tile) کاشی‌ها مجدداً محاسبه می‌شوند.

**آیا می‌توانم برای تمام محتوای یک سلول یک ابر링ک تنظیم کنم؟**

[Hyperlinks](/slides/fa/cpp/manage-hyperlinks/) در سطح متن (پرتیشن) داخل فریم متن سلول یا در سطح کل جدول/شکل تنظیم می‌شوند. در عمل، لینک را به یک پرتیشن یا به تمام متن داخل سلول اختصاص می‌دهید.

**آیا می‌توانم فونت‌های متفاوتی داخل یک سلول تنظیم کنم؟**

بله. فریم متن یک سلول از [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (بخش‌ها) با قالب‌بندی مستقل—قابلیت فونت، سبک، اندازه و رنگ—پشتیبانی می‌کند.