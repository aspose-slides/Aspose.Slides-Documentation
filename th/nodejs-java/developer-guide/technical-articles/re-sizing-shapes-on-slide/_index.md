---
title: ปรับขนาดรูปร่างบนสไลด์การนำเสนอใน Node.js
type: docs
weight: 130
url: /th/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java—ทำการปรับเลย์เอาต์สไลด์โดยอัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของการนำเสนอ คุณอาจต้องปรับขนาดและตำแหน่งของรูปร่างเพื่อให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีการปรับขนาดรูปร่างด้วยตนเองและวิธีจัดการกับตารางบนสไลด์ มาสเตอร์ และเลเอาต์

## **ปรับขนาดรูปร่าง**

เพื่อคงตำแหน่งและขนาดสัมพันธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างของมันด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม แล้วใช้สัดส่วนความสูงที่สอดคล้องกับพิกัดแนวตั้งและความสูงของมัน

ตัวอย่างแรกโหลดการนำเสนอที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ ใช้ [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) ร่วมกับ [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) เพื่อให้ลูปต่อมาควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและขนาดของรูปร่างวัดเป็นพอยต์ อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปร่างบิดเบี้ยว และการเปลี่ยนขนาดของรูปร่างจะไม่ปรับขนาดฟอนต์

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // คำนวณอัตราสเกลแนวนอนและแนวตั้งแบบอิสระ.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
ตารางต้องการการจัดการแยกต่างหาก: ปรับสเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงโดยรวมของตาราง ความสูงของแถวอาจยังคงใหญ่กว่าที่ขอไว้หากเนื้อหาในเซลล์ต้องการพื้นที่เพิ่มเติม
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปร่างบนมาสเตอร์และเลเอาต์รวมถึงสไลด์เดี่ยวก่อนบันทึกการนำเสนอที่ปรับขนาด ตัวช่วยของมันจัดการกับแต่ละ [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) โดยปรับสเกลความกว้างของคอลัมน์ด้วย [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) และความสูงขั้นต่ำของแถวด้วย [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) จากนั้นปรับสเกลตำแหน่งของตารางโดยไม่ต้องสเกลขนาดรวมของมันแยกต่างหาก

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // มิติของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // คำนวณอัตราสเกลแนวนอนและแนวตั้งแบบอิสระ.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลเอาต์รวมถึงสไลด์เดี่ยว.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**ทำไมรูปร่างถึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่ได้สเกลรูปร่าง รูปร่างจะรักษาตำแหน่งและขนาดเดิมซึ่งอาจล้นออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปร่างบิดเบี้ยวได้เช่นกัน

**โค้ดที่ให้มาทำงานกับรูปแบบรูปร่างทั้งหมดหรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ตรวจสอบการจัดวางผลลัพธ์ โดยเฉพาะข้อความและตาราง เพราะตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**

ปรับสเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวด้วยอัตราส่วนความสูง จากนั้นสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับมาสเตอร์สไลด์และเลเอาต์สไลด์หรือไม่?**

ใช่ ตัวอย่างที่สองทำการวนผ่าน [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) และ [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) ของแต่ละมาสเตอร์ และใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกมัน

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ใช่ เรียกใช้ [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ค่าปัจจัยสเกลสะท้อนทิศทางสุดท้าย

**มีขีดจำกัดของขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถระบุขนาดสไลด์แบบกำหนดเองได้โดยใช้ [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) ขนาดที่รองรับยังขึ้นอยู่กับรูปแบบการนำเสนอและแอปพลิเคชันที่ใช้เปิดไฟล์ด้วย

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

ใช้ปัจจัยสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้ต้นแบบเดิมพอดีกับมิติสไลด์ใหม่ ให้ใช้สัดส่วนที่เล็กกว่าระหว่างอัตราส่วนความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้จะคงอัตราส่วนเดิมไว้ แต่อาจเหลือพื้นที่ว่างที่ขอบหนึ่ง