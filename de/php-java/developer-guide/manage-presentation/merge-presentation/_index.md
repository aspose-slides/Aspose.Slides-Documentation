---
title: Effizientes Zusammenführen von Präsentationen in PHP
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/php-java/merge-presentation/
keywords:
- PowerPoint zusammenführen
- Präsentationen zusammenführen
- Folien zusammenführen
- PPT zusammenführen
- PPTX zusammenführen
- ODP zusammenführen
- PowerPoint kombinieren
- Präsentationen kombinieren
- Folien kombinieren
- PPT kombinieren
- PPTX kombinieren
- ODP kombinieren
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in PHP durch Klonen von Folien, Steuerung von Mastern und Layouts, Anpassen der Foliengröße, Erhalt von Abschnitten und Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für PHP via Java fügt Präsentationen zusammen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) in eine andere geklont werden. Der Hauptvorgang ist [SlideCollection::addClone()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/), der die Formatierung der Quellfolie beibehalten oder die geklonte Folie an einen Master oder ein Layout in der Zielpräsentation anhängen kann.

Dieser Artikel behandelt die gängigsten Zusammenführungs‑Workflows:

- alle Folien zusammenführen und dabei die Quellformatierung beibehalten;
- ausgewählte Folien zusammenführen;
- einen Master aus der Zielpräsentation anwenden;
- ein bestimmtes Layout aus der Zielpräsentation anwenden;
- unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- geklonte Folien zu einem Abschnitt hinzufügen;
- mehrere Präsentationen in einem End‑to‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Probleme behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie übernimmt einen Großteil ihres Erscheinungsbildes von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Klon‑Überladung, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [SlideCollection::addClone()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/) auf eine dieser Arten:

