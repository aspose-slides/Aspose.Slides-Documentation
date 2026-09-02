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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in JavaScript durch Klonen von Folien, Steuern von Mastern und Layouts, Anpassen der Foliengröße, Bewahren von Abschnitten und den Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für Node.js über Java kombiniert Präsentationen, indem Folien von einer [Präsentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) in eine andere geklont werden. Die Hauptoperation ist [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), die das Format der Quellfolie erhalten oder die geklonte Folie an einen Master oder ein Layout in der Zielpräsentation anhängen kann.

Dieser Artikel behandelt die gebräuchlichsten Zusammenführungs‑Workflows:

- alle Folien zusammenführen und dabei ihr Quellformat beibehalten;
- ausgewählte Folien zusammenführen;
- einen Master aus der Zielpräsentation anwenden;
- ein bestimmtes Layout aus der Zielpräsentation anwenden;
- unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- geklonte Folien zu einem Abschnitt hinzufügen;
- mehrere Präsentationen in einem End‑zu‑Ende‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Probleme behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen großen Teil ihres Erscheinungsbildes von ihrem Layout und Master. Aus diesem Grund bestimmt die gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [SlideCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/) auf eine der folgenden Arten:

- `addClone(sourceSlide)` — das Layout und Format der Quellfolie beibehalten. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, nicht mehrfach geklont werden.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — die geklonte Folie an einen bestimmten Ziel‑[MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) anhängen. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layouttyps oder des Namens.
- `addClone(sourceSlide, destinationLayout)` — die geklonte Folie direkt an ein bestimmtes Ziel‑[LayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/) anhängen.

Der an `addClone` übergebene Master oder das Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quell‑Präsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Der einfachste Merge kopiert jede Folie der Quell‑Präsentation in die Ziel‑Präsentation. Dies ist die geeignete Wahl, wenn die importierten Folien ihr ursprüngliches Theme, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Ziel‑Präsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn das Quellformat bewusst erhalten wird.

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

Verwenden Sie die [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Ziel‑Präsentation gehört.

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

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master, indem es den Typ oder Namen des Quell‑Layouts abgleicht. Existiert kein geeignetes Layout und `allowCloneMissingLayout` ist `true`, wird das Quell‑Layout geklont, damit die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-)‑Überladung, wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

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

Das Anwenden eines Ziel‑Layouts ändert die ererbte Layout‑Beziehung; es gestaltet den Inhalt der Quell‑Folien nicht neu. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass das ererbte Format und das Verhalten der Platzhalter passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, aber das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet deren Inhalt nicht automatisch für die neue Leinwand um. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktischer Ansatz ist, die Quell‑Präsentation vor dem Klonen zu skalieren. Die [SlideSize.setSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)‑Methode kann bestehenden Inhalt skalieren und gleichzeitig die Folienabmessungen ändern. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesizescaletype/) skaliert Inhalte, sodass sie in die gewünschte Größe passen.

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

Durch Skalieren wird das Quell‑Präsentationsobjekt im Speicher geändert. Wenn Sie die ursprüngliche Quell‑Präsentation für weitere Vorgänge unverändert benötigen, öffnen Sie eine separate Instanz für den Merge.

## **Folien in einen Präsentations‑Abschnitt zusammenführen**

