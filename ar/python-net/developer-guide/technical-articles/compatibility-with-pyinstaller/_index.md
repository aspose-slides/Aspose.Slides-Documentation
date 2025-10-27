---
title: التوافق مع PyInstaller و cx_Freeze
linktitle: التوافق مع PyInstaller
type: docs
weight: 122
url: /ar/python-net/compatibility-with-pyinstaller/
keywords:
- compatibility
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "حزم Aspose.Slides for Python عبر .NET باستخدام PyInstaller. اتبع هذا الدليل لتجميع وتكوين واستكشاف تطبيقك وإصلاح المشكلات لجعله ملفًا تنفيذيًا مستقلًا."
---

## **التوافق مع PyInstaller و cx_Freeze**

Aspose.Slides for Python عبر .NET هي امتدادات قياسية لـ Python C، لذا يمكن تجميدها كاعتمادات للبرنامج باستخدام أدوات مثل PyInstaller و cx_Freeze (أو ما شابه). يتيح لك هذا إنشاء ملفات تنفيذية من سكريبتات Python الخاصة بك. تسمى هذه الأدوات “freezers” لأنها تجمع شيفرتك واعتمادياتها في ملف واحد قابل للتوزيع يعمل على أجهزة أخرى دون الحاجة إلى تثبيت Python أو مكتبات إضافية. يبسط هذا النهج توزيع تطبيقات Python الخاصة بك.

يتم توضيح تجميد امتداد Aspose.Slides for Python عبر .NET كاعتماد في المثال التالي باستخدام برنامج بسيط يستخدم Aspose.Slides.

### **PyInstaller**

عمومًا، لا يتطلب أي شيء خاص عند حزم برنامج يعتمد على امتداد Aspose.Slides for Python عبر .NET. عندما يستورد البرنامج الامتداد بطريقة يمكن لـ PyInstaller رؤيتها، سيتم تجميع الامتداد مع البرنامج. نظرًا لأن Aspose.Slides for Python عبر .NET يتضمن ربطات (hooks) لـ PyInstaller، يتم اكتشاف اعتمادياته تلقائيًا ونسخها إلى الحزمة.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

مع ذلك، قد يتغاضى PyInstaller أحيانًا عن الاستيرادات المخفية — وهي الوحدات التي يتم استيرادها ديناميكيًا أو بشكل غير مباشر بواسطة الشيفرة الخاصة بك. لتضمين استيراد مخفي، استخدم خيارات PyInstaller. يتم تحديد اعتماديات الامتداد في ربطات PyInstaller التي تُرفق مع Aspose.Slides for Python عبر .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

### **cx_Freeze**

لتجميد برنامج باستخدام cx_Freeze، قم بتكوينه لتضمين الحزمة الجذرية لامتداد Aspose.Slides for Python عبر .NET الذي تستخدمه. يضمن ذلك نسخ الامتداد وجميع الوحدات التابعة إليه إلى عملية البناء إلى جانب تطبيقك.

#### **استخدام سكريبت cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **استخدام سكريبت الإعداد**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو .NET على جهاز المستخدم؟**

لا، لا يلزم وجود PowerPoint. Aspose.Slides هو محرك مستقل؛ حزمة Python توفر كل ما يلزم كامتداد لـ CPython. لا يحتاج المستخدم إلى تثبيت .NET بشكل منفصل.

**كيف يمكنني إرفاق الترخيص بشكل صحيح لتطبيق مُجمد؟**

يمكنك تخزين ملف ترخيص XML بجوار الملف التنفيذي أو تضمينه كموارد وتحميله من مسار يمكن الوصول إليه قبل أول استدعاء للـ API. مهم: لا تقم بتعديل محتوى XML (حتى لا تغير فواصل الأسطر).

**ماذا أفعل إذا تم عرض الخطوط بشكل مختلف بعد البناء مقارنةً ببيئة التطوير؟**

تأكد من أن الخطوط التي تستخدمها متاحة في بيئة الهدف (مضمونة أو مثبتة على النظام) وأن مساراتها يتم حلها بشكل صحيح أثناء تشغيل البرنامج؛ سلوك الخطوط حساس بشكل خاص على نظام Linux.