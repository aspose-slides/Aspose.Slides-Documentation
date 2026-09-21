---
title: Управление текстовыми полями в презентациях PowerPoint на Python
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/python-net/text-fields/
keywords:
- текстовое поле
- автоматический текст
- номер слайда
- дата и время
- заголовок
- нижний колонтитул
- текстовая часть
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из частей. Обычная [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/) содержит буквальный текст; часть‑поле также имеет [Field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/field/), тип которой определяет автоматически обновляемое значение, например номер слайда или дату. Две части могут отображать одинаковые символы, при этом только одна содержит поле.

Используйте [Portion.field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/field/) чтобы различать их: для обычного текста он равен `None`. [Portion.add_field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/add_field/) преобразует существующую часть в поле. Держите метку и её динамическое значение в отдельных частях, чтобы преобразование значения не заменило также метку.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых рамок и абзацев см. [Управление текстом](/slides/ru/python-net/manage-text/).

## **Создание поля номера слайда**

В следующем полном примере создаётся текстовое поле, содержащее буквальную метку `Slide `, за которой следует автоматически обновляемый номер. Перед добавлением поля задаются размер, насыщенность и цвет номера, затем открывается сохранённая презентация и проверяются тип поля, текст и форматирование. Входной файл не требуется.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Новая презентация начинается с номера слайда 1, поэтому текст равен `Slide 1`, и обе проверки выводят `True`. После переоткрытия номер остаётся полем; это не буквальная `1`. Индексы в проверке относятся к фигуре и частям, созданным в этом примере.

## **Выбор типа поля**

[FieldType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/) предоставляет следующие предопределённые значения. Передайте соответствующее значение в [add_field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/add_field/).

| Значение | Назначение |
|---|---|
| [slide_number](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/slide_number/) | Текущий номер слайда. |
| [date_time](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/date_time/) | Дата/время в формате по умолчанию приложения рендеринга. |
| [date_time1](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/date_time9/) | Предопределённый формат даты или комбинированный формат даты/времени. |
| [date_time10](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/date_time13/) | Предопределённые форматы времени, с опциями для секунд и 12‑часового формата. |
| [header](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/header/) | Поле заголовка; см. ограничения заполнителя и формата ниже. |
| [footer](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/footer/) | Поле нижнего колонтитула. |

Например, [date_time3](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/date_time3/) представляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата даты Python. [language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/language_id/) части и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создание поля из внутренней строки**

Перегрузка строкового параметра метода [add_field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/add_field/) принимает внутренний идентификатор поля. Используйте её, когда нужно сохранить идентификатор, предоставленный другим приложением, у которого нет предопределённого значения. Вы также можете создать объект [FieldType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/__init__/) из идентификатора. [FieldType.internal_string](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fieldtype/internal_string/) раскрывает этот идентификатор для просмотра.

В этом примере сохраняется поле `custom-report-id`, специфичное для приложения, с запасным текстом `Report-042`. Идентификатор не регистрирует вычисление: Aspose.Slides не генерирует идентификаторы отчётов для неизвестного типа. Приложение, которое понимает этот идентификатор, должно предоставить его смысл и обновлять значение.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

После этого цикла PPTX тип остаётся `custom-report-id`, а текст — `Report-042`. Передача строки вроде `%Y-%m-%d` задаст тип поля; она не настроит пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Прочитайте и измените существующее поле через [Field.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/field/type/). Проверьте, что поле существует, прежде чем обращаться к его типу. Чтобы остановить автоматические обновления, вызовите [Portion.remove_field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/remove_field/). Это сохраняет часть и её текущий текст, удаляя связь с полем. Если нужен конкретный фиксированный результат, присвойте этот текст после удаления поля.

Настройку API, связанную с обработкой полей даты/времени, см. в [Presentation.current_date_time](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/current_date_time/). Пример ниже использует явную дату утверждения при преобразовании поля в обычный текст. Кортеж названий месяцев на английском сохраняет фиксированную дату независимо от региональных настроек системы.

Скачайте [sample.pptx](sample.pptx) и разместите его в рабочем каталоге. Файл содержит две именованные текстовые фигуры `UpdatedAt` и `ApprovedDate`, каждая с полем даты/времени, а также обычные текстовые метки. Ниже приведён пример обхода текстовых фигур верхнего уровня на обычных слайдах. Он меняет поля даты/времени на длинный формат даты и делает их курсивом, сохраняя остальное форматирование. Только поля в `ApprovedDate` становятся фиксированным текстом.

