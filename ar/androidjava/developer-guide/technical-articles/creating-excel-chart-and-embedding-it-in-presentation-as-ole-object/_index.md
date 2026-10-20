---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 30
url: /ar/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين مخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells لـ Android عبر Java وتضمين دفتر العمل في عرض PowerPoint باستخدام Aspose.Slides لـ Android عبر Java، بما في ذلك معاينة المخطط."
---
## **نظرة عامة**

تظهر هذه المقالة كيفية إنشاء مخطط عمودي في Excel باستخدام Aspose.Cells for Android عبر Java وتضمين دفتر العمل الخاص به في عرض تقديمي PowerPoint باستخدام Aspose.Slides for Android عبر Java. يحتوي دفتر العمل المضمن على كل من البيانات المصدرية والمخطط. يعرض معاينة PNG منفصلة المخطط على الشريحة قبل تفعيل كائن OLE.

النتيجة هي كائن Excel مضمّن، وليس مخطط PowerPoint أصلي. يتطلب تحرير دفتر العمل عبر OLE تطبيق سطح مكتب يدعم تفعيل OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

أضف Aspose.Cells for Android عبر Java و Aspose.Slides for Android عبر Java إلى تبعيات مشروعك. استدعِ `ExcelChartEmbedding.createPresentation(getFilesDir())` من نشاط Android. لا يلزم وجود Microsoft Office لإنشاء العرض التقديمي باستخدام هذه المكتبات.

لا يلزم أي ملفات إدخال: ينشئ المثال البيانات والمخطط في الذاكرة، ثم يكتب `OutputChart.pptx` إلى دليل الملفات الداخلي للتطبيق. تطبيق التراخيص لكلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيف يعمل التضمين**

1. إنشاء دفتر عمل يحتوي على ورقة بيانات وورقة مخطط.  
2. اجعل ورقة المخطط نشطة بحيث يفتح دفتر العمل على المخطط.  
3. تعيين نطاق عرض OLE لدفتر العمل وتصيير المخطط إلى PNG.  
4. حفظ دفتر العمل كـ XLSX في الذاكرة وتضمين تلك البايتات في شريحة.  
5. تعيين PNG كمعاينة كائن OLE وحفظ العرض التقديمي كـ PPTX.  

نطاق عرض دفتر العمل والإطار على الشريحة لهما أدوار مختلفة. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) يأخذ مؤشرات صف وعمود بداية/نهاية بدءًا من الصفر. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) بدلاً من ذلك يأخذ الصف العلوي، العمود الأيسر، الصف السفلي، والعمود الأيمن. يستخدم المثال فهرس الصف 55 وفهرس العمود 25 كحدود السفلية اليمنى؛ هذه القيم هي خيارات تخطيط، ليست عدد صفوف أو أعمدة البيانات.

يستخدم إطار الشريحة النقاط. يضبط المثال الإطار داخل الشريحة ويُوسِّطها مع الحفاظ على نسبة أبعاد PNG، بدلاً من تمديد المعاينة لملء الشريحة.

## **إنشاء وتضمين المخطط**

المثال الكامل التالي يملأ `DataSheet` بأربعة صفوف وخمسة أعمدة من القيم. يصبح كل صف سلسلة مخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ دفتر العمل.

