---
title: ส่งออกงานนำเสนอเป็น XAML ใน Python ผ่าน Java
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/python-java/export-to-xaml/
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
- Python
- Java
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น XAML ด้วย Aspose.Slides for Python via Java ใช้ตัวเลือกเริ่มต้นหรือรวมสไลด์ที่ซ่อนอยู่"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint และ OpenDocument ไปเป็น XAML ด้วย Aspose.Slides for Python via Java โดยจะแนะนำ XAML, แสดงวิธีส่งออกด้วยการตั้งค่าเริ่มต้น, และสาธิตวิธีรวมสไลด์ที่ซ่อนอยู่ด้วย [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/)  

ตัวอย่างต้องใช้ Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ วางไฟล์ `pres.pptx` ไว้ในไดเรกทอรีทำงานปัจจุบัน ตัวอย่างแต่ละอันจะเริ่ม JVM หากยังไม่ได้รัน

## **เกี่ยวกับ XAML**

XAML (Extensible Application Markup Language) คือภาษาที่ใช้ XML สำหรับอธิบายส่วนต่อประสานผู้ใช้ มักใช้ในเฟรมเวิร์กเช่น Windows Presentation Foundation (WPF) คุณสามารถสร้างและแก้ไข XAML ด้วยตัวออกแบบแบบภาพหรือด้วยโปรแกรมแก้ไขข้อความ

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

สร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) จากไฟล์อินพุต แล้วส่ง [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/) ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อส่งออกด้วยการตั้งค่าเริ่มต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

ใช้ [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/) เพื่อกำหนดค่าการส่งออก เพื่อรวมสไลด์ที่ซ่อนอยู่ ให้เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) พร้อมค่า `True` ก่อนบันทึก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันจะเลือกฟอนต์สำรองเมื่อฟอนต์ต้นฉบับไม่พร้อมใช้ได้อย่างไร?**

ใช้ [setDefaultRegularFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) บนวัตถุ [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/) ของคุณเพื่อระบุฟอนต์สำรอง ตรวจสอบให้แน่ใจว่าฟอนต์ที่เลือกมีอยู่ในสภาพแวดล้อมการส่งออก

**ฉันสามารถใช้มาร์กอัปที่ส่งออกไปในเฟรมเวิร์ก XAML ใดก็ได้หรือไม่?**

เฟรมเวิร์ก XAML มีความแตกต่างกันในส่วนขององค์ประกอบและฟีเจอร์ที่รองรับ ควรทดสอบมาร์กอัปที่ส่งออกในเฟรมเวิร์กเป้าหมายของคุณก่อนนำไปใช้ในแอปพลิเคชัน

**สไลด์ที่ซ่อนอยู่จะถูกส่งออกโดยค่าเริ่มต้นหรือไม่?**

ไม่ หากต้องการรวมสไลด์เหล่านั้น ให้เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) พร้อมค่า `True` หากต้องการยกเว้นให้ตั้งค่าเป็น `False`