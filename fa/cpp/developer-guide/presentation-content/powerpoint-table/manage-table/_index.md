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
- نسبت عرض به ارتفاع
- ترازبندی متن
- قالب‌بندی متن
- سبک جدول
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و ویرایش جداول در اسلایدهای PowerPoint با Aspose.Slides برای C++. مثال‌های ساده کد را برای بهینه‌سازی جریان کار جداول خود کشف کنید."
---
## **مقدمه**

یک جدول در PowerPoint روش کارآمدی برای نمایش و بیان اطلاعات است. اطلاعات در یک شبکه از سلول‌ها (چیدمان‌شده به صورت ردیف‌ها و ستون‌ها) ساده و آسان برای درک است.

Aspose.Slides کلاس [Table](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/)، رابط [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/)، کلاس [Cell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/cell/)، رابط [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) و سایر انواع را ارائه می‌دهد تا بتوانید جداول را در انواع ارائه‌ها ایجاد، به‌روزرسانی و مدیریت کنید. 

## **ایجاد جدول از ابتدا**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. آرایه‌ای از `columnWidth` تعریف کنید.  
4. آرایه‌ای از `rowHeight` تعریف کنید.  
5. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) را از طریق متد [AddTable()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addtable/) به اسلاید اضافه کنید.  
6. بر روی هر [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) تکرار کنید تا قالب‌بندی مرزهای بالا، پایین، راست و چپ اعمال شود.  
7. دو سلول اول سطر اول جدول را با هم ترکیب کنید.  
8. به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) یک [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) دسترسی پیدا کنید.  
9. متنی به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) اضافه کنید.  
10. ارائه تغییر یافته را ذخیره کنید.

این کد C++ نشان می‌دهد که چگونه یک جدول در یک ارائه ایجاد کنید:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر فایل PPTX است
auto pres = System::MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
auto sld = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// یک شکل جدول را به اسلاید اضافه می‌کند
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// سلول‌های ۱ و ۲ ردیف ۱ را ترکیب می‌کند
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// متنی به سلول ترکیب‌شده اضافه می‌کند
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// ارائه را در دیسک ذخیره می‌کند
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **شماره‌گذاری در جدول استاندارد**

در یک جدول استاندارد، شماره‌گذاری سلول‌ها ساده و مبتنی بر صفر است. اولین سلول جدول به صورت 0,0 (ستون 0، ردیف 0) ایندکس می‌شود. 

به عنوان مثال، سلول‌های یک جدول با 4 ستون و 4 ردیف به این شکل شماره‌گذاری می‌شوند:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

این کد C++ نشان می‌دهد که چگونه شماره‌گذاری سلول‌های یک جدول را مشخص کنید:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// یک شیء از کلاس Presentation می‌سازد که نمایانگر یک فایل PPTX است
auto pres = System::MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
auto sld = pres->get_Slides()->idx_get(0);

// ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// یک شکل جدول به اسلاید اضافه می‌کند
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// قالب حاشیه را برای هر سلول تنظیم می‌کند
for (const auto& row : tbl->get_Rows())
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

// ارائه را بر روی دیسک ذخیره می‌کند
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **دسترسی به جدول موجود**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  

2. مرجع اسلاید حاوی جدول را از طریق شاخص آن دریافت کنید.  

3. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) ایجاد کنید و آن را به null تنظیم کنید.  

4. بر روی تمام اشیای [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) تکرار کنید تا جدول پیدا شود.  

   اگر مشکوکید اسلاید مورد نظر فقط یک جدول دارد، می‌توانید تمام اشکال موجود در آن را بررسی کنید. وقتی شکلی به عنوان جدول شناسایی شد، می‌توانید آن را به شیء [Table](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/) تبدیل کنید. اما اگر اسلاید شامل چندین جدول باشد، بهتر است جدول مورد نیاز را از طریق ویژگی [set_AlternativeText()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_alternativetext/) جستجو کنید.  

5. از شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) برای کار با جدول استفاده کنید. در مثال زیر یک ردیف جدید به جدول اضافه کردیم.  

6. ارائه تغییر یافته را ذخیره کنید.  

این کد C++ نشان می‌دهد که چگونه به یک جدول موجود دسترسی داشته و با آن کار کنید:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// یک شیء از کلاس Presentation می‌سازد که نمایانگر یک فایل PPTX است
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// به اولین اسلاید دسترسی می‌یابد
auto sld = pres->get_Slides()->idx_get(0);

// مقدار Table را به null مقداردهی می‌کند
System::SharedPtr<ITable> tbl;

// از طریق اشکال تکرار می‌کند و مرجع به جدول یافت‌شده را تنظیم می‌کند
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// متن را برای ستون اول ردیف دوم تنظیم می‌کند
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// ارائه تغییر یافته را بر روی دیسک ذخیره می‌کند
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **یابی سلولی که چارچوب متن را در اختیار دارد**

هنگامی که کد عمومی پردازش متن یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) از یک جدول دریافت می‌کند، از متد [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentcell/) برای بازیابی [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/) مالک استفاده کنید. برای چارچوب متن سلول جدول، [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentcell/) صاحب را برمی‌گرداند و [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentshape/) مقدار `nullptr` برمی‌گرداند، حتی اگر جدول خودش یک شکل باشد.

