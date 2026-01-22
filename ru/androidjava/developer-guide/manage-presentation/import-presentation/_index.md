---
title: Импорт презентаций из PDF или HTML на Android
linktitle: Импорт презентации
type: docs
weight: 60
url: /ru/androidjava/import-presentation/
keywords:
- импорт презентации
- импорт слайда
- импорт PDF
- импорт HTML
- PDF в презентацию
- PDF в PPT
- PDF в PPTX
- PDF в ODP
- HTML в презентацию
- HTML в PPT
- HTML в PPTX
- HTML в ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Импортируйте документы PDF и HTML в презентации PowerPoint и OpenDocument в Java с помощью Aspose.Slides for Android для бесшовной, высокопроизводительной обработки слайдов."
---

Используя [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), вы можете импортировать презентации из файлов других форматов. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) для импорта презентаций из PDF, HTML‑документов и т.д.

## **Импорт PowerPoint из PDF**

В этом случае вы преобразуете PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/) .
2. Вызовите метод [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) и передайте путь к PDF‑файлу.
3. Используйте метод [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот Java‑код демонстрирует преобразование PDF в PowerPoint:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert  title="Tip" color="primary" %}} 
Возможно, вам будет полезно бесплатное веб‑приложение **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), так как оно реализует процесс в реальном времени. 
{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы преобразуете HTML‑документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/) .
2. Вызовите метод [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) и передайте HTML‑файл.
3. Используйте метод [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот Java‑код демонстрирует преобразование HTML в PowerPoint: 
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


## **FAQ**

**Сохраняются ли таблицы при импорте PDF и можно ли улучшить их обнаружение?**

Таблицы могут быть обнаружены во время импорта; класс [PdfImportOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/) содержит метод [setDetectTables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) , который включает распознавание таблиц. Эффективность зависит от структуры PDF.