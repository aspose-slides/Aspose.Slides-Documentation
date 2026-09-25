---
title: .NET'te Sunum Şekillerini Yönet
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/net/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayt üzerindeki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliği alma
- şekil alternatif metni
- şekil ayar noktası
- önceden ayarlanmış şekil ayarı
- şekil geometrisi
- şekil düzen formatları
- şekil SVG olarak
- şekli SVG'ye
- şekli hizala
- şekli döndür
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve döndürmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirebileceğiniz yer olduğu gibi, yığın sırasının da kaynağıdır: indeks `0` en arka şekildir, son indeks ise en ön şekildir.

Bu makale bu modeli izler. Önce bir şekli güvenilir şekilde tanımlamayı ve önceden ayarlanmış şekil ayar noktalarını değiştirmeyi açıklar, ardından şekilleri kopyalamayı, kaldırmayı, gizlemeyi ve yeniden sıralamayı gösterir. Son bölümler, düzen seviyesindeki biçimlendirme, SVG dışa aktarımı, hizalama ve döndürme ayarlarını kapsar. Her örnek bağımsızdır, böylece yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımla ve Bul**

Koleksiyon indeksleri, bilinen bir dosya işlenirken kullanışlıdır, ancak kararlı tanımlayıcılar değildir. Bir şekli eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve sürdürüldüğüne göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/name/) geliştirici kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenir. İsimler düzenlenebilir ve benzersiz olması garanti değildir; kod bu isimlere bağımlıysa bir adlandırma kuralları oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/alternativetext/) erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa faydalıdır. Kullanıcılar tarafından görülür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti değildir. Anlamlı erişilebilirlik metnini sessizce bir veri tabanı anahtarı olarak kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/officeinteropshapeid/) yalnızca bir slayt içinde benzersiz ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelen salt okunur bir tanımlayıcıdır. PowerPoint ile entegrasyon yaparken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanan veya yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [UniqueId](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/uniqueid/) özelliği sunum kapsamına sahiptir, ancak eklentiler için tasarlanmıştır ve yeniden atanabilir. Dışsal kalıcı bir anahtar gibi davranılmamalıdır. Uzun vadeli kimlik gerekliliği varsa, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Alternatif metin başlığı ve açıklamasını okuyup güncellemek için pratik bir örnek görmek isterseniz, [Alternatif Metin Başlıkları ve Açıklamaları Yönet](/slides/tr/net/presentation-accessibility/) bölümüne bakın. Alternatif metni, görselin anlamını okuyuculara açıklamak için kullanın ve kodun şekilleri bulmak için kullandığı şekil adlarından ayrı tutun.

Aşağıdaki örnek, `Name` ile sıralı karşılaştırma yaparak arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod yanlış nesneyle devam etmek yerine bu sonucu raporlar.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Bir işlem belirli bir şekil türüne özgüyse, tip‑özel üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ise yalnızca metin ve alternatif metni günceller.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Önceden Ayarlanmış Şekil Ayarlarını Tanımla ve Değiştir**

Önceden ayarlanmış geometri şekilleri, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktalarına sahip olabilir. Bu noktalara, salt okunur [IGeometryShape.Adjustments](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/adjustments/) koleksiyonu üzerinden erişilir. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/net/aspose.slides/iadjustvalue/) değiştirilebilen bir değere sahiptir.

Sadece sabit bir koleksiyon indeksine güvenmeyin. Ayarları döngüyle inceleyin ve salt okunur [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/type/) özelliğine bakın; bu özelliğin [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeadjustmenttype/) değeri, ayarın neyi kontrol ettiğini açıklar. Salt okunur [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/name/) özelliği ek tanımlama bilgisi sağlar ve aynı anlamsal türe sahip birden fazla ayar içeren önceden ayarlanmışlarda özellikle yararlıdır.

Ayara uygun değer özelliğini kullanın:

