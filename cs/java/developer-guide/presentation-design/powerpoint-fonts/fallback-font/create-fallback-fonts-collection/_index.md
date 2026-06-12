---
title: Konfigurace kolekcí náhradních fontů v Javě
linktitle: Kolekce náhradních fontů
type: docs
weight: 20
url: /cs/java/create-fallback-fonts-collection/
keywords:
- náhradní font
- náhradní pravidlo
- kolekce fontů
- konfigurace fontu
- nastavení fontu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Nastavte kolekci náhradních fontů v Aspose.Slides pro Javu, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel náhradních fontů pro prezentaci. Každé pravidlo náhrady je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit k vlastnosti `FontFallBackRulesCollection` objektu `FontsManager` prezentace. `FontsManager` řídí fonty v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí náhradních fontů, jsou během vykreslování prezentace použity určené náhradní fonty.

## **Použití pravidel náhradních fontů**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule) mohou být uspořádány do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRulesCollection), která implementuje rozhraní [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IFontFallBackRulesCollection). Je možné přidávat nebo odstraňovat pravidla z kolekce.

Poté může být tato kolekce přiřazena metodě [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRulesCollection) třídy [FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager). `FontsManager` řídí fonty v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) má metodu [getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getFontsManager--) s vlastní instancí třídy [FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager).

Zde je příklad, jak vytvořit kolekci pravidel náhradních fontů a přiřadit ji do [FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getFontsManager--) určité prezentace:  

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

Po inicializaci `FontsManager` s kolekcí náhradních fontů jsou během vykreslování prezentace použity náhradní fonty.

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Vykreslit prezentaci s náhradním fontem](/slides/cs/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou moje pravidla náhrad vložena do souboru PPTX a viditelná v PowerPointu po uložení?**

Ne. Pravidla náhrad jsou nastavení vykreslování za běhu; nejsou serializována do souboru PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Platí náhrada i pro text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Stejný mechanismus substituce glyfů se používá pro jakýkoli text v těchto objektech.

**Distribuuje Aspose nějaké fonty spolu s knihovnou?**

Ne. Fonty přidáváte a používáte na své straně a na vlastní odpovědnost.

**Lze současně použít náhradu/substituci chybějících fontů a náhradu pro chybějící glyfy?**

Ano. Jedná se o nezávislé fáze stejného pipeline pro řešení fontů: nejprve engine zjistí dostupnost fontů ([replacement](/slides/cs/java/font-replacement/)/[substitution](/slides/cs/java/font-substitution/)), poté náhrada vyplní mezery pro chybějící glyfy v dostupných fontech.