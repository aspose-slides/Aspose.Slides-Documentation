---
title: Neden Open XML SDK?
type: docs
weight: 120
url: /tr/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- karşılaştırma
- sunum nesne modeli
- yüksek kaliteli dönüşüm
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides'in ücretsiz Open XML SDK'ya göre neden daha iyi bir seçim olduğunu görün: özellikleri karşılaştırın, otomasyonsuz dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışırken Open XML SDK veya Aspose.Slides'i ne zaman tercih edebileceklerini açıklar. Open XML SDK, OOXML paketlerini ve bunların altında yatan XML öğelerini işlemek için bir kütüphane olarak tanımlanırken, Aspose.Slides, yüksek seviyeli bir nesne modeli ve birçok PowerPoint‑related görevi destekleyen bir sunum işleme kütüphanesi olarak sunulmaktadır.

Makale, her iki seçeneği desteklenen formatlar, programlama modeli, render ve yazdırma yetenekleri, platform desteği ve yaygın kullanım senaryoları açısından karşılaştırır. Ayrıca, Open XML SDK’nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides’ın ise birden fazla PowerPoint formatı ile çalışma, şekilleri kopyalama ya da klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS’ye dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğu belirtilir.

## **Open XML SDK Nedir?**
[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)’e göre Open XML SDK şu şekilde tanımlanmıştır:

Open XML SDK 2.0, Open XML paketlerini ve paketin içindeki temel Open XML şema öğelerini işlerken görevleri basitleştirir. Open XML SDK 2.0, geliştiricilerin Open XML paketleri üzerinde gerçekleştirdiği birçok yaygın görevi kapsüller; böylece yalnızca birkaç satır kodla karmaşık işlemler yapabilirsiniz.

OOXML belgeleri esasen sıkıştırılmış XML dosyalarıdır ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü tiplenmiş bir şekilde çalışmanıza olanak tanıyan sınıflar koleksiyonudur. Yani bir dosyayı açıp XML’i çıkarmak, bu XML’i bir DOM ağacına yüklemek ve XML öğeleriyle nitelikleri doğrudan işlemek yerine, Open XML SDK bu işi yapacak sınıfları sunar.

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamanızın aşağıdaki sunum işleme görevlerini gerçekleştirmesine olanak tanıyan bir sınıf kitaplığıdır:

- **Presentation** nesne modeliyle programlama.
- PDF, XPS ve TIFF dahil olmak üzere tüm popüler PowerPoint sunum formatları arasında yüksek kalite dönüşümler.
- PNG, JPEG ve BMP gibi bilinen formatlarda slayt küçük resimleri oluşturma ve slaytı SVG olarak dışa aktarma yeteneği.
- Sıfırdan ya da bir veya birden fazla belgeden birleştirerek sunum oluşturma.
- Animasyonlar, OLE Çerçeveleri, Tablolar ekleme, grafik oluşturma ve yönetme desteği.
- TextFrames, Paragraflar ve Bölümler düzeyinde metin biçimlendirmesi üzerinde kapsamlı kontrol.

Desteklenen özellikler hakkında daha fazla bilgi için lütfen [Aspose.Slides Features](/slides/tr/php-java/product-overview/) sayfasını ziyaret edin.

## **Open XML SDK ve Aspose.Slides Karşılaştırması**
{{% alert color="primary" %}} 

Aşağıdaki tablo, Open XML SDK ve Aspose.Slides özelliklerini karşılaştırır.

{{% /alert %}} 

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen Sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT’den PPTX’e dönüşüm|Hayır|Evet|
|<p>Sunum Belgesi Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bul ve değiştir.</p><p>- Sunumlarda slaytları birleştir.</p>|Hayır|Evet|
|Belge nesne modeliyle detaylı programlama, TextHolders, TextFrames, Paragraflar ve Bölümler gibi bireysel öğelere ve biçimlendirmeye erişim.|Evet|Evet|
|OOXML belgesinin ilişki tanımlayıcıları, liste tanımlayıcıları gibi temel XML öğeleri ve niteliklerine düşük seviyeli tam erişim.|Evet|Hayır|
|<p>Render:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine render et.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF olarak render et.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirt.</p>|Hayır|Evet|
|Desteklenen platformlar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Sonuç**
{{% alert color="primary" %}} 

Open XML SDK ve Aspose.Slides, çok farklı ihtiyaç ve hedef kitlelere hitap ettikleri için doğrudan rekabet içinde değildir. Open XML SDK, OOXML belgeleriyle güçlü tiplenmiş bir şekilde çalışmayı sağlayan bir sınıf kitaplığıdır. Aspose.Slides ise neredeyse tüm Microsoft PowerPoint dosya formatları için mükemmel destek sunan çok yönlü bir sunum işleme kütüphanesidir.

Eğer sadece PPTX belgesi üzerinde temel bir programlama işlemi yapmanız gerekiyorsa, Open XML SDK uygun bir seçim olabilir. Open XML SDK ile basit bir PPTX belge oluşturma, yorumları, başlık/alt bilgileri kaldırma, görüntüleri çıkarma gibi görevleri rahatlıkla yapabilirsiniz. Bazı görevler Open XML SDK ile gerçekleştirilebilir ancak Aspose.Slides ile yapılamaz. Örneğin, bir OOXML belgesinin XML öğelerine ve niteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK’yı kullanmalısınız. Ancak belgeler üzerinde aşağıdaki gibi karmaşık işlemler yapmanız gerekiyorsa Aspose.Slides en iyi seçenektir:

- PPTX’e ek olarak daha eski PowerPoint formatlarını destekleme.
- Slaytlardaki şekilleri nesne, stil ve diğer biçimlendirmeleri uygun şekilde birleştirerek kopyalama veya klonlama.
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.
- Şekillerle birlikte bağlayıcılar kullanarak animasyon ekleme.
- Belgeyi PDF, TIFF veya XPS’ye dönüştürerek Microsoft PowerPoint’in dönüşüm kalitesini tam olarak elde etme.
- Hem masaüstü hem de web tabanlı ortamlarda .NET veya Java uygulamaları geliştirme.

{{% /alert %}}