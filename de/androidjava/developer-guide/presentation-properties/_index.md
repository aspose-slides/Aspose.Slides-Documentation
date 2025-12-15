---
title: Präsentationseigenschaften auf Android verwalten
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Meistern Sie Präsentationseigenschaften in Aspose.Slides für Android via Java und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint bietet eine Funktion zum Hinzufügen von Eigenschaften zu Präsentationsdateien. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (eingebaute) Eigenschaften
- Benutzerdefinierte (eigene) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen zum Dokument, wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften werden von den Benutzern als **Name/Wert**‑Paare definiert, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Android via Java können Entwickler auf die Werte eingebauter Eigenschaften sowie benutzerdefinierter Eigenschaften zugreifen und sie ändern.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist das Office‑Symbol zu klicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007 auszuwählen, wie unten gezeigt:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides für Android via Java x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 

|**Advanced‑Eigenschaften‑Menü auswählen**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der Ihnen die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht, wie in der Abbildung unten gezeigt:

|**Eigenschaften‑Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Im obigen **Eigenschaften‑Dialog** sehen Sie viele Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten erlauben die Konfiguration verschiedener Informationsarten, die sich auf die PowerPoint‑Dateien beziehen. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften der PowerPoint‑Dateien zu verwalten.



Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Android via Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Android via Java zwei Arten von Dokumenteigenschaften, nämlich **eingebaute** und **benutzerdefinierte** Eigenschaften. Entwickler können daher beide Arten von Eigenschaften über die Aspose.Slides‑API für Android via Java nutzen. Aspose.Slides für Android via Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die **IDocumentProperties**‑Eigenschaft, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)‑Objekt bereitgestellt wird, nutzen, um auf die Dokumenteigenschaften der Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Zugriff auf eingebaute Eigenschaften**

Diese über das Objekt [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**.
```java
// Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zeige die eingebauten Eigenschaften an
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

Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie das Auslesen. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im nachfolgenden Beispiel wird gezeigt, wie wir die eingebauten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Android via Java ändern können.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Setze die eingebauten Eigenschaften
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


Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, wie unten dargestellt:

|**Eingebaute Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Android via Java ermöglicht es Entwicklern außerdem, benutzerdefinierte Werte für Dokumenteigenschaften einer Präsentation festzulegen. Das nachstehende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation gesetzt werden können.
```java
Presentation pres = new Presentation();
try {
    // Abrufen der Dokumenteigenschaften
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Hinzufügen benutzerdefinierter Eigenschaften
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Abrufen des Eigenschaftsnamen an einem bestimmten Index
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

## **Zugriff auf benutzerdefinierte Eigenschaften und Änderung**

Aspose.Slides für Android via Java ermöglicht es Entwicklern außerdem, die Werte benutzerdefinierter Eigenschaften zu lesen. Das nachstehende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation lesen und ändern können.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zugriff auf und Ändern benutzerdefinierter Eigenschaften
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Anzeigen von Namen und Werten benutzerdefinierter Eigenschaften
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

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="primary" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Setters der Eigenschaft [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zur Schnittstelle [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, kann wie folgt implementiert werden:
```java
// Lese die Informationen der Präsentation
// Erhalte die aktuellen Eigenschaften
// Setze die neuen Werte für die Felder Autor und Titel
// Aktualisiere die Präsentation mit neuen Werten
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
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


Eine neue Vorlage kann von Grund auf erstellt und dann verwendet werden, um mehrere Präsentationen zu aktualisieren:
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


## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt von der Klasse PortionFormat) zur Verfügung, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser Java‑Code zeigt Ihnen, wie Sie die Korrektursprache für PowerPoint festlegen: xxx Warum fehlt LanguageId in der Java‑PortionFormat‑Klasse?
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

    portionFormat.setLanguageId("zh-CN"); // legt die ID einer Korrektursprache fest

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Standard‑Sprache festlegen**

Dieser Java‑Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Fügt eine neue Rechteckform mit Text hinzu
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Prüft die Sprache der ersten Portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides‑API arbeiten können:

[![PowerPoint‑Metadaten ansehen & bearbeiten](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, falls die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was geschieht, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr bestehender Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht erforderlich, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja, Sie können auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `getPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `readDocumentProperties` der Schnittstelle [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/), um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu verbessern.