---
title: จัดการข้อความยกเหนือและยกใต้ในงานนำเสนอด้วย C++
linktitle: ยกเหนือและยกใต้
type: docs
weight: 80
url: /th/cpp/superscript-and-subscript/
keywords:
- ยกเหนือ
- ยกใต้
- เพิ่มยกเหนือ
- เพิ่มยกใต้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เชี่ยวชาญการใช้ยกเหนือและยกใต้ใน Aspose.Slides สำหรับ C++ และยกระดับงานนำเสนอของคุณด้วยการจัดรูปแบบข้อความระดับมืออาชีพเพื่อให้ได้ผลกระทบสูงสุด."
---
## **ภาพรวม**

Aspose.Slides มีคุณสมบัติสำหรับผสานข้อความยกเหนือและยกใต้ลงในงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ของคุณ ไม่ว่าคุณจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรืออธิบายเนื้อหาด้วยเชิงอรรถ ตัวเลือกการจัดรูปแบบเฉพาะเหล่านี้ช่วยให้รักษาความชัดเจนและความแม่นยำได้อย่างดี ในบทความนี้ คุณจะได้เรียนรู้วิธีการใช้สไตล์ยกเหนือและยกใต้โดยต่อเนื่องและทำให้ผลลัพธ์ของแต่ละสไลด์ดูเป็นมืออาชีพ

## **จัดการข้อความยกเหนือและยกใต้**

คุณสามารถเพิ่มข้อความยกเหนือและยกใต้ได้ในส่วนของย่อหน้าที่ใดก็ได้ เพื่อเพิ่มข้อความยกเหนือหรือยกใตในกรอบข้อความของ Aspose.Slides ต้องใช้คุณสมบัติ **Escapement** ของคลาส PortionFormat

คุณสมบัตินี้คืนค่า หรือกำหนดค่าข้อความยกเหนือหรือยกใต้ (ค่าตั้งแต่ -100% (ยกใต้) ถึง 100% (ยกเหนือ)). ตัวอย่างเช่น :

- สร้างอินสแตนซ์ของคลาส [การนำเสนอ](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม IAutoShape ประเภท Rectangle ลงในสไลด์
- เข้าถึง ITextFrame ที่เชื่อมโยงกับ IAutoShape
- ลบ Paragraphs ที่มีอยู่
- สร้างอ็อบเจกต์ paragraph ใหม่เพื่อเก็บข้อความยกเหนือและเพิ่มเข้าไปในคอลเลกชัน IParagraphs ของ ITextFrame
- สร้างอ็อบเจกต์ portion ใหม่
- ตั้งค่าคุณสมบัติ Escapement สำหรับ portion ระหว่าง 0 ถึง 100 เพื่อเพิ่มข้อความยกเหนือ (0 หมายถึงไม่มีการยกเหนือ)
- กำหนดข้อความบางส่วนให้กับ Portion แล้วเพิ่มลงในคอลเลกชัน portion ของ paragraph
- สร้างอ็อบเจกต์ paragraph ใหม่เพื่อเก็บข้อความยกใต้และเพิ่มเข้าไปในคอลเลกชัน IParagraphs ของ ITextFrame
- สร้างอ็อบเจกต์ portion ใหม่
- ตั้งค่าคุณสมบัติ Escapement สำหรับ portion ระหว่าง 0 ถึง -100 เพื่อเพิ่มข้อความยกใต้ (0 หมายถึงไม่มีการยกใต้)
- กำหนดข้อความบางส่วนให้กับ Portion แล้วเพิ่มลงในคอลเลกชัน portion ของ paragraph
- บันทึกการนำเสนอเป็นไฟล์ PPTX

การทำงานตามขั้นตอนข้างต้นแสดงด้านล่างนี้.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **คำถามที่พบบ่อย**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**

ใช่, Aspose.Slides จะรักษาการจัดรูปแบบข้อความยกเหนือและยกใต้ได้อย่างถูกต้องเมื่อนำการนำเสนอออกเป็น PDF, PPT/PPTX, รูปภาพ และรูปแบบที่รองรับอื่น ๆ การจัดรูปแบบเฉพาะนี้จะคงอยู่ในไฟล์ผลลัพธ์ทั้งหมด.

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**

ใช่, Aspose.Slides อนุญาตให้ผสมสไตล์ข้อความต่าง ๆ ภายใน portion เดียว คุณสามารถเปิดใช้ตัวหนา, ตัวเอียง, ขีดเส้นใต้ และพร้อมกันใช้ยกเหนือหรือยกใตได้โดยกำหนดคุณสมบัติตรงกันใน [PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/).

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**

ใช่, Aspose.Slides รองรับการจัดรูปแบบภายในวัตถุส่วนใหญ่ รวมถึงตารางและส่วนของแผนภูมิ เมื่อทำงานกับ SmartArt คุณต้องเข้าถึงองค์ประกอบที่เหมาะสม (เช่น [SmartArtNode](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartnode/)) และคอนเทนเนอร์ข้อความของมัน แล้วกำหนดคุณสมบัติ [PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/) ในลักษณะเดียวกัน.