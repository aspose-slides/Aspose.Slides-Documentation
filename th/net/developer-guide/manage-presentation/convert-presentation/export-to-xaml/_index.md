---
title: ส่งออกงานนำเสนอเป็น XAML ใน .NET
linktitle: การนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน .NET ด้วย Aspose.Slides—โซลูชันเร็ว ไม่ต้องใช้ Office ที่รักษาเค้าโครงของคุณให้คงเดิม"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML โดยใช้ Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export.xaml/xamloptions/) รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแต็ก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษาโปรแกรมเชิงพรรณนาที่ช่วยให้คุณสร้างหรือเขียนส่วนติดต่อผู้ใช้สำหรับแอป โดยเฉพาะแอปที่ใช้ WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin Forms  

XAML ซึ่งเป็นภาษาที่อิงจาก XML เป็นรูปแบบของ Microsoft สำหรับอธิบาย GUI คุณอาจใช้เครื่องมือออกแบบเพื่อทำงานกับไฟล์ XAML ส่วนใหญ่ แต่คุณก็สามารถเขียนและแก้ไข GUI ได้เช่นกัน

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

โค้ด C# นี้แสดงวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

คุณสามารถเลือกตัวเลือกจากอินเทอร์เฟซ [IXamlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export.xaml/ixamloptions) ที่ควบคุมกระบวนการส่งออกและกำหนดวิธีที่ Aspose.Slides ส่งออกงานนำเสนอของคุณเป็น XAML  

ตัวอย่างเช่น หากคุณต้องการให้ Aspose.Slides เพิ่มสไลด์ที่ซ่อนจากงานนำเสนอของคุณเมื่อต้องการส่งออกเป็น XAML คุณสามารถตั้งค่าคุณสมบัติ [ExportHiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) เป็น true ดูตัวอย่างโค้ด C# นี้:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรให้ฟอนต์คาดเดาได้หากฟอนต์เดิมไม่มีบนเครื่อง?**

ตั้งค่า [DefaultRegularFont](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/defaultregularfont/) ใน [XamlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export.xaml/xamloptions/) — จะถูกใช้เป็นฟอนต์สำรองเมื่อฟอนต์เดิมไม่มีอยู่ ซึ่งช่วยหลีกเลี่ยงการแทนที่ที่ไม่คาดคิด

**XAML ที่ส่งออกมีเจตนาใช้เฉพาะกับ WPF เท่านั้นหรือสามารถใช้ในสแต็ก XAML อื่นได้ด้วยหรือไม่?**

XAML เป็นภาษามาร์กอัป UI ทั่วไปที่ใช้ใน WPF, UWP, และ Xamarin.Forms การส่งออกมุ่งเน้นความเข้ากันได้กับสแต็ก XAML ของ Microsoft; พฤติกรรมที่แน่นอนและการสนับสนุนโครงสร้างเฉพาะขึ้นอยู่กับแพลตฟอร์มเป้าหมาย ให้ทดสอบมาร์กอัปในสภาพแวดล้อมของคุณ

**สไลด์ที่ซ่อนได้รับการสนับสนุนหรือไม่ และฉันจะป้องกันไม่ให้ส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่รวมอยู่ คุณสามารถควบคุมพฤติกรรมนี้ผ่าน [ExportHiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) ใน [XamlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export.xaml/xamloptions/) — ปิดการใช้งานหากไม่ต้องการส่งออกสไลด์เหล่านั้น