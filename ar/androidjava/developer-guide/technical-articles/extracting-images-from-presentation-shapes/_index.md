---
title: استخراج الصور من أشكال العرض
type: docs
weight: 100
url: /androidjava/extracting-images-from-presentation-shapes/
keywords: "استخراج صورة، PowerPoint، PPT، PPTX، عرض PowerPoint، Java، Aspose.Slides for Android عبر Java"
description: "استخراج الصور من عرض PowerPoint في Java"

---

{{% alert color="primary" %}} 

غالبًا ما تضاف الصور إلى الأشكال وتستخدم أيضًا كخلفيات للشرائح. يتم إضافة كائنات الصورة من خلال [IImageCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/)، وهي مجموعة من [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) كائنات.

تشرح هذه المقالة كيف يمكنك استخراج الصور المضافة إلى العروض. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، يجب عليك تحديد موقع الصورة أولاً من خلال المرور بكل شريحة ثم المرور بكل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. 

```java
    public void extractImages()
    {
        Presentation pres = new Presentation(folderPath + "ExtractImages.pptx");
        com.aspose.slides.IPPImage img = null;
        com.aspose.slides.IPPImage backImage = null;

        int slideIndex = 0;
        String imageType = "";
        boolean ifImageFound = false;
        for (int i = 0; i < pres.getSlides().size(); i++)
        {

            slideIndex++;
            //الوصول إلى الشريحة الأولى
            ISlide sl = pres.getSlides().get_Item(i);


            //الوصول إلى الشريحة الأولى Slide sl = pres.getSlideByPosition(i);
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //الحصول على الصورة الخلفية
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //حفظ الصورة
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //الحصول على الصورة الخلفية
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //حفظ الصورة
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // الوصول إلى الشكل الذي يحتوي على صورة
                IShape sh = sl.getShapes().get_Item(j);

                if (sh instanceof IAutoShape)
                {
                    IAutoShape ashp = (IAutoShape) sh;
                    if (ashp.getFillFormat().getFillType() == FillType.Picture)
                    {
                        img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                        imageType = getImageTType(img);
                        ifImageFound = true;
                    }
                } else if (sh instanceof IPictureFrame)
                {
                    IPictureFrame pf = (IPictureFrame) sh;
                    img = pf.getPictureFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }

                //تعيين تنسيق الصورة المفضل
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //حفظ الصورة
                    img.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
                ifImageFound = false;
            }
        }
    }

    private String getImageTType(IPPImage image)
    {
        String imageContentType = image.getContentType();
        imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
        imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
        return imageContentType;
    }

    private String capitalize(String str)
    {
        if (str == null || str.length() <= 1) return str;
        return str.substring(0, 1).toUpperCase() + str.substring(1);
    }
```