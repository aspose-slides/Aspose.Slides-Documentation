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
- Редактирование PowerPoint на Python
- PowerPoint для Python без Microsoft Office
- Управление PPTX с помощью Python
- Предпросмотр слайдов на Python
- Добавление аудио в слайды на Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides for Python via .NET, создайте первую презентацию и найдите руководства по общим задачам, справочник API и поддержку."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET — это библиотека Python для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument без Microsoft PowerPoint или Microsoft Office.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая варианты с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАЛО РАБОТЫ</p>
<ul>
<li><a href="/slides/ru/python-net/installation/">Установка</a></li>
<li><a href="/slides/ru/python-net/create-presentation/">Создайте вашу первую презентацию</a></li>
<li><a href="/slides/ru/python-net/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНКА</p>
<ul>
<li><a href="/slides/ru/python-net/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/python-net/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/python-net/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/python-net/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/python-net/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/python-net/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/python-net/convert-slide/">Отображать слайды как изображения</a></li>
<li><a href="/slides/ru/python-net/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>РАБОЧИЕ ПРОЦЕССЫ SLIDES</p>
<ul>
<li><a href="/slides/ru/python-net/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/python-net/powerpoint-animation/">Анимация</a></li>
<li><a href="/slides/ru/python-net/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/python-net/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/python-net/merge-presentation/">Объединение презентаций</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/python-net/examples/">Примеры по элементам слайда</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Примеры на GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка и поддержка</b></p>
<hr>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API‑справочник</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Примечания к выпуску</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Страница продукта</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Форум бесплатной поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платная техподдержка</a></li>
</ul>
</div>
</div>

------

## **Ваша первая презентация**

Установите пакет из PyPI:

```bash
pip install aspose.slides
```

Пакет включает используемую .NET‑runtime, поэтому отдельная установка .NET не требуется. В Linux также установите библиотеки libgdiplus и ICU, а при работе с системным Python в Debian или Ubuntu запускать команду в виртуальном окружении. macOS имеет дополнительные требования, и установка на этой системе не проверялась. Смотрите [Установка](/slides/ru/python-net/installation/) для получения команд, требований к macOS и поддерживаемых версий Python.

Сохраните следующий код как *hello.py*:

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить автофигуру типа CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Сохранить презентацию в файл PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Запустите его командой `python hello.py`. Скрипт сохраняет *new_presentation.pptx* в текущей папке, создавая один слайд с облачной фигурой, на которой написано «Hello, Aspose!». Без лицензии сохранённый файл содержит водяной знак оценки — см. [Лицензирование](/slides/ru/python-net/licensing/). Для получения дополнительных способов создания и заполнения презентации смотрите [Создание презентаций](/slides/ru/python-net/create-presentation/).