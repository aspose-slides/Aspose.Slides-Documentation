---
title: استخراج الصور من أشكال العرض التقديمي
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/java/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- خلفية الشريحة
- خلفية الشكل
- PowerPoint
- OpenDocument
- العرض التقديمي
- Java
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Java — حل سريع ومناسب للمبرمجين."
---

## **استخراج الصور من الأشكال**

{{% alert color="primary" %}} 
عادةً ما تتم إضافة الصور إلى الأشكال وتُستخدم أيضًا بشكل شائع كخلفيات للشرائح. يتم إضافة كائنات الصورة عبر [IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/)، وهي مجموعة من كائنات [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). 

توضح هذه المقالة كيفية استخراج الصور المضافة إلى العروض التقديمية. 
{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، عليك أولاً تحديد موقع الصورة عبر استعراض كل شريحة ثم استعراض كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. 
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
                //الوصول إلى الشكل الذي يحتوي على صورة
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


## **FAQ**

**هل يمكنني استخراج الصورة الأصلية دون أي قص أو تأثيرات أو تحولات الشكل؟**

نعم. عند الوصول إلى صورة الشكل، تحصل على كائن الصورة من [مجموعة الصور](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) في العرض التقديمي، مما يعني الحصول على البكسلات الأصلية دون قص أو تأثيرات تنسيق. تت traversة العملية مجموعة الصور في العرض التقديمي وكائنات [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/) التي تخزن البيانات الخام.

**هل هناك خطر من تكرار الملفات المتطابقة عند حفظ العديد من الصور دفعة واحدة؟**

نعم، إذا قمت بحفظ كل شيء دون التمييز. قد تحتوي [مجموعة الصور](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) في العرض التقديمي على بيانات ثنائية متطابقة يُشار إليها من قبل أشكال أو شرائح مختلفة. لتجنب التكرارات، قارن التجزئات أو الأحجام أو محتويات البيانات المستخرجة قبل الكتابة.

**كيف يمكنني تحديد الأشكال المرتبطة بصورة معينة من مجموعة الصور في العرض التقديمي؟**

لا يخزن Aspose.Slides روابط عكسية من [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/) إلى الأشكال. قم بإنشاء خريطة يدوية أثناء التجوال: كلما وجدت إشارة إلى [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)، سجّل أي أشكال تستخدمها.

**هل يمكنني استخراج الصور المضمنة داخل كائنات OLE، مثل المستندات المرفقة؟**

ليس مباشرةً، لأن كائن OLE هو حاوية. تحتاج إلى استخراج حزمة OLE نفسها ثم تحليل محتوياتها باستخدام أدوات منفصلة. تعمل أشكال الصور في العرض التقديمي عبر [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)؛ OLE نوع كائن مختلف.