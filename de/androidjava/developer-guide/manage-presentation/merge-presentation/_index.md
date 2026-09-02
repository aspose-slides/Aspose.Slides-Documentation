---
title: Effizientes Zusammenführen von Präsentationen auf Android
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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen auf Android durch das Klonen von Folien, die Steuerung von Mastern und Layouts, das Ändern der Foliengröße, das Beibehalten von Abschnitten und das Verwalten von geschützten oder großen Dateien zusammenführen."
---
## **Übersicht**

Aspose.Slides für Android via Java fügt Präsentationen zusammen, indem Folien von einer [Präsentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) in eine andere geklont werden. Die Hauptoperation ist [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), die entweder das Format der Quellfolie beibehalten oder die geklonte Folie einem Master oder Layout in der Zielpräsentation zuweisen kann.

Dieser Artikel behandelt die gängigsten Zusammenführungs‑Workflows:

- alle Folien zusammenführen und dabei das Quellformat beibehalten;
- ausgewählte Folien zusammenführen;
- einen Master aus der Zielpräsentation anwenden;
- ein bestimmtes Layout aus der Zielpräsentation anwenden;
- unterschiedliche Foliengrößen vor dem Zusammenführen normalisieren;
- geklonte Folien zu einem Abschnitt hinzufügen;
- mehrere Präsentationen in einem End‑zu‑End‑Workflow zusammenführen;
- Master, Ressourcen, Notizen, Kommentare, Medien, Schriften, Passwörter, große Dateien und Multithreading‑Aspekte behandeln.

## **Wie das Klonen von Folien Master und Layouts beeinflusst**

Eine Folie erbt einen Großteil ihres Erscheinungsbildes von ihrem Layout und Master. Daher bestimmt die von Ihnen gewählte Überladung des Klonens, wie die zusammengeführte Folie in die Zielpräsentation integriert wird.

Verwenden Sie [ISlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/) auf eine der folgenden Arten:

- `addClone(sourceSlide)` — das Layout und Format der Quellfolie beibehalten. Bei Bedarf kann der Quell‑Master automatisch in die Zielpräsentation geklont werden. Aspose.Slides verfolgt automatisch geklonte Master, sodass wiederholte Folien, die denselben Quell‑Master verwenden, diesen nicht mehrfach klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — die geklonte Folie einem bestimmten Ziel‑[IMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) zuweisen. Aspose.Slides sucht unter diesem Master nach einem passenden Layout anhand des Layout‑Typs oder Namens.
- `addClone(sourceSlide, destinationLayout)` — die geklonte Folie direkt einem bestimmten Ziel‑[ILayoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/) zuweisen.

Der an eine `addClone`‑Überladung übergebene Master oder Layout muss zur **Ziel**‑Präsentation gehören, nicht zur Quellpräsentation.

## **Gesamte Präsentationen zusammenführen und Quellformat beibehalten**

Die einfachste Zusammenführung kopiert jede Folie der Quellpräsentation in die Zielpräsentation. Dies ist die richtige Wahl, wenn importierte Folien ihr ursprüngliches Design, ihren Master und ihre Layout‑Beziehungen behalten sollen.

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

Die resultierende Präsentation kann mehrere Master enthalten, wenn Quell‑ und Zielpräsentation unterschiedliche Designs verwenden. Dies ist zu erwarten, wenn das Quellformat bewusst beibehalten wird.

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

Validieren Sie Folienindizes vor dem Klonen, wenn sie von Benutzereingaben oder externer Konfiguration stammen.

## **Folien mit einem Ziel‑Master zusammenführen**

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

Aspose.Slides wählt unter dem angegebenen Master ein passendes Layout aus, indem es den Typ oder Namen des Quell‑Layouts vergleicht. Existiert kein geeignetes Layout und `allowCloneMissingLayout` ist `true`, wird das Quell‑Layout geklont, sodass die Folie hinzugefügt werden kann. Ist der Wert `false`, wird eine [PptxEditException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxeditexception/) ausgelöst.

Verwenden Sie `false`, wenn der Merge‑Vorgang fehlschlagen soll, anstatt ein zusätzliches Layout in den Ziel‑Master einzufügen.

## **Folien mit einem bestimmten Ziel‑Layout zusammenführen**

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

