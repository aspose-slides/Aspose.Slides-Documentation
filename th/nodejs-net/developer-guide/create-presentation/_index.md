---
title: สร้างงานนำเสนอใน Node.js ผ่าน .NET
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/nodejs-net/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PowerPoint
- สร้าง PPTX
- เพิ่มกล่องข้อความ
- เพิ่มสไลด์
- ขนาดสไลด์
- หน้าจอกว้าง
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างงานนำเสนอ PowerPoint ด้วย JavaScript บน Aspose.Slides สำหรับ Node.js ผ่าน .NET: เพิ่มกล่องข้อความและสไลด์ ตั้งขนาดสไลด์ 16:9 และบันทึกผลลัพธ์เป็น PPTX."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน .NET, เพิ่มกล่องข้อความในสไลด์แรก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX. นอกจากนี้ยังแสดงวิธีเพิ่มสไลด์เพิ่มเติมและวิธีสลับงานนำเสนอเป็นสไลด์แบบ widescreen (16:9).

ตัวอย่างต้องใช้โครงการที่ตั้งค่าไว้ตามที่อธิบายใน [การติดตั้ง](/slides/th/nodejs-net/installation/). บันทึกแต่ละตัวอย่างเป็นไฟล์ `.js` ในโฟลเดอร์โครงการและเรียกใช้จากโฟลเดอร์นั้นด้วย `node`, ตัวอย่างเช่น `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides สำหรับ Node.js ผ่าน .NET ไม่มีเอกสารอ้างอิง API ของตัวเอง มันทำการสะท้อน API ของ Aspose.Slides สำหรับ .NET โดยใช้ชื่อแบบ camelCase ดังนั้นลิงก์ API ในบทความนี้จะนำไปสู่คลาสและสมาชิกที่ตรงกันใน [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/th/net/).
{{% /alert %}}

## **สร้างงานนำเสนอพร้อมกล่องข้อความ**

เพื่อสร้างงานนำเสนอและใส่กล่องข้อความบนสไลด์แรก ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คลาสใหม่จะมีสไลด์ว่างหนึ่งสไลด์อยู่แล้ว.
2. รับสไลด์นั้นจากคอลเลกชัน [slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) คอลเลกชันนี้อ่านด้วย `get(index)` และดัชนีเริ่มจาก 0.
3. เพิ่มสี่เหลี่ยมด้วยเมธอด [addAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/shapecollection/addautoshape/) และตั้งค่า [text](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/text/) ของ [textFrame](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/textframe/).
4. บันทึกงานนำเสนอด้วยเมธอด [save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) และค่า `SaveFormat.Pptx`.
5. เรียก `dispose` ในบล็อค `finally` เพื่อปล่อยทรัพยากร .NET ที่สนับสนุนงานนำเสนอ.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // ตำแหน่ง (x, y) และขนาด (width, height) อยู่ในหน่วยจุด.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

สคริปต์จะเขียนไฟล์ `new-presentation.pptx` ไปยังโฟลเดอร์โครงการ ไฟล์นี้มีสไลด์หนึ่งสไลด์ที่มีสี่เหลี่ยมเติมสีโดยมุมซ้ายบนห่างจากขอบซ้ายและบนของสไลด์ 50 จุด สี่เหลี่ยมมีความกว้าง 400 จุดและความสูง 100 จุด และข้อความของมันถูกจัดกึ่งกลาง จุดหนึ่งเท่ากับ 1/72 นิ้ว หากไม่มีไลเซนส์ Aspose.Slides จะเพิ่มลายน้ำการประเมินผลบนสไลด์; ดูที่ [Licensing](/slides/th/nodejs-net/licensing/).

## **เพิ่มสไลด์**

งานนำเสนอใหม่มีสไลด์หนึ่งสไลด์ หากต้องการเพิ่มสไลด์เพิ่มเติม ให้ส่งสไลด์เลเอาต์ไปยังเมธอด [addEmptySlide](https://reference.aspose.com/slides/th/net/aspose.slides/slidecollection/addemptyslide/) ของคอลเลกชัน `slides`. เมธอด [getByType](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslidecollection/getbytype/) ของคอลเลกชัน [layoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/layoutslides/) จะคืนค่าเลเอาต์แรกของ [SlideLayoutType](https://reference.aspose.com/slides/th/net/aspose.slides/slidelayouttype/) ที่กำหนด.

ตัวอย่างต่อไปนี้จะเพิ่มสไลด์สองสไลด์โดยใช้เลเอาต์ Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สคริปต์พิมพ์ `Slide count: 3` และเขียนไฟล์ `three-slides.pptx`. สไลด์ใหม่จะถูกเพิ่มต่อหลังจากสไลด์แรกและไม่มีรูปร่างใด ๆ งานนำเสนอใหม่จะมีเลเอาต์ Blank เสมอ แต่หากเปิดงานนำเสนอจากไฟล์อาจไม่มีเลเอาต์ประเภทที่ต้องการ; ในกรณีนั้น `getByType` จะคืนค่า `null` ดังนั้นควรตรวจสอบผลลัพธ์ก่อนนำไปใช้ต่อ.

## **ตั้งค่าขนาดสไลด์**

งานนำเสนอใหม่ใช้สไลด์ขนาด 4:3 ที่มีขนาด 720 × 540 จุด (10 × 7.5 นิ้ว). หากต้องการสร้างสไลด์ widescreen แทน ให้เรียกเมธอด [setSize](https://reference.aspose.com/slides/th/net/aspose.slides/slidesize/setsize/) ของ [slideSize](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slidesize/) ของงานนำเสนอพร้อมค่าประเภท [SlideSizeType](https://reference.aspose.com/slides/th/net/aspose.slides/slidesizetype/) และค่าประเภท [SlideSizeScaleType](https://reference.aspose.com/slides/th/net/aspose.slides/slidesizescaletype/). ประเภทสเกลบอกให้ Aspose.Slides ทำอย่างไรกับรูปร่างที่อยู่บนสไลด์แล้ว; `DoNotScale` จะคงรูปแบบเดิม ซึ่งเป็นตัวเลือกที่ถูกต้องสำหรับงานนำเสนอที่ยังไม่มีเนื้อหา.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สคริปต์พิมพ์ `Slide size: 960 x 540 points` ซึ่งเท่ากับ 13.33 × 7.5 นิ้ว และเขียนไฟล์ `widescreen.pptx`. `SlideSizeType.OnScreen16x9` มีอัตราส่วน 16:9 เหมือนกันแต่ขนาดเล็กกว่า: 720 × 405 จุด.

## **คำถามที่พบบ่อย**

**ตำหนหน่วยที่ใช้วัดตำแหน่งและขนาดคืออะไร?**

เป็นจุด (points) หนึ่งนิ้วเท่ากับ 72 จุด ดังนั้นสไลด์ 4:3 เริ่มต้นคือ 720 × 540 จุด และสไลด์ widescreen 16:9 คือ 960 × 540 จุด.

**ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

ค่าที่ใดก็ได้จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/), ตัวอย่างเช่น `SaveFormat.Ppt` สำหรับ PowerPoint 97–2003, `SaveFormat.Odp` สำหรับ OpenDocument, หรือ `SaveFormat.Pdf`. สำหรับการส่งออกเป็น PDF ดูที่ [Convert PowerPoint to PDF](/slides/th/nodejs-net/convert-powerpoint-to-pdf/).

**ทำไมงานนำเสนอที่บันทึกจึงมีข้อความ "Evaluation only"?**

หากไม่มีไลเซนส์ Aspose.Slides จะเพิ่มลายน้ำการประเมินผลในสไลด์ที่บันทึก ใช้ไลเซนส์ตามที่อธิบายใน [Licensing](/slides/th/nodejs-net/licensing/) เพื่อเอาออก.

**ทำไมฉันควรเรียก `dispose`?**

`Presentation` เป็นอ็อบเจกต์ที่อ้างอิงจากอ็อบเจกต์ .NET ที่เก็บหน่วยความจำและทรัพยากรอื่น ๆ การเรียก `dispose` จะปล่อยทรัพยากรเหล่านั้นทันทีที่คุณไม่ต้องการงานนำเสนออีกต่อไป และการเรียกในบล็อค `finally` จะปล่อยทรัพยากรแม้เกิดข้อผิดพลาด.