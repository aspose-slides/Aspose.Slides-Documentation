---
title: เพิ่มสไลด์ Layout ไปยังงานนำเสนอ
type: docs
weight: 20
url: /th/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET ช่วยให้นักพัฒนาสามารถเพิ่มสไลด์ Layout ใหม่ในงานนำเสนอได้ เพื่อเพิ่มสไลด์ Layout โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- เข้าถึงคอลเลกชัน Master Slide
- พยายามค้นหาสไลด์ Layout ที่มีอยู่เพื่อดูว่าต้องการสไลด์นั้นมีอยู่ในคอลเลกชัน Layout Slide หรือไม่
- เพิ่มสไลด์ Layout ใหม่หากไม่มี Layout ที่ต้องการ
- เพิ่มสไลด์เปล่าที่ใช้ Layout ใหม่ที่เพิ่มเข้ามา
- สุดท้ายให้บันทึกไฟล์งานนำเสนอโดยใช้วัตถุ Presentation
## **ตัวอย่าง**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
using (Presentation p = new Presentation(FileName))
{
    // พยายามค้นหาโดยประเภทสไลด์ Layout
    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide =
        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??
        layoutSlides.GetByType(SlideLayoutType.Title);
    if (layoutSlide == null)
    {
        // สถานการณ์ที่งานนำเสนอไม่มีประเภท Layout บางประเภท.
        // งานนำเสนอ Technographics.pptx มีเฉพาะประเภท Layout แบบ Blank และ Custom เท่านั้น.
        // แต่สไลด์ Layout ที่เป็นประเภท Custom มีชื่อสไลด์ที่แตกต่างกัน,
        // เช่น "Title", "Title and Content" เป็นต้น และสามารถใช้สิ่งเหล่านี้
        // เป็นชื่อในการเลือกสไลด์ Layout.
        // นอกจากนี้ยังสามารถใช้ชุดประเภทรูปทรง placeholder ได้ ตัวอย่างเช่น,
        // สไลด์ Title ควรมีเฉพาะประเภท placeholder Title เท่านั้น เป็นต้น.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }
    //เพิ่มสไลด์เปล่าที่ใช้สไลด์ Layout ที่เพิ่มเข้ามา 
    p.Slides.InsertEmptySlide(0, layoutSlide);
    //บันทึกงานนำเสนอ    
    p.Save(FileName, SaveFormat.Pptx);
}
``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **ดาวน์โหลดตัวอย่างที่ทำงานได้**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
สำหรับรายละเอียดเพิ่มเติม โปรดเยี่ยมชม [ใช้หรือเปลี่ยนรูปแบบสไลด์ใน .NET](/slides/th/net/slide-layout/).
{{% /alert %}}