---
title: Başlarken
type: docs
weight: 10
url: /tr/net/getting-started/
keywords:
- başlarken
- sistem gereksinimleri
- kurulum
- ilk sunum
- NuGet
- PPT işleme
- PPTX işleme
- ODP işleme
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Yeni bir .NET projesinden Aspose.Slides ile kaydedilen ilk sunuma giden yol: gereksinimleri kontrol edin, paketi kurun, ilk programı çalıştırın ve ortak görevlerle devam edin."
---
## **Genel Bakış**

Aşağıdaki dört adımı sırayla uygulayın. Her adım ne yapılacağını belirtir ve ayrıntılı makaleye bağlanır. Değerlendirme, lisanslama ve destek adımlardan sonra ele alınır.

## **Adım 1: Sistem Gereksinimlerini Kontrol Edin**

Aspose.Slides for .NET Windows, Linux ve macOS üzerinde çalışır. [Sistem Gereksinimleri](/slides/tr/net/system-requirements/) her paketin desteklediği işletim sistemlerini ve .NET sürümlerini, ayrıca Linux için gereken ek kütüphaneleri listeler.

## **Adım 2: Paketi Yükleyin**

Aspose.Slides for .NET, aynı sınıfları sağlayan iki paket olarak NuGet üzerinden dağıtılır. Projenize birini ekleyin:

- Windows’da: `dotnet add package Aspose.Slides.NET`
- Linux ve macOS’da: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Linux’da önce `fontconfig` kütüphanesini kurun.
- Alpine Linux’da ve glibc sürümü 2.23 (x64) veya 2.39 (ARM64)’ten eski olan Linux sistemlerinde: `Aspose.Slides.NET`, `libgdiplus` kütüphanesi kurulu olmak şartıyla.

[Kurulum](/slides/tr/net/installation/) Linux komutlarını, Aspose.Slides.NET’in Linux’da ihtiyaç duyduğu ek başlangıç ayarını ve Visual Studio adımlarını verir.

## **Adım 3: İlk Sunumunuzu Oluşturun**

[Aspose.Slides for .NET ana sayfasındaki hızlı başlangıç](/slides/tr/net/#your-first-presentation) tam bir konsol programıdır: bir slayta metin kutusu ekler ve sunumu PPTX dosyası olarak kaydeder. [Sunum Oluşturma](/slides/tr/net/create-presentation/) aynı adımları daha ayrıntılı açıklar, mevcut bir sunumu açma ve başka bir formatta kaydetme yöntemlerini gösterir.

## **Adım 4: Ortak Görevlerle Devam Edin**

- [Bir Sunumu Aç](/slides/tr/net/open-presentation/)
- [Bir Sunumu Kaydet](/slides/tr/net/save-presentation/)
- [Sunumu PDF'ye Dönüştür](/slides/tr/net/convert-powerpoint-to-pdf/)
- [Slaytları Görüntü Olarak İşle](/slides/tr/net/convert-slide/)
- [Sunum Metnini Düzenle](/slides/tr/net/manage-text/)
- [Slayt öğesine göre örnekler](/slides/tr/net/examples/)

## **Değerlendir ve Lisansla**

Lisans olmadan, Aspose.Slides değerlendirme modunda çalışır: kaydettiği her slayta filigran ekler ve sunumlardan okunan metni keser.

- [Aspose.Slides'i Değerlendir](/slides/tr/net/evaluate-aspose-slides/) değerlendirme sınırlamalarını ve geçici bir lisans talep etme yolunu açıklar.
- [Lisanslama](/slides/tr/net/licensing/) bir lisansı dosyadan, akıştan veya gömülü kaynaktan nasıl uygulayacağınızı gösterir.
- [Ölçülen Lisanslama](/slides/tr/net/metered-licensing/) kullanıma göre faturalandırılan lisanslamayı kapsar.
- [Desteklenen Dosya Formatları](/slides/tr/net/supported-file-formats/) Aspose.Slides’in yükleyip kaydedebildiği formatları listeler.

## **Yardım Alın**

[Ürün Desteği](/slides/tr/net/product-support/) ücretsiz destek forumunda ([https://forum.aspose.com/c/slides/tr/11](https://forum.aspose.com/c/slides/tr/11)) nasıl soru sorulacağını ve bir sorunu bildirirken nelere yer vermeniz gerektiğini açıklar.

## **SSS**

**Microsoft PowerPoint yüklü olmak zorunda mı?**

Hayır. Aspose.Slides sunum dosyalarını kendisi okur ve yazar; PowerPoint kullanmaz, bu yüzden sunucularda ve Linux üzerinde de çalışır.

**.NET Framework uygulaması için hangi paketi kullanmalıyım?**

Aspose.Slides.NET. .NET Framework 4.6.2 ve sonrası, .NET 6 ve sonrası, .NET Standard 2.0 için derlemeler içerir. Aspose.Slides.NET6.CrossPlatform .NET 6 veya sonraki sürümleri gerektirir.