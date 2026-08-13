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
- Integrierte Eigenschaften
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
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für Android über Java und optimieren Sie Suche, Markenauftritt und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können problemlos über die Aspose.Slides API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties/) . Eine Instanz dieses Interfaces wird von der Methode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" %}} 

Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation stets den Produktnamen Aspose.Slides und die Versionsnummer der Bibliothek, die sie erzeugt hat, meldet. Jeder an `setNameOfApplication` übergebene Wert wird beim Schreiben der Präsentation verworfen.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist das Office‑Symbol anzuklicken und dann den Menüeintrag **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007 wie unten dargestellt auszuwählen:

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nachdem Sie den Menüeintrag **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der Ihnen die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht, wie unten in der Abbildung dargestellt:

|**Eigenschafts‑Dialog**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Im obigen **Properties Dialog** sehen Sie, dass es viele Registerkartenseiten gibt, z. B. **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

## **Arbeiten mit Dokumenteigenschaften mithilfe von Aspose.Slides für Android über Java**

Wie bereits beschrieben unterstützt Aspose.Slides für Android über Java zwei Arten von Dokumenteigenschaften, nämlich **Built-in**‑ und **Custom**‑Eigenschaften. Entwickler können somit über die Aspose.Slides für Android über Java‑API auf beide Arten von Eigenschaften zugreifen. Aspose.Slides für Android über Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die Eigenschaft **IDocumentProperties**, die vom Objekt [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation) bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften von Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Zugriff auf integrierte Eigenschaften**

Diese von dem Objekt [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties) bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Anzeige der integrierten Eigenschaften
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

Das Ändern integrierter Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel zeigen wir, wie die integrierten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Android über Java geändert werden können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Setzen Sie die integrierten Eigenschaften
    dp.setAuthor("Aspose.Slides for Android via Java");
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

|**Integrierte Dokumenteigenschaften nach Änderungen**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Android über Java ermöglicht Entwicklern zudem das Hinzufügen benutzerdefinierter Werte für Dokumenteigenschaften einer Präsentation. Das nachstehende Beispiel fügt drei benutzerdefinierte Eigenschaften hinzu, sucht dann den bei Index 2 gespeicherten Namen und entfernt diese Eigenschaft, sodass die gespeicherte Präsentation zwei davon beibehält. Benutzerdefinierte Eigenschaften werden alphabetisch indiziert, nicht in der Reihenfolge, in der sie hinzugefügt wurden.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Abrufen der Dokumenteigenschaften
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

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides für Android über Java ermöglicht Entwicklern außerdem den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Das nachstehende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Auf benutzerdefinierte Eigenschaften zugreifen und sie ändern
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

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)-Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Eigenschaftssetzers [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zum Interface [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, kann folgendermaßen umgesetzt werden:

```java
import com.aspose.slides.*;

// Lese die Informationen der Präsentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Hole die aktuellen Eigenschaften
IDocumentProperties props = info.readDocumentProperties();

// Setze die neuen Werte für die Felder Author und Title
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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Rechtschreibsprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt durch die Klasse PortionFormat) zur Verfügung, mit der Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen können. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser Java‑Code zeigt, wie Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen:

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

    portionFormat.setLanguageId("zh-CN"); // setzt die ID einer Korrektursprache

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

    // Prüft die Sprache der ersten Portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑Beispiel**

Testen Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata), um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten können:

[![PowerPoint‑Metadaten anzeigen & bearbeiten](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## ***FAQ**

### Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?

Integrierte Eigenschaften sind ein wesentlicher Bestandteil einer Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

### Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr bestehender Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

### Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?

Ja, Sie können auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `getPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `readDocumentProperties`, die vom Interface [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/) bereitgestellt wird, um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu verbessern.