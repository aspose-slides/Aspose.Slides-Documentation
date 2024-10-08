---
title: إضافة شرائح التخطيط إلى العرض التقديمي
type: docs
weight: 20
url: /ar/net/add-layout-slides-to-presentation/
---

يسمح Aspose.Slides لـ .NET للمطورين بإضافة شرائح تخطيط جديدة في العرض التقديمي. لإضافة شريحة تخطيط، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation
- الوصول إلى مجموعة الشريحة الرئيسية
- حاول العثور على شرائح التخطيط الموجودة لمعرفة ما إذا كانت الشريحة المطلوبة متاحة بالفعل في مجموعة شرائح التخطيط أم لا
- إضافة شريحة تخطيط جديدة إذا كانت التخطيط المطلوب غير متوفرة
- إضافة شريحة فارغة مع شريحة التخطيط المضافة حديثًا
- أخيرًا، قم بكتابة ملف العرض التقديمي باستخدام كائن Presentation
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "إضافة شرائح التخطيط.pptx";

//Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation(FileName))

{

    // حاول البحث عن نوع شريحة التخطيط

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // الحالة عندما لا يحتوي العرض التقديمي على بعض أنواع التخطيطات.

        // تحتوي عرض Technographics.pptx فقط على أنواع تخطيط فارغ ومخصص.

        // لكن تحتوي شرائح التخطيط بأنواع مخصصة على أسماء شرائح مختلفة،

        // مثل "العنوان"، "العنوان والمحتوى"، وما إلى ذلك. ومن الممكن استخدام هذه

        // الأسماء لاختيار شريحة التخطيط.

        // أيضاً من الممكن استخدام مجموعة من أنواع أشكال القوائم النائبة. على سبيل المثال،

        // يجب أن تحتوي شريحة العنوان على نوع واحد فقط من قوائم العنوان، وهكذا.

        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

        {

            if (titleAndObjectLayoutSlide.Name == "العنوان والمحتوى")

            {

                layoutSlide = titleAndObjectLayoutSlide;

                break;

            }

        }

        if (layoutSlide == null)

        {

            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

            {

                if (titleLayoutSlide.Name == "العنوان")

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

                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "العنوان والمحتوى");

                }

            }

        }

    }

    //إضافة شريحة فارغة مع شريحة التخطيط المضافة

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //حفظ العرض التقديمي    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **تحميل رمز المثال**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **تحميل مثال يعمل**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

للحصول على مزيد من التفاصيل، تفضل بزيارة [إضافة شرائح التخطيط إلى العرض التقديمي](/slides/ar/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}