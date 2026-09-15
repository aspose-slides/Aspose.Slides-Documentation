---
title: Sunumları Harici Bağlı Görsellerle HTML'ye Dışa Aktarma
type: docs
weight: 100
url: /tr/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- "PowerPoint'i dışa aktar"
- "OpenDocument'i dışa aktar"
- "sunumu dışa aktar"
- "slaytı dışa aktar"
- "PPT'yi dışa aktar"
- "PPTX'i dışa aktar"
- "ODP'yi dışa aktar"
- "PowerPoint'ten HTML'ye"
- "OpenDocument'ten HTML'ye"
- "sunumdan HTML'ye"
- "slayttan HTML'ye"
- "PPT'den HTML'ye"
- "PPTX'ten HTML'ye"
- "ODP'den HTML'ye"
- "bağlı görüntü"
- "harici bağlı görüntü"
- "bağlı kaynak"
- "harici kaynak"
- "Python"
- "Java"
- "Aspose.Slides"
description: "PowerPoint ve OpenDocument sunumlarını Python'da Aspose.Slides kullanarak HTML'ye dışa aktarın; görüntüler ve diğer kaynaklar harici bağlı dosyalar olarak kaydedilir."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek bir HTML dosyasına dışa aktarır. Görseller ve diğer kaynaklar doğrudan HTML içine, genellikle Base64 veri olarak yazılır. Tek bir taşınabilir dosyaya ihtiyacınız olduğunda bu kullanışlıdır, ancak bir web sitesi, bir CMS veya sunucu tarafı dönüşüm hattı için her zaman en iyi format değildir.

Aşağıdaki durumlarda harici bağlı kaynakları kullanın:

- HTML belgesinin boyutunu azaltmak;
- Görselleri, yazı tiplerini, sesleri veya videoları tarayıcıda veya CDN'de ayrı ayrı önbelleğe almak;
- Dışa aktarma sonrası oluşturulan kaynakları incelemek, değiştirmek, sıkıştırmak veya son işlem uygulamak;
- Çıktı yapısını bir web uygulamasının beklentisine daha yakın tutmak.

