---
title: Aspose.Slides'ı Değerlendirin
type: docs
weight: 120
url: /tr/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides'ı değerlendirin
- Aspose.Slides değerlendirmesi
- değerlendirme sürümü
- tam işlevsellik
- değerlendirme filigranı
- Aspose.Slides satın al
- sınırlama
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i değerlendirin ve PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumları için API özelliklerini keşfedin—ücretsiz denemenizi başlatın."
---
## **Aspose.Slides Değerlendirme**

Aspose.Slides'ı değerlendirme amaçlı olarak indirebilirsiniz. Değerlendirme paketi satın alınan paketle aynıdır; lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı hâle gelir.

Lisans olmadan Aspose.Slides, değerlendirme modunda tam işlevselliğini sağlar, ancak iki sınırlama vardır: kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler ve kodunuzun bir sunumdan okuduğu metin, ilk birkaç karakterine kesilir ve değerlendirme sınırlaması hakkında bir uyarı eklenir. Kodunuzun yazdığı metin tam olarak kaydedilir.

![Değerlendirme filigranı içeren bir slayt](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Değerlendirme sürümü sınırlamaları olmadan Aspose.Slides'ı test etmek istiyorsanız **30 Day Temporary License** talep edebilirsiniz. Daha fazla bilgi için lütfen [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) adresine bakın.
{{% /alert %}}

## **Değerlendirme Paketini Yükle**

```bash
dotnet add package Aspose.Slides.NET
```

Linux ve macOS'ta bunun yerine Aspose.Slides.NET6.CrossPlatform paketini kullanabilirsiniz; bakınız [Kurulum](/slides/tr/net/installation/).

## **Lisans Uygula**

Bunlar, değerlendirme paketini lisanslı bir hâle getiren “birkaç satır kod”dır. Lisansı, uygulama başlatıldığında, herhangi bir `Presentation` nesnesi oluşturulmadan önce bir kez uygulayın — daha önce oluşturulmuş bir sunum değerlendirme filigranını korur.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` ayrıca bir `Stream` kabul eder; bu, lisans bir dosya yerine gömülü kaynak olarak gönderildiğinde daha iyi bir seçenektir. Yol yanlışsa veya dosyanın süresi dolmuşsa çağrı bir istisna fırlatır, böylece hatalar başlatma sırasında hemen görünür ve sessizce değerlendirme moduna geri dönmez.

Lisans uygulandıktan sonra, kaydedilen sunumlarda artık filigran bulunmaz ve metin tam olarak okunur.

## **SSS**

### Değerlendirme modunda farklı iş parçacıklarında birden fazla sunumu paralel olarak test edebilir miyim?
Evet. Farklı belgeleri paralel olarak işleyebilirsiniz; aynı sunum nesnesini [iş parçacıkları arasında](/slides/tr/net/multithreading/) paylaşmamalısınız. Değerlendirme modeli bunu etkilemez.

### Sunucuda veya CI'de kütüphaneyi değerlendirmek için Microsoft PowerPoint'i kurmam gerekiyor mu?
Hayır. Aspose.Slides bağımsız bir motor olup, değerlendirme ya da üretim için PowerPoint kurulu olmasını gerektirmez.

### Değerlendirme modunda PPT/PPTX'ten PDF ve görüntülere dönüşümü tamamen test edebilir miyim?
Evet. [Dönüştürücüler](/slides/tr/net/convert-presentation/) çalışır; çıktı bir filigran içerecektir.

### Filigran olmadan yük testi için geçici bir lisans kullanabilir miyim?
Evet. 30 günlük geçici bir lisans, değerlendirme modu kısıtlamalarını kaldırır ve filigransız test yapmanıza izin verir.