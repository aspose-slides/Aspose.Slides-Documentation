---
title: รูปแบบไฟล์ที่รองรับ
type: docs
weight: 96
url: /th/net/supported-file-formats/
keywords:
- รูปแบบไฟล์ที่รองรับ
- โหลดการนำเสนอ
- นำเข้า PDF
- นำเข้า HTML
- บันทึกการนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "ดูว่ารูปแบบไฟล์ใดที่ Aspose.Slides for .NET สามารถโหลด, นำเข้า, บันทึก, และเรนเดอร์ได้, และ API ใดที่อ่านหรือเขียนแต่ละรูปแบบ"
---
## **ภาพรวม**

Aspose.Slides for .NET เปิดและบันทึกการนำเสนอ PowerPoint และ OpenDocument นอกจากนี้ยังนำเข้าเนื้อหา PDF และ HTML ไปยังสไลด์ บันทึกการนำเสนอเป็นรูปแบบเอกสาร เว็บ และภาพ และเรนเดอร์สไลด์และรูปร่างแต่ละอันเป็นภาพ บทความนี้แสดงรายการรูปแบบที่รองรับทั้งหมดและระบุ API ที่ใช้ในการอ่านหรือเขียนแต่ละรูปแบบ

แพ็คเกจ NuGet ทั้งสอง, Aspose.Slides.NET และ Aspose.Slides.NET6.CrossPlatform, รองรับรูปแบบเดียวกัน; ดู [การติดตั้ง](/slides/th/net/installation/) เพื่อเลือกใช้ระหว่างพวกมัน สำหรับภาพรวมของคุณสมบัติการแก้ไข, ดู [ภาพรวมคุณสมบัติ](/slides/th/net/features-overview/)

## **เวอร์ชัน Microsoft PowerPoint ที่รองรับ**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

การนำเสนอที่บันทึกโดย PowerPoint 95 และเวอร์ชันก่อนหน้านั้นไม่สามารถเปิดได้. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) จะตรวจจับไฟล์ PowerPoint 95 และรายงาน `LoadFormat.Ppt95`, แต่คอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) จะโยน [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) สำหรับไฟล์นั้น

{{% /alert %}}

## **รูปแบบไฟล์ที่รองรับ**

ตารางนี้ใช้การดำเนินการสี่แบบ:

