---
title: Deklarasyon
type: docs
weight: 60
url: /tr/java/artifact-classifier-change/
keywords:
- sınıflandırıcı Aspose.Slides
- artefakt sınıflandırıcı
- Aspose.Slides kullan
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java artık jdk16 yerine jdk8 sınıflandırıcısını kullanıyor. Nedenini ve bağımlılıkları nasıl güncelleyeceğinizi öğrenin."
---
## Artefakt Sınıflandırıcı Değişikliği `jdk16`'dan `jdk8`'e

**26.10** sürümünden itibaren, yayınladığımız artefaktlarda kullanılan sınıflandırıcıyı **`jdk16`** (Java 6) yerine **`jdk8`** (Java 8) olarak değiştirdik.

### Neler değişti

| | Önce | Sonra |
|---|---|---|
| Sınıflandırıcı | `jdk16` | `jdk8` |
| Minimum Java sürümü | Java 1.6 | Java 8 |

**Önce:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Sonra:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Neden bu değişikliği yaptık

İç incelemeden sonra, artık değer katmayan ve bakım sürecini aktif olarak engelleyen eski Java sürümlerine **desteği bırakmaya** karar verdik. Tüm kullanıcılar için yeni, güvenli bir temel olarak Java 8 seçildi.

Bu kapsamda, sınıflandırıcı gerçek minimum desteklenen sürümü yansıtacak şekilde güncellendi. Ayrıca ürünün resmi olarak **JDK 8** (eski `1.8` biçimi yerine) olarak adlandırıldığı mevcut Oracle isimlendirme standardına da uyduk.

### Yapmanız gerekenler

1. **Sınıflandırıcıyı güncelleyin** bağımlılık bildirimlerinizde `jdk16` yerine `jdk8` olarak.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Çalışma ortamınızın** Java 8 veya üzeri olduğunu doğrulayın.

3. **Eski sınıflandırıcıyı kilitleyen** lock dosyalarını veya bağımlılık önbelleklerini yenileyin.

### Geçiş Notu: jdk16 ve jdk8

26.10 sürümünden itibaren, hem jdk16 hem de jdk8 sınıflandırıcıları Java 8 uyumlu JAR'lar sağlayacak (kaynak/hedef uyumluluğu Java 8 olarak ayarlanmış olarak derlenmiş).

- `jdk16` → geriye dönük uyumluluk (mevcut entegrasyonlar) için yayınlamaya devam edecek.
- `jdk8` → Java 8 ortamları için yeni tercih edilen sınıflandırıcı olarak tanıtıldı.

⚠️ Not: Bu çift yayınlama aşamasının 31 Mart 2027'de sona ermesi planlanıyor. Bu tarihten sonra, jdk16 sınıflandırıcısı emekli edilecek ve yalnızca jdk8 desteklenecek.

### Uyumluluk notları

- `jdk16` sınıflandırıcısı **31 Mart 2027** tarihinden sonra **artık yayınlanmamaktadır**.
- Eğer hâlâ Java 1.6 desteğine ihtiyaç duyuyorsanız, geçiş yapana kadar önceki ana sürüm hattında kalın.

### Yardıma mı ihtiyacınız var?

Geçiş sırasında sorunlarla karşılaşırsanız, lütfen daha fazla yardım için [Aspose destek](https://forum.aspose.com/) ekibiyle iletişime geçin.