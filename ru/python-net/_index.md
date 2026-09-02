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
- Библиотека PPT для Python
- Экспорт PowerPoint в PDF на Python
- Экспорт PowerPoint в SVG на Python
- Редактирование PowerPoint в Python
- Python PowerPoint без Microsoft Office
- Управление PPTX с помощью Python
- Предпросмотр слайдов в Python
- Додавление аудио к слайдам в Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET предоставляет полный набор функций, включая управление текстом, фигурами, таблицами и анимациями, добавление аудио и видео к слайдам, предварительный просмотр слайдов и экспорт в SVG, PDF и другие форматы."
---
{{% alert color="primary" %}}

**Добро пожаловать в Aspose.Slides for Python via .NET**

![Логотип продукта Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET — это мощная библиотека классов, позволяющая вашим приложениям читать и записывать презентации PowerPoint® без необходимости установки Microsoft PowerPoint®.

Это первый и единственный компонент, предоставляющий полнофункциональное управление документами PowerPoint® для разработчиков на Python.

Aspose.Slides for Python via .NET включает широкий набор функций, таких как работа с текстом, фигурами, таблицами и анимацией; добавление аудио и видео; предварительный просмотр слайдов; экспорт слайдов в такие форматы, как SVG, PDF и другие.

{{% /alert %}}

## Установить Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Пакет поставляется с необходимой средой выполнения .NET, поэтому ничего больше устанавливать не требуется, и Microsoft PowerPoint не нужен. Python 3.7 и новее на Windows, Linux или macOS.

## Создать презентацию PowerPoint на Python

В этом примере создаётся презентация, на первый слайд добавляется фигура с текстом, а результат сохраняется как PPTX, так и PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

При запуске он записывает `presentation.pptx` (около 34 КБ) и `presentation.pdf` (около 36 КБ) в рабочий каталог.

Без лицензии библиотека работает в оценочном режиме, который добавляет водяной знак и ограничивает количество слайдов. Смотрите [Licensing](/slides/ru/python-net/licensing/) для применения лицензии.

## Ресурсы Aspose.Slides for Python via .NET

Изучите эти полезные ресурсы:

- [Aspose.Slides for Python via .NET Онлайн‑документация](/slides/ru/python-net/)
- [Aspose.Slides for Python via .NET Возможности](/slides/ru/python-net/features-overview/)
- [Aspose.Slides for Python via .NET Примечания к выпуску](https://releases.aspose.com/slides/ru/python-net/release-notes/)
- [Aspose.Slides for Python via .NET Страница продукта](https://products.aspose.com/slides/ru/python-net/)
- [Скачать Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/ru/python-net/)
- [Установить пакет Aspose.Slides for Python via .NET PyPi](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET Руководство по API](https://reference.aspose.com/slides/ru/python-net/)
- [Aspose.Slides for Python via .NET Бесплатный форум поддержки](https://forum.aspose.com/c/slides/ru/11)
- [Aspose.Slides for Python via .NET Платная служба поддержки](https://helpdesk.aspose.com/)

## Часто задаваемые вопросы

### Что такое Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET — мощная библиотека Python, позволяющая программно создавать, редактировать и конвертировать презентации PowerPoint (PPT, PPTX, ODP) без установленного Microsoft PowerPoint.

### Какие функции презентаций поддерживает Aspose.Slides?

Библиотека поддерживает работу с текстом, фигурами, таблицами, диаграммами, анимацией, шаблонами слайдов, аудио, видео и многим другим. Кроме того, она предоставляет предварительный просмотр слайдов, рендеринг, печать и экспорт в форматы, такие как PDF, SVG, HTML и изображения.

### Могу ли я конвертировать презентации в другие форматы с помощью Aspose.Slides?

Да. Aspose.Slides позволяет конвертировать файлы PowerPoint в PDF, SVG, HTML, JPG, PNG, TIFF и другие форматы с высоким качеством и производительностью.

### Требуется ли Microsoft PowerPoint для использования Aspose.Slides?

Нет. Aspose.Slides — автономный API и не требует Microsoft Office или какого‑либо стороннего программного обеспечения.

### Какие платформы поддерживает Aspose.Slides for Python via .NET?

Он кросс‑платформенный и работает в средах Windows, Linux и macOS.

### Как начать работу с Aspose.Slides for Python?

Вы можете установить её через PyPi и изучить [Developer Guide](/slides/ru/python-net/developer-guide/) для начала работы с примерами, справочниками API и учебными материалами.