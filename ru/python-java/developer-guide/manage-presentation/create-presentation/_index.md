---
title: Создание презентаций в Python через Java
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/python-java/create-presentation/
keywords:
- создать презентацию
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
description: "Создавайте презентации в Python через Java с Aspose.Slides — получайте файлы PPT, PPTX и ODP, пользуйтесь поддержкой OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

Эта статья демонстрирует, как создать презентацию с помощью Aspose.Slides for Python via Java, добавить фигуру с текстом на первый слайд и сохранить результат в файл PPTX. В разделе FAQ рассматриваются форматы вывода, шаблоны, размеры слайдов, использование памяти, многопоточность, лицензирование, цифровые подписи и поддержка VBA.

## **Создание презентации**

Создание файла PowerPoint с нуля в Aspose.Slides for Python via Java так же просто, как создание экземпляра класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) . Конструктор автоматически предоставляет пустую презентацию с одним слайдом, предоставляя вам мгновенную холст для фигур, текста, диаграмм или любого другого контента, необходимого вашему приложению. После того как вы измените этот слайд — или добавите новые — вы можете сохранить результат в формате PPTX, старом PPT или даже OpenDocument. Ниже приведён короткий пример кода, демонстрирующий этот процесс, добавляя простую фигуру на первый слайд.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получить первый слайд по его индексу.
1. Добавить [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) типа [ShapeType.Cloud](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#Cloud) с помощью [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Установить текст фигуры с помощью [TextFrame.setText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#setText).
1. Сохранить презентацию, используя [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Pptx).

Следующий пример требует Aspose.Slides for Python via Java и совместимой среды выполнения Java. Он запускает JVM, если она ещё не запущена, добавляет облако‑фигуру на первый слайд и сохраняет презентацию:

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

    # Добавить фигуру-облако и установить её текст.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Сохранить презентацию в файл PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Новая презентация](new_presentation.png)

## **Часто задаваемые вопросы**

**В какие форматы я могу сохранять новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/python-java/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), [SVG](/slides/ru/python-java/render-slide-as-svg/), и [изображения](/slides/ru/python-java/convert-powerpoint-to-png/), среди прочих.

**Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужном формате; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-java/supported-file-formats/).

**Как контролировать размер/соотношение сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-java/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите, как должен масштабироваться контент.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм = 72 единицы.

**Как работать с очень большими презентациями (с множеством медиа‑файлов), чтобы уменьшить использование памяти?**

Используйте [стратегии управления BLOB](/slides/ru/python-java/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочитайте файловые рабочие процессы вместо полностью in-memory потоков.

**Можно ли создавать/сохранять презентации параллельно?**

Вы не можете работать с одним экземпляром [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-java/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

**Как удалить водяной знак trial и ограничения?**

[Примените лицензию](/slides/ru/python-java/licensing/) один раз на процесс. XML лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе с несколькими потоками.

**Можно ли цифрово подписать созданный PPTX?**

Да. [Цифровые подписи](/slides/ru/python-java/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать VBA‑проекты](/slides/ru/python-java/presentation-via-vba/) и сохранять файлы с включёнными макросами, такие как PPTM/PPSM.