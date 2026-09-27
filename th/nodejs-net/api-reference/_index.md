---
title: เอกสารอ้างอิง API
type: docs
weight: 50
url: /th/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET ถูกบันทึกในเอกสารอ้างอิง API ของ Aspose.Slides for .NET. ดูว่าชื่อคลาสและสมาชิกของ .NET ถูกแมปเป็น JavaScript อย่างไร."
---
## **ภาพรวม**

Aspose.Slides for Node.js via .NET ไม่มีเอกสารอ้างอิง API ของตัวเอง แพ็กเกจนี้เปิดเผยคลาสของ Aspose.Slides for .NET ให้กับ JavaScript ด้วยชื่อเดียวกัน แต่สมาชิกใช้รูปแบบ camelCase ดังนั้น[Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/th/net/) จะอธิบายคลาส สมาชิก และ enumeration ของมัน

## **แปลงชื่อ .NET เป็น JavaScript**

เพื่อใช้สมาชิกที่คุณพบในเอกสารอ้างอิง API ของ .NET ให้ใช้กฎเหล่านี้:

- **คลาสและ enumeration จะคงชื่อ .NET ไว้** เช่นเดียวกับค่า enumeration: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf` นำเข้าพวกมันจากแพ็กเกจ: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **คุณสมบัติและเมธอดจะเริ่มด้วยตัวอักษรเล็ก** `Presentation.Slides` กลายเป็น `presentation.slides` และ `ShapeCollection.AddAutoShape` กลายเป็น `shapes.addAutoShape` คุณสมบัติคงเป็นคุณสมบัติ: อ่านและตั้งค่าได้โดยไม่ต้องใส่วงเล็บ
- **รายการในคอลเลคชันอ่านด้วย `get(index)`** และจำนวนรายการด้วย `count`: `presentation.slides.get(0)` แทน `presentation.Slides[0]`
- **บาง overload จะได้รับชื่อแยกกัน** ตัวอย่างเช่น overload `Slide.GetImage(Size)` จะเป็น `slide.getImageWithImageSize({ width, height })` ส่วนอื่นๆ ใช้เมธอดเดียวกับอาร์กิวเมนต์เพิ่มเติมแบบออปชัน: `presentation.save(path, format, options, slides)` ครอบคลุมหลาย overload ของ `Presentation.Save` และ `new Presentation(null, buffer)` เปิดไฟล์นำเสนอจาก `Buffer` แต่ละคลาสอยู่ในไฟล์เดียวภายใต้โฟลเดอร์ `lib` ของแพ็กเกจ (เช่น `node_modules/aspose.slides.via.net/lib/Slide.js`) ที่คุณสามารถค้นหาชื่อที่ถูกต้องได้
- **ปล่อยการนำเสนอด้วย `dispose`** เมื่อใช้งานเสร็จ; JavaScript ไม่มีคำสั่ง `using`

แพ็กเกจนี้ไม่ได้ห่อหุ้มทุกสมาชิกของ .NET หากสมาชิกใดจากเอกสารอ้างอิง API ของ .NET หายจากไฟล์คลาส จะไม่สามารถใช้ได้ใน JavaScript

## **ตัวอย่าง**

สคริปต์ต่อไปนี้ใช้กฎข้างต้น คอมเมนต์แต่ละบรรทัดแสดงการเรียก .NET ที่บรรทัดถัดไปสอดคล้องกัน มันจะเพิ่มสี่เหลี่ยมผืนผ้าพร้อมข้อความลงในสไลด์แรก เรนเดอร์สไลด์เป็นภาพ PNG ขนาด 960 × 540 พิกเซล และบันทึกการนำเสนอเป็น PDF เรียกใช้จากโฟลเดอร์โครงการที่ติดตั้งแพ็กเกจตามที่อธิบายใน[Installation](/slides/th/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

สคริปต์จะเขียนไฟล์ `slide.png` และ `slide.pdf` ไปยังโฟลเดอร์ปัจจุบัน ทั้งสองไฟล์จะแสดงสี่เหลี่ยมผืนผ้าพร้อมข้อความ หากไม่มีลิขสิทธิ์ จะมีสลับน้ำประดับการประเมิน; ดูที่[Licensing](/slides/th/nodejs-net/licensing/).

สำหรับรายละเอียดของสมาชิกที่ใช้ในที่นี้ ดูที่[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/text/) และ[Slide.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage/) ในเอกสารอ้างอิง API ของ Aspose.Slides for .NET