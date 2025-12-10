---
title: Автоматизировать локализацию презентаций в .NET
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/net/presentation-localization/
keywords:
- смена языка
- проверка правописания
- идентификатор языка
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Автоматизировать локализацию слайдов PowerPoint и OpenDocument в .NET с помощью Aspose.Slides, используя практические образцы кода C# и советы для более быстрого глобального развертывания."
---

## **Изменение языка для презентации и текста фигуры**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Rectangle на слайд.
- Добавьте текст в TextFrame.
- Установите Language Id для текста.
- Запишите презентацию в файл PPTX.

Реализация указанных выше шагов демонстрируется ниже в примере.
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

**Вызывает ли Language ID автоматический перевод текста?**

Нет. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) в Aspose.Slides сохраняет язык для проверки правописания и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли Language ID на переносы и разрывы строк при рендеринге?**

В Aspose.Slides [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) используется для проверки. Качество переноса слов и перенос строк в основном зависят от наличия [proper fonts](/slides/ru/net/powerpoint-fonts/) и настроек разметки/переноса для системы письма. Чтобы обеспечить правильный рендеринг, сделайте нужные шрифты доступными, настройте [font substitution rules](/slides/ru/net/font-substitution/) и/или [embed fonts](/slides/ru/net/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Да. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с отдельными настройками проверки.