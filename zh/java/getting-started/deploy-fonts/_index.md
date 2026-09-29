---
title: 在 Linux 和 Docker 中为 Aspose.Slides for Java 部署字体
linktitle: 部署字体
type: docs
weight: 155
url: /zh/java/deploy-fonts/
keywords:
- 部署字体
- 安装字体
- Docker 中的字体
- Linux 上的字体
- 缺失字体
- 字体替代
- Microsoft 核心字体
- ttf-mscorefonts-installer
- 自定义字体
- 默认字体
- 服务器
- 容器
- PDF 转换
- 演示文稿
- Java
- Aspose.Slides
description: "在 Linux 服务器和 Docker 容器中为 Aspose.Slides for Java 部署字体：检查哪些字体被替代，在 Debian、Ubuntu 和 Alpine 上安装字体包，添加自己的字体文件，并设置默认字体。"
---
## **概览**

Aspose.Slides 在渲染演示文稿时会使用系统中可用的字体来绘制文字，例如在将幻灯片转换为 PDF 或图像时。Windows 桌面系统通常已安装演示文稿使用的字体。Linux 服务器和容器的字体较少，Aspose.Slides 会使用替代字体来绘制文字。替代字体的字形和宽度不同，导致换行方式变化、文字可能溢出形状，并且替代字体缺失的字符无法正确绘制。如果根本没有安装任何字体，Java 的字体支持无法启动，Aspose.Slides 会报错并停止。

本文展示了如何检查 Aspose.Slides 替代了哪些字体、如何在 Debian、Ubuntu 和 Alpine Linux 上安装字体、如何添加自己的字体文件，以及如何在缺少字体时设置使用的字体。示例在官方 Eclipse Temurin 镜像的 Docker 中运行，参见 [Run Aspose.Slides for Java in Docker](/slides/zh/java/how-to-run-aspose-slides-in-docker/)。包装命令是 Dockerfile 指令；在 Linux 服务器上以 root 身份运行相同的命令即可。

关于字体 API 本身（例如在演示文稿中嵌入字体以及回退和替换规则），请参阅 [PowerPoint Fonts](/slides/zh/java/powerpoint-fonts/)。

## **检查哪些字体被替代**

下面的 Maven 项目会报告 Aspose.Slides 在当前环境中替代的字体。创建一个名为 *font-check* 的文件夹并将以下文件添加进去。

