---
title: Specify Fallback Fonts for Presentations on Android
linktitle: Fallback Font
type: docs
weight: 10
url: /th/androidjava/create-fallback-font/
keywords:
- แบบอักษรสำรอง
- กฎการสำรอง
- ใช้แบบอักษร
- แทนที่แบบอักษร
- ช่วง Unicode
- glyph ที่หายไป
- glyph ที่ถูกต้อง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อกำหนดแบบอักษรสำรองในไฟล์ PPT, PPTX และ ODP ทำให้การแสดงผลข้อความคงที่บนอุปกรณ์หรือระบบปฏิบัติการใดๆ ก็ตาม"
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุแบบอักษรสำรองสำหรับการแสดงผลและการส่งออกงานนำเสนอ  
แบบอักษรสำรองจะถูกใช้เมื่อแบบอักษรหลักไม่มี glyphs สำหรับอักขระบางตัว  

พฤติกรรมการสำรองกำหนดผ่านกฎการสำรอง แต่ละกฎเชื่อมโยงช่วง Unicode กับแบบอักษรหนึ่งหรือหลายแบบที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือถอนแบบอักษรสำรองจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลคชันกฎแบบอักษรสำรอง  

กฎการสำรองเป็นการตั้งค่าการแสดงผลในช่วงเวลารันไทม์ ไม่ได้แก้ไขไฟล์งานนำเสนอเองและไม่ได้ถูกเก็บไว้ในไฟล์ PPTX  

## **กฎการสำรองแบบอักษร**

Aspose.Slides รองรับอินเทอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IFontFallBackRule) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) เพื่อระบุกฎที่จะใช้แบบอักษรสำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) แสดงความสัมพันธ์ระหว่างช่วง Unicode ที่กำหนด (ใช้สำหรับค้นหา glyph ที่หายไป) กับรายการแบบอักษรที่อาจมี glyph ที่เหมาะสม:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//โดยใช้หลายวิธีคุณสามารถเพิ่มรายการแบบอักษร:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

คุณยังสามารถ [remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) แบบอักษรสำรองหรือ [addFallBackFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) เข้าไปในอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) ที่มีอยู่ได้  

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRulesCollection) สามารถใช้เพื่อจัดระเบียบรายการของอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) เมื่อจำเป็นต้องระบุกฎการแทนที่แบบอักษรสำรองสำหรับหลายช่วง Unicode  

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [สร้างคอลเลกชันแบบอักษรสำรอง](/slides/th/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างแบบอักษรสำรอง, การแทนที่แบบอักษร, และการฝังแบบอักษรคืออะไร?**

แบบอักษรสำรองจะถูกใช้เฉพาะสำหรับอักขระที่หายไปในแบบอักษรหลัก [Font substitution](/slides/th/androidjava/font-substitution/) แทนที่แบบอักษรที่ระบุทั้งหมดด้วยแบบอักษรอื่น [Font embedding](/slides/th/androidjava/embedded-font/) จะบรรจุแบบอักษรไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความได้ตามที่ตั้งใจ  

**แบบอักษรสำรองถูกนำไปใช้ในการส่งออก เช่น PDF, PNG หรือ SVG หรือเฉพาะการแสดงผลบนหน้าจอเท่านั้น?**

ใช่. แบบอักษรสำรองมีผลต่อทุก [การแสดงผลและการส่งออก](/slides/th/androidjava/convert-presentation/) ที่ต้องวาดอักขระแต่ไม่มีในแบบอักษรต้นฉบับ  

**การตั้งค่าการสำรองทำให้ไฟล์งานนำเสนอเปลี่ยนแปลงหรือไม่ และการตั้งค่านี้จะคงอยู่เมื่ิอเปิดไฟล์ครั้งต่อไปหรือไม่?**

ไม่. กฎการสำรองเป็นการตั้งค่าการแสดงผลในช่วงรันไทม์ในโค้ดของคุณ; ไม่ได้ถูกเก็บไว้ในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint  

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์แบบอักษรมีผลต่อการเลือกแบบอักษรสำรองหรือไม่?**

ใช่. เครื่องยนต์จะค้นหาแบบอักษรจากโฟลเดอร์ระบบที่มีอยู่และจาก [เส้นทางเพิ่มเติม](/slides/th/androidjava/custom-font/) ใด ๆ ที่คุณระบุ หากแบบอักษรไม่มีอยู่จริง กฎที่อ้างอิงแบบอักษรนั้นไม่สามารถทำงานได้  

**แบบอักษรสำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่. เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกใช้เพื่อแสดงอักขระที่หายไป  