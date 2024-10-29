---
title: التوافق مع PyInstaller و cx_Freeze
type: docs
weight: 122
url: /ar/python-net/compatibility-with-pyinstaller/
---


## التوافق مع PyInstaller و cx_Freeze ##

تعتبر ملحقات 'Aspose.Slides for Python عبر .NET' ببساطة ملحقات C بلغة Python، والتي يمكن تجميدها بمساعدة PyInstaller و cx_Freeze (أو أدوات مشابهة) كاعتماديات للبرنامج. هذا يعني أنه يمكنك استخدام أدوات مثل PyInstaller و cx_Freeze لإنشاء ملفات تنفيذية من سكريبتات Python الخاصة بك. تُسمى هذه الأدوات "مجمدات" لأنها تقوم بتجميد كودك واعتمادياته في ملف واحد يمكن أن يعمل على آلات أخرى دون الحاجة إلى Python أو مكتبات أخرى. مما يسهل توزيع تطبيقات Python الخاصة بك للآخرين.

يتم توضيح تجميد ملحق 'Aspose.Slides for Python عبر .NET' كاعتماد برنامج من خلال مثال لبرنامج بسيط يستخدم Aspose.Slides.

### PyInstaller
بشكل عام، لا حاجة لعمل أي شيء خاص عند تعبئة برنامج يعتمد على ملحق 'Aspose.Slides for Python عبر .NET'. عندما يقوم برنامج باستيراد ملحق بطريقة تكون مرئية لـ PyInstaller، سيتم تعبئة الملحق مع البرنامج. نظرًا لأن ملحقات 'Aspose.Slides for Python عبر .NET' تأتي مع توصيلات PyInstaller، سيتم العثور على اعتمادياتها الخاصة ونسخها في الحزمة.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

```
$ pyinstaller slide_app.py
```

ومع ذلك، في بعض الأحيان لا يستطيع PyInstaller اكتشاف بعض الاستيرادات المخفية، وهي الوحدات التي يتم استيرادها ديناميكيًا أو بشكل غير مباشر بواسطة الكود الخاص بك. للتعامل مع استيراد مخفي في PyInstaller، استخدم خيارات PyInstaller. يتم تحديد اعتماديات الملحق في توصيلات PyInstaller التي تأتي مع ملحق 'Aspose.Slides for Python عبر .NET'.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```
$ pyinstaller slide_app.spec
```

### cx_Freeze ###
لتجميد برنامج باستخدام cx_Freeze، استخدم خياراته لتجميد الحزمة الجذرية للملحق 'Aspose.Slides for Python عبر .NET' الذي تستخدمه. سيتأكد هذا من أن الملحق والوحدات التي يعتمد عليها قد تم نسخها مع البرنامج.

#### استخدام سكريبت cxfreeze ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### باستخدام سكريبت Setup ####
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


```
$ python setup.py build_exe
```