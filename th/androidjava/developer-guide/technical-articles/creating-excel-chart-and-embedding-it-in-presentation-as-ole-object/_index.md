---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE
type: docs
weight: 30
url: /th/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells for Android via Java และฝังสมุดงานลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Android via Java พร้อมภาพตัวอย่างของแผนภูมิ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างแผนภูมิคอลัมน์ Excel ด้วย Aspose.Cells for Android via Java และฝังสมุดงานไว้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Android via Java สมุดงานที่ฝังไว้จะมีข้อมูลต้นฉบับและแผนภูมิรวมอยู่ด้วย ภาพตัวอย่าง PNG แยกต่างหากจะแสดงแผนภูมิบนสไลด์ก่อนที่วัตถุ OLE จะถูกเปิดใช้งาน

ผลลัพธ์คือวัตถุ Excel ที่ฝังอยู่ ไม่ใช่แผนภูมิดั้งเดิมของ PowerPoint การแก้ไขสมุดงานผ่าน OLE ต้องอาศัยแอปพลิเคชันบนเดสก์ท็อปที่รองรับการเปิดใช้งาน OLE และติดตั้ง Excel ที่เข้ากันได้

## **ข้อกำหนดเบื้องต้น**

เพิ่ม Aspose.Cells for Android via Java และ Aspose.Slides for Android via Java ไปยัง dependencies ของโปรเจกต์ของคุณ เรียก `ExcelChartEmbedding.createPresentation(getFilesDir())` จาก Activity ของ Android Microsoft Office ไม่จำเป็นสำหรับการสร้างงานนำเสนอด้วยไลบรารีเหล่านี้

ไม่ต้องมีไฟล์อินพุต: ตัวอย่างจะสร้างข้อมูลและแผนภูมิในหน่วยความจำ แล้วเขียน `OutputChart.pptx` ไปยังไดเรกทอรีไฟล์ภายในของแอป ใช้ไลเซนส์สำหรับทั้งสองผลิตภัณฑ์เมื่อรันนอกโหมดประเมินผล

## **วิธีการทำงานของการฝัง**

1. สร้างสมุดงานที่มีชีตข้อมูลและชีตแผนภูมิ
1. ทำให้ชีตแผนภูมิเป็นชีตที่เปิดใช้งานเพื่อให้สมุดงานเปิดที่แผนภูมิ
1. กำหนดช่วงการแสดงผล OLE ของสมุดงานและเรนเดอร์แผนภูมิเป็น PNG
1. บันทึกสมุดงานเป็น XLSX ในหน่วยความจำและฝังไบต์เหล่านั้นในสไลด์
1. ตั้งค่า PNG เป็นภาพตัวอย่างของวัตถุ OLE แล้วบันทึกงานนำเสนอเป็น PPTX

ช่วงการแสดงผลของสมุดงานและกรอบบนสไลด์มีบทบาทที่ต่างกัน [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) รับดัชนีแถวและคอลัมน์เริ่มต้น/สิ้นสุดแบบศูนย์ฐาน ส่วน [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) จะรับแถวบนสุด คอลัมน์ซ้าย แถวล่างสุด และคอลัมน์ขวา ตัวอย่างใช้ดัชนีแถว 55 และคอลัมน์ 25 เป็นขอบเขตด้านล่าง‑ขวา; ค่านี้เป็นการเลือกการจัดวาง ไม่ได้บ่งบอกจำนวนแถวหรือคอลัมน์ของข้อมูล

กรอบสไลด์ใช้หน่วยจุด ตัวอย่างทำให้พอดีภายในสไลด์และจัดกึ่งกลางโดยคงอัตราส่วนของ PNG ไว้ แทนที่จะยืดภาพตัวอย่างให้เต็มสไลด์

## **สร้างและฝังแผนภูมิ**

ตัวอย่างเต็มด้านล่างจะเติม `DataSheet` ด้วยค่าทั้งหมด 4 แถวและ 5 คอลัมน์ แต่ละแถวจะกลายเป็นชุดข้อมูลของแผนภูมิ `ChartSheet` จะถูกเลือกเป็นชีตที่เปิดใช้งานก่อนบันทึกสมุดงาน

