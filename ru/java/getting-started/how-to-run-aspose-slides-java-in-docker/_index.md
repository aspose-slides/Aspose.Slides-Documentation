---
title: "Запуск Aspose.Slides for Java в Docker"
linktitle: "Docker"
type: docs
weight: 150
url: /ru/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- "Docker контейнер"
- "многоступенчатая сборка"
- "образ контейнера"
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- шрифты
- "конвертация PDF"
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создайте и запустите приложение Aspose.Slides for Java в Docker: многоступенчатый Dockerfile на официальных образах Maven и Eclipse Temurin, библиотеки Linux и шрифты, необходимые Aspose.Slides, и как скопировать сгенерированные файлы на ваш компьютер."
---
## **Обзор**

В этой статье показано, как запустить Aspose.Slides for Java в контейнере Docker. Вы создаёте небольшой проект Maven, который создаёт презентацию с текстовым полем и конвертирует её в PDF, упаковываете его с помощью многоступенчатого Dockerfile на официальных образах Maven и Eclipse Temurin, запускаете контейнер и копируете сгенерированные файлы на свою машину. В статье также объясняется, что ещё нужно Aspose.Slides в образе Linux помимо Java, и приводятся варианты для Alpine Linux и для образов, в которых Java устанавливается из пакетов дистрибутива.