| Ayarlama türü | Amaç | Değiştirilmesi gereken değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [RawValue](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `RawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `RawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `RawValue` |
| `StartAngle` | Pasta veya yay başlangıç açısı | [AngleValue](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Pasta veya yay bitiş açısı | `AngleValue` |

`Type` ve `Name` atanamaz. `RawValue`, önceden ayarlanmışın yerel geometri birimlerinde okuma/yazma tam sayı iken, `AngleValue` derece cinsinden okuma/yazma açı değeridir. Ayarların sayısı, sırası, anlamı ve geçerli aralığı önceden ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/shapetype/) üzerine bağlıdır. Bir önceden ayarlama için geçerli bir değer, başka bir önceden ayarlama için geçersiz olabilir veya farklı etki yaratabilir.

`Type` `ShapeAdjustmentType.Custom` olduğunda API standart bir anlamsal anlam tanımaz. `Name`, önceden ayarlama türü ve mevcut değeri inceleyin; beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan türlerde bile aynı tip birden çok kez geçiyorsa, bir değer seçmeden önce bunu kontrol edin. [Connector](/slides/tr/net/connector/) makalesi, bağlayıcı bükülme ayarlarıyla bu durumu gösterir.

Aşağıdaki tam örnek, üç önceden ayarlanmış şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarı dolaşır, `Name` ve `Type` değerlerini raporlar, boyutla ilgili değerleri `RawValue` üzerinden, açıları `AngleValue` üzerinden değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometrileri tutar; sağ sütun ayarlanmış yuvarlak dikdörtgen, dört yönlü ok ve pasta gösterir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Varsayılan ve ayarlanmış şekil sütunları için başlık ekler.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Değeri değiştirmeden önce anlamsal türü kontrol etmek, kodun amacını açıkça belirtir ve farklı önceden ayarlanmış şekillerde aynı koleksiyon indeksinin aynı anlama gelmediğini varsaymayı önler.

## **Şekil Koleksiyonunu Değiştir**

Ekleme, kopyalama, kaldırma ve yeniden sıralama yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını ya da sırasını değiştiriyorsa, o işlemden önce yakalanan indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyala**

[AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/insertclone/) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler, boyutu değiştirmeden kopyayı taşır; genişlik ve yükseklik alan aşırı yüklemeler ise yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arka tarafa ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerekiyorsa, kopyaya yeni mantıksal kimlikler atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak bir kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliğiyle kalır.

### **Şekilleri Kaldır**

[Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. Birden çok eşleşmeyi indeksli döngü içinde kaldırırken, kalan indekslerin geçerli kalması için sondan başlangıca doğru dolaşın.

Bu örnek, belirli bir ad taşıyan tüm şekilleri kaldırır. Sabit bir koleksiyon öğesi yerine `slide.Shapes[i]` okur ve şekli gereksiz yere tip dönüşümü yapmaz.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmemiş şekillere referanslar kaydedilen indekslerden daha güvenilirdir. Bağlayıcılar, animasyonlar ve kaldırılan nesneye başvuran diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını etkileyebilir.

### **Bir Şekli Gizle**

[Hidden](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/hidden/) öğesini `true` yapmak, şekli koleksiyonda tutar ancak normal slayt gösteriminde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği kod için hâlâ erişilebilir olduğundan, daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Gizleme silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından gizlenmesi kaldırılabilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Order Değiştir**

Üst üste gelen şekiller koleksiyon sırasına göre çizilir. [Reorder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/reorder/) mevcut bir şekli kopyalamadan hedef indekse taşır. İndeks `0` arka, `Count - 1` ise ön taraftır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Dikdörtgen ilk oluşturulduğunda elipsin arkasındadır. Son indekse taşındığında ön tarafa gelir. Tüm ilgili şekiller eklendikten ya da kopyalandıktan sonra z‑order'ı sonlandırın; bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İncele**

Normal slaytlar, düzen slaytları ve ana slaytların ayrı şekil koleksiyonları vardır. Bir düzen koleksiyonundaki şekil, normal bir slayttaki aynı konumdaki şekille aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak ya da değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/fillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/lineformat/) özelliklerini `AutoShape` olup olmadığına bakmadan okur.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Bir düzeni düzenlemek, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce, normal bir slaydın nesneyi devralıp devralmadığını veya yerel bir geçersiz kılma içerip içermediğini belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktar**

[WriteAsSvg](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/writeassvg/) bir şeklin render edilmiş içeriğini akışa yazar. Sonuç, tüm slayt arka planı veya komşu şekilleri içermeden yalnızca şekli içerir.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Sunumu render ederken açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri, görseller gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, bireysel şekil yerine slaytı dışa aktarın. Akışı çağıran taraf sahiplenir ve serbest bırakmalıdır.

## **Şekilleri Hizala**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/alignshapes/) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi veya dağıtım modunu belirtir. `alignToSlide` `true` ise slayt kenarları kullanılır; `false` ise seçili şekiller birbirine göre hizalanır.

Bu örnek üç şekli slaytın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce mevcut indekslerine dönüştürülür.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Hizalama konumları değiştirir, z‑order'ı etkilemez. Göreceli hizalama genellikle en az iki şekil gerektirir, yatay ya da dikey dağıtım ise boşlukları tanımlamak için yeterli sayıda şekil gerektirir. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Döndür**

[ShapeFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey döndürme ayarları ve rotasyonu saklar. `FlipH` ve `FlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/net/aspose.slides/nullablebool/) kullanır: `True` döndürmeyi açar, `False` devre dışı bırakır ve `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, döndürülmemiş bir şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki döndürme ayarını değiştirir. Bu, yeni bir [Frame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/frame/) atandığında çerçevenin tamamının değişeceği için önemlidir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Kaydedilen şekil, konumu, boyutu ve rotasyonu korurken yatay ve dikey olarak yansıtılmıştır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksi kullanmalı mıyım?**

Yalnızca koleksiyonun indeks kullanılmadan önce değişmeyeceği kısa vadeli işlemelerde kullanılabilir. Şablonlar için doğrulanmış bir `Name` veya `AlternativeText` kuralı, slayt‑kapsamlı interop işleri için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek, onu z‑order'dan kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Neden kopyalanan bir şekil başka bir şeklin önünde görünüyor?**

`AddClone` kopyayı koleksiyonun sonuna ekler; koleksiyonun sonu z‑order'da ön taraftır. Başlangıç indeksini seçmek için `InsertClone` kullanın veya tüm şekiller eklendikten sonra `Reorder` ile konumlandırın.

**Önceden ayarlanmış bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Sadece kesin önceden ayarlama ve koleksiyon düzeni doğrulandıktan sonra kullanılabilir. `IGeometryShape.Adjustments` içinde döngüyle dolaşıp `IAdjustValue.Type` kontrol etmeyi tercih edin; aynı anlamsal tip birden çok kez ortaya çıkıyorsa ek bilgi için `IAdjustValue.Name` kullanın.