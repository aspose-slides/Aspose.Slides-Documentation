---
title: Schriftartsubstitution
type: docs
weight: 70
url: /de/cpp/font-substitution/
keywords: "Schriftart, Ersatzschriftart, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Ersatzschriftart in PowerPoint in C++"
---

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen (zum Beispiel, wenn auf eine Schriftart nicht zugegriffen werden kann) getan werden muss:

1. Laden Sie die entsprechende Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Ersatz hinzu.
5. Fügen Sie die Regel zur Sammlung der Schriftart-Ersatzregeln der Präsentation hinzu.
6. Generieren Sie das Folienbild, um den Effekt zu beobachten.

Dieser C++-Code demonstriert den Prozess der Schriftartsubstitution:

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

// Fügt die Regel zur Sammlung der Schriftartersatzregeln hinzu
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Fügt die Sammlung der Schriftartregel zur Regelauflistung hinzu
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Speichert PPTX auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="HINWEIS" color="warning" %}} 

Sie möchten möglicherweise [**Schriftartenersetzung**](/slides/de/cpp/font-replacement/) sehen. 

{{% /alert %}}