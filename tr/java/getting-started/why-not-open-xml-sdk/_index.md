---
title: Neden Open XML SDK?
type: docs
weight: 120
url: /tr/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- karşılaştırma
- sunum nesne modeli
- yüksek kaliteli dönüşüm
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides'in ücretsiz Open XML SDK'dan neden daha iyi bir seçenek olduğunu görün: özellikleri karşılaştırın, otomasyon gerektirmeyen dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışmak için Open XML SDK veya Aspose.Slides'ı ne zaman tercih edebileceklerini açıklar. Open XML SDK'yı OOXML paketlerini ve bunların altındaki XML öğelerini işlemek için bir kütüphane olarak tanımlarken, Aspose.Slides'ı yüksek seviyeli bir nesne modeli ve birçok PowerPoint ile ilgili görevi destekleyen bir sunum işleme kütüphanesi olarak sunar.

Makale, her iki seçeneği desteklenen biçimler, programlama modeli, renderleme ve yazdırma yetenekleri, platform desteği ve yaygın kullanım senaryoları açısından karşılaştırır. Ayrıca, Open XML SDK'nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides'ın ise birden çok PowerPoint biçimiyle çalışma, şekilleri kopyalama veya çoğaltma, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS'ye dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğu açıklığa kavuşturulur.

## **Open XML SDK Nedir?**
According to the [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK is defined as: 

Open XML SDK 2.0, Open XML paketlerini ve paket içindeki temel Open XML şema öğelerini manipüle etme görevini basitleştirir. Open XML SDK 2.0, geliştiricilerin Open XML paketleri üzerinde gerçekleştirdiği birçok ortak görevi kapsüller, böylece sadece birkaç satır kodla karmaşık işlemler yapabilirsiniz.

OOXML belgeleri esasen sıkıştırılmış XML dosyalarıdır ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü tiplenmiş bir şekilde çalışmanıza olanak tanıyan sınıflar koleksiyonudur. Yani bir dosyayı açıp XML'i çıkarıp, bu XML'i bir DOM ağacına yüklemek ve XML öğeleri ile öznitelikleri doğrudan işlemek yerine, Open XML SDK bu işlemler için sınıflar sağlar.

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamanızın aşağıdaki sunum işleme görevlerini gerçekleştirmesini sağlayan bir sınıf kütüphanesidir:

- **Presentation** nesne modeli ile programlama.
- PDF, XPS ve TIFF'ye dönüşüm dahil olmak üzere tüm popüler desteklenen PowerPoint sunum formatları arasında yüksek kaliteli dönüştürmeler.
- PNG, JPEG ve BMP gibi yaygın formatlarda slayt küçük resimleri oluşturma ve slaytları SVG olarak dışa aktarma yeteneği.
- Sıfırdan veya bir ya da birden fazla belgeyi birleştirerek sunumlar oluşturma yeteneği.
- Animasyonlar, Ole Frames, Tablolar ekleme, grafik oluşturma ve yönetme desteği.
- TextFrames, Paragraflar ve Bölümler seviyelerinde metin biçimlendirmesini yönetmek için kapsamlı kontrol erişimi.

Desteği verilen özellikler hakkında daha fazla detay için lütfen [Aspose.Slides Özellikleri](/slides/tr/java/product-overview/) adresini ziyaret edin.

## **Open XML SDK ve Aspose.Slides Karşılaştırması**
{{% alert color="info" %}} 

İşte sonraki tablo Open XML SDK ve Aspose.Slides özelliklerini karşılaştırmaktadır.

{{% /alert %}} 

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen Sunum Formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e Dönüştürme |No|Yes|
|<p>Sunum Belge Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bulma ve değiştirme.</p><p>- Sunumlardaki slaytları birleştirme.</p>|No|Yes|
|Belge nesne modeli ile ayrıntılı programlama, TextHolders, TextFrames, Paragraflar ve Bölümler gibi bireysel öğelere ve biçimlendirmeye erişim.|Yes|Yes|
|Bir OOXML belgesinin ilişki tanımlayıcıları, liste tanımlayıcıları gibi temel XML öğeleri ve özniteliklerine düşük seviyeli doğrudan ve tam erişim.|Yes|No|
|<p>Renderleme:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine renderleme.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF formatlarında renderleme.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirtme.</p>|No|Yes|
|Desteklenen platformlar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Sonuç**
{{% alert color="info" %}} 

Open XML SDK ve Aspose.Slides doğrudan rekabet etmez, çünkü oldukça farklı ihtiyaç ve kitleleri hedefler. Open XML SDK, OOXML belgeleriyle güçlü tiplenmiş bir şekilde çalışmak için bir sınıf kütüphanesidir. Aspose.Slides, neredeyse tüm Microsoft PowerPoint dosya formatları için mükemmel destek sunan çok faydalı bir sunum işleme kütüphanesidir.

Eğer tek ihtiyacınız PPTX belgesi üzerinde oldukça temel bir programlama işlemi yapmaksa, Open XML SDK uygun bir seçenek olabilir. Open XML SDK ile basit bir PPTX belgesi oluşturma, yorumları, üstbilgi/altbilgileri kaldırma, resimleri çıkarma gibi basit görevleri rahatlıkla yapabilirsiniz. Bazı görevler Open XML SDK ile gerçekleştirilebilir, ancak Aspose.Slides ile gerçekleştirilemez. Örneğin, bir OOXML belgesinin XML öğelerine ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK'yı kullanmalısınız. Ancak, aşağıdaki gibi karmaşık belge işlemleri yapmanız gerekiyorsa Aspose.Slides kullanmak en iyi seçeneğinizdir:

- PPTX'in yanı sıra eski PowerPoint formatlarını da destekleme.
- Şekilleri slayt içinde kopyalama veya çoğaltma, nesneleri, stilleri ve diğer biçimlendirmeleri uygun şekilde birleştirme.
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirme.
- Animasyonları uygulama ve şekillerle bağlayıcıları kullanma.
- Bir belgeyi PDF, TIFF veya XPS'ye dönüştürme, böylece Microsoft PowerPoint'in dönüştürmüş gibi tam olarak görünmesini sağlama.
- .NET veya Java uygulamasını hem masaüstü hem de web tabanlı ortamlarda geliştirme.

{{% /alert %}}