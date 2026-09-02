---
title: Преобразовать PPT в PPTX на Python
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/python-net/convert-ppt-to-pptx/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Преобразуйте устаревшие файлы PPT в PPTX на Python с помощью Aspose.Slides. Включает примеры конвертации одиночных файлов и пакетной обработки, обработку ошибок и примечания о точности."
---
## **Обзор**

PPT — это устаревший бинарный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides for Python via .NET может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как преобразовать один файл или каталог файлов и объясняет, что следует проверить после конвертации.

## **Преобразовать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) с параметром [SaveFormat.PPTX](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/). Оператор `with` освобождает объект презентации и освобождает его ресурсы после завершения блока.

```python
import aspose.slides as slides

# Загрузить устаревшую презентацию PPT.
with slides.Presentation("presentation.ppt") as presentation:
    # Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Расширение файла само по себе не выбирает формат вывода; это делает аргумент [SaveFormat.PPTX](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/). Держите входные и выходные пути различными, если необходимо сохранить оригинальный файл PPT.

## **Преобразовать несколько файлов PPT**

Следующий пример преобразует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому одна неудачная конверсия не останавливает остальную партию.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Для производственных нагрузок записывайте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и записывайте имена неудавшихся файлов в очередь повторных попыток или проверки. Повреждённые файлы, файлы, защищённые паролем и открытые без требуемого пароля, недоступные пути и неподдерживаемое содержимое могут привести к сбою конверсии. См. [Password-Protected Presentations](/slides/ru/python-net/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конверсия обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию точно одинаково. Устаревшая функция, для которой нет эквивалента в PPTX, или не поддерживается библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте преобразованный файл, если он содержит анимацию, переходы, встроенные или связанные объекты OLE, элементы управления ActiveX, встроенные медиафайлы, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий процесс с поддержкой макросов, когда VBA должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться преобразованная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте ключевые количества слайдов и содержимое, затем сравните его внешний вид и поведение слайд-шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентация будет редактироваться в текущих версиях PowerPoint, передаваться системам, работающим с пакетами Open XML, или сохраняться в формате, который легче исследовать и восстанавливать, чем устаревший бинарный PPT. Сохраните оригинальный PPT в качестве архивной или откатывающей копии, пока преобразованная презентация не пройдет проверку точности.

Если вам вместо этого нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте рекомендации по конкретным форматам в [Convert Presentations to Multiple Formats](/slides/ru/python-net/convert-presentation/), а не предполагайте, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн-конвертер**

Для редкого файла или быстрой сравнения вы можете использовать [онлайн-конвертер PPT в PPTX](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяющихся конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте Python API.

## **Связанные статьи**

- [PPT против PPTX](/slides/ru/python-net/ppt-vs-pptx/)
- [Сохранение презентаций в Python](/slides/ru/python-net/save-presentation/)
- [Поддерживаемые форматы файлов](/slides/ru/python-net/supported-file-formats/)
- [Открытие презентаций в Python](/slides/ru/python-net/open-presentation/)

## **Вопросы и ответы**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Python via .NET загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX весь контент точно?**

Она сохраняет обычное содержимое презентации, но точная точность не гарантирована для каждой устаревшей или неподдерживаемой функции. Просмотрите сгенерированный файл, если он содержит макросы, объекты OLE или ActiveX, медиа, специализированные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла вы укажете правильный пароль. Отсутствующий или неверный пароль приводит к сбою операции загрузки.

**Стоит ли удалять файл PPT после конвертации?**

Сохраните оригинал, пока не проверите PPTX в просмотрщиках и процессах, которые важны для вас. Это обеспечивает копию для отката, если устаревшая функция конвертируется иначе.