---
title: إدارة جداول العروض التقديمية في C++
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/cpp/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى جدول
- نسبة العرض إلى الارتفاع
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides لـ C++. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول الخاص بك."
---
## **المقدمة**

تنظم الجداول في PowerPoint المعلومات في صفوف وأعمدة، مما يجعل قراءتها ومقارنة القيم أسهل.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) والفئة [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) والواجهة [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) وأنواع أخرى لتتيح لك إنشاء وتحديث وإدارة الجداول في العروض التقديمية.

## **إنشاء جدول من الصفر**

إنشاء جدول عن طريق تحديد موضعه وعرض الأعمدة وارتفاع الصفوف. بعد إضافته إلى شريحة، يمكنك تنسيق حدود الخلايا، دمج الخلايا، وإدراج النص.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة باستخدام فهرسها.
3. تعريف مصفوفة لعروض الأعمدة بالنقاط.
4. تعريف مصفوفة لارتفاعات الصفوف بالنقاط.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) لتطبيق التنسيق على الحدود العليا والسفلى واليمين واليسار.
7. دمج الخليتين الأوليتين في الصف الأول للجدول.
8. الوصول إلى الخلية المدمجة عبر الطريقة [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/).
9. تعيين النص في الخلية المدمجة.
10. حفظ العرض التقديمي المعدل.

المثال أدناه ينشئ جدولًا بثلاثة أعمدة وخمسة صفوف عند (100, 50) نقطة. يطبق حدودًا حمراء بعرض 5 نقاط، يدمج الخليتين الأوليتين في الصف الأول، ويحفظ النتيجة كـ `table.pptx`.

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

## **ترقيم في جدول قياسي**

في جدول قياسي، مؤشرات الخلايا تبدأ من الصفر وتستخدم الترتيب (العمود، الصف). الخلية الأولى لديها المؤشر (0, 0).

على سبيل المثال، تُرقم خلايا جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

هذا المثال ينشئ جدول 4 × 4 الموضح أعلاه، بعرض أعمدة وارتفاع صفوف 70 نقطة وحدود خلايا حمراء بعرض 5 نقاط. تُظهر الإحداثيات مؤشرات الخلايا؛ المثال يترك الخلايا فارغة ويحفظ الجدول كـ `StandardTables_out.pptx`.

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

## **الوصول إلى جدول موجود**

يتم تخزين الجداول في مجموعة الأشكال الخاصة بالشريحة. قم بالتكرار عبر الأشكال لتحديد جدول، ثم استخدم الواجهة [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) لقراءة خلاياه أو تحديثها.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة التي تحتوي على الجدول باستخدام فهرسها.
3. التكرار عبر كائنات [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) والتوقف عندما يتم العثور على جدول. إذا احتوت الشريحة على عدة جداول، استخدم [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) لتحديد الجدول المطلوب.
4. تحديث النص في الخلية المستهدفة.
5. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `UpdateExistingTable.pptx` ويعثر على أول جدول في الشريحة الأولى. يضبط الخلية في العمود 0، الصف 1 إلى `New` ويحفظ النتيجة كـ `table1_out.pptx`. يجب أن يحتوي الإدخال على شريحة واحدة على الأقل، وأن يحتوي أول جدول في تلك الشريحة على عمود واحد على الأقل واثنين من الصفوف.

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

لتغيير حجم صف في جدول موجود وفهم لماذا يمكن أن يتجاوز ارتفاعه الفعلي الحد الأدنى المطلوب، راجع [Control Row Height](/slides/ar/cpp/manage-rows-and-columns/#control-row-height).

## **العثور على الخلية التي تملك إطار النص**

عند وصول كود معالجة النص العامة إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) من جدول، استخدم [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) لاسترجاع [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) المالك. في إطار نص خلية جدول، يعيد [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) المالك و [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) القيمة `nullptr`، رغم أن الجدول نفسه يعتبر شكلاً.

إحداثيات الخلية متاحة عبر طريقتي [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) و[ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) للقراءة فقط. كما توفر [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) تنقلًا للقراءة فقط: تُعيد المالك ولكنها لا تغير الملكية. تحقق دائمًا من أن الخليّة المرجعة ليست `nullptr` قبل استخدامها.

للحصول على مثال كامل يحدد مالكي خلايا الجدول والمسShapes، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/cpp/search-and-replace-text/).

## **محاذاة النص في جدول**

يمكنك التحكم في التثبيت الرأسي واتجاه النص في خلايا الجدول الفردية. المثال في هذا القسم يوسّط النص داخل الخلية الأولى ويدوره بزاوية 270 درجة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة باستخدام فهرسها.
3. إضافة كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) إلى الشريحة.
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) من الجدول.
5. الوصول إلى أول [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) وتعيين نصه ولونه.
6. تعيين تثبيت الخلية الرأسي واتجاه النص باستخدام [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) و[set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. حفظ العرض التقديمي المعدل.

هذا المثال ينشئ جدول 4 × 4 بعرض أعمدة 120 نقطة وارتفاع صفوف 100 نقطة. ينسّق النص في الخلية (0, 0)، يضيف قيمًا إلى الخلايا المتبقية في الصف الأول، ويحفظ النتيجة كـ `Vertical_Align_Text_out.pptx`.

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

## **تعيين تنسيق النص على مستوى الجدول**

استخدم [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) لتطبيق تنسيق النص على جميع خلايا الجدول. تدعم التحميلات تنسيق الجزء والفقرة وإطار النص، بحيث يمكنك ضبط هذه الخصائص دون التكرار عبر الخلايا الفردية.

1. تحميل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة باستخدام فهرسها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) من الشريحة.
4. تعيين حجم الخط باستخدام [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) للنص.
5. تعيين محاذاة الفقرة والهامش الأيمن باستخدام [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و[set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. تعيين اتجاه النص باستخدام [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. حفظ العرض التقديمي المعدل.

المثال أدناه يفتح `table.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل له. يضبط حجم الخط إلى 25 نقطة، يمحاذاة الفقرات إلى اليمين بهامش أيمن 20 نقطة، ويجعل النص عموديًا. يُحفظ العرض المُنسق كـ `result.pptx`.

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

## **الحصول على خصائص نمط الجدول**

استخدم [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) لقراءة نمط الجدول المسبق و[set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) لتعيينه. يطبق هذا المثال [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) على جدول واحد، يطبع اسم النمط، ويعين نفس النمط لجدول ثانٍ. يتم حفظ كلا الجدولين في `table-style.pptx`.

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

## **قفل نسبة العرض إلى الارتفاع للجدول**

نسبة العرض إلى الارتفاع للجدول هي نسبة عرضه إلى ارتفاعه. استخدم [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) لقفل هذه النسبة للجدول.

المثال أدناه يفتح `pres.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل مع جدول كأول شكل له. يطبع حالة القفل الحالية، يفعّل قفل نسبة العرض إلى الارتفاع، يطبع الحالة المحدثة (`True`)، ويحفظ النتيجة كـ `pres-out.pptx`.

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

## **الأسئلة المتكررة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يعرض الجدول طريقة [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/)، وتحتوي الفقرات على [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). يضمن استخدام كلاهما الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من نقل أو تغيير حجم جدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/cpp/applying-protection-to-presentation/) لتعطيل النقل، وتغيير الحجم، والاختيار، وما إلى ذلك. تنطبق هذه الأقفال على الجداول أيضًا.

**هل دعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمدد أو تجانب).