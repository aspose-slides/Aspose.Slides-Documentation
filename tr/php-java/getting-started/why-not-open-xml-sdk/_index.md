---
title: "Open XML SDK Neden Değil?"
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
description: "Aspose.Slides'in ücretsiz Open XML SDK'dan daha iyi bir seçenek olduğunu görün: özellikleri karşılaştırın, otomasyonsuz dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışmak için Open XML SDK veya Aspose.Slides'i ne zaman seçebileceğini açıklar. Open XML SDK, OOXML paketlerini ve bunların temel XML öğelerini manipüle eden bir kütüphane olarak tanımlanırken, Aspose.Slides bir sunum işleme kütüphanesi olarak yüksek seviyeli bir nesne modeli ve birçok PowerPoint ile ilgili görevi destekleyecek şekilde sunulmaktadır.

Makale, her iki seçeneği desteklenen formatlar, programlama modeli, renderleme, platform desteği ve ortak kullanım senaryoları açısından karşılaştırır. Ayrıca Open XML SDK'nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides'ın ise birden fazla PowerPoint formatı ile çalışma, şekilleri kopyalama veya klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS'e dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğu açıklanır.

## **Open XML SDK Nedir?**
According to the [MSDN Kütüphanesi](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK is defined as: 

The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open 

XML packages, so that you can perform complex operations with just a few lines of code.

OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to 

extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.

## **Aspose.Slides Nedir?**
Aspose.Slides is a class library that allows your application to perform the following presentation processing tasks:

- **Presentation** nesne modeliyle programlama.
- PDF, XPS ve TIFF dahil tüm popüler desteklenen PowerPoint sunum formatları arasında yüksek kaliteli dönüşümler.
- PNG, JPEG ve BMP gibi bilinen formatlarda slayt küçük görselleri oluşturma ve slaytları SVG olarak dışa aktarma yeteneği.
- Sıfırdan veya birden çok belgeden birleştirerek sunumlar oluşturma yeteneği.
- Animasyon ekleme, Ole Çerçeveleri, Tablolar, grafikler oluşturma ve yönetme desteği.
- TextFrames, Paragraflar ve Bölümler seviyelerinde metin biçimlendirmesini yönetmek için kapsamlı kontrol imkânı.

For more details about the features supported, please visit [Aspose.Slides Özellikleri](/slides/tr/php-java/product-overview/).

## **Open XML SDK ile Aspose.Slides Karşılaştırması**
{{% alert color="info" %}} 

Aşağıdaki tablo Open XML SDK ve Aspose.Slides özelliklerini karşılaştırır.

{{% /alert %}} 

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen Sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e Dönüştürme|No|Yes|
|<p>Sunum Belgesi Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bul ve değiştir.</p><p>- Sunumlarda slaytları birleştir.</p>|No|Yes|
|Detaylı programlama, belge nesne modeli üzerinden erişim, TextHolders, TextFrames, Paragraflar ve Bölümler gibi öğeler ve biçimlendirme.|Yes|Yes|
|Altta yatan XML öğelerine ve ilişki kimlikleri, liste kimlikleri gibi özniteliklere düşük seviyeli tam erişim.|Yes|No|
|<p>Renderleme:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine renderle.</p><p>- Slayt küçük görsellerini PNG, JPEG, BMP, SVG ve TIFF olarak renderle.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirt.</p>|No|Yes |
|Desteklenen platformlar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Sonuç**
{{% alert color="info" %}} 

Open XML SDK ve Aspose.Slides doğrudan rekabet etmez çünkü çok farklı ihtiyaç ve hedef kitlelere hitap ederler. Open XML SDK, OOXML belgeleriyle güçlü tipli bir şekilde çalışmayı sağlayan bir sınıf kütüphanesidir. Aspose.Slides, neredeyse tüm Microsoft PowerPoint dosya formatlarını destekleyen çok faydalı bir sunum işleme kütüphanesidir.

Eğer tek ihtiyacınız bir PPTX belgesi üzerinde oldukça temel bir programlama işlemi yapmaksa, Open XML SDK uygun bir seçim olabilir. Open XML SDK ile basit bir PPTX belgesi oluşturma, yorumları, üstbilgi/altbilgileri kaldırma, görüntüleri çıkarma gibi görevleri rahatlıkla yapabilirsiniz. Bazı görevler Open XML SDK ile yapılabilir, ancak Aspose.Slides ile yapılamaz. Örneğin, bir OOXML belgesinin XML öğelerine ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK'yı kullanmalısınız. Öte yandan, belgeler üzerinde aşağıdaki gibi karmaşık işlemler yapmanız gerekiyorsa Aspose.Slides en iyi seçenektir:

- PPTX dışındaki eski PowerPoint formatlarını da destekleme.
- Slaytlardaki şekilleri, nesneleri, stilleri ve diğer biçimlendirmeleri uygun bir şekilde birleştirerek kopyalama veya klonlama.
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.
- Animasyonlar uygulama ve şekillerle bağlayıcılar kullanma.
- Belgeyi PDF, TIFF veya XPS'e dönüştürme, böylece tam olarak Microsoft PowerPoint'in dönüştürmesi gibi görünmesini sağlama.
- .NET veya Java uygulamalarını hem masaüstü hem de web tabanlı ortamlarda geliştirme.

{{% /alert %}}