Genel HTML dönüşüm iş akışı için, [PowerPoint Sunumlarını HTML'ye Dönüştür](/slides/tr/python-java/convert-powerpoint-to-html/) sayfasına bakın. Bu makale, dışa aktarmanın kaynak bağlama kısmına odaklanmaktadır.

## **Bağlantılı Kaynak Dışa Aktarımı Nasıl Çalışır**

`ILinkEmbedController`, uygulamanızın her bir kaynağı ayrı ayrı değerlendirerek, dışa aktarıcının veriyi HTML içinde gömüp gömmeyeceğine ya da harici olarak kaydedip bir bağlantı yazıp yazmayacağına karar vermesini sağlar.

Arayüzün üç yöntemi vardır:

- `ILinkEmbedController.getObjectStoringLocation`, bir kaynağın bağlanıp bağlanmayacağını veya gömülüp gömülmeyeceğini belirler.
- `ILinkEmbedController.getUrl`, oluşturulan HTML'ye veya başka bir bağlı kaynağa yazılacak URL'yi döndürür.
- `ILinkEmbedController.saveExternal`, bağlı kaynak verilerini diske veya başka bir depolama hedefine yazar.

Dosya sistemi yolu ve tarayıcı URL'si ayrı konulardır. Örneğin, aşağıdaki örnek kaynak dosyalarını diskte `html-output/assets` klasörüne yazar, ancak HTML `assets/resource-1.svg` gibi göreli URL'ler içerir. Bir tarayıcı bu URL'leri bağlantıyı içeren dosyaya göreli olarak çözer. Bu yüzden `presentation.html` dosyasından bir SVG dosyasına bağlantı `assets/resource-1.svg` şeklinde olur, o SVG dosyasından aynı `assets` klasöründe kaydedilmiş bir görsele bağlantı ise `resource-4.jpg` olur.

## **Bağlantılı Kaynaklarla HTML Dışa Aktarma**

Aşağıdaki Python örneği bir çıktı dizini oluşturur, HTML dosyasını oraya kaydeder ve bağlantılı kaynakları bir `assets` alt dizininde saklar. Kontrolcü, Aspose.Slides güvenli bir dosya uzantısı sağladığında veya çıkarabildiğinde yaygın görüntü, yazı tipi, ses, video ve CSS kaynaklarını bağlar. Tanınmayan kaynaklar gömülü kalır.

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

Tam dosyalar sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görüntüler genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, kaynak sunumda kullanılandan daha küçük veya daha uygun bir dosya ürettiğinde farklı bir görüntü kodeği seçebilir. Şeffaflık içeren görseller PNG olarak dışa aktarılır.

## **Dağıtım İçin URL'leri Seçme**

Örnek, göreli bir URL ön eki kullanır: `assets/`. `presentation.html` `html-output/presentation.html` konumundan açılırsa, tarayıcı `html-output/assets/resource-1.svg` dosyasını yükler.

Bir bağlı kaynağın başka bir bağlı kaynağa başvurması gerektiğinde, örnek `ILinkEmbedController.getUrl` içinde `referrer` parametresini kullanır ve yalnızca dosya adını döndürür. Örneğin, `resource-1.svg` ve `resource-4.jpg` aynı `assets` klasöründeyse, SVG dosyası `resource-4.jpg`'e, `assets/resource-4.jpg` yerine, referans vermelidir.

Dosyalar başka bir yerde dağıtıldığında farklı bir URL ön eki kullanın:

- Varlık dizini HTML dosyasının yanında olduğunda `assets/` kullanın.
- Varlık dizini HTML dosyasının bir üst seviyesinde olduğunda `../assets/` kullanın.
- Dosyalar bir CDN'ye veya sabit dosya sunucusuna yüklendiğinde `https://cdn.example.com/presentations/job-123/assets/` kullanın.

`ILinkEmbedController.getUrl` tarafından döndürülen URL, `ILinkEmbedController.saveExternal` tarafından yazılan dosyanın nihai dağıtım konumuyla eşleşmelidir. Sunucu uygulamalarında, başka bir dışa aktarmadan gelen dosyaların üzerine yazılmasını önlemek için her dönüşüm işi için benzersiz bir çıktı dizini veya nesne depolama ön eki kullanın.

## **Ne Zaman Gömülmüş Olarak Kullanılmalı**

Gömülü Base64 HTML, çıktı tek bir dosya olmalıysa hâlâ kullanışlıdır; örneğin bir e-posta eki, çevrim dışı ön izleme veya destekleyici bir varlık klasörü olmadan taşınacak bir belge gibi. Bağlantılı kaynaklar, HTML bir web uygulaması tarafından sunulacak, bir CMS'de saklanacak, bir derleme hattı tarafından optimize edilecek veya tarayıcılar tarafından HTML'den bağımsız olarak önbelleğe alınacaksa daha uygun bir çözümdür.

## **SSS**

**Sadece görselleri harici hale getirip diğer kaynakları gömülü tutabilir miyim?**

Evet. `ILinkEmbedController.getObjectStoringLocation` içinde, ayrı dosyalar olarak kaydetmek istediğiniz içerik türleri için yalnızca [LinkEmbedDecision.Link](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linkembeddecision/#Link) döndürün ve diğer tüm durumlar için [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/linkembeddecision/#Embed) döndürün.

**Neden dışa aktarılan görüntü uzantısı kaynak sunumdan farklı?**

Aspose.Slides, boyutu veya tarayıcı uyumluluğunu artırmak için HTML dışa aktarımı sırasında raster görüntüleri yeniden kodlayabilir. Örneğin, kaynak dosyadan bir görüntü, render sonucuna bağlı olarak JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL'ler çalışır mı?**

Göreli URL'ler yalnızca aynı göreli klasör yapısı korunursa çalışır. HTML `assets/resource-1.png` referans veriyorsa, `assets` klasörü HTML dosyasının yanında kalmalıdır; aksi takdirde farklı bir URL ön eki oluşturmanız gerekir.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm işi için benzersiz bir çıktı dizini veya depolama ön eki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarmanın başka bir dışa aktarmanın oluşturduğu kaynakların üzerine yazmasını engeller.