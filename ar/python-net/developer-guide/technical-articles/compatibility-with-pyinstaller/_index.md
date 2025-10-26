---
title: التوافق مع PyInstaller و cx_Freeze
linktitle: التوافق مع PyInstaller
type: docs
weight: 122
url: /ar/python-net/developer-guide/technical-articles/compatibility-with-pyinstaller/
keywords:
- التوافق
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "حزم Aspose.Slides للبايثون عبر .NET باستخدام PyInstaller. اتبع هذا الدليل لتجميع التطبيق، وتكوينه، وحل المشكلات لتشغيله كملف تنفيذي مستقل."
---

## **التوافق مع PyInstaller و cx_Freeze**

ملحقات Aspose.Slides للبايثون عبر .NET هي ملحقات C قياسية للبايثون، لذا يمكن تجميدها كاعتمادات للبرنامج باستخدام أدوات مثل PyInstaller و cx_Freeze (أو ما شابه). يتيح لك ذلك إنشاء ملفات تنفيذية من سكريبتات البايثون الخاصة بك. تُسمى هذه الأدوات “مجمّدة” لأنها تُدمج الكود الخاص بك واعتماداته في ملف واحد يمكن توزيعه ويعمل على أجهزة أخرى دون الحاجة إلى تثبيت بايثون أو مكتبات إضافية. يبسط هذا النهج توزيع تطبيقات البايثون الخاصة بك.

تجميد ملحق Aspose.Slides للبايثون عبر .NET كاعتماد موضح أدناه باستخدام برنامج بسيط يستخدم Aspose.Slides.

### **PyInstaller**

بشكل عام، لا يلزم أي شيء خاص عند حزم برنامج يعتمد على ملحق Aspose.Slides للبايثون عبر .NET. عندما يستورد البرنامج الملحق بطريقة يمكن لـ PyInstaller رؤيتها، سيتم دمج الملحق مع البرنامج. نظرًا لأن Aspose.Slides للبايثون عبر .NET يتضمن ربطات PyInstaller، يتم اكتشاف واعتماد اعتماده تلقائيًا ونقله إلى الحزمة.

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

ومع ذلك، قد يتغاضى PyInstaller أحيانًا عن الاستيرادات المخفية — الوحدات التي يتم استيرادها ديناميكيًا أو بشكل غير مباشر من قبل الكود الخاص بك. لتضمين استيراد مخفي، استخدم خيارات PyInstaller. يتم تحديد اعتمادات الملحق في ربطات PyInstaller التي تُرفق مع Aspose.Slides للبايثون عبر .NET.

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

لتجميد برنامج باستخدام cx_Freeze، قم بتكوينه لتضمين الحزمة الجذرية لملحق Aspose.Slides للبايثون عبر .NET الذي تستخدمه. يضمن ذلك نسخ الملحق وجميع الوحدات التابعة إلى البناء جنبًا إلى جنب مع تطبيقك.

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

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو .NET على جهاز المستخدم؟**

لا، لا يلزم وجود PowerPoint. Aspose.Slides هو محرك مستقل؛ حزمة البايثون تُرسل كل ما يلزم كملحق لـ CPython. لا يحتاج المستخدم إلى تثبيت .NET بشكل منفصل.

**كيف يمكنني إرفاق الترخيص بشكل صحيح لتطبيق مجمد؟**

يمكنك حفظ ملف الترخيص XML بجانب الملف التنفيذي أو تضمينه كمورد وتحميله من مسار قابل للوصول قبل أول استدعاء للواجهة البرمجية. مهم: لا تُعدّل محتوى XML (ليس حتى فواصل الأسطر).

**ماذا أفعل إذا ظهرت الخطوط بشكل مختلف بعد البناء مقارنةً ببيئة التطوير؟**

تأكد من أن الخطوط التي تستخدمها متوفرة في البيئة المستهدفة (مضمنة أو مثبتة على النظام) وأن مساراتها تُحلّ بشكل صحيح وقت التشغيل؛ سلوك الخطوط حساس خصوصًا على نظام Linux.