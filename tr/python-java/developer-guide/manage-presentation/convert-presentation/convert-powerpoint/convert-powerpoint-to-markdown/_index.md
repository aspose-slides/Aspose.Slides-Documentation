---
title: Python üzerinden Java ile PowerPoint Sunumlarını Markdown'a Dönüştürme
linktitle: PowerPoint'ten Markdown
type: docs
weight: 140
url: /tr/python-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştürme
- sunum dönüştürme
- slayt dönüştürme
- PPT dönüştürme
- PPTX dönüştürme
- PowerPoint'ten MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'den MD'ye
- PowerPoint'i Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'yi MD olarak kaydet
- PPT'yi MD'ye aktar
- PPTX'yi MD'ye aktar
- Markdown görüntü dışa aktarımı
- CDN görüntü bağlantıları
- PowerPoint
- sunum
- Markdown
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PPT ve PPTX sunumlarını Markdown'a dönüştürün ve dışa aktarılan bitmap, metafile ve SVG görüntülerinin nerede kaydedileceğini ve nasıl başvurulacağını kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, PPT ve PPTX sunumlarını belge, statik site, içerik göçü ve sürüm kontrolü iş akışları için Markdown'a dönüştürebilir. Bir Markdown lezzeti seçebilir, slayt içeriğinin nasıl işleneceğini kontrol edebilir ve dışa aktarılan görüntülerin nerede saklanacağını ve oluşturulan Markdown'un bunlara nasıl başvuracağını belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarma yalnızca metin çıktısı üretir. Görsel içeriği dışa aktarmak için, [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setExportType) yöntemini kullanarak dışa aktarma türünü, [MarkdownExportType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownexporttype/) enumerasyonundaki `Sequential` veya `Visual` değerine ayarlayın. `Sequential`, slayt öğelerini ayrı ayrı ve sırayla işlerken, `Visual` gruplandırılmış öğeleri bir arada tutarak görsel ilişkiyi korur. `TextOnly` değeri görüntü kaynakları üretmez, bu nedenle bu modda görüntü kaydetme geri aramaları tetiklenmez.

## **Bir Sunumu Markdown'a Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) enumerasyonundaki `Md` değeriyle çağırın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Her örnek, geçerli çalışma dizininden `presentation.pptx` dosyasını okur. Örnekleri çalıştırmadan önce Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanı kurun. JVM'yi her Python işlemi için bir kez başlatın.

## **Bir Markdown Lezzeti Seçin**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setFlavor) yöntemi, çıktı için kullanılan Markdown spesifikasyonunu kontrol eder. [Flavor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/flavor/) enumerasyonu CommonMark, GitHub Flavored Markdown ve diğer desteklenen varyantları içerir.

Aşağıdaki örnek bir sunumu CommonMark olarak dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Varsayılan Yerel Kaydetme Davranışıyla Görüntüleri Dışa Aktarma**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görüntüleri yapılandırmak için iki yöntem sağlar:

- [setBasePath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setBasePath) Markdown belgesi ve kaynakları için temel dizini belirler.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) görüntü alt dizinini belirler. Varsayılan değeri `Images`'tır.

Aşağıdaki örnek görsel içeriği işler, görüntüleri `output/assets` klasörüne yazar ve Markdown belgesinde göreli görüntü referansları oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Bu davranış, özel bir görüntü kaydetme işleyicisi `False` döndürdüğünde geri dönüş (fallback) olarak da hizmet eder.

## **Görüntü Kaydetmeyi ve Markdown Bağlantılarını Özelleştirme**

Markdown dışa aktarımı sırasında oluşturulan SVG olmayan bitmap ve metafil kaynakları için bir geri arama kaydetmek üzere [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/) yöntemini kullanın. `MarkdownImageSavingHandler` geri araması, görüntü nesnesini, onun [ImageFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imageformat/) değerini ve oluşturulan Markdown bağlantısını tek elemanlı bir `String[]` parametresi olarak alır. Görüntüyü verilen formatta kaydedin veya yükleyin ve `link[0]` öğesini Markdown çıktısında görünmesi gereken referansla değiştirin.

SVG formatında oluşturulan kaynaklar ayrı şekilde işlenir. [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/) yöntemiyle bir geri arama kaydedin. `MarkdownSvgImageSavingHandler` geri araması, bir [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) nesnesi ve tek elemanlı `String[] link` parametresini alır. SVG'nin `ImageFormat` argümanı yoktur; bunun yerine [SvgImage.getSvgData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/#getSvgData) yönteminden XML verisini yazın veya yükleyin. Dışa aktarım modu ve görsel gruplamaya bağlı olarak, kaynak sunumdaki bir SVG rasterleştirilebilir veya diğer içerikle birleştirilebilir; ortaya çıkan SVG olmayan kaynak daha sonra görüntü kaydetme geri aramasına iletilir. Her dışa aktarılan görsel kaynağın özel işlenmesi gerektiğinde her iki geri aramayı da kaydedin.

İşleyici dönüş değeri, görüntüyü kimin işleyeceğini belirler:

