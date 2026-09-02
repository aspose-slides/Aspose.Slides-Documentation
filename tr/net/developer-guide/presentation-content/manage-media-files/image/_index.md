---
title: Sunumlarda Görüntü Yönetimini .NET'te Optimize Edin
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/net/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- web'den
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- harici SVG kaynakları
- SVG çözücü
- bağlantılı SVG görüntüleri
- SVG yazı tipleri
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument'te görüntü yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha çekici ve görsel olarak etkileyici hâle getirir. Microsoft PowerPoint'te, dosyalardan, internetteki veya diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunum slaytlarına çeşitli yollarla resim eklemenizi sağlar.

{{% alert  title="Tip" color="primary" %}} 

Aspose, görüntülerden hızlı bir şekilde sunum oluşturmanızı sağlayan ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunmaktadır. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırmayı, efekt uygulamayı veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Resim Çerçevesi](/slides/tr/net/picture-frame/) bölümüne bakın. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Görüntüleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [Görüntüyü JPG'ye](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/), [JPG'yi Görüntüye](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/), [JPG'yi PNG'ye](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/), [PNG'yi JPG'ye](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/), [PNG'yi SVG'ye](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/), ve [SVG'yi PNG'ye](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görüntüleri destekler. 

## **Yerel Olarak Depolanan Görüntüleri Slaytlara Ekle**

Bir veya daha fazla yerel depolanan görüntüyü bir sunum slaytına ekleyebilirsiniz. Aşağıdaki C# örnek kodu, bir slayta görüntü eklemenin nasıl yapılacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Web'den Görüntüleri Slaytlara Ekle**

Eğer eklemek istediğiniz görüntü bilgisayarınızda depolanmamışsa, doğrudan web üzerinden ekleyebilirsiniz. 

Aşağıdaki C# örnek kodu, web üzerinden bir slayta görüntü eklemenin nasıl yapılacağını gösterir:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Görselleri Slayt Üstatlarına Ekle**

Bir slayt üstatı, onu kullanan slaytların tema ve düzen gibi bilgilerini saklar ve kontrol eder. Bir slayt üstatına bir görüntü eklendiğinde, bu görüntü o üstatı temel alan tüm slaytlarda görünür. 

Aşağıdaki C# örnek kodu, bir slayt üstatına görüntü eklemenin nasıl yapılacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Görselleri Slayt Arka Planı Olarak Ekle**

Bir veya daha fazla slaytın arka planı olarak bir resim kullanabilirsiniz. Ayrıntılar için *[Görselleri Slaytların Arka Planı Olarak Ayarlama](/slides/tr/net/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **Sunumlara SVG Ekle**

SVG içeriği, bir sunuma [SvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/svgimage/) sınıfı kullanılarak eklenebilir. Ortaya çıkan [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) nesnesi daha sonra sunumun görüntü koleksiyonuna eklenebilir ve bir resim çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki C# örneği, bağımsız bir SVG dizesi içe aktarır. Bu SVG tarafından kullanılan tüm görüntüler, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülür.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Harici Kaynaklarla SVG İçeriğini İçe Aktar**

Tasarıma araçlarından, diyagram editörlerinden, simge sistemlerinden ve web hatlarından dışa aktarılan SVG dosyaları, SVG belgesinin dışında depolanan kaynaklara başvurabilir. Örneğin, bir SVG `images/photo.png` gibi bir görüntü bağlantısı, bir CSS `url(...)` değeri veya bir yazı tipi URL'si içerebilir.

Böyle bir SVG içeriğini içe aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/net/aspose.slides.import/iexternalresourceresolver/) uygulaması oluşturun ve uygun bir `SvgImage` yapıcısına, temel URI ile birlikte iletin. Temel URI, SVG belgesinin konumunu tanımlar ve göreceli bağlantıların çözülmesinde kullanılır.

[ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) arabirimi, içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `SvgContent` SVG işaretlemesini bir dize olarak döndürür.
- `SvgData` SVG içeriğini bir bayt dizisi olarak döndürür.
- `BaseUri` göreceli bağlantılar için kullanılan temel URI'yi döndürür.
- `ExternalResourceResolver` SVG görüntüsüne atanmış çözücüyü döndürür.

### **Harici Kaynak Çözücüyü Uygula**

Çözücünün iki yöntemi vardır:

- [ResolveUri](https://reference.aspose.com/slides/tr/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) temel URI ile bir göreceli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemezse veya izin verilmiyorsa `null` döndürün.
- [GetEntity](https://reference.aspose.com/slides/tr/net/aspose.slides.import/iexternalresourceresolver/getentity/) mutlak bir kaynak URI'si için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya kullanılamıyorsa `null` döndürün. Gerektiğinde bir yedek akış da döndürülebilir.

Aşağıdaki çözücü, yalnızca izin verilen yerel bir dizinden bağlantılı kaynakları yükler. Ağ kaynakları ve izin verilen dizinin dışındaki yollar engellenir. Çözülmemiş görüntü bağlantıları için isteğe bağlı bir yedek görüntü döndürülür.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Bu çözücü kasıtlı olarak yalnızca yerel dosyalara izin verir.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Yedeklemeyi yalnızca görüntü kaynakları için kullanın. Bir görüntü akışı
        // eksik bir font veya stil sayfası için geçerli olmaz.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **SVG İçe Aktarım Sırasında Bağlı Kaynakları Çöz**

`assets/diagram.svg` dosyasının aşağıdaki gibi göreceli bir referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki C# örneği, SVG dosyasının URI'sini temel URI olarak geçirir ve özel bir çözücü sağlar. Çözücü, göreceli görüntü bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'yi işlerken bağlantılı kaynağı içeren bir akış döndürür.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Temel URI, SVG belgesinin konumunu temsil eder.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage, kaynak içeriği, ikili veri, temel URI ve çözücüyü ortaya çıkar.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

`SvgImage` sınıfı ayrıca SVG verilerini bir bayt dizisi veya bir akış olarak, dış kaynak çözücüsü ve temel URI ile birlikte kabul eden aşırı yüklemeler sunar.

{{% alert title="Important" color="warning" %}}

Kaynak çözücü, Aspose.Slides SVG'yi işler ve render ederken harici kaynakların kullanılabilir olmasını sağlar. Orijinal SVG işaretlemesini değiştirmez veya çözülen kaynakları otomatik olarak içine gömme yapmaz.

Bir `ISvgImage` sunumun görüntü koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de bir raster yedek görüntüsü içerebilir. Bağlantılı bir kaynak, oluşturulan yedek görüntüde görünebilirken `images/photo.png` gibi bir göreceli bağlantı depolanan SVG'de değişmeden kalır. Yerel SVG temsili render eden bir uygulama, orijinal dış kaynağa erişilemediğinde bağlantılı içeriği atlayabilir.

{{% /alert %}}

### **Taşınabilir Bir SVG Resmi Oluştur**

Dış dosyalara bağımlı olmayan bir SVG resmi oluşturmak için, `SvgImage` oluşturmadan önce SVG'yi kendi içinde tutarlı hâle getirin. Örneğin, bağlantılı görüntü URL'lerini görüntü verilerini içeren `data:` URI'leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage`'i oluşturun, sunumun görüntü koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenen Kaynakları Yönet**

Bir kaynak URI'si geçersiz, yasaklanmış veya çözülemez olduğunda `ResolveUri`'den `null` döndürün. Kaynak okunamadığında `GetEntity`'den `null` döndürün. Aspose.Slides mümkün olduğunda bu kaynağı olmadan SVG'yi işlemeye devam eder.

Eksik bir kaynak için bir yedek akış döndürülebilir, ancak içeriği talep edilen kaynak türüyle uyumlu olmalıdır. Örneğin, eksik bir görüntü için sadece bir görüntü akışı döndürün; bir yazı tipi veya stil sayfası için değil.

{{% alert title="Security" color="warning" %}}

Güvenilmeyen SVG dosyalarından keyfi dosya yolları veya sınırsız ağ URL'leri çözülmemelidir. İzin verilen şemaları, dizinleri ve hostları kısıtlayın. Ağ kaynakları için ayrıca bağlantı zaman aşımları, yanıt‑boyut sınırlamaları ve içerik doğrulaması uygulanmalıdır.

{{% /alert %}}

## **SVG'yi Bir Şekil Kümesine Dönüştür**
Aspose.Slides, PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir SVG'yi bir şekil kümesine dönüştürebilir:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, bir [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage) nesnesini ilk parametre olarak alan [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection) arabiriminin [AddGroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/addgroupshape/methods/1) metodunun bir aşırı yüklemesi tarafından sağlanır.

Aşağıdaki C# örnek kodu, bu yöntemi kullanarak bir SVG dosyasını bir şekil kümesine dönüştürmenin nasıl yapılacağını gösterir:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Kaynak SVG dosya adı
string svgFileName = "sample.svg";

// Çıktı sunum dosya adı
string outPptxPath = "presentation.pptx";

// Yeni bir sunum oluştur
using (IPresentation presentation = new Presentation())
{
    // SVG dosya içeriğini oku
    string svgContent = File.ReadAllText(svgFileName);

    // Bir SvgImage nesnesi oluştur
    ISvgImage svgImage = new SvgImage(svgContent);

    // Slayt boyutunu al
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG görüntüsünü bir şekil grubuna dönüştür ve slayt boyutuna ölçeklendir
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Sunumu PPTX formatında kaydet
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Görselleri EMF Olarak Slaytlara Ekle**
Aspose.Slides for .NET, Aspose.Cells ile Excel çalışma sayfalarından EMF görselleri oluşturmanıza ve bunları sunum slaytlarına eklemenize olanak tanır.

Aşağıdaki C# örnek kodu, bu işlemin nasıl yapılacağını gösterir:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Çalışma kitabını bir akısa kaydet
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Görsel Koleksiyonundaki Görselleri Değiştir**

Aspose.Slides, bir sunumun görüntü koleksiyonunda depolanan görselleri, slayt şekilleri tarafından kullanılan görseller dahil, değiştirebilmenizi sağlar. Bu bölüm, koleksiyonda görselleri güncellemenin çeşitli yollarını açıklar. Bir görseli ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut başka bir görsel kullanarak değiştirebilirsiniz.

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Yeni bir görseli bir dosyadan bayt dizisine yükleyin.
3. Hedef görseli yeni görsel ile bayt dizisini kullanarak değiştirin.
4. İkinci yöntemde, görseli bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesne ile değiştirin.
5. Üçüncü yöntemde, hedef görseli sunumun görüntü koleksiyonunda zaten mevcut bir görsel ile değiştirin.
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunumu temsil eden Presentation sınıfının bir örneğini oluştur.
using Presentation presentation = new Presentation("sample.pptx");

// İlk yol.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// İkinci yol.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Üçüncü yol.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Sunumu bir dosyaya kaydet.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Aspose'un ücretsiz [Metni GIF'e] (https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü sayesinde metni kolayca canlandırabilir ve metinden GIF'ler oluşturabilirsiniz. 

{{% /alert %}}

## **SSS**

**Girişteki resim çözünürlüğü ekleme sonrası aynı kalır mı?**

Evet. Kaynak piksel değerleri korunur, ancak nihai görünüm, slayttaki [picture](/slides/tr/net/picture-frame/) nasıl ölçeklendiğine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Onlarca slaytta aynı logoyu bir anda değiştirmek için en iyi yol nedir?**

Logoyu master slayta veya bir yerleşime yerleştirin ve sunumun görüntü koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilir, ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden fazla slaytın arka planı olarak aynı anda nasıl ayarlayabilirim?**

Resmi master slaytta veya ilgili yerleşimde arka plan olarak atayın; bu master/yerleşimi kullanan tüm slaytlar arka planı devralır.

**Bir sunumun çok sayıda resim nedeniyle çok büyük olmasını nasıl engellerim?**

Tek bir görüntü kaynağını yeniden kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve gerektiğinde tekrarlanan grafiklerini master’da tutun.