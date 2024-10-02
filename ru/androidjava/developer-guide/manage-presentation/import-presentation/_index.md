---
title: Импорт Презентации
type: docs
weight: 60
url: /ru/androidjava/import-presentation/
keywords: "Импорт PowerPoint, PDF в Презентацию, PDF в PPTX, PDF в PPT, Java, Aspose.Slides для Android через Java"
description: "Импорт презентации PowerPoint из PDF. Конвертировать PDF в PowerPoint"
---

С помощью [**Aspose.Slides для Android через Java**](https://products.aspose.com/slides/androidjava/) вы можете импортировать презентации из файлов в других форматах. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/), который позволяет импортировать презентации из PDF, HTML документов и так далее.

## **Импорт PowerPoint из PDF**

В этом случае вы можете конвертировать PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. Вызовите метод [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) и передайте файл PDF.
3. Используйте метод [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот код на Java демонстрирует операцию PDF в PowerPoint:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Совет" color="primary" %}} 

Вам может быть интересно посмотреть **Aspose free** [PDF в PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) веб-приложение, потому что это живая реализация процесса, описанного здесь. 

{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы можете конвертировать HTML документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. Вызовите метод [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) и передайте файл HTML.
3. Используйте метод [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот код на Java демонстрирует операцию HTML в PowerPoint: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="Примечание" color="warning" %}} 

Вы также можете использовать Aspose.Slides для конвертации HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}