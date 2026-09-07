---
title: Конвертировать PPT в PPTX на Python
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/python-java/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX на Python с помощью Aspose.Slides. Включает примеры на Python для конвертации одиночного файла и пакетной, обработку ошибок и замечания о точности."
---
## **Обзор**

PPT — это устаревший бинарный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides for Python via Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. В этой статье показано, как преобразовать один файл или каталог файлов и объясняется, что проверять после конвертации.

Каждый пример при необходимости запускает виртуальную машину Java и освобождает презентацию после использования. Замените пути в примерах на свои файлы или каталоги.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) , затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с аргументом [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Pptx) . Блок `finally` освобождает презентацию и её ресурсы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Загрузить устаревшую презентацию PPT.
presentation = Presentation("presentation.ppt")
try:
    # Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Расширение файла само по себе не определяет формат вывода; это делает аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Pptx). Держите пути входного и выходного файлов разными, если нужно сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример преобразует каждый файл `.ppt` в указанном каталоге. Каждый файл обрабатывается независимо, поэтому сбой одной конвертации не останавливает остальную партию.

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

Для производственных нагрузок регистрируйте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и записывайте имена неудачных файлов в очередь повторных попыток или проверки. Повреждённые файлы, файлы, защищённые паролем и открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. [Презентации с паролем](/slides/ru/python-java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конверсия обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция без эквивалента в PPTX или не поддерживаемая библиотекой может быть нормализована, опущена или отображена иначе.

Проверьте преобразованный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиафайлы, необычные шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий рабочий процесс с поддержкой макросов, когда VBA должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться преобразованная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество слайдов и их содержимое, затем сравните его внешний вид и поведение в режиме показа с тем, что ожидается в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в современных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или хранить в формате, который проще просматривать и восстанавливать, чем устаревший бинарный PPT. Сохраняйте оригинальный PPT как архивную или откатную копию, пока преобразованная презентация не пройдёт проверки точности.

Если вам нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте руководство по конкретному формату в статье [Конвертировать презентации в несколько форматов](/slides/ru/python-java/convert-presentation/) вместо предположения, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для единичного файла или быстрой проверки вы можете воспользоваться [онлайн‑конвертером PPT в PPTX](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторных конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте API Python via Java.

## **Связанные статьи**

- [PPT vs PPTX](/slides/ru/python-java/ppt-vs-pptx/)
- [Сохранить презентации в Python](/slides/ru/python-java/save-presentation/)
- [Поддерживаемые форматы файлов](/slides/ru/python-java/supported-file-formats/)
- [Открыть презентации в Python](/slides/ru/python-java/open-presentation/)

## **FAQ**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Python via Java загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX весь контент точно?**

Она сохраняет основной контент презентации, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если в нём есть макросы, OLE‑ или ActiveX‑объекты, медиа, специализированные анимации или необычные шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла указать правильный пароль. Отсутствие пароля или неверный пароль приводит к ошибке загрузки.

**Следует ли удалять файл PPT после конвертации?**

Сохраняйте оригинал, пока не убедитесь, что PPTX работает в нужных просмотрщиках и рабочих процессах. Это обеспечивает возможность отката в случае, если устаревшая функция конвертирована иначе.