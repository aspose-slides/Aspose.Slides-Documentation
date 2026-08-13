---
title: "Verwalten von Präsentationseigenschaften in Java"
linktitle: "Präsentationseigenschaften"
type: docs
weight: 70
url: /de/java/presentation-properties/
keywords:
- "PowerPoint-Eigenschaften"
- "Präsentationseigenschaften"
- "Dokumenteigenschaften"
- "Integrierte Eigenschaften"
- "Benutzerdefinierte Eigenschaften"
- "Erweiterte Eigenschaften"
- "Eigenschaften verwalten"
- "Eigenschaften ändern"
- "Dokumenten-Metadaten"
- "Metadaten bearbeiten"
- "Korrektursprache"
- "Standardsprache"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Java"
- "Aspose.Slides"
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für Java und optimieren Sie Suche, Markenauftritt und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht das Arbeiten mit Dokumenteigenschaften von Präsentationen über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/) . Eine Instanz dieses Interfaces wird von der Methode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getDocumentProperties--) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" %}} 

Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation immer „Aspose.Slides for Java“ und die Versionsnummer der verwendeten Bibliothek angibt. Jeder Wert, der an `setNameOfApplication` übergeben wird, wird beim Schreiben der Präsentation verworfen.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist das Office‑Symbol zu klicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007 auszuwählen, wie unten dargestellt:

|**Auswahl des Menüpunktes „Advanced Properties“**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, in dem Sie die Dokumenteigenschaften der PowerPoint‑Datei verwalten können, wie in der nachstehenden Abbildung gezeigt:

|**Eigenschaften‑Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Im obigen **Eigenschaften‑Dialog** sehen Sie mehrere Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten erlauben das Konfigurieren verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften der PowerPoint‑Dateien zu verwalten.

### Arbeiten mit Dokumenteigenschaften mithilfe von Aspose.Slides für Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Java zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides‑API nutzen. Aspose.Slides für Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die **IDocumentProperties**‑Eigenschaft, die vom Objekt [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation) bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften von Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Zugriff auf integrierte Eigenschaften**

Zu den über das Objekt [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties) exponierten integrierten Eigenschaften gehören: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (Wird zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Presentation verknüpft ist
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

## **Ändern integrierter Eigenschaften**

Das Ändern integrierter Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel zeigen wir, wie integrierte Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Java geändert werden können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Presentation verknüpft ist
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

|**Integrierte Dokumenteigenschaften nach Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Hinzufügen benutzerdefinierter Dokumenteigenschaften**

Aspose.Slides für Java ermöglicht Entwicklern auch das Hinzufügen benutzerdefinierter Werte für Dokumenteigenschaften einer Präsentation. Das nachstehende Beispiel fügt drei benutzerdefinierte Eigenschaften hinzu, sucht anschließend den Namen an Index 2 und entfernt diese Eigenschaft, sodass die gespeicherte Präsentation zwei davon behält. Benutzerdefinierte Eigenschaften werden alphabetisch sortiert, nicht in der Reihenfolge ihrer Erstellung.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Abrufen von Dokumenteigenschaften
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Hinzufügen benutzerdefinierter Eigenschaften
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Abrufen des Eigenschaftsnames an einem bestimmten Index
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Entfernen der ausgewählten Eigenschaft
    dProps.removeCustomProperty(getPropertyName);
    
    // Speichern der Präsentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides für Java erlaubt Entwicklern auch den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Das nachstehende Beispiel zeigt, wie Sie alle benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz auf das DocumentProperties-Objekt, das mit der Presentation verknüpft ist
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

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Setters der Eigenschaft [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zur Schnittstelle [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo) hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Ein typisches Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, lässt sich wie folgt implementieren:

```java
import com.aspose.slides.*;

// Informationen zur Präsentation lesen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// aktuelle Eigenschaften erhalten
IDocumentProperties props = info.readDocumentProperties();

// neue Werte für Autor- und Titel‑Felder setzen
props.setAuthor("New Author");
props.setTitle("New Title");

// Präsentation mit neuen Werten aktualisieren
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Eine weitere Möglichkeit besteht darin, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um Eigenschaften in anderen Präsentationen zu aktualisieren:

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

Eine neue Vorlage kann von Grund auf erstellt und dann verwendet werden, um mehrere Präsentationen zu aktualisieren:

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

## **Korrektursprache festlegen**

Aspose.Slides bietet die Eigenschaft LanguageId (exponiert durch die Klasse PortionFormat), mit der Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen können. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik im PowerPoint überprüft werden.

Dieser Java‑Code zeigt, wie Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen:

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

    portionFormat.setLanguageId("zh-CN"); // die ID einer Korrektursprache festlegen

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standardsprache festlegen**

Dieser Java‑Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen:

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

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## ***FAQ**

### Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?

Integrierte Eigenschaften sind ein fester Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern von der jeweiligen Eigenschaft zulässig, auf einen leeren Wert setzen.

### Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

### Kann ich Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden?

Ja, Sie können Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `getPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `readDocumentProperties` der Schnittstelle [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/), um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu steigern.