Das Anwenden eines Ziel‑Layouts ändert die geerbte Layout‑Beziehung; es gestaltet den Inhalt der Quellfolie nicht um. Wenn Quell‑ und Ziel‑Layouts unterschiedliche Platzhalter‑Strukturen aufweisen, prüfen Sie das Ergebnis, um sicherzustellen, dass das vererbte Format und das Platzhalter‑Verhalten passend sind.

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

Präsentationen mit verschiedenen Folienmaßen können zusammengeführt werden, jedoch gestaltet das Klonen einer Folie in eine Präsentation mit anderer Foliengröße deren Inhalt nicht automatisch für die neue Leinwand neu. Formen können daher verschoben, unerwartet skaliert oder außerhalb des sichtbaren Folienbereichs erscheinen.

Ein praktikabler Ansatz ist, die Quellpräsentation vor dem Klonen zu skalieren. Die Methode [SlideSize.setSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) kann vorhandenen Inhalt skalieren, während die Folienabmessungen geändert werden. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesizescaletype/) skaliert den Inhalt, sodass er in die gewünschte Größe passt.

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

Das Skalieren ändert das Quellpräsentations‑Objekt im Speicher. Wenn Sie die ursprüngliche Quellpräsentation für andere Vorgänge unverändert benötigen, öffnen Sie eine separate Instanz für den Merge.

## **Folien in einen Präsentationsabschnitt einfügen**

