---
title: ลบสไลด์
type: docs
weight: 80
url: /th/net/delete-a-slide/
---
## **OpenXML SDK**
```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// ดึงอ็อบเจกต์การนำเสนอและส่งต่อไปยังเมธอด DeleteSlide ถัดไป.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // เปิดเอกสารต้นฉบับในโหมดอ่าน/เขียน.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // ส่งเอกสารต้นฉบับและตำแหน่งของสไลด์ที่ต้องการลบไปยังเมธอด DeleteSlide ถัดไป.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// ลบสไลด์ที่ระบุออกจากการนำเสนอ.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // ใช้ตัวอย่าง CountSlides เพื่อรับจำนวนสไลด์ในการนำเสนอ.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // ดึงส่วนการนำเสนอจากเอกสารการนำเสนอ. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // ดึงการนำเสนอจากส่วนการนำเสนอ.

    Presentation presentation = presentationPart.Presentation;

    // ดึงรายการ ID ของสไลด์ในการนำเสนอ.

    SlideIdList slideIdList = presentation.SlideIdList;

    // ดึง ID ของสไลด์ที่ระบุ

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // ดึง Relationship ID ของสไลด์.

    string slideRelId = slideId.RelationshipId;

    // ลบสไลด์ออกจากรายชื่อสไลด์.

    slideIdList.RemoveChild(slideId);

    //

    // ลบการอ้างอิงถึงสไลด์จากการแสดงแบบกำหนดเองทั้งหมด.

    if (presentation.CustomShowList != null)

    {

        // วนผ่านรายการของการแสดงแบบกำหนดเอง.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // ประกาศลิงค์ลิสต์ของรายการสไลด์.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // ค้นหาการอ้างอิงสไลด์ที่จะลบออกจากการแสดงแบบกำหนดเอง.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // ลบการอ้างอิงสไลด์ทั้งหมดออกจากการแสดงแบบกำหนดเอง.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // บันทึกการนำเสนอที่แก้ไขแล้ว.

    presentation.Save();

    // ดึงส่วนสไลด์สำหรับสไลด์ที่ระบุ.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // ลบส่วนสไลด์

    presentationPart.DeletePart(slidePart);

}

// ดึงอ็อบเจกต์การนำเสนอและส่งต่อไปยังเมธอด CountSlides ถัดไป.

public static int CountSlides(string presentationFile)

{

    // เปิดการนำเสนอในโหมดอ่านอย่างเดียว.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ส่งการนำเสนอไปยังเมธอด CountSlide ถัดไป

        // และคืนค่าจำนวนสไลด์.

        return CountSlides(presentationDocument);

    }

}

// นับจำนวนสไลด์ในการนำเสนอ.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // ตรวจสอบว่าอ็อบเจกต์เอกสารเป็น null หรือไม่.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ดึงส่วนการนำเสนอของเอกสาร.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // ดึงจำนวนสไลด์จาก SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // คืนค่าจำนวนสไลด์ให้กับเมธอดก่อนหน้า.

    return slidesCount;

}   
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //สร้างอ็อบเจกต์ PresentationEx ที่แสดงไฟล์ PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //เข้าถึงสไลด์โดยใช้ดัชนีในคอลเลกชันสไลด์

        ISlide slide = pres.Slides[slideIndex];


        //ลบสไลด์โดยใช้การอ้างอิงของมัน

        pres.Slides.Remove(slide);


        //บันทึกการนำเสนอเป็นไฟล์ PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)