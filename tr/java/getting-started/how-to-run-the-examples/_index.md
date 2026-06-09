---
title: Örnekleri Nasıl Çalıştırılır
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
description: "Aspose.Slides for Java örneklerini hızlıca çalıştırın: depoyu klonlayın, paketleri geri yükleyin, ardından PPT, PPTX ve ODP özelliklerini derleyip test edin."
---
## **GitHub'tan Aspose.Slides'ı İndirin**
Aspose.Slides for Java'nın tüm örnekleri [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) adresinde barındırılmaktadır. Depoyu favori Github istemcinizle klonlayabilir veya ZIP dosyasını [buradan](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) indirebilirsiniz.

ZIP dosyasının içeriğini bilgisayarınızdaki herhangi bir klasöre çıkarın. Tüm örnekler **Examples** klasöründe bulunur.

![todo:image_alt_text](examples_directory.png)

## **Örnekleri IDE'ye İçe Aktarın**
Proje Maven yapı sistemini kullanır. Herhangi bir modern IDE projeyi ve bağımlılıklarını kolayca açabilir veya içe aktarabilir. Aşağıda popüler IDE'lerde örnekleri nasıl derleyip çalıştıracağınızı gösteriyoruz.

### **IntelliJ IDEA**
**File** menüsüne tıklayın ve **Open** seçeneğini seçin. Proje klasörüne gidin ve **pom.xml** dosyasını seçin.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Proje açılacak ve bağımlılıklar otomatik olarak indirilecektir. **Project** sekmesinden **src/main/java** klasöründeki örneklere göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve "Run .." seçeneğini seçin; örnek yürütülecek ve çıktısı yerleşik konsol penceresinde gösterilecektir.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** menüsüne tıklayın ve **Import** seçeneğini seçin. **Maven** - Existing Maven Projects seçeneğini işaretleyin.

![todo:image_alt_text](eclipse_import.png)

GitHub'tan klonladığınız veya indirdiğiniz klasöre gidin ve **pom.xml** dosyasını seçin. Proje açılacak ve bağımlılıklar otomatik olarak indirilecektir. **Package Explorer** sekmesinden **src/main/java** klasöründeki örneklere göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve **Run As** - **Java Application** seçeneğini seçin; örnek yürütülecek ve çıktısı yerleşik konsol penceresinde gösterilecektir.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** menüsüne tıklayın ve **Open Project** seçeneğini seçin. GitHub'tan klonladığınız veya indirdiğiniz klasöre gidin. **Examples** klasörünün simgesi Maven projesi olduğunu gösterir. **Examples** klasörünü seçip açın.

![todo:image_alt_text](netbeans_openproject.png)

Proje açılacak ve bağımlılıklar otomatik olarak indirilecektir. **Projects** sekmesinden **source packages** içinde örneklere göz atın. Bir örneği çalıştırmak için dosyaya sağ tıklayın ve **Run File** seçeneğini seçin; örnek yürütülecek ve çıktısı yerleşik konsol penceresinde gösterilecektir.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides Kütüphanesini Maven Yerel Depoya Ekle**
**Aspose.Slides Examples** projesini IDE'ye ithal ettiğinizde Maven, [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) adresinden aspose.slides JAR dosyasını otomatik olarak indirir. İnternete erişiminiz yoksa JAR dosyasını yerel deponuza manuel olarak ekleyebilirsiniz.

### **mvn install**
[aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) indirin, çıkarın ve aspose.slides‑version.jar dosyasını örneğin C sürücüsüne kopyalayın. Aşağıdaki komutu çalıştırın:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Şimdi **aspose.slides** jar dosyası Maven yerel deponuza kopyalanmış oldu.

### **pom.xml**
Kurulumun ardından **aspose.slides** koordinatını pom.xml dosyanıza ekleyin. **repositories** sekmesine aşağıdaki depoyu, **dependencies** sekmesine de bağımlılığı ekleyin.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```

### **Tamam**
Projeyi derleyin, artık **aspose.slides** jar dosyası Maven yerel deponuzdan alınabilir.

## **Katkıda Bulunun**
Bir örnek eklemek veya iyileştirmek isterseniz, projeye katkıda bulunmanızı öneririz. Bu depodaki tüm örnekler ve vitrini projeler açık kaynaklıdır ve kendi uygulamalarınızda özgürce kullanılabilir.

Katkıda bulunmak için depoyu fork'layabilir, kaynak kodunu düzenleyebilir ve bir Pull Request gönderebilirsiniz. Değişiklikleri inceleyecek ve faydalı bulursak depoya ekleyeceğiz.