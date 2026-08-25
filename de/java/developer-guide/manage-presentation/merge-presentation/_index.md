---
title: Effizientes Zusammenführen von Präsentationen in Java
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
description: "Erfahren Sie, wie Sie PowerPoint‑ und OpenDocument‑Präsentationen in Java zusammenführen, indem Sie Folien klonen, Master und Layouts steuern, Folieninhalte skalieren, Abschnitte erhalten und geschützte oder große Dateien behandeln."
---
## **Übersicht**

Aspose.Slides für Java fügt Präsentationen zusammen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) in eine andere geklont werden. Die Hauptoperation ist [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), die die Formatierung der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zieldatei zuweisen kann.

Dieser Artikel behandelt die gebräuchlichsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei deren Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master aus der Zieldatei anwenden;
- Ein bestimmtes Layout aus der Zieldatei anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Aspekte behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen Großteil ihres Aussehens von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Klon‑Überladung, wie die zusammengeführte Folie in die Zieldatei integriert wird.

Verwenden Sie [ISlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/) auf eine der folgenden Arten:

- `addClone(sourceSlide)` — bewahrt das Layout und die Formatierung der Quellfolie. Bei Bedarf kann der Quell‑Master automatisch in die Zieldatei geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — fügt die geklonte Folie einem bestimmten Ziel-[IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/). Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(sourceSlide, destinationLayout)` — fügt die geklonte Folie direkt einem bestimmten Ziel-[ILayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/) zu.

Der Master oder das Layout, das an eine `addClone`‑Überladung übergeben wird, muss zur **Ziel**‑Präsentation gehören, nicht zur Quellpräsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie der Quellpräsentation in die Zielpräsentation. Dies ist die geeignete Wahl, wenn die importierten Folien ihr ursprüngliches Thema, ihren Master und ihre Layout‑Beziehungen beibehalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zielpräsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst beibehalten wird.

## **Ausgewählte Folien zusammenführen**

Sie müssen nicht jede Folie klonen. Das folgende Beispiel importiert nur ausgewählte Folienindizes aus der Quellpräsentation.

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

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

Verwenden Sie die [addClone(ISlide,IMasterSlide,boolean)](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Überladung, wenn importierte Folien einem Master folgen sollen, der bereits zur Zielpräsentation gehört.

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

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master aus, indem es den Layout‑Typ oder Namen der Quellfolie vergleicht. Wenn kein geeignetes Layout existiert und `allowCloneMissingLayout` **true** ist, wird das Quell‑Layout geklont, damit die Folie hinzugefügt werden kann. Ist es **false**, wird eine [PptxEditException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie **false**, wenn die Zusammenführung fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

Verwenden Sie die [addClone(ISlide,ILayoutSlide)](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)‑Überladung, wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

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

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht neu. Wenn Quell‑ und Ziel‑Layouts unterschiedliche Platzhalter‑Strukturen haben, prüfen Sie das Ergebnis, um sicherzustellen, dass die geerbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, aber das Klonen einer Folie in eine Präsentation mit anderer Foliengröße gestaltet ihren Inhalt nicht automatisch für die neue Leinwand neu. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktischer Ansatz besteht darin, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.setSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesize/#setSize-float-float-int-) kann vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

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

Das Skalieren ändert das Quellpräsentations‑Objekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation für weitere Vorgänge unverändert benötigen, öffnen Sie eine separate Instanz für die Zusammenführung.

## **Folien in einen Präsentationsabschnitt einfügen**

Die grundlegende Folien‑Klon‑Schleife reproduziert die Abschnittshierarchie der Quellpräsentation nicht. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation und klonen Sie Folien explizit mit [addClone(ISlide,ISection)](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, enumerieren Sie [Presentation.getSections](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSections--), holen Sie die aktuellen Folien jedes Quellabschnitts mit [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/de/java/com.aspose.slides/isection/#getSlidesListOfSection--), erstellen Sie die Abschnitte im Ziel neu und klonen jede zurückgegebene Folie in den entsprechenden Zielabschnitt. Siehe [Manage Slide Sections](/slides/de/java/slide-section/) für ein vollständiges Beispiel zur Abschnitt‑Enumeration, inklusive leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur geöffnet, solange sie kopiert wird, und speichert die endgültige Datei einmalig.

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

Dies ist ein nützliches Baseline‑Beispiel, um die Quellformatierung importierter Folien zu erhalten. Wenn Ihr Ergebnis ein einheitliches Ziel‑Thema verwenden muss, ersetzen Sie den einfachen `addClone(slide)`‑Aufruf durch die zuvor gezeigte Ziel‑Master‑ oder Ziel‑Layout‑Überladung.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Standard‑Folienklonen kann einen benötigten Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um zu vermeiden, dass derselbe Master mehrfach geklont wird. Manuell geklonte Master werden von diesem Register nicht verfolgt, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell identisch sind. Wenn eine Unternehmens‑Template das finale Erscheinungsbild bestimmen muss, wählen Sie einen Ziel‑Master oder -Layout explizit und prüfen Sie das Ergebnis nach der Zusammenführung.

### **Notizen und Kommentare**

Sprecher‑Notizen und Folien‑Kommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie mitkopiert. Aspose.Slides bietet zudem eigene APIs für [presentation notes](/slides/de/java/presentation-notes/) und [presentation comments](/slides/de/java/presentation-comments/).

Ist die Formatierung der Notizenseite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notiz‑Master auf Präsentationsebene liegen und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie auch die Kommentar‑Autoren und verschachtelten Kommentare nach dem Kombinieren von Dateien unterschiedlicher Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf präsentationsweite Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst und nicht nur ihre sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpfter Audio‑, Video‑, OLE‑Objekt‑ oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie wandelt einen externen Link nicht in eingebetteten Inhalt um. Testen Sie Pfade und URLs verknüpfter Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, dies sollte jedoch nicht als allgemeine Garantie verstanden werden, dass identische Binär‑Ressourcen aus unabhängigen Quellpräsentationen stets dedupliziert werden. Wenn die Dateigröße wichtig ist, prüfen Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentationsebene verwaltet. Wenn die Typografie über verschiedene Rechner hinweg konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schrift im Zielumfeld verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) inspizieren und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/java/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie das Recht haben, die in den Quell‑Dateien verwendeten Schriften einzubetten. Schriftlizenzen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Das Passwort übergeben Sie mittels [LoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Arbeiten Sie mit der entschlüsselten Präsentation.
} finally {
    source.dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet nicht automatisch denselben Schutz auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binärobjekten können erheblichen Speicher beanspruchen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateinutzung. Siehe [Manage Presentation BLOBs](/slides/de/java/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien laden Sie nach Möglichkeit über Dateipfade, entsorgen jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Checkpoints.

### **Thread‑Sicherheit**

Laden, verändern, speichern oder klonen Sie dieselbe [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz nicht gleichzeitig aus mehreren Threads. Halten Sie jede Präsentationsinstanz auf einen Zusammenführungsvorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie separate Präsentationsinstanzen und folgen Sie der [Aspose.Slides Multithreading‑Leitlinie](/slides/de/java/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Design verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie exakt dasselbe bekannte Layout nutzen soll. Verwenden Sie einen Master, wenn Aspose.Slides anhand des Layout‑Typs oder Namens der Quellfolie ein passendes Layout aus dem Master auswählen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Zielabmessungen neu gestaltet. Skalieren Sie die Quellpräsentation zuerst, zum Beispiel mit [SlideSize.setSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesize/#setSize-float-float-int-) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesizescaletype/).

**Kann ich PPT-, PPTX‑ und ODP‑Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die gewünschten Folien in eine Zielpräsentation und speichern Sie das Ergebnis in einem unterstützten Ausgabeformat. Da die Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexen Inhalt nach cross‑formatigen Zusammenführungen. Siehe [Supported File Formats](/slides/de/java/supported-file-formats/).

**Werden Quellabschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Rekonstruieren Sie die erforderlichen Abschnitte in der Zielpräsentation und nutzen Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), wenn die Abschnittsstruktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notizen‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten erfordern, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien ebenfalls Präsentation‑ebene Strukturen betreffen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass ihre Ziel‑Dateien oder URLs nach der Zusammenführung weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aus allen Quellen in der zusammengeführten Präsentation garantiert verfügbar?**

Verlassen Sie sich nicht allein auf das Klonen von Folien für die Schriftverteilung. Inspizieren Sie die eingebetteten Schriften der Zielpräsentation und verwalten Sie das Einbetten bzw. die Verfügbarkeit externer Schriften explizit, wenn Typografie wichtig ist.

**Wie füge ich eine passwortgeschützte Datei zusammen?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie BLOB‑Management, laden Sie nach Möglichkeit über Dateipfade, entsorgen Sie Quellpräsentationen sofort nach dem Kopieren und speichern Sie das Endergebnis nur einmal, wenn es nötig ist.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Zusammenführung auf eigene Präsentationsinstanzen beschränkt.