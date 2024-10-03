---
title: Перемещение абзаца из одной презентации в другую
type: docs
weight: 130
url: /ru/net/move-a-paragraph-from-one-presentation-to-another/
---

## **OpenXML Презентация**
``` csharp

  string FilePath = @"..\..\..\..\Примеры Файлов\";

string FileName = FilePath + "Перемещение абзаца из одной презентации в другую 1.pptx";

string DestFileName = FilePath + "Перемещение абзаца из одной презентации в другую 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Перемещает диапазон абзацев в фигуре TextBody в исходном документе

// в другую фигуру TextBody в целевом документе.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Открываем исходный файл для чтения/записи.

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // Открываем целевой файл для чтения/записи.

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Получаем первый слайд в исходной презентации.

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // Получаем первую фигуру TextBody в ней.

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // Получаем первый абзац в фигуре TextBody.

        // Примечание: "Drawing" является псевдонимом пространства имен DocumentFormat.OpenXml.Drawing

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // Получаем первый слайд в целевой презентации.

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // Получаем первую фигуру TextBody в ней.

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // Клонируем исходный абзац и вставляем клонированный абзац в целевую фигуру TextBody.

        // Передача "true" создает глубокое клонирование, что создает копию

        // объекта Paragraph и всего, что на него ссылается непосредственно или косвенно.

        textBody2.Append(p1.CloneNode(true));

        // Удаляем исходный абзац из исходного файла.

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // Заменяем удаленный абзац на заполнитель.

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // Сохраняем слайд в исходном файле.

        slide1.Slide.Save();

        // Сохраняем слайд в целевом файле.

        slide2.Slide.Save();

    }

}

}

// Получаем часть слайда первого слайда в документе презентации.

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Получаем ID отношения первого слайда

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Получаем часть слайда по ID отношения.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
Не редкость, когда разработчики нуждаются в извлечении текста из презентации. Для этого вам нужно извлечь текст из всех фигур на всех слайдах в презентации. Эта статья объясняет, как извлекать текст из презентаций Microsoft PowerPoint PPTX с использованием Aspose.Slides. Будь то извлечение текста из одного слайда или всей презентации, Aspose.Slides использует класс PresentationScanner и статические методы, которые он предоставляет. Все они сгруппированы под пространством имен [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Примеры Файлов\";

string FileName = FilePath + "Перемещение абзаца из одной презентации в другую 1.pptx";

string DestFileName = FilePath + "Перемещение абзаца из одной презентации в другую 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Перемещает диапазон абзацев в фигуре TextBody в исходном документе

// в другую фигуру TextBody в целевом документе.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    // Создаем экземпляр класса Presentation, который представляет PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    // Получаем первую фигуру на первом слайде

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        // Получаем текст из заполнителя

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    // Получаем первую фигуру на первом слайде

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        // Получаем текст из заполнителя

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   

``` 
## **Скачать работающий пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Move a Paragraph/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)