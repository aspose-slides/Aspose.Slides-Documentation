---
title: "إدارة خلايا الجداول في العروض التقديمية باستخدام C++"
linktitle: "إدارة الخلايا"
type: docs
weight: 30
url: /ar/cpp/manage-cells/
keywords:
- "خلية جدول"
- "دمج خلايا"
- "إزالة الحدود"
- "تقسيم خلية"
- "صورة في خلية"
- "لون الخلفية"
- "PowerPoint"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "إدارة خلايا جداول PowerPoint في C++: تحديد الخلايا المدمجة، إزالة الحدود، تقسيم الخلايا، وتعيين ألوان الخلفية والصور باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

Aspose.Slides يتيح لك الوصول إلى خلايا الجداول وتعديلها في عروض PowerPoint. يشرح هذا المقال كيفية تحديد خلايا الجداول المدمجة، إزالة حدود الخلايا، العمل مع ترقيم الخلايا بعد الدمج أو الفصل، تغيير لون خلفية الخلية، وإضافة صورة داخل خلية جدول. تُظهر الأمثلة كيفية إنشاء أو فتح Presentation، الحصول على جدول من شريحة، تحديث تنسيق الخلية عبر خصائص الخلية، وحفظ العرض المعدل كملف PPTX.

Aspose.Slides يستخدم فهارس تبدأ من الصفر للوصول إلى خلايا الجدول بالترتيب `(column, row)`.

## **تحديد خلية جدول مدمجة**

