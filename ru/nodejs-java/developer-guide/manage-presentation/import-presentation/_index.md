---
title: Импорт презентаций из PDF или HTML в JavaScript
linktitle: Импорт презентации
type: docs
weight: 60
url: /ru/nodejs-java/import-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Импортируйте PDF и HTML документы в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js для беспроблемной, высокопроизводительной обработки слайдов."
---

Используя [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), вы можете импортировать презентации из файлов других форматов. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/), позволяющий импортировать презентации из PDF, HTML‑документов и т.д.

## **Импорт PowerPoint из PDF**

В этом случае вы конвертируете PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. Вызовите метод [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) и передайте PDF‑файл.
3. Используйте метод [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот JavaScript‑код демонстрирует операцию конвертации PDF в PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert  title="Tip" color="primary" %}} 
Возможно, вам будет интересно попробовать бесплатное веб‑приложение **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), поскольку это живой пример процесса, описанного здесь. 
{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы конвертируете HTML‑документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/).
2. Вызовите метод [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) и передайте HTML‑файл.
3. Используйте метод [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот JavaScript‑код демонстрирует операцию конвертации HTML в PowerPoint:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Сохраняются ли таблицы при импорте PDF и можно ли улучшить их обнаружение?**

Таблицы могут быть обнаружены во время импорта; класс [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) содержит метод [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables), который включает распознавание таблиц. Эффективность зависит от структуры PDF.