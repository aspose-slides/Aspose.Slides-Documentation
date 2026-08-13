---
title: Linux'ta Yazı Tipleriyle İlgili Ortak İstisna ve Hatalar
type: docs
weight: 200
url: /tr/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Yazı tipi istisnası, Yazı tipi hatası, Linux, Java, Aspose.Slides for Java"
description: "Linux'ta yazı tipi istisnaları ve hataları"
---
## **Genel Bakış**

Aspose.Slides Linux üzerinde kullanıldığında, Java süreci gerekli yazı tipi klasörlerine veya geçici dizine erişemezse, sistemde hiçbir yazı tipi yüklü değilse veya fontconfig ya da libfreetype gibi gerekli sistem kütüphaneleri eksikse, yazı tipiyle ilgili sorunlar ortaya çıkabilir.

Bu makale, Linux'ta yazı tipleriyle ilgili yaygın hataları ve istisnaları açıklar ve bunları çözmek için çözümler sunar. Yazı tipi ve TEMP dizinlerine erişimin nasıl kontrol edileceğini, gerekli yazı tipleri ve kütüphanelerin nasıl kurulacağını ve `FontsLoader`'ı sistem genelinde kurulum yapmadan yazı tiplerini yüklemek için nasıl kullanılacağını açıklar.

## **Linux'ta Kod Çalıştırıldığında Eksik Metin veya Görüntüler (EMF veya WMF)**

Bu sorun, aşağıdaki durumlarda kısıtlamalar bulunan sistemlerde ortaya çıkar:

1. Yazı tipi yüklü olmadığında veya Java süreci için yazı tipi klasörüne erişilemediğinde
2. TEMP dizinine erişilemediğinde.

### **Çözüm**

TEMP dizinine ve yazı tipi klasörüne erişimin sağlandığını kontrol edin ve doğrulayın. 

{{% alert color="warning" %}}
Bazı durumlarda, ortam ya da güvenlik politikası tarafından uygulanan kısıtlamalar nedeniyle klasörlere erişim izni veremeyebilirsiniz. Aşağıdaki geçici çözümleri deneyin: 
{{% /alert %}}

**Geçici Çözüm**

Yüklemeksizin gereken yazı tiplerini yüklemek için [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader) kullanın:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Eğer TEMP dizinine erişilemezse, Java için TEMP olarak başka bir dizin belirtmek için bu kodu kullanın:
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

## **İstisna: InvalidOperationException: Sistem Üzerinde Yüklü Hiçbir Yazı Tipi Bulunamıyor**

Bu istisna aşağıdaki durumlarda oluşur:

1. Java süreci yazı tipi klasörüne erişemediğinde
2. herhangi bir yazı tipi yüklü olmadığında.

### **Çözüm**

1. Java süreci için yazı tipi klasörüne erişimin sağlandığını kontrol edin ve doğrulayın.
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

Bu istisna, fontconfig ve yazı tipleri eksik olan bir Linux sisteminde oluşur.

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

Ayrıca, bazı open-jdk sürümleri (örneğin, **alpine JDK**) de **yüklü yazı tiplerine** ihtiyaç duyar.

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

## **İstisna: UnsatisfiedLinkError: libfreetype.so.6: Paylaşımlı Nesne Dosyası Açılamadı: Böyle Bir Dosya veya Dizin Yok**

Bu istisna, libfreetype kütüphanesi eksik bir Linux sisteminde oluşur.

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

{{% alert title="TIP" color="info" %}} 
Yazı tiplerini kurmayı veya FontsLoader'ı kullanmayı unutmayın.
{{% /alert %}}