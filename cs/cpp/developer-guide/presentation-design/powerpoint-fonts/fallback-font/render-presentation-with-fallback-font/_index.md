---
title: Vykreslování prezentací s náhradními fonty v C++
linktitle: Vykreslit prezentace
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
description: "Vykreslete prezentace s náhradními fonty v Aspose.Slides pro C++ – zachovejte jednotný text napříč PPT, PPTX a ODP pomocí podrobných ukázek kódu v C++."
---
## **Přehled**

Aspose.Slides umožňuje vykreslovat prezentace pomocí pravidel náhradních písem. Tento článek ukazuje, jak vytvořit kolekci pravidel náhradních písem, upravit její pravidla odstraněním nebo přidáním náhradních písem a přiřadit kolekci pomocí metody `FontsManager::set_FontFallBackRulesCollection`.

Jakmile je kolekce pravidel náhradních písem přiřazena k `FontsManager` prezentace, jsou pravidla aplikována během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím ukládání jako PNG obrázek.

## **Vykreslení snímku pomocí pravidel náhradního písma**

1. Vytvoříme [kolekci pravidel náhradního písma](/slides/cs/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/remove/) pravidlo náhradního písma a [AddFallBackFonts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) k jinému pravidlu.
1. Předáme kolekci pravidel metodě [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Pomocí metody [Presentation::Save()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) můžeme prezentaci uložit ve stejném formátu nebo v jiném. Po nastavení kolekce pravidel náhradního písma do FontsManager se tato pravidla aplikují během jakýchkoli operací s prezentací: ukládání, vykreslování, převod atd.

``` cpp
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

// Také můžeme odebrat libovolná existující pravidla ze seznamu
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
Přečtěte si více o tom, jak [převést snímky PowerPointu do PNG v C++](/slides/cs/cpp/convert-powerpoint-to-png/).
{{% /alert %}}