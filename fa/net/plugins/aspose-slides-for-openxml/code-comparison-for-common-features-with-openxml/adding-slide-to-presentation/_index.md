---
title: افزودن اسلاید به ارائه
type: docs
weight: 20
url: /fa/net/adding-slide-to-presentation/
---
## **ارائه OpenXML**
در عملکرد زیر به‌صورت پیش‌فرض یک اسلاید به ارائه اضافه می‌شود. در اینجا ما اسلاید جدیدی را در شاخص ۲ اضافه می‌کنیم که شامل متنی است.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// یک اسلاید را به ارائه مورد نظر اضافه کنید.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // سند منبع را به صورت خواندن/نوشتن باز کنید. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // سند منبع و موقعیت و عنوان اسلایدی که قرار است اضافه شود را به متد بعدی پاس دهید.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// اسلاید مشخص‌شده را در موقعیت معین به ارائه اضافه کنید.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // اطمینان حاصل کنید که ارائه خالی نیست.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // یک اسلاید جدید را اعلان و نمونه‌سازی کنید.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // محتویات اسلاید را ساختار بدهید.            

    // ویژگی‌های غیر بصری اسلاید جدید را مشخص کنید.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // ویژگی‌های شکل گروهی اسلاید جدید را مشخص کنید.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // شکل عنوان اسلاید جدید را اعلان و نمونه‌سازی کنید.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // ویژگی‌های لازم شکل برای شکل عنوان را مشخص کنید. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // متن شکل عنوان را مشخص کنید.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // شکل بدنه اسلاید جدید را اعلان و نمونه‌سازی کنید.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // ویژگی‌های لازم شکل برای شکل بدنه را مشخص کنید.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // متن شکل بدنه را مشخص کنید.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // بخش اسلاید برای اسلاید جدید را ایجاد کنید.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // بخش اسلاید جدید را ذخیره کنید.

    slide.Save(slidePart);

    // فهرست شناسه‌های اسلاید در بخش ارائه را اصلاح کنید.

    // فهرست شناسه اسلاید نباید خالی (null) باشد.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // بالاترین شناسه اسلاید را در فهرست فعلی پیدا کنید.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // شناسه اسلاید قبلی را دریافت کنید.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // از همان چیدمان اسلاید همانند اسلاید قبلی استفاده کنید.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // اسلاید جدید را پس از اسلاید قبلی در فهرست اسلایدها وارد کنید.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // ارائه اصلاح‌شده را ذخیره کنید.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
هر فایل ارائه پاورپوینت شامل یک **اسلاید اصلی Master** و سایر **اسلایدهای Normal** است. این به این معنی است که یک فایل ارائه حداقل یک یا چند اسلاید دارد. مهم است بدانید که فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for .NET پشتیبانی نمی‌شوند. هر اسلاید موقعیت خاصی دارد و یک **شناسه منحصربفرد** دارد. **شناسه اسلاید** می‌تواند از ۰ تا ۲۵۵ برای اسلایدهای Master و از ۲۵۶ تا ۶۵۵۳۵ برای اسلایدهای Normal باشد.

Aspose.Slides for .NET به توسعه‌دهندگان اجازه می‌دهد تا اسلایدهای خالی را به ارائه‌ها اضافه کنند با استفاده از متد **AddEmptySlide** که توسط شی **Presentation** ارائه می‌شود. برای افزودن یک اسلاید خالی به ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- متد AddEmptySlide را که توسط شی Presentation ارائه شده فراخوانی کنید
- کارهایی را با اسلاید خالی جدید انجام دهید
- یک اسلاید دیگر اضافه کنید و متن را در آن درج کنید.
- در نهایت، فایل PPT را با استفاده از متد Write که توسط شی Presentation ارائه شده بنویسید

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPT است

Presentation pres = new Presentation();

//یک اسلاید خالی به‌صورت پیش‌فرض اضافه می‌شود، وقتی که شما ایجاد می‌کنید

//ارائه از سازنده پیش‌فرض

//افزودن یک اسلاید خالی به ارائه و دریافت مرجع آن

//آن اسلاید خالی

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//نوشتن خروجی به دیسک

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **بارگیری کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)