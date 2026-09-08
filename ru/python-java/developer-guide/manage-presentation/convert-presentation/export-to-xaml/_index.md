---
title: Экспорт презентаций в XAML на Python через Java
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/python-java/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспортировать PPT в XAML
- экспортировать PPTX в XAML
- экспортировать ODP в XAML
- Python
- Java
- Aspose.Slides
description: "Экспортируйте презентации PowerPoint и OpenDocument в XAML с помощью Aspose.Slides for Python via Java. Используйте параметры по умолчанию или включайте скрытые слайды."
---
## **Обзор**

В этой статье объясняется, как экспортировать презентации PowerPoint и OpenDocument в XAML с помощью Aspose.Slides for Python via Java. В ней вводится XAML, показывается экспорт с настройками по умолчанию и демонстрируется, как включить скрытые слайды с помощью [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/).

Для примеров требуются Aspose.Slides for Python via Java и совместимая среда выполнения Java. Поместите `pres.pptx` в текущий рабочий каталог. Каждый пример запускает JVM только в том случае, если она ещё не запущена.

## **О XAML**

XAML (Extensible Application Markup Language) — язык на основе XML для описания пользовательских интерфейсов. Он используется такими фреймворками, как Windows Presentation Foundation (WPF). Вы можете создавать и редактировать XAML с помощью визуального дизайнера или текстового редактора.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Создайте [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) из входного файла, затем передайте [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/) в [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для экспорта с настройками по умолчанию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/) для настройки экспорта. Чтобы включить скрытые слайды, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) с `True` перед сохранением:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Как выбрать запасной шрифт, если оригинальный шрифт недоступен?**

Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) у вашего объекта [XamlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/), чтобы указать запасной шрифт. Убедитесь, что выбранный шрифт доступен в среде экспорта.

**Можно ли использовать экспортированную разметку в любом XAML‑фреймворке?**

XAML‑фреймворки различаются по поддерживаемым элементам и возможностям. Проверьте экспортированную разметку в целевом фреймворке перед её интеграцией в приложение.

**Экспортируются ли скрытые слайды по умолчанию?**

Нет. Чтобы включить их, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) с `True`. Оставьте значение `False`, чтобы исключить их.