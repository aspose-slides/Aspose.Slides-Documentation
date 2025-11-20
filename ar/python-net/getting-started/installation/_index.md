---
title: "التثبيت"
type: docs
weight: 70
url: /ar/python-net/installation/
keywords:
- "تحميل Aspose.Slides"
- "تثبيت Aspose.Slides"
- "استخدام Aspose.Slides"
- "تثبيت Aspose.Slides"
- Windows
- macOS
- Python
description: "تعرف على كيفية تثبيت Aspose.Slides لـ Python عبر .NET بسرعة. دليل خطوة بخطوة، متطلبات النظام، وعينات الشيفرة — ابدأ العمل على عروض PowerPoint التقديمية اليوم!"
---

## **نظرة عامة**

تأتي حزمة Aspose.Slides for Python عبر .NET مرفقة بجميع مكتبات .NET الأساسية، مما يعني عدم الحاجة لتثبيت .NET بشكل منفصل. يسهل ذلك عملية الإعداد ويسمح للمطورين بالبدء في العمل على العروض التقديمية فورًا. ومع ذلك، يجب ملاحظة أنه اعتمادًا على نظام التشغيل أو البيئة الخاصة بك، قد تحتاج إلى تثبيت بعض الاعتمادات الخاصة بالمنصة المطلوبة من .NET. بالإضافة إلى ذلك، يجب تلبية بعض متطلبات النظام لضمان التوافق الكامل وعمل الحزمة بشكل صحيح.

## **ويندوز**

**متطلبات النظام**

تحقق وتأكد من أن مواصفات جهازك تلبي أو تتجاوز [متطلبات النظام](/slides/ar/python-net/system-requirements/).

### **تثبيت Aspose.Slides**

`pip` هو أسهل طريقة لتنزيل وتثبيت [Aspose.Slides for Python عبر .NET](https://pypi.org/project/aspose-slides/) على Windows.

لتثبيت Aspose.Slides، نفّذ الأمر التالي:
```sh
pip install aspose-slides
```


**استخدام Aspose.Slides**

اختبر تثبيت Aspose.Slides الخاص بك عن طريق تشغيل الشيفرة التالية لإنشاء عرض تقديمي PowerPoint:
```python
# استيراد Aspose.Slides لـ Python عبر .NET.
# إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي.
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **macOS**

**متطلبات النظام**

تحقق وتأكد من أن مواصفات جهازك تلبي أو تتجاوز [متطلبات النظام](/slides/ar/python-net/system-requirements/).

### **المتطلبات المسبقة**

**Python مع المكتبات المشتركة**

هناك عدة طرق لتثبيت Python على macOS، لكننا نوصي بشدة باستخدام [أداة pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

بعد تثبيت وتكوين **pyenv**، قم بتثبيت Python مع المكتبات المشتركة عن طريق تشغيل الأوامر التالية في تطبيق Terminal:

1. تثبيت Python:
```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```


2. تعيينه كإصدار Python العالمي:
```sh
pyenv global 3.9.13
```


3. تعيينه كإصدار Python خاص بالصدفة:
```sh
pyenv shell 3.9.13
```


4. إنشاء رابط رمزي لمكتبة libpython في دليل مكتبة النظام:
```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```


ملاحظة: يلزم Python 3.5 أو أحدث. تم استخدام الإصدار 3.9.13 هنا كمثال فقط.

**تثبيت مكتبة libgdiplus**

مكتبة **libgdiplus** هي تنفيذ Windows GDI+ لـ macOS و Linux تعتمد عليه .NET للوظائف الرسومية على تلك الأنظمة.

لتثبيت هذه المكتبة على macOS، نفّذ الأمر التالي:
```sh
brew install mono-libgdiplus
```


### **تثبيت Aspose.Slides**

`pip` هو أسهل طريقة لتنزيل وتثبيت [Aspose.Slides for Python عبر .NET](https://pypi.org/project/aspose-slides/) على macOS.

لتثبيت Aspose.Slides، نفّذ الأمر التالي:
```sh
pip install aspose-slides
```


**استخدام Aspose.Slides**

اختبر تثبيت Aspose.Slides الخاص بك عن طريق تشغيل الشيفرة التالية لإنشاء عرض تقديمي PowerPoint:
```python
# استيراد Aspose.Slides لـ Python عبر .NET.
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني تثبيت Aspose.Slides في بيئة افتراضية؟**

نعم، يمكنك تثبيتها في أي بيئة افتراضية للـ Python باستخدام `pip`. فقط تأكد من أن البيئة لديها إمكانية الوصول إلى الاعتمادات الأصلية المطلوبة حسب نظام التشغيل الخاص بك.

**هل يمكنني استخدام Aspose.Slides في حاويات Docker؟**

نعم، ولكن عليك التأكد من أن صورة Docker الخاصة بك تتضمن المكتبات الأصلية المطلوبة (**libgdiplus**، حزم الخطوط، إلخ) والإصدار الصحيح من Python.

**هل هناك نسخة مجانية أو قيود على النسخة التجريبية؟**

نعم، بشكل افتراضي يعمل Aspose.Slides في وضع التقييم، مما يضيف علامات مائية وقد يكون له قيود أخرى. لإزالة القيود، تحتاج إلى تطبيق [رخصة](/slides/ar/python-net/licensing/) صالحة.