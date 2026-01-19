---
title: إضافة شرائح التخطيط إلى العرض التقديمي
type: docs
weight: 20
url: /ar/net/add-layout-slides-to-presentation/
---

يتيح Aspose.Slides for .NET للمطورين إضافة شرائح تخطيط جديدة في العرض التقديمي. لإضافة شريحة تخطيط، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة Presentation
- الوصول إلى مجموعة الشرائح الرئيسية Master Slide
- محاولة العثور على شرائح تخطيط موجودة للتحقق مما إذا كانت الشريحة المطلوبة متوفرة بالفعل في مجموعة شرائح التخطيط أم لا
- إضافة شريحة تخطيط جديدة إذا لم يتوفر التخطيط المطلوب
- إضافة شريحة فارغة باستخدام شريحة التخطيط التي تم إضافتها حديثًا
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن Presentation
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation(FileName))

{

    // Try to search by layout slide type

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // The situation when a presentation doesn't contain some type of layouts.

        // Technographics.pptx presentation only contains Blank and Custom layout types.

        // But layout slides with Custom types has different slide names,

        // like "Title", "Title and Content", etc. And it is possible to use these

        // names for layout slide selection.

        // Also it is possible to use the set of placeholder shape types. For example,

        // Title slide should have only Title pleceholder type, etc.

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

    //Adding empty slide with added layout slide 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Save presentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **تنزيل المثال التشغيلي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
لمزيد من التفاصيل، زر [تطبيق أو تغيير تخطيطات الشرائح في .NET](/slides/ar/net/slide-layout/).
{{% /alert %}}