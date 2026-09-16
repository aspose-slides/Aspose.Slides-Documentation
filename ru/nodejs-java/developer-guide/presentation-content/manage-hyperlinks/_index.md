---
title: Управление гиперссылками презентации в JavaScript
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/nodejs-java/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- текстовая гиперссылка
- гиперссылка слайда
- гиперссылка фигуры
- гиперссылка изображения
- гиперссылка видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Добавляйте, форматируйте, обновляйте и удаляйте гиперссылки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java, используя примеры на JavaScript."
---
## **Введение**

Гиперссылка соединяет содержимое презентации с веб‑сайтом или расположением внутри презентации. В PowerPoint гиперссылки обычно служат двум целям:

* Открыть веб‑сайт из текста, фигуры или медиа‑кадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides for Node.js via Java позволяет добавлять такие ссылки, управлять их внешним видом и звуком, обновлять их свойства и удалять их. Приведённые ниже примеры показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового кадра.

{{% alert color="info" title="Примечание" %}}
Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/ru/editor).
{{% /alert %}} 

## **Добавление URL‑гиперссылок**

Вы можете назначить URL веб‑сайта тексту, фигуре или медиа‑кадру. Элемент, к которому вы привязываете гиперссылку, определяет область клика: часть текста связывает выбранный текст, а фигура или кадр — объект слайда.

### **Добавление URL‑гиперссылок к тексту**

Чтобы связать текст с веб‑сайтом, передайте [Hyperlink](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink) в метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) части текста, как показано ниже. Только эта часть текста становится кликабельной.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Добавление URL‑гиперссылок к фигурам и медиа‑кадрам**

Чтобы сделать фигуру или кадр кликабельным, вызовите её метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape#setHyperlinkClick). Гиперссылка принадлежит самому объекту, а не части текста внутри него.

То же самое применяется к кадрам изображений, аудио и видео: назначьте гиперссылку кадру и при необходимости вызовите [setTooltip](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setTooltip).

Следующий пример делает прямоугольник кликабельным:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Использование гиперссылок для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к конкретному слайду. В следующем примере используется [setInternalHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick), чтобы связать текст “Page 2” на первом слайде со вторым слайдом.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Форматирование гиперссылок**

### **Цвет**

Метод [setColorSource](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setColorSource) класса [Hyperlink](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы задать собственный цвет текста, выберите [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkColorSource) и задайте цвет заливки части. Эта возможность была добавлена в PowerPoint 2019; более старые версии эту настройку не применяют.

Следующий пример добавляет две текстовые гиперссылки на один слайд. Первая использует красный цвет текста, вторая сохраняет стандартный цвет гиперссылки.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Звук**

Гиперссылка может воспроизводить звук при активации или останавливать уже воспроизводящийся звук. Для настройки этих поведений используйте следующие методы:

- [Hyperlink.setSound](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setSound) — указывает аудио, связанное с гиперссылкой.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) — управляет тем, будет ли при активации гиперссылки остановлен предыдущий звук.

#### **Добавление звука к гиперссылке**

Следующий пример загружает `sampleaudio.wav` и связывает его с кнопкой на первом слайде. При нажатии кнопка воспроизводит звук и переходит к следующему слайду. Вторая фигура на том же слайде останавливает предыдущий звук при клике, не выполняя перехода.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Извлечение звука из гиперссылки**

