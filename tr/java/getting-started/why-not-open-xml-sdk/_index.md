---
title: Neden Open XML SDK Kullanılmasın
type: docs
weight: 120
url: /tr/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- karşılaştırma
- sunum nesne modeli
- yüksek kalite dönüştürme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides'in ücretsiz Open XML SDK'dan daha iyi bir seçim olmasının nedenini görün: özellikleri karşılaştırın, otomasyonsuz dönüştürme ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışmak için Open XML SDK mı yoksa Aspose.Slides mi seçeceklerine dair kararlarını açıklar. Open XML SDK, OOXML paketlerini ve bunların altındaki XML öğelerini manipüle etmek için bir kütüphane olarak tanımlanırken, Aspose.Slides, yüksek seviyeli bir nesne modeli ve birçok PowerPoint ile ilgili görevi destekleyen bir sunum işleme kütüphanesi olarak sunulmaktadır.

Makale, desteklenen formatlar, programlama modeli, renderleme, platform desteği ve yaygın kullanım senaryoları açısından her iki seçeneği karşılaştırır. Ayrıca, Open XML SDK’nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides’ın ise birden çok PowerPoint formatı ile çalışma, şekilleri kopyalama veya klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS’ye dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğu da belirtilir.

## **Open XML SDK Nedir?**
According to the [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK is defined as: 

The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open 

XML packages, so that you can perform complex operations with just a few lines of code.

OOXML belgeleri esasen sıkıştırılmış XML dosyalarıdır ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü tipli bir şekilde çalışmanıza olanak tanıyan sınıfların bir koleksiyonudur. Yani bir dosyayı sıkıştırmayı açıp XML’i çıkarmak, bu XML’i bir DOM ağacına yüklemek ve XML öğeleri ve öznitelikleriyle doğrudan çalışmak yerine, Open XML SDK bu işlemleri gerçekleştirecek sınıfları sağlar.

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamanızın aşağıdaki sunum işleme görevlerini gerçekleştirmesini sağlayan bir sınıf kitaplığıdır:

- Bir **Presentation** nesne modeli ile programlama.
- PDF, XPS ve TIFF dahil olmak üzere tüm popüler desteklenen PowerPoint sunum formatları arasında yüksek kaliteli dönüşümler.
- PNG, JPEG ve BMP gibi yaygın formatlarda slayt küçük resimleri oluşturma ve slaytı SVG’ye dışa aktarma yeteneği.
- Sıfırdan veya bir veya birden fazla belgeden birleştirerek sunumlar oluşturma yeteneği.
- Animasyonlar, Ole Frames, Tablolar ekleme, grafik oluşturma ve yönetme desteği.
- TextFrames, Paragraphs ve Portions seviyelerinde metin biçimlendirmesini yönetmek için kapsamlı kontrol.

Daha fazla özellik detayı için lütfen [Aspose.Slides Features](/slides/tr/java/product-overview/) adresini ziyaret edin.

## **Open XML SDK ile Aspose.Slides Karşılaştırması**
{{% alert color="info" %}} 

Aşağıdaki tablo Open XML SDK ve Aspose.Slides özelliklerini karşılaştırmaktadır.

{{% /alert %}} 

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen Sunum Formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e Dönüştürme|Hayır|Evet|
|<p>Sunum Belgesi Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bul ve değiştir.</p><p>- Sunumlardaki slaytları birleştir.</p>|Hayır|Evet|
|Belge nesne modeli ile ayrıntılı programlama, TextHolders, TextFrames, Paragraphs ve Portions gibi bireysel öğelere ve biçimlendirmeye erişim.|Evet|Evet|
|İlişki tanımlayıcıları, bir OOXML belgesinin liste tanımlayıcıları gibi temel XML öğeleri ve özniteliklerine düşük seviyeli doğrudan ve tam erişim.|Evet|Hayır|
|<p>Renderleme:</p><p>- Sunumları PDF, PDF Notes, XPS, TIFF görüntülerine dönüştür.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF olarak renderle.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirt.</p>|Hayır|Evet|
|Desteklenen platformlar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Sonuç**
{{% alert color="info" %}} 

Open XML SDK ve Aspose.Slides doğrudan rekabet etmez çünkü çok farklı ihtiyaç ve hedef kitlelere hitap ederler. Open XML SDK, OOXML belgeleriyle güçlü tipli bir şekilde çalışmak için bir sınıf kitaplığıdır. Aspose.Slides ise neredeyse tüm Microsoft PowerPoint dosya formatları için büyük destek sağlayan çok yararlı bir sunum işleme kütüphanesidir.

Eğer tek yapmanız gereken bir PPTX belgesi üzerinde oldukça temel bir programlama işlemi ise, Open XML SDK uygun bir seçim olabilir. Open XML SDK ile basit bir PPTX belgesi oluşturma, yorumları, üstbilgi/altbilgileri kaldırma, resimleri çıkarma gibi görevleri rahatça yapabilirsiniz. Bazı görevler Open XML SDK ile gerçekleştirilebilir, ancak Aspose.Slides ile gerçekleştirilemez. Örneğin, bir OOXML belgesinin XML öğelerine ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK kullanmalısınız. Ancak, aşağıdaki gibi karmaşık belgeler üzerinde işlem yapmanız gerekiyorsa Aspose.Slides en iyi seçenektir:

- PPTX'in yanı sıra eski PowerPoint formatlarını da destekleme.
- Slaytlardaki şekilleri, nesneleri, stilleri ve diğer biçimlendirmeleri uygun şekilde birleştirerek kopyalama veya klonlama.
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.
- Animasyonları uygulama ve şekillerle kullanılan bağlayıcıları kullanma.
- Bir belgeyi PDF, TIFF veya XPS'ye dönüştürerek tam olarak Microsoft PowerPoint'in dönüştürmesi gibi görünmesini sağlama.
- .NET veya Java uygulamasını hem masaüstü hem de web tabanlı ortamlarda geliştirme.

{{% /alert %}}