---
title: حذف شريحة
type: docs
weight: 80
url: /net/delete-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "حذف شريحة.pptx";

DeleteSlide(FileName, 1);

// الحصول على كائن العرض التقديمي وتمريره إلى طريقة DeleteSlide التالية.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // فتح المستند المصدر للقراءة / الكتابة.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // تمرير المستند المصدر ومؤشر الشريحة التي سيتم حذفها إلى طريقة DeleteSlide التالية.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// حذف الشريحة المحددة من العرض التقديمي.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // استخدم العينة CountSlides للحصول على عدد الشرائح في العرض التقديمي.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // الحصول على جزء العرض التقديمي من مستند العرض التقديمي. 

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // الحصول على العرض التقديمي من جزء العرض التقديمي.

    Presentation presentation = presentationPart.Presentation;

    // الحصول على قائمة معرفات الشرائح في العرض التقديمي.

    SlideIdList slideIdList = presentation.SlideIdList;

    // الحصول على معرف الشريحة للشريحة المحددة

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // الحصول على معرف العلاقة للشريحة.

    string slideRelId = slideId.RelationshipId;

    // إزالة الشريحة من قائمة الشرائح.

    slideIdList.RemoveChild(slideId);

    //

    // إزالة المراجع إلى الشريحة من جميع العروض التقديمية المخصصة.

    if (presentation.CustomShowList != null)

    {

        // التجول عبر قائمة العروض التقديمية المخصصة.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // إعلان قائمة مرتبطة بإدخالات قائمة الشرائح.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // العثور على مرجع الشريحة لإزالته من العرض التقديمي المخصص.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // إزالة جميع المراجع إلى الشريحة من العرض التقديمي المخصص.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // حفظ العرض التقديمي المعدل.

    presentation.Save();

    // الحصول على جزء الشريحة للشريحة المحددة.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // إزالة جزء الشريحة.

    presentationPart.DeletePart(slidePart);

}

// الحصول على كائن العرض التقديمي وتمريره إلى طريقة CountSlides التالية.

public static int CountSlides(string presentationFile)

{

    // فتح العرض التقديمي للقراءة فقط.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // تمرير العرض التقديمي إلى طريقة CountSlide التالية

        // وإرجاع عدد الشرائح.

        return CountSlides(presentationDocument);

    }

}

// عد الشرائح في العرض التقديمي.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // التحقق من وجود كائن مستند فارغ.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // الحصول على جزء العرض التقديمي من المستند.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // الحصول على عدد الشرائح من أجزاء الشرائح.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // إرجاع عدد الشرائح إلى الطريقة السابقة.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "حذف شريحة.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //إنشاء كائن PresentationEx الذي يمثل ملف PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //الوصول إلى شريحة باستخدام مؤشرها في مجموعة الشرائح

        ISlide slide = pres.Slides[slideIndex];


        //إزالة شريحة باستخدام مرجعها

        pres.Slides.Remove(slide);


        //كتابة العرض التقديمي كملف PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **تحميل نموذج التعليمات البرمجية**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Delete%20a%20slide%20\(Aspose.Slides\).zip)