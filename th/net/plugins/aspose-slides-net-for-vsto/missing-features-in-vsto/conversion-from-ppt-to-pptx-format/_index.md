---
title: การแปลงจาก PPT เป็นรูปแบบ PPTX
type: docs
weight: 20
url: /th/net/conversion-from-ppt-to-pptx-format/
---
ฟีเจอร์เฉพาะของ Aspose.Slides ที่ให้ความยืดหยุ่นในการแปลงรุ่นโดยไม่กระทบต่อการทำงาน  
SaveFormat เป็น enumeration ที่สามารถแปลงเอกสารเป็นนามสกุลตามที่ระบุในตารางด้านล่าง  

|**ชื่อสมาชิก**|**ค่า**|**คำอธิบาย**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |

ด้านล่างเป็นโค้ดตัวอย่างที่แสดงการแปลงจาก PPT เป็น PPTX คุณสามารถทำแบบกลับกันได้เช่นกัน  

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation(srcFileName);

//กำลังบันทึกงานนำเสนอ PPTX ไปยังรูปแบบ PPTX
pres.Save(destFileName, SaveFormat.Pptx);
``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)