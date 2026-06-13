---
title: จัดการโหนดรูปร่าง SmartArt ในงานนำเสนอโดยใช้ C++
linktitle: โหนดรูปร่าง SmartArt
type: docs
weight: 30
url: /th/cpp/manage-smartart-shape-node/
keywords:
- โหนด SmartArt
- โหนดลูก
- เพิ่มโหนด
- ตำแหน่งโหนด
- เข้าถึงโหนด
- ลบโหนด
- ตำแหน่งกำหนดเอง
- โหนดผู้ช่วย
- รูปแบบการเติม
- เรนเดอร์โหนด
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการโหนดรูปร่าง SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides สำหรับ C++ พร้อมตัวอย่างโค้ดที่ชัดเจนและเคล็ดลับเพื่อทำให้งานนำเสนอของคุณเป็นระบบระเบียบมากขึ้น."
---
## **ภาพรวม**

กราฟิก SmartArt ในงานนำเสนอ PowerPoint ถูกจัดระเบียบผ่านโหนดที่มีข้อความและกำหนดโครงสร้างของแผนภาพ Aspose.Slides ช่วยให้คุณทำงานกับโหนด SmartArt เหล่านี้ด้วยโปรแกรมได้: เพิ่มโหนดและโหนดลูกใหม่, แทรกโหนดลูกในตำแหน่งเฉพาะ, เข้าถึงโหนดที่มีอยู่, และอ่านข้อความ, ระดับ, และตำแหน่งของมัน

บทความนี้อธิบายวิธีจัดการโหนดของรูปร่าง SmartArt แสดงวิธีลบโหนด, ทำงานกับโหนดลูกโดยใช้ดัชนีหรือตำแหน่ง, เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ, ปรับตำแหน่ง, ขนาด, และการหมุนของรูปร่างโหนด SmartArt, ตั้งค่ารูปแบบการเติมของโหนด, และสร้างภาพขนาดย่อสำหรับโหนดลูกของ SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides สำหรับ C++ มี API ที่ง่ายที่สุดในการจัดการรูปร่าง SmartArt อย่างง่าย ด้านล่างเป็นตัวอย่างโค้ดที่จะช่วยเพิ่มโหนดและโหนดลูกภายในรูปร่าง SmartArt

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- เดินทางผ่านรูปร่างทุกรูปในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- เพิ่ม Node ใหม่ใน NodeCollection ของรูปร่าง SmartArt และตั้งค่าข้อความใน TextFrame
- จากนั้น เพิ่มโหนดลูกใน SmartArt Node ที่เพิ่งเพิ่มและตั้งค่าข้อความใน TextFrame
- บันทึกงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **เพิ่มโหนด SmartArt ที่ตำแหน่งเฉพาะ**
ในโค้ดตัวอย่างต่อไปนี้ เราได้อธิบายวิธีเพิ่มโหนดลูกที่เป็นของโหนดที่เกี่ยวข้องของรูปร่าง SmartArt ในตำแหน่งเฉพาะ

- สร้างอินสแตนซ์ของ `Presentation` class.
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน.
- เพิ่มรูปร่าง SmartArt ประเภท StackedList ในสไลด์ที่เข้าถึง
- เข้าถึงโหนดแรกในรูปร่าง SmartArt ที่เพิ่ม
- จากนั้น เพิ่มโหนดลูกสำหรับโหนดที่เลือกที่ตำแหน่ง 2 และตั้งค่าข้อความของมัน
- บันทึกงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **เข้าถึงโหนด SmartArt**
โค้ดตัวอย่างต่อไปนี้จะช่วยให้เข้าถึงโหนดภายในรูปร่าง SmartArt โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้เนื่องจากเป็นแบบอ่านอย่างเดียวและจะถูกตั้งค่าเฉพาะเมื่อเพิ่มรูปร่าง SmartArt

