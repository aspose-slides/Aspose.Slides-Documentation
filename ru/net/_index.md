---
title: Aspose.Slides для .NET
second_title: Aspose.Slides для .NET
type: docs
weight: 10
url: /ru/net/
keywords:
- документация
- обработка презентаций
- конвертация презентаций
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides for .NET, создайте первую презентацию и найдите руководства по общим задачам, справочник API и поддержку."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET — это библиотека классов для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument в приложениях .NET без Microsoft PowerPoint или автоматизации Office.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая версии с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начало работы</b></p>
<hr>
<p>НАЧАЛО РАБОТЫ</p>
<ul>
<li><a href="/slides/ru/net/installation/">Установка</a></li>
<li><a href="/slides/ru/net/create-presentation/">Создание первой презентации</a></li>
<li><a href="/slides/ru/net/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНКА</p>
<ul>
<li><a href="/slides/ru/net/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/net/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/net/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/net/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/net/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/net/convert-powerpoint-to-pdf/">Преобразовать в PDF</a></li>
<li><a href="/slides/ru/net/convert-slide/">Отобразить слайды как изображения</a></li>
<li><a href="/slides/ru/net/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>РАБОЧИЕ ПРОЦЕССЫ SLIDES</p>
<ul>
<li><a href="/slides/ru/net/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/net/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/net/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/net/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/net/merge-presentation/">Объединить презентации</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/net/examples/">Примеры по элементам слайда</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Примеры на GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка и Поддержка</b></p>
<hr>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API справочник</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/net/known-issues/">Известные проблемы</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платный сервис поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваша первая презентация**

Создайте консольное приложение с .NET SDK 6 или более поздней версии:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Затем добавьте один пакет для вашей платформы:

- Для Windows: `dotnet add package Aspose.Slides.NET`
- Для Linux и macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — см.[Установка](/slides/ru/net/installation/) для предварительных требований Linux и для систем, которым нужен Aspose.Slides.NET вместо этого.

Замените содержимое *Program.cs* этим кодом и выполните `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Программа сохраняет *hello.pptx* с одним слайдом, содержащим текстовое поле. Без лицензии сохранённый файл содержит водяной знак оценки — см.[Лицензирование](/slides/ru/net/licensing/). Для получения дополнительных способов создания и заполнения презентации см.[Создание презентаций](/slides/ru/net/create-presentation/).