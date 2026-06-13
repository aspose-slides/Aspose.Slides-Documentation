---
title: ใช้ธีมกับงานนำเสนอ
type: docs
weight: 30
url: /th/net/apply-a-theme-to-a-presentation/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Apply a new theme to the presentation. 
// ใช้ธีมใหม่กับงานนำเสนอ

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Apply a new theme to the presentation. 
// ใช้ธีมใหม่กับงานนำเสนอ

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Get the presentation part of the presentation document.
    // รับส่วน Presentation ของเอกสาร Presentation

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Get the existing slide master part.
    // ดึงส่วน Slide Master ที่มีอยู่

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Get the new slide master part.
    // ดึงส่วน Slide Master ใหม่

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Remove the existing theme part.
    // ลบส่วนธีมที่มีอยู่

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Remove the old slide master part.
    // ลบส่วน Slide Master เก่า

    presentationPart.DeletePart(slideMasterPart);

    // Import the new slide master part, and reuse the old relationship ID.
    // นำเข้าส่วน Slide Master ใหม่ และใช้ ID ความสัมพันธ์เก่าอีกครั้ง

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Change to the new theme part.
    // เปลี่ยนเป็นส่วนธีมใหม่

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Insert the code for the layout for this example.
    // แทรกโค้ดสำหรับเลย์เอาต์ในตัวอย่างนี้

    string defaultLayoutType = "Title and Content";

    // Remove the slide layout relationship on all slides. 
    // ลบความสัมพันธ์ของเลย์เอาต์สไลด์ในสไลด์ทั้งหมด

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Determine the slide layout type for each slide.
            // กำหนดประเภทเลย์เอาต์สไลด์สำหรับแต่ละสไลด์

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Delete the old layout part.
            // ลบส่วนเลย์เอาต์เก่า

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Apply the new layout part.
            // ใช้ส่วนเลย์เอาต์ใหม่

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Apply the new default layout part.
            // ใช้ส่วนเลย์เอาต์เริ่มต้นใหม่

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Get the slide layout type.
 // ดึงประเภทเลย์เอาต์สไลด์

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Remarks: If this is used in production code, check for a null reference.
    // หมายเหตุ: หากใช้ในโค้ดจริง ควรตรวจสอบการอ้างอิงเป็น null

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
เพื่อใช้ธีม เราต้องทำสำเนาสไลด์พร้อมมาสเตอร์ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation ที่มีพรีเซนเทชันต้นทางซึ่งสไลด์จะถูกคัดลอกจาก
- สร้างอินสแตนซ์ของคลาส Presentation ที่มีพรีเซนเทชันปลายทางซึ่งสไลด์จะถูกคัดลอกไปยัง
- เข้าถึงสไลด์ที่ต้องการคัดลอกพร้อมกับสไลด์มาสเตอร์
- สร้างอินสแตนซ์ของคลาส IMasterSlideCollection โดยอ้างอิงคอลเลกชัน Masters ที่เปิดเผยโดยอ็อบเจกต์ Presentation ของพรีเซนเทชันปลายทาง
- เรียกเมธอด AddClone ที่เปิดเผยโดยอ็อบเจกต์ IMasterSlideCollection และส่งมาสเตอร์จากไฟล์ PPTX ต้นทางที่ต้องการคัดลอกเป็นพารามิเตอร์ให้เมธอด AddClone
- สร้างอินสแตนซ์ของคลาส ISlideCollection โดยตั้งค่าการอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ Presentation ของพรีเซนเทชันปลายทาง
- เรียกเมธอด AddClone ที่เปิดเผยโดยอ็อบเจกต์ ISlideCollection และส่งสไลด์จากพรีเซนเทชันต้นทางที่ต้องการคัดลอกและสไลด์มาสเตอร์เป็นพารามิเตอร์ให้เมธอด AddClone
- เขียนไฟล์พรีเซนเทชันปลายทางที่ได้รับการปรับปรุง

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Instantiate Presentation class to load the source presentation file
    //สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์พรีเซนเทชันต้นทาง

    //Instantiate Presentation class for destination presentation (where slide is to be cloned)
    //สร้างอินสแตนซ์ของคลาส Presentation สำหรับพรีเซนเทชันปลายทาง (ที่สไลด์จะถูกคัดลอก)

    //Instantiate ISlide from the collection of slides in source presentation along with
    //สร้างอินสแตนซ์ของ ISlide จากคอลเลกชันสไลด์ในพรีเซนเทชันต้นทางพร้อมกับ
    //master slide
    //สไลด์มาสเตอร์

    //Clone the desired master slide from the source presentation to the collection of masters in the
    //คัดลอกสไลด์มาสเตอร์ที่ต้องการจากพรีเซนเทชันต้นทางไปยังคอลเลกชันมาสเตอร์ใน
    //destination presentation
    //พรีเซนเทชันปลายทาง

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Clone the desired master slide from the source presentation to the collection of masters in the
    //คัดลอกสไลด์มาสเตอร์ที่ต้องการจากพรีเซนเทชันต้นทางไปยังคอลเลกชันมาสเตอร์ใน
    //destination presentation
    //พรีเซนเทชันปลายทาง

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Clone the desired slide from the source presentation with the desired master to the end of the
    //คัดลอกสไลด์ที่ต้องการจากพรีเซนเทชันต้นทางพร้อมกับมาสเตอร์ที่ต้องการไปยังท้ายของ
    //collection of slides in the destination presentation
    //คอลเลกชันสไลด์ในพรีเซนเทชันปลายทาง

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Clone the desired master slide from the source presentation to the collection of masters in the//destination presentation
    //คัดลอกสไลด์มาสเตอร์ที่ต้องการจากพรีเซนเทชันต้นทางไปยังคอลเลกชันมาสเตอร์ใน //พรีเซนเทชันปลายทาง

    //Save the destination presentation to disk
    //บันทึกพรีเซนเทชันปลายทางลงดิสก์

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Download Running Code Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)