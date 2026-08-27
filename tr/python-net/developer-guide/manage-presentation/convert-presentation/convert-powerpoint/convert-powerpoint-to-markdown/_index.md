---
title: "Python'da PowerPoint Sunumlarını Markdown'a Dönüştür"
linktitle: "PowerPoint'ten Markdown'a"
type: docs
weight: 140
url: /tr/python-net/convert-powerpoint-to-markdown/
keywords:
  - PowerPoint dönüştür
  - sunumu dönüştür
  - slaytı dönüştür
  - PPT dönüştür
  - PPTX dönüştür
  - PowerPoint'ten MD'ye
  - sunumdan MD'ye
  - slayttan MD'ye
  - PPT'den MD'ye
  - PPTX'ten MD'ye
  - PowerPoint'ı Markdown olarak kaydet
  - sunumu Markdown olarak kaydet
  - slaytı Markdown olarak kaydet
  - PPT'yi MD olarak kaydet
  - PPTX'i MD olarak kaydet
  - PPT'yi MD'ye dışa aktar
  - PPTX'i MD'ye dışa aktar
  - Markdown görüntü dışa aktarımı
  - CDN görüntü bağlantıları
  - PowerPoint
  - sunum
  - Markdown
  - Python
  - Python via .NET
  - Aspose.Slides
description: "Python'da PPT ve PPTX sunumlarını Markdown'a dönüştürün ve dışa aktarılan görsellerin nereye kaydedileceğini ve oluşturulan Markdown'ın bunlara nasıl başvuracağını kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, PPT ve PPTX sunumlarını belgeler, statik‑site, içerik‑taşıma ve sürüm‑kontrolü iş akışları için Markdown’a dönüştürebilir. Bir Markdown çeşidini seçebilir, slayt içeriğinin nasıl oluşturulacağını kontrol edebilir ve dışa aktarılan görsellerin nerede saklanacağını ve oluşturulan Markdown’ın bunlara nasıl başvurduğunu belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarımı yalnızca metin çıktısı kullanır. Görsel içeriği dışa aktarmak için, [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/export_type/) özelliğini [MarkdownExportType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownexporttype/) enum’ından `SEQUENTIAL` veya `VISUAL` değerine ayarlayın. `SEQUENTIAL`, slayt öğelerini ayrı ayrı ve sırayla oluştururken, `VISUAL` gruplanmış öğeleri birlikte tutarak görsel ilişkilerini korur. `TEXT_ONLY` değeri görsel kaynaklarını üretmez.

## **Sunumu Markdown'a Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipresentation/save/) metodunu, [SaveFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) enum’ından `MD` değeriyle çağırın.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Markdown Çeşidini Seçin**

[MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/flavor/) özelliği, çıktıda kullanılacak Markdown spesifikasyonunu denetler. [Flavor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/flavor/) enum’ı CommonMark, GitHub Flavored Markdown ve diğer desteklenen varyantları içerir.

Aşağıdaki örnek sunumu CommonMark olarak dışa aktarır:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Görselleri Varsayılan Yerel Kaydetme Davranışıyla Dışa Aktarın**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görseller için iki özellik sağlar:

- [base_path](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/base_path/) Markdown belgesi ve kaynakları için temel dizini belirtir.
- [images_save_folder_name](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) görsel alt dizinini belirtir. Varsayılan değeri `Images`.

Aşağıdaki örnek görsel içeriği oluşturur, görselleri `output/assets` klasörüne yazar ve Markdown belgesinde göreceli görsel referansları oluşturur:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Export görsel kaynakları ürettiğinde Aspose.Slides görsel alt dizinini oluşturur, ancak uygulamanın Markdown dosyasını kaydetmeden önce `base_path` dizinini oluşturması gerekir.

## **Yayın İçin Markdown ve Görselleri Hazırlama**

Aspose.Slides for Python via .NET, dışa aktarım sırasında oluşturulan her görsel bağlantısını değiştirmek için .NET görüntü kaydetme geri çağrımlarını açmaz. Bunun yerine, Markdown belgesini ve görsel klasörünü bir yayın dizinine dışa aktarın ve ardından bu dizini göreceli yapısını değiştirmeden yayınlayın.

Aşağıdaki örnek `cdn-origin/presentations/quarterly-report` dizinini bağlanmış veya senkronize bir yayın dizini olarak hazırlar. Örnek kendisi ağ üzerinden bir yükleme yapmaz: oluşturulan bağlantılar, dizin hedef site veya CDN konumunda yayınlandıktan sonra geçerli olur.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

`presentation.md` dosyasını `assets` dizini ile birlikte yayınlayın. Markdown belgesi göreceli görsel referansları kullanır, bu yüzden her iki öğenin de hedefte aynı ilişkiyi koruması gerekir. Eğer bir yayın sistemi mutlak dış URL’ler gerektiriyorsa, tüm görsel dosyaları yayınlandıktan sonra oluşturulan bağlantıları ayrı bir son‑işleme adımında yeniden yazın.

## **SSS**

**Python geri çağrımları Markdown dışa aktarımı sırasında tek tek görüntü dosyalarını ve bağlantılarını özelleştirebilir mi?**

Hayır. Aspose.Slides for Python via .NET, .NET `ImageSaving` ve `SvgImageSaving` geri çağrımlarını açmaz. Yerel çıktıyı [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/base_path/) ve [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) ile yapılandırın, ardından oluşturulan kaynakları yayınlayın veya son‑işlemden geçirin.

**Dışa aktarılan görseller nerede kaydedilir?**

Görsel konumu, [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/base_path/) ve [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) tarafından kontrol edilir. Markdown belgesi bu görsellere göreceli yollarla başvurur.

**Görsel bağlantıları hangi yol ayıracını kullanmalı?**

Markdown bağlantılarında ve URL’lerde ileri eğik çizgi (`/`) kullanın. Dosya‑sistemi yolları için yalnızca `os.path.join` kullanın ve son‑işlem sırasında oluşturulan bağlantıları ayrı olarak normalleştirin.

**Markdown dışa aktarımı sırasında köprüler korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/python-net/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/python-net/slide-transition/) ve [animations](/slides/tr/python-net/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown'a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğini birden çok iş parçacığı arasında paylaşmayın. [multithreading guidelines](/slides/tr/python-net/multithreading/) izleyin ve her dosya için ayrı bir örnek kullanın.