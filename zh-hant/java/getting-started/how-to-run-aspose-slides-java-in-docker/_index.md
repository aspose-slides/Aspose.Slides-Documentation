---
title: 在 Docker 中執行 Aspose.Slides for Java
linktitle: Docker
type: docs
weight: 150
url: /zh-hant/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker 容器
- 多階段建置
- 容器映像
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- 字型
- PDF 轉換
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "在 Docker 中建置並執行 Aspose.Slides for Java 應用程式：使用官方 Maven 與 Eclipse Temurin 映像的多階段 Dockerfile、Aspose.Slides 所需的 Linux 函式庫與字型，以及如何將產生的檔案複製到您的機器。"
---
## **概觀**

本文說明如何在 Docker 容器中執行 Aspose.Slides for Java。您會建立一個小型 Maven 專案，該專案會建立一個包含文字方塊的簡報並將其轉換為 PDF，使用官方的 Maven 和 Eclipse Temurin 映像以多階段 Dockerfile 打包，執行它，並將產生的檔案複製到您的機器。本文同時說明 Aspose.Slides 在 Linux 映像中除了 Java 之外還需要什麼，並以 Alpine Linux 以及從發行版套件安裝 Java 的映像為例提供變體。

您只需要在機器上安裝 Docker。JDK 與 Maven 已包含在建置映像中，無需自行安裝。若要安裝 Docker，請參閱[取得 Docker](https://docs.docker.com/get-started/get-docker/)。

## **選擇基礎映像**

本文中的 Dockerfile 使用 Docker Hub 上的兩個官方映像：

- [maven](https://hub.docker.com/_/maven) 標籤為 `3.9-eclipse-temurin-21` 用於建置應用程式。它包含 Apache Maven 3.9 與 Eclipse Temurin JDK 21。
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) 標籤為 `21-jre` 用於執行它。它包含基於 Ubuntu 的 Eclipse Temurin Java 21 執行階段，未包含 JDK 與 Maven。

Aspose.Slides for Java 以 Java 的字型支援繪製文字，在 Linux 上需要 fontconfig、FreeType 函式庫以及至少一種已安裝的字型。Eclipse Temurin 映像已包含 fontconfig、FreeType 與 DejaVu 字型，因此本文的 Dockerfile 不會安裝其他套件。在沒有任何字型的映像中，儲存簡報會因錯誤「Fontconfig head is null, check your fonts or fonts configuration」而停止。若您在其他基礎映像上建置，請參閱[使用其他基礎映像](#use-another-base-image)。

## **建立專案**

建立一個名為 *hello-slides-docker* 的資料夾，並將以下檔案加入其中。

* pom.xml 宣告 Aspose 的 Maven 套件庫與 Aspose.Slides for Java 相依性，如同[安裝](/slides/zh-hant/java/installation/)所述；Aspose.Slides for Java 未發佈於 Maven Central，須額外加入套件庫條目。`finalName` 元素將應用程式 JAR 檔命名為 *hello-slides.jar*，而 [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) 會在 Maven 打包時將相依性複製到 *target/lib*。請將 Aspose.Slides 版號設為 [套件庫](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中的最新版本。

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
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
        <finalName>hello-slides</finalName>
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

* src/main/java/HelloSlides.java 會建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)，在其第一張投影片上加入一個帶文字的矩形，並使用 [save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法分別以 PPTX 與 PDF 格式儲存簡報。兩個檔案會寫入工作目錄下的 *output* 資料夾。程式接著呼叫 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 取得 Aspose.Slides 在渲染時取代的字型，讓您得以檢查容器中是否具備簡報使用的字型。

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

* .dockerignore 會將本機建置產生的 *target* 資料夾與先前執行的輸出排除在 Docker 建置上下文之外，確保映像僅由來源檔案建構。

```text
target/
output/
```

## **撰寫 Dockerfile**

在 *hello-slides-docker* 資料夾內加入一個名為 *Dockerfile* 的檔案：

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

此檔案包含兩個階段：

- **建置階段** 從 Maven 映像開始。它先複製 *pom.xml*，然後執行 `mvn dependency:go-offline`，以下載 Aspose.Slides for Java 以及 Maven 外掛，因而只要 *pom.xml* 未變動，Docker 就會重複使用該層。接著複製來源程式碼並執行 `mvn package`，將程式編譯成 *target/hello-slides.jar*，並將 Aspose.Slides JAR 複製到 *target/lib*。`-B` 參數讓 Maven 以非互動（批次）模式執行。
- **執行階段** 從較小的 Java 執行階段映像開始，只複製應用程式 JAR 與 *lib* 資料夾。它會建立 *output* 資料夾，將其所有權指派給 `ubuntu`（Ubuntu 基礎映像所定義的非 root 使用者），並以該使用者執行應用程式。類別路徑 `hello-slides.jar:lib/*` 包含應用程式本身與 *lib* 中的所有 JAR 檔；`*` 會由 Java 自行展開。

此專案以 Java 11 編譯（`maven.compiler.release` 屬性），因此執行階段可使用較新的 Java 版本。例如，若要在 Java 25 上執行，將執行階段的映像改為 `eclipse-temurin:25-jre`。

## **建置與執行容器**

在 *hello-slides-docker* 資料夾中開啟終端機。先建置映像，之後以該映像執行容器：

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

第一次建置會下載基礎映像、Maven 外掛與 Aspose.Slides for Java，可能需要數分鐘；之後的建置會重複使用快取。容器執行應用程式後結束，並輸出：

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

第一行顯示文字使用的是 Calibri（新簡報的預設字型），而 Calibri 並未安裝於映像中，於是 Aspose.Slides 使用 DejaVu Sans 取代。PDF 中的文字為真實、可選取的文字，且仍使用該字型。未授權時，Aspose.Slides 亦會在每張投影片上加上評估水印；請參閱[授權](/slides/zh-hant/java/licensing/)。

## **將輸出複製到您的機器**

檔案位於已停止容器的 */app/output* 資料夾。將它們複製到機器上的 *output* 資料夾，然後移除容器：

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

上述兩個指令在 Bash、PowerShell 與 Windows 命令提示字元皆可使用。

在 Linux 上，您也可以將機器的資料夾掛載到容器，讓應用程式直接寫入該資料夾：

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` 參數會以您的使用者與群組 ID 執行應用程式，使其能寫入您建立的資料夾，且檔案屬於您本人。`--rm` 會在容器停止時自動移除容器。

## **在 Alpine Linux 上執行**

Eclipse Temurin 亦提供基於 Alpine Linux 的映像，體積更小。它同樣包含 fontconfig、FreeType 與 DejaVu 字型，因此應用程式在此映像上亦不需要額外套件。若要使用，將 *Dockerfile* 中的執行階段（第二個 `FROM` 之後的所有內容）替換為：

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine 映像沒有 `ubuntu` 使用者，因此此階段會以 `adduser` 建立名為 `app` 的使用者，並以該使用者執行應用程式。使用與前述相同的指令建置、執行與複製輸出，應用程式會輸出相同的兩行文字。

## **使用其他基礎映像**

如果您的映像是透過 Linux 發行版的套件安裝 Java，則必須同時安裝 Java 的字型函式庫與至少一種字型。以 Debian 與 Ubuntu 為例，`openjdk-21-jre-headless` 套件僅將 fontconfig、FreeType 與 HarfBuzz 標示為 **建議** 套件，若使用 `apt-get install --no-install-recommends` 便會將它們排除，導致應用程式因找不到 `libfontmanager.so` 而拋出 `UnsatisfiedLinkError`。以下執行階段會在 Debian 13 上安裝 Java 21、相關函式庫與 DejaVu 字型，並建立名為 `app` 的非 root 使用者：

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

相同的階段亦可於 Ubuntu 26.04 上使用 `FROM ubuntu:26.04`。

## **常見問題**

**Saving the presentation stops with "Fontconfig head is null, check your fonts or fonts configuration". What is missing?**  
缺少字型。Java 的字型支援在映像中找不到任何已安裝的字型。請安裝字型套件，例如在 Debian 與 Ubuntu 上安裝 `fonts-dejavu-core`，如同[使用其他基礎映像](#use-another-base-image)所示。其他可用的字型套件請參閱[部署字型](/slides/zh-hant/java/deploy-fonts/)。

**The application stops with an UnsatisfiedLinkError for libfontmanager.so. What is missing?**  
缺少 Java 字型支援的原生函式庫；錯誤訊息會列出無法載入的檔案，例如 `libharfbuzz.so.0`。這通常發生在從發行版套件安裝 Java 時未同時安裝其 **建議** 套件。請參考[使用其他基礎映像](#use-another-base-image)安裝所需的函式庫。

**Why is the text in the PDF in a different font than in PowerPoint?**  
簡報使用的字型未安裝於映像中，導致 Aspose.Slides 使用替代字型繪製文字。應用程式的輸出會列出每個被取代的字型。請參閱[部署字型](/slides/zh-hant/java/deploy-fonts/)了解如何在映像中安裝字型或從應用程式資料夾載入。

**How much memory can the application use in the container?**  
預設情況下，Java 會將堆積記憶體限制為容器可用記憶體的四分之一，例如使用 `docker run -m 1g` 時約為 250 MB。若要處理大型簡報，可透過 `MaxRAMPercentage` 參數提升比例，例如 `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`。Java 會在應用程式輸出前顯示「Picked up JAVA_TOOL_OPTIONS」訊息。

**Do I need a JDK or Maven on my machine?**  
不需要。建置階段在 Maven 映像內完成編譯。只有在您想在 Docker 之外建置或執行應用程式時才需要 JDK 與 Maven；請參閱[安裝](/slides/zh-hant/java/installation/)。