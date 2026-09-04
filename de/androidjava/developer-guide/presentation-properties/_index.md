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
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie die Präsentationseigenschaften in Aspose.Slides für Android via Java und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides-API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties/)‑Schnittstelle. Eine Instanz dieser Schnittstelle wird von [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation stets den Produktnamen Aspose.Slides und die Versionsnummer der Bibliothek, die sie erstellt hat, anzeigt. Jeder an `setNameOfApplication` übergebene Wert wird verworfen, wenn die Präsentation geschrieben wird.
{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist, das Office‑Symbol anzuklicken und anschließend das Menü **Prepare | Properties | Advanced Properties** von Microsoft PowerPoint 2007 zu wählen, wie unten gezeigt:

|**Auswahl des Menüpunkts „Advanced Properties“**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, in dem Sie die Dokumenteigenschaften der PowerPoint‑Datei verwalten können, wie in der nachfolgenden Abbildung dargestellt:

|**Eigenschafts‑Dialog**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im oben gezeigten **Eigenschafts‑Dialog** sehen Sie viele Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften der PowerPoint‑Dateien zu verwalten.



Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Android via Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Android via Java zwei Arten von Dokumenteigenschaften, nämlich **Built-in** und **Custom**. Entwickler können also beide Arten von Eigenschaften über die Aspose.Slides‑API für Android via Java nutzen. Aspose.Slides für Android via Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die von **Presentation** ([https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)) angebotene **IDocumentProperties**‑Eigenschaft verwenden, um auf die Dokumenteigenschaften von Präsentationsdateien zuzugreifen, wie nachfolgend beschrieben:

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation verschlüsselt wird, indem `false` an [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) übergeben wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann `true` an [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) übergeben und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

Die Option „nur Dokumenteigenschaften laden“ steuert, was Aspose.Slides lädt; sie entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die komplette Präsentation geladen.

Das folgende Beispiel prüft den Lademodus über [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) und liest anschließend eingebaute Eigenschaften über [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Master‑Folien, Layout‑Folien, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) prüfen, bevor sie eine Operation ausführen, die das vollständige Objektmodell der Präsentation erfordert.

{{% alert color="warning" title="Warning" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumenten‑Management‑Systeme einen spezifischen Bedarf haben, ohne Passwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Bei einer verschlüsselten PPTX‑Datei ist eine im Modus „nur Dokumenteigenschaften laden“ geladene Präsentation zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften dieses nur‑Metadaten‑Objekts nicht speichern, da die öffentlichen Eigenschaften konsistent mit den entsprechenden Daten innerhalb der verschlüsselten Präsentation bleiben müssen. Eine Aktualisierung erfordert daher das korrekte Öffnungspasswort und ein vollständiges Laden.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions.setPassword](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird mit [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) überprüft, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu prüfen:

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

Ist einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet, muss sie die öffentlichen Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Diese von [IDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties) bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (Wird zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**.

```java
import com.aspose.slides.*;

// Instanziieren der Presentation-Klasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Eine Referenz auf das IDocumentProperties-Objekt erstellen, das mit der Presentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Eingebaute Eigenschaften anzeigen
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

Das Ändern eingebauter Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Eigenschaftsfeld einen Zeichenkettenwert zuweisen, und der Wert wird geändert. Im nachfolgenden Beispiel zeigen wir, wie die eingebauten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Android via Java geändert werden können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
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

Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation und das Ergebnis wird wie folgt dargestellt:

|**Eingebaute Dokumenteigenschaften nach der Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Android via Java erlaubt Entwicklern außerdem, benutzerdefinierte Werte für die Dokumenteigenschaften einer Präsentation hinzuzufügen. Das nachfolgende Beispiel fügt drei benutzerdefinierte Eigenschaften hinzu, sucht dann den Namen, der an Index 2 gespeichert ist, und entfernt diese Eigenschaft, sodass die gespeicherte Präsentation zwei davon behält. Benutzerdefinierte Eigenschaften werden alphabetisch indiziert, nicht in der Reihenfolge ihrer Hinzufügung.

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

## **Zugriff auf und Änderung benutzerdefinierter Eigenschaften**

Aspose.Slides für Android via Java ermöglicht Entwicklern zudem den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Das nachfolgende Beispiel zeigt, wie Sie alle benutzerdefinierten Eigenschaften einer Präsentation lesen und ändern können.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Eine Referenz auf das DocumentProperties-Objekt erstellen, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zugriff auf benutzerdefinierte Eigenschaften und deren Änderung
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Namen und Werte benutzerdefinierter Eigenschaften anzeigen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Werte benutzerdefinierter Eigenschaften ändern
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Speichere deine Präsentation in einer Datei
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" title="Note" %}}
Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Setters der Eigenschaft [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.
{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zur Schnittstelle [IPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt. Sie ermöglichen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Ein typisches Szenario – Eigenschaften laden, einen Wert ändern und das Dokument aktualisieren – kann wie folgt implementiert werden:

```java
import com.aspose.slides.*;

// Lese die Informationen der Präsentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Hole die aktuellen Eigenschaften
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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt von der Klasse PortionFormat) zur Verfügung, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Der folgende Java‑Code zeigt, wie die Korrektursprache für ein PowerPoint‑Dokument festgelegt wird:

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

    portionFormat.setLanguageId("zh-CN"); // Setze die Id einer Korrektursprache

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standard‑Sprache festlegen**

Der folgende Java‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

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

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr bestehender Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht erforderlich, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentationseigenschaften lesen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) und anschließend [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--), um gespeicherte Dokument‑Metadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/androidjava/examine-presentation/) für ein vollständiges Berichts‑Beispiel und formatspezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne deren Öffnungspasswort lesen?**

Ja. Die Verschlüsselung der Dokumenteigenschaften muss vor der Verschlüsselung der Präsentation deaktiviert worden sein, und die Präsentation muss im Modus „nur Dokumenteigenschaften laden“ geöffnet werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Modus „nur Dokumenteigenschaften laden“ aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, sodass das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der kompletten Präsentation mit dem korrekten Öffnungspasswort erfordert.