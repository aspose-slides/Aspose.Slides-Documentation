---
title: ทำไมไม่ใช้ Open XML SDK
type: docs
weight: 50
url: /th/net/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- เปรียบเทียบ
- โมเดลอ็อบเจกต์การนำเสนอ
- การแปลงคุณภาพสูง
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ดูว่าทำไม Aspose.Slides จึงเป็นตัวเลือกที่ดีกว่า Open XML SDK ฟรี: เปรียบเทียบคุณลักษณะ, การแปลงโดยไม่ต้องอัตโนมัติ, และการรองรับกว้างสำหรับ PPT, PPTX และ ODP."
---
## **ภาพรวม**

บทความนี้อธิบายว่าเมื่อใดนักพัฒนาจะเลือกใช้ Open XML SDK หรือ Aspose.Slides สำหรับการทำงานกับเอกสารงานนำเสนอ โดยอธิบายว่า Open XML SDK เป็นไลบรารีสำหรับจัดการแพ็กเกจ OOXML และองค์ประกอบ XML ด้านล่างของแพ็กเกจ ส่วน Aspose.Slides นำเสนอเป็นไลบรารีประมวลผลงานนำเสนอที่มีโมเดลอ็อบเจกต์ระดับสูงและรองรับงานหลายอย่างที่เกี่ยวกับ PowerPoint  

บทความเปรียบเทียบตัวเลือกทั้งสองตามรูปแบบที่รองรับ, โมเดลการเขียนโปรแกรม, ความสามารถในการเรนเดอร์และพิมพ์, การสนับสนุนแพลตฟอร์ม, และกรณีการใช้งานทั่วไป อีกทั้งยังชี้แจงว่า Open XML SDK อาจเหมาะกับการดำเนินการพื้นฐานบนไฟล์ PPTX หรือการเข้าถึงองค์ประกอบ OOXML โดยตรง ในขณะที่ Aspose.Slides เหมาะกับงานนำเสนอที่ซับซ้อนเช่นการทำงานกับหลายรูปแบบ PowerPoint, การคัดลอกหรือโคลนรูปทรง, การแทนที่ข้อความ, การใช้เอฟเฟกต์แอนิเมชัน, และการแปลงงานนำเสนอเป็น PDF, TIFF หรือ XPS  

## **Open XML SDK คืออะไร?**

บางครั้งเราพบคำถามนี้: *ทำไมเราควรใช้ผลิตภัณฑ์ของ Aspose แทน Open XML SDK ที่ฟรี?*  

เราพบว่าการตอบคำถามนี้โดยอิงจากคุณลักษณะและฟังก์ชันการทำงานเป็นเรื่องง่าย  

ตาม [ไลบรารี MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) Open XML SDK ถูกกำหนดไว้ดังนี้:  

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Aspose.Slides คืออะไร?**

Aspose.Slides เป็นไลบรารีคลาสที่ทำให้แอปพลิเคชันสามารถทำงานประมวลผลงานนำเสนอเหล่านี้ได้:  

- การเขียนโปรแกรมด้วยโมเดลอ็อบเจกต์ของงานนำเสนอ.  
- การแปลงคุณภาพสูงที่ครอบคลุมรูปแบบงานนำเสนอ PowerPoint ที่ได้รับการสนับสนุนทั้งหมด รวมถึงการแปลงเป็น PDF, XPS, TIFF และการพิมพ์.  
- การสร้างภาพย่อของสไลด์ในรูปแบบที่เป็นที่รู้จักเช่น PNG, JPEG และ BMP รวมถึงการส่งออกสไลด์เป็น SVG.  
- การสร้างงานนำตั้งแต่ต้นหรือโดยการรวมเอาองค์ประกอบจากเอกสารหนึ่งหรือหลายเอกสาร.  
- การเพิ่มแอนิเมชัน, OLE Frame, ตาราง, การสร้างและจัดการแผนภูมิ.  
- การควบคุม (การควบคุมอย่างกว้างขวาง) และการจัดการรูปแบบข้อความในระดับ TextFrames, Paragraphs และ Portions.  

สำหรับรายละเอียดเพิ่มเติมเกี่ยวกับคุณสมบัติที่มี โปรดดูหน้า [คุณสมบัติ Aspose.Slides](/slides/th/net/product-overview/)  

## **เปรียบเทียบ Open XML SDK กับ Aspose.Slides**

