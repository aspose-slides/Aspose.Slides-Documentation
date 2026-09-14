---
title: تضمين الخطوط في العروض التقديمية في بايثون عبر جافا
linktitle: الخطوط المضمّنة
type: docs
weight: 40
url: /ar/python-java/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخطوط
- الحصول على خط مضمّن
- إضافة خط مضمّن
- إزالة خط مضمّن
- ضغط خط مضمّن
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة الخطوط المضمّنة في باوربوينت باستخدام Aspose.Slides للغة بايثون عبر جافا. إضافة، استرجاع، إزالة، وضغط الخطوط للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **المقدمة**

يخزن تضمين الخطوط بيانات الخط داخل عرض تقديمي لبرنامج PowerPoint. عندما يدعم المشاهد الخطوط المضمنة، يمكنه عرض النص باستخدام هذه الخطوط حتى لو لم تكن مثبتة على النظام الهدف. يساعد ذلك في الحفاظ على فواصل الأسطر وتباعد النص وتنسيق الشريحة.

تتيح لك Aspose.Slides للغة Python عبر Java استرجاع الخطوط المضمنة وإضافتها وإزالتها عبر فئة [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) التي تُرجَع بواسطة [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getFontsManager). يمكنك أيضًا تقليل حجم بيانات الخط المضمن بإزالة الأحرف التي لا يستخدمها العرض التقديمي.

الأمثلة أدناه تعمل مع ملفات PPTX. قبل تضمين خط، تأكد من أن بيانات الخط متاحة لـ Aspose.Slides وأن ترخيصه يسمح بالتضمين.

## **الحصول على الخطوط المضمنة وإزالتها**

استخدم [getEmbeddedFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) لسرد الخطوط المخزنة في عرض تقديمي. لإزالة أحدها، مرّر خطًا من تلك القائمة إلى [removeEmbeddedFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont)، ثم احفظ العرض التقديمي.

المثال التالي يسرد الخطوط المضمنة في ملف `EmbeddedFonts.pptx` ويزيل خط Calibri إذا كان موجودًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

إزالة خط مضمّن تحذف بيانات الخط المخزنة؛ لا تغير الخط المعين للنص. إذا كان الخط مثبتًا على النظام الهدف، يمكن للنص الاستمرار في استخدامه. وإلا قد يتطلب العرض استبدال الخط، مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وأذونات التضمين**

استخدم فئة [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ [FontsManager.getFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getFonts) لاسترجاع الخطوط المستخدمة في العرض التقديمي. لكل خط، مرّر كائنًا من نوع [FontData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontdata/) والقيمة المطلوبة من نوع [FontStyleType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontstyletype/) إلى [FontsManager.getFontBytes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getFontBytes). تُرجِع الطريقة البيانات الثنائية لهذا النمط من الخط، أو `None` عندما يكون الخط أو النمط المطلوب غير متاح. لا تُمرّر نتيجة `None` إلى [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)، لأن هذه الطريقة تتطلّب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/embeddinglevel/) هو تعداد علمي يُظهر قيود التضمين المخزنة في الخط:

