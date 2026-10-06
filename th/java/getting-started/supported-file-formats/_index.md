---
title: รูปแบบไฟล์ที่รองรับ
type: docs
weight: 106
url: /th/java/supported-file-formats/
keywords:
- รูปแบบไฟล์ที่รองรับ
- โหลดงานนำเสนอ
- นำเข้า PDF
- นำเข้า HTML
- บันทึกงานนำเสนอ
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
- Java
- Aspose.Slides
description: "ดูว่า Aspose.Slides for Java รองรับการโหลด, นำเข้า, บันทึกและเรนเดอร์ไฟล์รูปแบบใดบ้าง และ API ตัวใดอ่านหรือเขียนแต่ละรูปแบบ"
---
## **Overview**

Aspose.Slides for Java เปิดและบันทึกงานนำเสนอ PowerPoint และ OpenDocument รวมถึงนำเข้าเนื้อหา PDF และ HTML ไปยังสไลด์ บันทึกงานนำเสนอเป็นรูปแบบเอกสาร เว็บ และรูปภาพ และเรนเดอร์สไลด์หรือรูปร่างแต่ละอันเป็นภาพ บทความนี้ระบุรูปแบบที่รองรับทั้งหมดและบอก API ที่อ่านหรือเขียนแต่ละรูปแบบ

สำหรับภาพรวมของคุณลักษณะการแก้ไข ดูที่ [Features Overview](/slides/th/java/features-overview/)

## **Supported Microsoft PowerPoint Versions**

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

งานนำเสนอที่บันทึกด้วย PowerPoint 95 และเวอร์ชันก่อนหน้านั้นไม่สามารถเปิดได้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) จะตรวจพบไฟล์ PowerPoint 95 แล้วรายงาน `LoadFormat.Ppt95` แต่คอนสัทรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) จะโยน [PptUnsupportedFormatException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptunsupportedformatexception/) สำหรับไฟล์ดังกล่าว

{{% /alert %}}

## **Supported File Formats**

ตารางนี้ใช้สี่การดำเนินการ:

