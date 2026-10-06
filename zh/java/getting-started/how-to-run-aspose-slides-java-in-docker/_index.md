---
title: 在 Docker 中运行 Aspose.Slides for Java
linktitle: Docker
type: docs
weight: 150
url: /zh/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker 容器
- 多阶段构建
- 容器镜像
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- 字体
- PDF 转换
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "在 Docker 中构建并运行 Aspose.Slides for Java 应用程序：使用官方 Maven 和 Eclipse Temurin 镜像的多阶段 Dockerfile、Aspose.Slides 所需的 Linux 库和字体，以及如何将生成的文件复制到您的机器。"
---
## **概述**

本文演示如何在 Docker 容器中运行 Aspose.Slides for Java。您将构建一个小型 Maven 项目，用于创建包含文本框的演示文稿并将其转换为 PDF，使用官方 Maven 和 Eclipse Temurin 镜像上的多阶段 Dockerfile 打包，运行它，并将生成的文件复制到本机。文章还说明了 Aspose.Slides 在 Linux 镜像中除 Java 之外需要哪些组件，并以 Alpine Linux 以及从发行版包中安装 Java 的镜像为例给出变体。

只需在机器上安装 Docker 即可。JDK 和 Maven 已包含在构建镜像中，无需另行安装。有关 Docker 的安装，请参阅[获取 Docker](https://docs.docker.com/get-started/get-docker/)。

## **选择基础镜像**

本文中的 Dockerfile 使用了 Docker Hub 上的两个官方镜像：

- [maven](https://hub.docker.com/_/maven)（标签 `3.9-eclipse-temurin-21`）用于构建应用程序。它包含 Apache Maven 3.9 和 Eclipse Temurin JDK 21。
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin)（标签 `21-jre`）用于运行应用程序。它在 Ubuntu 上提供 Eclipse Temurin Java 21 运行时，不包含 JDK 和 Maven。

Aspose.Slides for Java 使用 Java 的字体支持绘制文本，在 Linux 上需要 fontconfig、FreeType 库以及至少一种已安装的字体。Eclipse Temurin 镜像已经包含 fontconfig、FreeType 和 DejaVu 字体，因此本文的 Dockerfile 不安装任何额外的软件包。如果镜像中没有任何字体，保存演示文稿时会报错 “Fontconfig head is null, check your fonts or fonts configuration”。如果您使用其他基础镜像，请参阅[使用其他基础镜像](#use-another-base-image)。

## **创建项目**

创建名为 *hello-slides-docker* 的文件夹并向其中添加以下文件。

*pom.xml* 声明了 Aspose 的 Maven 仓库以及 Aspose.Slides for Java 的依赖，如[安装](/slides/zh/java/installation/)中所述；Aspose.Slides for Java 未发布到 Maven Central，必须添加仓库条目。`finalName` 元素将应用程序的 JAR 文件命名为 *hello-slides.jar*，而 [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) 在 Maven 打包时会把应用的依赖复制到 *target/lib*。请将 Aspose.Slides 版本设为[仓库](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)中列出的最新版本。

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

*src/main/java/HelloSlides.java* 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)，在其第一张幻灯片上添加一个带文本的矩形，并使用 [save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法分别以 PPTX 和 PDF 格式保存演示文稿。两个文件均写入工作目录下的 *output* 文件夹。随后程序会列出 Aspose.Slides 在渲染演示文稿时替换的字体，使用 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)，以便您查看容器中是否已安装演示文稿使用的字体。

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

*.dockerignore* 将本地构建产生的 *target* 文件夹以及此前运行的输出排除在 Docker 构建上下文之外，从而仅使用源文件构建镜像。

```text
target/
output/
```

## **编写 Dockerfile**

在 *hello-slides-docker* 文件夹中添加名为 *Dockerfile* 的文件：

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

该文件包含两个阶段：

- **构建阶段** 以 Maven 镜像为基础。首先复制 *pom.xml* 并运行 `mvn dependency:go-offline`，该命令会下载 Aspose.Slides for Java 及 Maven 插件，只要 *pom.xml* 未更改，Docker 就会复用该层。随后复制源代码并运行 `mvn package`，将程序编译为 *target/hello-slides.jar*，并将 Aspose.Slides JAR 文件复制到 *target/lib*。`-B` 选项让 Maven 以非交互（批处理）模式运行。
- **运行阶段** 以更小的 Java 运行时镜像为基础，仅复制应用的 JAR 文件和 *lib* 文件夹。它会创建 *output* 文件夹并交给 `ubuntu`（Ubuntu 基础镜像中定义的非 root 用户），随后以该用户身份运行应用程序。类路径 `hello-slides.jar:lib/*` 包含应用本身以及 *lib* 中的所有 JAR 文件；Java 会自行展开 `*`。

项目使用 Java 11 编译（`maven.compiler.release` 属性），因此运行阶段可以使用更新的 Java 版本。例如，要在 Java 25 上运行应用，只需将运行阶段的镜像改为 `eclipse-temurin:25-jre`。

## **构建并运行容器**

在 *hello-slides-docker* 文件夹中打开终端。先构建镜像，再基于该镜像运行容器：

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

首次构建会下载基础镜像、Maven 插件以及 Aspose.Slides for Java，耗时数分钟；后续构建会复用这些层。容器运行应用后退出，并打印如下内容：

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

首行显示文本使用了 Calibri（新演示文稿的默认字体），但镜像中未安装 Calibri，因而 Aspose.Slides 使用 DejaVu Sans 绘制文本。PDF 中的文本是真正的、可选中的文字，使用的是该字体。未授权情况下，Aspose.Slides 还会在每张保存的幻灯片上添加评估水印，详见[授权](/slides/zh/java/licensing/)。

## **将输出复制到本机**

这些文件位于已停止容器的 */app/output* 文件夹中。将它们复制到本机的 *output* 文件夹后，删除容器：

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

上述两条命令在 Bash、PowerShell 和 Windows 命令提示符下的用法相同。

在 Linux 上，您也可以将本机文件夹挂载到容器中，让应用直接写入该文件夹：

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` 选项使用您的用户 ID 和组 ID 运行应用，从而能够写入您创建的文件夹，且生成的文件归您所有。`--rm` 选项在容器停止后自动删除容器。

## **在 Alpine Linux 上运行**

Eclipse Temurin 也提供基于 Alpine Linux 的镜像，体积更小。它同样包含 fontconfig、FreeType 和 DejaVu 字体，因此应用无需额外的软件包。要使用该镜像，只需将 *Dockerfile* 中的运行阶段（从第二个 `FROM` 行开始的所有内容）替换为：

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine 镜像没有 `ubuntu` 用户，因此该阶段使用 `adduser` 创建名为 `app` 的用户并以其身份运行应用。使用上述相同的构建、运行和复制命令即可，输出仍为两行相同内容。

## **使用其他基础镜像**

如果您的镜像通过 Linux 发行版的包管理器安装 Java，则需要同时安装 Java 的字体库和至少一种字体。以 Debian 和 Ubuntu 为例，`openjdk-21-jre-headless` 包仅将 fontconfig、FreeType 和 HarfBuzz 标记为推荐项，使用 `apt-get install --no-install-recommends` 会省略它们，导致应用因缺少 `libfontmanager.so` 而抛出 `UnsatisfiedLinkError`。以下运行阶段在 Debian 13 上安装 Java 21、所需库以及 DejaVu 字体，并创建名为 `app` 的非 root 用户：

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

相同的阶段也可用于 `FROM ubuntu:26.04`。

## **常见问题解答**

**保存演示文稿时出现 “Fontconfig head is null, check your fonts or fonts configuration”。缺少什么？**

缺少字体。Java 的字体支持在镜像中未发现已安装的字体。请安装字体包，例如在 Debian 和 Ubuntu 上安装 `fonts-dejavu-core`，参考[使用其他基础镜像](#use-another-base-image)。[部署字体](/slides/zh/java/deploy-fonts/) 列出了其他可用的字体包。

**应用因 `UnsatisfiedLinkError` 而在 libfontmanager.so 上停止。缺少什么？**

缺少 Java 字体支持的本地库；错误信息会指明未能加载的文件，例如 `libharfbuzz.so.0`。这通常发生在从发行版包安装 Java 时未带上其推荐的库。请安装[使用其他基础镜像](#use-another-base-image) 中列出的相应库。

**为什么 PDF 中的文字字体与 PowerPoint 中不同？**

演示文稿使用的字体未在镜像中安装，导致 Aspose.Slides 使用替代字体绘制文本。应用的输出会列出每个被替换的字体。请参阅[部署字体](/slides/zh/java/deploy-fonts/) 了解如何在镜像中安装字体或从应用文件夹加载字体。

**容器中应用最多可以使用多少内存？**

默认情况下，Java 将堆大小限制为容器可用内存的四分之一，例如使用 `docker run -m 1g` 启动容器时堆约为 250 MB。要处理大型演示文稿，可以通过 `MaxRAMPercentage` 选项提升比例，例如 `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`。Java 会在应用输出前打印 “Picked up JAVA_TOOL_OPTIONS” 行。

**我是否需要在本机上安装 JDK 或 Maven？**

不需要。构建阶段在 Maven 镜像内部完成编译。只有在您希望在 Docker 之外构建和运行应用时才需要 JDK 和 Maven，详情请参阅[安装](/slides/zh/java/installation/)。