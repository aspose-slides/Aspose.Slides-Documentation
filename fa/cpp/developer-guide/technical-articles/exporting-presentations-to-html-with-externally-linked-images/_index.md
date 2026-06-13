---
title: صادرات ارائه‌ها به HTML با تصاویر لینک‌شده خارجی
type: docs
weight: 50
url: /fa/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- صادرات PowerPoint
- صادرات OpenDocument
- صادرات ارائه
- صادرات اسلاید
- صادرات PPT
- صادرات PPTX
- صادرات ODP
- PowerPoint به HTML
- OpenDocument به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ODP به HTML
- تصویر لینک‌شده
- تصویر لینک‌شده خارجی
- منبع لینک‌شده
- منبع خارجی
- C++
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML در C++ با استفاده از Aspose.Slides و ذخیره تصاویر و سایر منابع به‌صورت فایل‌های لینک‌شده خارجی."
---
## **مرور کلی**

به طور پیش‌فرض، Aspose.Slides یک ارائه را به یک فایل HTML خودکفا صادر می‌کند. تصاویر و سایر منابع مستقیماً در HTML نوشته می‌شوند، معمولاً به صورت داده‌های Base64. این وقتی مفید است که شما به یک فایل قابل حمل نیاز دارید، اما همیشه بهترین قالب برای یک وب‌سایت، یک CMS یا یک خط لوله تبدیل سمت سرور نیست.

به‌منظور استفاده از منابع لینک‌شده خارجی وقتی می‌خواهید:

- حجم سند HTML را کاهش دهید؛
- تصاویر، فونت‌ها، صدا یا ویدیو را به‌صورت جداگانه در مرورگر یا CDN کش کنید؛
- منابع تولید شده پس از صادرات را بررسی، جایگزین، فشرده یا پس‌پردازش کنید؛
- ساختار خروجی را نزدیک‌تر به آنچه یک برنامه وب انتظار دارد نگه دارید.

برای جریان کاری عمومی تبدیل HTML، به [تبدیل ارائه‌های PowerPoint به HTML](/slides/fa/cpp/convert-powerpoint-to-html/) مراجعه کنید. این مقاله بر بخش لینک‌گذاری منابع در خروجی تمرکز دارد.

## **نحوه کار خروجی با منابع لینک‌شده**

[ILinkEmbedController](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/) به برنامه شما اجازه می‌دهد تا به‌صورت منبع به منبع تصمیم بگیرد که آیا صادرکننده داده‌ها را در HTML تعبیه می‌کند یا به‌صورت خارجی ذخیره می‌کند و لینک می‌نویسد.

این رابط سه متد دارد:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) تصمیم می‌گیرد که آیا یک منبع باید لینک شود یا تعبیه گردد.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) URLی را برمی‌گرداند که در HTML تولید شده یا به منبع لینک‌شده دیگری نوشته خواهد شد.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) داده‌های منبع لینک‌شده را روی دیسک یا به مقصد ذخیره‌سازی دیگری می‌نویسد.

مسیر فایل سیستم و URL مرورگر مواردی جداگانه هستند. به عنوان مثال، نمونه زیر فایل‌های منبع را در `html-output/assets` روی دیسک می‌نویسد، در حالی که HTML شامل URLهای نسبی مانند `assets/resource-1.svg` است. مرورگر این URLها را نسبت به فایلی که شامل لینک است حل می‌کند. بنابراین، لینکی از `presentation.html` به یک فایل SVG از `assets/resource-1.svg` استفاده می‌کند، در حالی که لینکی از همان فایل SVG به تصویری که در همان پوشه `assets` ذخیره شده است، از `resource-4.jpg` استفاده می‌کند.

## **خروجی HTML با منابع لینک‌شده**

مثال C++ زیر یک پوشه خروجی ایجاد می‌کند، فایل HTML را در آن ذخیره می‌کند و منابع لینک‌شده را در زیرپوشه `assets` ذخیره می‌نماید. کنترلر زمانی که Aspose.Slides پسوند فایل امنی را فراهم می‌کند یا می‌تواند استنتاج کند، منابع رایج تصویر، فونت، صدا، ویدئو و CSS را لینک می‌کند. منابعی که شناخته نشوند به‌صورت تعبیه‌شده باقی می‌مانند.

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

پس از خروجی، پوشه خروجی این ساختار را دارد:

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

