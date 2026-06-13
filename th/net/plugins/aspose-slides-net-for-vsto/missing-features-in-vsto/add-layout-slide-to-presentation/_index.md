---
title: เพิ่ม Layout สไลด์ไปยังงานนำเสนอ
type: docs
weight: 10
url: /th/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET ช่วยให้นักพัฒนาสามารถเพิ่มสไลด์ Layout ใหม่ในงานนำเสนอได้ เพื่อเพิ่มสไลด์ Layout ให้ทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- เข้าถึงคอลเลกชัน Master Slide
- พยายามค้นหาสไลด์ Layout ที่มีอยู่เพื่อดูว่าต้องการสไลด์นั้นมีอยู่ในคอลเลกชัน Layout Slide หรือไม่
- เพิ่มสไลด์ Layout ใหม่หากไม่มี Layout ที่ต้องการ
- เพิ่มสไลด์ว่างโดยใช้ Layout Slide ที่เพิ่งเพิ่ม
- สุดท้ายให้บันทึกไฟล์งานนำเสนอด้วยอ็อบเจกต์ Presentation
## **ตัวอย่าง**
``` csharp

 //สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ

using (Presentation p = new Presentation("Test.pptx"))

{

   // พยายามค้นหาโดยประเภทสไลด์ Layout

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // สถานการณ์ที่งานนำเสนอไม่มีบางประเภทของ Layout

     // งานนำเสนอ Technographics.pptx มีเฉพาะประเภท Layout แบบ Blank และ Custom เท่านั้น

     // แต่สไลด์ Layout ที่เป็นประเภท Custom มีชื่อสไลด์ที่แตกต่างกัน,

     // เช่น "Title", "Title and Content", เป็นต้น และสามารถใช้เหล่านี้

     // ชื่อเหล่านี้สำหรับการเลือก Layout สไลด์

     // นอกจากนี้ยังสามารถใช้ชุดของประเภท placeholder shape ได้ ตัวอย่างเช่น,

     // สไลด์ Title ควรมีเฉพาะ placeholder ประเภท Title เท่านั้น เป็นต้น

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

  //เพิ่มสไลด์ว่างด้วย Layout สไลด์ที่เพิ่ม

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //บันทึกงานนำเสนอ

  p.Save("Output.pptx", SaveFormat.Pptx);

}
``` 
## **ดาวน์โหลดตัวอย่างที่ทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

สำหรับรายละเอียดเพิ่มเติม โปรดเยี่ยมชม [ใช้หรือเปลี่ยนการจัดวางสไลด์ใน .NET](/slides/th/net/slide-layout/).

{{% /alert %}}