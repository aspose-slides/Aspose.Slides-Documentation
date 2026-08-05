---
title: Konfigurace kolekcí náhradních písem v C++
linktitle: Kolekce náhradních písem
type: docs
weight: 20
url: /cs/cpp/create-fallback-fonts-collection/
keywords:
- náhradní písmo
- náhradní pravidlo
- kolekce písem
- konfigurovat písmo
- nastavit písmo
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Nastavte kolekci náhradních písem v Aspose.Slides pro C++, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel náhradního písma pro prezentaci. Každé pravidlo fallback je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit pomocí metody `set_FontFallBackRulesCollection` třídy `FontsManager` prezentace. `FontsManager` řídí písma v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí fallback písem, specifikovaná náhradní písma jsou použita během vykreslování prezentace.

## **Použití pravidel fallback**

Instance [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) třídy lze uspořádat do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrulescollection/), která implementuje rozhraní [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrulescollection/). Je možné přidávat nebo odstraňovat pravidla z kolekce.

Poté může být tato kolekce předána metodě [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) třídy [FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/). `FontsManager` řídí písma v celé prezentaci.

Každý [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) má metodu [get_FontsManager()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/) s vlastní instancí třídy `FontsManager`.

Zde je příklad, jak vytvořit kolekci pravidel fallback písem a přiřadit ji do `FontsManager` konkrétní prezentace:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Po inicializaci `FontsManager` kolekcí fallback písem jsou tato písma použita během vykreslování prezentace.

{{% alert color="primary" %}} 
Přečtěte si více o [Render Presentation with Fallback Font](/slides/cs/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou moje pravidla fallback vložena do souboru PPTX a viditelná v PowerPointu po uložení?**

Ne. Pravidla fallback jsou nastavení vykreslování v runtime; nejsou serializována do PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Používá se fallback na text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Stejný mechanismus substituce glyfů se používá pro jakýkoli text v těchto objektech.

**Distribuuje Aspose nějaká písma spolu s knihovnou?**

Ne. Písma přidáváte a používáte na své straně a nesete za to odpovědnost.

**Lze současně použít nahrazení/substituci chybějících písem a fallback pro chybějící glyfy?**

Ano. Jedná se o nezávislé fáze stejného pipeline řešení písem: nejprve engine řeší dostupnost písem ([replacement](/slides/cs/cpp/font-replacement/)/[substitution](/slides/cs/cpp/font-substitution/)), poté fallback doplňuje mezery pro chybějící glyfy v dostupných písmech.