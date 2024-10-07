---
title: Präsentationseigenschaften
type: docs
weight: 70
url: /androidjava/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften, wie folgt:

- Systemdefinierte (Integrierte) Eigenschaften
- Benutzerdefinierte (Eigene) Eigenschaften

**Integrierte** Eigenschaften enthalten allgemeine Informationen über das Dokument wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften sind diejenigen, die von den Benutzern als **Name/Wert**-Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Android über Java können Entwickler die Werte integrierter Eigenschaften sowie benutzerdefinierter Eigenschaften abrufen und ändern.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**
Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften der Präsentationsdateien. Alles, was Sie tun müssen, ist, auf das Office-Symbol zu klicken und das Menüelement **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007 auszuwählen, wie unten gezeigt:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die **Anwendung** und **Produzenten** Felder festlegen können, da Aspose Ltd. und Aspose.Slides für Android über Java x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 

|**Auswahl des Menüelements Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nachdem Sie das Menüelement **Erweiterte Eigenschaften** ausgewählt haben, öffnet sich ein Dialogfeld, das Ihnen die Verwaltung der Dokumenteigenschaften der PowerPoint-Datei ermöglicht, wie im folgenden Bild dargestellt:

|**Eigenschaften-Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im obigen **Eigenschaften-Dialog** können Sie sehen, dass es viele Registerkarten gibt, wie **Allgemein**, **Zusammenfassung**, **Statistik**, **Inhalt** und **Benutzerdefiniert**. Alle diese Registerkarten ermöglichen es, verschiedene Arten von Informationen zu den PowerPoint-Dateien zu konfigurieren. Die **Benutzerdefinierte** Registerkarte wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint-Dateien zu verwalten.

## Mit Dokumenteigenschaften arbeiten mit Aspose.Slides für Android über Java

Wie zuvor beschrieben, unterstützt Aspose.Slides für Android über Java zwei Arten von Dokumenteigenschaften, nämlich **Integrierte** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften mit der API von Aspose.Slides für Android über Java abrufen. Aspose.Slides für Android über Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) zur Verfügung, die die mit einer Präsentationsdatei verknüpften Dokumenteigenschaften über die **Presentation.DocumentProperties**-Eigenschaft darstellt.

Entwickler können die **IDocumentProperties**-Eigenschaft, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) Objekt bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften der Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Auf integrierte Eigenschaften zugreifen**
Diese Eigenschaften, die vom [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) Objekt bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords** **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Letztes Druckdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Ist sie zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**

