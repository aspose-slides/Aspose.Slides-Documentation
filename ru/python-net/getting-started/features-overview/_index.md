---
title: Обзор функций
type: docs
weight: 20
url: /ru/python-net/features-overview/
keywords:
- функции
- поддерживаемые платформы
- формат файлов
- конвертация
- рендеринг
- печать
- форматирование
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Ознакомьтесь с Aspose.Slides for Python via .NET: мощным API для создания, редактирования, автоматизации и эффективного конвертирования презентаций PowerPoint и OpenDocument."
---

## **Поддерживаемые платформы**
Платформы, на которых можно использовать Aspose.Slides for Python via .NET, включают Windows x64 или x86 и широкий набор дистрибутивов Linux с установленным Python 3.5 или более поздней версии. Для целевой платформы Linux существуют дополнительные требования:
- Библиотеки времени выполнения GCC‑6 (или новее)
- Зависимости .NET Core Runtime. Установка самого .NET Core Runtime НЕ требуется
- Для Python 3.5‑3.7: требуется сборка Python с `pymalloc`. Параметр сборки `--with-pymalloc` включён по умолчанию. Обычно сборка `pymalloc` отмечается суффиксом `m` в имени файла.
- Общая библиотека Python `libpython`. Параметр сборки `--enable-shared` отключён по умолчанию, некоторые дистрибутивы Python не содержат `libpython`. Для некоторых платформ Linux её можно установить через менеджер пакетов, например: `sudo apt-get install libpython3.7`. Частая проблема – библиотека `libpython` установлена в другом месте, чем стандартный системный путь для разделяемых библиотек. Проблему можно решить, указав альтернативные пути к библиотекам при сборке Python, либо создав символическую ссылку на файл `libpython` в стандартном системном каталоге. Обычно имя файла выглядит как `libpythonX.Ym.so.1.0` для Python 3.5‑3.7 или `libpythonX.Y.so.1.0` для Python 3.8 и новее (например: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Если вам нужна поддержка большего количества платформ, ищите «близнеца» – продукты Aspose.Slides for .NET или Aspose.Slides for Java.

## **Форматы файлов и конверсия**
Aspose.Slides for Python via .NET поддерживает большинство форматов документов PowerPoint. Он также позволяет экспортировать их в популярные форматы, широко используемые организациями. Подробности:

|**Функция**|**Описание**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ru/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET обеспечивает самую быструю обработку этого формата презентаций.|
|[PPT to PPTX conversion](/slides/ru/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET поддерживает конверсию PPT в PPTX.|
|[Portable Document Format (PDF)](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Можно экспортировать все поддерживаемые форматы файлов в документы Adobe Portable Document Format (PDF) одним методом.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Можно экспортировать все поддерживаемые форматы файлов в документы XML Parser Specification (XPS) одним методом.|
|[Tagged Image File Format (TIFF)](/slides/ru/python-net/convert-powerpoint-to-tiff/)|Можно экспортировать все поддерживаемые форматы презентаций в Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET поддерживает конверсию PresentationEx в формат HTML.|

## **Рендеринг и печать**
Aspose.Slides for Python via .NET поддерживает высококачественный рендеринг слайдов презентаций в различные графические форматы. Подробности:

|**Функция**|**Описание**|
| :- | :- |
|.NET Supported Image Formats|С помощью Aspose.Slides for Python via .NET можно рендерить слайды и изображения на слайдах во все графические форматы, поддерживаемые .NET, такие как TIFF, PNG, BMP, JPEG, GIF и метафайлы.|
|SVG Format|Aspose.Slides for Python via .NET также предоставляет встроенные методы, позволяющие экспортировать слайды презентации в формат Scalable Vector Graphics (SVG).|
|Presentation Printing|Последние версии Aspose.Slides for Python via .NET предоставляют встроенные методы печати с различными опциями.|

## **Функции контента**
Aspose.Slides for Python via .NET позволяет получать доступ, изменять или создавать почти все элементы или содержимое презентационных документов. Подробности:

|**Функция**|**Описание**|
| :- | :- |
|Master Slides|Мастер‑слайды определяют макет обычных слайдов. Aspose.Slides for Python via .NET позволяет получать доступ к мастер‑слайдам и изменять их.|
|Normal Slides|С помощью Aspose.Slides for Python via .NET можно создавать новые слайды разных типов; также можно получать доступ к существующим слайдам и изменять их.|
|Cloning / Copying Slides|В Aspose.Slides for Python via .NET есть встроенные методы, позволяющие клонировать или копировать существующие слайды внутри презентации. Клонированные и скопированные слайды можно использовать в другой презентации. Поскольку слайд наследует макет от мастер‑слайда, встроенные методы клонирования автоматически копируют мастер‑слайд.|
|Managing Slides sections|Методы для организации слайдов в разные разделы внутри презентации.|
|Place Holders and Text Holders|Можно получать доступ к плейсхолдерам и текстовым плейсхолдерам на слайде. Кроме того, можно создавать слайд с текстовыми плейсхолдерами с нуля, используя соответствующий метод.|
|Header and Footers|Aspose.Slides for Python via .NET упрощает работу с заголовками/нижними колонтитулами на слайдах.|
|Notes in Slides|С помощью Aspose.Slides for Python via .NET можно получать доступ к заметкам, связанным со слайдом, изменять их и добавлять новые заметки.|
|Finding a Shape|Можно также найти конкретную форму на слайде, используя альтернативный текст, связанный с этой формой.|
|Backgrounds|Aspose.Slides for Python via .NET позволяет работать с фонами, связанными с мастер‑слайдом или обычным слайдом презентации.|
|Text Boxes|Текстовые блоки можно создавать с нуля. Можно получать доступ к существующим текстовым блокам и изменять их текст, сохраняя исходный формат.|
|Rectangle Shapes|Можно создавать или изменять прямоугольные формы с помощью Aspose.Slides for Python via .NET.|
|Poly Line Shapes|Можно создавать или изменять полилинейные формы с помощью Aspose.Slides for Python via .NET.|
|Ellipse Shapes|Можно создавать или изменять эллиптические формы с помощью Aspose.Slides for Python via .NET.|
|Group Shapes|Aspose.Slides for Python via .NET поддерживает групповые формы.|
|Auto Shapes|Aspose.Slides for Python via .NET поддерживает автофигуры.|
|SmartArt|Aspose.Slides for Python via .NET предоставляет поддержку SmartArt‑форм в MS PowerPoint.|
|Charts|Aspose.Slides for Python via .NET предоставляет поддержку диаграмм MSO в PowerPoint.|
|Shapes Serialization|Aspose.Slides for Python via .NET поддерживает большое количество форм. Когда поддержка определённой формы отсутствует, можно воспользоваться методом сериализации, позволяющим сериализовать форму из существующего слайда и дальше использовать её по необходимости.|
|Picture Frames|Можно управлять изображениями в picture frames с помощью Aspose.Slides for Python via .NET.|
|Audio Frames|Можно привязывать или встраивать аудиофайлы в audio frames на слайдах с Aspose.Slides for Python via .NET.|
|Video Frames|Можно работать с видеофайлами в video frames. Aspose.Slides for Python via .NET также поддерживает привязанные и встроенные видео.|
|OLE Frame|Можно управлять OLE‑объектами в OLE frames с Aspose.Slides for Python via .NET.|
|Tables|Aspose.Slides for Python via .NET поддерживает таблицы на слайдах.|
|ActiveX Controls|Поддержка ActiveX‑элементов управления.|
|VBA Macros|Поддержка управления VBA‑макросами внутри презентаций.|
|Text Frame|Можно получить доступ к тексту любой формы через связанный с ней text frame.|
|Text Scanning|Можно сканировать текст в презентации на уровне всей презентации или отдельного слайда с помощью встроенных методов сканирования.|
|Animations|Можно применять анимацию к формам.|
|Slide Shows|Aspose.Slides for Python via .NET поддерживает слайд‑шоу и переходы между слайдами.|

## **Форматирование**
С помощью Aspose.Slides for Python via .NET можно форматировать тексты и формы на слайдах презентаций. Подробности:

|**Функция**|**Описание**|
| :- | :- |
|Text Formatting|<p>В Aspose.Slides for Python via .NET тексты управляются через text frames, связанные с формами. Поэтому можно форматировать тексты, используя абзацы и их части, связанные с text frames. Эти элементы текста можно форматировать с помощью Aspose.Slides for Python via .NET.</p><p>- Тип шрифта</p><p>- Размер шрифта</p><p>- Цвет шрифта</p><p>- Оттенки шрифта</p><p>- Выравнивание абзаца</p><p>- Маркировка абзаца</p><p>- Ориентация абзаца</p>|
|Shape Formatting|<p>В Aspose.Slides for Python via .NET базовым элементом слайда является форма. Эти формы можно форматировать следующим образом:</p><p>- Позиция</p><p>- Размер</p><p>- Контур</p><p>- Заливка (включая шаблон, градиент, сплошную)</p><p>- Текст</p><p>- Изображение</p>|

## **FAQ**

**Нужно ли устанавливать Microsoft PowerPoint на сервер/ПК для работы библиотеки?**

Нет. PowerPoint не требуется; Aspose.Slides — самостоятельный движок для создания, редактирования, конвертации и рендеринга презентаций.

**Как работает многопоточность? Можно ли распараллелить обработку?**

Безопасно обрабатывать разные документы в разных потоках; один и тот же [presentation](/slides/ru/python-net/presentation/) объект не должен использоваться [множеством потоков](/slides/ru/python-net/multithreading/) одновременно.

**Поддерживаются ли пароли и шифрование файлов?**

Да. [Можно](/slides/ru/python-net/password-protected-presentation/) открывать зашифрованные презентации, задавать или удалять пароли для открытия и записи, а также проверять статус защиты.

**Нужно ли заботиться о шрифтовых пакетах в Linux‑контейнерах?**

Да. Рекомендуется установить общие шрифтовые пакеты и/или явно [указать каталоги шрифтов](/slides/ru/python-net/custom-font/) в приложении, чтобы избежать неожиданных замен.

**Есть ли ограничения в оценочной версии?**

В [режиме оценки](/slides/ru/python-net/licensing/) к выходным файлам добавляется водяной знак и применяются определённые ограничения; доступна [30‑дневная временная лицензия](https://purchase.aspose.com/temporary-license/) для полного тестирования всех функций.

**Поддерживается ли импорт внешних форматов в презентацию (PDF/HTML → PPTX)?**

Да. Можно добавлять [PDF‑страницы и HTML‑контент](/slides/ru/python-net/import-presentation/) в презентацию, превращая их в слайды.