---
title: Präsentationen mit Fallback-Schriftarten in C++
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
description: "Präsentationen mit Fallback-Schriftarten in Aspose.Slides für C++ rendern - Text konsistent über PPT, PPTX und ODP hinweg mit Schritt-für-Schritt-C++-Codebeispielen."
---
## **Übersicht**

Aspose.Slides ermöglicht das Rendern von Präsentationen mit Fallback‑Schriftartenregeln. Dieser Artikel zeigt, wie man eine Sammlung von Fallback‑Schriftartenregeln erstellt, deren Regeln durch Entfernen oder Hinzufügen von Fallback‑Schriftarten ändert und die Sammlung mittels der Methode `FontsManager::set_FontFallBackRulesCollection` zuweist.

Sobald die Sammlung von Fallback‑Schriftartenregeln dem `FontsManager` der Präsentation zugewiesen ist, werden die Regeln bei Vorgängen wie dem Speichern, Rendern und Konvertieren der Präsentation angewendet. Das Beispiel demonstriert, wie die konfigurierten Regeln beim Rendern einer Folienvorschau und beim Speichern als PNG‑Bild verwendet werden.

## **Folien mit Fallback‑Schriftartenregeln rendern**

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback‑Schriftartenregeln](/slides/de/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/remove/) einer Fallback‑Schriftartenregel und [AddFallBackFonts()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) zu einer anderen Regel.
3. Übergeben Sie die Regelsammlung an die Methode [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Mit der Methode [Presentation::Save()](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) können wir die Präsentation im selben Format speichern oder in ein anderes Format konvertieren. Nachdem die Fallback‑Schriftartenregelsammlung im FontsManager gesetzt wurde, werden diese Regeln bei allen Vorgängen über die Präsentation angewendet: speichern, rendern, konvertieren usw.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// Neue Instanz einer Regelsammlung erstellen
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Mehrere Regeln erstellen
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Versuche, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
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
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Erfahren Sie mehr darüber, wie Sie [PowerPoint‑Folien in C++ nach PNG konvertieren](/slides/de/cpp/convert-powerpoint-to-png/).
{{% /alert %}}