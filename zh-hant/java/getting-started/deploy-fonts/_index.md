---
title: 在 Linux 與 Docker 中部署 Aspose.Slides for Java 的字型
linktitle: 部署字型
type: docs
weight: 155
url: /zh-hant/java/deploy-fonts/
keywords:
- 部署字型
- 安裝字型
- Docker 中的字型
- Linux 上的字型
- 缺少的字型
- 字型替代
- Microsoft 核心字型
- ttf-mscorefonts-installer
- 自訂字型
- 預設字型
- 伺服器
- 容器
- PDF 轉換
- 簡報
- Java
- Aspose.Slides
description: "在 Linux 伺服器與 Docker 容器中部署 Aspose.Slides for Java 的字型：檢查哪些字型被替代、在 Debian、Ubuntu 與 Alpine 上安裝字型套件、加入自訂字型檔案，並設定預設字型。"
---
## **概觀**

Aspose.Slides 在渲染簡報時會使用可用的字型繪製文字，例如在將投影片轉換為 PDF 或影像時。Windows 桌面通常已安裝簡報使用的字型。Linux 伺服器與容器通常只提供少量字型，因而 Aspose.Slides 會改用替代字型來繪製文字。替代字型的字形與寬度不同，可能導致換行方式變化、文字超出形狀，且替代字型缺少的字元無法正確繪製。若系統根本未安裝任何字型，Java 的字型支援將無法啟動，Aspose.Slides 會因錯誤而停止。

本文說明如何檢查 Aspose.Slides 替代了哪些字型、如何在 Debian、Ubuntu 與 Alpine Linux 上安裝字型、如何加入自訂字型檔，以及如何在缺少字型時設定使用的字型。示範會在官方 Eclipse Temurin 映像的 Docker 環境中執行，參考 [Run Aspose.Slides for Java in Docker](/slides/zh-hant/java/how-to-run-aspose-slides-in-docker/)。Dockerfile 中的套件指令即為映像指令；在 Linux 伺服器上，請以 root 身份執行相同指令。

關於字型 API 本身（例如在簡報中嵌入字型、備援與取代規則），請參閱 [PowerPoint Fonts](/slides/zh-hant/java/powerpoint-fonts/)。

## **檢查哪些字型被替代**

以下 Maven 專案會報告 Aspose.Slides 在目前環境下替代的字型。建立一個名為 *font-check* 的資料夾，並將下列檔案加入其中。

