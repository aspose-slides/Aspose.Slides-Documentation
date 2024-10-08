---
title: تحويل PowerPoint PPT إلى JPG في Python
linktitle: تحويل PowerPoint PPT إلى JPG
type: docs
weight: 60
url: /ar/python-net/convert-powerpoint-to-jpg/
keywords: "python ppt to image, تحويل عرض PowerPoint, JPG, JPEG, PowerPoint إلى JPG, PowerPoint إلى JPEG, PPT إلى JPG, PPTX إلى JPG, PPT إلى JPEG, PPTX إلى JPEG, Python, Aspose.Slides"
description: "تحويل PowerPoint إلى JPG في Python. حفظ الشريحة كصورة JPG"
---

## **حول تحويل PowerPoint إلى JPG**
مع [**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG في Python. من الممكن أيضًا تحويل PPT/PPTX إلى BMP أو PNG أو SVG في Python. مع هذه المميزات، من السهل تنفيذ عارض العروض التقديمية الخاص بك، وإنشاء الصورة المصغرة لكل شريحة. قد يكون هذا مفيدًا إذا كنت ترغب في حماية شرائح العرض التقديمي من حقوق النشر، وعرض العرض في وضع القراءة فقط. يتيح لك Aspose.Slides تحويل العرض التقديمي بالكامل أو شريحة معينة إلى تنسيقات الصور. 

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides PowerPoint إلى صور JPG، يمكنك تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
إليك الخطوات لتحويل PPT/PPTX إلى JPG:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على كائن الشريحة من نوع [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. إنشاء الصورة المصغرة لكل شريحة ثم تحويلها إلى JPG. يُستخدم [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) للحصول على صورة مصغرة لشريحة، ويعيد [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) كائنًا كنتيجة. يجب استدعاء [GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) من الشريحة المطلوبة من نوع [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) ، ويتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، استدعِ [**IImage.Save(string filename, ImageFormat format)**](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) من كائن الصورة المصغرة. مرر اسم الملف الناتج وتنسيق الصورة إليه. 

{{% alert color="primary" %}} 
**ملاحظة**: يختلف تحويل PPT/PPTX إلى JPG عن التحويل إلى أنواع أخرى في Aspose.Slides .NET API. بالنسبة للأنواع الأخرى، عادةً ما تستخدم [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)الطريقة، لكن هنا تحتاج إلى [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8)الطريقة.
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **تحويل PowerPoint PPT/PPTX إلى JPG بأبعاد مخصصة**
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و *ScaleY* بتمريرها إلى [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) الطريقة:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

desiredX = 1200
desiredY = 800
scaleX = (float)(1.0 / pres.slide_size.size.width) * desiredX
scaleY = (float)(1.0 / pres.slide_size.size.height) * desiredY

for sld in pres.slides:
    with sld.get_image(scaleX, scaleY) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب [مجانًا لتجميع الصور](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **انظر أيضًا**

اطلع على خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/).