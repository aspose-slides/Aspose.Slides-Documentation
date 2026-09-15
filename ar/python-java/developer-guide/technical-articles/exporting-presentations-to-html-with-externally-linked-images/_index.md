---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 100
url: /ar/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تصدير الشريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- صورة مرتبطة
- صورة مرتبطة خارجيًا
- مورد مرتبط
- مورد خارجي
- Python
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML في Python باستخدام Aspose.Slides مع حفظ الصور والموارد الأخرى كملفات مرتبطة خارجيًا."
---
## **نظرة عامة**

بشكل افتراضي، تقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML مستقل. يتم كتابة الصور والموارد الأخرى مباشرةً داخل ملف HTML، عادةً كبيانات Base64. هذا ملائم عندما تحتاج إلى ملف واحد محمول، لكنه ليس دائمًا الصيغة المثالية لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل من جانب الخادم.

استخدم الموارد المرتبطة خارجيًا عندما تريد:

- تقليل حجم مستند HTML؛
- تخزين الصور أو الخطوط أو الصوت أو الفيديو مؤقتًا في المتصفح أو شبكة توصيل المحتوى (CDN) بشكل منفصل؛
- فحص، استبدال، ضغط أو معالجة الموارد المُولدة بعد التصدير؛
- الحفاظ على بنية الإخراج أقرب إلى ما يتوقعه تطبيق الويب.

للمسار العام لتحويل HTML، راجع [تحويل عروض PowerPoint إلى HTML](/slides/ar/python-java/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد في عملية التصدير.

## **كيفية عمل تصدير الموارد المربوطة**

`ILinkEmbedController` يسمح لتطبيقك بتحديد، موردًا بمورد، ما إذا كان المصدّر سيضمّن البيانات داخل HTML أو سيحفظها خارجيًا ويكتب رابطًا.

تحتوي الواجهة على ثلاث طرق:

- `ILinkEmbedController.getObjectStoringLocation` يقرر ما إذا كان يجب ربط المورد أو تضمينه.
- `ILinkEmbedController.getUrl` تُعيد عنوان URL الذي سيُكتب إلى HTML المُولَّد أو إلى مورد مرتبط آخر.
- `ILinkEmbedController.saveExternal` يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL للمتصفح هما اعتباران منفصلان. على سبيل المثال، يكتب المثال أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل هذه العناوين نسبةً إلى الملف الذي يحتوي على الرابط. لذلك، يُستخدم الرابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، بينما يستخدم الرابط من ملف SVG هذا إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع موارد مرتبطة**

المثال التالي بلغة Python ينشئ دليل إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في مجلد فرعي `assets`. يقوم المتحكم بربط الصور والخطوط والصوت والفيديو وموارد CSS الشائعة عندما تقدم Aspose.Slides هذه الموارد أو يمكنها استنتاج امتداد ملف آمن. تُبقى الموارد غير المعروفة مضمَّنة.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

بعد التصدير، يكون هيكل مجلد الإخراج كالتالي:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

تختلف الملفات الدقيقة اعتمادًا على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، تُصدر الصور النقطية عادةً كملفات JPEG أو PNG. قد تختار Aspose.Slides ترميز صورة مختلف عن ذلك المستخدم في العرض الأصلي إذا كان ذلك ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدر الصور ذات الشفافية كملفات PNG.

## **اختيار عناوين URL للنشر**

يستخدم المثال بادئة عنوان URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، سيقوم المتصفح بتحميل `html-output/assets/resource-1.svg`.

عند إشارة مورد مرتبط إلى مورد مرتبط آخر، يستخدم المثال معامل `referrer` في `ILinkEmbedController.getUrl` ويعيد اسم الملف فقط. على سبيل المثال، إذا كان كل من `resource-1.svg` و`resource-4.jpg` موجودين في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg` وليس إلى `assets/resource-4.jpg`.

استخدم بادئة عنوان URL مختلفة عندما تُنشر الملفات في مكان آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوى واحد فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُرفع الملفات إلى CDN أو خادم ملفات ثابت.

يجب أن يتطابق عنوان URL الذي تُعيده `ILinkEmbedController.getUrl` مع الموقع النهائي للنشر للملف الذي يكتبه `ILinkEmbedController.saveExternal`. في تطبيقات الخادم، استخدم دليل إخراج فريد أو بادئة تخزين كائن لكل مهمة تحويل لتجنب الكتابة فوق ملفات تصدير أخرى.

## **متى يجب تضمين الموارد بدلاً من ربطها**

يبقى HTML المضمّن بصيغة Base64 مفيدًا عندما يجب أن يكون الإخراج ملفًا واحدًا، مثل مرفق بريد إلكتروني أو معاينة دون اتصال أو مستند سيتم نقله دون مجلد أصول داعم. تكون الموارد المرتبطة خيارًا أفضل عندما يتم تقديم HTML عبر تطبيق ويب، أو تخزينه في نظام إدارة محتوى، أو تحسينه عبر خط بناء، أو تخزينه مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **الأسئلة الشائعة**

**هل يمكنني إقلاع الصور فقط مع إبقاء الموارد الأخرى مضمَّنة؟**

نعم. في `ILinkEmbedController.getObjectStoringLocation`، أعد `[LinkEmbedDecision.Link](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linkembeddecision/#Link)` فقط لأنواع المحتوى التي تريد حفظها كملفات منفصلة، وأعد `[LinkEmbedDecision.Embed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linkembeddecision/#Embed)` لكل ما تبقى.

**لماذا يختلف امتداد الصورة المصدَّرة عن العرض التقديمي الأصلي؟**

قد تقوم Aspose.Slides بإعادة تشفير الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف الأصلي كملف JPEG أو PNG اعتمادًا على النتيجة المُرَسمة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما يتم الحفاظ على هيكل المجلدات النسبي نفسه. إذا أشار HTML إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجوار ملف HTML ما لم تُنشئ بادئة عنوان URL مختلفة.

**هل يجب على تطبيقات الخادم إعادة استخدام نفس دليل الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل مهمة تحويل. هذا يتجنب تصادم أسماء الملفات ويمنع كتابة مورد واحد فوق موارد تم توليدها من تصدير آخر.