---
title: Sunumları .NET'te Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/net/save-presentation/
keywords:
- PowerPoint'i kaydet
- OpenDocument'i kaydet
- sunumu kaydet
- slaytı kaydet
- PPT'yi kaydet
- PPTX'i kaydet
- ODP'yi kaydet
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
description: "Aspose.Slides kullanarak .NET'te sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint ya da OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[C# ile Açık Sunumlar](/slides/tr/net/open-presentation/) bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıklar. Bu makale, sunumların nasıl oluşturulup kaydedileceğini gösterir. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı bir sunumun içeriğini barındırır. Sıfırdan bir sunum oluşturuyor ya da mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde onu kaydetmek isteyeceksiniz. Aspose.Slides for .NET ile bir **dosyaya** ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının `Save` yöntemini çağırın. Yönteme dosya adını ve kaydetme biçimini iletin. Aşağıdaki örnek, Aspose.Slides kullanarak bir sunumu nasıl kaydedeceğinizi gösterir.

```cs
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // Burada bazı işlemler yapın...

    // Sunumu bir dosyaya kaydedin.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Sunumları Akışlara Kaydet**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının `Save` yöntemine bir çıktı akışı geçirerek bir sunumu akışa kaydedebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup onu bir dosya akışına kaydediyoruz.

```cs
// Presentation dosyasını temsil eden Presentation sınıfını örnekleyin.
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

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/) sınıfı üzerinden ayarlamanıza izin verir. [ViewProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/) sınıfındaki `LastView` özelliğine, [ViewType](https://reference.aspose.com/slides/tr/net/aspose.slides/viewtype/) enum'undan bir değer atayın.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenizi sağlar. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/) sınıfını kullanın ve `Conformance` özelliğini ayarlayın. `Conformance.Iso29500_2008_Strict` olarak ayarlandığında, çıkış dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve Katı Office Open XML biçiminde kaydeder.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // Sunumu Katı Office Open XML formatında kaydedin.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Sunumları Zip64 Modunda Office Open XML Biçiminde Kaydet**

Office Open XML dosyası, sıkıştırılmış herhangi bir dosyanın, sıkıştırılmamış dosyanın ve arşivin toplam boyutu için 4 GB (2^32 bayt) sınırı koyan bir ZIP arşividir ve aynı zamanda arşivi 65 535 (2^16‑1) dosyayla sınırlar. ZIP64 format uzantıları bu sınırları 2^64’e yükseltir.

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/zip64mode/) özelliği, bir Office Open XML dosyası kaydedilirken ZIP64 uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu özellik aşağıdaki modları sağlar:

- `IfNecessary` sunum yukarıdaki sınırlamaları aşıyorsa ZIP64 uzantılarını kullanır. Bu varsayılan moddur.
- `Never` ZIP64 uzantılarını asla kullanmaz.
- `Always` her zaman ZIP64 uzantılarını kullanır.

Aşağıdaki kod, ZIP64 uzantıları etkinleştirilmiş bir PPTX olarak bir sunumu nasıl kaydedeceğinizi gösterir:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOT" color="warning" %}}
`Zip64Mode.Never` ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxexception/) istisnası atılır.
{{% /alert %}}

## **Sunumları Küçük Resmi Yenilemeden Kaydet**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) özelliği, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` ise kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` ise mevcut küçük resim korunur. Sunumun küçük resmi yoksa hiç oluşturulmaz.

Aşağıdaki kod, sunumu küçük resmi yenilenmeden PPTX olarak kaydeder.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Bilgi" color="info" %}}
Bu seçenek, PPTX biçiminde bir sunumu kaydetme süresini kısaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Al**

[IProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/) arayüzü, [ISaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isaveoptions/) arayüzü üzerinden açığa çıkan `ProgressCallback` özelliği ve soyut [SaveOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/) sınıfı ile kullanılır. `ProgressCallback` özelliğine bir [IProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/) uygulaması atayarak, kaydetme ilerlemesini yüzde olarak alabilirsiniz.

Aşağıdaki kod bölümleri, `IProgressCallback` kullanımını gösterir.

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

{{% alert title="Bilgi" color="info" %}}
Aspose, kendi API’siyle geliştirilmiş bir [ücretsiz PowerPoint Bölücü uygulaması](https://products.aspose.app/slides/tr/splitter) sunar. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydet” (artımlı kaydet) destekleniyor mu, sadece değişiklikler mi yazılıyor?**

Hayır. Kaydetme her seferinde tam hedef dosyasını oluşturur; artımlı “hızlı kaydetme” desteklenmez.

**Aynı Presentation örneğini birden çok iş parçacığından kaydetmek güvenli mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği **thread‑safe** değildir; kaydetme işlemini tek bir iş parçacığından yapın.

**Kaydederken köprüler ve harici olarak bağlanan dosyalar ne oluyor?**

[Hyperlink](/slides/tr/net/manage-hyperlinks/)ler korunur. Harici bağlanan dosyalar (ör. görece yollarla eklenen videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/net/presentation-properties/) desteklenir ve kaydedilirken dosyaya yazılır.