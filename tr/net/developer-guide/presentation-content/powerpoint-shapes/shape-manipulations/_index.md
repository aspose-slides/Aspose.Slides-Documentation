---
title: .NET'te Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/net/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil ayar noktası
- önceden tanımlı şekil ayarı
- şekil geometrisi
- şekil düzen biçimleri
- şekil SVG olarak
- şekli SVG'ye dönüştür
- şekli hizala
- şekli çevir
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin.
---
## **Genel Bakış**

Aspose.Slides for .NET, bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olmanın yanı sıra yığılma sırasının kaynağıdır: indeks `0` en arkadaki şekildir, son indeks ise en öndeki şekildir.

Bu makale bu modeli izler. Önce bir şekli güvenilir şekilde tanımlamayı ve önceden ayarlanmış şekil ayar noktalarını değiştirmeyi açıklar, ardından şekilleri kopyalama, kaldırma, gizleme ve yeniden sıralamayı gösterir. Son bölümler, düzen seviyesinde biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve bakımına bağlı olarak bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/name/) geliştirici kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesi'nde kolayca incelenebilir. Adlar düzenlenebilir ve benzersiz olması garanti edilmez; kod bunlara bağlıysa bir adlandırma kuralları oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/alternativetext/) bir erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa kullanışlıdır. Kullanıcılara görünür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/officeinteropshapeid/) bir slayt içinde benzersiz olan, PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelen yalnızca‑okunur bir tanımlayıcıdır. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanan veya yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [UniqueId](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/uniqueid/) özelliği sunum kapsamına sahiptir, ancak eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak ele alınmamalıdır. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, `Name` üzerinden sıralı (ordinal) karşılaştırma yaparak arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde kod, yanlış nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil tipine özgüyse, tip‑özgü üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ise yalnızca metin ve alternatif metni günceller.

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

## **Önceden Tanımlı Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden tanımlı geometri şekilleri, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayar noktaları sunabilir. Bunlara, yalnızca‑okunur [IGeometryShape.Adjustments](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/adjustments/) koleksiyonu üzerinden erişin. Koleksiyon şekil tarafından sağlanır, ancak her [IAdjustValue](https://reference.aspose.com/slides/tr/net/aspose.slides/iadjustvalue/) değiştirilebilen bir değer içerir.

Yalnızca sabit bir koleksiyon indeksine güvenmeyin. Ayarları döngüyle gezerek yalnızca‑okunur [Type](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/type/) özelliğine bakın; [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeadjustmenttype/) değeri, ayarın neyi kontrol ettiğini tanımlar. Yalnızca‑okunur [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/name/) özelliği ek tanımlama bilgisi sağlar ve aynı anlamsal tipe sahip birden çok ayar bulunduğunda özellikle yararlıdır.

Ayara uygun değer özelliğini kullanın:

