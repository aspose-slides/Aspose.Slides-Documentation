---
title: สร้างภาพขนาดย่อของรูปทรงงานนำเสนอใน C++
linktitle: ภาพขนาดย่อของรูปทรง
type: docs
weight: 70
url: /th/cpp/shape-thumbnails/
keywords:
- ภาพขนาดย่อของรูปทรง
- ภาพของรูปทรง
- เรนเดอร์รูปทรง
- การเรนเดอร์รูปทรง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "สร้างภาพขนาดย่อของรูปทรงคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for C++ – สร้างและส่งออกภาพขนาดย่อของงานนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides ใช้สร้างไฟล์งานนำเสนอซึ่งแต่ละหน้าเป็นสไลด์ สไลด์เหล่านี้สามารถดูได้โดยเปิดไฟล์งานนำเสนอด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูภาพของรูปทรงแยกต่างหากในโปรแกรมดูภาพ ในกรณีดังกล่าว Aspose.Slides ช่วยคุณสร้างภาพขนาดย่อของรูปทรงสไลด์ วิธีการใช้คุณลักษณะนี้อธิบายในบทความนี้  
บทความนี้อธิบายวิธีสร้างภาพขนาดย่อของสไลด์ในหลายวิธี:

- สร้างภาพขนาดย่อของรูปทรงภายในสไลด์
- สร้างภาพขนาดย่อของรูปทรงสำหรับรูปทรงสไลด์โดยกำหนดขนาดตามผู้ใช้
- สร้างภาพขนาดย่อของรูปทรงภายในขอบเขตของลักษณะการแสดงผลของรูปทรง

## **สร้างภาพขนาดย่อของรูปทรงจากสไลด์**

เพื่อสร้างภาพขนาดย่อของรูปทรงจากสไลด์ใด ๆ ด้วย Aspose.Slides for C++:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. รับออปเจ็กต์อ้างอิงของสไลด์ใด ๆ ด้วย ID หรือดัชนีของมัน
3. ดึงภาพขนาดย่อของรูปทรงจากสไลด์อ้างอิงด้วยสเกลเริ่มต้น
4. บันทึกภาพขนาดย่อไปยังรูปแบบภาพที่ต้องการใดก็ได้

ตัวอย่างด้านล่างแสดงการสร้างภาพขนาดย่อของรูปทรง

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **สร้างภาพขนาดย่อด้วยปัจจัยการสเกลที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพขนาดย่อของรูปทรงสไลด์ใด ๆ ด้วย Aspose.Slides for C++:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. รับออปเจ็กต์อ้างอิงของสไลด์ใด ๆ ด้วย ID หรือดัชนีของมัน
3. ดึงภาพขนาดย่อของสไลด์อ้างอิงโดยใช้ขอบเขตของรูปทรง
4. บันทึกภาพขนาดย่อในรูปแบบภาพที่ต้องการใดก็ได้

ตัวอย่างด้านล่างแสดงการสร้างภาพขนาดย่อด้วยปัจจัยการสเกลที่กำหนดโดยผู้ใช้

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // การสเกลตามแกน X และ Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **สร้างภาพขนาดย่อของรูปทรงตามขอบเขตของลักษณะการแสดงผล**

วิธีนี้สำหรับการสร้างภาพขนาดย่อของรูปทรงช่วยให้นักพัฒนาสร้างภาพขนาดย่อภายในขอบเขตของลักษณะการแสดงผลของรูปทรง โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปทรง ภาพขนาดย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อสร้างภาพขนาดย่อของรูปทรงสไลด์ใด ๆ ตามขอบเขตของลักษณะการแสดงผล ให้ใช้ตัวอย่างโค้ดต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. รับออปเจ็กต์อ้างอิงของสไลด์ใด ๆ ด้วย ID หรือดัชนีของมัน
3. ดึงภาพขนาดย่อของสไลด์อ้างอิงโดยใช้ขอบเขตของรูปทรงเป็นลักษณะการแสดงผล
4. บันทึกภาพขนาดย่อในรูปแบบภาพที่ต้องการใดก็ได้

ตัวอย่างด้านล่างแสดงการสร้างภาพขนาดย่อโดยกำหนดปัจจัยการสเกลตามผู้ใช้

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // การสเกลตามแกน X และ Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพขนาดย่อของรูปทรง?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/cpp/aspose.slides/imageformat/), และอื่น ๆ รูปทรงยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/writeassvg/) โดยบันทึกเนื้อหาของรูปทรงเป็น SVG.

**ความแตกต่างระหว่างขอบเขต Shape กับ Appearance เมื่อเรนเดอร์ภาพขนาดย่อคืออะไร?**  
`Shape` ใช้รูปทรงเรขาคณิตของรูปทรง; `Appearance` พิจารณา [เอฟเฟกต์ภาพ](/slides/th/cpp/shape-effect/) (เงา, แสงเรืองแสง, ฯลฯ) เข้าไว้ด้วย

**จะเกิดอะไรขึ้นหากรูปทรงถูกทำเครื่องหมายว่า hidden? จะยังคงเรนเดอร์เป็นภาพขนาดย่อหรือไม่?**  
รูปทรงที่ถูกซ่อนยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธง hidden มีผลต่อการแสดงสไลด์โชว์แต่ไม่ป้องกันการสร้างภาพของรูปทรง

**รูปกลุ่ม, แผนภูมิ, SmartArt, และวัตถุซับซ้อนอื่น ๆ รองรับหรือไม่?**  
ใช่. วัตถุใด ๆ ที่เป็นตัวแทนเป็น [Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartart/)) สามารถบันทึกเป็นภาพขนาดย่อหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพขนาดย่อสำหรับรูปทรงข้อความหรือไม่?**  
ใช่. คุณควร [จัดหาฟอนต์ที่ต้องการ](/slides/th/cpp/custom-font/) (หรือ [กำหนดการทดแทนฟอนต์](/slides/th/cpp/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองที่ไม่ต้องการและการเปลี่ยนแปลงการเรียงข้อความ.