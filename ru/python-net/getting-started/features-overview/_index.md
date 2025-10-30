---
title: Обзор возможностей
type: docs
weight: 20
url: /ru/python-net/features-overview/
keywords:
- функции
- поддерживаемые платформы
- формат файла
- конвертация
- рендеринг
- печать
- форматирование
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Откройте для себя Aspose.Slides for Python via .NET: мощный API для создания, редактирования, автоматизации и эффективного преобразования презентаций PowerPoint и OpenDocument."
---

## **Поддерживаемые платформы**
Платформы, на которых можно использовать Aspose.Slides for Python via .NET, — Windows x64 или x86 и широкий спектр дистрибутивов Linux с установленным Python 3.5 или новее. Для целевой платформы Linux требуются дополнительные зависимости:
- Библиотеки среды выполнения GCC‑6 (или новее)
- Зависимости .NET Core Runtime. Установка самого .NET Core Runtime НЕ требуется
- Для Python 3.5‑3.7: требуется сборка Python с `pymalloc`. Параметр сборки `--with-pymalloc` включён по умолчанию. Обычно сборка с `pymalloc` помечается суффиксом `m` в имени файла.
- Общая библиотека `libpython`. Параметр сборки `--enable-shared` отключён по умолчанию, поэтому в некоторых дистрибутивах Python отсутствует общая библиотека `libpython`. Для некоторых платформ Linux её можно установить через менеджер пакетов, например: `sudo apt-get install libpython3.7`. Частая проблема — библиотека `libpython` установлена в другом месте, чем стандартный системный каталог общих библиотек. Проблему можно решить, задав альтернативные пути к библиотекам при сборке Python, либо создав символическую ссылку на файл `libpython` в стандартном каталоге. Обычно имя файла общей библиотеки выглядит как `libpythonX.Ym.so.1.0` для Python 3.5‑3.7 или `libpythonX.Y.so.1.0` для Python 3.8 и новее (например: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Если вам нужна поддержка большего количества платформ, смотрите «близнец‑брат» проду­ктов Aspose.Slides for .NET или Aspose.Slides for Java.

## **Форматы файлов и конвертация**
Aspose.Slides for Python via .NET поддерживает большинство форматов документов PowerPoint. Он также позволяет экспортировать их в популярные форматы, широко используемые и обмениваемые организациями. Ознакомьтесь с деталями:

|**Функция**|**Описание**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/ru/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET обеспечивает самую быструю обработку этого формата презентаций.|
|[PPT to PPTX conversion](/slides/ru/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET поддерживает конвертацию PPT в PPTX.|
|[Portable Document Format (PDF)](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Можно экспортировать все поддерживаемые форматы файлов в документы Adobe Portable Document Format (PDF) одним методом.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Можно экспортировать все поддерживаемые форматы файлов в документы XML Parser Specification (XPS) одним методом.|
|[Tagged Image File Format (TIFF)](/slides/ru/python-net/convert-powerpoint-to-tiff/)|Можно экспортировать все поддерживаемые форматы презентаций в Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET поддерживает конвертацию PresentationEx в формат HTML.|

## **Рендеринг и печать**
Aspose.Slides for Python via .NET поддерживает высококачественный рендеринг слайдов презентаций в различные графические форматы. Ознакомьтесь с деталями:

|**Функция**|**Описание**|
| :- | :- |
|.NET Supported Image Formats|С Aspose.Slides for Python via .NET вы можете рендерить слайды и изображения на слайдах во все графические форматы, поддерживаемые .NET, такие как TIFF, PNG, BMP, JPEG, GIF и метафайлы.|
|SVG Format|Aspose.Slides for Python via .NET также предоставляет встроенные методы, позволяющие экспортировать слайды презентаций в форматы Scalable Vector Graphics (SVG).|
|Presentation Printing|Последние версии Aspose.Slides for Python via .NET предоставляют встроенные методы печати с различными опциями.|

## **Возможности контента**
Aspose.Slides for Python via .NET позволяет получать доступ, изменять или создавать почти все элементы и содержимое презентационных документов. Ознакомьтесь с деталями:

|**Функция**|**Описание**|
| :- | :- |
|Master Slides|Мастер‑слайды определяют макет обычных слайдов. Aspose.Slides for Python via .NET позволяет получать доступ к мастер‑слайдам презентаций и изменять их.|
|Normal Slides|С Aspose.Slides for Python via .NET можно создавать новые слайды разных типов; также доступен доступ к существующим слайдам и их изменение.|
|Cloning / Copying Slides|В Aspose.Slides for Python via .NET есть встроенные методы, позволяющие клонировать или копировать существующие слайды внутри презентации. Также можно использовать скопированные и клонированные слайды из одной презентации в другую. Поскольку слайд наследует макет от мастер‑слайда, встроенные методы клонирования автоматически копируют мастер‑слайд при клонировании.|
|Managing Slides sections|Методы для организации слайдов в различные секции внутри презентации.|
|Place Holders and Text Holders|Можно получать доступ к заполнителям и текстовым заполнителям на слайде. Кроме того, можно создать слайд с текстовыми заполнителями с нуля, используя соответствующий метод.|
|Header and Footers|Aspose.Slides for Python via .NET упрощает работу с заголовками/подвалами на слайдах.|
|Notes in Slides|С Aspose.Slides for Python via .NET можно получать доступ к заметкам, связанным со слайдом, изменять их и добавлять новые заметки.|
|Finding a Shape|Можно находить конкретную фигуру на слайде, используя альтернативный текст, привязанный к фигуре.|
|Backgrounds|Aspose.Slides for Python via .NET позволяет работать с фонами, связанными с мастер‑слайдом или обычным слайдом презентации.|
|Text Boxes|Текстовые блоки можно создавать с нуля, получать доступ к существующим и изменять их текст без потери исходного формата.|
|Rectangle Shapes|Можно создавать или изменять прямоугольные фигуры с Aspose.Slides for Python via .NET.|
|Poly Line Shapes|Можно создавать или изменять ломаные линии с Aspose.Slides for Python via .NET.|
|Ellipse Shapes|Можно создавать или изменять эллипсы с Aspose.Slides for Python via .NET.|
|Group Shapes|Aspose.Slides for Python via .NET поддерживает групповые фигуры.|
|Auto Shapes|Aspose.Slides for Python via .NET поддерживает автоматические фигуры.|
|SmartArt|Aspose.Slides for Python via .NET обеспечивает поддержку фигур SmartArt в MS PowerPoint.|
|Charts|Aspose.Slides for Python via .NET обеспечивает поддержку диаграмм MSO в PowerPoint.|
|Shapes Serialization|Aspose.Slides for Python via .NET поддерживает большое количество фигур. Когда поддержка какой‑то фигуры отсутствует, можно воспользоваться методом сериализации, позволяющим сериализовать эту фигуру из существующего слайда и далее использовать её по необходимости.|
|Picture Frames|Можно управлять изображениями в рамках picture frames с Aspose.Slides for Python via .NET.|
|Audio Frames|Можно привязывать или встраивать аудиофайлы в audio frames на слайдах с Aspose.Slides for Python via .NET.|
|Video Frames|Можно работать с видеофайлами в video frames. Aspose.Slides for Python via .NET также поддерживает привязанные и встроенные видео.|
|OLE Frame|Можно управлять OLE‑объектами в OLE‑кадрах с Aspose.Slides for Python via .NET.|
|Tables|Aspose.Slides for Python via .NET поддерживает таблицы на слайдах.|
|ActiveX Controls|Поддержка элементов управления ActiveX.|
|VBA Macros|Поддержка управления VBA‑макросами внутри презентаций.|
|Text Frame|Можно получить доступ к тексту любой фигуры через text frame, связанный с этой фигурой.|
|Text Scanning|Можно сканировать текст в презентации на уровне презентации или слайда с помощью встроенных методов сканирования.|
|Animations|Можно применять анимацию к фигурам.|
|Slide Shows|Aspose.Slides for Python via .NET поддерживает слайд‑шоу и переходы между слайдами.|

## **Форматирование**
С Aspose.Slides for Python via .NET можно форматировать тексты и фигуры на слайдах презентаций. Ознакомьтесь с деталями:

|**Функция**|**Описание**|
| :- | :- |
|Text Formatting|<p>В Aspose.Slides for Python via .NET вы управляете текстом через text frames, привязанные к фигурам. Таким образом, вы можете форматировать текст, используя абзацы и части, связанные с text frames. Эти текстовые элементы могут быть отформатированы через Aspose.Slides for Python via .NET.</p><p>- Тип шрифта</p><p>- Размер шрифта</p><p>- Цвет шрифта</p><p>- Оттенки шрифта</p><p>- Выравнивание абзаца</p><p>- Маркировка абзаца</p><p>- Ориентация абзаца</p>|
|Shape Formatting|<p>В Aspose.Slides for Python via .NET базовым элементом слайда является фигура. Вы можете форматировать эти фигуры с помощью Aspose.Slides for Python via .NET:</p><p>- Позиция</p><p>- Размер</p><p>- Линия</p><p>- Заливка (включая узор, градиент, сплошную)</p><p>- Текст</p><p>- Изображение</p>|

## **FAQ**

**Нужен ли установить Microsoft PowerPoint на сервер/ПК, чтобы библиотека работала?**

Нет. PowerPoint не требуется; Aspose.Slides — это автономный движок для создания, редактирования, конвертации и рендеринга презентаций.

**Как работает многопоточность? Можно ли параллелить обработку?**

Безопасно обрабатывать разные документы в разных потоках; один и тот же [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) объект не должен использоваться [несколькими потоками](/slides/ru/python-net/multithreading/) одновременно.

**Поддерживаются ли пароли файлов и шифрование?**

Да. [Можно](/slides/ru/python-net/password-protected-presentation/) открыть зашифрованные презентации, задать или удалить пароль открытия и записи, а также проверить статус защиты.

**Нужно ли учитывать шрифтовые пакеты в контейнерах Linux?**

Да. Рекомендуется установить общие пакеты шрифтов и/или явно [указать каталоги шрифтов](/slides/ru/python-net/custom-font/) в приложении, чтобы избежать неожиданной подстановки.

**Есть ли ограничения в пробной версии?**

В [режиме оценки](/slides/ru/python-net/licensing/) к результату добавляется водяной знак и действуют определённые ограничения; доступна [30‑дневная временная лицензия](https://purchase.aspose.com/temporary-license/) для полнофункционального тестирования.

**Поддерживается ли импорт внешних форматов в презентацию (PDF/HTML → PPTX)?**

Да. Вы можете добавить [PDF‑страницы и HTML‑контент](/slides/ru/python-net/import-presentation/) в презентацию, превратив их в слайды.