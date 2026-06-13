---
title: แสดงเป็น Tiff ด้วยมิติที่ผู้กำหนด
type: docs
weight: 40
url: /th/net/rendered-as-tiff-by-user-defined-dimension/
---
ตัวอย่างต่อไปนี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร TIFF ด้วยขนาดภาพที่กำหนดเองโดยใช้คลาส **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//สร้างอ็อบเจ็กต์ Presentation ที่แสดงถึงไฟล์ Presentation
Presentation pres = new Presentation(srcFileName);

//สร้างคลาส TiffOptions
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//กำหนดประเภทการบีบอัด
opts.CompressionType = TiffCompressionTypes.Default;

//ประเภทการบีบอัด
//Default - ระบุโครงร่างการบีบอัดเริ่มต้น (LZW).
//None - ระบุว่าจะไม่มีการบีบอัด
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - ขึ้นอยู่กับประเภทการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.
//Resolution unit - จะเท่ากับ "2" เสมอ (จุดต่อ นิ้ว)

//กำหนด DPI ของภาพ
opts.DpiX = 200;

opts.DpiY = 100;

//ตั้งขนาดภาพ
opts.ImageSize = new Size(1728, 1078);

//บันทึกการนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)