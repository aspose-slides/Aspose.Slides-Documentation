---
title: .NET'te Sunum Yer Tutucularını Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/net/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- ipucu metni
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile metin, resim, grafik ve içerik yer tutucularını incelemeyi ve düzenlemeyi ve yer tutucu kalıtımını anlamayı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir düzen slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) özelliği aracılığıyla sunar. Bu özellik, normal bir şekil için `null` veya bir [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) nesnesi döndürür. Yer tutucunun ne tür içerik barındırması gerektiğini belirlemek için [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) özelliğini kullanın.

Şekil arabirimi, yer tutucu türünü öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu, bir [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu, bir [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) ile temsil edilebilir.
- Bir içerik yer tutucusu çeşitli içerik türlerini barındırabilir. Her yer tutucunun bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) olduğunu varsaymak yerine hem [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) hem de çalışma zamanı şekil arabirimini kontrol edin.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı türünü garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman bir tür kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlama**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana‑seviye yer tutucuları tanımlar.
2. Bir düzen slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan kalıtım alabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve düzeninden kalıtım alabilir.

[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) metodunu çağırarak bu hiyerarşide bir seviye yukarı çıkabilirsiniz. Bir slayt yer tutucusu normalde düzen yer tutucusunu döndürür; bir düzen yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa metod `null` döner.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını rapor eder:

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili düzeni veya anayı düzenlemek, bu ayarı hâlâ devralan tüm slaytları etkileyebilir. Yerel bir sıradan şeklin temel yer tutucusu yoktur ve yalnızca aynı koordinatları kapladığı için kalıtım başlatmaz.

## **Yer Tutucu Durumunu Kaldırma**

Bir şablonu uyarlarken, mevcut nesneyi sıradan bir şekil olarak tutmak için [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) kullanın. Bunun [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) özelliği `null` olur, ancak şekil slayt koleksiyonunda kalır. Buna karşılık, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) şekli o koleksiyondan siler.

Aşağıdaki örnek, en az bir slaytı ve ilk slaytta boş olmayan bir metin yer tutucusu olan `template.pptx` dosyasını gerektirir. Yer tutucu, düzen veya ana tarafından devralınan biçimlendirmeyi görmek için kullanılmalıdır. Örnek, aynı şeklin kaldığını kontrol eder, yöntemi artık sıradan şekil üzerinde yeniden çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Warning" %}}
Yer tutucu durumunun kaldırılması, devralınan görünüm ayarlarını otomatik olarak korumaz. Aşağıdaki örnek, bu ayarları kasıtlı olarak değiştirmeden bırakır, bu yüzden çıktı farklı görünebilir. Pozisyonu ve boyutu tamamen devralınan bir şekil, çağrı sonrası sıfır koordinat ve boyuta sahip olabilir ve koleksiyonda kalmasına rağmen görünmez hâle gelebilir.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Ordinary bir şekil üzerinde yöntemi çağırmak hiçbir etkisi yoktur.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Eşleşen bir yer tutucu için, üç kontrol de `True` çıktısını verir. Metin kalır, ancak devralınan konum, boyut, dönüş, yazı tipi, paragraf hizalaması, metin çerçevesi kenar boşlukları, dikey tutma, dolgu ve çizgi ayarları yer tutucu ilişkisi kaldırıldığında değişebilir. Örneğin, devralınan başlık biçimlendirmesi sıradan metin biçimlendirmesine geri dönebilir. Düzenler hakkında daha fazla bilgi için [Slayt Düzeni](/slides/tr/net/slide-layout/) sayfasına bakın.

İstenen görünümü korumak için, çağrıdan önce çözülmüş konum, boyut ve dönüşü yakalayın ve gerekli etkili biçimlendirme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), ve [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) ile alın. Yalnızca etkili‑format nesnelerine güvenmeyin, çünkü ilişki kaldırıldıktan sonra metin biçimlendirme değerleri değişebilir. Yakalanan değerleri, şablonunuzda kullanılan yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin çerçevesi ayarları, dolgu ve çizgi dahil olmak üzere sıradan şekle açıkça uygulayın.

