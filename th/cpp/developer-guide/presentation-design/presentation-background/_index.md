---
title: จัดการพื้นหลังของงานนำเสนอใน C++
linktitle: พื้นหลังสไลด์
type: docs
weight: 20
url: /th/cpp/presentation-background/
keywords:
- พื้นหลังของงานนำเสนอ
- พื้นหลังสไลด์
- สีทึบ
- สีไล่สี
- พื้นหลังรูปภาพ
- ความโปร่งใสของพื้นหลัง
- คุณสมบัติของพื้นหลัง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ พร้อมเคล็ดลับโค้ดเพื่อยกระดับการนำเสนอของคุณ."
---
## **คำนำ**

สีทึบ, การไล่สี, และรูปภาพมักใช้เป็นพื้นหลังของสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดียว) หรือ **สไลด์แม่** (ใช้กับหลายสไลด์พร้อมกัน)

![พื้นหลัง PowerPoint](powerpoint-background.png)

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์ปกติ**

Aspose.Slides อนุญาตให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์ที่กำหนดในงานนำเสนอ — แม้ว่างานนำเสนอจะใช้สไลด์แม่ก็ตาม การเปลี่ยนแปลงจะส่งผลเฉพาะต่อสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Solid`  
4. ใช้วิธี [get_SolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_solidfillcolor/) บน [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังแบบทึบ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างแสดงวิธีตั้งค่าสีทึบสีน้ำเงินเป็นพื้นหลังสำหรับสไลด์ปกติ:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ตั้งค่าสีพื้นหลังของสไลด์เป็นสีน้ำเงิน.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์แม่**

Aspose.Slides อนุญาตให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์แม่ในงานนำเสนอ สไลด์แม่ทำหน้าที่เป็นเทมเพลตที่ควบคุมการจัดรูปแบบสำหรับสไลด์ทั้งหมด ดังนั้นเมื่อคุณเลือกสีทึบเป็นพื้นหลังของสไลด์แม่ สีดังกล่าวจะใช้กับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/) ของสไลด์แม่ (ผ่าน `get_Masters`) เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของพื้นหลังสไลด์แม่เป็น `Solid`  
4. ใช้วิธี [get_SolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_solidfillcolor/) เพื่อระบุสีพื้นหลังแบบทึบ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างแสดงวิธีตั้งค่าสีทึบ (สีเขียวป่า) เป็นพื้นหลังสำหรับสไลด์แม่:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// ตั้งค่าสีพื้นหลังสำหรับสไลด์แม่เป็นสีเขียวป่า.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าพื้นหลังแบบไล่สีสำหรับสไลด์**

การไล่สีเป็นเอฟเฟกต์กราฟิกที่สร้างจากการเปลี่ยนสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังสไลด์ การไล่สีสามารถทำให้งานนำเสนอดูศิลปะและเป็นมืออาชีพมากขึ้น Aspose.Slides อนุญาตให้คุณตั้งค่าสีไล่สีเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Gradient`  
4. ใช้วิธี [get_GradientFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_gradientformat/) บน [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/) เพื่อกำหนดการตั้งค่าไล่สีที่ต้องการ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างแสดงวิธีตั้งค่าสีไล่สีเป็นพื้นหลังสำหรับสไลด์:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ใช้เอฟเฟกต์ไล่สีกับพื้นหลัง.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งรูปภาพเป็นพื้นหลังสไลด์**

นอกจากการเติมสีทึบและการไล่สีแล้ว Aspose.Slides ยังอนุญาตให้คุณใช้รูปภาพเป็นพื้นหลังสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Picture`  
4. โหลดรูปภาพที่ต้องการใช้เป็นพื้นหลังสไลด์  
5. เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ  
6. ใช้วิธี [get_PictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_picturefillformat/) บน [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/) เพื่อกำหนดรูปภาพเป็นพื้นหลัง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างแสดงวิธีตั้งรูปภาพเป็นพื้นหลังสำหรับสไลด์:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ตั้งค่าคุณสมบัติภาพพื้นหลัง.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// โหลดภาพ.
auto image = Images::FromFile(u"Tulips.jpg");
// เพิ่มภาพลงในคอลเลกชันภาพของงานนำเสนอ.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าชนิดการเติมพื้นหลังเป็นภาพต่อเป็นพื้นผิวและปรับคุณสมบัติการต่อภาพ:

```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
อ่านเพิ่มเติม: [**ภาพต่อเป็นพื้นผิว**](/slides/th/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งใสของภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งใสของภาพพื้นหลังสไลด์เพื่อให้เนื้อหาของสไลด์โดดเด่นขึ้น โค้ด C++ ด้านล่างแสดงวิธีเปลี่ยนความโปร่งใสของภาพพื้นหลังสไลด์:

```cpp
auto transparencyValue = 30; // เป็นตัวอย่าง.

// รับคอลเลกชันของการแปลงรูปภาพ.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// ค้นหาเอฟเฟกต์ความโปร่งใสที่มีเปอร์เซ็นต์คงที่ที่มีอยู่.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// ตั้งค่าความโปร่งใสใหม่.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **รับค่าพื้นหลังสไลด์**

Aspose.Slides มีอินเทอร์เฟซ [IBackgroundEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibackgroundeffectivedata/) สำหรับดึงค่าพื้นหลังที่มีผลของสไลด์ อินเทอร์เฟซนี้เปิดเผย [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) และ [EffectFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) ที่มีผล

โดยใช้เมธอด `get_Background` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง C++ ด้านล่างแสดงวิธีรับค่าพื้นหลังที่มีผลของสไลด์:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// ดึงพื้นหลังที่มีผลโดยพิจารณาจากสไลด์แม่, เลย์เอาต์, และธีม.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

**ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและคืนค่าเป็นพื้นหลังของธีม/เลย์เอาต์ได้หรือไม่?**

ได้. ให้ลบการเติมเฉพาะของสไลด์ และพื้นหลังจะถูกสืบทอดใหม่จากสไลด์ [layout](/slides/th/cpp/slide-layout/)/[master](/slides/th/cpp/slide-master/) ที่สอดคล้อง (เช่น [theme background](/slides/th/cpp/presentation-theme/))

**หากฉันเปลี่ยนธีมของงานนำเสนอภายหลัง พื้นหลังจะเกิดอะไรขึ้น?**

หากสไลด์มีการเติมของตนเอง มันจะคงเดิมไว้ หากพื้นหลังสืบทอดจาก [layout](/slides/th/cpp/slide-layout/)/[master](/slides/th/cpp/slide-master/) จะอัปเดตให้ตรงกับ [new theme](/slides/th/cpp/presentation-theme/) ใหม่