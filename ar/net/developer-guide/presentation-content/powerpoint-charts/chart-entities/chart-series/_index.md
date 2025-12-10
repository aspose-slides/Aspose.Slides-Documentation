---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية في .NET
linktitle: سلسلة البيانات
type: docs
url: /ar/net/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط في C# لبرنامج PowerPoint (PPT/PPTX) مع أمثلة شفرة عملية وأفضل الممارسات لتعزيز عروض البيانات الخاصة بك."
---

## **نظرة عامة**

تصف هذه المقالة دور [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) في Aspose.Slides for .NET، مع التركيز على كيفية هيكلة البيانات وتصويرها داخل العروض التقديمية. توفر هذه الكائنات العناصر الأساسية التي تُعرّف مجموعات نقاط البيانات والفئات ومعلمات المظهر في المخطط. من خلال العمل مع [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/)، يمكن للمطورين دمج مصادر البيانات الأساسية بسلاسة والحفاظ على التحكم الكامل في طريقة عرض المعلومات، مما ينتج عروضًا تقديمية ديناميكية مدفوعة بالبيانات تنقل الرؤى والتحليل بوضوح.

السلسلة هي صف أو عمود من الأرقام يتم تمثيله في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

يُتحكم خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) في طريقة تداخل الأشرطة والأعمدة في مخطط ثنائي الأبعاد عن طريق تحديد نطاق من -100 إلى 100. نظرًا لأن هذه الخاصية مرتبطة بمجموعة السلاسل وليس بسلسلة مخطط فردية، فهي للقراءة فقط على مستوى السلسلة. لتكوين قيم التداخل، استخدم خاصية `ParentSeriesGroup.Overlap` القابلة للقراءة والكتابة، والتي تُطبق التداخل المحدد على جميع السلاسل في تلك المجموعة.

فيما يلي مثال C# يوضح كيفية إنشاء عرض تقديمي، إضافة مخطط عمودي متجمع، الوصول إلى أول سلسلة مخطط، تكوين إعداد التداخل، ثم حفظ النتيجة كملف PPTX:
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط عمودي متجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // تعيين تداخل السلسلة.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // حفظ ملف العرض التقديمي على القرص.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![The series overlap](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

يسهّل Aspose.Slides تخصيص ألوان تعبئة سلاسل المخططات، مما يتيح لك إبراز نقاط بيانات معينة وإنشاء مخططات جذابة بصريًا. يتم ذلك عبر كائن [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/)، الذي يدعم أنواع تعبئة مختلفة، وتكوينات ألوان، وخيارات تنسيق متقدمة أخرى. بعد إضافة مخطط إلى شريحة والوصول إلى السلسلة المطلوبة، احصل ببساطة على السلسلة وطبق لون التعبئة المناسب. إلى جانب التعبئات الصلبة، يمكنك أيضًا الاستفادة من التعبئات المتدرجة أو النمطية لمزيد من المرونة في التصميم. بمجرد ضبط الألوان وفقًا لمتطلباتك، احفظ العرض التقديمي لإنهاء المظهر المحدث.

يوضح مثال C# التالي كيفية تغيير لون السلسلة الأولى:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط عمودي متجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // تعيين لون السلسلة الأولى.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // حفظ ملف العرض التقديمي على القرص.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![The color of the series](series_color.png)

## **تغيير اسم السلسلة** 

يوفر Aspose.Slides طريقة بسيطة لتعديل أسماء سلاسل المخططات، مما يسهل تسمية البيانات بشكل واضح ومعبّر. من خلال الوصول إلى خلية ورقة العمل ذات الصلة في بيانات المخطط، يمكن للمطورين تخصيص طريقة عرض البيانات. يكون هذا التعديل مفيدًا خصوصًا عندما تحتاج أسماء السلاسل إلى تحديث أو توضيح بناءً على سياق البيانات. بعد إعادة تسمية السلسلة، يمكن حفظ العرض التقديمي لتثبيت التغييرات. 

فيما يلي مقطع شفرة C# يوضح هذه العملية عمليًا.
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط عمودي متجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // تعيين اسم السلسلة الأولى.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // حفظ ملف العرض التقديمي على القرص.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


