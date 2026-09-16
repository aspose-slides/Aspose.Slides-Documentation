---
title: Управление гиперссылками презентации на Android
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/androidjava/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- гиперссылка в тексте
- гиперссылка на слайд
- гиперссылка на фигуру
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Добавляйте, форматируйте, обновляйте и удаляйте гиперссылки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Android via Java, используя примеры на Java."
---
## **Введение**

Гиперссылка соединяет содержимое презентации с веб‑сайтом или местом внутри презентации. В PowerPoint гиперссылки обычно служат двум целям:

* Открыть веб‑сайт из текста, фигуры или медиа‑кадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides for Android via Java позволяет добавлять такие ссылки, управлять их внешним видом и звуком, обновлять их свойства и удалять их. Приведённые ниже примеры показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового кадра.

{{% alert color="info" title="Note" %}}

Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/ru/editor).

{{% /alert %}} 

## **Добавить URL‑гиперссылки**

Вы можете присвоить веб‑адрес URL тексту, фигуре или медиа‑кадру. Элемент, к которому вы присваиваете гиперссылку, определяет область клика: часть текста связывает выбранный текст, а фигура или кадр связывают объект слайда.

### **Добавить URL‑гиперссылки к тексту**

Чтобы связать текст с веб‑сайтом, передайте объект [Hyperlink](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/hyperlink/) в метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) части текста, как показано ниже. Только эта часть текста становится кликабельной.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Добавить URL‑гиперссылки к фигурам и медиа‑кадрам**

Чтобы сделать фигуру или кадр кликабельными, вызовите их метод [setHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). Гиперссылка принадлежит самому объекту, а не части текста внутри него.

Тот же подход применяется к кадрам изображений, аудио и видео: присвойте гиперссылку кадру и при необходимости вызовите [setTooltip](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-).

Ниже пример, который делает прямоугольник кликабельным:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Использовать гиперссылки для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к определённому слайду. В следующем примере используется метод [setInternalHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) для связи текста «Page 2» на первом слайде со вторым слайдом.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Форматировать гиперссылки**

### **Цвет**

Метод [setColorSource](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) интерфейса [IHyperlink](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы задать собственный цвет текста, выберите значение [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/hyperlinkcolorsource/) и задайте цвет заливки части. Эта возможность была введена в PowerPoint 2019; более ранние версии её не поддерживают.

Ниже пример, который добавляет две текстовые гиперссылки на один слайд. Первая использует красный цвет текста, вторая сохраняет цвет гиперссылки по умолчанию.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Звук**

Гиперссылка может воспроизводить звук при активации или останавливать уже воспроизводимый звук. Используйте следующие методы для настройки этих действий:

- [IHyperlink.setSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) указывает аудио, связанное с гиперссылкой.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) контролирует, будет ли активация гиперссылки останавливать предыдущее звучание.

#### **Добавить звук к гиперссылке**

В следующем примере загружается файл `sampleaudio.wav` и связывается с кнопкой на первом слайде. Нажатие кнопки воспроизводит звук и переходит к следующему слайду. Вторая фигура на этом слайде останавливает предыдущий звук при нажатии, без навигационного действия.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Извлечь звук из гиперссылки**

