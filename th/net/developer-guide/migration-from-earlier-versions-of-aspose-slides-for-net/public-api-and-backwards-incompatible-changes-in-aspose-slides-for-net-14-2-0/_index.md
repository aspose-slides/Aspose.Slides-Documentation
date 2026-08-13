---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันกับเวอร์ชันก่อนใน Aspose.Slides for .NET 14.2.0
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides for .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
## **Public API และการเปลี่ยนแปลงที่ไม่เข้ากันกับเวอร์ชันก่อน**
{{% alert color="info" %}} 

เราได้ทำการเปลี่ยนแปลงบางอย่างใน Aspose.Slides for .NET 14.2.0 API. คุณสมบัติและเมธอดบางส่วนถูกลบออกและบางส่วนถูกย้ายไปยังเนมสเปซอื่น

{{% /alert %}} 
### **เมธอด Aspose.Slides.IPresentation.Write(…) ถูกลบ**
เมธอดเหล่านี้เขียนอ็อบเจกต์ Presentation ลงในไฟล์รูปแบบ PPTX เท่านั้น ใน API ใหม่ คลาส Presentation ใช้ทำงานกับทุกรูปแบบ สามารถใช้เมธอด Presentation.Save(…) เพื่อบันทึกอ็อบเจกต์ Presentation ไปยังรูปแบบที่รองรับทั้งหมด
### **คลาสที่เกี่ยวข้องกับ Theme Styles ถูกย้ายไปยังเนมสเปซ Aspose.Slides.Theme**
คลาสต่อไปนี้ถูกย้ายจากเนมสเปซ Aspose.Slides ไปยังเนมสเปซ Aspose.Slides.Theme.

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
### **การเปลี่ยนแปลงจาก Aspose.Slides for .NET 8.X.0**
ฟีเจอร์ของ Aspose.Slides for .NET 8.4 ถูกเพิ่มเข้าไปใน Aspose.Slides for .NET 14.2.0