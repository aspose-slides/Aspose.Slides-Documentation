---
title: Sunum Slide Master'larını .NET'te Yönet
linktitle: Slide Master
type: docs
weight: 80
url: /tr/net/slide-master/
keywords:
- slide master
- master slide
- PPT master slide
- çoklu master slide
- master slide'ları karşılaştır
- arka plan
- yer tutucu
- master slide kopyala
- master slide kopyala
- master slide çoğalt
- kullanılmayan master slide
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te slide master'ları yönetin: PowerPoint ve OpenDocument sunumlarındaki master slide'lara erişin, düzenleyin, kopyalayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

**Slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarlarını içerebilir. PowerPoint’te, bir slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for .NET aynı modeli destekler. Bir sunum bir veya daha fazla master slide içerebilir ve her master slide birkaç layout slide içerebilir. Normal slide'lar genellikle doğrudan bir master slide'a başvurmaz. Bunun yerine, normal bir slide bir layout slide kullanır ve bu layout slide bir master slide'a aittir.

Hiyerarşi şu şekildedir:

1. **Slide master** - ortak tasarımı ve temayı tanımlar.
1. **Layout slide** - yer tutucuların ve düzen seviyesindeki biçimlendirmelerin belirli bir düzenini tanımlar.
1. **Normal slide** - gerçek sunum içeriğini içerir ve bir layout slide kullanır.

![Master slide'ların, layout slide'ların ve normal slide'ların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides'de bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) arayüzü ile temsil edilir. Bir sunumdaki tüm master slide'lar, [Presentation.Masters](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/masters/) koleksiyonu aracılığıyla kullanılabilir; bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/) arayüzünü uygular.

{{% alert color="info" title="Inheritance" %}}
Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir master slide ve bir layout slide her ikisi de bir arka plan tanımlarsa, o layout'a dayalı slaytlar layout arka planını kullanır. Layout slide'lar hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/net/slide-layout/) sayfasına bakın.
{{% /alert %}}

## **Slide Master'lara Erişim**

PowerPoint'te, **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides'de master slide'lara erişmek için `Masters` koleksiyonunu kullanın:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Ayrıca bir normal slide'ın kullandığı master slide'ı, layout'u üzerinden alabilirsiniz:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Bir Slide Master'ın İçeriği**

Bir master slide, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/) arayüzünü uygular, bu sayede normal ve layout slide'larında kullanılan birçok aynı slayt özelliğini sunar. Master'a özgü üyeler, [IMasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) API sayfasında listelenir.

Sıkça kullanılan master slide üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `Background` | Master seviyesindeki slayt arka planını ayarlar. |
| `Shapes` | Logolar, resim çerçeveleri ve paylaşılan metin gibi master üzerine yerleştirilen şekilleri depolar. |
| `LayoutSlides` | Master'a ait layout slide'ları depolar. |
| `ThemeManager` | Master tema API'lerine erişim sağlar. |
| `HeaderFooterManager` | Master ve onun alt layout'ları için üstbilgi, altbilgi, tarih ve slayt numaralarını kontrol eder. |
| `GetDependingSlides` | Layout'ları aracılığıyla master'a bağımlı olan normal slide'ları döndürür. |

## **Slide Master'a Resim Ekleme**

Bir master slide'a resim eklediğinizde, o master'ın layout'larını kullanan slaytlarda görünür. Bu, logolar, filigranlar, süsleyici bantlar ve diğer tekrarlanan görsel öğeler için kullanışlıdır.

Aşağıdaki örnek, ilk master slide'a bir logo ekler:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/net/picture-frame/) sayfasına bakın.

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slide'larda tanımlanır. Master slide, bu layout'ların devraldığı ortak stil ve temayı sağlar, her layout ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandığını belirler.

PowerPoint'te, yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümünde Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master'a ait layout slide ile çalışın:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Master slide'da zaten bulunan yer tutucu şekilleri de biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer bir degrade dolgu uygular:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Normal slaytlar tarafından devralınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/net/manage-placeholder/) ve [Text Formatting](/slides/tr/net/text-formatting/) sayfalarına bakın.

## **Slide Master Arka Planını Değiştirme**

Master arka planı, onu geçersiz kılmayan layout ve slaytlar tarafından devralınır. Aşağıdaki örnek, ilk master slide için katı bir arka plan rengi ayarlar:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

İlgili konular için [Presentation Background](/slides/tr/net/presentation-background/) ve [Presentation Theme](/slides/tr/net/presentation-theme/) sayfalarına bakın.

## **Slide Master'ı Başka Bir Sunuma Kopyalama**

[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) metodunu kullanarak bir master slide'ı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Master'ı ile birlikte normal slaytları da kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/net/clone-slides/) sayfasına bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden fazla master slide içerebilir. Bu, farklı bölümlerin farklı marka, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![Master slide ekleme ve yönetme için PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master'ı kopyalar, kopyaya farklı bir arka plan verir, o kopyalanmış master altında bir layout oluşturur ve o layout'a dayalı yeni bir slayt ekler:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Slide Master'ları Karşılaştırma**

Master slide'lar, [IBaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/) tarafından devralınan `Equals` metodu ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/net/compare-slides/) sayfasına bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/) üzerindeki `LastView` özelliğini kullanarak PowerPoint'in ilk açtığı görünümü kontrol edebilirsiniz. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/net/save-presentation/) sayfasına bakın.

## **Kullanılmayan Master Slide'ları Kaldırma**

Sunumlarda bazen, hiçbir normal slayt tarafından kullanılmayan master slide'lar bulunur. Kullanılmayan master'ları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

Kullanılmayan master'ları `Masters` koleksiyonundan kaldırmak için [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/tr/net/aspose.slides/masterslidecollection/removeunused/) metodunu kullanın:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Ayrıca düşük kodlu [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) metodunu da kullanabilirsiniz:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **SSS**

**Slide master ile layout slide arasındaki fark nedir?**

Bir slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi paylaşılan tasarım ayarlarını tanımlar. Bir layout slide, bir master slide'a aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slide kullanır, bu nedenle hem layout'tan hem de master'dan devralır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden fazla slide master içerebilir. Farklı bölümlerin farklı görsel sistemler veya markalama gerektirdiği durumlarda birden çok master kullanın.

**Yer tutucuları bir master slide'a mı yoksa bir layout slide'a mı eklemeliyim?**

Çoğu durumda, yer tutucuları layout slide'lara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi master slide'a koyun, ardından içerik yer tutucularını normal slaytların kullanacağı layout'lara yerleştirin.

**Hâlâ kullanılan bir master slide'ı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slide doğrudan güvenli bir şekilde silinemez. Önce bu slaytları başka bir master altında layout'lara taşıyın veya yalnızca kullanılmayan master'ları kaldıran temizlik yöntemini kullanın.