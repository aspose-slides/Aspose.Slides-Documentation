---
title: Linux ve Docker'da Aspose.Slides for Java için Fontları Dağıtın
linktitle: Fontları Dağıt
type: docs
weight: 155
url: /tr/java/deploy-fonts/
keywords:
- fontları dağıt
- fontları kur
- Docker'da fontlar
- Linux'ta fontlar
- eksik fontlar
- font değişimi
- Microsoft temel fontları
- ttf-mscorefonts-installer
- özel fontlar
- varsayılan font
- sunucu
- konteyner
- PDF dönüşümü
- sunum
- Java
- Aspose.Slides
description: "Linux sunucularında ve Docker konteynerlerinde Aspose.Slides for Java için fontları dağıtın: hangi fontların yedeklendiğini kontrol edin, Debian, Ubuntu ve Alpine'de font paketlerini kurun, kendi font dosyalarınızı ekleyin ve varsayılan bir font ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu render ettiğinde, örneğin slaytları PDF'ye veya görüntülere dönüştürdüğünde, mevcut fontları kullanarak metin çizer. Windows masaüstü genellikle sunumların kullandığı fontlara sahiptir. Linux sunucular ve konteynerler genellikle çok az font içerir, bu yüzden Aspose.Slides metni bir yedek fontla çizer. Yedek font, farklı harf şekilleri ve genişliklerine sahiptir, bu yüzden satırlar farklı şekilde kayabilir ve metin şeklinin dışına taşabilir; yedek fontta bulunmayan karakterler doğru çizilmez. Hiç font yüklü değilse, Java'nın font desteği başlatılamaz ve Aspose.Slides bir hata ile durur.

Bu makale, Aspose.Slides'in hangi fontları yedeklediğini nasıl kontrol edeceğinizi, Debian, Ubuntu ve Alpine Linux üzerinde fontları nasıl kuracağınızı, kendi font dosyalarınızı nasıl ekleyeceğinizi ve bir font eksik olduğunda kullanılan fontu nasıl ayarlayacağınızı gösterir. Örnekler, resmi Eclipse Temurin imajları üzerinde Docker'da çalıştırılır; örnek [Run Aspose.Slides for Java in Docker](/slides/tr/java/how-to-run-aspose-slides-in-docker/) adresindedir. Paket komutları Dockerfile talimatlarıdır; bir Linux sunucusunda aynı komutları root olarak çalıştırın.

Font API'siyle ilgili, örneğin bir sunuma font gömmek ve geri dönüş/yerine koyma kuralları gibi konular için [PowerPoint Fonts](/slides/tr/java/powerpoint-fonts/) sayfasına bakın.

## **Yedeklenen Fontları Kontrol Et**

Aşağıdaki Maven projesi, mevcut ortamda Aspose.Slides'in yedeklediği fontları raporlar. *font-check* adlı bir klasör oluşturun ve aşağıdaki dosyaları bu klasöre ekleyin.

