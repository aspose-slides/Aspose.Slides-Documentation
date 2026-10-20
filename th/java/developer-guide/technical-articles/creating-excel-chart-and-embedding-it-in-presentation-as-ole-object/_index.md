---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE
type: docs
weight: 30
url: /th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells สำหรับ Java และฝังเวิร์กบุ๊กในงานนำเสนอ PowerPoint ด้วย Aspose.Slides พร้อมภาพพรีวิวของแผนภูมิ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการสร้างแผนภูมิคอลัมน์ Excel ด้วย Aspose.Cells for Java และฝังเวิร์กบุ๊กของมันในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Java. เวิร์กบุ๊กที่ฝังรวมข้อมูลต้นฉบับและแผนภูมิไว้ด้วยกัน. การแสดงภาพล่วงหน้า PNG แยกต่างหากจะแสดงแผนภูมิบนสไลด์ก่อนที่วัตถุ OLE จะเปิดใช้งาน.

ผลลัพธ์คือวัตถุ Excel ที่ฝังอยู่, ไม่ใช่แผนภูมิ PowerPoint แท้. การแก้ไขเวิร์กบุ๊กผ่าน OLE จำเป็นต้องใช้แอปพลิเคชันเดสก์ท็อปที่รองรับการเปิดใช้งาน OLE และการติดตั้ง Excel ที่เข้ากันได้.

## **ข้อกำหนดเบื้องต้น**

เพิ่ม Aspose.Cells for Java และ Aspose.Slides for Java ไปยังการพึ่งพาของโปรเจกต์ของคุณ. รันตัวอย่างภายในเมธอด Java. ไม่จำเป็นต้องใช้ Microsoft Office เพื่อสร้างงานนำเสนอด้วยไลบรารีเหล่านี้.

ไม่ต้องใช้ไฟล์อินพุตใด ๆ: ตัวอย่างสร้างข้อมูลและแผนภูมิในหน่วยความจำ, จากนั้นเขียน `OutputChart.pptx` ไปยังไดเรกทอรีทำงานปัจจุบัน. ใช้ไลเซนส์สำหรับทั้งสองผลิตภัณฑ์เมื่อต้องการเรียกใช้ในโหมดนอกการประเมินผล.

## **วิธีการฝังทำงาน**

1. สร้างเวิร์กบุ๊กที่มีแผ่นงานข้อมูลและแผ่นงานแผนภูมิ.
1. ทำให้แผ่นงานแผนภูมิเข้าเป็นแอคทีฟเพื่อให้เวิร์กบุ๊กเปิดที่แผนภูมิ.
1. กำหนดช่วงการแสดงผล OLE ของเวิร์กบุ๊กและเรนเดอร์แผนภูมิเป็น PNG.
1. บันทึกเวิร์กบุ๊กเป็น XLSX ในหน่วยความจำและฝังไบท์เหล่านั้นในสไลด์.
1. กำหนด PNG เป็นภาพล่วงหน้าของวัตถุ OLE และบันทึกงานนำเสนอเป็น PPTX.

ช่วงการแสดงผลของเวิร์กบุ๊กและกรอบบนสไลด์มีบทบาทที่แตกต่างกัน. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) รับดัชนีแถวและคอลัมน์เริ่มต้น/สิ้นสุดแบบเริ่มจากศูนย์. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) แทนที่จะรับแถวบน, คอลัมน์ซ้าย, แถวล่าง, และคอลัมน์ขวา. ตัวอย่างใช้ดัชนีแถว 55 และดัชนีคอลัมน์ 25 เป็นขอบล่างขวา; ค่าดังกล่าวเป็นการเลือกรูปแบบการจัดวาง, ไม่ใช่จำนวนแถวหรือคอลัมน์ของข้อมูล.

กรอบสไลด์ใช้หน่วยจุด. ตัวอย่างทำให้พอดีภายในสไลด์และจัดกึ่งกลางโดยคงอัตราส่วนของ PNG, แทนการยืดภาพล่วงหน้าให้เต็มสไลด์.

## **สร้างและฝังแผนภูมิ**