```java
// Instanziiere die Präsentationsklasse, die die Präsentation darstellt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zeige die integrierten Eigenschaften an
    System.out.println("Kategorie : " + dp.getCategory());
    System.out.println("Aktueller Status : " + dp.getContentStatus());
    System.out.println("Erstellungsdatum : " + dp.getCreatedTime());
    System.out.println("Autor : " + dp.getAuthor());
    System.out.println("Beschreibung : " + dp.getComments());
    System.out.println("Schlüsselwörter : " + dp.getKeywords());
    System.out.println("Zuletzt geändert von : " + dp.getLastSavedBy());
    System.out.println("Vorgesetzter : " + dp.getManager());
    System.out.println("Änderungsdatum : " + dp.getLastSavedTime());
    System.out.println("Präsentationsformat : " + dp.getPresentationFormat());
    System.out.println("Letztes Druckdatum : " + dp.getLastPrinted());
    System.out.println("Ist zwischen Produzenten geteilt : " + dp.getSharedDoc());
    System.out.println("Betreff : " + dp.getSubject());
    System.out.println("Titel : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Integrierte Eigenschaften ändern**
Das Ändern der integrierten Eigenschaften von Präsentationsdateien ist so einfach wie das Abrufen dieser. Sie können einfach einen Stringwert einer gewünschten Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im Beispiel unten haben wir demonstriert, wie wir die integrierten Dokumenteigenschaften der Präsentationsdatei mit Aspose.Slides für Android über Java ändern können.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Setze die integrierten Eigenschaften
    dp.setAuthor("Aspose.Slides für Android über Java");
    dp.setTitle("Ändern von Präsentationseigenschaften");
    dp.setSubject("Aspose Thema");
    dp.setComments("Aspose Beschreibung");
    dp.setManager("Aspose Manager");
    
    // Speichern Sie Ihre Präsentation in einer Datei
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die integrierten Eigenschaften der Präsentation, die wie folgt angezeigt werden können:

|**Integrierte Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**
Aspose.Slides für Android über Java ermöglicht es Entwicklern auch, benutzerdefinierte Werte für Dokumenteigenschaften von Präsentationen hinzuzufügen. Ein Beispiel wird unten gegeben, das zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.

```java
Presentation pres = new Presentation();
try {
    // Dokumenteigenschaften abrufen
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Benutzerdefinierte Eigenschaften hinzufügen
    dProps.set_Item("Neue Benutzerdefinierte", 12);
    dProps.set_Item("Mein Name", "Mudassir");
    dProps.set_Item("Benutzerdefiniert", 124);
    
    // Abrufen des Eigenschaftsnamen an einem bestimmten Index
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Entfernen der ausgewählten Eigenschaft
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
Aspose.Slides für Android über Java ermöglicht es Entwicklern auch, die Werte benutzerdefinierter Eigenschaften abzurufen. Ein Beispiel wird unten gegeben, das zeigt, wie Sie auf all diese benutzerdefinierten Eigenschaften für eine Präsentation zugreifen und sie ändern können.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz auf das DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zugriff auf und Ändern von benutzerdefinierten Eigenschaften
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Namen und Werte der benutzerdefinierten Eigenschaften anzeigen
        System.out.println("Benutzerdefinierter Eigenschaftsname : " + dp.getCustomPropertyName(i));
        System.out.println("Benutzerdefinierter Eigenschaftswert : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Werte der benutzerdefinierten Eigenschaften ändern
        dp.set_Item(dp.getCustomPropertyName(i), "Neuer Wert " + (i + 1));
    }
    
    // Speichern Sie Ihre Präsentation in einer Datei
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/) Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**
{{% alert color="primary" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) und [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zur Schnittstelle [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Eigenschaftssetters [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zur [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) Schnittstelle hinzugefügt. Sie bieten schnellen Zugriff auf Dokumenteigenschaften und ermöglichen es, Eigenschaften zu ändern und zu aktualisieren, ohne eine gesamte Präsentation zu laden.

Das typische Szenario, das die Eigenschaften lädt, einige Werte ändert und das Dokument aktualisiert, kann folgendermaßen implementiert werden:

```java
// Lese die Informationen zur Präsentation
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Erhalte die aktuellen Eigenschaften
IDocumentProperties props = info.readDocumentProperties();

// Setze die neuen Werte der Autor- und Titel-Felder
props.setAuthor("Neuer Autor");
props.setTitle("Neuer Titel");

// Aktualisiere die Präsentation mit neuen Werten
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Es gibt eine andere Möglichkeit, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um Eigenschaften in anderen Präsentationen zu aktualisieren:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Vorlagenautor");
template.setTitle("Vorlagen-Titel");
template.setCategory("Vorlagenkategorie");
template.setKeywords("Schlüsselwort1, Schlüsselwort2, Schlüsselwort3");
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
template.setTitle("Vorlagen-Titel");
template.setCategory("Vorlagenkategorie");
template.setKeywords("Schlüsselwort1, Schlüsselwort2, Schlüsselwort3");
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
Aspose.Slides für Android über Java bietet die Möglichkeit zu überprüfen, ob eine Präsentation geändert oder erstellt wurde. Ein Beispiel wird unten gegeben, das zeigt, wie überprüft werden kann, ob die Präsentation erstellt oder geändert wurde.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Anwendungsname: " + app);
System.out.println("Anwendungsversion: " + ver);
```

## **Sprache für die Korrekturhilfe festlegen**

Aspose.Slides bietet die Eigenschaft LanguageId (bereitgestellt von der Klasse PortionFormat), um Ihnen zu ermöglichen, die Korrektursprache für ein PowerPoint-Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser Java-Code zeigt Ihnen, wie Sie die Korrektursprache für ein PowerPoint-Dokument festlegen: xxx Warum fehlt LanguageId in der Java PortionFormat-Klasse?

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

    portionFormat.setLanguageId("zh-CN"); // setze die Id einer Korrektursprache

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standardsprache festlegen**

Dieser Java-Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Fügt eine neue rechteckige Form mit Text hinzu
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Neuer Text");

    // Überprüft die Sprache des ersten Portions
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```