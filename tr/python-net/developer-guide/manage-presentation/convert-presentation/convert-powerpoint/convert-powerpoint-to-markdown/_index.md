---
title: PowerPoint Sunumlarını Python'da Markdown'a Dönüştür
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint'i Markdown'a dönüştür
- OpenDocument'i Markdown'a dönüştür
- sunumu Markdown'a dönüştür
- slaytı Markdown'a dönüştür
- PPT'yi Markdown'a dönüştür
- PPTX'i Markdown'a dönüştür
- ODP'yi Markdown'a dönüştür
- PowerPoint'i MD'ye dönüştür
- OpenDocument'i MD'ye dönüştür
- sunumu MD'ye dönüştür
- slaytı MD'ye dönüştür
- PPT'yi MD'ye dönüştür
- PPTX'i MD'ye dönüştür
- ODP'yi MD'ye dönüştür
- PowerPoint
- OpenDocument
- sunum
- Markdown
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument slaytlarını—PPT, PPTX, ODP—Aspose.Slides for Python via .NET ile temiz Markdown'a dönüştürün, belgeleri otomatikleştirin ve biçimlendirmeyi koruyun."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını Markdown'a dönüştürmenize olanak tanır; bu, belge iş akışları, statik site oluşturma, içerik taşıma ve sürüm kontrolüne dayalı metin yayınlama için faydalı olabilir. API, PPT ve PPTX sunumlarını doğrudan MD dosyalarına dışa aktarmayı destekler ve oluşturulan Markdown belgesinde slayt içeriğinin nasıl temsil edileceğini kontrol etmek için ek seçenekler sunar.

Sunumları sade Markdown olarak dışa aktarabilir, CommonMark ve GitHub Flavored Markdown gibi birden çok Markdown çeşidinden seçim yapabilir ve dışa aktarım sırasında görsellerin nasıl işleneceğini yapılandırabilirsiniz. Görsel içerik içeren sunumlar için Aspose.Slides, görselleri ayrı bir klasöre kaydetmenize ve oluşturulan Markdown dosyasından başvurmanıza da izin verir.

{{% alert color="warning" %}}
PowerPoint'ten Markdown'a dışa aktarma varsayılan olarak **görseller olmadan** yapılır. Görseller içeren bir PowerPoint belgesini dışa aktarmak istiyorsanız, `export_type = MarkdownExportType.VISUAL` ayarlamanız ve Markdown belgesinde başvurulan görsellerin kaydedileceği `base_path` belirlemeniz gerekir.
{{% /alert %}}

## **Sunumları Markdown'a Dönüştür**

Aşağıdaki örnek, Aspose.Slides for Python via .NET kullanarak PowerPoint sunumunu varsayılan ayarlarla Markdown'a dönüştürmenin en basit yolunu gösterir.

1. Sunumu yüklemek için bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturun.
2. `save` metodunu çağırarak onu bir Markdown dosyası olarak dışa aktarın.

Aşağıdaki Python kod parçacığını kullanarak dönüşümü gerçekleştirin:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Sunumları Markdown Çeşidine Dönüştür**

Aspose.Slides, temel Markdown, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab ve 17 başka Markdown çeşidi dahil olmak üzere sunumları çeşitli Markdown formatlarına dönüştürmenize olanak tanır.

Aşağıdaki Python örneği, bir PowerPoint sunumunu CommonMark'a nasıl dönüştüreceğinizi gösterir:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

Desteklenen 23 Markdown çeşidi, [Flavor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) enumerasyonu ve [MarkdownSaveOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) sınıfı içinde listelenir.

## **Görseller İçeren Sunumları Markdown'a Dönüştür**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) sınıfı, oluşturulan Markdown dosyasını yapılandırmanıza olanak sağlayan özellikler ve enumerasyonlar sunar. Örneğin, [MarkdownExportType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum'ı görsellerin nasıl işleneceğini kontrol eder: `SEQUENTIAL`, `TEXT_ONLY` veya `VISUAL`.

### **Görselleri Sıralı Olarak Dönüştür**

Görsellerin oluşturulan Markdown içinde tek tek—birbiri ardına—görünmesini istiyorsanız, `SEQUENTIAL` seçeneğini seçin. Aşağıdaki Python örneği, görselleri olan bir sunumu Markdown'a nasıl dönüştüreceğinizi gösterir.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Görselleri Görsel Olarak Dönüştür**

Görsellerin sonuç Markdown'ta birlikte görünmesini istiyorsanız, `VISUAL` seçeneğini seçin. Bu modda, görseller uygulamanın geçerli dizinine kaydedilir (ve Markdown belgesi göreli yollar kullanır) veya özel bir çıktı yolu ve klasör adı belirtebilirsiniz.

Aşağıdaki Python örneği bu işlemi gösterir:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **SSS**

**Hipermetin bağlantıları Markdown'a dışa aktarımda korunur mu?**

Evet. Metin [hiperbağlantılar](/slides/tr/python-net/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [geçişler](/slides/tr/python-net/slide-transition/) ve [animasyonlar](/slides/tr/python-net/powerpoint-animation/) dönüştürülmez.

**Dönüşümü birden çok iş parçacığında çalıştırarak hızlandırabilir miyim?**

Dosyalar arasında paralelleştirme yapabilirsiniz, ancak iş parçacıkları arasında aynı [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğini [paylaşmayın](/slides/tr/python-net/multithreading/). Çakışmayı önlemek için dosya başına ayrı örnekler/süreçler kullanın.

**Görseller ne olur—nerede kaydedilir ve yollar göreli mi?**

[Görseller](/slides/tr/python-net/image/) ayrı bir klasöre dışa aktarılır ve Markdown dosyası varsayılan olarak onları göreli yollarla referans alır. Temel çıktı yolunu ve varlık klasör adını yapılandırarak öngörülebilir bir depo yapısını koruyabilirsiniz.