مختصات سلول از طریق متدهای فقط‑خواندنی [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/get_firstcolumnindex/) و [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/get_firstrowindex/) در دسترس است. همچنین [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/get_parentcell/) ناوبری فقط‑خواندنی را فراهم می‌کند: صاحب را برمی‌گرداند اما مالکیت را تغییر نمی‌دهد. قبل از استفاده همیشه بررسی کنید که سلول برگشتی مقدار `nullptr` نباشد.

برای یک مثال کامل که مالکین سلول‑جدول و شکل را شناسایی می‌کند، از جمله اشکالی که به گره‌های SmartArt مرتبط هستند، به بخش [Search and Replace Text](/slides/fa/cpp/search-and-replace-text/) مراجعه کنید.

## **ترازبندی متن در جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) به اسلاید اضافه کنید.  
4. یک شیء [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را از جدول به‌دست آورید.  
5. به [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) مربوط به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) دسترسی پیدا کنید.  
6. متن را به‌صورت عمودی ترازبندی کنید.  
7. ارائه تغییر یافته را ذخیره کنید.

این کد C++ نشان می‌دهد که چگونه متن را در یک جدول ترازبندی کنید:

```c++
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
#include <DOM/ISlideCollection.h>
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

// یک نمونه از کلاس Presentation ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();

// اسلاید اول را دریافت می‌کند
auto slide = presentation->get_Slides()->idx_get(0);

// ستون‌ها را با عرض‌ها و ردیف‌ها را با ارتفاع‌ها تعریف می‌کند
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// یک شکل جدول را به اسلاید اضافه می‌کند
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// چارچوب متن را به‌دست می‌آورد
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// شی Paragraph را برای چارچوب متن ایجاد می‌کند
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// شی Portion را برای پاراگراف ایجاد می‌کند
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// متن را به‌صورت عمودی ترازبندی می‌کند
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// ارائه را بر روی دیسک ذخیره می‌کند
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **تنظیم قالب‌بندی متن در سطح جدول**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) را از اسلاید به‌دست آورید.  
4. برای متن، متد [set_FontHeight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_fontheight/) را تنظیم کنید.  
5. متدهای [set_Alignment()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_alignment/) و [set_MarginRight()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginright/) را تنظیم کنید.  
6. متد [set_TextVerticalType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframeformat/set_textverticaltype/) را تنظیم کنید.  
7. ارائه تغییر یافته را ذخیره کنید.  

این کد C++ نشان می‌دهد که چگونه گزینه‌های قالب‌بندی دلخواه خود را بر متن داخل جدول اعمال کنید:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// یک نمونه از کلاس Presentation ایجاد می‌کند
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// فرض می‌کنیم اولین شکل در اولین اسلاید یک جدول است
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// ارتفاع فونت سلول‌های جدول را تنظیم می‌کند
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// تنظیم ترازبندی متن سلول‌های جدول و حاشیه راست در یک فراخوانی
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// تنظیم نوع عمودی متن سلول‌های جدول
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **دریافت ویژگی‌های سبک جدول**

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های سبک یک جدول را دریافت کنید تا بتوانید این جزئیات را برای جدول دیگری یا در مکان دیگری استفاده کنید. این کد C++ نشان می‌دهد که چگونه ویژگی‌های سبک را از یک سبک پیش‌فرض جدول دریافت کنید:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **قفل کردن نسبت عرض به ارتفاع جدول**

نسبت عرض به ارتفاع یک شکل هندسی، نسبت اندازه‌های آن در ابعاد مختلف است. Aspose.Slides ویژگی `AspectRatioLocked()` را فراهم کرده تا بتوانید تنظیم قفل نسبت عرض به ارتفاع را برای جداول و سایر اشکال اعمال کنید. 

این کد C++ نشان می‌دهد که چگونه نسبت عرض به ارتفاع یک جدول را قفل کنید:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا می‌توانم جهت خوانش راست به چپ (RTL) را برای کل جدول و متون داخل سلول‌های آن فعال کنم؟**

بله. جدول متد [set_RightToLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/table/set_righttoleft/) را ارائه می‌دهد و پاراگراف‌ها متد [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraphformat/set_righttoleft/) دارند. استفاده از هر دو باعث حفظ ترتیب و رندر صحیح RTL داخل سلول‌ها می‌شود.

**چگونه می‌توانم جلوگیری کنم که کاربران جدول را در فایل نهایی جابه‌جا یا اندازهٔ آن را تغییر دهند؟**

از [قفل‌های شکل](/slides/fa/cpp/applying-protection-to-presentation/) استفاده کنید تا جابه‌جایی، تغییر اندازه، انتخاب و غیره را غیرفعال کنید. این قفل‌ها برای جداول نیز اعمال می‌شوند.

**آیا افزودن تصویر به عنوان پس‌زمینه داخل یک سلول پشتیبانی می‌شود؟**

بله. می‌توانید برای یک سلول پرکنش تصویر ([picture fill](https://reference.aspose.com/slides/fa/cpp/aspose.slides/picturefillformat/)) تنظیم کنید؛ تصویر بر حسب حالت انتخابی (کشیده یا کاشی) منطقهٔ سلول را پوشش می‌دهد.