Пример распознаёт встроенные внутренние идентификаторы `datetime` и `datetime1`‑`datetime13`. Группы, таблицы, заметки, макеты и шаблоны требуют обхода их собственных контейнеров текста и не охвачены данным примером.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

После переоткрытия `UpdatedAt` имеет тип `datetime3` и остаётся динамичным. `ApprovedDate` не содержит поля и содержит `05 April 2030`. Обе части даты курсивом, при этом их исходный размер шрифта, жирность и цвет сохраняются. Обычные текстовые метки не изменились. Проверка читает первую часть двух известных фигур в предоставленном образце.

## **Сохранение форматирования текста**

Работайте с существующей частью при добавлении поля, изменении его типа или удалении. Эти операции сохраняют форматирование части. Используйте [Portion.portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/portion_format/) для изменения только необходимых свойств, как в примерах для цвета или курсива.

Избегайте перестройки всей текстовой рамки лишь для обновления одного поля: это может привести к потере оригинальных границ частей и их индивидуального форматирования. Также различайте явно установленное форматирование и наследуемое из абзаца, макета или темы. См. [Форматирование текста](/slides/ru/python-net/text-formatting/) для более широких вариантов форматирования.

## **Поля и заполнители заголовка/подвала**

Поле является частью текстовой части. Заполнитель — это фигура с ролью в презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый блок не превращает эту фигуру в заполнитель.

Менеджеры заголовков/подвалов управляют текстом заполнителя и его видимостью на слайдах, макетах и шаблонах, включая распространение на зависимые слайды. Поле номера в пользовательском текстовом блоке может быть полезно, даже если вы не используете заполнитель номера слайда. И наоборот, изменение видимости заполнителя не удаляет поле из несвязанного текстового блока.

Предопределённые типы заголовка и подвала не создают соответствующие заполнители и не предоставляют их содержимое. В частности, обычный слайд PowerPoint не имеет заполнителя заголовка; заголовки относятся к страницам заметок и раздаточным материалам. Не следует полагать, что поле заголовка или подвала в произвольной фигуре автоматически получит текст, настроенный через менеджер заполнителей. Для такого процесса см. [Presentation Headers and Footers](/slides/ru/python-net/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверьте как тип поля, так и получаемый текст после сохранения и переоткрытия. Сохранение идентификатора не доказывает, что приложение может вычислить или отобразить его значение.

| Формат | Поведение поля и ограничения |
|---|---|
| PPTX | Сохраняет внутренние идентификаторы полей вместе с их текстом. При проверках кругового прохода предопределённые типы и пользовательский идентификатор, использованный выше, выжили после сохранения и переоткрытия. Неизвестный пользовательский тип сохранил свой запасный текст; он не получил автоматической логики расчёта. Другое приложение может обрабатывать неподдерживаемые идентификаторы по‑другому. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. При проверках кругового прохода поля номера слайда и предопределённые поля даты/времени выжили после сохранения и переоткрытия. Пользовательское поле в обычном текстовом блоке слайда открылось с его идентификатором, но с текстом `*`; поле заголовка в том же контексте также дало `*`. Не полагайтесь на то, что пользовательские поля или неподдерживаемые контексты полей сохранят видимый текст. |

Для переносимого фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте нужное значение перед сохранением. Это сохраняет выбранный текст, но намеренно прекращает автоматические обновления. Также протестируйте целевое приложение, если его собственный пересчёт полей является частью вашего процесса.

## **FAQ**

**Как определить, является ли отображаемый номер или дата полем?**  
Проверьте [Portion.field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/field/). Значение, отличное от `None`, указывает на поле; один лишь отображаемый текст не может дать ответ.

**Удаление поля удаляет его текст или форматирование?**  
Нет. [remove_field](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/remove_field/) преобразует существующую часть в обычный текст. При необходимости конкретной фиксированной даты или запасного значения задайте его явно после удаления.

**Может ли внутренняя строка определить новый формат даты или формулу?**  
Нет. Она идентифицирует тип поля. Неизвестный идентификатор не предоставляет вычислитель или шаблон формата даты Python. Используйте поддерживаемый предопределённый тип или отформатируйте значение самостоятельно как обычный текст.

**Зачем снова проверять презентацию после её сохранения?**  
Идентификаторы полей, вычисляемый текст и форматирование — это отдельные элементы, которые нужно проверять. При конвертации формата видимый результат может измениться, даже если идентификатор поля остаётся.