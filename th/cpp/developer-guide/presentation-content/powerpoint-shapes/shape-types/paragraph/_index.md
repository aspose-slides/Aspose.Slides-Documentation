---
title: รับขอบเขตย่อหน้าจากงานนำเสนอใน C++
linktitle: ย่อหน้า
type: docs
weight: 60
url: /th/cpp/paragraph/
keywords:
- ขอบเขตย่อหน้า
- ขอบเขตส่วนข้อความ
- พิกัดย่อหน้า
- พิกัดส่วน
- ขนาดย่อหน้า
- ขนาดส่วนข้อความ
- กรอบข้อความ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าและส่วนข้อความใน Aspose.Slides สำหรับ C++ เพื่อเพิ่มประสิทธิภาพการวางตำแหน่งข้อความในงานนำเสนอ PowerPoint"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต, ขนาดและพิกัดของย่อหน้าและส่วนของข้อความใน Aspose.Slides แสดงวิธีดึงสี่เหลี่ยมของย่อหน้าใน `TextFrame` โดยใช้ `GetRect()`, วิธีการรับพิกัดของย่อหน้าและส่วนภายใน TextFrame ของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่นหน่วยการวัด, ผลของการตัดบรรทัดต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าแบบมีประสิทธิภาพ

## **รับพิกัดย่อหน้าและส่วนใน TextFrame**

ด้วย Aspose.Slides for C++ นักพัฒนาสามารถรับพิกัดสี่เหลี่ยมของ Paragraph ภายในคอลเลกชันของย่อหน้าใน TextFrame ได้แล้ว นอกจากนี้ยังสามารถรับพิกัดของ Portion ภายในคอลเลกชันของส่วนของย่อหน้าได้ ในหัวข้อนี้ เราจะสาธิตด้วยตัวอย่างว่าอย่างไรในการรับพิกัดสี่เหลี่ยมของย่อหน้าพร้อมกับตำแหน่งของส่วนภายในย่อหน้า

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**

ได้เพิ่มเมธอดใหม่ **GetRect()** เข้ามา ซึ่งทำให้สามารถรับสี่เหลี่ยมขอบเขตของย่อหน้าได้

``` cpp
// สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **รับขนาดของย่อหน้าและส่วนภายใน TextFrame ของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ [Portion](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.portion) หรือ [Paragraph](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.paragraph) ใน TextFrame ของเซลล์ตาราง คุณสามารถใช้เมธอด [IPortion::GetRect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) และ [IParagraph::GetRect](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) ได้

โค้ดตัวอย่างนี้แสดงการทำงานที่อธิบายไว้:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **คำถามที่พบบ่อย**

**พิกัดที่ส่งคืนสำหรับย่อหน้าและส่วนของข้อความใช้หน่วยใด?**

หน่วยเป็นพอยต์ โดยที่ 1 นิ้ว = 72 พอยต์ ซึ่งใช้กับพิกัดและขนาดทั้งหมดบนสไลด์

**การตัดบรรทัดมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่ หากเปิดใช้งาน [wrapping](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframeformat/set_wraptext/) ใน [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/) ข้อความจะตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ซึ่งจะทำให้ขอบเขตจริงของย่อเปลี่ยนแปลง

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างเชื่อถือได้หรือไม่?**

ได้ ใช้การแปลงจากพอยต์เป็นพิกเซลโดย: pixels = points × (DPI / 72) ผลลัพธ์ขึ้นอยู่กับค่า DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้าแบบ "effective" โดยคำนึงถึงการสืบทอดสไตล์ได้อย่างไร?**

ใช้ [effective paragraph formatting data structure](/slides/th/cpp/shape-effective-properties/) ซึ่งจะส่งคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การตัดบรรทัด, RTL และอื่น ๆ