فایل‌های دقیق بسته به محتوای ارائه و گزینه‌های خروجی متفاوت هستند. به عنوان مثال، تصاویر رستر به‌طور معمول به‌صورت JPEG یا PNG صادر می‌شوند. Aspose.Slides ممکن است کدک تصویری متفاوتی نسبت به آنچه در ارائه منبع استفاده شده است انتخاب کند، هنگامی که این کار منجر به فایل کوچکتر یا مناسب‌تر می‌شود. تصاویری که شفافیت دارند به‌صورت PNG صادر می‌شوند.

## **انتخاب URLها برای استقرار**

نمونه از پیشوند URL نسبی `assets/` استفاده می‌کند. اگر `presentation.html` از `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.svg` را بارگذاری می‌کند.

زمانی که یک منبع لینک‌شده به منبع لینک‌شده دیگری ارجاع می‌دهد، نمونه از پارامتر `referrer` در [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) استفاده می‌کند و فقط نام فایل را برمی‌گرداند. به عنوان مثال، اگر `resource-1.svg` و `resource-4.jpg` هر دو در پوشه `assets` باشند، فایل SVG باید به `resource-4.jpg` ارجاع دهد، نه به `assets/resource-4.jpg`.

یک پیشوند URL متفاوت استفاده کنید هنگامی که فایل‌ها در مکان دیگری استقرار می‌یابند:

- از `assets/` استفاده کنید زمانی که پوشهٔ دارایی‌ها کنار فایل HTML قرار دارد.
- از `../assets/` استفاده کنید زمانی که پوشهٔ دارایی‌ها یک سطح بالاتر از فایل HTML است.
- از `https://cdn.example.com/presentations/job-123/assets/` استفاده کنید زمانی که فایل‌ها به یک CDN یا سرور فایل استاتیک بارگذاری می‌شوند.

URLی که توسط [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) برگردانده می‌شود باید با مکان نهایی استقرار فایلی که توسط [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) نوشته می‌شود مطابقت داشته باشد. در برنامه‌های سروری، برای هر کار تبدیل یک پوشه خروجی یا پیشوند ذخیره‌سازی شیء منحصر به فرد استفاده کنید تا از بازنویسی فایل‌های خروجی دیگر جلوگیری شود.

## **چه موقع به جای آن تعبیه کنید**

HTML تعبیه‌شده Base64 هنوز زمانی مفید است که خروجی باید یک فایل واحد باشد، مانند یک پیوست ایمیل، پیش‌نمایش آفلاین، یا سندی که بدون پوشه دارایی پشتیبان جابه‌جا می‌شود. منابع لینک‌شده زمانی بهتر هستند که HTML توسط یک برنامه وب سرویس‌دهی شود، در یک CMS ذخیره شود، توسط یک خط لوله ساخت بهینه‌سازی شود، یا توسط مرورگرها به‌صورت مستقل از HTML کش شود.

## **FAQ**

**آیا می‌توانم فقط تصاویر را به‌صورت خارجی ذخیره کنم و سایر منابع را تعبیه بمانم؟**

بله. در [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) فقط برای انواع محتوایی که می‌خواهید به‌صورت فایل‌های جداگانه ذخیره شوند مقدار `LinkEmbedDecision::Link` را برگردانید و برای بقیه مقدار `LinkEmbedDecision::Embed` را برگردانید.

**چرا پسوند تصویر صادرشده با ارائه منبع متفاوت است؟**

Aspose.Slides ممکن است هنگام خروجی HTML تصاویر رستر را مجدداً رمزگذاری کند تا حجم یا سازگاری مرورگر بهبود یابد. به عنوان مثال، تصویری که در فایل منبع وجود دارد ممکن است بسته به نتیجه رندر به‌صورت JPEG یا PNG نوشته شود.

**آیا URLهای نسبی پس از جابه‌جا کردن فایل HTML کار می‌کنند؟**

URLهای نسبی تنها زمانی کار می‌کنند که ساختار پوشه نسبی یکسان حفظ شود. اگر HTML به `assets/resource-1.png` ارجاع دهد، پوشه `assets` باید در کنار فایل HTML بماند مگر اینکه پیشوند URL متفاوتی تولید کنید.

**آیا برنامه‌های سروری باید از همان پوشه خروجی استفاده مجدد کنند؟**

خیر. برای هر کار تبدیل یک پوشه خروجی یا پیشوند ذخیره‌سازی منحصر به فرد استفاده کنید. این کار از تداخل نام فایل‌ها جلوگیری می‌کند و مانع نوشتن دوباره منابع تولید‌شده توسط یک خروجی دیگر می‌شود.