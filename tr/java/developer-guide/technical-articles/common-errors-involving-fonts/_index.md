---
title: Linux'ta Yazı Tipleriyle İlgili Yaygın İstisnalar ve Hatalar
type: docs
weight: 200
url: /tr/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Yazı tipi istisnası, Yazı tipi hatası, Linux, Java, Aspose.Slides for Java"
description: "Linux'ta yazı tipi istisnaları ve hataları"
---
## **Genel Bakış**

Aspose.Slides Linux üzerinde kullanıldığında, Java işlemi gerekli yazı tipi klasörlerine veya geçici klasöre erişemiyorsa, sistemde hiçbir yazı tipi yüklü değilse veya fontconfig ya da libfreetype gibi gerekli sistem kütüphaneleri eksikse, yazı tipiyle ilgili sorunlar ortaya çıkabilir.

Bu makale, Linux'ta yazı tipleriyle ilgili yaygın hataları ve istisnaları açıklar ve bunları çözmek için çözümler sunar. Yazı tipi ve TEMP klasörlerine erişimin nasıl kontrol edileceğini, gerekli yazı tiplerinin ve kütüphanelerin nasıl yükleneceğini ve `FontsLoader`ı kullanarak sistem genelinde kurulum yapmadan yazı tiplerini nasıl yükleneceğini açıklar.

## **Linux'ta Kod Çalıştırıldığında Metin veya Görüntü (EMF veya WMF) Eksikliği**

Bu sorun aşağıdaki durumlarda sınırlamalara sahip sistemlerde meydana gelir:

1. Hiç yazı tipi yüklü değilse veya Java işlemi için yazı tipi klasörüne erişilemiyorsa
2. TEMP klasörüne erişilemiyorsa.

### **Çözüm**

TEMP klasörüne ve yazı tipi klasörüne erişimin verildiğini kontrol edin ve doğrulayın. 

{{% alert color="warning" %}}

Bazı durumlarda ortam veya güvenlik politikası tarafından uygulanan kısıtlamalar nedeniyle klasörlere erişim sağlanamayabilir. Aşağıdaki geçici çözümleri deneyin: 

{{% /alert %}}

**Geçici Çözüm**

Gerekli yazı tiplerini sistem genelinde kurmadan yüklemek için [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader)ı kullanın:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

TEMP klasörüne erişilemiyorsa, Java için TEMP olarak kullanılacak başka bir klasörü belirlemek için şu kodu kullanın:
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **İstisna: InvalidOperationException: Sistem üzerinde yüklü hiçbir yazı tipi bulunamıyor**

Bu istisna aşağıdaki durumlarda ortaya çıkar

1) Java işlemi yazı tipi klasörüne erişemiyor
2) Hiç yazı tipi yüklü değil.

### **Çözüm**

1. Java işlemi için yazı tipi klasörüne erişimin verildiğini kontrol edin ve doğrulayın.

2. Birkaç yazı tipi yükleyin veya [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader)ı kullanın.

3. Yazı tiplerini yükleyin.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader) kullanarak: 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **İstisna: InternalError: InvocationTargetException**

Linux'ta bir PPTX dosyasını PDF'ye dönüştürürken, dönüşüm `java.lang.InternalError: java.lang.reflect.InvocationTargetException` hatasıyla başarısız olabilir. Altta yatan hata `Cannot load from short array because "sun.awt.FontConfiguration.head" is null` ise, Linux yazı tipi yapılandırması kullanılamaz durumdadır veya önbelleği henüz oluşturulmamıştır.

### **Çözüm**

fontconfig paketini yükleyin ve yazı tipi önbelleğini yeniden oluşturun:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **İstisna: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

Bu istisna, fontconfig ve yazı tiplerinin eksik olduğu bir Linux sisteminde ortaya çıkar. 

### **Çözüm**

fontconfig paketini yükleyin:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Ayrıca bazı open-jdk sürümleri (örneğin **alpine JDK**) **yüklenmiş yazı tiplerini** gerektirir.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **İstisna: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

Bu istisna, libfreetype kütüphanesinin eksik olduğu bir Linux sisteminde ortaya çıkar. 

### **Çözüm**

libfreetype ve fontconfig paketlerini yükleyin:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="info" %}} 

Yazı tiplerini yüklemeyi veya FontsLoaderı kullanmayı unutmayın.

{{% /alert %}}