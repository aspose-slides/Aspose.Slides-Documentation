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

Aspose.Slides Linux'ta kullanıldığında, Java işlemi gereken yazı tipi klasörlerine veya geçici dizine erişemezse, sistemde hiçbir yazı tipi yüklü değilse ya da fontconfig veya libfreetype gibi gerekli sistem kitaplıkları eksikse, yazı tipiyle ilgili sorunlar ortaya çıkabilir.

Bu makale, Linux'ta yazı tipleriyle ilgili yaygın hataları ve istisnaları açıklar ve bunların çözüm yollarını sunar. Yazı tipi ve TEMP dizinlerine erişimin nasıl kontrol edileceğini, gerekli yazı tiplerinin ve kitaplıkların nasıl yükleneceğini ve `FontsLoader` kullanarak yazı tiplerini sistem geneline kurmadan nasıl yükleneceğini açıklar.

## **Linux'ta Kod Çalıştırıldığında Eksik Metin veya Görüntüler (EMF veya WMF)**

Bu sorun, aşağıdaki durumlarda kısıtlamalar bulunan sistemlerde meydana gelir:

1. Yazı tipi yüklü olmadığında veya Java işlemi için yazı tipi klasörüne erişilemediğinde
2. TEMP dizinine erişilemediğinde.

### **Çözüm**

TEMP dizinine ve yazı tipi klasörüne erişimin verildiğini kontrol edin ve onaylayın. 

{{% alert color="warning" %}}
Bazı durumlarda, ortam veya güvenlik politikası tarafından getirilen kısıtlamalar nedeniyle klasörlere erişim izni veremeyebilirsiniz. Aşağıdaki geçici çözümleri deneyin: 
{{% /alert %}}

**Geçici Çözüm**

Gerekli yazı tiplerini kurmadan yüklemek için [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader) kullanın:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

TEMP dizinine erişilemiyorsa, Java için TEMP olarak başka bir dizin belirlemek için bu kodu kullanın:
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

## **İstisna: InvalidOperationException: Sistemde Yüklü Hiçbir Yazı Tipi Bulunamıyor**

Bu istisna aşağıdaki durumlarda oluşur:

1) Java işlemi yazı tipi klasörüne erişemediğinde  
2) hiç yazı tipi yüklü olmadığında.

### **Çözüm**

1. Java işlemi için yazı tipi klasörüne erişimin verildiğini kontrol edin ve onaylayın.

2. Bazı yazı tipleri kurun veya [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader) kullanın.

3. Yazı tiplerini kurun.

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

## **İstisna: NoClassDefFoundError: com.aspose.slides.internal.ey.this Sınıfı Başlatılamadı**

Bu istisna, fontconfig ve yazı tipleri eksik olan bir Linux sisteminde ortaya çıkar. 

### **Çözüm**

fontconfig kurun:

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

Ayrıca, bazı open-jdk sürümleri (örneğin **alpine JDK**) de **kurulu yazı tiplerine** ihtiyaç duyar.

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

## **İstisna: UnsatisfiedLinkError: libfreetype.so.6: Paylaşılan Nesne Dosyası Açılamadı: Böyle Bir Dosya veya Dizin Yok**

Bu istisna, libfreetype kitaplığı eksik olan bir Linux sisteminde oluşur. 

### **Çözüm**

libfreetype ve fontconfig kurun:

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

{{% alert title="TIP" color="primary" %}} 
Yazı tiplerini kurmayı veya FontsLoader kullanmayı unutmayın.
{{% /alert %}}