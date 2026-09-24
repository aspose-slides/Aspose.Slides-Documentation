---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام Java
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- علامة البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة التخزين المؤقت للمخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides for Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

هذه المقالة توضح كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر عمل خارجي مرتبط بالمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/java/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
توفر Aspose.Slides الأسلوبين [ReadWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData#readWorkbookStream--) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) اللذين يسمحان لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مماثلة للمصدر.

هذا الكود Java يوضح عملية نموذجية:

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

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بمجموعات السلاسل والفئات الأصلية. قد يتسبب هذا التناقض في رمي [IChart.validateChartLayout](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#validateChartLayout--) استثناء `ArgumentOutOfRangeException` (المعامل: index). لتجنب الاستثناء، قم بمسح السلاسل والفئات القائمة **قبل** كتابة دفتر العمل المحدث إلى المخطط مرة أخرى.

```java
// بعد تعديل تدفق دفتر العمل (مثلاً باستخدام Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// مسح مراجع البيانات الحالية.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

مسح المجموعات يضمن أن بنية بيانات المخطط تتوافق مع دفتر العمل الجديد، مما يسمح لـ `validateChartLayout` بإكمال العملية دون أخطاء.

## **تعيين خلية دفتر العمل كعلامة بيانات للمخطط**

1. إنشاء مثال من فئة [Presentation](https://apireference.aspose.com/slides/ar/java/com.aspose.slides/presentation) .
1. الحصول على مرجع الشريحة من خلال فهرستها.
1. إضافة مخطط فقاعة مع بعض البيانات.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية دفتر العمل كعلامة بيانات.
1. حفظ العرض التقديمي.

هذا الكود Java يوضح كيفية تعيين خلية دفتر عمل كعلامة بيانات للمخطط:

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

هذا الكود Java يوضح عملية يتم فيها استخدام الأسلوب [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) للوصول إلى مجموعة أوراق العمل:

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

هذا الكود Java يوضح كيفية تحديد نوع لمصدر البيانات:

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

## **اكتشاف صيغ دفتر العمل المدمج غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر عمل Excel الثنائي (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام الأسلوب `getEmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IChartData) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/WorkbookType) لاكتشاف الصيغ غير المدعومة وتخطي تلك المخططات.

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

        // قم بقراءة أو تعديل بيانات دفتر عمل المخطط هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

باستخدام الطريقتين **`readWorkbookStream`** و**`setExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

هذا الكود Java يوضح عملية إنشاء دفتر عمل خارجي:

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

باستخدام الأسلوب **`setExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذا الأسلوب لتحديث مسار دفتر العمل الخارجي (في حال تم نقل الأخير).

بينما لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

هذا الكود Java يوضح كيفية تعيين دفتر عمل خارجي:

```java
// ينشئ مثيلاً من فئة Presentation
import com.aspose.slides.*;

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

المعامل الثاني (`boolean`) من أسلوب `setExternalWorkbook` يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر Excel أم لا.

* عند ضبط قيمته إلى `false`، يتم تحديث مسار دفتر العمل فقط — لن يتم تحميل أو تحديث بيانات المخطط من دفتر العمل المستهدف. يمكنك استخدام هذا الإعداد عندما يكون دفتر العمل المستهدف غير موجود أو غير متاح.
* عند ضبط قيمته إلى `true`، يتم تحديث بيانات المخطط من دفتر العمل المستهدف.

```java
import com.aspose.slides.*;

// ينشئ مثيلاً من فئة Presentation
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

### **الحصول على مسار دفتر العمل مصدر البيانات الخارجي للمخطط**

1. إنشاء مثال من فئة [Presentation](https://apireference.aspose.com/slides/ar/java/com.aspose.slides/presentation) .
1. الحصول على مرجع الشريحة من خلال فهرستها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على أن نوع المصدر هو نفسه نوع مصدر البيانات للدفتر الخارجي.

هذا الكود Java يوضح العملية:

```java
import com.aspose.slides.*;

// ينشئ مثيلاً من فئة Presentation
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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تعدل بها محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُرمى استثناء.

هذا الكود Java هو تنفيذ للعملية الموضحة:

```java
import com.aspose.slides.*;

// ينشئ مثيلاً من فئة Presentation
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

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/)، قم بتكوينه باستخدام [SpreadsheetOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/spreadsheetoptions/)، واستدعِ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) مع القيمة `true` قبل فتح العرض التقديمي.

المثال Java التالي يفتح عرضًا تقديميًا يشير مخططه إلى دفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [IChart.getChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#getChartData--) و[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
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

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، يُرمى Aspose.Slides استثناء. قم بتمكين الاستعادة فقط عندما يكون استخدام البيانات المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريتها على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة الشائعة**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

Yes. A chart has a [data source type](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getDataSourceType--) and a [path to an external workbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); if the source is an external workbook, you can read the full path to make sure an external file is being used.

**Are relative paths to external workbooks supported, and how are they stored?**

Yes. If you specify a relative path, it is automatically converted to an absolute path. This is convenient for project portability; however, be aware that the presentation will store the absolute path in the PPTX file.

**Can I use workbooks located on network resources/shares?**

Yes, such workbooks can be used as an external data source. However, editing remote workbooks directly from Aspose.Slides is not supported—they can only be used as a source.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

No. The presentation stores a [link to the external file](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) and uses it for reading data. The external file itself is not modified when the presentation is saved.

**What should I do if the external file is password-protected?**

Aspose.Slides does not accept a password when linking. A common approach is to remove protection in advance or prepare a decrypted copy (for example, using [Aspose.Cells](/cells/java/)) and link to that copy.

**Can multiple charts reference the same external workbook?**

Yes. Each chart stores its own link. If they all point to the same file, updating that file will be reflected in each chart the next time the data is loaded.