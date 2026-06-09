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
description: "PowerPoint ve OpenDocument sunumlarındaki slaytları, yapıyı ve meta verileri .NET kullanarak keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden mevcut formatını nasıl belirleyeceğinizi, belge özelliklerini nasıl okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/) API'lerine dayanmakta olup, sunum meta verileriyle çalışmak için tipik işlemleri göstermektedir.

## **Bir Sunum Formatını Kontrol Etme**

Bir sunum üzerinde çalışmadan önce, sunumun o anda hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumu yüklemeden bir sunumun formatını kontrol edebilirsiniz. Aşağıdaki C# koduna bakın:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Sunum Özelliklerini Almak**

Bu C# kodu, sunum özelliklerini (sunum hakkındaki bilgileri) nasıl alacağınızı gösterir:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ...
```

DocumentProperties sınıfı altındaki [özellikleri](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/#properties) görebilirsiniz.

## **Sunum Özelliklerini Güncelleme**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanızı sağlayan [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) metodunu sunar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Belge özelliklerinin değiştirilmesinin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Yararlı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar yararlı olabilir:

- [Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme](https://docs.aspose.com/slides/tr/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Bir Sunumun Yazma Koruması (salt okunur) olup olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Bir Sunumu Yüklemeden Önce Parola Koruması Olup Olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bir Sunumu Koruyan Parolayı Doğrulama](https://docs.aspose.com/slides/tr/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunum seviyesindeki [embedded-font information](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getembeddedfonts/) arayın, ardından bu girdileri [fonts actually used across content](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getfonts/) kümesiyle karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

[slide collection](https://reference.aspose.com/slides/tr/net/aspose.slides/slidecollection/) içinde döngü yapın ve her slaydın [visibility flag](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yönlendirmesi kullanılıyor mu, varsayılanlardan farklı mı olduğunu tespit edebilir miyim?**

Evet. Mevcut [slide size](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slidesize/) ve yönlendirmeyi standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarım davranışını öngörmeye yardımcı olur.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde görebilir miyim?**

Evet. Tüm [charts](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/) üzerinde gezinerek, [data source](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/datasourcetype/) kontrol edin ve verinin dahili mi yoksa bağlantı temelli mi olduğunu, varsa kırık bağlantıları not edin.

**Render veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını toplayın ve büyük görüntüler, şeffaflık, gölgeler, animasyonlar ve multimedya gibi öğeleri arayın; potansiyel performans darboğazlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.