---
title: Преобразование PowerPoint в Word
type: docs
weight: 110
url: /androidjava/convert-powerpoint-to-word/
keywords: "Преобразовать PowerPoint, PPT, PPTX, Презентация, Word, DOCX, DOC, PPTX в DOCX, PPT в DOC, PPTX в DOC, PPT в DOCX, Java, java, Aspose.Slides"
description: "Преобразование презентации PowerPoint в Word на Java"
---

Если вы планируете использовать текстовое содержимое или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно преобразовать презентацию в Word (DOC или DOCX).

* По сравнению с Microsoft PowerPoint, приложение Microsoft Word более оснащено инструментами или функциональностью для работы с контентом.
* Кроме функций редактирования в Word, вы также можете воспользоваться улучшенными возможностями для совместной работы, печати и обмена документами.

{{% alert color="primary" %}} 

Вам может быть интересно протестировать наш [**Онлайн-конвертер Презентаций в Word**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы увидеть, что вы можете получить от работы с текстовым содержимым слайдов.

{{% /alert %}} 

## **Aspose.Slides и Aspose.Words**

Для преобразования файла PowerPoint (PPTX или PPT) в Word (DOCX или DOC) вам нужны оба [Aspose.Slides для Android через Java](https://products.aspose.com/slides/androidjava/) и [Aspose.Words для Java](https://products.aspose.com/words/java/).

Как отдельный API, [Aspose.Slides](https://products.aspose.app/slides) для Java предоставляет функции, которые позволяют извлекать тексты из презентаций.

[Aspose.Words](https://docs.aspose.com/words/java/) — это продвинутый API для обработки документов, который позволяет приложениям генерировать, изменять, преобразовывать, отображать, печатать файлы и выполнять другие задачи с документами без использования Microsoft Word.

## **Преобразование PowerPoint в Word**

1. Загрузите библиотеки [Aspose.Slides для Android через Java](https://downloads.aspose.com/slides/java) и [Aspose.Words для Java](https://downloads.aspose.com/words/java).
2. Добавьте *aspose-slides-x.x-jdk16.jar* и *aspose-words-x.x-jdk16.jar* в ваш CLASSPATH.
3. Используйте этот фрагмент кода для преобразования PowerPoint в Word:

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