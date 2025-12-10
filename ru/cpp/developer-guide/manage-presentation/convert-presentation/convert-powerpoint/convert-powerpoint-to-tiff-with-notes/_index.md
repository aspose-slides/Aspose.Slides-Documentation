---
title: Конвертировать презентации PowerPoint в TIFF с примечаниями на C++
linktitle: PowerPoint в TIFF с примечаниями
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
- PowerPoint с примечаниями
- презентация с примечаниями
- слайд с примечаниями
- PPT с примечаниями
- PPTX с примечаниями
- TIFF с примечаниями
- C++
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в TIFF с примечаниями, используя Aspose.Slides для C++. Узнайте, как эффективно экспортировать слайды с примечаниями докладчика."
---

## **Обзор**

Aspose.Slides for C++ предоставляет простое решение для преобразования презентаций PowerPoint и OpenDocument (PPT, PPTX и ODP) с примечаниями в формат TIFF. Этот формат широко используется для хранения изображений высокого качества, печати и архивирования документов. С помощью Aspose.Slides вы можете не только экспортировать полные презентации с примечаниями докладчика, но и создавать миниатюры слайдов в представлении Notes Slide. Процесс конвертации прост и эффективен, использует метод `Save` класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для преобразования всей презентации в серию TIFF‑изображений с сохранением примечаний и макета.

## **Преобразование презентации в TIFF с примечаниями**

Сохранение презентации PowerPoint или OpenDocument в TIFF с примечаниями с помощью Aspose.Slides for C++ включает следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): загрузите файл PowerPoint или OpenDocument.  
2. Настройте параметры вывода макета: используйте класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) для указания, как должны отображаться примечания и комментарии.  
3. Сохраните презентацию в TIFF: передайте настроенные параметры в метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Предположим, у нас есть файл "speaker_notes.pptx" со следующим слайдом:

![Слайд презентации с примечаниями докладчика](slide_with_notes.png)

```cpp
// Создать объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Отображать примечания под слайдом.

// Настроить параметры TIFF с размещением примечаний.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Сохранить презентацию в TIFF с примечаниями докладчика.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Результат:

![Изображение TIFF с примечаниями докладчика](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Посетите бесплатный конвертер Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Могу ли я управлять положением области примечаний в полученном TIFF?**

Да. Используйте [настройки макета примечаний](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) для выбора между вариантами `None`, `BottomTruncated` или `BottomFull`, которые соответственно скрывают примечания, помещают их на одну страницу или позволяют им переходить на дополнительные страницы.

**Как я могу уменьшить размер TIFF‑файла с примечаниями без заметной потери качества?**

Выберите [эффективное сжатие](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (например, `LZW` или `RLE`), установите разумное значение DPI и, если допустимо, используйте более низкий [формат пикселей](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (например, 8 bpp или 1 bpp для монохромного изображения). Небольшое уменьшение [размеров изображения](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) также может помочь без заметного ухудшения читаемости.

**Влияет ли шрифт в примечаниях на результат, если оригинальные шрифты отсутствуют в системе?**

Да. Отсутствующие шрифты вызывают [подстановку](/slides/ru/cpp/font-selection-sequence/), что может изменить метрики текста и его внешний вид. Чтобы избежать этого, [предоставьте необходимые шрифты](/slides/ru/cpp/custom-font/) или задайте шрифт по умолчанию в качестве [резервного шрифта](/slides/ru/cpp/fallback-font/), чтобы использовались требуемые гарнитуры.