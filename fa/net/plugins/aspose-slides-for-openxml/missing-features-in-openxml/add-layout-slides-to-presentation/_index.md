---
title: افزودن اسلایدهای Layout به ارائه
type: docs
weight: 20
url: /fa/net/add-layout-slides-to-presentation/
---
Aspose.Slides برای .NET به توسعه‌دهندگان امکان اضافه‌کردن اسلایدهای Layout جدید به ارائه را می‌دهد. برای اضافه کردن یک اسلاید Layout، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- به مجموعه اسلایدهای Master دسترسی پیدا کنید
- سعی کنید اسلایدهای Layout موجود را پیدا کنید تا ببینید اسلاید مورد نیاز قبلاً در مجموعه Layout Slide موجود است یا نه
- اگر Layout مورد نظر موجود نیست، یک اسلاید Layout جدید اضافه کنید
- یک اسلاید خالی با Layout اسلاید تازه اضافه‌شده اضافه کنید
- در نهایت، فایل ارائه را با استفاده از شی Presentation ذخیره کنید
## **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است، ایجاد کنید

using (Presentation p = new Presentation(FileName))

{

    // سعی کنید بر اساس نوع اسلاید Layout جستجو کنید

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // موقعیتی که در آن یک ارائه برخی از انواع Layoutها را ندارد.
        // ارائه Technographics.pptx فقط شامل انواع Layout Blank و Custom است.
        // اما اسلایدهای Layout با نوع Custom نام‌های متفاوتی دارند،
        // همانند "Title"، "Title and Content"، و غیره. و می‌توان از این‌ها استفاده کرد
        // به عنوان نام‌ها برای انتخاب اسلاید Layout.
        // همچنین می‌توان از مجموعه انواع شکل‌های placeholder استفاده کرد. برای مثال،
        // اسلاید عنوان باید فقط نوع placeholder Title را داشته باشد، و غیره.
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

    //اضافه کردن اسلاید خالی با اسلاید Layout اضافه‌شده 
    p.Slides.InsertEmptySlide(0, layoutSlide);
    //ذخیره ارائه    
    p.Save(FileName, SaveFormat.Pptx);

}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Download Running Example**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
برای جزئیات بیشتر، به [اعمال یا تغییر Layout اسلایدها در .NET](/slides/fa/net/slide-layout/) مراجعه کنید.
{{% /alert %}}