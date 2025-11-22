---
title: Локализация презентации
type: docs
weight: 100
url: /ru/net/presentation-localization/
keywords: "Изменить язык, Проверка орфографии, Проверка орфографии, Проверка орфографии, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Изменить или проверить язык в презентации PowerPoint. Проверка орфографии текста в C# или .NET"
---

## **Изменить язык текста презентации и фигуры**
- Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получить ссылку на слайд, используя его Index.
- Добавить AutoShape типа Rectangle на слайд.
- Добавить некоторый текст в TextFrame.
- Установить LanguageId для текста.
- Записать презентацию в файл PPTX.

Реализация вышеуказанных шагов демонстрируется ниже в примере.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Часто задаваемые вопросы**

**Вызывает ли language_id автоматический перевод текста?**

Нет. [language_id](https://reference.aspose.com/slides/net/aspose.slides/portionformat/languageid/) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли language_id на переносы слов и разрывы строк при рендеринге?**

В Aspose.Slides [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) используется для проверки правописания. Качество переноса слов и разрыва строк в основном зависит от наличия [соответствующих шрифтов](/slides/ru/net/powerpoint-fonts/) и настроек разметки/переноса строк для системы письма. Чтобы обеспечить корректный рендеринг, сделайте необходимые шрифты доступными, настройте [правила замены шрифтов](/slides/ru/net/font-substitution/) и/или [встроить шрифты](/slides/ru/net/embedded-font/) в презентацию.

**Могу ли я задать разные языки в одном абзаце?**

Да. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с различными настройками проверки.