---
title: Aspose.Slides для Node.js через .NET
second_title: Aspose.Slides для Node.js
type: docs
weight: 47
url: /ru/nodejs-net/
keywords:
- документация
- обработка презентаций
- преобразование презентаций
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides for Node.js via .NET, создайте первую презентацию и найдите руководства по общим задачам, лицензированию, справочнику API и поддержке."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides для Node.js через .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET — это библиотека для создания, чтения, редактирования и преобразования презентаций PowerPoint и OpenDocument в приложениях Node.js, без Microsoft PowerPoint или автоматизации Office. Она запускает Aspose.Slides for .NET через мост edge-js, поэтому её JavaScript API отражает .NET API с именами членов в camelCase.

Библиотека загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая варианты с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАЛО РАБОТЫ</p>
<ul>
<li><a href="/slides/ru/nodejs-net/installation/">Установка</a></li>
<li><a href="/slides/ru/nodejs-net/create-presentation/">Создайте свою первую презентацию</a></li>
<li><a href="/slides/ru/nodejs-net/developer-guide/">Руководство разработчика</a></li>
</ul>
<p>ОЦЕНИТЬ</p>
<ul>
<li><a href="/slides/ru/nodejs-net/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/nodejs-net/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/nodejs-net/open-presentation/">Открыть и сохранить презентацию</a></li>
<li><a href="/slides/ru/nodejs-net/convert-powerpoint-to-pdf/">Преобразовать в PDF</a></li>
<li><a href="/slides/ru/nodejs-net/convert-slide/">Отрисовать слайды как изображения</a></li>
<li><a href="/slides/ru/nodejs-net/manage-text/">Редактировать текст</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка &amp; Поддержка</b></p>
<hr>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Справочник .NET API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Примечания к выпуску</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Скачать</a></li>
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

Вам требуется Node.js 22 или 24 и .NET SDK 8 или новее; для Linux также необходимы несколько системных пакетов. [Установка](/slides/ru/nodejs-net/installation/) перечисляет их и проверенные платформы. Создайте проект, добавьте переопределение, которое указывает npm, какую версию edge-js установить, и установите пакет:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Один раз на машину восстановите пакеты .NET, от которых зависит библиотека. Сохраните файл `deps.csproj` из [Восстановить зависимости .NET](/slides/ru/nodejs-net/installation/#restore-the-net-dependencies) в папку `deps` внутри папки проекта, затем выполните:

```sh
dotnet restore deps/deps.csproj
```

Сохраните этот код как *hello.js* в папке проекта:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Новая презентация содержит один пустой слайд.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Позиция и размер указаны в пунктах (1/72 дюйма): x, y, ширина, высота.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Освободить объект .NET, который поддерживает презентацию.
    presentation.dispose();
}
```

Запустите его из папки проекта:

```sh
node hello.js
```

Скрипт выводит `Saved hello.pptx` и сохраняет *hello.pptx* с одним слайдом, содержащим прямоугольник с текстом. Без лицензии сохранённый файл содержит водяной знак оценки — см. [Лицензирование](/slides/ru/nodejs-net/licensing/). Для получения дополнительных способов создания и заполнения презентации см. [Создание презентации](/slides/ru/nodejs-net/create-presentation/).