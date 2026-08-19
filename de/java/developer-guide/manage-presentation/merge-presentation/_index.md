---
title: Präsentationen in Java effizient zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in Java durch Klonen von Folien, Steuerung von Mastern und Layouts, Ändern der Foliengröße, Beibehalten von Abschnitten und den Umgang mit geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für Java verbindet Präsentationen, indem es Folien von einer [Präsentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) in eine andere klont. Die Hauptoperation ist [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), die das Format der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zielpräsentation zuweisen kann.

Dieser Artikel behandelt die häufigsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei das Quellformat beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zielpräsentation anwenden;
- Ein bestimmtes Layout aus der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑Ende‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriftarten, Passwörter, große Dateien und Multithreading‑Probleme behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt vieles von ihrem Aussehen von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/) auf eine der folgenden Arten:

- `addClone(sourceSlide)` — Beibehaltung des Layouts und Formats der Quellfolie. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — Die geklonte Folie einem bestimmten Ziel-[IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) zuordnen. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(sourceSlide, destinationLayout)` — Die geklonte Folie direkt einem bestimmten Ziel-[ILayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/) zuordnen.

Der an eine `addClone`‑Überladung übergebene Master oder Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quellpräsentation.

## **Gesamte Präsentationen zusammenführen und Quellformat beibehalten**

Die einfachste Zusammenführung kopiert jede Folie aus der Quellpräsentation in die Zielpräsentation. Dies ist die geeignete Wahl, wenn die importierten Folien ihr ursprüngliches Design, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zielpräsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn das Quellformat bewusst erhalten bleibt.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Im folgenden Beispiel werden nur ausgewählte Folien‑Indizes aus der Quellpräsentation importiert.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Validieren Sie Folien‑Indizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

Verwenden Sie die Überladung [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-), wenn importierte Folien einem Master folgen sollen, der bereits zur Zielpräsentation gehört.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides wählt unter dem angegebenen Master ein passendes Layout aus, indem es den Layout‑Typ oder Namen der Quellfolie abgleicht. Wenn kein geeignetes Layout existiert und `allowCloneMissingLayout` **true** ist, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es **false**, wird eine [PptxEditException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie **false**, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die Überladung [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es wird nicht das Layout des Quell‑Folieninhalts neu gestaltet. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalterstrukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass das geerbte Format und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, aber das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet den Inhalt nicht automatisch für die neue Leinwand neu. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktikabler Ansatz besteht darin, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.setSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesize/#setSize-float-float-int-) kann vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Das Skalieren verändert das Quell‑Präsentations‑Objekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation für weitere Vorgänge unverändert benötigen, öffnen Sie für den Merge eine separate Instanz.

## **Folien in einen Präsentations‑Abschnitt einfügen**

Die grundlegende Folien‑Klon‑Schleife reproduziert die Abschnittshierarchie der Quellpräsentation nicht. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation aus und klonen Sie Folien explizit mit [addClone(ISlide, ISection)](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, reproduzieren Sie diese Abschnitte in der Zielpräsentation und ordnen jedem Quell‑Slide den entsprechenden Zielabschnitt zu.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑Ende‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur solange geöffnet, wie sie kopiert wird, und speichert die endgültige Datei einmalig.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Dies ist ein nützliches Grundgerüst, um das Quellformat importierter Folien zu erhalten. Wenn Ihr Ergebnis ein einheitliches Ziel‑Design verwenden muss, ersetzen Sie den einfachen Aufruf `addClone(slide)` durch die zuvor gezeigte Überladung für Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Format‑Treue**

Das Standard‑Klonen von Folien kann einen erforderlichen Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um zu vermeiden, dass derselbe Master mehrfach geklont wird. Manuell geklonte Master werden von diesem Register nicht erfasst; vermeiden Sie daher ein Vor‑Klonen von Master, sofern Sie nicht explizit die Masterstruktur steuern müssen.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit demselben Namen visuell äquivalent sind. Wenn ein Unternehmens‑Template das endgültige Erscheinungsbild bestimmen muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout ausdrücklich und prüfen Sie das Ergebnis nach dem Zusammenführen.

### **Notizen und Kommentare**

Sprechernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden kopiert, wenn eine Folie geklont wird. Aspose.Slides stellt zudem spezielle APIs für [Presentation‑Notes](https://docs.aspose.com/slides/de/java/presentation-notes/) und [Presentation‑Comments](https://docs.aspose.com/slides/de/java/presentation-comments/) bereit.

Ist die Formatierung der Notiz‑Seite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notiz‑Master Objekte auf Präsentationsebene sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie außerdem die Autoren von Kommentaren und verschachtelte Kommentare nach dem Kombinieren von Dateien verschiedener Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst statt nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen beibehalten kann.

Eingebettete und verlinkte Ressourcen sollten unterschiedlich behandelt werden. Ein verlinktes Audio, Video, OLE‑Objekt oder Hyperlink bleibt abhängig von seinem externen Ziel; das Klonen einer Folie macht einen externen Link nicht zu eingebettetem Inhalt. Testen Sie Pfade und URLs verlinkter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, das bedeutet jedoch keine generelle Garantie, dass identische Binär‑Ressourcen aus unabhängigen Quellpräsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, prüfen Sie das zusammengeführte Paket und messen Sie das Ergebnis, statt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriftarten und Schriftartenverfügbarkeit**

Schriftarten werden auf Präsentationsebene verwaltet. Wenn die Typografie über verschiedene Geräte hinweg konsistent sein muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schriftart im Zielumfeld verfügbar ist. Sie können eingebettete Schriftarten mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) inspizieren und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](https://docs.aspose.com/slides/de/java/embedded-font/) beschrieben.

Prüfen Sie zudem, ob Sie das Einbetten der in den Quell‑Dateien verwendeten Schriftarten überhaupt dürfen. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort wird über [LoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) übergeben.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Arbeiten mit der entschlüsselten Präsentation.
} finally {
    source.dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet den Schutz nicht automatisch auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binär‑Objekten können erheblichen Speicher beanspruchen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateien. Siehe [Manage Presentation BLOBs](https://docs.aspose.com/slides/de/java/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien bevorzugen Sie das Laden über Dateipfade, wenn möglich, entsorgen jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Prüfstellen.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)-Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Präsentations‑Instanz auf einen Merge‑Vorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentations‑Instanzen und folgen Sie den [Aspose.Slides Multithreading‑Richtlinien](https://docs.aspose.com/slides/de/java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [`addClone(sourceSlide)`](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**

Verwenden Sie ein spezifisches Layout, wenn jede importierte Folie ein bekanntes Layout verwenden soll. Verwenden Sie einen Master, wenn Sie Aspose.Slides die Auswahl unter den Layouts dieses Masters anhand des Quell‑Layout‑Typs oder Namens überlassen möchten.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Zielabmessungen neu gestaltet. Skalieren Sie die Quellpräsentation zuerst, wenn Sie eine vorhersehbare Platzierung benötigen, beispielsweise mit [SlideSize.setSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesize/#setSize-float-float-int-) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die benötigten Folien in eine Zielpräsentation und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach einem Format‑übergreifenden Merge. Siehe [Supported File Formats](https://docs.aspose.com/slides/de/java/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Replizieren Sie die benötigten Abschnitte in der Zielpräsentation und verwenden Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die von Notiz‑Master‑Styling, Kommentar‑Autoren oder verschachtelten Review‑Daten abhängen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien ebenfalls Präsentation‑level‑Strukturen betreffen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass ihre Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriftarten aus jeder Quelle garantiert im Merge‑Dokument verfügbar?**

Verlassen Sie sich nicht allein auf das Klonen von Folien für die Schriftarten‑Bereitstellung. Inspizieren Sie die eingebetteten Schriftarten des Ziels und verwalten Sie das Einbetten bzw. die externe Verfügbarkeit von Schriftarten explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Verwenden Sie BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quellpräsentationen sofort nach dem Merge und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)-Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation auf eigene Präsentations‑Instanzen beschränkt.