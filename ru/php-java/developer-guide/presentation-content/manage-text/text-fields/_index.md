---
title: Управление текстовыми полями в презентациях PowerPoint на PHP
linktitle: Текстовые поля
type: docs
weight: 52
url: /ru/php-java/text-fields/
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
- PHP
- Aspose.Slides
description: "Создавайте, просматривайте, изменяйте и удаляйте текстовые поля в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java. Сохраняйте форматирование и проверяйте сохранённые файлы PPTX и PPT."
---
## **Обзор**

Текстовый абзац состоит из частей. Обычная [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) содержит буквальный текст; часть‑поле также имеет [Field](https://reference.aspose.com/slides/ru/php-java/aspose.slides/field/), тип которой определяет автоматически обновляемое значение, например номер слайда или дату. Две части могут отображать одинаковые символы, но только одна из них содержит поле.

Используйте [Portion::getField](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getField), чтобы различать их: для обычного текста он возвращает `null`. [Portion::addField](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#addField) преобразует существующую часть в поле. Держите метку и её динамическое значение в отдельных частях, чтобы преобразование значения не заменило метку.

Это руководство охватывает поля внутри текста, их форматирование и сохранение в PPTX и PPT. Для текстовых фреймов и абзацев см. [Manage Text](/slides/ru/php-java/manage-text/).

## **Создать поле номера слайда**

Следующий полностью заполненный пример создаёт текстовое поле, содержащее буквальную метку `Slide ` и автоматически обновляемый номер. Перед добавлением поля задаются размер, толщина и цвет номера, затем сохраняется презентация, открывается вновь и проверяются тип поля, текст и форматирование. Входной файл не требуется.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Новая презентация начинается с номера слайда 1, поэтому текст выглядит как `Slide 1`, и обе проверки выводят `true`. Номер остаётся полем после повторного открытия; это не буквальная `1`. Индексы в проверке относятся к фигуре и частям, созданным в этом примере.

## **Выбрать тип поля**

[FieldType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/) предоставляет следующие методы для получения предопределённых значений. Передайте соответствующее значение в [addField](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#addField).

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getSlideNumber) | Текущий номер слайда. |
| [getDateTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getDateTime) | Дата/время в формате по умолчанию приложения, выполняющего рендеринг. |
| [getDateTime1](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getDateTime9) | Предопределённые форматы даты или комбинированные форматы даты/времени. |
| [getDateTime10](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getDateTime13) | Предопределённые форматы времени, с вариантами секунд и 12‑часового формата. |
| [getHeader](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getHeader) | Поле заголовка; см. ограничения плейсхолдера и формата ниже. |
| [getFooter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getFooter) | Поле нижнего колонтитула. |

Например, [getDateTime3](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getDateTime3) представляет день, полное название месяца и год на английском. Это предопределённые форматы полей, а не произвольные строки формата PHP‑даты. Язык, установленный с помощью [setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId), и приложение, обрабатывающее презентацию, могут влиять на отображаемый результат.

## **Создать поле из внутренней строки**

Перегруженный строковый вариант [addField](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#addField) принимает внутренний идентификатор поля. Используйте его, когда нужно сохранить идентификатор, поставленный другим приложением и не имеющий предопределённого значения. Также можно построить [FieldType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#FieldType) из идентификатора. [FieldType::getInternalString](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fieldtype/#getInternalString) раскрывает этот идентификатор для проверки.

В этом примере сохраняется поле `custom-report-id`, специфичное для приложения, с запасным текстом `Report-042`. Идентификатор не регистрирует расчёт: Aspose.Slides не генерирует идентификаторы отчётов для неизвестного типа. Приложение, которое понимает этот идентификатор, должно предоставить его значение и обновлять его.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

После прохода PPTX тип остаётся `custom-report-id`, а текст — `Report-042`. Передача строки вида `Y-m-d` назовет тип поля; она не задаст пользовательский формат даты. Для фиксированной даты в произвольном формате используйте обычный текст.

## **Просмотр, изменение и удаление полей даты/времени**

Измените существующее поле через [Field::setType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/field/#setType). Убедитесь, что поле существует, прежде чем обращаться к его типу. Чтобы остановить автоматические обновления, вызовите [Portion::removeField](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#removeField). Это оставит часть и её текущий текст, удалив связь с полем. Если нужен конкретный фиксированный параметр, задайте нужный текст после удаления поля.

Для настройки, связанной с обработкой полей даты/времени, см. [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#setCurrentDateTime). В примере ниже используется явная дата утверждения при преобразовании поля в обычный текст.

Скачайте [sample.pptx](sample.pptx) и поместите его в рабочий каталог JavaBridge, либо передайте абсолютный путь в конструктор презентации. Файл содержит два именованных текстовых объекта — `UpdatedAt` и `ApprovedDate`, каждый с полем даты/времени, а также обычные текстовые метки. Далее пример перебирает текстовые объекты верхнего уровня на обычных слайдах. Он меняет поля даты/времени на формат «длинная дата» и делает их курсивом, сохраняя остальное форматирование. Только поля в `ApprovedDate` становятся фиксированным текстом.

Образец распознаёт встроенные внутренние идентификаторы `datetime` и `datetime1`‑`datetime13`. Группы, таблицы, заметки, макеты и шаблоны требуют обхода собственных контейнеров текста и находятся за пределами данного примера.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

После повторного открытия `UpdatedAt` имеет тип `datetime3` и остаётся динамическим. В `ApprovedDate` поля нет, текст — `05 April 2030`. Оба фрагмента даты курсивом, а их исходный размер шрифта, полужирное начертание и цвет остались без изменений. Обычные метки текста не изменились. Проверка считывает первую часть двух известных фигур в предоставленном образце.

## **Сохранить форматирование текста**

Работайте с существующей частью при добавлении поля, изменении его типа или удалении. Эти операции сохраняют форматирование части. Используйте [Portion::getPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getPortionFormat), чтобы менять только необходимые свойства, как показано в примерах для цвета или курсивного начертания.

Старайтесь не перестраивать весь текстовый фрейм только для обновления одного поля: такой подход может удалить исходные границы частей и их индивидуальное форматирование. Также различайте явно заданное форматирование и унаследованное от абзаца, макета или темы. См. [Text Formatting](/slides/ru/php-java/text-formatting/) для более широких возможностей форматирования.

## **Поля и плейсхолдеры заголовка/нижнего колонтитула**

Поле является частью текстовой части. Плейсхолдер — это объект с ролью в презентации, например нижний колонтитул или номер слайда. Добавление поля в обычный текстовый блок не превращает объект в плей‑холдер.

Менеджеры заголовков/нижних колонтитулов управляют текстом плейсхолдера и его видимостью на слайдах, макетах и шаблонах, включая распространение на зависимые слайды. Поэтому поле‑номер в пользовательском текстовом блоке может быть полезным даже без использования плейсхолдера номера слайда. И наоборот, изменение видимости плейсхолдера не удаляет поле из несвязанного текстового блока.

Предопределённые типы заголовка и нижнего колонтитула не создают соответствующие плейсхолдеры и не заполняют их содержимым. В частности, обычный слайд PowerPoint не имеет плейсхолдера заголовка; заголовки относятся к страницам заметок и раздаточным материалам. Не следует предполагать, что поле заголовка или нижнего колонтитула в произвольном объекте автоматически получит текст, настроенный через менеджер плейсхолдеров. Для такого сценария см. [Presentation Headers and Footers](/slides/ru/php-java/presentation-header-and-footer/).

## **Ограничения PPTX и PPT**

Проверьте как тип поля, так и полученный текст после сохранения и повторного открытия. Сохранение идентификатора не гарантирует, что приложение сможет вычислить или отобразить его значение.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Хранит внутренние идентификаторы полей вместе с их текстом. При проверках «кругового» прохода предопределённые типы и пользовательский идентификатор, использованный выше, выжили после сохранения и повторного открытия. Неизвестный пользовательский тип сохранил запасной текст и не получил логики автоматического расчёта. Другое приложение может обращаться с неподдерживаемыми идентификаторами иначе. |
| PPT | Использует устаревшие представления полей и имеет более ограниченную совместимость. При проверках «кругового» прохода поля номера слайда и предопределённые даты/времена выжили после сохранения и повторного открытия. Пользовательское поле в обычном текстовом блоке открылось с его идентификатором, но текстом `*`; то же произошло с полем заголовка в том же контексте. Не рассчитывайте на то, что пользовательские поля или неподдерживаемые контексты полей сохранят свой видимый текст. |

Для переносимого фиксированного вывода преобразуйте неподдерживаемые поля в обычный текст и явно задайте желаемое значение перед сохранением. Это сохраняет выбранный текст, но намеренно останавливает автоматические обновления. Также протестируйте целевое приложение, если его собственный пересчёт полей входит в ваш рабочий процесс.

## **Вопросы и ответы**

**Как определить, является ли отображаемый номер или дата полем?**

Проверьте [Portion::getField](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getField). Ненулевое значение указывает на поле; по только лишь отображаемому тексту это определить нельзя.

**Удаляет ли удаление поля его текст или форматирование?**

Нет. [removeField](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#removeField) преобразует существующую часть в обычный текст. При необходимости задайте конкретное значение позже, если нужен фиксированный день или запасной текст.

**Может ли внутренняя строка определить новый формат даты или формулу?**

Нет. Она лишь идентифицирует тип поля. Неизвестный идентификатор не предоставляет вычислитель или шаблон формата PHP‑даты. Используйте поддерживаемый предопределённый тип или отформатируйте значение самостоятельно как обычный текст.

**Почему проверять презентацию снова после её сохранения?**

Идентификаторы полей, вычисленный текст и форматирование — это отдельные аспекты, которые нужно проверять. При конвертации формата видимый результат может измениться, даже если идентификатор поля остаётся.