---
title: จัดการกราฟิก SmartArt ในงานนำเสนอด้วย C++
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/cpp/manage-smartart-shape/
keywords:
- วัตถุ SmartArt
- กราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยน SmartArt
- เข้าถึง SmartArt
- ประเภทเลย์เอาต์ SmartArt
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานอัตโนมัติสำหรับการสร้าง, แก้ไขและจัดสไตล์ SmartArt ของ PowerPoint ด้วย C++ ผ่าน Aspose.Slides พร้อมตัวอย่างโค้ดสั้นและคำแนะนำที่มุ่งเน้นประสิทธิภาพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถสร้างและจัดการกราฟิก SmartArt ในงานนำเสนอ PowerPoint ผ่านโปรแกรมได้ บทความนี้อธิบายวิธีเพิ่มรูปแบบ SmartArt ลงในสไลด์ การเข้าถึงรูปแบบ SmartArt ที่มีอยู่ การค้นหา SmartArt ตามประเภทเลย์เอาต์เฉพาะ และการอัปเดตลักษณะการแสดงผลโดยการเปลี่ยนสไตล์หรือสไตล์สีของ SmartArt

ตัวอย่างแสดงวิธีทำงานกับรูปแบบ SmartArt ผ่านคอลเลกชันรูปทรงของสไลด์ ตรวจสอบว่ารูปทรงเป็น SmartArt หรือไม่ แล้วจึงแก้ไขหรือสำรวจคุณสมบัติของมัน

## **สร้างรูปแบบ SmartArt**
Aspose.Slides for C++ ตอนนี้สนับสนุนการเพิ่มรูปแบบ SmartArt แบบกำหนดเองในสไลด์ตั้งแต่ต้น Aspose.Slides for C++ มี API ที่ง่ายที่สุดในการสร้างรูปแบบ SmartArt อย่างสะดวก เพื่อติดตั้งรูปแบบ SmartArt ในสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของ[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)คลาส
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่มรูปแบบ SmartArt โดยกำหนด LayoutType
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **เข้าถึงรูปแบบ SmartArt บนสไลด์**
โค้ดต่อไปนี้จะใช้เพื่อเข้าถึงรูปร่าง SmartArt ที่เพิ่มในสไลด์ของงานนำเสนอ ในตัวอย่างโค้ดเราจะวนผ่านทุกรูปทรงภายในสไลด์และตรวจสอบว่ามันเป็นรูปแบบ SmartArt หรือไม่ หากเป็นประเภท SmartArt เราจะทำการแปลงประเภทเป็นอินสแตนซ์ SmartArt

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **เข้าถึงรูปแบบ SmartArt ด้วย Layout Type เฉพาะ**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงรูปแบบ SmartArt ด้วย LayoutType ที่กำหนด โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้เนื่องจากเป็นค่าอ่านอย่างเดียวและกำหนดเมื่อตอนเพิ่มรูปแบบ SmartArt

- สร้างอินสแตนซ์ของ`Presentation`คลาสและโหลดงานนำเสนอที่มีรูปแบบ SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านทุกรูปทรงภายในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt และทำการ Typecast รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
- ตรวจสอบรูปแบบ SmartArt ด้วย LayoutType ที่กำหนดและดำเนินการตามที่ต้องการต่อไป

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **เปลี่ยนสไตล์ของรูปแบบ SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้เข้าถึงรูปแบบ SmartArt ด้วย LayoutType ที่กำหนด

- สร้างอินสแตนซ์ของ`Presentation`คลาสและโหลดงานนำเสนอที่มีรูปแบบ SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านทุกรูปทรงภายในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt และทำการ Typecast รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
- ค้นหารูปแบบ SmartArt ด้วยสไตล์เฉพาะ
- ตั้งค่าสไตล์ใหม่ให้กับรูปแบบ SmartArt
- บันทึกงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **เปลี่ยนสไตล์สีของรูปแบบ SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การเปลี่ยนสไตล์สีของรูปแบบ SmartArt ใด ๆ โค้ดตัวอย่างต่อไปนี้จะเข้าถึงรูปแบบ SmartArt ด้วยสไตล์สีที่กำหนดและเปลี่ยนสไตล์นั้น

- สร้างอินสแตนซ์ของ`Presentation`คลาสและโหลดงานนำเสนอที่มีรูปแบบ SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านทุกรูปทรงภายในสไลด์แรก
- ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt และทำการ Typecast รูปทรงที่เลือกเป็น SmartArt หากเป็น SmartArt
- ค้นหารูปแบบ SmartArt ด้วยสไตล์สีที่กำหนด
- ตั้งค่าสไตล์สีใหม่ให้กับรูปแบบ SmartArt
- บันทึกงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **คำถามที่พบบ่อย**

**ฉันสามารถทำแอนิเมชันให้ SmartArt เป็นออบเจ็กต์เดียวได้หรือไม่?**

ได้ครับ SmartArt เป็นรูปทรงหนึ่ง สามารถใช้ [standard animations](/slides/th/cpp/powerpoint-animation/) ผ่าน API แอนิเมชัน (เข้าออก, เน้น, เส้นทางการเคลื่อนที่) เหมือนกับรูปทรงอื่น ๆ

**ฉันจะหา SmartArt เฉพาะบนสไลด์ได้อย่างไรหากไม่รู้ ID ภายใน?**

กำหนดและใช้ Alternative Text (AltText) แล้วค้นหารูปทรงตามค่าดังกล่าว—นี่เป็นวิธีที่แนะนำให้ค้นหาเป้าหมาย

**ฉันสามารถจัดกลุ่ม SmartArt กับรูปทรงอื่น ๆ ได้หรือไม่?**

ได้ คุณสามารถจัดกลุ่ม SmartArt กับรูปทรงอื่น ๆ (รูปภาพ, ตาราง ฯลฯ) แล้ว [manipulate the group](/slides/th/cpp/group/)

**ฉันจะดึงรูปภาพของ SmartArt เฉพาะ (เช่นสำหรับพรีวิวหรือรายงาน) อย่างไร?**

ส่งออกภาพขนาดย่อ/รูปภาพของรูปทรง; ไลบรารีสามารถ [render individual shapes](/slides/th/cpp/create-shape-thumbnails/) ไปเป็นไฟล์ราสเตอร์ (PNG/JPG/TIFF)

**ลักษณะของ SmartArt จะคงที่เมื่อแปลงงานนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ใช่ เครื่องมือเรนเดอร์มุ่งเน้นความเที่ยงตรงสูงสำหรับ [PDF export](/slides/th/cpp/convert-powerpoint-to-pdf/) พร้อมตัวเลือกคุณภาพและความเข้ากันได้หลายระดับ