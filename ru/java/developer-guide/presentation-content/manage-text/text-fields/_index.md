---
title: Управление текстовыми полями в презентациях PowerPoint на Java
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/java/text-fields/
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
- Java
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для Java. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из фрагментов. Обычный [IPortion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/) содержит буквальный текст; фрагмент поля также имеет [IField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifield/), тип которого определяет автоматически обновляемое значение, например номер слайда или дату. Два фрагмента могут отображать одинаковые символы, при этом только один из них содержит поле.

Используйте [IPortion.getField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#getField--) , чтобы различать их: для обычного текста он возвращает `null`. [IPortion.addField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) преобразует существующий фрагмент в поле. Держите подпись и её динамическое значение в отдельных фрагментах, чтобы преобразование значения не заменило подпись.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых фреймов и абзацев см. [Управление текстом](/slides/ru/java/manage-text/).

## **Создание поля номера слайда**

Ниже приведён полный пример, который создаёт текстовое поле, содержащее буквальную подпись `Slide ` и автоматически обновляемый номер. Перед добавлением поля он задаёт размер, толщину и цвет номера, затем открывает сохранённую презентацию и проверяет тип поля, текст и форматирование. Входной файл не требуется.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Новая презентация начинается с номера слайда 1, поэтому текст выглядит как `Slide 1`, и обе проверки выводят `true`. Номер остаётся полем после повторного открытия; это не буквальная `1`. Приведения типов и индексы в проверке относятся к фигуре и фрагментам, созданным в этом примере.

## **Выбор типа поля**

[FieldType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/) реализует [IFieldType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifieldtype/) и предоставляет следующие методы для получения предопределённых значений. Передайте соответствующее значение в [addField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Метод | Назначение |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Текущий номер слайда. |
| [getDateTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getDateTime--) | Дата/время в формате по умолчанию приложения, выполняющего рендеринг. |
| [getDateTime1](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getDateTime9--) | Предопределённые форматы даты или комбинированные форматы даты/времени. |
| [getDateTime10](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getDateTime13--) | Предопределённые форматы времени с опциями секунд и 12‑часового формата. |
| [getHeader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getHeader--) | Поле заголовка; см. ограничения по заполнителям и формату ниже. |
| [getFooter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getFooter--) | Поле нижнего колонтитула. |

Например, [getDateTime3](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#getDateTime3--) представляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата даты Java. Язык, установленный с помощью [setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создание поля из внутренней строки**

Перегрузка метода [addField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#addField-java.lang.String-) с параметром string принимает внутренний идентификатор поля. Используйте её, когда нужно сохранить идентификатор, предоставленный другим приложением, у которого нет предопределённого значения. Также можно создать [FieldType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) из этого идентификатора. [IFieldType.getInternalString](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifieldtype/#getInternalString--) раскрывает этот идентификатор для просмотра.

В этом примере сохраняется специфическое для приложения поле `custom-report-id` с резервным текстом `Report-042`. Идентификатор не регистрирует вычисление: Aspose.Slides не генерирует идентификаторы отчётов для неизвестного типа. Приложение, которое понимает этот идентификатор, должно предоставить его смысл и обновлять значение.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

После этого кругового прохода PPTX тип остаётся `custom-report-id`, а текст — `Report-042`. Передача строки вроде `yyyy-MM-dd` задаст тип поля; она не настроит пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Измените существующее поле через [IField.setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Убедитесь, что поле существует, прежде чем обращаться к его типу. Чтобы остановить автоматическое обновление, вызовите [IPortion.removeField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#removeField--). Это сохраняет фрагмент и его текущий текст, удаляя связь с полем. Если нужен конкретный фиксированный значение, присвойте этот текст после удаления поля.

Для настройки API, связанной с обработкой полей даты/времени, см. [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Пример ниже использует явную дату утверждения при преобразовании поля в обычный текст.

Скачайте [sample.pptx](sample.pptx) и поместите его в рабочий каталог. Он содержит две именованные текстовые фигуры, `UpdatedAt` и `ApprovedDate`, каждая с полем даты/времени, а также обычные текстовые подписи. Приведённый пример проходит по верхнеуровневым текстовым фигурам обычных слайдов. Он меняет поля даты/времени на формат «длинная дата» и делает их курсивом, сохраняя прочее форматирование. Только поля в `ApprovedDate` становятся фиксированным текстом.

Образец распознаёт встроенные внутренние идентификаторы `datetime` и `datetime1` … `datetime13`. Группы, таблицы, заметки, макеты и мастеры требуют обхода собственных текстовых контейнеров и находятся вне области этого примера.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

После повторного открытия `UpdatedAt` имеет тип `datetime3` и остаётся динамичным. `ApprovedDate` не содержит поля и содержит `05 April 2030`. Оба фрагмента даты курсивом, а их исходный размер шрифта, настройка полужирного и цвет остаются неизменными. Обычные текстовые подписи не изменились. Проверка считывает первый фрагмент двух известных фигур в предоставленном образце.

## **Сохранение форматирования текста**

Работайте с существующим фрагментом при добавлении поля, изменении его типа или удалении. Эти операции сохраняют форматирование фрагмента. Используйте [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#getPortionFormat--) , чтобы менять только необходимые свойства, как делают примеры для цвета или курсивa.

Избегайте перестройки всего текстового блока только для обновления одного поля: при этом могут быть потеряны исходные границы фрагментов и их индивидуальное форматирование. Также различайте явно установленное форматирование и наследуемое от абзаца, макета или темы. См. [Форматирование текста](/slides/ru/java/text-formatting/) для более широких возможностей форматирования.

## **Поля и заполнители заголовка/нижнего колонтитула**

Поле является частью текстового фрагмента. Заполнитель — это фигура с ролью в презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый блок не превращает эту фигуру в заполнитель.

Менеджеры заголовков/нижних колонтитулов управляют текстом заполняющих элементов и их видимостью на слайдах, макетах и мастерах, включая распространение на зависимые слайды. Поэтому поле номера в пользовательском текстовом блоке может быть полезным, даже если вы не используете заполнитель номера слайда. Напротив, изменение видимости заполнителя не удаляет поле из несвязанного текстового блока.

Предопределённые типы заголовков и нижних колонтитулов не создают соответствующие заполнители и не предоставляют их содержимое. В частности, обычный слайд PowerPoint не имеет заполнителя заголовка; заголовки относятся к заметкам и раздаточным материалам. Не предполагаете, что поле заголовка или нижнего колонтитула в произвольной фигуре автоматически получит текст, настроенный через менеджер заполнителей. Для такого процесса см. [Заголовки и нижние колонтитулы презентации](/slides/ru/java/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверьте как тип поля, так и получаемый текст после сохранения и повторного открытия. Сохранение идентификатора не доказывает, что приложение может вычислить или отобразить его значение.

| Формат | Поведение поля и ограничения |
|---|---|
| PPTX | Сохраняет внутренние идентификаторы полей вместе с их текстом. При проверках кругового прохода предопределённые типы и пользовательский идентификатор, использованный выше, сохранялись после сохранения и повторного открытия. Неизвестный пользовательский тип сохранил резервный текст; он не получил логики автоматических вычислений. Другое приложение может обрабатывать неподдерживаемые идентификаторы иначе. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. При проверках кругового прохода поля номера слайда и предопределённые поля даты/времени сохранялись после сохранения и повторного открытия. Пользовательское поле в обычном текстовом блоке слайда открылось с его идентификатором, но с текстом `*`; поле заголовка в том же контексте также выдало `*`. Не полагайтесь на сохранение видимого текста пользовательских полей или неподдерживаемых контекстов полей. |

Для переносимого фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте желаемое значение перед сохранением. Это сохраняет выбранный текст, но намеренно останавливает автоматические обновления. Также протестируйте целевое приложение, если его собственный пересчёт полей является частью вашего процесса.

## **Вопросы и ответы**

**Как определить, является ли отображаемый номер или дата полем?**

Проверьте [IPortion.getField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#getField--). Ненулевое значение указывает на поле; один лишь отображаемый текст не может сказать об этом.

**Удаляет ли удаление поля его текст или форматирование?**

Нет. [removeField](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#removeField--) преобразует существующий фрагмент в обычный текст. При необходимости конкретной фиксированной даты или резервного значения присвойте её явно после этого.

**Может ли внутренняя строка определить новый формат даты или формулу?**

Нет. Она идентифицирует тип поля. Неизвестный идентификатор не предоставляет средств вычисления или шаблона формата даты Java. Используйте поддерживаемый предопределённый тип или отформатируйте значение сами как обычный текст.

**Почему проверять презентацию повторно после её сохранения?**

Идентификаторы полей, вычисленный текст и форматирование — это отдельные аспекты, которые необходимо проверять. Преобразование формата может изменить видимый результат, даже если идентификатор поля всё ещё присутствует.