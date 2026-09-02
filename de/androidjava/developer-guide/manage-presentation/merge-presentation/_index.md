---
title: Präsentationen auf Android effizient zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen auf Android durch das Klonen von Folien, das Steuern von Mastern und Layouts, das Anpassen der Foliengröße, das Beibehalten von Abschnitten und das Verarbeiten von geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides for Android via Java fügt Präsentationen zusammen, indem Folien von einer [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) in eine andere geklont werden. Der zentrale Vorgang ist [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), der die Formatierung der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zielpräsentation zuordnen kann.

Dieser Artikel behandelt die gebräuchlichsten Zusammenführungs‑Workflows:

- Alle Folien zusammenführen und dabei deren Quellformatierung beibehalten;
- Ausgewählte Folien zusammenführen;
- Einen Master der Zielpräsentation anwenden;
- Ein bestimmtes Layout der Zielpräsentation anwenden;
- Unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- Geklonte Folien zu einem Abschnitt hinzufügen;
- Mehrere Präsentationen in einem End‑zu‑Ende‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Aspekte behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie übernimmt einen Großteil ihres Aussehens von ihrem Layout und Master. Aus diesem Grund bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/) auf eine der folgenden Arten:

- `addClone(sourceSlide)` — Erhält das Layout und die Formatierung der Quellfolie. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — Ordnet die geklonte Folie einem bestimmten Ziel‑[IMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) zu. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(sourceSlide, destinationLayout)` — Ordnet die geklonte Folie direkt einem bestimmten Ziel‑[ILayoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/) zu.

Der an `addClone` übergebene Master oder das Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quellpräsentation.

## **Gesamte Präsentationen zusammenführen und Quellformatierung beibehalten**

Die einfachste Zusammenführung kopiert jede Folie der Quellpräsentation in die Zielpräsentation. Dies ist die passende Wahl, wenn die importierten Folien ihr ursprüngliches Theme, Master und Layout‑Beziehungen beibehalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zielpräsentation unterschiedliche Designs verwenden. Das ist zu erwarten, wenn die Quellformatierung bewusst erhalten bleibt.

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

Validieren Sie Folienindizes vor dem Klonen, wenn sie aus Benutzereingaben oder externen Konfigurationen stammen.

## **Folien unter Verwendung eines Ziel‑Masters zusammenführen**

Verwenden Sie die Überladung [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-), wenn importierte Folien einem Master folgen sollen, der bereits zur Zielpräsentation gehört.

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

Aspose.Slides wählt ein passendes Layout unter dem angegebenen Master aus, indem es den Layout‑Typ oder Namen der Quellfolie abgleicht. Existiert kein geeignetes Layout und `allowCloneMissingLayout` ist `true`, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist es `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn der Merge fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien unter Verwendung eines bestimmten Ziel‑Layouts zusammenführen**

Verwenden Sie die Überladung [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), wenn Sie genau wissen, welches Ziel‑Layout die importierten Folien verwenden sollen.

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

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; der Inhalt der Quellfolie wird nicht neu gestaltet. Haben Quell‑ und Ziel‑Layout unterschiedliche Platzhalter‑Strukturen, prüfen Sie das Ergebnis, um sicherzustellen, dass die vererbte Formatierung und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit unterschiedlichen Folienabmessungen können zusammengeführt werden, jedoch wird beim Klonen einer Folie in eine Präsentation mit anderer Foliengröße der Inhalt nicht automatisch für die neue Leinwand umgestaltet. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktischer Ansatz ist, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.setSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) kann vorhandenen Inhalt skalieren, während die Foliengröße geändert wird. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

Das Ändern der Größe modifiziert das Quellpräsentations‑Objekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation für weitere Vorgänge unverändert benötigen, öffnen Sie eine separate Instanz für den Merge.

## **Folien in einen Präsentations‑Abschnitt zusammenführen**

