---
title: Конвертация PPT в PPTX на Python
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/python-java/convert-ppt-to-pptx/
keywords:
- конвертация PowerPoint
- конвертация презентации
- конвертация слайда
- конвертация PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX на Python с помощью Aspose.Slides. Включает примеры на Python для конвертации одного файла и пакетной обработки, обработки ошибок и замечаний о точности."
---
## **Обзор**

PPT — это устаревший двоичный формат PowerPoint, а PPTX — более новый формат Open XML. Aspose.Slides for Python via Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как конвертировать один файл или каталог файлов, и объясняет, что следует проверить после конвертации.

Каждый пример при необходимости запускает виртуальную машину Java и освобождает презентацию после использования. Замените примерные пути своими путями к файлам или каталогам.

## **Конвертация файла PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) , затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с аргументом [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Pptx) . Блок `finally` освобождает презентацию и её ресурсы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Загрузить устаревшую PPT презентацию.
presentation = Presentation("presentation.ppt")
try:
    # Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Расширение файла само по себе не определяет формат вывода; определяет аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Pptx) . Держите пути входного и выходного файлов разными, если вам нужно сохранить оригинальный файл PPT.

## **Конвертация нескольких файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в указанном каталоге. Каждый файл обрабатывается независимо, поэтому ошибка при конвертации одного файла не останавливает остальные.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Для производственных задач регистрируйте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и записывайте имена неудачных файлов в очередь повторной обработки или проверки. Повреждённые файлы, файлы, защищённые паролем и открытые без нужного пароля, недоступные пути и неподдерживаемый контент могут приводить к сбою конвертации. См. [Password-Protected Presentations](/slides/ru/python-java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие возможности**

Конвертация обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая возможность, которой нет эквивалента в PPTX или которая не поддерживается библиотекой, может быть нормализована, опущена или отображена иначе.

Проверяйте конвертированный файл, если в нём присутствуют анимации, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные мультимедиа, редкие шрифты или макросы VBA. Обычный файл PPTX не является форматом с поддержкой макросов, поэтому используйте соответствующий workflow с поддержкой макросов, когда VBA должно оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться конвертированная презентация.

Для важных документов повторно откройте сгенерированный PPTX программно, проверьте количество слайдов и ключевой контент, затем сравните его внешний вид и поведение слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) как доказательство того, что каждая устаревшая возможность имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в современных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или сохранять в формате, который легче просматривать и восстанавливать, чем устаревший двоичный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдет проверку точности.

Если вместо этого вам нужны PDF, HTML, изображения, XPS или иной тип вывода, используйте рекомендации для конкретных форматов в [Convert Presentations to Multiple Formats](/slides/ru/python-java/convert-presentation/) вместо предположения, что все цели сохраняют редактируемые возможности PowerPoint.

## **Онлайн‑конвертер**

Для отдельного файла или быстрой сравнимости вы можете воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx) . Для повторяющихся конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте API Python via Java.

## **Связанные статьи**

- [PPT vs PPTX](/slides/ru/python-java/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/ru/python-java/save-presentation/)
- [Supported File Formats](/slides/ru/python-java/supported-file-formats/)
- [Open Presentations in Python](/slides/ru/python-java/open-presentation/)

## **FAQ**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Python via Java загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конвертация PPT в PPTX весь контент точно?**

Она сохраняет обычный контент презентаций, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если в нём есть макросы, OLE или ActiveX‑объекты, медиа, специальные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла вы укажите правильный пароль. Отсутствие пароля или неверный пароль приводит к сбою операции загрузки.

**Следует ли удалять файл PPT после конвертации?**

Сохраняйте оригинал, пока не убедитесь, что PPTX работает в нужных просмотрщиках и рабочих процессах. Это обеспечивает возможность отката, если какая‑то устаревшая функция была преобразована иначе.