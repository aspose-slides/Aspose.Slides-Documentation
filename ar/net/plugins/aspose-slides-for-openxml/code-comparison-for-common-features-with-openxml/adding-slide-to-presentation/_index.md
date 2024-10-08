---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 20
url: /ar/net/adding-slide-to-presentation/
---

## **عرض OpenXML**
في الوظيفة أدناه، يتم إضافة شريحة إلى العرض التقديمي بشكل افتراضي. هنا نقوم بإضافة شريحة جديدة في الفهرس 2 تحتوي على بعض النصوص.

```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "ش slides جديدة");

// إدراج شريحة في العرض التقديمي المحدد.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // فتح الوثيقة المصدر كقراءة وكتابة. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // تمرير الوثيقة المصدر وموقع وعنوان الشريحة المراد إدراجها إلى الطريقة التالية.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// إدراج الشريحة المحددة في العرض التقديمي في الموقع المحدد.

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

    // التحقق من أن العرض التقديمي ليس فارغًا.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("وثيقة العرض التقديمي فارغة.");

    }

    // الإعلان عن شريحة جديدة وتثبيتها.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // بناء محتوى الشريحة.            

    // تحديد الخصائص غير المرئية للشريحة الجديدة.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // تحديد خصائص الشكل الجماعي للشريحة الجديدة.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // الإعلان عن شكل العنوان في الشريحة الجديدة وتثبيته.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // تحديد الخصائص المطلوبة لشكل العنوان. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "العنوان" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // تحديد نص شكل العنوان.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));


    // الإعلان عن شكل الجسم في الشريحة الجديدة وتثبيته.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // تحديد الخصائص المطلوبة لشكل الجسم.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "عنصر محتوى" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // تحديد نص شكل الجسم.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // إنشاء جزء الشريحة للشريحة الجديدة.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // حفظ جزء الشريحة الجديدة.

    slide.Save(slidePart);

    // تعديل قائمة معرفات الشرائح في جزء العرض التقديمي.

    // يجب ألا تكون قائمة معرفات الشرائح فارغة.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // البحث عن أعلى معرف شريحة في القائمة الحالية.

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

    // الحصول على معرف الشريحة السابقة.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // استخدام نفس تخطيط الشريحة كتلك الخاصة بالشريحة السابقة.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // إدراج الشريحة الجديدة في قائمة الشرائح بعد الشريحة السابقة.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // حفظ العرض التقديمي المعدل.

    presentationPart.Presentation.Save();

}

}

``` 
## **Aspose.Slides**
كل ملف عرض تقديمي في PowerPoint يحتوي على **شريحة رئيسية واحدة** وشرائح **عادية** أخرى. هذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة أو أكثر على الأقل. من المهم معرفة أن ملفات العرض التقديمي التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides لـ .NET. كل شريحة لها موقع محدد و**معرف فريد**. يمكن أن يتراوح **معرف الشريحة** من 0 إلى 255 للشرائح الرئيسية ومن 256 إلى 65535 للشرائح العادية.

تتيح Aspose.Slides لـ .NET للمطورين إضافة شرائح فارغة إلى العروض التقديمية باستخدام طريقة **AddEmptySlide** المعروضة من كائن **Presentation**. لإضافة شريحة فارغة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

- قم بإنشاء نسخة من فئة Presentation
- استدعاء طريقة AddEmptySlide المعروضة من كائن Presentation
- قم ببعض الأعمال مع الشريحة الفارغة المضافة حديثًا
- إضافة شريحة أخرى وإدراج نص عليها.
- أخيرًا، قم بكتابة ملف PPT باستخدام طريقة Write المعروضة من كائن Presentation

```csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Instantiate PresentationEx class that represents the PPT file

Presentation pres = new Presentation();

//تمت إضافة شريحة فارغة بشكل افتراضي، عند إنشاء

//عرض تقديمي من المنشئ الافتراضي

//إضافة شريحة فارغة إلى العرض التقديمي والحصول على مرجع لـ

//تلك الشريحة الفارغة

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//اكتب المخرجات على القرص

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **تنزيل رمز العينة**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)