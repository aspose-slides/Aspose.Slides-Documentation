---
title: Переобразование презентаций PowerPoint в TIFF с примечаниями на C++
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
description: "Преобразуйте презентации PowerPoint в TIFF с примечаниями с помощью Aspose.Slides для C++. Узнайте, как эффективно экспортировать слайды с заметками докладчика."
---
## **Введение**

Aspose.Slides for C++ предоставляет простое решение для преобразования презентаций PowerPoint и OpenDocument (PPT, PPTX и ODP) с примечаниями в формат TIFF. Этот формат широко используется для хранения изображений высокого качества, печати и архивирования документов. С Aspose.Slides вы можете не только экспортировать целые презентации с заметками докладчика, но и создавать миниатюры слайдов в режиме Notes Slide. Процесс конвертации прост и эффективен, используя метод `Save` класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) для преобразования всей презентации в серию изображений TIFF при сохранении примечаний и макета.

## **Преобразовать презентацию в TIFF с примечаниями**

Сохранение презентации PowerPoint или OpenDocument в TIFF с примечаниями с помощью Aspose.Slides for C++ включает следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/): загрузите файл PowerPoint или OpenDocument.  
2. Настройте параметры макета вывода: используйте класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/) для указания того, как должны отображаться заметки и комментарии.  
3. Сохраните презентацию в TIFF: передайте настроенные параметры методу [Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/).

Предположим, у нас есть файл "speaker_notes.pptx" со следующим слайдом:

![Слайд презентации с заметками докладчика](slide_with_notes.png)

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте объект класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Отобразить примечания под слайдом.

// Настройте параметры TIFF с расположением заметок.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Сохраните презентацию в TIFF вместе с примечаниями докладчика.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Результат:

![Изображение TIFF с заметками докладчика](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Ознакомьтесь с бесплатным конвертером PowerPoint в плакаты от Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ru/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Могу ли я контролировать положение области заметок в итоговом TIFF?

Да. Используйте [настройки расположения заметок](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) для выбора среди вариантов `None`, `BottomTruncated` или `BottomFull`, которые соответственно скрывают заметки, помещают их на одну страницу или позволяют им переноситься на дополнительные страницы.

### Как можно уменьшить размер файла TIFF с примечаниями без заметной потери качества?

Выберите [эффективное сжатие](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (например, `LZW` или `RLE`), установите разумное значение DPI и, при возможности, используйте более низкий [формат пикселей](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (например, 8 bpp или 1 bpp для монохромных изображений). Слегка уменьшив [размер изображения](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/set_imagesize/), можно также сократить файл без заметного ухудшения читаемости.

### Влияет ли шрифт в примечаниях на результат, если оригинальные шрифты отсутствуют в системе?

Да. Отсутствующие шрифты вызывают [замену](/slides/ru/cpp/font-selection-sequence/), что может изменить метрики текста и его внешний вид. Чтобы избежать этого, [предоставьте необходимые шрифты](/slides/ru/cpp/custom-font/) или задайте шрифт по умолчанию [fallback font](/slides/ru/cpp/fallback-font/), чтобы использовались требуемые гарнитуры.