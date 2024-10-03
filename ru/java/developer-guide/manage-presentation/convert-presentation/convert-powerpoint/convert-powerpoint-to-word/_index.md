---
title: Конвертация PowerPoint в Word
type: docs
weight: 110
url: /ru/java/convert-powerpoint-to-word/
keywords: "Конвертация PowerPoint, PPT, PPTX, Презентация, Word, DOCX, DOC, PPTX в DOCX, PPT в DOC, PPTX в DOC, PPT в DOCX, Java, java, Aspose.Slides"
description: "Конвертация PowerPoint Презентации в Word на Java"
---

Если вы планируете использовать текстовое содержание или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно конвертировать презентацию в Word (DOC или DOCX). 

* По сравнению с Microsoft PowerPoint приложение Microsoft Word лучше оборудовано инструментами или функциональностью для работы с содержанием. 
* Помимо функций редактирования в Word, вы также можете получить преимущество от улучшенного сотрудничества, печати и функций обмена. 

{{% alert color="primary" %}} 

Вам может быть интересно попробовать наш [**Онлайн конвертер Презентация в Word**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы узнать, что вы можете получить, работая с текстовым содержанием слайдов. 

{{% /alert %}} 

## **Aspose.Slides и Aspose.Words**

Чтобы конвертировать файл PowerPoint (PPTX или PPT) в Word (DOCX или DOC), вам нужны оба [Aspose.Slides для Java](https://products.aspose.com/slides/java/) и [Aspose.Words для Java](https://products.aspose.com/words/java/).

В качестве самостоятельного API, [Aspose.Slides](https://products.aspose.app/slides) для Java предоставляет функции, которые позволяют извлекать текст из презентаций. 

[Aspose.Words](https://docs.aspose.com/words/java/) является передовым API для обработки документов, который позволяет приложениям генерировать, модифицировать, конвертировать, рендерить, печатать файлы и выполнять другие задачи с документами без использования Microsoft Word.

## **Конвертация PowerPoint в Word**

1. Скачайте библиотеки [Aspose.Slides для Java](https://downloads.aspose.com/slides/java) и [Aspose.Words для Java](https://downloads.aspose.com/words/java).
2. Добавьте *aspose-slides-x.x-jdk16.jar* и *aspose-words-x.x-jdk16.jar* в ваш CLASSPATH.
3. Используйте этот фрагмент кода для конвертации PowerPoint в Word:

```java
Presentation pres = new Presentation(inputPres);
try {
    Document doc = new Document();
    DocumentBuilder builder = new DocumentBuilder(doc);
    for (ISlide slide : pres.getSlides())
    {
        // генерирует и вставляет изображение слайда
        BufferedImage bitmap = slide.getThumbnail(1, 1);

        builder.insertImage(bitmap);

        // вставляет тексты слайда
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof AutoShape)
            {
                builder.writeln(((AutoShape)shape).getTextFrame().getText());
            }
        }

        builder.insertBreak(BreakType.PAGE_BREAK);
    }
    doc.save(outputDoc);
} finally {
    if (pres != null) pres.dispose();
}
```