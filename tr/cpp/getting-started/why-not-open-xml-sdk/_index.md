---
title: "Neden Open XML SDK Değil"
type: docs
weight: 100
url: /tr/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- karşılaştırma
- sunum nesne modeli
- yüksek kaliteli dönüşüm
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides'ın ücretsiz Open XML SDK'dan daha iyi bir tercih olmasının nedenini görün: özellikleri karşılaştırın, otomasyon gerektirmeyen dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışmak için Open XML SDK mı yoksa Aspose.Slides mı seçebileceklerini açıklar. Open XML SDK, OOXML paketlerini ve altındaki XML öğelerini manipüle etmek için bir kitaplık olarak tanımlanırken, Aspose.Slides yüksek seviyeli bir nesne modeli sunan ve birçok PowerPoint‑related görevi destekleyen bir sunum işleme kitaplığı olarak sunulmaktadır.

Makale, her iki seçeneği desteklenen formatlar, programlama modeli, render ve baskı yetenekleri, platform desteği ve yaygın kullanım senaryoları açısından karşılaştırır. Ayrıca, Open XML SDK’nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides’ın ise birden fazla PowerPoint formatı ile çalışmak, şekilleri kopyalamak veya çoğaltmak, metin değiştirmek, animasyon uygulamak ve sunumları PDF, TIFF veya XPS formatına dönüştürmek gibi karmaşık görevler için daha uygun olduğu vurgulanmaktadır.

## **Open XML SDK Nedir?**
Bazen şu soru duyulur: Neden ücretsiz Open XML SDK yerine Aspose ürünlerini kullanalım? Bu soruya cevap basittir: özellikler ve işlevsellik. [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) göre, Open XML SDK şu şekilde tanımlanır: Open XML SDK 2.0, Open XML paketlerini ve bir paketin içindeki temel Open XML şema öğelerini manipüle etme görevini basitleştirir. Open XML SDK 2.0, geliştiricilerin Open XML paketleri üzerinde gerçekleştirdiği birçok yaygın görevi kapsüller, böylece birkaç satır kodla karmaşık işlemler yapabilirsiniz. OOXML belgeleri esasen sıkıştırılmış XML dosyalarıdır ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü bir şekilde tiplenmiş bir şekilde çalışmanıza izin veren sınıflar koleksiyonudur. Bu, bir dosyayı açıp XML’i çıkarmak, XML’i bir DOM ağacına yüklemek ve XML öğeleri ve öznitelikleriyle doğrudan çalışmak yerine, Open XML SDK’nın bu işlemler için sınıflar sağlaması anlamına gelir.

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamanızın aşağıdaki sunum işleme görevlerini gerçekleştirmesini sağlayan bir sınıf kitaplığıdır:

- **Presentation** nesne modeli ile programlama.
- Popüler tüm PowerPoint sunum formatları arasında yüksek kaliteli dönüşümler, PDF ve XPS dönüşümleri dahil.
- PNG, JPEG ve BMP gibi bilinen formatlarda slayt küçük resimleri üretme ve slaytı SVG olarak dışa aktarma.
- Sıfırdan veya birden çok belgeden birleştirerek sunumlar oluşturma.
- Animasyonlar, Ole Çerçeveler, Tablolar ekleme, grafikler oluşturma ve yönetme.
- TextFrames, Paragraflar ve Bölümler seviyesinde metin biçimlendirmesi üzerinde kapsamlı kontrol.

Daha fazla özellik detayı için lütfen [Aspose.Slides Features](/slides/tr/cpp/product-overview/) sayfasını ziyaret edin.

## **Open XML SDK ve Aspose.Slides Karşılaştırması**
Aşağıdaki tablo Open XML SDK ve Aspose.Slides özelliklerini karşılaştırmaktadır.

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen Sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e Dönüştürme|Hayır|Evet|
|<p>Sunum Belgesi Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bulma ve değiştirme.</p><p>- Sunumlarda slaytları birleştirme.</p>|Hayır|Evet|
|Belge nesne modeliyle ayrıntılı programlama, TextHolders, TextFrames, Paragraflar ve Bölümler gibi bireysel öğelere ve biçimlendirmelere erişim.|Evet|Evet|
|OOXML belgesinin ilişki tanımlayıcıları, liste tanımlayıcıları gibi temel XML öğeleri ve özniteliklerine düşük seviyeli tam erişim.|Evet|Hayır|
|<p>Render:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine render etme.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF olarak render etme.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirleme.</p>|Hayır|Evet|

## **Sonuç**
Open XML SDK ve Aspose.Slides doğrudan rekabet etmez, çünkü oldukça farklı ihtiyaçları ve hedef kitleleri vardır. Open XML SDK, OOXML belgeleriyle güçlü bir tiplenmiş şekilde çalışmak için bir sınıf kitaplığıdır. Aspose.Slides ise hemen hemen tüm Microsoft PowerPoint dosya formatlarını destekleyen çok kullanışlı bir sunum işleme kitaplığıdır. Eğer tek yapmanız gereken PPTX belgesi üzerinde oldukça temel bir programlama işlemi ise, Open XML SDK uygun bir seçim olabilir. Open XML SDK ile basit bir PPTX belge oluşturma, yorumları, üstbilgi/altbilgileri kaldırma, resimleri çıkarma gibi görevleri rahatça yapabilirsiniz. Bazı görevler Open XML SDK ile gerçekleştirilebilir, ancak Aspose.Slides ile yapılamaz. Örneğin, bir OOXML belgesinin XML öğeleri ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK’yı kullanmalısınız. Diğer yandan, belgeler üzerinde aşağıdaki gibi karmaşık işlemler yapmanız gerekiyorsa Aspose.Slides en iyi seçenektir:

- PPTX’in yanı sıra eski PowerPoint formatlarını da destekleme.
- Slaytlardaki şekilleri, nesneleri, stilleri ve diğer biçimlendirmeleri uygun bir şekilde birleştirerek kopyalama veya çoğaltma.
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.
- Animasyonlar uygulama ve şekillerle bağlayıcılar kullanma.
- Belgeyi PDF veya XPS’ye dönüştürerek Microsoft PowerPoint’in dönüştürdüğü gibi görünmesini sağlama.
- Masaüstü ve konsol tabanlı ortamlarda bir C++ uygulaması geliştirme.