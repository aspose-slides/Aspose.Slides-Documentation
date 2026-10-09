---
title: Örnekleri Çalıştırma
type: docs
weight: 140
url: /tr/java/how-to-run-the-examples/
keywords:
- örnekler
- yazılım gereksinimleri
- GitHub
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java örneklerini hızlı bir şekilde çalıştırın: depoyu klonlayın, paketleri geri yükleyin, ardından PPT, PPTX ve ODP özelliklerini derleyin ve test edin."
---
## **GitHub'dan Aspose.Slides'ı İndirin**
Aspose.Slides for Java'nın tüm örnekleri [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java) üzerinden sunulmaktadır. Depoyu tercih ettiğiniz GitHub istemcisiyle klonlayabilir veya ZIP dosyasını [buradan](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) indirebilirsiniz.

ZIP dosyasının içeriğini bilgisayarınızdaki herhangi bir klasöre çıkarın. Tüm örnekler **Examples** klasöründe bulunur.

![todo:image_alt_text](examples_directory.png)

## **Örnekleri IDE'ye Aktarın**
Proje Maven derleme sistemini kullanır. Herhangi bir modern IDE projeyi ve bağımlılıklarını kolayca açabilir veya içe aktarabilir. Aşağıda popüler IDE'lerde örnekleri derleme ve çalıştırma adımlarını gösteriyoruz.

### **IntelliJ IDEA**
**Dosya** menüsüne tıklayın ve **Aç** seçeneğini seçin. Proje klasörüne gidin ve **pom.xml** dosyasını seçin.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Proje açılacak ve bağımlılıklar otomatik olarak indirilecektir. **Project** sekmesinden **src/main/java** klasöründeki örnekleri göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve “Run ..” (Çalıştır ..) seçeneğini seçin; örnek yürütülür ve çıktı yerleşik konsol penceresinde gösterilir.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**Dosya** menüsüne tıklayın ve **Import** (İçe Aktar) seçeneğini seçin. **Maven** - Existing Maven Projects (Mevcut Maven Projeleri) öğesini seçin.

![todo:image_alt_text](eclipse_import.png)

GitHub'dan klonladığınız veya indirdiğiniz klasöre gidin ve **pom.xml** dosyasını seçin. Proje açılacak ve bağımlılıklar otomatik olarak indirilecektir. **Package Explorer** sekmesinden **src/main/java** klasöründeki örnekleri göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve **Run As** - **Java Application** (Uygulama Olarak Çalıştır - Java Uygulaması) seçeneğini seçin; örnek yürütülür ve çıktı yerleşik konsol penceresinde gösterilir.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**Dosya** menüsüne tıklayın ve **Open Project** (Projeyi Aç) seçeneğini seçin. GitHub'dan klonladığınız veya indirdiğiniz klasöre gidin. **Examples** klasörünün ikonu bir Maven projesi olduğunu gösterecektir. **Examples** klasörünü seçin ve açın.

![todo:image_alt_text](netbeans_openproject.png)

Proje açılacak ve bağımlılıklar otomatik olarak indirilecektir. **Projects** sekmesinden **source packages** içinde örnekleri göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve **Run File** (Dosyayı Çalıştır) seçeneğini seçin; örnek yürütülür ve çıktı yerleşik konsol penceresinde gösterilir.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides Kütüphanesini Maven Yerel Depoya Ekleyin**
**Aspose.Slides Örnekleri** projesini IDE'ye içe aktardığınızda Maven, [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) adresinden aspose.slides JAR dosyasını otomatik olarak indirir. İnternete erişiminiz yoksa JAR dosyasını yerel deponuza manuel olarak ekleyebilirsiniz.

### **mvn install**
[aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) dosyasını indirin, içeriğini çıkarın ve aspose.slides‑version.jar dosyasını örneğin C sürücüsüne kopyalayın. Aşağıdaki komutu çalıştırın:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Artık **aspose.slides** JAR dosyası Maven yerel deponuza kopyalanmış olacaktır.

### **pom.xml**
Kurulumdan sonra **aspose.slides** koordinatlarını pom.xml dosyanıza ekleyin. **repositories** bölümüne aşağıdaki depo satırını ve **dependencies** bölümüne bağımlılık satırını ekleyin.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>26.10</version>
    <classifier>jdk8</classifier>
</dependency>
```

### **Tamam**
Projeyi derleyin; artık **aspose.slides** JAR dosyası Maven yerel deponuzdan alınabilecektir.

## **Katkıda Bulunma**
Bir örnek eklemek veya iyileştirmek istiyorsanız projeye katkıda bulunmanız teşvik edilir. Bu depodaki tüm örnekler ve gösterim projeleri açık kaynaklıdır ve kendi uygulamalarınızda özgürce kullanılabilir.

Katkıda bulunmak için depoyu fork'layabilir, kaynak kodu düzenleyebilir ve bir Pull Request gönderebilirsiniz. Değişiklikleri inceleyecek ve faydalı bulunduğu takdirde depoya dahil edeceğiz.