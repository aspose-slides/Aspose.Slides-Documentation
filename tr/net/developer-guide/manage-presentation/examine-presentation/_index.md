---
title: .NET'te Sunum Bilgilerini Getirme ve Güncelleme
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
description: ".NET kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'da sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden mevcut formatını belirleme, belge özelliklerini okuma ve gerektiğinde bu özellikleri güncelleme yöntemlerini açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/) API'lerine dayanır ve sunum meta verileriyle çalışmak için tipik işlemleri gösterir.

## **Sunum Formatını Kontrol Et**

Sunum üzerinde çalışmadan önce, mevcut formatının (PPT, PPTX, ODP ve diğerleri) ne olduğunu öğrenmek isteyebilirsiniz.

Sunumun formatını sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki C# koduna bakın:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Sunum Özelliklerini Al**

Bu C# kodu, sunum özelliklerini (sunumla ilgili bilgileri) nasıl alacağınızı gösterir:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

DocumentProperties sınıfı altındaki [özellikler](https://reference.aspose.com/slides/tr/net/aspose.slides/documentproperties/#properties) sınıfına bakabilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) yöntemini sağlar.

Diyelim ki aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz var.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Belge özelliklerini değiştirmenin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik nitelikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar faydalı olabilir:

- [Sunumları Parola ile Koru](/slides/tr/net/password-protected-presentation/)
- [Sunumları Yazma Korumasına Al](/slides/tr/net/write-protected-presentation/)

## **SSS**

**Sunularda fontların gömülü olup olmadığını ve hangi fontların gömülü olduğunu nasıl kontrol edebilirim?**

Sunum seviyesinde [embedded-font information](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getembeddedfonts/) arayın, ardından bu girdileri içerik boyunca kullanılan [fonts actually used across content](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsmanager/getfonts/) ile karşılaştırarak hangi fontların render için kritik olduğunu belirleyin.

**Dosyada gizli slaytların olup olmadığını ve sayısını nasıl hızla öğrenebilirim?**

[slide collection](https://reference.aspose.com/slides/tr/net/aspose.slides/slidecollection/) üzerinden döngü yapın ve her slaydın [visibility flag](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slide size](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slidesize/) ve yönü standart ön ayarlarla karşılaştırın; bu, baskı ve dışa aktarma davranışını önceden tahmin etmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlıca görmek mümkün mü?**

Evet. Tüm [charts](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/) öğelerini dolaşın, [data source](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/datasourcetype/) tipini kontrol edin ve verinin içsel mi yoksa bağlantı bazlı mı olduğunu, ayrıca kırık bağlantılar olup olmadığını not edin.

**Render veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayısını sayın ve büyük resimler, şeffaflık, gölgeler, animasyonlar ve multimedya öğelerini kontrol edin; potansiyel performans sorunlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.