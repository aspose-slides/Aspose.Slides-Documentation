---
title: "สร้างภาพตัวอย่างของรูปร่างพรีเซนเทชันใน C++"
linktitle: "ภาพตัวอย่างของรูปร่าง"
type: docs
weight: 70
url: /th/cpp/shape-thumbnails/
keywords:
- "ภาพตัวอย่างของรูปร่าง"
- "รูปภาพของรูปร่าง"
- "การเรนเดอร์รูปร่าง"
- "การเรนเดอร์รูปร่าง"
- "ขอบเขตภาพที่แท้จริง"
- "ขอบเขตของรูปร่าง"
- "PowerPoint"
- "พรีเซนเทชัน"
- "C++"
- "Aspose.Slides"
description: "สร้างภาพตัวอย่างของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for C++ – สร้างและส่งออกภาพตัวอย่างของพรีเซนเทชันได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides ใช้ในการสร้างไฟล์พรีเซนเทชันที่แต่ละหน้าเป็นสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์พรีเซนเทชันด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูภาพของรูปร่างแยกจากกันในโปรแกรมดูภาพ ในกรณีดังกล่าว Aspose.Slides ช่วยคุณสร้างภาพตัวอย่างขนาดย่อของรูปร่างในสไลด์ วิธีการใช้คุณลักษณะนี้อธิบายในบทความนี้  
บทความนี้อธิบายวิธีการสร้างภาพตัวอย่างของสไลด์ในหลายรูปแบบ:

- สร้างภาพตัวอย่างของรูปร่างภายในสไลด์
- สร้างภาพตัวอย่างของรูปร่างสำหรับสไลด์โดยกำหนดมิติเอง
- สร้างภาพตัวอย่างของรูปร่างภายในขอบเขตของการปรากฏของรูปร่าง

## **สร้างภาพตัวอย่างของรูปร่างจากสไลด์**
เพื่อสร้างภาพตัวอย่างของรูปร่างจากสไลด์ใด ๆ โดยใช้ Aspose.Slides for C++:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน  
3. รับภาพตัวอย่างของรูปร่างจากสไลด์ที่อ้างถึงด้วยสเกลค่าเริ่มต้น  
4. บันทึกภาพตัวอย่างเป็นรูปแบบภาพที่ต้องการใด ๆ  

ตัวอย่างด้านล่างเป็นการสร้างภาพตัวอย่างของรูปร่าง

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **สร้างภาพตัวอย่างด้วยปัจจัยสเกลที่กำหนดโดยผู้ใช้**
เพื่อสร้างภาพตัวอย่างของรูปร่างจากสไลด์ใด ๆ โดยใช้ Aspose.Slides for C++:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน  
3. รับภาพตัวอย่างของสไลด์ที่อ้างถึงโดยใช้ขอบเขตของรูปร่าง  
4. บันทึกภาพตัวอย่างเป็นรูปแบบภาพที่ต้องการใด ๆ  

ตัวอย่างด้านล่างสร้างภาพตัวอย่างโดยใช้ปัจจัยสเกลที่กำหนดโดยผู้ใช้

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // การสเกลตามแกน X และ Y

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **สร้างภาพตัวอย่างรูปร่างตามขอบเขตของการแสดงผล**
วิธีนี้สำหรับการสร้างภาพตัวอย่างของรูปร่างช่วยนักพัฒนาให้สร้างภาพตัวอย่างภายในขอบเขตของการแสดงผลของรูปร่าง โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ผลลัพธ์ที่สร้างจะถูกจำกัดด้วยขอบเขตของสไลด์ เพื่อสร้างภาพตัวอย่างของรูปร่างใด ๆ ในขอบเขตการแสดงผล ให้ใช้โค้ดตัวอย่างต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน  
3. รับภาพตัวอย่างของสไลด์ที่อ้างถึงโดยใช้ขอบเขตของรูปร่างเป็นการแสดงผล  
4. บันทึกภาพตัวอย่างเป็นรูปแบบภาพที่ต้องการใด ๆ  

ตัวอย่างด้านล่างสร้างภาพตัวอย่างโดยใช้ปัจจัยสเกลที่กำหนดโดยผู้ใช้

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // การสเกลตามแกน X และ Y

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **รับขอบเขตภาพที่แท้จริงของรูปร่าง**

คุณสมบัติเฟรมของ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, และ `IShape::get_Height()`—อธิบายสี่เหลี่ยมที่เก็บไว้ในโมเดลพรีเซนเทชัน เนื้อหาที่จริง ๆ แล้วถูกเรนเดอร์อาจขยายออกนอกเฟรมหรือครอบคลุมสี่เหลี่ยมที่จัดแนวตามแกนต่างกัน การหมุน, เส้นขอบ, ปลายลูกศร, การจัดวางข้อความและการล้น, เรขาคณิต SmartArt ที่สร้างขึ้น, และเอฟเฟกต์การเรนเดอร์อื่น ๆ สามารถเปลี่ยนพื้นที่ที่ใช้ได้ทั้งหมด

