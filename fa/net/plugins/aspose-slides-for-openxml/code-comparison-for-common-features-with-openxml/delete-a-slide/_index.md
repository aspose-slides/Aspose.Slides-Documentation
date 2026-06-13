---
title: حذف یک اسلاید
type: docs
weight: 80
url: /fa/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// دریافت شیء ارائه و ارسال آن به متد DeleteSlide بعدی.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // سند منبع را به صورت خواندن/نوشتن باز کنید.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // سند منبع و شاخص اسلایدی که باید حذف شود را به متد DeleteSlide بعدی ارسال کنید.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// حذف اسلاید مشخص شده از ارائه.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // از نمونه CountSlides برای دریافت تعداد اسلایدها در ارائه استفاده کنید.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // دریافت بخش ارائه از سند ارائه.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // دریافت ارائه از بخش ارائه.

    Presentation presentation = presentationPart.Presentation;

    // دریافت فهرست شناسه‌های اسلاید در ارائه.

    SlideIdList slideIdList = presentation.SlideIdList;

    // دریافت شناسه اسلاید موردنظر

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // دریافت شناسه رابطه اسلاید.

    string slideRelId = slideId.RelationshipId;

    // حذف اسلاید از فهرست اسلایدها.

    slideIdList.RemoveChild(slideId);

    //

    // حذف مراجع اسلاید از تمام نمایش‌های سفارشی.

    if (presentation.CustomShowList != null)

    {

        // پیمایش فهرست نمایش‌های سفارشی.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // اعلام یک فهرست پیوندی از ورودی‌های فهرست اسلایدها.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // یافتن مرجع اسلاید برای حذف از نمایش سفارشی.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // حذف تمام مراجع اسلاید از نمایش سفارشی.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // ذخیرهٔ ارائهٔ تغییر یافته.

    presentation.Save();

    // دریافت بخش اسلاید برای اسلاید مشخص شده.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // حذف بخش اسلاید.

    presentationPart.DeletePart(slidePart);

}

// دریافت شیء ارائه و ارسال آن به متد CountSlides بعدی.

public static int CountSlides(string presentationFile)

{

    // ارائه را به صورت فقط-خواندنی باز کنید.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ارائه را به متد CountSlide بعدی ارسال کنید

        // و تعداد اسلایدها را برگردانید.

        return CountSlides(presentationDocument);

    }

}

// شمارش اسلایدهای ارائه.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // بررسی وجود شیء سند تهی.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // دریافت بخش ارائه از سند.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // دریافت تعداد اسلایدها از SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // برگرداندن تعداد اسلایدها به متد قبلی.

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

    //یک شیء PresentationEx ایجاد می‌کند که نمایانگر یک فایل PPTX است
    using (Presentation pres = new Presentation(presentationFile))

    {

        //دسترسی به اسلاید با استفاده از شاخص آن در مجموعه اسلایدها
        ISlide slide = pres.Slides[slideIndex];


        //حذف یک اسلاید با استفاده از مرجع آن
        pres.Slides.Remove(slide);


        //نوشتن ارائه به صورت فایل PPTX
        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **دانلود کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)