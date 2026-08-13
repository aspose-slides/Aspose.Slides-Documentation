---
title: Konfigurace kolekcí náhradních písem v C++
linktitle: Kolekce náhradního písma
type: docs
weight: 20
url: /cs/cpp/create-fallback-fonts-collection/
keywords:
- náhradní písmo
- pravidlo náhradního písma
- kolekce písem
- konfigurace písma
- nastavení písma
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Nastavte kolekci náhradních písem v Aspose.Slides pro C++, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel náhradních písem pro prezentaci. Každé pravidlo náhradního písma je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit pomocí metody `set_FontFallBackRulesCollection` třídy `FontsManager` prezentace. `FontsManager` řídí písma v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí náhradních písem, jsou během vykreslování prezentace použita určená náhradní písma.

## **Použít pravidla náhradních písem**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrule/) mohou být uspořádány do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontfallbackrulescollection/), která implementuje rozhraní [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ifontfallbackrulescollection/). Je možné přidávat nebo odebírat pravidla z kolekce.

Poté může být tato kolekce předána metodě [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) třídy [FontsManager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/). FontsManager řídí písma v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) má metodu [get_FontsManager()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/), která poskytuje vlastní instanci třídy FontsManager.

Zde je příklad, jak vytvořit kolekci pravidel náhradních písem a přiřadit ji do FontsManageru určité prezentace:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Po inicializaci FontsManageru s kolekcí náhradních písem jsou během vykreslování prezentace použita náhradní písma.

{{% alert color="info" %}} 
Přečtěte si více o tom, jak [Vykreslit prezentaci s náhradním písmem](/slides/cs/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Časté dotazy**

### Budou moje pravidla náhradních písem vložena do souboru PPTX a viditelná v PowerPointu po uložení?

Ne. Pravidla náhradních písem jsou nastaveními vykreslování za běhu; nejsou serializována do souboru PPTX a nebudou se zobrazovat v rozhraní PowerPointu.

### Používá se náhradní písmo na text uvnitř SmartArt, WordArt, grafů a tabulek?

Ano. Pro jakýkoli text v těchto objektech se používá stejný mechanismus substituce glyfu.

### Distribuuje Aspose nějaká písma spolu s knihovnou?

Ne. Písma přidáváte a používáte na své straně a nesete za to odpovědnost.

### Lze použít nahrazení/substituci chybějících písem a náhradní písmo pro chybějící glyfy společně?

Ano. Jedná se o nezávislé fáze stejného potrubí řešení písem: nejprve engine zjišťuje dostupnost písem ([nahrazení](/slides/cs/cpp/font-replacement/)/[substituce](/slides/cs/cpp/font-substitution/)), poté náhradní písmo vyplní mezery pro chybějící glyfy v dostupných písmech.