---
title: ส่งออกการนำเสนอเป็น XAML บน Android
linktitle: การนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/androidjava/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกการนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- การนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ด้วย Java โดยใช้ Aspose.Slides สำหรับ Android—โซลูชันที่รวดเร็ว ปราศจาก Office ที่คงรูปแบบการจัดวางของคุณไว้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกรายการนำเสนอ PowerPoint ไปเป็น XAML โดยใช้ Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML การแสดงวิธีบันทึกรายการนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษาการเขียนโปรแกรมเชิงอธิบายที่ช่วยให้คุณสร้างหรือเขียนส่วนติดต่อผู้ใช้สำหรับแอปพลิเคชัน โดยเฉพาะที่ใช้ WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin Forms  

XAML ซึ่งเป็นภาษาที่อิงจาก XML เป็นรูปแบบของ Microsoft สำหรับอธิบาย GUI คุณมักจะใช้เครื่องมือออกแบบในการทำงานกับไฟล์ XAML ส่วนใหญ่ แต่คุณก็ยังสามารถเขียนและแก้ไข GUI ของคุณได้เช่นกัน

## **ส่งออกการนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

โค้ด Java นี้แสดงวิธีการส่งออกการนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **ส่งออกการนำเสนอเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

คุณสามารถเลือกตัวเลือกจากอินเตอร์เฟส [IXamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IXamlOptions) เพื่อควบคุมกระบวนการส่งออกและกำหนดว่ Aspose.Slides จะส่งออกการนำเสนอของคุณเป็น XAML อย่างไร

ตัวอย่างเช่น หากคุณต้องการให้ Aspose.Slides เพิ่มสไลด์ที่ซ่อนอยู่จากการนำเสนอของคุณเมื่อส่งออกเป็น XAML คุณสามารถตั้งค่าคุณสมบัติ [ExportHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) เป็น true ดูโค้ด Java ตัวอย่างนี้:

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

## **FAQ**

**ฉันจะทำให้ฟอนต์คาดเดาได้อย่างไรหากฟอนต์เดิมไม่มีอยู่ในระบบ?**

ตั้งค่า [ฟอนต์ปกติเริ่มต้น](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ใน [XamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/) — จะถูกใช้เป็นฟอนต์สำรองเมื่อฟอนต์เดิมหายไป ซึ่งช่วยป้องกันการแทนที่ที่ไม่คาดคิด

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้ได้กับสแตก XAML อื่น ๆ ด้วย?**

XAML เป็นภาษามาร์กอัป UI ทั่วไปที่ใช้ใน WPF, UWP, และ Xamarin.Forms การส่งออกมุ่งเน้นความเข้ากันได้กับสแตก XAML ของ Microsoft; พฤติกรรมและการสนับสนุนสำหรับโครงสร้างเฉพาะจะขึ้นอยู่กับแพลตฟอร์มเป้าหมาย ทดสอบมาร์กอัปในสภาพแวดล้อมของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้ส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกรวมไว้ คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ใน [XamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/) — ปิดการใช้งานหากไม่ต้องการส่งออกสไลด์เหล่านี้