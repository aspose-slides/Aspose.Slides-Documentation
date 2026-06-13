---
title: จัดการรูปร่างการนำเสนอใน C++
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/cpp/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- ทำสำเนารูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ Interop Shape ID
- ข้อความแทนรูปร่าง
- รูปแบบการจัดวางรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดตำแหน่งรูปร่าง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้การสร้าง, แก้ไขและปรับแต่งรูปร่างใน Aspose.Slides สำหรับ C++ และส่งมอบการนำเสนอ PowerPoint ที่มีประสิทธิภาพสูง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับรูปร่างในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการค้นหารูปร่างบนสไลด์, ทำสำเนารูปร่าง, ลบรูปร่าง, ซ่อนรูปร่าง, เปลี่ยนลำดับการแสดง, รับค่า Interop Shape ID, และตั้งค่า Alternative Text เพื่อระบุตัวและการประมวลผลต่อไป

นอกจากนี้ยังครอบคลุมการเข้าถึง Layout Formats ของรูปร่าง, การเรนเดอร์รูปร่างเป็น SVG, การจัดตำแหน่งรูปร่างบนสไลด์, และการใช้คุณสมบัติ flip สำหรับการสะท้อนแนวนอนและแนวตั้ง อีกทั้งยังมี FAQ สั้น ๆ เกี่ยวกับการรวมรูปร่าง, ลำดับการซ้อนกัน, และการล็อกรูปร่าง

## **ค้นหารูปร่างบนสไลด์**
หัวข้อนี้จะอธิบายเทคนิคง่าย ๆ เพื่อช่วยนักพัฒนาค้นหารูปร่างเฉพาะบนสไลด์โดยไม่ต้องใช้ Id ภายในของมัน การรู้ว่าไฟล์ PowerPoint ไม่มีวิธีระบุตัวรูปร่างบนสไลด์ยกเว้น Id ภายในที่เป็นเอกลักษณ์ทำให้การค้นหาด้วย Id ภายในค่อนข้างยาก รูปร่างทั้งหมดที่เพิ่มลงบนสไลด์จะมี Alt Text เราแนะนำให้นักพัฒนาใช้ Alternative Text เพื่อค้นหารูปร่างเฉพาะ คุณสามารถใช้ MS PowerPoint กำหนด Alternative Text ให้กับวัตถุที่คุณอาจเปลี่ยนแปลงในอนาคตได้

