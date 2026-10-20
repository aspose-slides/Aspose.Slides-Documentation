---
title: วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 40
url: /th/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- ออบเจ็กต์ OLE
- ฝังแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แก้ปัญหาการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ OLE ของ Excel ที่ฝังอยู่กับ Aspose.Slides สำหรับ Android ผ่าน Java ตั้งค่าขนาดแผนภูมิแบบคงที่เพื่อให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกัน"
---
## **ภาพรวม**

แผนภูมิ Excel ที่ฝังเป็นออบเจ็กต์ OLE ในงานนำเสนอ PowerPoint ด้วยคอมโพเนนต์ Aspose อาจเปลี่ยนขนาดหลังจากการเปิดใช้งานครั้งแรก ซึ่งทำให้แผนภูมิดูต่างกันอย่างเห็นได้ชัดก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายสาเหตุที่ทำให้ขนาดเปลี่ยนแปลงและแสดงวิธีป้องกันโดยการจับคู่ขนาดแผนภูมิที่คงที่กับกรอบ OLE

ใน [สร้างแผนภูมิ Excel แล้วฝังเป็นออบเจ็กต์ OLE ในงานนำเสนอ](/slides/th/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) เราได้อธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells for Android via Java และฝังลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Android via Java เพื่อแก้ปัญหา [issue การแสดงตัวอย่างออบเจ็กต์](/slides/th/androidjava/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดรูปภาพแผนภูมิให้กับกรอบออบเจ็กต์ OLE ของแผนภูมิ ในงานนำเสนอผลลัพธ์เมื่อคุณดับเบิลคลิกที่กรอบออบเจ็กต์ OLE ที่แสดงรูปภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถแก้ไขเวิร์กบุ๊ก Excel ที่ฝังไว้และกลับไปที่สไลด์โดยคลิกนอกเวิร์กบุ๊กที่เปิดใช้งาน ขนาดของกรอบออบเจ็กต์ OLE จะเปลี่ยนแปลงเมื่อผู้ใช้กลับไปที่สไลด์ และอัตราการปรับขนาดจะแตกต่างกันตามขนาดเดิมของกรอบออบเจ็กต์ OLE และเวิร์กบุ๊ก Excel ที่ฝังไว้

## **สาเหตุของการปรับขนาด**

เวิร์กบุ๊ก Excel ที่ฝังไว้มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามคงไว้เมื่อออบเจ็กต์ถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีขนาดที่กำหนดไว้แยกต่างหาก เมื่อเวิร์กบุ๊ก Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจาขนาดของออบเจ็กต์เพื่อรักษาสัดส่วนเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างเวิร์กบุ๊กและกรอบ OLE จึงทำให้เกิดการปรับขนาดของออบเจ็กต์

## **วิธีแก้ปัญหาที่ทำงาน**

กำหนดขนาดแผนภูมิให้ตรงกับกรอบ OLE บนสไลด์และทำให้ขนาดแผนภูมิอิสระจากหน้าต่างเวิร์กบุ๊ก วิธีนี้ทำงานได้ทั้งกับงานนำเสนอใหม่และเทมเพลตที่มีอยู่แล้ว

ตัวอย่างต้องใช้ Aspose.Cells for Android via Java และ Aspose.Slides for Android via Java สร้างแผนภูมิคอลัมน์ง่ายบนแผ่นงานแผนภูมิที่ใช้งานอยู่และฝังเวิร์กบุ๊กในรูปแบบ XLS เรียก `FixedChartSize.createPresentation(getFilesDir())` จากกิจกรรม Android เพื่อบันทึกผลลัพธ์ในไดเรกทอรีไฟล์ภายในของแอป การเปิดใช้งาน OLE ต้องใช้ PowerPoint บนเดสก์ท็อปและการติดตั้ง Excel ที่เข้ากันได้ ไม่ได้กำหนดรูปภาพตัวอย่างแผนภูมิ; แผนภูมิจะปรากฏเมื่อออบเจ็กต์ OLE ถูกเปิดใช้งานใน PowerPoint

ตัวอย่างสร้างงานนำเสนอใหม่พร้อมกรอบ OLE ขนาด 9.5 × 4 นิ้ว ตั้งอยู่ห่างจากขอบซ้าย 0.5 นิ้วและจากด้านบน 1 นิ้ว พิกัดและขนาดของสไลด์เป็นหน่วยจุด (72 จุดต่อหนึ่งนิ้ว) สำหรับงานนำเสนอที่มีอยู่แล้ว ดู [ใช้เทมเพลต](#use-a-template)

## **กำหนดขนาดแผนภูมิแบบคงที่**

ตั้งค่า [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) เป็น false เพื่อให้ขนาดแผนภูมิอิสระจากหน้าต่างเวิร์กบุ๊ก ตั้งค่าขนาดของ [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) ผ่าน [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) และ [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) โดยแปลงจากจุดเป็นพิกเซลที่ 96 พิกเซลต่อหนึ่งนิ้ว: กรอบที่มีขนาด 684 × 288 จุด เท่ากับแผนภูมิขนาด 912 × 384 พิกเซล ตั้งค่า [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) เป็นค่า CUSTOM ของ [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) ตัวอย่างฝังเวิร์กบุ๊กด้วย [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) และบันทึกงานนำเสนอพร้อมกรอบ OLE ขนาด 9.5 × 4 นิ้ว

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

                    // พิกัดและขนาดของสไลด์อยู่ในหน่วยจุด (72 จุดต่อหนึ่งนิ้ว).
                    float width = 684f; // 9.5 นิ้ว.
                    float height = 288f; // 4 นิ้ว.

                    chart.setSizeWithWindow(false);
                    // แปลงจากหน่วยจุดเป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว.
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

## **ใช้เทมเพลต**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่แล้ว เพื่อปรับตัวอย่างให้ทำงานได้:

1. โหลดงานนำเสนอเทมเพลตแทนการสร้างงานนำเสนอเปล่า
1. ตรวจสอบว่าสไลด์แรกมีอย่างน้อยสามรูปร่าง แล้วใช้รูปร่างที่ตำแหน่งดัชนี 2 เป็นตัวแสดงตำแหน่งใส่ข้อมูล
1. ดึงความกว้างและความสูงของกรอบจากรูปร่างนั้น แทนการใช้ค่าคงที่ 684 และ 288 คำนวณขนาดเท่าเดิม
1. เพิ่มกรอบ OLE ที่ตำแหน่งของตัวแสดงตำแหน่งแทนการใช้พิกัดคงที่ 36 และ 72
1. ลบตัวแสดงตำแหน่งออกก่อนบันทึกงานนำเสนอ

## **คำถามที่พบบ่อย**

**ทำไมแผนภูมิ Excel ที่ฝังไว้ถึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

เพราะ Excel พยายามคืนขนาดหน้าต่างเดิมเมื่อตอนเปิดใช้งานครั้งแรก ส่วนกรอบออบเจ็กต์ OLE ใน PowerPoint มีขนาดของมันเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้เกิดการปรับขนาด

**ฉันจะทำให้ขนาดแผนภูมิและกรอบ OLE สอดคล้องกันได้อย่างไร?**

กำหนดขนาดแผนภูมิแบบคงที่ให้ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์แผนภูมิแบบกำหนดเองก่อนฝังเวิร์กบุ๊ก ตัวอย่างด้านบนแสดงการตั้งค่าและการแปลงหน่วยที่จำเป็น

**การจับขนาดหน้าต่างเวิร์กบุ๊กเพียงอย่างเดียวพอหรือไม่?**

การจับขนาดหน้าต่างเวิร์กบุ๊กอย่างเดียวไม่สามารถป้องกันกรอบ OLE จากการเปลี่ยนขนาดหลังเปิดใช้งานได้อย่างแน่นอน ใช้ขนาดแผนภูมิแบบคงที่ตามตัวอย่าง

**วิธีแก้ปัญหานี้ทำงานได้กับงานนำเสนอแบบเทมเพลตและงานนำเสนอใหม่หรือไม่?**

ใช่ สำหรับเทมเพลต ให้ใช้ขนาดและตำแหน่งของตัวแสดงตำแหน่ง สำหรับงานนำเสนอใหม่ ให้ระบุขนาดและตำแหน่งของกรอบโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างใช้เวิร์กบุ๊ก Excel ที่สร้างด้วย Aspose.Cells ไม่ได้แสดงพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel แล้วฝังเป็นออบเจ็กต์ OLE ในงานนำเสนอ](/slides/th/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)