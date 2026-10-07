---
title: Aspose.Slides для Python через Java
second_title: Aspose.Slides для Python
type: docs
weight: 47
url: /ru/python-java/
is_root: true
keywords:
- Aspose.Slides для Python через Java
- Библиотека PowerPoint для Python
- управление презентациями PowerPoint в Python
- чтение и запись PowerPoint в Python
- редактирование слайдов PowerPoint в Python
- экспорт PowerPoint в PDF в Python
- экспорт PowerPoint в SVG в Python
- предварительный просмотр слайдов в Python
- добавление аудио и видео в слайды в Python
- PowerPoint без Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides для Python через Java, создайте первую презентацию и найдите руководства по общим задачам, справочник API и поддержку."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java — это библиотека для создания, чтения, редактирования и конвертирования презентаций PowerPoint и OpenDocument в Python‑приложениях без Microsoft PowerPoint; она запускает движок Aspose.Slides Java в вашем процессе Python через JPype.

Он загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая версии с макросами и шаблоны, и экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАТЬ РАБОТУ</p>
<ul>
<li><a href="/slides/ru/python-java/installation/">Установка</a></li>
<li><a href="/slides/ru/python-java/create-presentation/">Создайте свою первую презентацию</a></li>
<li><a href="/slides/ru/python-java/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНКА</p>
<ul>
<li><a href="/slides/ru/python-java/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/python-java/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/python-java/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с помощью Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/python-java/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/python-java/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/python-java/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/python-java/convert-slide/">Отображать слайды как изображения</a></li>
<li><a href="/slides/ru/python-java/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>РАБОЧИЕ ПРОЦЕССЫ</p>
<ul>
<li><a href="/slides/ru/python-java/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/python-java/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/python-java/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/python-java/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/python-java/merge-presentation/">Объединить презентации</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/python-java/examples/">Примеры по элементам слайда</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка &amp; Поддержка</b></p>
<hr>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/python-java/known-issues/">Известные проблемы</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Страница продукта</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платный центр поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваша первая презентация**

Установите Python и JDK, задайте `JAVA_HOME` и создайте и активируйте виртуальное окружение, как описано в [Installation](/slides/ru/python-java/installation/). Затем установите JPype и Aspose.Slides из PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Сохраните этот код как *hello.py*. Он запускает виртуальную машину Java, добавляет облако с текстом на первый слайд новой презентации и сохраняет презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Создать презентацию с одним пустым слайдом.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить форму облака и установить её текст.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Сохранить презентацию как файл PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Запустите его в том же виртуальном окружении:

```sh
python hello.py
```

Скрипт сохраняет *new_presentation.pptx* с одним слайдом, содержащим облако с текстом "Hello, Aspose!". Без лицензии сохранённый файл также содержит водяной знак оценки — смотрите [Лицензирование](/slides/ru/python-java/licensing/). Для получения дополнительных способов создания и заполнения презентации см. [Создание презентаций](/slides/ru/python-java/create-presentation/).