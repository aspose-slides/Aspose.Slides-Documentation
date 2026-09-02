---
title: إدارة دفاتر عمل المخططات في العروض التقديمية على Android
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/androidjava/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- مخزن المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides لنظام Android عبر Java: إدارة دفاتر عمل المخططات بسهولة في تنسيقات PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

وتتطرق أيضًا إلى العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متوفرًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
توفر Aspose.Slides طريقتي [ReadWorkbookStream](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) اللتين تسمحان لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها هيكل مشابه للمصدر.

يعرض هذا الشيفرة جافا عملية نموذجية:

```java
import com.aspose.slides.*;

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدَّل، يحتفظ المخطط بسلسلاته ومجموعات الفئات الأصلية. قد يتسبب هذا الاختلاف في فشل [IChart.validateChartLayout](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IChart#validateChartLayout--) مع خطأ "فهرس خارج النطاق". احذف السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدَّث مرة أخرى إلى المخطط.

```java
// بعد تعديل تدفق دفتر العمل (مثلاً باستخدام Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// مسح مراجع البيانات الحالية.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

يضمن مسح المجموعات أن تكون بنية بيانات المخطط متوافقة مع دفتر العمل الجديد، مما يسمح لـ `validateChartLayout` بالانتهاء دون أخطاء.

## **تعيين خلية دفتر العمل كعنوان بيانات المخطط**

1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط فقاعة مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. تعيين خلية دفتر العمل كعنوان بيانات.
6. حفظ العرض التقديمي.

تُظهر هذه الشيفرة جافا كيفية تعيين خلية دفتر عمل كعنوان بيانات للمخطط:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// ينشئ كائن من فئة العرض التقديمي التي تمثل ملف عرض تقديمي
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

توضح هذه الشيفرة جافا عملية يتم فيها استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

```java
import com.aspose.slides.*;

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

تُظهر هذه الشيفرة جافا كيفية تحديد نوع لمصدر البيانات:

```java
import com.aspose.slides.*;

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

## **الكشف عن تنسيقات دفتر العمل المضمّنة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر عمل Excel الثنائي (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام طريقة `getEmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IChartData) جنبًا إلى جنب مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/WorkbookType) للكشف عن التنسيقات غير المدعومة وتجاوز تلك المخططات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // دفتر العمل المضمّن بصيغة .xlsb غير مدعوم.
            continue;
        }

        // قراءة أو تعديل بيانات دفتر عمل المخطط هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

باستخدام طريقتي **`readWorkbookStream`** و**`setExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو جعل دفتر عمل داخلي خارجيًا.

توضح هذه الشيفرة جافا عملية إنشاء دفتر عمل خارجي:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من أنه لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

تُظهر هذه الشيفرة جافا كيفية تعيين دفتر عمل خارجي:

```java
import com.aspose.slides.*;

// ينشئ كائنًا من فئة Presentation
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

يُستخدم معامل `updateChartData` (تحت طريقة `setExternalWorkbook`) لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما تكون قيمة `updateChartData` مضبوطة على `false`، يتم تحديث مسار دفتر العمل فقط—لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف. قد تريد استخدام هذا الإعداد في حالة عدم وجود دفتر العمل الهدف أو عدم توفره.
* عندما تكون قيمة `updateChartData` مضبوطة على `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

```java
import com.aspose.slides.*;

// ينشئ كائنًا من فئة Presentation
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

### **الحصول على مسار مصدر البيانات الخارجي لدفتر عمل المخطط**

1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفسه نوع مصدر بيانات دفتر العمل الخارجي.

توضح هذه الشيفرة جافا العملية:

```java
import com.aspose.slides.*;

// ينشئ كائنًا من فئة Presentation
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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إلقاء استثناء.

تُظهر هذه الشيفرة جافا تنفيذ العملية الموضحة:

```java
import com.aspose.slides.*;

// ينشئ كائنًا من فئة Presentation
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

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متوفر، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/)، وقم بتهيئتها باستخدام [SpreadsheetOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/spreadsheetoptions/)، واستدعِ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) مع `true` قبل فتح العرض التقديمي.

المثال التالي بجافا يفتح عرضًا تقديميًا يشير مخططه إلى دفتر عمل خارجي غير متوفر ويصل إلى البيانات المستعادة عبر [IChart.getChartData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichart/#getChartData--) و[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
} finally {
    presentation.dispose();
}
```

إذا كان دفتر العمل الخارجي غير متوفر وتم تعطيل الاستعادة، تلقي Aspose.Slides استثناءً. فعل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مضمّن؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لحملية المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام such workbooks كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](/cells/androidjava/)) والربط بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا أشار جميعها إلى نفس الملف، سيعكس تحديث ذلك الملف في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.