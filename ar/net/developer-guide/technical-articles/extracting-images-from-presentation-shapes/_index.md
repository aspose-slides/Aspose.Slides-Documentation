---
title: استخراج الصور من أشكال العرض التقديمي في .NET
linktitle: صورة من شكل
type: docs
weight: 90
url: /ar/net/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- خلفية الشريحة
- خلفية الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET — حل سريع وصديق للمبرمجين."
---

## **استخراج الصور من الأشكال**

{{% alert color="primary" %}} 

غالبًا ما تُضاف الصور إلى الأشكال وتُستخدم أيضًا بشكل متكرر كخلفيات للشرائح. يتم إضافة كائنات الصورة من خلال [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/)، التي هي مجموعة من كائنات [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) . 

تشرح هذه المقالة كيفية استخراج الصور المضافة إلى العروض التقديمية. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، يجب أولاً تحديد موقع الصورة بالمرور عبر كل شريحة ثم المرور عبر كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. XXX 
```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // الوصول إلى العرض التقديمي
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // الوصول إلى الشريحة الأولى
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // الوصول إلى الشريحة الأولى Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // يحصل على صورة الخلفية  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // يضبط تنسيق الصورة المفضل 

            ImageType = Backimg.ContentType;
            ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
            Format = GetImageFormat(ImageType);

            String ImagePath = path + "BackImage_";
            Backimg.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "." + ImageType, Format);

        }
        else
        {
            if (sl.LayoutSlide.Background.FillFormat.FillType == FillType.Picture)
            {
                // يحصل على صورة الخلفية  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // يضبط تنسيق الصورة المفضل 

                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // الوصول إلى الشكل الذي يحتوي على صورة
            IShape sh = sl.Shapes[j];

            if (sh is AutoShape)
            {
                AutoShape ashp = (AutoShape)sh;
                if (ashp.FillFormat.FillType == FillType.Picture)
                {
                    img = ashp.FillFormat.PictureFillFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;

                }
            }

            else if (sh is PictureFrame)
            {
                IPictureFrame pf = (IPictureFrame)sh;
                if (pf.FillFormat.FillType == FillType.Picture)
                {
                    img = pf.PictureFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;
                }
            }

            // يضبط التنسيق المفضل للصورة المستخرجة
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                String ImagePath = path + "Slides\\Image_";
                img.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "_Shape_" + j.ToString() + "." + ImageType, Format);
            }
            ifImageFound = false;
        }
    }
}

public static System.Drawing.Imaging.ImageFormat GetImageFormat(String ImageType)
{
    System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;
    switch (ImageType)
    {
        case "jpeg":
            Format = System.Drawing.Imaging.ImageFormat.Jpeg;
            break;

        case "emf":
            Format = System.Drawing.Imaging.ImageFormat.Emf;
            break;

        case "bmp":
            Format = System.Drawing.Imaging.ImageFormat.Bmp;
            break;

        case "png":
            Format = System.Drawing.Imaging.ImageFormat.Png;
            break;

        case "wmf":
            Format = System.Drawing.Imaging.ImageFormat.Wmf;
            break;

        case "gif":
            Format = System.Drawing.Imaging.ImageFormat.Gif;
            break;

    }
    return Format;
}
```


## **الأسئلة الشائعة**

**هل يمكنني استخراج الصورة الأصلية دون أي تقليم أو تأثيرات أو تحويلات الشكل؟**

نعم. عندما تصل إلى صورة الشكل، ستحصل على كائن الصورة من مجموعة صور العرض التقديمي، مما يعني البكسلات الأصلية دون تقليم أو تأثيرات تنسيق. يمر سير العمل عبر مجموعة صور العرض التقديمي وكائنات [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) ، التي تخزن البيانات الخام.

**هل هناك خطر من تكرار الملفات المتطابقة عند حفظ العديد من الصور مرة واحدة؟**

نعم، إذا قمت بحفظ كل شيء دون تمييز. يمكن أن تحتوي مجموعة صور العرض التقديمي على بيانات ثنائية متطابقة يتم الإشارة إليها بواسطة أشكال أو شرائح مختلفة. لتجنب التكرارات، قارن التجزئات أو الأحجام أو محتويات البيانات المستخرجة قبل الكتابة.

**كيف يمكنني تحديد الأشكال المرتبطة بصورة محددة من مجموعة صور العرض التقديمي؟**

Aspose.Slides لا يخزن الروابط العكسية من [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) إلى الأشكال. قم بإنشاء خريطة يدوية أثناء التجوال: كلما وجدت إشارة إلى [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)، سجّل الأشكال التي تستخدمها.

**هل يمكنني استخراج الصور المضمنة داخل كائنات OLE، مثل المستندات المرفقة؟**

ليس مباشرة، لأن كائن OLE هو حاوية. تحتاج إلى استخراج حزمة OLE نفسها ثم تحليل محتوياتها باستخدام أدوات منفصلة. تعمل أشكال الصور في العرض التقديمي عبر [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)؛ OLE هو نوع كائن مختلف.