---
title: Конвертировать презентации PowerPoint в TIFF с заметками на C++
linktitle: PowerPoint в TIFF с заметками
type: docs
weight: 100
url: /ru/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- конвертировать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
- PowerPoint в TIFF
- презентация в TIFF
- слайд в TIFF
- PPT в TIFF
- PPTX в TIFF
- сохранить PPT как TIFF
- сохранить PPTX как TIFF
- экспортировать PPT в TIFF
- экспортировать PPTX в TIFF
- PowerPoint с заметками
- презентация с заметками
- слайд с заметками
- PPT с заметками
- PPTX с заметками
- TIFF с заметками
- C++
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint в TIFF с заметками, используя Aspose.Slides для C++. Узнайте, как эффективно экспортировать слайды с примечаниями выступающего."
---

## **Обзор**

Aspose.Slides for C++ предоставляет простое решение для преобразования презентаций PowerPoint и OpenDocument (PPT, PPTX и ODP) с заметками в формат TIFF. Этот формат широко используется для высокого качества хранения изображений, печати и архивирования документов. С помощью Aspose.Slides вы можете не только экспортировать целые презентации с примечаниями выступающего, но и создавать миниатюры слайдов в представлении заметок слайдов. Процесс конвертации прост и эффективен, использует метод `Save` класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для преобразования всей презентации в серию TIFF‑изображений с сохранением заметок и макета.

## **Преобразовать презентацию в TIFF с заметками**

Сохранение презентации PowerPoint или OpenDocument в TIFF с заметками с помощью Aspose.Slides for C++ включает следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): загрузите файл PowerPoint или OpenDocument.  
1. Настройте параметры вывода макета: используйте класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) для указания того, как должны отображаться заметки и комментарии.  
1. Сохраните презентацию в TIFF: передайте настроенные параметры методу [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Предположим, у нас есть файл «speaker_notes.pptx» со следующим слайдом:

![Слайд презентации с заметками выступающего](slide_with_notes.png)

Ниже приведён фрагмент кода, демонстрирующий, как преобразовать презентацию в TIFF‑изображение в представлении заметок слайдов с помощью метода [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).
```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Отобразить заметки под слайдом.

// Настройте параметры TIFF с расположением заметок.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Результат:

![Изображение TIFF с заметками выступающего](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Посмотрите бесплатный онлайн‑конвертер Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Могу ли я управлять позицией области заметок в полученном TIFF?**

Да. Используйте [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) для выбора между вариантами `None`, `BottomTruncated` или `BottomFull`, которые соответственно скрывают заметки, помещают их на одну страницу или позволяют распределять их на несколько страниц.

**Как уменьшить размер TIFF‑файла с заметками без заметной потери качества?**

Выберите [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (например, `LZW` или `RLE`), задайте разумное значение DPI и, если приемлемо, используйте более низкий [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (например, 8 bpp или 1 bpp для монохромного изображения). Слегка уменьшив [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/), также можно сократить размер без заметного ухудшения читаемости.

**Влияет ли шрифт в заметках на результат, если оригинальные шрифты отсутствуют в системе?**

Да. Отсутствующие шрифты вызывают [substitution](/slides/ru/cpp/font-selection-sequence/), что может изменить метрики текста и его внешний вид. Чтобы избежать этого, [supply the required fonts](/slides/ru/cpp/custom-font/) или задайте шрифт‑запас [fallback font](/slides/ru/cpp/fallback-font/), чтобы использовались нужные типографические гарнитуры.