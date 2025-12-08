---
title: Локализация презентаций
type: docs
weight: 100
url: /ru/net/presentation-localization/
keywords: "Смена языка, Проверка орфографии, Проверка правописания, Орфографический проверщик, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Смена или проверка языка в презентации PowerPoint. Проверка орфографии текста на C# или .NET"
---

## **Изменение языка текста в презентации и форме**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Rectangle на слайд.
- Добавьте текст в TextFrame.
- Установите Language Id для текста.
- Сохраните презентацию в файл PPTX.

Реализация указанных шагов продемонстрирована ниже в примере.
```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Влияет ли Language ID на автоматический перевод текста?**

Нет. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли Language ID на переносы и разбиение строк при рендеринге?**

В Aspose.Slides [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) используется для проверки. Качество переносов и разбиения строк в основном зависит от наличия подходящих шрифтов и параметров разметки/разбиения строк для системы письма. Чтобы обеспечить правильный рендеринг, обеспечьте доступность необходимых шрифтов, настройте [font substitution rules](/slides/ru/net/font-substitution/), и/или [embed fonts](/slides/ru/net/embedded-font/) в презентацию.

**Можно ли задать разные языки в пределах одного абзаца?**

Да. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с разными настройками проверки.
