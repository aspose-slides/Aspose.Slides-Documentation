---
title: "จัดการสไลด์มาสเตอร์ของการนำเสนอใน C++"
linktitle: "สไลด์มาสเตอร์"
type: docs
weight: 80
url: /th/cpp/slide-master/
keywords:
- "สไลด์มาสเตอร์"
- "สไลด์มาสเตอร์"
- "สไลด์มาสเตอร์ PPT"
- "สไลด์มาสเตอร์หลายอัน"
- "เปรียบเทียบสไลด์มาสเตอร์"
- "พื้นหลัง"
- "ตัวยึดตำแหน่ง"
- "คัดลอกสไลด์มาสเตอร์"
- "สำเนาสไลด์มาสเตอร์"
- "ทำซ้ำสไลด์มาสเตอร์"
- "สไลด์มาสเตอร์ที่ไม่ได้ใช้"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "C++"
- "Aspose.Slides"
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ C++: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบ และลบสไลด์มาสเตอร์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

**สไลด์มาสเตอร์** กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ สามารถมีรูปทรงทั่วไป โลโก้ พื้นหลัง รูปแบบข้อความ การตั้งค่าธีม และการตั้งค่าฝั่งล่าง ใน PowerPoint การแก้ไขสไลด์มาสเตอร์เป็นวิธีปกติเพื่อให้การนำเสนอมีความสอดคล้องโดยไม่ต้องทำรูปแบบเดียวกันซ้ำในทุกสไลด์

Aspose.Slides for C++ รองรับโมเดลเดียวกัน การนำเสนอสามารถมีสไลด์มาสเตอร์หนึ่งหรือหลายอัน และแต่ละสไลด์มาสเตอร์สามารถมีสไลด์เลเอาท์หลายสไลด์ สไลด์ปกติส่วนใหญ่ไม่ได้อ้างอิงสไลด์มาสเตอร์โดยตรง แต่ใช้สไลด์เลเอาท์ ซึ่งสไลด์เลเอาท์นั้นเป็นส่วนหนึ่งของสไลด์มาสเตอร์

ลำดับชั้นคือ:

1. **สไลด์มาสเตอร์** – กำหนดการออกแบบและธีมที่ใช้ร่วมกัน
1. **สไลด์เลเอาท์** – กำหนดการจัดวางตัวเต็มของ placeholder และการจัดรูปแบบระดับเลเอาท์
1. **สไลด์ปกติ** – มีเนื้อหาในการนำเสนอจริงและใช้สไลด์เลเอาท์หนึ่งสไลด์

![ลำดับชั้นของสไลด์มาสเตอร์, สไลด์เลเอาท์, และสไลด์ปกติ](slide-master_2.jpg)

ใน Aspose.Slides สไลด์มาสเตอร์ถูกแทนด้วยอินเทอร์เฟซ [IMasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/) สไลด์มาสเตอร์ทั้งหมดในงานนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน [Presentation::get_Masters](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_masters/) ซึ่งทำงานตาม [IMasterSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/)

{{% alert color="info" title="การสืบทอด" %}}

เมื่อสมบัติเช่นเดียวกันถูกกำหนดที่หลายระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หากสไลด์มาสเตอร์และสไลด์เลเอาท์ทั้งสองกำหนดพื้นหลัง สไลด์ที่สร้างจากเลเอาท์นั้นจะใช้พื้นหลังของเลเอาท์ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสไลด์เลเอาท์ โปรดดูที่ [Apply or Change Slide Layouts](/slides/th/cpp/slide-layout/)

{{% /alert %}}

## **การเข้าถึงสไลด์มาสเตอร์**

ใน PowerPoint คุณสามารถเปิดมุมมองสไลด์มาสเตอร์ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master ในแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides ใช้คอลเลกชัน `get_Masters()` เพื่อเข้าถึงสไลด์มาสเตอร์:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

คุณยังสามารถดึงสไลด์มาสเตอร์ที่ใช้โดยสไลด์ปกติผ่านเลเอาท์ของมันได้:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **สไลด์มาสเตอร์ประกอบด้วยอะไร**

