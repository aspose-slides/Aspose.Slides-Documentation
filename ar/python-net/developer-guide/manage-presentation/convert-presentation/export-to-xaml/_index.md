---
title: تصدير العروض التقديمية إلى XAML باستخدام Python
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/python-net/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- Python
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML باستخدام Python و Aspose.Slides — حل سريع بدون Office يحافظ على تنسيقك الأصلي."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides. تتضمن مقدمة موجزة عن XAML، وتظهر كيفية حفظ عرض تقديمي إلى XAML بالإعدادات الافتراضية، وتوضح كيفية تخصيص التصدير من خلال [XamlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. كما تجيب المقالة على بعض الأسئلة الشائعة المتعلقة بخطوط الاستبدال، وتوافق XAML مع مختلف الأنماط، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هو لغة توصيف مبنية على XML تُستخدم لوصف واجهات المستخدم في أطر العمل مثل WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم بصري أو كتابة وتحرير العلامات مباشرة.

## **تصدير العروض إلى XAML بالإعدادات الافتراضية**

يوضح المثال التالي بلغة Python كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

بشكل افتراضي، تُحفظ الشرائح المصدرة في مجلد فرعي يُسمى `pres` داخل دليل العمل الحالي للعملية، كما تُعيده الدالة [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). يتم إنشاء المجلد تلقائيًا، ويتم حفظ أي صور مطلوبة هناك أيضًا.

يُؤخذ اسم مجلد الإخراج من اسم ملف المصدر بدون الامتداد. بالنسبة للملف `pres.pptx`، تُسمى ملفات الإخراج `pres/Slide_1.xaml`، `pres/Slide_2.xaml`، وهكذا. حتى إذا مررت مسارًا مطلقًا للعرض التقديمي المدخل، يُنشأ مجلد الإخراج نسبةً إلى دليل العمل الحالي، وليس بجانب ملف الإدخال.

## **تصدير العروض إلى XAML بإعدادات مخصصة**

استخدم الفئة [XamlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/) للتحكم في طريقة تصدير Aspose.Slides للعرض التقديمي إلى XAML.

لتضمين الشرائح المخفية في ناتج XAML، اضبط الخاصية [export_hidden_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) على القيمة `True`، كما هو موضح في المثال التالي بلغة Python:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **التقاط جميع القطع الفنية التي تم إنشاؤها بتنسيق XAML**

يمكن لتصدير XAML أن ينتج مستند XAML لكل شريحة تم تصديرها بالإضافة إلى صور وموارد داعمة منفصلة. احتفظ بجميع هذه الملفات عند تخزين أو نقل التصدير.

تستخدم الأمثلة أدناه الحافظ الافتراضي للملفات في دليل مؤقت، ثم تجمع الملفات التي تم إنشاؤها.

### **فهم دورة حياة التصدير**

- ابدأ التصدير باستخدام الدالة الخاصة بـ XAML [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) التي تقبل خيارات XAML. اقرأ الملفات التي تم إنشاؤها فقط بعد أن تُعيد الدالة بنجاح.
- احفظ المسار النسبي لكل قطعة فنية لأن XAML قد يشير إلى الموارد باستخدام مسارات نسبية.
- اقرأ القطع الفنية كـ bytes. يجب عدم فك ترميز الصور والموارد الثنائية الأخرى كنص.
- أبلغ عن النجاح العام فقط بعد اكتمال الجمع وأي عملية تخزين تالية. دع أخطاء التخزين تصل إلى المستدعي، واحذف المخرجات الجزئية إذا فشل التخزين.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) يكون افتراضيًا `False`، مما يستبعد مستندات XAML للشرائح المخفية. ضبطه على `True` يضمّنها وأي موارد مطلوبة لتصديرها. تعتمد عدد الموارد على العرض التقديمي؛ لا تفترض وجود ملف واحد لكل شريحة.

{{% alert color="warning" title="Warning" %}}
الأمثلة تقوم مؤقتًا بتغيير دليل العمل الحالي للعملية، مما يؤثر على جميع الخيوط. شغّل كل عملية تصدير في عملية عامل مخصصة، أو تأكد من أن أي عمل آخر في العملية لا يعتمد على دليل العمل الحالي أثناء التصدير. مجرد وجود دليل مؤقت فريد لا يجعل عمليات التصدير المتزامنة في نفس العملية آمنة.
{{% /alert %}}

### **تصدير إلى الذاكرة وفحص القطع الفنية**

هذا المثال الكامل يحمل `pres.pptx`، يصدره إلى دليل مؤقت، يجمع كل قطعة فنية في قاموس بأسماء نسبية وbytes، ويطبع اسمها، نوعها، وعدد الـ bytes. يحافظ على بنية الدليل التي تم إنشاؤها ويزيل الملفات المؤقتة بعد الجمع. يتم حل مسار الإدخال قبل تغيير دليل العمل.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # فك ترميز XAML فقط، وفقط عندما يكون الفحص النصي مطلوبًا.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

