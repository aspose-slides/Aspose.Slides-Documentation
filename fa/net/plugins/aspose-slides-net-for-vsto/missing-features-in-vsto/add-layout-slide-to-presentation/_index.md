---
title: افزودن اسلاید Layout به ارائه
type: docs
weight: 10
url: /fa/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET به توسعه‌دهندگان امکان اضافه کردن اسلایدهای Layout جدید به ارائه را می‌دهد. برای اضافه کردن یک اسلاید Layout، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- به مجموعه Master Slide دسترسی پیدا کنید
- سعی کنید اسلایدهای Layout موجود را پیدا کنید تا ببینید اسلاید مورد نیاز قبلاً در مجموعه Layout Slide موجود است یا خیر
- اگر Layout مطلوب موجود نیست، یک اسلاید Layout جدید اضافه کنید
- یک اسلاید خالی با Layout اسلاید تازه اضافه‌شده اضافه کنید
- در نهایت، فایل ارائه را با استفاده از شی Presentation بنویسید.
## **مثال**
``` csharp

 //یک نمونه از کلاس Presentation ایجاد کنید که فایل ارائه را نشان می‌دهد

using (Presentation p = new Presentation("Test.pptx"))

{

   // سعی کنید بر اساس نوع اسلاید Layout جستجو کنید

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // موقعیتی که یک ارائه برخی انواع Layoutها را شامل نمی‌شود.

     // ارائه Technographics.pptx فقط شامل انواع Layout Blank و Custom است.

     // اما اسلایدهای Layout با نوع Custom نام‌های اسلاید متفاوتی دارند،

     // مانند "Title"، "Title and Content"، و غیره. و امکان استفاده از این

     // نام‌ها برای انتخاب اسلاید Layout وجود دارد.

     // همچنین می‌توان از مجموعهٔ انواع اشکال جای‌دار استفاده کرد. برای مثال،

     // اسلاید Title باید فقط نوع جای‌دار Title را داشته باشد، و غیره.

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

  //ذخیرهٔ ارائه

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **بارگیری مثال اجرایی**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **بارگیری کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
برای جزئیات بیشتر، به [اعمال یا تغییر Layout اسلایدها در .NET](/slides/fa/net/slide-layout/) مراجعه کنید.
{{% /alert %}}