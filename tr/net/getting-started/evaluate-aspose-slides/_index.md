---
title: Aspose.Slides'i Değerlendir
type: docs
weight: 120
url: /tr/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides'i değerlendirin
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
description: " .NET için Aspose.Slides'i değerlendirin ve PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumları için API özelliklerini keşfedin—ücretsiz denemenize başlayın."
---
## **Aspose.Slides Değerlendirme**

Aspose.Slides'i değerlendirme amacıyla kolayca indirebilirsiniz. Değerlendirme paketi satın alınan paketle aynıdır. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde basitçe lisanslı hâle gelir.

Aspose.Slides'in (lisans belirtilmemiş) değerlendirme sürümü tam ürün işlevselliği sağlar, ancak belgeyi açtığınızda ve kaydettiğinizde belgenin üst kısmına bir değerlendirme filigranı ekler. Sunum slaytlarından metin çıkarırken ayrıca bir slayt ile sınırlı olursunuz.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 
Aspose.Slides'i değerlendirme sürümü sınırlamaları olmadan test etmek istiyorsanız, **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için lütfen [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) adresine bakın.
{{% /alert %}}

## **Değerlendirme Paketi Kurulumu**

```bash
dotnet add package Aspose.Slides.NET
```

## **Lisansı Uygulama**

Bunlar, değerlendirme paketini lisanslı bir pakete dönüştüren "birkaç satır kod"dur. Lisansı, uygulama başlangıcında, herhangi bir `Presentation` nesnesi oluşturulmadan önce bir kez uygulayın — daha önce oluşturulmuş bir sunum değerlendirme filigranını korur.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` ayrıca bir `Stream` alır; bu, lisans bir gömülü kaynak olarak gönderildiğinde, diskteki bir dosyadan daha iyi bir seçenektir. Yol yanlışsa veya dosya süresi dolmuşsa, çağrı bir istisna fırlatır, bu nedenle hatalar başlangıçta hemen görülür ve sessizce değerlendirme moduna geri dönmez.

Lisans uygulandığında filigran kaybolur ve bir slaytlık metin çıkarma sınırlaması kaldırılır.

## **SSS**

### Değerlendirme modunda farklı iş parçacıkları arasında birden fazla sunumu paralel olarak test edebilir miyim?
Evet. Farklı belgeleri paralel olarak işleyebilirsiniz; aynı sunum nesnesini [iş parçacıkları arasında](/slides/tr/net/multithreading/) paylaşmamalısınız. Değerlendirme modu bunu etkilemez.

### Sunucuda veya CI ortamında kütüphaneyi değerlendirmek için Microsoft PowerPoint'i kurmam gerekir mi?
Hayır. Aspose.Slides bağımsız bir motor olduğundan, değerlendirme veya üretim ortamı için PowerPoint kurulu olmasına gerek yoktur.

### Değerlendirme modunda PPT/PPTX'i PDF ve görsellere dönüştürmeyi tam olarak test edebilir miyim?
Evet. [Dönüştürücüler](/slides/tr/net/convert-presentation/) çalışır; çıktı bir filigran içerecektir.

### Yük testi için filigransız bir geçici lisans kullanabilir miyim?
Evet. 30 günlük geçici bir lisans, değerlendirme modu sınırlamalarını kaldırır ve filigransız test yapmanıza izin verir.