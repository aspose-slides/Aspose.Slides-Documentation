---
title: แปลงสไลด์การนำเสนอเป็นภาพใน C++
linktitle: สไลด์เป็นภาพ
type: docs
weight: 41
url: /th/cpp/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิทแมป
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพใน C++ ด้วย Aspose.Slides—การเรนเดอร์ที่รวดเร็วและคุณภาพสูงพร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for C++ ช่วยให้คุณแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่างๆ ได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่นๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) หรือ
    - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/irenderingoptions/)
2. สร้างภาพสไลด์โดยเรียกใช้เมธอด [GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/)

[Bitmap](https://reference.aspose.com/slides/th/cpp/system.drawing/bitmap/) คืออ็อบเจ็กต์ที่ให้คุณทำงานกับภาพที่กำหนดด้วยข้อมูลพิกเซล คุณสามารถใช้อินสแตนซ์ของคลาสนี้เพื่อบันทึกภาพในรูปแบบต่างๆ มากมาย (BMP, JPG, PNG เป็นต้น).

## **แปลงสไลด์เป็นบิทแมปและบันทึกภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจ็กต์บิทแมปและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็นบิทแมปแล้วบันทึกภาพเป็น JPEG หรือรูปแบบที่คุณต้องการอื่นๆ

โค้ด C++ นี้แสดงวิธีแปลงสไลด์แรกของการนำเสนอเป็นอ็อบเจ็กต์บิทแมปและบันทึกภาพเป็นรูปแบบ PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// แปลงสไลด์แรกในงานนำเสนอเป็นบิทแมป.
auto image = presentation->get_Slide(0)->GetImage();

// บันทึกภาพในรูปแบบ PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

คุณอาจต้องการภาพที่มีขนาดเฉพาะ โดยใช้การโอเวอร์โหลดจาก [GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) คุณสามารถแปลงสไลด์เป็นภาพด้วยมิติที่กำหนด (ความกว้างและความสูง).

ตัวอย่างโค้ดนี้แสดงวิธีทำเช่นนี้:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// แปลงสไลด์แรกในงานนำเสนอเป็นบิทแมปด้วยขนาดที่กำหนด.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// บันทึกภาพในรูปแบบ JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์ที่มีบันทึกย่อและคอมเมนต์เป็นภาพ**

สไลด์บางสไลด์อาจมีบันทึกย่อและคอมเมนต์

Aspose.Slides มีอินเทอร์เฟซสองตัว—[ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/irenderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์การนำเสนอเป็นภาพ ทั้งสองอินเทอร์เฟซมีเมธอด `set_SlidesLayoutOptions` ซึ่งช่วยให้คุณกำหนดการเรนเดอร์บันทึกย่อและคอมเมนต์บนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกย่อและคอมเมนต์ในภาพที่ได้

โค้ด C++ นี้แสดงวิธีแปลงสไลด์ที่มีบันทึกย่อและคอมเมนต์:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // กำหนดตำแหน่งของบันทึกย่อ.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // กำหนดตำแหน่งของคอมเมนต์.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // กำหนดความกว้างของพื้นที่คอมเมนต์.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // กำหนดสีของพื้นที่คอมเมนต์.

// สร้างตัวเลือกการเรนเดอร์.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// แปลงสไลด์แรกของงานนำเสนอเป็นภาพ.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// บันทึกภาพในรูปแบบ GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นภาพใดๆ เมธอด [set_NotesPosition](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) ไม่สามารถใช้ค่า `BottomFull` (เพื่อระบุตำแหน่งของบันทึกย่อ) ได้ เนื่องจากข้อความของบันทึกย่ออาจใหญ่เกินไป ทำให้ไม่สามารถพอดีกับขนาดภาพที่กำหนด. 
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) ให้การควบคุมที่มากขึ้นของภาพ TIFF ที่ได้โดยให้คุณระบุพารามิเตอร์ต่างๆ เช่น ขนาด ความละเอียด พาเลทสี และอื่นๆ

โค้ด C++ นี้แสดงกระบวนการแปลงที่ใช้ตัวเลือก TIFF เพื่อสร้างภาพขาวดำที่มีความละเอียด 300 DPI และขนาด 2160 × 2800:

```cpp 
// โหลดไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ดึงสไลด์แรกจากงานนำเสนอ.
auto slide = presentation->get_Slide(0);

// กำหนดค่าการตั้งค่าของภาพ TIFF ขาออก.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // กำหนดขนาดของภาพ.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // กำหนดรูปแบบพิกเซล (ขาว-ดำ).
tiffOptions->set_DpiX(300);                                         // กำหนดความละเอียดแนวนอน.
tiffOptions->set_DpiY(300);                                         // กำหนดความละเอียดแนวตั้ง.

// แปลงสไลด์เป็นภาพด้วยตัวเลือกที่กำหนด.
auto image = slide->GetImage(tiffOptions);

// บันทึกภาพในรูปแบบ TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides ให้คุณแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ ทำให้สามารถแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพได้

ตัวอย่างโค้ดนี้แสดงวิธีแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพด้วย C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// เรนเดอร์งานนำเสนอเป็นภาพสไลด์ต่อสไลด์.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่เรนเดอร์สไลด์ที่ซ่อน).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // แปลงสไลด์เป็นภาพ.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // บันทึกภาพในรูปแบบ JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **การแสดงผลอีโมจีสี**

{{% alert title="Note" color="warning" %}} 
เพื่อให้การแสดงผลอีโมจีสีถูกต้องเมื่อแปลงสไลด์การนำเสนอเป็นภาพ ฟอนต์อีโมจีที่ใช้ในงานนำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ อีโมจีอาจปรากฏเป็นสีเดียวในภาพผลลัพธ์. 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**  
ไม่, เมธอด `GetImage` จะบันทึกเป็นภาพคงที่ของสไลด์เท่านั้น ไม่มีแอนิเมชัน.

**สไลด์ที่ซ่อนอยู่สามารถส่งออกเป็นภาพได้หรือไม่?**  
ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงตรวจให้แน่ใจว่าได้รวมไว้ในลูปการประมวลผล.

**สามารถบันทึกภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**  
ได้, Aspose.Slides รองรับการเรนเดอร์เงา ความโปร่งใส และเอฟเฟกต์กราฟิกอื่นๆ เมื่อบันทึกสไลด์เป็นภาพ.