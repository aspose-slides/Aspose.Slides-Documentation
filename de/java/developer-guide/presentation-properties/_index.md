---
title: Verwaltungspräsentationseigenschaften in Java
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/java/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- integrierte Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokumentmetadaten
- Metadaten bearbeiten
- Rechtschreibprüfungssprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für Java und optimieren Sie Suche, Branding und Workflow in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides‑API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/). Eine Instanz dieses Interfaces wird von der Methode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getDocumentProperties--) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" title="Hinweis" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation immer "Aspose.Slides for Java" und die Version der Bibliothek, die sie erzeugt hat, anzeigt. Jeder an `setNameOfApplication` übergebene Wert wird beim Schreiben der Präsentation verworfen.
{{% /alert %}}

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Sie müssen lediglich das Office‑Symbol anklicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** von Microsoft PowerPoint 2007 wie unten gezeigt auswählen:

|**Erweiterte Eigenschaften auswählen**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht, wie in der folgenden Abbildung dargestellt:

|**Eigenschaftsdialog**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Im obigen **Properties Dialog** sehen Sie mehrere Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** dient der Verwaltung benutzerdefinierter Eigenschaften der PowerPoint‑Dateien.

### Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Java zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Entwickler können beide Arten über die Aspose.Slides‑API zugreifen. Aspose.Slides für Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die von dem [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)‑Objekt bereitgestellte **IDocumentProperties**‑Eigenschaft nutzen, um die Dokumenteigenschaften von Präsentationsdateien wie unten beschrieben zu erhalten:

## **Zugriff auf integrierte Eigenschaften**

Diese Eigenschaften, die vom Objekt [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties) bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zeigen Sie die integrierten Eigenschaften an
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Integrierte Eigenschaften ändern**

Das Ändern der integrierten Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Attribut einen Zeichenkettenwert zuweisen und der Wert wird geändert. Im untenstehenden Beispiel zeigen wir, wie die integrierten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Java geändert werden können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Setzen Sie die integrierten Eigenschaften
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Speichern Sie Ihre Präsentation in einer Datei
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die integrierten Eigenschaften der Präsentation, wie unten dargestellt:

|**Integrierte Dokumenteigenschaften nach der Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Java erlaubt Entwicklern auch das Hinzufügen benutzerdefinierter Werte zu den Dokumenteigenschaften einer Präsentation. Das folgende Beispiel fügt drei benutzerdefinierte Eigenschaften hinzu, sucht dann den Namen an Index 2 und entfernt diese Eigenschaft, sodass die gespeicherte Präsentation nur zwei davon enthält. Benutzerdefinierte Eigenschaften werden alphabetisch indiziert, nicht in der Reihenfolge ihrer Hinzufügung.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Dokumenteigenschaften abrufen
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Benutzerdefinierte Eigenschaften hinzufügen
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Eigenschaftsnamen an bestimmtem Index abrufen
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Ausgewählte Eigenschaft entfernen
    dProps.removeCustomProperty(getPropertyName);
    
    // Präsentation speichern
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides für Java ermöglicht es Entwicklern zudem, die Werte benutzerdefinierter Eigenschaften auszulesen. Das nachfolgende Beispiel zeigt, wie alle benutzerdefinierten Eigenschaften einer Präsentation zugegriffen und geändert werden können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zugriff auf und Ändern benutzerdefinierter Eigenschaften
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Namen und Werte benutzerdefinierter Eigenschaften anzeigen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Werte benutzerdefinierter Eigenschaften ändern
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Speichern Sie Ihre Präsentation in einer Datei
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/) Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" title="Hinweis" %}}
Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Property‑Setters [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.
{{% /alert %}}

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zum Interface [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo) hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, lässt sich wie folgt implementieren:

```java
import com.aspose.slides.*;

// Informationen der Präsentation lesen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// aktuelle Eigenschaften abrufen
IDocumentProperties props = info.readDocumentProperties();

// neue Werte für Autor- und Titel-Felder setzen
props.setAuthor("New Author");
props.setTitle("New Title");

// Präsentation mit neuen Werten aktualisieren
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Eine weitere Möglichkeit besteht darin, die Eigenschaften einer bestimmten Präsentation als Vorlage zu nutzen, um Eigenschaften in anderen Präsentationen zu aktualisieren:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Eine neue Vorlage kann von Grund auf erstellt und anschließend verwendet werden, um mehrere Präsentationen zu aktualisieren:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Rechtschreibprüfungssprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (exponiert von der Klasse PortionFormat) bereit, um die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festzulegen. Die Rechtschreibprüfungssprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // ID einer Rechtschreibprüfung festlegen

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standard‑Sprache festlegen**

Dieser Java‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Fügt eine neue Rechteckform mit Text hinzu
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Prüft die Sprache des ersten Abschnitts
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides‑API arbeiten können:

[![Ansicht & Bearbeitung von PowerPoint-Metadaten](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?**

Integrierte Eigenschaften sind ein fester Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft erneut hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht erforderlich, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) und anschließend [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) zum Auslesen gespeicherter Metadaten, ohne ein [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Objekt zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/java/examine-presentation/) für ein vollständiges Berichtsexemplar und format‑spezifische Einschränkungen.