Devralınan şekil geometrisi de [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/) aracılığıyla açıkça atanabilir. Dikdörtgen bir metin yer tutucusu için bu, [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) atanması anlamına gelir; yalnızca dolgu ve çizgiyi geri yüklemek görünür dikdörtgeni sağlamayabilir. Ek efektler veya daha karmaşık biçimlendirmeye sahip şablonlar, bu ayarların da ele alınmasını gerektirir.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları normalde metni destekler. Its [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) özelliğini kullanmadan önce [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) olup olmadığını kontrol edin.

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) tipine dönüştürmekten kaçınır. Ayrıca, kırılgan bir şekil indeksine güvenmek yerine yer tutucuyu amacına göre tanımlar.

## **Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda görüntülenen tasarım‑zamanı talimatıdır, örneğin *Başlık eklemek için tıklayın*. Özel ipucu metnini, normal bir slaydın şekil koleksiyonundan ulaşmaya çalışmak yerine düzen yer tutucusunda ayarlayın. Düzeni [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) aracılığıyla erişin ve [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/) üzerinde yineleyin.

Aşağıdaki örnek, ilk slayt tarafından kullanılan düzen üzerindeki başlık ve alt‑başlık ipuçlarını değiştirir:

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

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarındaki boş yer tutucular için tasarlanmıştır. Bir kullanıcı ya da program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucunu değiştirmek, düzeni kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

Ele alınması gereken iki durum vardır:

- Resim yer tutucusu zaten dolu ve bir [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) ile temsil ediliyorsa, resmi [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) ve [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) aracılığıyla değiştirin.
- Eğer hala boş bir yer tutucuysa, [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) ile yer tutucunun koordinatlarına bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Sonraki örnek her iki durumu da destekler ve sunumu kaydeder:

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

Boş bir yer tutucu için oluşturulan değiştirici, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) yalnızca‑okunur. Ayrılmış konumu korur ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisinin korunması kritikse, önce PowerPoint'te yer tutucuyu hazırlayıp doldurun, ardından ortaya çıkan [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)'i Aspose.Slides ile güncelleyin.

Görünürlük, kırpma ve diğer resim‑özel etkiler için [Resim Çerçevelerini Yönetme](/slides/tr/net/picture-frame/) sayfasına bakın. Bu işlemler resim çerçevesine veya resim dolgusuna aittir, yer tutucu meta verilerine değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu, bir [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) ile temsil edilebilir. Bu örnek, hem yer tutucu türüne hem de çalışma zamanı arabirimine göre böyle bir grafik bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucusu genellikle [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) tipine sahiptir. PowerPoint'te bu, grafikler, tablolar, diyagramlar, resimler ve medya gibi çeşitli içerik türleri için bir başlatıcı görevi görür. Doldurulduktan sonra, içinde ne olduğunu öğrenmek için gerçek şekil arabirimini inceleyin. Özel düzenler ayrıca [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), veya [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) tiplerini ortaya çıkarabilir.

Aspose.Slides, boş bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) yer tutucusunu yalnızca [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) değiştirerek bir [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) e dönüştürmez; tür yalnızca‑okunurdur. Boş bir grafik veya içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

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

Eklenen grafik, sıradan bir yerel grafiktir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan devralmaz. Kategorilerini, serilerini veya çalışma kitabı verilerini değiştirmek gerektiğinde özel [grafik yönetim makaleleri](/slides/tr/net/powerpoint-charts/) sayfasını kullanın.

## **Tam Örnek: Metin veya Resim İçeriğini Güncelleme**

Aşağıdaki uçtan uca örnek, bir şablon açar, ilk slaytta bir başlık veya resim yer tutucusunu arar, yer tutucu ve şekil türlerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksini varsaymaktan veya her yer tutucuyu aynı arabirime dönüştürmekten kasıtlı olarak kaçınır:

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

**Temel yer tutucu nedir?**

Temel yer tutucu, başka bir yer tutucunun devraldığı düzen veya ana üzerindeki karşılık gelen şekildir. Onu almak için [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığından `null` döndürür.

**Tüm slayt başlıklarını bir düzen yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir düzen üzerinden devralınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum boyunca gerçek başlık metnini değiştirmek için slaytları döngüyle gezip her başlık yer tutucusunu güncellemeniz gerekir.

**Tarih, slayt‑numarası, üstbilgi ve altbilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, düzen, ana, not veya dağıtım kapsamında üstbilgi ve altbilgi yöneticilerini kullanın. Tam örnekler için [Sunum Üstbilgi ve Altbilgi Yönetimi](/slides/tr/net/presentation-header-and-footer/) sayfasına bakın.