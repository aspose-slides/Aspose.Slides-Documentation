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
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML باستخدام C++ وAspose.Slides مع حفظ الصور وغيرها من الموارد كملفات مرتبطة خارجيًا."
---
## **نظرة عامة**

بشكل افتراضي، يقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML مستقل. تُكتب الصور والموارد الأخرى مباشرةً داخل HTML، عادةً كبيانات Base64. هذا ملائم عندما تحتاج إلى ملف واحد قابل للنقل، لكنه ليس دائماً التنسيق الأنسب لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل على الخادم.

استخدم الموارد المرتبطة خارجياً عندما تريد:

- تقليل حجم مستند HTML؛
- تخزين الصور أو الخطوط أو الصوت أو الفيديو مؤقتاً في المتصفح أو شبكة توزيع المحتوى (CDN) بشكل منفصل؛
- فحص، استبدال، ضغط أو معالجة الموارد المُولَّدة بعد التصدير؛
- الحفاظ على بنية الإخراج أقرب إلى ما يتوقعه تطبيق ويب.

للحصول على سير عمل التحويل العام إلى HTML، راجع [Convert PowerPoint Presentations to HTML](/slides/ar/cpp/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد في عملية التصدير.

## **كيف يعمل تصدير الموارد المرتبطة**

[ILinkEmbedController](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/) يسمح لتطبيقك بتحديد، لكل مورد على حدة، ما إذا كان المصدِّر يدمج البيانات داخل HTML أو يحفظها خارجيًا ويكتب رابطًا.

تحتوي الواجهة على ثلاث طرق:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) يقرر ما إذا كان يجب ربط المورد أو دمجه.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) يُرجع عنوان URL الذي سيُكتب في HTML المُنشأ أو في مورد مرتبط آخر.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL في المتصفح هما اعتباران منفصلان. على سبيل المثال، يكتب المثال أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل هذه العناوين نسبةً إلى الملف الذي يحتوي على الرابط. لذلك، يستخدم الرابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، بينما يستخدم الرابط من ملف SVG إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع الموارد المرتبطة**

مثال C++ التالي ينشئ دليل إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في مجلد فرعي يسمى `assets`. يقوم المتحكم بربط الصور، الخطوط، الصوت، الفيديو، وموارد CSS الشائعة عندما يوفر Aspose.Slides أو يمكنه استنتاج امتداد ملف آمن. تُبقى الموارد غير المعروفة مدمجة.

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

بعد التصدير، يحتوي مجلد الإخراج على هذه البنية:

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

تعتمد الملفات الفعلية على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، تُصدر الصور النقطية عادةً كـ JPEG أو PNG. قد تختار Aspose.Slides ترميز صورة مختلف عن المستخدم في العرض الأصلي إذا كان ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدر الصور ذات الشفافية كـ PNG.

## **اختيار عناوين URL للنشر**

يستخدم المثال بادئة عنوان URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، سيحمّل المتصفح `html-output/assets/resource-1.svg`.

عندما يشير مورد مرتبط إلى مورد مرتبط آخر، يستخدم المثال معامل `referrer` في [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) ويُرجع اسم الملف فقط. على سبيل المثال، إذا كان `resource-1.svg` و `resource-4.jpg` كلاهما في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg` وليس إلى `assets/resource-4.jpg`.

استخدم بادئة URL مختلفة عندما تُنشر الملفات في موقع آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول بمستوى واحد أعلى من ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُرفع الملفات إلى شبكة توزيع محتوى أو خادم ملفات ثابت.

يجب أن يتطابق عنوان URL الذي تُرجعه [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) مع الموقع النهائي للملف الذي يكتبه [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). في تطبيقات الخادم، استخدم دليل إخراج فريد أو بادئة تخزين كائن لكل مهمة تحويل لتجنب استبدال ملفات من تصدير آخر.

## **متى يجب دمج الموارد بدلاً من ذلك**

لا يزال HTML المدمج بصيغة Base64 مفيدًا عندما يجب أن يكون الإخراج ملفًا واحدًا، مثل مرفق بريد إلكتروني، معاينة دون اتصال، أو مستند سينتقل دون مجلد أصول داعم. الموارد المرتبطة تكون أنسب عندما يُقدَّم HTML عبر تطبيق ويب، يُخزن في نظام إدارة محتوى، يُحسّن بواسطة خط أنابيب بناء، أو يُخزَّن مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **الأسئلة الشائعة**

**هل يمكنني استخراج الصور فقط وإبقاء الموارد الأخرى مدمجة؟**

نعم. في [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)، أرجِع `LinkEmbedDecision::Link` فقط لأنواع المحتوى التي تريد حفظها كملفات منفصلة، وأرجِع `LinkEmbedDecision::Embed` لكل ما عدا ذلك.

**لماذا يختلف امتداد الصورة المصدرة عن العرض التقديمي الأصلي؟**

قد يعيد Aspose.Slides ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتَب صورة من الملف الأصلي كـ JPEG أو PNG اعتمادًا على النتيجة المرسومة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما تُحافظ على نفس بنية المجلدات النسبية. إذا كان HTML يشير إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجوار ملف HTML ما لم تُولِّد بادئة URL مختلفة.

**هل يجب على تطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل مهمة تحويل. هذا يمنع تصادم أسماء الملفات ويمنع استبدال الموارد التي تم توليدها من قبل تصدير آخر.