สมุดงานจะบันทึกเป็น XLSX อย่างชัดเจนเพื่อให้สอดคล้องกับส่วนขยาย `xlsx` ที่ส่งไปยัง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). PNG จะถูกโหลดโดยตรงจากไบต์โดยไม่ต้องแปลงเป็นบิทแมป การกำหนดผ่าน [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) จะแทนที่ตัวจุดพัก OLE เริ่มต้น

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

                // เรนเดอร์ภาพตัวอย่างแผนภูมิและทำการแปลงสมุดงานที่แก้ไขได้เป็นไบต์แยกต่างหาก.
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

                        // ปรับขนาดภาพตัวอย่างให้พอดีในสไลด์โดยไม่เปลี่ยนอัตราส่วนภาพ.
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

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีสไลด์หนึ่งสไลด์ที่ฝังสมุดงาน Excel และภาพตัวอย่างของแผนภูมิไว้ สมุดงานประกอบด้วยข้อมูลดั้งเดิมและแผนภูมิคอลัมน์ที่มี 4 ชุด ขนาดของภาพตัวอย่างจะอยู่กึ่งกลางสไลด์และคงอัตราส่วนเดิม

![แผนภูมิคอลัมน์ Excel แสดงเป็นภาพตัวอย่างของสมุดงานที่ฝังไว้](excel-chart-ole-preview.png)

ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่มี Excel พร้อมใช้งาน ให้คลิกสองครั้งที่วัตถุเพื่อเปิดใช้งานและแก้ไขสมุดงานที่ฝังไว้ การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปโฮสต์และการตั้งค่าความปลอดภัย

## **คำถามที่พบบ่อย**

**ทำไมต้องมีภาพตัวอย่าง?**

สมุดงานที่ฝังและภาพตัวอย่างบนสไลด์เป็นเนื้อหาที่แยกจากกัน จำเป็นต้องจัดเตรียมภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนตัวจุดพัก "EMBEDDED OLE OBJECT" เริ่มต้น ดู [Object Preview Issue when Adding OleObjectFrame](/slides/th/androidjava/object-preview-issue-when-adding-oleobjectframe/)

**ภาพตัวอย่างจะอัปเดตอัตโนมัติเมื่อเปลี่ยนสมุดงานในโค้ดหรือไม่?**

ให้ถือว่าภาพตัวอย่างเป็นสแนปชอต เมื่ออัปเดตข้อมูลสมุดงานโดยโปรแกรม ควรสร้างภาพแผนภูมิใหม่และแทนที่ภาพตัวอย่างพร้อมกับข้อมูลสมุดงานที่ฝังไว้

**สามารถใช้ XLS แทน XLSX ได้หรือไม่?**

ได้ ให้บันทึกสมุดงานเป็นรูปแบบ XLS แล้วใช้ `xls` เป็นส่วนขยายของข้อมูลที่ฝัง ส่วนขยายต้องตรงกับรูปแบบสมุดงานจริง; การเปลี่ยนเพียงส่วนขยายอย่างเดียวจะไม่ทำการแปลงข้อมูล

**ทำไมวัตถุอาจเปลี่ยนขนาดหลังจากเปิดใช้งาน?**

แอปโฮสต์อาจอัปเดตการแสดงผลของวัตถุ OLE เมื่อเปิดใช้งานสมุดงาน ทั้งช่วงการแสดงผล OLE ของสมุดงานและขนาดกรอบสไลด์มีผล ดู [Working Solution for Worksheet Resizing](/slides/th/androidjava/working-solution-for-worksheet-resizing/)

## **ส่วนที่เกี่ยวข้อง**

- [Working Solution for Worksheet Resizing](/slides/th/androidjava/working-solution-for-worksheet-resizing/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/th/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE](/slides/th/androidjava/manage-ole/)