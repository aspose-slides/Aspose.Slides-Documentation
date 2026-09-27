---
title: สร้างงานนำเสนอใน JavaScript
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/nodejs-java/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างงานนำเสนอด้วย Aspose.Slides — ผลิตไฟล์ PPT, PPTX และ ODP, รับประโยชน์จากการสนับสนุน OpenDocument, และบันทึกแบบโปรแกรมเพื่อผลลัพธ์ที่น่าเชื่อถือ."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอใน Aspose.Slides, เพิ่มกล่องข้อความในสไลด์แรกของมัน, และบันทึกผลลัพธ์เป็นไฟล์.

ก่อนเริ่ม, ให้ติดตั้งแพ็กเกจ `aspose.slides.via.java` จาก npm พร้อมกับ JDK, Python, และเครื่องมือการสร้าง C++ ที่จำเป็น. ดูที่ [Installation](/slides/th/nodejs-java/installation/).

## **สร้างงานนำเสนอ PowerPoint**

เพื่อสร้างงานนำเสนอและใส่กล่องข้อความบนสไลด์แรก, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) . งานนำเสนอใหม่จะมีสไลด์ว่างหนึ่งสไลด์อยู่แล้ว.
2. ดึงสไลด์นั้นจาก [slide collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslides/) ตามดัชนีของมัน, 0.
3. เพิ่มรูปสี่เหลี่ยมโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/addautoshape/) แล้วตั้งค่าข้อความด้วย [setText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/settext/).
4. บันทึกงานนำเสนอเป็นไฟล์ PPTX ด้วยเมธอด [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/save/).
5. ปลดปล่อยงานนำเสนอด้วยเมธอด [dispose](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/dispose/), และสิ้นสุดกระบวนการ.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides ทำงานในเครื่องเสมือน Java ที่ทำให้ Node.js ทำงานต่อ, ดังนั้นจึงต้องสิ้นสุดกระบวนการอย่างชัดเจน.
process.exit(0);
```

มุมซ้ายบนของสี่เหลี่ยมอยู่ห่างจากขอบซ้ายของสไลด์ 50 จุดและจากขอบบน 50 จุด, และสี่เหลี่ยมมีความกว้าง 400 จุดและความสูง 100 จุด. บันทึกโค้ดเป็น *hello.js* ในโฟลเดอร์โปรเจกต์ของคุณและรัน `node hello.js`: จะบันทึก *hello.pptx* ที่มีสไลด์หนึ่งสไลด์ที่บรรจุสี่เหลี่ยมและข้อความไว้ในโฟลเดอร์ปัจจุบัน.

Aspose.Slides ทำงานในเครื่องเสมือน Java ที่แพ็กเกจ `java` เริ่มต้นภายในกระบวนการ Node.js. เครื่องเสมือนนั้นทำให้ Node.js ไม่ออกจากการทำงานโดยอัตโนมัติหลังจากสคริปต์ทำงานเสร็จ, ดังนั้นตัวอย่างจบด้วย `process.exit(0)`.

หากไม่มีไลเซนส์, Aspose.Slides จะเพิ่มลายน้ำการประเมินผลลงในทุกสไลด์ที่บันทึก; ดูที่ [Licensing](/slides/th/nodejs-java/licensing/).

## **คำถามที่พบบ่อย**

### ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?

คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/nodejs-java/save-presentation/) และส่งออกเป็น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/th/nodejs-java/render-a-slide-as-an-svg-image/), และ [images](/slides/th/nodejs-java/convert-powerpoint-to-png/), รวมถึงอื่น ๆ.

### ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?

ใช่. โหลดเทมเพลตแล้วบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [are supported](/slides/th/nodejs-java/supported-file-formats/).

### ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานนำเสนออย่างไร?

ตั้งค่า [slide size](/slides/th/nodejs-java/slide-size/) (รวมถึงพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกว่าข้อมูลควรปรับขนาดอย่างไร.

### หน่วยที่ใช้วัดขนาดและพิกัดคืออะไร?

เป็นหน่วยจุด: 1 นิ้วเท่ากับ 72 หน่วย.

### ฉันจะจัดการกับงานนำเสนอขนาดใหญ่มาก (มีไฟล์สื่อหลายไฟล์) เพื่อทำให้การใช้หน่วยความจำน้อยลงอย่างไร?

ใช้ [BLOB management strategies](/slides/th/nodejs-java/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และเลือกใช้เวิร์กโฟลว์แบบไฟล์เป็นหลักแทนสตรีมที่เก็บในหน่วยความจำเท่านั้น.

### ฉันสามารถสร้าง/บันทึกงานนำเสนอแบบขนานได้หรือไม่?

คุณไม่สามารถทำงานกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เดียวกันจาก [multiple threads](/slides/th/nodejs-java/multithreading/) ได้. ให้เรียกใช้อินสแตนซ์แยกกันและแยกจากกันต่อแต่ละเธรดหรือกระบวนการ.

### ฉันจะลบลายน้ำทดลองและข้อจำกัดออกได้อย่างไร?

[Apply a license](/slides/th/nodejs-java/licensing/) หนึ่งครั้งต่อกระบวนการ. XML ของไลเซนส์ต้องไม่มีการแก้ไข, และการตั้งค่าไลเซนส์ควรทำให้สอดคล้องกันหากมีหลายเธรด.

### ฉันสามารถลงนิติฐานดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?

ใช่. [Digital signatures](/slides/th/nodejs-java/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) ถูกสนับสนุนสำหรับงานนำเสนอ.

### แมโคร (VBA) ได้รับการสนับสนุนในงานนำเสนอที่สร้างหรือไม่?

ใช่. คุณสามารถ [create/edit VBA projects](/slides/th/nodejs-java/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานแมโครเช่น PPTM/PPSM.