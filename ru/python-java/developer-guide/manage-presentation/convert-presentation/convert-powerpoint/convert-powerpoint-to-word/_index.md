---
title: Конвертация презентаций PowerPoint в документы Word с помощью Python через Java
linktitle: PowerPoint в Word
type: docs
weight: 110
url: /ru/python-java/convert-powerpoint-to-word/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в Word
- презентация в Word
- PPT в Word
- PPTX в Word
- ODP в Word
- PowerPoint в DOCX
- PPT в DOCX
- PPTX в DOCX
- PowerPoint в DOC
- сохранить PPT как DOCX
- сохранить PPTX как DOCX
- экспортировать PPT в DOCX
- экспортировать PPTX в DOCX
- Python
- Java
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в Word с помощью Python через Java, используя Aspose.Slides и Aspose.Words, объединяя изображения слайдов с редактируемым текстом."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint и OpenDocument в документы Word с использованием Aspose.Slides for Python via Java вместе с Aspose.Words for Java. Aspose.Slides рендерит каждый слайд и считывает его текст, тогда как Aspose.Words создает документ Word через JPype. Microsoft Office не требуется.

Полученный документ содержит изображение слайда, за которым следует редактируемый текст, извлечённый из верхнеуровневых автоформ слайда. Изображение сохраняет визуальный вид слайда; отдельные формы, диаграммы и таблицы не преобразуются в редактируемые объекты Word. Извлечённый текст не сохраняет исходное форматирование или позиционирование.

## **Преобразовать PowerPoint в Word**

1. Установите [Aspose.Slides for Python via Java](/slides/ru/python-java/installation/) и совместимую Java-runtime.
2. Скачайте [Aspose.Words for Java](https://releases.aspose.com/words/java/). Поместите основной JAR-файл в каталог `lib` рядом со скриптом и переименуйте его в `aspose-words.jar`, либо измените путь в примере, чтобы он соответствовал скачанному файлу.
3. Поместите исходную презентацию `sample.pptx` в рабочий каталог. Путь `lib/aspose-words.jar` также относителен этого каталога.
4. Запустите следующий код Python, чтобы создать `output.docx`.

В примере исходный файл загружается с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и рендерит слайды с помощью [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage). Для вставки изображений и текста в документ Word используется [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) из Aspose.Words.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Подгоните изображение слайда по ширине текстовой области, сохраняя его пропорции.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Добавьте простой текст из верхнеуровневых автоформ, включая текстовые поля.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Каждый слайд начинается на новой странице. Длинный извлечённый текст или необычно высокие изображения слайдов могут потребовать дополнительных страниц. Код добавляет разрывы страниц только между слайдами и освобождает презентацию и отрендеренные изображения в блоках `finally`. JVM остаётся доступной для последующих преобразований в том же процессе Python.

## **FAQ**

**Какие библиотеки требуются?**

Используйте Aspose.Slides for Python via Java, JPype, совместимую Java-runtime и Aspose.Words for Java. Оба продукта Aspose работают в одной JVM. Aspose.Slides обрабатывает презентацию; Aspose.Words записывает документ Word.

**Можно ли конвертировать файлы PPT и ODP, а также PPTX?**

Да. Замените `sample.pptx` на файл PPT или ODP. См. [Supported File Formats](/slides/ru/python-java/supported-file-formats/) для поддерживаемых форматов входных презентаций.

**Весь ли контент слайда редактируем в Word?**

Нет. Каждый слайд вставляется как статическое изображение, а под ним добавляется обычный текст из верхнеуровневых автоформ. Текст, находящийся внутри групп, таблиц, SmartArt и диаграмм, а также заметки спикера, не извлекается этим примером. Анимации и переходы не воспроизводятся в документе Word.

**Можно ли сохранить как DOC вместо DOCX?**

Да. Измените имя выходного файла на `output.doc`. Aspose.Words выбирает формат вывода по расширению имени файла при использовании этой перегрузки метода save.