Die grundlegende Folien‑Klon‑Schleife reproduziert nicht die Abschnittshierarchie der Quellpräsentation. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation aus und klonen Sie Folien explizit mit [addClone(ISlide, ISection)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Die geklonten Folien werden an den angegebenen Ziel‑Abschnitt angehängt. Um mehrere Quell‑Abschnitte zu erhalten, enumerieren Sie [Presentation.getSections](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSections--), holen Sie die aktuellen Folien jedes Quell‑Abschnitts mit [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), erzeugen Sie die Abschnitte in der Zielpräsentation neu und klonen Sie jede zurückgegebene Folie in den entsprechenden Ziel‑Abschnitt. Siehe [Manage Slide Sections](/slides/de/androidjava/slide-section/) für ein vollständiges Beispiel zur Abschnitt‑Enumeration, inkl. leerer Abschnitte und struktureller Änderungen.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑Ende‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur so lange geöffnet, wie sie kopiert wird, und speichert die endgültige Datei einmal.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

Dies ist ein nützliches Grundgerüst, um die Quellformatierung der importierten Folien beizubehalten. Wenn Ihr Ausgabe‑Theme einheitlich sein muss, ersetzen Sie den einfachen Aufruf `addClone(slide)` durch die zuvor gezeigte overload mit Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Formattreue**

Standard‑Folienklonen kann einen erforderlichen Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein mehrfaches Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden nicht im Register erfasst, daher sollten Sie Master nicht vorab klonen, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell äquivalent sind. Wenn ein Unternehmens‑Template das endgültige Aussehen steuert, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout ausdrücklich und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Sprechernotizen und Folienkommentare sind mit dem Folieninhalt verknüpft und werden beim Klonen einer Folie kopiert. Aspose.Slides bietet zudem spezielle APIs für [presentation notes](/slides/de/androidjava/presentation-notes/) und [presentation comments](/slides/de/androidjava/presentation-comments/).

Ist die Formatierung der Notizseite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notizen‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie außerdem die Kommentar‑Autoren und verschachtelten Kommentare nach dem Zusammenführen von Dateien verschiedener Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können auf Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten verweisen. Klonen Sie die Folie selbst und nicht nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen erhalten kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpfter Audio‑, Video‑, OLE‑Eintrag oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie verwandelt keinen externen Link in eingebetteten Inhalt. Testen Sie verknüpfte Ressourcen‑Pfade und URLs in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, dies ist jedoch keine generelle Garantie, dass identische binäre Ressourcen aus unabhängigen Quell‑Präsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, prüfen Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplikation zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentations‑Ebene verwaltet. Wenn die Typografie über verschiedene Geräte hinweg konsistent bleiben muss, gehen Sie nicht davon aus, dass das reine Klonen von Folien garantiert, dass jede benötigte Schrift in der Zielumgebung verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) inspizieren und das Einbetten explizit verwalten, wie in [Embed Fonts in Presentations](/slides/de/androidjava/embedded-font/) beschrieben.

Stellen Sie zudem sicher, dass Sie das Einbetten der in den Quell‑Dateien verwendeten Schriften dürfen. Schrift‑Lizenzen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor ihre Folien geklont werden können. Geben Sie das Passwort über [LoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) an.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Mit der entschlüsselten Präsentation arbeiten.
} finally {
    source.dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet den Schutz nicht automatisch auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz separat, falls erforderlich.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen großen Binärobjekten können erheblichen Speicher beanspruchen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateien. Siehe [Manage Presentation BLOBs](/slides/de/androidjava/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien bevorzugen Sie das Laden über Dateipfade, entsorgen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, sofern der Workflow keine Checkpoints erfordert.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Präsentations‑Instanz auf einen Merge‑Vorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentations‑Instanzen und beachten Sie die [Aspose.Slides Multithreading‑Leitlinie](/slides/de/androidjava/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lassen sich importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout anstelle eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout verwenden soll. Verwenden Sie einen Master, wenn Sie Aspose.Slides erlauben möchten, basierend auf dem Layout‑Typ oder Namen der Quellfolie ein geeignetes Layout des Masters auszuwählen.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, jedoch wird der Folieninhalt nicht automatisch für die Zielabmessungen umgestaltet. Skalieren Sie die Quellpräsentation zuerst, wenn Sie eine vorhersehbare Platzierung benötigen, beispielsweise mit [SlideSize.setSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen in einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die gewünschten Folien in ein Ziel und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da Präsentations‑Formate nicht exakt denselben Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Zusammenführungen. Siehe [Supported File Formats](/slides/de/androidjava/supported-file-formats/).

**Werden Quell‑Abschnitte automatisch erhalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Reproduzieren Sie die erforderlichen Abschnitte in der Zielpräsentation und verwenden Sie die Abschnitt‑Überladung von [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), wenn die Abschnitts‑Struktur bewahrt werden muss.

**Werden Sprecher‑Notizen und Kommentare erhalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die Notizen‑Master‑Styling, Kommentar‑Autoren oder verschachtelte Review‑Daten benötigen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien sowohl Präsentations‑ als auch Folien‑Strukturen betreffen.

**Was geschieht mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aus allen Quellen im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftbereitstellung. Inspizieren Sie die eingebetteten Schriften des Ziels und verwalten Sie das Einbetten oder die externe Verfügbarkeit von Schriften explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), dann klonen Sie die Folien wie gewohnt. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie das BLOB‑Management, wenn große Binärobjekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quellpräsentationen sofort nach dem Merge und speichern Sie das Endergebnis nur bei Bedarf.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation isoliert in eigenen Präsentations‑Instanzen.