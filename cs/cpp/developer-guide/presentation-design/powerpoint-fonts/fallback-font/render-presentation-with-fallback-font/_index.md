---
title: Vykreslování prezentací s náhradními fonty v C++
linktitle: Vykreslování prezentací
type: docs
weight: 30
url: /cs/cpp/render-presentation-with-fallback-font/
keywords:
- náhradní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vykreslujte prezentace s náhradními fonty v Aspose.Slides pro C++ - zachovejte jednotný text napříč PPT, PPTX a ODP pomocí podrobných ukázek kódu v C++."
---
## **Přehled**

Aspose.Slides vám umožňuje renderovat prezentace pomocí pravidel náhradních písem. Tento článek ukazuje, jak vytvořit kolekci pravidel náhradních písem, upravit její pravidla odebráním nebo přidáním náhradních písem a přiřadit kolekci pomocí metody `FontsManager::set_FontFallBackRulesCollection`.

Jakmile je kolekce pravidel náhradních písem přiřazena k `FontsManager` prezentace, jsou pravidla použita během operací, jako je ukládání, renderování a konverze prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při renderování miniatury snímku a jejím uložení jako PNG obrázek.

## **Renderování snímku pomocí pravidel náhradních písem**

Následující příklad zahrnuje tyto kroky:

1. Vytvoříme [kolekci pravidel náhradních písem](/slides/cs/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/remove/) pravidlo náhradního písma a [AddFallBackFonts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) k jinému pravidlu.
1. Předáme kolekci pravidel do metody [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Pomocí metody [Presentation::Save()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) můžeme prezentaci uložit ve stejném formátu nebo v jiném. Po nastavení kolekce pravidel náhradních písem v `FontsManager` jsou tato pravidla aplikována během všech operací s prezentací: ukládání, renderování, konverze atd.

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

// Vytvořte novou instanci kolekce pravidel
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Vytvořte několik pravidel
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Pokus o odebrání náhradního fontu "Tahoma" z načtených pravidel
	fallBackRule->Remove(u"Tahoma");

	// A aktualizace pravidel pro zadaný rozsah
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Také můžeme odebrat jakákoli existující pravidla ze seznamu
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Přiřazení připraveného seznamu pravidel k použití
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Vykreslení miniatury pomocí inicializované kolekce pravidel a uložení do PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="info" %}} 
Přečtěte si více o tom, jak [převést snímky PowerPointu do PNG v C++](/slides/cs/cpp/convert-powerpoint-to-png/).
{{% /alert %}}