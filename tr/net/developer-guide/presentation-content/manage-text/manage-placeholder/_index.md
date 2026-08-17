---
title: Sunum Yer Tutucularını .NET’te Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/net/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- resim yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- ipucu metni
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile metin, resim, grafik ve içerik yer tutucularını incelemeyi ve düzenlemeyi, ayrıca yer tutucu kalıtımını anlamayı öğrenin."
---
## **Genel Bakış**

Bir yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, bir yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir yerleşim slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape.Placeholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/placeholder/) özelliği aracılığıyla sunar. Bu özellik, normal bir şekil için `null` veya bir [IPlaceholder](https://reference.aspose.com/slides/tr/net/aspose.slides/iplaceholder/) nesnesi döndürür. Yer tutucunun ne tür içerik barındırması gerektiğini belirlemek için [IPlaceholder.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/iplaceholder/type/) kullanın.

Şekil arabirimi, yer tutucu türünü öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/iplaceholder/type/) hem de çalışma zamanındaki şekil arabirimine bakın.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/iplaceholder/type/) bir yer tutucunun rolünü açıklar; şeklin çalışma zamanındaki tipini garanti etmez. Metin, resim, grafik, tablo veya medya‑özelliği üyelerine erişmeden önce her zaman bir tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlamak**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stiller ve bazı durumlarda ana‑seviye yer tutucular tanımlar.
2. Bir yerleşim slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan devralabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve yerleşiminden devralabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getbaseplaceholder/) çağırın. Bir slayt yer tutucusu tipik olarak yerleşim yer tutucusunu döndürür; bir yerleşim yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `null` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını raporlar:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Normal bir slaytta bir yer tutucu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili yerleşim veya ana slaytı düzenlemek, bu ayarı hâlâ devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve aynı koordinatları kullandığı için devralmaya başlamaz.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, merkez‑başlık, alt‑başlık, gövde ve metin yer tutucuları genellikle metni destekler. [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olup olmadığını kontrol ettikten sonra [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/textframe/) özelliğini kullanın.

Bu örnek, ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Bu desen, resim, grafik, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olarak dökümana zorlamaktan kaçınır. Ayrıca yer tutucuyu amacına göre tanımlar ve kırılgan bir şekil indeksi kullanmaz.

## **Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda tasarım zamanında gösterilen talimattır; örneğin *Başlık eklemek için tıklayın*. Normal bir slaytın şekil koleksiyonundan ulaşmaya çalışmak yerine, düzen yer tutucusuna özel bir ipucu metni ayarlayın. Düzeni, [ISlide.LayoutSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/layoutslide/) aracılığıyla alın ve [ILayoutSlide.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/shapes/) üzerinde döngü oluşturun.

Aşağıdaki örnek, ilk slaytın kullandığı düzen üzerindeki başlık ve alt başlık ipuçlarını değiştirir:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Kullanıcı veya program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucu değiştirmek, düzeni kullanan slaytlardaki mevcut metni değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

İki durum vardır:

- Resim yer tutucusu zaten doluysa ve bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) ile temsil ediliyorsa, resmi [IPictureFillFormat.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/picture/) ve [ISlidesPicture.Image](https://reference.aspose.com/slides/tr/net/aspose.slides/islidespicture/image/) aracılığıyla değiştirin.
- Hâlâ boş bir yer tutucuysa, [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addpictureframe/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Aşağıdaki örnek her iki durumu da destekler ve sunumu kaydeder:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Boş bir yer tutucu için oluşturulan değişiklik yerel bir resim çerçevesidir, yeni bir yer tutucu değildir; çünkü [IShape.Placeholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/placeholder/) yalnızca‑okunurdur. Rezerv edilen konumu korur ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisi önemliyse, önce PowerPoint içinde yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile elde edilen [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) güncelleyin.

Görüntü saydamlığı, kırpma ve diğer resim‑özel etkiler için [Manage Picture Frames](/slides/tr/net/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verileriyle değil.

## **Grafik ve İçerik Yer Tutucuları ile Çalışma**

Dolu bir grafik yer tutucusu bir [IChart](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/) ile temsil edilebilir. Bu örnek, hem yer tutucu tipine hem de çalışma zamanı arabirimine göre böyle bir grafiği bulur, başlığını değiştirir ve dosyayı kaydeder:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/tr/net/aspose.slides/placeholdertype/) tipindedir. PowerPoint’te bu, grafikler, tablolar, diyagramlar, resimler ve medya dahil çeşitli içerik türlerini başlatan bir tetikleyici olarak çalışır. Doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil arabirimini inceleyin. Özel düzenler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/tr/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/tr/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/tr/net/aspose.slides/placeholdertype/), veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/tr/net/aspose.slides/placeholdertype/) seviyelerini ortaya çıkarabilir.

Aspose.Slides, bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) yer tutucusunu yalnızca [IPlaceholder.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/iplaceholder/type/) tipini değiştirerek bir [IChart](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/) haline dönüştürmez; tip salt‑okunurdur. Boş bir grafik veya içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bunu bir grafik için yapar:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Eklenen grafik, yerel bir grafik nesnesidir. Yer tutucunun alanını kaplar ancak yerleşim yer tutucusundan devralmaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde ilgili [chart management articles](/slides/tr/net/powerpoint-charts/) bölümlerini kullanın.

## **Tam Örnek: Metin veya Resim İçeriğini Güncelleme**

Aşağıdaki uç‑uç örnek bir şablon açar, ilk slaytta bir başlık ya da resim yer tutucusunu arar, yer tutucu ve şekil tiplerini denetler, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, bir şekil indeksi varsaymaktan veya her yer tutucuyu aynı arabirime dökümana zorlamaktan kasıtlı olarak kaçınır.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **SSS**

**Temel bir yer tutucu nedir?**

Temel bir yer tutucu, başka bir yer tutucunun devraldığı yerleşim ya da ana slayttaki karşılık gelen şekildir. Onu almak için [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getbaseplaceholder/) kullanın. Normal bir yerel şekil `null` döndürür çünkü yer tutucu hiyerarşisinin bir parçası değildir.

**Tüm slayt başlıklarını bir yerleşim yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir yerleşim üzerinden devralınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum genelinde gerçek başlık metnini değiştirmek için slaytlar üzerinde döngü kurup her başlık yer tutucusunu güncelleyin.

**Tarih, slayt‑numarası, başlık ve altbilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, yerleşim, ana, notlar veya el ilanı kapsamındaki başlık ve altbilgi yöneticilerini kullanın. Tam örnekler için [Manage Presentation Header and Footer](/slides/tr/net/presentation-header-and-footer/) bölümüne bakın.