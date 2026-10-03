---
title: Обзор функций
type: docs
weight: 104
url: /ru/java/features-overview/
keywords:
- функции
- поддерживаемые платформы
- форматы файлов
- конвертация
- визуализация
- содержание презентации
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Ознакомьтесь с тем, что покрывает Aspose.Slides for Java перед её оценкой: поддерживаемые платформы, форматы файлов, визуализация слайдов и контент, который вы можете создавать и редактировать."
---
## **Обзор**

Aspose.Slides for Java — это библиотека классов для создания, чтения, редактирования, конвертации и визуализации презентаций PowerPoint и OpenDocument. У неё нет собственного пользовательского интерфейса и она не требует Microsoft PowerPoint или Microsoft Office. Эта статья подводит итоги возможностей библиотеки и содержит ссылки на статьи, описывающие каждый раздел.

## **Поддерживаемые платформы**

Aspose.Slides for Java — это один файл JAR, опубликованный в репозитории Maven компании Aspose с классификатором `jdk16`. Библиотека написана полностью на Java: в JAR нет нативных библиотек, и она не зависит от других пакетов.

- **Java:** Java 8 или новее. Aspose.Slides for Java 26.9 и более ранние версии также работают на Java 6 и 7, поддержку которых версия 26.10 уже не предоставляет; см. [26.9 release notes](https://releases.aspose.com/slides/ru/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/).
- **Операционные системы:** любая ОС с установленной Java‑runtime, например Windows, Linux и macOS. В Linux необходимо установить библиотеку fontconfig и хотя бы один шрифт.

[Установка](/slides/ru/java/installation/) показывает, как добавить библиотеку в проект и перечисляет требования к Linux. [Системные требования](/slides/ru/java/system-requirements/) подробно описывают поддерживаемые платформы.

## **Форматы файлов и конвертации**

Aspose.Slides открывает и сохраняет презентации в форматах PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP и PowerPoint XML. Она импортирует содержимое PDF и HTML в слайды и сохраняет презентации в PDF, XPS, HTML, HTML5, TIFF, анимированный GIF, SWF, Markdown и XAML. [Поддерживаемые форматы файлов](/slides/ru/java/supported-file-formats/) перечисляет каждый формат вместе с API, которое его читает или записывает.

|**Функция**|**Описание**|
| :- | :- |
|[PPT и PPTX](/slides/ru/java/ppt-vs-pptx/)|Чтение и запись как бинарного формата PowerPoint 97‑2003, так и формата Office Open XML.|
|[Конвертация PPT в PPTX](/slides/ru/java/convert-ppt-to-pptx/)|Преобразование устаревших презентаций PPT в PPTX.|
|[Конвертация ODP в PPTX](/slides/ru/java/convert-odp-to-pptx/)|Открытие и сохранение презентаций ODP, OTP и FODP, а также конвертация ODP в PPTX.|
|[Portable Document Format (PDF)](/slides/ru/java/convert-powerpoint-to-pdf/)|Экспорт презентаций в PDF, включая документы PDF/A и PDF/UA.|
|[XML Paper Specification (XPS)](/slides/ru/java/convert-powerpoint-to-xps/)|Экспорт презентаций в документы XPS.|
|[Tagged Image File Format (TIFF)](/slides/ru/java/convert-powerpoint-to-tiff/)|Экспорт презентаций в многостраничные TIFF‑изображения, по одному изображению на слайд.|
|[HTML](/slides/ru/java/convert-powerpoint-to-html/)|Экспорт презентаций в HTML и HTML5.|
|[Импорт PDF и HTML](/slides/ru/java/import-presentation/)|Создание слайдов из страниц PDF и содержимого HTML.|

## **Отображение презентаций**

Aspose.Slides визуализирует слайды и отдельные фигуры в виде изображений PNG, JPEG, BMP, GIF, TIFF и SVG, а слайды — в виде метафайлов EMF. См. [Конвертировать слайды презентации в изображения](/slides/ru/java/convert-slide/), [Отобразить слайды презентации как SVG‑изображения](/slides/ru/java/render-a-slide-as-an-svg-image/) и [Создать миниатюры фигур презентации](/slides/ru/java/create-shape-thumbnails/).

## **Возможности контента**

Aspose.Slides позволяет создавать, читать и изменять практически всё содержимое презентации:

|**Раздел**|**Что можно сделать**|
| :- | :- |
|[Слайды](/slides/ru/java/presentation-slide/)|Добавлять, клонировать, переупорядочивать и удалять слайды; применять макеты и шаблоны; группировать слайды в разделы; менять размер слайда.|
|[Дизайн](/slides/ru/java/presentation-design/)|Устанавливать фоны, цвета темы, колонтитулы и шрифты.|
|[Текст](/slides/ru/java/manage-text/)|Создавать и редактировать текстовые фреймы, абзацы и фрагменты; задавать шрифты, цвета, маркеры и выравнивание; выполнять поиск и замену текста.|
|[Фигуры](/slides/ru/java/powerpoint-shapes/)|Создавать AutoShape‑ы, линии, соединители, группировать фигуры и вставлять рамки изображений; задавать положение, размер, линию и заливку (сплошную, градиентную или узорчатую); находить фигуру по альтернативному тексту.|
|[Таблицы](/slides/ru/java/powerpoint-table/), [диаграммы](/slides/ru/java/powerpoint-charts/), и [SmartArt](/slides/ru/java/powerpoint-smartart/)|Создавать и редактировать таблицы, диаграммы Microsoft Office и схемы SmartArt.|
|[Медиа](/slides/ru/java/manage-media-files/), [OLE‑объекты](/slides/ru/java/manage-ole/), и [ActiveX‑элементы управления](/slides/ru/java/activex/)|Добавлять встроенные или связанные аудио и видео‑фреймы, встраивать OLE‑объекты, а также добавлять, изменять или удалять элементы управления ActiveX.|
|[Примечания](/slides/ru/java/presentation-notes/) и [комментарии](/slides/ru/java/presentation-comments/)|Добавлять, читать и редактировать заметки докладчика и комментарии обзора.|
|[Анимация](/slides/ru/java/powerpoint-animation/) и [переходы](/slides/ru/java/slide-transition/)|Применять анимационные эффекты к фигурам, задавать переходы между слайдами и настраивать параметры показа слайдов.|
|[Безопасность](/slides/ru/java/presentation-security/)|Шифровать презентации паролем, устанавливать защиту от записи и работать с [цифровыми подписями](/slides/ru/java/digital-signature-in-powerpoint/).|
|[VBA‑макросы](/slides/ru/java/presentation-via-vba/)|Добавлять, извлекать и удалять VBA‑модули в презентациях с поддержкой макросов.|
|[Свойства](/slides/ru/java/presentation-properties/)|Читать и редактировать свойства документа.|

## **Часто задаваемые вопросы**

**Нужно ли устанавливать Microsoft PowerPoint на сервер или ПК, чтобы библиотека работала?**

Нет. PowerPoint не требуется; Aspose.Slides — это автономный движок для создания, редактирования, конвертации и визуализации презентаций.

**Как работает многопоточность? Можно ли параллелить обработку?**

Можно безопасно обрабатывать разные документы в разных потоках; один и тот же объект [Презентация](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) не должен использоваться [одновременно несколькими потоками](/slides/ru/java/multithreading/).

**Поддерживаются ли пароли и шифрование файлов?**

Да. [Вы можете](/slides/ru/java/password-protected-presentation/) открывать зашифрованные презентации, задавать или удалять пароль на открытие и запись, а также проверять статус защиты.

**Нужно ли заботиться о шрифтах в контейнерах Linux?**

Да. В Linux требуется библиотека fontconfig и хотя бы один шрифт, а используемые в презентациях шрифты (или подходящие их заменители) должны быть установлены, чтобы текст отображался корректно. Вы также можете [указать каталоги шрифтов](/slides/ru/java/custom-font/) в приложении. Смотрите [Установка](/slides/ru/java/installation/#linux).

**Есть ли ограничения в оценочной версии?**

Да. Без [лицензии](/slides/ru/java/licensing/) Aspose.Slides добавляет водяной знак оценки на каждый сохраняемый слайд и обрезает текст, получаемый через API. Доступна [30‑дневная временная лицензия](https://purchase.aspose.com/temporary-license/) для полного тестирования возможностей.

**Поддерживается ли импорт внешних форматов в презентацию (PDF или HTML в PPTX)?**

Да. Вы можете добавить [PDF‑страницы и HTML‑содержимое](/slides/ru/java/import-presentation/) в презентацию, превратив их в слайды.