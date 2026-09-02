---
title: ".NET'te Sunumları Kaydet"
linktitle: "Sunumu Kaydet"
type: docs
weight: 80
url: /tr/net/save-presentation/
keywords:
- "PowerPoint kaydet"
- "OpenDocument kaydet"
- "sunum kaydet"
- "slayt kaydet"
- "PPT kaydet"
- "PPTX kaydet"
- "ODP kaydet"
- "sunumu dosyaya"
- "sunumu akışa"
- "önceden tanımlı görünüm türü"
- "Katı Office Open XML Biçimi"
- "Zip64 modu"
- "küçük resmi yenileme"
- "kaydetme ilerlemesi"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides kullanarak .NET'te sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint ya da OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[C#'ta Sunumları Aç](/slides/tr/net/open-presentation/) başlığı, bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıklamıştır. Bu makale, sunumların nasıl oluşturulup kaydedileceğini anlatır. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı bir sunumun içeriğini barındırır. Sıfırdan bir sunum oluşturuyorsanız ya da mevcut bir sunumu değiştiriyorsanız, işiniz bittiğinde kaydetmek isteyeceksiniz. Aspose.Slides for .NET ile bir **dosyaya** ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydetme**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının `Save` metodunu çağırarak bir sunumu dosyaya kaydedin. Metoda dosya adını ve kaydetme biçimini iletin. Aşağıdaki örnek, Aspose.Slides kullanarak bir sunumun nasıl kaydedileceğini göstermektedir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
using (Presentation presentation = new Presentation())
{
    // Burada bazı işlemler yapın...

    // Sunumu bir dosyaya kaydet.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Sunumları Akışlara Kaydetme**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının `Save` metoduna bir çıktı akışı geçirerek bir sunumu akışa kaydedebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Sunumu akışa kaydet.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydetme**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza olanak tanır. [LastView](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/lastview/) özelliğini, [ViewType](https://reference.aspose.com/slides/tr/net/aspose.slides/viewtype/) enum'ından bir değerle ayarlayın.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Katı Office Open XML Biçiminde Sunumları Kaydetme**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenizi sağlar. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/) sınıfını kullanın ve uyumluluk özelliğini ayarlayın. `Conformance.Iso29500_2008_Strict` ayarlandığında çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve Katı Office Open XML biçiminde kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Sunum dosyasını temsil eden Presentation sınıfını oluştur.
using (Presentation presentation = new Presentation())
{
    // Sunumu Katı Office Open XML biçiminde kaydet.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **ZIP64 Modunda Office Open XML Biçiminde Sunumları Kaydetme**

Office Open XML dosyası, sıkıştırılmamış herhangi bir dosyanın, sıkıştırılmış herhangi bir dosyanın ve arşivin toplam boyutunun 4 GB (2^32 bayt) sınırına tabi olduğu bir ZIP arşividir ve arşivde en fazla 65 535 (2^16‑1) dosya bulunabilir. ZIP64 biçim uzantıları bu sınırlamaları 2^64’e kadar yükseltir.

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/zip64mode/) özelliği, bir Office Open XML dosyası kaydedilirken ZIP64 uzantılarını ne zaman kullanacağınızı seçmenizi sağlar.

Bu özellik aşağıdaki modları sunar:

- `IfNecessary` ZIP64 uzantılarını yalnızca sunum yukarıdaki sınırlamaları aştığında kullanır. Bu varsayılan moddur.
- `Never` ZIP64 uzantılarını asla kullanmaz.
- `Always` ZIP64 uzantılarını her zaman kullanır.

Aşağıdaki kod, ZIP64 uzantıları etkinleştirilmiş bir PPTX dosyası olarak bir sunumun nasıl kaydedileceğini gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Sıkıştırma Düzeyleriyle Office Open XML Biçiminde Sunumları Kaydetme**

Büyük sunumlarla çalışırken dosya boyutu ve işleme süresini dengelemek için sıkıştırma düzeyini ayarlayabilirsiniz. Gereksinimlerinize bağlı olarak daha hızlı işleme ya da daha küçük çıktı dosyaları tercih edilebilir.

Aspose.Slides, Office Open XML biçiminde sunum kaydederken kullanılacak sıkıştırma düzeyini belirlemenizi sağlayan [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/compressionlevel/) özelliğini sunar.

Mevcut sıkıştırma düzeyleri şunlardır:

- **None**: Sıkıştırma uygulanmaz. Dosyalar olduğu gibi saklanır.
- **Level1**: En hızlı sıkıştırma, en düşük sıkıştırma oranı.
- **Level2**: **Level1**’e göre biraz daha iyi sıkıştırma oranı.
- **Level3**: **Level2**’ye göre daha iyi sıkıştırma, işlem süresinde orta derecede etki.
- **Level4**: **Level3**’ten daha iyi sıkıştırma.
- **Level5**: **Level4**’ten daha iyi sıkıştırma, ek işlem süresi.
- **Level6**: İşleme hızı ve dosya boyutu arasında iyi bir denge sunan standart sıkıştırma. *Varsayılan sıkıştırma düzeyidir*.
- **Level7**: **Level6**’dan daha iyi sıkıştırma, daha yavaş işleme.
- **Level8**: **Level7**’den daha iyi sıkıştırma.
- **Level9**: Azami sıkıştırma. En küçük dosya boyutunu verir, ancak en uzun işleme süresine sahiptir.

Aşağıdaki örnek, sıkıştırma **olmadan** bir PPTX dosyası olarak sunumu kaydetmeyi gösterir:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Bu örnek, **azami sıkıştırma** ile bir PPTX dosyası olarak sunumu kaydetmeyi gösterir:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Küçük Resmi Yenilemeksizin Sunumları Kaydetme**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) özelliği, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` ise kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` ise mevcut küçük resim korunur. Sunumun küçük resmi yoksa hiçbir şey oluşturulmaz.

Aşağıdaki kod, sunumu küçük resmi yenilenmeden PPTX olarak kaydeder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX formatında bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerlemesini Yüzde Olarak Güncelleme**

[IProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/) arabirimi, [ISaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isaveoptions/) arabirimi tarafından yayınlanan `ProgressCallback` özelliği ve soyut [SaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/) sınıfı aracılığıyla kullanılır. `ProgressCallback`e bir [IProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/) uygulaması atayarak kaydetme ilerlemesini yüzde olarak alabilirsiniz.

Aşağıdaki kod parçacıkları, `IProgressCallback` kullanımını gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Burada ilerleme yüzde değerini kullan.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API’si kullanılarak geliştirilmiş ücretsiz bir **PowerPoint Splitter** uygulaması sunar. Bu uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden çok dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydetme” (artımlı kaydetme) sadece değişiklikleri yazarak destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyasını oluşturur; artımlı “hızlı kaydetme” desteklenmez.

**Aynı Presentation nesnesini birden çok thread’den kaydetmek güvenli mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/net/multithreading/); tek bir thread’den kaydedilmelidir.

**Kaydederken köprüler ve harici bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/net/manage-hyperlinks/) korunur. Harici bağlı dosyalar (ör. relatif yollarla eklenmiş videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/net/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.