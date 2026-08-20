---
title: .NET'te Sunum Şekillerini Yönet
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
- şekil düzen formatları
- şekil SVG olarak
- şekli SVG'ye
- şekli hizala
- şekli çevir
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunum şekillerini tanımlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET, bir slayttaki şekilleri sıralı bir [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olmasının yanı sıra yığın sıralarının kaynağıdır: indeks `0` en arkadaki şekildir, son indeks ise en öndeki şekildir.

Bu makale bu modeli takip eder. Öncelikle bir şekli güvenilir bir şekilde nasıl tanımlayacağınızı açıklar, ardından şekilleri nasıl kopyalayacağınızı, kaldıracağınızı, gizleyeceğinizi ve sırasını değiştireceğinizi gösterir. Son bölümler, düzen düzeyinde biçimlendirme, SVG dışa aktarımı, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, bu yüzden yalnızca iş akışınızın gerektirdiği işlemleri kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri, bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekli eklemek, kaldırmak veya sırasını değiştirmek indeksini değiştirebilir. Sunumun nasıl oluşturulduğuna ve yönetildiğine göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/name/) geliştiricinin kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesi'nde incelemesi kolaydır. İsimler düzenlenebilir ve benzersiz olması garanti edilmez, bu yüzden koda bağımlıysanız bir adlandırma kuralları belirleyin.
- [AlternativeText](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/alternativetext/) erişilebilirlik açıklaması veya yazar tarafından sağlanan bir etiket zaten şekli tanımlıyorsa kullanışlıdır. Kullanıcılara görünür, yerelleştirilebilir veya erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti edilmez. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/officeinteropshapeid/) bir okuma‑yazma olmayan tanımlayıcıdır, slayt içinde benzersizdir ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken veya bir şeklin ömrü boyunca belirsiz olmayan bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanan veya yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [UniqueId](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/uniqueid/) özelliği sunum kapsamına sahiptir, ancak eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak ele alınmamalıdır. Uzun vadeli kimlik önemliyse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, `Name` ile sıralı bir karşılaştırma yaparak arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod hatalı nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgüyse, tür‑spesifik üyeleri kullanmadan önce arabirimi kontrol edin. Bu örnek, adlandırılmış nesne bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ise metni ve alternatif metni günceller.

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

## **Şekil Koleksiyonunu Değiştirme**

Ekleme, kopyalama, kaldırma ve yeniden sıralama metodları koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını veya sırasını değiştiriyorsa, o işlemden önce yakalanan indekslere güvenmeye devam etmeyin.

### **Bir Şekli Kopyalama**

[AddClone](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [InsertClone](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/insertclone/) da bir kopya oluşturur ancak belirtilen z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler kopyayı boyutunu değiştirmeden taşır; genişlik ve yükseklik içeren aşırı yüklemeler de yeniden boyutlandırabilir.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adı ve alternatif metni dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerektiğinde klona yeni mantıksal tanımlayıcılar atayın. Karmaşık şekiller tarafından kullanılan kaynaklar sunum tarafından yönetilir, ancak kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliği olur.

### **Şekilleri Kaldırma**

[Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli yineleme sırasında birden fazla eşleşmeyi kaldırırken, kalan indekslerin geçerli kalması için sondan başlayarak dolaşın.

Bu örnek, belirli bir isimle işaretlenmiş tüm şekilleri kaldırır. Sabit bir koleksiyon öğesi yerine `slide.Shapes[i]` okunur ve şekil gereksiz yere bir tipe dönüştürülmez.

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

Kaldırma sonrası şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmeyen şekillere referanslar, kaydedilmiş indekslere göre daha güvenilirdir. Ayrıca kaldırılan nesneye başvuran bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünen bir şekli kaldırmak slaydın görünümünden daha fazlasını etkileyebilir.

### **Bir Şekli Gizleme**

[Hidden](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/hidden/) özelliğini `true` yaparak şekil koleksiyonda kalır ancak normal slayt gösterisinde görünmez. İndeksi, biçimi ve içeriği kod tarafından hâlâ erişilebilir olduğundan, daha sonra geri getirilebilecek isteğe bağlı öğeler için gizleme uygundur.

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

Gizleme bir silme veya güvenlik işlemi değildir. Nesne hâlâ bulunabilir ve bir kullanıcı ya da kod tarafından gizlilikten çıkarılabilir; aynı zamanda sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste gelen şekiller koleksiyon sırasına göre boyanır. [Reorder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/reorder/) mevcut bir şekli klonlamadan hedef indeksine taşır. İndeks `0` arka, `Count - 1` ön demektir.

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

Dikdörtgen ilk oluşturulduğunda elipsin arkasında durur. Son indekse taşındığında ön tarafa gelir. Tüm ilişkili şekiller eklendikten veya kopyalandıktan sonra z‑orderʼı sonlandırın; bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, normal bir slayttaki benzer konumlu şekilyle aynı nesne değildir. Düzenin sağladığı biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/fillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/lineformat/) değerlerini, her şeklin bir `AutoShape` olduğu varsayımını yapmadan okur.

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

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma mı içeriyor belirleyin ve o düzeni kullanan her slaytı test edin.

## **Şekli SVG Olarak Dışa Aktarma**

[WriteAsSvg](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/writeassvg/) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç, şekli içerir; tüm slayt arka planını veya komşu şekilleri içermez.

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

Render sırasında sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar, görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, bireysel bir şekil yerine slaytı dışa aktarın. Çağıran akımı sahiplenir ve kapatmak zorundadır.

## **Şekilleri Hizalama**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/alignshapes/) aşırı yüklemeleri, tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/shapesalignmenttype/) kenar, merkez çizgisi veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarları kullanılır; `false` yaparsanız seçili şekiller birbirine göre hizalanır.

Bu örnek, üç şekli slaytın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce mevcut indekslerine dönüştürülür.

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

Hizalama konumları değiştirir, z‑orderʼı değil. Göreceli hizalama genellikle en az iki şekil gerektirirken, yatay veya dikey dağıtım yeterli boşluk tanımlamak için yeterli sayıda şekle ihtiyaç duyar. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve döndürmeyi saklar. `FlipH` ve `FlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/net/aspose.slides/nullablebool/) kullanır: `True` çevirme etkinleştirir, `False` devre dışı bırakır ve `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu bir çevrilmemiş şekil içerir.

![Çevirme öncesi şekil](shape_to_be_flipped.png)

Bu örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/frame/) atamak çerçevenin tamamını değiştirir.

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

Kaydedilen şekil, konum, boyut ve döndürmeyi korurken yatay ve dikey olarak yansıtılır.

![Çevirme sonrası şekil](flipped_shape.png)

## **SSS**

**Bir şekil tanımlayıcısı olarak koleksiyon indeksi kullanmalı mıyım?**

Sadece koleksiyon, indeks kullanılmadan önce değişmeyecek kısa süreli işlemler için kullanılmalıdır. Yazarın oluşturduğu şablonlar için doğrulanmış bir `Name` veya `AlternativeText` konvansiyonu, slayt kapsamlı interop çalışması için ise `OfficeInteropShapeId` tercih edin.

**Bir şekli gizlemek, onu z‑orderʼdan çıkarır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür yapılabilir.

**Neden kopyalanan bir şekil başka bir şeklin önünde göründü?**

`AddClone` kopyayı koleksiyonun sonuna ekler; bu da z‑orderʼın ön kısmıdır. Başlangıç indeksini seçmek için `InsertClone` kullanın ya da tüm şekiller eklendikten sonra `Reorder` ile konumlandırın.