- **Load**: คอนสัทรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) เปิดไฟล์เป็นงานนำเสนอที่แก้ไขได้
- **Import**: เมธอดของ [SlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/) สร้างสไลด์จากเนื้อหาไฟล์และเพิ่มลงในงานนำเสนอที่มีอยู่ คอนสัทรัคเตอร์ของ Presentation ไม่ได้แปลงไฟล์เหล่านี้เป็นสไลด์
- **Save**: [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เขียนงานนำเสนอลงไฟล์หรือสตรีม ทุกรูปแบบยกเว้น XAML จะเลือกด้วยค่า [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/)
- **Render**: เมธอดการเรนเดอร์วาดสไลด์หรือรูปร่างเป็นภาพ รูปแบบที่รองรับการเรนเดอร์เท่านั้นจะไม่มีค่า SaveFormat

|**Format**|**Description**|**Load / Import**|**Save / Render**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|งานนำเสนอ PowerPoint 97‑2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|แม่แบบ PowerPoint 97‑2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|การแสดงสไลด์ PowerPoint 97‑2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|งานนำเสนอ PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|แม่แบบ PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|การแสดงสไลด์ PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|งานนำเสนอ PowerPoint ที่เปิดใช้งานมาโคร|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|แม่แบบ PowerPoint ที่เปิดใช้งานมาโคร|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|การแสดงสไลด์ PowerPoint ที่เปิดใช้งานมาโคร|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|งานนำเสนอ OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|งานนำเสนอ Flat XML OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|แม่แบบงานนำเสนอ OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|งานนำเสนอ PowerPoint XML|Load|Save|`SaveFormat.Xml`; ไฟล์ที่โหลดจะรายงาน `SourceFormat.Xml` (ไม่มีค่า `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff` (หนึ่งหน้าต่อสไลด์); `ImageFormat.Tiff` (หนึ่งสไลด์)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (แบบเคลื่อนไหว, ทั้งสไลด์); `ImageFormat.Gif` (หนึ่งสไลด์)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, หนึ่งไฟล์ XAML ต่อสไลด์; ไม่ใช่ค่า `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Load and Import**

- **Load:** ส่งพาธไฟล์หรือสตรีมไปยังคอนสัทรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) รูปแบบจะตรวจจับจากเนื้อหา; [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) ให้ตั้งค่าเช่น รหัสผ่าน เพื่อเช็คไฟล์ก่อนเปิด ให้เรียก [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ซึ่งจะรายงานค่า [LoadFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadformat/) จะรายงาน `LoadFormat.Unknown` สำหรับ PowerPoint XML แต่คอนสัทรัคเตอร์จะเปิดไฟล์ดังกล่าวได้และ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSourceFormat--) จะคืนค่า `SourceFormat.Xml` ดูที่ [Open Presentations](/slides/th/java/open-presentation/) และ [Determine the Original Presentation Format](/slides/th/java/detect-presentation-source-format/)
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) เพิ่มหนึ่งสไลด์ต่อหน้า PDF ที่ส่วนท้ายของงานนำเสนอ [SlideCollection.addFromHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) เพิ่มสไลด์ที่สร้างจาก HTML และ [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) แทรกสไลด์เหล่านั้นที่ตำแหน่งที่ระบุ คอนสัทรัคเตอร์ของ Presentation ไม่ทำการอิมพอร์ต: จะโยน [PptUnsupportedFormatException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptunsupportedformatexception/) สำหรับไฟล์ PDF และไม่แปลง HTML ให้เป็นเนื้อหาสไลด์ ดูที่ [Import Presentations from PDF or HTML](/slides/th/java/import-presentation/)

## **Save and Render**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) เขียนงานนำเสนอในรูปแบบตามค่าของ [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) มีโอเวอร์โหลดที่รับอ็อบเจ็กต์ options ควบคุมผลลัพธ์ เช่น [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/), และ [GifOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/gifoptions/). โอเวอร์โหลดที่รับอาร์เรย์ของตำแหน่งสไลด์ (เริ่มจาก 1) จะบันทึกเฉพาะสไลด์เหล่านั้น; รองรับ PDF, XPS, TIFF, HTML, HTML5, SWF, GIF และ Markdown แต่ไม่รองรับรูปแบบงานนำเสนอหรือ PowerPoint XML XAML มีโอเวอร์โหลดเฉพาะของมันเองคือ [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) ที่รับ [IXamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloptions/). ดูที่ [Save Presentations](/slides/th/java/save-presentation/), [Convert Presentations](/slides/th/java/convert-presentation/), และ [Export Presentations to XAML](/slides/th/java/export-to-xaml/)
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#getImage-float-float-) และ [Shape.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage--) คืนค่า [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/), และ [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-) เขียนเป็น PNG, JPEG, BMP, GIF หรือ TIFF โดยเลือกด้วยค่า [ImageFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) เรนเดอร์สไลด์ทั้งหมดหรือสไลด์ที่เลือกพร้อมกัน [Slide.writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) และ [Shape.writeAsSvg](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) เขียน SVG, และ [Slide.writeAsEmf](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) เขียน EMF. ดูที่ [Convert Presentation Slides to Images](/slides/th/java/convert-slide/) และ [Render Presentation Slides as SVG Images](/slides/th/java/render-a-slide-as-an-svg-image/)

{{% alert color="warning" title="Warning" %}}

ImageFormat ยังมีค่า `Emf`, `Wmf`, `Icon`, `Exif` และ `MemoryBmp` แต่ IImage.save ไม่สร้างรูปแบบเหล่านั้น: ไฟล์ที่บันทึกจะมีข้อมูล PNG เพื่อให้ได้ภาพ EMF ของสไลด์ ให้ใช้ Slide.writeAsEmf

{{% /alert %}}

## **FAQ**

**Can I convert a PPT presentation to PPTX or ODP?**

ได้ เปิดไฟล์ PPT ด้วยคอนสัทรัคเตอร์ Presentation แล้วบันทึกด้วย `SaveFormat.Pptx` หรือ `SaveFormat.Odp` ดูที่ [Convert PPT to PPTX](/slides/th/java/convert-ppt-to-pptx/)

**Can I open a PDF or HTML file as a presentation?**

ไม่ได้ คอนสัทรัคเตอร์ Presentation จะโยน PptUnsupportedFormatException สำหรับไฟล์ PDF และไม่แปลง HTML ให้เป็นสไลด์ สร้างหรือเปิดงานนำเสนอแล้วนำเข้าหน้า PDF หรือเนื้อหา HTML ด้วยเมธอดของ SlideCollection ตามที่อธิบายด้านบน แล้วบันทึกในรูปแบบที่สนับสนุนใดก็ได้

**Can I load an exported PNG or SVG image as an editable presentation?**

ไม่ได้ ผลลัพธ์ของภาพเป็นเพียงการบันทึกลักษณะการแสดงของสไลด์ ไม่ได้บันทึกข้อความ รูปร่าง หรือแผนภูมิ ควรเก็บไฟล์งานนำเสนอเดิมไว้หากต้องการแก้ไขต่อในภายหลัง

**Can I save PDF/A or PDF/UA documents?**

ได้ ส่งค่า [PdfCompliance](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfcompliance/) ไปยัง [PdfOptions.setCompliance](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b หรือ PDF/UA

**Can I check whether a file is password‑protected before opening it?**

ได้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ตรวจสอบไฟล์โดยไม่ต้องสร้างอ็อบเจ็กต์ Presentation และ [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) จะบอกว่าต้องใช้รหัสผ่านหรือไม่ ดูที่ [Password‑Protect Presentations](/slides/th/java/password-protected-presentation/)