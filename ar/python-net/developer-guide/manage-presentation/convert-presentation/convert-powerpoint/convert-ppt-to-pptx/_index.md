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
description: "تحويل ملفات PPT القديمة إلى PPTX في Python باستخدام Aspose.Slides. يتضمن أمثلة على التحويل لملف واحد وتحويل دفعي، معالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for Python via .NET تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو مجموعة ملفات ويشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) مع [SaveFormat.PPTX](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/). يُعيد بيان `with` تحرير العرض ويطلق موارده عند انتهاء الكتلة.

```python
import aspose.slides as slides

# تحميل عرض PPT القديم.
with slides.Presentation("presentation.ppt") as presentation:
    # حفظ العرض بصيغة PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

امتداد الملف لا يحدد تنسيق الإخراج بذاته؛ إنّ وسيط [SaveFormat.PPTX](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) هو الذي يفعل ذلك. حافظ على اختلاف مسارات الإدخال والإخراج إذا كنت بحاجة للاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يُعالج كل ملف بشكل مستقل، لذا فإن فشل تحويل واحد لا يوقف بقية الدفعة.

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

في بيئات الإنتاج، سجّل الاستثناء الكامل، وحدد ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة انتظار للمراجعة أو إعادة المحاولة. الملفات الفاسدة، والملفات المحمية بكلمة مرور والتي تُفتح بدون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم يمكن أن يتسبب جميعًا في فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/python-net/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، القوالب الرئيسة، التخطيطات، النصوص، الأشكال، الصور، الجداول، والرسوم البيانية. ومع ذلك، لا تمثّل كل من PPT و PPTX كل ميزة بنفس الطريقة بالضبط. قد يتم تعديل أو إهمال أو عرض بشكل مختلف ميزة قديمة لا تمتلك ما يكافئها في PPTX أو لا تدعمها المكتبة.

تحقق من الملف المحوّل عندما يحتوي على رسومات متحركة، انتقالات، كائنات OLE مضمّنة أو مرتبطة، عناصر تحكم ActiveX، وسائط مضمّنة، خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن يظل VBA متاحًا. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض المُحوَّل.

بالنسبة للمستندات الهامة، أعد فتح ملف PPTX المُنشأ برمجيًا وتفقد عدد الشرائح والمحتوى الرئيسي، ثم قارنه بالمظهر وسلوك عرض الشرائح في المشاهد المستهدف. لا تعتبر استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) الناجح دليلًا على أن كل ميزة قديمة لديها تمثيل دقيق في PPTX.

## **متى يجب استخدام PPTX**

استخدم PPTX عندما يُعدل العرض في إصدارات PowerPoint الحالية، أو يتم تبادله مع أنظمة تتعامل مع حزم Open XML، أو يُخزن بتنسيق يسهل فحصه واستعادته مقارنةً بملف PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو للرجوع إليها حتى يجتاز العرض المُحوَّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/slides/ar/python-net/convert-presentation/) بدلًا من الافتراض بأن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **المحول عبر الإنترنت**

لملف عرضية أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدفعة أو التعامل مع الأخطاء على مستوى التطبيق، استخدم واجهة برمجة تطبيقات Python.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/slides/ar/python-net/ppt-vs-pptx/)
- [حفظ العروض التقديمية في Python](/slides/ar/python-net/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/python-net/supported-file-formats/)
- [فتح العروض التقديمية في Python](/slides/ar/python-net/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. Aspose.Slides for Python via .NET يقوم بتحميل وحفظ ملفات العرض دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على جميع المحتويات بدقة؟**

يحافظ على محتوى العرض الشائع، لكن الدقة الكاملة غير مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُنتج عندما يحتوي على ماكرو، كائنات OLE أو ActiveX، وسائط، رسومات متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قمت بتوفير كلمة المرور الصحيحة عند تحميل الملف. عدم توفير كلمة مرور أو تقديم كلمة مرور غير صحيحة يتسبب في فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالملف الأصلي حتى تتأكد من صحة PPTX في المشاهد وسير العمل التي تهمك. هذا يوفر نسخة رجوع إذا تم تحويل ميزة قديمة بطريقة مختلفة.