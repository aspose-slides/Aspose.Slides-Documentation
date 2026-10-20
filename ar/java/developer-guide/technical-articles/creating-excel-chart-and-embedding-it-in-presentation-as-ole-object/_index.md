---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 30
url: /ar/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين المخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells for Java وتضمين دفتر العمل في عرض PowerPoint باستخدام Aspose.Slides، مع معاينة للمخطط."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء مخطط أعمدة Excel باستخدام Aspose.Cells for Java وتضمين دفتر العمل الخاص به في عرض تقديمي PowerPoint باستخدام Aspose.Slides for Java. يحتوي دفتر العمل المضمن على كل من البيانات المصدرية والمخطط. يتم عرض معاينة PNG منفصلة للمخطط على الشريحة قبل تنشيط كائن OLE.

النتيجة هي كائن Excel مدمج، وليس مخطط PowerPoint أصلي. يتطلب تحرير دفتر العمل عبر OLE تطبيقًا سطح مكتب يدعم تنشيط OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

أضف Aspose.Cells for Java و Aspose.Slides for Java إلى تبعيات مشروعك. شغّل المثال داخل طريقة Java. لا يلزم وجود Microsoft Office لإنشاء العرض التقديمي باستخدام هذه المكتبات.

لا توجد ملفات إدخال مطلوبة: ينشئ المثال البيانات والمخطط في الذاكرة، ثم يكتب `OutputChart.pptx` إلى دليل العمل الحالي. قم بتطبيق تراخيص كلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيف يعمل التضمين**

1. إنشاء دفتر عمل يحتوي على ورقة بيانات وورقة مخطط.
2. اجعل ورقة المخطط نشطة بحيث يفتح دفتر العمل على المخطط.
3. حدد نطاق عرض OLE لدفتر العمل وقم بتصيير المخطط إلى PNG.
4. احفظ دفتر العمل كملف XLSX في الذاكرة وضمّ تلك البايتات في شريحة.
5. عيّن PNG كمعاينة لكائن OLE واحفظ العرض التقديمي كملف PPTX.

نطاق عرض دفتر العمل والإطار على الشريحة لهما أدوار مختلفة. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) يأخذ مؤشرات الصف والعمود للبداية/النهاية صفرية الأساس. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) بدلاً من ذلك يأخذ الصف العلوي، العمود الأيسر، الصف السفلي، والعمود الأيمن. يستخدم المثال فهرس الصف 55 وفهرس العمود 25 كحدود السفلية اليمنى؛ هذه القيم اختيار تخطيط، ليست عدد الصفوف أو الأعمدة في البيانات.

يستخدم إطار الشريحة النقاط. يضبط المثال الإطار ضمن الشريحة ويضعه في الوسط مع الحفاظ على نسبة أبعاد PNG، بدلاً من تمديد المعاينة لملء الشريحة.

## **إنشاء وتضمين المخطط**

يعرض المثال الكامل التالي ملء `DataSheet` بأربعة صفوف وخمس أعمدة من القيم. يصبح كل صف سلسلة مخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ دفتر العمل.

يتم حفظ دفتر العمل صراحةً كملف XLSX، متطابقًا مع الامتداد `xlsx` الممرر إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). يتم تحميل PNG مباشرةً من بايتاته دون تحويل bitmap وسيط. يؤدي تعيينه عبر [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) إلى استبدال العنصر النائب الافتراضي لـ OLE.

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

        // توليد معاينة المخطط وتسلسل دفتر العمل القابل للتحرير بشكل منفصل.
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

                // ضبط المعاينة داخل الشريحة دون تغيير نسبة أبعادها.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
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
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة بها دفتر عمل Excel مدمج ومعاينة للمخطط. يحتوي دفتر العمل على البيانات الأصلية ومخطط أعمدة بأربع سلاسل. المعاينة متمركزة على الشريحة وتحتفظ بأبعادها.

![مخطط أعمدة Excel معروض كمعاينة لدفتر عمل مدمج](excel-chart-ole-preview.png)

في بيئة PowerPoint سطح مكتب متوافقة مع توفر Excel، انقر نقرًا مزدوجًا على الكائن لتنشيطه وتحرير دفتر العمل المدمج. يعتمد التنشيط والتحرير على دعم OLE لتطبيق المضيف وإعدادات الأمان.

## **الأسئلة المتكررة**

**لماذا تحتاج صورة معاينة؟**

دفتر العمل المدمج ومعاينة الشريحة الخاصة به محتوى منفصل. قدم صورة مخطط بحيث تعرض الشريحة المخطط بدلاً من العنصر النائب الافتراضي "EMBEDDED OLE OBJECT". راجع [Object Preview Issue when Adding OleObjectFrame](/slides/ar/java/object-preview-issue-when-adding-oleobjectframe/).

**هل يتم تحديث المعاينة تلقائيًا عندما أغيّر دفتر العمل في الشيفرة؟**

عامل المعاينة كلقطة ثابتة. عند تحديث بيانات دفتر العمل برمجياً، أعد توليد صورة المخطط واستبدل المعاينة بالإضافة إلى بيانات دفتر العمل المدمج.

**هل يمكنني استخدام XLS بدلاً من XLSX؟**

نعم. احفظ دفتر العمل بتنسيق XLS واستخدم `xls` كامتداد للبيانات المدمجة. يجب أن يتطابق الامتداد مع تنسيق دفتر العمل الفعلي؛ تغيير الامتداد وحده لا يقوم بتحويل البيانات.

**لماذا قد يتغير حجم الكائن بعد التنشيط؟**

يمكن لتطبيق المضيف تحديث عرض كائن OLE عندما ينشط دفتر العمل. يؤثر نطاق عرض OLE لدفتر العمل وأبعاد إطار الشريحة معًا. راجع [Working Solution for Chart Resizing in PPTX](/slides/ar/java/working-solution-for-chart-resizing-in-pptx/).

## **الأقسام ذات الصلة**

- [حل عملي لإعادة تحجيم المخطط في PPTX](/slides/ar/java/working-solution-for-chart-resizing-in-pptx/)
- [مشكلة معاينة الكائن عند إضافة OleObjectFrame](/slides/ar/java/object-preview-issue-when-adding-oleobjectframe/)
- [تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint](/slides/ar/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)