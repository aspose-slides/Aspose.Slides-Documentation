---
title: مصنف الرسم البياني
type: docs
weight: 70
url: /ar/java/chart-workbook/
keywords: "مصنف الرسم البياني، بيانات الرسم البياني، عرض PowerPoint، Java، Aspose.Slides for Java"
description: "مصنف الرسم البياني في عرض PowerPoint في Java"
---

## **تعيين بيانات الرسم البياني من المصنف**
يوفر Aspose.Slides طريقتي [ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) اللتين تتيحان لك قراءة وكتابة بيانات الرسم البياني المصنفة (التي تحتوي على بيانات الرسم البياني المعدلة باستخدام Aspose.Cells). **ملاحظة** أن بيانات الرسم البياني يجب أن تكون منظمة بنفس الطريقة أو يجب أن تحتوي على هيكل مشابه للمصدر.

تظهر هذه الشفرة Java عملية عينة:

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

## **تعيين خلية المصنف كعلامة بيانات الرسم البياني**

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني فقاعي مع بعض البيانات.
1. الوصول إلى سلسلة الرسم البياني.
1. تعيين خلية المصنف كعلامة بيانات.
1. حفظ العرض التقديمي.

تظهر هذه الشفرة Java كيفية تعيين خلية مصنف كعلامة بيانات للرسم البياني:

```java
String lbl0 = "قيمة الخلية لعلامة 0";
String lbl1 = "قيمة الخلية لعلامة 1";
String lbl2 = "قيمة الخلية لعلامة 2";

// ينشئ مثيلًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي
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

توضح هذه الشفرة Java عملية حيث يتم استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

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

تظهر هذه الشفرة Java كيفية تحديد نوع لمصدر البيانات:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("نص حرفي");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **المصنف الخارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/)، قمنا بتنفيذ دعم المصنفات الخارجية كمصدر بيانات للرسم البياني.
{{% /alert %}} 

### **إنشاء مصنف خارجي**

باستخدام طريقتي **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء مصنف خارجي من الصفر أو جعل مصنف داخلي خارجي.

توضح هذه الشفرة Java عملية إنشاء المصنف الخارجي:

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

### **تعيين مصنف خارجي**

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين مصنف خارجي إلى الرسم البياني كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث المسار إلى المصنف الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تعديل البيانات في المصنفات المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام مثل هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير المسار النسبي لمصنف خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

تظهر هذه الشفرة Java كيفية تعيين مصنف خارجي:

```java
// ينشئ مثيلًا من فئة العرض التقديمي
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

معامل `ChartData` (تحت طريقة `setExternalWorkbook`) يستخدم لتحديد ما إذا كان سيتم تحميل مصنف Excel أم لا.

* عندما يتم تعيين قيمة `ChartData` إلى `false`، يتم تحديث مسار المصنف فقط - لن يتم تحميل بيانات الرسم البياني أو تحديثها من المصنف المستهدف. قد تحتاج إلى استخدام هذا الإعداد عندما تكون في موقف حيث يكون المصنف المستهدف غير موجود أو غير متاح.
* عندما يتم تعيين قيمة `ChartData` إلى `true` ، يتم تحديث بيانات الرسم البياني من المصنف المستهدف.

```java
// ينشئ مثيلًا من فئة العرض التقديمي
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

### **الحصول على مسار مصنف بيانات الرسم البياني الخارجي**

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إنشاء كائن لشكل الرسم البياني.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات الرسم البياني.
1. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفس النوع الخارجي لمصدر بيانات المصنف.

توضح هذه الشفرة Java العملية:

```java
// ينشئ مثيلًا من فئة العرض التقديمي
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

### **تحرير بيانات الرسم البياني**

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تقوم بها بإجراء تغييرات على محتويات المصنفات الداخلية. عند عدم القدرة على تحميل مصنف خارجي، يتم طرح استثناء.

هذه الشفرة Java هي تنفيذ للعملية الموصوفة:

```java
// ينشئ مثيلًا من فئة العرض التقديمي
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