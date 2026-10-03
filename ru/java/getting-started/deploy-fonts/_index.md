---
title: Развёртывание шрифтов для Aspose.Slides for Java в Linux и Docker
linktitle: Развёртывание шрифтов
type: docs
weight: 155
url: /ru/java/deploy-fonts/
keywords:
- развёртывание шрифтов
- установка шрифтов
- шрифты в Docker
- шрифты в Linux
- отсутствующие шрифты
- замена шрифтов
- основные шрифты Microsoft
- ttf-mscorefonts-installer
- пользовательские шрифты
- шрифт по умолчанию
- сервер
- контейнер
- конвертация PDF
- презентация
- Java
- Aspose.Slides
description: "Развёртывание шрифтов для Aspose.Slides for Java на Linux серверах и в Docker контейнерах: проверить, какие шрифты заменяются, установить пакеты шрифтов в Debian, Ubuntu и Alpine, добавить свои файлы шрифтов и задать шрифт по умолчанию."
---
## **Обзор**

Aspose.Slides рисует текст шрифтами, доступными ему при рендеринге презентации, например при конвертации слайдов в PDF или изображения. На настольном компьютере под Windows обычно есть шрифты, используемые в презентациях. На Linux‑серверах и в контейнерах обычно мало шрифтов, поэтому Aspose.Slides рисует текст заменяющим шрифтом. Заменяющий шрифт имеет другую форму букв и ширину, поэтому строки могут переноситься иначе, текст может выходить за пределы формы, а символы, отсутствующие в заменяющем шрифте, отрисовываются некорректно. Если шрифтов вообще не установлено, поддержка шрифтов Java не может запуститься, и Aspose.Slides завершается с ошибкой.

Эта статья показывает, как проверить, какие шрифты заменяет Aspose.Slides, как установить шрифты в Debian, Ubuntu и Alpine Linux, как добавить свои файлы шрифтов и как задать шрифт, используемый при отсутствии оригинального шрифта. Примеры запускаются в Docker на официальных образах Eclipse Temurin, как в [Run Aspose.Slides for Java in Docker](/slides/ru/java/how-to-run-aspose-slides-in-docker/). Команды пакета являются инструкциями Dockerfile; на Linux‑сервере выполните те же команды от имени root.

Для самого API шрифтов, такого как встраивание шрифтов в презентацию и правила резервирования и замены, см. [PowerPoint Fonts](/slides/ru/java/powerpoint-fonts/).

## **Проверка заменяемых шрифтов**

Следующий Maven‑проект выводит шрифты, которые Aspose.Slides заменяет в текущей среде. Создайте папку с именем *font-check* и добавьте в неё файлы, перечисленные ниже.

