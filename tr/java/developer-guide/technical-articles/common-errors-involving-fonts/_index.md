---
title: Linux'ta Yazı Tipleriyle İlgili Ortak İstisnalar ve Hatalar
type: docs
weight: 200
url: /tr/java/common-errors-involving-fonts/
keywords: "Yazı tipi istisnası, Yazı tipi hatası, Linux, Java, Aspose.Slides for Java"
description: "Linux'ta yazı tipi istisnaları ve hataları"
---
## **Genel Bakış**

Aspose.Slides Linux'ta kullanıldığında, Java işlemi gerekli yazı tipi klasörlerine veya geçici dizine erişemezse, sistemde hiç yazı tipi yüklü değilse veya fontconfig veya libfreetype gibi gerekli sistem kütüphaneleri eksikse, yazı tipiyle ilgili sorunlar ortaya çıkabilir.

Bu makale, Linux'ta yazı tipleriyle ilgili yaygın hata ve istisnaları açıklar ve çözüm önerileri sunar. Yazı tipi ve TEMP dizinlerine erişimin nasıl kontrol edileceğini, gerekli yazı tipleri ve kütüphanelerin nasıl yükleneceğini ve `FontsLoader` kullanarak sistem genelinde yüklemeden yazı tiplerini nasıl yükleyeceğinizi anlatır.

## **Linux'ta Kod Çalıştırıldığında Eksik Metin veya Görüntüler (EMF veya WMF)**

Bu sorun aşağıdaki durumlarda kısıtlamalar bulunan sistemlerde oluşur:

1. Yazı tipi yüklü olmadığında veya Java işlemi için yazı tipi klasörüne erişilemediğinde
2. TEMP dizinine erişilemediğinde.

### **Çözüm**

TEMP dizinine ve yazı tipi klasörüne erişimin sağlandığını kontrol edin ve onaylayın. 

{{% alert color="warning" %}}

Bazı durumlarda, ortam veya güvenlik politikası kaynaklı kısıtlamalar nedeniyle klasörlere erişim izni veremeyebilirsiniz. Bu çözüm yollarını deneyin: 

{{% /alert %}}

**Geçici Çözüm**

Yüklemeye gerek kalmadan gerekli yazı tiplerini yüklemek için [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader) kullanın:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Eğer TEMP dizinine erişilemiyorsa, Java için TEMP'i başka bir dizin olarak belirlemek üzere bu kodu kullanın:
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

Bu istisna aşağıdaki durumlarda ortaya çıkar:

1) Java işlemi yazı tipi klasörüne erişemediğinde  
2) hiçbir yazı tipi yüklü olmadığında.

### **Çözüm**

1. Java işlemi için yazı tipi klasörüne erişimin sağlandığını kontrol edin ve onaylayın.

2. Bazı yazı tipleri yükleyin veya [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/FontsLoader) kullanın.

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

## **İstisna: NoClassDefFoundError: com.aspose.slides.internal.ey.this Sınıfı Başlatılamadı**

Bu istisna, fontconfig ve yazı tipleri bulunmayan bir Linux sisteminde ortaya çıkar. 

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

Ayrıca, bazı open-jdk sürümleri (örneğin, **alpine JDK**) da **yüklü yazı tiplerine** ihtiyaç duyar.

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

## **İstisna: UnsatisfiedLinkError: libfreetype.so.6: Paylaşılan Nesne Dosyası Açılmadı: Böyle Bir Dosya ya da Dizin Yok**

Bu istisna, libfreetype kütüphanesi bulunmayan bir Linux sisteminde ortaya çıkar. 

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

{{% alert title="TIP" color="primary" %}} 

Yazı tiplerini yüklemeyi veya FontsLoader kullanmayı unutmayın.

{{% /alert %}}