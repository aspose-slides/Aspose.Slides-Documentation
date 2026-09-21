---
title: Управление текстовыми полями в презентациях PowerPoint на Android
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/androidjava/text-fields/
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
- Android
- Java
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для Android на Java. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из частей (portions). Обычный [IPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/) содержит буквальный текст; часть‑поле также имеет [IField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifield/), тип которого определяет автоматически обновляемое значение, например номер слайда или дату. Две части могут отображать одинаковые символы, при этом только одна содержит поле.

Используйте [IPortion.getField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getField--) чтобы различать их: для обычного текста он возвращает `null`. [IPortion.addField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) преобразует существующую часть в поле. Держите подпись и её динамическое значение в отдельных частях, чтобы преобразование значения не заменило подпись.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых фреймов и абзацев см. [Manage Text](/slides/ru/androidjava/manage-text/).

## **Создание поля номера слайда**

Следующий полностью рабочий пример создаёт текстовый блок, содержащий буквальную подпись `Slide ` и автоматически обновляемый номер. Перед добавлением поля задаются размер, жирность и цвет номера, затем открывается сохранённая презентация и проверяется тип поля, текст и форматирование. Входной файл не требуется.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

Новая презентация начинается с номера слайда 1, поэтому текст выглядит как `Slide 1`, и обе проверки выводят `true`. Номер остаётся полем после повторного открытия; это не буквальный `1`. Приведения типов и индексы в проверке относятся к фигурам и частям, созданным в этом примере.

## **Выбор типа поля**