В следующем примере открывается презентация, созданная выше, и первый звук гиперссылки фигуры считывается в память через методы [getSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#getSound--) и [getBinaryData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Подсказка и настройки взаимодействия**

После назначения гиперссылки тексту или фигуре можно вызвать следующие методы интерфейса [IHyperlink](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/):

- [setTooltip](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) задаёт текст, который пользователь может увидеть как подсказку к ссылке.
- [setTargetFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) указывает целевой кадр внутри родительского HTML‑фреймсета, если применимо.
- [setHistory](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) контролирует, будет ли активация ссылки добавлять её пункт назначения в список просмотренных гиперссылок.
- [setHighlightClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) контролирует, будет ли гиперссылка выделяться при нажатии.

## **Удалить гиперссылки из презентаций**

Используйте метод [getAnyHyperlinks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) для получения контейнеров гиперссылок, включая ссылки частей текста, перед их изменением. Ниже пример, который удаляет оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите лишь [removeHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) или [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); удаление действия клика не удаляет его аналог при наведении.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Для безусловного удаления метод [removeAllHyperlinks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) удаляет оба типа активации в выбранной области одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок смотрите [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Создать полный список гиперссылок**

Перед распространением презентации создайте инвентарь её интерактивных действий и веб‑ссылок. Метод [getAnyHyperlinks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) возвращает объекты [IHyperlinkContainer](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkcontainer/), а не простой список URL‑строк. Проверяйте как [getHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) так и [getHyperlinkMouseOver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) для каждого контейнера. Они независимы: один контейнер может содержать оба действия, поэтому полный отчёт требует до двух строк на контейнер.

Сканирование только гиперссылок уровня фигур может пропустить ссылки, прикреплённые к частям текста. Выполняйте запрос в соответствующей области и сохраняйте полученные контейнеры, чтобы позже обновить или удалить их действия.

### **Запрос областей презентации, слайда и текстового кадра**

Интерфейс [IHyperlinkQueries](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/) доступен через свойства [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) и [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Каждая область поддерживает одинаковые запросы:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) возвращает контейнеры с действием клика.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) возвращает контейнеры с действием наведения мыши.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) возвращает контейнеры с любым из этих действий.

Ниже пример, который создаёт файл `hyperlink-audit-input.pptx` с внешней ссылкой‑кликом, ссылкой‑наведение‑мыши на файл, внутренней навигацией по слайдам, ссылкой‑наведение‑мыши на текст и действием макроса. Он не выполняет ни одно из этих действий. Три запроса работают в каждой области; их результаты описывают контейнеры, а не количество действий. Область текстового кадра исключает ссылки самой фигуры‑контейнера.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для этого примера запросы презентации и слайда каждый возвращают три контейнера клика, два контейнера наведения и три контейнера с любым действием. Запрос текстового кадра возвращает по одному контейнеру в каждой категории.

### **Классифицировать действия и назначения**

