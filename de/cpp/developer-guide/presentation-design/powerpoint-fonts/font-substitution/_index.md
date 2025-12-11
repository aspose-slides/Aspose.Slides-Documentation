---
title: Schriftart-Substitution in Präsentationen mit C++ konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/cpp/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Aktivieren Sie die optimale Schriftart-Substitution in Aspose.Slides für C++, wenn PowerPoint- und OpenDocument-Präsentationen in andere Dateiformate konvertiert werden."
---

## **Schriftart‑Substitutionsregeln festlegen**

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen zu tun ist (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann) – so:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für die Ersetzung hinzu.
5. Fügen Sie die Regel zur Sammlung der Schriftart‑Ersetzungsregeln der Präsentation hinzu.
6. Generieren Sie das Folienbild, um den Effekt zu beobachten.

Dieser C++‑Code demonstriert den Schriftart‑Substitutionsprozess:
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Lädt eine Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definiert die Schriftart, die ersetzt wird, und die neue Schriftart
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Fügt eine Schriftartregel für die Schriftart-Ersetzung hinzu
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Fügt die Regel zur Sammlung von Schriftart-Substitutionsregeln hinzu
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Fügt die Schriftartregel-Sammlung zur Regel-Liste hinzu
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Speichert PPTX auf Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 

Vielleicht möchten Sie [**Schriftart‑Ersetzung**](/slides/de/cpp/font-replacement/) sehen. 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Replacement](/slides/de/cpp/font-replacement/) ist ein erzwungenes Überschreiben einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die ursprüngliche Schriftart nicht verfügbar ist, und dann wird eine festgelegte Ersatzschriftart verwendet.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen am Standard-[font selection](/slides/de/cpp/font-selection-sequence/)-Ablauf teil, der beim Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird Ersetzung oder Substitution angewendet.

**Was ist das Standardverhalten, wenn weder Ersetzung noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die nächstgelegene verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit anhängen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [add external fonts](/slides/de/cpp/custom-font/) hinzufügen, damit die Bibliothek sie für Auswahl und Rendering berücksichtigt, einschließlich für nachfolgende Konvertierungen.

**Verteilt Aspose Schriftarten mit der Bibliothek?**

Nein. Aspose verteilt keine kostenpflichtigen oder kostenlosen Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schrifterkennung beginnt in den Schriftartenverzeichnissen des Betriebssystems. Der Satz an standardmäßig verfügbaren Schriftarten und die Suchpfade variieren zwischen den Plattformen, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie den Schriftartensatz über Maschinen oder Container hinweg, [add the external fonts](/slides/de/cpp/custom-font/) hinzufügen, die für die Ausgabedokumente erforderlich sind, und [embed fonts](/slides/de/cpp/embedded-font/) in Präsentationen ein, wenn möglich, damit die ausgewählten Schriftarten beim Rendering verfügbar sind.