---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام جافا
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- ملصق البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخزن المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides لجافا: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر رسم المخطط في Aspose.Slides. توضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، استرداد مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides الطريقتين [ReadWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) اللتين تتيحان لك قراءة وكتابة دفاتر بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو يجب أن يكون لها بنية مشابهة للمصدر.

يعرض هذا كود جافا عملية نموذجية:

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

### **تحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بسلسلات الفئات والمجموعات الأصلية. قد يتسبب هذا التناقض في إلقاء `chart.validateChartLayout()` استثناءً من نوع `ArgumentOutOfRangeException` (معامل: index). لتجنب الاستثناء، امسح السلاسل والفئات الموجودة **قبل** كتابة دفتر العمل المحدث مرة أخرى إلى المخطط.

```java
// بعد تعديل تدفق دفتر العمل (مثلًا باستخدام Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// امسح مراجع البيانات الحالية.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// اكتب دفتر العمل المحدث مرة أخرى إلى المخطط.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// التحقق الآن ينجح.
chart.validateChartLayout();
```

يمكّن مسح المجموعات من توافق بنية بيانات المخطط مع دفتر العمل الجديد، مما يسمح لـ `validateChartLayout()` بإكمال التنفيذ دون أخطاء.

## **تعيين خلية دفتر العمل كملصق بيانات المخطط**

1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/ar/java/com.aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط فقاعة مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. تعيين خلية دفتر العمل كملصق بيانات.
6. حفظ العرض التقديمي.

يعرض هذا كود جافا كيفية تعيين خلية دفتر العمل كملصق بيانات المخطط:

```java
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

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

يظهر هذا كود جافا عملية يتم فيها استخدام طريقة [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

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

يعرض هذا كود جافا كيفية تحديد نوع لمصدر البيانات:

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

## **كشف صيغ دفاتر العمل المضمنة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر عمل Excel الثنائي (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام طريقة `getEmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/WorkbookType) للكشف عن الصيغ غير المدعومة وتخطي تلك المخططات.

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
            // دفتر العمل المضمن بتنسيق .xlsb غير مدعوم.
            continue;
        }

        // اقرأ أو عدّل بيانات دفتر عمل المخطط هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

{{% alert color="info" %}} 
في [Aspose.Slides 19.4](https://docs.aspose.com/slides/ar/java/aspose-slides-for-java-19-4-release-notes/)، نفذنا دعم دفاتر العمل الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**

باستخدام طريقتي **`readWorkbookStream`** و **`setExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو جعل دفتر عمل داخلي خارجيًا.

يظهر هذا كود جافا عملية إنشاء دفتر عمل خارجي:

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

باستخدام طريقة **`setExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي إلى مخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (في حال تم نقل الأخير).

في حين لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام تلك الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يظهر هذا كود جافا كيفية تعيين دفتر عمل خارجي:

```java
import com.aspose.slides.*;

// ينشئ مثيلًا لفئة Presentation
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

المعامل الثاني (`boolean`) لطريقة `setExternalWorkbook` يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر عمل إكسل أم لا.

* عندما يكون قيمته `false`، يتم فقط تحديث مسار دفتر العمل — لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل المستهدف. قد تريد استخدام هذا الإعداد عندما يكون دفتر العمل المستهدف غير موجود أو غير متاح.  
* عندما تكون قيمته `true`، تُحدَّث بيانات المخطط من دفتر العمل المستهدف.

```java
import com.aspose.slides.*;

// ينشئ مثيلًا لفئة Presentation
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

### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي لمخطط**

1. إنشاء مثيل من الفئة [Presentation](https://apireference.aspose.com/slides/ar/java/com.aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على تطابق نوع المصدر مع نوع مصدر دفتر العمل الخارجي.

يعرض هذا كود جافا العملية:

```java
import com.aspose.slides.*;

// ينشئ مثيلًا لفئة Presentation
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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إلقاء استثناء.

هذا كود جافا يوضح العملية المذكورة:

```java
import com.aspose.slides.*;

// ينشئ مثيلًا لفئة Presentation
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

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/)، وقم بتكوينه باستخدام [SpreadsheetOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/spreadsheetoptions/)، ثم استدعِ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) مع `true` قبل فتح العرض التقديمي.

يفتح المثال التالي عرضًا تقديميًا يشير مخططه إلى دفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [IChart.getChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // اقرأ أو عدل بيانات دفتر العمل المستعاد هنا.
} finally {
    presentation.dispose();
}
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، يطرح Aspose.Slides استثناءً. فعّل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمن؟**  
نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getDataSourceType--) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**  
نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا ملائم لنقل المشاريع؛ ومع ذلك، يجب الانتباه إلى أن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركة شبكية؟**  
نعم، يمكن استخدام such دفاتر عمل كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تعديل دفاتر العمل البعيدة مباشرةً — يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**  
لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**  
Aspose.Slides لا يقبل كلمة مرور عند الربط. عادةً ما يتم إما إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/java/)) وربطها.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**  
نعم. يخزن كل مخطط رابطه الخاص. إذا كانت جميع الروابط تشير إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.