---
title: การแปลงเป็น HTML
type: docs
weight: 20
url: /th/net/conversion-to-html/
---
**HTML** เป็นหนึ่งในหลายรูปแบบที่ใช้กันอย่างแพร่หลายสำหรับการแลกเปลี่ยนข้อมูล **Aspose.Slides for .NET** ให้การสนับสนุนการแปลงงานนำเสนอเป็น HTML ด้านล่างเป็นโค้ดตัวอย่างที่แสดงวิธีทำ

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//สร้างวัตถุ Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน
Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//บันทึกพรีเซนเทชันเป็น HTML
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)