สไลด์มาสเตอร์เป็นวัตถุแบบสไลด์ มันทำงานตาม [IBaseSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/) ดังนั้นจึงมีสมบัติสไลด์หลายอย่างที่ใช้ร่วมกับสไลด์ปกติและสไลด์เลเอาท์ สมาชิกเฉพาะของมาสเตอร์สามารถดูได้บนหน้า API ของ [IMasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/)

สมาชิกสไลด์มาสเตอร์ที่ใช้บ่อยรวมถึง:

| สมาชิก | จุดประสงค์ |
| --- | --- |
| `get_Background()` | ตั้งค่าพื้นหลังระดับมาสเตอร์ของสไลด์ |
| `get_Shapes()` | เก็บรูปทรงที่วางบนมาสเตอร์ เช่น โลโก้, กรอบรูป, และข้อความที่ใช้ร่วมกัน |
| `get_LayoutSlides()` | เก็บสไลด์เลเอาท์ที่เป็นส่วนของมาสเตอร์ |
| `get_ThemeManager()` | ให้เข้าถึง API ธีมของมาสเตอร์ |
| `get_HeaderFooterManager()` | ควบคุมส่วนหัว, ส่วนล่าง, วันที่ และหมายเลขสไลด์สำหรับมาสเตอร์และเลเอาท์ลูกของมัน |
| `GetDependingSlides()` | คืนค่าสไลด์ปกติที่พึ่งพามาสเตอร์ผ่านเลเอาท์ของพวกมัน |

## **เพิ่มภาพลงในสไลด์มาสเตอร์**

เมื่อคุณเพิ่มภาพลงในสไลด์มาสเตอร์ ภาพนั้นจะปรากฏบนสไลด์ที่ใช้เลเอาท์จากมาสเตอร์นั้น ซึ่งเหมาะสำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องทำซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ลงในสไลด์มาสเตอร์แรก:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบรูป ดูที่ [Picture Frame](/slides/th/cpp/picture-frame/)

## **ทำงานกับ Placeholder**

Placeholder ปกติจะกำหนดบนสไลด์เลเอาท์ มาสเตอร์มอบสไตล์และธีมที่เลเอาท์เหล่านั้นสืบทอด ส่วนแต่ละเลเอาท์จะตัดสินใจว่า placeholder ใดพร้อมใช้งานและวางไว้ที่ไหน

ใน PowerPoint คำสั่ง placeholder มีให้ในมุมมอง Slide Master

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่ม placeholder ใหม่ด้วย Aspose.Slides ให้ทำงานกับสไลด์เลเอาท์ที่เป็นส่วนของมาสเตอร์:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

คุณยังสามารถจัดรูปแบบรูปทรง placeholder ที่มีอยู่บนสไลด์มาสเตอร์ได้ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใส่การเติมสีไล่เชิงเส้น:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Placeholder หัวเรื่องที่ฟอร์แมตแล้วสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกรูปแบบ placeholder และข้อความเพิ่มเติม โปรดดูที่ [Set Prompt Text in Placeholder](/slides/th/cpp/manage-placeholder/) และ [Text Formatting](/slides/th/cpp/text-formatting/)

## **เปลี่ยนพื้นหลังของสไลด์มาสเตอร์**

พื้นหลังของมาสเตอร์จะสืบทอดไปยังเลเอาท์และสไลด์ที่ไม่ได้กำหนดทับเอง ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังทึบสำหรับสไลด์มาสเตอร์แรก:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สำหรับหัวข้อที่เกี่ยวข้อง โปรดดูที่ [Presentation Background](/slides/th/cpp/presentation-background/) และ [Presentation Theme](/slides/th/cpp/presentation-theme/)

## **คัดลอกสไลด์มาสเตอร์ไปยังงานนำเสนออื่น**

ใช้เมธอด [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/addclone/) เพื่อคัดลอกสไลด์มาสเตอร์ไปยังงานนำเสนออื่น มาสเตอร์ที่คัดลอกแล้วสามารถใช้โดยเลเอาท์และสไลด์ในงานนำหมายปลายได้

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

