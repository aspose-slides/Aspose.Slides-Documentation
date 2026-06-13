---
title: ส่งออกงานนำเสนอเป็น XAML ใน C++
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน C++ ด้วย Aspose.Slides—วิธีแก้ปัญหาเร็ว ไม่ต้องใช้ Office ที่คงรูปร่างเลย์เอาต์ของคุณไว้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML ด้วย Aspose.Slides รวมทั้งการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนไว้ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อน

## **เกี่ยวกับ XAML**

XAML เป็นภาษาการเขียนโปรแกรมเชิงบรรยายที่ช่วยให้คุณสร้างหรือเขียนส่วนต่อประสานผู้ใช้สำหรับแอป โดยเฉพาะแอปที่ใช้ WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin Forms  

XAML ซึ่งเป็นภาษาที่อิง XML เป็นรูปแบบของ Microsoft สำหรับอธิบาย GUI คุณมักจะใช้เครื่องมือออกแบบเพื่อทำงานกับไฟล์ XAML ส่วนใหญ่ แต่คุณก็ยังสามารถเขียนและแก้ไข GUI ของคุณได้

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

โค้ด C++ นี้แสดงวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

คุณสามารถเลือกตัวเลือกจากอินเทอร์เฟซ [IXamlOptions](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.xaml.i_xaml_options) เพื่อควบคุมกระบวนการส่งออกและกำหนดวิธีที่ Aspose.Slides จะส่งออกงานนำเสนอของคุณเป็น XAML  

ตัวอย่างเช่น หากคุณต้องการให้ Aspose.Slides เพิ่มสไลด์ที่ซ่อนไว้จากงานนำเสนอของคุณเมื่อส่งออกเป็น XAML คุณสามารถส่งค่าจริงไปยังเมธอด [set_ExportHiddenSlides()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) ดูตัวอย่างโค้ด C++ นี้:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรเพื่อให้แน่ใจว่าได้ฟอนต์ที่คาดการณ์ได้หากฟอนต์ต้นฉบับไม่มีในเครื่อง?**

ใช้ [set_DefaultRegularFont](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) ใน [XamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/) — จะถูกใช้เป็นฟอนต์สำรองเมื่อฟอนต์ต้นฉบับไม่มีอยู่ ช่วยป้องกันการแทนที่ที่ไม่คาดคิด

**XAML ที่ส่งออกออกมามีจุดประสงค์ใช้เฉพาะกับ WPF หรือสามารถใช้ในสแตก XAML อื่น ๆ ได้ด้วยหรือไม่?**

XAML เป็นภาษามาร์กอัป UI ทั่วไปที่ใช้ใน WPF, UWP และ Xamarin.Forms การส่งออกมุ่งเป้าเพื่อความเข้ากันได้กับสแตก XAML ของ Microsoft; พฤติกรรมที่แน่นอนและการสนับสนุนโครงสร้างเฉพาะจะขึ้นอยู่กับแพลตฟอร์มเป้าหมาย ทดสอบมาร์กอัปในสภาพแวดล้อมของคุณ

**สไลด์ที่ซ่อนไว้ได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้ถูกส่งออกโดยค่าเริ่มต้นอย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนไว้จะไม่ถูกรวมเข้าไป คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [set_ExportHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) ใน [XamlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export.xaml/xamloptions/) — ให้ปิดการใช้งานหากคุณไม่ต้องการส่งออกสไลด์เหล่านั้น