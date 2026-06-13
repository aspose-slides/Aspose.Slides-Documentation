---
title: ทำไมไม่ใช้ Open XML SDK
type: docs
weight: 100
url: /th/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- การเปรียบเทียบ
- โมเดลวัตถุการนำเสนอ
- การแปลงคุณภาพสูง
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ดูว่าทำไม Aspose.Slides ถึงเป็นตัวเลือกที่ดีกว่า Open XML SDK ฟรี: เปรียบเทียบคุณลักษณะ, การแปลงโดยไม่ต้องอัตโนมัติ, และการสนับสนุนอย่างกว้างขวางสำหรับ PPT, PPTX และ ODP."
---
## **ภาพรวม**

บทความนี้อธิบายว่าเมื่อใดนักพัฒนาจึงอาจเลือกใช้ Open XML SDK หรือ Aspose.Slides สำหรับการทำงานกับเอกสารนำเสนอ โดยอธิบายว่า Open XML SDK คือไลบรารีสำหรับจัดการแพ็กเกจ OOXML และองค์ประกอบ XML ที่อยู่ภายใน ในขณะที่ Aspose.Slides นำเสนอเป็นไลบรารีการประมวลผลการนำเสนอที่มีโมเดลออบเจ็กต์ระดับสูงและรองรับงานหลายอย่างที่เกี่ยวกับ PowerPoint

บทความเปรียบเทียบทั้งสองตัวเลือกตามรูปแบบที่รองรับ, รูปแบบการเขียนโปรแกรม, ความสามารถในการเรนเดอร์และพิมพ์, การสนับสนุนแพลตฟอร์ม, และกรณีการใช้งานทั่วไป นอกจากนี้ยังชี้ให้เห็นว่า Open XML SDK อาจเหมาะกับการดำเนินการพื้นฐานบน PPTX หรือการเข้าถึงองค์ประกอบ OOXML โดยตรง ในขณะที่ Aspose.Slides เหมาะกับงานนำเสนอที่ซับซ้อน เช่น การทำงานกับหลายรูปแบบ PowerPoint, การคัดลอกหรือทำซ้ำรูปร่าง, การแทนที่ข้อความ, การใส่เอฟเฟกต์แอนิเมชัน, และการแปลงการนำเสนอเป็น PDF, TIFF หรือ XPS

## **Open XML SDK คืออะไร?**
เรามักได้ยินคำถามนี้บ่อย: ทำไมเราต้องใช้ผลิตภัณฑ์ของ Aspose แทน Open XML SDK ที่ฟรี? คำตอบง่าย ๆ คือคุณลักษณะและฟังก์ชัน ตามที่ระบุใน[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) Open XML SDK ถูกกำหนดว่า: The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.

## **Aspose.Slides คืออะไร?**
Aspose.Slides เป็นคลาสไลบรารีที่ทำให้แอปพลิเคชันของคุณสามารถทำงานประมวลผลการนำเสนอได้ดังต่อไปนี้

- การโปรแกรมด้วยโมเดลวัตถุ **Presentation**  
- การแปลงคุณภาพสูงระหว่างรูปแบบการนำเสนอ PowerPoint ที่ได้รับความนิยมทั้งหมด รวมถึงการแปลงเป็น PDF และ XPS  
- ความสามารถในการสร้างรูปย่อสไลด์ในรูปแบบที่รู้จักกันอย่างกว้างขวางเช่น PNG, JPEG และ BMP พร้อมกับการส่งออกสไลด์เป็น SVG  
- ความสามารถในการสร้างการนำเสนอจากศูนย์หรือโดยการรวมจากเอกสารหนึ่งหรือหลายเอกสาร  
- การสนับสนุนการเพิ่มแอนิเมชัน, Ole Frames, ตาราง, การสร้างและจัดการแผนภูมิ  
- การควบคุมที่ครอบคลุมสำหรับการจัดการการจัดรูปแบบข้อความในระดับ TextFrames, Paragraphs และ Portions  

สำหรับรายละเอียดเพิ่มเติมเกี่ยวกับคุณลักษณะที่รองรับ โปรดเยี่ยมชม[Aspose.Slides Features](/slides/th/cpp/product-overview/)

