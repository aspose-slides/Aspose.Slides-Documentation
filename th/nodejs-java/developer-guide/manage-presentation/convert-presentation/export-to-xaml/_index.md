---
title: ส่งออกงานนำเสนอเป็น XAML ใน JavaScript
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/nodejs-java/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js—โซลูชันที่เร็วและไม่มี Office ซึ่งรักษาการจัดวางของคุณไว้ครบถ้วน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML ด้วย Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML การแสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าปริยาย และสาธิตการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามที่พบบ่อยบางประการเกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML คือภาษาการเขียนโปรแกรมเชิงอธิบายที่ช่วยให้คุณสร้างหรือเขียนคลาสผู้ใช้สำหรับแอปพลิเคชัน โดยเฉพาะแอปที่ใช้ WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin forms.

XAML ซึ่งเป็นภาษาที่อิงจาก XML เป็นรูปแบบของ Microsoft สำหรับการอธิบาย GUI คุณอาจใช้เครื่องมือออกแบบเพื่อทำงานกับไฟล์ XAML ส่วนใหญ่ของเวลา แต่คุณยังสามารถเขียนและแก้ไข GUI ของคุณได้

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกค่าเริ่มต้น**

โค้ด JavaScript นี้แสดงให้คุณเห็นวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าปริยาย:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

คุณสามารถเลือกตัวเลือกจากคลาส [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/XamlOptions) เพื่อควบคุมกระบวนการส่งออกและกำหนดว่า Aspose.Slides จะส่งออกงานนำเสนอของคุณเป็น XAML อย่างไร

ตัวอย่างเช่น หากคุณต้องการให้ Aspose.Slides เพิ่มสไลด์ที่ซ่อนอยู่จากงานนำเสนอของคุณเมื่อส่งออกเป็น XAML คุณสามารถตั้งค่าบิษัท [setExportHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) ให้เป็น true ดูตัวอย่างโค้ด JavaScript นี้:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะรับประกันฟอนต์ที่คาดการณ์ได้อย่างไรหากฟอนต์ดั้งเดิมไม่มีในเครื่อง?**

ให้ใช้ [setDefaultRegularFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/) — จะใช้เป็นฟอนต์สำรองเมื่อฟอนต์ดั้งเดิมไม่มีอยู่ ซึ่งช่วยหลีกเลี่ยงการแทนที่ที่ไม่คาดคิด

**XAML ที่ส่งออกออกแบบมาเพื่อใช้กับ WPF เท่านั้นหรือสามารถใช้ในสแตก XAML อื่น ๆ ได้ด้วยหรือไม่?**

XAML เป็นภาษามาร์กอัป UI แบบทั่วไปที่ใช้ใน WPF, UWP และ Xamarin.Forms การส่งออกมุ่งเน้นความเข้ากันได้กับสแตก XAML ของ Microsoft; พฤติกรรมที่แน่นอนและการสนับสนุนโครงสร้างเฉพาะขึ้นอยู่กับแพลตฟอร์มเป้าหมาย ควรทดสอบมาร์กอัปในสภาพแวดล้อมของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้มันถูกส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนอยู่จะไม่รวมอยู่ คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) ใน [XamlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/xamloptions/) — ปิดการใช้งานหากคุณไม่จำเป็นต้องส่งออกสไลด์เหล่านั้น.