يوضح الشيفرة التالية في C# طريقة بديلة لتغيير اسم السلسلة:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط عمودي متجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // تعيين اسم السلسلة الأولى.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // حفظ ملف العرض التقديمي على القرص.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![The series name](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

يتيح Aspose.Slides for .NET الحصول على لون التعبئة التلقائي لسلاسل المخططات داخل منطقة الرسم. بعد إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يمكنك الحصول على مرجع للشريحة المطلوبة حسب الفهرس، ثم إضافة مخطط باستخدام النوع المفضل لديك (مثل `ChartType.ClusteredColumn`). من خلال الوصول إلى السلاسل في المخطط، يمكنك الحصول على لون التعبئة التلقائي.

يوضح كود C# أدناه هذه العملية بالتفصيل.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة مخطط عمودي متجمع بالبيانات الافتراضية.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // الحصول على لون تعبئة السلسلة.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


الإخراج:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **تعيين لون تعبئة معكوس لسلسلة مخطط**

عند احتواء سلسلة البيانات الخاصة بك على قيم إيجابية وسلبية، قد يجعل تلوين كل عمود أو شريط بنفس اللون المخطط صعب القراءة. يسمح لك Aspose.Slides for .NET بتعيين لون تعبئة معكوس—تعبئة منفصلة تُطبق تلقائيًا على نقاط البيانات التي تقع تحت الصفر—لتمييز القيم السلبية بنظرة واحدة. في هذا القسم ستتعلم كيفية تمكين هذا الخيار، اختيار اللون المناسب، وحفظ العرض التقديمي المحدث.

يوضح المثال التالي عملية التنفيذ:
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // إضافة فئات جديدة.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // إضافة سلسلة جديدة.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // ملء بيانات السلسلة.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // تعيين إعدادات اللون للسلسلة.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![The inverted solid fill color](inverted_solid_fill_color.png)

يمكنك عكس لون التعبئة لنقطة بيانات واحدة بدلاً من السلسلة بأكملها. ما عليك سوى الوصول إلى `IChartDataPoint` المطلوبة وتعيين خاصية `InvertIfNegative` إلى `true`.

يوضح المثال التالي كيفية القيام بذلك:
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

    // عكس اللون إذا كانت نقطة البيانات عند الفهرس 2 سالبة.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **مسح قيم نقاط البيانات المحددة**

في بعض الأحيان يحتوي مخطط على قيم اختبارية أو قيم شاذة أو مدخلات قديمة تحتاج إلى إزالتها دون إعادة بناء السلسلة بالكامل. يتيح لك Aspose.Slides for .NET استهداف أي نقطة بيانات حسب الفهرس، مسح محتواها، وتحديث الرسم فورًا بحيث تتحرك النقاط المتبقية وتُعاد موازنة المحاور تلقائيًا.

يوضح المثال التالي العملية:
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

يتحكم عرض الفجوة في كمية المسافة الفارغة بين الأعمدة أو الأشرطة المتجاورة—فالفجوات الأوسع تُبرز الفئات الفردية، بينما الفجوات الأضيق تُنشئ مظهرًا أكثر كثافة وتجمعًا. من خلال Aspose.Slides for .NET يمكنك ضبط هذا المعامل لسلسلة كاملة، مما يتيح تحقيق التوازن البصري المطلوب في العرض التقديمي دون تعديل البيانات الأساسية.

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

    // حفظ العرض التقديمي على القرص.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // تعيين قيمة GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // حفظ العرض التقديمي على القرص.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![The gap width](gap_width.png)

## **الأسئلة المتكررة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

لا يفرض Aspose.Slides حدًا ثابتًا لعدد السلاسل التي يمكنك إضافتها. الحد العملي يحدده قابلية قراءة المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة متقاربة جدًا أو متباعدة جدًا؟**

قم بضبط إعداد `GapWidth` لتلك السلسلة (أو مجموعة السلاسل الأصل). يؤدي زيادة القيمة إلى توسيع المسافة بين الأعمدة، بينما يؤدي تقليلها إلى تقريبها من بعضها.