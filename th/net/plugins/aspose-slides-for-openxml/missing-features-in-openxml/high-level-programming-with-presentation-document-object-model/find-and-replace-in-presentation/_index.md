---
title: ค้นหาและแทนที่ในงานนำเสนอ
type: docs
weight: 20
url: /th/net/find-and-replace-in-presentation/
---
ต่อไปนี้คือขั้นตอนที่ต้องทำ:

1. เปิดงานนำเสนอ.
1. ค้นหาข้อความ.
1. แทนที่ข้อความ.
1. เขียนงานนำเสนอ.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//เปิดงานนำเสนอ

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//รับกล่องข้อความทั้งหมดในงานนำเสนอ

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //ค้นหาข้อความที่ต้องการแทนที่

        if (port.Text.Contains(strToFind))

        //แทนที่ข้อความที่มีอยู่ด้วยข้อความใหม่

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)