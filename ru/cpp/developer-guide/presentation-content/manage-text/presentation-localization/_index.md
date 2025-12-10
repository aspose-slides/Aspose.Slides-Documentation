---
title: Автоматизация локализации презентаций в C++
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/cpp/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- идентификатор языка
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument в C++ с помощью Aspose.Slides, используя практические примеры кода и рекомендации для более быстрой глобальной поставки."
---

## **Изменение языка для презентации и текста фигуры**
- Создайте экземпляр [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) класса.  
- Получите ссылку на слайд, используя его Index.  
- Добавьте AutoShape типа Rectangle на слайд.  
- Добавьте некоторый текст в TextFrame.  
- Установите Language Id для текста.  
- Сохраните презентацию в файл PPTX.

Реализация вышеописанных шагов демонстрируется ниже в примере.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Вызывает ли Language ID автоматический перевод текста?**

No. [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли Language ID на переносы и разбиение строк при рендеринге?**

В Aspose.Slides, [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) предназначен для проверки. Качество переноса слов и перенос строк в основном зависят от наличия [правильных шрифтов](/slides/ru/cpp/powerpoint-fonts/) и настроек разметки/разделения строк для системы письма. Чтобы обеспечить корректный рендеринг, предоставьте необходимые шрифты, настройте [правила подстановки шрифтов](/slides/ru/cpp/font-substitution/) и/или [встраивание шрифтов](/slides/ru/cpp/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Yes. [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) применяется к уровню текстовой части, поэтому в одном абзаце можно смешивать несколько языков с различными настройками проверки.