يفتح المثال عرض تقديمي موجودًا ويصل إلى الشكل الأول في الشريحة الأولى باعتبارها جدولًا. يفترض أن الشريحة والشكل موجودان وأن الشكل هو جدول. ثم يتكرر عبر جميع الصفوف والأعمدة ويستخدم [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) لتحديد الخلايا في المناطق المدمجة. لكل تطابق، يطبع إحداثيات الخلية بترتيب `row;column`، [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)، [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)، وإحداثيات بدء المنطقة، [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) و[get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

إنشاء [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وإضافة جدول إلى شريحته الأولى باستخدام [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). يتم تحديد عرض الأعمدة، ارتفاع الصفوف، وموقع الجدول بالنقاط. يضبط المثال جميع حدود الخلية الأربعة إلى [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)، مما يجعلها غير مرئية.

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

## **إضافة حدود قطرية للخلية**

استخدم [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) لرسم خط من الزاوية العليا اليسرى إلى الأسفل اليمنى، واستخدم [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) لرسم خط من الزاوية السفلى اليسرى إلى العليا اليمنى. يمكن أن يشير القطر إلى عنوان زاوية؛ ويمكن للقطرين معًا تشكيل X لتحديد أن الخلية غير قابلة للتطبيق.

كل قطري هو [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). استخدم [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) للوصول إلى تعبئته، واستدعِ [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) مع [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) واختر لونًا عبر [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). اضبط عرض الخط باستخدام [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) بالنقاط.

يخلق المثال ثلاث خلايا في صف واحد: قطري نزولي أحمر، قطري صعودي أزرق، وكلا القطرين. يترك حدود الخلية العليا، السفلى، اليسرى، واليمنى دون تغيير.

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

القطري هو خاصية تنسيق، وليس انقسامًا للخلية. تحتفظ كل خلية بإطار نص واحد يمكن الوصول إليه عبر [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/). لا يمكن تحرير المناطق على جانبي القطر بشكل مستقل.

![ثلاث خلايا جدول تُظهر قطريًا أحمر من أعلى اليسار إلى أسفل اليمين، قطريًا أزرق من أسفل اليسار إلى أعلى اليمين، وكلا القطرين يشكلان X.](diagonal-cell-borders.png)

*من اليسار إلى اليمين: قطري نزولي (أحمر، 3 نقطة)، قطري صعودي (أزرق، 5 نقاط)، وكلا القطرين.*

## **دمج خلايا الجدول**

استخدم [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) لدمج نطاق مستطيل من خلايا الجدول في خلية واحدة. حدد الخلايا في الزاويتين العليا اليسرة والسفلى اليمنى للنطاق. تتحكم الوسيطة الأخيرة فيما إذا كان الدمج قد يشمل خلايا خارج النطاق المحدد؛ `false` يبقي الدمج داخل ذلك النطاق.

يخلق المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة، ثم يدمج الأربع خلايا المركزية من `(1, 1)` إلى `(2, 2)`. الخلية الناتجة تمتد عمودين وصفين، بينما يظل شبكة الجدول الأساسية بأربعة أعمدة وأربعة صفوف. للوصول إلى محتوى الخلية المدمجة أو تنسيقها، استخدم موقعها العلوي الأيسر: `table->idx_get(1, 1)` في هذا المثال. تبقى المواقع الأخرى في النطاق المدمج جزءًا من شبكة الجدول، لذا لا تتغير فهارس الخلايا خارج النطاق.

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

حفظ دمج الخلايا في المثال السابق شبكة الجدول. قد يؤدي تقسيم خلية إلى إدخال عمود شبكة جديد وتغيير فهارس الأعمدة للخلايا إلى يمينها. Aspose.Slides يتبع نموذج شبكة الجدول في PowerPoint.

يخلق هذا المثال جدولًا 4×4 بأعمدة وصفوف 70 نقطة ويستدعي [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) على الخلية `(1, 1)`. يتم تمرير نصف عرض الخلية 70 نقطة لإنشاء خليتين بعرض متساوٍ.

بعد هذا الانقسام، يتم الوصول إلى النصفين كـ `table->idx_get(1, 1)` و `table->idx_get(2, 1)`. أصبحت شبكة الجدول الآن تحتوي على خمسة أعمدة: الخلايا التي كانت في الأعمدة 2 و3 تنتقل إلى الأعمدة 3 و4 على التوالي. تبقى فهارس الصفوف دون تغيير. استخدم هذه الفهارس المحدثة للأعمدة عند الوصول إلى الخلايا بعد الانقسام.

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
[![خلية غير مدمجة ذات 70 نقطة تنقسم إلى خليتين 35 نقطة، مضافة عمود شبكة خامس وتحريك الفهارس إلى يمينه. الصفوف الأخرى تحتفظ بخلية تمتد عبر كلا الموضعين الجديدين للعمود.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*تقسيم العرض يؤثر على الخلية (1, 1)، باستخدام فهارس (column, row) صفرية. الصفوف الأخرى تحتفظ بخلية تمتد عبر كلا الموضعين الجديدين للعمود.*
<!-- visual-explanation:manage-cells:end -->

### **تقسيم الخلايا المدمجة حسب امتداد الصف أو العمود**

لتحضير خلايا القالب المدمجة لملء البيانات، استخدم [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) للتقسيم على طول حد صف موجود، أو [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) للتقسيم على طول حد عمود.

الوسيطة `index` تحسب الصفوف في الجزء العلوي أو الأعمدة في الجزء الأيسر من الانقسام؛ وهي نسبية إلى المنطقة المدمجة:

- تقسم الصف: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- تقسم العمود: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

يتوقع المثال أن يحتوي العرض التقديمي على جدول كشكل أول في الشريحة الأولى، مع دمج `(1, 2)` و `(1, 3)` عموديًا. بدءًا من الموضع السفلي، يستخدم [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) و[get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) لتحديد الأصل ويفحص كلا الامتدادات. ثم يقوم `SplitByRowSpan(1)` بفصل الصفين 2 و3 لأسماء المنتجات. لدمج أفقي ذو عمودين، استخدم `SplitByColSpan(1)` بدلًا من ذلك.

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

    // استرجاع الخلايا الناتجة من الجدول بعد التقسيم.
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

تظل شبكة الجدول وفهارس الخلايا المحيطة دون تغيير. استرجع الخلايا الناتجة باستخدام إحداثياتها؛ هنا، كلاهما له امتداد 1 و [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) يطبع `False`. يمكن أن تبقى المناطق الأكبر مدمجة جزئيًا بعد تقسيم واحد.

يبقى النص الأصلي وتنسيقه في الخلية العليا (أو اليسرى)؛ الخلية الجديدة فارغة لكنها ترث تنسيق الخلية مثل التعبئة والحدود والهوامش. قم بملء الخلايا بعد التقسيم واضبط أي تنسيقات نصية مطلوبة صراحة.

العرض التقديمي المحفوظ يحتوي على خلايا منفصلة "Product A" و "Product B" مع الحفاظ على تنسيق خلية القالب. راجع [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) للتفاصيل.

### **تقسيم خلية بارتفاع محدد**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) يأخذ ارتفاع الجزء العلوي بالنقاط. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) يأخذ عدد صفوف الشبكة الموجودة في الجزء العلوي. لتوسيط خلية بارتفاع 40 نقطة في العمود الأيمن، اطرح 40 من ارتفاع الخلية الفعلي ووزع المساحة المتبقية بالتساوي فوقها وتحتها.

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

يضيف الانقسام الأول صفًا إلى الشبكة، تاركًا 90 نقطة في الأسفل عند `(1, 1)`. الانقسام الثاني يستهدف تلك الخلية ويضيف صفًا آخر تحتها. يحتوي العمود الأيمن الآن على `(1, 0)` بـ 50 نقطة (`margin`)، `(1, 1)` بـ 40 نقطة، و`(1, 2)` بـ 50 نقطة (`margin`). الخلية اليسرى تمتد عبر جميع الصفوف الثلاثة بارتفاعها الأصلي 140 نقطة.

![الخلية اليسرى تمتد على كامل ارتفاع الجدول إلى جانب ثلاث خلايا مع Middle في الوسط.](split-by-height.png)

## **تغيير لون خلفية خلية الجدول**

يخلق هذا المثال جدولًا بأعمدة 150 نقطة وصفوف 50 نقطة. يستخدم [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) لاختيار تعبئة صلبة و[get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) للوصول إلى لون التعبئة وتعيينه إلى الأحمر للخلية `(2, 3)`, في العمود الثالث والصف الرابع.

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

ضع صورة الإدخال في دليل العمل قبل تشغيل هذا المثال. يقوم بتحميل الصورة عبر [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) ويضيفها إلى مجموعة صور العرض التقديمي عبر [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). ثم يعيّن الصورة إلى تعبئة الصورة للخلية `(0, 0)`, الخلية الأولى في الجدول.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) يمدد الصورة لملء الخلية، مما قد يغير نسبة أبعادها. عرض الأعمدة وارتفاع الصفوف بالنقاط. يتم تحرير الصورة المحملة بعد إضافتها إلى العرض التقديمي.

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

## **الأسئلة الشائعة**

**هل يمكنني تعيين سماكات خطوط وأنماط مختلفة للجوانب المختلفة لخلية واحدة؟**

نعم. حدود [أعلى](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[أسفل](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[يسار](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[يمين](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) لها خصائص منفصلة، لذا يمكن أن تختلف سماكة كل جانب والنمط.

**ماذا يحدث للصورة إذا غيرت حجم العمود/الصف بعد تعيين صورة كخلفية للخلية؟**

السلوك يعتمد على [وضع التعبئة](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/). (تمديد/تكرار). عند التمديد، تتكيف الصورة مع الخلية الجديدة؛ عند التكرار، يتم إعادة حساب القوالب.

**هل يمكنني تعيين ارتباط تشعبي لكامل محتوى خلية؟**

[Hyperlinks](/slides/ar/cpp/manage-hyperlinks/) يتم ضبطها على مستوى النص (الجزء) داخل إطار نص الخلية أو على مستوى الجدول/الشكل بأكمله. عمليًا، تقوم بتعيين الرابط إلى جزء أو إلى كل النص في الخلية.

**هل يمكنني تعيين خطوط مختلفة داخل خلية واحدة؟**

نعم. يدعم إطار نص الخلية [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (القطع) بتنسيق مستقل—عائلة الخط، النمط، الحجم، واللون.