---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 40
url: /ar/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط إكسل
- كائن OLE
- تضمين المخطط
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إصلاح تغير حجم المخطط غير المتوقع في ملفات PPTX عند استخدام كائنات OLE مدمجة من Excel مع Aspose.Slides لنظام Android عبر Java. ضبط أبعاد المخطط الثابتة للحفاظ على توافق أحجام المخطط وإطار OLE."
---
## **نظرة عامة**

يمكن أن تتغير حجم مخططات Excel المضمنة ككائنات OLE في عروض PowerPoint التقديمية باستخدام مكونات Aspose بعد تفعيلها الأول. يمكن أن يتسبب ذلك في اختلاف ملحوظ في مظهر المخطط قبل وبعد التفعيل. يوضح هذا المقال سبب حدوث تغيير الحجم ويظهر كيفية منعه عن طريق مطابقة أبعاد المخطط الثابتة مع إطار OLE.

في [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells for Android عبر Java وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for Android عبر Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/androidjava/object-preview-issue-when-adding-oleobjectframe/)، قمنا بإسناد صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة المخطط، يتم تفعيل مخطط Excel. يمكن للمستخدمين تحرير مصنف Excel المضمن ثم العودة إلى الشريحة بالنقر خارج المصنف المُفعَّل. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، ويختلف عامل تغيير الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ومصنف Excel المضمن.

## **سبب تغيير الحجم**

يحتوي مصنف Excel المضمن على أبعاد نافذة خاصة به، ويحاول Excel الاحتفاظ بهذه الأبعاد عند تفعيل الكائن لأول مرة. يمتلك إطار OLE على الشريحة أبعادًا معرفة بشكل مستقل. عندما يتم تفعيل مصنف Excel، يتفاوض كل من Excel وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية التضمين. لذلك يمكن أن يتسبب الاختلاف بين نافذة المصنف وإطار OLE في تغيير حجم الكائن.

## **الحل العملي**

قم بمطابقة حجم المخطط مع إطار OLE على الشريحة واحفظ أبعاد المخطط مستقلة عن نافذة المصنف. يعمل هذا الحل مع عرض جديد أو قالب موجود.

يتطلب المثال Aspose.Cells for Android عبر Java وAspose.Slides for Android عبر Java. ينشئ مخطط عمودي بسيط على ورقة مخطط نشطة ويضمّن المصنف بتنسيق XLS. استدعِ `FixedChartSize.createPresentation(getFilesDir())` من نشاط Android لحفظ النتيجة في دليل الملفات الداخلي للتطبيق. يتطلب تفعيل OLE وجود PowerPoint على سطح المكتب وتثبيت Excel متوافق. لا يتم إسناد صورة معاينة للمخطط؛ يصبح المخطط مرئيًا عندما يتم تفعيل كائن OLE في PowerPoint.

ينشئ المثال عرضًا جديدًا بإطار OLE بحجم 9.5 × 4 بوصة موضعه 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات وأبعاد الشريحة بوحدة النقاط (72 نقطة لكل بوصة). للحصول على عرض موجود، انظر [استخدام قالب](#use-a-template).

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // إحداثيات وأبعاد الشريحة بوحدة النقاط (72 نقطة لكل بوصة).
                    float width = 684f; // 9.5 بوصة.
                    float height = 288f; // 4 بوصة.

                    chart.setSizeWithWindow(false);
                    // تحويل النقاط إلى بكسلات المخطط باستخدام 96 بكسل لكل بوصة.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```
## **تعيين حجم مخطط ثابت**

قم بتعيين [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) إلى false بحيث تكون أبعاد المخطط مستقلة عن نافذة المصنف. اضبط أبعاد [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) عبر [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) و[setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-)، مع تحويل النقاط إلى بكسلات باستخدام 96 بكسل لكل بوصة: إطار بقياس 684 × 288 نقطة يساوي مخططًا بقياس 912 × 384 بكسل. قم بتعيين [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) إلى القيمة CUSTOM من [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). يضمّن المثال المصنف عبر [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ويحفظ عرضًا بإطار OLE بحجم 9.5 × 4 بوصة.

## **استخدام قالب**

منطق التحجيم هو نفسه لعرض موجود. لتكييف المثال:

1. قم بتحميل عرض القالب بدلاً من إنشاء عرض فارغ.
2. تحقق من أن الشريحة الأولى تحتوي على ثلاثة أشكال على الأقل، ثم استخدم الشكل الموجود في الفهرس 2 كعنصر نائب.
3. خذ عرض وارتفاع الإطار من ذلك الشكل بدلاً من استخدام القيم الثابتة 684 و288. حافظ على حسابات التحجيم دون تغيير.
4. أضف إطار OLE في موضع عنصر النائب بدلاً من الإحداثيات الثابتة 36 و72.
5. احذف عنصر النائب قبل حفظ العرض.

## **الأسئلة المتكررة**

**لماذا يتغير حجم مخطط Excel المضمن بعد تفعيله في PowerPoint؟**

يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، بينما يمتلك إطار OLE في PowerPoint أبعادًا خاصة به. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يؤدي إلى تغيير الحجم.

**كيف يمكن الحفاظ على توافق أحجام المخطط وإطار OLE؟**

قم بتحديد أبعاد مخطط ثابتة مطابقة لإطار OLE واستخدم حجم طباعة مخطط مخصص قبل تضمين المصنف. يوضح المثال أعلاه الإعدادات المطلوبة وتحويل الوحدات.

**هل يكفي مطابقة حجم نافذة المصنف؟**

مطابقة حجم نافذة المصنف وحدها لا تمنع بشكل موثوق تغيير حجم إطار OLE بعد التفعيل. استخدم أبعاد مخطط ثابتة كما هو موضح في المثال.

**هل يعمل هذا الحل مع العروض القائمة على القالب والعروض الجديدة؟**

نعم. بالنسبة للقالب، استخدم أبعاد وموقع عنصر النائب. بالنسبة لعرض جديد، حدد أبعاد الإطار وموقعه مباشرة.

**هل يمكنني استخدام هذا المثال مع مخططات تم إنشاؤها في برامج جداول بيانات أخرى؟**

يستخدم المثال مصنف Excel تم إنشاؤه باستخدام Aspose.Cells. لا يوضح سلوك التفعيل لبرامج جداول بيانات أخرى.

## **الأقسام ذات الصلة**

- [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)