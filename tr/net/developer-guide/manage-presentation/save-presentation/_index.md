---
title: Sunumları .NET'te Kaydet
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
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını C# ile Aspose.Slides for .NET kullanarak dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Sunum oluşturduktan veya [mevcut bir sunumu aç](/slides/tr/net/open-presentation/) sonra, sonucu yazmak için [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini kullanın. Aspose.Slides for .NET bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda dosyaya veya akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için çıkış yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) değerini [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemine iletin. Format değeri, Aspose.Slides'in oluşturduğu dosya türünü belirler.

Aşağıdaki örnek bir sunum oluşturur ve onu PPTX dosyası olarak kaydeder:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Sunumları Orijinal Formatında Kaydet**

Dosya ve akış algılama örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıkış formatları arasındaki ayrım için [Orijinal Sunum Formatını Belirleme](/slides/tr/net/detect-presentation-source-format/) sayfasına bakın.

Toplu işleme uygulamasında, giriş formatı önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal formatını [IPresentation.SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/sourceformat/) özelliğinden okuyun. Elde edilen [SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/sourceformat/) değerini [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/tosaveformat/) yöntemine geçirerek karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) değerini alın ve ardından [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) ile değiştirilmiş sunumu yazın.

Aşağıdaki tam örnek, giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği formatta bir çıkış dizinine kaydeder:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/tosaveformat/) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML'i ilgili sunum kaydetme formatlarıyla eşleştirir. Yalnızca sunum kaynak formatlarını eşleştirir; PDF, HTML, TIFF veya resim gibi dışa aktarma formatlarını seçmek için değildir. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/sourceformat/) değeri geçirilirse bir [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception) oluşur.

Legacy PPT, PPS ve POT dosyaları aynı ikili konteyneri kullanır. Böyle bir sunum bir dosya uzantısı olmadan bir akıştan yüklendiğinde, bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt tipleri korumak gerekiyorsa, özgün dosya adını veya format meta verisini ayrı bir şekilde tutun ve çıktı dosya adı ve formatı seçilirken kullanın.

## **Sunumları Akışa Kaydet**

Son bir dosya yoluna bağlı kalmadan bir sunumu yazmak için yazılabilir bir [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) ve bir [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) değerini [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemine iletin. Bu yaklaşım, çıktının bir web hizmetinden dönmesi, bir veritabanında saklanması veya bellek içinde işlenmesi gerektiğinde faydalıdır.

Aşağıdaki örnek yeni bir sunumu bir dosya akışına kaydeder:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydet**

PowerPoint'in kaydedilen bir sunumu ilk açtığında kullanılacak görünümü belirtebilirsiniz. Kaydetmeden önce [ViewProperties.LastView](https://reference.aspose.com/slides/tr/net/aspose.slides/viewproperties/lastview/) özelliğini bir [ViewType](https://reference.aspose.com/slides/tr/net/aspose.slides/viewtype/) değerine ayarlayın.

Aşağıdaki örnek Slide Master görünümünü başlangıç görünümü olarak yapılandırır:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Sunumları Katı Office Open XML Formatında Kaydet**

Office Open XML'in Katı profiline uyan bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/) örneği oluşturun ve [Conformance](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/conformance/) özelliğini `Conformance.Iso29500_2008_Strict` olarak ayarlayın. Ardından bu seçenekleri [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemine iletin.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Sunumları Office Open XML Formatında Zip64 Modunda Kaydet**

Standart bir ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlar. PPTX dosyası bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırlamaları aşabilir. ZIP64 uzantıları ilgili boyut ve giriş sayısı limitlerini yükseltir.

[PptxOptions.Zip64Mode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/zip64mode/) özelliğini kullanarak Aspose.Slides'in ZIP64 uzantılarını yazıp yazmayacağını kontrol edin:

- `IfNecessary` yalnızca sunum standart ZIP limitlerini aştığında ZIP64 kullanır. Bu varsayılan moddur.
- `Never` ZIP64 uzantılarını devre dışı bırakır.
- `Always` her zaman ZIP64 uzantılarını yazar.

Aşağıdaki örnek, çıktı sunumu için her zaman ZIP64 uzantılarını etkinleştirir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode` `Never` olarak ayarlanırsa ve sunum standart ZIP limitlerine sığmazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxexception/) fırlatır.
{{% /alert %}}

## **Sunumları Office Open XML Formatında Sıkıştırma Seviyeleriyle Kaydet**

PPTX çıktısı için, [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/compressionlevel/) özelliğini ayarlayarak kaydetme hızını dosya boyutuyla dengeleyebilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/net/aspose.slides.export/compressionlevel/) enumarasyonu şu değerleri sağlar:

- `None` veriyi sıkıştırma olmadan depolar.
- `Level1` en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- `Level2` ila `Level5` arasında, kaydetme hızından ziyade daha küçük çıktıyı tercih eder.
- `Level6` kaydetme hızı ile dosya boyutunu dengeler. Bu varsayılan seviyedir.
- `Level7` ve `Level8` daha da küçük çıktıyı kaydetme hızından üstün tutar.
- `Level9` en güçlü sıkıştırmayı sağlar ve en fazla işlem süresine ihtiyaç duyar.

Aşağıdaki örnek bir sunumu sıkıştırma olmadan kaydeder:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Aşağıdaki örnek maksimum sıkıştırma seviyesini kullanır:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Küçük Resmi Yenilemeksizin Sunumları Kaydet**

Bir sunum PPTX olarak kaydedildiğinde, [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pptxoptions/refreshthumbnail/) özelliği belge küçük resmini kontrol eder:

- `true` kaydetme işlemi sırasında küçük resmi yeniden oluşturur. Bu varsayılan değerdir.
- `false` mevcut küçük resmi korur. Sunumun küçük resmi yoksa, Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek bir sunumu küçük resmini yenilemeden kaydeder:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Küçük resim yenilemeyi devre dışı bırakmak, PPTX dosyasının kaydedilmesi için gereken süreyi azaltabilir.
{{% /alert %}}

## **Kaydetme İlerlemesini Yüzde Olarak Güncelle**

Bir kaydetme işlemini izlemek için [IProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/) arayüzünü uygulayın ve uygulamayı [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isaveoptions/progresscallback/) özelliğine atayın. Aspose.Slides, dışa aktarım sırasında ilerleme değerleriyle [IProgressCallback.Reporting](https://reference.aspose.com/slides/tr/net/aspose.slides/iprogresscallback/reporting/) metodunu çağırır.

Aşağıdaki örnek PDF dışa aktarma ilerlemesini konsola raporlar:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose, Aspose.Slides API'siyle oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Seçilen slaytları bir sunumdan ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **SSS**

**Aspose.Slides artımlı veya “hızlı kaydetme”yi destekliyor mu?**

Hayır. Her kaydetme işlemi yalnızca değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Birden fazla iş parçacığı aynı Presentation örneğini kaydedebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği [thread-safe değildir](/slides/tr/net/multithreading/). Her örüme aynı anda yalnızca bir iş parçacığından erişin ve kaydedin.

**Bir sunumu kaydettiğimde hiperlinkler ve harici bağlı dosyalar ne olur?**

[Hyperlinkler](/slides/tr/net/manage-hyperlinks/) sunumda kalır. Aspose.Slides harici bağlı dosyaları kopyalamaz, bu nedenle kaydedilen sunumun bunların konumlarına hâlâ erişebilmesi gerekir.

**Yazar, başlık, şirket ve oluşturma tarihi gibi belge meta verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [belge özelliklerini](/slides/tr/net/presentation-properties/) ayarlayın, Aspose.Slides bunları çıktı dosyasına yazar.