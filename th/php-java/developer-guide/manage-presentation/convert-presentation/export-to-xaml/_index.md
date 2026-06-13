---
title: ส่งออกงานนำเสนอเป็น XAML ใน PHP
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — โซลูชันรวดเร็ว ไม่ต้องใช้ Office ที่คงรูปแบบของคุณไว้ครบถ้วน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML โดยใช้ Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้นและสาธิตวิธีปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปหลายข้อที่เกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML คือภาษาโปรแกรมเชิงพรรณนาที่ช่วยให้คุณสร้างหรือเขียนส่วนติดต่อผู้ใช้สำหรับแอปพลิเคชัน โดยเฉพาะแอปที่ใช้ WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin Forms  

XAML ซึ่งเป็นภาษาที่อิงจาก XML เป็นรูปแบบของ Microsoft สำหรับอธิบาย GUI คุณอาจใช้ Designer เพื่อทำงานกับไฟล์ XAML ส่วนใหญ่ แต่คุณก็สามารถเขียนและแก้ไข GUI ด้วยตนเองได้เช่นกัน

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

โค้ด PHP นี้แสดงวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

คุณสามารถเลือกตัวเลือกจากคลาส [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/) ที่ควบคุมกระบวนการส่งออกและกำหนดว่า Aspose.Slides จะส่งออกงานนำเสนอของคุณเป็น XAML อย่างไร  

ตัวอย่างเช่น หากคุณต้องการให้ Aspose.Slides เพิ่มสไลด์ที่ซ่อนอยู่จากงานนำเสนอของคุณขณะส่งออกเป็น XAML คุณสามารถใช้เมธอด [setExportHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/setexporthiddenslides/) พร้อมค่ `true` ดูโค้ด PHP ตัวอย่างนี้:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันจะรับรองฟอนต์ที่คาดเดาได้ได้อย่างไรหากฟอนต์ต้นฉบับไม่พร้อมใช้งานบนเครื่อง?**

ตั้งค่า [ฟอนต์ปกติเริ่มต้น](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/) — จะถูกใช้เป็นฟอนต์สำรองเมื่อฟอนต์ต้นฉบับไม่มีอยู่ ช่วยหลีกเลี่ยงการทดแทนที่ไม่คาดคิด

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้ในสแตก XAML อื่นได้ด้วย?**

XAML เป็นภาษามาร์คอัป UI แบบทั่วไปที่ใช้ใน WPF, UWP และ Xamarin.Forms การส่งออกมุ่งเน้นความเข้ากันได้กับสแตก XAML ของ Microsoft; พฤติกรรมที่แน่นอนและการสนับสนุนโครงสร้างเฉพาะขึ้นอยู่กับแพลตฟอร์มเป้าหมาย ให้ทดสอบมาร์คอัปในสภาพแวดล้อมของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้มันถูกส่งออกโดยค่าเริ่มต้นอย่างไร?**

โดยค่าเริ่มต้นสไลด์ที่ซ่อนจะไม่ถูกรวมอยู่ คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/setexporthiddenslides/) ใน [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/) — ให้ปิดใช้งานหากคุณไม่ต้องการส่งออกสไลด์เหล่านั้น