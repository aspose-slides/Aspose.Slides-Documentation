---
title: إدارة دفاتر العمل الخاصة بالمخططات في العروض التقديمية باستخدام Java
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- مخزن المخطط المؤقت
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides للـ Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتسهيل بيانات عرضك التقديمي."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر العمل الخاصة بالمخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
توفر Aspose.Slides طريقتي [ReadWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData#readWorkbookStream--) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) اللتين تسمحان بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملحوظة** أن بيانات المخطط يجب أن تُنظم بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

هذا الكود Java يوضح عملية نموذجية:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين خلية دفتر عمل كعنوان بيانات المخطط**

1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/ar/java/com.aspose.slides/presentation) .
1. الحصول على مرجع الشريحة عبر فهرسها.
1. إضافة مخطط فقاعة مع بعض البيانات.
1. الوصول إلى سلسل المخطط.
1. تعيين خلية دفتر العمل كعنوان بيانات.
1. حفظ العرض التقديمي.

هذا الكود Java يوضح كيفية تعيين خلية دفتر عمل كعنوان بيانات المخطط:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// يقوم بإنشاء كائن من فئة العرض التقديمي التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة أوراق العمل**

هذا الكود Java يوضح عملية يتم فيها استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحديد نوع مصدر البيانات**

هذا الكود Java يوضح كيفية تحديد نوع لمصدر البيانات:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اكتشاف صيغ دفاتر العمل المدمجة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام طريقة `getEmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/WorkbookType) لاكتشاف الصيغ غير المدعومة وتجاوز تلك المخططات.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // دفتر العمل المدمج بصيغة .xlsb غير مدعوم.
            continue;
        }

        // اقرأ أو عدّل بيانات دفتر عمل المخطط هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/ar/java/aspose-slides-for-java-19-4-release-notes/)، قمنا بتنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**

باستخدام طريقتي **`readWorkbookStream`** و**`setExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

هذا الكود Java يوضح عملية إنشاء دفتر عمل خارجي:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تخصيص دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

في حين لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر العمل الخارجي، يتم تحويله إلى مسار كامل تلقائيًا.

هذا الكود Java يوضح كيفية تعيين دفتر عمل خارجي:

```java
// ينشئ مثلاً من فئة Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

معامل `ChartData` (تحت طريقة `setExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما تُضبط قيمة `ChartData` على `false`، يتم فقط تحديث مسار دفتر العمل — لن يتم تحميل أو تحديث بيانات المخطط من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.
* عندما تُضبط قيمة `ChartData` على `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

```java
// ينشئ مثلاً من فئة Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **الحصول على مسار مصدر البيانات الخارجي لدفتر العمل الخاص بالمخطط**

1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/ar/java/com.aspose.slides/presentation) .
1. الحصول على مرجع الشريحة عبر فهرسها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على ما إذا كان نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

هذا الكود Java يوضح العملية:

```java
// ينشئ مثلاً من فئة Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// يحفظ العرض التقديمي
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تقوم بها بتعديل محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إلقاء استثناء.

هذا الكود Java هو تنفيذ للعملية الموضحة:

```java
// ينشئ مثلاً من فئة Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استعادة دفتر عمل من ذاكرة المخطط المؤقتة**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزَّنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/)، وكمّنه باستخدام [SpreadsheetOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/spreadsheetoptions/)، ثم استدعِ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) مع `true` قبل فتح العرض التقديمي.

المثال التالي بلغة Java يفتح عرضًا تقديميًا يرتبط مخططه بدفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [IChart.getChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#getChartData--) و[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // اقرأ أو عدّل بيانات دفتر العمل المستعاد هنا.
} finally {
    presentation.dispose();
}
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، فإن Aspose.Slides يلقي استثناءً. فعّل الاستعادة فقط عندما تكون استخدام البيانات المخزَّنة مؤقتًا كخيار احتياطي مقبول، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getDataSourceType--) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا قمت بتحديد مسار نسبي، يتم تحويله تلقائيًا إلى مسار مطلق. هذا يسهل قابلية نقل المشروع؛ مع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكية؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. المنهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](/cells/java/)) والربط بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا أشار جميعها إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.