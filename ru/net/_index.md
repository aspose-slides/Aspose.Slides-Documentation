---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
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
description: "Начните здесь: установите Aspose.Slides for .NET, создайте первую презентацию и найдите руководства по общим задачам, развёртыванию и справочнику API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET — это библиотека классов для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument в приложениях .NET без Microsoft PowerPoint или Office Automation.

Она загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая версии с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начать работу</b></p>
<hr>
<p>Начало работы</p>
<ul>
<li><a href="/slides/ru/net/installation/">Установка</a></li>
<li><a href="/slides/ru/net/create-presentation/">Создайте свою первую презентацию</a></li>
<li><a href="/slides/ru/net/system-requirements/">Системные требования</a></li>
<li><a href="/slides/ru/net/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНКА</p>
<ul>
<li><a href="/slides/ru/net/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/net/features-overview/">Обзор функций</a></li>
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
<li><a href="/slides/ru/net/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/net/convert-slide/">Отрисовать слайды как изображения</a></li>
<li><a href="/slides/ru/net/manage-text/">Редактировать текст и формы</a></li>
</ul>
<p>Рабочие процессы Slides</p>
<ul>
<li><a href="/slides/ru/net/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/net/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/net/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/net/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/net/merge-presentation/">Объединить презентации</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/net/examples/">Примеры по элементам слайдов</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Примеры на GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Развёртывание и поддержка</b></p>
<hr>
<p>РАЗВЁРТЫВАНИЕ</p>
<ul>
<li><a href="/slides/ru/net/net6/">Кроссплатформенно (.NET 6+)</a></li>
<li><a href="/slides/ru/net/how-to-run-aspose-slides-in-docker/">Запуск в Docker</a></li>
<li><a href="/slides/ru/net/deploy-fonts/">Шрифты</a></li>
<li><a href="/slides/ru/net/security/">Безопасность</a></li>
</ul>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ru/net/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/ru/net/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/net/known-issues/">Известные проблемы</a></li>
<li><a href="/slides/ru/net/api-limitations/">Ограничения метаданных вывода</a></li>
<li><a href="https://releases.aspose.com/slides/ru/net/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ru/11">Форум бесплатной поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платная поддержка</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Ваша первая презентация**

Создайте консольное приложение с .NET SDK 6 или более новой версией:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Затем добавьте один пакет для вашей платформы:

- В Windows: `dotnet add package Aspose.Slides.NET`
- В Linux и macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — см. [Installation](/slides/ru/net/installation/) для предварительных требований Linux и для систем, которым нужен Aspose.Slides.NET вместо этого.

Замените содержимое *Program.cs* этим кодом и запустите `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Программа сохраняет *hello.pptx* с одним слайдом, содержащим текстовое поле. Без лицензии сохранённый файл содержит водяной знак оценки — см. [Licensing](/slides/ru/net/licensing/). Для получения дополнительных способов создания и заполнения презентации см. [Create Presentations](/slides/ru/net/create-presentation/).