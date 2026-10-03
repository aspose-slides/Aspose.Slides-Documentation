---
title: Neden Open XML SDK
type: docs
weight: 180
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
description: "Aspose.Slides'in ücretsiz Open XML SDK'dan daha iyi bir seçim olmasını neden gördüğünüzü görün: özellikleri karşılaştırın, otomasyon gerektirmeyen dönüşüm ve PPT, PPTX ve ODP için geniş destek."
---
## **Genel Bakış**

Bu makale, geliştiricilerin sunum belgeleriyle çalışırken Open XML SDK veya Aspose.Slides'i ne zaman tercih edebileceklerini açıklar. Open XML SDK, OOXML paketlerini ve altındaki XML öğelerini manipüle etmek için bir kütüphane olarak tanımlanırken, Aspose.Slides, yüksek seviyeli bir nesne modeli ve birçok PowerPoint ile ilgili görevi destekleyen bir sunum işleme kütüphanesi olarak sunulmaktadır. Makale, her iki seçeneği desteklenen formatlar, programlama modeli, renderleme, platform desteği ve yaygın kullanım senaryolarına göre karşılaştırmaktadır. Ayrıca, Open XML SDK'nın temel PPTX işlemleri veya OOXML öğelerine doğrudan erişim için uygun olabileceği, Aspose.Slides'in ise birden fazla PowerPoint formatıyla çalışma, şekilleri kopyalama veya klonlama, metin değiştirme, animasyon uygulama ve sunumları PDF, TIFF veya XPS'ye dönüştürme gibi karmaşık sunum görevleri için daha uygun olduğu açıklığa kavuşturulmaktadır.

## **Open XML SDK Nedir?**
Microsoft [MSDN Kütüphanesi](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) göre, Open XML SDK şu şekilde tanımlanmıştır:

Open XML SDK 2.0, bir paket içindeki Open XML paketlerini ve altındaki Open XML şema öğelerini manipüle etme görevini basitleştirir. Open XML SDK 2.0, geliştiricilerin Open XML paketleri üzerinde gerçekleştirdiği birçok ortak görevi kapsüller, böylece yalnızca birkaç satır kodla karmaşık işlemler yapabilirsiniz.

OOXML belgeleri temelde sıkıştırılmış XML dosyalarından oluşur ve Open XML SDK, OOXML belgelerinin içeriğiyle güçlü tipli bir şekilde çalışmanıza olanak tanıyan sınıflar koleksiyonudur. Yani, bir dosyayı açıp XML'i çıkarmak, bu XML'i bir DOM ağacına yüklemek ve XML öğeleri ve öznitelikleriyle doğrudan çalışmak yerine, Open XML SDK bu işlemi yapacak sınıflar sunar.

## **Aspose.Slides Nedir?**
Aspose.Slides, uygulamanızın aşağıdaki sunum işleme görevlerini gerçekleştirmesini sağlayan bir sınıf kitaplığıdır:

- **Presentation** nesne modeliyle programlama.
- Popüler tüm desteklenen PowerPoint sunum formatları arasında yüksek kaliteli dönüşümler, PDF, XPS ve TIFF'e dönüştürme dahil.
- PNG, JPEG ve BMP gibi bilinen formatlarda slayt küçük resimleri oluşturma ve slaytı SVG'ye dışa aktarma yeteneği.
- Sıfırdan veya bir veya birden fazla belgeyi birleştirerek sunumlar oluşturma yeteneği.
- Animasyonlar, Ole Çerçeveler, Tablolar ekleme, grafik oluşturma ve yönetme desteği.
- TextFrames, Paragraflar ve Bölümler seviyelerinde metin formatlamasını yönetmek için kapsamlı kontrol imkanı.

Desteklenen özellikler hakkında daha fazla ayrıntı için lütfen [Aspose.Slides Özellikleri](/slides/tr/java/product-overview/) sayfasını ziyaret edin.

## **Open XML SDK ile Aspose.Slides'i Karşılaştırma**
{{% alert color="info" title="Note" %}}
Aşağıdaki tablo Open XML SDK ve Aspose.Slides özelliklerini karşılaştırmaktadır.
{{% /alert %}}

|**Özellik veya Özellik Kategorisi**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Desteklenen Sunum formatları|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT'den PPTX'e Dönüşüm|Hayır|Evet|
|<p>Sunum Belgesi Nesne Modeli (DOM) ile yüksek seviyeli programlama:</p><p>- Metin bulma ve değiştirme.</p><p>- Sunumlardaki slaytları birleştirme.</p>|Hayır|Evet|
|Belge nesne modeliyle ayrıntılı programlama, TextHolders, TextFrames, Paragraphs ve Portions gibi bireysel öğelere ve biçimlendirmeye erişim.|Evet|Evet|
|İlişki tanımlayıcıları, OOXML belgesinin liste tanımlayıcıları gibi alt XML öğeleri ve özniteliklerine düşük seviyeli doğrudan ve tam erişim.|Evet|Hayır|
|<p>Renderleme:</p><p>- Sunumları PDF, PDF Notları, XPS, TIFF görüntülerine renderle.</p><p>- Slayt küçük resimlerini PNG, JPEG, BMP, SVG ve TIFF olarak renderle.</p><p>- Görüntü çözünürlüğü, kalite, sıkıştırma ve diğer seçenekleri belirt.</p>|Hayır|Evet|
|Desteklenen platformlar|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Sonuç**
{{% alert color="info" title="Note" %}}
Open XML SDK ve Aspose.Slides doğrudan rekabet etmez çünkü oldukça farklı ihtiyaç ve hedef kitlelere hitap ederler. Open XML SDK, OOXML belgeleriyle güçlü tipli bir şekilde çalışmayı sağlayan bir sınıf kitaplığıdır. Aspose.Slides, neredeyse tüm Microsoft PowerPoint dosya formatları için mükemmel destek sunan çok faydalı bir sunum işleme kitaplığıdır.

Eğer yapmanız gereken tek şey bir PPTX belgesi üzerinde oldukça temel bir programlama işlemi ise, Open XML SDK uygun bir seçim olabilir. Open XML SDK ile basit bir PPTX belge oluşturma, yorumları, üstbilgi/altbilgileri kaldırma, görüntüleri çıkarma gibi basit görevleri rahatça yapabilirsiniz. Bazı görevler Open XML SDK ile gerçekleştirilebilirken Aspose.Slides ile gerçekleştirilemez. Örneğin, bir OOXML belgesinin XML öğelerine ve özniteliklerine doğrudan erişmeniz gerekiyorsa Open XML SDK kullanmalısınız. Ancak, belgeler üzerinde aşağıdaki gibi karmaşık işlemler gerçekleştirmeniz gerekiyorsa, Aspose.Slides kullanmak en iyi seçeneğinizdir:

- PPTX'e ek olarak eski PowerPoint formatlarını destekleyin.
- Slayt içindeki şekilleri, nesneleri, stilleri ve diğer biçimlendirmeleri uygun şekilde birleştirecek şekilde kopyalayın veya klonlayın.
- Biçimlendirilmiş veya biçimlendirilmemiş metni değiştirin.
- Animasyonları uygulama ve şekillerle kullanılan bağlantı elemanlarını kullanma.
- Bir belgeyi PDF, TIFF veya XPS'ye dönüştürün, böylece tam olarak Microsoft PowerPoint'in dönüştürdüğü gibi görünür.
- Hem masaüstü hem de web tabanlı ortamlar için .NET veya Java uygulaması geliştirin.
{{% /alert %}}