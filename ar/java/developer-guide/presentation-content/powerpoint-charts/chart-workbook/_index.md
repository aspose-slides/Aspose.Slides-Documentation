---
title: إدارة مصنفات المخططات في العروض التقديمية باستخدام Java
linktitle: مصنف المخطط
type: docs
weight: 70
url: /ar/java/chart-workbook/
keywords:
- مصنف المخطط
- بيانات المخطط
- خلية المصنف
- علامة البيانات
- ورقة العمل
- مصدر البيانات
- مصنف خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides for Java: إدارة مصنفات المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي."
---

## **قراءة وكتابة بيانات المخطط من مصنف**
توفر Aspose.Slides طريقة [ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) و[WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) التي تسمح لك بقراءة وكتابة مصنفات بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو يجب أن يكون لها بنية مشابهة للمصدر.

يعرض هذا الكود Java عملية نموذجية:
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


## **تعيين خلية مصنف كعلامة بيانات مخطط**

1. إنشاء مثال من فئة [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف مخطط فقاعة مع بعض البيانات.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية المصنف كعلامة بيانات.
1. احفظ العرض التقديمي.

هذا الكود Java يوضح لك كيفية تعيين خلية مصنف كعلامة بيانات مخطط:
```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// إنشاء كائن فئة عرض تقديمي يمثل ملف عرض تقديمي
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

يعرض هذا الكود Java عملية حيث يتم استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:
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

هذا الكود Java يوضح لك كيفية تحديد نوع لمصدر البيانات:
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


## **مصنف خارجي**
{{% alert color="primary" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/)، أضفنا دعمًا للمصنفات الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء مصنف خارجي**

باستخدام طريقتي **`readWorkbookStream`** و**`setExternalWorkbook`**، يمكنك إما إنشاء مصنف خارجي من الصفر أو جعل مصنف داخلي خارجيًا.

هذا الكود Java يوضح عملية إنشاء المصنف الخارجي:
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

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين مصنف خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار المصنف الخارجي (إذا تم نقل الأخير).

على الرغم من أنه لا يمكنك تعديل البيانات في المصنفات المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لمصنف خارجي، يتم تحويله إلى مسار كامل تلقائيًا.

هذا الكود Java يوضح لك كيفية تعيين مصنف خارجي:
```java
// إنشاء مثال من فئة Presentation
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


معامل `ChartData` (تحت طريقة `setExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل مصنف Excel أم لا. 

* عندما تكون قيمة `ChartData` مضبوطة على `false`، يتم فقط تحديث مسار المصنف — لن يتم تحميل بيانات المخطط أو تحديثها من المصنف الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون المصنف الهدف غير موجود أو غير متاح. 
* عندما تكون قيمة `ChartData` مضبوطة على `true`، يتم تحديث بيانات المخطط من المصنف الهدف.
```java
// إنشاء مثال من فئة Presentation
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


### **الحصول على مسار مصنف مصدر البيانات الخارجي لمخطط**

1. إنشاء مثال من فئة [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. احصل على مرجع الشريحة عبر فهرسها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على أن نوع المصدر هو نفسه نوع مصدر البيانات للمصنف الخارجي.

هذا الكود Java يوضح العملية:
```java
// إنشاء مثيل من فئة Presentation
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


### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات المصنفات الداخلية. عندما لا يمكن تحميل مصنف خارجي، يتم إلقاء استثناء.

هذا الكود Java هو تنفيذ للعملية الموصوفة:
```java
// إنشاء مثال من فئة Presentation
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


## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بمصنف خارجي أم مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) و[مسار إلى المصنف الخارجي](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)؛ إذا كان المصدر مصنفًا خارجيًا، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية للمصنفات الخارجية، وكيف يتم تخزينها؟**

نعم. إذا قمت بتحديد مسار نسبي، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لتوفير قابلية نقل المشروع؛ مع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام المصنفات الموجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام هذه المصنفات كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تعديل المصنفات البعيدة مباشرةً — يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يقوم العرض التقديمي بتخزين [رابط إلى الملف الخارجي](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عند حفظ العرض التقديمي.

**ماذا يجب أن أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا يقبل Aspose.Slides كلمة مرور عند الربط. أحد الأساليب الشائعة هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال، باستخدام [Aspose.Cells](/cells/java/)) وربطها بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس المصنف الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.