يتم حفظ دفتر العمل صراحةً كـ XLSX، مطابقًا للامتداد `xlsx` الممرَّر إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). يتم تحميل PNG مباشرةً من بايتاته دون تحويل إلى bitmap وسيط. يبدل تعيينه عبر [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) العنصر النائب الافتراضي لـ OLE.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("DataSheet");

                int[][] values = {
                    { 67, 44, 46, 43, 24 },
                    { 86, 64, 97, 29, 40 },
                    { 68, 89, 78, 69, 38 },
                    { 91, 48, 60, 26, 25 }
                };

                for (int row = 0; row < values.length; row++) {
                    for (int column = 0; column < values[row].length; column++) {
                        dataSheet.getCells().get(row, column).putValue(values[row][column]);
                    }
                }

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                chartSheet.setName("ChartSheet");

                int lastChartRow = 55;
                int lastChartColumn = 25;
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                for (int row = 1; row <= values.length; row++) {
                    chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
                }

                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
                workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

                // إنشاء معاينة المخطط وتسلسل دفتر العمل القابل للتحرير بشكل منفصل.
                ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
                imageOptions.setImageType(ImageType.PNG);
                ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
                chart.toImage(chartImageStream, imageOptions);
                byte[] chartImageBytes = chartImageStream.toByteArray();

                ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                workbook.save(workbookStream, XLSX);
                byte[] workbookBytes = workbookStream.toByteArray();

                IImage chartImage = Images.fromData(chartImageBytes);
                try {
                    Presentation presentation = new Presentation();
                    try {
                        ISlide slide = presentation.getSlides().get_Item(0);
                        double slideWidth = presentation.getSlideSize().getSize().getWidth();
                        double slideHeight = presentation.getSlideSize().getSize().getHeight();

                        // تلائم المعاينة داخل الشريحة دون تغيير نسبة أبعادها.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
                    } finally {
                        presentation.dispose();
                    }
                } finally {
                    chartImage.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Could not create the presentation: " + exception.getMessage());
        }
    }
}
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة بملف Excel مضمّن ومعاينة مخطط. يحتوي دفتر العمل على البيانات الأصلية ومخطط عمودي بأربع سلاسل. المعاينة مُوسَّطة على الشريحة وتحتفظ بنسبة أبعادها.

![مخطط عمودي في Excel يظهر كمعاينة لدفتر عمل مضمّن](excel-chart-ole-preview.png)

في بيئة PowerPoint سطح مكتب متوافقة مع توفر Excel، انقر نقرًا مزدوجًا على الكائن لتفعيل وتعديل دفتر العمل المضمّن. يعتمد التفعيل والتعديل على دعم OLE لتطبيق المضيف وإعدادات الأمان.

## **الأسئلة المتكررة**

**لماذا تحتاج صورة معاينة؟**

دفتر العمل المضمن ومعاينة الشريحة الخاصة به محتوى منفصل. قدم صورة مخطط بحيث تعرض الشريحة المخطط بدلاً من العنصر النائب الافتراضي "EMBEDDED OLE OBJECT". انظر [مشكلة معاينة العنصر عند إضافة OleObjectFrame](/slides/ar/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**هل يتم تحديث المعاينة تلقائيًا عند تعديل دفتر العمل في الكود؟**

عامل المعاينة كصورة ثابتة. عند تحديث بيانات دفتر العمل برمجيًا، أعد توليد صورة المخطط واستبدل المعاينة بالإضافة إلى بيانات دفتر العمل المضمنة.

**هل يمكنني استخدام XLS بدلاً من XLSX؟**

نعم. احفظ دفتر العمل بتنسيق XLS واستخدم `xls` كامتداد البيانات المضمنة. يجب أن يتطابق الامتداد مع تنسيق دفتر العمل الفعلي؛ تغيير الامتداد وحده لا يحول البيانات.

**لماذا قد يتغير حجم الكائن بعد التفعيل؟**

قد يقوم تطبيق المضيف بتحديث عرض كائن OLE عند تفعيل دفتر العمل. يؤثر كل من نطاق عرض OLE لدفتر العمل وأبعاد إطار الشريحة. انظر [الحل العملي لإعادة تحجيم ورقة العمل](/slides/ar/androidjava/working-solution-for-worksheet-resizing/).

## **الأقسام ذات الصلة**

- [الحل العملي لإعادة تحجيم ورقة العمل](/slides/ar/androidjava/working-solution-for-worksheet-resizing/)
- [مشكلة معاينة العنصر عند إضافة OleObjectFrame](/slides/ar/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [إدارة OLE](/slides/ar/androidjava/manage-ole/)