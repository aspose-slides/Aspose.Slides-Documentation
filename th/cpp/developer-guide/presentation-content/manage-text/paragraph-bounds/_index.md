---
title: รับขอบเขตย่อหน้าจากงานนำเสนอใน C++
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/cpp/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- เฟรมข้อความ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าใน Aspose.Slides สำหรับ C++ เพื่อปรับตำแหน่งข้อความให้เหมาะสมในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต ขนาด และพิกัดของย่อหน้าใน Aspose.Slides ซึ่งแสดงวิธีดึงสี่เหลี่ยมผืนผ้าย่อหน้าจาก [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) โดยใช้ [IParagraph::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getrect/), วิธีรับพิกัดย่อหน้าภายในกรอบข้อความของเซลล์ตาราง, และไฮไลท์รายละเอียดสำคัญเช่นหน่วยวัด ผลของการห่อหุ้มข้อความต่อขอบเขต การแปลงเป็นพิกเซล และค่าการจัดรูปแบบย่อหน้าที่มีประสิทธิภาพ

## **รับพิกัดสี่เหลี่ยมผืนผ้าของย่อหน้า**

ใช้ [IParagraph::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getrect/) เพื่อรับสี่เหลี่ยมผืนผ้าขอบเขตของย่อหน้า

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **รับขนาดของย่อหน้าใน TextFrame ของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) ใน TextFrame ของเซลล์ตาราง ให้ใช้ [IParagraph::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getrect/). สี่เหลี่ยมที่ส่งกลับเป็นค่าตามสัดส่วนของ TextFrame ของเซลล์ตาราง ดังนั้นให้เพิ่มตำแหน่งตารางและออฟเซ็ตของเซลล์เมื่อจำเป็นต้องได้พิกัดระดับสไลด์

ตัวอย่างต่อไปนี้รับขอบเขตของย่อหน้าในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**พิกัดย่อมวัดเป็นหน่วยใด?**

พวกมันวัดเป็นจุด (points) โดยที่ 1 นิ้วเท่ากับ 72 จุด ซึ่งใช้กับพิกัดและขนาดทั้งหมดบนสไลด์

**การห่อหุ้มคำมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่ หาก [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_wraptext/) ถูกเปิดใช้งานสำหรับ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/), ข้อความจะตัดบรรทัดให้พอดีกับความกว้างของพื้นที่ ซึ่งจะทำให้ขอบเขตจริงของย่อเปลี่ยนแปลง

**พิกัดย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างเชื่อถือได้หรือไม่?**

ใช่. แปลงจากจุดเป็นพิกเซลโดยใช้สูตรนี้: พิกเซล = จุด x (DPI / 72). ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้า "effective" อย่างไร โดยคำนึงถึงการสืบทอดสไตล์?**

ใช้ [โครงสร้างข้อมูลการจัดรูปแบบย่อหน้าแบบมีประสิทธิภาพ](/slides/th/cpp/shape-effective-properties/); ซึ่งจะคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง การเว้นระยะ การห่อหุ้ม RTL และอื่น ๆ