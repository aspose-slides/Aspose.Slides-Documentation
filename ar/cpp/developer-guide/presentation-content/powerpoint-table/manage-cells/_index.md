---
title: إدارة خلايا الجدول في العروض التقديمية باستخدام C++
linktitle: إدارة الخلايا
type: docs
weight: 30
url: /ar/cpp/manage-cells/
keywords:
- خلية جدول
- دمج خلايا
- إزالة الحدود
- تقسيم خلية
- صورة في خلية
- لون الخلفية
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة خلايا جدول PowerPoint في C++: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بالوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint التقديمية. يشرح هذا المقال كيفية تحديد الخلايا المدمجة في الجدول، وإزالة حدود الخلية، والعمل مع ترقيم الخلايا بعد الدمج أو تقسيم الخلايا، وتغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح عرض تقديمي، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

يستخدم Aspose.Slides فهارس تبدأ من الصفر للوصول إلى خلايا الجدول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرض تقديمي موجود ويصل إلى الشكل الأول في الشريحة الأولى كجدول. يفترض أن الشريحة والشكل موجودان وأن الشكل جدول. ثم يُكرر عبر جميع الصفوف والأعمدة ويستخدم [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)، [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)، وإحداثيات بدء المنطقة، [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) و[get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **إزالة حدود خلية الجدول**

أنشئ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وأضف جدولًا إلى شريحته الأولى باستخدام [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع حدود الخلية الأربعة إلى [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **دمج خلايا الجدول**

استخدم [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) لتجميع نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاويتين العلوية اليسرى والسفلية اليمنى للنطاق. الوسيط النهائي يتحكم ما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يحافظ على الدمج داخل ذلك النطاق.

يقوم المثال بإنشاء جدول 4×4 بأعمدة وصفوف حجمها 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` حتى `(2, 2)`. الخلية الناتجة تمتد على عمودين وصفين، بينما يحتفظ شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى أو تنسيق الخلية المدمجة، استخدم موقعها العلوي الأيسر: `table->idx_get(1, 1)` في هذا المثال. المواقع الأخرى في النطاق المدمج تظل جزءًا من شبكة الجدول، لذا لا تتغير فهارس الخلايا خارج النطاق.

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

## **تقسيم خلايا الجدول**

يحافظ دمج الخلايا في المثال السابق على شبكة الجدول. قد يؤدي تقسيم خلية إلى إدخال عمود جديد في الشبكة وتغيير فهارس الأعمدة للخلايا التي على يمينها. تتبع Aspose.Slides نموذج شبكة الجدول الخاص بـ PowerPoint.

يقوم هذا المثال بإنشاء جدول 4×4 بأعمدة وصفوف حجمها 70 نقطة ويستدعي [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) على الخلية `(1, 1)`. يتم تمرير نصف عرض الخلية البالغ 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا التقسيم، يتم الوصول إلى النصفين كـ `table->idx_get(1, 1)` و `table->idx_get(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: الخلايا التي كانت في الأعمدة 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تبقى فهارس الصفوف دون تغيير. استخدم فهارس الأعمدة المحدثة عند الوصول إلى الخلايا بعد التقسيم.

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

### **تقسيم الخلايا المدمجة حسب الصف أو العمود**

لتحضير خلايا القالب المدمجة لتعبئة البيانات، استخدم [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) لتقسيم على طول حد صف موجود، أو [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) لتقسيم على طول حد عمود.

المُعامل `index` يحسب الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من التقسيم؛ وهو نسبًيا للمنطقة المدمجة:

- تقسم صف: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- تقسم عمود: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

يفترض المثال أن يحتوي عرض تقديمي على جدول كأول شكل في الشريحة الأولى، مع دمج `(1, 2)` و `(1, 3)` عموديًا. بدءًا من الموضع السفلي، يستخدم [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) و[get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) لتحديد الأصل ويتحقق من كلا النطاقين. ثم يقوم `SplitByRowSpan(1)` بفصل الصفوف 2 و3 لأسماء المنتجات. لدمج أفقي بعمودين، استخدم `SplitByColSpan(1)` بدلاً من ذلك.

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

    // استرجع الخلايا الناتجة من الجدول بعد التقسيم.
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

تظل شبكة الجدول وفهارس الخلايا المجاورة دون تغيير. استعد الخلايا الناتجة بإحداثياتها؛ هنا، كلاهما لديه امتداد 1 و [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) يطبع `False`. يمكن للمناطق الأكبر أن تظل مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العلوية (أو اليسرى)؛ الخلية الجديدة تكون فارغة لكنها ترث تنسيق الخلية مثل التعبئة والحدود والهوامش. قم بملء الخلايا بعد التقسيم وضبط أي تنسيق نص مطلوب صراحةً.

يحتوي العرض التقديمي المحفوظ على خلايا منفصلة "Product A" و "Product B" مع الحفاظ على تنسيق خلايا القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) للحصول على التفاصيل.

## **تغيير لون خلفية خلية الجدول**

يقوم هذا المثال بإنشاء جدول بأعمدة حجمها 150 نقطة وصفوف حجمها 50 نقطة. يستخدم [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) لاختيار تعبئة صلبة و[get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) للوصول إلى لون التعبئة وتعيينه إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

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

## **إضافة صورة داخل خلية جدول**

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة باستخدام [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) ويضيفها إلى مجموعة صور العرض التقديمي باستخدام [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). ثم يُعيّن الصورة إلى تعبئة الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) يمدّد الصورة لتملأ الخلية، مما قد يغيّر نسبة الأبعاد الخاصة بها. عرض الأعمدة وارتفاع الصفوف بالنقاط. يتم التخلص من الصورة المحملة بعد إضافتها إلى العرض التقديمي.

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

## **الأسئلة المتكررة**

**هل يمكنني تعيين سماكات خطوط وأنماط مختلفة لأطراف مختلفة من خلية واحدة؟**

نعم. حدود [أعلى](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[أسفل](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[يسار](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[يمين](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) لها خصائص منفصلة، لذا يمكن أن تختلف السماكة والنمط لكل جانب.

**ماذا يحدث للصورة إذا قمت بتغيير حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/). عند التمدد، تُعدل الصورة لتناسب الخلية الجديدة؛ عند التكرار، تُعاد حساب البلاط.

**هل يمكنني تعيين ارتباط تشعبي لكل محتوى الخلية؟**

[الروابط التشعبية](/slides/ar/cpp/manage-hyperlinks/) يتم ضبطها على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل كاملًا. عمليًا، تقوم بتعيين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [المقاطع](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) بتنسيق مستقل—نوع الخط، الأسلوب، الحجم، واللون.