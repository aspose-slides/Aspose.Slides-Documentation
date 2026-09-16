---
title: تصدير العروض التقديمية إلى XAML في Python عبر Java
linktitle: العرض إلى XAML
type: docs
weight: 30
url: /ar/python-java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- عرض تقديمي إلى XAML
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
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى XAML باستخدام Aspose.Slides لPython عبر Java. استخدم الخيارات الافتراضية أو قم بتضمين الشرائح المخفية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides for Python via Java. تتضمن مقدمة مختصرة عن XAML، وتظهر كيفية حفظ عرض تقديمي إلى XAML بالإعدادات الافتراضية، وتوضح كيفية تخصيص التصدير عبر [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. تجيب المقالة أيضًا على بعض الأسئلة الشائعة المتعلقة بخطوط الاستFallback، وتوافق مجموعة XAML، وسلوك تصدير الشرائح المخفية.

تتطلب الأمثلة Aspose.Slides for Python via Java وبيئة تشغيل Java متوافقة. ضع الملف `pres.pptx` في دليل العمل الحالي. يبدأ كل مثال تشغيل JVM فقط إذا لم يكن قيد التشغيل بالفعل.

## **حول XAML**

XAML هي لغة توصيف مبنية على XML تُستخدم لوصف واجهات المستخدم في أطر مثل WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم بصري أو كتابة وتحرير العلامات مباشرةً.

## **تصدير العروض إلى XAML بالإعدادات الافتراضية**

يوضح المثال التالي بلغة Python كيفية تصدير عرض تقديمي إلى XAML بالإعدادات الافتراضية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

بشكل افتراضي، تُحفظ الشرائح المصدرة في مجلد فرعي `pres` داخل دليل العمل الحالي للعملية. يُنشأ المجلد تلقائيًا، وتُحفظ أي صور مطلوبة هناك أيضًا.

يُؤخذ اسم مجلد الإخراج من اسم ملف المصدر دون الامتداد. بالنسبة للملف `pres.pptx`، تُسمى ملفات الإخراج `pres/Slide_1.xaml` و`pres/Slide_2.xaml` وهكذا. حتى إذا مررت مسارًا مطلقًا للعرض التقديمي المدخل، فإن مجلد الإخراج يُنشأ نسبةً إلى دليل العمل الحالي، وليس بجوار ملف الإدخال.

## **تصدير العروض إلى XAML بخيارات مخصصة**

استخدم الفئة [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/) للتحكم في طريقة تصدير Aspose.Slides لعرض تقديمي إلى XAML.

لحفظ الناتج في موقع مخصص، نفذ `IXamlOutputSaver` ومرر مثالًا من تنفيذك إلى طريقة [setOutputSaver](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/#setOutputSaver) في [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/).

لإدراج الشرائح المخفية في ناتج XAML، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) مع القيمة `True`، كما هو موضح في المثال التالي بلغة Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **التقاط جميع القطع الفنية المولدة من XAML**

يمكن لتصدير XAML أن ينتج مستند XAML لكل شريحة مصدرة بالإضافة إلى صور وموارد داعمة منفصلة. عيّن `IXamlOutputSaver` مخصصًا إلى [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/#setOutputSaver) لتلقي هذه القطع بدلاً من استخدام الحفظ الافتراضي على نظام الملفات. ابدأ التصدير باستخدام التحميل الزائد الخاص بـ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) الذي يقبل خيارات XAML.

في Python، استخدم `jpype.JProxy` لتنفيذ واجهة Java `IXamlOutputSaver`. حوّل مسار الاستدعاء إلى `str` وانسخ مصفوفة البايتات من Java إلى Python `bytes` قبل الإرجاع، كما هو موضح أدناه.

### **فهم دورة حياة الاستدعاء**

يستدعي المصدّر `IXamlOutputSaver.save` بشكل منفصل لكل قطعة فنية مُولدة:

- `path` يحدد القطعة وقد يتضمن أدلة نسبية. احتفظ بهذه المعلومات لأن XAML قد يشير إلى موارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات القطعة. يجب عدم فك ترميز الصور والموارد الثنائية الأخرى كالنص.
- المسؤولية عن الاحتفاظ أو حفظ البيانات قبل الإرجاع تقع على عاتق الحافظ. تنسخ الأمثلة كل مصفوفة بايتات إلى ذاكرة مملوكة للتطبيق.
- اعتبر عملية التصدير ناجحة فقط عندما تعود عملية حفظ العرض التقديمي وتكون جميع الاستدعاءات قد أكملت بنجاح. لا تتجاهل أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا حدثت عملية الحفظ لاحقًا، أبلغ عن النجاح الكلي فقط بعد أن تنجح تلك الخطوة أيضًا.

يتطبق [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) أيضًا على حافظ مخصص. الإعداد الافتراضي `False` يستثني مستندات XAML للشرائح المخفية. تمرير القيمة `True` يضمن تضمينها وأي موارد مطلوبة لتصديرها. عدد الموارد يعتمد على العرض التقديمي؛ لا تفترض وجود استدعاء واحد لكل شريحة أو ترتيب ثابت للاستدعاءات.

### **التصدير إلى الذاكرة وفحص القطع الفنية**

هذا المثال الكامل يحمل `pres.pptx`، يجمع كل قطعة في قاموس Python من الأسماء وقيم `bytes` غير القابلة للتغيير، ويطبع اسمها ونوعها وعدد البايتات. يحافظ على الأسماء المقدمة تمامًا. تُعلم الأسماء المكررة المجموعة بأنها غير صالحة بدلاً من الكتابة فوق القطعة صمتًا. يتحقق المثال من ذلك قبل استخدام النتائج.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # فك ترميز XAML فقط، وفقط عندما يكون فحص النص مطلوبًا.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

تُعد فحوصات الامتداد مفيدة للتفتيش؛ احتفظ بجميع القطع، بما في ذلك أنواع الموارد غير المألوفة. لا تغير البايتات عند التخزين أو النقل. استخدم `bytes.decode` مع UTF-8 فقط لـ XAML الذي يحتاج معالجة نصية.

### **حزم القطع الفنية المجمعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من صحة أسمائه، ويكتب البايتات الأصلية في أرشيف ZIP. يضمن اسم الأرشيف الفريد فصل وظائف التصدير المتزامنة. تستخدم مداخل ZIP شرطات مائلة للأمام وتحتفظ بالأدلة النسبية. تُرفض الأسماء غير الآمنة أو المتصادمة بعد التطبيع قبل كتابة الحزمة بالكامل.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # الإغلاق ينهى دليل ZIP قبل الإبلاغ عن النجاح.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

يستخدم المثال `zipfile.ZipFile` في Python لكتابة أرشيف محلي واحد؛ ليس للمصدّر كتابة ملفات XAML أو الصور منفردة. للتخزين عن بُعد، استبدل مرحلة كتابة الأرشيف بتحميل المصفوفات المجمعة. استخدم معرف وظيفة التصدير مع الاسم النسبي الكامل للقطعة كمفتاح Blob، أو خزن معرف الوظيفة والاسم النسبي والبيانات الثنائية في صف قاعدة بيانات. انشر الوظيفة فقط بعد إكمال جميع التحميلات أو التزام معاملات قاعدة البيانات. نظّف المخرجات الجزئية إذا فشل الحفظ.

للعروض التقديمية الكبيرة، يمكن لحافظ مخصص حفظ كل قطعة مباشرةً في تخزين التطبيق لتفادي الاحتفاظ بنسخة إضافية من التصدير بالكامل في ذاكرة التطبيق. حافظ على تزامن كل استدعاء من منظور المصدّر: أرجع فقط بعد قبول الوجهة للبايتات، واترك الأخطاء تصل إلى المستدعي.

### **الحفاظ على أسماء الموارد والتحقق من الإشارات**

- طوّع فواصل المسارات عند الحاجة في الوجهة، ولكن احتفظ بالأدلة النسبية. لا تستخدم `pathlib.Path.name` فقط إلا إذا علمت أن كل اسم مُولد فريد وأن إشارات الموارد ستظل صالحة.
- طبق تحققًا من صحة الاسم وفقًا للوجهة. عند كتابة ملفات منفردة، رفض المسارات الجذرية وشرائح العبور، حلّ الوجهة باستخدام `pathlib.Path.resolve` وتأكد من بقاءها تحت دليل التصدير المقصود، مع تضمين فاصل الدليل في فحص الحاوية. استخدم دليلًا يتحكم به التطبيق دون روابط رمزية قد تعيد توجيه الكتابات.
- استخدم حافظًا ومساحة أسماء تخزين منفصلة لكل وظيفة تصدير. اكتشف التصادمات بعد تطبيع الفواصل ووفقًا لقواعد حساسية حالة الوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وتفقد إشاراته للموارد القائمة على الملفات، مثل سمة `Source` أو `ImageSource` للصور. حل كل URI نسبي مقابل دليل القطعة XAML الحاوية، طوّع اسم التخزين الناتج، وتأكد من وجود المفتاح المقابل في الخريطة أو مدخل ZIP أو الكائن المخزن. عالج URIs الخارجية وتعبيرات XAML markup بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `pres/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `pres/images/image1.png`. الاحتفاظ بـ `image1.png` فقط سيكسر هذا الرابط. في تخزين الكائنات، حافظ على نفس البنية تحت بادئة الوظيفة واجعل عناوين URL لهذه الموارد قابلة للوصول للمستهلك XAML. أعد فتح ZIP المكتمل للتحقق من أسماء المداخل وبايتات الموارد، وحمّل شرائح تمثيلية في بيئة XAML المستهدفة لتأكيد أن الصور تُحل بشكل صحيح.

## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يكن الخط الأصلي متوفرًا على الجهاز؟**

استدعِ [setDefaultRegularFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/) — يُستخدم كخط بديل أثناء التصدير عندما يكون الأصلي مفقودًا. لا يضمن ذلك أن XAML المُنشأ سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من توفر الخطوط المشار إليها في XAML في البيئة التي يُعرض فيها.

**هل يُقصد من XAML المُصدَّر أن يكون مخصصًا فقط لـ WPF، أم يمكن استخدامه في مجموعات XAML أخرى أيضًا؟**

تصدّر Aspose.Slides XAML الخاص بـ WPF عبر واجهتها العامة. لا يُضمن التوافق مع مجموعات XAML الأخرى مثل UWP وXamarin.Forms. اختبر العلامات المُولّدة في البيئة المستهدفة.

**هل تُدعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُضمن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) في [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/) — أبقِها غير مفعلة إذا لم تحتاج لتصديرها.