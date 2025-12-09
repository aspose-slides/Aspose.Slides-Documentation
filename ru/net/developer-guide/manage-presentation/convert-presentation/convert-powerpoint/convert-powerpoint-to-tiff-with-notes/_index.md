---
title: Конвертировать презентации PowerPoint в TIFF с приметками в .NET
linktitle: PowerPoint в TIFF с приметками
type: docs
weight: 100
url: /ru/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в TIFF
- презентация в TIFF
- слайд в TIFF
- PPT в TIFF
- PPTX в TIFF
- сохранить PPT как TIFF
- сохранить PPTX как TIFF
- экспортировать PPT в TIFF
- экспортировать PPTX в TIFF
- PowerPoint с приметками
- презентация с приметками
- слайд с приметками
- PPT с приметками
- PPTX с приметками
- TIFF с приметками
- .NET
- C#
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в TIFF с приметками с помощью Aspose.Slides для .NET. Узнайте, как эффективно экспортировать слайды с заметками докладчика."
---

## **Обзор**

Aspose.Slides for .NET предоставляет простое решение для преобразования презентаций PowerPoint и OpenDocument (PPT, PPTX и ODP) с примечаниями в формат TIFF. Этот формат широко используется для качественного хранения изображений, печати и архивирования документов. С помощью Aspose.Slides вы можете не только экспортировать целые презентации с примечаниями докладчика, но и генерировать миниатюры слайдов в представлении «Слайд с заметками». Процесс конвертации прост и эффективен: используется метод `Save` класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) для преобразования всей презентации в серию TIFF‑изображений с сохранением примечаний и макета.

## **Преобразовать презентацию в TIFF с примечаниями**

Сохранить презентацию PowerPoint или OpenDocument в TIFF с примечаниями с помощью Aspose.Slides for .NET можно следующими шагами:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/): загрузить файл PowerPoint или OpenDocument.  
1. Настроить параметры вывода макета: использовать класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) для указания, как должны отображаться примечания и комментарии.  
1. Сохранить презентацию в TIFF: передать сконфигурированные параметры методу [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index).

Предположим, у нас есть файл **speaker_notes.pptx** со следующим слайдом:

![The presentation slide with speaker notes](slide_with_notes.png)

Ниже приведён фрагмент кода, демонстрирующий, как преобразовать презентацию в TIFF‑изображение в представлении «Слайд с заметками» с использованием свойства [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).
```c#
// Создать объект класса Presentation, представляющий файл презентации.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Настроить параметры TIFF с разметкой заметок.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Отображать заметки под слайдом.
        }
    };

    // Сохранить презентацию в TIFF с заметками докладчика.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


Результат:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Совет" color="primary" %}}

Посмотрите бесплатный онлайн‑конвертер Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Могу ли я контролировать положение области заметок в полученном TIFF?**

Да. Используйте настройки макета [notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/), выбирая варианты `None`, `BottomTruncated` или `BottomFull`, которые соответственно скрывают заметки, помещают их на одну страницу или позволяют распределять их по нескольким страницам.

**Как уменьшить размер TIFF‑файла с заметками без заметной потери качества?**

Выберите [efficient compression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (например, `LZW` или `RLE`), задайте разумное значение DPI и, если допустимо, используйте более низкий [pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) (например, 8 bpp или 1 bpp для монохромного изображения). Немного уменьшив [image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/), можно также сократить размер без заметного ухудшения читаемости.

**Влияет ли шрифт в заметках на результат, если исходные шрифты отсутствуют в системе?**

Да. При отсутствии шрифтов происходит [substitution](/slides/ru/net/font-selection-sequence/), что может изменить метрики текста и его внешний вид. Чтобы избежать этого, [supply the required fonts](/slides/ru/net/custom-font/) или задайте шрифт по умолчанию через [fallback font](/slides/ru/net/fallback-font/), чтобы использовались нужные гарнитуры.