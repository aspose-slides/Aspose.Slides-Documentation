---
title: إدارة الصفوف والأعمدة في جداول PowerPoint باستخدام C++
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/cpp/manage-rows-and-columns/
keywords:
- صف جدول
- عمود جدول
- الصف الأول
- رأس جدول
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط جدول
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides لـ C++ وتسريع تحرير العروض التقديمية وتحديثات البيانات."
---
## **مقدمة**

Aspose.Slides for C++ يتيح لك إدارة بنية الجدول وتنسيقه في عروض PowerPoint من خلال الفئة [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). يمكنك تعيين صف رأس، استنساخ أو إزالة الصفوف والأعمدة، وتطبيق تنسيق النص على صف أو عمود كامل.

تشرح هذه المقالة هذه العمليات مع أمثلة C++. كما تُظهر كيفية استرجاع نمط الجدول المسبق بحيث يمكنك إعادة استخدامها. مؤشرات الصفوف والأعمدة في الجدول تبدأ من الصفر.

## **التحكم في ارتفاع الصف**

استخدم [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) لتعيين الحد الأدنى لارتفاع الصف بالنقاط. إنه حد أدنى وليس ارتفاعًا ثابتًا. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) يُعيد الارتفاع الفعلي؛ لا يمكن تعيين هذه القيمة مباشرة. يمكنك الوصول إلى الصف عبر [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

المثال يحمل الملف [row-height-input.pptx](row-height-input.pptx)، الذي يحتوي على جدول كأول شكل في الشريحة الأولى. يبدأ صفه الأول عند 70 نقطة. الخلايا تستخدم نص Arial بحجم 18 نقطة، وتغليف، وهوامش علوية وسفلية بمقدار 6 نقاط؛ النص الطويل في العمود الثاني يلتف إلى عدة أسطر. يزيد المثال الحد الأدنى إلى 100 نقطة، ثم يقلّله إلى 20 نقطة، ويطبع الارتفاع الفعلي بعد كل تغيير، ويحفظ النتيجتين.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

مع العرض المرفق، يؤدي زيادة الحد الأدنى إلى إضافة مساحة إلى الصف. تقليل الحد يقلل من تلك المساحة الإضافية، لكن الارتفاع الفعلي يظل أكبر من 20 نقطة لأن النص وهوامش الخلية تحتاج إلى مساحة أكبر. لا يمكن لتقليل الحد الأدنى وحده أن يجبر الصف على أن يكون أقل من المساحة المطلوبة لمحتواه.

عدة عوامل تؤثر على الارتفاع الفعلي:

- **النص وحجم الخط:** النص الطويل، فواصل الأسطر الصريحة، أو الخط الأكبر قد يتطلب مساحة رأسية أكبر.
- **التغليف وعرض العمود:** مع تمكين التغليف، يمكن لتقليل عرض العمود عبر [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) إنتاج أسطر أكثر. العمود الأعرض قد يقلل المساحة الرأسية المطلوبة.
- **هوامش الخلية:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) و[ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) يتحكمان في الهوامش التي تضيف مساحة رأسية. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) و[ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) يتحكمان في الهوامش التي تقلل العرض المتاح للنص ويمكن أن تسبب تغليفًا إضافيًا.

في هذا الجدول بدون خلايا مدمجة، تحدد الخلية التي تحتاج إلى أكبر مساحة رأسية الحد الأدنى للمحتوى للصف بأكمله. لتقليل ارتفاع الصف، قد تحتاج أيضًا إلى تقصير النص، أو تقليل حجم الخط أو الهوامش، أو توسيع عمود.

تظهر الصور أدناه نفس الجدول بنفس المقياس. في تشغيل .NET المرجعي المعروض هنا، كانت الارتفاعات الفعلية 70 و100 و55.2 نقطة: بقي الصف الأخير أطول من الحد الأدنى البالغ 20 نقطة. يمكن أن تختلف قياسات النص الدقيقة مع الخطوط المتاحة في بيئتك. قم بتنزيل النتائج المحفوظة: [increased minimum](row-height-increased.pptx) و[decreased minimum](row-height-decreased.pptx).

| الأصل: الحد الأدنى 70 نقطه، الارتفاع الفعلي 70 نقطه | الزيادة: الحد الأدنى 100 نقطه، الارتفاع الفعلي 100 نقطه | التخفيض: الحد الأدنى 20 نقطه، الارتفاع الفعلي 55.2 نقطه |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **تعيين الصف الأول كعنوان**

