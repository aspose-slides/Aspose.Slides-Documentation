---
title: استخراج الصور من أشكال العرض
type: docs
weight: 90
url: /ar/net/extracting-images-from-presentation-shapes/
keywords: "استخراج صورة، PowerPoint، PPT، PPTX، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "استخراج الصور من عرض PowerPoint باستخدام C# أو .NET"
---

{{% alert color="primary" %}} 

غالبًا ما تتم إضافة الصور إلى الأشكال وغالبًا ما تستخدم كخلفيات للشرائح. يتم إضافة كائنات الصورة من خلال [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/)، وهي مجموعة من كائنات [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) . 

تشرح هذه المقالة كيفية استخراج الصور المضافة إلى العروض. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، يجب عليك أولاً تحديد موقع الصورة من خلال المرور بكل شريحة ثم المرور بكل شكل. بمجرد العثور على الصورة أو التعرف عليها، يمكنك استخراجها وحفظها كملف جديد. XXX 

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
            // الحصول على الصورة الخلفية  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // تعيين تنسيق الصورة المفضل 

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
                // الحصول على الصورة الخلفية  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // تعيين تنسيق الصورة المفضل 

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

            // تعيين التنسيق المفضل للصورة المستخرجة 
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