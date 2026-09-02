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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in PHP durch Klonen von Folien, Steuerung von Mastern und Layouts, Anpassen der Foliengröße, Beibehalten von Abschnitten und Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für PHP über Java fügt Präsentationen zusammen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) in eine andere geklont werden. Die Hauptoperation ist [SlideCollection::addClone()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/), die entweder die Formatierung der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zielpräsentation zuordnen kann.

Dieser Artikel behandelt die gebräuchlichsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei deren Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zielpräsentation anwenden;
- Ein bestimmtes Layout aus der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Probleme verarbeiten.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen Großteil ihres Erscheinungsbildes von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Klon‑Überladung, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [SlideCollection::addClone()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/) auf eine der folgenden Arten:

- `addClone(sourceSlide)` — die Layout‑ und Formatierung der Quellfolie beibehalten. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — die geklonte Folie an einen bestimmten Ziel‑[MasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) anhängen. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(sourceSlide, destinationLayout)` — die geklonte Folie direkt an einen bestimmten Ziel‑[LayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/) anhängen.

Der an eine `addClone`‑Überladung übergebene Master oder das Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quellpräsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie aus der Quellpräsentation in die Zielpräsentation. Diese Vorgehensweise ist geeignet, wenn die importierten Folien ihr ursprüngliches Design, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zielpräsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst beibehalten wird.

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

## **Folien mit einem Ziel‑Master zusammenführen**

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

Aspose.Slides wählt unter dem angegebenen Master ein passendes Layout aus, indem es den Typ oder Namen des Quell‑Layouts abgleicht. Existiert kein geeignetes Layout und `allowCloneMissingLayout` ist `true`, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn die Zusammenführung fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

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

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die geerbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, jedoch passt das Klonen einer Folie in eine Präsentation mit anderer Foliengröße den Inhalt nicht automatisch an die neue Zeichenfläche an. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktischer Ansatz besteht darin, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize::setSize()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/setsize/) kann den vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

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

Das Skalieren ändert das Quellpräsentations‑Objekt im Speicher. Wenn die ursprüngliche Quellpräsentation für weitere Vorgänge unverändert bleiben muss, öffnen Sie für die Zusammenführung eine separate Instanz.

## **Folien in einen Präsentationsabschnitt zusammenführen**

Die grundlegende Folien‑Klon‑Schleife stellt die Abschnittshierarchie der Quellpräsentation nicht wieder her. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation und klonen Sie Folien explizit mit [addClone(Slide, Section)](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/) in diese.

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

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, erstellen Sie diese im Ziel erneut und ordnen jeder Quellfolie den entsprechenden Zielabschnitt zu.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quellpräsentation nur während des Kopiervorgangs geöffnet und speichert die endgültige Datei ein einziges Mal.

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

Dies ist ein nützliches Fundament, um die Quellformatierung importierter Folien beizubehalten. Wenn Ihr Ergebnis ein einheitliches Ziel‑Design verwenden muss, ersetzen Sie den einfachen Aufruf `addClone($slide)` durch die zuvor gezeigte passende Ziel‑Master‑ oder Ziel‑Layout‑Überladung.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Das Standard‑Klonen von Folien kann einen erforderlichen Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein wiederholtes Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden von diesem Register nicht erfasst, daher vermeiden Sie das Vor‑Klonen von Mastern, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit demselben Namen visuell identisch sind. Wenn eine Unternehmensvorlage das endgültige Erscheinungsbild steuern muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout explizit und prüfen Sie das Ergebnis nach dem Zusammenführen.

### **Notizen und Kommentare**

Rednernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie kopiert. Aspose.Slides stellt außerdem dedizierte APIs für [presentation notes](https://docs.aspose.com/slides/de/php-java/presentation-notes/) und [presentation comments](https://docs.aspose.com/slides/de/php-java/presentation-comments/) bereit.

Wenn die Formatierung der Notizenseite wichtig ist, prüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie zudem die Kommentar‑Autoren und verschachtelten Kommentare, nachdem Sie Dateien verschiedener Autoren oder Vorlagen kombiniert haben.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten referenzieren. Klonen Sie die Folie selbst, anstatt nur die sichtbaren Formen zu kopieren, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie wandelt einen externen Link nicht in eingebetteten Inhalt um. Testen Sie Pfade und URLs verknüpfter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt explizit automatisch geklonte Master, dies sollte jedoch nicht als generelle Garantie dafür angesehen werden, dass identische Binär‑Ressourcen aus unabhängigen Quellpräsentationen stets dedupliziert werden. Wenn die Dateigröße wichtig ist, prüfen Sie das zusammengeführte Paket und messen das Ergebnis, anstatt sich auf implizite Deduplizierung zu verlassen.

### **Eingebettete Schriftarten und Schriftverfügbarkeit**

Schriftarten werden auf Präsentationsebene verwaltet. Wenn die Typografie auf verschiedenen Rechnern konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schriftart in der Zielumgebung verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getembeddedfonts/) prüfen und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](https://docs.aspose.com/slides/de/php-java/embedded-font/) beschrieben.

Stellen Sie außerdem sicher, dass Sie das Einbetten der in den Quell‑Dateien verwendeten Schriftarten dürfen. Schriftlizenzen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Geben Sie das Passwort über [LoadOptions::setPassword()](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/setpassword/) an.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Mit der entschlüsselten Präsentation arbeiten.
} finally {
    $source->dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen großen Binär‑Objekten können erheblichen Speicher beanspruchen. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Open Presentations](https://docs.aspose.com/slides/de/php-java/open-presentation/#open-large-presentations) für ein PHP‑via‑Java‑Beispiel für große Dateien.

Bei großen Dateien laden Sie nach Möglichkeit von Dateipfaden, entsorgen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie das wiederholte Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Checkpoints.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanzen nicht in mehreren Threads. Diese Vorgänge werden in PHP‑via‑Java nicht für die Mehr‑Thread‑Nutzung unterstützt. Wenn Sie parallele Merge‑Jobs benötigen, führen Sie sie in separaten Single‑Thread‑Prozessen aus, wobei jeder Prozess seine eigenen Präsentations‑Instanzen verwendet, und befolgen Sie die [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/de/php-java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [`addClone(sourceSlide)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein konkretes Layout, wenn jede importierte Folie ein bekanntes Layout nutzen soll. Verwenden Sie einen Master, wenn Sie möchten, dass Aspose.Slides basierend auf dem Typ oder Namen des Quell‑Layouts eines seiner Layouts auswählt.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber Folieninhalte werden nicht automatisch an die Ziel‑Abmessungen angepasst. Skalieren Sie die Quellpräsentation zuerst, wenn Sie eine vorhersehbare Platzierung benötigen, beispielsweise mit [SlideSize::setSize()](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/setsize/) und [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesizescaletype/).

