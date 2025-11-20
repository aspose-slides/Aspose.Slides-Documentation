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
description: "حزم Aspose.Slides لـ Python عبر .NET باستخدام PyInstaller. اتبع هذا الدليل لتجميع وتكوين ومعالجة تطبيقك إلى ملف تنفيذي مستقل."
---

## **التوافق مع PyInstaller و cx_Freeze**

تعد امتدادات Aspose.Slides لـ Python عبر .NET امتدادات Python C قياسية، لذا يمكن تجميدها كاعتماديات للبرنامج باستخدام أدوات مثل PyInstaller و cx_Freeze (أو ما شابه). هذا يتيح لك إنشاء ملفات تنفيذية من سكريبتات Python الخاصة بك. تُسمى هذه الأدوات “freezers” لأنها تجمع شفرتك واعتمادياتها في ملف واحد قابل للتوزيع يعمل على أجهزة أخرى دون الحاجة إلى تثبيت Python أو مكتبات إضافية. يبسط هذا النهج عملية توزيع تطبيقات Python الخاصة بك.

يتم توضيح تجميد امتداد Aspose.Slides لـ Python عبر .NET كاعتماد أدناه باستخدام برنامج بسيط يستخدم Aspose.Slides.

### **PyInstaller**

عمومًا، لا يلزم أي شيء خاص عند حزم برنامج يعتمد على امتداد Aspose.Slides لـ Python عبر .NET. عندما يستورد البرنامج الامتداد بطريقة يمكن لـ PyInstaller رؤيتها، سيتم تضمين الامتداد مع البرنامج. نظرًا لأن Aspose.Slides لـ Python عبر .NET يتضمن ربطات (hooks) لـ PyInstaller، يتم اكتشاف اعتمادياته تلقائيًا ونسخها إلى الحزمة.

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


ومع ذلك، قد يتغاضى PyInstaller أحيانًا عن الاستيرادات المخفية — الوحدات التي يتم استيرادها ديناميكيًا أو بصورة غير مباشرة بواسطة الشفرة الخاصة بك. لتضمين استيراد مخفي، استخدم خيارات PyInstaller. يتم تحديد اعتمادية الامتداد في ربطات PyInstaller التي تُرفق مع Aspose.Slides لـ Python عبر .NET.

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

لجمّدة برنامج باستخدام cx_Freeze، قم بتكوينه لتضمين الحزمة الجذرية لامتداد Aspose.Slides لـ Python عبر .NET الذي تستخدمه. يضمن ذلك نسخ الامتداد وجميع الوحدات التابعة إلى عملية البناء جنبًا إلى جنب مع تطبيقك.

#### **استخدام سكربت cxfreeze**
```bash
$ cxfreeze slide_app.py --packages=aspose
```


#### **استخدام سكربت الإعداد**

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


## **الأسئلة المتداولة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو .NET على جهاز المستخدم؟**

لا، لا يُطلب PowerPoint. Aspose.Slides هو محرك مستقل؛ حزمة Python تُرفق كل ما يلزم كامتداد لـ CPython. لا يحتاج المستخدم إلى تثبيت .NET بشكل منفصل.

**كيف يجب علي ربط الترخيص بشكل صحيح بتطبيق مجمَّد؟**

يمكنك حفظ ملف الترخيص XML بجوار الملف التنفيذي أو تضمينه كمورد وتحميله من مسار يمكن الوصول إليه قبل أول استدعاء لواجهة برمجة التطبيقات. مهم: لا تُعدّل محتوى XML (ولا حتى فواصل الأسطر).

**ماذا أفعل إذا ظهرت الخطوط بشكل مختلف بعد عملية البناء مقارنةً ببيئة التطوير؟**

تأكد من أن الخطوط التي تستخدمها متوفرة في بيئة الهدف (مضمَّنة أو مثبتة على النظام) وأن مساراتها يتم حلها بشكل صحيح عند وقت التشغيل؛ سلوك الخطوط حساس بشكل خاص على نظام Linux.