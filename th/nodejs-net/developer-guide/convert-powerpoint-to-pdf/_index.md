---
title: แปลง PowerPoint เป็น PDF ใน Node.js ผ่าน .NET
linktitle: PowerPoint เป็น PDF
type: docs
weight: 30
url: /th/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint เป็น PDF
- แปลง PowerPoint เป็น PDF
- PPTX เป็น PDF
- PPT เป็น PDF
- ODP เป็น PDF
- บันทึกการนำเสนอเป็น PDF
- PDF/A
- PdfOptions
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงการนำเสนอ PPTX, PPT และ ODP เป็น PDF ใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ผ่าน .NET และสร้างไฟล์ PDF/A เพื่อการจัดเก็บระยะยาวด้วย PdfOptions."
---
## **ภาพรวม**

Aspose.Slides for Node.js via .NET จะแปลงการนำเสนอ PowerPoint และ OpenDocument เป็น PDF โดยไม่ต้องใช้ Microsoft PowerPoint. ทุกสไลด์ที่มองเห็นได้จะกลายเป็นหนึ่งหน้า PDF ที่มีขนาดเท่ากับสไลด์เดิม และข้อความจะยังคงสามารถเลือกและค้นหาได้. บทความนี้แสดงการแปลงตามค่าเริ่มต้นและการแปลงเป็น PDF/A ด้วย [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/).

ตัวอย่างต้องการไฟล์การนำเสนอชื่อ `sample.pptx` ในโฟลเดอร์โปรเจ็กต์ที่คุณตั้งค่าใน [การติดตั้ง](/slides/th/nodejs-net/installation/). การนำเสนอ PowerPoint ใดก็ได้จะใช้ได้. บันทึกแต่ละตัวอย่างเป็นไฟล์ `.js` ในโฟลเดอร์โปรเจ็กต์และเรียกใช้งานจากโฟลเดอร์นั้นด้วย `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET ไม่มีเอกสารอ้างอิง API ของตนเอง. มันทำสำเนา API ของ Aspose.Slides for .NET ด้วยชื่อแบบ camelCase, ดังนั้นลิงก์ API ในบทความนี้จะชี้ไปยังคลาสและสมาชิกที่ตรงกันใน [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/th/net/).
{{% /alert %}}

## **แปลงการนำเสนอเป็น PDF**

เพื่อแปลงการนำเสนอเป็น PDF, ทำตามขั้นตอนต่อไปนี้:

1. เปิดการนำเสนอโดยส่งพาธของไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/presentation/). โค้ดเดียวกันทำงานกับไฟล์ PPTX, PPT, และ ODP.
2. เรียกใช้เมธอด [save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) พร้อมพาธผลลัพธ์และ `SaveFormat.Pdf`.
3. เรียก `dispose` ในบล็อก `finally` เพื่อปล่อยทรัพยากร .NET ที่รองรับการนำเสนอ.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

สคริปต์จะเขียนไฟล์ `sample.pdf` ลงในโฟลเดอร์โปรเจ็กต์. การแปลงใช้ค่าตั้งต้น: ทุกสไลด์ที่ไม่ได้ซ่อนจะกลายเป็นหน้าในลำดับสไลด์. หากไม่มีไลเซนส์, แต่ละหน้าจะมีลายน้ำการประเมิน; ดูที่ [การให้สิทธิ์](/slides/th/nodejs-net/licensing/).

## **แปลงการนำเสนอเป็น PDF/A**

เพื่อควบคุมผลลัพธ์, ส่งอ็อบเจ็กต์ [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/) เป็นอาร์กิวเมนต์ที่สามของ `save`. ตัวอย่างต่อไปนี้ตั้งค่าคุณสมบัติ [compliance](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/compliance/) เป็น `PdfCompliance.PdfA2b`, ซึ่งจะสร้างไฟล์ PDF/A-2b. PDF/A เป็นมาตรฐาน ISO สำหรับการจัดเก็บระยะยาว: อีกหนึ่งข้อกำหนดคือ ต้องฝังฟอนต์ทั้งหมดที่เอกสารใช้ไว้ในไฟล์.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

สคริปต์จะเขียนไฟล์ `sample-pdfa.pdf` พร้อมหน้าที่เหมือนกับการแปลงตามค่าเริ่มต้น. เพื่อยืนยันว่าไฟล์ตรงตามมาตรฐาน, ตรวจสอบด้วยตัวตรวจสอบ PDF/A อย่างเช่น [veraPDF](https://verapdf.org/). ค่าอื่น ๆ ของ [PdfCompliance](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfcompliance/) จะเลือกมาตรฐานอื่น ๆ เช่น `PdfA1b`, `PdfA2a`, หรือ `PdfUa` สำหรับการเข้าถึงได้.

## **คำถามที่พบบ่อย**

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**

โดยค่าเริ่มต้นสไลด์ที่ซ่อนจะถูกข้าม. ตั้งค่าคุณสมบัติ [showHiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/showhiddenslides/) ของ `PdfOptions` เป็น `true` แล้วส่ง options ไปยัง `save`.

**ฉันสามารถปกป้อง PDF ด้วยรหัสผ่านได้หรือไม่?**

ใช่. ตั้งค่าคุณสมบัติ [password](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/password/) ของ `PdfOptions` ก่อนเรียก `save`. โปรแกรมอ่าน PDF จะขอรหัสผ่านนั้นก่อนเปิดไฟล์.

**ฉันสามารถแปลงเฉพาะบางสไลด์ได้หรือไม่?**

ใช่. ส่งอาร์เรย์ของตำแหน่งสไลด์เป็นอาร์กิวเมนต์ที่สี่ของ `save`. ตำแหน่งเริ่มที่ 1, และอาร์กิวเมนต์ที่สามสามารถเป็น `null` หากไม่ต้องการ options: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` จะสร้าง PDF ที่มีสไลด์แรกและสไลด์ที่สาม.

**ทำไมข้อความถึงแสดงแตกต่างเมื่อแปลงบน Linux?**

Aspose.Slides สามารถใช้ฟอนต์ที่ติดตั้งบนเครื่องที่ทำการแปลงเท่านั้น. เมื่อการนำเสนอใช้ฟอนต์ที่ไม่มีอยู่, เช่น Calibri บนเซิร์ฟเวอร์ Linux ปกติ, Aspose.Slides จะใช้ฟอนต์ที่ติดตั้งแทน ซึ่งอาจทำให้รูปแบบข้อความและการตัดบรรทัดเปลี่ยนแปลง. ให้ติดตั้งฟอนต์ที่การนำเสนอของคุณใช้เพื่อให้ผลลัพธ์เหมือนกับบน Windows.

**ฉันสามารถรับ PDF เป็น Buffer แทนไฟล์ได้หรือไม่?**

ใช่. `presentation.saveToBuffer(SaveFormat.Pdf)` จะคืนค่า PDF เป็น `Buffer` ของ Node.js, ซึ่งสะดวกเมื่อคุณส่งผลลัพธ์ใน HTTP response. เมธอดนี้ยังรับ `PdfOptions` เป็นอาร์กิวเมนต์ที่สองด้วย.