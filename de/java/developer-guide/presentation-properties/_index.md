---
title: Präsentationseigenschaften
type: docs
weight: 70
url: /java/presentation-properties/
---

{{% alert color="primary" %}}

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Standard) Eigenschaften
- Benutzerdefinierte (Benutzerdefinierte) Eigenschaften

**Standard** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie den Dokumenttitel, den Namen des Autors, Dokumentstatistiken und so weiter. **Benutzerdefinierte** Eigenschaften sind die, die von den Benutzern als **Name/Wert**-Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Java können Entwickler die Werte von Standard- sowie benutzerdefinierten Eigenschaften abrufen und ändern.

{{% /alert %}}

## **Dokumenteigenschaften in PowerPoint**
Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteigenschaften der Präsentationsdateien. Alles, was Sie tun müssen, ist, auf das Office-Symbol zu klicken und das Menüelement **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007 auszuwählen, wie unten dargestellt:

{{% alert color="primary" %}}

Bitte beachten Sie, dass Sie keine Werte für die **Anwendung** und **Produzent** Felder festlegen können, da Aspose Ltd. und Aspose.Slides für Java x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}}

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nachdem Sie das Menüelement **Erweiterte Eigenschaften** ausgewählt haben, erscheint ein Dialogfeld, das es Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint-Datei zu verwalten, wie unten in der Abbildung dargestellt:

|**Eigenschaften-Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im obigen **Eigenschaften-Dialog** können Sie sehen, dass es viele Registerkarten wie **Allgemein**, **Zusammenfassung**, **Statistiken**, **Inhalte** und **Benutzerdefiniert** gibt. All diese Registerkarten ermöglichen es, verschiedene Arten von Informationen, die mit den PowerPoint-Dateien verbunden sind, zu konfigurieren. Die Registerkarte **Benutzerdefiniert** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint-Dateien zu verwalten.

Arbeiten mit Dokumenteigenschaften mithilfe von Aspose.Slides für Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Java zwei Arten von Dokumenteigenschaften, nämlich **Standard**- und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften mit der Aspose.Slides für Java API abrufen. Aspose.Slides für Java bietet eine Klasse [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties), die die Dokumenteigenschaften darstellt, die mit einer Präsentationsdatei über die **Presentation.DocumentProperties**-Eigenschaft verbunden sind.

