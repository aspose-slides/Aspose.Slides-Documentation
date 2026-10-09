---
title: Deklarasyon
type: docs
weight: 60
url: /tr/java/artifact-classifier-change/
keywords:
- sınıflandırıcı Aspose.Slides
- artefakt sınıflandırıcısı
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
description: "Aspose.Slides for Java artık jdk16 yerine jdk8 sınıflandırıcısını kullanıyor. Nedenini ve bağımlılıklarınızı nasıl güncelleyeceğinizi öğrenin."
---
## **Artefakt Sınıflandırması `jdk16`'dan `jdk8`'e Değiştirildi**

**26.10** sürümünden itibaren, yayımladığımız artefaktlardaki sınıflandırıcıyı **`jdk16`** (Java 6) yerine **`jdk8`** (Java 8) olarak değiştirdik.

### **Ne değişti**

|   | Önce | Sonra |
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

### **Bu değişikliği yapma nedenimiz**

İç gözden geçirme sonrasında, artık değer katmayan ve bakım sürecini aktif olarak zorlaştıran eski Java sürümlerine **destek vermeyi bırakmaya** karar verdik. Java 8, tüm kullanıcılar için yeni, güvenli bir temel olarak seçildi.

Bu kapsamda, gerçek minimum desteklenen sürümü yansıtacak şekilde sınıflandırıcı güncellendi. Ayrıca, ürünün resmi olarak **JDK 8** olarak adlandırıldığı (eski `1.8` biçimi yerine) mevcut Oracle adlandırma konvansiyonu ile uyum sağlandı.

### **Yapmanız gerekenler**

1. Bağımlılık açıklamalarınızdaki sınıflandırıcıyı `jdk16` yerine `jdk8` olarak **güncelleyin**.

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

2. Çalışma ortamınızın Java 8 veya daha yüksek bir sürüm olduğundan **emin olun**.

3. Eski sınıflandırıcıyı kilitleyen **kilit dosyalarını** veya bağımlılık önbelleklerini **yenileyin**.

### **Geçiş Notu: jdk16 ve jdk8**

**26.10** sürümünden itibaren, hem `jdk16` hem de `jdk8` sınıflandırıcıları Java 8 uyumlu JAR'lar sağlayacak (kaynak/hedef uyumluluğu Java 8 olarak ayarlanmış).

- `jdk16` → geriye dönük uyumluluk (mevcut entegrasyonlar) için yayımlanmaya devam eder.  
- `jdk8` → Java 8 ortamları için yeni tercih edilen sınıflandırıcı olarak tanıtıldı.

⚠️ Not: Bu çift yayımlama aşaması **31 Mart 2027**'de sona erecek. Bu tarihten sonra `jdk16` sınıflandırıcısı devre dışı bırakılacak ve yalnızca `jdk8` desteklenecek.

### **Uyumluluk notları**

- `jdk16` sınıflandırıcısı **31 Mart 2027** tarihinden itibaren **daha fazla yayımlanmayacak**.  
- Eğer hâlâ Java 1.6 desteğine ihtiyaç duyuyorsanız, geçiş yapana kadar önceki ana sürüm hattında kalın.

### **Yardıma mı ihtiyacınız var?**

Geçiş sırasında sorun yaşarsanız, lütfen [Aspose desteği](https://forum.aspose.com/) ile iletişime geçin.