- **Load**: คอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) เปิดไฟล์เป็นการนำเสนอที่สามารถแก้ไขได้
- **Import**: วิธีของ [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) สร้างสไลด์จากเนื้อหาไฟล์และเพิ่มลงในการนำเสนอที่มีอยู่ คอนสตรัคเตอร์ Presentation ไม่ได้โหลดไฟล์เหล่านี้เป็นการนำเสนอ
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) เขียนการนำเสนอไปยังไฟล์หรือสตรีม ทุกรูปแบบยกเว้น XAML จะถูกเลือกโดยค่า [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
- **Render**: วิธีการเรนเดอร์วาดสไลด์หรือรูปร่างเป็นภาพ รูปแบบที่สามารถเรนเดอร์ได้เท่านั้นไม่มีค่า SaveFormat

|**รูปแบบ**|**คำอธิบาย**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|การนำเสนอ PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|เทมเพลต PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|การแสดงสไลด์ PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|การนำเสนอ PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|เทมเพลต PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|การแสดงสไลด์ PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|การนำเสนอ PowerPoint ที่รองรับแมโคร|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|เทมเพลต PowerPoint ที่รองรับแมโคร|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|การแสดงสไลด์ PowerPoint ที่รองรับแมโคร|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|การนำเสนอ OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|การนำเสนอ OpenDocument แบบ Flat XML|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|เทมเพลตการนำเสนอ OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|การนำเสนอ PowerPoint XML|Load|Save|`SaveFormat.Xml`; ไฟล์ที่โหลดจะรายงาน `SourceFormat.Xml` (ไม่มีค่า `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (หนึ่งสไลด์)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (แอนิเมชัน, ทุกสไลด์); `ImageFormat.Gif` (หนึ่งสไลด์)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.Save(IXamlOptions)`, หนึ่งไฟล์ XAML ต่อสไลด์; ไม่ใช่ค่า `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **โหลดและนำเข้า**

- **Load:** ส่งพาธไฟล์หรือสตรีมไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) รูปแบบจะถูกตรวจจับจากเนื้อหา; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ให้การตั้งค่าเช่นรหัสผ่าน เพื่อเช็คไฟล์ก่อนเปิด, เรียก [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) ซึ่งจะรายงานค่า [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/). มันรายงาน `LoadFormat.Unknown` สำหรับ PowerPoint XML, แต่คอนสตรัคเตอร์จะเปิดไฟล์นั้นและ [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) จะคืนค่า `SourceFormat.Xml`. ดู [เปิดการนำเสนอ](/slides/th/net/open-presentation/) และ [กำหนดรูปแบบต้นฉบับของการนำเสนอ](/slides/th/net/detect-presentation-source-format/).
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) จะเพิ่มสไลด์หนึ่งหน้าต่อหนึ่งหน้า PDF ไปยังส่วนท้ายของการนำเสนอ. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) จะเพิ่มสไลด์ที่สร้างจาก HTML, และ [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) จะแทรกสไลด์เหล่านั้นในตำแหน่งที่กำหนด. คอนสตรัคเตอร์ Presentation ไม่ได้ทำการนำเข้า: มันจะโยน [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) สำหรับไฟล์ PDF และไม่แปลงมาร์กอัป HTML เป็นเนื้อหาในสไลด์. ดู [นำเข้าการนำเสนอจาก PDF หรือ HTML](/slides/th/net/import-presentation/).

## **บันทึกและเรนเดอร์**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) เขียนการนำเสนอในรูปแบบของค่า [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). overload ที่รับอ็อบเจกต์ options จะควบคุมผลลัพธ์, เช่น [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), และ [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). overload ที่รับอาร์เรย์ของตำแหน่งสไลด์ (เริ่มจาก 1) จะบันทึกเฉพาะสไลด์เหล่านั้น; มันรองรับ PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, และ Markdown, แต่ไม่รองรับรูปแบบการนำเสนอหรือ PowerPoint XML. XAML มี overload เฉพาะที่รับ [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/). ดู [บันทึกการนำเสนอ](/slides/th/net/save-presentation/), [แปลงการนำเสนอ](/slides/th/net/convert-presentation/), และ [ส่งออกการนำเสนอเป็น XAML](/slides/th/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) และ [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ส่งคืน [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), และ [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) จะบันทึกเป็น PNG, JPEG, BMP, GIF หรือ TIFF ตามค่า [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) จะเรนเดอร์สไลด์ทั้งหมดหรือสไลด์ที่เลือกพร้อมกัน. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) และ [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) เขียน SVG, ส่วน [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) เขียน EMF. ดู [แปลงสไลด์การนำเสนอเป็นภาพ](/slides/th/net/convert-slide/) และ [เรนเดอร์สไลด์เป็นภาพ SVG](/slides/th/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat ยังมีค่า `Emf`, `Wmf`, `Icon`, `Exif`, และ `MemoryBmp`, แต่ IImage.Save ไม่ได้สร้างรูปแบบเหล่านั้น: ไฟล์ที่เขียนออกมาจะมีข้อมูล PNG. หากต้องการภาพ EMF ของสไลด์, ใช้ Slide.WriteAsEmf

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงการนำเสนอ PPT เป็น PPTX หรือ ODP ได้หรือไม่?**

ได้. เปิดไฟล์ PPT ด้วยคอนสตรัคเตอร์ Presentation แล้วบันทึกด้วย `SaveFormat.Pptx` หรือ `SaveFormat.Odp`. ดู [แปลง PPT เป็น PPTX](/slides/th/net/convert-ppt-to-pptx/).

**ฉันสามารถเปิดไฟล์ PDF หรือ HTML เป็นการนำเสนอได้หรือไม่?**

ไม่ได้. สร้างหรือเปิดการนำเสนอ, นำเข้าหน้ากระดาษ PDF หรือเนื้อหา HTML ลงในนั้นด้วยวิธีของ SlideCollection ที่อธิบายด้านบน, จากนั้นบันทึกในรูปแบบที่รองรับใด ๆ

**ฉันสามารถโหลดภาพ PNG หรือ SVG ที่ส่งออกเป็นการนำเสนอที่แก้ไขได้หรือไม่?**

ไม่ได้. ผลลัพธ์ภาพบันทึกลักษณะการแสดงของสไลด์เท่านั้น, ไม่ได้บันทึกข้อความ, รูปร่าง หรือแผนภูมิ. หากต้องการแก้ไขในภายหลัง, ควรเก็บไฟล์การนำเสนอเดิมไว้

**ฉันสามารถบันทึกเอกสาร PDF/A หรือ PDF/UA ได้หรือไม่?**

ได้. ตั้งค่า [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) เป็นค่า [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) ที่ต้องการ: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b หรือ PDF/UA

**ฉันสามารถตรวจสอบว่าไฟล์ถูกป้องกันด้วยรหัสผ่านก่อนเปิดหรือไม่?**

ได้. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) ตรวจสอบไฟล์โดยไม่สร้างอ็อบเจกต์ Presentation, และคุณสมบัติ [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) จะรายงานว่าต้องใช้รหัสผ่านหรือไม่. ดู [การป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/net/password-protected-presentation/)

**แพ็คเกจ NuGet สองชุดสนับสนุนรูปแบบต่างกันหรือไม่?**

ไม่. Aspose.Slides.NET และ Aspose.Slides.NET6.CrossPlatform มีค่า LoadFormat และ SaveFormat เหมือนกัน รวมถึงวิธีการนำเข้าและเรนเดอร์เดียวกัน. ความแตกต่างอยู่ที่แพลตฟอร์มที่ทำงานและความต้องการของแพลตฟอร์มนั้น ๆ; ดู [การติดตั้ง](/slides/th/net/installation/)