- สร้างอินสแตนซ์ของ `Presentation` class และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- เดินทางผ่านรูปร่างทุกรูปในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- เดินทางผ่านโหนดทั้งหมดภายในรูปร่าง SmartArt
- เข้าถึงและแสดงข้อมูลเช่นตำแหน่งโหนด SmartArt, ระดับ และข้อความ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **เข้าถึงโหนดลูกของ SmartArt**
โค้ดตัวอย่างต่อไปนี้จะช่วยให้เข้าถึงโหนดลูกที่เป็นของโหนดที่เกี่ยวข้องของรูปร่าง SmartArt

- สร้างอินสแตนซ์ของคลาส PresentationEx และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- เดินทางผ่านรูปร่างทุกรูปในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปร่างที่เลือกเป็น SmartArtEx หากเป็น SmartArt
- เดินทางผ่านโหนดทั้งหมดภายในรูปร่าง SmartArt
- สำหรับโหนดรูปร่าง SmartArt ที่เลือกแต่ละอัน ให้เดินทางผ่านโหนดลูกทั้งหมดภายในโหนดนั้น
- เข้าถึงและแสดงข้อมูลเช่นตำแหน่งโหนดลูก, ระดับ และข้อความ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **เข้าถึงโหนดลูกของ SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้วิธีเข้าถึงโหนดลูกในตำแหน่งบางตำแหน่งที่เป็นของโหนดที่เกี่ยวข้องของรูปร่าง SmartArt

- สร้างอินสแตนซ์ของ `Presentation` class.
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน.
- เพิ่มรูปร่าง SmartArt ประเภท StackedList.
- เข้าถึงรูปร่าง SmartArt ที่เพิ่ม
- เข้าถึงโหนดที่ดัชนี 0 ของรูปร่าง SmartArt ที่เข้าถึง
- จากนั้น เข้าถึงโหนดลูกที่ตำแหน่ง 1 ของโหนด SmartArt ที่เข้าถึงโดยใช้เมธอด GetNodeByPosition()
- เข้าถึงและแสดงข้อมูลเช่นตำแหน่งโหนดลูก, ระดับ และข้อความ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **ลบโหนด SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้วิธีลบโหนดภายในรูปร่าง SmartArt

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- เดินทางผ่านรูปร่างทุกรูปในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- ตรวจสอบว่า SmartArt มีโหนดมากกว่า 0 โหนดหรือไม่
- เลือกโหนด SmartArt ที่จะลบ
- จากนั้น ลบโหนดที่เลือกโดยใช้เมธอด RemoveNode() แล้วบันทึกงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **ลบโหนด SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้วิธีลบโหนดภายในรูปร่าง SmartArt ที่ตำแหน่งเฉพาะ

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- เดินทางผ่านรูปร่างทุกรูปในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- เลือกโหนดรูปร่าง SmartArt ที่ดัชนี 0
- จากนั้น ตรวจสอบว่าโหนด SmartArt ที่เลือกมีโหนดลูกมากกว่า 2 โหนดหรือไม่
- จากนั้น ลบโหนดที่ตำแหน่ง 1 โดยใช้เมธอด RemoveNodeByPosition()
- บันทึกงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโหนดลูกของ SmartArt**
ตอนนี้ Aspose.Slides รองรับการตั้งค่าคุณสมบัติ X และ Y ของ SmartArtShape โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าตำแหน่ง, ขนาดและการหมุนของ SmartArtShape ตามกำหนด โปรดทราบว่าการเพิ่มโหนดใหม่ทำให้ตำแหน่งและขนาดของโหนดทั้งหมดถูกคำนวณใหม่

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **ตรวจสอบโหนดผู้ช่วย**
ในโค้ดตัวอย่างต่อไปนี้ เราจะตรวจสอบวิธีระบุโหนดผู้ช่วยในคอลเลกชันโหนด SmartArt และการเปลี่ยนแปลงพวกมัน

