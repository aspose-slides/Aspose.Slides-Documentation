---
title: แปลงสไลด์พรีเซนเทชันเป็นภาพใน C++
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
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การพรีเซนเทชัน
- C++
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพใน C++ ด้วย Aspose.Slides—เรนเดอร์ที่รวดเร็วและคุณภาพสูง พร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for C++ ช่วยให้คุณสามารถแปลงสไลด์พรีเซนเทชันของ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่าง ๆ รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ ได้อย่างง่ายดาย

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่คุณต้องการส่งออกโดยใช้:
    - The [ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/irenderingoptions/) interface.
2. Generate the slide image by calling the [GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) method.

A [Bitmap](https://reference.aspose.com/slides/th/cpp/system.drawing/bitmap/) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (BMP, JPG, PNG, etc.).

## **แปลงสไลด์เป็นบิทแมปและบันทึกภาพเป็น PNG**

You can convert a slide to a bitmap object and use it directly in your application. Alternatively, you can convert a slide to a bitmap and then save the image in JPEG or any other preferred format.

This C++ code demonstrates how to convert the first slide of a presentation to a bitmap object and then save the image in PNG format:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// แปลงสไลด์แรกในพรีเซนเทชันเป็นบิตแมพ.
auto image = presentation->get_Slide(0)->GetImage();

// บันทึกภาพในรูปแบบ PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

You may need to get an image of a certain size. Using an overload from the [GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/), you can convert a slide to an image with specific dimensions (width and height). 

This sample code demonstrates how to do this:

```cpp
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// แปลงสไลด์แรกในพรีเซนเทชันเป็นบิตแมพด้วยขนาดที่ระบุ.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// บันทึกภาพในรูปแบบ JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์ที่มีบันทึกและความคิดเห็นเป็นภาพ**

Some slides may contain notes and comments.

Aspose.Slides provides two interfaces—[ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) and [IRenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/irenderingoptions/)—that allow you to control the rendering of presentation slides to images. Both interfaces include the `set_SlidesLayoutOptions` method, which enables you to configure the rendering of notes and comments on a slide when converting it to an image.

With the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) class, you can specify your preferred position for notes and comments in the resulting image.

This C++ code demonstrates how to convert a slide with notes and comments:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์พรีเซนเทชัน.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // ตั้งค่าตำแหน่งของบันทึก.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // ตั้งค่าตำแหน่งของความคิดเห็น.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // ตั้งค่าความกว้างของพื้นที่ความคิดเห็น.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // ตั้งค่าสีสำหรับพื้นที่ความคิดเห็น.

// สร้างตัวเลือกการเรนเดอร์.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// แปลงสไลด์แรกของพรีเซนเทชันเป็นภาพ.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// บันทึกภาพในรูปแบบ GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นภาพใด ๆ วิธีการ [set_NotesPosition](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) ไม่สามารถใช้ `BottomFull` (เพื่อระบุตำแหน่งของบันทึก) ได้ เนื่องจากข้อความของบันทึกอาจมีขนาดใหญ่เกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่กำหนดได้.
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

The [ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) interface provides greater control over the resulting TIFF image by allowing you to specify parameters such as size, resolution, color palette, and more.

This C++ code demonstrates a conversion process where TIFF options are used to output a black-and-white image with a 300 DPI resolution and a size of 2160 × 2800:

```cpp 
// โหลดไฟล์พรีเซนเทชัน.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ดึงสไลด์แรกจากพรีเซนเทชัน.
auto slide = presentation->get_Slide(0);

// กำหนดค่าการตั้งค่าของภาพ TIFF เอาต์พุต.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // ตั้งค่าขนาดภาพ.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // ตั้งค่ารูปแบบพิกเซล (ดำและขาว).
tiffOptions->set_DpiX(300);                                         // ตั้งค่าความละเอียดแนวนอน.
tiffOptions->set_DpiY(300);                                         // ตั้งค่าความละเอียดแนวตั้ง.

// แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
auto image = slide->GetImage(tiffOptions);

// บันทึกภาพในรูปแบบ TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides allows you to convert all slides in a presentation to images, effectively converting the entire presentation into a series of images.

This sample code demonstrates how to convert all slides in a presentation to images in C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// เรนเดอร์พรีเซนเทชันเป็นภาพสไลด์ต่อสไลด์.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // ควบคุมสไลด์ที่ซ่อน (ไม่เรนเดอร์สไลด์ที่ซ่อน).
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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่, วิธีการ `GetImage` จะบันทึกเฉพาะภาพคงที่ของสไลด์เท่านั้น ไม่รวมแอนิเมชัน.

**สามารถส่งออกสไลด์ที่ซ่อนเป็นภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ธรรมดา เพียงตรวจสอบให้แน่ใจว่ามันถูกรวมอยู่ในลูปการประมวลผล.

**สามารถบันทึกภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อตัวบันทึกสไลด์เป็นภาพ.