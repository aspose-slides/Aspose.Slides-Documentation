---
title: Конвертировать презентации OpenDocument на Python
linktitle: Конвертировать OpenDocument
type: docs
weight: 10
url: /ru/python-java/convert-openoffice-odp/
keywords:
- конвертировать ODP
- ODP в PDF
- ODP в HTML
- ODP в TIFF
- ODP в PPT
- ODP в PPTX
- ODP в XPS
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Конвертировать презентации OpenDocument (ODP) в PDF, HTML и другие форматы с помощью Aspose.Slides for Python via Java, без установки OpenOffice или LibreOffice."
---
## **Введение**

Aspose.Slides for Python via Java позволяет конвертировать презентации OpenDocument (ODP) в такие форматы, как PDF, HTML, TIFF, XPS, PPT и PPTX. Конвертация ODP использует тот же API, что и конвертация PowerPoint: загрузите исходный файл с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и выберите формат вывода с помощью [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/).

## **Конвертировать ODP в PDF**

Следуйте [инструкции по установке](/slides/ru/python-java/installation/) перед запуском примера. Поместите презентацию ODP с именем `pres.odp` в рабочий каталог. Следующий код при необходимости запускает JVM, загружает презентацию и сохраняет её как `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Презентация OpenDocument в разных приложениях**

Презентация ODP может выглядеть по‑разному в PowerPoint и LibreOffice/OpenOffice Impress, поскольку эти приложения поддерживают различные функции презентаций и поведения рендеринга. Проверяйте конвертированные презентации, когда их макет зависит от сложного форматирования.

Различия совместимости могут влиять на:

- Таблицы, включая их порядок наложения относительно других фигур и поддержку заливок изображениями.
- Поворот и выравнивание текста.
- Заливки изображением, градиентом и узором, применяемые к тексту.
- Нумерованные и маркированные списки.

Изображение ниже показывает список, созданный в LibreOffice Impress:

![ODP list example in LibreOffice Impress](odp-list-example.png)

Aspose.Slides сохраняет списки ODP для совместимости с LibreOffice/OpenOffice Impress.

Подробности о совместимости функций см. в [Руководство Microsoft по формату OpenDocument Presentation](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Вопросы и ответы**

**Что делать, если форматирование моего файла ODP меняется после конвертации?**

ODP и PowerPoint используют разные модели презентаций. Таблицы, шрифты и стили заливки могут отображаться иначе. Убедитесь, что требуемые шрифты доступны, проверьте результат и при необходимости скорректируйте макет или форматирование.

**Нужны ли для конвертации файлов ODP OpenOffice или LibreOffice?**

Нет. Aspose.Slides for Python via Java обрабатывает презентации без каких‑либо приложений. Требуются совместимая среда выполнения Java и пакет Python.

**Можно ли настроить вывод PDF при конвертации презентации ODP?**

Да. Используйте [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) для настройки параметров экспорта PDF, таких как качество изображений и сжатие.

**Можно ли конвертировать презентации ODP на сервере или в контейнере?**

Да. Установите пакет Python, совместимую среду выполнения Java и шрифты, необходимые для ваших презентаций, в целевой среде. Приложения офиса не требуются.