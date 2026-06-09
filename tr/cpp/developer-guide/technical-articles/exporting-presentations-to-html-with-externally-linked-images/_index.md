---
title: Harici Bağlantılı Görsellerle Sunumları HTML'ye Dışa Aktarma
type: docs
weight: 50
url: /tr/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunum dışa aktar
- slayt dışa aktar
- PPT dışa aktar
- PPTX dışa aktar
- ODP dışa aktar
- PowerPoint'tan HTML'ye
- OpenDocument'ten HTML'ye
- sunumdan HTML'ye
- slayttan HTML'ye
- PPT'den HTML'ye
- PPTX'den HTML'ye
- ODP'den HTML'ye
- bağlantılı görsel
- harici olarak bağlanmış görsel
- bağlantılı kaynak
- harici kaynak
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını C++'ta Aspose.Slides kullanarak HTML'ye dışa aktar, görseller ve diğer kaynaklar harici bağlantılı dosyalar olarak kaydedilir."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek dosyalı HTML dosyasına dışa aktarır. Görseller ve diğer kaynaklar doğrudan HTML içine, genellikle Base64 verisi olarak yazılır. Bu, tek bir taşınabilir dosyaya ihtiyaç duyduğunuzda kullanışlıdır, ancak bir web sitesi, bir CMS veya sunucu tarafı dönüşüm hattı için her zaman en iyi format değildir.

Harici olarak bağlanan kaynakları aşağıdaki durumlarda kullanın:

- HTML belgesinin boyutunu küçültmek;
- görselleri, yazı tiplerini, sesleri veya videoları tarayıcıda veya CDN'de ayrı ayrı önbelleğe almak;
- dışa aktarma sonrası oluşturulan kaynakları incelemek, değiştirmek, sıkıştırmak veya son işlem yapmak;
- çıktı yapısını bir web uygulamasının beklediği şekle daha yakın tutmak.

Genel HTML dönüşüm süreci için, [PowerPoint Sunumlarını HTML'ye Dönüştür](/slides/tr/cpp/convert-powerpoint-to-html/) bölümüne bakın. Bu makale, dışa aktarmanın kaynak bağlama kısmına odaklanır.

## **Bağlantılı Kaynak Dışa Aktarması Nasıl Çalışır**

[ILinkEmbedController](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/) uygulamanıza, kaynak bazında dışa aktarımcının veriyi HTML içinde gömüp gömmeyeceğine ya da dışarı kaydedip bir bağlantı yazacağına karar verme imkanı verir.

Arayüz üç metoda sahiptir:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) bir kaynağın bağlanıp bağlanmayacağını veya gömülü olup olmayacağını belirler.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) oluşturulan HTML'ye ya da başka bir bağlı kaynağa yazılacak URL'yi döndürür.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) bağlı kaynak verisini diske ya da başka bir depolama hedefine yazar.

Dosya sistemi yolu ve tarayıcı URL'si ayrı konulardır. Örneğin, aşağıdaki örnek kaynak dosyalarını `html-output/assets` klasörüne diskte yazar, HTML ise `assets/resource-1.svg` gibi göreli URL'ler içerir. Bir tarayıcı bu URL'leri bağlantıyı içeren dosyaya göreli olarak çözer. Bu nedenle, `presentation.html` dosyasından bir SVG dosyasına bağlantı `assets/resource-1.svg` kullanırken, aynı `assets` klasöründe kaydedilen bir resme SVG dosyasından yapılan bağlantı `resource-4.jpg` olur.

## **Bağlantılı Kaynaklarla HTML Dışa Aktarımı**

Aşağıdaki C++ örneği bir çıktı dizini oluşturur, HTML dosyasını oraya kaydeder ve bağlı kaynakları bir `assets` alt klasöründe saklar. Kontrolör, Aspose.Slides güvenli bir dosya uzantısı sağlayabildiğinde veya çıkarabildiğinde ortak görsel, yazı tipi, ses, video ve CSS kaynaklarını bağlar. Tanınamayan kaynaklar gömülü kalır.

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

