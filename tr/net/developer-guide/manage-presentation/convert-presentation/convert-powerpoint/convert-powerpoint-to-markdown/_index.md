---
title: PowerPoint Sunumlarını .NET'te Markdown'a Dönüştür
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştürme
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'ten MD'ye
- PowerPoint'i Markdown olarak kaydet
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
- .NET
- C#
- Aspose.Slides
description: "PPT ve PPTX sunumlarını .NET'te Markdown'a dönüştürün ve dışa aktarılan bitmap, metafile ve SVG görüntülerinin nerede kaydedileceğini ve nasıl referans verileceğini kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for .NET, PPT ve PPTX sunumlarını belgelemeye, statik siteye, içerik taşıma ve sürüm kontrolü iş akışlarına uygun Markdown'a dönüştürebilir. Bir Markdown çeşidini seçebilir, slayt içeriğinin nasıl oluşturulacağını kontrol edebilir ve dışa aktarılan görsellerin nerede depolanacağını ve oluşturulan Markdown'ın bunlara nasıl referans vermesini belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarma sadece metin çıkışı kullanır. Görsel içeriği dışa aktarmak için, [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/exporttype/) özelliğini [MarkdownExportType] enum'ında bulunan `Sequential` veya `Visual` değerlerinden birine ayarlayın. `Sequential`, slayt öğelerini ayrı ayrı ve sırayla render ederken, `Visual` görsel ilişkilerini korumak için gruplanmış öğeleri bir arada tutar. `TextOnly` değeri görüntü kaynakları üretmez, bu nedenle bu modda görüntü kaydetme olayları tetiklenmez.

## **Bir Sunumu Markdown'a Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini, [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) enum'undan `Md` değeriyle çağırın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Bir Markdown Çeşidi Seçin**

[MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/flavor/) özelliği, çıktıda kullanılan Markdown spesifikasyonunu kontrol eder. [Flavor](https://reference.aspose.com/slides/tr/net/aspose.slides.export/flavor/) enum'ı CommonMark, GitHub Flavored Markdown ve diğer desteklenen varyantları içerir.

Aşağıdaki örnek bir sunumu CommonMark olarak dışa aktarır:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Varsayılan Yerel Kaydetme Davranışıyla Görselleri Dışa Aktarma**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görseller için iki özellik sağlar:

- [BasePath](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/basepath/) Markdown belgesi ve kaynakları için temel dizini belirtir.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) görsel alt dizinini belirtir. Varsayılan değeri `Images`.

Aşağıdaki örnek görsel içeriği render eder, görselleri `output/assets` dizinine yazar ve Markdown belgesinde göreli görsel referansları oluşturur:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Bu davranış, özel bir görüntü kaydetme işleyicisi `false` döndürdüğünde geri dönüş olarak da hizmet verir.

## **Görsel Kaydetmeyi ve Markdown Bağlantılarını Özelleştirme**

