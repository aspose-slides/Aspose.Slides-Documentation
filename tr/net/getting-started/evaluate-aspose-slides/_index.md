---
title: Aspose.Slides'ı Değerlendir
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
description: ".NET için Aspose.Slides'ı değerlendirin ve PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumları için API özelliklerini keşfedin—ücretsiz denemenize başlayın."
---
## **Aspose.Slides Değerlendirme**

Aspose.Slides'ı değerlendirme amacıyla kolayca indirebilirsiniz. Değerlendirme paketi, satın alınan paketle aynı olur. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde basitçe lisanslı hâle gelir. 

Aspose.Slides'ın değerlendirme sürümü (lisans belirtilmediğinde) tam ürün işlevselliği sağlar, ancak belgeyi açtığınızda ve kaydettiğinizde belgenin üst kısmına bir değerlendirme filigranı ekler. Sunum slaytlarından metin çıkarırken ayrıca bir slaytla sınırlı olursunuz.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

Aspose.Slides'ı değerlendirme sürümü sınırlamaları olmadan test etmek istiyorsanız, **30 Günlük Geçici Lisans** isteyebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) adresine bakın.

{{% /alert %}}

## **Değerlendirme Paketini Yükleyin**

```bash
dotnet add package Aspose.Slides.NET
```

## **Bir Lisans Uygulayın**

Bunlar, değerlendirme paketini lisanslı bir hâle getiren "birkaç satır kod"dur. Lisansı, uygulama başlangıcında, herhangi bir `Presentation` nesnesi oluşturulmadan önce bir kez uygulayın — daha önce oluşturulmuş bir sunum değerlendirme filigranını tutar.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` ayrıca bir `Stream` parametresini kabul eder; bu, lisans bir dosya olarak değil gömülü kaynak olarak gönderildiğinde daha iyi bir seçenektir. Yol hatalıysa veya dosyanın süresi geçmişse çağrı bir istisna fırlatır, böylece hatalar başlangıçta hemen ortaya çıkar ve sessizce değerlendirme moduna dönmez.

Lisans uygulandıktan sonra filigran kaybolur ve tek slayt için metin çıkarma sınırlaması kaldırılır.

## **SSS**

### Değerlendirme modunda farklı iş parçacıklarında paralel olarak birden fazla sunumu test edebilir miyim?

Evet. Farklı belgeleri paralel olarak işleyebilirsiniz; aynı sunum nesnesini [iş parçacıkları arasında](/slides/tr/net/multithreading/) paylaşmamalısınız. Değerlendirme modu bunu etkilemez.

### Sunucuda veya CI ortamında kütüphaneyi değerlendirmek için Microsoft PowerPoint'i kurmam gerekir mi?

Hayır. Aspose.Slides bağımsız bir motor olup, değerlendirme ya da üretim için PowerPoint kurulumu gerektirmez.

### Değerlendirme modunda PPT/PPTX'i PDF ve görüntülere dönüştürmeyi tam olarak test edebilir miyim?

Evet. [Dönüştürücüler](/slides/tr/net/convert-presentation/) çalışır; çıktı bir filigran içerir.

### Yük testi için filigransız bir geçici lisans kullanabilir miyim?

Evet. 30 günlük geçici bir lisans, değerlendirme modu sınırlamalarını kaldırır ve filigransız test yapmanıza olanak tanır.