Die grundlegende Schleife zum Klonen von Folien recreiert die Abschnittshierarchie der Quellpräsentation nicht. Wenn Abschnitte im Ergebnis wichtig sind, erstellen oder wählen Sie Abschnitte in der Zielpräsentation aus und klonen Sie Folien explizit mit [addClone(ISlide, ISection)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Die geklonten Folien werden an den angegebenen Zielabschnitt angehängt. Um mehrere Quellabschnitte zu erhalten, reproduzieren Sie diese Abschnitte in der Zielpräsentation und ordnen jede Quellfolie dem entsprechenden Zielabschnitt zu.

## **Mehrere Präsentationen sicher zusammenführen**

Das folgende End‑zu‑End‑Beispiel verwendet die erste Präsentation als Ziel, normalisiert die Foliengröße jeder zusätzlichen Quelle, hält jede Quelle nur offen, solange sie kopiert wird, und speichert die endgültige Datei einmalig.

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

Dies ist ein nützlicher Ausgangspunkt, um das Quellformat importierter Folien zu bewahren. Wenn Ihr Ergebnis ein einheitliches Ziel‑Theme verwenden muss, ersetzen Sie den einfachen Aufruf `addClone(slide)` durch die zuvor gezeigte Überladung für Ziel‑Master oder Ziel‑Layout.

## **Praktische Überlegungen**

### **Master, Layouts und Format‑Treue**

Das Standard‑Klonen von Folien kann einen erforderlichen Quell‑Master automatisch in die Zielpräsentation übernehmen. Aspose.Slides führt ein internes Register für automatisch geklonte Master, um ein mehrfaches Klonen desselben Masters zu vermeiden. Manuell geklonte Master werden von diesem Register nicht erfasst, vermeiden Sie also das Vor‑Klonen von Mastern, es sei denn, Sie benötigen explizite Kontrolle über die Master‑Struktur.

Gehen Sie nicht davon aus, dass zwei Master oder Layouts mit gleichem Namen visuell äquivalent sind. Wenn ein Corporate‑Template das endgültige Aussehen steuern muss, wählen Sie einen Ziel‑Master oder ein Ziel‑Layout ausdrücklich und prüfen Sie das Ergebnis nach dem Merge.

### **Notizen und Kommentare**

Sprecher‑Notizen und Folien‑Kommentare sind mit dem Folieninhalt verknüpft und werden mitgeklont. Aspose.Slides bietet zudem dedizierte APIs für [Präsentations‑Notizen](https://docs.aspose.com/slides/de/androidjava/presentation-notes/) und [Präsentations‑Kommentare](https://docs.aspose.com/slides/de/androidjava/presentation-comments/).

Ist das Format der Notiz‑Seite wichtig, prüfen Sie die zusammengeführte Präsentation, da Notiz‑Master Präsentations‑Objekte sind und zwischen Quell‑Dateien variieren können. Für Review‑Workflows prüfen Sie auch Kommentar‑Autoren und verschachtelte Kommentare nach dem Kombinieren von Dateien unterschiedlicher Autoren oder Templates.

### **Bilder, Audio, Video, OLE‑Objekte und externe Links**

Folien können Präsentations‑Ressourcen wie Bilder, eingebettetes Audio, eingebettetes Video und OLE‑Daten referenzieren. Klonen Sie die Folie selbst statt nur die sichtbaren Formen, damit Aspose.Slides die Beziehungen der Folie zu ihren Ressourcen bewahren kann.

Eingebettete und verknüpfte Ressourcen sollten unterschiedlich behandelt werden. Ein verknüpftes Audio, Video, OLE‑Objekt oder Hyperlink bleibt von seinem externen Ziel abhängig; das Klonen einer Folie verwandelt keinen externen Link in eingebetteten Inhalt. Testen Sie Pfade und URLs von verknüpften Ressourcen in der Umgebung, in der die zusammengeführte Präsentation geöffnet wird.

Aspose.Slides verfolgt automatisch geklonte Master, dies ist jedoch keine allgemeine Garantie, dass identische Binär‑Ressourcen aus unabhängigen Quell‑Präsentationen immer dedupliziert werden. Wenn die Dateigröße wichtig ist, inspizieren Sie das zusammengeführte Paket und messen Sie das Ergebnis, anstatt sich auf implizite Deduplizierung zu verlassen.

### **Eingebettete Schriften und Schriftverfügbarkeit**

Schriften werden auf Präsentations‑Ebene verwaltet. Wenn Typografie über verschiedene Rechner hinweg konsistent bleiben muss, gehen Sie nicht davon aus, dass das Klonen von Folien allein garantiert, dass jede erforderliche Schrift im Zielumfeld verfügbar ist. Sie können eingebettete Schriften mit [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) prüfen und das Einbetten explizit verwalten, wie in [Schriften in Präsentationen einbetten](https://docs.aspose.com/slides/de/androidjava/embedded-font/) beschrieben.

Stellen Sie außerdem sicher, dass Sie die Erlaubnis haben, die in den Quell‑Dateien verwendeten Schriften einzubetten. Lizenzbedingungen können das Einbetten einschränken.

### **Passwortgeschützte Präsentationen**

Eine passwortgeschützte Quelle muss erfolgreich geöffnet werden, bevor deren Folien geklont werden können. Übergeben Sie das Passwort mittels [LoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Arbeit mit der entschlüsselten Präsentation.
} finally {
    source.dispose();
}
```

Das Öffnen einer verschlüsselten Quelle wendet den Schutz nicht automatisch auf die Zielpräsentation an. Konfigurieren Sie den Ausgabeschutz bei Bedarf separat.

### **Große Präsentationen und Speicherverbrauch**

Große Präsentationen mit hochauflösenden Bildern, Audio, Video oder anderen umfangreichen Binär‑Objekten können erheblichen Speicher beanspruchen. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) bietet Steuerungen für BLOB‑Verarbeitung und temporäre Dateien. Siehe [Präsentations‑BLOBs verwalten](https://docs.aspose.com/slides/de/androidjava/manage-blob/) für Strategien bei großen Dateien.

Bei großen Dateien bevorzugen Sie das Laden über Dateipfade, entsorgen Sie jede Quellpräsentation, sobald sie zusammengeführt wurde, und vermeiden Sie wiederholtes Speichern von Zwischenergebnissen, es sei denn, der Workflow erfordert Prüfstellen.

### **Thread‑Sicherheit**

Laden, ändern, speichern oder klonen Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)-Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Präsentationsinstanz auf einen Merge‑Vorgang beschränkt. Wenn Sie unabhängige Jobs parallelisieren, verwenden Sie unabhängige Präsentationsinstanzen und befolgen Sie die [Aspose.Slides Multithreading‑Richtlinien](https://docs.aspose.com/slides/de/androidjava/multithreading/).

## **FAQ**

**Wie behalte ich das ursprüngliche Design jeder Quellpräsentation bei?**

Verwenden Sie [`addClone(sourceSlide)`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ohne Angabe eines Ziel‑Masters oder -Layouts. Aspose.Slides kann den Quell‑Master automatisch klonen, wenn er von der importierten Folie benötigt wird.

**Wie lasse ich importierte Folien das Ziel‑Theme verwenden?**

Verwenden Sie die Überladung, die einen Ziel‑Master akzeptiert. Übergeben Sie einen Master aus der Zielpräsentation, nicht aus der Quelle. Aspose.Slides versucht, jede Quellfolie einem passenden Layout unter diesem Master zuzuordnen.

**Wann sollte ich ein bestimmtes Ziel‑Layout statt eines Ziel‑Masters verwenden?**

Verwenden Sie ein bestimmtes Layout, wenn jede importierte Folie ein bekanntes Layout verwenden soll. Verwenden Sie einen Master, wenn Aspose.Slides die passende Layout‑Auswahl innerhalb dieses Masters basierend auf Typ oder Namen des Quell‑Layouts treffen soll.

**Können Präsentationen mit unterschiedlichen Foliengrößen zusammengeführt werden?**

Ja, aber der Folieninhalt wird nicht automatisch für die Ziel­dimensionen neu gestaltet. Skalieren Sie die Quellpräsentation zuerst, wenn Sie vorhersehbare Platzierungen benötigen, zum Beispiel mit [SlideSize.setSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) und [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesizescaletype/).

**Kann ich PPT, PPTX und ODP Präsentationen zu einer Datei zusammenführen?**

Ja. Laden Sie jede Quellpräsentation, klonen Sie die erforderlichen Folien in eine Zielpräsentation und speichern Sie das Ziel in einem unterstützten Ausgabeformat. Da die Formate nicht exakt den gleichen Funktionsumfang bieten, prüfen Sie komplexe Inhalte nach formatübergreifenden Merges. Siehe [Unterstützte Dateiformate](https://docs.aspose.com/slides/de/androidjava/supported-file-formats/).

**Werden Quellabschnitte automatisch beibehalten?**

Nicht durch eine einfache Schleife, die nur Folien klont. Reproduzieren Sie die benötigten Abschnitte in der Zielpräsentation und verwenden Sie die Abschnitts‑Überladung von [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), wenn die Abschnitts‑Struktur erhalten bleiben muss.

**Werden Sprecher‑Notizen und Kommentare beibehalten?**

Sie werden zusammen mit der geklonten Folie kopiert. Für Workflows, die das Styling des Notiz‑Masters, Kommentar‑Autoren oder verschachtelte Review‑Daten benötigen, prüfen Sie das zusammengeführte Ergebnis, da diese Szenarien ebenfalls Präsentations‑Ebene‑Strukturen betreffen.

**Was passiert mit Audio, Video, OLE‑Objekten und Hyperlinks?**

Eingebettete Inhalte werden als Teil der Ressourcen‑Beziehungen der geklonten Folie übernommen. Externe Links bleiben extern, sodass deren Ziel‑Dateien oder URLs nach dem Merge weiterhin verfügbar sein müssen.

**Sind eingebettete Schriften aus allen Quellen im zusammengeführten Dokument garantiert verfügbar?**

Verlassen Sie sich nicht ausschließlich auf das Klonen von Folien für die Schriftbereitstellung. Prüfen Sie die eingebetteten Schriften der Zielpräsentation und verwalten Sie das Einbetten oder die externe Verfügbarkeit von Schriften explizit, wenn Typografie wichtig ist.

**Wie merge ich eine passwortgeschützte Datei?**

Öffnen Sie sie mit dem korrekten [LoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), dann klonen Sie ihre Folien wie üblich. Der Ausgabeschutz wird separat konfiguriert.

**Wie gehe ich mit sehr großen Präsentationen um?**

Nutzen Sie das BLOB‑Management, wenn große Binär‑Objekte den Speicherverbrauch dominieren, bevorzugen Sie das Laden über Dateipfade für sehr große Dateien, entsorgen Sie Quellpräsentationen sofort nach dem Merge und speichern Sie das Endergebnis nur, wenn es benötigt wird.

**Kann ich Folien aus mehreren Threads zusammenführen?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)-Instanz gleichzeitig aus mehreren Threads. Halten Sie jede Merge‑Operation auf eigene Präsentationsinstanzen beschränkt.