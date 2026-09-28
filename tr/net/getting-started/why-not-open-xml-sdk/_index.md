---
title: Neden Open XML SDK?
type: docs
weight: 180
url: /tr/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- karşılaştırma
- sunum nesne modeli
- yüksek kaliteli dönüşüm
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides'in ücretsiz Open XML SDK'dan neden daha iyi bir seçim olduğunu görün: özellikleri karşılaştırın, otomasyonsuz dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışırken Open XML SDK veya Aspose.Slides'i ne zaman tercih edebileceğini açıklar. Open XML SDK'nın OOXML paketlerini ve altındaki XML öğelerini manipüle eden bir kütüphane olduğu, Aspose.Slides'in ise yüksek seviyeli bir nesne modeli ve birçok PowerPoint‑related görevi destekleyen bir sunum işleme kütüphanesi olduğu belirtilir.

Makale, her iki seçeneği desteklenen formatlar, programlama modeli, renderleme, platform desteği ve ortak kullanım senaryoları açısından karşılaştırır. Ayrıca Open XML SDK'nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides'in ise birden fazla PowerPoint formatı ile çalışma, şekilleri kopyalama veya klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS'ye dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğu açıklanır.

## **Open XML SDK Nedir?**
Bazen şu soru sorulur: *Aspose ürünlerini ücretsiz Open XML SDK yerine neden kullanmalıyız?*

Bu soruya özellikler ve işlevsellik açısından cevap vermek kolaydır.

[MSDN Kütüphanesi](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) göre, Open XML SDK şu şekilde tanımlanır:

> "Open XML SDK 2.0, Open XML paketlerini ve bir paket içindeki temel Open XML şema öğelerini manipüle etme görevini basitleştirir. Open XML SDK 2.0, geliştiricilerin Open XML paketleri üzerinde gerçekleştirdiği birçok ortak görevi kapsüller, böylece sadece birkaç satır kodla karmaşık işlemler yapabilirsiniz. OOXML belgeleri temelde sıkıştırılmış XML dosyalarıdır ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü tipli bir şekilde çalışmanıza olanak tanıyan sınıflar koleksiyonudur. Yani dosyayı açıp XML'i çıkarmak, XML'i bir DOM ağacına yüklemek ve XML öğeleriyle doğrudan çalışmak yerine, Open XML SDK bu işlemleri gerçekleştiren sınıflar sunar."

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamaların aşağıdaki sunum işleme görevlerini gerçekleştirmesini sağlayan bir sınıf kütüphanesidir:

- Sunum nesne modeliyle programlama.
- PDF, XPS ve TIFF dahil olmak üzere tüm popüler PowerPoint sunum formatlarını yüksek kaliteyle dönüştürme.
- PNG, JPEG ve BMP gibi bilinen formatlarda slayt küçük resimleri oluşturma ve slaytları SVG olarak dışa aktarma.
- Sıfırdan sunum oluşturma veya bir veya birden çok belgeden öğeler birleştirme.
- Animasyonlar, OLE Çerçeveleri, tablolar ekleme, grafik oluşturma ve yönetme.
- TextFrames, Paragraflar ve Bölümler seviyesinde metin biçimlendirmesini (geniş kontrol) yönetme.

Mevcut özellikler hakkında daha fazla ayrıntı için lütfen [Aspose.Slides Özellikleri](/slides/tr/net/product-overview/) sayfasına bakın.

## **Open XML SDK ve Aspose.Slides Karşılaştırması**
Bu tablo, Open XML SDK yeteneklerini ve özelliklerini Aspose.Slides ile karşılaştırır.

|**Özellik ya da Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e dönüşüm|Hayır|Evet|
|<p>Sunum Belgesi Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bul ve değiştir.</p><p>- Sunumlarda slaytları birleştir.</p>|Hayır|Evet|
|Belge nesne modeliyle ayrıntılı programlama; TextHolders, TextFrames, Paragraflar ve Bölümler gibi bireysel öğelere ve biçimlendirmelere erişim.|Evet|Evet|
|Alttaki XML öğeleri ve özniteliklerine (ilişki kimlikleri, OOXML belgesinin liste kimlikleri vb.) düşük seviyeli doğrudan ve tam erişim.|Evet|Hayır|
|<p>Sunum Renderleme:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine renderle.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF olarak renderle.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirt.</p>|Hayır|Evet|
|Desteklenen platformlar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Sonuç**
Open XML SDK ve Aspose.Slides doğrudan rekabet etmez; çünkü çok farklı ihtiyaçları karşılar ve farklı hedef kitlelere yöneliktir.

{{% alert color="info" title="Not" %}}
Open XML SDK, OOXML belgeleriyle güçlü tipli bir şekilde çalışmanızı sağlayan bir sınıf kütüphanesidir; Aspose.Slides ise neredeyse tüm Microsoft PowerPoint dosya formatlarını destekleyen son derece kullanışlı bir sunum işleme kütüphanesidir.
{{% /alert %}}

Eğer iş akışınız PPTX belgesi üzerinde temel bir programlama işlemi ise, Open XML SDK iyi bir tercih olabilir. Open XML SDK ile basit bir PPTX belgesi oluşturma, yorumları, üstbilgi/altbilgileri kaldırma, resimleri çıkarma gibi görevleri rahatça yapabilirsiniz. Bazı görevler Open XML SDK ile yapılabilir ancak Aspose.Slides ile yapılamaz. Örneğin, bir OOXML belgesinin XML öğeleri ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK kullanmalısınız.

Belgelere karmaşık görevler uygulamanız gerekiyorsa — aşağıdaki listedeki görevler gibi — Aspose.Slides en iyi seçeneğinizdir.

- Eski PowerPoint formatlarını (ve PPTX'i) içeren işlemler.
- Slaytlardaki şekilleri, nesneleri, stilleri ve diğer biçimlendirme öğelerini uygun şekilde birleştirerek kopyalama veya klonlama.
- Biçimlenmiş veya biçimsiz metni değiştirme.
- Şekillerle animasyon uygulama ve bağlantı elemanları kullanma.
- Belgeyi PDF, TIFF veya XPS'ye dönüştürme, böylece Microsoft PowerPoint'in yaptığı gibi görünmesini sağlama.
- Hem masaüstü hem de web tabanlı ortamlarda .NET veya Java uygulaması geliştirme.