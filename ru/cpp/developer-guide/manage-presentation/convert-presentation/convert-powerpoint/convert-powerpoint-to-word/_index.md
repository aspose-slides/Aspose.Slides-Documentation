---
title: Преобразование PowerPoint в Word
type: docs
weight: 110
url: /cpp/convert-powerpoint-to-word/
keywords: "Преобразовать PowerPoint, PPT, PPTX, Презентация, Word, DOCX, DOC, PPTX в DOCX, PPT в DOC, PPTX в DOC, PPT в DOCX, C++, Aspose.Slides"
description: "Преобразуйте презентацию PowerPoint в Word на C++"
---

Если вы планируете использовать текстовое содержимое или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно преобразовать презентацию в Word (DOC или DOCX).

* По сравнению с Microsoft PowerPoint, приложение Microsoft Word более оснащено инструментами или функциональностью для работы с содержимым.
* Кроме функций редактирования в Word, вы также можете извлечь выгоду от улучшенного сотрудничества, печати и функций обмена.

{{% alert color="primary" %}} 

Вы можете попробовать наш [**Онлайн-конвертер Презентация в Word**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы увидеть, что вы можете получить от работы с текстовым содержимым слайдов.

{{% /alert %}} 

### **Aspose.Slides и Aspose.Words**

Для преобразования файла PowerPoint (PPTX или PPT) в Word (DOCX или DOC) вам нужны обе библиотеки [Aspose.Slides для C++](https://products.aspose.com/slides/cpp/) и [Aspose.Words для C++](https://products.aspose.com/words/cpp/).

Как самостоятельный API, [Aspose.Slides](https://products.aspose.app/slides) для C++ предоставляет функции, которые позволяют извлекать тексты из презентаций.

[Aspose.Words](https://docs.aspose.com/words/cpp/) — это продвинутый API для обработки документов, который позволяет приложениям генерировать, изменять, преобразовывать, рендерить, печатать файлы и выполнять другие задачи с документами без использования Microsoft Word.

## **Преобразование PowerPoint в Word**

Используйте этот фрагмент кода для преобразования PowerPoint в Word:

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