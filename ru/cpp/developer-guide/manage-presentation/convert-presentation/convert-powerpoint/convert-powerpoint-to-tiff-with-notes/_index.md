---
title: Конвертировать презентации PowerPoint в TIFF с нотатками на C++
linktitle: PowerPoint в TIFF с нотатками
type: docs
weight: 100
url: /ru/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в TIFF
- презентацию в TIFF
- слайд в TIFF
- PPT в TIFF
- PPTX в TIFF
- сохранить PPT как TIFF
- сохранить PPTX как TIFF
- экспортировать PPT в TIFF
- экспортировать PPTX в TIFF
- PowerPoint с нотатками
- презентация с нотатками
- слайд с нотатками
- PPT с нотатками
- PPTX с нотатками
- TIFF с нотатками
- C++
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в TIFF с нотатками с помощью Aspose.Slides для C++. Узнайте, как эффективно экспортировать слайды с заметками докладчика."
---

## **Обзор**

Aspose.Slides for C++ предоставляет простое решение для преобразования презентаций PowerPoint и OpenDocument (PPT, PPTX и ODP) с нотатками в формат TIFF. Этот формат широко используется для хранения изображений высокого качества, печати и архивирования документов. С помощью Aspose.Slides вы можете не только экспортировать целые презентации с заметками докладчика, но и создавать миниатюры слайдов в представлении Notes Slide. Процесс конвертации прост и эффективен, он использует метод `Save` класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для преобразования всей презентации в серию TIFF‑изображений с сохранением нотаток и разметки.

## **Преобразовать презентацию в TIFF с нотатками**

Сохранение презентации PowerPoint или OpenDocument в TIFF с нотатками с помощью Aspose.Slides for C++ включает следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): загрузите файл PowerPoint или OpenDocument.
1. Настройте параметры выводимой разметки: используйте класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) для указания того, как должны отображаться нотатки и комментарии.
1. Сохраните презентацию в TIFF: передайте сконфигурированные параметры в метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Предположим, у нас есть файл "speaker_notes.pptx" со следующим слайдом:

![Слайд презентации с нотатками докладчика](slide_with_notes.png)

Ниже приведён фрагмент кода, демонстрирующий, как преобразовать презентацию в TIFF‑изображение в представлении Notes Slide с использованием метода [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
// Создать экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Отображать заметки под слайдом.

// Настроить параметры TIFF с размещением заметок.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Сохранить презентацию в TIFF с заметками докладчика.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Результат:

![TIFF‑изображение с нотатками докладчика](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Посмотрите бесплатный конвертер Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Вопросы и ответы**

**Можно ли управлять положением области нотаток в полученном TIFF?**

Да. Используйте [настройки размещения нотаток](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), чтобы выбрать из вариантов, таких как `None`, `BottomTruncated` или `BottomFull`, которые соответственно скрывают нотатки, помещают их на одну страницу или позволяют им продолжаться на дополнительные страницы.

**Как можно уменьшить размер TIFF‑файла с нотатками без заметной потери качества?**

Выберите [эффективное сжатие](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (например, `LZW` или `RLE`), задайте разумное значение DPI и, если приемлемо, используйте более низкий [формат пикселей](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (например, 8 bpp или 1 bpp для монохромного изображения). Немного уменьшив [размеры изображения](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/), можно также снизить размер без заметного ухудшения читаемости.

**Влияет ли шрифт в нотатках на результат, если оригинальные шрифты отсутствуют в системе?**

Да. Отсутствующие шрифты вызывают [замену](/slides/ru/cpp/font-selection-sequence/), что может изменить метрики текста и его внешний вид. Чтобы этого избежать, [предоставьте необходимые шрифты](/slides/ru/cpp/custom-font/) или задайте шрифт‑заменитель по умолчанию с помощью [fallback font](/slides/ru/cpp/fallback-font/), чтобы использовались требуемые типографики.