- สร้างอินสแตนซ์ของคลาส PresentationEx และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
- รับอ้างอิงของสไลด์ที่สองโดยใช้ Index ของมัน
- เดินทางผ่านรูปร่างทุกรูปในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และทำ Typecast รูปร่างที่เลือกเป็น SmartArtEx หากเป็น SmartArt
- เดินทางผ่านโหนดทั้งหมดในรูปร่าง SmartArt และตรวจสอบว่าพวกมันเป็นโหนดผู้ช่วยหรือไม่
- เปลี่ยนสถานะของโหนดผู้ช่วยเป็นโหนดปกติ
- บันทึกงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **ตั้งค่ารูปแบบการเติมของโหนด**
Aspose.Slides สำหรับ C++ ทำให้สามารถเพิ่มรูปร่าง SmartArt แบบกำหนดเองและตั้งค่าการเติมของพวกมันได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปร่าง SmartArt และตั้งค่าการเติมโดยใช้ Aspose.Slides สำหรับ C++

- สร้างอินสแตนซ์ของคลาส `Presentation`
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- เพิ่มรูปร่าง SmartArt โดยตั้งค่า LayoutType ของมัน
- ตั้งค่า FillFormat สำหรับโหนดของรูปร่าง SmartArt
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **สร้างภาพขนาดย่อของโหนดลูก SmartArt**
นักพัฒนาสามารถสร้างภาพขนาดย่อของโหนดลูกของ SmartArt ได้โดยทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation` ที่แทนไฟล์ PPTX
2. เพิ่ม SmartArt
3. รับอ้างอิงของโหนดโดยใช้ Index ของมัน
4. รับภาพขนาดย่อ
5. บันทึกภาพขนาดย่อในรูปแบบภาพที่ต้องการ

ตัวอย่างด้านล่างสร้างภาพขนาดย่อของโหนดลูกของ SmartArt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**SmartArt animation ถูกสนับสนุนหรือไม่?**

ใช่. SmartArt ถูกจัดเป็นรูปทรงปกติ ดังนั้นคุณจึงสามารถ [ใช้แอนิเมชันมาตรฐาน](/slides/th/cpp/shape-animation/) (การเข้ามา, การออก, การเน้น, เส้นทางการเคลื่อนที่) และปรับเวลาได้ คุณยังสามารถทำให้รูปทรงภายในโหนด SmartArt มีการเคลื่อนไหวได้เมื่อจำเป็น

**ฉันจะหาตำแหน่ง SmartArt เฉพาะบนสไลด์ได้อย่างมั่นใจหากไม่ทราบ ID ภายในได้อย่างไร?**

กำหนดและค้นหาโดยใช้ [ข้อความแทน](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/set_alternativetext/). การตั้งค่า AltText ที่โดดเด่นบน SmartArt ช่วยให้คุณค้นหาได้ด้วยโปรแกรมโดยไม่ต้องอ้างอิงถึงตัวระบุภายใน

**ลักษณะของ SmartArt จะถูกเก็บไว้เมื่อแปลงงานนำเสนอเป็น PDF หรือไม่?**

ใช่. Aspose.Slides เรนเดอร์ SmartArt ด้วยความละเอียดภาพสูงระหว่าง [การส่งออกเป็น PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), รักษาเลย์เอาต์, สี, และเอฟเฟกต์

**ฉันสามารถดึงภาพของ SmartArt ทั้งหมด (สำหรับภาพตัวอย่างหรือรายงาน) ได้หรือไม่?**

ใช่. คุณสามารถเรนเดอร์รูปร่าง SmartArt ไปยัง [รูปแบบแรสเตอร์](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getimage/) หรือไปยัง [SVG](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/writeassvg/) สำหรับผลลัพธ์เวกเตอร์ที่ขยายได้ ทำให้เหมาะสำหรับภาพขนาดย่อ, รายงาน, หรือการใช้งานบนเว็บ