Entwickler können die **IDocumentProperties**-Eigenschaft, die vom [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Objekt bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften der Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Zugriff auf Standard-Eigenschaften**
Diese Eigenschaften, die vom [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) Objekt bereitgestellt werden, umfassen: **Ersteller** (Autor), **Beschreibung**, **Schlüsselwörter**, **Erstellt** (Erstellungsdatum), **Modifiziert** (Änderungsdatum), **Gedruckt** (Letztes Druckdatum), **Zuletzt bearbeitet von**, **Schlüsselwörter**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **Präsentationsformat**, **Betreff** und **Titel**.

```java
// Präsentationsklasse instanziieren, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verbunden ist, erstellen
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Standard-Eigenschaften anzeigen
    System.out.println("Kategorie : " + dp.getCategory());
    System.out.println("Aktueller Status : " + dp.getContentStatus());
    System.out.println("Erstellungsdatum : " + dp.getCreatedTime());
    System.out.println("Autor : " + dp.getAuthor());
    System.out.println("Beschreibung : " + dp.getComments());
    System.out.println("Schlüsselwörter : " + dp.getKeywords());
    System.out.println("Zuletzt bearbeitet von : " + dp.getLastSavedBy());
    System.out.println("Vorgesetzter : " + dp.getManager());
    System.out.println("Änderungsdatum : " + dp.getLastSavedTime());
    System.out.println("Präsentationsformat : " + dp.getPresentationFormat());
    System.out.println("Letztes Druckdatum : " + dp.getLastPrinted());
    System.out.println("Wird zwischen Produzenten geteilt : " + dp.getSharedDoc());
    System.out.println("Betreff : " + dp.getSubject());
    System.out.println("Titel : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standard-Eigenschaften ändern**
Die Änderung der Standard-Eigenschaften von Präsentationsdateien ist ebenso einfach wie der Zugriff auf sie. Sie können einfach einen String-Wert an jede gewünschte Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im folgenden Beispiel zeigen wir, wie wir die Standard-Dokumenteigenschaften der Präsentationsdatei mithilfe von Aspose.Slides für Java ändern können.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verbunden ist, erstellen
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Standard-Eigenschaften festlegen
    dp.setAuthor("Aspose.Slides für Java");
    dp.setTitle("Ändern der Präsentationseigenschaften");
    dp.setSubject("Aspose Betreff");
    dp.setComments("Aspose Beschreibung");
    dp.setManager("Aspose Manager");
    
    // Präsentation in eine Datei speichern
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die Standard-Eigenschaften der Präsentation, die wie folgt angesehen werden können:

|**Standard-Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**
Aspose.Slides für Java ermöglicht es Entwicklern auch, benutzerdefinierte Werte für die Präsentationsdokumenteigenschaften hinzuzufügen. Ein Beispiel wird unten gegeben, das zeigt, wie man die benutzerdefinierten Eigenschaften für eine Präsentation festlegt.

```java
Presentation pres = new Presentation();
try {
    // Dokumenteigenschaften abrufen
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Benutzerdefinierte Eigenschaften hinzufügen
    dProps.set_Item("Neue Benutzerdefinierte", 12);
    dProps.set_Item("Mein Name", "Mudassir");
    dProps.set_Item("Benutzerdefiniert", 124);
    
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

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern von benutzerdefinierten Eigenschaften**
Aspose.Slides für Java ermöglicht es Entwicklern auch, die Werte der benutzerdefinierten Eigenschaften abzurufen. Ein Beispiel wird unten gegeben, das zeigt, wie Sie auf all diese benutzerdefinierten Eigenschaften einer Präsentation zugreifen und diese ändern können.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Referenz auf das DocumentProperties-Objekt, das mit der Präsentation verbunden ist, erstellen
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Benutzerdefinierte Eigenschaften abrufen und ändern
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Namen und Werte der benutzerdefinierten Eigenschaften anzeigen
        System.out.println("Benutzerdefinierter Eigenschaftenname : " + dp.getCustomPropertyName(i));
        System.out.println("Benutzerdefineter Eigenschaftswert : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Werte der benutzerdefinierten Eigenschaften ändern
        dp.set_Item(dp.getCustomPropertyName(i), "Neuer Wert " + (i + 1));
    }
    
    // Präsentation in eine Datei speichern
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX ](https://docs.fileformat.com/presentation/pptx/) Präsentation. Folgende Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**
{{% alert color="primary" %}}

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) und [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) Eigenschaftssetters wurde geändert.

{{% /alert %}}

Die zwei neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zur [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo) Schnittstelle hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf die Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne eine ganze Präsentation zu laden.

Das typische Szenario, die Eigenschaften zu laden, einige Werte zu ändern und das Dokument zu aktualisieren, kann wie folgt implementiert werden:

```java
// Informationen zur Präsentation lesen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Aktuelle Eigenschaften abrufen
IDocumentProperties props = info.readDocumentProperties();

// Neue Werte für die Felder Autor und Titel festlegen
props.setAuthor("Neuer Autor");
props.setTitle("Neuer Titel");

// Die Präsentation mit neuen Werten aktualisieren
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Es gibt eine weitere Möglichkeit, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um die Eigenschaften in anderen Präsentationen zu aktualisieren:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Vorlagenautor");
template.setTitle("Vorlagentitel");
template.setCategory("Vorlagenkategorie");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Unsere Firma");
template.setComments("Aus Vorlage erstellt");
template.setContentType("Vorlageninhalt");
template.setSubject("Vorlagenbetreff");

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

Eine neue Vorlage kann von Grund auf neu erstellt und dann verwendet werden, um mehrere Präsentationen zu aktualisieren:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Vorlagenautor");
template.setTitle("Vorlagentitel");
template.setCategory("Vorlagenkategorie");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Unsere Firma");
template.setComments("Aus Vorlage erstellt");
template.setContentType("Vorlageninhalt");
template.setSubject("Vorlagenbetreff");

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

## **Überprüfen, ob die Präsentation geändert oder erstellt wurde**
Aspose.Slides für Java bietet die Möglichkeit zu überprüfen, ob eine Präsentation geändert oder erstellt wurde. Ein Beispiel wird unten gegeben, das zeigt, wie man überprüfen kann, ob die Präsentation erstellt oder geändert wurde.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Anwendungsname: " + app);
System.out.println("Anwendungsversion: " + ver);
```

## **Sprache für die Korrekturhilfe festlegen**

Aspose.Slides bietet die Spracheigenschaft LanguageId (die von der Klasse PortionFormat bereitgestellt wird), um die Korrekturhilfesprache für ein PowerPoint-Dokument festzulegen. Die Korrekturhilfesprache ist die Sprache, für die die Rechtschreibung und Grammatik im PowerPoint überprüft werden.

Dieser Java-Code zeigt Ihnen, wie Sie die Korrekturhilfesprache für ein PowerPoint festlegen: xxx Warum fehlt LanguageId in der Java-Klasse PortionFormat?

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

    portionFormat.setLanguageId("zh-CN"); // Id einer Korrekturhilfesprache festlegen

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standard-Sprache festlegen**

Dieser Java-Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Fügt eine neue rechteckige Form mit Text hinzu
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Neuer Text");

    // Überprüft die Sprache der ersten Portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```