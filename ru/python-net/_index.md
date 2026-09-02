---
title: Aspose.Slides для Python через .NET
second_title: Aspose.Slides для Python
type: docs
weight: 35
url: /ru/python-net/
is_root: true
keywords:
- Aspose.Slides для Python
- Автоматизация PowerPoint на Python
- Библиотека Python PPT
- Экспорт PowerPoint в PDF на Python
- Экспорт PowerPoint в SVG на Python
- Редактирование PowerPoint в Python
- Python PowerPoint без Microsoft Office
- Управление PPTX с помощью Python
- Предпросмотр слайдов в Python
- Python добавление аудио в слайды
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET предоставляет полный набор функций, включая работу с текстом, фигурами, таблицами и анимациями, добавление аудио и видео в слайды, предварительный просмотр слайдов и экспорт в SVG, PDF и другие форматы."
---
{{% alert color="info" %}}

**Добро пожаловать в Aspose.Slides for Python via .NET**

![Логотип продукта Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET — это надёжная библиотека классов, позволяющая вашим приложениям читать и записывать презентации PowerPoint® без необходимости использовать Microsoft PowerPoint®.

Это первый и единственный компонент, предоставляющий полнофункциональное управление документами PowerPoint® для разработчиков на Python.

Aspose.Slides for Python via .NET включает широкий набор функций, таких как работа с текстом, фигурами, таблицами и анимациями; добавление аудио и видео; предварительный просмотр слайдов; а также экспорт слайдов в форматы, такие как SVG, PDF и другие.

{{% /alert %}}

## Установка Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Пакет поставляется со всеми необходимыми компонентами .NET, поэтому ничего дополнительно устанавливать не требуется, и Microsoft PowerPoint не нужен. Python 3.7 или новее на Windows, Linux или macOS.

## Создание презентации PowerPoint в Python

В этом примере создаётся презентация, на первый слайд добавляется фигура с текстом, а результат сохраняется как в формате PPTX, так и PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

После выполнения будет записан файл `presentation.pptx` (≈ 34 KB) и `presentation.pdf` (≈ 36 KB) в текущий рабочий каталог.

Без лицензии библиотека работает в оценочном режиме, который добавляет водяной знак и ограничивает количество слайдов. Смотрите [Licensing](/slides/ru/python-net/licensing/) для получения лицензии.

## Ресурсы Aspose.Slides for Python via .NET

Изучите эти полезные ресурсы:

- [Документация Aspose.Slides for Python via .NET онлайн](/slides/ru/python-net/)
- [Функции Aspose.Slides for Python via .NET](/slides/ru/python-net/features-overview/)
- [Примечания к выпуску Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/ru/python-net/release-notes/)
- [Страница продукта Aspose.Slides for Python via .NET](https://products.aspose.com/slides/ru/python-net/)
- [Скачать Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/ru/python-net/)
- [Установить пакет PyPi Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/)
- [Справочник API Aspose.Slides for Python via .NET](https://reference.aspose.com/slides/ru/python-net/)
- [Бесплатный форум поддержки Aspose.Slides for Python via .NET](https://forum.aspose.com/c/slides/ru/11)
- [Платный сервис поддержки Aspose.Slides for Python via .NET](https://helpdesk.aspose.com/)

## Часто задаваемые вопросы

### Что такое Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET — это мощная библиотека Python, позволяющая программно создавать, редактировать и конвертировать презентации PowerPoint (PPT, PPTX, ODP) без установки Microsoft PowerPoint.

### Какие функции презентаций поддерживает Aspose.Slides?

Библиотека поддерживает работу с текстом, фигурами, таблицами, диаграммами, анимациями, шаблонами слайдов, аудио, видео и многим другим. Она также позволяет просматривать слайды, выполнять их рендеринг и экспортировать в форматы PDF, SVG, HTML и изображения.

### Можно ли конвертировать презентации в другие форматы с помощью Aspose.Slides?

Да. Aspose.Slides позволяет конвертировать файлы PowerPoint в PDF, SVG, HTML, JPG, PNG, TIFF и другие форматы с высоким качеством и производительностью.

### Требуется ли Microsoft PowerPoint для использования Aspose.Slides?

Нет. Aspose.Slides — независимый API и не требует Microsoft Office или любого стороннего программного обеспечения.

### Какие платформы поддерживает Aspose.Slides for Python via .NET?

Он кросс‑платформенный и работает в средах Windows, Linux и macOS.

### Как начать работу с Aspose.Slides for Python?

Вы можете установить его через PyPi и ознакомиться с [Руководством разработчика](/slides/ru/python-net/developer-guide/), чтобы начать с примеров, справочников API и учебных материалов.