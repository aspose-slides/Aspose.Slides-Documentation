---
title: "التوافق مع PyInstaller و cx_Freeze"
linktitle: "التوافق مع PyInstaller"
type: docs
weight: 122
url: /ar/python-net/compatibility-with-pyinstaller/
keywords:
- "التوافق"
- "PyInstaller"
- "cx_Freeze"
- "Python"
- "Aspose.Slides"
description: "احزم Aspose.Slides للـ Python عبر .NET باستخدام PyInstaller. اتبع هذا الدليل لتجميع وتكوين وحل مشكلات تطبيقك إلى ملف تنفيذي مستقل."
---

## **التوافق مع PyInstaller و cx_Freeze**

امتدادات Aspose.Slides للـ Python عبر .NET هي امتدادات C قياسية للـ Python، لذا يمكن تجميدها كاعتمادات للبرنامج باستخدام أدوات مثل PyInstaller و cx_Freeze (أو ما شابه). يتيح لك ذلك إنشاء ملفات تنفيذية من سكريبتات الـ Python الخاصة بك. تُسمى هذه الأدوات “مجمّدة” لأنها تجمع كودك واعتماداته في ملف واحد قابل للتوزيع يعمل على أجهزة أخرى دون الحاجة إلى تثبيت Python أو مكتبات إضافية. يبسط هذا النهج توزيع تطبيقات الـ Python الخاصة بك.

توضيح تجميد امتداد Aspose.Slides للـ Python عبر .NET كاعتماد موضح أدناه في برنامج بسيط يستخدم Aspose.Slides.

### **PyInstaller**

بشكل عام، لا يلزم أي شيء خاص عند حزم برنامج يعتمد على امتداد Aspose.Slides للـ Python عبر .NET. عندما يستورد البرنامج الامتداد بطريقة يمكن لـ PyInstaller رؤيتها، سيُضمّن الامتداد مع البرنامج. نظرًا لأن Aspose.Slides للـ Python عبر .NET يتضمن خطافات PyInstaller، يتم اكتشاف واعتماداعهاته تلقائيًا ونسخها إلى الحزمة.

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

ومع ذلك، قد يتفوت PyInstaller أحيانًا الاستيرادات المخفية — الوحدات التي يتم استيرادها ديناميكيًا أو غير مباشرًا بواسطة الكود الخاص بك. لإضافة استيراد مخفي، استخدم خيارات PyInstaller. يتم تحديد اعتماديات الامتداد في خطافات PyInstaller التي تُرسل مع Aspose.Slides للـ Python عبر .NET.

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

لتجميد برنامج باستخدام cx_Freeze، قم بتهيئته ليشمل الحزمة الأساسية لامتداد Aspose.Slides للـ Python عبر .NET الذي تستخدمه. يضمن ذلك نسخ الامتداد وجميع الوحدات التابعة إلى بناء التطبيق جنبًا إلى جنب مع تطبيقك.

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

**هل أحتاج إلى Microsoft PowerPoint أو .NET مثبتًا على جهاز المستخدم؟**

لا، لا يلزم وجود PowerPoint. Aspose.Slides هو محرك مستقل؛ حزمة الـ Python تُرسل كل ما يلزم كامتداد لـ CPython. لا يحتاج المستخدم إلى تثبيت .NET بشكل منفصل.

**كيف يمكنني إرفاق الترخيص بشكل صحيح إلى تطبيق مجمد؟**

يمكنك تخزين ملف الترخيص XML بجوار الملف التنفيذي أو تضمينه كموارد وتحميله من مسار يمكن الوصول إليه قبل أول استدعاء لواجهة البرمجة. مهم: لا تقم بتعديل محتوى XML (وليس حتى سطور الفواصل).

**ماذا أفعل إذا ظهرت الخطوط بشكل مختلف بعد البناء مقارنةً ببيئة التطوير؟**

تأكد من أن الخطوط التي تستخدمها متوفرة في البيئة الهدف (مُضمّنة أو مُثبتة على النظام) وأن مساراتها تُحل بصورة صحيحة أثناء وقت التشغيل؛ سلوك الخطوط حساس خاصةً على نظام Linux.