ใช้ [Shape::GetVisualBounds](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getvisualbounds/) เพื่อคำนวณพื้นที่ที่ใช้โดยไม่ต้องสร้างภาพ วิธีนี้จะคืนค่าเป็น [RectangleF](https://reference.aspose.com/slides/th/cpp/system.drawing/rectanglef/) ในพิกัดของสไลด์ สี่เหลี่ยมที่คืนค่าไม่ถูกตัดให้พอดีกับสไลด์ ดังนั้นพิกัดของมันอาจเป็นค่าลบเมื่อเนื้อหาขยายออกนอกต้นกำเนิดของสไลด์

[Shape::GetVisualBounds](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getvisualbounds/) ยังไม่ได้กำหนดในอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ดังนั้นให้เก็บรูปร่างที่ได้จากคอลเลกชันรูปร่างของสไลด์เป็นค่าอินเทอร์เฟซและทำการแคสต์เท่านั้นเมื่อเรียกใช้เมธอด

ตัวอย่างต่อไปนี้จะดึงและเปรียบเทียบเฟรมและขอบเขตภาพที่แท้จริง:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

[RectangleF](https://reference.aspose.com/slides/th/cpp/system.drawing/rectanglef/) เดียวกันสามารถใช้เพื่อจัดตำแหน่งรูปร่างที่อยู่ใกล้เคียงให้สอดรับกับด้าน `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()`, หรือ `RectangleF::get_Bottom()`; สำรองพื้นที่เพียงพอในเลย์เอาต์ที่สร้าง; หรือค้นพบเนื้อหาที่อยู่นอกพื้นที่ที่กำหนดได้ ขอบเขตภาพที่แท้จริงมีประโยชน์เป็นพิเศษสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปร่างที่หมุน, และกลุ่มรูปร่าง ที่เฟรมที่เก็บอาจไม่แทนผลลัพธ์ที่เรนเดอร์ทั้งหมด

ใช้ [Shape::GetVisualBounds](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getvisualbounds/) เมื่อคุณต้องการพิกัดสำหรับการจัดเลย์เอาต์หรือการตรวจสอบและไม่ต้องการบิตแมพ ใช้ [IShape::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/getimage/) เมื่อคุณต้องการเรนเดอร์รูปร่าง ด้วย [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` ปรับขนาดภาพจากขอบเขตของรูปร่างรวมถึงการตั้งค่าเส้นขอบ, ขณะที่ `ShapeThumbnailBounds::Appearance` ปรับขนาดจากการแสดงผลของรูปร่างและจำกัดผลลัพธ์ให้อยู่ในขอบเขตของสไลด์ ในทางตรงกันข้าม, [Shape::GetVisualBounds](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getvisualbounds/) จะคืนเพียงสี่เหลี่ยมที่คำนวณได้และจะไม่ตัดให้พอดีกับสไลด์

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดที่สามารถใช้เมื่อบันทึกภาพตัวอย่างของรูปร่าง?**  
PNG, JPEG, BMP, GIF, TIFF และรูปแบบอื่น ๆ รูปร่างยังสามารถส่งออกเป็นเวกเตอร์ SVG ได้โดยการบันทึกเนื้อหารูปร่างเป็น SVG.

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance เมื่อเรนเดอร์ภาพตัวอย่างคืออะไร?**  
`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` พิจารณา [visual effects](/slides/th/cpp/shape-effect/) (เงา, กลอเน็ท ฯลฯ) เข้ามา.

**ถ้ารูปร่างถูกทำเครื่องหมายว่าเป็น hidden จะเกิดอะไรขึ้น? จะยังคงถูกเรนเดอร์เป็นภาพตัวอย่างหรือไม่?**  
รูปร่างที่ถูกซ่อนยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนมีผลต่อการแสดงสไลด์โชว์แต่ไม่ป้องกันการสร้างภาพของรูปร่าง.

**กลุ่มรูปร่าง, แผนภูมิ, SmartArt และวัตถุซับซ้อนอื่น ๆ รองรับหรือไม่?**  
ใช่. วัตถุใด ๆ ที่เป็น [Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartart/)) สามารถบันทึกเป็นภาพตัวอย่างหรือเป็น SVG.

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพตัวอย่างสำหรับรูปร่างข้อความหรือไม่?**  
ใช่. คุณควร [provide the required fonts](/slides/th/cpp/custom-font/) (หรือ [configure font substitutions](/slides/th/cpp/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองที่ไม่ต้องการและการจัดเรียงข้อความที่ผิดพลาด.