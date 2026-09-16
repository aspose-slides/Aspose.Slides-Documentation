---
title: Hyperlinks in Präsentationen verwalten in PHP
linktitle: Hyperlinks verwalten
type: docs
weight: 20
url: /de/php-java/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text-Hyperlink
- Folien-Hyperlink
- Form-Hyperlink
- Bild-Hyperlink
- Video-Hyperlink
- veränderbarer Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java hinzufügen, formatieren, aktualisieren und entfernen, anhand von PHP-Beispielen."
---
## **Einleitung**

Ein Hyperlink verbindet Präsentationsinhalte mit einer Website oder einem Ort innerhalb der Präsentation. In PowerPoint dienen Hyperlinks üblicherweise zwei Zwecken:

* Öffnen einer Website über Text, eine Form oder einen Medienrahmen.
* Navigieren zu einer anderen Folie, zum Beispiel aus einem Inhaltsverzeichnis.

Aspose.Slides for PHP via Java ermöglicht das Hinzufügen dieser Links, die Steuerung von Aussehen und Klang, das Aktualisieren ihrer Eigenschaften und das Entfernen. Die nachstehenden Beispiele zeigen, wie mit Hyperlinks auf einzelnen Elementen gearbeitet wird und wie auf Hyperlinks auf Präsentations‑, Folien‑ oder Textfeld‑Ebene zugegriffen wird. Sie setzen voraus, dass PHP/Java Bridge und der Aspose.Slides PHP‑Wrapper initialisiert sind. API‑Mitglieder ohne PHP‑Referenzseiten‑Link verweisen auf die zugrunde liegende Java‑API.

{{% alert color="info" title="Note" %}}

Sie können Präsentationen auch mit dem [free online Aspose PowerPoint editor](https://products.aspose.app/slides/de/editor) bearbeiten.

{{% /alert %}} 

## **URL-Hyperlinks hinzufügen**

Sie können einer Website‑URL Text, einer Form oder einem Medienrahmen zuweisen. Das Element, dem Sie den Hyperlink zuweisen, bestimmt den anklickbaren Bereich: ein Textabschnitt verlinkt den ausgewählten Text, während eine Form oder ein Rahmen das Folienobjekt verlinkt.

### **URL-Hyperlinks zu Text hinzufügen**

Um Text mit einer Website zu verlinken, übergeben Sie ein [Hyperlink](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/) an die [setHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/sethyperlinkclick/)‑Methode des Textabschnitts, wie unten gezeigt. Nur dieser Textabschnitt wird anklickbar.

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

### **URL-Hyperlinks zu Formen und Medienrahmen hinzufügen**

Um eine Form oder einen Rahmen anklickbar zu machen, rufen Sie deren [setHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/sethyperlinkclick/)‑Methode auf. Der Hyperlink gehört zum Objekt selbst und nicht zu einem Textabschnitt darin.

Der gleiche Ansatz gilt für Bild-, Audio‑ und Video‑Rahmen: Weisen Sie den Hyperlink dem Rahmen zu und rufen Sie bei Bedarf [setTooltip](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/settooltip/) auf.

Das folgende Beispiel macht ein Rechteck anklickbar:

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

## **Hyperlinks zum Erstellen eines Inhaltsverzeichnisses verwenden**

Interne Hyperlinks ermöglichen es Lesern, von einem Inhaltsverzeichnis zu einer bestimmten Folie zu springen. Das folgende Beispiel verwendet [setInternalHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) um den Text „Page 2“ auf der ersten Folie mit der zweiten Folie zu verknüpfen.

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

## **Hyperlinks formatieren**

### **Farbe**

Die [setColorSource](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/setcolorsource/)‑Methode von [Hyperlink](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/) bestimmt, ob ein Hyperlink die Hyperlink‑Farbe der Präsentation oder die Formatierung des Textabschnitts verwendet. Um eine benutzerdefinierte Textfarbe anzuwenden, wählen Sie [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkcolorsource/) und setzen die Füllfarbe des Abschnitts. Diese Funktion wurde in PowerPoint 2019 eingeführt; ältere Versionen berücksichtigen diese Einstellung nicht.

Das folgende Beispiel fügt zwei Text‑Hyperlinks zur gleichen Folie hinzu. Der erste verwendet eine rote Textfüllung, der zweite behält die Standard‑Hyperlink‑Farbe bei.

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
### **Ton**

Ein Hyperlink kann beim Aktivieren einen Ton abspielen oder einen bereits spielenden Ton stoppen. Verwenden Sie die folgenden Methoden, um dieses Verhalten zu konfigurieren:

- [Hyperlink::setSound](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/setsound/) legt die dem Hyperlink zugeordnete Audiodatei fest.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/setstopsoundonclick/) steuert, ob das Aktivieren des Hyperlinks den vorherigen Ton stoppt.

