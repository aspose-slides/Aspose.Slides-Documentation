---
title: Artefakt Sınıflandırıcı Değişikliği
type: docs
weight: 60
url: /tr/java/artifact-classifier-change/
keywords:
- sınıflandırıcı Aspose.Slides
- artefakt sınıflandırıcısı
- Aspose.Slides kullanımı
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java artık jdk16 yerine jdk8 sınıflandırıcısını kullanıyor. Nedenini ve bağımlılıklarını nasıl güncelleyeceğini öğren."
---
## **Artefakt Sınıflandırıcı Değişikliği `jdk16`'dan `jdk8`'e**

**26.10** sürümünden itibaren, yayımladığımız artefaktlarda kullanılan sınıflandırıcıyı **`jdk16`** (Java 6) yerine **`jdk8`** (Java 8) olarak değiştirdik.

### **Ne Değişti**

| | Önceden | Sonra |
|---|---|---|
| Sınıflandırıcı | `jdk16` | `jdk8` |
| Minimum Java sürümü | Java 1.6 | Java 8 |

**Before:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**After:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Neden Bu Değişikliği Yaptık**

İç incelemenin ardından, artık değer katmayan ve bakım sürecini aktif olarak zorlayan eski Java sürümlerine **destek vermeyi bırakmaya** karar verdik. Tüm kullanıcılar için yeni, güvenli bir temel olarak Java 8 seçildi.

Bu çerçevede, sınıflandırıcı gerçek minimum desteklenen sürümü yansıtacak şekilde güncellendi. Ayrıca, ürünün resmi olarak **JDK 8** olarak adlandırıldığı (eski `1.8` formatı yerine) mevcut Oracle adlandırma konvansiyonuna da uyduk.

### **Yapmanız Gerekenler**

1. **Bağımlılık bildirimlerinizdeki sınıflandırıcıyı** `jdk16`'dan `jdk8`'e güncelleyin.

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

2. **Çalışma ortamınızı** Java 8 veya daha üstü olduğundan emin olun.

3. **Eski sınıflandırıcıyı sabitleyen** kilit dosyalarını veya bağımlılık önbelleklerini yenileyin.

### **Geçiş Notu: jdk16 ve jdk8**

**26.10** sürümünden itibaren, jdk16 ve jdk8 sınıflandırıcıları Java 8 uyumlu JAR'lar sağlayacak (kaynak/hedef uyumluluğu Java 8 olarak ayarlanmış).

- `jdk16` → geriye dönük uyumluluk (mevcut entegrasyonlar) için yayınlanmaya devam edecek.
- `jdk8` → Java 8 ortamları için yeni tercih edilen sınıflandırıcı olarak tanıtıldı.

⚠️ Not: Bu çift yayınlama aşaması 31 Mart 2027'de sona erecek. Bu tarihten sonra, jdk16 sınıflandırıcısı kullanımdan kaldırılacak ve sadece jdk8 desteklenecek.

### **Uyumluluk Notları**

- `jdk16` sınıflandırıcısı **31 Mart 2027**'den sonra **artık yayınlanmıyor**.
- Hâlâ Java 1.6 desteği gerekiyorsa, geçiş yapana kadar önceki ana sürüm hattında kalın.

### **Yardıma mı ihtiyacınız var?**

Geçiş sırasında sorunlarla karşılaşırsanız, lütfen daha fazla yardım için [Aspose desteği](https://forum.aspose.com/) ile iletişime geçin.