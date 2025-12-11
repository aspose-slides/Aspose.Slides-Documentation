---
title: استخراج الصور من أشكال العرض التقديمي
linktitle: صورة من الشكل
type: docs
weight: 90
url: /ar/cpp/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- خلفية الشريحة
- خلفية الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++ — حل سريع وسهل الاستخدام في الكود."
---

## **استخراج الصور من الأشكال**

{{% alert color="primary" %}} 

عادةً ما يتم إضافة الصور إلى الأشكال وتُستخدم كثيرًا كخلفيات للشرائح. يتم إضافة كائنات الصورة عبر [IImageCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection)، وهي مجموعة من كائنات [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). 

تشرح هذه المقالة كيفية استخراج الصور المضافة إلى العروض التقديمية. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، عليك أولاً تحديد موقع الصورة بالمرور عبر كل شريحة ثم عبر كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. 
``` cpp
void Run()
{
    System::String path = u"D:\\Aspose Data\\";
    //الوصول إلى العرض التقديمي
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(path + u"ExtractImages.pptx");
    System::SharedPtr<Aspose::Slides::IPPImage> img;
    System::SharedPtr<Aspose::Slides::IPPImage> Backimg;

    int32_t slideIndex = 0;
    System::String ImageType = u"";
    bool ifImageFound = false;
    for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
    {
        slideIndex++;
        //الوصول إلى الشريحة الأولى
        System::SharedPtr<ISlide> sl = pres->get_Slides()->idx_get(i);
        System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();

        if (sl->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
        {
            //الحصول على صورة الخلفية  
            Backimg = sl->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

            //ضبط تنسيق الصورة المطلوب
            ImageType = Backimg->get_ContentType();
            ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
            Format = GetImageFormat(ImageType);

            System::String ImagePath = path + u"BackImage_";
            Backimg->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
        }
        else
        {
            if (sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
            {
                //الحصول على صورة الخلفية  
                Backimg = sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

                //ضبط تنسيق الصورة المطلوب 
                ImageType = Backimg->get_ContentType();
                ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                Format = GetImageFormat(ImageType);

                System::String ImagePath = path + u"BackImage_Slide_" + i;
                Backimg->get_SystemImage()->Save(ImagePath + u"LayoutSlide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
            }
        }

        for (int32_t j = 0; j < sl->get_Shapes()->get_Count(); j++)
        {
            // الوصول إلى الشكل الذي يحتوي على صورة
            System::SharedPtr<IShape> sh = sl->get_Shapes()->idx_get(j);

            if (System::ObjectExt::Is<AutoShape>(sh))
            {
                System::SharedPtr<AutoShape> ashp = System::ExplicitCast<Aspose::Slides::AutoShape>(sh);
                if (ashp->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = ashp->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;

                }
            }
            else if (System::ObjectExt::Is<PictureFrame>(sh))
            {
                System::SharedPtr<IPictureFrame> pf = System::ExplicitCast<Aspose::Slides::IPictureFrame>(sh);
                if (pf->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = pf->get_PictureFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;
                }
            }

            //ضبط تنسيق الصورة المفضل
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                System::String ImagePath = path + u"Slides\\Image_";
                img->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"_Shape_" + System::Convert::ToString(j) + u"." + ImageType, Format);
            }

            ifImageFound = false;
        }
    }
}

System::SharedPtr<System::Drawing::Imaging::ImageFormat> GetImageFormat(System::String ImageType)
{
    System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
    {
        const System::String& switch_value_0 = ImageType;
        do {
            if (switch_value_0 == u"jpeg")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
                break;
            }
            if (switch_value_0 == u"emf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Emf();
                break;
            }
            if (switch_value_0 == u"bmp")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Bmp();
                break;
            }
            if (switch_value_0 == u"png")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Png();
                break;
            }
            if (switch_value_0 == u"wmf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Wmf();
                break;
            }
            if (switch_value_0 == u"gif")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Gif();
                break;
            }
        } while (false);
    }

    return Format;
}
```


## **الأسئلة الشائعة**

**هل يمكنني استخراج الصورة الأصلية دون أي قص أو تأثيرات أو تحويلات الشكل؟**

نعم. عندما تصل إلى صورة الشكل، ستحصل على كائن الصورة من [مجموعة الصور](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/)، أي البيكسلات الأصلية دون قص أو تأثيرات تنسيقية. يتنقل سير العمل عبر مجموعة صور العرض وكائنات [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/) التي تخزن البيانات الخام.

**هل هناك خطر تكرار الملفات المتطابقة عند حفظ العديد من الصور دفعة واحدة؟**

نعم، إذا قمت بحفظ كل شيء دون تمييز. قد تحتوي [مجموعة الصور](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/) في العرض على بيانات ثنائية متطابقة يُشار إليها من قبل أشكال أو شرائح مختلفة. لتجنب التكرار، قارن التجزئات أو الأحجام أو محتويات البيانات المستخرجة قبل الكتابة.

**كيف يمكنني تحديد الأشكال المرتبطة بصورة معينة من مجموعة العرض؟**

لا تقوم Aspose.Slides بتخزين روابط عكسية من [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/) إلى الأشكال. يمكنك إنشاء خريطة يدوياً أثناء التجول: كلما وجدت إشارة إلى [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)، سجّل أي الأشكال تستخدمها.

**هل يمكنني استخراج الصور المضمنة داخل كائنات OLE، مثل المستندات المرفقة؟**

ليس مباشرة، لأن كائن OLE هو حاوية. تحتاج إلى استخراج حزمة OLE نفسها ثم تحليل محتوياتها باستخدام أدوات منفصلة. تعمل أشكال الصور في العروض عبر [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)؛ OLE هو نوع كائن مختلف.