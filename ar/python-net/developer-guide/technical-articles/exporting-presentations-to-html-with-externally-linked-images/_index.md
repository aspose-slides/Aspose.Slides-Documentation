---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا في Python
linktitle: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 100
url: /ar/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تصدير شريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- عرض تقديمي إلى HTML
- شريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- صورة مرتبطة
- صورة مرتبطة خارجيًا
- مورد مرتبط
- مورد خارجي
- Python
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML باستخدام Aspose.Slides في Python مع حفظ الصور كملفات مرتبطة خارجية."
---
## **نظرة عامة**

افتراضيًا، تقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML مستقل. تُكتب الصور والموارد الأخرى مباشرةً داخل HTML، عادةً كبيانات Base64. هذا مفيد عندما تحتاج إلى ملف واحد محمول، لكنه ليس دائمًا الأنسب لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل على الجانب الخادمي.

- تقليل حجم مستند HTML؛
- تخزين الصور مؤقتًا بشكل منفصل في المتصفح أو شبكة CDN؛
- فحص، استبدال، ضغط، أو معالجة الصور المُنشأة بعد التصدير؛
- الحفاظ على بنية الإخراج أقرب إلى ما تتوقعه تطبيقات الويب.

للحصول على سير عمل عام لتحويل HTML، راجع [تحويل عروض PowerPoint إلى HTML](/slides/ar/python-net/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الصور في عملية التصدير.

## **كيفية عمل تصدير الصور المرتبطة**

في .NET و Java، تمثل [ILinkEmbedController](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/ilinkembedcontroller/) واجهة رد النداء التي يستخدمها المصدِّر لتحديد ما إذا كان يجب تضمين المورد أو ربطه. في Python عبر .NET، لا يمكن حاليًا للفئات في Python تنفيذ هذه الواجهة مباشرة، لذا فإن سير العمل العملي هو:

1. تصدير العرض التقديمي إلى HTML باستخدام [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/).
2. استخدم [SlideImageFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/slideimageformat/) مع [SVGOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/) بحيث يتم تمثيل الشرائح كـ SVG في HTML.
3. نقل بيانات الصور بصيغة Base64 من عناوين URL `data:` في HTML إلى ملفات منفصلة.
4. استبدال عناوين URL `data:` الأصلية بروابط نسبية مثل `assets/resource-1.jpg`.

مسار نظام الملفات وعنوان URL المتصفح موضوعان منفصلان. على سبيل المثال، يكتب العينة أدناه ملفات الصور إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.jpg`. يقوم المتصفح بحل تلك العناوين نسبةً إلى ملف HTML الذي يحتوي على الرابط.

## **تصدير HTML مع صور مرتبطة**

المثال التالي بلغة Python ينشئ دليلًا للإخراج، يحفظ ملف HTML هناك، يخزن الصور المستخرجة في دليل فرعي `assets`، ويعيد كتابة عناوين URL للصور بصيغة Base64 إلى روابط نسبية. يستخرج المثال صيغ الصور الشائعة بصيغة Base64 عندما توفر Aspose.Slides امتداد ملف آمن. تظل عناوين URL للبيانات غير المعروفة مضمَّنة.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

بعد عملية التصدير، قد يحتوي مجلد الإخراج على هذه البنية:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

تعتمد الملفات الفعلية على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، تُصدر الصور النقطية عادةً كـ JPEG أو PNG. قد تختار Aspose.Slides برنامج الترميز للصور مختلفًا عن الموجود في العرض الأصلي إذا كان ذلك ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدر الصور ذات الشفافية كـ PNG.

## **اختيار عناوين URL للنشر**

تستخدم العينة بادئة URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، يقوم المتصفح بتحميل `html-output/assets/resource-1.jpg`.

استخدم اسم دليل أصول مختلف أو أعد كتابة الروابط المُولدة عندما تُنشر الملفات في مكان آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجانب ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوىً واحدًا فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُحمَّل الملفات إلى شبكة CDN أو خادم ملفات ثابت.

في تطبيقات الخادم، استخدم دليل إخراج فريد أو بادئة تخزين كائن لكل مهمة تحويل لتجنب استبدال الملفات من عملية تصدير أخرى.

## **متى يجب التضمين بدلاً من ذلك**

يظل HTML المشفر بـ Base64 المضمن مفيدًا عندما يجب أن يكون الإخراج ملفًا واحدًا، مثل مرفق بريد إلكتروني، معاينة غير متصلة، أو مستند سينتقل دون مجلد أصول داعم. الصور المرتبطة هي الأنسب عندما يُقدَّم HTML عبر تطبيق ويب، يُخزن في نظام إدارة محتوى، يتم تحسينه عبر خط أنابيب بناء، أو يتم تخزينه مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **الأسئلة المتكررة**

**هل يمكنني استخراج الصور فقط وإبقاء الموارد الأخرى مضمَّنة؟**

نعم. العينة تستخرج فقط عناوين URL للبيانات `image/*` بصيغة Base64 التي تكون أنواع المحتوى الخاصة بها مدرجة في `EXTENSIONS_BY_CONTENT_TYPE`. تظل عناوين URL للبيانات الأخرى مضمَّنة.

**لماذا يختلف امتداد الصورة المُصدَّرة عن العرض التقديمي الأصلي؟**

قد تقوم Aspose.Slides بإعادة ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف الأصلي كـ JPEG أو PNG اعتمادًا على نتيجة العرض.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما يتم الحفاظ على نفس بنية المجلدات النسبية. إذا كان HTML يشير إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجانب ملف HTML ما لم تقم بإنشاء بادئة URL مختلفة.

**هل يجب على تطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل مهمة تحويل. هذا يجنب تصادم أسماء الملفات ويمنع عملية تصدير واحدة من استبدال الموارد التي تم إنشاؤها بواسطة عملية تصدير أخرى.