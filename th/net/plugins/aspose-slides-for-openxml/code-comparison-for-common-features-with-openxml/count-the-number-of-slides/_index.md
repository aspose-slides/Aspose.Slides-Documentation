---
title: นับจำนวนสไลด์
type: docs
weight: 50
url: /th/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// รับอ็อบเจ็กต์พรีเซนเทชันและส่งต่อไปยังเมธอด CountSlides ถัดไป.

public static int CountSlides(string presentationFile)

{

    // เปิดพรีเซนเทชันในโหมดอ่านอย่างเดียว.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ส่งพรีเซนเทชันไปยังเมธอด CountSlide ถัดไป

        // และคืนค่าจำนวนสไลด์.

        return CountSlides(presentationDocument);

    }

}

// นับจำนวนสไลด์ในพรีเซนเทชัน.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // ตรวจสอบว่าอ็อบเจ็กต์เอกสารเป็น null หรือไม่.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ดึงส่วนพรีเซนเทชันของเอกสาร.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // ดึงจำนวนสไลด์จาก SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // คืนค่าจำนวนสไลด์ให้เมธอดก่อนหน้า.

    return slidesCount;

} 
```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //สร้างอ็อบเจ็กต์ PresentationEx ที่เป็นตัวแทนของไฟล์ PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

```
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)