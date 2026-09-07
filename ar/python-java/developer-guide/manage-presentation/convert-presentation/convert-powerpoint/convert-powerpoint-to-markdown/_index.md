---
title: تحويل عروض PowerPoint إلى Markdown في Python عبر Java
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/python-java/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- العرض التقديمي إلى MD
- الشريحة إلى MD
- PPT إلى MD
- PPTX إلى MD
- حفظ PowerPoint كـ Markdown
- حفظ العرض التقديمي كـ Markdown
- حفظ الشريحة كـ Markdown
- حفظ PPT كـ MD
- حفظ PPTX كـ MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- تصدير صور Markdown
- روابط صور CDN
- PowerPoint
- العرض التقديمي
- Markdown
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى Markdown في Python عبر Java والتحكم بمكان حفظ الصور المُصدَّرة بنوع bitmap و metafile و SVG وكيفية الإشارة إليها."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يمكنه تحويل عروض PPT و PPTX إلى Markdown للتوثيق، المواقع الساكنة، ترحيل المحتوى، وسير عمل التحكم في الإصدارات. يمكنك اختيار نوع Markdown، التحكم في طريقة عرض محتوى الشرائح، وتحديد مكان حفظ الصور المصدّرَة وكيفية إشارة Markdown المُولدة إليها.

بشكل افتراضي، تصدير Markdown يستخدم إخراج نصي فقط. لتصدير المحتوى المرئي، عيّن نوع التصدير باستخدام طريقة [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setExportType) إلى القيمة `Sequential` أو `Visual` من تعداد [MarkdownExportType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownexporttype/). `Sequential` يُظهر عناصر الشريحة بشكل منفصل وبالترتيب، بينما `Visual` يجمع العناصر المرتبطة معًا للحفاظ على العلاقة البصرية بينها. القيمة `TextOnly` لا تُصدر موارد الصور، لذلك لا يتم استدعاء ردود حفظ الصورة في هذا الوضع.

## **تحويل عرض تقديمي إلى Markdown**

حمّل الملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، ثم استدعِ طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع القيمة `Md` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

كل مثال يقرأ `presentation.pptx` من دليل العمل الحالي. ثبّت Aspose.Slides for Python via Java وبيئة تشغيل Java متوافقة قبل تشغيل الأمثلة. ابدأ JVM مرة واحدة لكل عملية Python.

## **اختيار نوع Markdown**

طريقة [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setFlavor) تتحكم في مواصفة Markdown المستخدمة في الإخراج. تعداد [Flavor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/flavor/) يضم CommonMark، GitHub Flavored Markdown، وغيرها من الأنواع المدعومة.

المثال التالي يصدر عرضًا تقديميًا كـ CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **تصدير الصور باستخدام السلوك الافتراضي لحفظ محلي**

الفئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/) توفر طريقتين لتكوين حفظ الصور محليًا:

- [setBasePath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setBasePath) يحدد الدليل الأساسي لمستند Markdown وموارده.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) يحدد المجلد الفرعي للصور. القيمة الافتراضية هي `Images`.

المثال التالي يُظهر المحتوى المرئي، يكتب الصور إلى `output/assets`، ويُنشئ مراجع صورة نسبية في مستند Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

هذا السلوك يُعد أيضًا بديلًا عندما تُعيد معالِج حفظ الصورة المخصَّص `False`.

## **تخصيص حفظ الصور وروابط Markdown**

استخدم طريقة [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/) لتسجيل رد نداء للموارد غير SVG من نوع bitmap وmetafile التي تُصدّر أثناء تصدير Markdown. رد النداء `MarkdownImageSavingHandler` يتلقى كائن الصورة، قيمتها من نوع [ImageFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/)، والرابط Markdown المُولَّد كمصفوفة `String[]` ذات عنصر واحد. احفظ أو حمِّل الصورة بالتنسيق المزوَّد، واستبدل `link[0]` بالمرجع الذي يجب أن يظهر في مخرجات Markdown.

الموارد المُصدَّرة بصيغة SVG تُعامل منفصلًا. سجِّل رد نداء باستخدام طريقة [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/). رد النداء `MarkdownSvgImageSavingHandler` يتلقى كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) ومصفوفة `String[] link` ذات عنصر واحد. لا يحتوي SVG على وسيط `ImageFormat`؛ اكتب أو حمِّل بيانات XML الخاصة به من طريقة [SvgImage.getSvgData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/#getSvgData) بدلًا من ذلك. بناءً على وضع التصدير وتجميع العناصر البصرية، قد يتم تحويل SVG في العرض المصدر إلى raster أو دمجه مع محتوى آخر؛ ثم يُمرَّر المورد غير SVG إلى رد نداء حفظ الصورة. سجِّل كلا ردِّي النداء عندما يتطلب كل مورد بصري مُصدَّر معالجة مخصَّصة.

قيمة إرجاع المعالِج تحدد من سيعالج الصورة:

- أرجِع `True` بعد أن يكون المعالِج قد حفظ، أو رفع، أو حوَّل، أو عالج الصورة بأي طريقة وعين قيمة صالحة إلى `link[0]`. Aspose.Slides يكتب هذه القيمة إلى مستند Markdown ولا يقوم بالحفظ المحلي الافتراضي.
- أرجِع `False` للسماح لـ Aspose.Slides بحفظ الصورة محليًا وإنشاء الرابط وفق القيم المحددة عبر [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setBasePath) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}