- `True` döndürün; işleyici görüntüyü kaydetti, yükledi, dönüştürdü veya başka bir şekilde işledi ve `link[0]`'a geçerli bir değer atadıktan sonra. Aspose.Slides bu değeri Markdown belgesine yazar ve varsayılan yerel kaydetme işlemini gerçekleştirmez.
- `False` döndürün; böylece Aspose.Slides görüntüyü yerel olarak kaydeder ve bağlantısını [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setBasePath) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) ile ayarlanan değerlere göre oluşturur.

{{% alert color="danger" title="Önemli" %}}
`True` döndüren bir işleyici, görüntünün sorumluluğunu alır. Geçerli ve boş olmayan bir bağlantı atamadan `True` döndürürse, dışa aktarım bir `InvalidOperationException` ile başarısız olur.
{{% /alert %}}

Python'da bu geri aramaları `jpype.JProxy` ile kaydedin; Java geri arama arayüzünü `invoke` yöntemiyle uygulayın. `link` argümanı değiştirilebilir bir Java string dizisidir: işlemden önce `link[0]`'ı bir Python stringine dönüştürün, ardından yerine koyulan URL'yi tekrar `link[0]`'a atayın.

### **Görüntüleri CDN Kaynak Dizini'ne Kaydetme ve Harici URL'ler Kullanma**

Aşağıdaki örnek `cdn-origin/presentations/quarterly-report` dizinini bağlanmış veya senkronize edilmiş bir CDN kaynak dizini olarak kabul eder. Her işleyici, oluşturulan dosya adını alır, görüntüyü bu özel dizine kaydeder ve oluşturulan yerel referansı genel bir CDN URL'siyle değiştirir. Örnek kendisi ağ üzerinden bir yükleme yapmaz: URL, dizin CDN kaynağı olarak bağlandıktan ya da dosyaları CDN'ye yayınlandıktan sonra geçerli olur. Nesne depolama için, dosya sistemi yazmasını depolama SDK'sının yükleme işlemiyle değiştirin ve `link[0]`'ı yalnızca yükleme başarılı olduğunda atayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Bitmap işleyici, 128 × 128 pikselden daha küçük görüntüler için bilerek `False` döndürür; bu nedenle Aspose.Slides bu görüntüleri varsayılan davranışı kullanarak `output/fallback-images` klasörüne kaydeder. Daha büyük bitmap ve metafil kaynakları ile SVG kaynakları özel kod tarafından işlenir. Örneğin, `fallback-images/image1.png` gibi oluşturulan bir yerel referans `https://cdn.example.com/presentations/quarterly-report/image1.png` olur. İşleyiciler dosya yazarken yalnızca işletim sistemi yollarını kullanır; Markdown'a yazılan bağlantılar ise ileri eğik çizgi (`/`) ve URL kodlu dosya adları kullanır. Göreli bağlantılar oluştururken aynı kuralı uygulayın: platforma özgü dizin ayırıcı yerine `/` kullanın.

## **SSS**

**Bir işleyici hem raster görüntüleri hem de SVG görüntüleri işleyebilir mi?**

Hayır. Oluşturulan bitmap ve metafil kaynakları için [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/) yöntemini ve SVG olarak oluşturulan kaynaklar için [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/) yöntemini kullanın. İlki bir görüntü nesnesi ve bir [ImageFormat] değeri sağlar; ikincisi ise SVG verisi [SvgImage.getSvgData] ile okunabilen bir [SvgImage] nesnesi sağlar. Dışa aktarım sırasında rasterleştirilen bir kaynak SVG, görüntü kaydetme geri aramasıyla işlenir.

**Bir image-saving işleyicisi `False` döndürdüğünde ne olur?**

Aspose.Slides varsayılan yerel kaydetme davranışını kullanır. Görüntü konumu ve oluşturulan referans, [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setBasePath) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) ile ayarlanan değerlerle kontrol edilir.

**Bir işleyici görüntüyü yerel olarak kaydetmeden bir URL sağlayabilir mi?**

Evet. İşleyici görüntüyü nesne depolamaya yükleyebilir veya başka bir hizmete yönlendirebilir, elde edilen URL'yi `link[0]`'a atayabilir ve `True` döndürebilir. İşleyicinin işleme sürecini kendisi tamamlaması gerekir; `True` döndürmek varsayılan yerel kaydetmeyi engeller.

**Markdown dışa aktarımı bir işleyiciden neden `InvalidOperationException` atar?**

Bu istisna, işleyicinin `True` döndürdüğü ancak geçerli bir bağlantı sağlamadığı durumlarda ortaya çıkar. `True` döndürmeden önce Markdown'a yazılması gereken göreli yolu veya harici URL'yi `link[0]`'a atayın.

**Görüntü bağlantılarında hangi yol ayırıcı kullanılmalıdır?**

Markdown bağlantılarında ve URL'lerde ileri eğik çizgi (`/`) kullanın. `pathlib.Path`'i yalnızca dosya sistemi yolları için kullanın, ardından Markdown referansını ayrı olarak oluşturun veya normalleştirin.

**Hyperlinkler Markdown dışa aktarımında korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/python-java/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/python-java/slide-transition/) ve [animations](/slides/tr/python-java/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown'a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation] örneğini iş parçacıkları arasında paylaşmayın. [multithreading guidelines](/slides/tr/python-java/multithreading/) yönergelerini izleyin ve her dosya için ayrı bir örnek kullanın.