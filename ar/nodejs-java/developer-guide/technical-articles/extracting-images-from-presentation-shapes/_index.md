---
title: استخراج الصور من أشكال العرض التقديمي
type: docs
weight: 100
url: /ar/nodejs-java/extracting-images-from-presentation-shapes/
keywords: "استخراج صورة، PowerPoint، PPT، PPTX، عرض تقديمي PowerPoint، Java، Aspose.Slides for Node.js via Java"
description: "استخراج الصور من عرض PowerPoint التقديمي باستخدام JavaScript"
---

{{% alert color="primary" %}} 

غالبًا ما يتم إضافة الصور إلى الأشكال وتُستخدم أيضًا بشكل متكرر كخلفيات للشرائح. يتم إضافة كائنات الصورة عبر [ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/)، وهي مجموعة من كائنات [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).

تشرح هذه المقالة كيفية استخراج الصور المضافة إلى العروض التقديمية. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، يجب عليك أولاً تحديد موقع الصورة من خلال استعراض كل شريحة ثم كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. 
```javascript
function extractImages() {
    const folderPath = "./";
    const pres = new aspose.slides.Presentation(folderPath + "ExtractImages.pptx");
    let img = null;
    let backImage = null;

    let slideIndex = 0;
    let imageType = 0;
    let ifImageFound = false;

    for (let i = 0; i < pres.getSlides().size(); i++) {
        slideIndex++;
        let sl = pres.getSlides().get_Item(i);

        if (sl.getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_Slide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        } else if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_LayoutSlide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        }

        for (let j = 0; j < sl.getShapes().size(); j++) {
            let sh = sl.getShapes().get_Item(j);

            if (java.instanceOf(sh, "com.aspose.slides.IAutoShape")) {
                let ashp = sh;
                if (ashp.getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
                    img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }
            } else if (java.instanceOf(sh, "com.aspose.slides.IPictureFrame")) {
                let pf = sh;
                img = pf.getPictureFormat().getPicture().getImage();
                imageType = getImageTType(img);
                ifImageFound = true;
            }

            if (ifImageFound) {
                const imagePath = folderPath + "backImage_Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                saveImage(img, imagePath, imageType);
            }
            ifImageFound = false;
        }
    }
}

function getImageTType(image) {
    let imageContentType = image.getContentType();
    imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
    imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
    return imageContentType;
}

function capitalize(str) {
    if (!str || str.length <= 1) return str;
    return str.charAt(0).toUpperCase() + str.slice(1);
}

function saveImage(image, path, imageType) {    
    var ImageFormatClass = java.import('com.aspose.slides.ImageFormat');
    let imageTypeValue = java.callStaticMethodSync("com.aspose.slides.ImageFormat", "getValue", ImageFormatClass.class, capitalize(imageType));
    
    image.getImage().save(path, java.newInstanceSync("java.lang.Integer", imageTypeValue.longValue));
    console.log(`Image saved to ${path}`);
}
```


## **FAQ**

**هل يمكنني استخراج الصورة الأصلية بدون أي قص أو تأثيرات أو تحولات على الشكل؟**

نعم. عندما تصل إلى صورة الشكل، تحصل على كائن الصورة من [مجموعة الصور](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي، أي البكسلات الأصلية دون قص أو تأثيرات تنسيق. تتنقل العملية عبر مجموعة الصور الخاصة بالعرض التقديمي وكائنات PPImage، التي تخزن البيانات الخام.

**هل هناك خطر تكرار ملفات متطابقة عند حفظ العديد من الصور مرة واحدة؟**

نعم، إذا قمت بحفظ كل شيء بدون تمييز. قد تحتوي [مجموعة الصور](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/) الخاصة بالعرض التقديمي على بيانات ثنائية متطابقة يتم الإشارة إليها من قبل أشكال أو شرائح مختلفة. لتجنب تكرار الملفات، قارن التجزئات أو الأحجام أو محتويات البيانات المستخرجة قبل الكتابة.

**كيف يمكنني تحديد الأشكال المرتبطة بصورة معينة من مجموعة الصور الخاصة بالعرض التقديمي؟**

لا تقوم Aspose.Slides بتخزين الروابط العكسية من PPImage إلى الأشكال. قم بإنشاء خريطة يدوية أثناء التجول: كلما وجدت إشارة إلى PPImage، سجِّل الأشكال التي تستخدمه.

**هل يمكنني استخراج الصور المضمنة داخل كائنات OLE، مثل المستندات المرفقة؟**

ليس مباشرة، لأن كائن OLE هو حاوية. تحتاج إلى استخراج حزمة OLE نفسها ثم تحليل محتوياتها باستخدام أدوات منفصلة. تعمل أشكال الصور في العرض التقديمي عبر PPImage؛ أما OLE فهو نوع كائن مختلف.