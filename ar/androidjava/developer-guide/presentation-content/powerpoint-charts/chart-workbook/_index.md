---
title: مصنف الرسم البياني
type: docs
weight: 70
url: /ar/androidjava/chart-workbook/
keywords: "مصنف الرسم البياني، بيانات الرسم البياني، عرض PowerPoint، Java، Aspose.Slides for Android عبر Java"
description: "مصنف الرسم البياني في عرض PowerPoint باستخدام Java"
---

## **تعيين بيانات الرسم البياني من المصنف**
توفر Aspose.Slides طرق [ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) التي تتيح لك قراءة وكتابة مصنفات بيانات الرسم البياني (التي تحتوي على بيانات رسم بياني تم تحريرها باستخدام Aspose.Cells). **ملحوظة**: يجب تنظيم بيانات الرسم البياني بنفس الطريقة أو أن يكون لها هيكل مشابه للمصدر.

يوضح هذا الكود Java عملية عينة:

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

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني فقاعي مع بعض البيانات.
1. الوصول إلى سلسلة الرسم البياني.
1. تعيين خلية المصنف كعلامة بيانات.
1. حفظ العرض التقديمي.

يوضح لك هذا الكود Java كيفية تعيين خلية مصنف كعلامة بيانات الرسم البياني:

```java
String lbl0 = "قيمة خلية العلامة 0";
String lbl1 = "قيمة خلية العلامة 1";
String lbl2 = "قيمة خلية العلامة 2";

// إنشاء مثيل من فئة العرض التقديمي التي تمثل ملف العرض التقديمي
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

يوضح هذا الكود Java عملية حيث يتم استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

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

يوضح لك هذا الكود Java كيفية تحديد نوع لمصدر البيانات:

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

## **المصنف الخارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-19-4-release-notes/)، نفذنا دعمًا للمصنفات الخارجية كمصدر بيانات للرسم البياني.
{{% /alert %}} 

### **إنشاء مصنف خارجي**

باستخدام **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء مصنف خارجي من الصفر أو جعل مصنف داخلي خارجي.

يوضح هذا الكود Java عملية إنشاء المصنف الخارجي:

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

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين مصنف خارجي لرسم بياني كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار المصنف الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تعديل البيانات في المصنفات المخزنة في مواقع أو موارد بعيدة، يمكنك استخدام مثل هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير المسار النسبي لمصنف خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يوضح لك هذا الكود Java كيفية تعيين مصنف خارجي:

```java
// إنشاء مثيل من فئة العرض التقديمي
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

* عندما يتم تعيين قيمة `ChartData` إلى `false`، يتم تحديث مسار المصنف فقط - لن يتم تحميل بيانات الرسم البياني أو تحديثها من المصنف المستهدف. قد ترغب في استخدام هذا الإعداد عندما تكون في حالة حيث يكون المصنف المستهدف غير موجود أو غير متاح. 
* عندما يتم تعيين قيمة `ChartData` إلى `true`، يتم تحديث بيانات الرسم البياني من المصنف المستهدف.

```java
// إنشاء مثيل من فئة العرض التقديمي
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

1. إنشاء مثيل من فئة [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إنشاء كائن لشكل الرسم البياني.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات الرسم البياني.
1. تحديد الشرط ذي الصلة بناءً على كون نوع المصدر هو نفسه نوع مصدر البيانات للمصنف الخارجي.

يوضح هذا الكود Java العملية:

```java
// إنشاء مثيل من فئة العرض التقديمي
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// حفظ العرض التقديمي
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تحرير بيانات الرسم البياني**

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تقوم بها بإجراء تغييرات على محتويات المصنفات الداخلية. عندما يتعذر تحميل مصنف خارجي، يتم رفع استثناء.

هذا الكود Java هو تنفيذ للعملية الموصوفة:

```java
// إنشاء مثيل من فئة العرض التقديمي
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