---
title: تضمين الخطوط في العروض التقديمية باستخدام Python
linktitle: الخطوط المُضمَّنة
type: docs
weight: 40
url: /ar/python-net/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخطوط
- الحصول على الخط المُضمَّن
- إضافة خط مُضمَّن
- إزالة الخط المُضمَّن
- ضغط الخط المُضمَّن
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة الخطوط المُضمَّنة في PowerPoint باستخدام Aspose.Slides للغة Python عبر .NET. استخدم Python لإضافة الخطوط واسترجاعها وإزالتها وضغطها لضمان الحفاظ على مظهر النص وتقليل حجم الملف."
---
## **المقدمة**

يُخزّن تضمين الخطوط بيانات الخط داخل عرض PowerPoint. عندما يدعم عارض الخطوط المُضمَّنة، يمكنه عرض النص باستخدام تلك الخطوط حتى إذا لم يتم تثبيتها على النظام المستهدف. يساعد ذلك في الحفاظ على فواصل الأسطر وتباعد النص وتنسيق الشريحة.

تتيح لك Aspose.Slides للغة Python عبر .NET استرجاع الخطوط المُضمَّنة وإضافتها وإزالتها من خلال خاصية [fonts_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/fonts_manager/) لكائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). يمكنك أيضًا تقليل حجم بيانات الخط المُضمَّن عن طريق إزالة الأحرف التي لا يستخدمها العرض.

تعمل الأمثلة أدناه مع ملفات PPTX. قبل تضمين الخط، تأكد من أن بيانات الخط متاحة لـ Aspose.Slides وأن ترخيصه يسمح بالتضمين.

## **الحصول على الخطوط المُضمَّنة وإزالتها**

استخدم [get_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) لسرد الخطوط المخزنة في عرض تقديمي. لإزالة أحدها، مرِّر خطًا من تلك القائمة إلى [remove_embedded_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/remove_embedded_font/)، ثم احفظ العرض.

المثال التالي يسرد الخطوط المُضمَّنة في `EmbeddedFonts.pptx` ويزيل خط Calibri إذا كان موجودًا:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

إزالة خط مُضمَّن يحذف بيانات الخط المخزنة؛ ولا يغيّر الخط المعين للنص. إذا كان الخط مثبتًا على النظام المستهدف، ما زال بإمكان النص استخدامه. وإلا قد يتطلب العرض [استبدال الخط](/slides/ar/python-net/font-substitution/)، وهو ما قد يؤثر على التخطيط.

## **فحص بيانات الخط وإذن التضمين**

استخدم الفئة [FontsManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ [get_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_fonts/) لاسترجاع الخطوط المستخدمة في العرض. لكل خط، مرِّر كائن [FontData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontdata/) والقيمة المطلوبة من [FontStyleType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontstyletype/) إلى [get_font_bytes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_font_bytes/). تُعيد الطريقة البيانات الثنائية لذلك نمط الخط، أو `None` عندما يكون الخط أو النمط المطلوب غير متوفر. لا تمرّر نتيجة `None` إلى [get_font_embedding_level](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_font_embedding_level/)، لأن هذه الطريقة تتطلب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/ar/python-net/aspose.slides/embeddinglevel/) هو تعداد علمي يُبلغ عن قيود التضمين المخزنة في الخط:

