---
title: Verwalten von Präsentationseigenschaften in Java
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/java/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- eingebaute Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
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
description: "Steuern Sie Präsentationseigenschaften in Aspose.Slides für Java und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Eingebaute** und **Benutzerdefinierte**. Beide Eigenschaftstypen können einfach über die Aspose.Slides API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/) . Eine Instanz dieses Interfaces wird von [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDocumentProperties--) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Hinweis" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation immer "Aspose.Slides for Java" und die Version der Bibliothek, die sie erzeugt hat, meldet. Jeder an `setNameOfApplication` übergebene Wert wird beim Schreiben der Präsentation verworfen.
{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist das Office‑Symbol zu klicken und dann den Menüpunkt **Prepare | Properties | Advanced Properties** von Microsoft PowerPoint 2007 wie unten gezeigt auszuwählen:

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der es Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint‑Datei zu verwalten, wie in der nachfolgenden Abbildung dargestellt:

|**Eigenschaftsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im obigen **Eigenschaftsdialog** sehen Sie viele Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten erlauben das Konfigurieren verschiedener Informationen zu PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften der PowerPoint‑Dateien zu verwalten.

### Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Java zwei Arten von Dokumenteigenschaften: **Eingebaute** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides für Java API nutzen. Aspose.Slides für Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die Eigenschaft **IDocumentProperties**, die vom Objekt [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation) bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften von Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Öffentliche Eigenschaften einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wird eine Präsentation verschlüsselt, indem `false` an [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) übergeben wird, bleiben deren Dokumenteigenschaften öffentlich. Eine Anwendung kann dann `true` an [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) übergeben und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

Die Option “nur Dokumenteigenschaften laden” steuert, was Aspose.Slides lädt; sie entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die komplette Präsentation wird geladen.

Das folgende Beispiel prüft den Lademodus über [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) und liest anschließend eingebaute Eigenschaften über [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDocumentProperties--) :

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Masterfolien, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) prüfen, bevor eine Operation ausgeführt wird, die das komplette Präsentationsobjektmodell erfordert.

{{% alert color="warning" title="Warnung" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur öffentlich, wenn Indexierungs-, Klassifizierungs-, Such- oder Dokumenten‑Management‑Systeme eine spezielle Anforderung haben, ohne Passwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die im “nur Dokumenteigenschaften‑Laden”-Modus geöffnet wurde, zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften aus diesem reinen Metadaten‑Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Eine Aktualisierung erfordert daher das korrekte Öffnungspasswort und ein vollständiges Laden.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions.setPassword](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) verwendet, um zu prüfen, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu verifizieren:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Darf eine Anwendung die Präsentationsinhalte nicht entschlüsseln oder laden, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Diese Eigenschaften, die vom Objekt [IDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties) bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (Zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation‑Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties‑Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zeigen Sie die eingebauten Eigenschaften an
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

Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist ebenso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im nachfolgenden Beispiel wird gezeigt, wie wir die eingebauten Dokumenteigenschaften der Präsentationsdatei mit Aspose.Slides für Java ändern können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Setzen Sie die eingebauten Eigenschaften
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

Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, wie unten dargestellt:

|**Eingebaute Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Java ermöglicht Entwicklern auch das Hinzufügen benutzerdefinierter Werte für Dokumenteigenschaften einer Präsentation. Das nachfolgende Beispiel fügt drei benutzerdefinierte Eigenschaften hinzu, sucht dann den Namen an Index 2 und entfernt diese Eigenschaft, sodass die gespeicherte Präsentation zwei davon behält. Benutzerdefinierte Eigenschaften werden alphabetisch indexiert, nicht in der Reihenfolge ihrer Hinzufügung.

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

Aspose.Slides für Java ermöglicht Entwicklern ebenfalls den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Das folgende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation zugreifen und ändern können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zugriff auf und Ändern benutzerdefinierter Eigenschaften
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Anzeigen von Namen und Werten benutzerdefinierter Eigenschaften
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Ändern der Werte benutzerdefinierter Eigenschaften
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Speichern Sie Ihre Präsentation in einer Datei
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX ](https://docs.fileformat.com/presentation/pptx/)Präsentation. Die nachfolgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" title="Hinweis" %}}
Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) und [WriteBindedPresentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Setters der Eigenschaft [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.
{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden dem Interface [IPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentationInfo) hinzugefügt. Sie ermöglichen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne eine gesamte Präsentation zu laden.

Ein typisches Szenario besteht darin, die Eigenschaften zu laden, einen Wert zu ändern und das Dokument zu aktualisieren. Dies kann wie folgt umgesetzt werden:

```java
import com.aspose.slides.*;

// Lese die Informationen der Präsentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Erhalte die aktuellen Eigenschaften
IDocumentProperties props = info.readDocumentProperties();

// Setze die neuen Werte der Felder Autor und Titel
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

## **Prüfsprach festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (exponiert durch die Klasse PortionFormat) bereit, mit der Sie die Prüf­sprache für ein PowerPoint‑Dokument festlegen können. Die Prüf­sprache ist die Sprache, für die Rechtschreibung und Grammatik im PowerPoint geprüft werden.

Der folgende Java‑Code zeigt, wie Sie die Prüf­sprache für ein PowerPoint festlegen:

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

    portionFormat.setLanguageId("zh-CN"); // setzt die ID einer Korrektursprache

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standard‑Sprache festlegen**

Der folgende Java‑Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen:

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

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern die jeweilige Eigenschaft es zulässt, auf einen leeren Wert setzen.

**Was geschieht, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht erforderlich, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die komplette Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) und anschließend [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) , um die gespeicherten Dokument‑Metadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/java/examine-presentation/) für ein vollständiges Bericht‑Beispiel und format‑spezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne deren Öffnungspasswort lesen?**

Ja. Die Verschlüsselung der Dokumenteigenschaften muss deaktiviert worden sein, bevor die Präsentation verschlüsselt wurde, und die Präsentation muss im Modus “nur Dokumenteigenschaften laden” geöffnet werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Modus “nur Dokumenteigenschaften laden” aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, sodass das Aktualisieren einer verschlüsselten PPTX‑Datei ein vollständiges Laden der Präsentation mit dem korrekten Öffnungspasswort erfordert.