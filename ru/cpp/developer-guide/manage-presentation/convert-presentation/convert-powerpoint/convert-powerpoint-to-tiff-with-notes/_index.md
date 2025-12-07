---
title: Преобразовать презентации PowerPoint в TIFF с примечаниями на C++
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
- презентация в TIFF
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
description: "Преобразуйте презентации PowerPoint в TIFF с примечаниями с помощью Aspose.Slides для C++. Узнайте, как эффективно экспортировать слайды с примечаниями докладчика."
---

## **Обзор**

Aspose.Slides for C++ предоставляет простое решение для преобразования презентаций PowerPoint и OpenDocument (PPT, PPTX и ODP) с примечаниями в формат TIFF. Этот формат широко используется для хранения изображений высокого качества, печати и архивирования документов. С помощью Aspose.Slides вы можете не только экспортировать целые презентации с примечаниями докладчика, но и создавать миниатюры слайдов в представлении «Слайд с примечаниями». Процесс конвертации прост и эффективен, используя метод `Save` класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для преобразования всей презентации в серию изображений TIFF при сохранении примечаний и макета.

## **Конвертация презентации в TIFF с примечаниями**

Сохранение презентации PowerPoint или OpenDocument в TIFF с примечаниями с помощью Aspose.Slides for C++ включает следующие шаги:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) : загрузить файл PowerPoint или OpenDocument.  
1. Настроить параметры вывода макета: использовать класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) для указания того, как должны отображаться примечания и комментарии.  
1. Сохранить презентацию в TIFF: передать настроенные параметры в метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Предположим, у нас есть файл **speaker_notes.pptx** со следующим слайдом:

![The presentation slide with speaker notes](slide_with_notes.png)

Ниже приведён фрагмент кода, демонстрирующий, как преобразовать презентацию в изображение TIFF в представлении «Слайд с примечаниями», используя метод [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).
```cpp
// Создайте объект класса Presentation, представляющий файл презентации.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Отобразить примечания под слайдом.

// Настройте параметры TIFF с размещением примечаний.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Сохраните презентацию в TIFF с примечаниями докладчика.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Результат:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Посмотрите бесплатный конвертер PowerPoint в постер от Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Могу ли я управлять положением области примечаний в полученном TIFF?**

Да. Используйте [настройки макета примечаний](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) для выбора вариантов, таких как `None`, `BottomTruncated` или `BottomFull`, которые соответственно скрывают примечания, помещают их на одну страницу или позволяют перенести их на дополнительные страницы.

**Как можно уменьшить размер файла TIFF с примечаниями без заметной потери качества?**

Выберите эффективное сжатие ([set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/), например `LZW` или `RLE`), задайте разумное DPI и, если допускается, используйте более низкий [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (например, 8 bpp или 1 bpp для монохромного изображения). Сокращение [размеров изображения](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) также может помочь без заметного ухудшения читаемости.

**Влияет ли шрифт в примечаниях на результат, если исходные шрифты отсутствуют в системе?**

Да. Отсутствующие шрифты вызывают [замену](/slides/ru/cpp/font-selection-sequence/), что может изменить метрики текста и его внешний вид. Чтобы избежать этого, [предоставьте требуемые шрифты](/slides/ru/cpp/custom-font/) или задайте шрифт по умолчанию [fallback font](/slides/ru/cpp/fallback-font/), чтобы использовались нужные гарнитуры.