*pom.xml* 与 [Run Aspose.Slides for Java in Docker](/slides/zh/java/how-to-run-aspose-slides-in-docker/#create-the-project) 中的相同，只是将 artifact ID 和 JAR 文件名改为 *font-check*：

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

*src/main/java/FontCheck.java* 为每个字体名称在幻灯片上添加一个文本框，并使用 [setLatinFont](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) 方法指定字体。字体名称来自命令行；如果没有参数，程序会检查 Calibri、Arial 和 Times New Roman。它会打印 Aspose.Slides 查找字体的文件夹（[FontsLoader.getFontFolders](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#getFontFolders--)），将幻灯片渲染为 *output/fonts.pdf*，并打印 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) 报告的替代信息。文章后面会解释开头的两个可选步骤：加载 *fonts* 文件夹和读取 `DEFAULT_FONT` 变量。

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
        // 要检查的字体：命令行参数，或三种常见的 Office 字体。
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // 如果存在，在工作目录的 fonts 文件夹中加载字体文件。
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // 如果已设置 DEFAULT_FONT 环境变量，则使用其中指定的字体来处理缺失字体的文本。
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

`getFontFolders` 可能会多次返回同一个文件夹，因此程序在打印之前先将文件夹收集到集合中。

*.dockerignore* 用于将本地构建结果排除在构建上下文之外：

```text
target/
output/
```

*Dockerfile* 使用 Maven 镜像构建程序，并在已经包含 fontconfig 和 DejaVu 字体的 Eclipse Temurin Java 运行时镜像上运行。[Run Aspose.Slides for Java in Docker](/slides/zh/java/how-to-run-aspose-slides-in-docker/) 逐条解释了每个指令。

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

构建镜像并运行检查：

```bash
docker build -t font-check .
docker run --rm font-check
```

该镜像仅包含 DejaVu 字体，因此所有三种字体均被替换为 DejaVu Sans：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

要检查自己演示文稿的字体，只需将它们的名称作为参数传入，例如 `docker run --rm font-check "Segoe UI" Consolas`。若要将 *output/fonts.pdf* 从容器复制出来，请使用 [Copy the Output to Your Machine](/slides/zh/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) 中的命令。

## **在 Debian 和 Ubuntu 上安装字体**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer` 包会下载并安装 Microsoft 的 Web 核心字体，其中包括 Arial、Times New Roman、Courier New、Verdana、Georgia 和 Trebuchet MS。这些字体受 Microsoft 最终用户许可协议（EULA）约束，只有在接受 EULA 后才会安装。Docker 构建无法响应提示，因此安装程序会拒绝 EULA 并不安装任何字体，尽管 `apt-get install` 仍然显示成功。必须在安装包之前使用 `debconf-set-selections` **先**接受 EULA。后续指令中再接受是无效的，因为此时包已经安装，apt 不会再次运行安装程序。

在 *Dockerfile* 的运行阶段（runtime stage）中，在其 `FROM` 行之后立即添加以下指令，使其以 root 身份在 `USER` 指令之前执行：

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

重新构建镜像并使用相同的两条命令再次运行检查。Arial 和 Times New Roman 现在已安装：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri 是 Aspose.Slides 创建演示文稿时的默认字体，并不属于核心字体，因此仍被替代。请参阅 [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts)。

基于 Ubuntu 的 Eclipse Temurin 镜像已启用 `multiverse` 组件，包含该包。Debian 中该包位于 `contrib` 组件，而 Debian 镜像默认未启用。在基于 Debian 的运行阶段（例如 [Use Another Base Image](/slides/zh/java/how-to-run-aspose-slides-in-docker/#use-another-base-image) 中的阶段），在同一指令中启用 `contrib`：

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **其他字体包**

Debian 和 Ubuntu 还提供了自由授权的字体包，例如：

| 包 | 字体 |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans、DejaVu Serif、DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans、Serif、Mono，度量与 Arial、Times New Roman、Courier New 相同 |
| `fonts-crosextra-carlito` | Carlito，度量与 Calibri 相同 |
| `fonts-crosextra-caladea` | Caladea，度量与 Cambria 相同 |

在运行阶段的 `RUN` 指令中使用 `apt-get install` 安装它们，方法与安装 Microsoft 核心字体相同。Aspose.Slides for Java 并不使用 Linux 字体配置的别名：即便安装了 `fonts-liberation`，Arial 仍会使用通用替代字体而非 Liberation Sans。若要使用度量兼容的字体替代缺失字体，请将其设为[默认字体](#set-a-default-font-for-missing-fonts)或添加[字体替代规则](/slides/zh/java/font-substitution/)。

## **添加自己的字体文件**

发行版未打包的字体（例如组织内部的字体或您已获授权在服务器上使用的其他字体）可以作为字体文件添加。将字体文件（如 *.ttf*）放入 *font-check* 文件夹内的 *fonts* 子文件夹中。下面的示例使用 Carlito 字体文件，它的度量与 Calibri 相同，您可以从 [Google Fonts](https://fonts.google.com/specimen/Carlito) 下载。

### **将字体安装到系统字体文件夹**

Aspose.Slides 会读取 `Font folders` 行中列出的文件夹中的字体。若要为镜像中的所有应用程序安装字体，请将它们复制到 */usr/local/share/fonts*（本地安装字体的文件夹）。在 *Dockerfile* 的运行阶段，在安装 Microsoft 核心字体的 `RUN` 指令之后添加以下指令：

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

重新构建镜像后，检查 Calibri 与 Carlito：

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito 不再被替代：

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **从应用程序文件夹加载字体**

也可以不将字体安装到系统文件夹，而是随应用程序一起分发并使用 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 加载。这样字体仅对 Aspose.Slides 可用，并随应用程序一起部署。*FontCheck* 正是这么做的：当容器中的工作目录 */app* 包含 *fonts* 文件夹时，程序会在创建演示文稿之前将该文件夹传递给 `loadExternalFonts`。[Custom Font](/slides/zh/java/custom-font/) 还介绍了从内存加载等其它供给字体的方式。

在 *Dockerfile* 中，删除 `COPY fonts/ /usr/local/share/fonts/` 指令，并在复制 *lib* 文件夹的指令之后添加以下指令：

```dockerfile
COPY fonts/ ./fonts/
```

重新构建镜像并使用相同的两条命令运行检查。应用程序文件夹现在出现在字体文件夹列表中，Carlito 仍未被替代：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` 会将字体添加到已安装的字体中，但 Java 的字体支持仍需要至少一个已安装的字体。如果镜像中没有任何已安装的字体，`loadExternalFonts` 会因 “Fontconfig head is null, check your fonts or fonts configuration” 错误而停止。

## **为缺失的字体设置默认字体**

当字体缺失时，Aspose.Slides 会自行选择替代字体。若想自行指定，可将字体名称传递给 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) 方法的 `LoadOptions`，并将该选项对象传递给 `Presentation` 构造函数。*FontCheck* 会从 `DEFAULT_FONT` 环境变量读取字体名称。加载了 Carlito 后，可将其用作缺失字体的默认字体：

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

现在 Calibri 将使用 Carlito 绘制，字符宽度与 Calibri 相同，文本保持原有换行：

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

默认字体会替代所有缺失的字体。若需要对单个字体进行映射，例如将 Arial 映射为 Liberation Sans、Calibri 映射为 Carlito，请使用[字体替代规则](/slides/zh/java/font-substitution/)。规则会改变渲染输出，但 `getSubstitutions` 不会反映这些规则，因此请检查输出文件中的实际字体。对于亚洲文字，还需调用 [setDefaultAsianFont](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-)，参见 [Default Font](/slides/zh/java/default-font/)。

## **在 Alpine Linux 上安装字体**

基于 Alpine 的 Eclipse Temurin 镜像同样包含 DejaVu 字体；[Run on Alpine Linux](/slides/zh/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) 介绍了其运行阶段。若要在该镜像上同样安装 Microsoft 核心字体，请将 *font-check* Dockerfile 的运行阶段替换为如下内容：

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

`update-ms-fonts` 下载并安装与 Debian、Ubuntu 包相同的 Microsoft 核心字体，EULA 的处理方式相同。`fc-cache` 刷新 fontconfig 的字体缓存。构建镜像并使用 [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted) 中的两条命令运行检查，会输出：

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

本文其余步骤在 Alpine 上的操作方式相同：将 *fonts* 文件夹复制到 */usr/local/share/fonts* 或应用程序文件夹，并设置 `DEFAULT_FONT` 以选择默认字体。Alpine 镜像默认没有 */usr/local/share/fonts* 文件夹，只有在执行 `COPY` 指令创建该文件夹后，它才会出现在 `Font folders` 行中。

## **FAQ**

**为什么在服务器上转换后演示文稿的外观会不同？**

服务器缺少演示文稿使用的字体，导致 Aspose.Slides 使用字形宽度不同的替代字体绘制文字。运行 *FontCheck* 并传入演示文稿使用的字体名称即可查看哪些字体被替代，然后安装这些字体或从应用程序文件夹加载它们。

**构建时已安装 ttf-mscorefonts-installer，但 Arial 仍被替代，为什么？**

因为在安装包之前未接受 EULA，安装程序跳过了字体。请在安装该包的指令中，将 `debconf-set-selections` 命令放在 `apt-get install` 之前，如 [Microsoft Core Fonts](#microsoft-core-fonts) 中所示，然后重新构建镜像。

**打开 PDF 的电脑需要这些字体吗？**

不需要。在本示例中，PDF 已经嵌入了用于绘制文字的字体，因而在任何电脑上显示效果相同。字体只在 Aspose.Slides 渲染演示文稿的机器上需要。