Для определения типа действия перед интерпретацией назначения используйте метод [IHyperlink.getActionType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#getActionType--). Значения перечисления [HyperlinkActionType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/hyperlinkactiontype/) охватывают не только веб‑навигацию:

| Значения | Смысл для аудита |
| --- | --- |
| `Hyperlink` | Внешняя гиперссылка; проверьте URL и его схему. |
| `JumpSpecificSlide` | Внутренняя навигация к определённому слайду. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Встроенная навигация слайд‑шоу, разрешаемая в контексте показа. |
| `JumpEndShow`, `StartCustomSlideShow` | Завершить текущий показ или запустить пользовательский показ. |
| `StartMacro` | Выполнить макрос. |
| `StartProgram` | Запустить программу. |
| `OpenFile`, `OpenPresentation` | Открыть файл или другую презентацию; проверяйте отдельно от веб‑URL. |
| `StartStopMedia` | Начать или остановить воспроизведение медиа. |
| `NoAction`, `Unknown` | Нет навигационного действия или действие неизвестно и требует проверки. |

Внешние назначения читайте через [getExternalUrl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--), а конкретные внутренние назначения — через [getTargetSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия. Сохраняйте значение, возвращаемое [getExternalUrlOriginal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--), если оно отличается от нормализованного URL, и включайте подсказку, возвращаемую [getTooltip](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlink/#getTooltip--), когда она доступна.

### **Отчет, очистка и проверка гиперссылок**

Ниже приведён пример на Java, который читает существующую презентацию (используйте файл, созданный выше), записывает `hyperlink-audit.json`, применяет политику, сохраняет `hyperlink-sanitized.pptx` и снова открывает её для повторной проверки обоих типов активации. Перед изменением контейнеры собираются, а при обработке используется сравнение ссылок, чтобы не обрабатывать один и тот же контейнер дважды. Запросы презентации охватывают обычные слайды; для инвентаризации всего пакета они также явно запрашивают мастера, макеты, заметки и мастера раздаточных материалов, если они присутствуют.

Отчёт фиксирует индекс слайда, начинающийся с 1, и [getSlideId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) где это возможно. Метод [ISlideComponent.getSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidecomponent/#getSlide--) предоставляет слайд‑владелец для поддерживаемых контейнеров. У мастеров, макетов и заметок нет обычного индекса слайда и они идентифицируются по своей области. Контейнеры фигур и контейнеры форматирования частей текста помечаются отдельно; остальные типы сохраняют своё имя типа во время выполнения. Каждый контейнер получает локальный ID отчёта, чтобы его два действия можно было сопоставить. В отчёте типы действий сохраняются как целочисленные константы, определённые перечислением Java.

Эта преднамеренно строгая политика приложения разрешает только абсолютные HTTPS‑URL и корректные внутренние цели слайдов. Она отклоняет макросы, программы, файловые действия, другие действия слайд‑шоу, неизвестные действия и прочие схемы URL. Эти отклонения — решения политики, а не вывод о безопасности Aspose.Slides. Один лишь HTTPS не гарантирует доверие: добавьте списки разрешённых хостов и другие проверки для вашего приложения. Проверяются как оригинальные, так и нормализованные внешние URL. Пример проверяет метаданные без переходов по ссылкам и без выполнения действий.

Для исправления контейнерный метод [getHyperlinkManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) поддерживает [setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) и [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Здесь запрещённые внешние ссылки‑клики заменяются фиксированной HTTPS‑страницей‑приёмником; остальные запрещённые клики и действия наведения удаляются независимо. Установите `replaceExternalClicks` в `false`, чтобы удалить все нарушения политики. Выберите страницу‑заменитель, принадлежащую вашему приложению, перед развертыванием.

Флаг экспорта отчёта использует консервативную политику проверки PDF: помечайте действия наведения и всё, что не является внешней ссылкой или переходом к конкретному слайду, как потенциально неподдерживаемое. Это лишь рекомендация для проверки, а не тест возможностей или гарантия, что непомеченные ссылки сохранятся при экспорте. Поддерживаемый экспорт в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/) может сохранять гиперссылки в зависимости от действия, параметров экспорта и просмотрщика. Растровые [изображения](/slides/ru/androidjava/convert-powerpoint-to-png/) и [видео](/slides/ru/androidjava/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; помечайте каждое действие при аудитах для этих форматов.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Сериализовать плоские строки этого отчёта без дополнительной зависимости JSON.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

С созданным выше вводом отчёт содержит пять строк действий. Ссылка‑наведение на файл и макрос‑клик удаляются, тогда как HTTPS‑ссылки и внутренняя навигация по слайдам остаются. Проверка выводит ноль запрещённых действий. Ввод, содержащий запрещённый внешний URL‑клик, также демонстрирует ветвь замены. Контейнер с разрешённым кликом и запрещённым наведением сохраняет своё действие‑клик.

Эта выборочная очистка отличается от метода [removeAllHyperlinks](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), который удаляет оба типа активации по всей выбранной области независимо от политики. Проверка здесь рассматривает только действия гиперссылок; она не удаляет встроенные VBA‑проекты, OLE‑объекты или другое активное содержимое и не проверяет экспортированный PDF или HTML файл.

## **FAQ**

**Как я могу создать ссылку на раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка указывает на отдельный слайд. Чтобы выполнить навигацию к разделу, свяжите её с первым слайдом этого раздела.

**Могу ли я привязать гиперссылку к элементам мастер‑слайда, чтобы она работала на всех слайдах?**

Да. Элементы мастер‑слайда и макета поддерживают гиперссылки. Такие ссылки доступны во время показа на всех слайдах, использующих соответствующий мастер или макет.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемый экспорт в PDF и HTML может сохранять гиперссылки; растровые изображения и видео — нет. См. рекомендации по экспорту в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).