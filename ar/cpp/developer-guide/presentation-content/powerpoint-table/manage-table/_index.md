---
title: إدارة جداول العروض التقديمية بلغة C++
linktitle: إدارة الجدول
type: docs
weight: 10
url: /ar/cpp/manage-table/
keywords:
- إضافة جدول
- إنشاء جدول
- الوصول إلى الجدول
- نسبة الأبعاد
- محاذاة النص
- تنسيق النص
- نمط الجدول
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "إنشاء وتعديل الجداول في شرائح PowerPoint باستخدام Aspose.Slides للغة C++. اكتشف أمثلة شفرة بسيطة لتبسيط سير عمل الجداول الخاص بك."
---
## **المقدمة**

الجدول في PowerPoint هو طريقة فعّالة لعرض وتقديم المعلومات. المعلومات في شبكة من الخلايا (المرتبة في صفوف وأعمدة) تكون مباشرة وسهلة الفهم.

توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/ar/cpp/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) والفئة [Cell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/cell/) والواجهة [ICell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/) وأنواع أخرى لتتيح لك إنشاء وتحديث وإدارة الجداول في جميع أنواع العروض التقديمية. 

## **إنشاء جدول من الصفر**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. تعريف مصفوفة `columnWidth`.
4. تعريف مصفوفة `rowHeight`.
5. إضافة كائن [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addtable/).
6. التكرار عبر كل [ICell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/) لتطبيق التنسيق على الحدود العلوية والسفلية واليمنى واليسرى.
7. دمج الخليتين الأوليتين في الصف الأول للجدول. 
8. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textframe/) الخاص بـ [ICell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/). 
9. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textframe/).
10. حفظ العرض التقديمي المعدل.

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

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعروضها والصفوف بارتفاعاتها
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// يضيف شكل جدول إلى الشريحة
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// يضبط تنسيق الحدود لكل خلية
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
// يدمج الخلايا 1 و 2 في الصف 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// يضيف بعض النص إلى الخلية المدمجة
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// يحفظ العرض التقديمي على القرص
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **الترقيم في جدول قياسي**

في جدول قياسي، يكون ترقيم الخلايا بسيطًا ويعتمد على الصفر. الخلية الأولى في الجدول تُرقم كـ 0,0 (العمود 0، الصف 0). 

على سبيل المثال، تُرقم الخلايا في جدول يحتوي على 4 أعمدة و4 صفوف بهذه الطريقة:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

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

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرضها والصفوف بارتفاعها
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// يضيف شكل جدول إلى الشريحة
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// يضبط تنسيق الحدود لكل خلية
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

// يحفظ العرض التقديمي إلى القرص
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **الوصول إلى جدول موجود**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).

2. الحصول على مرجع إلى الشريحة التي تحتوي على الجدول عبر فهرستها. 

3. إنشاء كائن [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) وتعيينه إلى null.

4. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) حتى يتم العثور على الجدول.

   إذا كنت تشك أن الشريحة التي تتعامل معها تحتوي على جدول واحد فقط، يمكنك ببساطة فحص جميع الأشكال التي تحتويها. عندما يتم تحديد شكل كجدول، يمكنك تحويل نوعه إلى كائن [Table](https://reference.aspose.com/slides/ar/cpp/aspose.slides/table/). ولكن إذا كانت الشريحة تحتوي على عدة جداول، فمن الأفضل البحث عن الجدول المطلوب عبر طريقة [set_AlternativeText()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_alternativetext/).

5. استخدام كائن [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) للعمل مع الجدول. في المثال أدناه، أضفنا صفًا جديدًا إلى الجدول.

6. حفظ العرض التقديمي المعدل.

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

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// يصل إلى الشريحة الأولى
auto sld = pres->get_Slides()->idx_get(0);

// يهيئ جدولًا فارغًا (null)
System::SharedPtr<ITable> tbl;

// يتنقل عبر الأشكال ويضبط مرجعًا إلى الجدول الموجود
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// يضبط النص للعمود الأول من الصف الثاني
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// يحفظ العرض التقديمي المعدل إلى القرص
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **العثور على الخلية التي تمتلك إطار نص**

عند تلقي كود معالجة النص العامة كائن [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) من جدول، استخدم [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentcell/) لاسترجاع [ICell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/) المالكة. بالنسبة لإطار نص خلية جدول، تُعيد [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentcell/) المالك وتُعيد [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr`، على الرغم من أن الجدول نفسه يعتبر شكلاً.

إحداثيات الخلية متاحة عبر الطريقتين القراءة فقط [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/get_firstcolumnindex/) و[ICell::get_FirstRowIndex](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icell/get_firstrowindex/). كما تُوفر [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/get_parentcell/) تنقلًا للقراءة فقط: تُعيد المالك لكنها لا تغير الملكية. تحقق دائمًا من أن الخلية المرجعة ليست `nullptr` قبل استخدامها.

لمثال كامل يحدد مالكي خلايا الجدول والأشكال، بما في ذلك الأشكال المرتبطة بعُقَد SmartArt، راجع [Search and Replace Text](/slides/ar/cpp/search-and-replace-text/).

## **محاذاة النص في جدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة كائن [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) إلى الشريحة. 
4. الوصول إلى كائن [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) من الجدول. 
5. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/).
6. محاذاة النص عموديًا.
7. حفظ العرض التقديمي المعدل.

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

// ينشئ كائنًا من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

// يحصل على الشريحة الأولى
auto slide = presentation->get_Slides()->idx_get(0);

// يحدد الأعمدة بعرضها والصفوف بارتفاعها
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// يضيف شكل جدول إلى الشريحة
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// يصل إلى إطار النص
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// ينشئ كائن Paragraph لإطار النص
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// ينشئ كائن Portion للفقرة
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// يضبط النص عموديًا
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// يحفظ العرض التقديمي إلى القرص
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **تعيين تنسيق النص على مستوى الجدول**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) من الشريحة.
4. ضبط [set_FontHeight()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_fontheight/) للنص. 
5. ضبط [set_Alignment()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_alignment/) و[set_MarginRight()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. ضبط [set_TextVerticalType()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. حفظ العرض التقديمي المعدل. 

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

// ينشئ كائنًا من فئة Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// لنفترض أن الشكل الأول في الشريحة الأولى هو جدول
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// يضبط ارتفاع خط خلايا الجدول
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// يضبط محاذاة نص خلايا الجدول والهامش الأيمن في استدعاء واحد
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// يضبط نوع النص العمودي لخلايا الجدول
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **الحصول على خصائص نمط الجدول**

تسمح لك Aspose.Slides باسترجاع خصائص النمط لجدول حتى تتمكن من استخدام تلك التفاصيل لجدول آخر أو في مكان آخر. يُظهر هذا الكود C++ كيفية الحصول على خصائص النمط من نمط جدول مبدئي:

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

## **قفل نسبة الأبعاد للجدول**

نسبة الأبعاد للشكل الهندسي هي نسبة أحجامه في الأبعاد المختلفة. وفّرت Aspose.Slides الخاصية `AspectRatioLocked()` للسماح لك بقفل إعداد نسبة الأبعاد للجداول والأشكال الأخرى. 

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

## **الأسئلة المتكررة**

**هل يمكنني تمكين اتجاه القراءة من اليمين إلى اليسار (RTL) لجدول كامل والنص داخل خلاياه؟**

نعم. يوفّر الجدول طريقة [set_RightToLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides/table/set_righttoleft/) وتملك الفقرات الطريقة [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraphformat/set_righttoleft/). يضمن استخدامهما معًا الترتيب الصحيح للـ RTL وعرضه داخل الخلايا.

**كيف يمكنني منع المستخدمين من تحريك أو تغيير حجم الجدول في الملف النهائي؟**

استخدم [shape locks](/slides/ar/cpp/applying-protection-to-presentation/) لتعطيل التحريك، وتغيير الحجم، وتحديد العنصر، وما إلى ذلك. تُطبق هذه الأقفال على الجداول أيضًا.

**هل يدعم إدراج صورة داخل خلية كخلفية؟**

نعم. يمكنك تعيين [picture fill](https://reference.aspose.com/slides/ar/cpp/aspose.slides/picturefillformat/) للخلية؛ ستغطي الصورة مساحة الخلية وفقًا للوضع المختار (تمديد أو تجانب).