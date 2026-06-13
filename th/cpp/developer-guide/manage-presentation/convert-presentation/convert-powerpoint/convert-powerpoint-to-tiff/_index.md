---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF ด้วย C++
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/cpp/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- การนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายด้วย Aspose.Slides สำหรับ C++ พร้อมตัวอย่างโค้ด"
---
## **เบื้องต้น**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่สูญเสียข้อมูลที่ได้รับการใช้อย่างกว้างขวาง เนื่องจากคุณภาพที่ยอดเยี่ยมและการเก็บรายละเอียดของกราฟิกอย่างละเอียด นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้นภาพ, ความแม่นยำของสี, และการตั้งค่าต้นฉบับในภาพของพวกเขา

โดยใช้ Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ให้เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความคมชัดสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

ด้วยเมธอด [Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ด C++ ตัวนี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น TIFF:

```cpp
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// บันทึกการนำเสนอเป็น TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [set_BwConversionMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) ช่วยให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [set_CompressionType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) ถูกตั้งเป็น `CCITT4` หรือ `CCITT3`.

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ดังต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด C++ ตัวนี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

ผลลัพธ์:

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงการนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถตั้งค่าตามที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/). ตัวอย่างเช่น เมธอด [set_ImageSize](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_imagesize/) ทำให้คุณกำหนดขนาดของภาพที่สร้างขึ้น

โค้ด C++ ตัวนี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```cpp
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// ตั้งค่าประเภทการบีบอัด.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
ประเภทการบีบอัด:
    Default - ระบุแผนการบีบอัดเริ่มต้น (LZW).
    None - ระบุว่าไม่มีการบีบอัด.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// ความลึกขึ้นอยู่กับประเภทการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

// ตั้งค่า DPI ของภาพ.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// ตั้งค่าขนาดภาพ.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// บันทึกการนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพกำหนดเอง**

โดยใช้เมธอด [set_PixelFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่สร้างขึ้น

โค้ด C++ ตัวนี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง:

```cpp
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
    Format1bppIndexed - 1 บิตต่อพิกเซล, ใช้ดรรชนี.
    Format4bppIndexed - 4 บิตต่อพิกเซล, ใช้ดรรชนี.
    Format8bppIndexed - 8 บิตต่อพิกเซล, ใช้ดรรชนี.
    Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
    Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
*/

// บันทึกการนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="เคล็ดลับ" color="primary" %}}
ลองใช้ [ตัวแปลง PowerPoint เป็นโปสเตอร์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดียวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides ให้คุณแปลงสไลด์แต่ละสไลด์จากการนำเสนอ PowerPoint และ OpenDocument ให้เป็นภาพ TIFF ได้แบบแยกส่วน

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่จำกัดจำนวนสไลด์ คุณสามารถแปลงการนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF

**ภาพเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์ของ PowerPoint จะถูกเก็บไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ TIFF เป็นรูปภาพแบบคงที่ ดังนั้นภาพเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ได้รับการเก็บรักษา มีเพียงภาพนิ่งของสไลด์ที่ส่งออกเท่านั้น