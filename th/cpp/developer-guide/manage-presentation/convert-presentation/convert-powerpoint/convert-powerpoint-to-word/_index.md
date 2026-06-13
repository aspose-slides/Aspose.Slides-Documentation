---
title: แปลงการนำเสนอ PowerPoint เป็นเอกสาร Word ด้วย C++
linktitle: PowerPoint เป็น Word
type: docs
weight: 110
url: /th/cpp/convert-powerpoint-to-word/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น Word
- การนำเสนอเป็น Word
- สไลด์เป็น Word
- PPT เป็น Word
- PPTX เป็น Word
- PowerPoint เป็น DOCX
- การนำเสนอเป็น DOCX
- สไลด์เป็น DOCX
- PPT เป็น DOCX
- PPTX เป็น DOCX
- PowerPoint เป็น DOC
- การนำเสนอเป็น DOC
- สไลด์เป็น DOC
- PPT เป็น DOC
- PPTX เป็น DOC
- บันทึก PPT เป็น DOCX
- บันทึก PPTX เป็น DOCX
- ส่งออก PPT เป็น DOCX
- ส่งออก PPTX เป็น DOCX
- C++
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint PPT และ PPTX เป็นเอกสาร Word ที่แก้ไขได้ใน C++ โดยใช้ Aspose.Slides พร้อมรักษาเลย์เอาต์ ภาพและการจัดรูปแบบที่แม่นยำ"
---
## **บทนำ**

หากคุณตั้งใจใช้เนื้อหาข้อความหรือข้อมูลจากการนำเสนอ (PPT หรือ PPTX) ในรูปแบบใหม่ คุณอาจได้รับประโยชน์จากการแปลงการนำเสนอเป็น Word (DOC หรือ DOCX).

* เมื่อเทียบกับ Microsoft PowerPoint แอป Microsoft Word มีเครื่องมือหรือฟังก์ชันสำหรับเนื้อหามากกว่า.
* นอกจากนี้ฟังก์ชันการแก้ไขใน Word ยังทำให้คุณได้รับประโยชน์จากการทำงานร่วมกัน การพิมพ์ และการแชร์ที่ดียิ่งขึ้น.

{{% alert color="primary" %}} 

คุณอาจต้องการลองใช้ [**Presentation to Word Online Converter**](https://products.aspose.app/slides/th/conversion/ppt-to-word) ของเราเพื่อดูว่าคุณจะได้ประโยชน์อะไรจากการทำงานกับเนื้อหาข้อความจากสไลด์. 

{{% /alert %}} 

## **Aspose.Slides และ Aspose.Words**

เพื่อแปลงไฟล์ PowerPoint (PPTX หรือ PPT) เป็น Word (DOCX หรือ DOC) คุณต้องใช้ทั้ง [Aspose.Slides for C++](https://products.aspose.com/slides/th/cpp/) และ [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

ในรูปแบบ API แยกเดี่ยว [Aspose.Slides](https://products.aspose.app/slides) สำหรับ C++ มีฟังก์ชันที่ช่วยให้คุณดึงข้อความจากการนำเสนอ. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) เป็น API การประมวลผลเอกสารขั้นสูงที่ช่วยให้แอปพลิเคชันสร้าง แก้ไข แปลง แสดงผล พิมพ์ไฟล์ และทำงานอื่น ๆ กับเอกสารโดยไม่ต้องใช้ Microsoft Word.

## **แปลงการนำเสนอ PowerPoint เป็นเอกสาร Word**

ใช้โค้ดตัวอย่างนี้เพื่อแปลง PowerPoint เป็น Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // สร้างและแทรกรูปภาพสไลด์
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // แทรกข้อความของสไลด์
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```

## **คำถามที่พบบ่อย**

**ต้องติดตั้งส่วนประกอบอะไรเพื่อแปลงการนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word?**

คุณเพียงแค่เพิ่มแพคเกจที่เกี่ยวข้องสำหรับ [Aspose.Slides for C++](https://releases.aspose.com/slides/th/cpp/) และ [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) ลงในโครงการของคุณ ทั้งสองไลบรารีทำงานเป็น API แยกเดี่ยว และไม่จำเป็นต้องติดตั้ง Microsoft Office.

**รองรับรูปแบบการนำเสนอ PowerPoint และ OpenDocument ทั้งหมดหรือไม่?**

Aspose.Slides [รองรับรูปแบบการนำเสนอทั้งหมด](/slides/th/cpp/supported-file-formats/), รวมถึง PPT, PPTX, ODP และประเภทไฟล์ทั่วไปอื่น ๆ ซึ่งทำให้คุณสามารถทำงานกับการนำเสนอที่สร้างในเวอร์ชันต่าง ๆ ของ Microsoft PowerPoint.