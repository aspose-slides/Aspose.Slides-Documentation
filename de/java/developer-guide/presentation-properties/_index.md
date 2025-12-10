---
title: Präsentationseigenschaften in Java verwalten
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/java/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eingebaute Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokument-Metadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Meistern Sie die Präsentationseigenschaften in Aspose.Slides für Java und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint bietet eine Funktion, mit der Eigenschaftendaten zu den Präsentationsdateien hinzugefügt werden können. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften, wie folgt

- Systemdefinierte (eingebaute) Eigenschaften
- Benutzerdefinierte (eigene) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Namen des Autors, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften sind diejenigen, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Java können Entwickler auf die Werte eingebauter Eigenschaften sowie benutzerdefinierter Eigenschaften zugreifen und sie ändern.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Sie müssen lediglich das Office‑Symbol anklicken und anschließend den Menüeintrag **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007 auswählen, wie unten dargestellt:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** setzen können, da Aspose Ltd. und Aspose.Slides für Java x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 

|**Auswahl des Menüeintrags Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nachdem Sie den Menüeintrag **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der es Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint‑Datei zu verwalten, wie in der nachstehenden Abbildung dargestellt:

|**Eigenschaften‑Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im oben gezeigten **Properties Dialog** können Sie sehen, dass es mehrere Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom** gibt. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Arten von Informationen zu PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Java
Als bereits beschrieben unterstützt Aspose.Slides für Java zwei Arten von Dokumenteigenschaften, nämlich **Built-in** und **Custom** Eigenschaften. Entwickler können somit beide Arten von Eigenschaften über die Aspose.Slides für Java‑API nutzen. Aspose.Slides für Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die über das Objekt [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) bereitgestellte Eigenschaft **IDocumentProperties** verwenden, um auf die Dokumenteigenschaften von Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Zugriff auf eingebaute Eigenschaften**

Diese Eigenschaften, die vom Objekt [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**  
```java
// Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Presentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Anzeige der eingebauten Eigenschaften
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


## **Eingebaute Eigenschaften ändern**

Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenfolgenwert einer gewünschten Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel haben wir gezeigt, wie die eingebauten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Java geändert werden können.  
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Setze die eingebauten Eigenschaften
    dp.setAuthor("Aspose.Slides for Java");
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


Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, die unten dargestellt werden:

|**Eingebaute Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Java ermöglicht es Entwicklern außerdem, benutzerdefinierte Werte für die Dokumenteigenschaften einer Präsentation hinzuzufügen. Das nachstehende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.  
```java
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


|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf benutzerdefinierte Eigenschaften und deren Änderung**

Aspose.Slides für Java ermöglicht es Entwicklern auch, auf die Werte benutzerdefinierter Eigenschaften zuzugreifen. Das nachstehende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.  
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum DocumentProperties-Objekt, das mit der Presentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zugriff auf benutzerdefinierte Eigenschaften und deren Änderung
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Namen und Werte benutzerdefinierter Eigenschaften anzeigen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Werte benutzerdefinierter Eigenschaften ändern
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Präsentation in einer Datei speichern
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX ](https://docs.fileformat.com/presentation/pptx/)Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="primary" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Property‑Setters [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zur [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo)‑Schnittstelle hinzugefügt. Sie bieten schnellen Zugriff auf Dokumenteigenschaften und ermöglichen das Ändern und Aktualisieren von Eigenschaften, ohne eine gesamte Präsentation zu laden.

Das typische Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, kann wie folgt umgesetzt werden:  
```java
// Informationen der Präsentation lesen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// aktuelle Eigenschaften abrufen
IDocumentProperties props = info.readDocumentProperties();

// neue Werte für Autor- und Titelfelder setzen
props.setAuthor("New Author");
props.setTitle("New Title");

// Präsentation mit neuen Werten aktualisieren
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Eine weitere Möglichkeit besteht darin, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um Eigenschaften in anderen Präsentationen zu aktualisieren:  
```java
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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


Eine neue Vorlage kann von Grund auf erstellt und anschließend verwendet werden, um mehrere Präsentationen zu aktualisieren:  
```java
DocumentProperties template = new DocumentProperties();\

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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Rechtschreibsprache festlegen**

Aspose.Slides stellt die Property LanguageId (exponiert durch die Klasse PortionFormat) bereit, mit der Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen können. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser Java‑Code zeigt, wie die Korrektursprache für ein PowerPoint festgelegt wird: xxx Warum fehlt LanguageId in der Java‑Klasse PortionFormat?  
```java
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

    portionFormat.setLanguageId("zh-CN"); // setzt die Id einer Korrektursprache

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Standardsprache festlegen**

Dieser Java‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:  
```java
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

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder, sofern von der jeweiligen Eigenschaft erlaubt, sie auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden?**

Ja, Sie können auf Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden, indem Sie die Methode `getPresentationInfo` aus der Klasse [PresentationFactory](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `readDocumentProperties` der Schnittstelle [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/), um die Eigenschaften effizient zu lesen, wodurch Speicher gespart und die Leistung verbessert wird.