*pom.xml* — это тот же файл, что использовался в [Run Aspose.Slides for Java in Docker](/slides/ru/java/how-to-run-aspose-slides-in-docker/#create-the-project), но с изменённым идентификатором артефакта и именем JAR‑файла на *font-check*:

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

*src/main/java/FontCheck.java* добавляет по одному текстовому полю на слайд для каждого имени шрифта и задаёт шрифт с помощью метода [setLatinFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Имена шрифтов берутся из командной строки; без аргументов программа проверяет Calibri, Arial и Times New Roman. Она выводит папки, в которых Aspose.Slides ищет шрифты ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#getFontFolders--)), рендерит слайд в *output/fonts.pdf* и выводит замену, полученную от [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Два необязательных шага в начале — загрузка папки *fonts* и чтение переменной `DEFAULT_FONT` — объяснены далее в этой статье.

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
        // Шрифты для проверки: аргументы командной строки или три распространённые шрифта Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Загрузить файлы шрифтов из папки fonts в рабочем каталоге, если она существует.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Использовать шрифт, указанный в переменной окружения DEFAULT_FONT, если она задана, для текста, у которого шрифт отсутствует.
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

`getFontFolders` может возвращать одну и ту же папку несколько раз, поэтому программа собирает папки в набор перед выводом.

*.dockerignore* удерживает локальные результаты сборки вне контекста сборки:

```text
target/
output/
```

*Dockerfile* собирает программу с использованием образа Maven и запускает её на образе Eclipse Temurin Java runtime, который уже содержит fontconfig и шрифты DejaVu. [Run Aspose.Slides for Java in Docker](/slides/ru/java/how-to-run-aspose-slides-in-docker/) объясняет каждую инструкцию.

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

Соберите образ и запустите проверку:

```bash
docker build -t font-check .
docker run --rm font-check
```

В образе присутствуют только шрифты DejaVu, поэтому все три шрифта заменяются на DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Чтобы проверить шрифты ваших собственных презентаций, передайте их имена в качестве аргументов, например `docker run --rm font-check "Segoe UI" Consolas`. Чтобы скопировать *output/fonts.pdf* из контейнера, используйте команды из раздела [Copy the Output to Your Machine](/slides/ru/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Установка шрифтов в Debian и Ubuntu**

### **Microsoft Core Fonts**

Пакет `ttf-mscorefonts-installer` загружает и устанавливает основные веб‑шрифты Microsoft, среди которых Arial, Times New Roman, Courier New, Verdana, Georgia и Trebuchet MS. Шрифты лицензированы по лицензии конечного пользователя Microsoft (EULA), и пакет устанавливает их только после принятия EULA. При сборке в Docker невозможно ответить на запрос, поэтому установщик отклоняет EULA и не устанавливает шрифты, хотя `apt-get install` всё равно сообщает об успехе. Примите EULA с помощью `debconf-set-selections` **до** установки пакета. Принятие её в более поздней инструкции не помогает: пакет уже установлен, и apt не запускает установщик повторно.

Добавьте эту инструкцию в этап выполнения *Dockerfile* непосредственно после строки `FROM`, чтобы она выполнялась от имени root, перед инструкцией `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Соберите образ и снова запустите проверку теми же двумя командами. Arial и Times New Roman теперь установлены:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, шрифт по умолчанию в презентации, создаваемой Aspose.Slides, не относится к основным шрифтам, поэтому он всё ещё заменяется. См. [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Образы Eclipse Temurin, основанные на Ubuntu, включают `multiverse` — компонент Ubuntu, содержащий данный пакет. В Debian пакет находится в компоненте `contrib`, который не включён в образах Debian. В этапе выполнения на базе Debian, например в том, что используется в [Use Another Base Image](/slides/ru/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), включите `contrib` в той же инструкции:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Другие пакеты шрифтов**

Debian и Ubuntu также предоставляют свободно лицензированные шрифты, например:

| Package | Fonts |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif и Mono, с теми же метриками, что у Arial, Times New Roman и Courier New |
| `fonts-crosextra-carlito` | Carlito, с теми же метриками, что у Calibri |
| `fonts-crosextra-caladea` | Caladea, с теми же метриками, что у Cambria |

Установите их с помощью `apt-get install` в инструкции `RUN` этапа выполнения, так же, как и основные шрифты Microsoft. Aspose.Slides for Java не применяет псевдонимы шрифтов из конфигурации Linux: даже после установки `fonts-liberation` текст в Arial по‑прежнему рисуется заменяющим шрифтом, а не Liberation Sans. Чтобы использовать шрифт с совместимыми метриками вместо отсутствующего, задайте его как [default font](#set-a-default-font-for-missing-fonts) или добавьте [font substitution rule](/slides/ru/java/font-substitution/).

## **Добавление собственных файлов шрифтов**

Шрифты, которые не включены в дистрибутивы, такие как шрифты вашей организации или другие шрифты, на использование которых у вас есть лицензия на сервере, можно добавить в виде файлов шрифтов. Поместите файлы шрифтов, например файлы *.ttf*, в папку *fonts* внутри папки *font-check*. Ниже приведённые примеры используют файлы Carlito — шрифт с теми же метриками, что и Calibri, который можно скачать с [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Установка шрифтов в системную папку шрифтов**

Aspose.Slides читает шрифты из папок, указанных в строке `Font folders`. Чтобы установить ваши шрифты для всех приложений в образе, скопируйте их в */usr/local/share/fonts* — папку локально установленных шрифтов. Добавьте эту инструкцию в этап выполнения *Dockerfile* после инструкции `RUN`, которая устанавливает основные шрифты Microsoft:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Пересоберите образ, затем проверьте Calibri и Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito больше не заменяется:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Загрузка шрифтов из папки приложения**

Вместо установки шрифтов в системную папку, вы можете поставлять их вместе с приложением и загружать с помощью [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Тогда шрифты доступны только Aspose.Slides и развёртываются вместе с приложением. *FontCheck* делает именно это: когда его рабочий каталог, */app* в контейнере, содержит папку *fonts*, программа передаёт эту папку в `loadExternalFonts` до создания презентации. [Custom Font](/slides/ru/java/custom-font/) описывает другие способы предоставления шрифтов, например загрузку из памяти.

В *Dockerfile* удалите инструкцию `COPY fonts/ /usr/local/share/fonts/` и добавьте эту после инструкции, копирующей папку *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Пересоберите образ и запустите проверку теми же двумя командами. Папка приложения теперь появляется среди папок шрифтов, и Carlito по‑прежнему не заменяется:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` добавляет шрифты к установленным, но поддержка шрифтов Java всё равно требует как минимум один установленный шрифт. В образе без каких‑либо шрифтов `loadExternalFonts` завершается ошибкой "Fontconfig head is null, check your fonts or fonts configuration".

## **Установка шрифта по умолчанию для отсутствующих шрифтов**

Когда шрифт отсутствует, Aspose.Slides использует заменяющий шрифт, выбираемый автоматически. Чтобы задать замену вручную, передайте имя шрифта в метод [setDefaultRegularFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) класса [LoadOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/) и передайте эти параметры конструктору [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/). *FontCheck* считывает имя шрифта из переменной окружения `DEFAULT_FONT`. При загруженном Carlito используйте его для отсутствующих шрифтов:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Теперь Calibri отрисовывается как Carlito, чьи символы имеют такие же ширины, как у Calibri, поэтому текст сохраняет переносы строк:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Шрифт по умолчанию заменяет каждый отсутствующий шрифт. Чтобы сопоставить отдельные шрифты, например Arial → Liberation Sans и Calibri → Carlito, используйте [font substitution rules](/slides/ru/java/font-substitution/). Правила меняют отрисованный результат, но `getSubstitutions` их не отражает, поэтому проверяйте шрифты в результирующем файле. Для азиатского текста также вызывайте [setDefaultAsianFont](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); см. [Default Font](/slides/ru/java/default-font/).

## **Установка шрифтов в Alpine Linux**

Образ Eclipse Temurin на базе Alpine также содержит шрифты DejaVu; [Run on Alpine Linux](/slides/ru/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) описывает его этап выполнения. Чтобы установить основные шрифты Microsoft и в нём, замените этап выполнения Dockerfile *font-check* следующим:

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

`update-ms-fonts` загружает и устанавливает те же основные шрифты Microsoft, что и пакет для Debian и Ubuntu, и их EULA применяется аналогично. `fc-cache` обновляет кэш шрифтов fontconfig. Соберите образ и запустите проверку двумя командами из раздела [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted). Вывод будет следующим:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Остальные шаги на этой странице работают одинаково в Alpine: скопируйте папку *fonts* в */usr/local/share/fonts* или в папку приложения и задайте `DEFAULT_FONT`, чтобы выбрать шрифт по умолчанию. В образе Alpine нет папки */usr/local/share/fonts*, поэтому она появляется в строке `Font folders` только после того, как инструкция `COPY` создаст её.

## **FAQ**

**Почему презентация выглядит иначе при конвертации на сервере?**

Сервер не содержит шрифтов, используемых в презентации, поэтому Aspose.Slides рисует текст заменяющим шрифтом, у которого ширина букв отличается. Запустите *FontCheck* с именами шрифтов презентации, чтобы увидеть, какие шрифты заменяются, затем установите их или загрузите из папки приложения.

**Сборка установила ttf-mscorefonts-installer, но Arial всё ещё заменяется. Почему?**

EULA не была принята до установки пакета, поэтому установщик пропустил шрифты. Разместите команду `debconf-set-selections` перед `apt-get install` в инструкции, устанавливающей пакет, как показано в разделе [Microsoft Core Fonts](#microsoft-core-fonts), и пересоберите образ.

**Нужны ли шрифты на компьютере, который открывает PDF?**

Нет. В этих примерах PDF содержит шрифты, использованные для отрисовки текста, поэтому он выглядит одинаково на любом компьютере. Шрифты нужны только там, где Aspose.Slides рендерит презентацию.