---
title: Başlarken
type: docs
weight: 10
url: /tr/java/getting-started/
keywords:
- başlangıç
- sistem gereksinimleri
- kurulum
- ilk sunum
- Maven
- PPT işleme
- PPTX işleme
- ODP işleme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile yeni bir Java projesinden ilk kaydedilen sunuma giden yol: gereksinimleri kontrol edin, Aspose'un Maven deposundan kütüphaneyi ekleyin, ilk programı çalıştırın ve yaygın görevlerle devam edin."
---
## **Genel Bakış**

Aşağıdaki dört adımdan sırayla geçin. Her adım ne yapılacağını adlandırır ve detayları içeren makaleye bağlanır. Değerlendirme, lisanslama ve destek adımlardan sonra ele alınır.

## **Adım 1: Sistem Gereksinimlerini Kontrol Edin**

Aspose.Slides for Java, yerel kod içermeyen tek bir JAR dosyasıdır; bu nedenle desteklenen bir Java çalışma zamanına sahip herhangi bir işletim sisteminde çalışır. [Sistem Gereksinimleri](/slides/tr/java/system-requirements/) desteklenen işletim sistemlerini ve Java sürümlerini listeler. Sonraki adımlardaki proje ve komutlar JDK 11 veya üzeri ve Maven yolu için [Apache Maven](https://maven.apache.org/install.html) gerektirir.

## **Adım 2: Kütüphaneyi Projenize Ekleyin**

Aspose.Slides for Java, Maven Central'da değil, Aspose'un kendi Maven deposunda yayınlanır. Aşağıdaki yollardan birini seçin:

- Maven ile: *pom.xml* dosyanıza `https://releases.aspose.com/java/repo/` deposunu bildirin ve `com.aspose:aspose-slides` bağımlılığını `jdk16` sınıflandırıcısıyla ekleyin.
- Maven olmadan: Depodan *-jdk16.jar* ile biten JAR dosyasını indirin ve sınıf yoluna yerleştirin.

Linux'ta ayrıca fontconfig kitaplığını ve en az bir fontu yükleyin. Bunlar olmadan sunumu kaydetme işlemi "Fontconfig head is null, check your fonts or fonts configuration" hatasıyla başarısız olur.

[Kurulum](/slides/tr/java/installation/) *pom.xml* girişlerini, JAR indirmesini ve Linux komutunu verir.

## **Adım 3: İlk Sunumunuzu Oluşturun**

[Aspose.Slides for Java ana sayfasındaki hızlı başlangıç](/slides/tr/java/#your-first-presentation) tam bir Maven projesidir: bir *pom.xml* dosyası ve bir slayta bulut şekli ekleyip onu PPTX dosyası olarak kaydeden bir program. `mvn compile exec:java` ile çalıştırırsınız. [Sunum Oluşturma](/slides/tr/java/create-presentation/) aynı programı adım adım açıklar. Mevcut bir sunumu açıp başka bir biçimde kaydetmek için [Sunum Açma](/slides/tr/java/open-presentation/) ve [Sunum Kaydetme](/slides/tr/java/save-presentation/) bölümlerine bakın.

## **Adım 4: Yaygın Görevlerle Devam Edin**

- [Sunum Açma](/slides/tr/java/open-presentation/)
- [Sunum Kaydetme](/slides/tr/java/save-presentation/)
- [Sunumu PDF'e Dönüştürme](/slides/tr/java/convert-powerpoint-to-pdf/)
- [Slaytları Görüntü Olarak Render Etme](/slides/tr/java/convert-slide/)
- [Sunum Metnini Düzenleme](/slides/tr/java/manage-text/)
- [Slayt öğesi örnekleri](/slides/tr/java/examples/)

## **Değerlendirme ve Lisanslama**

Lisans olmadan Aspose.Slides değerlendirme modunda çalışır: kaydettiği her slayta bir filigran ekler ve kodunuzun sunumlardan okuduğu metni kısar.

- [Aspose.Slides'ı Değerlendirme](/slides/tr/java/evaluate-aspose-slides/) değerlendirme sınırlamalarını ve geçici lisans talep etmeyi açıklar.
- [Lisanslama](/slides/tr/java/licensing/) bir lisansı dosyadan ya da akıştan nasıl uygulayacağınızı gösterir.
- [Ölçülen Lisanslama](/slides/tr/java/metered-licensing/) kullanım bazlı faturalandırılan lisanslamayı kapsar.
- [Desteklenen Dosya Biçimleri](/slides/tr/java/supported-file-formats/) Aspose.Slides'ın yükleyip kaydedebileceği biçimleri listeler.

## **Yardım Alın**

[Techik Destek](/slides/tr/java/technical-support/) ücretsiz destek forumunda([free support forum](https://forum.aspose.com/c/slides/tr/11)) nasıl soru sorulacağını ve bir sorunu bildirirken nelerin dahil edilmesi gerektiğini açıklar.

## **SSS**

**Microsoft PowerPoint yüklü olması gerekir mi?**

Hayır. Aspose.Slides sunum dosyalarını kendisi okur ve yazar; PowerPoint kullanmaz, bu yüzden sunucularda ve Linux'ta da çalışır.

**Maven, Aspose.Slides for Java'yi neden bulamıyor?**

Kütüphane Maven Central'da yoktur. *pom.xml* dosyanıza [Kurulum](/slides/tr/java/installation/)'da gösterildiği gibi Aspose'un deposunu ekleyin; Maven kütüphaneyi oradan indirir.

**`jdk16` sınıflandırıcısı kütüphanenin Java 16 gerektirdiği anlamına mı geliyor?**

Hayır. Sınıflandırıcı, kütüphanenin Java SE sürümünü seçer; diğer sürüm Android içindir. Aynı sürüm JDK 21 gibi mevcut JDK'larda çalışır.