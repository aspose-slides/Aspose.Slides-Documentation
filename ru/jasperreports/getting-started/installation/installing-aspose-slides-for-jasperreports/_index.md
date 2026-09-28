---
title: Установка Aspose.Slides для JasperReports
type: docs
weight: 40
url: /ru/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Выберите JAR‑файлы Aspose.Slides для JasperReports, соответствующие версии вашего JasperReports, и добавьте их в JasperReports, Maven‑проект или JasperReports Server."
---
## **Выберите JAR‑файлы для вашей версии JasperReports**

Aspose.Slides for JasperReports распространяется в виде ZIP‑файла на [странице загрузки](https://releases.aspose.com/slides/ru/jasperreport/). Его папка *lib* содержит одну подпапку для каждого диапазона версий JasperReports. Возьмите JAR‑файлы из подпапки, соответствующей используемой версии JasperReports:

| Версия JasperReports | Подпапка в *lib* |
| :- | :- |
| 3.7.2 до 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 до 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 до 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Для JasperReports 6.17.0 и новее, включая JasperReports 7, подпапки нет. Подпапка *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* не содержит JAR‑файлов, только примечание, что поддержка этих версий завершена в Aspose.Slides for JasperReports 17.6.

В каждой подпапке находятся два JAR‑файла; *xx.x* в их названиях — версия продукта:

- *aspose.slides.jasperreports.library-xx.x.jar* содержит экспортеры для JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` и `ASHtmlExporter`) и класс `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* содержит действия экспорта для JasperReports Server. Он построен на основе библиотечного JAR, поэтому сервер всегда требует оба JAR‑файла из одной и той же подпапки.

## **Добавьте библиотечный JAR в JasperReports или ваше приложение**

Скопируйте *aspose.slides.jasperreports.library-xx.x.jar* из соответствующей подпапки в папку *lib* JasperReports или в classpath вашего приложения. После этого приложение сможет создавать экспортеры в коде.

{{% alert color="info" title="Note" %}}
В Linux JasperReports требуется fontconfig и как минимум один установленный шрифт для заполнения отчёта. Без шрифтов заполнение завершится ошибкой «Error initializing graphic environment».
{{% /alert %}}

## **Добавьте библиотечный JAR в проект Maven**

JAR поставляется в ZIP‑файле, а не из репозитория Maven. Чтобы использовать его в сборке Maven, установите его в локальный репозиторий Maven. Для версии 26.6 выполните эту команду в папке, где находится JAR:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Затем добавьте его в зависимости в *pom.xml* вместе с версией JasperReports, охваченной подпапкой JAR:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Идентификаторы group и artifact — те, которые вы указали в команде установки; они просто должны совпадать. Полный пример проекта, использующего JasperReports 6.16.0, находится в [Your first export](/slides/ru/jasperreports/#your-first-export).

## **Добавьте JAR‑файлы в JasperReports Server**

Скопируйте оба JAR‑файла из соответствующей подпапки в папку *WEB-INF/lib* веб‑приложения JasperReports Server, затем зарегистрируйте экспортеры, как описано в [Integration with JasperServer](/slides/ru/jasperreports/integration-with-jasperserver/).