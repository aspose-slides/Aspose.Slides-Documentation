---
title: "Преобразование презентаций PowerPoint в XPS на Python"
linktitle: "PowerPoint в XPS"
type: docs
weight: 70
url: /ru/python-java/convert-powerpoint-to-xps/
keywords:
- "конвертировать PowerPoint"
- "конвертировать презентацию"
- "конвертировать PPT"
- "конвертировать PPTX"
- "PowerPoint в XPS"
- "презентация в XPS"
- "PPT в XPS"
- "PPTX в XPS"
- "сохранить PPT как XPS"
- "сохранить PPTX как XPS"
- "экспортировать PPT в XPS"
- "экспортировать PPTX в XPS"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Преобразуйте презентации PowerPoint PPT и PPTX в XPS на Python с помощью Aspose.Slides for Python via Java, используя настройки экспорта по умолчанию или пользовательские."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет конвертировать презентации PowerPoint в XPS, сохраняя файл PPT или PPTX в формате XPS. Эта статья объясняет, когда XPS может быть полезен, и показывает, как экспортировать презентацию, используя либо настройки по умолчанию, либо пользовательские [XpsOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xpsoptions/) параметры.

## **О XPS**

XPS (XML Paper Specification) — это основанный на XML формат документов, разработанный Microsoft. Он описывает фиксированные страницы, сохраняющие расположение текста и графики для просмотра и печати совместимым программным обеспечением.

## **Когда использовать формат Microsoft XPS**

Используйте XPS, когда рабочий процесс требует фиксированных файлов для обмена или печати с помощью совместимых с XPS инструментов. Получателям необходимо программное обеспечение, поддерживающее XPS. Если в вашем рабочем процессе требуется PDF, смотрите [Convert PowerPoint to PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Чтобы попробовать преобразовать презентацию PPT или PPTX в XPS, используйте [free online converter](https://products.aspose.app/slides/ru/conversion).

{{% /alert %}}

| Исходная презентация PowerPoint | Выходной документ XPS |
| --- | --- |
| ![Original PowerPoint presentation](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentation converted to XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Конвертация в XPS с помощью Aspose.Slides**

Используйте метод [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) с [SaveFormat.Xps](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Xps) для экспорта презентации. Вы можете использовать настройки экспорта по умолчанию или задать [XpsOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xpsoptions/) для настройки вывода.

Каждый пример ниже при необходимости запускает виртуальную машину Java и освобождает презентацию после использования. Замените имя входного файла на путь к вашему файлу PPT или PPTX.

### **Конвертация презентаций в XPS с использованием настроек по умолчанию**

Следующий код Python конвертирует презентацию в XPS, используя настройки по умолчанию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Сохранить презентацию как XPS‑документ.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Конвертация презентаций в XPS с пользовательскими настройками**

Следующий пример использует [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) для сохранения метафайлов как PNG‑изображения в результирующем документе XPS:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Сохранить презентацию с пользовательскими настройками XPS.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Могу ли я сохранить XPS в поток вместо файла?**

Да. Метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) имеет перегрузки, принимающие Java‑поток вывода. При работе с Python via Java используйте совместимый Java‑поток через JPype, например Java ByteArrayOutputStream, чтобы держать экспортированные данные в памяти.

**Включаются ли скрытые слайды в вывод XPS?**

Скрытые слайды исключаются по умолчанию. Чтобы включить их, установите [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) в `True` перед сохранением.

**Сохраняются ли анимации и переходы между слайдами в XPS?**

Нет. XPS содержит фиксированные страницы, поэтому экспортированные слайды не воспроизводят анимации или эффекты переходов.