- `addClone(sourceSlide)` — die Layout‑ und Formatierung der Quellfolie beibehalten. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — die geklonte Folie an einen bestimmten Ziel-[MasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) anhängen. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(sourceSlide, destinationLayout)` — die geklonte Folie direkt an ein bestimmtes Ziel-[LayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/) anhängen.

Der übergebene Master oder das Layout eines `addClone`‑Überlades muss zur **Ziel**‑Präsentation gehören, nicht zur Quellpräsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Der einfachste Merge kopiert jede Folie aus der Quellpräsentation in die Zielpräsentation. Dies ist die passende Wahl, wenn die importierten Folien ihr ursprüngliches Thema, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quelle und Ziel unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst erhalten bleibt.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quellpräsentation.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien unter Verwendung eines Ziel‑Masters zusammenführen**

Verwenden Sie die [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Zielpräsentation gehört.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides wählt ein geeignetes Layout unter dem angegebenen Master, indem es den Typ oder Namen des Quell‑Layouts abgleicht. Existiert kein passendes Layout und `allowCloneMissingLayout` ist `true`, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien unter Verwendung eines bestimmten Ziel‑Layouts zusammenführen**

Verwenden Sie die [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/)‑Überladung, wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Das Anwenden eines Ziel‑Layouts ändert die vererbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Haben Quelle und Ziel unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die vererbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienmaßen können zusammengeführt werden, doch das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet deren Inhalt nicht automatisch für die neue Leinwand um. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs dargestellt werden.

Ein praktischer Ansatz ist, die Quellpräsentation vor dem Klonen zu skalieren. Die [SlideSize::setSize()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/setsize/)‑Methode kann vorhandenen Inhalt skalieren, während die Folienmaße geändert werden. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesizescaletype/) skaliert den Inhalt, um in die gewünschte Größe zu passen.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Durch Skalierung wird das Quell‑Präsentationsobjekt im Speicher geändert. Wenn Sie die ursprüngliche Quellpräsentation für weitere Vorgänge unverändert benötigen, öffnen Sie für den Merge eine separate Instanz.

## **Folien in einen Präsentationsabschnitt zusammenführen**

Die grundlegende Folien‑Klon‑Schleife stellt die Abschnittshierarchie der Quellpräsentation nicht wieder her. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation und klonen Sie Folien explizit mit [addClone(Slide, Section)](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, enumerieren Sie [Presentation::getSections](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSections), holen Sie die aktuellen Folien jedes Quellabschnitts mit [Section::getSlidesListOfSection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getSlidesListOfSection), rekonstruieren Sie die Abschnitte im Ziel und klonen Sie jede zurückgegebene Folie in ihren entsprechenden Zielabschnitt. Siehe [Manage Slide Sections](/slides/de/php-java/slide-section/) für ein vollständiges Abschnitt‑Enumerierungs‑Beispiel, inklusive leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑to‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur solange offen, wie sie kopiert wird, und speichert die Enddatei einmalig.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Dies ist eine nützliche Basis, um die Quellformatierung importierter Folien beizubehalten. Müssen Sie ein einheitliches Ziel‑Theme verwenden, ersetzen Sie den einfachen `addClone($slide)`‑Aufruf durch die zuvor gezeigte Überladung für Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Standard‑Folien‑Klonen kann einen erforderlichen Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um zu verhindern, dass derselbe Master wiederholt geklont wird. Manuell geklonte Master werden von diesem Register nicht erfasst, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell identisch sind. Muss ein Corporate‑Template das finale Erscheinungsbild steuern, wählen Sie explizit einen Ziel‑Master oder ein Ziel‑Layout und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Sprecher‑Notizen und Folien‑Kommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie kopiert. Aspose.Slides stellt zudem dedizierte APIs für [presentation notes](/slides/de/php-java/presentation-notes/) und [presentation comments](/slides/de/php-java/presentation-comments/) bereit.

Ist die Formatierung der Notizenseite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows sollten Sie auch Kommentar‑Autoren und Thread‑Kommentare nach dem Zusammenführen von Dateien verschiedener Autoren oder Templates prüfen.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten referenzieren. Klonen Sie die Folie selbst statt nur die sichtbaren Shapes, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie verwandelt einen externen Link nicht in eingebetteten Inhalt. Testen Sie Pfade und URLs von verknüpften Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt explizit automatisch geklonte Master, dies sollte jedoch nicht als allgemeine Garantie gesehen werden, dass identische Binär‑Ressourcen aus unabhängigen Quellpräsentationen stets dedupliziert werden. Ist die Dateigröße entscheidend, inspizieren Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriftarten und Verfügbarkeit von Schriftarten**

Schriftarten werden auf Präsentationsebene verwaltet. Muss die Typografie über verschiedene Geräte hinweg konsistent bleiben, gehen Sie nicht davon aus, dass das Klonen von Folien allein garantiert, dass jede benötigte Schriftart in der Zielumgebung verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getembeddedfonts/) prüfen und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/php-java/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie berechtigt sind, die in den Quell‑Dateien verwendeten Schriftarten einzubetten. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort geben Sie über [LoadOptions::setPassword()](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/setpassword/) an.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Arbeiten mit der entschlüsselten Präsentation.
} finally {
    $source->dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet den gleichen Schutz nicht automatisch auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen großen Binär‑Objekten können erheblichen Speicher beanspruchen. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Open Presentations](/slides/de/php-java/open-presentation/#open-large-presentations) für ein PHP‑via‑Java‑Beispiel zu großen Dateien.

Bei großen Dateien bevorzugen Sie nach Möglichkeit das Laden von Dateipfaden, entsorgen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Checkpoints.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie keine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)-Instanzen in mehreren Threads. Diese Vorgänge werden in PHP via Java nicht für Multithreading unterstützt. Benötigen Sie parallele Merge‑Jobs, führen Sie sie in separaten Single‑Thread‑Prozessen aus, wobei jeder Prozess seine eigenen Präsentationsinstanzen nutzt, und befolgen Sie die [Aspose.Slides multithreading guidance](/slides/de/php-java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [SlideCollection::addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/) ohne Angabe eines Ziel‑Masters oder Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Design verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout verwenden soll. Verwenden Sie einen Master, wenn Aspose.Slides basierend auf dem Typ oder Namen des Quell‑Layouts zwischen den Layouts dieses Masters auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, jedoch wird der Folieninhalt nicht automatisch für die Ziel‑Abmessungen neu gestaltet. Skalieren Sie die Quellpräsentation zuerst, wenn Sie eine vorhersehbare Platzierung benötigen, beispielsweise mit [SlideSize::setSize()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/setsize/) und [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesizescaletype/).

**Kann ich PPT-, PPTX- und ODP-Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die erforderlichen Folien in ein Ziel und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da Präsentationsformate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Merges. Siehe [Supported File Formats](/slides/de/php-java/supported-file-formats/).

**Werden Quellabschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Rekonstruieren Sie die benötigten Abschnitte im Ziel und verwenden Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden mit der geklonten Folie kopiert. Für Workflows, die von der Stilistik des Notizen‑Masters, Kommentar‑Autoren oder Thread‑Reviews abhängen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Strukturen betreffen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übertragen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus jeder Quelle garantiert in der zusammengeführten Präsentation verfügbar?**

Verlassen Sie sich nicht allein auf das Klonen von Folien für die Schriftarten‑Bereitstellung. Inspizieren Sie die eingebetteten Schriftarten des Ziels und verwalten Sie das Einbetten bzw. die Verfügbarkeit externer Schriftarten explizit, wenn Typografie wichtig ist.

**Wie füge ich eine passwortgeschützte Datei zusammen?**

Öffnen Sie sie mit dem korrekten [LoadOptions::setPassword()](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/setpassword/), dann klonen Sie ihre Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie sollte ich sehr große Präsentationen handhaben?**

Verwenden Sie BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden von Dateipfaden für sehr große Dateien, entsorgen Sie Quellpräsentationen zügig und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Das Laden, Speichern oder Klonen von Präsentationen in mehreren Threads wird in PHP via Java nicht unterstützt. Für parallele Arbeiten nutzen Sie separate Single‑Thread‑Prozesse und halten Sie Präsentationsinstanzen in jedem Prozess isoliert.