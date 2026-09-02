---
title: .NET'te Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/net/examine-presentation/
keywords:
- sunum formatı
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
description: ".NET kullanarak PowerPoint ve OpenDocument sunumlarındaki slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun biçimini tanımlayabilir ve tam bir sunum nesne modelini oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde yararlıdır.

Bu makale, hafif incelemeyi [PresentationFactory](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/) ve [IPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/) aracılığıyla, ayrıca hedeflenmiş güncellemeleri [IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) aracılığıyla göstermektedir.

## **Sunum Biçimini Kontrol Et**

Bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği oluşturmadan incelemek için [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) kullanın. [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/loadformat/) özelliği, PPTX, PPT veya ODP gibi tespit edilen biçimi raporlar.

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

[IDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/) tarafından ortaya çıkarılan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Özellik | Envanter değeri |
| --- | --- |
| [Slaytlar](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/slides/tr/) | Toplam slayt sayısı. |
| [GizliSlaytlar](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/hiddenslides/) | Gizli slaytların sayısı. |
| [Notlar](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/notes/) | Not içeren slaytların sayısı. |
| [Paragraflar](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/paragraphs/) | Mevcut olduğunda toplam paragraf sayısı. |
| [Kelimeler](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/words/) | Toplam kelime sayısı. |
| [MultimedyaKlipleri](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/multimediaclips/) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek, bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca, [HeadingPairs](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/headingpairs/) ile [TitlesOfParts](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/titlesofparts/) birleştirerek yazı tipleri, temalar ve slayt başlıkları gibi içerik gruplarını gösterir.

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

Her bir [IHeadingPair](https://reference.aspose.com/slides/tr/net/aspose.slides/iheadingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/titlesofparts/) düz, sıralı bir dizi olduğundan, her başlık çiftinde belirtilen ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veri ve Biçim Sınırlamaları**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut meta verileri yansıtır. Aspose.Slides, bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yüklemez ve dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı en son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli-slayt, paragraf, kelime ve multimedya sayımları için genişletilmiş belge özelliklerinin yanı sıra başlık çiftleri ve bölüm başlıklarını da sağlar. Kullanılabilirlik, belge üreticisi tarafından hangi özelliklerin yazıldığına bağlıdır.
- **PPT:** İkili biçim, karşılık gelen belge-özet özelliklerini depolayabilir. Bir özellik eksikse veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides bunu slaytlardan hesaplamak yerine saklanan ya da varsayılan değerini döndürür.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint’e özgü genişletilmiş özelliğe karşılık gelmez. Gizli-slayt, not-slaytı, multimedya, başlık çifti ve bölüm başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değerleri döndürebilir. Sıfır değeri ya da boş bir diziyi, ilgili içeriğin yok olduğunun kesin kanıtı olarak değerlendirmeyin.

Envanterler ve ön kontroller için hafif meta veri yaklaşımını kullanın. Sonucun bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) ile uygulayın ve ardından bağlanmış sunumu [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/writebindedpresentation/) ile yazın.

Aşağıdaki resim, orijinal belge özelliklerini göstermektedir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek, başlığı ve son kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

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

Aşağıdaki resim, güncellenmiş belge özelliklerini göstermektedir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Sunumları Parola ile Koruma](/slides/tr/net/password-protected-presentation/)
- [Sunumları Yazma Koruması](/slides/tr/net/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.FontsManager](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/fontsmanager/) kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getembeddedfonts/) ve sunumda kullanılan yazı tiplerini elde etmek için [FontsManager.GetFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getfonts/) çağırın. İki sonucu karşılaştırarak render için gerekli ancak gömülü olmayan yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve sayısını nasıl hızlıca öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) ve [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/readdocumentproperties/) aracılığıyla [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/idocumentproperties/hiddenslides/) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, depolanmış meta veriler eksik veya eski olabilir veya canlı değerleri doğrulamanız gerekiyorsa, [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) üzerinde döngü yaparak her slaytın [Slide.Hidden](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.SlideSize](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slidesize/) okuyun. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [ISlideSize.Type](https://reference.aspose.com/slides/tr/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/tr/net/aspose.slides/islidesize/size/), ve [ISlideSize.Orientation](https://reference.aspose.com/slides/tr/net/aspose.slides/islidesize/orientation/) inceleyin.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde nasıl görebilirim?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/) bulun ve [ChartData.DataSourceType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/datasourcetype/) inceleyin. Dış bir çalışma kitabı için, [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/externalworkbookpath/) okuyun. Veri kaynağı türü ve yol, dış referansı gösterir, ancak hedefin erişilebilir olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) ve her slaytın [IBaseSlide.Shapes](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/shapes/) koleksiyonunu dolaşın. Şekil sayıları ve büyük resimler, efektler, animasyonlar veya multimedya varlığına bakarak tarama sinyalleri kullanın ve bir slaytı kesin bir performans darboğuzu olarak değerlendirmeden önce temsilci bir render veya dışa aktarma ölçümü yapın.