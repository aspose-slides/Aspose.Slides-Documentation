---
title: .NET'te Sunum Slide Master'larını Yönet
linktitle: Slayt Ustası
type: docs
weight: 80
url: /tr/net/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slaytı
- birden çok master slayt
- master slaytları karşılaştır
- arka plan
- yer tutucu
- master slaytı klonla
- master slaytı kopyala
- master slaytı çoğalt
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarında master slaytlarına erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve altbilgi ayarları içerebilir. PowerPoint’te, slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan bir sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for .NET aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birkaç layout slayt barındırabilir. Normal slaytlar doğrudan bir master slayta referans vermez. Bunun yerine, normal bir slayt bir layout slayt kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şudur:

1. **Slide master** – ortak tasarım ve temayı tanımlar.
1. **Layout slide** – yer tutucuların ve layout‑seviyesi biçimlendirmenin belirli bir düzenini tanımlar.
1. **Normal slide** – gerçek sunum içeriğini içerir ve bir layout slayt kullanır.

![master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’te bir slide master, [IMasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) arayüzüyle temsil edilir. Bir sunumdaki tüm master slaytlar, [Presentation.Masters](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/masters/) koleksiyonu aracılığıyla erişilebilir ve bu koleksiyon [IMasterSlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/) arayüzünü uygular.

{{% alert color="info" title="Kalıtım" %}}

Aynı özellik birden fazla seviyede tanımlandığında, daha spesifik seviye kazanır. Örneğin, bir master slayt ve bir layout slayt aynı arka planı tanımlıyorsa, o layout’a dayalı slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/net/slide-layout/) bölümüne bakın.

{{% /alert %}}

## **Slayt Ustalarına Erişim**

PowerPoint’te **View** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’te master slaytlara erişmek için `Masters` koleksiyonunu kullanın:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Ayrıca bir normal slaytın kullandığı master slaytı, onun layout’u üzerinden alabilirsiniz:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Bir Slayt Ustası Neler İçerir**

Bir master slayt, slayt benzeri bir nesnedir. [IBaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/) arayüzünü uyguladığı için, normal ve layout slaytlarda kullanılan birçok aynı slayt özelliğine sahiptir. Master‑özel üyeler [IMasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslide/) API sayfasında listelenir.

Sık kullanılan master slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `Background` | Master‑seviyesinde slayt arka planını ayarlar. |
| `Shapes` | Master üzerine yerleştirilen logolar, resim çerçeveleri ve ortak metin gibi şekilleri depolar. |
| `LayoutSlides` | Master’a ait layout slaytları depolar. |
| `ThemeManager` | Master tema API’lerine erişim sağlar. |
| `HeaderFooterManager` | Master ve onun alt layoutları için başlık, altbilgi, tarih ve slayt numaralarını kontrol eder. |
| `GetDependingSlides` | Layoutları aracılığıyla master’a bağlı normal slaytları döndürür. |

## **Bir Slayt Ustasına Resim Ekleme**

Bir master slayta resim eklediğinizde, o master’dan layout kullanan slaytlarda görüntülenir. Logo, filigran, dekoratif şerit ve diğer tekrarlayan görsel öğeler için kullanışlıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Master Grafiklerinin Görünürlüğünü Kontrol Etme**

[Müşteriler] inherited master graphics, such as logos or decorative shapes, can be hidden without deleting them from the master using [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/showmastershapes/). Set [Slide.ShowMasterShapes](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/showmastershapes/) to `false` on the slide that should omit those graphics and keep it `true` on slides that should display them.

Aşağıdaki bağımsız örnek, bir master’da mavi bir dekoratif şerit oluşturur ve aynı boş layout‑u kullanan iki slaytta farklı görünürlük ayarları uygular. İlk slaytta şerit görünür, ikincisinde gizlenir. Giriş sunumu veya resim gerektirmez.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Örnek, yeni bir sunumla gelen **Blank** layout‑u kullanır ve başlangıç slaytının kendi yer tutucularını kaldırır.

### **Ayarın Kapsamını Seçin**

Normal bir slayt, [ISlide.LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/layoutslide/) ve [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ilayoutslide/masterslide/) aracılığıyla master’ına erişir. Özelliği tek bir slayt üzerinde ayarlamak sadece o slaytı etkiler. [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslide/showmastershapes/) `false` olarak ayarlandığında, ortak layout’u kullanan tüm slaytlarda master grafikleri gizlenir; kendi ayarı `true` olsa bile. Tek bir slaytta grafikleri gizlemek için slayt özelliğini değiştirin ve ortak layout‑u değiştirmeyin.

