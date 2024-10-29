---
title: إدارة القوائم النقطية والمرقمة
type: docs
weight: 70
url: /ar/python-net/manage-bullet-and-numbered-lists/
keywords: "نقاط, قوائم نقطية, أرقام, قوائم مرقمة, صور نقاط, قوائم متعددة المستويات, عرض PowerPoint, بايثون, Aspose.Slides لبايثون عبر .NET"
description: "إنشاء قوائم نقطية ومرقمة في عرض PowerPoint باستخدام بايثون"
---

في **مايكروسوفت باوربوينت**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تقوم بها في وورد و محررات النصوص الأخرى. **Aspose.Slides لبايثون عبر .NET** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك التقديمية.

### لماذا تستخدم القوائم النقطية؟

تساعد القوائم النقطية في تنظيم وعرض المعلومات بسرعة وكفاءة.

**مثال على القائمة النقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه قرائك أو مشاهديك إلى معلومات مهمة
- تتيح لقرائك أو مشاهديك البحث عن النقاط الرئيسية بسهولة
- تنقل وتوفر تفاصيل مهمة بكفاءة.

### لماذا تستخدم القوائم المرقمة؟

تساعد القوائم المرقمة أيضًا في تنظيم وعرض المعلومات. من المثالي أن تستخدم الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، وما إلى ذلك) مهمًا أو عندما يجب الإشارة إلى إدخال (على سبيل المثال، *انظر الخطوة 3*).

**مثال على القائمة المرقمة**

هذه ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء مثيل من فئة العرض التقديمي.
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي.

## إنشاء النقاط

لإنشاء قائمة نقطية، اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة (التي تريد إضافة قائمة نقطية إليها) في مجموعة الشرائح من خلال كائن [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. إضافة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) في الشريحة المحددة.
4. الوصول إلى [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [text_frame]().
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
8. تعيين نوع النقطة إلى الرمز ثم تعيين حرف النقطة.
9. تعيين نص الفقرة.
10. تعيين انبعاث الفقرة لتعيين النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقطة.
13. إضافة الفقرة التي تم إنشاؤها في مجموعة الفقرات في [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. إضافة الفقرة الثانية وتكرار الخطوات 7-12.
15. حفظ العرض التقديمي.

الكود التجريبي في بايثون - تنفيذ الخطوات أعلاه - يظهر لك كيفية إنشاء قائمة نقطية في شريحة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "نصي"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

 

## إنشاء صور النقاط

يتيح لك Aspose.Slides لبايثون عبر .NET تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت تريد إضافة اهتمام بصري إلى قائمة أو جذب المزيد من الانتباه إلى إدخالات في قائمة، يمكنك استخدام صورتك الخاصة كنقطة.

 {{% alert color="primary" %}} 

من المثالي، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، أن تختار صورة رسومية بسيطة مع خلفية شفافة. تعمل مثل هذه الصور بشكل أفضل كرموز نقطية مخصصة.

في جميع الحالات، ستقلل الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة أن تختار صورة تبدو جيدة (كبديل لرمز النقطة) في قائمة.

{{% /alert %}} 

لإنشاء نقطة صورة، اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. إضافة [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) في الشريحة المحددة.
4. الوصول إلى [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. تحميل صورة من القرص وإضافتها إلى [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ثم استخدام مثيل [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) الذي تم إرجاعه من طريقة [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
8. تعيين نوع النقطة إلى صورة ثم تعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين انبعاث الفقرة لتعيين النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها في مجموعة الفقرات في [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. إضافة الفقرة الثانية وتكرار الخطوات 7-13.
15. حفظ العرض التقديمي.

هذا كود بايثون يظهر لك كيفية إنشاء نقطة صورة في شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "نصي"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

 

## إنشاء القوائم متعددة المستويات

لإنشاء قائمة نقطية تحتوي على عناصر من مستويات مختلفة- قوائم إضافية تحت القائمة النقطية الرئيسية- اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. إضافة [auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) في الشريحة المحددة.
4. الوصول إلى [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) للشكل المضاف.
5. إزالة الفقرة الافتراضية في [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) مع تعيين العمق إلى 0.
7. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph مع تعيين العمق إلى 1.
8. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph مع تعيين العمق إلى 2.
9. إنشاء مثيل الفقرة الرابعة باستخدام فئة Paragraph مع تعيين العمق إلى 3.
10. إضافة الفقرات التي تم إنشاؤها في مجموعة الفقرات في [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
11. حفظ العرض التقديمي.

هذا الكود، الذي هو تنفيذ للخطوات أعلاه، يظهر لك كيفية إنشاء قائمة نقطية متعددة المستويات في بايثون:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "نصي عمق 0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "نصي عمق 1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "نصي عمق 2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "نصي عمق 3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

 

## إنشاء الأرقام

هذا الكود في بايثون يظهر لك كيفية إنشاء قائمة مرقمة في شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "نصي 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "نصي 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```