*`pom.xml`* dosyası, [Run Aspose.Slides for Java in Docker](/slides/tr/java/how-to-run-aspose-slides-in-docker/#create-the-project) adresindeki gibi, ancak artifact ID ve JAR dosya adı *font-check* olarak değiştirilmiştir:
```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <finalName>font-check</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*`src/main/java/FontCheck.java`* her bir font adı için bir metin kutusu ekler ve fontu [setLatinFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) yöntemiyle atar. Font adları komut satırından gelir; argüman verilmezse program Calibri, Arial ve Times New Roman'ı kontrol eder. Aspose.Slides'in fontları aradığı klasörleri ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#getFontFolders--)) yazdırır, slaytı *output/fonts.pdf* dosyasına render eder ve [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) tarafından raporlanan yedeklemeleri listeler. Başlangıçtaki iki isteğe bağlı adım, bir *fonts* klasörünü yüklemek ve bir `DEFAULT_FONT` değişkeni okumak, bu makalenin ilerleyen bölümlerinde açıklanmıştır.
```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // Kontrol edilecek fontlar: komut satırı argümanları ya da üç yaygın Office fontu.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Çalışma dizinindeki fonts klasöründen font dosyalarını yükle, eğer mevcutsa.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // DEFAULT_FONT ortam değişkeninde belirtilen fontu kullan, eğer ayarlıysa, eksik fontlu metinler için.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` aynı klasörü birden fazla kez döndürebilir, bu nedenle program klasörleri bir kümede toplayıp ardından yazdırır.

*.dockerignore* yerel yapı sonuçlarını yapı bağlamından dışarı tutar:
```text
target/
output/
```

*Dockerfile* programı Maven imajı ile derler ve Eclipse Temurin Java çalışma zamanı imajı üzerinde çalıştırır; bu imaj zaten fontconfig ve DejaVu fontlarını içerir. [Run Aspose.Slides for Java in Docker](/slides/tr/java/how-to-run-aspose-slides-in-docker/) her talimatı açıklar.
```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

İmajı derleyin ve kontrolü çalıştırın:
```bash
docker build -t font-check .
docker run --rm font-check
```

İmaj yalnızca DejaVu fontlarını içerdiği için üç font da DejaVu Sans ile değiştirilir:
```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Kendi sunumlarınızın fontlarını kontrol etmek için isimlerini argüman olarak geçirin, örneğin `docker run --rm font-check "Segoe UI" Consolas`. *output/fonts.pdf* dosyasını konteynerden kopyalamak için [Copy the Output to Your Machine](/slides/tr/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) bölümündeki komutları kullanın.

## **Debian ve Ubuntu Üzerinde Fontları Kur**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer` paketi, Arial, Times New Roman, Courier New, Verdana, Georgia ve Trebuchet MS gibi Microsoft'un web için temel fontlarını indirir ve kurar. Fontlar, Microsoft'un son kullanıcı lisans sözleşmesi (EULA) kapsamında lisanslanmıştır ve paket, EULA kabul edildikten sonra bunları kurar. Docker derlemesi bu soruya yanıt veremez, bu yüzden kurucu EULA'yı reddeder ve hiçbir font kurmaz; `apt-get install` hâlâ başarılı gibi raporlanır. Paketi kurmadan **önce** `debconf-set-selections` ile EULA'yı kabul edin. Daha sonraki bir talimatta kabul etmek işe yaramaz; paket zaten kurulmuş olur ve apt kurucuyu tekrar çalıştırmaz.

Bu talimatı *Dockerfile*'ın çalışma süresi aşamasına, `FROM` satırının hemen sonrasına, `USER` talimatından önce ekleyin; böylece root olarak çalışır:
```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

İmajı yeniden derleyin ve aynı iki komutla kontrolü tekrar çalıştırın. Arial ve Times New Roman şimdi kuruludur:
```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Aspose.Slides'in oluşturduğu bir sunumun varsayılan fontu Calibri, temel fontlar arasında yer almadığı için hâlâ yedeklenir. Bkz. [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Ubuntu tabanlı Eclipse Temurin imajları `multiverse` bileşenini etkinleştirir; bu bileşen paket içerir. Debian'da paket `contrib` bileşenindedir ve Debian imajları bunu etkinleştirmez. Debian tabanlı bir çalışma aşamasında, örneğin [Use Another Base Image](/slides/tr/java/how-to-run-aspose-slides-in-docker/#use-another-base-image) içindekinde, aynı talimat içinde `contrib`'u etkinleştirin:
```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Diğer Font Paketleri**

Debian ve Ubuntu ayrıca serbest lisanslı fontları paketler, örnek:

| Paket | Fontlar |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif ve Mono, Arial, Times New Roman ve Courier New ile aynı metriklere sahip |
| `fonts-crosextra-carlito` | Carlito, Calibri ile aynı metriklere sahip |
| `fonts-crosextra-caladea` | Caladea, Cambria ile aynı metriklere sahip |

Bu paketleri çalışma aşamasındaki bir `RUN` talimatında `apt-get install` ile kurun; Microsoft temel fontlarıyla aynı şekilde yapılır. Aspose.Slides for Java, Linux font yapılandırmasının takma adlarını uygular; `fonts-liberation` kurulu olsa bile Arial'deki metin hâlâ genel yedek fontla çizilir, Liberation Sans ile değil. Eksik bir fontun yerine metrik‑uyumlu bir font kullanmak için onu [varsayılan font](#set-a-default-font-for-missing-fonts) olarak ayarlayın veya bir [font yedekleme kuralı](/slides/tr/java/font-substitution/) ekleyin.

## **Kendi Font Dosyalarınızı Ekleyin**

Dağıtımların paketlemediği fontlar—örneğin kuruluşunuzun fontları veya sunucuda kullanma lisansına sahip olduğunuz diğer fontlar—font dosyaları olarak eklenebilir. Font dosyalarını, örneğin *.ttf* dosyalarını, *font-check* klasörünün içindeki *fonts* adlı bir klasöre koyun. Aşağıdaki örnekler, Calibri ile aynı metriklere sahip bir font olan Carlito'nun dosyalarını kullanır; bunları [Google Fonts](https://fonts.google.com/specimen/Carlito) adresinden indirebilirsiniz.

### **Fontları Sistem Font Klasörüne Kurun**

Aspose.Slides, `Font folders` satırında listelenen klasörlerdeki fontları okur. Fontlarınızı imajdaki tüm uygulamalar için kurmak üzere, onları */usr/local/share/fonts* içine kopyalayın; bu klasör yerel kurulmuş fontlar içindir. Microsoft temel fontlarını kuran `RUN` talimatından sonra, *Dockerfile*'ın çalışma aşamasına şu talimatı ekleyin:
```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

İmajı yeniden derleyin, ardından Calibri ve Carlito'yu kontrol edin:
```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito artık yedeklenmez:
```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Fontları Uygulama Klasöründen Yükleyin**

Fontları bir sistem klasörüne kurmak yerine, uygulama ile birlikte dağıtabilir ve [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ile yükleyebilirsiniz. Bu şekilde fontlar yalnızca Aspose.Slides tarafından kullanılabilir ve uygulama ile birlikte dağıtılır. *FontCheck* bunu yapar: konteyner içinde çalışma dizini */app* içinde bir *fonts* klasörü olduğunda, program bu klasörü `loadExternalFonts`a sunum oluşturulmadan önce geçirir. [Custom Font](/slides/tr/java/custom-font/) diğer font sağlama yöntemlerini açıklar, örneğin bellekten yükleme.

*Dockerfile* içinde `COPY fonts/ /usr/local/share/fonts/` talimatını kaldırın ve *lib* klasörünü kopyalayan talimatın ardından aşağıdaki talimatı ekleyin:
```dockerfile
COPY fonts/ ./fonts/
```

İmajı yeniden derleyin ve aynı iki komutla kontrolü çalıştırın. Uygulama klasörü artık font klasörleri arasında görünecek ve Carlito hâlâ yedeklenmeyecek:
```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` fontları kurulu olanlara ekler, ancak Java'nın font desteği hâlâ en az bir kurulu font gerekir. Hiç font olmayan bir imajda, `loadExternalFonts` "Fontconfig head is null, check your fonts or fonts configuration" hatasıyla durur.

## **Eksik Fontlar İçin Varsayılan Font Ayarla**

Bir font eksik olduğunda, Aspose.Slides kendiliğinden bir yedek seçer. Bunu siz belirlemek için font adını [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) üzerindeki [setDefaultRegularFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) yöntemine aktarın ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yapıcısına gönderin. *FontCheck*, font adını `DEFAULT_FONT` ortam değişkeninden okur. Carlito yüklüyse, eksik fontlar için onu kullanın:
```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri artık Carlito ile çizilir; karakterlerin genişliği Calibri ile aynı olduğu için metin satır sonlarını korur:
```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Varsayılan font her eksik fontu değiştirir. Tek tek fontları eşlemek için, örneğin Arial'ı Liberation Sans ve Calibri'yi Carlito ile eşlemek, [font yedekleme kuralları](/slides/tr/java/font-substitution/) kullanın. Kurallar render edilen çıktıyı değiştirir, ancak `getSubstitutions` bunları yansıtmaz; bu yüzden fontları çıktı dosyasında kontrol edin. Asya metinleri için ayrıca [setDefaultAsianFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) çağırın; bakınız [Default Font](/slides/tr/java/default-font/).

## **Alpine Linux Üzerinde Fontları Kur**

Alpine tabanlı Eclipse Temurin imajı da DejaVu fontlarını içerir; [Run on Alpine Linux](/slides/tr/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) çalışma aşamasını açıklar. Microsoft temel fontlarını da kurmak için *font-check* Dockerfile'ının çalışma aşamasını şu şekilde değiştirin:
```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` Debian ve Ubuntu paketindeki aynı Microsoft temel fontlarını indirir ve kurar; EULA aynı biçimde uygulanır. `fc-cache` fontconfig önbelleğini günceller. İmajı derleyin ve [Yedeklenen Fontları Kontrol Et](#check-which-fonts-are-substituted) bölümündeki iki komutla kontrolü çalıştırın. Şu çıktıyı verir:
```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Bu sayfadaki diğer adımlar Alpine'de aynı şekilde çalışır: *fonts* klasörünü */usr/local/share/fonts* ya da uygulama klasörüne kopyalayın ve `DEFAULT_FONT` ayarını varsayılan font seçmek için kullanın. Alpine imajında */usr/local/share/fonts* klasörü yoktur; bu klasör yalnızca bir `COPY` talimatı oluşturduktan sonra `Font folders` satırında görünür.

## **SSS**

**Bir sunum sunucuda dönüştürüldüğünde neden farklı görünür?**

Sunucuda sunumun kullandığı fontlar bulunmadığı için Aspose.Slides metni, harf genişlikleri farklı olan bir yedek fontla çizer. Hangi fontların yedeklendiğini görmek için *FontCheck*'i sunumun font adlarıyla çalıştırın, ardından bu fontları kurun ya da uygulama klasöründen yükleyin.

**Derleme `ttf-mscorefonts-installer` paketini kurdu ancak Arial hâlâ yedekleniyor. Neden?**

EULA paket kurulumundan önce kabul edilmediği için kurucu fontları atladı. Paketi kuran talimat içinde `debconf-set-selections` komutunu `apt-get install`'den **önce** ekleyin; bkn. [Microsoft Core Fonts](#microsoft-core-fonts) ve imajı yeniden derleyin.

**PDF'yi açan bilgisayarın fontları gereklidir?**

Hayır. Bu örneklerde PDF, metni çizerken kullanılan fontları içerir; bu yüzden herhangi bir bilgisayarda aynı şekilde görünür. Fontlar yalnızca Aspose.Slides'in sunumu render ettiği ortamda gereklidir.