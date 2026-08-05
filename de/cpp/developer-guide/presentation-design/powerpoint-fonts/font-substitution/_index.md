---
title: Schriftersetzung in Präsentationen mit C++
linktitle: Schriftersetzung
type: docs
weight: 70
url: /de/cpp/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftersetzung
- Schriftart ersetzen
- Schriftart‑Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Optimale Schriftersetzung in Aspose.Slides für C++ aktivieren, wenn PowerPoint‑ und OpenDocument‑Präsentationen in andere Dateiformate konvertiert werden."
---
## **Übersicht**

Die Schriftersetzung ermöglicht es Aspose.Slides, eine andere Schriftart zu verwenden, wenn die ursprüngliche Schriftart der Präsentation beim Rendern oder Konvertieren nicht verfügbar ist. Sie können prüfen, welche Schriftarten ersetzt wurden, indem Sie die Methode `GetSubstitutions` aus dem Interface `IFontsManager` verwenden.

Aspose.Slides ermöglicht außerdem das Festlegen von Schriftersetzungsregeln. Beispielsweise können Sie angeben, dass eine nicht zugängliche Schriftart durch eine andere verfügbare Schriftart ersetzt werden soll, und diese Regeln dann über den Schriftarten‑Manager der Präsentation anwenden.

## **Schriftart-Substitutionsregeln festlegen**

Aspose.Slides erlaubt das Festlegen von Regeln für Schriftarten, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn eine Schriftart nicht zugänglich ist) geschehen soll, auf folgende Weise:

1. Laden Sie die betreffende Präsentation.  
2. Laden Sie die Schriftart, die ersetzt werden soll.  
3. Laden Sie die neue Schriftart.  
4. Fügen Sie eine Regel für den Ersatz hinzu.  
5. Fügen Sie die Regel zur Sammlung der Schriftart‑Ersetzungsregeln der Präsentation hinzu.  
6. Generieren Sie das Folien‑Bild, um den Effekt zu beobachten.

Dieser C++‑Code demonstriert den Schriftart‑Substitutionsvorgang:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Lädt eine Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definiert die Schriftart, die ersetzt werden soll, und die neue Schriftart
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Fügt eine Schriftartregel für den Schriftartersatz hinzu
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Fügt die Regel zur Sammlung von Schriftart‑Ersetzungsregeln hinzu
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Fügt die Schriftartregel‑Sammlung zur Regel‑Liste hinzu
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Speichert PPTX auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Vielleicht möchten Sie sich [**Font Replacement**](/slides/de/cpp/font-replacement/) ansehen. 
{{% /alert %}}

## **Einschränkungen für mathematische Gleichungs‑Schriftarten**

Schriftersetzungsregeln nehmen am standardmäßigen Schriftartauswahl‑Prozess teil, der beim Rendern und Konvertieren verwendet wird. Sie eignen sich für normale Textszenarien, bei denen Aspose.Slides eine nicht zugängliche Schriftart gemäß der konfigurierten Regel durch eine andere verfügbare Schriftart ersetzen kann.

Bei Office‑Mathe‑Gleichungen gibt es jedoch eine wichtige Einschränkung. Wenn eine Gleichung mit **Cambria Math** erstellt wurde, kann Aspose.Slides weiterhin die originale **Cambria Math**‑Schriftart benötigen, um das Layout der Gleichung korrekt zu berechnen und zu rendern. Deshalb wird das Ersetzen von **Cambria Math** durch eine andere Math‑Schriftart, etwa **STIX Two Math**, für das Rendern von Gleichungen nicht unterstützt und kann weiterhin zu einer Ausnahme führen, die anzeigt, dass **Cambria Math** erforderlich ist.

Um solche Präsentationen erfolgreich zu konvertieren, stellen Sie sicher, dass **Cambria Math** zur Laufzeit für Aspose.Slides verfügbar ist. Sie können die Schriftart im Betriebssystem installieren oder sie als [externen Schriftart](/slides/de/cpp/custom-font/) bereitstellen, damit sie am normalen Schriftartauswahl‑Prozess während des Renderns und Konvertierens teilnehmen kann.

Diese Einschränkung bezieht sich ausschließlich auf das Rendern von Gleichungen. Die oben beschriebenen standardmäßigen Schriftersetzungsregeln gelten weiterhin für regulären Präsentationstext, wenn die ursprüngliche Schriftart nicht zugänglich ist.

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**  
[Replacement](/slides/de/cpp/font-replacement/) ist ein erzwungenes Überschreiben einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die ursprüngliche Schriftart nicht verfügbar ist, und dann eine festgelegte Ersatzschriftart verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**  
Die Regeln beteiligen sich an der standardmäßigen [font selection](/slides/de/cpp/font-selection-sequence/)-Sequenz, die beim Laden, Rendern und Konvertieren ausgewertet wird; ist die ausgewählte Schriftart nicht verfügbar, wird ein Ersatz oder eine Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Replacement noch Substitution konfiguriert ist und die Schriftart im System fehlt?**  
Die Bibliothek versucht, die am besten verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit anhängen, um Substitution zu vermeiden?**  
Ja. Sie können zur Laufzeit [externen Schriftarten](/slides/de/cpp/custom-font/) hinzufügen, sodass die Bibliothek sie für die Auswahl und das Rendern berücksichtigt, auch für nachfolgende Konvertierungen.

**Verteilt Aspose irgendwelche Schriftarten mit der Bibliothek?**  
Nein. Aspose verteilt weder kostenpflichtige noch kostenlose Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und auf eigene Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**  
Ja. Die Schriftartenerkennung beginnt in den Schriftarten‑Verzeichnissen des Betriebssystems. Der Satz an standardmäßig verfügbaren Schriftarten und die Suchpfade unterscheiden sich plattformabhängig, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**  
Synchronisieren Sie den Schriftarten‑Satz über Maschinen oder Container, [fügen Sie die externen Schriftarten](/slides/de/cpp/custom-font/) hinzu, die für die Ausgabedokumente erforderlich sind, und betten Sie Schriftarten ([embed fonts](/slides/de/cpp/embedded-font/)) in Präsentationen ein, wann immer dies möglich ist, damit die gewünschten Schriftarten beim Rendern verfügbar sind.