หลังจากตั้งค่า Alternative Text ให้กับรูปร่างที่ต้องการแล้ว คุณสามารถเปิดงานนำเสนอนั้นด้วย Aspose.Slides for C++ และวนลูปผ่านรูปร่างทั้งหมดที่อยู่บนสไลด์ ในแต่ละรอบคุณสามารถตรวจสอบ Alternative Text ของรูปร่างและรูปร่างที่มีข้อความตรงกันจะเป็นรูปร่างที่คุณต้องการ เพื่อแสดงเทคนิคนี้อย่างชัดเจน เราได้สร้างเมธอด [FindShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) ที่ทำหน้าที่ค้นหารูปร่างเฉพาะในสไลด์และคืนค่ารูปร่างนั้น

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **ทำสำเนารูปร่าง**
เพื่อทำสำเนารูปร่างไปยังสไลด์โดยใช้ Aspose.Slides for C++:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึงคอลเล็กชันรูปร่างของสไลด์ต้นฉบับ
4. เพิ่มสไลด์ใหม่ในงานนำเสนอ
5. ทำสำเนารูปร่างจากคอลเล็กชันของสไลด์ต้นฉบับไปยังสไลด์ใหม่
6. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่ม Group Shape ไปยังสไลด์

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **ลบรูปร่าง**
Aspose.Slides for C++ อนุญาตให้นักพัฒนาลบรูปร่างใด ๆ ได้ เพื่อลบรูปร่างจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. เข้าถึงสไลด์แรก
3. ค้นหารูปร่างด้วย AlternativeText ที่กำหนดไว้
4. ลบรูปร่าง
5. บันทึกไฟล์ลงดิสก์

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **ซ่อนรูปร่าง**
Aspose.Slides for C++ อนุญาตให้นักพัฒนาซ่อนรูปร่างใด ๆ ได้ เพื่อลบรูปร่างจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. เข้าถึงสไลด์แรก
3. ค้นหารูปร่างด้วย AlternativeText ที่กำหนดไว้
4. ซ่อนรูปร่าง
5. บันทึกไฟล์ลงดิสก์

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **เปลี่ยนลำดับของรูปร่าง**
Aspose.Slides for C++ อนุญาตให้นักพัฒนาเปลี่ยนลำดับการแสดงของรูปร่าง การเปลี่ยนลำดับระบุว่ารูปร่างใดอยู่ด้านหน้าหรือด้านหลัง เพื่อลำดับรูปร่างจากสไลด์ใดสไลด์หนึ่ง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. เข้าถึงสไลด์แรก
3. เพิ่มรูปร่างหนึ่งรูป
4. ใส่ข้อความใน Text Frame ของรูปร่างนั้น
5. เพิ่มรูปร่างอีกรูปหนึ่งที่มีพิกัดเดียวกัน
6. เปลี่ยนลำดับของรูปร่างเหล่านั้น
7. บันทึกไฟล์ลงดิสก์

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **รับค่า Interop Shape ID**
Aspose.Slides for C++ อนุญาตให้นักพัฒนา รับค่า Identifier ที่เป็นเอกลักษณ์ของรูปร่างในระดับสไลด์ ซึ่งต่างจากคุณสมบัติ UniqueId ที่ให้ค่า Identifier ในระดับงานนำเสนอ คุณสมบัติ OfficeInteropShapeId ถูกเพิ่มให้กับอินเทอร์เฟซ IShape และคลาส Shape ตามลำดับ ค่าที่ได้จาก OfficeInteropShapeId จะสอดคล้องกับค่า Id ของวัตถุ Microsoft.Office.Interop.PowerPoint.Shape ตัวอย่างโค้ดมีดังนี้

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **ตั้งค่าคุณสมบัติ AlternativeText**
Aspose.Slides for C++ อนุญาตให้นักพัฒนาตั้งค่า AlternateText ของรูปร่างใด ๆ ได้ เพื่อตั้งค่า AlternateText ของรูปร่าง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. เข้าถึงสไลด์แรก
3. เพิ่มรูปร่างใด ๆ ลงในสไลด์
4. ทำงานบางอย่างกับรูปร่างที่เพิ่มใหม่
5. วนลูปผ่านรูปร่างเพื่อหารูปร่างที่ต้องการ
6. ตั้งค่า AlternativeText
7. บันทึกไฟล์ลงดิสก์

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **เข้าถึง Layout Formats ของรูปร่าง**
Aspose.Slides for C++ อนุญาตให้นักพัฒนาเข้าถึง Layout Formats ของรูปร่าง บทความนี้สาธิตวิธีเข้าถึงคุณสมบัติ **FillFormat** และ **LineFormat** ของรูปร่าง

ตัวอย่างโค้ดมีดังนี้

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **เรนเดอร์รูปร่างเป็น SVG**
ตอนนี้ Aspose.Slides for C++ รองรับการเรนเดอร์รูปร่างเป็น SVG วิธี WriteAsSvg และการโอเวอร์โหลดของมันได้ถูกเพิ่มเข้าไปในคลาส Shape และอินเทอร์เฟซ IShape วิธีนี้ช่วยบันทึกเนื้อหาของรูปร่างเป็นไฟล์ SVG โค้ดตัวอย่างด้านล่างแสดงวิธีส่งออกรูปร่างของสไลด์เป็นไฟล์ SVG

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **การจัดตำแหน่งรูปร่าง**
Aspose.Slides อนุญาตให้จัดตำแหน่งรูปร่างได้ทั้งสัมพันธ์กับขอบสไลด์หรือสัมพันธ์กับรูปร่างอื่น ๆ เพื่อจุดนี้ได้มีการเพิ่มเมธอดโอเวอร์โหลด [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) และการกำหนดค่าใน enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) เพื่อระบุตัวเลือกการจัดตำแหน่งที่เป็นไปได้

**ตัวอย่างที่ 1**

โค้ดต้นฉบับด้านล่างจัดตำแหน่งรูปร่างที่มีดัชนี 1, 2 และ 4 ให้สอดคล้องกับขอบบนของสไลด์

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**ตัวอย่างที่ 2**

ตัวอย่างด้านล่างแสดงวิธีจัดตำแหน่งคอลเล็กชันทั้งหมดของรูปร่างโดยอิงจากรูปร่างที่อยู่ด้านล่างสุดในคอลเล็กชัน

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **คุณสมบัติ Flip**