## **เปรียบเทียบ Open XML SDK และ Aspose.Slides**
ตารางต่อไปนี้เปรียบเทียบคุณลักษณะของ Open XML SDK และ Aspose.Slides

|**ลักษณะหรือหมวดหมู่ลักษณะ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|รูปแบบการนำเสนอที่รองรับ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|การแปลงจาก PPT เป็น PPTX|No|Yes|
|<p>การเขียนโปรแกรมระดับสูงด้วย Presentation Document Object Model (DOM):</p><p>- ค้นหาและแทนที่ข้อความ</p><p>- จัดสรรสไลด์ในงานนำเสนอ</p>|No|Yes|
|การเขียนโปรแกรมโดยละเอียดด้วย Document Object Model, การเข้าถึงองค์ประกอบและการจัดรูปแบบเช่น TextHolders, TextFrames, Paragraphs และ Portions.|Yes|Yes|
|การเข้าถึงระดับต่ำโดยตรงและเต็มรูปแบบต่อองค์ประกอบและแอตทริบิวต์ XML ที่อยู่ภายใต้ เช่น ตัวระบุความสัมพันธ์, ตัวระบุรายการของเอกสาร OOXML.|Yes|No|
|<p>การเรนเดอร์:</p><p>- เรนเดอร์งานนำเสนอเป็น PDF, PDF Notes, XPS, ภาพ TIFF</p><p>- เรนเดอร์รูปย่อสไลด์เป็น PNG, JPEG, BMP, SVG และ TIFF</p><p>- ระบุตัวเลือกความละเอียดภาพ, คุณภาพ, การบีบอัดและอื่น ๆ</p>|No|Yes|

## **สรุป**
Open XML SDK และ Aspose.Slides ไม่ได้แข่งขันกันโดยตรง เพราะพวกเขาตอบสนองความต้องการและผู้ชมที่ต่างกัน Open XML SDK เป็นไลบรารีคลาสที่ให้วิธีการทำงานกับเอกสาร OOXML อย่างแบบ strongly‑typed ส่วน Aspose.Slides เป็นไลบรารีการประมวลผลการนำเสนอที่มีประโยชน์อย่างยิ่งและสนับสนุนรูปแบบไฟล์ Microsoft PowerPoint เกือบทั้งหมด หากสิ่งที่คุณต้องการทำคือการดำเนินการโปรแกรมพื้นฐานบนเอกสาร PPTX อย่างง่าย ๆ Open XML SDK อาจเป็นตัวเลือกที่เหมาะสม ด้วย Open XML SDK คุณจะทำงานอย่างสบายใจกับงานง่าย ๆ เช่น การสร้างเอกสาร PPTX ง่าย ๆ หรือการลบคอมเมนต์, ส่วนหัว/ส่วนท้าย, การสกัดภาพหรืออื่น ๆ งานบางอย่างสามารถทำได้ด้วย Open XML SDK แต่ไม่สามารถทำได้ด้วย Aspose.Slides ตัวอย่างเช่น หากคุณต้องการเข้าถึงองค์ประกอบและแอตทริบิวต์ XML ของเอกสาร OOXML โดยตรง คุณควรใช้ Open XML SDK อย่างไรก็ตาม หากคุณต้องการทำงานที่ซับซ้อนบนเอกสาร เช่น งานต่อไปนี้ การใช้ Aspose.Slides คือทางเลือกที่ดีที่สุด

- สนับสนุนรูปแบบ PowerPoint เก่ารวมถึง PPTX  
- คัดลอกหรือทำซ้ำรูปร่างภายในสไลด์ในลักษณะที่รวมวัตถุ, สไตล์และการจัดรูปแบบอื่น ๆ อย่างเหมาะสม  
- แทนที่ข้อความที่มีการจัดรูปแบบหรือไม่มีการจัดรูปแบบ  
- ใส่แอนิเมชันและใช้คอนเนคเตอร์กับรูปร่างที่ใช้  
- แปลงเอกสารเป็น PDF หรือ XPS ให้มีลักษณะเหมือนที่ Microsoft PowerPoint จะทำการแปลง  
- พัฒนาแอปพลิเคชัน C++ ทั้งในสภาพแวดล้อมเดสก์ท็อปและคอนโซล