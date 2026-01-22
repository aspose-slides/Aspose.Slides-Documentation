---
title: إدارة مصنفات المخططات في العروض التقديمية على Android
linktitle: مصنف المخطط
type: docs
weight: 70
url: /ar/androidjava/chart-workbook/
keywords:
- مصنف المخطط
- بيانات المخطط
- خلية المصنف
- علامة البيانات
- ورقة عمل
- مصدر البيانات
- مصنف خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides لنظام Android عبر Java: إدراة مصنفات المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---

## **قراءة وكتابة بيانات المخطط من مصنف**
توفر Aspose.Slides الطريقتين [ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) اللتين تتيحان لك قراءة وكتابة مصنفات بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مماثلة للمصدر.

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


## **تعيين خلية المصنف كعلامة بيانات المخطط**

1. إنشاء نسخة من فئة [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط فقاعي مع بعض البيانات.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية المصنف كعلامة بيانات.
1. حفظ العرض التقديمي.

هذا الكود Java يوضح لك كيفية تعيين خلية المصنف كعلامة بيانات المخطط:
```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// يُنشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
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

هذا الكود Java يوضح عملية يتم فيها استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:
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

تدعم Aspose.Slides المصنفات الخارجية كمصدر بيانات للمخططات.

### **إنشاء مصنف خارجي**

باستخدام الطريقتين **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء مصنف خارجي من الصفر أو جعل مصنف داخلي خارجيًا.

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

باستخدام طريقة **`setExternalWorkbook`**، يمكنك ربط مصنف خارجي بمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار المصنف الخارجي (إذا تم نقل الأخير).

على الرغم من أنه لا يمكنك تحرير البيانات في المصنفات المخزنة في مواقع أو موارد عن بُعد، يمكنك الاستمرار في استخدام هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لمصنف خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

هذا الكود Java يوضح لك كيفية تعيين مصنف خارجي:
```java
// إنشاء نسخة من فئة Presentation
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


معامل `ChartData` (ضمن طريقة `setExternalWorkbook`) يُستخدم لتحديد ما إذا كان سيتم تحميل مصنف إكسل أم لا.

* عندما يتم تعيين قيمة `ChartData` إلى `false`، يتم تحديث مسار المصنف فقط—لن يتم تحميل أو تحديث بيانات المخطط من المصنف الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون المصنف الهدف غير موجود أو غير متاح.
* عندما يتم تعيين قيمة `ChartData` إلى `true`، يتم تحديث بيانات المخطط من المصنف الهدف.
```java
// إنشاء نسخة من فئة Presentation
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


### **الحصول على مسار مصنف مصدر البيانات الخارجي للمخطط**

1. إنشاء نسخة من فئة [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن للنوع (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفس نوع مصدر المصنف الخارجي.

هذا الكود Java يوضح العملية:
```java
// ينشئ مثيلًا من فئة Presentation
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

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تقوم بها بتعديل محتويات المصنفات الداخلية. عندما لا يمكن تحميل مصنف خارجي، يتم طرح استثناء.

هذا الكود Java هو تنفيذ للعملية الموصوفة:
```java
// ينشئ مثيلًا من فئة Presentation
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

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبط بمصنف خارجي أم مضمن؟**

نعم. للمخطط [نوع مصدر البيانات](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و[مسار المصنف الخارجي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)؛ إذا كان المصدر مصنفًا خارجيًا، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية للمصنفات الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لنقلية المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام المصنفات الموجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام مثل هذه المصنفات كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير المصنفات البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يقوم العرض التقديمي بتخزين [رابط إلى الملف الخارجي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/androidjava/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس المصنف الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.