Markdown dışa aktarımı sırasında üretilen SVG olmayan bitmap ve metafile kaynakları için [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/imagesaving/) olayını kullanın. Bu olayın [MarkdownImageSavingHandler](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) temsilcisi, [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesini, onun [ImageFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/) değerini ve oluşturulan Markdown bağlantısını `ref string` parametresi olarak alır. Görseli verilen formatta kaydedin veya yükleyin ve `link` değişkenini Markdown çıktısında yer alması gereken referansla değiştirin.

SVG formatında üretilen kaynaklar ayrı olarak işlenir. [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) olayına abone olun; bu olayın [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) temsilcisi bir [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) nesnesi ve `ref string link` parametresini alır. Bir SVG'nin `ImageFormat` argümanı yoktur; bunun yerine [ISvgImage.SvgData](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/svgdata/) özelliğinden XML verisini yazın veya yükleyin. Dışa aktarma modu ve görsel gruplamaya bağlı olarak, kaynak sunumdaki bir SVG rasterleştirilebilir veya diğer içeriklerle birleştirilebilir; ortaya çıkan SVG dışı kaynak daha sonra `ImageSaving` e gönderilir. Her dışa aktarılan görsel kaynağın özel işlenmesi gerektiğinde her iki olaya da abone olun.

İşleyicinin dönüş değeri, görüntünün kim tarafından işleneceğini belirler:

- İşleyici görüntüyü kaydettikten, yükledikten, dönüştürdükten veya başka bir şekilde işledikten ve `link`e geçerli bir değer atadıktan sonra `true` döndürün. Aspose.Slides bu değeri Markdown belgesine yazar ve varsayılan yerel kaydetme işlemini yapmaz.
- `false` döndürerek Aspose.Slides'in görüntüyü yerel olarak kaydetmesine ve bağlantıyı [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/basepath/) ve [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/)'a göre oluşturmasına izin verin.

{{% alert color="warning" title="Important" %}}
Bir işleyici `true` döndürdüğünde görselin sorumluluğunu alır. Geçerli ve boş olmayan bir bağlantı atamadan `true` döndürürse, dışa aktarma `InvalidOperationException` hatası ile başarısız olur.
{{% /alert %}}

### **Görselleri bir CDN Köken Dizini'ne Kaydedin ve Harici URL'ler Kullanın**

Aşağıdaki örnek `cdn-origin/presentations/quarterly-report` dizinini monte edilmiş veya senkronize bir CDN köken dizini olarak değerlendirir. Her işleyici oluşturulan dosya adını alır, görseli bu özel dizine kaydeder ve oluşturulan yerel referansı halka açık bir CDN URL'siyle değiştirir. Örnek kendisi ağ üzerinden bir yükleme yapmaz: URL, dizin CDN kökeni olarak monte edildikten veya dosyalar CDN'e yayınlandıktan sonra geçerli olur. Nesne depolama için, dosya sistemi yazımını depolama SDK'sının yükleme operasyonu ile değiştirin ve `link`i yalnızca yükleme başarılı olduğunda atayın.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Bitmap işleyici, 128 × 128 pikselden daha küçük görseller için kasıtlı olarak `false` döndürür; böylece Aspose.Slides bu görselleri varsayılan davranışı kullanarak `output/fallback-images` dizinine kaydeder. Daha büyük bitmap ve metafile kaynakları ile SVG kaynakları özel kod tarafından işlenir. Örneğin, `fallback-images/image1.png` gibi oluşturulan bir yerel referans `https://cdn.example.com/presentations/quarterly-report/image1.png` haline gelir. İşleyiciler dosya yazarken yalnızca işletim sistemi yollarını kullanır; Markdown'a yazılan bağlantılar ileri eğik çizgi (`/`) ve URL kodlamalı dosya adları kullanır. Göreli bağlantılar oluştururken aynı kuralı uygulayın: platforma özgü dizin ayırıcı yerine `/` kullanın.

## **SSS**

**Bir işleyici raster görüntüleri ve SVG görüntülerini birlikte işleyebilir mi?**

Hayır. Üretilen bitmap ve metafile kaynakları için [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/imagesaving/); SVG olarak üretilen kaynaklar için [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) kullanın. İlki bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesi ve bir [ImageFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/) sunar; ikincisi ise SVG verisi [ISvgImage.SvgData](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/svgdata/) üzerinden okunabilen bir [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) nesnesi sunar. Dışa aktarım sırasında rasterleştirilen bir kaynak SVG, bunun yerine `ImageSaving` tarafından işlenir.

**Bir görüntü kaydetme işleyicisi `false` döndürdüğünde ne olur?**

Aspose.Slides varsayılan yerel kaydetme davranışını kullanır. Görselin konumu ve oluşturulan referans [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/basepath/) ve [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/tr/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) tarafından kontrol edilir.

**Bir işleyici görseli yerel olarak kaydetmeden bir URL sağlayabilir mi?**

Evet. İşleyici görseli nesne depolamaya yükleyebilir ya da başka bir hizmete iletebilir, ortaya çıkan URL'yi `link`e atayabilir ve `true` döndürebilir. İşleyicinin işlemi kendisi tamamlaması gerekir; `true` döndürmek varsayılan yerel kaydetmeyi engeller.

**Markdown dışa aktarımı bir işleyiciden `InvalidOperationException` hatası atmasının nedeni nedir?**

Bu istisna, işleyici `true` döndürdüğünde geçerli bir bağlantı sağlamadığında ortaya çıkar. `true` döndürmeden önce Markdown'a yazılması gereken göreli yolu veya harici URL'yi atayın.

**Görsel bağlantıları hangi yol ayırıcıyı kullanmalıdır?**

Markdown bağlantılarında ve URL'lerde ileri eğik çizgi (`/`) kullanın. Dosya sistemi yolları için yalnızca `Path.Combine` kullanın, ardından Markdown referansını ayrı olarak oluşturun veya normalleştirin.

**Markdown dışa aktarımı sırasında köprüler korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/net/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/net/slide-transition/) ve [animations](/slides/tr/net/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown'a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini thread'ler arasında paylaşmayın. [multithreading guidelines](/slides/tr/net/multithreading/) yönergelerini izleyin ve her dosya için ayrı bir örnek kullanın.