---
title: Open XML SDK Neden Kullanılmamalı
type: docs
weight: 50
url: /tr/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
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
description: "Aspose.Slides'ın ücretsiz Open XML SDK'ya göre neden daha iyi bir seçim olduğunu görün: özellikleri karşılaştırın, otomasyon gerektirmeyen dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışmak için Open XML SDK veya Aspose.Slides'ı ne zaman tercih edebileceğini açıklar. Open XML SDK, OOXML paketlerini ve bunların altındaki XML öğelerini manipüle eden bir kütüphane olarak tanımlanırken, Aspose.Slides yüksek seviyeli bir nesne modeli ve birçok PowerPoint ile ilgili görevi destekleyen bir sunum işleme kütüphanesi olarak sunulmaktadır.

Makale, her iki seçeneği desteklenen formatlar, programlama modeli, renderleme ve yazdırma yetenekleri, platform desteği ve ortak kullanım senaryoları açısından karşılaştırır. Ayrıca, Open XML SDK'nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides'ın ise birden çok PowerPoint formatı ile çalışma, şekilleri kopyalama veya klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS'ye dönüştürme gibi karmaşık görevler için daha uygun olduğu da açıklanır.

## **Open XML SDK Nedir?**
Bazen şu soruyu alırız: *Neden ücretsiz Open XML SDK yerine Aspose ürünlerini kullanmalıyız?* 

Bu soruya özellikler ve işlevsellik bağlamında cevap vermek kolaydır. 

[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) göre Open XML SDK şu şekilde tanımlanır: 

> "Open XML SDK 2.0, Open XML paketlerini ve bir paket içindeki temel Open XML şema öğelerini manipüle etme görevini basitleştirir. Open XML SDK 2.0, geliştiricilerin Open XML paketleri üzerinde gerçekleştirdiği birçok yaygın görevi kapsüller, böylece sadece birkaç satır kodla karmaşık işlemler yapabilirsiniz. OOXML belgeleri temelde sıkıştırılmış XML dosyalarıdır ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü tipli bir şekilde çalışmanıza olanak tanıyan bir sınıf koleksiyonudur. Yani bir dosyayı açıp XML'i çıkarmak, XML'i bir DOM ağacına yüklemek ve XML öğeleri ve öznitelikleriyle doğrudan çalışmak yerine, Open XML SDK bu işi yapacak sınıfları sağlar."

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamaların aşağıdaki sunum işleme görevlerini gerçekleştirmesini sağlayan bir sınıf kitaplığıdır: 

- Sunum nesne modeliyle programlama.
- PDF, XPS, TIFF gibi tüm popüler PowerPoint sunum formatları dahil yüksek kaliteli dönüşümler ve yazdırma.
- PNG, JPEG ve BMP gibi yaygın formatlarda slayt küçük resimleri oluşturma ve slaytları SVG olarak dışa aktarma.
- Sıfırdan sunum oluşturma veya bir veya birden fazla belgeden öğeler birleştirerek sunum oluşturma.
- Animasyonlar, OLE Çerçeveleri, tablolar ekleme, grafikler oluşturma ve yönetme.
- TextFrames, Paragraflar ve Bölümler seviyesinde metin biçimlendirmesini (kapsamlı kontrol) yönetme. 

Daha fazla özellik ayrıntısı için lütfen [Aspose.Slides Features](/slides/tr/net/product-overview/) sayfasına bakın.
## **Open XML SDK ve Aspose.Slides Karşılaştırması**
Bu tablo, Open XML SDK yeteneklerini ve özelliklerini Aspose.Slides ile karşılaştırır.

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e dönüşüm|Hayır|Evet|
|<p>Sunum Belge Nesne Modeli (DOM) ile yüksek seviyeli programlama: </p><p>- Metinleri bul ve değiştir.</p><p>- Sunumlarda slaytları birleştir.</p>|Hayır|Evet|
|Belge nesne modeli ile ayrıntılı programlama; TextHolders, TextFrames, Paragraphs ve Portions gibi bireysel öğelere ve biçimlendirmeye erişim.|Evet|Evet|
|İlişki tanımlayıcıları, OOXML belgesinin liste tanımlayıcıları gibi temel XML öğeleri ve özniteliklerine düşük seviyeli doğrudan ve tam erişim.|Evet|Hayır|
|<p>Renderleme ve Yazdırma:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine renderle.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF formatlarına renderle.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirt.</p><p>- .NET baskı altyapısını kullanarak sunumları yazdır. Bileşen, MS PowerPoint'in Yazdırma Önizlemesi'nde gösterildiği gibi sunumları yazdırmak için yerleşik bir yazdırma metoduna sahiptir.</p>|Hayır|Evet|
|Desteklenen platformlar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Sonuç**
Open XML SDK ve Aspose.Slides doğrudan rekabet etmez çünkü çok farklı ihtiyaçlara hitap eder ve farklı hedef kitlelere yöneliktir. 

{{% alert color="info" %}} 

Open XML SDK, OOXML belgeleriyle çalışmak için güçlü tipli bir yol sağlayan bir sınıf kitaplığı iken Aspose.Slides, neredeyse tüm Microsoft PowerPoint dosya formatları için mükemmel destek sunan son derece yararlı bir sunum işleme kitaplığıdır. 

{{% /alert %}} 

Eğer iş akışınız bir PPTX belgesi üzerinde temel programlama işlemleri içeriyorsa, Open XML SDK iyi bir seçim olabilir. Open XML SDK ile basit bir PPTX belgesi oluşturma, yorumları, başlık/altbilgileri kaldırma, resimleri çıkarma gibi görevleri rahatça yapabilirsiniz. Belirli görevler Open XML SDK ile yapılabilir ancak Aspose.Slides ile yapılamaz. Örneğin, bir OOXML belgesinin XML öğelerine ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK kullanmanız gerekir. 

Eğer belgeler üzerinde aşağıdaki gibi karmaşık görevler gerçekleştirmeniz gerekiyorsa Aspose.Slides sizin için en iyi seçenektir. 

- Eski PowerPoint formatlarını (ve PPTX'i de) içeren işlemler.  
- Slaytlar içinde şekilleri kopyalama veya çoğaltma, nesneleri, stilleri ve diğer biçimlendirme öğelerini uygun bir şekilde birleştiren bir yöntem.  
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.  
- Şekillere animasyon uygulama ve bağlayıcıları kullanma.  
- Bir belgeyi PDF, TIFF veya XPS'ye dönüştürme, böylece Microsoft PowerPoint'in yaptığı gibi görünür.  
- .NET veya Java uygulamasını hem masaüstü hem de web tabanlı ortamlarda geliştirme.