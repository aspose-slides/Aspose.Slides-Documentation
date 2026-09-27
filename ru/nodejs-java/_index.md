---
title: Aspose.Slides для Node.js через Java
second_title: Aspose.Slides для Node.js
type: docs
weight: 47
url: /ru/nodejs-java/
keywords:
- документация
- обработка презентаций
- конвертация презентаций
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides для Node.js через Java, создайте первую презентацию и найдите руководства по общим задачам, справочник API и поддержку."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides для Node.js через Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides для Node.js через Java — это библиотека для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument в приложениях Node.js без Microsoft PowerPoint.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая версии с макросами и шаблоны, и экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАЛО</p>
<ul>
<li><a href="/slides/ru/nodejs-java/installation/">Установка</a></li>
<li><a href="/slides/ru/nodejs-java/create-presentation/">Создайте свою первую презентацию</a></li>
<li><a href="/slides/ru/nodejs-java/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНИТЬ</p>
<ul>
<li><a href="/slides/ru/nodejs-java/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/nodejs-java/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/nodejs-java/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Работа со Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/nodejs-java/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/nodejs-java/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/nodejs-java/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/nodejs-java/convert-slide/">Отображать слайды как изображения</a></li>
<li><a href="/slides/ru/nodejs-java/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>РАБОЧИЕ ПРОЦЕССЫ SLIDES</p>
<ul>
<li><a href="/slides/ru/nodejs-java/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/nodejs-java/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/nodejs-java/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/nodejs-java/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/nodejs-java/merge-presentation/">Объединить презентации</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/nodejs-java/examples/">Примеры по элементам слайда</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка &amp; Поддержка</b></p>
<hr>
<p>СПРАВКА</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/nodejs-java/known-issues/">Известные проблемы</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платная служба поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваше первое представление**

Помимо Node.js 20 или новее, пакету требуется Java Development Kit (JDK), Python и набор средств построения C++, потому что npm компилирует мост `java` во время установки. См. [Установка](/slides/ru/nodejs-java/installation/) для пошаговых инструкций по каждой операционной системе. Затем создайте проект и установите пакет из npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Сохраните этот код как *hello.js* в папке проекта:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides работает в виртуальной машине Java, которая удерживает Node.js в работе, поэтому процесс следует завершить явно.
process.exit(0);
```

Запустите его командой `node hello.js`. Скрипт сохраняет *hello.pptx* с одним слайдом, содержащим текстовое поле. Без лицензии сохранённый файл будет содержать водяной знак оценки — см. [Лицензирование](/slides/ru/nodejs-java/licensing/). Для получения дополнительных способов создания и заполнения презентации см. [Создание презентаций](/slides/ru/nodejs-java/create-presentation/).