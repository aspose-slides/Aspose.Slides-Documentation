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
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Präsentationen mit Fallback-Schriftarten in Aspose.Slides für C++ rendern – Text über PPT, PPTX und ODP hinweg konsistent halten mit schrittweisen C++-Codebeispielen."
---
## **Übersicht**

Aspose.Slides ermöglicht das Rendern von Präsentationen unter Verwendung von Fallback‑Schriftartenregeln. Dieser Artikel zeigt, wie man eine Sammlung von Fallback‑Schriftartenregeln erstellt, ihre Regeln durch Entfernen oder Hinzufügen von Fallback‑Schriftarten ändert und die Sammlung mit der Methode `FontsManager::set_FontFallBackRulesCollection` zuweist.

Sobald die Sammlung von Fallback‑Schriftartenregeln dem `FontsManager` der Präsentation zugewiesen ist, werden die Regeln bei Vorgängen wie dem Speichern, Rendern und Konvertieren der Präsentation angewendet. Das Beispiel demonstriert, wie die konfigurierten Regeln beim Rendern einer Folien‑Vorschau und beim Speichern als PNG‑Bild verwendet werden.

## **Eine Folie unter Verwendung von Fallback‑Schriftartenregeln rendern**

1. Wir [erstellen die Fallback‑Schriftartenregeln‑Sammlung](/slides/de/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/remove/) eine Fallback‑Schriftartregel und [AddFallBackFonts()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) zu einer anderen Regel hinzufügen.
1. Übergebe die Regel‑Sammlung an die Methode [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Mit der Methode [Presentation::Save()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) können wir die Präsentation im gleichen Format speichern oder in einem anderen Format. Nachdem die Fallback‑Schriftartenregeln‑Sammlung dem FontsManager zugewiesen wurde, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: speichern, rendern, konvertieren usw.

``` cpp
// Neue Instanz einer Regelensammlung erstellen
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Eine Anzahl von Regeln erstellen
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Versuchen, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
	fallBackRule->Remove(u"Tahoma");

	// Und die Regeln für den angegebenen Bereich aktualisieren
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
// Zuweisen einer vorbereiteten Regel-Liste zur Nutzung
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendern einer Miniaturansicht unter Verwendung der initialisierten Regelensammlung und Speichern als PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie Sie [PowerPoint‑Folien in C++ nach PNG konvertieren](/slides/de/cpp/convert-powerpoint-to-png/).
{{% /alert %}}