ตัวอย่างเต็มต่อไปนี้เติมค่าลงใน `DataSheet` ด้วยแถวสี่แถวและคอลัมน์ห้าคอลัมน์. แต่ละแถวจะกลายเป็นซีรีส์ของแผนภูมิ. `ChartSheet` ถูกเลือกเป็นแผ่นงานที่ใช้งานอยู่ก่อนบันทึกเวิร์กบุ๊ก.

เวิร์กบุ๊กถูกบันทึกเป็น XLSX อย่างชัดเจน, ตรงกับส่วนต่อท้าย `xlsx` ที่ส่งไปยัง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). PNG ถูกโหลดโดยตรงจากไบท์โดยไม่มีการแปลงบิตแมปกลาง. การกำหนดผ่าน [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) จะแทนที่ตัวจัดตำแหน่ง OLE เริ่มต้น.

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

        // เรนเดอร์ภาพพรีวิวของแผนภูมิและทำการซีเรียลไลซ์เวิร์กบุ๊กที่แก้ไขได้แยกต่างหาก.
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

                // ปรับภาพพรีวิวให้พอดีภายในสไลด์โดยไม่เปลี่ยนอัตราส่วนของมัน.
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

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีสไลด์หนึ่งที่ฝังเวิร์กบุ๊ก Excel และภาพล่วงหน้าแผนภูมิ. เวิร์กบุ๊กมีข้อมูลต้นฉบับและแผนภูมิคอลัมน์ที่มีสี่ซีรีส์. ภาพล่วงหน้าถูกจัดกึ่งกลางบนสไลด์และคงอัตราส่วนไว้.

![แผนภูมิคอลัมน์ Excel แสดงเป็นภาพล่วงหน้าของเวิร์กบุ๊กที่ฝังอยู่](excel-chart-ole-preview.png)

ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่เข้ากันได้และมี Excel อยู่, ดับเบิลคลิกวัตถุเพื่อเปิดใช้งานและแก้ไขเวิร์กบุ๊กที่ฝังไว้. การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปพลิเคชันโฮสต์และการตั้งค่าความปลอดภัย.

## **คำถามที่พบบ่อย**

**ทำไมต้องการภาพล่วงหน้า?**

เวิร์กบุ๊กที่ฝังและภาพล่วงหน้าของสไลด์เป็นเนื้อหาแยกกัน. ให้ภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนตัวจัดตำแหน่งเริ่มต้น "EMBEDDED OLE OBJECT". ดู [Object Preview Issue when Adding OleObjectFrame](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/).

**ภาพล่วงหน้าจะอัพเดตโดยอัตโนมัติหรือไม่เมื่อฉันเปลี่ยนเวิร์กบุ๊กในโค้ด?**

ถือภาพล่วงหน้าเป็นสแนปช็อต. เมื่ออัพเดตข้อมูลเวิร์กบุ๊กด้วยโปรแกรม, ให้สร้างภาพแผนภูมิใหม่และแทนที่ภาพล่วงหน้าและข้อมูลเวิร์กบุ๊กที่ฝัง.

**ฉันสามารถใช้ XLS แทน XLSX ได้หรือไม่?**

ใช่. บันทึกเวิร์กบุ๊กในรูปแบบ XLS และใช้ `xls` เป็นส่วนต่อท้ายของข้อมูลที่ฝัง. ส่วนต่อท้ายต้องตรงกับรูปแบบเวิร์กบุ๊กจริง; การเปลี่ยนส่วนต่อท้ายอย่างเดียวไม่แปลงข้อมูล.

**ทำไมวัตถุอาจเปลี่ยนขนาดหลังจากเปิดใช้งาน?**

แอปพลิเคชันโฮสต์อาจอัปเดตการนำเสนอของวัตถุ OLE เมื่อเปิดใช้งานเวิร์กบุ๊ก. ทั้งช่วงการแสดงผล OLE ของเวิร์กบุ๊กและขนาดของกรอบสไลด์มีความสำคัญ. ดู [Working Solution for Chart Resizing in PPTX](/slides/th/java/working-solution-for-chart-resizing-in-pptx/).

## **ส่วนที่เกี่ยวข้อง**

- [วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/java/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาภาพล่วงหน้าของวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/)
- [อัปเดตวัตถุ OLE อัตโนมัติโดยใช้ PowerPoint Add-In](/slides/th/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)