- `Installable` يسمح بالتضمين والتثبيت الدائم على نظام آخر، وفقًا لترخيص الخط.
- `Restricted` يمنع التضمين إلّا إذا تم الحصول على إذن من مالك الخط القانوني عندما يكون هذا العلم هو علم إذن الاستخدام الوحيد.
- `PreviewPrint` يسمح بالاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي على الخط للقراءة فقط.
- `Editable` يسمح بالاستخدام المؤقت ويسمح بتحرير المستند وحفظه.
- `NoSubsetting` هو قيد إضافي يمنع تضمين جزء فقط من الرموز. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BitmapOnly` هو قيد إضافي يسمح فقط بتضمين ملفات bitmap، وليس بيانات الخط الخارطي. إذا لم يكن للخط ملفات bitmap، لا يمكن تضمينه.

القيم الأربعة الأولى تصف إذن الاستخدام، بينما يمكن دمج `NoSubsetting` و `BitmapOnly` معها. تحقق من المُعدِّلات باستخدام عمليات البت. لأن `Installable` يساوي الصفر، قم بتمثيل بتات إذن الاستخدام وقارن النتيجة بـ `Installable` بدلاً من فحصه كعلم. يجب أن تعيّن الخطوط الحالية علمًا واحدًا على الأكثر لإذن الاستخدام. للتوافق مع الخطوط القديمة التي تعيّن أكثر من علم، يختار المساعد أدناه أقل قيود ممكنة: `Editable`، ثم `PreviewPrint`، ثم `Restricted`.

المثال التالي يراجع بيانات الخط العادي، العريض، المائل، والعريض المائل المتوفرة لكل خط تُرجِعه `getFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط التي هي bitmap‑only، الخطوط المحدودة للعرض والطباعة لأن الناتج يظل قابلًا للتحرير، والخطوط التي تم تضمينها بالفعل. إذا كان أي نمط متوفر يحتوي على `NoSubsetting`، يتم تضمين جميع الأحرف لتلك العائلة الخطية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هذا الفحص يُظهر القيود المشفّرة في كل ملف خط. لا يمنحك ترخيصًا، ولا يثبت أنك حصلت على الخط بصورة قانونية، ولا يحل محل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مضمَّنة.

## **إضافة خطوط مضمَّنة**

استخدم [addEmbeddedFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) لتضمين خط. تُقبل التحميلات الزائدة إما ككائن [FontData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontdata/) أو كمصفوفة بايت تحتوي على بيانات الخط. يتحكم تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/embedfontcharacters/) في الأحرف التي تُضمَّن:

- [All](https://reference.aspose.com/slides/ar/python-java/aspose.slides/embedfontcharacters/) يُضمِّن جميع الأحرف الموجودة في الخط. استخدم هذا الخيار عندما يحتاج المتلقون إلى تحرير العرض التقديمي وإدخال نص جديد.
- [OnlyUsed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/embedfontcharacters/) يُضمِّن الأحرف المستخدمة فقط في العرض لتقليل حجم الملف. اختر هذا الخيار لعرض نهائي يُقصد به غالبًا أن يُعرض فقط.

المثال التالي يستخدم [getFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getFonts) لاسترجاع الخطوط المستخدمة في ملف `Fonts.pptx` ويُضمّن تلك التي لم تُضمَّن بعد. يجب أن تكون الخطوط المراد إضافتها متوفرة على الجهاز الذي يُنفّذ الشيفرة. الخطوط المضمَّنة موجودة تحتفظ بمجموعة الأحرف الحالية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضغط الخطوط المضمَّنة**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#compressEmbeddedFonts) يقلل من بيانات الخط المضمَّن بإزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها بالفعل، لذا يعتمد الحد من الحجم على كمية بيانات الخط غير المستخدمة التي يحتويها العرض التقديمي.

المثال التالي يضغط الخطوط في ملف `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

احتفظ بالملف الأصلي إذا كان المتلقون قد يحتاجون لإضافة نص لاحقًا. الأحرف التي أُزيلت أثناء الضغط لن تكون متاحة من الخط المضمَّن، حتى لو كنت قد ضمنت جميع الأحرف في البداية.

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كان الخط المضمّن سيظل يُستبدل أثناء العرض؟**

استدعِ [getSubstitutions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getSubstitutions) في البيئة التي تُعرض فيها العرض التقديمي لتعرف الخطوط التي سيستبدلها Aspose.Slides. تحقق أيضًا من إعدادات استبدال الخطوط وقواعد التراجع عن الخط. التراجع يتعامل مع الأحرف المفقودة، لذا لا يحل تضمين الخط مشكلة الأحرف التي لا يحتويها الخط نفسه. 

**هل يجب عليّ تضمين الخطوط الشائعة مثل Arial وCalibri؟**

اعتمد القرار على بيئة الهدف. إذا كانت الخطوط المطلوبة متوفرة على كل جهاز يفتح أو يعرض العرض التقديمي، قد يؤدي تضمينها إلى زيادة غير ضرورية في حجم الملف. إذا كان من المحتمل أن يكون المتلقون أو الخوادم يفتقرون إلى تلك الخطوط، قد يساعد تضمينها في الحفاظ على المظهر المقصود، شريطة أن تسمح تراخيصها بذلك.