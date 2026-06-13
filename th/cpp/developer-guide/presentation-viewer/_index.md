---
title: สร้างตัวดูงานนำเสนอใน C++
linktitle: ตัวดูงานนำเสนอ
type: docs
weight: 50
url: /th/cpp/presentation-viewer/
keywords:
- ดูงานนำเสนอ
- ตัวดูงานนำเสนอ
- สร้างตัวดูงานนำเสนอ
- ดู PPT
- ดู PPTX
- ดู ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "สร้างตัวดูงานนำเสนอแบบกำหนดเองใน C++ ด้วย Aspose.Slides แสดงไฟล์ PowerPoint และ OpenDocument ได้อย่างง่ายดายโดยไม่ต้องใช้ Microsoft PowerPoint."
---
## **บทนำ**

Aspose.Slides สำหรับ C++ ใช้สำหรับสร้างไฟล์งานนำเสนอที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดงานนำเสนอใน Microsoft PowerPoint ตัวอย่างเช่น อย่างไรก็ตาม บางครั้งนักพัฒนาอาจต้องการดูสไลด์เป็นภาพในโปรแกรมดูภาพที่ต้องการ หรือสร้างโปรแกรมดูงานนำเสนอของตนเอง ในกรณีเช่นนี้ Aspose.Slides ให้คุณส่งออกสไลด์เดี่ยวเป็นภาพ บทความนี้อธิบายวิธีทำ

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์งานนำเสนอด้วย Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. เปิดสตรีมไฟล์
1. บันทึกสไลด์เป็นภาพ SVG ไปยังสตรีมไฟล์

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **สร้าง SVG ด้วย ID รูปร่างที่กำหนดเอง**

Aspose.Slides สามารถใช้เพื่อสร้าง [SVG](https://docs.fileformat.com/page-description-language/svg/) จากสไลด์ที่มี ID รูปร่างที่กำหนดเอง เพื่อทำเช่นนี้ ให้ใช้เมธอด `set_Id` จาก [ISvgShape](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isvgshape/). สามารถใช้ `CustomSvgShapeFormattingController` เพื่อกำหนด ID รูปร่างได้

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **สร้างภาพย่อสไลด์**

Aspose.Slides ช่วยคุณสร้างภาพย่อของสไลด์ เพื่อสร้างภาพย่อของสไลด์โดยใช้ Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. ดึงภาพย่อของสไลด์ที่อ้างอิงโดยกำหนดระดับสเกลที่ต้องการ
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **สร้างภาพย่อสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อสไลด์ด้วยมิติที่ผู้ใช้กำหนด โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. ดึงภาพย่อของสไลด์ที่อ้างอิงพร้อมมิติที่กำหนด
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **สร้างภาพย่อสไลด์พร้อมบันทึกผู้บรรยาย**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกผู้บรรยายโดยใช้ Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [RenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/renderingoptions/)
1. ใช้เมธอด `RenderingOptions.set_SlidesLayoutOptions` เพื่อกำหนดตำแหน่งของบันทึกผู้บรรยาย
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. ดึงภาพย่อของสไลด์ที่อ้างอิงพร้อมตัวเลือกการเรนเดอร์
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ตัวอย่างสด**

คุณสามารถลองแอปฟรี [**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูว่าคุณสามารถใช้งานกับ Aspose.Slides API อย่างไร:

![ตัวดู PowerPoint ออนไลน์](online-PowerPoint-viewer.png)

## **FAQ**

**ฉันสามารถฝังตัวดูงานนำเสนอในแอปพลิเคชันเว็บได้หรือไม่?**

ใช่ คุณสามารถใช้ Aspose.Slides บนเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็นภาพหรือ HTML แล้วแสดงในเบราว์เซอร์ คุณลักษณะการนำทางและการซูมสามารถนำไปใช้ด้วย JavaScript เพื่อประสบการณ์แบบโต้ตอบ

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในตัวดูที่กำหนดเองคืออะไร?**

แนวทางที่แนะนำคือเรนเดอร์แต่ละสไลด์เป็นภาพ (เช่น PNG หรือ SVG) หรือแปลงเป็น HTML ด้วย Aspose.Slides แล้วแสดงผลลัพธ์ภายใน picture box (สำหรับเดสก์ท็อป) หรือคอนเทนเนอร์ HTML (สำหรับเว็บ)

**ฉันจัดการงานนำเสนอขนาดใหญ่ที่มีสไลด์จำนวนมากอย่างไร?**

สำหรับเด็คขนาดใหญ่ ควรพิจารณาการโหลดแบบ lazy-loading หรือการเรนเดอร์ตามความต้องการของสไลด์ ซึ่งหมายถึงการสร้างเนื้อหาของสไลด์เมื่อผู้ใช้เลื่อนไปยังสไลด์นั้นเท่านั้น เพื่อลดการใช้หน่วยความจำและเวลาโหลด