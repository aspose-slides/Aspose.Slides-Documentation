---
title: รับรูปแบบไฟล์ของการพรีเซนเทชัน
type: docs
weight: 50
url: /th/net/get-the-file-format-of-presentation/
---
เพื่อรับรูปแบบไฟล์ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส **IPresentationInfo**
- รับข้อมูลเกี่ยวกับการพรีเซนเทชัน

ในตัวอย่างที่ให้ด้านล่าง เราได้รับรูปแบบไฟล์แล้ว.
## **ตัวอย่าง**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **ดาวน์โหลดตัวอย่างที่ทำงานได้**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)