Следующий пример открывает ранее созданную презентацию и считывает аудио гиперссылки первой фигуры в память с помощью [getSound](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#getSound) и [getBinaryData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Подсказка и параметры взаимодействия**

После назначения гиперссылки тексту или фигуре вы можете вызвать следующие методы класса [Hyperlink](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink):

- [setTooltip](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setTooltip) — задаёт текст, который пользователь видит как подсказку к ссылке.
- [setTargetFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) — указывает целевой фрейм внутри родительского HTML‑фреймсета, если применимо.
- [setHistory](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setHistory) — контролирует, будет ли активация ссылки добавлять её назначение в список просмотренных гиперссылок.
- [setHighlightClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) — управляет тем, будет ли гиперссылка подсвечиваться при клике.

## **Удаление гиперссылок из презентаций**

Для сбора контейнеров гиперссылок, включая ссылки в частях текста, перед их изменением используйте [getAnyHyperlinks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks). Следующий пример удаляет оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите только [removeHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) или [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); удаление действия клика не удаляет связанное действие при наведении.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Для безусловного удаления [removeAllHyperlinks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) удаляет оба типа активации в выбранной области одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. раздел [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Создание полного списка гиперссылок**

Перед распространением презентации составьте инвентарь её интерактивных действий и веб‑ссылок. [getAnyHyperlinks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) возвращает контейнеры гиперссылок, а не простой список URL‑строк. Проверьте как [getHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape#getHyperlinkClick), так и [getHyperlinkMouseOver](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) у каждого контейнера. Они независимы: один и тот же контейнер может содержать оба действия, поэтому полноценный отчёт может требовать до двух строк на контейнер.

Проверка только гиперссылок уровня фигур может пропустить ссылки, привязанные к частям текста. Запрашивайте соответствующую область вместо этого и сохраняйте возвращённые контейнеры, чтобы позже обновить или удалить их действия.

### **Запрос областей презентации, слайда и текстового кадра**

Класс [HyperlinkQueries](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries) доступен через [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) и [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Каждая область поддерживает те же запросы:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) — возвращает контейнеры с действием клика.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) — возвращает контейнеры с действием при наведении.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) — возвращает контейнеры с любым из действий или с обоими.

Следующий пример создаёт `hyperlink-audit-input.pptx` с внешней ссылкой‑кликом, ссылкой‑наведение на файл, внутренней навигацией по слайдам, ссылкой‑наведение на текст и действием макроса. Ни одно из этих действий не выполняется. Одни и те же три запроса работают во всех областях; подсчёты описывают количество контейнеров, а не количество действий. Область текстового кадра исключает ссылки самой охватывающей фигуры.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для этого примера запросы презентации и слайда возвращают по три контейнера клика, два контейнера наведения и три контейнера с любым из действий. Запрос текстового кадра возвращает по одному контейнеру в каждой категории.

### **Классификация действий и назначений**

Для определения действия перед определением назначения используйте [Hyperlink.getActionType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#getActionType). Значения перечисления [HyperlinkActionType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkActionType) охватывают больше, чем навигацию по вебу:

| Значения | Смысл для аудита |
| --- | --- |
| `Hyperlink` | Внешняя гиперссылка; проверьте URL и его схему. |
| `JumpSpecificSlide` | Внутренняя навигация к конкретному слайду. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Встроенная навигация презентации, определяется в контексте показа слайдов. |
| `JumpEndShow`, `StartCustomSlideShow` | Завершить текущий показ или запустить пользовательский показ. |
| `StartMacro` | Выполнить макрос. |
| `StartProgram` | Запустить программу. |
| `OpenFile`, `OpenPresentation` | Открыть файл или другую презентацию; рассматривать отдельно от веб‑URL. |
| `StartStopMedia` | Запустить или остановить воспроизведение медиа. |
| `NoAction`, `Unknown` | Нет действия навигации, либо нераспознанное действие, требующее проверки. |

Чтение внешних назначений производится через [getExternalUrl](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#getExternalUrl), а конкретных внутренних — через [getTargetSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL — это не значит, что у контейнера нет действия. Сохраняйте значение, возвращаемое [getExternalUrlOriginal](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal), если оно отличается от нормализованного URL, и включайте подсказку, возвращаемую [getTooltip](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Hyperlink#getTooltip), когда она доступна.

### **Отчёт, очистка и проверка гиперссылок**

Следующий пример JavaScript читает существующую презентацию (используйте файл, созданный выше), записывает `hyperlink-audit.json`, применяет политику, сохраняет `hyperlink-sanitized.pptx` и повторно открывает её, чтобы снова проверить оба типа активации. Он собирает контейнеры прежде, чем изменять их, и использует сравнение по ссылке, чтобы не обрабатывать один и тот же контейнер дважды. Запросы презентации охватывают обычные слайды; для инвентаризации всего пакета он также явно запрашивает мастера, макеты, заметки и мастера заметок/раздаточных листов, если они присутствуют.

Отчёт фиксирует индекс слайда, начиная с 1, и [getSlideId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/BaseSlide#getSlideId), если он доступен. [getSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape#getSlide) предоставляет родительский слайд для поддерживаемых контейнеров. У мастеров, макетов и заметок нет обычного индекса слайда и они идентифицируются по своей области. Контейнеры фигур и контейнеры форматирования частей текста помечаются отдельно; другие типы сохраняют своё имя типа во время выполнения. Каждому контейнеру присваивается локальный идентификатор отчёта, чтобы его два действия можно было сопоставить. В отчёте типы действий сохраняются как целочисленные константы, определённые перечислением HyperlinkActionType.

Эта преднамеренно строгая политика приложения допускает только абсолютные HTTPS‑URL и корректные внутренние цели слайдов. Она отклоняет макросы, программы, действия с файлами, другие действия слайд‑шоу, неизвестные действия и прочие схемы URL. Такие отклонения — решения политики, а не оценка безопасности Aspose.Slides. Один лишь HTTPS не гарантирует доверие: добавьте списки разрешённых хостов и другие проверки в своё приложение. Проверяются как оригинальные, так и нормализованные внешние URL. Пример проверяет только метаданные без переходов по ссылкам и без выполнения действий.

Для исправления контейнер поддерживает [getHyperlinkManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Shape#getHyperlinkManager), который позволяет использовать [setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) и [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Здесь запрещённые внешние ссылки‑клики заменяются фиксированной HTTPS‑страницей‑заглушкой; остальные запрещённые клики и действия при наведении удаляются независимо. Установите `replaceExternalClicks` в `false`, чтобы удалить все нарушения политики. Выберите страницу‑заменитель, принадлежащую вашему приложению, перед развёртыванием.

Флаг экспорта в отчёте использует консервативную политику проверки PDF: помечать действия при наведении и всё, что не является внешней ссылкой или переходом к конкретному слайду, как потенциально неподдерживаемое. Это лишь рекомендация для проверки, а не тест возможностей или гарантия, что не помеченные ссылки сохранятся при экспорте. Поддерживаемый экспорт в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/) может сохранять гиперссылки в зависимости от действия, параметров экспорта и средства просмотра. Растровые [изображения](/slides/ru/nodejs-java/convert-powerpoint-to-png/) и [видео](/slides/ru/nodejs-java/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; при аудите для этих форматов помечайте каждое действие.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

С входными данными, созданными выше, отчёт содержит пять строк действий. Ссылка‑наведение на файл и макрос‑клик удалены, тогда как HTTPS‑ссылки и внутренняя навигация по слайдам остаются. Проверка выводит ноль запрещённых действий. Ввод, содержащий запрещённый внешний URL‑клик, также демонстрирует ветку замены. Контейнер с разрешённым кликом и запрещённым наведением сохраняет своё действие‑клик.

Эта выборочная очистка отличается от [removeAllHyperlinks](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), который удаляет оба типа активации во всей выбранной области независимо от политики. Проверка здесь проверяет только действия гиперссылок; она не удаляет встроенные проекты VBA, OLE‑объекты или другое активное содержимое и не проверяет экспортированный PDF или HTML файл.

## **Вопросы и ответы**

**Как я могу создать ссылку на раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка указывает отдельный слайд. Чтобы создать навигацию к разделу, привяжите ссылку к первому слайду этого раздела.

**Могу ли я привязать гиперссылку к элементам макета слайда, чтобы она работала на всех слайдах?**

Да. Элементы мастера слайда и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа на слайдах, использующих соответствующий мастер или макет.

**Будут ли гиперссылки сохраняться при экспорте в PDF, HTML, изображения или видео?**

Экспорт в поддерживаемый PDF и HTML может сохранять гиперссылки; растровые изображения и видео — нет. См. замечания по экспорту в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).