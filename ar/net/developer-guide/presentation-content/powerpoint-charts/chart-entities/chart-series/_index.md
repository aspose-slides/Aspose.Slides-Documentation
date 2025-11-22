---
title: إدارة سلاسل المخططات في C#
linktitle: سلاسل المخطط
type: docs
url: /ar/net/chart-series/
keywords:
- سلسلة مخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة بيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- C#
- .NET
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخططات في C# لبرنامج PowerPoint (PPT/PPTX) مع أمثلة عملية على الشيفرة وأفضل الممارسات لتحسين عروض البيانات الخاصة بك."
---

## **نظرة عامة**

تصف هذه المقالة دور [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) في Aspose.Slides for .NET، مع التركيز على كيفية تنظيم البيانات وتصورها داخل العروض التقديمية. توفر هذه الكائنات العناصر الأساسية التي تحدد مجموعات فردية من نقاط البيانات والفئات ومعلمات المظهر في المخطط. من خلال العمل مع [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/)، يمكن للمطورين دمج مصادر البيانات الأساسية بسهولة والحفاظ على التحكم الكامل في طريقة عرض المعلومات، مما ينتج عروضًا تقديمية ديناميكية تعتمد على البيانات وتوضح الأفكار والتحليل بوضوح.

السلسلة هي صف أو عمود من الأرقام يتم تمثيله في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تحديد تداخل سلسلة المخططات**

تتحكم الخاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) في كيفية تداخل الأشرطة والأعمدة في مخطط ثنائي الأبعاد عن طريق تحديد نطاق من -100 إلى 100. نظرًا لأن هذه الخاصية مرتبطة بمجموعة السلسلة بدلاً من السلسلة الفردية للمخطط، فهي للقراءة فقط على مستوى السلسلة. لتكوين قيم التداخل، استخدم الخاصية `ParentSeriesGroup.Overlap` القابلة للقراءة والكتابة، والتي تطبق التداخل المحدد على جميع السلاسل في تلك المجموعة.

فيما يلي مثال C# يوضح كيفية إنشاء عرض تقديمي، إضافة مخطط عمود مُجَمَّع، الوصول إلى أول سلسلة مخطط، تكوين إعداد التداخل، ثم حفظ النتيجة كملف PPTX:
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف مخطط عمود مجمع مع البيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // اضبط تداخل السلسلة.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // احفظ ملف العرض التقديمي إلى القرص.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

تجعل Aspose.Slides من السهل تخصيص ألوان تعبئة سلاسل المخططات، مما يتيح لك تمييز نقاط البيانات المحددة وإنشاء مخططات جذابة بصريًا. يتم ذلك عبر كائن [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/) الذي يدعم أنواعًا متعددة من التعبئة، وتكوينات اللون، وخيارات تنسيق متقدمة أخرى. بعد إضافة مخطط إلى شريحة والوصول إلى السلسلة المطلوبة، احصل على السلسلة وطبق لون التعبئة المناسب. بالإضافة إلى التعبئة الصلبة، يمكنك أيضًا الاستفادة من التعبئات المتدرجة أو النمطية للحصول على مرونة تصميمية محسنة. بمجرد ضبط الألوان وفقًا لمتطلباتك، احفظ العرض التقديمي لإكمال المظهر المحدث.

يظهر المثال التالي بلغة C# كيفية تغيير لون السلسلة الأولى:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف مخطط عمود مجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // حدد لون السلسلة الأولى.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // احفظ ملف العرض التقديمي إلى القرص.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

توفر Aspose.Slides طريقة بسيطة لتعديل أسماء سلاسل المخططات، مما يسهل تسمية البيانات بطريقة واضحة ومفهومة. من خلال الوصول إلى خلية ورقة العمل ذات الصلة في بيانات المخطط، يمكن للمطورين تخصيص طريقة عرض البيانات. يكون هذا التعديل مفيدًا خصوصًا عندما يحتاج أسماء السلاسل إلى تحديث أو توضيح بناءً على سياق البيانات. بعد إعادة تسمية السلسلة، يمكن حفظ العرض التقديمي للحفاظ على التغييرات.

فيما يلي مقتطف كود C# يوضح هذا العملية عمليًا.
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف مخطط عمود مجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // حدد اسم السلسلة الأولى.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // احفظ ملف العرض التقديمي إلى القرص.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


