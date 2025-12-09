---
title: Автоматизация локализации презентаций в .NET
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/net/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- идентификатор языка
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument в .NET с помощью Aspose.Slides, используя практические примеры кода C# и советы для более быстрой глобальной развертки."
---

## **Изменение языка для текста презентации и формы**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape прямоугольного типа на слайд.
- Добавьте некоторый текст в TextFrame.
- Установите LanguageId для текста.
- Сохраните презентацию в виде файла PPTX.

Реализация вышеуказанных шагов показана ниже в примере.
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

**Вызывает ли LanguageId автоматический перевод текста?**

Нет. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) в Aspose.Slides хранит информацию о языке для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли LanguageId на переносы и разбиение строк при рендеринге?**

В Aspose.Slides [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) предназначен для проверки. Качество переносов и переносов строк в основном зависит от доступности [правильных шрифтов](/slides/ru/net/powerpoint-fonts/) и настроек разметки/переноса для системы написания. Чтобы обеспечить корректный рендеринг, сделайте требуемые шрифты доступными, настройте [правила подстановки шрифтов](/slides/ru/net/font-substitution/) и/или [встроите шрифты](/slides/ru/net/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Да. [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с различными настройками проверки.