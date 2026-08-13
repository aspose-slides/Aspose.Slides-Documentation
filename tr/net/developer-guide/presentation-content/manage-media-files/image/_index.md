---
title: .NET'te Sunumlarda Görüntü Yönetimini Optimize Edin
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
- arkaplan
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

Görseller, sunumları daha çekici ve görsel olarak etkileyici hâle getirir. Microsoft PowerPoint'te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunum slaytlarına çeşitli yollarla resim eklemenizi sağlar.

{{% alert  title="İpucu" color="info" %}} 

Aspose, görüntülerden hızlı bir şekilde sunumlar oluşturmanızı sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}

Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırmayı, efekt eklemeyi veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](/slides/tr/net/picture-frame/) sayfasına bakın. 

{{% /alert %}} 

{{% alert title="Not" color="warning" %}}

Görüntüleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [image to JPG](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/), ve [SVG to PNG](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlarda görüntüleri destekler. 

## **Yerel Olarak Saklanan Görüntüleri Slaytlara Ekle**

Bilgisayarınızda depolanan bir veya daha fazla resmi bir sunum slaytına ekleyebilirsiniz. Aşağıdaki C# örnek kodu bir resmi slayta eklemenin nasıl yapılacağını gösterir:

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

Bir slayta eklemek istediğiniz görüntü bilgisayarınızda depolanmamışsa, doğrudan web üzerinden ekleyebilirsiniz. 

İşte aşağıdaki C# örnek kodu, bir resmi web üzerinden slayta eklemenin nasıl yapılacağını gösterir:

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

## **Görselleri Slayt Ana Şablonlarına Ekle**

Bir slayt ana şablonu, kullandığı slaytların teması ve düzeni gibi bilgileri saklar ve kontrol eder. Bir resmi slayt ana şablonuna eklediğinizde, bu resim o ana şablona dayanan her slaytta görünür. 

Aşağıdaki C# örnek kodu, bir resmi slayt ana şablonuna eklemenin nasıl yapılacağını gösterir:

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

## **Görselleri Slayt Arkaplanı Olarak Ekle**

Bir veya daha fazla slayt için arkaplan resmi olarak bir görsel kullanabilirsiniz. Ayrıntılar için *[Setting Images as Backgrounds for Slides](/slides/tr/net/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **Sunumlara SVG Ekle**

SVG içeriği, bir sunuma [SvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/svgimage/) sınıfı kullanılarak eklenebilir. Ortaya çıkan [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) nesnesi daha sonra sunumun görüntü koleksiyonuna eklenebilir ve bir resim çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki C# örneği, kendi içinde bütünleşik bir SVG dizesini içe aktarır. Bu SVG tarafından kullanılan tüm görüntüler, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülür.

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

## **Dış Kaynaklarla SVG İçeriği İçe Aktar**

Tasarım araçlarından, diyagram düzenleyicilerinden, simge sistemlerinden ve web işlem hatlarından dışa aktarılan SVG dosyaları, SVG belgesinin dışında depolanan kaynaklara referans verebilir. Örneğin, bir SVG `images/photo.png` gibi bir görüntü bağlantısı, bir CSS `url(...)` değeri veya bir yazı tipi URL'si içerebilir.

Bu tür SVG içeriğini içe aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/net/aspose.slides.import/iexternalresourceresolver/) uygulaması oluşturun ve bunu temel URI ile birlikte uygun bir `SvgImage` oluşturucusuna geçirin. Temel URI, SVG belgesinin konumunu belirler ve göreceli bağlantıların çözülmesinde kullanılır.

[ISvgImage] arayüzü, içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `SvgContent` SVG işaretlemesini bir dize olarak döndürür.
- `SvgData` SVG içeriğini bir bayt dizisi olarak döndürür.
- `BaseUri` göreceli bağlantılar için kullanılan temel URI'yi döndürür.
- `ExternalResourceResolver` SVG görüntüsüne atanmış çözümleyiciyi döndürür.

### **Dış Kaynak Çözümleyicisi Uygulayın**

Çözümleyicinin iki yöntemi vardır:

- [ResolveUri](https://reference.aspose.com/slides/tr/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) temel URI ile göreceli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemez veya izin verilmiyorsa `null` döndürün.
- [GetEntity](https://reference.aspose.com/slides/tr/net/aspose.slides.import/iexternalresourceresolver/getentity/) mutlak bir kaynak URI'si için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya kullanılamazsa `null` döndürün. Gerekli olduğunda bir yedek akış da döndürülebilir.

Aşağıdaki çözümleyici, yalnızca izin verilen yerel bir dizinden bağlanmış kaynakları yükler. Ağ kaynakları ve izin verilen dizin dışındaki yollar engellenir. Çözülmemiş görüntü bağlantıları için isteğe bağlı bir yedek resim döndürülür.

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

        // Bu çözümleyici kasıtlı olarak yalnızca yerel dosyalara izin verir.
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

        // Yalnızca görüntü kaynakları için bir yedek kullanın. Bir görüntü akışı döndürmek
        // eksik bir yazı tipi veya stil sayfası için geçerli olmaz.
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

### **SVG İçe Aktarımı Sırasında Bağlı Kaynakları Çözümle**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreceli referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki C# örneği, SVG dosyasının URI'sini temel URI olarak geçirir ve özel bir çözümleyici sağlar. Çözümleyici, göreceli görüntü bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'i işlerken bağlı kaynağı içeren bir akış döndürür.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// SVG belgesinin konumunu temsil eden temel URI.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage, kaynak içeriği, ikili veri, temel URI ve çözümleyiciyi ortaya çıkarır.
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

`SvgImage` sınıfı ayrıca SVG verisini bir bayt dizisi veya akış olarak kabul eden, dış kaynak çözümleyicisi ve temel URI ile birlikte kullanılan aşırı yüklemeler sunar.

{{% alert title="Önemli" color="warning" %}}

Kaynak çözümleyici, Aspose.Slides SVG'i işler ve render ederken dış kaynakların kullanılabilir olmasını sağlar. Orijinal SVG işaretlemesini değiştirmez veya çözülen kaynakları otomatik olarak içine gömme yapmaz.

Bir `ISvgImage` sunumun görüntü koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de bir raster yedek görüntü içerebilir. Bağlı bir kaynak, oluşturulan yedek görüntüde görünebilirken, `images/photo.png` gibi bir göreceli bağlantı depolanmış SVG içinde değişmeden kalır. Yerel SVG temsiliyi render eden bir uygulama, orijinal dış kaynak kullanılamaz olduğunda bağlı içeriği atlayabilir.

{{% /alert %}}

### **Taşınabilir Bir SVG Resmi Oluştur**

Harici dosyalara bağımlı olmayan bir SVG resmi oluşturmak için, `SvgImage` oluşturulmadan önce SVG'yi kendi içinde bütünleşik hâle getirin. Örneğin, bağlanan resim URL'lerini görüntü verisini içeren `data:` URI'leri ile değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra, `SvgImage` oluşturun, onu sunumun görüntü koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenen Kaynakları Ele Al**

`ResolveUri` metodundan, bir kaynak URI'si geçersiz, yasak veya çözülemez olduğunda `null` döndürün. `GetEntity` metodundan, kaynak okunamadığında `null` döndürün. Aspose.Slides mümkün olduğunda bu kaynağı olmadan SVG işlemesine devam eder.

Eksik bir kaynak için bir yedek akış döndürülebilir, ancak içeriği istenen kaynak türüyle uyumlu olmalıdır. Örneğin, yalnızca eksik bir görüntü için bir görüntü akışı döndürün; bir yazı tipi veya stil sayfası için değil.

{{% alert title="Güvenlik" color="warning" %}}

Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya sınırsız ağ URL'leri çözümlemeyin. İzin verilen şemaları, dizinleri ve ana bilgisayarları kısıtlayın. Ağ kaynakları için ayrıca bağlantı zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması uygulayın.

{{% /alert %}}

## **SVG'yi Bir Şekil Setine Dönüştür**
Aspose.Slides, bir SVG'yi PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir şekil setine dönüştürebilir:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, bir [ISvgImage] nesnesini ilk parametre olarak alan [AddGroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/addgroupshape/methods/1) metodunun, [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection) arayüzündeki bir aşırı yüklemesi tarafından sağlanır.

Aşağıdaki C# örnek kodu, bu yöntemi kullanarak bir SVG dosyasını şekil setine dönüştürmenin nasıl yapılacağını gösterir:

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

    // SVG görüntüsünü şekil grubuna dönüştür ve slayt boyutuna ölçekle
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Sunumu PPTX formatında kaydet
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Görselleri EMF Olarak Slaytlara Ekle**
Aspose.Slides for .NET, Aspose.Cells ile Excel çalışma sayfalarından EMF görüntüleri oluşturmanıza ve bunları sunum slaytlarına eklemenize olanak tanır.

Aşağıdaki C# örnek kodu, bunu nasıl yapacağınızı gösterir:

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

    // Çalışma kitabını bir akışa kaydet
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

## **Görüntü Koleksiyonundaki Görselleri Değiştir**
Aspose.Slides, bir sunumun görüntü koleksiyonunda depolanan, slayt şekilleri tarafından kullanılan görüntüler dahil, görselleri değiştirmenizi sağlar. Bu bölüm, koleksiyondaki görüntüleri güncellemenin çeşitli yollarını açıklar. Bir görüntüyü ham bayt verisi, bir [IImage] örneği veya koleksiyonda zaten var olan başka bir görüntü kullanarak değiştirebilirsiniz.

İşlemleri aşağıdaki adımları izleyerek gerçekleştirin:

1. Görüntü içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile yükleyin.
1. Yeni bir görüntüyü dosyadan bayt dizisine yükleyin.
1. Hedef görüntüyü yeni görüntü ile bayt dizisini kullanarak değiştirin.
1. İkinci yaklaşımda, görüntüyü bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesine yükleyin ve hedef görüntüyü bu nesneyle değiştirin.
1. Üçüncü yaklaşımda, hedef görüntüyü sunumun görüntü koleksiyonunda zaten var olan bir görüntü ile değiştirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
using Presentation presentation = new Presentation("sample.pptx");

// İlk yöntem.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// İkinci yöntem.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Üçüncü yöntem.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Sunumu bir dosyaya kaydet.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Bilgi" color="info" %}}

Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca canlandırabilir ve metinden GIF'ler oluşturabilirsiniz. 

{{% /alert %}}

## **SSS**

**Ekleme sonrasında orijinal görüntü çözünürlüğü aynı kalır mı?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayttaki [picture](/slides/tr/net/picture-frame/) nasıl ölçeklendirildiğine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Onlarca slaytta aynı logoyu bir kerede değiştirmek için en iyi yol nedir?**

Logoyu ana slayta veya bir düzene yerleştirin ve sunumun görüntü koleksiyonunda değiştirin—güncellemeler o kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilir ve ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi aynı anda birden fazla slaytın arka planı olarak nasıl ayarlayabilirim?**

[Görüntüyü arka plan olarak atayın](/slides/tr/net/presentation-background/) ana slaytta veya ilgili düzende—bu ana/slayt düzenini kullanan tüm slaytlar arka planı devralır.

**Çok sayıda resim nedeniyle bir sunumun çok büyük olmasını nasıl önleyebilirim?**

Aynı görüntüyü birden çok kez kullanmak yerine tek bir görüntü kaynağını yeniden kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve tekrarlanan grafikleri gerektiğinde ana slaytta tutun.