ใน Aspose.Slides, คลาส [ShapeFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapeframe/) ให้การควบคุมการสะท้อนแนวนอนและแนวตั้งของรูปร่างผ่านคุณสมบัติ `flipH` และ `flipV` ทั้งสองเป็นประเภท [NullableBool](https://reference.aspose.com/slides/th/cpp/aspose.slides/nullablebool/) ซึ่งรับค่า `True` เพื่อบ่งบอกการพลิก, `False` สำหรับไม่มีการพลิก, หรือ `NotDefined` เพื่อใช้ค่าเริ่มต้น ค่าดังกล่าวสามารถเข้าถึงได้จาก [Frame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_frame/) ของรูปร่าง

เพื่อปรับเปลี่ยนการตั้งค่า flip จะสร้างอินสแตนซ์ใหม่ของ [ShapeFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapeframe/) ด้วยตำแหน่งและขนาดปัจจุบันของรูปร่าง, ค่าที่ต้องการสำหรับ `flipH` และ `flipV`, และมุมการหมุน จากนั้นกำหนดอินสแตนซ์นี้ให้กับ [Frame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_frame/) ของรูปร่างและบันทึกงานนำเสนอ การทำเช่นนี้จะทำให้การสะท้อนเกิดขึ้นและบันทึกลงไฟล์ผลลัพธ์

สมมติว่าเรามีไฟล์ sample.pptx ที่สไลด์แรกมีรูปร่างเดียวที่มีการตั้งค่า flip เริ่มต้นตามด้านล่าง

![รูปร่างที่จะพลิก](shape_to_be_flipped.png)

โค้ดตัวอย่างต่อไปนี้ดึงค่าคุณสมบัติ flip ปัจจุบันของรูปร่างและทำการพลิกทั้งแนวนอนและแนวตั้ง

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// ดึงคุณสมบัติการพลิกแนวนอนของรูปร่าง.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// ดึงคุณสมบัติการพลิกแนวตั้งของรูปร่าง.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // พลิกแนวนอน.
auto flipV = NullableBool::True; // พลิกแนวนอน.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปร่างที่ถูกพลิก](flipped_shape.png)

## **FAQ**

**ฉันสามารถรวมรูปร่าง (union/intersect/subtract) บนสไลด์เหมือนในโปรแกรมแก้ไขเดสก์ท็อปได้หรือไม่?**

ไม่มี API การทำงานแบบ Boolean ในตัว คุณอาจจำลองได้โดยสร้างโครงร่างที่ต้องการด้วยตนเอง—เช่น คำนวณเรขาคณิตผลลัพธ์ (ผ่าน [GeometryPath](https://reference.aspose.com/slides/th/cpp/aspose.slides/geometrypath/)) แล้วสร้างรูปร่างใหม่ด้วยคอนทัวร์นั้น พร้อมกับลบรูปร่างเดิมหากต้องการ

**ฉันจะควบคุมลำดับการซ้อน (z-order) เพื่อให้รูปร่างคงอยู่บนสุดได้อย่างไร?**

เปลี่ยนลำดับการแทรก/ย้ายภายในคอลเล็กชัน [shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseslide/get_shapes/) ของสไลด์ เพื่อให้ได้ผลลัพธ์ที่คาดเดาได้ ควรสรุปลำดับ z-order หลังจากทำการเปลี่ยนแปลงสไลด์ทั้งหมดเสร็จแล้ว

**ฉันสามารถ “ล็อก” รูปร่างเพื่อป้องกันผู้ใช้แก้ไขใน PowerPoint ได้หรือไม่?**

ทำได้ โดยตั้งค่า [shape-level protection flags](/slides/th/cpp/applying-protection-to-presentation/) เช่น การล็อกการเลือก, การย้าย, การปรับขนาด, การแก้ไขข้อความ หากจำเป็นสามารถกำหนดข้อจำกัดบนมาสเตอร์หรือเลย์เอาต์ได้ โปรดทราบว่านี่เป็นการป้องกันระดับ UI ไม่ใช่คุณลักษณะความปลอดภัย; หากต้องการความคุ้มครองที่เข้มงวดกว่า ควรใช้การจำกัดระดับไฟล์ เช่น คำแนะนำให้อ่านอย่างเดียวหรือรหัสผ่าน [/slides/th/cpp/password-protected-presentation/]