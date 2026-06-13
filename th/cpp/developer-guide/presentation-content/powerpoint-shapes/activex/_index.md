---
title: จัดการ ActiveX Controls ในงานนำเสนอด้วย C++
linktitle: ActiveX
type: docs
weight: 80
url: /th/cpp/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides for C++ ใช้ ActiveX อย่างไรเพื่ออัตโนมัติและเพิ่มประสิทธิภาพการนำเสนอ PowerPoint ให้กับนักพัฒนามีการควบคุมสไลด์อย่างเต็มที่"
---
## **บทนำ**

ActiveX control ถูกใช้ในงานพรีเซนเทชัน Aspose.Slides for C++ ให้คุณจัดการ ActiveX control ได้ แต่การจัดการเหล่านี้ค่อนข้างซับซ้อนและแตกต่างจากรูปทรงทั่วไปของพรีเซนเทชัน ตั้งแต่ Aspose.Slides for C++ เวอร์ชัน 18.1 คอมโพเนนต์นี้รองรับการจัดการ ActiveX control ในขณะนี้คุณสามารถเข้าถึง ActiveX control ที่ได้เพิ่มไว้แล้วในพรีเซนเทชันของคุณและแก้ไขหรือ删除โดยใช้คุณสมบัติต่าง ๆ ของมัน จำไว้ว่า ActiveX control ไม่ใช่รูปทรงและไม่ได้เป็นส่วนหนึ่งของ IShapeCollection ของพรีเซนเทชัน แต่เป็นส่วนของ IControlCollection บทความนี้จะแสดงวิธีการทำงานกับพวกมัน

## **แก้ไข ActiveX Control**
เพื่อจัดการ ActiveX control แบบง่าย เช่น กล่องข้อความและปุ่มคำสั่งบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส Presentation แล้วโหลดพรีเซนเทชันที่มี ActiveX control อยู่ในนั้น
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. เข้าถึง ActiveX control ในสไลด์โดยการเข้าถึง IControlCollection
1. เข้าถึง ActiveX control TextBox1 ด้วยอ็อบเจกต์ ControlEx
1. เปลี่ยนคุณสมบัติต่าง ๆ ของ ActiveX control TextBox1 รวมถึงข้อความ ฟอนต์ ความสูงของฟอนต์และตำแหน่งของเฟรม
1. เข้าถึงคอนโทรลที่สองที่ชื่อ CommandButton1
1. เปลี่ยนคำบรรยายของปุ่ม ฟอนต์และตำแหน่ง
1. ย้ายตำแหน่งของเฟรม ActiveX control
1. เขียนพรีเซนเทชันที่แก้ไขแล้วลงไฟล์ PPTX

โค้ดตัวอย่างด้านล่างจะอัปเดต ActiveX control บนสไลด์ของพรีเซนเทชันตามที่แสดงด้านล่าง

``` cpp
// เข้าถึงพรีเซนเทชันที่มีคอนโทรล ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// เข้าถึงสไลด์แรกในพรีเซนเทชัน
auto slide = presentation->get_Slides()->idx_get(0);

// เปลี่ยนข้อความใน TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // เปลี่ยนภาพทดแทน PowerPoint จะเปลี่ยนภาพนี้ระหว่างการเปิดใช้งาน ActiveX ดังนั้นบางครั้งอาจปล่อยภาพไว้โดยไม่เปลี่ยนแปลงก็ได้.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// เปลี่ยนคำบรรยายของปุ่ม
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // เปลี่ยนภาพทดแทน
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// ย้ายกรอบ ActiveX ลง 100 พอยต์
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// บันทึกพรีเซนเทชันพร้อมคอนโทรล ActiveX ที่แก้ไขแล้ว
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// กำลังลบคอนโทรล
slide->get_Controls()->Clear();

// บันทึกพรีเซนเทชันพร้อมคอนโทรล ActiveX ที่ลบแล้ว
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **เพิ่ม Media Player ActiveX Control**
ActiveX control ถูกใช้ในงานพรีเซนเทชัน Aspose.Slides for C++ ให้คุณเพิ่มและจัดการ ActiveX control ได้ แต่การจัดการเหล่านี้ค่อนข้างซับซ้อนและแตกต่างจากรูปทรงทั่วไปของพรีเซนเทชัน ตั้งแต่ Aspose.Slides for C++ 18.1 การสนับสนุนการเพิ่ม Media Player ActiveX control ได้ถูกเพิ่มเข้ามาใน Aspose.Slides จำไว้ว่า ActiveX control ไม่ใช่รูปทรงและไม่ได้เป็นส่วนหนึ่งของ IShapeCollection ของพรีเซนเทชัน แต่เป็นส่วนของ IControlExCollection บทความนี้จะแสดงวิธีการทำงานกับพวกมัน เพื่อจัดการ Media Player ActiveX control ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส Presentation แล้วโหลดพรีเซนเทชันตัวอย่างที่มี Media Player ActiveX control อยู่ในนั้น
1. สร้างอินสแตนซ์ของคลาส Presentation เป้าหมายและสร้างพรีเซนเทชันเปล่า
1. คัดลอกสไลด์ที่มี Media Player ActiveX control จากพรีเซนเทชันต้นแบบไปยังพรีเซนเทชันเป้าหมาย
1. เข้าถึงสไลด์ที่คัดลอกในพรีเซนเทชันเป้าหมาย
1. เข้าถึง ActiveX control ในสไลด์โดยการเข้าถึง IControlCollection
1. เข้าถึง Media Player ActiveX control และตั้งค่าพาธของวิดีโอโดยใช้คุณสมบัติของมัน
1. บันทึกพรีเซนเทชันเป็นไฟล์ PPTX

``` cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// สร้างอินสแตนซ์ของพรีเซนเทชันเปล่า
auto newPresentation = System::MakeObject<Presentation>();

// ลบสไลด์เริ่มต้น
newPresentation->get_Slides()->RemoveAt(0);

// คัดลอกสไลด์ที่มี Media Player ActiveX Control
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// เข้าถึง Media Player ActiveX control และตั้งค่าพาธของวิดีโอ
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// บันทึกพรีเซนเทชัน
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รักษา ActiveX control ไว้เมื่ออ่านและบันทึกใหม่หรือไม่หากไม่สามารถเรียกใช้ได้ใน runtime ของ C++?**

ใช่ Aspose.Slides ถือว่าเป็นส่วนหนึ่งของพรีเซนเทชันและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของมันได้; การเรียกใช้คอนโทรลเองไม่จำเป็นต้องทำเพื่อรักษาไว้

**ActiveX control แตกต่างจากวัตถุ OLE ในพรีเซนเทชันอย่างไร?**

ActiveX control เป็นคอนโทรลแบบโต้ตอบที่จัดการได้ (ปุ่ม, กล่องข้อความ, media player) ในขณะที่ [OLE](/slides/th/cpp/manage-ole/) หมายถึงวัตถุแอปพลิเคชันที่ฝังไว้ (เช่น เวิร์กชีต Excel) พวกมันถูกจัดเก็บและจัดการต่างกันและมีโมเดลคุณสมบัติที่แตกต่างกัน

**เหตุการณ์ของ ActiveX และแมโคร VBA ทำงานได้หรือไม่หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**

Aspose.Slides รักษา markup และ metadata ที่มีอยู่ไว้; อย่างไรก็ตามเหตุการณ์และแมโครจะทำงานเฉพาะใน PowerPoint บน Windows เมื่อการตั้งค่าความปลอดภัยอนุญาต ไลบรารีไม่ทำการเรียกใช้ VBA  