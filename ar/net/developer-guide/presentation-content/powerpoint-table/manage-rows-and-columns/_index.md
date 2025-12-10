---
title: إدارة الصفوف والأعمدة في جداول PowerPoint في .NET
linktitle: الصفوف والأعمدة
type: docs
weight: 20
url: /ar/net/manage-rows-and-columns/
keywords:
- صف الجدول
- عمود الجدول
- الصف الأول
- رأس الجدول
- استنساخ الصف
- استنساخ العمود
- نسخ الصف
- نسخ العمود
- إزالة الصف
- إزالة العمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides لـ .NET وتسريع تعديل العروض وتحديث البيانات."
---

لسماح لك بإدارة صفوف وأعمدة جدول في عرض تقديمي PowerPoint، توفر Aspose.Slides الفئة [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) والعديد من الأنواع الأخرى. 

## **تعيين الصف الأول كعنوان**

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي. 
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) وتعيينه إلى null. 
4. التجول بين جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعثور على الجدول المناسب. 
5. تعيين الصف الأول للجدول كعنوان له. 

هذا الكود C# يوضح لك كيفية تعيين الصف الأول للجدول كعنوان:
```c#
// يقوم بإنشاء كائن من الفئة Presentation
Presentation pres = new Presentation("table.pptx");

// الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// تهيئة TableEx كقيمة null
ITable tbl = null;

// يتنقل عبر الأشكال ويحدد إشارة إلى الجدول
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// يضبط الصف الأول للجدول كرأسه
tbl.FirstRow = true;

// يحفظ العرض التقديمي إلى القرص
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **استنساخ صف أو عمود في جدول**

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. تعريف مصفوفة `columnWidth`. 
4. تعريف مصفوفة `rowHeight`. 
5. إضافة كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. استنساخ صف الجدول. 
7. استنساخ عمود الجدول. 
8. حفظ العرض التقديمي المعدل. 

هذا الكود C# يوضح لك كيفية استنساخ صف أو عمود في جدول PowerPoint:
```c#
 // يقوم بإنشاء كائن من فئة Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = presentation.Slides[0];

    // تعريف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // إضافة شكل جدول إلى الشريحة
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // إضافة نص إلى الصف 1 الخلية 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // إضافة نص إلى الصف 1 الخلية 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // استنساخ الصف 1 في نهاية الجدول
    table.Rows.AddClone(table.Rows[0], false);

    // إضافة نص إلى الصف 2 الخلية 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // إضافة نص إلى الصف 2 الخلية 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // استنساخ الصف 2 كصف رابع في الجدول
    table.Rows.InsertClone(3,table.Rows[1], false);

    // استنساخ العمود الأول في النهاية
    table.Columns.AddClone(table.Columns[0], false);

    // استنساخ العمود الثاني في الفهرس الرابع
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // حفظ العرض التقديمي إلى القرص 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **إزالة صف أو عمود من جدول**

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. تعريف مصفوفة `columnWidth`. 
4. تعريف مصفوفة `rowHeight`. 
5. إضافة كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. إزالة صف الجدول. 
7. إزالة عمود الجدول. 
8. حفظ العرض التقديمي المعدل. 

هذا الكود C# يوضح لك كيفية إزالة صف أو عمود من جدول:
```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **تعيين تنسيق النص على مستوى صف الجدول**

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) المناسب من الشريحة. 
4. تعيين ارتفاع الخط [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) للخلوم في الصف الأول. 
5. تعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) للخلوم في الصف الأول. 
6. تعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) للخلوم في الصف الثاني. 
7. حفظ العرض التقديمي المعدل. 

هذا الكود C# يوضح العملية.
```c#
// ينشئ مثيلًا من الفئة Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول

// يحدد ارتفاع خط خلايا الصف الأول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// يضبط محاذاة نص خلايا الصف الأول والهوامش اليمنى
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// يضبط نوع النص العمودي لخلايا الصف الثاني
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// يحفظ العرض التقديمي إلى القرص
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **تعيين تنسيق النص على مستوى عمود الجدول**

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) المناسب من الشريحة. 
4. تعيين ارتفاع الخط [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) للخلوم في العمود الأول. 
5. تعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) للخلوم في العمود الأول. 
6. تعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) للخلوم في العمود الثاني. 
7. حفظ العرض التقديمي المعدل. 

هذا الكود C# يوضح العملية: 
```c#
// ينشئ مثيلًا من الفئة Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول

// يحدد ارتفاع خط خلايا العمود الأول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// يضبط محاذاة نص خلايا العمود الأول والهوامش اليمنى في استدعاء واحد
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// يحدد نوع النص العمودي لخلايا العمود الثاني
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// يحفظ العرض التقديمي إلى القرص
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الحصول على خصائص نمط الجدول**

تسمح لك Aspose.Slides باسترجاع خصائص النمط لجدول حتى تتمكن من استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يُظهر هذا الكود C# كيفية الحصول على خصائص النمط من نمط جدول محدد مسبقًا: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغيير سمة نمط الإعداد الافتراضي
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه مسبقًا؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/القالب الرئيسي، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تدعم الفرز أو الفلاتر مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد تعبئة صفوف الجدول وفقًا لهذا الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (متجانبة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعّل الأعمدة المخططة، ثم تجاوز خلايا معينة باستخدام تنسيق محلي؛ فالتنسيق على مستوى الخلية له أولوية أعلى من نمط الجدول.