---
title: إضافة شريحة تخطيط إلى العرض التقديمي
type: docs
weight: 10
url: /ar/net/add-layout-slide-to-presentation/
---

Aspose.Slides for .NET يسمح للمطورين بإضافة شرائح تخطيط جديدة في العرض التقديمي. لإضافة شريحة تخطيط، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة Presentation
- الوصول إلى مجموعة شرائح Master
- محاولة العثور على شرائح تخطيط موجودة للتحقق مما إذا كانت الشريحة المطلوبة موجودة بالفعل في مجموعة شرائح التخطيط أم لا
- إضافة شريحة تخطيط جديدة إذا كان التخطيط المطلوب غير متاح
- إضافة شريحة فارغة باستخدام شريحة التخطيط التي تم إضافتها حديثًا
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن Presentation.

## **مثال**
``` csharp

 //Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation("Test.pptx"))

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

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **تنزيل المثال التشغيلي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
لمزيد من التفاصيل، راجع [تطبيق أو تغيير تخطيطات الشرائح في .NET](/slides/ar/net/slide-layout/).
{{% /alert %}}