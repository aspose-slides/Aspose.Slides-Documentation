---
title: Aspose.Slides'ı Değerlendirin
type: docs
weight: 75
url: /tr/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides'ı değerlendirin
- Aspose.Slides değerlendirme
- değerlendirme sürümü
- tam işlevsellik
- değerlendirme filigranı
- Aspose.Slides satın al
- kısıtlama
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET için Aspose.Slides'ı değerlendirin ve PowerPoint (PPT, PPTX) ile OpenDocument (ODP) sunumları için API özelliklerini keşfedin—ücretsiz denemenizi başlatın."
---
## **Aspose.Slides Değerlendirme**

Aspose.Slides'ı değerlendirme amaçlı indirebilirsiniz. Değerlendirme paketi satın alınan paketle aynıdır; lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı hâle gelir.

Lisans olmadan, Aspose.Slides değerlendirme modunda tam işlevselliğini sağlar, ancak iki sınırlama vardır: kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler ve kodunuzun bir sunumdan okuduğu metin ilk birkaç karakterine kesilir, ardından değerlendirme sınırlamasına dair bir uyarı gelir. Kodunuzun yazdığı metin tamamen kaydedilir.

![Değerlendirme filigranlı bir slayt](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides'ı değerlendirme sürümü kısıtlamaları olmadan test etmek istiyorsanız, **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) adresine bakın.
{{% /alert %}}

## **Değerlendirme Paketini Yükleme**

```bash
dotnet add package Aspose.Slides.NET
```

Linux ve macOS'ta, bunun yerine Aspose.Slides.NET6.CrossPlatform paketini kullanabilirsiniz; [Kurulum](/slides/tr/net/installation/) bölümüne bakın.

## **Lisans Uygulama**

Bunlar, değerlendirme paketini lisanslı bir pakete dönüştüren “birkaç satır kod”dur. Lisansı, uygulama başlatılırken, herhangi bir `Presentation` nesnesi oluşturulmadan önce bir kez uygulayın — daha önce oluşturulan bir sunum değerlendirme filigranını tutar.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` ayrıca bir `Stream` alır; lisans bir gömülü kaynak olarak gönderildiğinde dosya yerine bu seçenek daha iyidir. Yol yanlışsa veya dosya süresi dolmuşsa çağrı bir istisna fırlatır, bu yüzden hatalar başlatma sırasında hemen ortaya çıkar ve sessizce değerlendirme moduna geri dönmez.

Lisans uygulandıktan sonra, kaydedilen sunumlar artık filigran taşımaz ve metin tamamen okunur.

## **SSS**

### Değerlendirme modunda farklı iş parçacıklarında paralel olarak birden fazla sunumu test edebilir miyim?

Evet. Farklı belgeleri paralel olarak işleyebilirsiniz; aynı sunum nesnesini [iş parçacıkları arasında](/slides/tr/net/multithreading/) paylaşmamalısınız. Değerlendirme modu bunu etkilemez.

### Kütüphaneyi bir sunucuda veya CI'de değerlendirmek için Microsoft PowerPoint'i yüklemem gerekiyor mu?

Hayır. Aspose.Slides bağımsız bir motor olup, değerlendirme ya da üretim aşamasında PowerPoint'in yüklü olmasını gerektirmez.

### Değerlendirme modunda PPT/PPTX'ten PDF ve görüntülere dönüşümü tam olarak test edebilir miyim?

Evet. [Dönüştürücüler](/slides/tr/net/convert-presentation/) çalışır; çıktı bir filigran içerecektir.

### Filigransız yük testi için geçici bir lisans kullanabilir miyim?

Evet. 30 günlük geçici lisans, değerlendirme modundaki sınırlamaları kaldırır ve filigransız test yapmanıza izin verir.