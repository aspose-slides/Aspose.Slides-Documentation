---
title: จัดการส่วนข้อความในงานนำเสนอโดยใช้ C++
linktitle: ส่วนข้อความ
type: docs
weight: 70
url: /th/cpp/portion/
keywords:
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนข้อความในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ C++ เพื่อเพิ่มประสิทธิภาพและการปรับแต่ง."
---
## **บทนำ**

ส่วนของข้อความเป็นส่วนที่ระบุของข้อความภายในย่อหน้าและให้คุณทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหาที่อยู่รอบข้าง ใน Aspose.Slides สามารถใช้ส่วนข้อความได้เมื่อคุณต้องการดึงตำแหน่งของส่วนข้อความ, ใช้การจัดรูปแบบกับบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดขึ้น

## **รับพิกัดของส่วนข้อความ**
**GetCoordinates()** method ได้ถูกเพิ่มไปยังคลาส IPortion และ Portion ซึ่งช่วยให้สามารถดึงพิกัดของจุดเริ่มต้นของส่วนได้:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับเพียงบางส่วนของข้อความภายในย่อหน้าหนึ่งเดียวได้หรือไม่?**

ใช่, คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/cpp/manage-hyperlinks/) ให้กับส่วนย่อยได้; เพียงส่วนนั้นเท่านั้นที่จะคลิกได้, ไม่ใช่ทั้งย่อหน้า

**สไตล์การสืบทอดทำงานอย่างไร: Portion จะเขียนทับอะไร, และอะไรบ้างที่มาจาก Paragraph/TextFrame?**

คุณสมบัติระดับ Portion มีความสำคัญสูงสุด หากคุณสมบัติไม่ได้ถูกตั้งค่าไว้บน [Portion](https://reference.aspose.com/slides/th/cpp/aspose.slides/portion/), ระบบจะดึงจาก [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/); หากไม่ได้ตั้งค่าในนั้นเช่นกัน จะดึงจาก [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/) หรือสไตล์ของ [theme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/theme/)

**จะเกิดอะไรขึ้นหากฟอนต์ที่กำหนดสำหรับ Portion ไม่มีบนเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[กฎการทดแทนฟอนต์](/slides/th/cpp/font-selection-sequence/) จะถูกนำมาใช้. ข้อความอาจเปลี่ยนแปลงการไหลใหม่: ตัวชี้วัด, การหักบรรทัด, และความกว้างอาจเปลี่ยนแปลง, ซึ่งสำคัญต่อการวางตำแหน่งที่แม่นยำ

**ฉันสามารถตั้งค่าความโปร่งใสหรือไล่สีของการเติมข้อความในระดับ Portion อย่างอิสระจากส่วนอื่นของย่อหน้าได้หรือไม่?**

ใช่, สีข้อความ, การเติมสี, และความโปร่งใสที่ระดับ [Portion](https://reference.aspose.com/slides/th/cpp/aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้