|**คุณลักษณะหรือหมวดคุณลักษณะ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|รูปแบบงานนำเสนอที่รองรับ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|การแปลงจาก PPT เป็น PPTX|No|Yes|
|<p>การเขียนโปรแกรมระดับสูงด้วย Presentation Document Object Model (DOM): </p><p>- ค้นหาและแทนที่ข้อความ</p><p>- ประกอบสไลด์ในงานนำเสนอ</p>|No|Yes|
|การเขียนโปรแกรมอย่างละเอียดด้วยโมเดลอ็อบเจกต์ของเอกสาร; เข้าถึงองค์ประกอบแต่ละรายการและการจัดรูปแบบเช่น TextHolders, TextFrames, Paragraphs และ Portions.|Yes|Yes|
|การเข้าถึงระดับล่างโดยตรงและเต็มรูปแบบต่อองค์ประกอบ XML และแอตทริบิวต์พื้นฐาน เช่น ตัวระบุความสัมพันธ์, ตัวระบุรายการของเอกสาร OOXML.|Yes|No|
|<p>การเรนเดอร์และพิมพ์:</p><p>- เรนเดอร์งานนำเสนอเป็น PDF, PDF Notes, XPS, ภาพ TIFF.</p><p>- เรนเดอร์ภาพย่อของสไลด์เป็น PNG, JPEG, BMP, SVG และ TIFF.</p><p>- กำหนดความละเอียดของภาพ, คุณภาพ, การบีบอัดและตัวเลือกอื่น ๆ.</p><p>- พิมพ์งานนำเสนอโดยใช้โครงสร้างการพิมพ์ของ .NET ส่วนประกอบมีเมธอดพิมพ์ในตัวเพื่อพิมพ์งานนำเสนอตามที่แสดงใน Print Preview ของ MS PowerPoint.</p>|No|Yes|
|แพลตฟอร์มที่รองรับ|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **สรุป**

Open XML SDK และ Aspose.Slides ไม่แข่งขันกันโดยตรง เนื่องจากพวกมันตอบสนองความต้องการที่แตกต่างกันอย่างมากและมุ่งเป้าไปที่ผู้ใช้กลุ่มต่างกัน  

{{% alert color="primary" %}}  

Open XML SDK เป็นไลบรารีคลาสที่ให้วิธีการแบบ strong‑typed สำหรับทำงานกับเอกสาร OOXML ในขณะที่ Aspose.Slides เป็นไลบรารีประมวลผลงานนำเสนอที่ให้การสนับสนุนที่ยอดเยี่ยมสำหรับไฟล์ Microsoft PowerPoint เกือบทุกรูปแบบ  

{{% /alert %}}  

หากกระบวนการทำงานของคุณเป็นการดำเนินการโปรแกรมพื้นฐานบนเอกสาร PPTX แล้ว Open XML SDK อาจเป็นตัวเลือกที่ดี ด้วย Open XML SDK คุณจะสามารถทำงานง่าย ๆ เช่น การสร้างเอกสาร PPTX อย่างง่าย การลบคอมเมนต์ ส่วนหัว/ส่วนท้าย การสกัดรูปภาพ หรืออื่น ๆ งานบางอย่างทำได้ด้วย Open XML SDK แต่ไม่สามารถทำได้ด้วย Aspose.Slides ตัวอย่างเช่น หากคุณต้องการเข้าถึงองค์ประกอบ XML และแอตทริบิวต์ของเอกสาร OOXML โดยตรง คุณควรใช้ Open XML SDK  

หากคุณต้องการทำงานที่ซับซ้อนบนเอกสาร—เช่นรายการต่อไปนี้—Aspose.Slides จะเป็นตัวเลือกที่ดีที่สุด  

- การดำเนินการที่เกี่ยวข้องกับรูปแบบ PowerPoint เก่า (และ PPTX ด้วย).  
- การคัดลอกหรือโคลนรูปทรงภายในสไลด์โดยผสานวัตถุ, สไตล์, และองค์ประกอบการจัดรูปแบบอื่น ๆ อย่างเหมาะสม.  
- การแทนที่ข้อความที่มีการจัดรูปแบบหรือไม่ได้จัดรูปแบบ.  
- การใช้แอนิเมชันและการเชื่อมต่อรูปทรงด้วยคอนเน็กเตอร์.  
- การแปลงเอกสารเป็น PDF, TIFF หรือ XPS ให้ได้ผลลัพธ์เหมือน Microsoft PowerPoint ทำการแปลง.  
- การพัฒนาแอปพลิเคชัน .NET หรือ Java ทั้งบนเดสก์ท็อปและเว็บ.