Dışa aktarmadan sonra çıktı klasörü şu yapıya sahiptir:

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

Tam dosyalar, sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görseller genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, daha küçük veya daha uygun bir dosya ürettiğinde kaynak sunumda kullanılandan farklı bir görüntü codec'i seçebilir. Şeffaflık içeren görseller PNG olarak dışa aktarılır.

## **Dağıtım İçin URL'lerin Seçilmesi**

Örnek bir göreli URL öneki kullanır: `assets/`. `presentation.html` dosyası `html-output/presentation.html` konumundan açıldığında tarayıcı `html-output/assets/resource-1.svg` dosyasını yükler.

Bir bağlantılı kaynak başka bir bağlantılı kaynağa başvurduğunda, örnek [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) içinde `referrer` parametresini kullanır ve yalnızca dosya adını döndürür. Örneğin, `resource-1.svg` ve `resource-4.jpg` aynı `assets` klasöründeyse, SVG dosyası `resource-4.jpg` a başvurmalı, `assets/resource-4.jpg` değil.

Dosyalar başka bir yerde dağıtıldığında farklı bir URL öneki kullanın:

- `assets/` öneki, varlık klasörü HTML dosyasının yanında olduğunda kullanılır.
- `../assets/` öneki, varlık klasörü HTML dosyasının bir seviye üstünde olduğunda kullanılır.
- `https://cdn.example.com/presentations/job-123/assets/` öneki, dosyalar bir CDN veya statik dosya sunucusuna yüklendiğinde kullanılır.

[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) tarafından döndürülen URL, [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) tarafından yazılan dosyanın nihai dağıtım konumuyla eşleşmelidir. Sunucu uygulamalarında, her dönüşüm işi için benzersiz bir çıktı dizini veya nesne‑depolama öneki kullanarak bir dışa aktarmanın diğerinin kaynaklarını üzerine yazmasını önleyin.

## **Ne Zaman Yerleşik (Embedded) Kullanılır**

Gömülü Base64 HTML, çıktının tek bir dosya olması gerektiğinde hâlâ faydalıdır; örneğin bir e‑posta eki, çevrimdışı ön izleme veya destekleyici varlık klasörü olmadan taşınacak bir belge. Bağlantılı kaynaklar, HTML bir web uygulaması tarafından sunulacaksa, bir CMS içinde saklanacaksa, bir derleme hattı tarafından optimize edilecekse veya tarayıcılar HTML'den bağımsız olarak önbelleğe alacaksa daha uygundur.

## **SSS**

**Sadece görselleri harici hale getirip diğer kaynakları gömülü tutabilir miyim?**

Evet. [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) içinde ayrı dosyalar olarak kaydetmek istediğiniz içerik türleri için `LinkEmbedDecision::Link` döndürün, diğer tüm içerikler için `LinkEmbedDecision::Embed` döndürün.

**Neden dışa aktarılan görsel uzantısı kaynak sunumdan farklı?**

Aspose.Slides, HTML dışa aktarımı sırasında boyutu küçültmek veya tarayıcı uyumluluğunu artırmak amacıyla raster görselleri yeniden kodlayabilir. Örneğin, kaynak dosyadaki bir görsel, oluşturulan sonuca bağlı olarak JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL'ler çalışır mı?**

Göreli URL'ler yalnızca aynı göreli klasör yapısı korunduğunda çalışır. HTML `assets/resource-1.png` adresine başvuruyorsa, `assets` klasörü HTML dosyasının yanında kalmalıdır; aksi takdirde farklı bir URL öneki oluşturmanız gerekir.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm işi için benzersiz bir çıktı dizini veya depolama öneki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarmanın diğerinin oluşturduğu kaynakları üzerine yazmasını engeller.