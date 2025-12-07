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
description: "Конвертировать презентации PowerPoint в TIFF с примечаниями с помощью Aspose.Slides для C++. Узнайте, как эффективно экспортировать слайды с примечаниями докладчика."
---

## **Обзор**

Aspose.Slides for C++ предоставляет простое решение для преобразования презентаций PowerPoint и OpenDocument (PPT, PPTX и ODP) с примечаниями в формат TIFF. Этот формат широко используется для хранения изображений высокого качества, печати и архивирования документов. С Aspose.Slides вы можете не только экспортировать полностью презентации с примечаниями докладчика, но и генерировать миниатюры слайдов в представлении Notes Slide. Процесс конвертации прост и эффективен, используя метод `Save` класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) для преобразования всей презентации в последовательность изображений TIFF с сохранением примечаний и макета.

## **Преобразовать презентацию в TIFF с примечаниями**

Сохранение презентации PowerPoint или OpenDocument в TIFF с примечаниями с помощью Aspose.Slides for C++ включает следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): загрузите файл PowerPoint или OpenDocument.  
2. Настройте параметры макета вывода: используйте класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) для указания того, как должны отображаться примечания и комментарии.  
3. Сохраните презентацию в TIFF: передайте настроенные параметры методу [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Предположим, у нас есть файл "speaker_notes.pptx" со следующим слайдом:

![Слайд презентации с примечаниями докладчика](slide_with_notes.png)

Приведённый ниже фрагмент кода демонстрирует, как преобразовать презентацию в изображение TIFF в представлении Notes Slide, используя метод [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) .
```cpp
// Создайте экземпляр класса Presentation, представляющего файл презентации.
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

![Изображение TIFF с примечаниями докладчика](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Посмотрите на бесплатный конвертер Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Могу ли я контролировать положение области примечаний в полученном TIFF?**

Да. Используйте [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) для выбора между вариантами `None`, `BottomTruncated` или `BottomFull`, которые соответственно скрывают примечания, помещают их на одну страницу или позволяют им продолжаться на дополнительных страницах.

**Как уменьшить размер файла TIFF с примечаниями без заметной потери качества?**

Выберите [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (например, `LZW` или `RLE`), задайте разумное значение DPI и, если приемлемо, используйте более низкий [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (например, 8 bpp или 1 bpp для монохромных изображений). С небольшим уменьшением [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) также можно снизить размер без заметного ухудшения читаемости.

**Влияет ли шрифт в примечаниях на результат, если оригинальные шрифты отсутствуют в системе?**

Да. Отсутствующие шрифты вызывают [substitution](/slides/ru/cpp/font-selection-sequence/), что может изменить метрики текста и его внешний вид. Чтобы избежать этого, [supply the required fonts](/slides/ru/cpp/custom-font/) или задайте шрифт по умолчанию через [fallback font](/slides/ru/cpp/fallback-font/).