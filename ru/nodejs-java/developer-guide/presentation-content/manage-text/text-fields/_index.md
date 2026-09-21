---
title: Управление текстовыми полями в презентациях PowerPoint на JavaScript
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для Node.js через Java. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из частей. Обычная [Portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/) содержит буквальный текст; часть‑поле также имеет [Field](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/field/), тип которого определяет автоматически обновляемое значение, например номер слайда или дату. Две части могут отображать одинаковые символы, но только одна содержит поле.

Используйте [Portion.getField](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#getField), чтобы отличать их: для обычного текста она возвращает `null`. [Portion.addField](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#addField) преобразует существующую часть в поле. Храните подпись и её динамическое значение в отдельных частях, чтобы преобразование значения не заменило подпись.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых фреймов и абзацев см. [Manage Text](/slides/ru/nodejs-java/manage-text/).

## **Создание поля номера слайда**

Следующий полный пример создаёт текстовое поле, содержащее буквальную подпись `Slide ` и автоматически обновляемый номер. Он задаёт размер, начертание и цвет номера перед добавлением поля, затем открывает сохранённую презентацию и проверяет тип поля, текст и форматирование. Входной файл не требуется.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Новая презентация начинается с номера слайда 1, поэтому текст `Slide 1`, и оба проверки выводят `true`. Номер остаётся полем после повторного открытия; это не буквальный `1`. Индексы в проверке относятся к фигуре и частям, созданным этим примером.

## **Выбор типа поля**

[FieldType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/) предоставляет следующие методы для получения предопределённых значений. Передайте соответствующее значение в [addField](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#addField).

| Метод | Назначение |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Текущий номер слайда. |
| [getDateTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Дата/время в формате по умолчанию приложения‑рендерера. |
| [getDateTime1](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Предопределённые форматы даты или совмещённые форматы даты/времени. |
| [getDateTime10](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Предопределённые форматы времени с опциями секунд и 12‑часового часовного цикла. |
| [getHeader](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getHeader) | Поле заголовка; см. ограничения плейсхолдера и формата ниже. |
| [getFooter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getFooter) | Поле нижнего колонтитула. |

Например, [getDateTime3](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getDateTime3) представляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата даты. Язык, установленный через [setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создание поля из внутренней строки**

Перегрузка строки метода [addField](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#addField) принимает внутренний идентификатор поля. Используйте её, когда необходимо сохранить идентификатор, поставляемый другим приложением, для которого нет предопределённого значения. Вы также можете построить [FieldType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/) из этого идентификатора. [FieldType.getInternalString](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fieldtype/#getInternalString) раскрывает этот идентификатор для проверки.

В этом примере сохраняется пользовательское поле `custom-report-id` с запасным текстом `Report-042`. Идентификатор не регистрирует вычисление: Aspose.Slides не генерирует идентификаторы отчётов для неизвестных типов. Приложение, понимающее этот идентификатор, должно задавать его смысл и обновлять значение.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

После этого кругового прохода PPTX тип `custom-report-id`, а текст `Report-042`. Передача строки вроде `yyyy-MM-dd` назовет тип поля; она не настроит пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Измените существующее поле через [Field.setType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/field/#setType). Проверьте, что поле существует, перед тем как обращаться к его типу. Чтобы остановить автоматические обновления, вызовите [Portion.removeField](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#removeField). Это сохраняет часть и её текущий текст, удаляя связь с полем. Если нужен конкретный фиксированный результат, присвойте нужный текст после удаления поля.

Для настройки, связанной с обработкой полей даты/времени, см. [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Пример ниже использует явную дату утверждения при преобразовании поля в обычный текст.

Скачайте [sample.pptx](sample.pptx) и разместите его в рабочей директории. Файл содержит два именованных текстовых объекта `UpdatedAt` и `ApprovedDate`, каждый с полем даты/времени, а также обычные подписи. Приведённый пример перебирает текстовые объекты верхнего уровня на обычных слайдах. Он меняет поля даты/времени на длинный формат даты и делает их курсивом, сохраняя остальное форматирование. Только поля в `ApprovedDate` становятся фиксированным текстом.

Дата утверждения — 5 апреля 2030 года; индексы месяцев в JavaScript начинаются с нуля, поэтому апрель `3`. Для построения и форматирования используется UTC, чтобы дата не зависела от локального часового пояса.

Образец распознаёт встроенные внутренние идентификаторы `datetime` и `datetime1`‑`datetime13`. Группы, таблицы, заметки, разметки и шаблоны требуют обхода собственных контейнеров текста и находятся за пределами данного примера.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

После повторного открытия `UpdatedAt` имеет тип `datetime3` и остаётся динамическим. `ApprovedDate` не содержит поля и содержит `05 April 2030`. Оба текстовых фрагмента даты курсивные, а их исходный размер шрифта, полужирное начертание и цвет сохранены. Обычные подписи неизменны. Проверка читает первую часть двух известных фигур в предоставленном образце.

## **Сохранение форматирования текста**

Работайте с существующей частью при добавлении поля, изменении его типа или удалении. Эти операции сохраняют форматирование части. Используйте [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#getPortionFormat), чтобы менять только нужные свойства, как в примерах для цвета или курсива.

Избегайте полной перестройки текстового фрейма только для обновления одного поля: такой подход может потерять границы исходных частей и их индивидуальное форматирование. Также различайте явно заданное форматирование и наследуемое от абзаца, разметки или темы. См. [Text Formatting](/slides/ru/nodejs-java/text-formatting/) для более широких возможностей форматирования.

## **Поля и плейсхолдеры заголовков/нижних колонтитулов**

Поле является частью текстовой части. Плейсхолдер — это объект с ролью презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый блок не превращает объект в плейзхолдер.

Менеджеры заголовков/нижних колонтитулов управляют текстом плейсхолдера и его видимостью на слайдах, разметках и шаблонах, включая распространение на зависимые слайды. Поле номера в пользовательском текстовом блоке может быть полезным, даже если вы не используете плейсхолдер номера слайда. И наоборот, изменение видимости плейсхолдера не удаляет поле из несвязанного текстового блока.

Предопределённые типы заголовка и нижнего колонтитула не создают соответствующие плейсхолдеры и не поставляют их содержимое. В частности, обычный слайд PowerPoint не имеет плейсхолдера заголовка; заголовки относятся к страницам заметок и раздаточным материалам. Не предполагаете, что поле заголовка или нижнего колонтитула в произвольном объекте автоматически получит текст, сконфигурированный через менеджер плейсхолдеров. Для такого процесса см. [Presentation Headers and Footers](/slides/ru/nodejs-java/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверяйте как тип поля, так и получаемый текст после сохранения и повторного открытия. Сохранение идентификатора не гарантирует, что приложение сможет вычислить или отобразить его значение.

| Формат | Поведение поля и ограничения |
|---|---|
| PPTX | Хранит внутренние идентификаторы полей вместе с их текстом. При проверках кругового прохода предопределённые типы и пользовательский идентификатор из примера сохранились после сохранения и повторного открытия. Неизвестный пользовательский тип сохранил запасной текст; он не получил логику автоматического расчёта. Другое приложение может по‑разному обрабатывать неподдерживаемые идентификаторы. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. При проверках кругового прохода поля номера слайда и предопределённые поля даты/времени сохранились после сохранения и повторного открытия. Пользовательское поле в обычном текстовом блоке открылось с его идентификатором, но с текстом `*`; поле заголовка в том же контексте также дало `*`. Не полагайтесь на сохранение видимого текста пользовательских полей или неподдерживаемых контекстов. |

Для переносимого фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте требуемое значение перед сохранением. Это сохраняет выбранный текст, но сознательно останавливает автоматические обновления. Тестируйте целевое приложение, если его собственный пересчёт полей входит в ваш рабочий процесс.

## **FAQ**

**Как определить, является ли отображаемый номер или дата полем?**

Проверьте [Portion.getField](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#getField). Некоторая не‑null‑значение указывает на поле; один лишь отображаемый текст такой информации не даёт.

**Удаляет ли удаление поля его текст или форматирование?**

Нет. [removeField](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#removeField) преобразует существующую часть в обычный текст. При необходимости присвойте явное значение позже, если нужен фиксированный текст или запасное значение.

**Может ли внутренняя строка определить новый формат даты или формулу?**

Нет. Она лишь идентифицирует тип поля. Неизвестный идентификатор не предоставляет механизм вычисления или шаблон формата даты. Используйте поддерживаемый предопределённый тип или оформляйте значение самостоятельно как обычный текст.

**Почему проверять презентацию снова после её сохранения?**

Идентификаторы полей, рассчитанный текст и форматирование — отдельные аспекты, требующие проверки. Конверсия формата может изменить видимый результат, даже если идентификатор поля остаётся.