- `INSTALLABLE` يسمح بالتضمين والتثبيت الدائم على نظام آخر، وفقًا لترخيص الخط.
- `RESTRICTED` يمنع التضمين ما لم يُحصل على إذن من مالك الخط القانوني عندما يكون هذا العلم هو علم الإذن الوحيد.
- `PREVIEW_PRINT` يسمح بالاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي على الخط للقراءة فقط.
- `EDITABLE` يسمح بالاستخدام المؤقت ويتيح تحرير المستند وحفظه.
- `NO_SUBSETTING` هو قيد إضافي يمنع تضمين جزء فقط من الحروف. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BITMAP_ONLY` هو قيد إضافي يسمح بتضمين ضربات البت ماب فقط، وليس بيانات المخطط. إذا لم يحتوي الخط على ضربات بت ماب، لا يمكن تضمينه.

القيم الأربعة الأولى تصف أذونات الاستخدام، بينما يمكن دمج `NO_SUBSETTING` و `BITMAP_ONLY` معها. تحقق من المعدلات باستخدام عمليات البت. لأن قيمة `INSTALLABLE` هي صفر، قم بقناع بتات أذونات الاستخدام ومقارنة النتيجة بـ `INSTALLABLE`. يجب أن تُعيّن الخطوط الحالية بتة أذونات استخدام واحدة على الأكثر. لضمان التوافق مع الخطوط القديمة التي تُعيّن أكثر من واحدة، يختار المساعد أدناه أقل إذن تقييدًا: `EDITABLE`، ثم `PREVIEW_PRINT`، ثم `RESTRICTED`.

المثال التالي يدقق البيانات العادية، العريضة، المائلة، والعريضة المائلة المتوفرة لكل خط يتم إرجاعه بواسطة `get_fonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط بت ماب فقط، الخطوط المحدودة للعرض والطباعة لأن الناتج يظل قابلاً للتحرير، والخطوط التي تم تضمينها بالفعل. إذا كان لأي نمط متوفر `NO_SUBSETTING`، يتم تضمين جميع الأحرف لتلك العائلة الخطية.
```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

هذا الفحص يبلّغ عن القيود المشفرة في كل ملف خط. لا يمنحك ترخيصًا، ولا يثبت أنك حصلت على الخط بصورة قانونية، ولا يحل محل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مُضمَّنة.

## **إضافة الخطوط المُضمَّنة**

استخدم [add_embedded_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/add_embedded_font/) لتضمين خط. تُقبل إصداراتها إما كائنًا من نوع [FontData](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontdata/) أو مصفوفة بايت تحتوي على بيانات الخط. يتحكم تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/embedfontcharacters/) في الأحرف التي يتم تضمينها:

- `[ALL](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/embedfontcharacters/)` يضمّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المستلمون إلى تحرير العرض وإدخال نص جديد.
- `[ONLY_USED](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/embedfontcharacters/)` يضمّن فقط الأحرف المستخدمة في العرض لتقليل حجم الملف. اختر هذا الخيار لعرض نهائي يُقصد منه أساسًا العرض.

المثال التالي يستخدم [get_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_fonts/) لاسترجاع الخطوط المستخدمة في `Fonts.pptx` ويضمّن تلك التي لم تُضمّن بعد. يجب أن تكون الخطوط المراد إضافتها متاحة على الجهاز الذي يُنفّذ الشيفرة. تحتفظ الخطوط المُضمَّنة الحالية بمجموعة الأحرف الخاصة بها.
```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **ضغط الخطوط المُضمَّنة**

[compress_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) يقلل من بيانات الخط المُضمّن عن طريق إزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها مسبقًا، لذا يعتمد تقليل الحجم على مقدار بيانات الخط غير المستخدمة الموجودة في العرض.

المثال التالي يضغط الخطوط في `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

احتفظ بالملف الأصلي إذا كان المستلمون قد يحتاجون إلى إضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لن تكون متاحة بعد ذلك من الخط المُضمّن، حتى إذا كنت قد ضمنت جميع الأحرف في البداية.

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كان الخط المُضمّن سيظل يتم استبداله أثناء العرض؟**

استدعي [get_substitutions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_substitutions/) في البيئة التي تقوم فيها بعرض العرض لتعرف أي الخطوط سيستبدلها Aspose.Slides. كما تحقق من إعدادات [استبدال الخط](/slides/ar/python-net/font-substitution/) وقواعد [الخط الاحتياطي](/slides/ar/python-net/fallback-font/). يتعامل الخط الاحتياطي مع الأحرف المفقودة، لذا فإن تضمين خط لا يحل مشكلة الأحرف التي لا يحتويها الخط نفسه.

**هل ينبغي عليّ تضمين الخطوط الشائعة مثل Arial و Calibri؟**

اعتمد القرار على البيئة المستهدفة. إذا كانت الخطوط المطلوبة متاحة على كل جهاز يفتح أو يعرض العرض، قد يؤدي تضمينها إلى زيادة حجم الملف دون ضرورة. إذا كان من المحتمل أن يفتقر المستلمون أو الخوادم إلى تلك الخطوط، يمكن لتضمينها أن يساعد في الحفاظ على المظهر المقصود، بشرط أن تسمح تراخيصها بذلك.