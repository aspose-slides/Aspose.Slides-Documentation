---
title: "Präsentationseigenschaften auf Android verwalten"
linktitle: "Präsentationseigenschaften"
type: docs
weight: 70
url: /de/androidjava/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Integrierte Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokument-Metadaten
- Metadaten bearbeiten
- Rechtschreibprüfungssprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Steuern Sie Präsentationseigenschaften in Aspose.Slides für Android über Java und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Integrierte** und **Benutzerdefinierte**. Beide Eigenschaftstypen können einfach über die Aspose.Slides‑API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Präsentations‑Dokumenteigenschaften über das [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties/)‑Interface. Eine Instanz dieses Interfaces wird von der Methode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Hinweis" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation stets den Produktnamen Aspose.Slides und die Versionsnummer der Bibliothek angibt, die sie erstellt hat. Jeder Wert, der an `setNameOfApplication` übergeben wird, wird beim Schreiben der Präsentation verworfen.
{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Sie müssen lediglich das Office‑Symbol anklicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007 auswählen, wie unten gezeigt:

|**Auswahl des Menüpunkts „Advanced Properties“**|** ** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| ** ** |
Nach der Auswahl des Menüpunkts **Advanced Properties** erscheint ein Dialog, in dem Sie die Dokumenteigenschaften der PowerPoint‑Datei verwalten können, wie in der nachstehenden Abbildung dargestellt:

|**Eigenschaften‑Dialog**|** ** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| ** ** |
Im obigen **Eigenschaften‑Dialog** sehen Sie mehrere Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Diese Registerkarten erlauben das Konfigurieren verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften der PowerPoint‑Dateien zu verwalten.



### Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Android über Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Android über Java zwei Arten von Dokumenteigenschaften: **Integrierte** und **Benutzerdefinierte**. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides‑API für Android über Java nutzen. Aspose.Slides für Android über Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die von **Presentation** (https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) bereitgestellte **IDocumentProperties**‑Eigenschaft verwenden, um auf die Dokumenteigenschaften von Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Zugriff auf integrierte Eigenschaften**

Diese Eigenschaften, die vom [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties)‑Objekt bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (letztes Druckdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird von mehreren Erstellern gemeinsam genutzt?), **PresentationFormat**, **Subject** und **Title**

```java
import com.aspose.slides.*;

// Instanziieren der Presentation‑Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties‑Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zeige die integrierten Eigenschaften an
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

Das Ändern integrierter Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Property einen Zeichenfolgenwert zuweisen, und der Wert wird geändert. Im untenstehenden Beispiel zeigen wir, wie die integrierten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Android über Java geändert werden können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Setze die integrierten Eigenschaften
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Speichere deine Präsentation in einer Datei
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die integrierten Eigenschaften der Präsentation, die anschließend wie folgt dargestellt werden:

|**Integrierte Dokumenteigenschaften nach der Änderung**|** ** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| ** ** |

## **Hinzufügen benutzerdefinierter Dokumenteigenschaften**

Aspose.Slides für Android über Java erlaubt Entwicklern zudem, benutzerdefinierte Werte für Dokumenteigenschaften einer Präsentation hinzuzufügen. Das nachstehende Beispiel fügt drei benutzerdefinierte Eigenschaften hinzu, sucht dann den Namen an Index 2 und entfernt diese Eigenschaft, sodass die gespeicherte Präsentation zwei verbleibende Eigenschaften enthält. Benutzerdefinierte Eigenschaften werden alphabetisch indiziert, nicht in der Reihenfolge ihrer Hinzufügung.

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
    
    // Eigenschaftsnamen an einem bestimmten Index abrufen
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Ausgewählte Eigenschaft entfernen
    dProps.removeCustomProperty(getPropertyName);
    
    // Präsentation speichern
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** ** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| ** ** |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides für Android über Java ermöglicht es Entwicklern außerdem, die Werte benutzerdefinierter Eigenschaften zu lesen. Das nachstehende Beispiel zeigt, wie Sie alle benutzerdefinierten Eigenschaften einer Präsentation zugreifen und ändern können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Auf benutzerdefinierte Eigenschaften zugreifen und sie ändern
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Namen und Werte der benutzerdefinierten Eigenschaften anzeigen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Werte der benutzerdefinierten Eigenschaften ändern
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Präsentation in einer Datei speichern
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften einer [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** ** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| ** ** |


|**Benutzerdefinierte Eigenschaften nach der Änderung**|** ** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| ** ** |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" title="Hinweis" %}}
Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Setters [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.
{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden dem Interface [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt. Sie ermöglichen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Ein typisches Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, kann wie folgt umgesetzt werden:

```java
import com.aspose.slides.*;

// Lese die Informationen der Präsentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Erhalte die aktuellen Eigenschaften
IDocumentProperties props = info.readDocumentProperties();

// Setze die neuen Werte für die Felder Autor und Titel
props.setAuthor("New Author");
props.setTitle("New Title");

// Aktualisiere die Präsentation mit neuen Werten
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

Eine neue Vorlage kann von Grund auf erstellt und anschließend zum Aktualisieren mehrerer Präsentationen verwendet werden:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Rechtschreibprüfungssprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (exponiert durch die Klasse PortionFormat) bereit, um die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festzulegen. Die Rechtschreibprüfungssprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser Java‑Code zeigt, wie die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festgelegt wird:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // setzt die Id einer Rechtschreibprüfungs­sprache

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

    // Überprüft die Sprache der ersten Portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie Dokumenteigenschaften über die Aspose.Slides‑API bearbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?**

Integrierte Eigenschaften sind ein fester Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern von der jeweiligen Eigenschaft erlaubt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft erneut hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Es ist nicht nötig, die Eigenschaft vorher zu entfernen oder zu prüfen; Aspose.Slides aktualisiert den Wert automatisch.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) und anschließend [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--), um gespeicherte Dokument‑Metadaten zu lesen, ohne ein [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Objekt zu instanziieren. Siehe [Build a Lightweight Presentation Inventory](/slides/de/androidjava/examine-presentation/) für ein komplettes Bericht‑Beispiel und format‑spezifische Einschränkungen.