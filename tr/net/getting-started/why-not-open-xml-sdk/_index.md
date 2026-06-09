---
title: Open XML SDK Neden Kullanılmamalı
type: docs
weight: 50
url: /tr/net/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- karşılaştırma
- sunum nesne modeli
- yüksek kalite dönüşüm
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides'in ücretsiz Open XML SDK'ye göre neden daha iyi bir seçim olduğunu görün: özellikleri karşılaştırın, otomasyonsuz dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışmak için Open XML SDK veya Aspose.Slides arasında ne zaman tercih yapabileceklerini açıklamaktadır. Open XML SDK, OOXML paketlerini ve bunların temel XML öğelerini manipüle etmek için bir kütüphane olarak tanımlanırken, Aspose.Slides yüksek seviyeli bir nesne modeli ve birçok PowerPoint‑related görevi destekleyen bir sunum işleme kütüphanesi olarak sunulmaktadır.

Makale, desteklenen formatlar, programlama modeli, renderlama ve yazdırma yetenekleri, platform desteği ve ortak kullanım senaryoları açısından her iki seçeneği karşılaştırır. Ayrıca, Open XML SDK’nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides’ın ise birden fazla PowerPoint formatıyla çalışma, şekilleri kopyalama veya klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS’ye dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğu vurgulanmaktadır.

## **Open XML SDK Nedir?**
Bazen şu soruyu alırız: *Neden ücretsiz Open XML SDK yerine Aspose ürünlerini kullanmalıyız?* 

Bu soruya özellikler ve işlevsellik açısından kolayca yanıt veriyoruz. 

[MSDN Kütüphanesi](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) göre, Open XML SDK şu şekilde tanımlanır: 

> "Open XML SDK 2.0, Open XML paketlerini ve bir paket içindeki temel Open XML şema öğelerini manipüle etme görevini basitleştirir. Open XML SDK 2.0, geliştiricilerin Open XML paketleri üzerinde gerçekleştirdiği birçok yaygın görevi kapsüller, böylece sadece birkaç satır kodla karmaşık işlemler yapabilirsiniz. OOXML belgeleri temelde sıkıştırılmış XML dosyalarıdır ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü bir şekilde tiplenmiş bir şekilde çalışmanıza izin veren sınıflar koleksiyonudur. Yani, bir dosyayı açıp XML'i çıkarmak, bu XML'i bir DOM ağacına yüklemek ve XML öğeleri ve nitelikleriyle doğrudan çalışmak yerine, Open XML SDK bu işlemleri yapmanıza olanak tanıyan sınıflar sağlar."

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamaların aşağıdaki sunum işleme görevlerini yerine getirmesini sağlayan bir sınıf kütüphanesidir: 

- Sunum nesne modeli ile programlama.
- PDF, XPS, TIFF gibi popüler PowerPoint sunum formatlarının yüksek kalitede dönüştürülmesi ve yazdırılması.
- PNG, JPEG ve BMP gibi yaygın formatlarda slayt küçük resimleri oluşturma ve slaytı SVG’ye dışa aktarma.
- Sıfırdan sunum oluşturma veya bir veya birden fazla belgeden öğeler birleştirerek sunum inşa etme.
- Animasyonlar, OLE Çerçeveleri, tablolar ekleme, grafikler oluşturma ve yönetme.
- TextFrames, Paragraflar ve Bölümler seviyesinde metin biçimlendirmeyi (geniş kontrol) yönetme. 

Daha fazla ayrıntı için lütfen [Aspose.Slides Özellikleri](/slides/tr/net/product-overview/) sayfasına bakın.

## **Open XML SDK ile Aspose.Slides Karşılaştırması**
Bu tablo, Open XML SDK yeteneklerini ve özelliklerini Aspose.Slides ile karşılaştırır.

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT’den PPTX’e dönüşüm|Hayır|Evet|
|<p>Sunum Belgesi Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bulma ve değiştirme.</p><p>- Sunumlarda slaytları birleştirme.</p>|Hayır|Evet|
|Belge nesne modeliyle detaylı programlama; TextHolders, TextFrames, Paragraflar ve Bölümler gibi bireysel öğelere ve biçimlendirmeye erişim.|Evet|Evet|
|OOXML belgesinin ilişki tanımlayıcıları, liste tanımlayıcıları gibi temel XML öğeleri ve niteliklerine düşük seviyeli doğrudan ve tam erişim.|Evet|Hayır|
|<p>Renderlama ve Yazdırma:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine renderlama.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF olarak renderlama.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirleme.</p><p>- .NET yazdırma altyapısını kullanarak sunumları yazdırma. Bileşen, MS PowerPoint'in Yazdırma Önizlemesi'nde gösterildiği gibi sunumları yazdırmak için yerleşik bir yazdırma yöntemi sunar.</p>|Hayır|Evet|
|Desteklenen platformlar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Sonuç**
Open XML SDK ve Aspose.Slides doğrudan rekabet etmez; çünkü çok farklı ihtiyaçları karşılar ve farklı hedef kitlelere yöneliktir. 

{{% alert color="primary" %}} 

Open XML SDK, OOXML belgeleriyle güçlü tiplenmiş bir şekilde çalışmayı sağlayan bir sınıf kütüphanesidir; Aspose.Slides ise neredeyse tüm Microsoft PowerPoint dosya formatlarını kapsamlı şekilde destekleyen son derece kullanışlı bir sunum işleme kütüphanesidir. 

{{% /alert %}} 

Eğer iş akışınız bir PPTX belgesi üzerinde temel bir programlama işlemi ise, Open XML SDK iyi bir tercih olabilir. Open XML SDK ile basit bir PPTX belgesi oluşturma, yorumları, üst/alt bilgileri kaldırma, resim çıkarma gibi basit görevleri rahatlıkla gerçekleştirebilirsiniz. Bazı görevler Open XML SDK ile yapılabilirken Aspose.Slides ile yapılamaz. Örneğin, bir OOXML belgesinin XML öğelerine ve niteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK kullanmalısınız. 

Belgeler üzerinde karmaşık görevler (aşağıdaki listede olduğu gibi) gerçekleştirmeniz gerekiyorsa Aspose.Slides en iyi seçeneğinizdir. 

- Daha eski PowerPoint formatlarını (ve PPTX’i de) içeren işlemler.
- Slaytlardaki şekilleri kopyalama veya klonlama; nesneleri, stilleri ve diğer biçimlendirme öğelerini uygun şekilde birleştirme.
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.
- Şekillerle bağlayıcılar kullanarak animasyon uygulama.
- Belgeyi PDF, TIFF veya XPS’ye dönüştürme ve Microsoft PowerPoint’in yaptığı dönüşüm gibi görünmesini sağlama.
- Hem masaüstü hem de web tabanlı ortamlarda .NET veya Java uygulaması geliştirme.