---
title: Преобразование презентаций PowerPoint в документы Word на C++
linktitle: PowerPoint в Word
type: docs
weight: 110
url: /ru/cpp/convert-powerpoint-to-word/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
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
description: "Преобразуйте слайды PowerPoint PPT и PPTX в редактируемые документы Word на C++ с помощью Aspose.Slides, сохраняя точный макет, изображения и форматирование."
---

Если вы планируете использовать текстовое содержание или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно преобразовать презентацию в Word (DOC или DOCX). 

* По сравнению с Microsoft PowerPoint приложение Microsoft Word обладает более широкими инструментами и функциями для работы с содержимым. 
* Помимо функций редактирования в Word, вы также можете воспользоваться улучшенными возможностями совместной работы, печати и обмена. 

{{% alert color="primary" %}} 

Возможно, вы захотите попробовать наш [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы увидеть, что вы можете получить, работая с текстовым содержимым слайдов. 

{{% /alert %}} 

## **Aspose.Slides и Aspose.Words**

Для преобразования файла PowerPoint (PPTX или PPT) в Word (DOCX или DOCX) вам нужны как [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/), так и [Aspose.Words for C++](https://products.aspose.com/words/cpp/). 

Как отдельный API, [Aspose.Slides](https://products.aspose.app/slides) для C++ предоставляет функции, позволяющие извлекать текст из презентаций. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) — это продвинутый API обработки документов, который позволяет приложениям генерировать, изменять, конвертировать, отображать, печатать файлы и выполнять другие операции с документами без использования Microsoft Word.

## **Преобразовать презентацию PowerPoint в документ Word**

Используйте этот фрагмент кода, чтобы преобразовать PowerPoint в Word:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // генерирует и вставляет изображение слайда
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // вставляет тексты слайда
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
```


## **FAQ**

**Какие компоненты необходимо установить для конвертации презентаций PowerPoint и OpenDocument в документы Word?**

Вам достаточно добавить соответствующие пакеты [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) и [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) в ваш проект. Обе библиотеки работают как отдельные API, и установка Microsoft Office не требуется.

**Поддерживаются ли все форматы презентаций PowerPoint и OpenDocument?**

Aspose.Slides [поддерживает все форматы презентаций](/slides/ru/cpp/supported-file-formats/), включая PPT, PPTX, ODP и другие распространённые типы файлов. Это гарантирует, что вы можете работать с презентациями, созданными в разных версиях Microsoft PowerPoint.