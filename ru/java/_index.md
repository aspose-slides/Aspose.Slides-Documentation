---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /ru/java/
keywords:
- документация
- обработка презентаций
- конвертация презентаций
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides for Java, создайте первую презентацию и найдите руководства по распространённым задачам, развертыванию и справочнику API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java — это библиотека классов для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument в Java‑приложениях без Microsoft PowerPoint.

Библиотека загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая варианты с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАЛО РАБОТЫ</p>
<ul>
<li><a href="/slides/ru/java/installation/">Установка</a></li>
<li><a href="/slides/ru/java/create-presentation/">Создайте свою первую презентацию</a></li>
<li><a href="/slides/ru/java/system-requirements/">Системные требования</a></li>
<li><a href="/slides/ru/java/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНКА</p>
<ul>
<li><a href="/slides/ru/java/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/java/features-overview/">Обзор возможностей</a></li>
<li><a href="/slides/ru/java/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/java/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/java/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/java/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/java/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/java/convert-slide/">Отображать слайды как изображения</a></li>
<li><a href="/slides/ru/java/manage-text/">Редактировать текст и формы</a></li>
</ul>
<p>Рабочие процессы Slides</p>
<ul>
<li><a href="/slides/ru/java/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/java/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/java/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/java/presentation-design/">Дизайн слайда</a></li>
<li><a href="/slides/ru/java/merge-presentation/">Объединить презентации</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/java/examples/">Примеры по элементам слайда</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Примеры на GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Развёртывание и поддержка</b></p>
<hr>
<p>РАЗВЁРТЫВАНИЕ</p>
<ul>
<li><a href="/slides/ru/java/system-requirements/#linux">Требования к Linux</a></li>
<li><a href="/slides/ru/java/how-to-run-aspose-slides-in-docker/">Запуск в Docker</a></li>
<li><a href="/slides/ru/java/deploy-fonts/">Шрифты</a></li>
<li><a href="/slides/ru/java/security/">Безопасность</a></li>
</ul>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ru/java/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/ru/java/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/java/known-issues/">Известные проблемы</a></li>
<li><a href="/slides/ru/java/api-limitations/">Ограничения метаданных вывода</a></li>
<li><a href="https://releases.aspose.com/slides/ru/java/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ru/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платный сервис поддержки</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Ваша первая презентация**

Aspose.Slides for Java публикуется в собственном Maven‑репозитории Aspose, а не в Maven Central. Создайте папку для Maven‑проекта и сохраните в ней файл *pom.xml*. Он объявляет репозиторий, добавляет библиотеку и указывает класс для запуска:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloSlides</exec.mainClass>
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
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

Сохраните этот код как *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Создайте презентацию. Она уже содержит один пустой слайд.
        Presentation presentation = new Presentation();
        try {
            // Получите первый слайд.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Добавьте форму облака и вставьте в неё текст.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Сохраните презентацию в файл PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Затем, при установленном JDK 11 или новее и Apache Maven, выполните следующую команду в папке проекта:

```bash
mvn compile exec:java
```

Программа сохраняет *new_presentation.pptx* в папке проекта, с одним слайдом, содержащим облако с текстом. В Linux необходимо установить fontconfig и хотя бы один шрифт; см. [Установка](/slides/ru/java/installation/#linux). Без лицензии сохранённый файл будет иметь водяной знак оценки — см. [Лицензирование](/slides/ru/java/licensing/). Для получения дополнительных способов создания и заполнения презентации см. [Создание презентаций](/slides/ru/java/create-presentation/).