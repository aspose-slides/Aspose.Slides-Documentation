---
title: Создание презентаций в Python через Java
linktitle: Создание презентации
type: docs
weight: 10
url: /ru/python-java/create-presentation/
keywords:
- создание презентации
- новая презентация
- создать PPT
- новый PPT
- создать PPTX
- новый PPTX
- создать ODP
- новый ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте презентации в Python через Java с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, получайте преимущества поддержки OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

В этой статье показано, как создать презентацию с помощью Aspose.Slides для Python через Java, добавить форму с текстом на первый слайд и сохранить результат в файл PPTX. В разделе FAQ рассматриваются форматы вывода, шаблоны, размер слайдов, использование памяти, многопоточность, лицензирование, цифровые подписи и поддержка VBA.

## **Создание презентации**

Создание PowerPoint‑файла «с нуля» в Aspose.Slides для Python через Java так же просто, как создание экземпляра класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). Конструктор автоматически создает пустую презентацию с одним слайдом, предоставляя сразу же полотно для фигур, текста, диаграмм или любого другого содержимого, нужного вашему приложению. После того как вы измените этот слайд – или добавите новые – можно сохранить результат в PPTX, старый PPT или даже форматы OpenDocument. Ниже приведён короткий пример кода, демонстрирующий этот процесс посредством добавления простой фигуры на первый слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите первый слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) типа [ShapeType.Cloud](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#Cloud) с помощью [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Установите текст формы с помощью [TextFrame.setText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#setText).
1. Сохраните презентацию, вызвав [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Pptx).

Следующий пример требует Aspose.Slides для Python через Java и совместимую среду выполнения Java. Он запускает JVM, если она ещё не запущена, добавляет облако на первый слайд и сохраняет презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Создать презентацию с одним пустым слайдом.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить форму облака и установить её текст.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Сохранить презентацию в файл PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Новая презентация](new_presentation.png)

## **FAQ**

**В какие форматы можно сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-java/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), [SVG](/slides/ru/python-java/render-slide-as-svg/), и [images](/slides/ru/python-java/convert-powerpoint-to-png/), среди прочего.

**Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и подобные [поддерживаются](/slides/ru/python-java/supported-file-formats/).

**Как задать размер/соотношение сторон слайдов при создании презентации?**

Установите [размер слайда](/slides/ru/python-java/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите способ масштабирования содержимого.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как обрабатывать очень большие презентации (с множеством медиафайлов), чтобы снизить использование памяти?**

Используйте [стратегии управления BLOB](/slides/ru/python-java/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и отдавайте предпочтение файловым рабочим процессам вместо полностью оперативных потоков.

**Можно ли создавать/сохранять презентации параллельно?**

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) из [многих потоков](/slides/ru/python-java/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

**Как удалить пробный водяной знак и ограничения?**

[Примените лицензию](/slides/ru/python-java/licensing/) один раз на процесс. XML лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована, если используется несколько потоков.

**Могу ли я цифрово подписать созданный PPTX?**

Да. [Цифровые подписи](/slides/ru/python-java/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-java/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.