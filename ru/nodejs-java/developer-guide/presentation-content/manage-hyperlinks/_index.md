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
- гиперссылка текста
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

Гиперссылка соединяет содержание презентации с веб‑сайтом или местом внутри презентации. В PowerPoint гиперссылки обычно выполняют две функции:

* Открыть веб‑сайт из текста, фигуры или медиа‑кадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides for Node.js via Java позволяет добавлять эти ссылки, управлять их внешним видом и звуком, обновлять их свойства и удалять их. Приведённые ниже примеры показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового фрейма.

{{% alert color="info" title="Note" %}}
Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Добавить URL‑гиперссылки**

Вы можете назначить URL веб‑сайта тексту, фигуре или медиа‑кадру. Элемент, к которому вы присваиваете гиперссылку, определяет область клика: часть текста делает кликабельным выбранный текст, тогда как фигура или кадр делает кликабельным объект слайда.

Для презентаций, содержащих относительные гиперссылки, см. [Управление базой гиперссылок](/slides/ru/nodejs-java/presentation-properties/#manage-the-hyperlink-base), чтобы прочитать, изменить или очистить базу уровня документа.

### **Добавить URL‑гиперссылки к тексту**

Чтобы привязать текст к веб‑сайту, передайте [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) методу [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) части текста, как показано ниже. Только эта часть текста становится кликабельной.

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

### **Добавить URL‑гиперссылки к фигурам и медиа‑кадрам**

Вызовите [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) для прямоугольника, чтобы сделать всю его площадь кликабельной. Используйте [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip), чтобы показать читателям подсказку о назначении при наведении курсора на прямоугольник. Оба метода также применимы к кадрам изображений, аудио и видео.

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

## **Использовать гиперссылки для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к определённому слайду. В следующем примере используется [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) для привязки текста «Page 2» на первом слайде ко второму слайду.

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

## **Форматировать гиперссылки**

Вы можете изменить цвет связанного текста, воспроизводить или останавливать звук при активации ссылки читателем и задать всплывающую подсказку, отображаемую при наведении.

### **Цвет**

Метод [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) класса [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы задать собственный цвет текста, выберите [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) и установите цвет заливки части. Эта функция была введена в PowerPoint 2019; в более ранних версиях это параметр не применяется.

В этом примере [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) заставляет первую ссылку использовать красный заливку части текста. Вторая ссылка сохраняет цвет гиперссылки презентации.

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

Гиперссылка может воспроизводить звук при активации или останавливать уже проигрывающий звук. Используйте следующие методы для настройки этих поведений:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) задаёт аудио, связанное с гиперссылкой.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) контролирует, останавливается ли предыдущий звук при активации гиперссылки.

#### **Добавить звук к гиперссылке**

Кнопка на первом слайде использует [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) для воспроизведения аудио из `sampleaudio.wav`, когда читатель нажимает для перехода вперёд. На втором слайде отдельная кнопка использует [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) для остановки воспроизведения и удержания читателя на этом слайде.

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

#### **Извлечь звук из гиперссылки**

В следующем примере открывается презентация, созданная выше, и аудио гиперссылки первой фигуры считывается в память с помощью [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) и [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData).

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

### **Настройки подсказки и взаимодействия**

Вы можете вызвать следующие методы [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) после назначения гиперссылки тексту или фигуре:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) задаёт текст, который просмотрщик может отображать как подсказку для ссылки.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) указывает целевой кадр внутри родительского HTML‑фреймсета, если применимо.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) контролирует, будет ли активация ссылки добавлять её назначение в список просмотренных гиперссылок.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) контролирует, будет ли гиперссылка подсвечиваться при клике.

## **Удалить гиперссылки из презентаций**

Используйте [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) для сбора контейнеров гиперссылок, включая ссылки частей текста, перед их изменением. В следующем примере удаляются оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите только [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) или [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); удаление действия клика не удаляет соответствующее действие наведения.

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

