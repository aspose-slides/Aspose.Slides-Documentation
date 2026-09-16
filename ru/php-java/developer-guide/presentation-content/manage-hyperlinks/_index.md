---
title: Управление гиперссылками презентации в PHP
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/php-java/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- гиперссылка в тексте
- гиперссылка на слайде
- гиперссылка на форме
- гиперссылка на изображении
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Добавляйте, форматируйте, обновляйте и удаляйте гиперссылки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java, используя примеры на PHP."
---
## **Введение**

Гиперссылка соединяет содержимое презентации с веб‑сайтом или местом внутри самой презентации. В PowerPoint гиперссылки обычно используются для двух целей:

* Открыть веб‑сайт из текста, формы или медиарезки.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides for PHP via Java позволяет добавлять такие ссылки, управлять их внешним видом и звуком, обновлять свойства и удалять их. Приведённые ниже примеры показывают, как работать с гиперссылками для отдельных элементов и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового кадра. Предполагается, что PHP/Java Bridge и обёртка Aspose.Slides PHP инициализированы. Члены API без ссылки на страницу справки PHP ведут к базовому Java API.

{{% alert color="info" title="Note" %}}
Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/ru/editor).
{{% /alert %}} 

## **Добавить URL‑гиперссылки**

Вы можете присвоить URL‑адрес веб‑сайта тексту, форме или медиарезке. Элемент, которому назначена гиперссылка, определяет область клика: часть текста связывает выбранный текст, а форма или резка связывают объект слайда.

### **Добавить URL‑гиперссылки к тексту**

Чтобы связать текст с веб‑сайтом, передайте объект [Hyperlink](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/) в метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/sethyperlinkclick/) части текста, как показано ниже. Кликабельной становится только эта часть текста.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Добавить URL‑гиперссылки к формам и медиарешеткам**

Чтобы сделать форму или резку кликабельными, вызовите их метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/sethyperlinkclick/). Гиперссылка принадлежит самому объекту, а не части текста внутри него.

То же самое относится к картинкам, аудио‑ и видеорезкам: назначьте гиперссылку резке и, при необходимости, вызовите [setTooltip](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/settooltip/).

Следующий пример делает прямоугольник кликабельным:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Использовать гиперссылки для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к конкретному слайду. В следующем примере используется метод [setInternalHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) для связывания текста “Page 2” на первом слайде со вторым слайдом.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Форматировать гиперссылки**

### **Цвет**

Метод [setColorSource](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/setcolorsource/) класса [Hyperlink](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы задать собственный цвет текста, выберите [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkcolorsource/) и установите цвет заливки части. Эта возможность была введена в PowerPoint 2019; в более ранних версиях это настройка не применяется.

Следующий пример добавляет две текстовые гиперссылки на один слайд. Первая использует красный цвет заливки текста, а вторая сохраняет цвет гиперссылки по умолчанию.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Звук**

Гиперссылка может воспроизводить звук при активации или прекращать уже воспроизводимый звук. Используйте следующие методы для настройки этих поведений:

- [Hyperlink::setSound](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/setsound/) задаёт аудио, связанное с гиперссылкой.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/setstopsoundonclick/) определяет, будет ли активация гиперссылки останавливать предыдущий звук.

#### **Добавить звук к гиперссылке**

Следующий пример загружает `sampleaudio.wav` и связывает его с кнопкой на первом слайде. Нажатие кнопки воспроизводит звук и переходит к следующему слайду. Вторая форма на этом слайде останавливает предыдущий звук при щелчке, не выполняя перехода.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Извлечь звук из гиперссылки**

