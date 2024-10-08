---
title: Präsentation mit Fallback-Schriftart rendern
type: docs
weight: 30
url: /de/cpp/render-presentation-with-fallback-font/
keywords: 
- Fallback-Schriftart
- PowerPoint rendern
- PowerPoint
- Präsentation
- C++
- Aspose.Slides für C++
description: "PowerPoint mit Fallback-Schriftart in C++ rendern"
---

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback-Schriftart-Regeln](/slides/de/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#aaf12e563d822f6e05e27732a837bcf33) eine Fallback-Schriftartregel und [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#a030268631ae616b775bdb6df8accf42c) zu einer anderen Regel hinzufügen.
1. Regeln-Sammlung auf [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) Eigenschaft setzen.
1. Mit [Presentation::Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode können wir die Präsentation im gleichen Format speichern oder in einem anderen. Nachdem die Fallback-Schriftart-Regeln-Sammlung dem FontsManager zugewiesen wurde, werden diese Regeln während aller Operationen über die Präsentation angewendet: speichern, rendern, konvertieren usw.

``` cpp
// Erstellen Sie eine neue Instanz einer Regelssammlung
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Erstellen Sie eine Anzahl von Regeln
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Versuch, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
	fallBackRule->Remove(u"Tahoma");

	// Und um die Regeln für den angegebenen Bereich zu aktualisieren
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Auch können wir vorhandene Regeln aus der Liste entfernen
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Zuweisen einer vorbereiteten Regel-Liste zur Verwendung
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering des Thumbnails mit der Verwendung der initialisierten Regelssammlung und speichern als PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Erfahren Sie mehr über [Speichern und Konvertieren in Präsentationen](/slides/de/cpp/creating-saving-and-converting-a-presentation/).
{{% /alert %}}