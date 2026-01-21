---
title: Präsentationen mit Fallback-Schriftarten in C++ rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/cpp/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folien rendern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Rendern Sie Präsentationen mit Fallback-Schriftarten in Aspose.Slides für C++ – halten Sie den Text über PPT, PPTX und ODP hinweg konsistent mit schrittweisen C++-Codebeispielen."
---

Das folgende Beispiel umfasst diese Schritte:

1. Wir [Erstellen einer Fallback‑Schriftartregelsammlung](/slides/de/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/remove/) eine Fallback‑Schriftartregel entfernen und [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) zu einer anderen Regel hinzufügen.
1. Übergeben Sie die Regelsammlung an die Methode [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Mit der Methode [Presentation::Save()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) können wir die Präsentation im selben Format speichern oder in ein anderes Format. Nachdem die Fallback‑Schriftartregelsammlung im FontsManager festgelegt wurde, werden diese Regeln bei allen Vorgängen an der Präsentation angewendet: Speichern, Rendern, Konvertieren usw.
``` cpp
// Neue Instanz einer Regelsammlung erstellen
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Eine Reihe von Regeln erstellen
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Versuch, die Fallback-Schriftart "Tahoma" aus geladenen Regeln zu entfernen
	fallBackRule->Remove(u"Tahoma");

	// Und die Regeln für den angegebenen Bereich zu aktualisieren
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Wir können auch vorhandene Regeln aus der Liste entfernen
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```



{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie man [Convert PowerPoint Slides to PNG in C++](/slides/de/cpp/convert-powerpoint-to-png/) konvertiert.
{{% /alert %}}