Следующий пример открывает созданную выше презентацию и читает аудио гиперссылки первой формы в память с помощью методов [getSound](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/getsound/) и [getBinaryData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Всплывающая подсказка и настройки взаимодействия**

После назначения гиперссылки тексту или форме вы можете вызвать следующие методы класса [Hyperlink](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/):

- [setTooltip](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/settooltip/) задаёт текст, который пользователь может увидеть в виде подсказки для ссылки.
- [setTargetFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/settargetframe/) указывает целевой кадр внутри родительского HTML‑фреймсета, если применимо.
- [setHistory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/sethistory/) контролирует, будет ли активация ссылки добавлять её назначение в список просмотренных гиперссылок.
- [setHighlightClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/sethighlightclick/) определяет, будет ли гиперссылка подсвечиваться при щелчке.

## **Удалить гиперссылки из презентаций**

Используйте метод [getAnyHyperlinks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) для получения контейнеров гиперссылок, включая ссылки в частях текста, перед их изменением. Следующий пример удаляет оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите только [removeHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) или [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); удаление действия щелчка не удаляет соответствующее действие «мышью над».

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Для безусловного удаления метод [removeAllHyperlinks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) удаляет оба типа активации в выбранном объёме одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. раздел [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Создать полный перечень гиперссылок**

Перед распространением презентации проведите инвентаризацию её интерактивных действий и веб‑ссылок. Метод [getAnyHyperlinks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) возвращает объекты [IHyperlinkContainer](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihyperlinkcontainer/), а не простой список URL‑строк. Осмотрите как [getHyperlinkClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) , так и [getHyperlinkMouseOver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) у каждого контейнера. Они независимы: один контейнер может предоставлять оба действия, поэтому полный отчёт требует до двух строк на контейнер.

Сканирование только гиперссылок уровня формы может пропустить ссылки, прикреплённые к частям текста. Запрашивайте нужный объём вместо этого и сохраняйте полученные контейнеры, чтобы позже можно было обновлять или удалять их действия.

### **Запрос областей Презентация, Слайд и Текстовый кадр**

Класс [HyperlinkQueries](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/) доступен через [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) и [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/gethyperlinkqueries/). Каждый объём поддерживает одинаковые запросы:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) возвращает контейнеры с действием щелчка.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) возвращает контейнеры с действием «мышью над».
- [getAnyHyperlinks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) возвращает контейнеры с любым из этих действий.

Следующий пример создаёт `hyperlink-audit-input.pptx` с внешней ссылкой‑клик, ссылкой‑мышью‑над файлом, внутренней навигацией по слайдам, ссылкой‑мышью‑над текстом и действием макроса. Он не выполняет ни одно из этих действий. Те же три запроса работают во всех объёмах; счётчики описывают контейнеры, а не общее количество действий. Объём текстового кадра исключает ссылки самой охватывающей формы.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Для этого примера запросы презентации и слайда каждый возвращают три контейнера‑клика, два контейнера‑мыши‑над и три контейнера с любым из действий. Запрос текстового кадра возвращает по одному контейнеру в каждой категории.

### **Классифицировать действия и назначения**

Используйте метод [Hyperlink::getActionType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/getactiontype/) для определения типа действия перед анализом его назначения. Значения [HyperlinkActionType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkactiontype/) охватывают не только веб‑навигацию:

| Значения | Значение для аудита |
| --- | --- |
| `Hyperlink` | Внешняя гиперссылка; проверьте URL и её схему. |
| `JumpSpecificSlide` | Внутренняя навигация к конкретному слайду. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Встроенная навигация показа, интерпретируется в контексте слайд‑шоу. |
| `JumpEndShow`, `StartCustomSlideShow` | Завершить текущий показ или запустить пользовательский показ. |
| `StartMacro` | Выполнить макрос. |
| `StartProgram` | Запустить программу. |
| `OpenFile`, `OpenPresentation` | Открыть файл или другую презентацию; рассматривать отдельно от веб‑URL. |
| `StartStopMedia` | Запустить или остановить воспроизведение медиа. |
| `NoAction`, `Unknown` | Нет навигационного действия или неопознанное действие, требующее проверки. |

Читать внешние назначения можно через [getExternalUrl](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/getexternalurl/), а конкретные внутренние назначения — через [getTargetSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/gettargetslide/). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия у контейнера. Сохраняйте значение, возвращаемое [getExternalUrlOriginal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--), если оно отличается от нормализованного URL, и включайте подсказку, возвращаемую [getTooltip](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlink/gettooltip/), когда она доступна.

### **Отчет, очистка и проверка гиперссылок**