[FieldType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/) реализует [IFieldType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifieldtype/) и предоставляет следующие методы для получения предопределённых значений. Передайте соответствующее значение в [addField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Метод | Назначение |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Текущий номер слайда. |
| [getDateTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Дата/время в формате по умолчанию приложения‑рендерера. |
| [getDateTime1](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Предопределённые форматы даты или комбинированные форматы дата/время. |
| [getDateTime10](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Предопределённые форматы времени с возможностью отображения секунд и 12‑часового формата. |
| [getHeader](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Поле заголовка; см. ограничения заполнителей и форматов ниже. |
| [getFooter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Поле нижнего колонтитула. |

Например, [getDateTime3](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) представляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата Java‑даты. Язык, установленный с помощью [setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создание поля из внутренней строки**

Перегрузка метода [addField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) принимает внутренний идентификатор поля. Используйте её, когда необходимо сохранить идентификатор, предоставленный другим приложением, у которого нет предопределённого значения. Также можно создать [FieldType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) из этого идентификатора. [IFieldType.getInternalString](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) раскрывает идентификатор для проверки.

В этом примере сохраняется поле `custom-report-id`, специфичное для приложения, с резервным текстом `Report-042`. Идентификатор не регистрирует вычисление: Aspose.Slides не генерирует идентификаторы отчётов для неизвестных типов. Приложение, которое понимает этот идентификатор, должно обеспечить его смысл и обновлять значение.

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

После прохода PPTX тип остаётся `custom-report-id`, а текст — `Report-042`. Передача строки вроде `yyyy-MM-dd` назовёт тип поля; она не задаст пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Измените существующее поле через [IField.setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Убедитесь, что поле существует, прежде чем обращаться к его типу. Чтобы остановить автоматические обновления, вызовите [IPortion.removeField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#removeField--). Это сохраняет часть и её текущий текст, удаляя ассоциацию с полем. Если нужен конкретный фиксированный результат, задайте нужный текст после удаления поля.

Для настройки API, связанной с обработкой полей даты/времени, см. [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Пример ниже использует явную дату утверждения при преобразовании поля в обычный текст.

Скачайте [sample.pptx](sample.pptx) и поместите его в рабочий каталог. В файле находятся две именованные текстовые фигуры — `UpdatedAt` и `ApprovedDate`, каждая с полем даты/времени, а также обычные текстовые подписи. Приведённый пример проходит по верх‑уровневым текстовым фигурам обычных слайдов. Он изменяет поля даты/времени на длинный формат даты и делает их курсивом, сохраняя остальные параметры форматирования. Только поля в `ApprovedDate` становятся фиксированным текстом.

Образец распознаёт встроенные внутренние идентификаторы `datetime` и `datetime1`‑`datetime13`. Группы, таблицы, примечания, шаблоны и мастеры требуют обхода их собственных текстовых контейнеров и находятся за пределами данного примера.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

После повторного открытия `UpdatedAt` имеет тип `datetime3` и остаётся динамичным. У `ApprovedDate` нет поля, текст — `05 April 2030`. Оба фрагмента даты курсивом, их исходный размер шрифта, жирность и цвет сохранены. Обычные подписи остаются без изменений. Проверка считывает первую часть двух известных фигур в предоставленном образце.

## **Сохранение форматирования текста**

Работайте с существующей частью при добавлении поля, изменении его типа или удалении. Эти операции сохраняют форматирование части. Используйте [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getPortionFormat--) чтобы менять только необходимые свойства, как в примерах для цвета или курсивного начертания.

Избегайте полной перестройки текстового фрейма только для обновления одного поля: такой подход может потерять границы частей и их индивидуальное форматирование. Также различайте явно установленное форматирование и наследуемое от абзаца, шаблона или темы. Смотрите раздел [Text Formatting](/slides/ru/androidjava/text-formatting/) для более широких возможностей форматирования.

## **Поля и заполнители заголовков/нижних колонтитулов**

Поле является частью текстовой части. Заполнитель — это фигура с ролью в презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый блок не превращает эту фигуру в заполнитель.

Менеджеры заголовков/нижних колонтитулов управляют текстом заполнителей и их видимостью на слайдах, шаблонах и мастерах, включая распространение на зависимые слайды. Поле‑номер в пользовательском текстовом блоке может быть полезным, даже если вы не используете заполнитель номера слайда. С другой стороны, изменение видимости заполнителя не удаляет поле из несвязанного текстового блока.

Предопределённые типы заголовков и нижних колонтитулов не создают соответствующих заполнителей и не предоставляют их содержимое. В частности, обычный слайд PowerPoint не имеет заполнитель‑заголовка; заголовки относятся к страницам примечаний и раздаточным материалам. Не полагайтесь на то, что поле заголовка или нижнего колонтитула в произвольной фигуре автоматически получит текст, настроенный через менеджер заполнителей. Для такого сценария см. [Presentation Headers and Footers](/slides/ru/androidjava/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверяйте как тип поля, так и получившийся текст после сохранения и повторного открытия. Сохранение идентификатора не гарантирует, что приложение сможет вычислить или отобразить его значение.

| Формат | Поведение поля и ограничения |
|---|---|
| PPTX | Хранит внутренние идентификаторы полей вместе с их текстом. При проверках «кругового» прохода предопределённые типы и пользовательский идентификатор из примера сохраняются. Неизвестный пользовательский тип сохраняет резервный текст; автоматической логики вычисления он не получает. Другие приложения могут обрабатывать неподдерживаемые идентификаторы по‑разному. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. При проверках «кругового» прохода поля номера слайда и предопределённые даты/время сохраняются. Пользовательское поле в обычном текстовом блоке открывается с его идентификатором, но текстом `*`; аналогично и поле заголовка в том же контексте выдаёт `*`. Не рассчитывайте на сохранение видимого текста для пользовательских полей или неподдерживаемых контекстов. |

Для портативного фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте желаемое значение перед сохранением. Это сохраняет выбранный текст, но сознательно останавливает автоматические обновления. Также протестируйте целевое приложение, если его собственный пересчёт полей входит в ваш рабочий процесс.

## **FAQ**

**Как определить, является ли отображаемый номер или дата полем?**

Проверьте [IPortion.getField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getField--). Ненулевое значение указывает на поле; по самому отображаемому тексту определить это нельзя.

**Удаляет ли удаление поля его текст или форматирование?**

Нет. [removeField](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#removeField--) преобразует существующую часть в обычный текст. При необходимости задайте конкретное значение после удаления.

**Может ли внутренняя строка задать новый формат даты или формулу?**

Нет. Она лишь идентифицирует тип поля. Неизвестный идентификатор не предоставляет вычислитель или шаблон формата Java‑даты. Используйте поддерживаемый предопределённый тип или форматируйте значение самостоятельно как обычный текст.

**Зачем проверять презентацию снова после её сохранения?**

Идентификаторы полей, вычисленный текст и форматирование — это отдельные аспекты, требующие проверки. Конверсия формата может изменить видимый результат, даже если идентификатор поля остаётся.