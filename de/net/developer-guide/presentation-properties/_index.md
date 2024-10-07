---
title: Präsentationseigenschaften - Zugriff auf oder Änderung der PowerPoint-Präsentationseigenschaften in C#
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /net/presentation-properties/
keywords: "wie man den zuletzt geändert von in PowerPoint entfernt, PowerPoint-Eigenschaften, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Präsentationseigenschaften in C# oder .NET"
---

## **Live-Beispiel**
Versuchen Sie die [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) Online-App, um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides-API arbeitet:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Über Präsentationseigenschaften**
Wie bereits beschrieben, unterstützt Aspose.Slides für .NET zwei Arten von Dokumenteigenschaften, die **Eingebaut** und **Benutzerdefiniert** sind. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides für .NET API abrufen. Aspose.Slides für .NET bietet eine Klasse [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties), die die mit einer Präsentationsdatei verbundenen Dokumenteigenschaften über die [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/properties/index) Eigenschaft darstellt. Entwickler können die von Objekt **Presentation** bereitgestellte [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) Eigenschaft verwenden, um auf die Dokumenteigenschaften der Präsentationsdateien wie unten beschrieben zuzugreifen:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die Felder **Anwendung** und **Producer** setzen können, da Aspose Ltd. und Aspose.Slides für .NET x.x.x gegen diese Felder angezeigt werden.

{{% /alert %}} 

## **Verwalten von Präsentationseigenschaften**
Microsoft PowerPoint bietet eine Funktion zum Hinzufügen einiger Eigenschaften zu den Präsentationsdateien. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Eingebaut) Eigenschaften
- Benutzerdefinierte (Benutzerdefiniert) Eigenschaften

**Eingebaut** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Autorname, Dokumentstatistik usw. **Benutzerdefiniert** Eigenschaften sind diejenigen, die von den Benutzern als **Name/Wert**-Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer definiert werden. Mit Aspose.Slides für .NET können Entwickler die Werte der eingebauten Eigenschaften sowie der benutzerdefinierten Eigenschaften abrufen und ändern. Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteigenschaften der Präsentationsdateien. Alles, was Sie tun müssen, ist, auf das Office-Symbol zu klicken und dann den Menüeintrag **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007 auszuwählen. Nachdem Sie den Menüeintrag **Erweiterte Eigenschaften** ausgewählt haben, erscheint ein Dialogfeld, das es Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint-Datei zu verwalten. Im **Eigenschaften-Dialog** können Sie sehen, dass es viele Registerkarten wie **Allgemein, Zusammenfassung, Statistiken, Inhalte und Benutzerdefiniert** gibt. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Arten von Informationen in Bezug auf die PowerPoint-Dateien. Die Registerkarte **Benutzerdefiniert** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint-Dateien zu verwalten.
## **Zugriff auf Eingebaute Eigenschaften**
Diese Eigenschaften, wie sie vom Objekt **IDocumentProperties** bereitgestellt werden, umfassen: **Ersteller(Autor)**, **Beschreibung**, **Schlüsselwörter**, **Erstellt** (Erstellungsdatum), **Änderung** (Änderungsdatum), **Gedruckt** (Letztes Druckdatum), **LastModifiedBy**, **Schlüsselwörter**, **SharedDoc** (Ist geteilt zwischen verschiedenen Produzenten?), **Präsentationsformat**, **Betreff** und **Titel**.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}
## **Ändern von Eingebauten Eigenschaften**
Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie der Zugriff darauf. Sie können einfach einen Stringwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im folgenden Beispiel haben wir gezeigt, wie wir die eingebauten Dokumenteigenschaften der Präsentationsdatei ändern können.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **Hinzufügen von Benutzerdefinierten Präsentationseigenschaften**
Aspose.Slides für .NET ermöglicht es Entwicklern auch, die benutzerdefinierten Werte für die Dokumenteigenschaften der Präsentation hinzuzufügen. Ein Beispiel, das zeigt, wie man die benutzerdefinierten Eigenschaften für eine Präsentation festlegt, wird unten gegeben.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **Zugriff auf und Ändern von Benutzerdefinierten Eigenschaften**
Aspose.Slides für .NET ermöglicht es Entwicklern auch, auf die Werte der benutzerdefinierten Eigenschaften zuzugreifen. Ein Beispiel, das zeigt, wie Sie auf all diese benutzerdefinierten Eigenschaften für eine Präsentation zugreifen und sie ändern können, wird unten gegeben.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **Überprüfen, ob die Präsentation geändert oder erstellt wurde**
Aspose.Slides für .NET bietet die Möglichkeit zu überprüfen, ob eine Präsentation geändert oder erstellt wurde. Ein Beispiel, das zeigt, wie man überprüft, ob die Präsentation erstellt oder geändert wurde, wird unten gegeben.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

Standard-Sprache festlegen

## **Korrektur Sprache festlegen**

Aspose.Slides bietet die [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) Eigenschaft (bereitgestellt durch die [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) Klasse), um Ihnen zu ermöglichen, die Korrektursprache für ein PowerPoint-Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreib- und Grammatikprüfungen in PowerPoint durchgeführt werden.

Dieser C#-Code zeigt Ihnen, wie Sie die Korrektursprache für ein PowerPoint-Dokument festlegen:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // festlegen der Id einer Korrektursprache
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Standard-Sprache festlegen**

Dieser C#-Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen: 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Fügt eine neue Rechteckform mit Text hinzu
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Neuer Text";
    
    // Überprüft die Sprache der ersten Portion
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```