**Kann ich PPT-, PPTX- und ODP‑Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die benötigten Folien in ein Ziel und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da Präsentationsformate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Zusammenführungen. Siehe [Supported File Formats](https://docs.aspose.com/slides/de/php-java/supported-file-formats/).

**Werden Quellabschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Erstellen Sie die erforderlichen Abschnitte im Ziel erneut und verwenden Sie die Abschnitts‑Überladung von [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Redner‑Notizen und Kommentare erhalten?**

Sie werden mit der geklonten Folie kopiert. Für Workflows, die von der Gestaltung des Notizen‑Masters, den Kommentar‑Autoren oder verschachtelten Review‑Daten abhängen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Strukturen betreffen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass ihre Ziel‑Dateien oder URLs nach dem Zusammenführen weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus allen Quellen garantiert in der zusammengeführten Präsentation verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Folienklonen für die Schriftarten‑Bereitstellung. Prüfen Sie die eingebetteten Schriftarten des Ziels und verwalten Sie das Einbetten von Schriftarten oder die Verfügbarkeit externer Schriftarten explizit, wenn Typografie wichtig ist.

**Wie führe ich eine passwortgeschützte Datei zusammen?**

Öffnen Sie sie mit dem richtigen [LoadOptions::setPassword()](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/setpassword/) und klonen Sie anschließend die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie sollte ich sehr große Präsentationen handhaben?**

Verwenden Sie das BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quellpräsentationen zeitnah und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Das Laden, Speichern oder Klonen von Präsentationen in mehreren Threads wird in PHP‑via‑Java nicht unterstützt. Für parallele Arbeiten verwenden Sie separate Single‑Thread‑Prozesse und halten Sie Präsentations‑Instanzen in jedem Prozess isoliert.