Следующий PHP‑пример читает существующую презентацию (используйте файл, созданный выше), пишет `hyperlink-audit.json`, применяет политику, сохраняет `hyperlink-sanitized.pptx` и открывает его снова для повторной проверки обоих типов активации. Он собирает контейнеры перед их изменением и использует сравнение ссылок, чтобы избежать двойной обработки одного и того же контейнера. Запросы презентации охватывают обычные слайды; для полного инвентаря пакета он также явно запрашивает мастера, макеты, заметки и мастера заметок и раздаточных материалов, если они существуют.

Отчёт фиксирует индекс слайда (начиная с 1) и [getSlideId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getSlideId--) при наличии. [ISlideComponent::getSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidecomponent/#getSlide--) предоставляет владелец‑слайд для поддерживаемых контейнеров. У мастеров, макетов и заметок нет обычного индекса слайда и они идентифицируются по своей области. Контейнеры форм и контейнеры форматирования частей текста помечаются отдельно; другие типы контейнеров сохраняют своё имя типа во время выполнения. Каждый контейнер получает локальный идентификатор отчёта, чтобы его два действия можно было сопоставить. В отчёте типы действий сохраняются как целочисленные константы, определённые перечислением PHP.

Эта преднамеренно строгая политика приложения разрешает только абсолютные HTTPS‑URL и действительные внутренние цели слайдов. Она отклоняет макросы, программы, файловые действия, другие действия слайд‑шоу, неизвестные действия и другие схемы URL. Эти отклонения — решения политики, а не оценка безопасности Aspose.Slides. Один лишь HTTPS не гарантирует доверие: добавьте списки разрешённых хостов и другие проверки для вашего приложения. Проверяются как оригинальные, так и нормализованные внешние URL. Пример проводит аудит метаданных без переходов по ссылкам и без выполнения действий.

Для исправления [getHyperlinkManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) поддерживает методы [setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) и [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Здесь запрещённые внешние ссылки‑клики заменяются фиксированной HTTPS‑страницей‑приёмником; другие запрещённые клики и запрещённые действия «мышью‑над» удаляются независимо. Установите `$replaceExternalClicks` в `false`, чтобы удалить все нарушения политики. Выберите страницу‑заменитель, принадлежащую вашему приложению, перед развёртыванием.

Флаг экспорта отчёта использует консервативную политику проверки PDF: помечает действия «мышью‑над» и всё, что не является внешней ссылкой или переходом к конкретному слайду, как потенциально неподдерживаемое. Это подсказка для проверки, а не тест возможностей или гарантия того, что непомеченные ссылки сохранятся при экспорте. Поддерживаемые экспорты в [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/php-java/convert-powerpoint-to-html/) могут сохранять гиперссылки в зависимости от действия, параметров экспорта и просмотрщика. Растровые [images](/slides/ru/php-java/convert-powerpoint-to-png/) и [video](/slides/ru/php-java/convert-powerpoint-to-video/) ссылки сохранять не могут; при аудите для этих форматов помечайте каждое действие.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

С входными данными, созданными выше, отчёт содержит пять строк действий. Ссылка‑мышью‑над файлом и клик‑макрос удаляются, а HTTPS‑ссылки и внутренняя навигация остаются. Проверка выводит ноль запрещённых действий. Ввод, содержащий запрещённый внешний URL‑клик, также демонстрирует ветку замены. Контейнер с разрешённым кликом и запрещённым «мышью‑над» сохраняет действие клика.

Эта выборочная очистка отличается от [removeAllHyperlinks](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), который удаляет оба типа активации во всём выбранном объёме независимо от политики. Проверка здесь проверяет только действия гиперссылок; она не удаляет встроенные VBA‑проекты, OLE‑объекты или другой активный контент и не проверяет экспортированный PDF или HTML файл.

## **Часто задаваемые вопросы**

**Как связать раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка адресует отдельный слайд. Чтобы создать навигацию к разделу, свяжите её с первым слайдом этого раздела.

**Можно ли привязать гиперссылку к элементам шаблона слайда, чтобы она работала на всех слайдах?**

Да. Элементы шаблона слайда и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа слайдов, использующих соответствующий шаблон или макет.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемый экспорт в PDF и HTML может сохранять гиперссылки; растровые изображения и видео — нет. См. рекомендации по экспорту в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).