يعرض الكود التالي بلغة C# طريقة بديلة لتغيير اسم السلسلة:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف مخطط عمود مجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // اضبط اسم السلسلة الأولى.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // احفظ ملف العرض التقديمي إلى القرص.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

تتيح Aspose.Slides for .NET الحصول على لون التعبئة التلقائي لسلاسل المخططات داخل منطقة الرسم. بعد إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يمكنك الحصول على مرجع للشفرة المطلوبة عن طريق الفهرس، ثم إضافة مخطط باستخدام النوع المفضل لديك (مثل `ChartType.ClusteredColumn`). من خلال الوصول إلى السلسلة في المخطط، يمكنك الحصول على لون التعبئة التلقائي.

يوضح كود C# أدناه هذه العملية بالتفصيل.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف مخطط عمود مجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // احصل على لون تعبئة السلسلة.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


المخرجات:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **تعيين لون تعبئة معكوس لسلسلة المخطط**

عندما تحتوي سلسلة البيانات الخاصة بك على قيم موجبة وسالبة، فإن تلوين كل عمود أو شريط بنفس اللون قد يجعل المخطط صعب القراءة. تتيح Aspose.Slides for .NET تعيين لون تعبئة معكوس — تعبئة منفصلة تُطبق تلقائيًا على نقاط البيانات التي تقع تحت الصفر — بحيث تبرز القيم السالبة بسهولة. في هذا القسم ستتعلم كيفية تمكين هذا الخيار، اختيار اللون المناسب، وحفظ العرض التقديمي المحدث.

يُظهر المثال التالي الكود العملية:
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // أضف فئات جديدة.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // أضف سلسلة جديدة.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // املأ بيانات السلسلة.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // اضبط إعدادات اللون للسلسلة.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![لون التعبئة الصلبة المعكوس](inverted_solid_fill_color.png)

يمكنك عكس لون التعبئة لنقطة بيانات واحدة بدلاً من السلسلة بأكملها. ما عليك سوى الوصول إلى `IChartDataPoint` المطلوب وضبط خاصية `InvertIfNegative` إلى true.

يظهر المثال التالي كيفية القيام بذلك:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // عكس اللون إذا كانت نقطة البيانات في الفهرس 2 سلبية.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **مسح قيم نقاط البيانات المحددة**

في بعض الأحيان يحتوي المخطط على قيم اختبار، أو قيم شاذة، أو إدخالات قديمة تحتاج إلى إزالتها دون إعادة بناء السلسلة بالكامل. تتيح Aspose.Slides for .NET استهداف أي نقطة بيانات بواسطة الفهرس، مسح محتواها، وتحديث المخطط فورًا بحيث يتم تحريك النقاط المتبقية وإعادة ضبط المحاور تلقائيًا.

يوضح المثال التالي الكود العملية:
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```


## **تعيين عرض الفجوة للسلسلة**

يتحكم عرض الفجوة في كمية المساحة الفارغة بين الأعمدة أو الأشرطة المتجاورة — الفجوات الأوسع تبرز الفئات الفردية، بينما الفجوات الضيقة تخلق مظهرًا أكثر كثافة وتماسكًا. عبر Aspose.Slides for .NET يمكنك ضبط هذا المعامل بدقة لسلسلة كاملة، للحصول على التوازن البصري المطلوب في عرضك التقديمي دون تعديل البيانات الأساسية.

يوضح المثال التالي كيفية تعيين عرض الفجوة لسلسلة:
```cs
ushort gapWidth = 30;

// إنشاء عرض تقديمي فارغ.
using (Presentation presentation = new Presentation())
{
    // الوصول إلى الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // تعيين قيمة GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![عرض الفجوة](gap_width.png)

## **الأسئلة الشائعة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

لا تفرض Aspose.Slides حدًا ثابتًا لعدد السلاسل التي يمكنك إضافتها. الحد العملي يحدده قابلية قراءة المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة ما قريبًا جدًا أو بعيدًا جدًا عن بعضها؟**

قم بضبط إعداد `GapWidth` لتلك السلسلة (أو مجموعة السلاسل الأم). زيادة القيمة توسع المسافة بين الأعمدة، بينما تقليلها يقربها من بعضها.