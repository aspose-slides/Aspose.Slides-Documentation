---
title: تحويل PPT إلى PPTX في بايثون
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/python-java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في بايثون باستخدام Aspose.Slides. يتضمن أمثلة بايثون للتحويل الفردي وتحويل الدُفعات، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides لبايثون عبر جافا تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. تُظهر هذه المقالة كيفية تحويل ملف واحد أو دليل يحتوي على ملفات وتشرح ما يجب التحقق منه بعد التحويل.

كل مثال يبدأ آلة جافا الافتراضية إذا لزم الأمر ويُطلق العرض التقديمي بعد الاستخدام. استبدل مسارات الأمثلة بمسارات ملفاتك أو أدلّتك الخاصة.

## **تحويل ملف PPT إلى PPTX**

قم بتحميل الملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Pptx). يقوم كتلة `finally` بتحرير العرض التقديمي وإطلاق موارده.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# تحميل عرض PPT القديم.
presentation = Presentation("presentation.ppt")
try:
    # حفظ العرض التقديمي بصيغة PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

امتداد الملف لا يحدِّد تنسيق الإخراج بحد ذاته؛ إنَّ معامل [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Pptx) هو الذي يحدده. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل عدة ملفات PPT**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يُعالَج كل ملف بصورة مستقلة، لذا فإن فشل تحويل واحد لا يوقف باقي الدفعة.

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

في بيئات الإنتاج، سجِّل الاستثناء الكامل، وقرر ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات التي فشل تحويلها إلى طابور إعادة المحاولة أو المراجعة. يمكن أن تسبب الملفات التالفة، والملفات المحمية بكلمة مرور والتي تُفتح بدون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعًا فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/python-java/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، والنماذج الرئيسة، وتخطيطات الشرائح، والنصوص، والأشكال، والصور، والجداول، والرسوم البيانية. ومع ذلك، لا تمثِّل PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تطبيع أو حذف أو عرض مختلف لميزة قديمة لا تمتلك ما مكافئ لها في PPTX أو غير مدعومة من قبل المكتبة.

تحقق من الملف المُحوَّل عندما يحتوي على تحريكات، أو انتقالات، أو كائنات OLE مدمجة أو مرتبطة، أو عناصر تحكم ActiveX، أو وسائط مدمجة، أو خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن يظل VBA متاحًا. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض التقديمي المُحوَّل.

بالنسبة للمستندات الهامة، أعد فتح ملف PPTX الذي تم إنشاؤه برمجيًا وتفقد عدد الشرائح الرئيسة والمحتوى، ثم قارن مظهره وسلوك عرض الشرائح في المشاهد المستهدف. لا تعتبر استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) الناجح دليلًا على أن كل ميزة قديمة لديها تمثيل دقيق في PPTX.

## **متى يجب استخدام PPTX**

استخدم PPTX عندما يتم تحرير العرض التقديمي في إصدارات PowerPoint الحالية، أو تبادلها مع الأنظمة التي تتعامل مع حزم Open XML، أو تخزينها بتنسيق أسهل للفحص والاستعادة مقارنةً بتنسيق PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو للعودة إليها حتى يجتاز العرض التقديمي المُحوَّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/slides/ar/python-java/convert-presentation/) بدلًا من الافتراض بأن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **المحولة عبر الإنترنت**

لملف عرضى أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة، المعالجة الدفعية، أو معالجة الأخطاء على مستوى التطبيق، استخدم واجهة برمجة تطبيقات Python عبر Java.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/slides/ar/python-java/ppt-vs-pptx/)
- [حفظ العروض التقديمية في Python](/slides/ar/python-java/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/python-java/supported-file-formats/)
- [فتح العروض التقديمية في Python](/slides/ar/python-java/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX بدون تثبيت Microsoft PowerPoint؟**

نعم. يقوم Aspose.Slides لبايثون عبر جافا بتحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على جميع المحتويات بدقة كاملة؟**

إنه يحافظ على محتوى العرض التقديمي الشائع، لكن الدقة الكاملة غير مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُنتج عندما يحتوي على ماكرو، أو كائنات OLE أو ActiveX، أو وسائط، أو تحريكات متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قمت بتوفير كلمة المرور الصحيحة عند تحميل الملف. يؤدي عدم وجود كلمة مرور أو كلمة مرور غير صحيحة إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالملف الأصلي حتى تتأكد من صحة PPTX في المشاهدين وسير العمل الذي يهمك. هذا يوفر نسخة للعودة إليها إذا تم تحويل ميزة قديمة بطريقة مختلفة.