---
title: Aspose.Slides for Android via Java'ı Kurun
type: docs
weight: 90
url: /tr/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides'ı kur
- Aspose.Slides'ı indir
- Aspose.Slides'ı kullan
- Aspose.Slides kurulumu
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ı hızlı bir şekilde kurun. Adım adım rehber, sistem gereksinimleri ve Java kod örnekleri — bugün PowerPoint sunumlarıyla çalışmaya başlayın!"
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java'yı nasıl kuracağınızı ve bir Android projesine nasıl ekleyeceğinizi açıklar. İki kurulum seçeneğini tanımlar: Aspose.Slides JAR dosyasını projeye manuel olarak eklemek ve kütüphaneyi Maven deposundan yüklemek.

Makale ayrıca, Android Studio'da yeni bir Android uygulaması oluşturmayı, Aspose.Slides kütüphanesine referans eklemeyi, programmatically bir PowerPoint sunumu oluşturmayı ve PPTX formatında kaydetmeyi gösteren adım adım bir örnek sunar. Ayrıca sürümleme notları içerir ve entegrasyonun doğrulanması, bellek kullanımının yönetilmesi ve son JAR boyutunun küçültülmesi konusundaki yaygın sorulara yanıt verir.

## **Kurulum**
Daha önce, Aspose.Slides for Android via Java tek bir ZIP dosyası halinde dağıtılıyordu; bu dosya JAR dosyasını, demoları ve ürün belgelerini içeriyordu. 

1. Aspose.Words for Android via Java 18.9'dan daha eski bir sürüm kullanmak istiyorsanız, Aspose.Slides.Android.zip dosyasının o sürümünü tercih ettiğiniz dizine çıkartmanız gerekir. 
1. Çıkarılan Jar dosyasını, Build Path yapılandırmasını kullanarak uygulamanıza ekleyin. 

### **Aspose.Slides for Android via Java Jar'a Referans Ekle**
1. En yeni sürümünü indirin [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/tr/androidjava)
1. aspose-slides-18.9-android.via.java.jar dosyasını projenizin *libs/*klasörüne kopyalayın

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

### **Maven Deposu'ndan Aspose.Slides for Android via Java'ı Yükleme**
1. Maven deposunu build.gradle dosyanıza ekleyin. 
1. JAR'ı bağımlılık olarak eklemek için [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) adresini kullanın.

``` java

 // 1. build.gradle dosyanıza Maven deposu ekleyin 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. 'Aspose.Slides for Android via Java' JAR'ı bir bağımlılık olarak ekleyin

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```
## **Aspose.Slides for Android via Java Kullanarak İlk Uygulamanız**
Bu bölümde, Aspose.Slides for Android via Java ile nasıl başlayacağınızı öğreneceksiniz. Sıfırdan yeni bir Android projesi oluşturmayı, Aspose.Slides JAR'ına referans eklemeyi ve PPTX formatında diske kaydedilen yeni bir PowerPoint sunumu yaratmayı göstermek istiyoruz. Örnek burada geliştirme için [Android Studio](https://developer.android.com/studio/index.html) kullanıyor ve uygulama Android Emülatöründe çalıştırılıyor. Aspose.Slides for Android via Java ile başlamanız için, Aspose.Slides for Android via Java kullanan bir uygulama oluşturmak adına bu adım adım öğreticiyi izleyin:

1. Android Studio'yu indirin ve istediğiniz bir konuma kurun. 
1. Android Studio'yu çalıştırın. 
1. Yeni bir Android Application Projesi oluşturun.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. aspose-slides-XX.XX-android.via.java.jar dosyasını projenizin libs/klasörüne kopyalayın

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Proje Bölümünü (dosya menüsünden) seçin ve Bağımlılıklar sekmesine tıklayın.
   1. "+" düğmesine tıklayın. Dosya bağımlılık seçeneğini seçin.
   1. libs klasöründen Aspose.Slides kütüphanesini seçin ve Tamam'a tıklayın.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. Gerekirse projeyi gradle dosyalarıyla senkronize edin. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. SD karta erişmek için özel izinlerin eklenmesi gerekir. AndroidManifest.xml dosyasına tıklayın ve XML görünümünü seçin. Dosyaya şu satırı ekleyin <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Uygulamanın kod bölümüne geri dönün ve bu içe aktarmaları ekleyin: 

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 

```

Şimdi, onCreate metodunun gövdesine bu kodu ekleyerek Aspose.Slides kullanarak sıfırdan yeni bir Presentation oluşturun ve SDCard'e PPTX formatında kaydedin.

``` java

 try

{

    // PPTX'i temsil eden Presentation sınıfını örnekleyin
    Presentation pres = new Presentation();



    // İlk slayta erişin
    ISlide sld = pres.getSlides().get_Item(0);



    // Rectangle tipinde bir AutoShape ekleyin
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Rectangle'a TextFrame ekleyin
    ashp.addTextFrame(" ");



    // Text frame'e erişim
    ITextFrame txtFrame = ashp.getTextFrame();



    // Text frame için Paragraph nesnesi oluşturun
    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Paragraph için Portion nesnesi oluşturun
    IPortion portion = para.getPortions().get_Item(0);



    // Metni ayarlayın
    portion.setText("Aspose TextBox");



    // PPTX'i karta kaydedin
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}

catch (Exception e)

{
   e.printStackTrace();
}
```

Tam kod aşağıdaki gibi görünmelidir:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. Şimdi uygulamayı tekrar çalıştırın. Bu sefer, Aspose.Slides kodu arka planda çalışacak ve SD karta kaydedilen bir belge oluşturacaktır.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Oluşturulan belgeyi görüntülemek için Araçlar menüsüne gidin. Android'i seçin ve ardından Android Device Monitor'ı seçin

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Sürümleme**
2018'den beri, Aspose.Slides for Android via Java sürümleme sistemi Aspose.Slides for Java ile uyumludur.

## **SSS**

**Aspose.Slides'ın doğru bir şekilde entegre edildiğini nasıl doğrulayabilirim?**

Projenizi derleyin, boş bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) nesnesi oluşturun ve yeni bir adla kaydedin. Dosya istisna fırlatmadan oluşturulursa, kütüphane başarıyla entegre edilmiştir.

**Büyük sunumları işlerken bellek tüketimini nasıl sınırlayabilirim?**

JVM bellek limitlerini yalnızca gerektiği kadar yükseltin ve her [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini bir `finally` bloğunda kapatarak önbelleği hemen serbest bırakın. Bu, bellek yetersizliği hatalarını önler ve toplu işlemler sırasında toplam bellek kullanımını öngörülebilir tutar.

**İstenmeyen dışa aktarım formatlarını dışarı çıkararak son JAR boyutunu küçültebilir miyim?**

Mevcut Aspose.Slides sürümleri tek bir monolitik kütüphane olarak dağıtıldığı için, derleme sırasında PDF veya SVG gibi belirli dışa aktarıcıları devre dışı bırakamazsınız.