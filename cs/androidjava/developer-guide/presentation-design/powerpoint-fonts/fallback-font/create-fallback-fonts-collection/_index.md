---
title: Nastavení kolekcí náhradních písem na Androidu
linktitle: Kolekce náhradních písem
type: docs
weight: 20
url: /cs/androidjava/create-fallback-fonts-collection/
keywords:
- náhradní písmo
- náhradní pravidlo
- kolekce písem
- konfigurace písma
- nastavení písma
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Nastavte kolekci náhradních písem v Aspose.Slides pro Android pomocí Javy, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides umožňuje nakonfigurovat sbírku pravidel náhradních písem pro prezentaci. Každé pravidlo náhrady je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření sbírky ji můžete přiřadit k vlastnosti `FontFallBackRulesCollection` objektu `FontsManager` prezentace. `FontsManager` řídí písma napříč prezentací a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován se sbírkou náhradních písem, zadaná náhradní písma jsou použita během vykreslování prezentace.

## **Použití pravidel náhradních písem**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule) mohou být uspořádány do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRulesCollection), která implementuje rozhraní [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Je možné přidávat nebo odebírat pravidla ze sbírky.

Poté může být tato sbírka přiřazena k metodě [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRulesCollection) třídy [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager). FontsManager řídí písma napříč prezentací.

Každá [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) má metodu [getFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getFontsManager--) s vlastní instancí třídy [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager).

Následuje příklad, jak vytvořit sbírku pravidel náhradních písem a přiřadit ji do [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getFontsManager--) určité prezentace:  

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

Po inicializaci FontsManageru se sbírkou náhradních písem jsou náhradní písma použita během vykreslování prezentace.

{{% alert color="info" %}} 
Přečtěte si více o tom, jak [Vykreslit prezentaci s náhradním písmem](/slides/cs/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Budou mé pravidla náhrady vložena do souboru PPTX a viditelná v PowerPointu po uložení?

Ne. Pravidla náhrady jsou nastavení vykreslování za běhu; nejsou serializována do souboru PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

### Platí náhrada i pro text uvnitř SmartArt, WordArt, grafů a tabulek?

Ano. Pro jakýkoli text v těchto objektech se používá stejný mechanismus substituce glifu.

### Distribuuje Aspose nějaká písma spolu s knihovnou?

Ne. Písma přidáváte a používáte na své straně a nesete za to plnou odpovědnost.

### Lze kombinovat nahrazení/substituci chybějících písem a náhradu pro chybějící glyfy?

Ano. Jedná se o nezávislé fáze stejného pipeline řešení písem: nejprve engine vyřeší dostupnost písem ([replacement](/slides/cs/androidjava/font-replacement/)/[substitution](/slides/cs/androidjava/font-substitution/)), poté náhrada vyplní mezery pro chybějící glyfy v dostupných písmech.