Вам нужен только Docker на вашем компьютере. JDK и Maven входят в образ сборки, поэтому их не нужно устанавливать. Чтобы установить Docker, смотрите [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Выбор базовых образов**

Dockerfile в этой статье использует два официальных образа из Docker Hub:

- [maven](https://hub.docker.com/_/maven) с тегом `3.9-eclipse-temurin-21` собирает приложение. Он содержит Apache Maven 3.9 и JDK Eclipse Temurin 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) с тегом `21-jre` запускает его. Он содержит runtime Java 21 от Eclipse Temurin на Ubuntu, без JDK и Maven.

Aspose.Slides for Java выводит текст с помощью поддержки шрифтов Java, которая в Linux требует библиотек fontconfig и FreeType и как минимум один установленный шрифт. Образы Eclipse Temurin уже включают fontconfig, FreeType и шрифты DejaVu, поэтому Dockerfile в этой статье не устанавливает дополнительных пакетов. В образе без шрифтов сохранение презентации завершается ошибкой «Fontconfig head is null, check your fonts or fonts configuration». Если вы собираете образ на другой базе, смотрите [Use Another Base Image](#use-another-base-image).

## **Создание проекта**

Создайте папку с именем *hello-slides-docker* и добавьте в неё следующие файлы.

*`pom.xml`* объявляет репозиторий Maven Aspose и зависимость Aspose.Slides for Java, как описано в [Installation](/slides/ru/java/installation/); Aspose.Slides for Java не публикуется в Maven Central, поэтому запись репозитория обязателна. Элемент `finalName` задаёт имя JAR‑файла приложения *hello-slides.jar*, а [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) копирует зависимости приложения в *target/lib* при упаковке Maven. Установите версию Aspose.Slides на последнюю, указанную в [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

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

*`src/main/java/HelloSlides.java`* создаёт [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), добавляет прямоугольник с текстом на первый слайд и сохраняет презентацию дважды с помощью метода [save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-): как PPTX и как PDF. Оба файла помещаются в папку *output* в текущем рабочем каталоге. Затем программа выводит список шрифтов, которые Aspose.Slides заменяет при рендеринге, используя [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), чтобы вы могли увидеть, есть ли в контейнере шрифты, используемые в презентации.

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

*`.dockerignore`* исключает папку *target* локальной сборки и результаты предыдущих запусков из контекста сборки Docker, поэтому образ собирается только из файлов исходного кода.

```text
target/
output/
```

## **Написание Dockerfile**

Добавьте файл с именем *Dockerfile* в папку *hello-slides-docker*:

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

Файл состоит из двух этапов:

- **Этап сборки** начинается с образа Maven. Сначала копируется *pom.xml* и выполняется `mvn dependency:go-offline`, который загружает Aspose.Slides for Java и плагины Maven, поэтому Docker переиспользует этот слой, пока *pom.xml* не изменится. Затем копируются исходные файлы и запускается `mvn package`, который компилирует программу в *target/hello-slides.jar* и копирует JAR‑файл Aspose.Slides в *target/lib*. Параметр `-B` запускает Maven в неблокирующем (batch) режиме.
- **Этап выполнения** начинается с более лёгкого образа Java runtime и копирует только JAR‑файл приложения и папку *lib*. Создаётся папка *output*, передаётся пользователю `ubuntu` (не‑root пользователю, определённому в образе на базе Ubuntu) и приложение запускается от имени этого пользователя. Класс‑путь `hello-slides.jar:lib/*` содержит приложение и каждый JAR‑файл в *lib*; символ `*` разворачивается самим Java.

Проект компилируется для Java 11 (свойство `maven.compiler.release`), поэтому этап выполнения может использовать более новую версию Java. Например, чтобы запустить приложение на Java 25, измените образ этапа выполнения на `eclipse-temurin:25-jre`.

## **Сборка и запуск контейнера**

Откройте терминал в папке *hello-slides-docker*. Сборте образ, затем запустите из него контейнер:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Первый запуск скачивает базовые образы, плагины Maven и Aspose.Slides for Java, поэтому он занимает несколько минут; последующие сборки используют уже загруженные данные. Контейнер запускает приложение и завершается. Он выводит:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Первая строка показывает, что текст использует шрифт Calibri — шрифт по умолчанию в новой презентации, — и что Calibri не установлен в образе, поэтому Aspose.Slides отрисовал текст шрифтом DejaVu Sans. Текст в PDF является реальным, выделяемым текстом в этом шрифте. Без лицензии Aspose.Slides также добавляет водяной знак оценки к каждому сохранённому слайду; см. [Licensing](/slides/ru/java/licensing/).

## **Копирование вывода на вашу машину**

Файлы находятся в папке */app/output* остановленного контейнера. Скопируйте их в папку *output* на своей машине, затем удалите контейнер:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Эти две команды работают одинаково в Bash, PowerShell и Windows Command Prompt.

В Linux вы также можете смонтировать папку вашей машины в контейнер, чтобы приложение записывало файлы туда напрямую:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Опция `--user` запускает приложение с вашими UID и GID, поэтому он может записывать в созданную папку, а файлы будут принадлежать вам. `--rm` удаляет контейнер после его завершения.

## **Запуск на Alpine Linux**

Eclipse Temurin тоже доступен как образ на базе Alpine Linux, который меньше по размеру. В нём также присутствуют fontconfig, FreeType и шрифты DejaVu, поэтому приложению не нужны дополнительные пакеты. Чтобы использовать его, замените этап выполнения в *Dockerfile* (всё начиная со второй строки `FROM`) на:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

В образе Alpine нет пользователя `ubuntu`, поэтому этот этап создаёт пользователя `app` с помощью `adduser` и запускает приложение от его имени. Сборка, запуск и копирование вывода выполняются теми же командами, что выше. Приложение выводит те же две строки.

## **Использование другого базового образа**

Если ваш образ устанавливает Java из пакетов дистрибутива, установите библиотеки шрифтов Java и хотя бы один шрифт. В Debian и Ubuntu пакет `openjdk-21-jre-headless` перечисляет fontconfig, FreeType и HarfBuzz только как рекомендованные, поэтому `apt-get install --no-install-recommends` оставит их вне установки, и приложение завершится с `UnsatisfiedLinkError` для `libfontmanager.so`. Этот этап выполнения устанавливает Java 21, необходимые библиотеки и шрифты DejaVu в Debian 13 и создаёт не‑root пользователя `app`:

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

Тот же этап работает в Ubuntu 26.04 с `FROM ubuntu:26.04`.

## **FAQ**

**Сохранение презентации останавливается с ошибкой «Fontconfig head is null, check your fonts or fonts configuration». Что отсутствует?**

Шрифт. Поддержка шрифтов Java не нашла установленного шрифта в образе. Установите пакет шрифтов, например `fonts-dejavu-core` в Debian и Ubuntu, как показано в [Use Another Base Image](#use-another-base-image). В разделе [Deploy Fonts](/slides/ru/java/deploy-fonts/) перечислены другие пакеты шрифтов.

**Приложение завершается с UnsatisfiedLinkError для libfontmanager.so. Что отсутствует?**

Нативная библиотека поддержки шрифтов Java; сообщение указывает файл, который не удалось загрузить, например `libharfbuzz.so.0`. Это происходит, когда Java установлена из пакетов дистрибутива без их рекомендованных зависимостей. Установите библиотеки, перечисленные в [Use Another Base Image](#use-another-base-image).

**Почему текст в PDF отображается другим шрифтом, чем в PowerPoint?**

Шрифты, используемые в презентации, не установлены в образе, поэтому Aspose.Slides заменяет их заменяющим шрифтом. Вывод приложения перечисляет каждый заменённый шрифт. В разделе [Deploy Fonts](/slides/ru/java/deploy-fonts/) объясняется, как установить шрифты в образе или загрузить их из папки приложения.

**Сколько памяти может использовать приложение в контейнере?**

По умолчанию Java ограничивает кучу четвертью памяти, доступной контейнеру, например около 250 МБ при запуске `docker run -m 1g`. Чтобы обрабатывать большие презентации, увеличьте долю параметром `MaxRAMPercentage`, например `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java тогда напечатает строку «Picked up JAVA_TOOL_OPTIONS» перед выводом приложения.

**Нужен ли мне JDK или Maven на машине?**

Нет. Этап сборки компилирует приложение внутри образа Maven. JDK и Maven нужны только если вы хотите собирать и запускать приложение вне Docker; см. [Installation](/slides/ru/java/installation/).