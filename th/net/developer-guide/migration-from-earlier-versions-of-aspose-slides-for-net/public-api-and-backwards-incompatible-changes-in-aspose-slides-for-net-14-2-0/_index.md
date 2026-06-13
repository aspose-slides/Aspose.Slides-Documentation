---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันกับรุ่นก่อนใน Aspose.Slides สำหรับ .NET 14.2.0
linktitle: Aspose.Slides สำหรับ .NET 14.2.0
type: docs
weight: 40
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้ไม่เข้ากันใน Aspose.Slides สำหรับ .NET เพื่อให้การย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณเป็นไปอย่างราบรื่น"
---
## **API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันกับเวอร์ชันก่อนหน้า**
{{% alert color="primary" %}} 

เราได้ทำการเปลี่ยนแปลงบางอย่างใน API ของ Aspose.Slides สำหรับ .NET 14.2.0 คุณสมบัติและเมธอดบางอย่างถูกลบออกและบางส่วนได้ถูกย้ายไปยังเนมสเปซอื่น

{{% /alert %}} 
### **เมธอด Aspose.Slides.IPresentation.Write(…) ถูกลบออก**
เมธอดเหล่านี้เขียนอ็อบเจกต์ Presentation ลงไฟล์รูปแบบ PPTX เท่านั้น ใน API ใหม่ คลาส Presentation ใช้ทำงานกับทุกรูปแบบ สามารถใช้เมธอด Presentation.Save(…) เพื่อบันทึกอ็อบเจกต์ Presentation ไปยังรูปแบบที่รองรับทั้งหมด
### **คลาสที่เกี่ยวข้องกับสไตล์ธีมถูกย้ายไปยังเนมสเปซ Aspose.Slides.Theme**
คลาสต่อไปนี้ได้ถูกย้ายจากเนมสเปซ Aspose.Slides ไปยังเนมสเปซ Aspose.Slides.Theme

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **การเปลี่ยนแปลงจาก Aspose.Slides สำหรับ .NET 8.X.0**
ฟีเจอร์ของ Aspose.Slides สำหรับ .NET 8.4 ได้ถูกเพิ่มเข้าไปใน Aspose.Slides สำหรับ .NET 14.2.0