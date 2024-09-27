---
title: Печать презентации
type: docs
weight: 50
url: /ru/python-net/print-presentation/
keywords: "Печать PowerPoint, PPT, PPTX, Печать презентации, Python, Принтер, Параметры печати"
description: "Печать презентации PowerPoint в Python"
---
Aspose.Slides для Python предоставляет 4 перегруженных метода `print`, которые позволяют вам печатать презентации. Перегруженные методы принимают разные аргументы, поэтому вы всегда найдете метод, который соответствует вашим потребностям в печати.

## **Печать на умолчательном принтере**

Эта простая операция печати используется для печати всех слайдов в презентации PowerPoint через умолчательный принтер системы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте презентацию, которую вы хотите напечатать.
2. Вызовите метод `print` (без параметров).

Этот код на Python показывает, как напечатать презентацию PowerPoint:

```python
import aspose.slides as slides

# Загрузите презентацию
presentation = slides.Presentation("Print.ppt")

# Вызовите метод print для печати всей презентации на умолчательном принтере
presentation.print()
```

## **Печать на конкретном принтере**

Эта операция используется для печати всех слайдов в презентации PowerPoint через конкретный принтер.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте презентацию, которую вы хотите напечатать.
2. Вызовите метод `print` и передайте имя принтера в виде строки.

Этот код на Python показывает, как напечатать презентацию PowerPoint, используя конкретный принтер:

```python
import aspose.slides as slides

try:
    # Загрузите презентацию
    with slides.Presentation("pres.pptx") as pres:
        # Вызовите метод print для печати всей презентации на желаемом принтере
        pres.print("Пожалуйста, укажите имя вашего принтера здесь")
except:
    print("Пожалуйста, укажите имя принтера как строковый параметр для метода Print класса Presentation")
```

## **Динамическая настройка параметров печати**

Используя свойства класса `PrinterSettings`, вы можете задать параметры, определяющие операцию печати. Вы можете указать, сколько копий нужно напечатать, следует ли распечатать слайды в альбомной или портретной ориентации, ваши предпочтительные поля и т.д.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте презентацию, которую вы хотите напечатать.
2. Создайте экземпляр класса `PrinterSettings`.
3. Укажите ваши предпочтительные параметры для операции печати:
   * количество копий
   * ориентация страницы
   * размеры полей и т.д.
4. Вызовите метод `print`.

Этот код на Python показывает, как напечатать презентацию PowerPoint с определенными параметрами печати: 

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    printerSettings = drawing.printing.PrinterSettings()
    printerSettings.copies = 2
    printerSettings.default_page_settings.landscape = True
    printerSettings.default_page_settings.margins.left = 10
    pres.print(printerSettings)
```