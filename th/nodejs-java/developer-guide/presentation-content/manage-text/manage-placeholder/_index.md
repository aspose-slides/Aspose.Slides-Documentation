---
title: จัดการ Placeholder ของงานนำเสนอด้วย JavaScript
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/nodejs-java/manage-placeholder/
keywords:
- ส่วนจัดเก็บตำแหน่ง
- ส่วนข้อความ
- ส่วนรูปภาพ
- ส่วนแผนภูมิ
- ข้อความแจ้งเตือน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการ placeholder ใน Aspose.Slides สำหรับ Node.js ผ่าน Java อย่างง่ายดาย: แทนที่ข้อความ ปรับแต่งข้อความแจ้งเตือน และตั้งค่าความโปร่งใสของรูปภาพใน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ให้คุณจัดการ placeholder ของงานนำเสนอด้วยโปรแกรมได้ บทความนี้อธิบายวิธีค้นหา placeholder บนสไลด์และเปลี่ยนข้อความของมัน ตั้งค่าข้อความแจ้งเตือนแบบกำหนดเองสำหรับ layout ของ placeholder และปรับความโปร่งใสของรูปภาพที่ใช้เป็นพื้นหลังของ placeholder นอกจากนี้ยังมี FAQ สั้น ๆ ที่ชี้แจงความแตกต่างระหว่าง base placeholder กับ local shape อธิบายว่าการเปลี่ยนแปลง placeholder สามารถนำไปใช้ผ่าน layout หรือ master ได้อย่างไร และชี้ไปที่การจัดการ placeholder ของส่วนหัวและส่วนท้าย

## **เปลี่ยนข้อความใน Placeholder**

โดยใช้ [Aspose.Slides สำหรับ Node.js ผ่าน Java](/slides/th/nodejs-java/), คุณสามารถค้นหาและแก้ไข placeholder บนสไลด์ในงานนำเสนอได้ Aspose.Slides ให้คุณทำการเปลี่ยนแปลงข้อความใน placeholder ได้

**Prerequisite**: คุณต้องมีงานนำเสนอที่มี placeholder อยู่ คุณสามารถสร้างงานนำเสนอเช่นนี้ในแอป Microsoft PowerPoint มาตรฐาน

นี่คือวิธีใช้ Aspose.Slides เพื่อแทนที่ข้อความใน placeholder ของงานนำเสนนั้น:

1. สร้างอินสแตนซ์ของคลาส [`Presentation`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) และส่งงานนำเสนอเป็นอาร์กิวเมนต์
2. รับออปเจกต์สไลด์ผ่านดัชนีของมัน
3. วนลูปไผ่าน shapes เพื่อค้นหา placeholder
4. แปลงประเภทของ placeholder shape เป็น [`AutoShape`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) แล้วเปลี่ยนข้อความโดยใช้ [`TextFrame`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame) ที่เชื่อมโยงกับ [`AutoShape`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape)
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงวิธีเปลี่ยนข้อความใน placeholder:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // วนลูปผ่าน shapes เพื่อค้นหา placeholder
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // เปลี่ยนข้อความในแต่ละ placeholder
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าข้อความแจ้งเตือนใน Placeholder**

Layout มาตรฐานและ layout ที่สร้างล่วงหน้ามีข้อความแจ้งเตือนของ placeholder เช่น ***Click to add a title*** หรือ ***Click to add a subtitle*** โดยใช้ Aspose.Slides คุณสามารถแทรกข้อความแจ้งเตือนที่ต้องการลงใน layout ของ placeholder ได้

โค้ด JavaScript นี้แสดงวิธีตั้งค่าข้อความแจ้งเตือนใน placeholder:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // วนลูปผ่านสไลด์
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint แสดง "คลิกเพื่อเพิ่มหัวข้อ"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // เพิ่มคำบรรยาย
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าความโปร่งใสของภาพใน Placeholder**

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสของรูปภาพพื้นหลังใน placeholder ที่เป็นข้อความได้ โดยการปรับความโปร่งใสของรูปในกรอบดังกล่าว คุณสามารถทำให้ข้อความหรือรูปภาพเด่นขึ้น (ขึ้นอยู่กับสีของข้อความและรูปภาพ)

โค้ด JavaScript นี้แสดงวิธีตั้งค่าความโปร่งใสสำหรับรูปภาพพื้นหลัง (ภายใน shape):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**Base placeholder คืออะไร และแตกต่างจาก local shape บนสไลด์อย่างไร?**  
Base placeholder คือ shape ดั้งเดิมบน layout หรือ master ที่ shape บนสไลด์สืบทอดประเภท ตำแหน่ง และการจัดรูปแบบบางส่วนจากมัน ส่วน local shape จะเป็นอิสระ; หากไม่มี base placeholder การสืบทอดจะไม่เกิดขึ้น

**ฉันจะอัปเดตหัวข้อหรือคำบรรยายทั้งหมดในงานนำเสนอโดยไม่ต้องวนลูปทุกสไลด์ได้อย่างไร?**  
แก้ไข placeholder ที่สอดคล้องบน layout หรือ master สไลด์ที่สร้างจาก layout/ master นั้นจะสืบทอดการเปลี่ยนแปลงโดยอัตโนมัติ

**ฉันจะควบคุม placeholder มาตรฐานของส่วนหัว/ส่วนท้าย—วันที่และเวลา, หมายเลขสไลด์, และข้อความส่วนท้ายได้อย่างไร?**  
ใช้ผู้จัดการ HeaderFooter ในระดับที่เหมาะสม (สไลด์ปกติ, layout, master, notes/handouts) เพื่อเปิดหรือปิด placeholder เหล่านั้นและตั้งค่าเนื้อหาได้