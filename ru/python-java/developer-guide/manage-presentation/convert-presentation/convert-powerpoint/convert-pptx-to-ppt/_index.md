---
title: Конвертировать PPTX в PPT в Python
linktitle: PPTX в PPT
type: docs
weight: 21
url: /ru/python-java/convert-pptx-to-ppt/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPTX
- PPTX в PPT
- сохранить PPTX как PPT
- экспортировать PPTX в PPT
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Конвертировать PPTX в устаревший формат PPT в Python с помощью Aspose.Slides for Python via Java. Включает пример кода и примечания о совместимости и защищённых файлах."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет конвертировать презентацию PPTX в устаревший формат PPT, используемый в PowerPoint 97–2003, без установленного Microsoft PowerPoint. Загрузите файл PPTX и сохраните его в формате PPT, как показано ниже.

## **Конвертировать PPTX в PPT**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с указанием пути вывода и [SaveFormat.Ppt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Ppt).

Следующий пример при необходимости запускает виртуальную машину Java и конвертирует `template.pptx` в `output.ppt`, используя параметры по умолчанию. Замените пути собственными именами файлов. Блок `finally` освобождает ресурсы презентации, даже если сохранение не удалось.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Загрузить презентацию PPTX.
presentation = Presentation("template.pptx")
try:
    # Сохранить презентацию в формате PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Аргумент [SaveFormat.Ppt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Ppt) выбирает формат вывода; изменение только расширения файла не конвертирует презентацию. Сохраняйте оригинальный файл PPTX, чтобы при необходимости вернуться к нему, если новая функция не имеет эквивалента в PPT.

## **Конвертировать PPTX в другие форматы**

Aspose.Slides также поддерживает другие форматы вывода. См. соответствующие статьи для параметров и примеров, специфичных для формата:

- [Конвертировать PowerPoint в PDF на Python](/slides/ru/python-java/convert-powerpoint-to-pdf/)
- [Конвертировать PowerPoint в XPS на Python](/slides/ru/python-java/convert-powerpoint-to-xps/)
- [Конвертировать PowerPoint в HTML на Python](/slides/ru/python-java/convert-powerpoint-to-html/)
- [Сохранить презентации как ODP на Python](/slides/ru/python-java/save-presentation/)
- [Конвертировать PowerPoint в PNG на Python](/slides/ru/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Все ли эффекты и функции PPTX сохраняются при конвертации в PPT?**

Не всегда. Устаревший формат PPT не поддерживает все функции, доступные в PPTX. Некоторые эффекты, объекты или поведения могут быть упрощены или отображены иначе. Просмотрите конвертированную презентацию в целевом просмотрщике, особенно если она содержит новые функции PowerPoint.

**Могу ли я конвертировать только выбранные слайды в PPT?**

Сохранение в PPT записывает всю презентацию. Чтобы конвертировать выбранные слайды, создайте новую презентацию, удалите её первоначальный пустой слайд, склонируйте необходимые слайды в неё и сохраните в формате PPT. См. [Клонирование слайдов в Python](/slides/ru/python-java/clone-slides/).

**Могу ли я конвертировать защищённый паролем файл PPTX?**

Да, если вы укажете правильный пароль при загрузке исходной презентации. Вы также можете настроить защиту для выходного файла. См. [Презентации, защищённые паролем](/slides/ru/python-java/password-protected-presentation/).