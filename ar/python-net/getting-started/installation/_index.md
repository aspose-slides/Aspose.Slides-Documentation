---
title: التثبيت
type: docs
weight: 70
url: /python-net/installation/
keywords: "تحميل Aspose.Slides، تثبيت Aspose.Slides، تثبيت Aspose.Slides، ويندوز، macOS، بايثون"
description: "تثبيت Aspose.Slides لبايثون عبر .NET على ويندوز أو macOS"
---

تأتي حزمة Aspose.Slides لبايثون عبر .NET مع مكتبات .NET التي تحتاجها، لذا فإن التثبيت المنفصل لـ .NET غير مطلوب. ومع ذلك، اعتمادًا على منصتك، قد تحتاج إلى تثبيت تبعيات محددة لـ .NET وتلبية متطلبات معينة.

## **ويندوز**

**متطلبات النظام**

تحقق و确认 أن مواصفات جهازك تلبي أو أفضل من [متطلبات النظام](/slides/python-net/system-requirements/).

### **تثبيت Aspose.Slides**

يعد `pip` أسهل طريقة لتحميل وتثبيت [Aspose.Slides لبايثون عبر .NET](https://pypi.org/project/aspose.slides/) على أجهزة ويندوز.

لتثبيت Aspose.Slides، قم بتشغيل هذا الأمر:  `pip install aspose.slides`

**استخدام Aspose.Slides**

اختبر تثبيت Aspose.Slides الخاص بك عن طريق تشغيل هذا الكود لإنشاء عرض تقديمي PowerPoint:

```python
# استيراد وحدة Aspose.Slides لبايثون عبر .NET
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**متطلبات النظام**

تحقق و تأكد أن مواصفات جهازك تلبي أو أفضل من [متطلبات النظام](/slides/python-net/system-requirements/).

### **المتطلبات المسبقة**

**بايثون مع المكتبات المشتركة**

هناك طرق مختلفة لتثبيت بايثون على macOS، ولكننا نوصي بشدة باستخدام [أداة pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

بعد تثبيت وتكوين pyenv، يجب عليك تثبيت بايثون مع المكتبات المشتركة عن طريق تشغيل هذه الأوامر في تطبيق Terminal:

1. قم بتثبيت بايثون: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. قم بتكوينه كتثبيت بايثون عالمي: `pyenv global 3.9.13`
3. قم بتكوينه كتثبيت بايثون في الصدفة: `pyenv shell 3.9.13`
4. أنشئ رابطًا رمزيًا لمكتبة libpython في دليل مكتبة النظام: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

ملاحظة: يتطلب الأمر بايثون 3.5 وما فوق. تم استخدام إصدار بايثون 3.9.13 كمثال فقط.

**تثبيت مكتبة libgdiplus**

مكتبة libgdiplus هي تنفيذ Windows GDI+ لـ macOS و Linux والتي يستخدمها .NET على تلك المنصات. لتثبيت هذه المكتبة، قم بتشغيل هذا الأمر: `brew install mono-libgdiplus` 

### **تثبيت Aspose.Slides**

يعد `pip` أسهل طريقة لتحميل وتثبيت [Aspose.Slides لبايثون عبر .NET](https://pypi.org/project/aspose.slides/) على أجهزة macOS. لتثبيت Aspose.Slides، قم بتشغيل هذا الأمر: `pip install aspose.slides`

**استخدام Aspose.Slides**

اختبر تثبيت Aspose.Slides الخاص بك عن طريق تشغيل هذا الكود لإنشاء عرض تقديمي PowerPoint:

```python
# استيراد وحدة Aspose.Slides لبايثون عبر .NET
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```