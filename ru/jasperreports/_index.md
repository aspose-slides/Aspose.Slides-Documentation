---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /ru/jasperreports/
keywords:
- документация
- JasperReports
- JasperReports Server
- экспорт отчётов
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides for JasperReports, экспортируйте первый отчёт в PowerPoint и найдите руководства по экспорту, интеграции с JasperReports Server и поддержке."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports добавляет экспортеры PowerPoint в JasperReports Library и JasperReports Server, чтобы Java‑приложения и серверы отчётов могли сохранять заполненные отчёты в виде презентаций без Microsoft PowerPoint.

Он экспортирует заполненный отчёт в PPT и PPTX, один слайд на страницу отчёта, а также в PDF и HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАЛО РАБОТЫ</p>
<ul>
<li><a href="/slides/ru/jasperreports/installing-aspose-slides-for-jasperreports/">Установка</a></li>
<li><a href="/slides/ru/jasperreports/product-overview/">Обзор продукта</a></li>
<li><a href="/slides/ru/jasperreports/system-requirements/">Системные требования</a></li>
<li><a href="/slides/ru/jasperreports/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНИТЬ</p>
<ul>
<li><a href="/slides/ru/jasperreports/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/jasperreports/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/jasperreports/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание со Slides</b></p>
<hr>
<p>ЭКСПОРТ</p>
<ul>
<li><a href="/slides/ru/jasperreports/ppt-pptx-pdf-and-html-export/">Экспорт в PPT, PPTX, PDF и HTML</a></li>
<li><a href="/slides/ru/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Сопоставление шрифтов</a></li>
<li><a href="/slides/ru/jasperreports/integration-with-jasperserver/">Интеграция с JasperReports Server</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/jasperreports/demos-setup/">Примеры проектов</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка &amp; Поддержка</b></p>
<hr>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Примечания к выпуску</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платная служба поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваш первый экспорт**

Эти шаги компилируют однострочный отчёт, заполняют его и экспортируют в PPTX с помощью JasperReports 6.16.0 из Maven Central. Требуется JDK 11 или новее и Apache Maven.

1. Скачайте ZIP‑архив со [download page](https://releases.aspose.com/slides/jasperreport/) и распакуйте его. Папка *lib* содержит подпапку для каждого диапазона версий JasperReports, в которой находится jar‑файл соответствующего диапазона. Для JasperReports 6.16.0 скопируйте *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* в пустую папку проекта.

2. Jar‑файл поставляется в ZIP, а не из Maven‑репозитория, поэтому установите его в локальный Maven‑репозиторий. Выполните эту команду в папке проекта:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Сохраните этот *pom.xml* в папке проекта. Он добавляет JasperReports 6.16.0 и установленный jar, а также указывает класс для запуска. JasperReports 6.16.0 объявляет модифицированную сборку iText, которой нет в Maven Central, поэтому файл исключает её; экспортёрам Aspose она не нужна.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. Сохраните дизайн отчёта как *hello.jrxml* в папке проекта. Он выводит одну строку текста в заголовочной полосе:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. Сохраните этот код как *src/main/java/HelloExport.java*. Он компилирует дизайн, заполняет его одной пустой записью и экспортирует результат с помощью `ASPptxExporter`:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // Скомпилируйте дизайн отчёта и заполните его одной пустой записью.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Экспортируйте заполненный отчёт в PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Выполните эту команду в папке проекта:

```bash
mvn compile exec:java
```

Программа сохраняет *hello.pptx* в папке проекта, создав один слайд с текстом отчёта. Компилятор отмечает, что код использует устаревший API: экспортёры получают ввод и вывод через `JRExporterParameter` и не принимают более новую конфигурацию `setExporterInput` и `setExporterOutput`. В Linux должен быть установлен fontconfig и по крайней мере один шрифт, иначе заполнение отчёта не удаётся. Без лицензии каждый слайд получает водяной знак оценки в центре — см. [Licensing](/slides/ru/jasperreports/licensing/). Чтобы экспортировать в PPT, PDF или HTML, смотрите [PPT, PPTX, PDF and HTML Export](/slides/ru/jasperreports/ppt-pptx-pdf-and-html-export/).