تُعتبر فحوصات الامتداد مفيدة للفحص؛ احتفظ بجميع القطع الفنية، بما في ذلك أنواع الموارد غير المألوفة. اترك الـ bytes دون تعديل عند التخزين أو النقل. فك ترميز XAML فقط عندما يتطلب معالجة نصية. يستخدم هذا النهج مساحة قرص مؤقتة بالإضافة إلى الذاكرة للقطع الفنية المجمعة.

### **حزم القطع الفنية المجمعة في ملف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من أسمائه، ويكتب الـ bytes الأصلية في أرشيف ZIP. يميّز اسم الأرشيف الفريد وظائف التصدير. تستخدم إدخالات ZIP شرطات مائلة للأمام وتحتفظ بالدلائل النسبية. تُرفض الأسماء غير الآمنة أو التي تتصادم بعد التطبيع قبل كتابة الحزمة.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # تم الانتهاء من دليل ZIP قبل الإبلاغ عن النجاح.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

يستخدم المثال [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) لكتابة أرشيف محلي واحد بعد جمع التصدير المؤقت. للتخزين عن بُعد، استبدل مرحلة كتابة الأرشيف بعمليات رفع للـ bytes المجمعة. استخدم معرف مهمة التصدير مع الاسم النسبي الكامل للقطعة الفنية كمفتاح كائن، أو خزن معرف المهمة والاسم النسبي والبيانات الثنائية في صف قاعدة بيانات. انشر المهمة فقط بعد اكتمال جميع عمليات الرفع أو تأكيد معاملة قاعدة البيانات. احذف المخرجات الجزئية إذا فشل التخزين.

بالنسبة للعروض التقديمية الكبيرة، عالج الملفات المؤقتة واحدة تلو الأخرى بعد التصدير بدلاً من جمع جميع الـ bytes في القاموس. هذا يتجنب نسخة إضافية في الذاكرة لكامل التصدير، لكنه لا يلغي متطلبات الذاكرة للمنتج نفسه.

### **حفظ أسماء الموارد والتحقق من المراجع**

- طوّع فواصل المسار عندما يتطلب الوجهة ذلك، ولكن احتفظ بالدلائل النسبية. لا تحتفظ بالاسم النهائي للملف فقط إلا إذا كان كل اسم مُولد معروفًا بأنه فريد وأن مراجع الموارد تظل صالحة.
- طبّق تحققًا من صحة الاسم وفقًا للوجهة. عند كتابة ملفات منفصلة، ارفض المسارات المطلقة وقطاعات الاستعراض، حل الوجهة، وتحقق من أنها تبقى تحت دليل التصدير المقصود. استخدم دليلًا يتحكم فيه التطبيق دون روابط رمزية قد تعيد توجيه الكتابات.
- استخدم مساحة تخزين منفصلة لكل مهمة تصدير. اكتشف التصادمات بعد تطبيع الفواصل ووفقًا لقواعد حساسية الحالة في الوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وافحص مراجع الموارد القائمة على الملفات، مثل سمة `Source` أو `ImageSource` للصور. حل كل URI نسبيًا بالنسبة إلى دليل قطعة XAML الحاوية، طوّع الاسم الناتج للتخزين، وتأكد من وجود المفتاح المقابل في القاموس أو إدخال ZIP أو الكائن المخزن. عالج URIs الخارجية وتعبيرات علامات XAML بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `pres/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `pres/images/image1.png`. الاحتفاظ بـ `image1.png` فقط سيكسر هذه العلاقة. بالنسبة لتخزين الكائنات، احفظ نفس الهيكلية تحت بادئة المهمة واجعل عناوين URL للموارد متاحة لمستهلك XAML. أعد فتح ملف ZIP المكتمل للتحقق من أسماء الإدخالات وbytes الموارد، وحمّل شرائح تمثيلية في بيئة XAML الهدف لتأكيد أن الصور تُحلّ بشكل صحيح.

## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط ثابتة إذا كانت الخطوط الأصلية غير متوفرة على الجهاز؟**

اضبط الخاصية [default_regular_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) في [XamlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/) — تُستخدم كخط احتياطي أثناء التصدير عندما يكون الخط الأصلي مفقودًا. هذا لا يضمن أن XAML المولد سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من أن الخطوط المشار إليها في XAML متوفرة في البيئة التي يُعرض فيها.

**هل XAML المصدّر مخصص فقط لـ WPF أم يمكن استخدامه في أنماط XAML أخرى؟**

تصدر Aspose.Slides XAML لـ WPF من خلال واجهة برمجة التطبيقات العامة لها. لا يُضمن التوافق مع أنماط XAML الأخرى، مثل UWP وXamarin.Forms. اختبر العلامات المولدة في بيئتك الهدف.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

افتراضياً، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر الخاصية [export_hidden_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) في [XamlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export.xaml/xamloptions/) — أبقها معطلة إذا لم تكن بحاجة لتصديرها.