المعالج الذي يُرجِع `True` يتحمل مسؤولية الصورة. إذا أَرجَع `True` دون تعيين رابط صالح غير فارغ، سيفشل التصدير مع `InvalidOperationException`.

{{% /alert %}}

في Python، سجِّل هذه الردود باستخدام `jpype.JProxy`، مع تنفيذ واجهة رد النداء Java عبر طريقة `invoke`. معامل `link` هو مصفوفة سلاسل Java قابلة للتعديل: حوِّل `link[0]` إلى سلسلة Python قبل معالجتها، ثم عيّن عنوان URL البديل مرة أخرى إلى `link[0]`.

### **حفظ الصور إلى دليل أصل CDN واستخدام عناوين URL خارجية**

المثال التالي يعامل `cdn-origin/presentations/quarterly-report` كدليل أصل CDN مُركَّب أو متزامن. كل معالج يستخرج اسم الملف المُولَّد، يحفظ الصورة إلى ذلك الدليل المخصَّص، ويستبدل الإشارة المحلية المُولَّدة بعنوان URL عام على CDN. لا يُجري العيّنة تحميلًا عبر الشبكة فعليًا: يصبح URL صالحًا فقط بعد أن يُركَّب الدليل كأصل CDN أو تُنشر ملفاته إلى CDN. للتخزين ككائن، استبدل كتابة نظام الملفات بعملية رفع SDK التخزينية وعين `link[0]` فقط بعد نجاح الرفع.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

معالج البت ماب يُعيد `False` عمدًا للصور أصغر من 128 × 128 بكسل، وبالتالي تحفظ Aspose.Slides تلك الصور إلى `output/fallback-images` باستخدام السلوك الافتراضي. تُعالج الموارد البت ماب الأكبر وموارد الميتا فايل، وكذلك موارد SVG، بواسطة الشيفرة المخصَّصة. على سبيل المثال، يصبح المرجع المحلي المُولَّد مثل `fallback-images/image1.png` إلى `https://cdn.example.com/presentations/quarterly-report/image1.png`. يستخدم المعالجون مسارات نظام التشغيل فقط عند كتابة الملفات؛ الروابط المكتوبة في Markdown تستخدم شرطات مائلة للأمام وأسماء ملفات مُهربة وفق URL. طبّق القاعدة نفسها عند بناء روابط نسبية: استخدم `/`، ولا تستخدم فاصل الدليل الخاص بالنظام.

## **الأسئلة المتكررة**

**هل يمكن لمُعالِج واحد معالجة كل من الصور النقطية وSVG؟**

لا. استخدم [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/) للموارد bitmap وmetafile المُصدَّرة و[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/) للموارد المُصدَّرة كـ SVG. الأول يزودك بكائن صورة وقيمة [ImageFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/)، والثاني يزودك بكائن [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) يمكن قراءة بيانات SVG الخاصة به عبر [SvgImage.getSvgData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/#getSvgData). يُعالج SVG المصدر الذي يتم تحويله إلى raster أثناء التصدير بواسطة رد نداء حفظ الصورة بدلاً من ذلك.

**ماذا يحدث عندما يُرجِع معالِج حفظ الصورة `False`؟**

يستخدم Aspose.Slides سلوكه الافتراضي لحفظ الصور محليًا. يتم التحكم في موقع الصورة والمرجع المُولَّد عبر القيم المحددة بـ [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setBasePath) و[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**هل يمكن للمعالج تقديم URL دون حفظ الصورة محليًا؟**

نعم. يمكن للمعالج رفع الصورة إلى تخزين كائن أو تمريرها إلى خدمة أخرى، تعيين URL الناتج إلى `link[0]`، وإرجاع `True`. يجب أن يُكمل المعالج المعالجة بنفسه؛ إرجاع `True` يمنع الحفظ المحلي الافتراضي.

**لماذا يرفع تصدير Markdown استثناء `InvalidOperationException` من المعالج؟**

يحدث هذا الاستثناء عندما يُرجِع المعالج `True` لكنه لا يُقدِّم رابطًا صالحًا. عيّن المسار النسبي أو URL الخارجي الذي يجب كتابته إلى Markdown قبل إرجاع `True`.

**أي فاصل مسار يجب أن تستخدمه روابط الصور؟**

استخدم الشرطات المائلة للأمام في روابط Markdown وعناوين URL. استخدم `pathlib.Path` فقط لمسارات نظام الملفات، ثم كوّن أو عيّن مرجع Markdown بشكل منفصل.

**هل تُحافظ الروابط التشعبية أثناء تصدير Markdown؟**

نعم. تُحافظ الروابط النصية [hyperlinks](/slides/ar/python-java/manage-hyperlinks/) كروابط Markdown قياسية. لا يتم تحويل انتقالات الشرائح [transitions](/slides/ar/python-java/slide-transition/) ولا الرسوم المتحركة [animations](/slides/ar/python-java/powerpoint-animation/).

**هل يمكن تحويل العروض التقديمية إلى Markdown بشكل متوازي؟**

يمكنك معالجة ملفات عروض تقديمية مختلفة بالتوازي، لكن لا تشارك نفس كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) بين الخيوط. اتبع إرشادات [multithreading](/slides/ar/python-java/multithreading/) واستخدم كائنًا منفصلاً لكل ملف.