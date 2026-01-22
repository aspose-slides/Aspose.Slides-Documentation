---
title: Конвертировать презентации PowerPoint в документы Word на Android
linktitle: PowerPoint в Word
type: docs
weight: 110
url: /ru/androidjava/convert-powerpoint-to-word/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в Word
- презентация в Word
- слайд в Word
- PPT в Word
- PPTX в Word
- PowerPoint в DOCX
- презентация в DOCX
- слайд в DOCX
- PPT в DOCX
- PPTX в DOCX
- PowerPoint в DOC
- презентация в DOC
- слайд в DOC
- PPT в DOC
- PPTX в DOC
- сохранить PPT как DOCX
- сохранить PPTX как DOCX
- экспортировать PPT в DOCX
- экспортировать PPTX в DOCX
- Android
- Java
- Aspose.Slides
description: "Конвертировать слайды PowerPoint PPT и PPTX в редактируемые документы Word в Java с помощью Aspose.Slides for Android, сохраняя точный макет, изображения и форматирование."
---


Если вы планируете использовать текстовое содержание или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно преобразовать презентацию в Word (DOC или DOCX). 

* По сравнению с Microsoft PowerPoint, приложение Microsoft Word более оснащено инструментами и функциями для работы с содержимым. 
* Помимо функций редактирования в Word, вы также можете воспользоваться расширенными возможностями совместной работы, печати и обмена. 

{{% alert color="primary" %}} 

Вы можете попробовать наш [**Конвертер презентаций в Word Online**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы увидеть, что вы можете получить, работая с текстовым содержимым слайдов. 

{{% /alert %}} 

## **Aspose.Slides и Aspose.Words**

Для преобразования файла PowerPoint (PPTX или PPT) в Word (DOCX или DOCX) вам понадобятся как [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/), так и [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/). 

Как самостоятельный API, [Aspose.Slides](https://products.aspose.app/slides) для Java предоставляет функции, позволяющие извлекать текст из презентаций. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) — это расширенный API обработки документов, который позволяет приложениям создавать, изменять, конвертировать, отрисовывать, печатать файлы и выполнять другие операции с документами без использования Microsoft Word. 

## **Конвертировать PowerPoint в Word**

1. Скачайте библиотеки [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) и [Aspose.Words for Java](https://downloads.aspose.com/words/java). 
2. Добавьте *aspose-slides-x.x-jdk16.jar* и *aspose-words-x.x-jdk16.jar* в ваш CLASSPATH. 
3. Используйте следующий фрагмент кода для конвертации PowerPoint в Word: 
```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // генерирует изображение слайда в виде потока байтов
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // вставляет тексты слайда
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```


## **FAQ**

**Какие компоненты необходимо установить для конвертации презентаций PowerPoint и OpenDocument в документы Word?**

Вам достаточно добавить соответствующий пакет для [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) и [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) в ваш проект. Обе библиотеки работают как самостоятельные API, и установка Microsoft Office не требуется. 

**Поддерживаются ли все форматы презентаций PowerPoint и OpenDocument?**

Aspose.Slides [поддерживает все форматы презентаций](/slides/ru/androidjava/supported-file-formats/), включая PPT, PPTX, ODP и другие распространённые типы файлов. Это гарантирует, что вы сможете работать с презентациями, созданными в разных версиях Microsoft PowerPoint.