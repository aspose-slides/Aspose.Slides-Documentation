---
title: تحويل PPT إلى PPTX في Python
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في Python باستخدام Aspose.Slides. يتضمن أمثلة للتحويل الفردي والدفعي، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن Aspose.Slides for Python عبر .NET تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو مجموعة ملفات ويشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) مع الوسيط [SaveFormat.PPTX](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/). يعرّض تعبير `with` العرض التقديمي ويطلق الموارد الخاصة به عند انتهاء الكتلة.

```python
import aspose.slides as slides

# تحميل عرض PPT القديم.
with slides.Presentation("presentation.ppt") as presentation:
    # حفظ العرض بصيغة PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

امتداد الملف لا يحدد تنسيق الإخراج بنفسه؛ إنما الوسيط [SaveFormat.PPTX](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) هو الذي يحدده. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت تحتاج إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف *.ppt* في دليل واحد. يتم معالجة كل ملف على حدة، لذا فإن فشل تحويل ملف واحد لا يوقف بقية الدفعة.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

لأعباء العمل الإنتاجية، سجّل الاستثناء الكامل، وقرر ما إذا كان يمكن الكتابة فوق ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى طابور إعادة المحاولة أو المراجعة. يمكن أن تتسبب الملفات التالفة، والملفات المحمية بكلمة مرور والتي تُفتح بدون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعها في فشل التحويل. راجع [Password-Protected Presentations](/python-net/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، القوالب الرئيسية، التخطيطات، النصوص، الأشكال، الصور، الجداول، والرسوم البيانية. ومع ذلك، لا تمثّل PPT و PPTX كل ميزة بنفس الطريقة. قد يتم تطبيع ميزة قديمة لا يوجد لها مكافئ في PPTX، أو لا تدعمها المكتبة، أو تُحذف، أو تُعرض بشكل مختلف.

تحقق من الملف المحوَّل عندما يحتوي على رسومات متحركة، انتقالات، كائنات OLE مضمّنة أو مترابطة، عناصر تحكم ActiveX، وسائط مضمّنة، خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يلزم بقاء VBA متاحًا. كذلك تحقق من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض التقديمي المحوَّل.

للمستندات الهامة، أعد فتح ملف PPTX المُولد برمجيًا وتفحص عدد الشرائح ومحتواها الرئيس، ثم قارن مظهره وسلوك عرض الشرائح في المشاهد المستهدف. لا تُعامل استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) الناجح كدليل على أن كل ميزة قديمة لها تمثيل دقيق في PPTX.

## **متى يتم استخدام PPTX**

استخدم PPTX عندما يُنوي تحرير العرض التقديمي في إصدارات PowerPoint الحالية، أو مشاركته مع الأنظمة التي تعمل مع حزم Open XML، أو تخزينه بتنسيق يسهل فحصه واستعادته مقارنةً بـ PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو نسخة للعودة إليها حتى يجتاز العرض التقديمي المحوَّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، اتبع الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) بدلاً من افتراض أن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **المحول عبر الإنترنت**

لملف عرض تقديمي عرضي أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدفعية أو التعامل مع الأخطاء على مستوى التطبيق، استخدم واجهة برمجة تطبيقات Python.

## **مقالات ذات صلة**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/python-net/save-presentation/)
- [Supported File Formats](/python-net/supported-file-formats/)
- [Open Presentations in Python](/python-net/open-presentation/)

## **FAQ**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. يستطيع Aspose.Slides for Python عبر .NET تحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على جميع المحتويات بدقة تامة؟**

يحافظ على محتوى العرض التقديمي الشائع، لكن لا يمكن ضمان الدقة الكاملة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُولد عندما يحتوي على ماكرو، أو كائنات OLE أو ActiveX، أو وسائط، أو رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا زودت كلمة المرور الصحيحة عند تحميل الملف. يؤدي عدم توفير كلمة مرور أو توفير كلمة غير صحيحة إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالملف الأصلي حتى تتأكد من صحة PPTX في المشاهد وسير العمل الذي يهمك. هذا يضمن وجود نسخة للعودة إليها إذا تم تحويل ميزة قديمة بطريقة مختلفة.