Для безусловного удаления [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) удаляет оба типа активаций в выбранном диапазоне одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. [Отчёт, очистка и проверка гиперссылок](#report-sanitize-and-verify-hyperlinks).

### **Очистить гиперссылки перед заменой текста SmartArt**

При замене абзаца в существующем узле SmartArt очистка его текстовых частей может оставить активной старую гиперссылку. Получите абзац через [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getTextFrame). Прежде чем очищать его части, вызовите [getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) у текстового кадра формы узла, отображающей абзац, затем вызовите [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) у полученного объекта. Это удалит каждую гиперссылку в этом кадре, включая ссылки в остальных абзацах.

В примере предполагается, что третья фигура на первом слайде файла `SmartArtHyperlink.pptx` является графикой SmartArt. Он заменяет первый абзац четвёртого узла. В этой презентации первая фигура узла отображает этот абзац.

После добавления обеих частей пример считывает их эффективное форматирование с помощью [getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#getEffective). Для этого форматирования `getHyperlinkClick` возвращает новую гиперссылку для первой части и `null` для второй.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("SmartArtHyperlink.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const smartArt = slide.getShapes().get_Item(2);
    const node = smartArt.getAllNodes().get_Item(3);
    const paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    const link = new aspose.slides.Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    const text = new aspose.slides.Portion(" (updated)");
    paragraph.getPortions().add(text);

    console.log(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    console.log(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **Создать полный инвентарь гиперссылок**

Перед распространением презентации необходимо инвентаризировать её интерактивные действия и веб‑ссылки. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) возвращает контейнеры гиперссылок, а не плоский список строк URL. Проверьте как [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick), так и [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) у каждого контейнера. Они независимы: один и тот же контейнер может иметь оба действия, поэтому полный отчёт может требовать до двух строк на контейнер.

Сканирование только гиперссылок уровня фигур может упустить ссылки, прикреплённые к частям текста. Вместо этого запросите соответствующий диапазон и сохраните полученные контейнеры, чтобы позже обновить или удалить их действия.

### **Запрос областей презентации, слайда и текстового кадра**

Класс [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) доступен через [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), и [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Каждый диапазон поддерживает одинаковые запросы:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) возвращает контейнеры с действием клика.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) возвращает контейнеры с действием наведения.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) возвращает контейнеры с любым из действий или обоими.

В этом примере назначаются действия клика и наведения фигуре и её тексту, а также действие макроса отдельной кнопке. Он сравнивает количество контейнеров, возвращённых [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks), с подсчётами для каждого типа активации. Запрос текстового кадра считает только ссылки в тексте. Действия самой охватывающей фигуры появляются в запросах слайда и презентации.

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

Для этого примера запросы презентации и слайда каждый возвращают три контейнера клика, два контейнера наведения и три контейнера с любым из действий. Запрос текстового кадра сообщает по одному контейнеру в каждой категории.

### **Классифицировать действия и назначения**

Используйте [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) для интерпретации действия перед интерпретацией его назначения. Значения [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) охватывают не только веб‑навигацию:

| Значения | Смысл для аудита |
| --- | --- |
| `Hyperlink` | Внешняя гиперссылка; проверьте URL и его схему. |
| `JumpSpecificSlide` | Внутренняя навигация к конкретному слайду. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Встроенная навигация слайд‑шоу, разрешаемая в контексте слайд‑шоу. |
| `JumpEndShow`, `StartCustomSlideShow` | Завершить текущий показ или запустить пользовательский показ. |
| `StartMacro` | Выполнить макрос. |
| `StartProgram` | Запустить программу. |
| `OpenFile`, `OpenPresentation` | Открыть файл или другую презентацию; рассматривать отдельно от веб‑URL. |
| `StartStopMedia` | Начать или остановить воспроизведение медиа. |
| `NoAction`, `Unknown` | Нет действия навигации, или неизвестное действие, требующее проверки. |

Считывайте внешние назначения через [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl), а конкретные внутренние назначения — через [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия у контейнера. Сохраняйте значение, возвращаемое [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal), когда оно отличается от нормализованного URL, и включайте подсказку, возвращаемую [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip), если она доступна.

### **Отчёт, очистка и проверка гиперссылок**

В этом примере открывается презентация из предыдущего примера и записывается одна запись JSON на каждое действие. Он использует [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) для сбора контейнеров на обычных слайдах, мастерах, макетах и заметках, включая мастеры заметок и раздаточных материалов, если они присутствуют. Он использует сравнение ссылок для подсчёта каждого контейнера единожды, применяет политику, описанную ниже, и повторно открывает сохранённую презентацию для проверки действий клика и наведения.

Отчёт фиксирует индекс слайда, начинающийся с единицы, и [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId), где он доступен. [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) предоставляет принадлежащий слайд для поддерживаемых контейнеров. У мастеров, макетов и заметок нет обычного индекса слайда и они идентифицируются по своей области. Контейнеры фигур и контейнеры форматирования частей текста помечаются отдельно; другие типы контейнеров сохраняют своё имя типа выполнения. Каждый контейнер получает локальный идентификатор в отчёте, чтобы его два действия можно было сопоставить. Отчёт сохраняет типы действий как целочисленные константы, определённые перечислением HyperlinkActionType.

Эта преднамеренно ограничительная политика приложения допускает только абсолютные HTTPS‑URL и допустимые внутренние цели слайдов. Она отклоняет макросы, программы, действия с файлами, другие действия слайд‑шоу, неизвестные действия и другие схемы URL. Эти отклонения являются политическими решениями, а не выводом о безопасности Aspose.Slides. Один лишь HTTPS не гарантирует доверие: добавьте списки разрешённых хостов и другие проверки для вашего приложения. Проверяются как оригинальные, так и нормализованные внешние URL. Пример проверяет метаданные без перехода по ссылкам или выполнения действий.

Для исправления контейнерный [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) поддерживает [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick), и [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Здесь запрещённые внешние ссылки клика заменяются фиксированной HTTPS‑страницей‑целевой; другие запрещённые клики и действия наведения удаляются независимо. Установите `replaceExternalClicks` в `false`, чтобы вместо этого удалить все нарушения политики. Выберите страницу-заменитель, принадлежащую приложению, перед развертыванием.

Флаг экспорта отчёта использует консервативную политику проверки PDF: помечать действия наведения и всё, кроме внешней ссылки или перехода к конкретному слайду, как потенциально неподдерживаемое. Это подсказка для проверки, а не проверка возможностей или гарантия того, что непомеченные ссылки сохранятся при экспорте. Поддерживаемые экспорты в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/) могут сохранять гиперссылки в зависимости от действия, параметров экспорта и просмотрщика. Растровые [изображения](/slides/ru/nodejs-java/convert-powerpoint-to-png/) и [видео](/slides/ru/nodejs-java/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; помечайте каждое действие при аудите для этих форматов.

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

С созданным выше вводом отчёт содержит пять строк действий. Ссылка наведения файлов и клик макроса удалены, в то время как HTTPS‑ссылки и внутренняя навигация по слайдам остаются. При проверке выводится ноль запрещённых действий. Ввод, содержащий запрещённый внешний URL‑клик, также активирует ветку замены. Контейнер с разрешённым кликом и запрещённым наведением сохраняет действие клика.

Эта выборочная очистка отличается от [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), который удаляет оба типа активации по всему выбранному диапазону независимо от политики. Проверка здесь проверяет только действия гиперссылок; она не удаляет встроенные VBA‑проекты, OLE‑объекты или другой активный контент и не проверяет экспортированный PDF или HTML‑файл.

## **FAQ**

**Как я могу создать ссылку на раздел или первый слайд этого раздела?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка ориентируется на отдельный слайд. Чтобы создать навигацию к разделу, привяжите ссылку к первому слайду этого раздела.

**Могу ли я прикрепить гиперссылку к элементам шаблона слайда, чтобы она работала на всех слайдах?**

Да. Элементы мастер‑слайда и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа слайдов на слайдах, использующих соответствующий мастер или макет.

**Будут ли гиперссылки сохраняться при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемые экспорты в PDF и HTML могут сохранять гиперссылки; растровые изображения и видео — нет. Смотрите соображения по экспорту в [Отчёт, очистка и проверка гиперссылок](#report-sanitize-and-verify-hyperlinks).