| Ayarlama türü | Amaç | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [RawValue](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `RawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `RawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `RawValue` |
| `StartAngle` | Dilim ya da yay başlangıç açısı | [AngleValue](https://reference.aspose.com/slides/tr/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Dilim ya da yay bitiş açısı | `AngleValue` |

`Type` ve `Name` atanamaz. `RawValue`, önceden tanımlı şeklin yerel geometri birimlerinde okun‑yazılabilir bir tamsayıdır, `AngleValue` ise derece cinsinden okun‑yazılabilir bir açıdır. Ayarların sayısı, sırası, anlamı ve geçerli aralığı, önceden tanımlı [ShapeType](https://reference.aspose.com/slides/tr/net/aspose.slides/igeometryshape/shapetype/) öğesine bağlıdır. Bir önceden tanımlı için geçerli bir değer, diğerine uygulanınca geçersiz veya farklı bir etki yaratabilir.

`Type` `ShapeAdjustmentType.Custom` olduğunda API standart bir anlamsal anlam tanımaz. `Name`, önceden tanımlı tip ve mevcut değeri inceleyin; beklenen anlam ve aralık bilinmiyorsa ayarı değiştirmeyin. Tanınan tipler için bile aynı tip birden çok kez ortaya çıkıyorsa değeri seçmeden önce kontrol edin. [Connector](/slides/tr/net/connector/) makalesi, bağlayıcı bükülme ayarlarıyla ilgili bu durumu gösterir.

Aşağıdaki tam örnek, üç önceden tanımlı şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Tüm ayarları döngüyle gezerek `Name` ve `Type` değerlerini raporlar, boyut‑ilişkili değerleri `RawValue` ile, açıları `AngleValue` ile değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometriyi, sağ sütun ise ayarlanmış yuvarlatılmış dikdörtgen, dört‑yönlü ok ve dilimi gösterir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Varsayılan ve ayarlanmış şekil sütunları için başlıklar ekler.
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

Değer değiştirmeden önce anlamsal tipin kontrol edilmesi, kodun niyetini açıklar ve farklı önceden tanımlı şekillerde aynı koleksiyon indeksinin aynı anlama gelmediği varsayımını önler.

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştirirse, o işlemden önce yakalanmış indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyalama**

[AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/insertclone/) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler kopyayı boyutunu değiştirmeden taşırken, genişlik ve yükseklik kabul edenler yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni ön tarafa kopyalar ve ikinci bir kopyayı arka tarafa ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerekiyorsa kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak bir kopya hâlâ yeni bir koleksiyon öğesi ve yeni şekil kimliğiyle bulunur.

### **Şekilleri Kaldırma**

[Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli bir döngü sırasında birden çok eşleşme kaldırılırken, kalan indekslerin geçerli kalması için sondan başlanarak gezin.

Bu örnek, belirli bir ada sahip her şekli kaldırır. Sabit bir koleksiyon öğesi yerine `slide.Shapes[i]` okunur ve şekil gereksiz yere cast edilmez.

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

Kaldırma sonrası şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere yapılan referanslar, kaydedilmiş indekslerden daha güvenilir kalır. Ayrıca kaldırılan nesneye başvuran bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/hidden/) değerini `true` olarak ayarlamak şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği koda hâlâ erişilebilir olur; bu yüzden gizleme, daha sonra geri getirilebilecek isteğe bağlı öğeler için uygundur.

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

Gizleme silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir ve sunum dosyasının bir parçası kalır.

### **Z‑Sırasını Değiştirme**

Üst‑üste binen şekiller koleksiyon sırasına göre boyanır. [Reorder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/reorder/) mevcut bir şekli kopyalamadan hedef bir indekse taşır. İndeks `0` arka taraftır; `Count - 1` ön taraftır.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında durur. Son indekse taşındığında ön tarafa gelir. Tüm ilgili şekiller eklenip/kopyalanıp tamamlandıktan sonra z‑sırasını sonlandırın; çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, normal bir slayttaki aynı konumda bulunan şekille aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak ya da değiştirmek istediğinizde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/fillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/lineformat/) özelliklerini okur; `AutoShape` olup olmadığına bakmadan.

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

Bir düzeni düzenlemek, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce, normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma içeriyor mu belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[WriteAsSvg](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/writeassvg/) bir şeklin işlenmiş içeriğini bir akıma yazar. Sonuç, şekli içerir; tüm slayt arka planını veya komşu şekilleri içermez.

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

Render ederken sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar ile görseller gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa slaytı dışa aktarın, tek bir şekli değil. Çağıran akımı sahiplenir ve kapatmalıdır.

## **Şekilleri Hizalama**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/alignshapes/) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/shapesalignmenttype/) kenar, merkez çizgi ya da dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirine göre hizalanır.

Bu örnek, üç şekli slaytın üst kenarına hizalar. Dönen şekil referansları, hizalamadan hemen önce mevcut indekslerine dönüştürülür.

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

Hizalama konumu değiştirir, z‑sırasını değiştirmez. Göreceli hizalama genellikle en az iki şekil gerektirirken, yatay ya da dikey dağıtım yeterli boşluk tanımlamak için yeterli sayıda şekle ihtiyaç duyar. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve döndürmeyi saklar. `FlipH` ve `FlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/net/aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı ve `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, çevirilmemiş bir şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/frame/) atanması çerçevenin tamamını değiştirir.

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

Kaydedilen şekil konumunu, boyutunu ve döndürmesini korurken yatay ve dikey olarak aynalanır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksi kullanmalı mıyım?**

Sadece koleksiyon işlem sırasında değişmeyecek ve kısa sürede kullanılacak ise kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` kuralı, slayt kapsamlı interop çalışmaları için `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek, onu z‑sırasından çıkarır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Kopyalanan bir şekil neden başka bir şeklin önünde göründü?**

`AddClone` kopyayı koleksiyonun sonuna ekler; bu, z‑sırasının ön kısmıdır. Başlangıç indeksi seçmek için `InsertClone` kullanın ya da tüm şekiller eklendikten sonra `Reorder` ile konumu ayarlayın.

**Önceden tanımlı bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Sadece tam olarak hangi önceden tanımlı şekil ve koleksiyon düzeni olduğundan emin olduktan sonra. `IGeometryShape.Adjustments` döngüsü yapın ve `IAdjustValue.Type` kontrol edin; aynı anlamsal tip birden çok kez ortaya çıkıyorsa ek bilgi için `IAdjustValue.Name` kullanın.