---
title: .NET'te Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/net/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunumu kaydet
- slaytı kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument formatına dışa aktarın."
---
## **Genel Bakış**

[C#'da Sunum Açma](/slides/tr/net/open-presentation/) bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıklamıştır. Bu makale, sunumların nasıl oluşturulacağını ve kaydedileceğini anlatır. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyorsanız ya da mevcut bir sunumu değiştiriyorsanız, işi tamamladığınızda onu kaydetmek isteyeceksiniz. Aspose.Slides for .NET ile **file** veya **stream** olarak kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydet**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının `Save` yöntemini çağırarak bir sunumu dosyaya kaydedin. Yönteme dosya adını ve kaydetme biçimini iletin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

```cs
// Sunum dosyasını temsil eden Presentation sınıfını oluşturun.
using (Presentation presentation = new Presentation())
{
    // Burada bazı işlemleri yapın...

    // Sunumu bir dosyaya kaydedin.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Sunumları Akışlara Kaydet**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının `Save` yöntemine bir çıktı akışı geçerek bir sunumu akışa kaydedebilirsiniz. Sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```cs
// Sunum dosyasını temsil eden Presentation sınıfını başlat.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Sunumu akışa kaydedin.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Önceden Tanımlı Görünüm Türü ile Sunumları Kaydet**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/) sınıfındaki `LastView` özelliğini [ViewType](https://reference.aspose.com/slides/tr/net/aspose.slides/viewtype/) enum'ından bir değere ayarlayın.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenize olanak tanır. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/) sınıfını kullanıp onun `Conformance` özelliğini ayarlayın. `Conformance.Iso29500_2008_Strict` olarak ayarlandığında çıkış dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve Katı Office Open XML biçiminde kaydeder.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Sunum dosyasını temsil eden Presentation sınıfını başlat.
using (Presentation presentation = new Presentation())
{
    // Sunumu Katı Office Open XML biçiminde kaydedin.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Office Open XML dosyası, sıkıştırılmamış dosya boyutu, sıkıştırılmış dosya boyutu ve arşiv toplam boyutu için 4 GB (2^32 bayt) sınırı koyan bir ZIP arşividir; ayrıca arşivde en fazla 65 535 (2^16‑1) dosya bulunabilir. ZIP64 biçim uzantıları bu sınırlamaları 2^64’e çıkarır.

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/zip64mode/) özelliği, bir Office Open XML dosyası kaydedilirken ZIP64 biçim uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu özellik aşağıdaki modları sunar:

- `IfNecessary` sunum yukarıdaki sınırlamaları aştığında yalnızca ZIP64 uzantılarını kullanır. Bu varsayılan moddur.
- `Never` ZIP64 uzantılarını hiçbir zaman kullanmaz.
- `Always` her zaman ZIP64 uzantılarını kullanır.

Aşağıdaki kod, ZIP64 biçim uzantıları etkinleştirilmiş bir PPTX dosyası olarak bir sunumu nasıl kaydedeceğinizi gösterir:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxexception/) istisnası fırlatılır.
{{% /alert %}}

## **Sunumları Office Open XML Biçiminde Sıkıştırma Düzeyleriyle Kaydet**

Büyük sunumlarla çalışırken dosya boyutu ile işleme süresini dengelemek için sıkıştırma düzeyini ayarlayabilirsiniz. Gereksinimlerinize bağlı olarak daha hızlı işleme ya da daha küçük çıktı dosyalarını tercih edebilirsiniz.

Aspose.Slides, Office Open XML biçiminde bir sunumu kaydederken kullanılan sıkıştırma düzeyini belirlemenizi sağlayan [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/compressionlevel/) özelliğini sunar.

Mevcut sıkıştırma düzeyleri şunlardır:

- **None**: Hiç sıkıştırma uygulanmaz. Dosyalar olduğu gibi saklanır.
- **Level1**: En düşük sıkıştırma oranı ile en hızlı sıkıştırma.
- **Level2**: **Level1**'e göre biraz daha iyi sıkıştırma oranı ile daha hızlı sıkıştırma.
- **Level3**: **Level2**'den daha iyi sıkıştırma sağlar, işleme süresi orta seviyededir.
- **Level4**: **Level3**'ten daha iyi sıkıştırma sağlar.
- **Level5**: **Level4**'ten iyileştirilmiş sıkıştırma, ek işleme süresi gerektirir.
- **Level6**: İşleme hızı ve dosya boyutu arasında iyi bir denge sunan standart sıkıştırma. Bu *varsayılan sıkıştırma seviyesidir*.
- **Level7**: **Level6**'dan daha iyi sıkıştırma, ancak daha yavaş işleme.
- **Level8**: **Level7**'den daha iyi sıkıştırma.
- **Level9**: En yüksek sıkıştırma. En uzun işleme süresi karşılığında en küçük dosya boyutunu üretir.

Aşağıdaki örnek, *sıkıştırma olmadan* bir PPTX dosyası olarak bir sunumu nasıl kaydedeceğinizi gösterir:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Bu örnek, *en yüksek sıkıştırma* ile bir PPTX dosyası olarak bir sunumu nasıl kaydedeceğinizi gösterir:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) özelliği, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını denetler:

- `true` olarak ayarlandığında kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlandığında mevcut küçük resim korunur. Sunumun küçük resmi yoksa hiç oluşturulmaz.

Aşağıdaki kod, sunumu küçük resmi yenilemeden PPTX olarak kaydeder.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX biçiminde bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **İlerleme Güncellemelerini Yüzde Olarak Kaydet**

[IProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/) arayüzü, [ISaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isaveoptions/) arayüzü tarafından açığa çıkarılan `ProgressCallback` özelliği ve soyut [SaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/) sınıfı aracılığıyla kullanılır. `ProgressCallback` özelliğine bir [IProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/) uygulaması atayarak kaydetme ilerlemesini yüzde olarak alabilirsiniz.

Aşağıdaki kod parçacıkları `IProgressCallback` kullanımını gösterir.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Burada ilerleme yüzde değerini kullanın.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sini kullanan ücretsiz bir **PowerPoint Splitter** uygulaması geliştirmiştir. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden çok dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydet” (artımlı kaydet) sadece değişiklikleri yazarak destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyayı oluşturur; artımlı “hızlı kaydet” desteklenmez.

**Aynı Presentation örneğini birden çok thread'den kaydetmek thread‑safe mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/net/multithreading/); tek bir thread'den kaydedin.

**Kaydetme sırasında köprüler ve harici bağlantılı dosyalar ne oluyor?**

[Hyperlinks](/slides/tr/net/manage-hyperlinks/) korunur. Harici bağlantılı dosyalar (ör. göreceli yollarla eklenen videolar) otomatik olarak kopyalanmaz; başvurulan yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp kaydedebilir miyim?**

Evet. Standart [document properties](/slides/tr/net/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.