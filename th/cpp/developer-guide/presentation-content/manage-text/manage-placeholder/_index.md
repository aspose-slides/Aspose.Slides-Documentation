---
title: จัดการ Placeholder ของพรีเซนเทชันใน C++
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/cpp/manage-placeholder/
keywords:
- ตำแหน่งเก็บ
- ตำแหน่งเก็บข้อความ
- ตำแหน่งเก็บรูปภาพ
- ตำแหน่งเก็บแผนภูมิ
- ข้อความแจ้ง
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการ placeholder อย่างง่ายดายใน Aspose.Slides สำหรับ C++: แทนที่ข้อความ ปรับแต่งข้อความแจ้ง และตั้งค่าความโปร่งใสของภาพใน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ให้คุณจัดการ placeholder ของงานพรีเซนเทชันโดยโปรแกรมได้ บทความนี้อธิบายวิธีค้นหา placeholder บนสไลด์และเปลี่ยนข้อความของมัน ตั้งข้อความ prompt ที่กำหนดเองสำหรับรูปแบบ placeholder และปรับความโปร่งใสของรูปภาพที่ใช้เป็นพื้นหลังของ placeholder นอกจากนี้ยังมี FAQ สั้น ๆ ที่ชี้แจงความแตกต่างระหว่าง base placeholder กับ local shape อธิบายวิธีการใช้การเปลี่ยนแปลง placeholder ผ่าน layout หรือ master และอ้างอิงการจัดการ placeholder ของ header และ footer

## **เปลี่ยนข้อความใน Placeholder**
โดยใช้ [Aspose.Slides for C++](/slides/th/cpp/), คุณสามารถค้นหาและแก้ไข placeholder บนสไลด์ในพรีเซนเทชันได้ Aspose.Slides ให้คุณทำการเปลี่ยนแปลงข้อความใน placeholder

**ความต้องการเบื้องต้น**: คุณต้องมีพรีเซนเทชันที่มี placeholder คุณสามารถสร้างพรีเซนเทชันดังกล่าวด้วยแอป Microsoft PowerPoint ปกติ

นี่คือตัวอย่างการใช้ Aspose.Slides เพื่อแทนที่ข้อความใน placeholder ของพรีเซนเทชันนั้น:

1. สร้างอินสแตนซ์ของคลาส [`Presentation`](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/) และส่งพรีเซนเทชันเป็นอาร์กิวเมนต์
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. วนลูปผ่าน shape เพื่อค้นหา placeholder
4. แคสต์รูปแบบ placeholder เป็น [`AutoShape`](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.auto_shape/) แล้วเปลี่ยนข้อความโดยใช้ [`TextFrame`](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.text_frame/) ที่เชื่อมต่อกับ [`AutoShape`](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.auto_shape/)
5. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ด C++ นี้แสดงวิธีเปลี่ยนข้อความใน placeholder:

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// โหลดพรีเซนเทชันที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// เข้าถึง placeholder แรกและที่สองในสไลด์และแคสต์เป็น AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// บันทึกพรีเซนเทชันลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ตั้งค่า Prompt Text ใน Placeholder**
เลเอาต์มาตรฐานและเลเอาต์ที่สร้างสำเร็จมีข้อความ prompt ของ placeholder เช่น ***Click to add a title*** หรือ ***Click to add a subtitle*** ด้วย Aspose.Slides คุณสามารถแทรกข้อความ prompt ที่ต้องการเข้าไปในเลเอาต์ของ placeholder

โค้ด C++ นี้แสดงวิธีตั้งค่า prompt text ใน placeholder:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // เมื่อไม่มีข้อความในนั้น PowerPoint จะแสดง "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // ทำเช่นเดียวกันสำหรับ subtitle.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ตั้งค่าความโปร่งใสของรูปภาพ Placeholder**

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสของรูปภาพพื้นหลังใน placeholder ของข้อความ โดยการปรับความโปร่งใสของรูปภาพในกรอบดังกล่าว คุณสามารถทำให้ข้อความหรือรูปภาพโดดเด่นขึ้น (ขึ้นอยู่กับสีของข้อความและรูปภาพ)

โค้ด C++ นี้แสดงวิธีตั้งค่าความโปร่งใสสำหรับพื้นหลังของรูปภาพ (ภายใน shape):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **คำถามที่พบบ่อย**

**Base placeholder คืออะไร และแตกต่างจาก local shape บนสไลด์อย่างไร?**

Base placeholder คือ shape ดั้งเดิมบน layout หรือ master ที่ shape ของสไลด์สืบทอดประเภท ตำแหน่ง และรูปแบบบางส่วนจากมัน ส่วน local shape เป็นอิสระ หากไม่มี base placeholder การสืบทอดจะไม่เกิดขึ้น

**ฉันจะอัปเดตหัวเรื่องหรือคำอธิบายทั้งหมดในพรีเซนเทชันโดยไม่ต้องวนลูปทุกสไลด์ได้อย่างไร?**

แก้ไข placeholder ที่สอดคล้องใน layout หรือ master สไลด์ที่อิงจาก layout/master นั้นจะสืบทอดการเปลี่ยนแปลงโดยอัตโนมัติ

**ฉันจะควบคุม placeholder ของ header/footer มาตรฐาน—วันที่และเวลา เลขสไลด์ และข้อความ footer อย่างไร?**

ใช้ผู้จัดการ HeaderFooter ในระดับที่เหมาะสม (สไลด์ทั่วไป, layout, master, notes/handouts) เพื่อเปิดหรือปิด placeholder เหล่านั้นและตั้งค่าข้อความของมัน