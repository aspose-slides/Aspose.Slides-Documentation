---
title: ทำไมไม่ใช่ Open XML SDK
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
description: "ดูเหตุผลที่ Aspose.Slides เป็นตัวเลือกที่ดีกว่า Open XML SDK ฟรี: เปรียบเทียบคุณลักษณะ, การแปลงแบบไม่มีการอัตโนมัติ, และการสนับสนุนอย่างกว้างขวางสำหรับ PPT, PPTX และ ODP."
---
## **ภาพรวม**

บทความนี้อธิบายว่าเมื่อใดนักพัฒนาจึงอาจเลือกใช้ Open XML SDK หรือ Aspose.Slides สำหรับทำงานกับเอกสารการนำเสนอ โดยอธิบาย Open XML SDK ว่าเป็นไลบรารีสำหรับจัดการแพ็คเกจ OOXML และองค์ประกอบ XML ขั้นฐานของมัน ในขณะที่ Aspose.Slides ถูกนำเสนอเป็นไลบรารีการประมวลผลการนำเสนอที่มีโมเดลวัตถุระดับสูงและสนับสนุนงานหลายอย่างที่เกี่ยวกับ PowerPoint

บทความเปรียบเทียบทั้งสองตัวเลือกตามรูปแบบที่รองรับ, โมเดลการเขียนโปรแกรม, การเรนเดอร์, การสนับสนุนแพลตฟอร์ม, และกรณีการใช้งานทั่วไป นอกจากนี้ยังชี้แจงว่า Open XML SDK อาจเหมาะสำหรับการดำเนินการ PPTX เบื้องต้นหรือการเข้าถึงองค์ประกอบ OOXML อย่างตรงไปตรงมา ในขณะที่ Aspose.Slides เหมาะสมกับงานการนำเสนอที่ซับซ้อน เช่น การทำงานกับหลายรูปแบบ PowerPoint, การคัดลอกหรือทำสำเนา shape, การแทนที่ข้อความ, การใช้แอนิเมชัน, และการแปลงการนำเสนอเป็น PDF, TIFF หรือ XPS

## **Open XML SDK คืออะไร?**
เราอาจได้ยินคำถามนี้บ่อยครั้ง: ทำไมเราควรใช้ผลิตภัณฑ์ของ Aspose แทน Open XML SDK ที่ฟรี? คำตอบคือง่าย: ฟีเจอร์และความสามารถ ตาม[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) Open XML SDK ถูกกำหนดว่า: The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.

## **Aspose.Slides คืออะไร?**
Aspose.Slides เป็นคลาสไลบรารีที่ทำให้แอปพลิเคชันของคุณสามารถทำงานการประมวลผลการนำเสนอได้ตามรายการต่อไปนี้:

- การเขียนโปรแกรมด้วยโมเดลวัตถุ **Presentation**  
- การแปลงคุณภาพสูงระหว่างรูปแบบการนำเสนอ PowerPoint ที่สนับสนุนทั้งหมด รวมถึงการแปลงเป็น PDF และ XPS  
- ความสามารถในการสร้างภาพย่อสไลด์ในรูปแบบที่รู้จักกันดีเช่น PNG, JPEG และ BMP พร้อมการส่งออกสไลด์เป็น SVG  
- ความสามารถในการสร้างงานนำเสนอจากศูนย์หรือโดยการรวมจากหนึ่งหรือหลายเอกสาร  
- การสนับสนุนการเพิ่มแอนิเมชัน, Ole Frames, ตาราง, การสร้างและจัดการแผนภูมิ  
- ความพร้อมใช้งานของการควบคุมอย่างกว้างขวางสำหรับการจัดการรูปแบบข้อความในระดับ TextFrames, Paragraphs และ Portions  
  สำหรับรายละเอียดเพิ่มเติมเกี่ยวกับฟีเจอร์ที่สนับสนุน โปรดเยี่ยมชม[Aspose.Slides Features](/slides/th/cpp/product-overview/)

## **เปรียบเทียบ Open XML SDK กับ Aspose.Slides**
ตารางต่อไปนี้เปรียบเทียบคุณลักษณะของ Open XML SDK และ Aspose.Slides

