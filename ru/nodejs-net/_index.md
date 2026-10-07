---
title: Aspose.Slides для Node.js через .NET
second_title: Aspose.Slides для Node.js
type: docs
weight: 47
url: /ru/nodejs-net/
keywords:
- документация
- обработка презентаций
- конверсия презентаций
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides for Node.js via .NET, создайте первую презентацию и найдите руководства по общим задачам, лицензированию, справочнику API и поддержке."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET — это библиотека для создания, чтения, редактирования и конвертирования презентаций PowerPoint и OpenDocument в приложениях Node.js, без Microsoft PowerPoint или автоматизации Office. Она запускает Aspose.Slides for .NET через мост edge-js, поэтому её JavaScript API отражает .NET API с именами членов в стиле camelCase.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая версии с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/ru/nodejs-net/installation/">Installation</a></li>
<li><a href="/slides/ru/nodejs-net/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/ru/nodejs-net/developer-guide/">Developer guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/ru/nodejs-net/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/ru/nodejs-net/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/ru/nodejs-net/open-presentation/">Open and save a presentation</a></li>
<li><a href="/slides/ru/nodejs-net/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/ru/nodejs-net/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/ru/nodejs-net/manage-text/">Edit text</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API reference</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Release notes</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Product page</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **Your first presentation**

Вам нужны Node.js 22 или 24 и .NET SDK 8 или новее; для Linux также требуются несколько системных пакетов. [Installation](/slides/ru/nodejs-net/installation/) перечисляет их и платформы, которые были протестированы. Создайте проект, добавьте переопределение, которое указывает npm, какую версию edge-js установить, и установите пакет:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Один раз на машину, восстановите .NET‑пакеты, от которых зависит библиотека. Сохраните файл `deps.csproj` из [Restore the .NET Dependencies](/slides/ru/nodejs-net/installation/#restore-the-net-dependencies) в папку `deps` внутри папки проекта, затем выполните:

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

Скрипт выводит `Saved hello.pptx` и сохраняет *hello.pptx* с одним слайдом, содержащим прямоугольник с текстом. Без лицензии сохранённый файл содержит водяной знак оценки — см. [Licensing](/slides/ru/nodejs-net/licensing/). Чтобы узнать о дополнительных способах создания и заполнения презентации, см. [Create a Presentation](/slides/ru/nodejs-net/create-presentation/).