---
title: แปลงสไลด์พรีเซนเทชันเป็นภาพใน Node.js via .NET
linktitle: สไลด์เป็นภาพ
type: docs
weight: 40
url: /th/nodejs-net/convert-slide/
keywords:
- แปลงสไลด์
- สไลด์เป็นภาพ
- สไลด์เป็น PNG
- บันทึกสไลด์เป็นภาพ
- เรนเดอร์สไลด์
- รูปย่อสไลด์
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "เรนเดอร์สไลด์จากพรีเซนเทชัน PPTX, PPT, และ ODP เป็นภาพ PNG ใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js via .NET โดยใช้ตัวคูณสเกลหรือขนาดที่กำหนดเป็นพิกเซลอย่างแม่นยำ"
---
## **ภาพรวม**

Aspose.Slides for Node.js via .NET เรนเดอร์สไลด์จากพรีเซนเทชัน PowerPoint และ OpenDocument เป็นรูปภาพ เช่น เพื่อแสดงตัวอย่างสไลด์บนหน้าเว็บ บทความนี้แสดงสองวิธีในการเลือกขนาดรูปภาพ: ตัวคูณสเกลสัมพันธ์กับขนาดสไลด์ และขนาดที่กำหนดเป็นพิกเซล ทั้งสองตัวอย่างจะบันทึกไฟล์ PNG

ตัวอย่างคาดว่าจะมีพรีเซนเทชันชื่อ `sample.pptx` ในโฟลเดอร์โปรเจกต์ที่คุณตั้งค่าไว้ใน [Installation](/slides/th/nodejs-net/installation/). พรีเซนเทชัน PowerPoint ใดก็ได้สามารถใช้ได้ บันทึกแต่ละตัวอย่างเป็นไฟล์ `.js` ในโฟลเดอร์โปรเจกต์และเรียกใช้จากโฟลเดอร์นั้นด้วย `node`

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET ไม่มี API reference ของตัวเอง มันเป็นการสะท้อน API ของ Aspose.Slides for .NET ด้วยชื่อแบบ camelCase ดังนั้นลิงก์ API ในบทความนี้จะนำไปสู่คลาสและสมาชิกที่สอดคล้องกันใน [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. เปิดพรีเซนเทชันด้วยคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)
2. ดึงสไลด์จากคอลเลกชัน [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) ด้วย `get(index)` โดยดัชนีเริ่มที่ 0
3. เรนเดอร์สไลด์ด้วย `getImageWithScale` หรือ `getImageWithImageSize` ในเอกสารอ้างอิง .NET API ทั้งสองเป็น overload ของ [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) พวกมันจะคืนออบเจ็กต์รูปภาพที่สอดคล้องกับ [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)
4. บันทึกภาพด้วยเมธอด [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) และค่า [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) จากนั้นเรียกเมธอด `dispose`

## **แปลงทุกสไลด์เป็นภาพ PNG**

`getImageWithScale` รับตัวคูณสเกลตามแนวนอนและแนวตั้ง ที่สเกล 1 หนึ่งจุดของสไลด์จะเท่ากับหนึ่งพิกเซลของภาพ ตัวอย่างต่อไปนี้เรนเดอร์ทุกสไลด์ที่สเกล 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// สเกล 1 จะเรนเดอร์หนึ่งพิกเซลต่อจุด; สเกล 2 จะเพิ่มความกว้างและความสูงเป็นสองเท่า.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

สคริปต์จะเขียนไฟล์หนึ่งไฟล์ต่อสไลด์ เช่น `slide_1.png`, `slide_2.png` เป็นต้น เริ่มนับจาก 1 สำหรับพรีเซนเทชันอัตราส่วน 16:9 ที่มีสไลด์ขนาด 960 × 540 จุด ภาพแต่ละภาพจะเป็น 1920 × 1080 พิกเซล สไลด์ที่ซ่อนก็จะถูกเรนเดอร์เช่นกัน; หากต้องการข้ามสไลด์ที่ซ่อน ให้ตรวจสอบคุณสมบัติ [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) ของสไลด์ แต่ละภาพจะถูกทำลายในบล็อก `finally` ของมันเอง ซึ่งทำให้ปล่อยทรัพยากรก่อนสไลด์ต่อไปจะถูกเรนเดอร์ หากไม่มีลิขสิทธิ์ ภาพจะมีลายน้ำการประเมินผล; ดูที่ [Licensing](/slides/th/nodejs-net/licensing/)

## **แปลงสไลด์เป็นภาพขนาดที่กำหนด**

`getImageWithImageSize` รับออบเจ็กต์ที่มี `width` และ `height` เป็นพิกเซล ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกให้กว้าง 1280 พิกเซลและคำนวณความสูงจากขนาดสไลด์ เพื่อให้ภาพคงอัตราส่วนของสไลด์:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

คุณสมบัติ [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) คืนค่าความกว้างและความสูงของสไลด์เป็นจุด สำหรับพรีเซนเทชันอัตราส่วน 16:9 สคริปต์จะแสดง `Saved a 1280 x 720 image` และเขียนไฟล์ `slide_1_1280px.png`; สำหรับพรีเซนเทชันอัตราส่วน 4:3 ภาพจะเป็น 1280 × 960 พิกเซล

## **คำถามที่พบบ่อย**

**ทำไมภาพที่ได้จาก `getImage` โดยไม่มีอาร์กิวเมนต์จึงมีขนาดเล็กขนาดนั้น?**

หากไม่ระบุอาร์กิวเมนต์ `getImage` จะเรนเดอร์สไลด์ที่ 20% ของขนาดในจุด ดังนั้นสไลด์ขนาด 960 × 540 จุดจะกลายเป็นภาพขนาด 192 × 108 พิกเซล ให้ใช้ `getImageWithScale` หรือ `getImageWithImageSize` เพื่อเลือกขนาด

**ฉันจะบันทึกเป็น JPEG หรือรูปแบบภาพอื่นได้อย่างไร?**

ส่งค่า `ImageFormat` ตัวอื่นไปยังเมธอด `save` ของภาพ เช่น `image.save("slide_1.jpg", ImageFormat.Jpeg)` รูปแบบจะมาจากค่าของ `ImageFormat` ไม่ได้มาจากนามสกุลไฟล์ ดังนั้นควรทำให้สองอย่างสอดคล้องกัน

**ทำไมข้อความในภาพถึงแสดงต่างกันบน Linux?**

Aspose.Slides สามารถใช้ฟอนต์ที่ติดตั้งบนเครื่องที่ทำการเรนเดอร์สไลด์เท่านั้น หากพรีเซนเทชันใช้ฟอนต์ที่ไม่มีบนเครื่องเช่น Calibri บนเซิร์ฟเวอร์ Linux ปกติ Aspose.Slides จะใช้ฟอนต์ที่ติดตั้งแทน ซึ่งอาจทำให้ลักษณะของข้อความและการตัดบรรทัดเปลี่ยนไป ให้ติดตั้งฟอนต์ที่พรีเซนเทชันของคุณใช้เพื่อให้ได้ภาพเหมือนกับบน Windows

**ทำไม `getThumbnailWithImageSize` ถึงล้มเหลวด้วย TypeError?**

เอกสาร README ของแพคเกจใช้ `getThumbnailWithImageSize` แต่แพคเกจไม่มีเมธอด `getThumbnail` ให้ใช้ `getImageWithImageSize` แทน; มันรับอาร์กิวเมนต์ `{ width, height }` แบบเดียวกัน