---
title: "วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX"
type: docs
weight: 40
url: /th/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- "การปรับขนาดแผนภูมิ"
- "แผนภูมิ Excel"
- "วัตถุ OLE"
- "ฝังแผนภูมิ"
- "PowerPoint"
- "งานนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "แก้ไขการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ OLE ของ Excel ที่ฝังไว้กับ Aspose.Slides สำหรับ Java ตั้งค่าขนาดแผนภูมิคงที่เพื่อให้ขนาดของแผนภูมิและกรอบ OLE คงที่สม่ำเสมอ"
---
## **พื้นหลัง**

แผนภูมิ Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint โดยใช้ส่วนประกอบของ Aspose สามารถเปลี่ยนขนาดหลังจากการเปิดใช้งานครั้งแรกได้ ซึ่งอาจทำให้การแสดงผลของแผนภูมิมีความแตกต่างอย่างชัดเจนก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายสาเหตุที่ทำให้ขนาดเปลี่ยนและแสดงวิธีป้องกันโดยการทำให้ขนาดแผนภูมิที่กำหนดคงที่ตรงกับกรอบ OLE

ใน[สร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ](/slides/th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) เราอธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells for Java และฝังลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Java เพื่อแก้ไข[ปัญหาการแสดงตัวอย่างวัตถุ](/slides/th/java/object-preview-issue-when-adding-oleobjectframe/) เราได้กำหนดภาพแผนภูมิให้กับกรอบวัตถุ OLE ของแผนภูมิ ในงานนำเสนอที่ได้ผลลัพธ์เมื่อคุณดับเบิลคลิกที่กรอบวัตถุ OLE ที่แสดงภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถแก้ไขสมุดงาน Excel ที่ฝังอยู่แล้วกลับไปยังสไลด์โดยคลิกนอกสมุดงานที่เปิดใช้งาน ขนาดของกรอบวัตถุ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์และปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดดั้งเดิมของกรอบวัตถุ OLE และสมุดงาน Excel ที่ฝังอยู่

## **สาเหตุของการเปลี่ยนขนาด**

สมุดงาน Excel ที่ฝังอยู่มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามคงไว้เมื่อวัตถุถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีขนาดที่กำหนดแยกจากกัน เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะต่อรองขนาดของวัตถิเพื่อรักษาอัตราส่วนส่วนสูง-กว้างเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างสมุดงานและกรอบ OLE จึงอาจทำให้วัตถุปรับขนาดได้

## **วิธีแก้ปัญหาที่ทำงานได้**

ทำให้ขนาดแผนภูมิตรงกับกรอบ OLE บนสไลด์และทำให้ขนาดแผนภูมิอิสระจากหน้าต่างสมุดงาน วิธีนี้ใช้ได้กับงานนำเสนอใหม่หรือเทมเพลตที่มีอยู่

ตัวอย่างต้องใช้ Aspose.Cells for Java และ Aspose.Slides for Java มันสร้างแผนภูมิคอลัมน์ง่ายบนชีตแผนภูมิที่ใช้งานอยู่และฝังสมุดงานในรูปแบบ XLS ไม่ได้กำหนดภาพแผนภูมิก่อนแสดง; แผนภูมิจะปรากฏเมื่อวัตถุ OLE ถูกเปิดใช้งานใน PowerPoint

ตัวอย่างสร้างงานนำเสนอใหม่ที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว วางตำแหน่ง 0.5 นิ้วจากขอบซ้ายและ 1 นิ้วนับจากด้านบน พิกัดและขนาดของสไลด์ใช้หน่วยจุด (72 จุดต่อหนึ่งนิ้ว) สำหรับงานนำเสนอที่มีอยู่ ดู[ใช้เทมเพลต](#use-a-template)

## **ตั้งค่าขนาดแผนภูมิคงที่**

ตั้งค่า[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-)เป็นfalseเพื่อให้ขนาดแผนภูมิอิสระจากหน้าต่างสมุดงาน กำหนดขนาดของ[getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--)ผ่าน[setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-)และ[setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-)โดยแปลงจากจุดเป็นพิกเซลที่ 96 พิกเซลต่อหนึ่งนิ้ว: กรอบที่วัดได้ 684 × 288 จุดสอดคล้องกับแผนภูมิที่วัดได้ 912 × 384 พิกเซล ตั้งค่า[setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-)เป็นค่​CUSTOMของ[PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) ตัวอย่างฝังกรอบด้วย[addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)และบันทึกงานนำเสนอที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว

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

        // พิกัดและขนาดของสไลด์ใช้หน่วยจุด (72 จุดต่อนิ้ว).
        float width = 684f; // 9.5 นิ้ว.
        float height = 288f; // 4 นิ้ว.

        chart.setSizeWithWindow(false);
        // แปลงจากจุดเป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว.
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

## **ใช้เทมเพลต**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่ เพื่อปรับตัวอย่างให้เข้ากับเทมเพลต:

1. โหลดงานนำเสนอเทมเพลตแทนการสร้างงานนำเสนอเปล่า
1. ตรวจสอบให้แน่ใจว่าสไลด์แรกมีรูปร่างอย่างน้อยสามรูป แล้วใช้รูปร่างที่ตำแหน่งดัชนี 2 เป็นตัวแทนที่จอด
1. ดึงความกว้างและความสูงของกรอบจากรูปร่างนั้นแทนการใช้ค่าคงที่ 684 และ 288 คำนวณขนาดตามเดิม
1. เพิ่มกรอบ OLE ที่ตำแหน่งของตัวแทนที่จอดแทนการใช้พิกัดคงที่ 36 และ 72
1. ลบตัวแทนที่จอดก่อนบันทึกงานนำเสนอ

## **คำถามที่พบบ่อย**

**ทำไมแผนภูมิ Excel ที่ฝังอยู่จึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

เหตุนี้เกิดจาก Excel พยายามคืนขนาดหน้าต่างเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบวัตถุ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะต่อรองขนาดเพื่อรักษาอัตราส่วน ซึ่งอาจทำให้ขนาดปรับเปลี่ยน

**ฉันจะทำให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกันได้อย่างไร?**

กำหนดขนาดแผนภูมิคงที่ให้ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์แผนภูมิแบบกำหนดเองก่อนฝังสมุดงาน ตัวอย่างด้านบนแสดงการตั้งค่าที่จำเป็นและการแปลงหน่วย

**การทำให้ขนาดหน้าต่างสมุดงานตรงกันพอหรือไม่?**

การทำให้ขนาดหน้าต่างสมุดงานตรงกันเพียงอย่างเดียวไม่สามารถป้องกันกรอบ OLE จากการเปลี่ยนขนาดหลังเปิดใช้งานได้อย่างเชื่อถือ ใช้ขนาดแผนภูมิคงที่ตามที่แสดงในตัวอย่าง

**วิธีแก้ปัญหานี้ทำงานกับงานนำเสนอแบบเทมเพลตและงานนำเสนอใหม่หรือไม่?**

ทำงานได้ ทั้งสำหรับเทมเพลต ให้ใช้ขนาดและตำแหน่งของตัวแทนที่จอด สำหรับงานนำเสนอใหม่ ให้ระบุขนาดและตำแหน่งของกรอบโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างใช้สมุดงาน Excel ที่สร้างด้วย Aspose.Cells ไม่ได้สาธิตพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ](/slides/th/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)