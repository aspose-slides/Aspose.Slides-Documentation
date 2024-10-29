---
title: إدارة الصفوف والأعمدة
type: docs
weight: 20
url: /ar/net/manage-rows-and-columns/
keywords: "جدول، صفوف وأعمدة الجدول، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إدارة صفوف وأعمدة الجدول في عروض PowerPoint باستخدام C# أو .NET"

---

لتمكينك من إدارة صفوف وأعمدة الجدول في عرض PowerPoint، يوفر Aspose.Slides فئة [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) وواجهة [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) والعديد من الأنواع الأخرى.

## **تعيين الصف الأول كعنوان**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وقم بتحميل العرض.
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. أنشئ كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) واضبطه على null.
4. انتقل عبر جميع كائنات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعثور على الجدول المعني.
5. قم بتعيين الصف الأول من الجدول كعنوان له.

يوضح هذا الكود C# كيفية تعيين الصف الأول من الجدول كعنوان له:

```c#
// ينشئ فئة Presentation
Presentation pres = new Presentation("table.pptx");

// يصل إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// يهيئ TableEx على null
ITable tbl = null;

// يتجول في الأشكال ويضبط مرجعًا للجدول
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// يحدد الصف الأول من جدول كعنوان له
tbl.FirstRow = true;

// يحفظ العرض على القرص
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **استنساخ صف أو عمود من الجدول**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. حدد مصفوفة من `columnWidth`.
4. حدد مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة من خلال طريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. استنسخ صف الجدول.
7. استنسخ عمود الجدول.
8. احفظ العرض المعدل.

يوضح هذا الكود C# كيفية استنساخ صف أو عمود من جدول PowerPoint:

```c#
 // ينشئ فئة Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // يصل إلى الشريحة الأولى
    ISlide sld = presentation.Slides[0];

    // يحدد الأعمدة بأبعاد والصفوف بارتفاعات
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // يضيف شكل جدول إلى الشريحة
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // يضيف نصًا إلى الخلية 1 في الصف 1
    table[0, 0].TextFrame.Text = "الصف 1 الخلية 1";

    // يضيف نصًا إلى الخلية 2 في الصف 1
    table[1, 0].TextFrame.Text = "الصف 1 الخلية 2";

    // يستنسخ الصف 1 في نهاية الجدول
    table.Rows.AddClone(table.Rows[0], false);

    // يضيف نصًا إلى الخلية 1 في الصف 2
    table[0, 1].TextFrame.Text = "الصف 2 الخلية 1";

    // يضيف نصًا إلى الخلية 2 في الصف 2
    table[1, 1].TextFrame.Text = "الصف 2 الخلية 2";

    // يستنسخ الصف 2 كصف الرابع من الجدول
    table.Rows.InsertClone(3,table.Rows[1], false);

    // يستنسخ العمود الأول في النهاية
    table.Columns.AddClone(table.Columns[0], false);

    // يستنسخ العمود الثاني عند مؤشر العمود الرابع
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // يحفظ العرض على القرص 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **إزالة صف أو عمود من الجدول**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. حدد مصفوفة من `columnWidth`.
4. حدد مصفوفة من `rowHeight`.
5. أضف كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) إلى الشريحة من خلال طريقة [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. أزل صف الجدول.
7. أزل عمود الجدول.
8. احفظ العرض المعدل.

يوضح هذا الكود C# كيفية إزالة صف أو عمود من جدول:

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

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) المعني من الشريحة.
4. قم بتعيين [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) خلايا الصف الأول.
5. قم بتعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) لخلايا الصف الأول.
6. قم بتعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) لخلايا الصف الثاني.
7. احفظ العرض المعدل.

يوضح هذا الكود C# العملية.

```c#
// ينشئ مثيل لعرض Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول

// يحدد ارتفاع خط الخلايا في الصف الأول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// يحدد محاذاة النص والهامش الأيمن للخلايا في الصف الأول
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// يحدد نوع النص العمودي للخلايا في الصف الثاني
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// يحفظ العرض على القرص
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **تعيين تنسيق النص على مستوى عمود الجدول**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) وقم بتحميل العرض،
2. احصل على مرجع الشريحة من خلال مؤشرها.
3. الوصول إلى كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) المعني من الشريحة.
4. قم بتعيين [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) لخلايا العمود الأول.
5. قم بتعيين [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) و [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) لخلايا العمود الأول.
6. قم بتعيين [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) لخلايا العمود الثاني.
7. احفظ العرض المعدل.

يوضح هذا الكود C# العملية:

```c#
// ينشئ مثيل لعرض Presentation
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // لنفترض أن الشكل الأول على الشريحة الأولى هو جدول

// يحدد ارتفاع خط الخلايا في العمود الأول
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// يحدد محاذاة النص والهامش الأيمن للخلايا في العمود الأول في مكالمة واحدة
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// يحدد نوع النص العمودي لخلايا العمود الثاني
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// يحفظ العرض على القرص
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **الحصول على خصائص نمط الجدول**

يتيح لك Aspose.Slides استرداد خصائص النمط لجدول حتى تتمكن من استخدام هذه التفاصيل لجدول آخر أو في مكان آخر. يوضح هذا الكود C# كيفية الحصول على خصائص النمط من نمط جدول مسبق:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // تغيير نمط الوضع الافتراضي
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```