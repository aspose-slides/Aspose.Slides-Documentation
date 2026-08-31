---
title: การแปลงเป็น Tiff พร้อมโน้ต
type: docs
weight: 10
url: /th/net/conversion-to-tiff-with-notes/
---
TIFF เป็นหนึ่งในหลายรูปแบบภาพที่ใช้กันอย่างกว้างขวางที่ Aspose.Slides for .NET รองรับสำหรับการแปลงพรีเซนเทชันที่มีโน้ตเป็นภาพ คุณยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide ได้ ด้านล่างคือโค้ดสแนปสองส่วนที่แสดงวิธีการสร้างภาพ TIFF ของพรีเซนเทชันในมุมมอง Notes Slide

**Save** เมธอดที่เปิดเผยโดยคลาส **Presentation** สามารถใช้เพื่อแปลงพรีเซนเทชันทั้งหมดในมุมมอง Notes Slide เป็น TIFF คุณยังสามารถสร้างภาพย่อของสไลด์ในมุมมอง Notes Slide สำหรับสไลด์แต่ละอันได้

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน
using (Presentation pres = new Presentation(srcFileName))
{
    //วางโน้ตผู้บรรยายใต้สไลด์ที่แสดงแต่ละสไลด์
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //บันทึกพรีเซนเทชันเป็น TIFF พร้อมโน้ต
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)