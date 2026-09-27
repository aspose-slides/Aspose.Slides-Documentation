---
title: Создание презентаций в Python через Java
linktitle: Создать презентацию
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
description: "Создавайте презентации в Python через Java с помощью Aspose.Slides — создавайте файлы PPT, PPTX и ODP, пользуйтесь поддержкой OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

В этой статье показано, как создать презентацию с помощью Aspose.Slides for Python via Java, добавить форму с текстом на первый слайд и сохранить результат в файл PPTX. В разделе FAQ рассматриваются форматы вывода, шаблоны, размер слайдов, использование памяти, многопоточность, лицензирование, цифровые подписи и поддержка VBA.

Прежде чем начать, установите Python, JDK, JPype и Aspose.Slides for Python via Java. См. [Установка](/slides/ru/python-java/installation/) для инструкций по Windows, Linux и macOS.

## **Создание презентации**

Создание файла PowerPoint с нуля в Aspose.Slides for Python via Java так же просто, как создание экземпляра класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) . Конструктор автоматически предоставляет пустую презентацию с одним слайдом, давая вам сразу холст для фигур, текста, диаграмм или любого другого содержимого, необходимого вашему приложению. После изменения этого слайда — или добавления новых — вы можете сохранить результат в формат PPTX, устаревший PPT или даже OpenDocument. Приведённый ниже короткий пример кода иллюстрирует этот процесс, добавляя простую форму на первый слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
2. Получите первый слайд по индексу 0.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) типа [ShapeType.Cloud](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#Cloud) с помощью [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) .
4. Установите текст формы, используя [TextFrame.setText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#setText) .
5. Сохраните презентацию, вызвав [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с параметром [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Pptx) .

Следующий пример запускает Java Virtual Machine (JVM), если он ещё не запущен, добавляет форму облака с текстом на первый слайд и сохраняет презентацию. Сохраните его как *create_presentation.py*:

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

    # Добавить форму облака и задать её текст.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Сохранить презентацию в файл PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Запустите скрипт в среде, где вы установили пакеты:

```sh
python create_presentation.py
```

Левый верхний угол облака находится на расстоянии 20 пунктов от левого и верхнего краёв слайда, а облако имеет ширину 200 пунктов и высоту 80 пунктов. Скрипт сохраняет *new_presentation.pptx* в текущий рабочий каталог, создавая один слайд, содержащий облако и его текст. JVM продолжает работать, пока не завершится процесс Python; см. [Ограничения и различия API](/slides/ru/python-java/limitations-and-api-differences/#import-the-library). Без лицензии Aspose.Slides также добавляет текстовое поле с оценочной водяной меткой на каждый сохраняемый слайд; см. [Лицензирование](/slides/ru/python-java/licensing/) .

Результат:

![Новая презентация](new_presentation.png)

## **FAQ**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в форматы [PPTX, PPT и ODP](/slides/ru/python-java/save-presentation/), а также экспортировать в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), [SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/) и [изображения](/slides/ru/python-java/convert-powerpoint-to-png/), и др.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/python-java/supported-file-formats/) .

**Как контролировать размер/соотношение сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/python-java/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите способ масштабирования содержимого.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как обрабатывать очень большие презентации (с множеством медиафайлов) для снижения использования памяти?**

Используйте [стратегии управления BLOB](/slides/ru/python-java/manage-blob/), ограничивайте хранение в памяти с помощью временных файлов и отдавайте предпочтение потокам работы с файлами вместо полностью в‑памяти потоков.

**Могу ли я создавать/сохранять презентации параллельно?**

Вы не можете работать с одним экземпляром [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/python-java/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

**Как удалить пробную водяную метку и ограничения?**

[Примените лицензию](/slides/ru/python-java/licensing/) один раз на процесс. XML лицензии должен оставаться без изменений, а настройка лицензии должна быть синхронизирована, если задействовано несколько потоков.

**Могу ли я цифрово подписать создаваемый PPTX?**

Да. [Цифровые подписи](/slides/ru/python-java/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/python-java/presentation-via-vba/) и сохранять файлы с включёнными макросами, такие как PPTM/PPSM.