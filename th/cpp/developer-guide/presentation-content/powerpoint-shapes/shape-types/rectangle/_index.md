---
title: เพิ่มสี่เหลี่ยมผืนผ้าในงานนำเสนอด้วย C++
linktitle: สี่เหลี่ยมผืนผ้า
type: docs
weight: 80
url: /th/cpp/rectangle/
keywords:
- เพิ่มสี่เหลี่ยมผืนผ้า
- สร้างสี่เหลี่ยมผืนผ้า
- รูปร่างสี่เหลี่ยมผืนผ้า
- สี่เหลี่ยมผืนผ้าง่าย
- สี่เหลี่ยมผืนผ้าตกแต่ง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เสริมงานนำเสนอ PowerPoint ของคุณด้วยการเพิ่มสี่เหลี่ยมผืนผ้าด้วย Aspose.Slides สำหรับ C++ — ออกแบบและปรับแก้รูปทรงได้อย่างง่ายดายผ่านการเขียนโปรแกรม."
---
## **ภาพรวม**

บทความนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมผืนผ้าไปยังสไลด์ PowerPoint ด้วย Aspose.Slides ครอบคลุมการสร้างสี่เหลี่ยมผืนผ้าง่าย สี่เหลี่ยมผืนผ้าตกแต่ง และการบันทึกงานนำเสนอที่อัปเดตเป็นไฟล์ PPTX

## **สร้างสี่เหลี่ยมผืนผ้าง่าย**
เช่นหัวข้อก่อนหน้า นี้ก็เกี่ยวกับการเพิ่มรูปทรงและครั้งนี้เราจะพูดถึงสี่เหลี่ยมผืนผ้า ในหัวข้อนี้เราได้อธิบายว่าผู้พัฒนาสามารถเพิ่มสี่เหลี่ยมผืนผ้าง่ายหรือสี่เหลี่ยมผืนผ้าตกแต่งลงในสไลด์โดยใช้ Aspose.Slides for C++ เพื่อเพิ่มสี่เหลี่ยมผืนผ้าง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [คลาส Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).
2. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
3. เพิ่ม IAutoShape ประเภท Rectangle โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้โดยอ็อบเจ็กต์ IShapes.
4. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่าง เราได้เพิ่มสี่เหลี่ยมผืนผ้าง่ายลงในสไลด์แรกของงานนำเสนอ.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **สร้างสี่เหลี่ยมผืนผ้าตกแต่ง**
เพื่อเพิ่มสี่เหลี่ยมผืนผ้าตกแต่งลงในสไลด์ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ [คลาส Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).
2. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
3. เพิ่ม IAutoShape ประเภท Rectangle โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้โดยอ็อบเจ็กต์ IShapes.
4. ตั้งค่า Fill Type ของสี่เหลี่ยมผืนผ้าเป็น Solid.
5. ตั้งค่าสีของสี่เหลี่ยมผืนผ้าโดยใช้คุณสมบัติ SolidFillColor.Color ที่เปิดให้ใช้โดยอ็อบเจ็กต์ FillFormat ที่เชื่อมโยงกับอ็อบเจ็กต์ IShape.
6. ตั้งค่าสีของเส้นของสี่เหลี่ยมผืนผ้า.
7. ตั้งค่าความกว้างของเส้นของสี่เหลี่ยมผืนผ้า.
8. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

ขั้นตอนข้างต้นได้ถูกนำไปใช้ในตัวอย่างด้านล่าง.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **คำถามที่พบบ่อย**

**ฉันจะเพิ่มสี่เหลี่ยมผืนผ้ามีมุมโค้งได้อย่างไร?**

ใช้ [ประเภท shape]แบบมุมโค้ง(https://reference.aspose.com/slides/th/cpp/aspose.slides/shapetype/)และปรับค่ารัศมีของมุมในคุณสมบัติของ shape; สามารถทำมุมโค้งแยกตามแต่ละมุมได้โดยการปรับค่า geometry.

**ฉันจะเติมสี่เหลี่ยมผืนผ้าด้วยภาพ (texture) อย่างไร?**

เลือก [fill type]ของภาพ(https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/), ระบุแหล่งที่มาของภาพ, และกำหนด [stretching/tiling modes](https://reference.aspose.com/slides/th/cpp/aspose.slides/picturefillmode/).

**สี่เหลี่ยมผืนผ้าสามารถมีเงาและแสงเรืองแสงได้หรือไม่?**

ได้. [Outer/inner shadow, glow, and soft edges](/slides/th/cpp/shape-effect/) มีให้ใช้พร้อมพารามิเตอร์ที่ปรับได้.

**ฉันสามารถเปลี่ยนสี่เหลี่ยมผืนผ้าให้เป็นปุ่มที่มี hyperlink ได้หรือไม่?**

ได้. [Assign a hyperlink](/slides/th/cpp/manage-hyperlinks/) ให้กับการคลิก shape (กระโดดไปยังสไลด์, ไฟล์, ที่อยู่เว็บ, หรืออีเมล).

**ฉันจะปกป้องสี่เหลี่ยมผืนผ้าจากการเคลื่อนที่และการเปลี่ยนแปลงได้อย่างไร?**

[Use shape locks](/slides/th/cpp/applying-protection-to-presentation/): คุณสามารถห้ามการเคลื่อนที่, ปรับขนาด, การเลือก, หรือการแก้ไขข้อความเพื่อรักษาเลย์เอาต์.

**ฉันสามารถแปลงสี่เหลี่ยมผืนผ้าเป็นภาพราสเตอร์หรือ SVG ได้หรือไม่?**

ได้. คุณสามารถ [render the shape](http://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getimage/) ไปเป็นภาพที่มีขนาด/สเกลที่กำหนดหรือ [export it as SVG](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/writeassvg/) เพื่อใช้งานเวกเตอร์.

**ฉันจะได้คุณสมบัติจริง (effective) ของสี่เหลี่ยมผืนผ้าอย่างรวดเร็วโดยคำนึงถึงธีมและการสืบทอดได้อย่างไร?**

[Use the shape’s effective properties](/slides/th/cpp/shape-effective-properties/): API จะคืนค่าที่คำนวณแล้วซึ่งรวมสไตล์ของธีม, เลเอาต์, และการตั้งค่าท้องถิ่น ทำให้การวิเคราะห์การจัดรูปแบบง่ายขึ้น.