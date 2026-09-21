---
title: Управление текстовыми полями в презентациях PowerPoint на .NET
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/net/text-fields/
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
- C#
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для .NET. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из частей. Обычный [IPortion](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/) содержит буквальный текст; часть‑поле также имеет [IField](https://reference.aspose.com/slides/ru/net/aspose.slides/ifield/), тип которого определяет автоматически обновляемое значение, например номер слайда или дату. Две части могут отображать одинаковые символы, но только одна содержит поле.

Используйте [IPortion.Field](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/field/) для различения: для обычного текста он равен `null`. [IPortion.AddField](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/addfield/) преобразует существующую часть в поле. Храните подпись и её динамическое значение в отдельных частях, чтобы преобразование значения не заменило подпись.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых рамок и абзацев см. [Manage Text](/slides/ru/net/manage-text/).

## **Создание поля номера слайда**

Следующий полный пример создаёт текстовое поле, содержащее буквальную подпись `Slide ` и автоматически обновляемый номер. Он задаёт размер, толщину и цвет номера перед добавлением поля, затем открывает сохранённую презентацию и проверяет тип поля, текст и форматирование. Входной файл не требуется.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Новая презентация начинается с номера слайда 1, поэтому текст `Slide 1`, и обе проверки выводят `True`. Номер остаётся полем после повторного открытия; это не буквальная `1`. Приведения типов и индексы в проверке относятся к фигуре и частям, созданным этим примером.

## **Выбор типа поля**

[FieldType](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/) реализует [IFieldType](https://reference.aspose.com/slides/ru/net/aspose.slides/ifieldtype/) и предоставляет следующие предопределённые значения. Передайте нужное значение в [AddField](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/addfield/).

| Value | Purpose |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/slidenumber/) | Текущий номер слайда. |
| [DateTime](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/datetime/) | Дата/время в формате приложения по умолчанию. |
| [DateTime1](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/datetime9/) | Предопределённые форматы даты или комбинированные форматы даты/времени. |
| [DateTime10](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/datetime13/) | Предопределённые форматы времени с вариантами секунд и 12‑часового формата. |
| [Header](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/header/) | Поле заголовка; см. ограничения заполнителя и формата ниже. |
| [Footer](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/footer/) | Поле нижнего колонтитула. |

Например, [DateTime3](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/datetime3/) представляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата даты .NET. Параметр [LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/) части и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создание поля из внутренней строки**

Перегрузка строки метода [AddField](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/addfield/) принимает внутренний идентификатор поля. Используйте её, когда нужно сохранить идентификатор, предоставленный другим приложением, у которого нет предопределённого значения. Можно также создать [FieldType](https://reference.aspose.com/slides/ru/net/aspose.slides/fieldtype/fieldtype/) из идентификатора. Свойство [IFieldType.InternalString](https://reference.aspose.com/slides/ru/net/aspose.slides/ifieldtype/internalstring/) раскрывает этот идентификатор для просмотра.

В этом примере сохраняется поле `custom-report-id`, специфичное для приложения, с запасным текстом `Report-042`. Идентификатор не регистрирует вычисление: Aspose.Slides не генерирует идентификаторы отчётов для неизвестных типов. Приложение, понимающее этот идентификатор, должно обеспечить его смысл и обновлять значение.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

После прохода через PPTX тип остаётся `custom-report-id`, а текст `Report-042`. Передача строки вида `yyyy-MM-dd` назовёт тип поля; она не задаст пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Чтение и изменение существующего поля происходит через [IField.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/ifield/type/). Убедитесь, что поле существует, прежде чем обращаться к его типу. Чтобы отключить автоматическое обновление, вызовите [IPortion.RemoveField](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/removefield/). Это сохраняет часть и её текущий текст, удаляя связь с полем. Если требуется конкретное фиксированное значение, назначьте этот текст после удаления поля.

Для настройки обработки полей даты/времени см. [Presentation.CurrentDateTime](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/currentdatetime/). В примере ниже при преобразовании поля в обычный текст используется конкретная дата утверждения.

Скачайте [sample.pptx](sample.pptx) и разместите её в рабочем каталоге. Файл содержит две именованные текстовые фигуры — `UpdatedAt` и `ApprovedDate`, каждая с полем даты/времени, плюс обычные подписи. Приведённый пример проходит по верхнеуровневым текстовым фигурам обычных слайдов. Он меняет поля даты/времени на длинный формат даты и делает их курсивом, сохраняет остальное форматирование. Только поля в `ApprovedDate` превращаются в фиксированный текст.

Пример распознаёт встроенные внутренние идентификаторы `datetime` и `datetime1` — `datetime13`. Группы, таблицы, заметки, макеты и шаблоны требуют обхода собственных контейнеров текста и находятся вне области этого примера.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

После повторного открытия `UpdatedAt` имеет тип `datetime3` и остаётся динамичным. `ApprovedDate` не содержит поля и содержит `05 April 2030`. Оба текста даты курсивом, их исходный размер шрифта, полужирность и цвет остаются неизменными. Обычные подписи текста не изменились. Проверка читает первую часть двух известных фигур в предоставленном образце.

## **Сохранение форматирования текста**

Работайте с существующей частью при добавлении, изменении типа или удалении поля. Эти операции сохраняют форматирование части. Используйте [IPortion.PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/portionformat/) для изменения только необходимых свойств, как в примерах для цвета или курсива.

Избегайте перестройки всей текстовой рамки только для обновления одного поля: это может привести к потере исходных границ частей и их индивидуального форматирования. Также различайте явно установленное форматирование и форматирование, унаследованное от абзаца, макета или темы. Смотрите [Text Formatting](/slides/ru/net/text-formatting/) для более широких возможностей форматирования.

## **Поля и заполнители заголовков/нижних колонтитулов**

Поле является частью текстовой части. Заполнитель — это фигура с ролью в презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый блок не преобразует эту фигуру в заполнителя.

Менеджеры заголовков/нижних колонтитулов управляют текстом заполнителя и его видимостью на слайдах, макетах и шаблонах, включая распространение на зависимые слайды. Поле номера в пользовательском текстовом блоке может быть полезным даже при отсутствии использования заполнителя номера слайда. И наоборот, изменение видимости заполнителя не удаляет поле из несвязанного текстового блока.

Предопределённые типы заголовков и нижних колонтитулов не создают соответствующие заполнители и не обеспечивают их содержимое. В частности, обычный слайд PowerPoint не имеет заполнителя заголовка; заголовки находятся на страницах заметок и раздаточных материалов. Не полагайтесь на то, что поле заголовка или нижнего колонтитула в произвольной фигуре автоматически получит текст, настроенный через менеджер заполнителей. Для такого сценария см. [Presentation Headers and Footers](/slides/ru/net/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверьте как тип поля, так и получившийся текст после сохранения и повторного открытия. Сохранение идентификатора не доказывает, что приложение сможет вычислить или отобразить его значение.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Хранит внутренние идентификаторы полей вместе с их текстом. В проверках кругового прохода предопределённые типы и пользовательский идентификатор, использованный выше, сохранились после сохранения и открытия. Неизвестный пользовательский тип сохранил запасной текст; он не получил логику автоматических вычислений. Другое приложение может иначе обрабатывать неподдерживаемые идентификаторы. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. В проверках кругового прохода номера слайдов и предопределённые поля даты/времени сохранились после сохранения и открытия. Пользовательское поле в обычном текстовом блоке открылось с его идентификатором, но с текстом `*`; поле заголовка в том же контексте также дало `*`. Не полагайтесь на то, что пользовательские поля или неподдерживаемые контексты полей сохранят видимый текст. |

Для переносимого фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте нужное значение перед сохранением. Это сохраняет выбранный текст, но намеренно останавливает автоматические обновления. Тестируйте целевое приложение, если его собственный пересчёт полей является частью вашего рабочего процесса.

## **FAQ**

**Как определить, является ли отображаемый номер или дата полем?**

Проверьте [IPortion.Field](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/field/). Ненулевое значение идентифицирует поле; один лишь отображаемый текст не может сказать об этом.

**Удаляет ли удаление поля его текст или форматирование?**

Нет. [RemoveField](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/removefield/) преобразует существующую часть в обычный текст. При необходимости задайте явное значение после удаления, если нужен фиксированный текст или запасное значение.

**Можно ли через внутреннюю строку задать новый формат даты или формулу?**

Нет. Она лишь идентифицирует тип поля. Неизвестный идентификатор не предоставляет вычислителя или шаблона формата даты .NET. Используйте поддерживаемый предопределённый тип или отформатируйте значение самостоятельно как обычный текст.

**Почему нужно проверять презентацию ещё раз после её сохранения?**

Идентификаторы полей, вычисленный текст и форматирование — это отдельные вещи, которые следует проверять. Конверсия формата может изменить видимый результат, даже если идентификатор поля остаётся.