استخدم الطريقة [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) لتحديد الصف الأول لتنسيق العنوان. مظهره يعتمد على نمط الجدول المطبق على الجدول.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على الشريحة الأولى.
3. احصل على الجدول المخزن كأول شكل في الشريحة.
4. فعّل تنسيق العنوان للصف الأول.
5. احفظ العرض المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى. يقوم بتمكين تنسيق العنوان للصف الأول ويحفظه كـ `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **استنساخ صف أو عمود في الجدول**

استنسخ الصفوف أو الأعمدة لإعادة استخدام محتواها وتنسيقها. يمكنك إضافة نسخة إلى نهاية الجدول أو إدراجها في موضع محدد.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على الشريحة الأولى.
3. حدّد عروض الأعمدة وارتفاعات الصفوف.
4. أضف جدولًا باستخدام الطريقة [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. استنسخ الصفوف المطلوبة.
6. استنسخ الأعمدة المطلوبة.
7. احفظ العرض المعدل.

المثال يتطلب `Test.pptx` يحتوي على شريحة واحدة على الأقل. يُنشئ جدولًا بثلاثة أعمدة وخمسة صفوف، بأبعاد محددة بالنقاط. يضيف نسخًا من الصف والعمود الأول، ثم يُدرج نسخًا من الصف والعمود الثاني في الفهرس 3 (الموضع الرابع). يصبح الجدول الناتج مكوّنًا من سبعة صفوف وخمسة أعمدة. الوسيط `false` يُعطّل الاستنساخ في الصفوف أو الأعمدة المجاورة المدمجة؛ لا يحتوي هذا الجدول على خلايا مدمجة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **إزالة صف أو عمود من الجدول**

إزالة الصفوف أو الأعمدة التي لم تعد تحتاجها في الجدول. يغيّر إزالة عنصر مؤشرات الصفوف أو الأعمدة التي تليه.

1. أنشئ عرضًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على الشريحة الأولى.
3. حدّد عروض الأعمدة وارتفاعات الصفوف.
4. أضف جدولًا باستخدام الطريقة [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. أزل الصف الثاني والعمود الثاني.
6. احفظ العرض المعدل.

هذا المثال يُنشئ جدولًا من ثلاثة في ثلاثة ويزيل الصف والعمود في الفهرس 1، ليبقى جدولًا من اثنين في اثنين في `TestTable_out.pptx`. الأبعاد بالنقاط. الوسيط `false` يُعطّل إزالة الصفوف أو الأعمدة المجاورة المدمجة؛ لا يحتوي هذا الجدول على خلايا مدمجة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **تطبيق تنسيق النص على مستوى صف الجدول**

طبق تنسيق النص على صف كامل للحفاظ على تساوي خلاياه. يمكنك تعيين خصائص الخط، وتنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على الجدول في الشريحة الأولى.
3. عيّن ارتفاع الخط باستخدام [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) للصف الأول.
4. عيّن المحاذاة والهوامش اليمنى للفقرة باستخدام [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و[set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) للصف الأول.
5. عيّن اتجاه النص باستخدام [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) للصف الثاني.
6. احفظ العرض المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى وعلى الأقل صفين. يطبق نصًا بحجم 25 نقطة، ومحاذاة إلى اليمين، وهوامش فقرة يمينية بمقدار 20 نقطة على الصف الأول، ثم يضبط النص العمودي في الصف الثاني.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **تطبيق تنسيق النص على مستوى عمود الجدول**

طبق تنسيق النص على عمود كامل للحفاظ على تساوي خلاياه. يمكنك تعيين خصائص الخط، وتنسيق الفقرة، واتجاه النص دون تنسيق كل خلية على حدة.

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. احصل على الجدول في الشريحة الأولى.
3. عيّن ارتفاع الخط باستخدام [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) للعمود الأول.
4. عيّن المحاذاة والهوامش اليمنى للفقرة باستخدام [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) و[set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) للعمود الأول.
5. عيّن اتجاه النص باستخدام [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) للعمود الثاني.
6. احفظ العرض المعدل.

المثال يتطلب `table.pptx` يحتوي على جدول كأول شكل في الشريحة الأولى وعلى الأقل عمودين. يطبق نصًا بحجم 25 نقطة، ومحاذاة إلى اليمين، وهوامش فقرة يمينية بمقدار 20 نقطة على العمود الأول، ثم يضبط النص العمودي في العمود الثاني.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **الحصول على خصائص نمط الجدول**

استخدم الطريقة [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) لاسترجاع النمط المطبق على جدول وإعادة استخدامه في جدول آخر. هذا يحدد النمط مسبقًا بدلاً من تجاوز تنسيقات الخلايا الفردية.

المثال يُنشئ جدولًا، يطبق [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/)، ويقرأ النمط مرة أخرى. يطبع `DarkStyle1` ويحفظ الجدول في `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه مسبقًا؟**

نعم. يورث الجدول سمة الشريحة/التخطيط/الماستر، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز أو فلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول بهذا الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (مخططة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعّل الأعمدة المخططة، ثم تجاوز خلايا محددة بالتنسيق المحلي؛ تنسيق الخلية يتفوق على نمط الجدول.