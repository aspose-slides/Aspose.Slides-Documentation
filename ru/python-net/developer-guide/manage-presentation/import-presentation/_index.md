---
title: Импортируйте презентации с помощью Python
linktitle: Импорт презентации
type: docs
weight: 60
url: /ru/python-net/import-presentation/
keywords:
- импорт PowerPoint
- импорт презентации
- импорт слайда
- PDF в презентацию
- PDF в PPT
- PDF в PPTX
- PDF в ODP
- HTML в презентацию
- HTML в PPT
- HTML в PPTX
- HTML в ODP
- Python
- Aspose.Slides
description: "Легко импортируйте документы PDF и HTML в презентации PowerPoint и OpenDocument на Python с помощью Aspose.Slides для бесшовной, высокопроизводительной обработки слайдов."
---

С помощью [**Aspose.Slides для Python через .NET**](https://products.aspose.com/slides/python-net/) вы можете импортировать презентации из файлов в других форматах. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) для импорта презентаций из PDF, HTML-документов и т.д.

## **Импорт PowerPoint из PDF**

В этом случае вы сможете конвертировать PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте экземпляр класса презентации.
2. Вызовите метод `add_from_pdf` и передайте PDF файл.
3. Используйте метод `save`, чтобы сохранить файл в формате PowerPoint.

Этот код на Python демонстрирует операцию PDF в PowerPoint:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Совет" color="primary" %}} 

Вам может быть интересно ознакомиться с **бесплатным** веб-приложением **Aspose** [PDF в PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), так как это живая реализация процесса, описанного здесь. 

{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы сможете конвертировать HTML-документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Вызовите метод `add_from_html` и передайте HTML файл.
3. Используйте метод `save`, чтобы сохранить файл в формате PowerPoint.

Этот код на Python демонстрирует операцию HTML в PowerPoint: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Примечание" color="warning" %}} 

Вы также можете использовать Aspose.Slides для конвертации HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}