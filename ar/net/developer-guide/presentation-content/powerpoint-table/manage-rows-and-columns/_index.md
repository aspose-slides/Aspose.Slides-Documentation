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
- استنساخ صف
- استنساخ عمود
- نسخ صف
- نسخ عمود
- إزالة صف
- إزالة عمود
- تنسيق نص الصف
- تنسيق نص العمود
- نمط الجدول
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: إدارة صفوف وأعمدة الجداول في PowerPoint باستخدام Aspose.Slides لـ .NET وتسريع تحرير العروض التقديمية وتحديث البيانات.
---

للسماح لك بإدارة صفوف وأعمدة جدول في عرض تقديمي PowerPoint، توفر Aspose.Slides الصنف [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) والواجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) والعديد من الأنواع الأخرى. 

## **تعيين الصف الأول كعنوان**

1. إنشاء نسخة من الصنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي. 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) وتعيينه إلى null. 
4. التنقل عبر جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعثور على الجدول المناسب. 
5. تعيين الصف الأول للجدول كعنوان له. 

```c#
// ينشئ كائن الفئة Presentation
Presentation pres = new Presentation("table.pptx");

// يصل إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// يهيئ TableEx ليكون null
ITable tbl = null;

// يتنقل عبر الأشكال ويحدد مرجعًا للجدول
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// يُعيّن الصف الأول للجدول كعنوان
tbl.FirstRow = true;

// يحفظ العرض التقديمي على القرص
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **استنساخ صف أو عمود الجدول**

1. إنشاء نسخة من الصنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. تعريف مصفوفة من `columnWidth`. 
4. تعريف مصفوفة من `rowHeight`. 
5. إضافة كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. استنساخ صف الجدول. 
7. استنساخ عمود الجدول. 
8. حفظ العرض التقديمي المعدل. 

```c#
 // ينشئ كائن الفئة Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = presentation.Slides[0];

    // تعريف الأعمدة بعرضها والصفوف بارتفاعها
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // إضافة شكل جدول إلى الشريحة
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // إضافة نص إلى الخلية 1 في الصف 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // إضافة نص إلى الخلية 2 في الصف 1
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // استنساخ الصف 1 في نهاية الجدول
    table.Rows.AddClone(table.Rows[0], false);

    // إضافة نص إلى الخلية 1 في الصف 2
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // إضافة نص إلى الخلية 2 في الصف 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // استنساخ الصف 2 كـ الصف الرابع في الجدول
    table.Rows.InsertClone(3,table.Rows[1], false);

    // استنساخ العمود الأول في النهاية
    table.Columns.AddClone(table.Columns[0], false);

    // استنساخ العمود الثاني في الفهرس الرابع للعمود
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // حفظ العرض التقديمي على القرص 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **إزالة صف أو عمود من الجدول**

1. إنشاء نسخة من الصنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. تعريف مصفوفة من `columnWidth`. 
4. تعريف مصفوفة من `rowHeight`. 
5. إضافة كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة عبر الطريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. إزالة صف الجدول. 
7. إزالة عمود الجدول. 
8. حفظ العرض التقديمي المعدل. 

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

1. إنشاء نسخة من الصنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) المناسب من الشريحة. 
4. تعيين [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) لخلايا الصف الأول. 
5. تعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) لخلايا الصف الأول. 
6. تعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) لخلايا الصف الثاني. 
7. حفظ العرض التقديمي المعدل. 

```c#
 // ينشئ مثيلاً من فئة Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول

// يحدد ارتفاع خط خلايا الصف الأول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// يحدد محاذاة النص في خلايا الصف الأول والهوامش اليمنى
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// يحدد نوع الاتجاه العمودي للنص في خلايا الصف الثاني
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// يحفظ العرض التقديمي على القرص
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **تعيين تنسيق النص على مستوى عمود الجدول**

1. إنشاء نسخة من الصنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتحميل العرض التقديمي، 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) المناسب من الشريحة. 
4. تعيين [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) لخلايا العمود الأول. 
5. تعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) لخلايا العمود الأول. 
6. تعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) لخلايا العمود الثاني. 
7. حفظ العرض التقديمي المعدل. 

```c#
// ينشئ مثيلاً من فئة Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول في الشريحة الأولى هو جدول

// يحدد ارتفاع خط خلايا العمود الأول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// يحدد محاذاة النص والهوامش اليمنى لخلايا العمود الأول في استدعاء واحد
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// يحدد نوع الاتجاه العمودي للنص في خلايا العمود الثاني
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// يحفظ العرض التقديمي على القرص
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **الحصول على خصائص نمط الجدول**

Aspose.Slides تمكنك من جلب خصائص النمط لجدول بحيث يمكنك استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح لك هذا الكود C# كيفية الحصول على خصائص النمط من نمط جدول مسبق الإعداد: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغيير السمة المسبقة الافتراضية 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمات/أنماط PowerPoint على جدول تم إنشاؤه بالفعل؟**

نعم. يرث الجدول سمة الشريحة/التخطيط/القالب الرئيسي، ولا يزال بإمكانك تجاوز التعبئات والحدود وألوان النص فوق تلك السمة.

**هل يمكنني فرز صفوف الجدول كما في Excel؟**

لا، جداول Aspose.Slides لا تحتوي على فرز أو عوامل تصفية مدمجة. قم بفرز البيانات في الذاكرة أولاً، ثم أعد ملء صفوف الجدول بهذا الترتيب.

**هل يمكنني الحصول على أعمدة مخططة (مقشرة) مع الحفاظ على ألوان مخصصة لخلايا معينة؟**

نعم. فعّل الأعمدة المخططة، ثم قم بتجاوز خلايا معينة بالتنسيق المحلي؛ حيث أن تنسيق الخلية له أولوية أعلى من نمط الجدول.