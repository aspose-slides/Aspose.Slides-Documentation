---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 50
url: /ar/cpp/exporting-presentations-to-html-with-externally-linked-images/
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
- C++
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument التقديمية إلى HTML باستخدام C++ و Aspose.Slides مع حفظ الصور وغيرها من الموارد كملفات مرتبطة خارجياً."
---
## **نظرة عامة**

بشكلٍ افتراضي، تقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML مستقل. تُكتب الصور والموارد الأخرى مباشرةً داخل ملف HTML، عادةً كبيانات Base64. هذا مفيد عندما تحتاج إلى ملف واحد محمول، لكنه ليس دائمًا الأنسب لموقع ويب أو نظام إدارة محتوى أو مسار تحويل على الخادم.

استخدم الموارد المرتبطة خارجيًا عندما تريد:

- تقليل حجم مستند HTML؛
- تخزين الصور أو الخطوط أو الصوت أو الفيديو في المتصفح أو شبكة توصيل المحتوى (CDN) بشكل منفصل؛
- فحص الموارد المستخرجة أو استبدالها أو ضغطها أو معالجتها بعد التصدير؛
- جعل بنية المخرجات أقرب إلى ما يتوقعه تطبيق الويب.

للتعرف على سير عمل تحويل HTML العام، راجع [Convert PowerPoint Presentations to HTML](/slides/ar/cpp/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد في عملية التصدير.

## **كيفية عمل تصدير الموارد المرتبطة**

[ILinkEmbedController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/) يتيح لتطبيقك اتخاذ القرار، موردًا بمورد، ما إذا كان المُصدِّر سيضمّن البيانات داخل HTML أو سيحفظها خارجيًا ويكتب رابطًا.

الواجهة تحتوي على ثلاث طرق:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) يحدد ما إذا كان يجب ربط المورد أو تضمينه.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) يُعيد عنوان URL الذي سيُكتب في HTML الناتج أو في مورد مرتبط آخر.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL في المتصفح هما شأنان منفصلان. على سبيل المثال، يكتب المثال أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل تلك العناوين نسبةً إلى الملف الذي يحتوي على الرابط. لذلك، يستخدم الرابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، بينما يستخدم الرابط من ملف SVG إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع موارد مرتبطة**

المثال التالي بلغة C++ ينشئ مجلد إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في مجلد فرعي اسمه `assets`. يقوم المتحكم بربط الصور المشتركة، الخطوط، الصوت، الفيديو، وموارد CSS عندما تُزوِّد Aspose.Slides بامتداد ملف آمن أو يمكن استنتاجه. تُبقى الموارد غير المعروفة مضمّنة.

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

بعد التصدير، يكون هيكل المجلد الناتج كالتالي:

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

الملفات الدقيقة تعتمد على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، تُصدر الصور النقطية عادةً بصيغة JPEG أو PNG. قد تختار Aspose.Slides ترميز صورة مختلف عن الموجود في العرض الأصلي إذا كان ذلك ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدر الصور ذات الشفافية بصيغة PNG.

## **اختيار عناوين URL للنشر**

يستخدم المثال بادئة URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، سيحمّل المتصفح `html-output/assets/resource-1.svg`.

عند إشارة مورد مرتبط إلى مورد مرتبط آخر، يستخدم المثال معامل `referrer` في [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) ويُعيد فقط اسم الملف. على سبيل المثال، إذا كان كلٌ من `resource-1.svg` و `resource-4.jpg` في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg` وليس إلى `assets/resource-4.jpg`.

استخدم بادئة URL مختلفة عندما تُنشر الملفات في مكان آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوى واحد فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُحمَّل الملفات إلى CDN أو خادم ملفات ثابت.

يجب أن يتطابق عنوان URL الذي تُعيده [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) مع الموقع النهائي للنشر للملف الذي يكتبه [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). في تطبيقات الخادم، استخدم مجلد إخراج فريد أو بادئة تخزين كائن لكل عملية تحويل لتجنب الكتابة فوق الملفات الناتجة عن تصدير آخر.

## **متى يُفضَّل التضمين بدلاً من ذلك**

يظل HTML المُضمّن كـ Base64 مفيدًا عندما يجب أن يكون الإخراج ملفًا واحدًا، مثل مرفق بريد إلكتروني، معاينة غير متصلة، أو مستند سينتقل دون مجلد أصول داعم. تكون الموارد المرتبطة الخيار الأفضل عندما يُقدَّم HTML عبر تطبيق ويب، يُحفظ في نظام إدارة محتوى، يُحسّن عبر مسار بناء، أو يُخزَّن مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **الأسئلة المتكررة**

**هل يمكنني إسناد الصور فقط خارجيًا وإبقاء باقي الموارد مضمَّنة؟**

نعم. في [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)، أعد `LinkEmbedDecision::Link` فقط لأنواع المحتوى التي تريد حفظها كملفات منفصلة، وأعد `LinkEmbedDecision::Embed` للبقية.

**لماذا يختلف امتداد الصورة المصدَّرة عن عرض الشرائح الأصلي؟**

قد تعيد Aspose.Slides ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف الأصلي كـ JPEG أو PNG حسب النتيجة المُعالجة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما تُحافظ على نفس بنية المجلدات النسبية. إذا أشار HTML إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجوار ملف HTML إلا إذا أنشأت بادئة URL مختلفة.

**هل يجب على تطبيقات الخادم إعادة استخدام مجلد الإخراج نفسه؟**

لا. استخدم مجلد إخراج فريد أو بادئة تخزين لكل عملية تحويل. هذا يمنع تصادم أسماء الملفات ويجنب استبدال الموارد التي ينتجها تصدير آخر.