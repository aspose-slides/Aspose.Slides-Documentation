---
title: ระบุฟอนต์สำรองสำหรับการนำเสนอใน Python
linktitle: ฟอนต์สำรอง
type: docs
weight: 10
url: /th/python-net/create-fallback-font/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- ใช้ฟอนต์
- แทนที่ฟอนต์
- ช่วง Unicode
- glyph ที่หายไป
- glyph ที่ถูกต้อง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อกำหนดฟอนต์สำรองในไฟล์ PPT, PPTX และ ODP, เพื่อให้แน่ใจว่าข้อความแสดงผลอย่างสม่ำเสมอบนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุฟอนต์สำรองสำหรับการเรนเดอร์และการส่งออกการนำเสนอ ฟอนต์สำรองจะถูกใช้เมื่อฟอนต์หลักไม่มี glyph สำหรับอักขระบางตัว  

พฤติกรรมการสำรองถูกกำหนดผ่านกฎสำรองแต่ละกฎเชื่อมโยงช่วง Unicode กับฟอนต์หนึ่งหรือหลายฟอนต์ที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือเอาฟอนต์สำรองออกจากกฎที่มีอยู่ และจัดกลุ่มหลายกฎในคอลเลกชันกฎฟอนต์สำรอง  

กฎสำรองเป็นการตั้งค่าการเรนเดอร์ในช่วงเวลาใช้งาน พวกมันไม่ได้แก้ไขไฟล์การนำเสนอเองและไม่ได้ถูกเก็บไว้ภายในไฟล์ PPTX  

## **ระบุฟอนต์สำรอง**

Aspose.Slides รองรับคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/python-net/aspose.slides/FontFallBackRule/) เพื่อระบุกฎในการใช้ฟอนต์สำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/python-net/aspose.slides/FontFallBackRule/) แสดงความสัมพันธ์ระหว่างช่วง Unicode ที่ระบุ ซึ่งใช้ในการค้นหา glyph ที่หายไป กับรายการฟอนต์ที่อาจมี glyph ที่เหมาะสม:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#ใช้หลายวิธีเพื่อเพิ่มรายการฟอนต์:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

คุณยังสามารถ [remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontfallbackrule/remove/) ฟอนต์สำรองหรือ [add_fall_back_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) ไปยังอ็อบเจกต์ [FontFallBackRule](https://reference.aspose.com/slides/th/python-net/aspose.slides/FontFallBackRule/) ที่มีอยู่ได้  

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontfallbackrulescollection/) สามารถใช้จัดรายการอ็อบเจกต์ [FontFallBackRule](https://reference.aspose.com/slides/th/python-net/aspose.slides/FontFallBackRule/) เมื่อจำเป็นต้องระบุกฎการเปลี่ยนฟอนต์สำรองสำหรับหลายช่วง Unicode  

{{% alert color="primary" title="See also" %}} 
- [สร้างคอลเลกชันฟอนต์สำรอง](/slides/th/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฟอนต์สำรอง, การแทนที่ฟอนต์, และการฝังฟอนต์ต่างกันอย่างไร?**

ฟอนต์สำรองจะใช้เฉพาะกับอักขระที่หายไปในฟอนต์หลัก [การแทนที่ฟอนต์](/slides/th/python-net/font-substitution/) จะเปลี่ยนฟอนต์ที่ระบุทั้งหมดด้วยฟอนต์อื่น ส่วน [การฝังฟอนต์](/slides/th/python-net/embedded-font/) จะบรรจุฟอนต์ไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความได้ตามต้องการ  

**ฟอนต์สำรองจะถูกนำไปใช้ในการส่งออกเช่น PDF, PNG หรือ SVG หรือใช้เฉพาะการเรนเดอร์บนหน้าจอ?**

ใช่ ฟอนต์สำรองมีผลต่อทุก [การเรนเดอร์และการส่งออก](/slides/th/python-net/convert-presentation/) ที่ต้องวาดอักขระแต่ฟอนต์ต้นทางไม่มี  

**การกำหนดค่าฟอนต์สำรองทำให้ไฟล์การนำเสนอเปลี่ยนแปลงหรือไม่ และการตั้งค่านี้จะคงอยู่เมื่อเปิดไฟล์ในภายหลังหรือไม่?**

ไม่ กฎสำรองเป็นการตั้งค่าการเรนเดอร์ในโค้ดของคุณ; พวกมันไม่ได้ถูกเก็บไว้ในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint  

**ระบบปฏิบัติการ (Windows/Linux/macOS) และโฟลเดอร์ฟอนต์ที่ตั้งค่าไว้มีผลต่อการเลือกฟอนต์สำรองหรือไม่?**

ใช่ เอนจินจะค้นหาฟอนต์จากโฟลเดอร์ระบบที่มีอยู่และ [เส้นทางเพิ่มเติม](/slides/th/python-net/custom-font/) ที่คุณระบุ หากฟอนต์ไม่มีอยู่จริง กฎที่อ้างอิงฟอนต์นั้นจะไม่มีผล  

**ฟอนต์สำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่ เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะทำงานเพื่อเรนเดอร์อักขระที่หายไป  