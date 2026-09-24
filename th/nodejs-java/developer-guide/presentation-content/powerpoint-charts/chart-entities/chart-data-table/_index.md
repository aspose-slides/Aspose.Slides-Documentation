---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอโดยใช้ JavaScript
linktitle: ตารางข้อมูล
type: docs
url: /th/nodejs-java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติตัวอักษร
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งแบบอักษร, เส้นขอบ และคีย์คำอธิบายของตารางข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java ช่วยให้คุณแสดงตารางข้อมูลของแผนภูมิและปรับแต่งการจัดรูปแบบข้อความ, เส้นขอบ, และคีย์คำอธิบายของตาราง บทความนี้อธิบายวิธีเปิดใช้งานตาราง, จัดรูปแบบข้อความ, ควบคุมประเภทของเส้นขอบแต่ละประเภท, และแสดงหรือซ่อนคีย์คำอธิบาย ตัวอย่างจะบันทึกแผนภูมิที่กำหนดค่าไว้ในไฟล์ PPTX

## **ตั้งค่าคุณสมบัติตัวอักษร**

เพื่อแสดงตารางข้อมูลของแผนภูมิ ให้ส่งค่า `true` ไปยัง [setDataTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/setdatatable/). ใช้ [getChartDataTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/getchartdatatable/) เพื่อเข้าถึงตารางและกำหนดการจัดรูปแบบข้อความ

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์แรก  
1. เปิดใช้งานตารางข้อมูลของแผนภูมิ  
1. เปิดใช้งานข้อความหนาโดยใช้ [setFontBold](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setfontbold) และส่งค่า `20` ไปยัง [setFontHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setfontheight) เพื่อกำหนดข้อความขนาด 20 จุด  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างต่อไปนี้ต้องการไฟล์ `input.pptx` ในไดเรกทอรีทำงานที่มีอย่างน้อยหนึ่งสไลด์ จะเพิ่มแผนภูมิที่มีข้อมูลค่าเริ่มต้นที่ตำแหน่ง (50, 50) ความกว้าง 600 จุด และความสูง 400 จุด ไฟล์ `output.pptx` ที่บันทึกจะมีแผนภูมิพร้อมตารางข้อมูลที่เปิดใช้งานและตั้งค่าฟอนต์ตามที่ระบุ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ปรับแต่งขอบตารางข้อมูล**

เปิดตารางโดยใช้ [Chart.setDataTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/setdatatable/) และเข้าถึงผ่าน [Chart.getChartDataTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/getchartdatatable/) คุณสามารถควบคุมขอบสามประเภทแยกกันได้:

- [setBorderHorizontal](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datatable/setborderhorizontal/) ควบคุมขอบแนวนอนของเซลล์  
- [setBorderVertical](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datatable/setbordervertical/) ควบคุมขอบแนวตั้งของเซลล์  
- [setBorderOutline](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datatable/setborderoutline/) ควบคุมขอบรอบนอกของตาราง  

ส่งค่า `true` ไปยังแต่ละเมธอดเพื่อแสดงขอบ หรือ `false` เพื่อซ่อนขอบ ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีข้อมูลค่าเริ่มต้น, แสดงขอบแนวนอนและขอบรอบนอก, และซ่อนขอบแนวตั้ง ไม่ต้องการไฟล์อินพุต ตำแหน่งและขนาดของแผนภูมิระบุเป็นจุด

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ตารางข้อมูลแผนภูมิกับขอบทั้งหมดเปิดใช้งาน, ไม่มีขอบแนวนอน, ไม่มีขอบแนวตั้ง, และไม่มีขอบรอบนอก](data-table-borders.png)

## **แสดงหรือซ่อนคีย์คำอธิบาย**

คีย์คำอธิบายเป็นสัญลักษณ์สีเล็ก ๆ อยู่ข้างชื่อซีรีส์ในตารางข้อมูล ช่วยให้ผู้อ่านจับคู่แต่ละแถวของตารางกับซีรีส์ของแผนภูมิ ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datatable/setshowlegendkey/) เพื่อแสดงสัญลักษณ์เหล่านี้หรือ `false` เพื่อซ่อน  

คีย์คำอธิบายของแผนภูมิที่แยกออกมาถูกควบคุมโดย [Chart.setLegend](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/setlegend/) การตั้งค่านี้เป็นอิสระ: การซ่อนคีย์คำอธิบายแยกจะไม่ส่งผลต่อคีย์ในตารางข้อมูล และการซ่อนคีย์ในตารางข้อมูลจะไม่ส่งผลต่อคีย์คำอธิบายแยก  

ตัวอย่างต่อไปนี้สร้างแผนภูมิที่มีข้อมูลค่าเริ่มต้น, เปิดใช้งานตารางข้อมูล, แสดงคีย์คำอธิบายในตารางพร้อมซ่อนคีย์คำอธิบายแยก ทั้งหมดของขอบตารางถูกเปิดใช้งานอย่างชัดเจน ไม่ต้องการงานนำเสนออินพุตใด ๆ เพื่อต้องการซ่อนคีย์ของตารางเท่านั้น ให้ส่งค่า `false` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datatable/setshowlegendkey/)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ตารางข้อมูลแผนภูมิกับคีย์คำอธิบายแสดงด้านซ้ายและซ่อนด้านขวา](data-table-legend-keys.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ได้ ส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datatable/setshowlegendkey/) เพื่อแสดงคีย์คำอธิบายหรือ `false` เพื่อซ่อน

**ตารางข้อมูลจะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ได้ Aspose.Slides จะเรนเดอร์แผนภูมิและตารางข้อมูลที่แสดงเป็นส่วนหนึ่งของสไลด์เมื่อส่งออกเป็น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/), หรือ [images](/slides/th/nodejs-java/convert-powerpoint-to-png/)

**ฉันสามารถทำงานกับตารางข้อมูลในแผนภูมิที่โหลดมาจากเทมเพลตได้หรือไม่?**

ได้ สำหรับแผนภูมิที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่ ให้ใช้ [hasDataTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/hasdatatable/) และ [setDataTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/setdatatable/) เพื่อตรวจสอบหรือเปลี่ยนแปลงว่าตารางข้อมูลถูกแสดงหรือไม่

**ฉันจะค้นหาแผนภูมิที่เปิดใช้งานตารางข้อมูลได้อย่างไร?**

วนรอบผ่านรูปร่างบนแต่ละสไลด์, ระบุแผนภูมิและเรียกเมธอด [hasDataTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/hasdatatable/) ของมัน ค่าที่ได้เป็น `true` หมายถึงตารางข้อมูลถูกเปิดใช้งาน