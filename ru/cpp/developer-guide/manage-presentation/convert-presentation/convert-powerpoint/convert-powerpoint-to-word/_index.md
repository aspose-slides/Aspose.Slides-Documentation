---
title: Конвертировать презентации PowerPoint в документы Word на C++
linktitle: PowerPoint в Word
type: docs
weight: 110
url: /ru/cpp/convert-powerpoint-to-word/
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
- C++
- Aspose.Slides
description: "Конвертировать слайды PowerPoint PPT и PPTX в редактируемые документы Word на C++ с использованием Aspose.Slides, сохраняющие точное расположение, изображения и форматирование."
---
## **Введение**

Если вы планируете использовать текстовое содержание или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно преобразовать презентацию в Word (DOC или DOCX). 

* По сравнению с Microsoft PowerPoint, приложение Microsoft Word более оснащено инструментами и функциями для работы с содержимым. 
* Кроме функций редактирования в Word, вы также получаете преимущества улучшенного взаимодействия, печати и совместного использования. 

{{% alert color="info" %}} 

Вы можете попробовать наш [**Конвертер презентаций в Word онлайн**](https://products.aspose.app/slides/ru/conversion/ppt-to-word), чтобы увидеть, что вы можете получить, работая с текстовым содержимым слайдов. 

{{% /alert %}} 

## **Aspose.Slides и Aspose.Words**

Для преобразования файла PowerPoint (PPTX или PPT) в Word (DOCX или DOC) вам нужны как [Aspose.Slides for C++](https://products.aspose.com/slides/ru/cpp/) , так и [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Как независимый API, [Aspose.Slides](https://products.aspose.app/slides) for C++ предоставляет функции, позволяющие извлекать текст из презентаций. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) — это расширенный API обработки документов, который позволяет приложениям создавать, изменять, конвертировать, визуализировать, печатать файлы и выполнять другие задачи с документами без использования Microsoft Word.

## **Преобразовать презентацию PowerPoint в документ Word**

Используйте этот фрагмент кода для преобразования PowerPoint в Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // генерирует изображение слайда как поток байтов
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // вставляет текст слайда
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### Какие компоненты необходимо установить для преобразования презентаций PowerPoint и OpenDocument в документы Word?

Вам нужно добавить соответствующие пакеты для [Aspose.Slides for C++](https://releases.aspose.com/slides/ru/cpp/) и [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) в ваш проект. Обе библиотеки работают как самостоятельные API, и установка Microsoft Office не требуется.

### Поддерживаются ли все форматы презентаций PowerPoint и OpenDocument?

Aspose.Slides [поддерживает все форматы презентаций](/slides/ru/cpp/supported-file-formats/), включая PPT, PPTX, ODP и другие распространённые типы файлов. Это гарантирует, что вы можете работать с презентациями, созданными в различных версиях Microsoft PowerPoint.