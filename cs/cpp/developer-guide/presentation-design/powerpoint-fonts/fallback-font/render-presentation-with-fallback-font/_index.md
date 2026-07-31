---
title: Vykreslení prezentací s náhradními fonty v C++
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
description: "Vykreslete prezentace s náhradními fonty v Aspose.Slides pro C++ – zachovejte jednotnost textu napříč PPT, PPTX a ODP pomocí podrobných C++ ukázek kódu."
---
## **Přehled**

Aspose.Slides umožňuje vykreslovat prezentace pomocí pravidel náhradních písem. Tento článek ukazuje, jak vytvořit kolekci pravidel náhradních písem, upravit její pravidla odebráním nebo přidáním náhradních písem a přiřadit kolekci pomocí metody `FontsManager::set_FontFallBackRulesCollection`.

Jakmile je kolekce pravidel náhradních písem přiřazena k `FontsManager` prezentace, jsou pravidla aplikována během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako PNG obrázek.

## **Vykreslení snímku pomocí pravidel náhradních písem**

Následující příklad obsahuje tyto kroky:

1. Vytvoříme [kolekci pravidel náhradních písem](/slides/cs/cpp/create-fallback-fonts-collection/).
2. Použijeme [Remove()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/remove/) k odebrání pravidla náhradního písma a [AddFallBackFonts()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) k přidání náhradních písem k jinému pravidlu.
3. Předáme kolekci pravidel metodě [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Pomocí metody [Presentation::Save()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) můžeme prezentaci uložit ve stejném formátu nebo v jiném. Po nastavení kolekce pravidel náhradních písem v FontsManager jsou tato pravidla aplikována během jakýchkoli operací s prezentací: ukládání, vykreslování, převod atd.

``` cpp
// Vytvořte novou instanci kolekce pravidel
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Vytvořte několik pravidel
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Pokoušíme se odstranit náhradní font "Tahoma" z načtených pravidel
	fallBackRule->Remove(u"Tahoma");

	// A aktualizovat pravidla pro zadaný rozsah
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Také můžeme odstranit jakákoli existující pravidla ze seznamu
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Přiřazení připraveného seznamu pravidel k použití
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Vykreslení miniatury pomocí inicializované kolekce pravidel a uložení do PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [převést snímky PowerPointu na PNG v C++](/slides/cs/cpp/convert-powerpoint-to-png/).
{{% /alert %}}