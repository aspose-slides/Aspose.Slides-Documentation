---
title: Обзор функций
type: docs
weight: 94
url: /ru/net/features-overview/
keywords:
- функции
- поддерживаемые платформы
- форматы файлов
- конверсия
- рендеринг
- содержание презентации
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор того, что охватывает Aspose.Slides for .NET перед оценкой: поддерживаемые платформы, форматы файлов, рендеринг слайдов и содержимое, которое вы можете создавать и редактировать."
---
## **Обзор**

Aspose.Slides for .NET — это библиотека классов для создания, чтения, редактирования, конвертации и рендеринга презентаций PowerPoint и OpenDocument. У неё нет собственного пользовательского интерфейса и она не требует Microsoft PowerPoint или Office, поэтому вы можете использовать её в консольных приложениях, настольных приложениях, таких как Windows Forms, веб‑приложениях и веб‑службах. Эта статья суммирует, что покрывает библиотека, и содержит ссылки на статьи, описывающие каждую область.

## **Поддерживаемые платформы**

Aspose.Slides for .NET распространяется в виде двух пакетов NuGet с одинаковым API:

|**Пакет**|**Сборки в пакете**|**Операционные системы**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 и .NET 6. Используйте с .NET Framework 4.6.2 или более новой версией, либо с .NET 6 и новее.|Windows. Linux и macOS с библиотекой `libgdiplus` и переключателем `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Используйте с .NET 6 и новее.|Windows (x86, x64), Linux (x64 с glibc 2.23 или новее, ARM64 с glibc 2.39 или новее) и macOS (x64, ARM64).|

[Установка](/slides/ru/net/installation/) объясняет, какой пакет выбрать и что требуется для каждого из них в Linux. [Системные требования](/slides/ru/net/system-requirements/) перечисляют поддерживаемые платформы подробно.

## **Форматы файлов и конверсия**

Aspose.Slides открывает и сохраняет презентации PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP и PowerPoint XML. Он импортирует PDF и HTML‑контент в слайды, а сохраняет презентации в PDF, XPS, HTML, HTML5, TIFF, анимированный GIF, SWF, Markdown и XAML. [Поддерживаемые форматы файлов](/slides/ru/net/supported-file-formats/) перечисляют каждый формат вместе с API, которое его читает или пишет.

|**Функция**|**Описание**|
| :- | :- |
|[PPT и PPTX](/slides/ru/net/ppt-vs-pptx/)|Чтение и запись как двоичного формата PowerPoint 97-2003, так и формата Office Open XML.|
|[Конверсия PPT в PPTX](/slides/ru/net/convert-ppt-to-pptx/)|Преобразование устаревших презентаций PPT в PPTX.|
|[Portable Document Format (PDF)](/slides/ru/net/convert-powerpoint-to-pdf/)|Экспорт презентаций в PDF, включая документы PDF/A и PDF/UA.|
|[XML Paper Specification (XPS)](/slides/ru/net/convert-powerpoint-to-xps/)|Экспорт презентаций в документы XPS.|
|[Tagged Image File Format (TIFF)](/slides/ru/net/convert-powerpoint-to-tiff/)|Экспорт презентаций в изображения TIFF.|
|[HTML](/slides/ru/net/convert-powerpoint-to-html/)|Экспорт презентаций в HTML и HTML5.|
|[Импорт PDF и HTML](/slides/ru/net/import-presentation/)|Создание слайдов из страниц PDF и содержимого HTML.|

## **Отображение презентаций**

Aspose.Slides рендерит слайды и отдельные фигуры в виде изображений PNG, JPEG, BMP, GIF, TIFF и SVG, а слайды — в виде metafile EMF. Смотрите [Преобразовать слайды презентации в изображения](/slides/ru/net/convert-slide/), [Отобразить слайд как SVG‑изображение](/slides/ru/net/render-a-slide-as-an-svg-image/) и [Создать миниатюры фигур](/slides/ru/net/create-shape-thumbnails/).

## **Функциональные возможности**

Aspose.Slides позволяет создавать, читать и изменять почти всё содержимое презентации:

|**Область**|**Что можно сделать**|
| :- | :- |
|[Слайды](/slides/ru/net/presentation-slide/)|Добавлять, клонировать, переупорядочивать и удалять слайды; применять макеты и шаблоны; организовывать слайды в разделы; менять размер слайда.|
|[Дизайн](/slides/ru/net/presentation-design/)|Устанавливать фон, цвета темы, колонтитулы и шрифты.|
|[Текст](/slides/ru/net/manage-text/)|Создавать и редактировать текстовые кадры, абзацы и фрагменты; задавать шрифты, цвета, маркеры и выравнивание; искать и заменять текст.|
|[Фигуры](/slides/ru/net/powerpoint-shapes/)|Создавать AutoShape, линии, соединения, группы фигур и кадровые изображения; задавать положение, размер, контур и заливку (сплошную, градиентную или узорчатую); находить фигуру по альтернативному тексту.|
|[Таблицы](/slides/ru/net/powerpoint-table/), [Диаграммы](/slides/ru/net/powerpoint-charts/), и [SmartArt](/slides/ru/net/powerpoint-smartart/)|Создавать и редактировать таблицы, диаграммы Microsoft Office и диаграммы SmartArt.|
|[Медиа](/slides/ru/net/manage-media-files/), [OLE‑объекты](/slides/ru/net/manage-ole/), и [ActiveX‑элементы](/slides/ru/net/activex/)|Добавлять встроенные или связанные аудио‑ и видео‑кадры, внедрять OLE‑объекты и добавлять, изменять или удалять элементы ActiveX.|
|[Заметки](/slides/ru/net/presentation-notes/) и [комментарии](/slides/ru/net/presentation-comments/)|Добавлять, читать и редактировать заметки выступающего и комментарии обзора.|
|[Анимация](/slides/ru/net/powerpoint-animation/) и [переходы](/slides/ru/net/slide-transition/)|Применять анимационные эффекты к фигурам, задавать переходы между слайдами и настраивать параметры слайд‑шоу.|
|[Безопасность](/slides/ru/net/presentation-security/)|Шифровать презентации паролем, устанавливать защиту от записи и работать с цифровыми подписями.|
|[VBA‑макросы](/slides/ru/net/presentation-via-vba/)|Добавлять, извлекать и удалять VBA‑модули в презентациях с поддержкой макросов.|
|[Свойства](/slides/ru/net/presentation-properties/)|Читать и редактировать свойства документа.|

## **Часто задаваемые вопросы**

**Нужно ли устанавливать Microsoft PowerPoint на сервер или ПК для работы библиотеки?**

Нет. PowerPoint не требуется; Aspose.Slides — это автономный движок для создания, редактирования, конвертации и рендеринга презентаций.

**Как работает многопоточность? Можно ли параллельно обрабатывать документы?**

Безопасно обрабатывать разные документы в разных потоках; один объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) не должен использоваться [несколькими потоками](/slides/ru/net/multithreading/) одновременно.

**Поддерживаются ли пароли файлов и шифрование?**

Да. [Вы можете](/slides/ru/net/password-protected-presentation/) открывать зашифрованные презентации, задавать или удалять пароль открытия и записи, а также проверять статус защиты.

**Нужно ли беспокоиться о шрифтах в контейнерах Linux?**

Да. Шрифты, используемые в ваших презентациях, или подходящие их заменители, должны быть установлены в системе, чтобы текст отображался корректно. Вы также можете [указать каталоги шрифтов](/slides/ru/net/custom-font/) в вашем приложении. [Установка](/slides/ru/net/installation/) перечисляет требования Linux для каждого пакета.

**Есть ли ограничения в оценочной версии?**

Да. Без [лицензии](/slides/ru/net/licensing/) Aspose.Slides добавляет водяной знак оценки на каждый сохраняемый слайд и усекает текст, считанный из презентаций. Доступна [30‑дневная временная лицензия](https://purchase.aspose.com/temporary-license/) для полного тестирования функций.

**Поддерживается ли импорт внешних форматов в презентацию (PDF или HTML в PPTX)?**

Да. Вы можете добавить [страницы PDF и HTML‑контент](/slides/ru/net/import-presentation/) в презентацию, преобразуя их в слайды.