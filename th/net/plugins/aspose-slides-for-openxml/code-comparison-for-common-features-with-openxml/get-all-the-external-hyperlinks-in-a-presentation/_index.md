---
title: ดึงไฮเปอร์ลิงก์ภายนอกทั้งหมดในงานนำเสนอ
type: docs
weight: 90
url: /th/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **การนำเสนอ OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// ส่งคืนไฮเปอร์ลิงก์ภายนอกทั้งหมดในสไลด์ของงานนำเสนอ.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// ประกาศรายการของสตริง.

List<string> ret = new List<string>();

// เปิดไฟล์งานนำเสนอในโหมดอ่านอย่างเดียว.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // วนซ้ำผ่านส่วนสไลด์ทั้งหมดในส่วนของงานนำเสนอ.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // วนซ้ำผ่านลิงก์ทั้งหมดในส่วนสไลด์.

        foreach (Drawing.HyperlinkType link in links)

        {

            // วนซ้ำผ่านความสัมพันธ์ภายนอกทั้งหมดในส่วนสไลด์. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // หาก ID ของความสัมพันธ์ตรงกับ ID ของลิงก์...

                if (relation.Id.Equals(link.Id))

                {

                    // เพิ่ม URI ของความสัมพันธ์ภายนอกลงในรายการสตริง.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// ส่งคืนรายการสตริง.

return ret;

}
``` 
## **Aspose.Slides**
Aspose.Slides for .NET ช่วยให้ผู้พัฒนาสามารถจัดการไฮเปอร์ลิงก์ในงานนำเสนอระดับการนำเสนอ สไลด์ และกรอบข้อความได้ คลาส **IHyperlinkQueries** ช่วยจัดการไฮเปอร์ลิงก์ในงานนำเสนอ

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX

Presentation pres = new Presentation(FileName);

//ดึงไฮเปอร์ลิงก์จากงานนำเสนอ

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **ดาวน์โหลดตัวอย่างโค้ดที่ทำงานได้**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **ตัวอย่างโค้ด**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)