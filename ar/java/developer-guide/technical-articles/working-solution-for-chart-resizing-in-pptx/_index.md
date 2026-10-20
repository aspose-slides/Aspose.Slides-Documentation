---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 40
url: /ar/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط Excel
- كائن OLE
- تضمين المخطط
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إصلاح تعديل حجم المخطط غير المتوقع في ملفات PPTX عند استخدام كائنات OLE داخلية من Excel مع Aspose.Slides for Java. ضبط أبعاد المخطط الثابتة للحفاظ على اتساق أحجام المخطط وإطار OLE."
---
## **الخلفية**

يمكن أن تتغير أحجام الرسوم البيانية في Excel المدمجة ككائنات OLE في عروض PowerPoint باستخدام مكونات Aspose بعد التفعيل الأول لها. قد يتسبب ذلك في فرق ملحوظ في مظهر الرسم البياني قبل وبعد التفعيل. تشرح هذه المقالة لماذا يحدث تعديل الحجم وتظهر كيفية منعه من خلال مطابقة أبعاد الرسم البياني الثابتة مع إطار OLE.

في [إنشاء رسوم Excel وتضمينها ككائنات OLE في العروض](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء رسم Excel باستخدام Aspose.Cells for Java وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة الرسم إلى إطار كائن OLE الخاص به. في العرض الناتج، عندما تنقر نقرًا مزدوجًا على إطار كائن OLE الذي يعرض صورة الرسم، يتم تفعيل رسم Excel. يمكن للمستخدمين تحرير دفتر العمل المدمج ثم العودة إلى الشريحة بالنقر خارج دفتر العمل المفعّل. يتغير حجم إطار كائن OLE عند عودة المستخدم إلى الشريحة، وعامل تعديل الحجم يختلف اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ودفة عمل Excel المدمجة.

## **سبب تعديل الحجم**

لدى دفتر عمل Excel المدمج أبعاده الخاصة للنافذة، ويحاول Excel الحفاظ عليها عند تفعيل الكائن للمرة الأولى. يحتوي إطار OLE على الشريحة على أبعاد معرفة بشكل مستقل. عندما يتم تفعيل دفتر عمل Excel، يتفاوض Excel وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية التضمين. الاختلاف بين نافذة دفتر العمل وإطار OLE يمكن أن يتسبب في تعديل حجم الكائن.

## **الحل العملي**

قم بمطابقة حجم الرسم مع إطار OLE على الشريحة واحرص على أن تكون أبعاد الرسم مستقلة عن نافذة دفتر العمل. يعمل هذا الحل مع عرض جديد أو قالب موجود.

المثال يتطلب Aspose.Cells for Java وAspose.Slides for Java. ينشئ رسمًا عموديًا بسيطًا على ورقة رسم نشطة ويضمّن دفتر العمل بصيغة XLS. لا يتم تعيين صورة معاينة للرسم؛ يصبح الرسم مرئيًا عندما يتم تفعيل كائن OLE في PowerPoint.

ينشئ المثال عرضًا جديدًا بإطار OLE مقاسه 9.5 × 4 بوصة موضعه 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات وأبعاد الشريحة بالنقاط (72 نقطة لكل بوصة). بالنسبة لعرض موجود، راجع [استخدام قالب](#use-a-template).

## **تحديد حجم ثابت للرسم**

عيّن [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) إلى false لجعل أبعاد الرسم مستقلة عن نافذة دفتر العمل. عيّن أبعاد [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) عبر [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) و[setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-)، محولًا النقاط إلى بكسلات باستخدام 96 بكسل لكل بوصة: إطار يبلغ 684 × 288 نقطة ي correspond إلى رسم بحجم 912 × 384 بكسل. عيّن [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) إلى القيمة CUSTOM من [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). يضمّن المثال دفتر العمل باستخدام [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ويحفظ عرضًا بإطار OLE مقاسه 9.5 × 4 بوصة.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إحداثيات الشريحة وأبعادها بالنقاط (72 نقطة لكل بوصة).
        float width = 684f; // 9.5 بوصة.
        float height = 288f; // 4 بوصة.

        chart.setSizeWithWindow(false);
        // تحويل النقاط إلى بكسلات الرسم باستخدام 96 بكسل لكل بوصة.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **استخدام قالب**

منطق التحجيم هو نفسه لعرض موجود. لتكييف المثال:

1. حمّل قالب العرض بدلاً من إنشاء عرض فارغ.  
2. تأكد من أن الشريحة الأولى تحتوي على ثلاثة أشكال على الأقل، ثم استخدم الشكل بالفهرس 2 كعنصر نائب.  
3. خذ عرض وإرتفاع الإطار من ذلك الشكل بدلاً من استخدام القيم الثابتة 684 و288. احفظ حسابات التحجيم كما هي.  
4. أضف إطار OLE في موضع العنصر النائب بدلاً من الإحداثيات الثابتة 36 و72.  
5. احذف العنصر النائب قبل حفظ العرض.

## **الأسئلة الشائعة**

**لماذا يتغير حجم رسم Excel المدمج بعد تفعيله في PowerPoint؟**  
يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يؤدي إلى تعديل الحجم.

**كيف يمكن الحفاظ على تناسق حجم الرسم وإطار OLE؟**  
حدد أبعاد رسم ثابتة تطابق إطار OLE واستخدم حجم طباعة مخصص للرسم قبل تضمين دفتر العمل. يوضح المثال أعلاه الإعدادات المطلوبة وتحويل الوحدات.

**هل يكفي مطابقة حجم نافذة دفتر العمل؟**  
مجاراة حجم نافذة دفتر العمل وحدها لا تضمن منع إطار OLE من تغيير حجمه بعد التفعيل. استخدم أبعاد رسم ثابتة كما هو موضح في المثال.

**هل يعمل هذا الحل مع العروض القائمة على القالب والعروض الجديدة؟**  
نعم. بالنسبة للقالب، استخدم أبعاد وموقع العنصر النائب. بالنسبة لعرض جديد، حدد أبعاد وموقع الإطار مباشرة.

**هل يمكنني استخدام هذا المثال مع الرسوم التي تم إنشاؤها في برامج جداول بيانات أخرى؟**  
يستخدم المثال دفتر عمل Excel تم إنشاؤه باستخدام Aspose.Cells. لا يوضح سلوك التفعيل لبرامج جداول بيانات أخرى.

## **الأقسام ذات الصلة**

- [إنشاء رسوم Excel وتضمينها ككائنات OLE في العروض](/slides/ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)