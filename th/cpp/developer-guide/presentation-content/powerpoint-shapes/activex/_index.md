---
title: "จัดการคอนโทรล ActiveX ในงานนำเสนอโดยใช้ C++"
linktitle: "ActiveX"
type: docs
weight: 80
url: /th/cpp/activex/
keywords:
- "ActiveX"
- "คอนโทรล ActiveX"
- "จัดการ ActiveX"
- "เพิ่ม ActiveX"
- "แก้ไข ActiveX"
- "เครื่องเล่นสื่อ"
- "PowerPoint"
- "งานนำเสนอ"
- "C++"
- "Aspose.Slides"
description: "แก้ไขกล่องข้อความและปุ่ม ActiveX, อัปเดตการแสดงตัวอย่างคอนโทรล, และใช้คอนโทรล Windows Media Player ใหม่ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for C++."
---
## **บทนำ**

คอนโทรล ActiveX ทำให้สไลด์ PowerPoint มีองค์ประกอบเชิงโต้ตอบ เช่น กล่องข้อความ, ปุ่มสั่งงาน, และเครื่องเล่นสื่อ. Aspose.Slides for C++ ทำให้เข้าถึงคอนโทรลของสไลด์ผ่าน [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). ใช้คอลเลกชันนี้เพื่อแก้ไขคอนโทรล, ย้ายบนสไลด์, หรือเอาออก.

## **รายการควบคุม ActiveX และคุณสมบัติที่เก็บไว้**

เพื่อสำรวจเทมเพลตที่ไม่คุ้นเคย, เปิดเพื่ออ่านและวนซ้ำคอนโทรลบนแต่ละสไลด์. ตัวอย่างรายงานหมายเลขสไลด์, ชื่อคอนโทรล, [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), และแต่ละคู่คีย์‑ค่าใน [คุณสมบัติที่เก็บไว้](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). มันอ่านงานนำเสนอโดยไม่เปิดใช้งานคอนโทรล, เรียกเหตุการณ์หรือมาโคร, เปลี่ยนค่า, หรือบันทึกไฟล์.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

ผลลัพธ์ที่เลือกจาก `ActiveX.pptm` แสดงกล่องข้อความและปุ่มสั่งงาน.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

คอลเลกชันคุณสมบัติที่ว่างปรากฏเป็น `[]`. สำหรับคอนโทรลที่ใช้การเก็บข้อมูลแบบไบนารี, `get_Properties` สามารถคืนค่า `nullptr`, แสดงเป็น `Properties unavailable`. หากต้องการเพียงชื่อ, ใช้ [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) หลังจากตรวจสอบว่าคอลเลกชันมีอยู่. รายงานแสดงคุณสมบัติที่มีในงานนำเสนอ. คอนโทรลบางตัวอาจสนับสนุนคุณสมบัติเพิ่มเติมในเวลาเรียกใช้.

## **แก้ไขคอนโทรล ActiveX**

ตัวอย่างคาดว่างานนำเสนอที่เปิดใช้งานมาโครจะมีกล่องข้อความชื่อ `TextBox1` และปุ่มสั่งงานชื่อ `CommandButton1` บนสไลด์แรก. มันใช้ [คอลเลกชันคุณสมบัติคอนโทรล](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำอธิบายของปุ่ม. คอนโทรลแต่ละตัวยังมีภาพตัวอย่างคงที่ที่ PowerPoint สามารถแสดงก่อนเปิดใช้งาน. จัดหาไฟล์ PNG สำหรับคอนโทรลแต่ละตัวที่แสดงข้อความและรูปลักษณ์ที่อัปเดต. ตัวอย่างกำหนดภาพเหล่านี้ผ่าน [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

ตัวอย่างย้ายคอนโทรลทั้งหมดบนสไลด์แรกลง 100 จุดโดยเปลี่ยน[กรอบ](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). มันบันทึกงานนำเสนอที่แก้ไขในรูปแบบ PPTM, จากนั้นใช้ [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) เพื่อบันทึกสำเนาที่สองพร้อมคอนโทรล ActiveX ทั้งหมดถูกลบออกจากสไลด์นั้น.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **เพิ่มคอนโทรล Media Player ของ ActiveX**

เพื่อใช้คอนโทรล Windows Media Player ที่กำหนดค่าแล้วซ้ำ, เริ่มด้วยเทมเพลตที่สไลด์แรกมีตัวเล่นชื่อ `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) คัดลอกสไลด์ทั้งหมดไปยังงานนำเสนอใหม่. ตัวอย่างตั้งค่า `URL` ของผู้เล่นใน [คอลเลกชันคุณสมบัติ](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) และบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์. วิดีโอยังคงเป็นไฟล์ภายนอก, ดังนั้นให้เลือกเส้นทางที่ผู้เล่นสามารถเข้าถึงได้ขณะเล่น.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถรักษาคอนโทรล ActiveX ไว้โดยไม่ต้องเรียกใช้หรือไม่?**

ใช่. Aspose.Slides สามารถอ่านและบันทึกคอนโทรลได้ รวมทั้งคุณสมบัติและตำแหน่งของมัน โดยไม่ต้องเปิดใช้งาน.

**คอนโทรล ActiveX แตกต่างจากวัตถุ OLE อย่างไร?**

คอนโทรล ActiveX ให้ผู้ใช้โต้ตอบกับสไลด์ได้ ตัวอย่างเช่น การพิมพ์ข้อความหรือคลิกปุ่ม. ส่วน [วัตถุ OLE](/slides/th/cpp/manage-ole/) ทำให้สไลด์สามารถบรรจุหรือเชื่อมโยงไปยังเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น เช่น แผ่นงาน Excel.

**เหตุการณ์ ActiveX จะยังคงเรียกใช้มาโคร VBA หลังจากที่ฉันบันทึกงานนำเสนอด้วย Aspose.Slides หรือไม่?**

บันทึกงานนำเสนอในรูปแบบที่รองรับมาโคร เช่น PPTM เพื่อเก็บโครงการ VBA ไว้. PowerPoint สำหรับ Windows สามารถเรียกใช้ตัวจัดการเหตุการณ์ที่มีอยู่ได้เมื่อการตั้งค่าความปลอดภัยของมันอนุญาตทั้งคอนโทรล ActiveX และมาโคร.