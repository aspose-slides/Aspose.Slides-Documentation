---
title: طباعة العرض التقديمي
type: docs
weight: 50
url: /ar/python-net/print-presentation/
keywords: "طباعة باوربوينت، PPT، PPTX، طباعة العرض التقديمي، بايثون، طابعة، خيارات الطباعة"
description: "طباعة عرض باوربوينت باستخدام بايثون"
---
تقدم Aspose.Slides لبايثون 4 طرق `print` مُحمَّلة تسمح لك بطباعة العروض التقديمية. تأخذ الطرق المُحمَّلة معلمات مختلفة، لذا ستجد دائمًا طريقة تناسب احتياجات طباعةك.

## **الطباعة إلى الطابعة الافتراضية**

تُستخدم هذه العملية البسيطة لطباعة جميع الشرائح في عرض باوربوينت من خلال الطابعة الافتراضية للنظام.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرر العرض التقديمي الذي تريد طباعته.
2. استدعِ طريقة `print` (بدون معلمات).

يظهر لك هذا الكود باستخدام بايثون كيفية طباعة عرض باوربوينت:

```python
import aspose.slides as slides

# تحميل العرض التقديمي
presentation = slides.Presentation("Print.ppt")

# استدعاء طريقة الطباعة لطباعة العرض التقديمي بالكامل إلى الطابعة الافتراضية
presentation.print()
```

## **الطباعة إلى طابعة معينة**

تُستخدم هذه العملية لطباعة جميع الشرائح في عرض باوربوينت من خلال طابعة معينة.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرر العرض التقديمي الذي تريد طباعته.
2. استدعِ طريقة `print` ومرر اسم الطابعة كسلسلة نصية.

يظهر لك هذا الكود باستخدام بايثون كيفية طباعة عرض باوربوينت باستخدام طابعة معينة:

```python
import aspose.slides as slides

try:
    # تحميل العرض التقديمي
    with slides.Presentation("pres.pptx") as pres:
        # استدعاء طريقة الطباعة لطباعة العرض التقديمي بالكامل إلى الطابعة المطلوبة
        pres.print("يرجى تعيين اسم طابعتك هنا")
except:
    print("يرجى تعيين اسم الطابعة كمعلمة نصية لطريقة طباعة العرض التقديمي")
```

## **تعيين خيارات الطباعة ديناميكيًا**

باستخدام الخصائص من فئة `PrinterSettings`، يمكنك تطبيق معلمات تحدد عملية الطباعة. يمكنك تحديد عدد النسخ التي يجب طباعتها، سواء كانت الشرائح يجب طباعتها في وضع أفقي أو عمودي، الهوامش المفضلة لديك، إلخ.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ومرر العرض التقديمي الذي تريد طباعته.
2. قم بتهيئة فئة `PrinterSettings`.
3. حدد معلماتك المفضلة لعملية الطباعة:
   * عدد النسخ
   * اتجاه الصفحة
   * أرقام الهوامش، إلخ.
4. استدعِ طريقة `print`.

يظهر لك هذا الكود باستخدام بايثون كيفية طباعة عرض باوربوينت مع خيارات طباعة معينة: 

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    printerSettings = drawing.printing.PrinterSettings()
    printerSettings.copies = 2
    printerSettings.default_page_settings.landscape = True
    printerSettings.default_page_settings.margins.left = 10
    pres.print(printerSettings)
```