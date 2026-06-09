---
title: Örnekleri Çalıştırma
type: docs
weight: 140
url: /tr/php-java/how-to-run-the-examples/
keywords:
- örnekler
- yazılım gereksinimleri
- GitHub
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java örneklerini hızlıca çalıştırın: depoyu klonlayın, paketleri geri yükleyin, ardından PPT, PPTX ve ODP özelliklerini oluşturup test edin."
---
## **GitHub'dan İndir**
Aspose.Slides for PHP via Java'nin tüm örnekleri [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) üzerinde barındırılmaktadır. Depoyu favori Github istemcinizle klonlayabilir veya ZIP dosyasını [buradan](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) indirebilirsiniz.

ZIP dosyasının içeriğini bilgisayarınızdaki herhangi bir klasöre çıkarın. Tüm örnekler **Examples** klasöründe bulunur.

![todo:image_alt_text](examples_directory.png)

## **Örnekleri IDE'ye İçe Aktarın**
Proje Maven yapı sistemini kullanır. Herhangi bir modern IDE projeyi ve bağımlılıklarını kolayca açabilir veya içe aktarabilir. Aşağıda popüler IDE'leri kullanarak örnekleri nasıl derleyeceğinizi ve çalıştıracağınızı gösteriyoruz.

### **IntelliJ IDEA**
**File** menüsüne tıklayın ve **Open** seçeneğini seçin. Proje klasörüne gidin ve **pom.xml** dosyasını seçin.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Proje otomatik olarak açılacak ve bağımlılıklar indirilecektir. **Project** sekmesinden **src/main/java** klasöründeki örneklere göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve "Run .." seçeneğini seçin; örnek yürütülecek ve çıktı yerleşik konsol penceresinde gösterilecektir.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** menüsüne tıklayın ve **Import** seçeneğini seçin. **Maven** - Existing Maven Projects seçeneğini seçin.

![todo:image_alt_text](eclipse_import.png)

GitHub'dan klonladığınız veya indirdiğiniz klasöre gidin ve **pom.xml** dosyasını seçin. Proje otomatik olarak açılacak ve bağımlılıklar indirilecektir. **Package Explorer** sekmesinden **src/main/java** klasöründeki örneklere göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve **Run As** - **Java Application** seçeneğini seçin; örnek yürütülecek ve çıktı yerleşik konsol penceresinde gösterilecektir.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** menüsüne tıklayın ve **Open Project** seçeneğini seçin. GitHub'dan klonladığınız veya indirdiğiniz klasöre gidin. **Examples** klasörünün simgesi bir Maven projesi olduğunu gösterecektir. Examples klasörünü seçip açın.

![todo:image_alt_text](netbeans_openproject.png)

Proje otomatik olarak açılacak ve bağımlılıklar indirilecektir. **Projects** sekmesinden **source packages** içindeki örneklere göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve **Run File** seçeneğini seçin; örnek yürütülecek ve çıktı yerleşik konsol penceresinde gösterilecektir.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides Kütüphanesini Maven Yerel Depoya Ekleyin**
**Aspose.Slides Examples** projesini IDE'ye içe aktardığınızda, Maven [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) üzerinden aspose.slides JAR dosyasını otomatik olarak indirir. İnternete erişiminiz yoksa, JAR dosyasını yerel deponuza manuel olarak ekleyebilirsiniz.

### **mvn install**
[aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/) dosyasını indirin, çıkarın ve aspose.slides-version.jar dosyasını başka bir yere, örneğin C sürücüsüne kopyalayın. Aşağıdaki komutu çalıştırın:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

Artık **aspose.slides** jar dosyası Maven yerel deponuza kopyalanmıştır.

### **pom.xml**
Kurulumdan sonra, pom.xml içinde **aspose.slides** koordinatını sadece bildirmeniz yeterlidir. repositories sekmesine aşağıdaki depoyu ve dependencies sekmesine bağımlılığı ekleyin.

``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php
```

### **Tamam**
Projeyi derleyin, artık **aspose.slides** jar dosyası Maven yerel deponuzdan alınabilir.

## **Katkıda Bulun**
Bir örnek eklemek veya iyileştirmek isterseniz, projeye katkıda bulunmanızı öneririz. Bu depodaki tüm örnekler ve demo projeler açık kaynaktır ve kendi uygulamalarınızda özgürce kullanılabilir.

Katkı sağlamak için depoyu fork edebilir, kaynak kodunu düzenleyebilir ve bir Pull Request gönderebilirsiniz. Değişiklikleri inceleyecek ve faydalı bulursak depoya ekleyeceğiz.