|**คุณลักษณะ หรือ หมวดคุณลักษณะ**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|รูปแบบการนำเสนอที่รองรับ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|การแปลงจาก PPT เป็น PPTX|No|Yes|
|<p>การเขียนโปรแกรมระดับสูงด้วย Presentation Document Object Model (DOM):</p><p>- ค้นหาและแทนที่ข้อความ.</p><p>- รวมสไลด์ในงานนำเสนอ.</p>|No|Yes|
|การเขียนโปรแกรมอย่างละเอียดด้วยโมเดลวัตถุของเอกสาร, เข้าถึงส่วนประกอบแต่ละส่วนและการจัดรูปแบบเช่น TextHolders, TextFrames, Paragraphs และ Portions.|Yes|Yes|
|การเข้าถึงระดับต่ำโดยตรงและเต็มรูปแบบต่อองค์ประกอบ XML ขั้นฐานและแอตทริบิวต์ เช่น ตัวระบุความสัมพันธ์, ตัวระบุรายการของเอกสาร OOXML.|Yes|No|
|<p>การเรนเดอร์:</p><p>- เรนเดอร์การนำเสนอเป็น PDF, PDF Notes, XPS, ภาพ TIFF.</p><p>- เรนเดอร์ภาพย่อสไลด์เป็น PNG, JPEG, BMP, SVG และ TIFF.</p><p>- กำหนดความละเอียดของภาพ, คุณภาพ, การบีบอัดและตัวเลือกอื่น ๆ.</p>|No|Yes|

## **บทสรุป**
Open XML SDK และ Aspose.Slides ไม่ได้แข่งขันกันตรง ๆ เนื่องจากตอบสนองความต้องการและกลุ่มผู้ใช้ที่ต่างกัน Open XML SDK เป็นคลาสไลบรารีที่ให้วิธีการทำงานกับเอกสาร OOXML อย่างแบบ strong‑typed ส่วน Aspose.Slides เป็นไลบรารีการประมวลผลการนำเสนอที่มีประโยชน์อย่างยิ่งและรองรับรูปแบบไฟล์ Microsoft PowerPoint เกือบทั้งหมด หากคุณต้องการทำการเขียนโปรแกรมพื้นฐานบนเอกสาร PPTX เพียงเล็กน้อย Open XML SDK อาจเป็นตัวเลือกที่เหมาะสม กับ Open XML SDK คุณจะสามารถทำงานง่าย ๆ เช่น สร้างเอกสาร PPTX ง่าย ๆ หรือการลบคอมเมนต์, ส่วนหัว/ส่วนท้าย, การสกัดภาพ หรืออื่น ๆ งานบางอย่างทำได้ด้วย Open XML SDK แต่ทำไม่ได้ด้วย Aspose.Slides ตัวอย่างเช่น หากคุณต้องการเข้าถึงองค์ประกอบ XML และแอตทริบิวต์ของเอกสาร OOXML โดยตรง คุณควรใช้ Open XML SDK อย่างไรก็ตาม หากคุณต้องการทำงานที่ซับซ้อนบนเอกสาร เช่น งานต่อไปนี้ การใช้ Aspose.Slides จะเป็นตัวเลือกที่ดีที่สุด:

- รองรับรูปแบบ PowerPoint เก่าเพิ่มเติม นอกเหนือจาก PPTX  
- คัดลอกหรือทำสำเนา shape ภายในสไลด์โดยผสานวัตถุ, สไตล์และการจัดรูปแบบอื่น ๆ อย่างเหมาะสม  
- แทนที่ข้อความที่มีรูปแบบหรือไม่มีก็ได้  
- การใช้แอนิเมชันและการเชื่อมต่อกับ shape ที่ใช้  
- แปลงเอกสารเป็น PDF หรือ XPS เพื่อให้แสดงผลเหมือน Microsoft PowerPoint แปลง  
- พัฒนาแอปพลิเคชัน C++ ทั้งในสภาพแวดล้อมเดสก์ท็อปและคอนโซล