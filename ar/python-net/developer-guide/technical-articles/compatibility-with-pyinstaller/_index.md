---
title: التوافق مع PyInstaller و cx_Freeze
linktitle: التوافق مع PyInstaller
type: docs
weight: 122
url: /ar/python-net/compatibility-with-pyinstaller/
keywords:
- التوافق
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "إنشاء حزمة Aspose.Slides للغة Python عبر .NET باستخدام PyInstaller. اتبع هذا الدليل لتجميع التطبيق، وتكوينه، وحل المشكلات لإنشاء ملف تنفيذي مستقل."
---

## **التوافق مع PyInstaller و cx_Freeze**

ملحقات Aspose.Slides للغة Python عبر .NET هي امتدادات قياسية لبايثون C، لذا يمكن تجميدها كاعتمادات للبرنامج باستخدام أدوات مثل PyInstaller و cx_Freeze (أو ما شابه). يتيح لك ذلك إنشاء ملفات تنفيذية من سكريبتات بايثون الخاصة بك. تُسمى هذه الأدوات “مجمِّدات” لأنها تجمع شفرتك واعتمادياتها في ملف واحد قابل للتوزيع يُشغل على أجهزة أخرى دون الحاجة إلى تثبيت بايثون أو مكتبات إضافية. يبسط هذا النهج عملية توزيع تطبيقات بايثون.

يُوضح المثال أدناه تجميد ملحق Aspose.Slides للغة Python عبر .NET كاعتماد من خلال برنامج بسيط يستخدم Aspose.Slides.

### **PyInstaller**

عمومًا، لا يتطلب شيء خاص عند حزم برنامج يعتمد على ملحق Aspose.Slides للغة Python عبر .NET. عندما يستورد البرنامج الملحق بطريقة يمكن لـ PyInstaller رؤيتها، سيتم تضمين الملحق مع البرنامج. نظرًا لأن Aspose.Slides للغة Python عبر .NET يتضمن ربطات (hooks) لـ PyInstaller، تُكتشف اعتمادياته تلقائيًا وتُنسخ إلى الحزمة.

`slide_app.py`:
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

ومع ذلك، قد يتغافل PyInstaller أحيانًا عن الاستيرادات المخفية — الوحدات التي تُستورد بصورة ديناميكية أو غير مباشرة من قبل الشفرة الخاصة بك. لتضمين استيراد مخفي، استخدم خيارات PyInstaller. تُحدَّد اعتماديات الملحق في ربطات PyInstaller التي تُرفق مع Aspose.Slides للغة Python عبر .NET.

`slide_app.spec`:
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

لتجميد برنامج باستخدام cx_Freeze، قم بتكوينه لتضمين الحزمة الجذرية لملحق Aspose.Slides للغة Python عبر .NET الذي تستخدمه. يضمن ذلك نسخ الملحق وجميع الوحدات التابعة إلى بنية البناء جنبًا إلى جنب مع تطبيقك.

#### **استخدام سكريبت cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **استخدام سكريبت الإعداد**

`setup.py`:
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

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو .NET على جهاز المستخدم؟**

لا، لا يلزم وجود PowerPoint. Aspose.Slides هو محرك مستقل؛ حزمة بايثون تُوزِّع كل ما يلزم كملحق لـ CPython. لا يحتاج المستخدم إلى تثبيت .NET بصورة منفصلة.

**كيف يمكنني إرفاق الترخيص بشكل صحيح لتطبيق مجمَّد؟**

يمكنك حفظ ملف الترخيص XML بجوار الملف التنفيذي أو تضمينه كموارد وتحميله من مسار قابل للوصول قبل أول استدعاء لواجهة برمجة التطبيقات. مهم: لا تقم بتعديل محتوى XML (ولا حتى فواصل الأسطر).

**ماذا أفعل إذا ظهرت اختلافات في عرض الخطوط بعد البنية مقارنة ببيئة التطوير؟**

تأكد من توفر الخطوط التي تستخدمها في البيئة الهدف (سواءً ضمن الحزمة أو مثبتة في النظام) وأنَّ مساراتها تُحلَّ بشكل صحيح أثناء التشغيل؛ سلوك الخطوط حساس بشكل خاص على Linux.