Bu ayar, master slaytın kendisinde görünürlük kontrolü olarak desteklenmez. Master üzerinde her zaman `false` döner ve `true` atanması `NotSupportedException` oluşturur. Bunu normal bir slayt ya da layout üzerinde uygulayın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etkisi |
| --- | --- |
| Master grafiklerini gizle | Master’dan kalıtılan şekilleri silmeden veya slaytın kendi şekillerini değiştirmeden görünürlüğünü kontrol eder. |
| Slayt arka plan dolgusunu değiştir | Arka plan rengini, degradeyi veya resmi değiştirir. Master grafikleri ayrı şekiller olduğundan, bu arka planın üstünde görünmeye devam edebilir. [Presentation Background](/slides/tr/net/presentation-background/) bölümüne bakın. |
| Master’dan bir şekli sil | Paylaşılan kaynak şekli kaldırır; bu master’ı kullanan hiçbir slayt artık o şekle erişemez. |

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layout’ların miras aldığı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların mevcut olduğunu ve nerelerde konumlandırılacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümünde Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master’a ait layout slaytıyla çalışın:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Ayrıca master slaytta zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve doğrusal bir degrade doldurması uygular:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Normal slaytlar tarafından miras alınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/net/manage-placeholder/) ve [Text Formatting](/slides/tr/net/text-formatting/) bölümlerine bakın.

## **Bir Slayt Ustasının Arka Planını Değiştirme**

Master arka planı, üzerine yazılan layout ve slaytlar tarafından geçersiz kılınmadıkça miras alınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

İlgili konular için [Presentation Background](/slides/tr/net/presentation-background/) ve [Presentation Theme](/slides/tr/net/presentation-theme/) bölümlerine bakın.

## **Bir Slaytı Başka Bir Sunuma Kopyalama**

[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/imasterslidecollection/addclone/) kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Normal slaytları onların master’larıyla birlikte kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/net/clone-slides/) bölümüne bakın.

## **Birden Çok Slayt Ustası Ekleme**

Bir sunum birden çok master slayt içerebilir. Bu, farklı bölümlerin farklı markalama, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![Master slayt ekleme ve yönetme PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master’ı klonlar, klona farklı bir arka plan verir, bu klon master altında bir layout oluşturur ve bu layout’a dayalı yeni bir slayt ekler:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Slayt Ustalarını Karşılaştırma**

Master slaytlar, [IBaseSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/) üzerinden miras alınan `Equals` metodu ile karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcılar ya da mevcut tarih gibi dinamik yer tutucu değerleri karşılaştırılmaz.

```csharp
using Aspose.Slides;

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

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/net/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/) üzerindeki `LastView` özelliği, PowerPoint’in ilk açtığı görünümü kontrol eder. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/net/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen sunumlar, hiçbir normal slayt tarafından kullanılmayan master slaytlar içerir. Kullanılmayan master’ları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirir.

`Masters` koleksiyonundan kullanılmayan master’ları kaldırmak için [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/tr/net/aspose.slides/masterslidecollection/removeunused/) yöntemini kullanın:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Ayrıca düşük‑kodlu [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) yöntemini de kullanabilirsiniz:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **SSS**

**Bir slayt ustası ile bir düzen slaytı arasındaki fark nedir?**

Bir slayt ustası tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Bir düzen slaytı bir master slaytına aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir düzen slaytı kullanır; böylece hem layout hem de master’dan miras alır.

**Bir sunum birden fazla slayt ustası içerebilir mi?**

Evet. Bir sunum birden fazla slayt ustası barındırabilir. Farklı bölümler farklı görsel sistemler veya markalama gerektirdiğinde birden çok master kullanın.

**Yer tutucuları bir master slayta mı yoksa bir layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Ortak görsel öğeler ve ortak biçimlendirmeyi master slayta, içerik yer tutucularını ise normal slaytların kullanacağı layout‑lara yerleştirin.

**Kullanılan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slaytı doğrudan kaldırmak güvenli değildir. Önce bu slaytları başka bir master altındaki layout’lara taşıyın veya yalnızca kullanılmayan master’ları temizleyen bir yöntem kullanın.