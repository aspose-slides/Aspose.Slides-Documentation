---
title: Konfigurace sbírek záložních písem pro Android
linktitle: Sbírka záložních písem
type: docs
weight: 20
url: /cs/androidjava/create-fallback-fonts-collection/
keywords:
- záložní písmo
- záložní pravidlo
- sbírka písem
- nastavení písma
- instalace písma
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Nastavte sbírku záložních písem v Aspose.Slides pro Android pomocí Javy, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat sbírku pravidel záložních písem pro prezentaci. Každé záložní pravidlo je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření sbírky ji můžete přiřadit k vlastnosti `FontFallBackRulesCollection` objektu `FontsManager` prezentace. `FontsManager` řídí písma v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován se sbírkou záložních písem, specifikovaná záložní písma jsou použita během vykreslování prezentace.

## **Použití záložních pravidel**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule) mohou být uspořádány do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRulesCollection), která implementuje rozhraní [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Je možné přidávat nebo odstraňovat pravidla ze sbírky.

Pak může být tato sbírka přiřazena k [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRulesCollection) metodě třídy [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager). FontsManager řídí písma v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) má metodu [getFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getFontsManager--) s vlastní instancí třídy [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager).

Zde je příklad, jak vytvořit sbírku pravidel záložních písem a přiřadit ji do [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getFontsManager--) určité prezentace:

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Po inicializaci FontsManageru se sbírkou záložních písem jsou záložní písma použita během vykreslování prezentace.

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Vykreslit prezentaci se záložním písmem](/slides/cs/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou moje záložní pravidla vložena do souboru PPTX a viditelná v PowerPointu po uložení?**

Ne. Záložní pravidla jsou nastavení vykreslování za běhu; nejsou serializována do PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Platí záloha i pro text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Pro jakýkoli text v těchto objektech se používá stejný mechanismus substituce glyfu.

**Distribuuje Aspose nějaká písma s knihovnou?**

Ne. Písma přidáváte a používáte na své straně a na vlastní odpovědnost.

**Lze kombinovat nahrazení/substituci chybějících písem a zálohu pro chybějící glyfy?**

Ano. Jedná se o nezávislé fáze stejného pipeline pro řešení písem: nejprve engine vyřeší dostupnost písem ([náhrada](/slides/cs/androidjava/font-replacement/)/[substituce](/slides/cs/androidjava/font-substitution/)), poté záloha doplní chybějící glyfy v dostupných písmech.