Die grundlegende Folien‑Klon‑Schleife reproduziert nicht die Abschnittshierarchie der Quell‑Präsentation. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Ziel‑Präsentation und klonen Sie Folien explizit mit [addClone(Slide, Section)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quell‑Abschnitte zu erhalten, reproduzieren Sie diese Abschnitte in der Ziel‑Präsentation und ordnen Sie jede Quell‑Folient dem entsprechenden Ziel‑Abschnitt zu.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑Ende‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jedes zusätzlichen Quell‑Dokuments, hält jede Quelle nur geöffnet, solange sie kopiert wird, und speichert die endgültige Datei einmalig.

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

Dies ist ein nützlicher Ausgangspunkt, um die Quellformatierung importierter Folien zu erhalten. Wenn Ihre Ausgabe ein einheitliches Ziel‑Theme verwenden muss, ersetzen Sie den einfachen Aufruf `addClone(sourceSlide)` durch die zuvor gezeigte passende Ziel‑Master‑ oder Ziel‑Layout‑Überladung.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Das standardmäßige Folienklonen kann einen erforderlichen Quell‑Master automatisch in die Ziel‑Präsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um Wiederholungen zu vermeiden. Manuell geklonte Master werden nicht im Register erfasst, daher sollten Sie Master nicht im Voraus klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit demselben Namen visuell äquivalent sind. Wenn ein Unternehmens‑Template das endgültige Aussehen steuern muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout explizit und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Sprechernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen der Folie mitkopiert. Aspose.Slides stellt zudem dedizierte APIs für [presentation notes](https://docs.aspose.com/slides/de/nodejs-java/presentation-notes/) und [presentation comments](https://docs.aspose.com/slides/de/nodejs-java/presentation-comments/) bereit.

Ist das Format der Notizenseite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notiz‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows überprüfen Sie zudem die Autoren der Kommentare und verschachtelte Kommentare nach dem Kombinieren von Dateien unterschiedlicher Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst und nicht nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen beibehalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpfter Audio‑, Video‑, OLE‑Objekt‑ oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie verwandelt einen externen Link nicht in eingebetteten Inhalt. Testen Sie Pfade und URLs von verknüpften Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, das ist jedoch keine allgemeine Garantie, dass identische Binär‑Ressourcen aus unabhängigen Quell‑Präsentationen immer dedupliziert werden. Wenn die Dateigröße entscheidend ist, prüfen Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplizierung zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentations‑Ebene verwaltet. Wenn die Typografie auf verschiedenen Maschinen konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede erforderliche Schrift im Ziel‑Umfeld verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) prüfen und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](https://docs.aspose.com/slides/de/nodejs-java/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie berechtigt sind, die in den Quell‑Dateien verwendeten Schriften einzubetten. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort geben Sie über [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) an.

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Mit der entschlüsselten Präsentation arbeiten.
} finally {
    source.dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet den Schutz nicht automatisch auf die Ziel‑Präsentation an. Konfigurieren Sie den Ausgabeschutz separat, falls erforderlich.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binär‑Objekten können erheblichen Speicher beanspruchen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Manage Presentation BLOBs](https://docs.aspose.com/slides/de/nodejs-java/manage-blob/) für Strategien zum Umgang mit großen Dateien.

Für sehr große Dateien bevorzugen Sie das Laden über Dateipfade, entsorgen Sie jede Quell‑Präsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Checkpoints.

### **Threadsicherheit**

Laden, speichern oder klonen Sie eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Instanz nicht in mehreren Threads. Diese Vorgänge werden für den Mehrthread‑Einsatz nicht unterstützt. Wenn Sie unabhängige Merge‑Jobs parallelisieren müssen, verwenden Sie mehrere Einzel‑Thread‑Prozesse, jeweils mit eigenen Präsentations‑Instanzen, und folgen Sie den [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/de/nodejs-java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quell‑Präsentation bei?**

Verwenden Sie [`addClone(sourceSlide)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Ziel‑Präsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quell‑Folien einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie genau ein bekanntes Layout nutzen soll. Verwenden Sie einen Master, wenn Aspose.Slides basierend auf dem Typ oder Namen des Quell‑Layouts ein geeignetes Layout aus diesem Master auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Ziel‑Abmessungen neu gestaltet. Skalieren Sie die Quell‑Präsentation vorher, zum Beispiel mit [SlideSize.setSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP‑Präsentationen in einer Datei zusammenführen?**

Ja. Laden Sie jede Quell‑Präsentation, klonen Sie die gewünschten Folien in eine Ziel‑Präsentation und speichern Sie das Ergebnis in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach einem formatübergreifenden Merge. Siehe [Supported File Formats](https://docs.aspose.com/slides/de/nodejs-java/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Replizieren Sie die erforderlichen Abschnitte in der Ziel‑Präsentation und verwenden Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprechernotizen und Kommentare behalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die die Gestaltung des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten betreffen, überprüfen Sie das zusammengeführte Ergebnis, da diese Szenarien ebenfalls Präsentations‑Level‑Strukturen umfassen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aus jeder Quelle im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftbereitstellung. Prüfen Sie die eingebetteten Schriften im Ziel und verwalten Sie das Einbetten oder die externe Schriftverfügbarkeit explizit, wenn die Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie BLOB‑Verwaltung, wenn große Binär‑Objekte den Speicher stark belasten, bevorzugen Sie das Laden über Dateipfade, entsorgen Sie Quell‑Präsentationen sofort nach dem Merge und speichern Sie das Endergebnis nur einmal, wenn es benötigt wird.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Laden, speichern oder klonen Sie Präsentations‑Instanzen nicht in mehreren Threads. Für parallele Merge‑Jobs verwenden Sie separate ein‑Thread‑Prozesse mit unabhängigen Präsentations‑Instanzen.