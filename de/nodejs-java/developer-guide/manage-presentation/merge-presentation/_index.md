---
title: Präsentationen effizient in JavaScript zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in JavaScript durch das Klonen von Folien, das Steuern von Mastern und Layouts, das Ändern der Foliengröße, das Beibehalten von Abschnitten und den Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides for Node.js via Java kombiniert Präsentationen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) in eine andere geklont werden. Der Hauptvorgang ist [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), der die Formatierung der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zielpräsentation zuordnen kann.

Dieser Artikel behandelt die häufigsten Zusammenführungs‑Workflows:

- alle Folien zusammenführen und dabei die Quellformatierung beibehalten;
- ausgewählte Folien zusammenführen;
- einen Master aus der Zielpräsentation anwenden;
- ein bestimmtes Layout aus der Zielpräsentation anwenden;
- unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- geklonte Folien zu einem Abschnitt hinzufügen;
- mehrere Präsentationen in einem vollständigen Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Probleme behandeln.

## **Wie das Klonen von Folien Master‑ und Layout‑Beziehungen beeinflusst**

Eine Folie erbt einen Großteil ihres Aussehens von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/) auf eine der folgenden Arten:

- `addClone(sourceSlide)` — behalte das Layout und die Formatierung der Quellfolie bei. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, nicht mehrfach geklont werden.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — ordne die geklonte Folie einem bestimmten Ziel-[MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) zu. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(sourceSlide, destinationLayout)` — ordne die geklonte Folie direkt einem bestimmten Ziel-[LayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/) zu.

Der an `addClone` übergebene Master oder das Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Variante kopiert jede Folie der Quell‑Präsentation in die Ziel‑Präsentation. Dies ist die geeignete Wahl, wenn die importierten Folien ihr ursprüngliches Theme, ihren Master und ihre Layout‑Beziehungen behalten sollen.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Ziel‑Präsentation unterschiedliche Designs verwenden. Dies ist zu erwarten, wenn die Quellformatierung bewusst erhalten bleibt.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quell‑Präsentation.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

Verwenden Sie die Überladung [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-), wenn importierte Folien einem Master folgen sollen, der bereits zur Ziel‑Präsentation gehört.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides wählt unter dem angegebenen Master ein passendes Layout, das dem Typ oder Namen des Quell‑Layouts entspricht. Existiert kein geeignetes Layout und ist `allowCloneMissingLayout` auf `true` gesetzt, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout im Ziel‑Master zu erzeugen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die Überladung [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-), wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Das Anwenden eines Ziel‑Layouts ändert die vererbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die vererbte Formatierung und das Platzhalter‑Verhalten passen.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit verschiedenen Folienabmessungen können zusammengeführt werden, aber das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet deren Inhalt nicht automatisch neu für die neue Leinwand. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktikabler Ansatz ist, die Quell‑Präsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.setSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) kann vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Das Ändern der Größe wirkt sich nur auf das Quell‑Präsentationsobjekt im Speicher aus. Wenn das Original‑Quell‑Präsentationsobjekt für weitere Vorgänge unverändert bleiben muss, öffnen Sie eine separate Instanz für den Merge.

## **Folien in einen Präsentations‑Abschnitt einfügen**

Die grundlegende Folien‑Klon‑Schleife erstellt die Abschnittshierarchie der Quell‑Präsentation nicht neu. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Ziel‑Präsentation aus und klonen Sie Folien explizit in diese mit [addClone(Slide, Section)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quell‑Abschnitte zu erhalten, enumerieren Sie [Presentation.getSections](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSections), rufen Sie die aktuellen Folien jedes Quell‑Abschnitts mit [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getSlidesListOfSection) ab, erstellen Sie die Abschnitte in der Ziel‑Präsentation neu und klonen Sie jede zurückgegebene Folie in den jeweiligen Ziel‑Abschnitt. Siehe [Manage Slide Sections](/slides/de/nodejs-java/slide-section/) für ein vollständiges Beispiel zur Abschnitts‑Enumeration, inklusive leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑to‑End‑Beispiel verwendet die erste Präsentation als Ziel‑Präsentation, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur geöffnet, solange sie kopiert wird, und speichert die endgültige Datei erst zum Schluss.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Dies ist ein nützliches Grundgerüst, um die Quellformatierung importierter Folien zu erhalten. Wenn Ihr Ergebnis ein einheitliches Ziel‑Theme verwenden muss, ersetzen Sie den einfachen Aufruf `addClone(sourceSlide)` durch die passende Ziel‑Master‑ oder Ziel‑Layout‑Überladung, die weiter oben gezeigt wurde.

## **Praktische Überlegungen**

### **Master, Layouts und Treue der Formatierung**

Das Standard‑Klönen von Folien kann einen erforderlichen Quell‑Master automatisch in die Ziel‑Präsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um zu vermeiden, dass derselbe Master mehrfach geklont wird. Manuell geklonte Master werden von diesem Register nicht erfasst, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit demselben Namen visuell identisch sind. Wenn eine Unternehmensvorlage das endgültige Aussehen steuern muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout explizit aus und überprüfen Sie das Ergebnis nach dem Zusammenführen.

### **Notizen und Kommentare**

Sprecher‑Notizen und Folien‑Kommentare sind an den Folieninhalt gebunden und werden beim Klonen einer Folie mitkopiert. Aspose.Slides stellt zudem dedizierte APIs für [presentation notes](/slides/de/nodejs-java/presentation-notes/) und [presentation comments](/slides/de/nodejs-java/presentation-comments/) bereit.

Ist die Formatierung der Notiz‑Seite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notiz‑Master auf Präsentationsebene liegen und zwischen Quell‑Dateien variieren können. Für Review‑Workflows sollten Sie zudem Kommentar‑Autoren und verschachtelte Kommentare nach dem Kombinieren von Dateien unterschiedlicher Autoren oder Vorlagen prüfen.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst statt nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt abhängig von seinem externen Ziel; das Klonen einer Folie verwandelt einen externen Link nicht in eingebetteten Inhalt. Testen Sie Pfade und URLs von verknüpften Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides zeichnet automatisch geklonte Master nach, das bedeutet jedoch nicht, dass identische Binär‑Ressourcen aus unabhängigen Quell‑Präsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, inspizieren Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriftarten und Verfügbarkeit von Schriftarten**

Schriftarten werden auf Präsentationsebene verwaltet. Wenn die Typografie über verschiedene Geräte hinweg konsistent sein muss, gehen Sie nicht davon aus, dass das Klonen von Folien allein garantiert, dass jede benötigte Schriftart im Ziel‑Umfeld verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) prüfen und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/nodejs-java/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie die Berechtigung zum Einbetten der in den Quell‑Dateien verwendeten Schriftarten besitzen. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor deren Folien geklont werden können. Das Passwort wird über [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) angegeben.

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Arbeiten mit der entschlüsselten Präsentation.
} finally {
    source.dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Ziel‑Präsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binär‑Objekten können viel Speicher beanspruchen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateien. Siehe [Manage Presentation BLOBs](/slides/de/nodejs-java/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien laden Sie nach Möglichkeit über Dateipfade, entsorgen jede Quell‑Präsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, sofern der Workflow keine Zwischenspeicherungen erfordert.

### **Thread‑Sicherheit**

Laden, speichern oder klonen Sie eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz nicht in mehreren Threads. Diese Vorgänge werden nicht für den Multithread‑Einsatz unterstützt. Wenn Sie unabhängige Merge‑Jobs parallelisieren müssen, verwenden Sie mehrere ein‑Thread‑Prozesse, jeder mit eigenen Präsentations‑Instanzen, und beachten Sie die [Aspose.Slides‑Multithreading‑Leitlinien](/slides/de/nodejs-java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quell‑Präsentation bei?**

Verwenden Sie [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Ziel‑Präsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quell‑Folie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout nutzen soll. Verwenden Sie einen Master, wenn Aspose.Slides basierend auf dem Typ oder Namen des Quell‑Layouts ein passendes Layout aus diesem Master auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Ziel‑Abmessungen neu gestaltet. Skalieren Sie die Quell‑Präsentation zuerst, z. B. mit [SlideSize.setSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quell‑Präsentation, klonen Sie die gewünschten Folien in eine Ziel‑Präsentation und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach einem Format‑übergreifenden Merge. Siehe [Supported File Formats](/slides/de/nodejs-java/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Erstellen Sie die erforderlichen Abschnitte in der Ziel‑Präsentation und verwenden Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notiz‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten betreffen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Strukturen umfassen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus allen Quellen im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht allein auf das Klonen von Folien für die Schriftarten‑Bereitstellung. Prüfen Sie die eingebetteten Schriftarten im Ziel und verwalten Sie das Einbetten oder die externe Verfügbarkeit von Schriftarten explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie das BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, laden Sie nach Möglichkeit über Dateipfade, entsorgen Sie Quell‑Präsentationen umgehend nach dem Merge und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Laden, speichern oder klonen Sie Präsentations‑Instanzen nicht in mehreren Threads. Für parallele Merge‑Jobs verwenden Sie separate ein‑Thread‑Prozesse mit unabhängigen Präsentations‑Instanzen.