---
title: ส่งออกงานนำเสนอเป็น XAML ด้วย Java
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/java/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint ไปเป็น XAML
- OpenDocument ไปเป็น XAML
- งานนำเสนอไปเป็น XAML
- PPT ไปเป็น XAML
- PPTX ไปเป็น XAML
- ODP ไปเป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ด้วย Java โดยใช้ Aspose.Slides—โซลูชันที่รวดเร็ว ปราศจาก Office และคงรักษาโครงร่างของคุณให้สมบูรณ์"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML ด้วย Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีการบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าปริยาย และสาธิตวิธีการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับแบบอักษรสำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อน

## **เกี่ยวกับ XAML**

XAML เป็นภาษาการเขียนโปรแกรมเชิงพรรณนา ที่ช่วยให้คุณสร้างหรือเขียนส่วนติดต่อผู้ใช้สำหรับแอป โดยเฉพาะแอปที่ใช้ WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin Forms  

XAML ซึ่งเป็นภาษาที่อิงจาก XML เป็นเวอร์ชันของ Microsoft สำหรับอธิบาย GUI คุณมักจะใช้ Designer เพื่อทำงานกับไฟล์ XAML ส่วนใหญ่ของเวลา แต่คุณก็ยังสามารถเขียนและแก้ไข GUI ของคุณได้

## **ส่งออกงานนำเสนอไปเป็น XAML ด้วยตัวเลือกค่าเริ่มต้น**

โค้ด Java นี้แสดงวิธีการส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าปริยาย:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **ส่งออกงานนำเสนอไปเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

คุณสามารถเลือกตัวเลือกจากอินเทอร์เฟซ [IXamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/IXamlOptions) ที่ควบคุมกระบวนการส่งออกและกำหนดวิธีที่ Aspose.Slides ส่งออกงานนำเสนอของคุณเป็น XAML  

ตัวอย่างเช่น หากคุณต้องการให้ Aspose.Slides เพิ่มสไลด์ที่ซ่อนอยู่จากงานนำเสนอของคุณเมื่อส่งออกเป็น XAML คุณสามารถตั้งค่า property [ExportHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) เป็น true ได้ ดูตัวอย่างโค้ด Java นี้:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทำให้แน่ใจว่าแบบอักษรจะคาดเดาได้อย่างไร หากแบบอักษรต้นแบบไม่มีบนเครื่อง?**  

ตั้งค่า [a default regular font](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ใน [XamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/) — จะใช้เป็นแบบอักษรสำรองเมื่อแบบอักษรต้นแบบไม่พบ วิธีนี้ช่วยหลีกเลี่ยงการแทนที่ที่ไม่คาดคิด  

**XAML ที่ส่งออกออกมานี้มีเจตนาใช้เฉพาะกับ WPF เท่านั้น หรือสามารถใช้ในสแตก XAML อื่นได้ด้วยหรือไม่?**  

XAML เป็นภาษามาร์กอัป UI ทั่วไปที่ใช้ใน WPF, UWP และ Xamarin.Forms การส่งออกมุ่งเน้นความเข้ากันได้กับสแตก XAML ของ Microsoft พฤติกรรมที่แน่นอนและการสนับสนุนโครงสร้างเฉพาะขึ้นอยู่กับแพลตฟอร์มเป้าหมาย ควรทดสอบมาร์กอัปในสภาพแวดล้อมของคุณ  

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้ถูกส่งออกโดยค่าเริ่มต้นได้อย่างไร?**  

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกรวมไว้ คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ใน [XamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/) — ปิดใช้งานหากคุณไม่ต้องการส่งออกสไลด์เหล่านั้น