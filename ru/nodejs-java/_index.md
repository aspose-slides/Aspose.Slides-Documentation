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
description: "Начните здесь: установите Aspose.Slides for Node.js via Java, создайте первую презентацию и найдите руководства по типовым задачам, справочнику API и поддержке."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java — это библиотека для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument в приложениях Node.js без использования Microsoft PowerPoint.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая версии с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/ru/nodejs-java/installation/">Установка</a></li>
<li><a href="/slides/ru/nodejs-java/create-presentation/">Создание первой презентации</a></li>
<li><a href="/slides/ru/nodejs-java/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/ru/nodejs-java/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/nodejs-java/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/nodejs-java/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Работа со Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/ru/nodejs-java/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/nodejs-java/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/nodejs-java/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/nodejs-java/convert-slide/">Рендеринг слайдов в изображения</a></li>
<li><a href="/slides/ru/nodejs-java/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/ru/nodejs-java/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/nodejs-java/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/nodejs-java/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/nodejs-java/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/nodejs-java/merge-presentation/">Объединение презентаций</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/ru/nodejs-java/examples/">Примеры по элементам слайдов</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка & Поддержка</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/nodejs-java/known-issues/">Известные проблемы</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">Страница продукта</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Загрузка</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платная служба поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваша первая презентация**

Помимо Node.js 20 или новее, пакету требуется набор для разработки Java (JDK), Python и инструментарий C++ — потому что npm компилирует мост `java` во время установки. Смотрите [Installation](/slides/ru/nodejs-java/installation/) для инструкций под каждую операционную систему. Затем создайте проект и установите пакет из npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Сохраните следующий код как *hello.js* в папке проекта:

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

// Aspose.Slides работает в виртуальной машине Java, которая удерживает Node.js запущенным, поэтому завершите процесс явно.
process.exit(0);
```

Запустите его командой `node hello.js`. Скрипт сохраняет *hello.pptx* с одним слайдом, содержащим текстовое поле. Без лицензии сохранённый файл будет помечен водяным знаком оценки — см. [Licensing](/slides/ru/nodejs-java/licensing/). Для получения дополнительных способов создания и заполнения презентаций см. [Create Presentations](/slides/ru/nodejs-java/create-presentation/).