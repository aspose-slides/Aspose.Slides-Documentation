---
title: Konfigurace kolekcí záložních fontů v C++
linktitle: Kolekce záložních fontů
type: docs
weight: 20
url: /cs/cpp/create-fallback-fonts-collection/
keywords:
- záložní font
- záložní pravidlo
- kolekce fontů
- konfigurace fontu
- nastavení fontu
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Nastavte kolekci záložních fontů v Aspose.Slides pro C++, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat sbírku pravidel záložních fontů pro prezentaci. Každé záložní pravidlo je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření sbírky ji můžete přiřadit pomocí metody `set_FontFallBackRulesCollection` třídy `FontsManager` prezentace. `FontsManager` řídí fonty v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován se sbírkou záložních fontů, jsou během vykreslování prezentace použity určené záložní fonty.

## **Použít pravidla záložních fontů**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) lze uspořádat do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrulescollection/), která implementuje rozhraní [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrulescollection/). Do sbírky lze přidávat nebo odebírat pravidla.

Pak lze tuto sbírku předat metodě [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) třídy [FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/). FontsManager řídí fonty v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) má metodu [get_FontsManager()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/), která vrací vlastní instanci třídy FontsManager.

Zde je příklad, jak vytvořit sbírku pravidel záložních fontů a přiřadit ji do FontsManageru konkrétní prezentace:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Po inicializaci FontsManageru se sbírkou záložních fontů jsou během vykreslování prezentace použity záložní fonty.

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Render Presentation with Fallback Font](/slides/cs/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou moje pravidla záložních fontů vložena do souboru PPTX a viditelná v PowerPointu po uložení?**

Ne. Pravidla záložních fontů jsou nastavení prováděná za běhu; nejsou serializována do PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Platí záložní fonty i pro text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Pro jakýkoli text v těchto objektech se používá stejný mechanismus substituce glyfu.

**Distribuuje Aspose nějaké fonty s knihovnou?**

Ne. Fonty přidáváte a používáte na své straně a na vlastní odpovědnost.

**Lze použít nahrazení/substituci chybějících fontů a záložní fonty pro chybějící glyfy společně?**

Ano. Jedná se o nezávislé fáze stejného pipeline pro řešení fontů: nejprve engine určuje dostupnost fontů ([replacement](/slides/cs/cpp/font-replacement/)/[substitution](/slides/cs/cpp/font-substitution/)), poté záložní fonty vyplňují mezery chybějících glyfů v dostupných fontech.