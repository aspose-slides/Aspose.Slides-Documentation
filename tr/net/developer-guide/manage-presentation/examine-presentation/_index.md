---
title: Sunum Bilgilerini .NET'te Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/net/examine-presentation/
keywords:
- sunum biçimi
- sunum özellikleri
- belge özellikleri
- özellikleri al
- özellikleri oku
- özellikleri değiştir
- özellikleri düzenle
- özellikleri güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun biçimini belirleyebilir ve tam bir sunum nesne modeli oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde faydalıdır.

Bu makale, [PresentationFactory](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/) ve [IPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/) aracılığıyla hafif denetimi, ayrıca [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) aracılığıyla hedeflenmiş güncellemeleri göstermektedir.

## **Sunum Biçimini Kontrol Et**

Eğer zaten yüklü bir sunumunuz varsa, yüklemeden sonra tespit için ve eski PPT, PPS ve POT akışlarının sınırlamaları için [Determine the Original Presentation Format](/slides/tr/net/detect-presentation-source-format/) sayfasına bakın.

[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) kullanarak bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği oluşturmadan inceleyebilirsiniz. [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/loadformat/) özelliği tespit edilen biçimi, örneğin PPTX, PPT veya ODP, raporlar.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Hafif Bir Sunum Envanteri Oluştur**

Birçok sunum dosyasını işlediğinizde, doğrulama, indeksleme veya bir belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, bir [IPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/) nesnesi elde etmek için [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) kullanın ve ardından belge meta verilerini okumak için [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) çağırın. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelini dolaşmanızı gerektirmez.

[IDocumentProperties] tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Özellik | Envanter değeri |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/slides/tr/) | Toplam slayt sayısı. |
| [HiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/hiddenslides/) | Gizli slayt sayısı. |
| [Notes](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/notes/) | Not içeren slayt sayısı. |
| [Paragraphs](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/paragraphs/) | Mevcut olduğunda toplam paragraf sayısı. |
| [Words](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/words/) | Toplam kelime sayısı. |
| [MultimediaClips](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/multimediaclips/) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek, bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca [HeadingPairs](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/headingpairs/) ile [TitlesOfParts](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/titlesofparts/) kombinasyonunu kullanarak yazı tipleri, temalar ve slayt başlıkları gibi içerik gruplarını gösterir.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Her [IHeadingPair](https://reference.aspose.com/slides/tr/net/aspose.slides/iheadingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/titlesofparts/) düz, sıralı bir dizi olduğundan, her başlık çiftinin belirttiği ardışık başlık sayısı kadar tüketilir.

### **Depolanmış Meta Veriler ve Biçim Sınırlamaları**

[IPresentationInfo.ReadDocumentProperties] tarafından döndürülen envanter özellikleri, kaynak belgede mevcut meta verileri yansıtır. Aspose.Slides, bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yükleyip dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli slayt, paragraf, kelime ve multimedya sayımları ile başlık çiftleri ve bölüm başlıkları için genişletilmiş belge özellikleri sağlar. Kullanılabilirlik, belge üreticisi tarafından hangi özelliklerin yazıldığına bağlıdır.
- **PPT:** İkili biçim, karşılık gelen belge özet özelliklerini depolayabilir. Bir özellik eksikse veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides bu özelliğin saklanan veya varsayılan değerini döndürür, slaytlardan hesaplamaz.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint‑spesifik genişletilmiş özellik ile eşleşmez. Gizli slayt, not slaytı, multimedya, başlık çifti ve bölüm başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değerleri döndürebilir. Sıfır değeri veya boş bir dizi, ilgili içeriğin olmadığının kesin kanıtı olarak kabul edilmemelidir.

Envanterler ve ön kontrol için hafif meta veri yaklaşımını kullanın. Sonuçların bellekteki değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyip canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[IPresentationInfo.ReadDocumentProperties] tarafından döndürülen özellikler, bir [Presentation] örneği oluşturmadan da değiştirilebilir. Değişiklikleri [IPresentationInfo.UpdateDocumentProperties] ile uygulayın ve ardından bağlanmış sunumu [IPresentationInfo.WriteBindedPresentation] ile yazın.

Aşağıdaki görüntü, orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek başlığı ve son kaydedilme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Aşağıdaki görüntü, güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Sunumları Parola ile Koruma](/slides/tr/net/password-protected-presentation/)
- [Sunumları Yazma Koruması ile Koruma](/slides/tr/net/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.FontsManager] kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager.GetEmbeddedFonts] ve sunum tarafından kullanılan yazı tiplerini elde etmek için [FontsManager.GetFonts] çağırın. İki sonucu karşılaştırarak, render için gerekli ancak gömülmemiş olan yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu nasıl hızlıca öğrenebilirim?**

Depolanan belge meta verileri yeterli olduğunda, [PresentationFactory.GetPresentationInfo] ve [IPresentationInfo.ReadDocumentProperties] aracılığıyla [IDocumentProperties.HiddenSlides] okuyun. Bu, hafif bir envanter için uygundur. Sunum bellekte değiştirilmişse, depolanan meta veriler eksik veya eski olabilir veya canlı değerleri doğrulamanız gerekiyorsa, [Presentation.Slides] üzerinden döngü yaparak her slaydın [Slide.Hidden] özelliğini inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.SlideSize] okuyun. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [ISlideSize.Type], [ISlideSize.Size] ve [ISlideSize.Orientation] inceleyin.

**Grafiklerin harici veri kaynaklarına referans verip vermediğini hızlı bir şekilde nasıl görebilirim?**

Evet. Her bir [Chart] bulun ve [ChartData.DataSourceType] inceleyin. Harici bir çalışma kitabı için [ChartData.ExternalWorkbookPath] okuyun. Veri kaynağı türü ve yolu harici bir referansı tanımlar, ancak hedefin erişilebilirliğini doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.Slides] ve her slaydın [IBaseSlide.Shapes] koleksiyonunu dolaşın. Şekil sayısı ve büyük resimler, efektler, animasyonlar veya multimedya varlığı gibi göstergeleri izleme sinyalleri olarak kullanın ve bir slaydın kesin bir performans darboğazı olduğunu kabul etmeden önce temsilci bir render veya dışa aktarım ölçümü yapın.