---
title: تحويل PPT إلى PPTX في Python
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/python-java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في Python باستخدام Aspose.Slides. يتضمن أمثلة Python للتحويل الفردي والدفعي، ومعالجة الأخطاء، وملاحظات بشأن الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for Python via Java تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو دليل من الملفات ويشرح ما يجب التحقق منه بعد التحويل.

كل مثال يبدأ تشغيل آلة Java الافتراضية إذا لزم الأمر ويحرر العرض بعد الاستخدام. استبدل مسارات الأمثلة بمسارات ملفاتك أو أدلتك الخاصة.

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Pptx). يقوم كتلة `finally` بتحرير العرض وإطلاق موارده.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# تحميل عرض PPT القديم.
presentation = Presentation("presentation.ppt")
try:
    # حفظ العرض التقديمي بتنسيق PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ملحق الملف لا يحدد تنسيق الإخراج بحد ذاته؛ إنّ معامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Pptx) هو الذي يحدده. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف بشكل مستقل، لذا فإن فشل التحويل لملف واحد لا يوقف باقي الدفعة.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

في بيئات الإنتاج، سجّل الاستثناء بالكامل، وقرّر ما إذا كان يمكن الكتابة فوق ملف الإخراج الموجود، واكتب أسماء الملفات التي فشل تحويلها إلى طابور لإعادة المحاولة أو المراجعة. يمكن أن تتسبب الملفات التالفة، والملفات المحمية بكلمة مرور تم فتحها دون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم في فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/python-java/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما تحافظ عملية التحويل على الشرائح، والقوالب الرئيسية، والتخطيطات، والنص، والأشكال، والصور، والجداول، والرسوم البيانية. ومع ذلك، لا يمثل كل من PPT و PPTX كل ميزة بنفس الطريقة بالضبط. قد يتم تطبيع أو حذف أو عرض ميزة قديمة لا توجد لها مكافئة في PPTX أو لا يدعمها المكتبة بشكل مختلف.

تحقّق من الملف المحوَّل عندما يحتوي على حركات، أو انتقالات، أو كائنات OLE مدمجة أو مرتبطة، أو عناصر تحكم ActiveX، أو وسائط مدمجة، أو خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل مناسب يدعم الماكرو عندما يجب أن يبقى VBA متاحًا. كما تأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض المحوَّل.

بالنسبة للوثائق الهامة، أعد فتح ملف PPTX المُنشأ برمجيًا وتفحص عدد الشرائح الرئيسة ومحتواها، ثم قارن مظهره وسلوك عرض الشرائح في المشاهد المقصود. لا تُعامل استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) الناجح كدليل على أن كل ميزة قديمة لها تمثيل دقيق في PPTX.

## **متى تستخدم PPTX**

استخدم PPTX عندما يتم تحرير العرض في إصدارات PowerPoint الحالية، أو يتم تبادله مع أنظمة تعمل بحزم Open XML، أو يُخزن بتنسيق يسهل فحصه واستعادته مقارنة بملف PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو للعودة إليها حتى يجتاز العرض المحوَّل فحوصات الدقة الخاصة بك.

إذا كنت بحاجة إلى PDF أو HTML أو صور أو XPS أو أي نوع آخر من المخرجات، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/slides/ar/python-java/convert-presentation/) بدلاً من الافتراض أن جميع الأهداف تحتفظ بميزات PowerPoint القابلة للتحرير.

## **المحول عبر الإنترنت**

لملف عشوائي أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدُفعية أو معالجة الأخطاء على مستوى التطبيق، استخدم واجهة برمجة تطبيقات Python عبر Java.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/slides/ar/python-java/ppt-vs-pptx/)
- [حفظ العروض التقديمية في Python](/slides/ar/python-java/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/python-java/supported-file-formats/)
- [فتح العروض التقديمية في Python](/slides/ar/python-java/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. يقوم Aspose.Slides for Python via Java بتحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ تحويل PPT إلى PPTX على جميع المحتويات بدقة؟**

يحافظ على محتوى العرض الشائع، ولكن لا يُضمن الدقة الكاملة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُنتج عندما يحتوي على ماكرو، أو كائنات OLE أو ActiveX، أو وسائط، أو رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قمت بتوفير كلمة المرور الصحيحة عند تحميل الملف. تؤدي كلمة مرور مفقودة أو غير صحيحة إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالأصل حتى تقوم بالتحقق من ملف PPTX في المشاهد وسير العمل التي تهمك. هذا يوفر نسخة يمكن الرجوع إليها إذا تم تحويل ميزة قديمة بشكل مختلف.