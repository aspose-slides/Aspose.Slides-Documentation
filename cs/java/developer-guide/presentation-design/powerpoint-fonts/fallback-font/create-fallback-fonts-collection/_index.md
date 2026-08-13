---
title: "Konfigurace kolekcí záložních fontů v Java"
linktitle: "Kolekce záložních fontů"
type: docs
weight: 20
url: /cs/java/create-fallback-fonts-collection/
keywords:
- "záložní font"
- "záložní pravidlo"
- "kolekce fontů"
- "konfigurace fontu"
- "nastavení fontu"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Java"
- "Aspose.Slides"
description: "Nastavte kolekci záložních fontů v Aspose.Slides pro Java, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel záložních fontů pro prezentaci. Každé záložní pravidlo je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit k vlastnosti `FontFallBackRulesCollection` objektu `FontsManager` prezentace. `FontsManager` řídí fonty v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí záložních fontů, jsou během vykreslování prezentace použity určené záložní fonty.

## **Použití záložních pravidel**

Instance třídy[FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule) mohou být uspořádány do[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRulesCollection), která implementuje rozhraní[IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IFontFallBackRulesCollection). Je možné přidávat nebo odebírat pravidla z kolekce.

Poté může být tato kolekce přiřazena metodě[FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRulesCollection) třídy[FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager). FontsManager řídí fonty v celé prezentaci.

Každá[Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) má metodu[getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getFontsManager--) s vlastní instancí třídy[FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager).

Níže je příklad, jak vytvořit kolekci pravidel záložních fontů a přiřadit ji do[FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getFontsManager--) konkrétní prezentace:
```java
import com.aspose.slides.*;

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

Po inicializaci FontsManageru s kolekcí záložních fontů jsou během vykreslování prezentace použity záložní fonty.

{{% alert color="info" %}} 
Přečtěte si více o tom, jak [Render Presentation with Fallback Font](/slides/cs/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

### Budou moje záložní pravidla vložena do souboru PPTX a viditelná v PowerPointu po uložení?

Ne. Záložní pravidla jsou nastavení vykreslování za běhu; nejsou serializována do souboru PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

### Platí záložní pravidla i pro text uvnitř SmartArt, WordArt, grafů a tabulek?

Ano. Stejný mechanismus substituce glyfů se používá pro jakýkoli text v těchto objektech.

### Distribuuje Aspose spolu s knihovnou nějaké fonty?

Ne. Fonty přidáváte a používáte na své straně a na vlastní odpovědnost.

### Lze kombinovat nahrazení/substituci chybějících fontů a záložní pravidla pro chybějící glyfy?

Ano. Jedná se o nezávislé fáze stejného procesu řešení fontů: nejprve engine zjišťuje dostupnost fontů([replacement](/slides/cs/java/font-replacement/)/[substitution](/slides/cs/java/font-substitution/)), poté záložní pravidla doplňují chybějící glyfy v dostupných fontech.