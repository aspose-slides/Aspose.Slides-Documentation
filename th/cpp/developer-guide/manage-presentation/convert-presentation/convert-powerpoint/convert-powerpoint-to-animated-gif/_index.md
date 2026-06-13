---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF เคลื่อนไหวใน C++
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF เคลื่อนไหว
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น GIF
- งานนำเสนอเป็น GIF
- สไลด์เป็น GIF
- PPT เป็น GIF
- PPTX เป็น GIF
- บันทึก PPT เป็น GIF
- บันทึก PPTX เป็น GIF
- ส่งออกรูปแบบ PPT เป็น GIF
- ส่งออกรูปแบบ PPTX เป็น GIF
- การตั้งค่าเริ่มต้น
- การตั้งค่าที่กำหนดเอง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF เคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++ ผลลัพธ์เร็วและมีคุณภาพสูง"
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF แบบเคลื่อนไหวด้วยเพียงไม่กี่บรรทัดของโค้ด สิ่งนี้มีประโยชน์เมื่อคุณต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่เบาและรองรับอย่างกว้างขวาง ซึ่งสามารถฝังในหน้าเว็บ, แอปแชท หรือเอกสารได้ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF ด้วยการตั้งค่าเริ่มต้นและวิธีปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกเช่น ขนาดเฟรม, ความล่าช้าของสไลด์, และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/gifoptions/)  

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

โค้ดตัวอย่างใน C++ นี้แสดงวิธีการแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

GIF แบบเคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น  

{{%  alert  title="เคล็ดลับ"  color="primary"  %}} 

หากคุณต้องการปรับแต่งพารามิเตอร์สำหรับ GIF สามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.gif_options) ดูตัวอย่างโค้ดด้านล่าง  

{{% /alert %}} 

## **แปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าที่กำหนดเอง**

โค้ดตัวอย่างนี้แสดงวิธีการแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่าที่กำหนดเองใน C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// ขนาดของ GIF ที่ได้ผลลัพธ์ 
gifOptions->set_FrameSize(Size(960, 720));
// ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนจะเปลี่ยนเป็นสไลด์ถัดไป
gifOptions->set_DefaultDelay(2000);
// เพิ่ม FPS เพื่อคุณภาพการเคลื่อนที่ของการเปลี่ยนภาพที่ดียิ่งขึ้น
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="ข้อมูล" color="info" %}}

คุณอาจต้องการลองใช้เครื่องมือแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ที่พัฒนาโดย Aspose  

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ถ้าแบบอักษรที่ใช้ในงานนำเสนอไม่ได้ติดตั้งบนระบบจะเป็นอย่างไร?**

ติดตั้งแบบอักษรที่ขาดหายไปหรือ [กำหนดแบบอักษรสำรอง](/slides/th/cpp/powerpoint-fonts/) Aspose.Slides จะทำการแทนที่ให้ แต่รูปลักษณ์อาจแตกต่าง สำหรับการสร้างแบรนด์ควรตรวจสอบให้แน่ใจว่ามีแบบอักษรที่ต้องการพร้อมใช้อย่างชัดเจน  

**ฉันสามารถวางลายน้ำบนเฟรมของ GIF ได้หรือไม่?**

ใช่ เพิ่มวัตถุ/โลโก้ที่มีความโปร่งแสงบางส่วน (/slides/th/cpp/watermark/) ลงบนสไลด์หลักหรือสไลด์แต่ละสไลด์ก่อนส่งออก — ลายน้ำจะปรากฏบนทุกเฟรม  