---
title: ย้ายสไลด์ไปยังตำแหน่งใหม่
type: docs
weight: 140
url: /th/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// นับจำนวนสไลด์ในงานนำเสนอ.

public static int CountSlides(string presentationFile)

{

    // เปิดงานนำเสนอในโหมดอ่านอย่างเดียว.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ส่งงานนำเสนอไปยังเมธอด CountSlides ถัดไป

        // และคืนค่าจำนวนสไลด์.

        return CountSlides(presentationDocument);

    }

}

// นับจำนวนสไลด์ในงานนำเสนอ.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // ตรวจสอบว่าอ็อบเจ็กต์เอกสารเป็นค่า null หรือไม่.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ดึงส่วนของงานนำเสนอจากเอกสาร.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // ดึงจำนวนสไลด์จาก SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // คืนค่าจำนวนสไลด์กลับไปยังเมธอดก่อนหน้า.

    return slidesCount;

}

// ย้ายสไลด์ไปยังตำแหน่งอื่นในลำดับสไลด์ของงานนำเสนอ.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// ย้ายสไลด์ไปยังตำแหน่งอื่นในลำดับสไลด์ของงานนำเสนอ.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // เรียกเมธอด CountSlides เพื่อรับจำนวนสไลด์ในงานนำเสนอ.

    int slidesCount = CountSlides(presentationDocument);

    // ตรวจสอบว่าตำแหน่ง from และ to อยู่ในช่วงและไม่เท่ากัน.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // ดึงส่วนของงานนำเสนอจากเอกสารงานนำเสนอ.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // จำนวนสไลด์ไม่เป็นศูนย์ ดังนั้นงานนำเสนอจะต้องมีสไลด์.           

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // ดึง ID ของสไลด์ต้นทาง.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // ระบุตำแหน่งของสไลด์เป้าหมายที่สไลด์ต้นทางจะถูกย้ายไปอยู่หลัง.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // ลบสไลด์ต้นทางออกจากตำแหน่งปัจจุบัน.

    sourceSlide.Remove();

    // แทรกสไลด์ต้นทางในตำแหน่งใหม่หลังสไลด์เป้าหมาย.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // บันทึกงานนำเสนอที่แก้ไขแล้ว.

    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// ย้ายสไลด์ไปยังตำแหน่งอื่นในลำดับสไลด์ของงานนำเสนอ.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // สร้างอินสแตนซ์ของคลาส PresentationEx เพื่อโหลดไฟล์ PPTX ต้นทาง

    using (Presentation pres = new Presentation(presentationFile))

    {

        // ดึงสไลด์ที่ต้องการเปลี่ยนตำแหน่ง

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // กำหนดตำแหน่งใหม่ให้สไลด์

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // เขียนไฟล์ PPTX ลงดิสก์

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)