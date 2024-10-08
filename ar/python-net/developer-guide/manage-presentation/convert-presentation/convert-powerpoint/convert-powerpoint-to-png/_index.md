---
title: تحويل PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/python-net/convert-powerpoint-to-png/
keywords: PowerPoint إلى PNG, PPT إلى PNG, PPTX إلى PNG, Python, Aspose.Slides لـ Python عبر .NET
description: تحويل عرض PowerPoint إلى PNG
---

## **حول تحويل PowerPoint إلى PNG**

صيغة PNG (رسومات الشبكة المحمولة) ليست شائعة مثل JPEG (مجموعة الخبراء في التصوير الفوتوغرافي)، لكنها لا تزال شائعة جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة والحجم ليس مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="نصيحة" color="primary" %}} قد ترغب في الاطلاع على **محولات PowerPoint إلى PNG** المجانية من Aspose: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ حي للعملية الموصوفة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

تابع هذه الخطوات:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) تحت واجهة [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. استخدم طريقة [ISlide.GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) لحفظ الصورة المصغرة للشريحة بتنسيق PNG.

يوضح كود Python هذا كيفية تحويل عرض PowerPoint إلى PNG:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image() as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)
```

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

إذا كنت ترغب في الحصول على ملفات PNG حول نطاق معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، والتي تحدد أبعاد الصورة المصغرة الناتجة.

يوضح هذا الكود في Python العملية الموصوفة:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(scaleX, scaleY) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

إذا كنت تريد الحصول على ملفات PNG حول حجم معين، يمكنك تمرير القيم المفضلة لديك لـ `width` و `height` كوسائط لـ `ImageSize`.

يظهر هذا الكود كيفية تحويل PowerPoint إلى PNG مع تحديد الحجم للصور:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(size) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```