#### **Hyperlink‑Ton hinzufügen**

Das folgende Beispiel lädt `sampleaudio.wav` und verknüpft es mit einem Button auf der ersten Folie. Beim Klicken auf den Button wird der Ton abgespielt und zur nächsten Folie navigiert. Eine zweite Form auf derselben Folie stoppt den vorherigen Ton beim Klicken, ohne eine Navigation auszuführen.

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

#### **Hyperlink‑Ton extrahieren**

Das folgende Beispiel öffnet die oben erstellte Präsentation und liest das Hyperlink‑Audio der ersten Form über [getSound](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/getsound/) und [getBinaryData](https://reference.aspose.com/slides/de/php-java/aspose.slides/audio/getbinarydata/) in den Speicher.

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

### **Tooltip‑ und Interaktionseinstellungen**

Sie können nach dem Zuweisen eines Hyperlinks zu Text oder einer Form die folgenden [Hyperlink](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/)‑Methoden aufrufen:

- [setTooltip](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/settooltip/) legt den Text fest, den ein Betrachter als Hinweis für den Link anzeigen kann.
- [setTargetFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/settargetframe/) gibt den Ziel‑Frame innerhalb eines übergeordneten HTML‑Framesets an, falls zutreffend.
- [setHistory](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/sethistory/) steuert, ob das Aktivieren des Links sein Ziel zur Liste der angesehenen Hyperlinks hinzufügt.
- [setHighlightClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/sethighlightclick/) steuert, ob der Hyperlink beim Klicken hervorgehoben wird.

## **Hyperlinks aus Präsentationen entfernen**

Verwenden Sie [getAnyHyperlinks](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/), um Hyperlink‑Container, einschließlich Text‑Abschnitt‑Links, zu sammeln, bevor Sie sie ändern. Das folgende Beispiel entfernt beide Aktivierungstypen von der ersten Folie. Um nur einen Typ zu entfernen, rufen Sie ausschließlich [removeHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) oder [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) auf; das Entfernen einer Klick‑Aktion entfernt nicht deren Maus‑Über‑Gegenstück.

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

Für bedingungslose Entfernung entfernt [removeAllHyperlinks](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) beide Aktivierungstypen im ausgewählten Umfang in einem Aufruf. Für selektive Bereinigung und Abdeckung von Master‑Folien, Layouts und Notizen siehe [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Ein vollständiges Hyperlink‑Inventar erstellen**

Bevor Sie eine Präsentation verbreiten, inventarisieren Sie deren interaktive Aktionen sowie deren Web‑Links. [getAnyHyperlinks](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) liefert [IHyperlinkContainer](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/)‑Objekte, keine flache Liste von URL‑Strings. Untersuchen Sie sowohl [getHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) als auch [getHyperlinkMouseOver](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) für jeden Container. Sie sind unabhängig: derselbe Container kann beide Aktionen exponieren, sodass ein vollständiger Bericht bis zu zwei Zeilen pro Container benötigen kann.

Das reine Scannen von Hyperlinks auf Form‑Ebene kann Links übersehen, die Text‑Abschnitte betreffen. Fragen Sie stattdessen den entsprechenden Umfang ab und behalten Sie die zurückgegebenen Container, damit Sie deren Aktionen später aktualisieren oder entfernen können.

### **Präsentations-, Folien‑ und Textfeld‑Umfänge abfragen**

Die Klasse [HyperlinkQueries](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/) ist über [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) und [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/gethyperlinkqueries/) verfügbar. Jeder Umfang unterstützt dieselben Abfragen:

- [getHyperlinkClicks](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) liefert Container mit einer Klick‑Aktion.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) liefert Container mit einer Maus‑Über‑Aktion.
- [getAnyHyperlinks](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) liefert Container mit einer oder beiden Aktionen.

Das folgende Beispiel erstellt `hyperlink-audit-input.pptx` mit einem externen Klick‑Link, einem Datei‑Maus‑Über‑Link, interner Folien‑Navigation, einem Text‑Maus‑Über‑Link und einer Makro‑Aktion. Es führt keine dieser Aktionen aus. Die gleichen drei Abfragen funktionieren in jedem Umfang; die Zählungen beschreiben Container, nicht die Gesamtzahl der Aktionen. Der Text‑Feld‑Umfang schließt die eigenen Links der umgebenden Form aus.

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

Für dieses Beispiel melden die Präsentations‑ und Folien‑Abfragen jeweils drei Klick‑Container, zwei Maus‑Über‑Container und drei Container mit einer beliebigen Aktion. Die Text‑Feld‑Abfrage meldet einen Container in jeder Kategorie.

### **Aktionen und Ziele klassifizieren**

Verwenden Sie [Hyperlink::getActionType](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/getactiontype/), um eine Aktion zu interpretieren, bevor Sie ihr Ziel interpretieren. Die Werte von [HyperlinkActionType](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkactiontype/) decken mehr als nur Web‑Navigation ab:

| Werte | Bedeutung für ein Audit |
| --- | --- |
| `Hyperlink` | Externer Hyperlink; URL und Schema prüfen. |
| `JumpSpecificSlide` | Interne Navigation zu einer bestimmten Folie. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Eingebaute Diashow‑Navigation, im Diashow‑Kontext aufgelöst. |
| `JumpEndShow`, `StartCustomSlideShow` | Aktuelle Show beenden oder benutzerdefinierte Show starten. |
| `StartMacro` | Makro ausführen. |
| `StartProgram` | Programm starten. |
| `OpenFile`, `OpenPresentation` | Datei oder andere Präsentation öffnen; separat von Web‑URLs prüfen. |
| `StartStopMedia` | Medienwiedergabe starten oder stoppen. |
| `NoAction`, `Unknown` | Keine Navigationsaktion oder nicht erkannte Aktion, die überprüft werden muss. |

Lesen Sie externe Ziele über [getExternalUrl](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/getexternalurl/) und spezifische interne Ziele über [getTargetSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/gettargetslide/). Interne Aktionen und eingebaute Befehle können keine externe URL besitzen; eine leere URL bedeutet nicht, dass der Container keine Aktion hat. Bewahren Sie den Wert von [getExternalUrlOriginal](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) auf, wenn er von der normalisierten URL abweicht, und fügen Sie den Tooltip aus [getTooltip](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlink/gettooltip/) hinzu, wenn verfügbar.

### **Hyperlinks berichten, bereinigen und verifizieren**

Das folgende PHP‑Beispiel liest eine bestehende Präsentation (verwenden Sie die oben erstellte Datei), schreibt `hyperlink-audit.json`, wendet eine Richtlinie an, speichert `hyperlink-sanitized.pptx` und öffnet sie erneut, um beide Aktivierungstypen erneut zu prüfen. Es sammelt Container, bevor sie geändert werden, und nutzt Referenzgleichheit, um dieselben Container nicht doppelt zu verarbeiten. Präsentations‑Abfragen decken normale Folien ab; für ein paketweites Inventar werden zudem explizit Master‑Folien, Layouts, Notizen sowie die Notiz‑ und Handzettel‑Master, falls vorhanden, abgefragt.

Der Bericht speichert einen ein‑basierten Folien‑Index und [getSlideId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#getSlideId--) sofern verfügbar. [ISlideComponent::getSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecomponent/#getSlide--) liefert die zugehörige Folie für unterstützte Container. Master‑Folien, Layouts und Notizen haben keinen normalen Folien‑Index und werden über ihren Umfang identifiziert. Form‑Container und Text‑Abschnitt‑Formatierungs‑Container werden separat benannt; andere Containertypen behalten ihren Laufzeit‑Typnamen. Jeder Container erhält eine berichts‑lokale ID, damit seine beiden Aktionen korreliert werden können. Der Bericht speichert Aktionstypen als die Ganzzahl‑Konstanten, die von der PHP‑Aufzählung definiert werden.

Diese bewusst restriktive Anwendungs‑Richtlinie erlaubt nur absolute HTTPS‑URLs und gültige interne Folien‑Ziele. Sie lehnt Makros, Programme, Datei‑Aktionen, andere Diashow‑Aktionen, unbekannte Aktionen und andere URL‑Schemen ab. Diese Ablehnungen sind Richtlinien‑Entscheidungen, kein Sicherheitsurteil von Aspose.Slides. HTTPS allein begründet kein Vertrauen: Fügen Sie Host‑Whitelist‑Einstellungen und weitere Prüfungen für Ihre Anwendung hinzu. Sowohl originale als auch normalisierte externe URLs werden geprüft. Das Beispiel prüft Metadaten, ohne Links zu folgen oder Aktionen auszuführen.

Zur Behebung unterstützt der [getHyperlinkManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) des Containers [setExternalHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) und [removeHyperlinkMouseOver](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Hier werden verbotene externe Klick‑Links durch eine feste HTTPS‑Landing‑Page ersetzt; andere verbotene Klick‑ und Maus‑Über‑Aktionen werden unabhängig entfernt. Setzen Sie `$replaceExternalClicks` auf `false`, um alle Richtlinien‑Verstöße zu entfernen. Wählen Sie vor dem Deployment eine von der Anwendung bereitgestellte Ersatz‑Seite aus.

Die Export‑Flagge des Berichts verwendet eine konservative PDF‑Überprüfung‑Richtlinie: Maus‑Über‑Aktionen und alles andere außer einem externen Link oder einem spezifischen Folien‑Sprung werden als potenziell nicht unterstützt gekennzeichnet. Es ist ein Hinweis zur Überprüfung, kein Fähigkeitstest oder eine Garantie, dass nicht gekennzeichnete Links den Export überstehen. Unterstützte [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/) und [HTML](/slides/de/php-java/convert-powerpoint-to-html/) Exporte können Hyperlinks erhalten, abhängig von der Aktion, den Export‑Optionen und dem Betrachter. Raster‑[images](/slides/de/php-java/convert-powerpoint-to-png/) und [video](/slides/de/php-java/convert-powerpoint-to-video/) können interaktive Hyperlinks nicht erhalten; kennzeichnen Sie jede Aktion, wenn Sie für diese Ausgaben auditieren.

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

Mit dem oben erstellten Input enthält der Bericht fünf Aktionszeilen. Der Datei‑Maus‑Über‑Link und das Makro‑Klick‑Element werden entfernt, während die HTTPS‑Links und die interne Folien‑Navigation erhalten bleiben. Die Verifizierung gibt null verbotene Aktionen aus. Ein Input mit einer verbotenen externen Klick‑URL testet zudem den Ersetzungs‑Zweig. Ein Container mit einem erlaubten Klick und einem verbotenen Maus‑Über‑Link behält seine Klick‑Aktion bei.

Diese selektive Bereinigung unterscheidet sich von [removeAllHyperlinks](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), das beide Aktivierungstypen im ausgewählten Umfang unabhängig von Richtlinien entfernt. Die Verifizierung hier prüft nur Hyperlink‑Aktionen; sie entfernt nicht eingebettete VBA‑Projekte, OLE‑Objekte oder andere aktive Inhalte und validiert auch nicht eine exportierte PDF‑ oder HTML‑Datei.

## **FAQ**

**Wie kann ich zu einem Abschnitt oder seiner ersten Folie verlinken?**

Abschnitte in PowerPoint gruppieren Folien, aber ein interner Hyperlink zielt auf eine einzelne Folie. Um zu einem Abschnitt zu navigieren, verlinken Sie zur ersten Folie dieses Abschnitts.

**Kann ich einem Master‑Folienelement einen Hyperlink zuweisen, sodass er auf allen Folien funktioniert?**

Ja. Elemente von Master‑Folien und Layouts unterstützen Hyperlinks. Links auf diesen Elementen stehen während der Bildshow auf allen Folien, die den entsprechenden Master oder das Layout verwenden, zur Verfügung.

**Werden Hyperlinks beim Export nach PDF, HTML, Bildern oder Video erhalten bleiben?**

Unterstützte PDF‑ und HTML‑Exporte können Hyperlinks erhalten; Raster‑Bilder und Video können das nicht. Siehe die Export‑Hinweise in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).