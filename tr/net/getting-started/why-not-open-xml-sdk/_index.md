---
title: Neden Open XML SDK?
type: docs
weight: 50
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
description: "Aspose.Slides'in ücretsiz Open XML SDK'dan daha iyi bir seçim olmasının nedenini görün: özellikleri karşılaştırın, otomasyon gerektirmeyen dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışırken Open XML SDK veya Aspose.Slides'i ne zaman tercih edebileceklerini açıklar. Open XML SDK, OOXML paketlerini ve altındaki XML öğelerini manipüle etmek için bir kütüphane olarak tanımlanırken, Aspose.Slides, yüksek seviyeli bir nesne modeli ve birçok PowerPoint‑ile‑ilgili görevi destekleyen bir sunum işleme kütüphanesi olarak sunulur.

Makale, her iki seçeneği desteklenen formatlar, programlama modeli, renderleme, platform desteği ve yaygın kullanım senaryoları açısından karşılaştırır. Ayrıca Open XML SDK'nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceğini, Aspose.Slides'in ise birden çok PowerPoint formatı üzerinde çalışma, şekilleri kopyalama veya klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS'ye dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğunu da açıklığa kavuşturur.

## **Open XML SDK Nedir?**
Bazen şu soruyu alırız: *Neden ücretsiz Open XML SDK yerine Aspose ürünlerini kullanmalıyız?* 

Bu soruyu özellikler ve işlevsellik açısından cevaplamak bizim için kolaydır. 

According to the [MSDN Kütüphanesi](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK is defined this way: 

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly‑typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamaların aşağıdaki sunum işleme görevlerini gerçekleştirmesine olanak tanıyan bir sınıf kütüphanesidir: 

- Sunum nesne modeliyle programlama.  
- PDF, XPS ve TIFF dahil, tüm popüler desteklenen PowerPoint sunum formatlarını kapsayan yüksek kaliteli dönüşümler.  
- PNG, JPEG ve BMP gibi bilinen formatlarda slayt küçük görselleri oluşturma ve slaytları SVG olarak dışa aktarma.  
- Sıfırdan ya da birden çok belgeden öğeleri birleştirerek sunum oluşturma.  
- Animasyonlar, OLE Çerçeveleri, tablolar ekleme, grafikler oluşturma ve yönetme.  
- TextFrames, Paragraflar ve Bölümler seviyelerinde metin biçimlendirmesini kontrol etme (kapsamlı kontrol) ve yönetme.  

Daha fazla ayrıntı için lütfen [Aspose.Slides Özellikleri](/slides/tr/net/product-overview/) sayfasına bakın.

## **Open XML SDK ile Aspose.Slides'i Karşılaştırın**
Bu tablo, Open XML SDK yeteneklerini ve özelliklerini Aspose.Slides ile karşılaştırır.

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e Dönüştürme |Hayır|Evet|
|<p>Yüksek seviyeli programlama ile bir Presentation Document Object Model (DOM): </p><p>- Metin bul ve değiştir.</p><p>- Sunumlarda slaytları birleştir.</p>|Hayır|Evet|
|Detaylı programlama ile bir belge nesne modeli; TextHolders, TextFrames, Paragraphs ve Portions gibi bireysel öğelere ve biçimlendirmeye erişim.|Evet|Evet|
|OOXML belgesinin ilişki tanımlayıcıları, liste tanımlayıcıları gibi temel XML öğeleri ve özniteliklerine düşük seviyeli doğrudan ve tam erişim.|Evet|Hayır|
|<p>Sunum Renderleme:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine renderla.</p><p>- Slayt küçük görsellerini PNG, JPEG, BMP, SVG ve TIFF olarak renderla.</p><p>- Görüntü çözünürlüğü, kalitesi, sıkıştırması ve diğer seçenekleri belirt.</p>|Hayır|Evet|
|Desteklenen platformlar|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Sonuç**
Open XML SDK ve Aspose.Slides doğrudan rekabet etmez çünkü çok farklı ihtiyaçları karşılar ve farklı hedef kitlelere yöneliktir. 

{{% alert color="info" %}} 

Open XML SDK, OOXML belgeleriyle çalışmak için güçlü tipli bir yol sağlayan bir sınıf kütüphanesidir; Aspose.Slides ise neredeyse tüm Microsoft PowerPoint dosya formatları için harika destek sunan son derece faydalı bir sunum işleme kütüphanesidir. 

{{% /alert %}} 

Eğer iş akışınız bir PPTX belgesi üzerinde temel bir programlama işlemi ise, Open XML SDK iyi bir seçim olabilir. Open XML SDK ile basit bir PPTX belge oluşturma, yorumları, üstbilgi/altbilgileri kaldırma, resimleri çıkarma gibi basit görevleri rahatlıkla yapabilirsiniz. Bazı görevler Open XML SDK ile yapılabilir ancak Aspose.Slides ile yapılamaz. Örneğin, bir OOXML belgesinin XML öğelerine ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK kullanmalısınız. 

Belgeler üzerinde karmaşık görevler gerçekleştirmeniz gerekiyorsa—aşağıdaki listedeki görevler gibi—Aspose.Slides en iyi seçeneğinizdir. 

- Eski PowerPoint formatlarını (ve PPTX'i) içeren işlemler.  
- Slaytlar içinde şekilleri kopyalama veya klonlama, nesneleri, stilleri ve diğer biçimlendirme öğelerini uygun bir şekilde birleştirme.  
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.  
- Şekillere animasyon uygulama ve bağlayıcılar kullanma.  
- Bir belgeyi PDF, TIFF veya XPS'ye dönüştürme, böylece Microsoft PowerPoint'in dönüşüm yaptığı gibi görünmesi.  
- .NET veya Java uygulamasını hem masaüstü hem de web tabanlı ortamlarda geliştirme.