หากต้องการคัดลอกสไลด์ปกติติดกับมาสเตอร์ของมัน โปรดดูที่ [Clone Slides](/slides/th/cpp/clone-slides/)

## **เพิ่มสไลด์มาสเตอร์หลายอัน**

งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายอัน ซึ่งมีประโยชน์เมื่อแต่ละส่วนต้องการแบรนด์, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![คำสั่ง PowerPoint สำหรับแทรกและจัดการสไลด์มาสเตอร์](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอกมาสเตอร์เริ่มต้น, ให้คัดลอกนั้นมีพื้นหลังที่ต่างออกไป, สร้างเลเอาท์ภายใต้มาสเตอร์ที่คัดลอก, และเพิ่มสไลด์ใหม่ที่อิงจากเลเอาท์นั้น:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เปรียบเทียบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถเปรียบเทียบด้วยเมธอด `Equals` ที่สืบทอดจาก [IBaseSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/) การเปรียบเทียบจะตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปร่าง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน, และการตั้งค่าสไลด์อื่น ๆ ไม่ได้เปรียบเทียบตัวระบุเฉพาะ เช่น slide ID หรือค่าพลาซ์ฮอลเดอร์แบบไดนามิก เช่น วันที่ปัจจุบัน

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

สำหรับข้อมูลเพิ่มเติม โปรดดูที่ [Compare Presentation Slides](/slides/th/cpp/compare-slides/)

## **ตั้งค่า Slide Master View เป็นมุมมองเริ่มต้น**

ใช้เมธอด `set_LastView` บน [ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นอันดับแรก ตัวอย่างต่อไปนี้เปิดงานนำเสนอในมุมมอง Slide Master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม โปรดดูที่ [Save Presentation](/slides/th/cpp/save-presentation/)

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

บางครั้งงานนำเสนออาจมีสไลด์มาสเตอร์ที่ไม่ได้ใช้โดยสไลด์ปกติใด ๆ การลบมาสเตอร์ที่ไม่ได้ใช้จะช่วยลดขนาดไฟล์และทำให้การดูแลเทมเพลตง่ายขึ้น

ใช้เมธอด [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/th/cpp/aspose.slides/masterslidecollection/removeunused/) เพื่อลบมาสเตอร์ที่ไม่ได้ใช้จากคอลเลกชัน `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

คุณยังสามารถใช้เมธอด low‑code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) ได้เช่นกัน:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**สไลด์มาสเตอร์กับสไลด์เลเอาท์ต่างกันอย่างไร?**

สไลด์มาสเตอร์กำหนดการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และรูปแบบข้อความ สไลด์เลเอาท์เป็นส่วนของสไลด์มาสเตอร์และกำหนดการจัดวาง placeholder เฉพาะ สไลด์ปกติใช้สไลด์เลเอาท์ ดังนั้นจึงสืบทอดจากทั้งเลเอาท์และมาสเตอร์

**งานนำเสนอหนึ่งสามารถมีสไลด์มาสเตอร์หลายอันได้หรือไม่?**

ได้ งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายอัน ใช้หลายมาสเตอร์เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน

**ควรเพิ่ม placeholder ไปที่สไลด์มาสเตอร์หรือสไลด์เลเอาท์?**

ในกรณีส่วนใหญ่ให้เพิ่ม placeholder ไปที่สไลด์เลเอาท์ ใส่องค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบนสไลด์มาสเตอร์ แล้วใส่ placeholder สำหรับเนื้อหาในเลเอาท์ที่สไลด์ปกติจะใช้

**ฉันสามารถลบสไลด์มาสเตอร์ที่ยังถูกใช้ได้หรือไม่?**

ไม่ได้ สไลด์มาสเตอร์ที่มีสไลด์พึ่งพาอยู่ไม่สามารถลบได้โดยตรง ต้องย้ายสไลด์เหล่านั้นไปยังเลเอาท์ของมาสเตอร์อื่นก่อน หรือใช้วิธีทำความสะอาดมาสเตอร์ที่ไม่ได้ใช้ซึ่งลบเฉพาะมาสเตอร์ที่ไม่มีการอ้างอิงเท่านั้น