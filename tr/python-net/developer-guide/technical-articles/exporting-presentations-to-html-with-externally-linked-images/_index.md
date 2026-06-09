---
title: Python'da Dış Bağlantılı Görsellerle Sunumları HTML'e Dışa Aktarma
linktitle: Dış Bağlantılı Görsellerle Sunumları HTML'e Dışa Aktarma
type: docs
weight: 100
url: /tr/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint'i dışa aktar
- OpenDocument'i dışa aktar
- sunumu dışa aktar
- slaytı dışa aktar
- PPT'yi dışa aktar
- PPTX'i dışa aktar
- ODP'yi dışa aktar
- PowerPoint'ten HTML'e
- OpenDocument'ten HTML'e
- sunumdan HTML'e
- slayttan HTML'e
- PPT'den HTML'e
- PPTX'den HTML'e
- ODP'den HTML'e
- bağlantılı görsel
- dışarıdan bağlantılı görsel
- bağlantılı kaynak
- dış kaynak
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını, görselleri dış bağlantılı dosyalar olarak kaydedilen Aspose.Slides kullanarak Python'da HTML'e dışa aktarın."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek bir HTML dosyasına dışa aktarır. Görseller ve diğer kaynaklar doğrudan HTML içine, genellikle Base64 veri olarak yazılır. Bu, tek bir taşınabilir dosya gerektiğinde uygundur, fakat bir web sitesi, bir CMS veya sunucu tarafı dönüştürme hattı için her zaman en iyi format olmayabilir.

Aşağıdaki durumlarda harici bağlanan görseller kullanın:

- HTML belgesinin boyutunu azaltmak;
- görselleri tarayıcıda veya CDN'de ayrı ayrı önbelleğe almak;
- dışa aktarıldıktan sonra oluşturulan görselleri incelemek, değiştirmek, sıkıştırmak veya sonradan işlemek;
- çıktının yapılandırmasını bir web uygulamasının beklentilerine daha yakın tutmak.

Genel HTML dönüştürme iş akışı için bakınız [PowerPoint Sunumlarını HTML'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-html/). Bu makale dışa aktarmanın görsel bağlama kısmına odaklanır.

## **Bağlantılı Görsel Dışa Aktarımının Çalışma Şekli**

.NET ve Java'da, [ILinkEmbedController](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/ilinkembedcontroller/) dışa aktarıcının bir kaynağın gömülüp gömülmeyeceğine karar vermek için kullandığı geri çağırma arayüzüdür. Python üzerinden .NET'te, Python sınıfları şu anda bu .NET geri çağırma arayüzünü doğrudan uygulayamaz, bu nedenle pratik iş akışı şudur:

1. Sunumu [HtmlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/htmloptions/) ile HTML’ye dışa aktarın.
1. Kaydırmaları HTML içinde SVG olarak temsil etmek için [SlideImageFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/slideimageformat/) ile [SVGOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/svgoptions/) kullanın.
1. Base64 görsel verilerini HTML `data:` URL’lerinden ayrı dosyalara taşıyın.
1. Orijinal `data:` URL’lerini `assets/resource-1.jpg` gibi göreli bağlantılarla değiştirin.

Dosya sistemi yolu ve tarayıcı URL’si ayrı konulardır. Örneğin, aşağıdaki örnek görsel dosyalarını diskte `html-output/assets` klasörüne yazar, HTML ise `assets/resource-1.jpg` gibi göreli URL’ler içerir. Bir tarayıcı bu URL’leri, bağlantıyı içeren HTML dosyasına göreli olarak çözer.

## **Bağlantılı Görsellerle HTML Dışa Aktarma**

Aşağıdaki Python örneği bir çıktı dizini oluşturur, HTML dosyasını oraya kaydeder, çıkarılan görselleri bir `assets` alt klasörüne yerleştirir ve Base64 görsel URL’lerini göreli bağlantılarla yeniden yazar. Örnek, Aspose.Slides güvenli bir dosya uzantısı sağladığında yaygın Base64 görsel formatlarını çıkarır. Tanınmayan Data URL’leri gömülü kalır.

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

Dışa aktarma sonrası, çıktı klasörü şu yapıya sahip olabilir:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Tam dosyalar sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görseller genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, daha küçük veya daha uygun bir dosya ürettiğinde kaynak sunumda kullanılandan farklı bir görüntü codec’i seçebilir. Şeffaflık içeren görseller PNG olarak dışa aktarılır.

## **Dağıtım İçin URL’lerin Seçilmesi**

Örnek, göreli bir URL öneki olan `assets/` kullanır: `presentation.html` dosyası `html-output/presentation.html` konumundan açıldığında tarayıcı `html-output/assets/resource-1.jpg` dosyasını yükler.

Dosyalar başka bir yerde dağıtıldığında farklı bir varlık dizini adı kullanın veya oluşturulan bağlantıları yeniden yazın:

- Varlık dizini HTML dosyasının yanında ise `assets/` kullanın.
- Varlık dizini HTML dosyasının bir seviye üstündeyse `../assets/` kullanın.
- Dosyalar bir CDN ya da statik dosya sunucusuna yüklendiyse `https://cdn.example.com/presentations/job-123/assets/` kullanın.

Sunucu uygulamalarında, her dönüşüm işi için benzersiz bir çıktı dizini veya nesne depolama öneki kullanarak başka bir dışa aktarımın dosyalarını üzerine yazmaktan kaçının.

## **Ne Zaman Gömülü Kullanmalı?**

Gömülü Base64 HTML, çıktı tek bir dosya olmalıysa hâlâ yararlıdır; örneğin bir e‑posta eki, çevrim dışı ön izleme veya destekleyici bir varlık klasörü olmadan taşınacak bir belge. Bağlantılı görseller, HTML bir web uygulaması tarafından sunulacaksa, bir CMS içinde saklanacaksa, bir derleme hattı tarafından optimize edilecekse veya tarayıcılar HTML’den bağımsız olarak önbelleğe alacaksa daha uygun bir seçenektir.

## **SSS**

**Yalnızca görselleri harici hale getirip diğer kaynakları gömülü tutabilir miyim?**

Evet. Örnek, `EXTENSIONS_BY_CONTENT_TYPE` içinde listelenen `image/*` Base64 veri URL’lerini yalnızca çıkarır. Diğer veri URL’leri gömülü kalır.

**Dışa aktarılan görsel uzantısı kaynak sunumdan neden farklı?**

Aspose.Slides, HTML dışa aktarımı sırasında raster görselleri yeniden kodlayarak boyutu azaltabilir veya tarayıcı uyumluluğunu artırabilir. Örneğin, kaynak dosyadaki bir görsel, oluşturulan sonuca göre JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL’ler çalışır mı?**

Göreli URL’ler yalnızca aynı göreli klasör yapısı korunduğunda çalışır. HTML `assets/resource-1.png` adresine başvuruyorsa, `assets` klasörü HTML dosyasının yanına kalmalıdır; aksi takdirde farklı bir URL öneki oluşturmalısınız.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm işi için benzersiz bir çıktı dizini veya depolama öneki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarımın başka bir dışa aktarmanın oluşturduğu kaynakları üzerine yazmasını engeller.