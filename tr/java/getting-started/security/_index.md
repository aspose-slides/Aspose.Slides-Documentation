---
title: Güvenlik
type: docs
weight: 160
url: /tr/java/security/
keywords:
- güvenlik
- bağımlılıklar
- üçüncü taraf bileşenler
- Maven
- JAR imzası
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ın sunumları nasıl işlediğini, projenizin bağımlılıklarına ne eklediğini, JAR dosyasını nasıl doğrulayacağınızı ve hangi üçüncü taraf bileşenleri içerdiğini inceleyin."
---
## **Giriş**

Bu makale, Aspose.Slides for Java kullanan bir uygulamanın güvenlik incelemesi için genellikle ihtiyaç duyulan bilgileri toplar: kütüphane sunumları nasıl işler, projenizin bağımlılıklarına ne ekler, JAR dosyasının Aspose'tan geldiğini nasıl kontrol edersiniz ve JAR dosyasının içerdiği üçüncü taraf bileşenler nelerdir.

## **Aspose.Slides Güvenliği**

Aspose ürünlerini geliştirirken en iyi uygulamaları uygular.

* Aspose.Slides for Java sunumlar oluşturmak, değiştirmek ve dönüştürmek için kullanılır. Sunumlardaki komut dosyalarını çalıştırmaz. Aspose.Slides sunum yapısını ayrıştırır ve kodunuzun nesne modeliyle çalışmasına olanak tanır.
* Aspose.Slides, uzak kod çalıştırmadan belgeleri ayrıştıran ve yorumlayan bir kitaplık olarak işlev görür. Tüm Aspose ürünleri makinelerinizde çalışır. Aspose'a hiçbir veri göndermezler. Tek istisna [ölçümlü lisanslama](/slides/tr/java/metered-licensing/)'dır: bunu kullanırsanız yalnızca API kullanım bilgileriniz işlenir.
* Aspose bileşenleri, normal uygulamalarla aynı kullanıcı bağlamında çalışır. Bu nedenle, Aspose bileşenleri kritik sistem kaynakları için risk oluşturmaz. Ayrıca, bir Aspose bileşeni bir belge açtığında makrolar otomatik olarak çalıştırılmaz.

## **Maven Bağımlılıkları**

Aspose.Slides for Java'nun Maven yapısı `com.aspose:aspose-slides` hiçbir bağımlılık bildirmez: POM dosyası yalnızca yapının kendi koordinatlarını içerir. Bir projeye eklediğinizde Maven yalnızca bu tek JAR dosyasını ekler, başka bir şey eklemez. Projenizin çözümlediği tüm yapıları, aktarılmış bağımlılıkları dahil, listelemek için proje klasöründe şu komutu çalıştırın:

```bash
mvn dependency:tree
```

[Kurulum](/slides/tr/java/installation/) örneğindeki proje için çıktı, Aspose.Slides'ın tek bağımlılık olduğunu gösterir:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **JAR Dosyasını Doğrulama**

Aspose JAR dosyasını imzalar. İmzayı kontrol etmek için JDK içindeki `jarsigner` aracını JAR dosyasının bulunduğu klasörde çalıştırın:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

İmza geçerli ve dosya imzalandıktan sonra hiçbir giriş değişmemişse komut `jar verified.` mesajını yazdırır. Bu mesaj imzalayanı isim olarak göstermez. Aspose'un dosyayı imzaladığını doğrulamak için `-verbose` ve `-certs` seçeneklerini ekleyin ve imzalayanın sertifikasının `CN=ASPOSE PTY LTD` olarak verildiğini kontrol edin. Maven JAR dosyasını indirirken, depolamanın dosyanın yanında yayınladığı SHA-1 sağlama değerini de kontrol eder.

## **Üçüncü Taraf Bileşenler**

Aspose.Slides for Java, üçüncü taraf bileşenlerden gelen kod ve verileri içerir. Bunlar JAR dosyasının bir parçasıdır, ayrı Maven yapıları değildir; bu nedenle `mvn dependency:tree` gibi Maven bağımlılıklarını okuyan araçlar bunları listelemez. JAR dosyası, bileşenleri ve lisanslarını listeleyen *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf* bildirimini içerir:

| Bileşen | Bildirimde belirtilen lisans |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Bildirim dosyasını JAR dosyasından çıkarmak için JDK içindeki `jar` aracını JAR dosyasının bulunduğu klasörde çalıştırın:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **SSS**

**Aspose.Slides for Java dış paketler kullanıyor mu?**

[Maven Bağımlılıkları](#maven-bağımlılıkları) bölümünde gösterildiği gibi hiçbir Maven bağımlılığı yoktur, ancak [Üçüncü Taraf Bileşenler](#üçüncü-taraf-bileşenler) bölümünde listelenen üçüncü taraf bileşenleri içerir. Güvenlik incelemenizde hem JAR dosyasını hem bu bileşenleri dahil edin.

**Aspose.Slides for Java ağ erişimine ihtiyaç duyar mı?**

Hayır. Sunum oluşturma, kaydetme ve render etme, ağ bağlantısı olmadan bir sistemde çalışır. Aspose'a veri gönderen tek özellik [ölçümlü lisanslama](/slides/tr/java/metered-licensing/)'dır; bu özellik API kullanımını raporlar.

**Aspose.Slides for Java yerel kod içerir mi?**

Hayır. JAR dosyası yalnızca Java sınıfları ve kaynaklarını içerir, bu nedenle uygulamanıza yerel kütüphane eklemez. Linux'ta, Java çalışma zamanının font desteği fontconfig kütüphanesini ve işletim sistemindeki fontları gerektirir; bakınız [Sistem Gereksinimleri](/slides/tr/java/system-requirements/#linux).