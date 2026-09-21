---
title: Управление текстовыми полями в презентациях PowerPoint на Python через Java
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/python-java/text-fields/
keywords:
- текстовое поле
- автоматический текст
- номер слайда
- дата и время
- заголовок
- нижний колонтитул
- текстовый фрагмент
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для Python через Java. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из частей (portions). Обычная [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) содержит буквальный текст; часть‑поле также имеет [Field](https://reference.aspose.com/slides/ru/python-java/aspose.slides/field/), тип которого указывает автоматически обновляемое значение, например номер слайда или дату. Две части могут отображать одинаковые символы, но только одна из них содержит поле.

Используйте [Portion.getField](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getField), чтобы различать их: для обычного текста он возвращает `None`. [Portion.addField](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#addField) преобразует существующую часть в поле. Держите метку и её динамическое значение в отдельных частях, чтобы преобразование значения не заменило также метку.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых рамок и абзацев см. [Manage Text](/slides/ru/python-java/manage-text/).

## **Создание поля номера слайда**

Следующий полностью работающий пример создает текстовое поле, содержащее буквальную метку `Slide ` и автоматически обновляемый номер. Он задает размер, жирность и цвет числа перед добавлением поля, затем открывает сохранённую презентацию и проверяет тип поля, текст и форматирование. Входной файл не требуется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Новая презентация начинается с номера слайда 1, поэтому текст будет `Slide 1`, и оба условия выводят `True`. Число остаётся полем после повторного открытия; это не буквальная `1`. Индексы в проверке относятся к фигуре и частям, созданным в этом примере.

## **Выбор типа поля**

[FieldType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/) предоставляет следующие методы для получения предопределённых значений. Передайте соответствующее значение в [addField](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#addField).

| Метод | Назначение |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getSlideNumber) | Текущий номер слайда. |
| [getDateTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getDateTime) | Дата/время в формате по умолчанию приложения‑рендерера. |
| [getDateTime1](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getDateTime9) | Предопределённые форматы даты или комбинированные форматы даты/времени. |
| [getDateTime10](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getDateTime13) | Предопределённые форматы времени, с опциями секунд и 12‑часового формата. |
| [getHeader](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getHeader) | Поле заголовка; см. ограничения placeholders и формата ниже. |
| [getFooter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getFooter) | Поле нижнего колонтитула. |

Например, [getDateTime3](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getDateTime3) представляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата даты Python. Язык, установленный через [setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId), и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создание поля из внутренней строки**

Перегрузка строка метода [addField](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#addField) принимает внутренний идентификатор поля. Используйте её, когда нужно сохранить идентификатор, предоставленный другим приложением, для которого нет предопределённого значения. Также можно создать [FieldType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#FieldType) из идентификатора. [FieldType.getInternalString](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fieldtype/#getInternalString) раскрывает этот идентификатор для проверки.

В этом примере сохраняется поле `custom-report-id`, специфичное для приложения, с резервным текстом `Report-042`. Идентификатор не регистрирует вычисление: Aspose.Slides не генерирует идентификаторы отчётов для неизвестных типов. Приложение, понимающее этот идентификатор, должно предоставить его смысл и обновлять значение.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

После прохождения данного PPTX‑циклица тип будет `custom-report-id`, а текст — `Report-042`. Передача строки вроде `yyyy-MM-dd` назовёт тип поля; она не настроит пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Измените существующее поле через [Field.setType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/field/#setType). Убедитесь, что поле существует, прежде чем обращаться к его типу. Чтобы остановить автоматическое обновление, вызовите [Portion.removeField](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#removeField). Это сохраняет часть и её текущий текст, удаляя связь с полем. Если нужен конкретный фиксированный значение, присвойте его после удаления поля.

Для настройки API, связанной с обработкой полей даты/времени, смотрите [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#setCurrentDateTime). Пример ниже использует явную дату утверждения при преобразовании поля в обычный текст.

Скачайте [sample.pptx](sample.pptx) и поместите его в рабочий каталог. Файл содержит две именованные текстовые фигуры `UpdatedAt` и `ApprovedDate`, каждая с полем даты/времени, а также обычные текстовые метки. Приведённый пример проходит по верхнеуровневым текстовым фигурам обычных слайдов. Он меняет поля даты/времени на формат «длинная дата» и делает их курсивом, сохраняет остальное форматирование. Только поля в `ApprovedDate` превращаются в фиксированный текст.

Пример распознаёт встроенные внутренние идентификаторы `datetime` и `datetime1`…`datetime13`. Группы, таблицы, заметки, макеты и шаблоны требуют обхода собственных текстовых контейнеров и находятся за пределами данного примера.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Используйте английские названия месяцев независимо от локали системы.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

После повторного открытия `UpdatedAt` имеет тип `datetime3` и остаётся динамическим. `ApprovedDate` не содержит поля и содержит `05 April 2030`. Оба текстовых фрагмента даты – курсив, а их исходный размер шрифта, жирность и цвет остаются без изменений. Обычные метки текста остаются неизменными. Проверка читает первую часть двух известных фигур в предоставленном образце.

## **Сохранение форматирования текста**

Работайте с существующей частью при добавлении поля, изменении его типа или удалении. Эти операции сохраняют форматирование части. Используйте [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getPortionFormat), чтобы менять только необходимые свойства, как показывают примеры для цвета или курсива.

Избегайте полной перестройки текстовой рамки только ради обновления одного поля: такой подход может потерять исходные границы частей и их индивидуальное форматирование. Также различайте явно установленное форматирование и наследуемое из абзаца, макета или темы. Смотрите [Text Formatting](/slides/ru/python-java/text-formatting/) для более широких возможностей форматирования.

## **Поля и placeholders заголовков/колонтитулов**

Поле является частью текстовой части. Placeholder — это фигура с ролью в презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый бокс не превращает эту фигуру в placeholder.

Менеджеры заголовков/колонтитулов управляют текстом placeholders и их видимостью на слайдах, макетах и шаблонах, включая распространение на зависимые слайды. Поэтому поле номера в пользовательском текстовом боксе может быть полезно даже при отсутствии использования placeholder для номера слайда. Напротив, изменение видимости placeholder не удаляет поле из несвязанного текстового бокса.

Предопределённые типы заголовков и колонтитулов не создают соответствующие placeholders и не заполняют их содержимым. В частности, обычный слайд PowerPoint не имеет placeholder‑заголовка; заголовки относятся к страницам заметок и раздаточным материалам. Не следует полагать, что поле заголовка или нижнего колонтитула в произвольной фигуре автоматически получит текст, настроенный через менеджер placeholders. Для такого сценария см. [Presentation Headers and Footers](/slides/ru/python-java/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверяйте как тип поля, так и полученный текст после сохранения и повторного открытия. Сохранение идентификатора не доказывает, что приложение способно вычислить или отобразить его значение.

| Формат | Поведение поля и ограничения |
|---|---|
| PPTX | Хранит внутренние идентификаторы полей вместе с их текстом. При проверках в цикле сохранения/открытия предопределённые типы и пользовательский идентификатор из примера сохраняются. Неизвестный пользовательский тип сохраняет свой резервный текст; он не получает логики автоматических вычислений. Другое приложение может по‑разному обрабатывать неподдерживаемые идентификаторы. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. При проверках в цикле номер слайда и предопределённые поля даты/времени сохраняются. Пользовательское поле в обычном текстовом боксе открывается с его идентификатором, но текстом `*`; поле заголовка в том же контексте тоже даёт `*`. Не полагайтесь на сохранение видимого текста пользовательских или неподдерживаемых полей. |

Для переносимого фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте желаемое значение перед сохранением. Это сохраняет выбранный текст, но намеренно отключает автоматические обновления. Тестируйте целевое приложение, если его собственный пересчёт полей входит в ваш рабочий процесс.

## **FAQ**

**Как определить, является ли отображаемый номер или дата полем?**

Проверьте [Portion.getField](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getField). Значение, отличное от `None`, указывает на поле; по самому отображаемому тексту определить нельзя.

**Удаляет ли удаление поля его текст или форматирование?**

Нет. [removeField](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#removeField) преобразует существующую часть в обычный текст. При необходимости присвойте явное значение после удаления, если нужен определённый фиксированный текст или резервное значение.

**Может ли внутренняя строка определить новый формат даты или формулу?**

Нет. Она лишь идентифицирует тип поля. Неизвестный идентификатор не предоставляет вычислителя или шаблона формата даты Python. Используйте поддерживаемый предопределённый тип или форматируйте значение сами как обычный текст.

**Почему после сохранения презентацию нужно проверять ещё раз?**

Идентификаторы полей, вычисленный текст и форматирование — это отдельные аспекты, которые следует проверять. Конверсия формата может изменить видимый результат, даже если идентификатор поля остаётся.