*pom.xml* 為 [Run Aspose.Slides for Java in Docker](/slides/zh-hant/java/how-to-run-aspose-slides-in-docker/#create-the-project) 中的檔案，只是將 artifact ID 與 JAR 檔名改為 *font-check*：

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

*src/main/java/FontCheck.java* 會在投影片上為每個字型名稱新增一個文字方塊，並使用 [setLatinFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) 方法指定字型。字型名稱由命令列傳入；若未提供參數，程式會檢查 Calibri、Arial 與 Times New Roman。程式會列印 Aspose.Slides 搜尋字型的資料夾（[FontsLoader.getFontFolders](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#getFontFolders--)），將投影片渲染為 *output/fonts.pdf*，並列印由 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 回報的替代結果。文章開頭的兩個可選步驟（載入 *fonts* 資料夾與讀取 `DEFAULT_FONT` 變數）會在稍後說明。

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
        // 要檢查的字型：命令列參數，或三種常見的 Office 字型。
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // 從工作目錄中的 fonts 資料夾載入字型檔案（如果該資料夾存在）。
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // 若已設定 DEFAULT_FONT 環境變數，使用該字型作為缺少字型的文字的替代字型。
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

`getFontFolders` 可能會重複回傳同一資料夾，因此程式會先將資料夾收集到集合中再列印。

*.dockerignore* 用於將本機建置結果排除在建置上下文之外：

```text
target/
output/
```

*Dockerfile* 會以 Maven 映像編譯程式，並在 Eclipse Temurin Java 執行階段映像上執行，該映像已內建 fontconfig 與 DejaVu 字型。[Run Aspose.Slides for Java in Docker](/slides/zh-hant/java/how-to-run-aspose-slides-in-docker/) 會說明每個指令的用途。

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

建置映像並執行檢查：

```bash
docker build -t font-check .
docker run --rm font-check
```

映像僅包含 DejaVu 字型，因此三個字型全部被取代為 DejaVu Sans：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

若要檢查自己簡報的字型，請將字型名稱作為參數傳入，例如 `docker run --rm font-check "Segoe UI" Consolas`。若要將 *output/fonts.pdf* 從容器複製到本機，請使用 [Copy the Output to Your Machine](/slides/zh-hant/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) 中的指令。

## **在 Debian 與 Ubuntu 上安裝字型**

### **Microsoft 核心字型**

`ttf-mscorefonts-installer` 套件會下載並安裝 Microsoft 為網路提供的核心字型，包括 Arial、Times New Roman、Courier New、Verdana、Georgia 與 Trebuchet MS。這些字型受 Microsoft 最終使用者授權合約（EULA）約束，套件僅在接受 EULA 後才會安裝。Docker 建置無法回應此提示，導致安裝程式拒絕 EULA 並且未安裝任何字型，雖然 `apt-get install` 仍回報成功。必須在套件安裝前先以 `debconf-set-selections` **接受** EULA。之後的指令若再接受則無效，因為套件已經安裝，apt 不會重新執行安裝程式。

將以下指令加入 *Dockerfile* 的執行階段（runtime）段，緊接在 `FROM` 行之後，以 root 身份執行，且在 `USER` 指令之前：

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

重新建置映像並再次執行檢查，兩個指令相同。此時 Arial 與 Times New Roman 已安裝：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri 為 Aspose.Slides 建立簡報時的預設字型，並非核心字型之一，仍會被取代。請參考 [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts)。

Ubuntu 基礎的 Eclipse Temurin 映像已啟用 `multiverse`（Ubuntu 中包含此套件的元件）。Debian 則需啟用 `contrib` 元件，因為 Debian 映像預設未啟用。若在基於 Debian 的執行階段（例如 [Use Another Base Image](/slides/zh-hant/java/how-to-run-aspose-slides-in-docker/#use-another-base-image)）中使用，請在同一指令中啟用 `contrib`：

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **其他字型套件**

Debian 與 Ubuntu 也提供自由授權的字型套件，例如：

| 套件 | 字型 |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans、DejaVu Serif、DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans、Serif、Mono（與 Arial、Times New Roman、Courier New 擁有相同度量） |
| `fonts-crosextra-carlito` | Carlito（與 Calibri 擁有相同度量） |
| `fonts-crosextra-caladea` | Caladea（與 Cambria 擁有相同度量） |

在執行階段的 `RUN` 指令中使用 `apt-get install` 安裝，方式與 Microsoft 核心字型相同。Aspose.Slides for Java 不會套用 Linux 字型設定中的別名：即使安裝了 `fonts-liberation`，Arial 仍會使用一般的替代字型，而非 Liberation Sans。若要以度量相容的字型取代缺失字型，請將其設定為[預設字型](#set-a-default-font-for-missing-fonts)或新增[字型替代規則](/slides/zh-hant/java/font-substitution/)。

## **加入自訂字型檔**

未由發行版提供的字型（例如組織內部字型或已取得授權的其他字型）可直接以檔案形式加入。將字型檔（例如 *.ttf*）放入 *font-check* 資料夾內的 *fonts* 子資料夾。以下範例使用 Carlito（與 Calibri 度量相同）的字型檔，可從 [Google Fonts](https://fonts.google.com/specimen/Carlito) 下載。

### **將字型安裝至系統字型資料夾**

Aspose.Slides 會讀取 `Font folders` 行列出的資料夾。若要為映像中的所有應用程式安裝字型，請將字型檔複製至 */usr/local/share/fonts*（本地安裝字型的資料夾）。在 *Dockerfile* 的執行階段段加入以下指令，放在安裝 Microsoft 核心字型的 `RUN` 指令之後：

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

重新建置映像，然後檢查 Calibri 與 Carlito：

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito 已不再被替代：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **從應用程式資料夾載入字型**

也可以將字型隨應用程式一起封裝，並使用 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 載入。這樣字型只對 Aspose.Slides 可用，且隨應用程式一起部署。*FontCheck* 會這麼做：當容器中的工作目錄（*/app*）內有 *fonts* 資料夾時，程式會在建立簡報前先將該資料夾傳給 `loadExternalFonts`。[Custom Font](/slides/zh-hant/java/custom-font/) 也說明了其他提供字型的方式，例如從記憶體載入。

在 *Dockerfile* 中，移除 `COPY fonts/ /usr/local/share/fonts/` 指令，並在複製 *lib* 資料夾的指令之後加入以下指令：

```dockerfile
COPY fonts/ ./fonts/
```

重新建置映像並以相同兩個指令執行檢查。此時應用程式資料夾會出現在字型資料夾列表中，Carlito 仍不會被替代：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` 會把字型加入已安裝的集合，然而 Java 的字型支援仍需要至少一個已安裝的字型。若映像中完全沒有安裝字型，`loadExternalFonts` 會因「Fontconfig head is null, check your fonts or fonts configuration」錯誤而停止。

## **設定缺失字型的預設字型**

當字型缺失時，Aspose.Slides 會自行選擇替代字型。若想自行指定，請使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 的 `setDefaultRegularFont` 方法傳入字型名稱，並將該選項傳給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 建構子。*FontCheck* 會從 `DEFAULT_FONT` 環境變數讀取字型名稱。載入 Carlito 後，可將其用作缺失字型的預設字型：

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

此時 Calibri 會以 Carlito 繪製，兩者字元寬度相同，文字保持原本換行：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

預設字型會取代所有缺失的字型。若要對個別字型進行映射，例如將 Arial 映射至 Liberation Sans、將 Calibri 映射至 Carlito，請使用[字型替代規則](/slides/zh-hant/java/font-substitution/)。規則會改變渲染結果，但 `getSubstitutions` 不會顯示這些規則，因此請直接檢查輸出檔案的字型。對亞洲文字亦需呼叫 [setDefaultAsianFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-)，詳情請見[Default Font](/slides/zh-hant/java/default-font/)。

## **在 Alpine Linux 上安裝字型**

基於 Alpine 的 Eclipse Temurin 映像亦包含 DejaVu 字型；[Run on Alpine Linux](/slides/zh-hant/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) 介紹了其執行階段。若同時要在 Alpine 上安裝 Microsoft 核心字型，請將 *font-check* Dockerfile 的執行階段換成以下內容：

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

`update-ms-fonts` 會下載並安裝與 Debian、Ubuntu 套件相同的 Microsoft 核心字型，EULA 處理方式相同。`fc-cache` 會更新 fontconfig 的字型快取。建置映像並以 [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted) 中的兩個指令執行檢查，會輸出：

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

在 Alpine 上的其他步驟與前述相同：將 *fonts* 資料夾複製至 */usr/local/share/fonts* 或應用程式資料夾，並設定 `DEFAULT_FONT` 以指定預設字型。Alpine 映像預設沒有 */usr/local/share/fonts* 資料夾，只有在 `COPY` 指令建立後才會在 `Font folders` 行出現。

## **常見問題集**

**為什麼在伺服器上轉換簡報後外觀會不同？**

伺服器缺少簡報所使用的字型，導致 Aspose.Slides 使用字形寬度不同的替代字型繪製文字。執行 *FontCheck* 並傳入簡報的字型名稱，即可查看哪些字型被替代，然後安裝這些字型或從應用程式資料夾載入。

**已安裝 ttf-mscorefonts-installer，但 Arial 仍被替代，為什麼？**

在套件安裝前未接受 EULA，導致安裝程式跳過字型。請將 `debconf-set-selections` 指令置於 `apt-get install` 前，如同 [Microsoft Core Fonts](#microsoft-core-fonts) 中示範，然後重新建置映像。

**開啟 PDF 的電腦需要安裝字型嗎？**

不需要。在本範例中，PDF 已內嵌繪製時使用的字型，無論在任何電腦上顯示都會相同。字型只在 Aspose.Slides 渲染簡報的環境中需要。