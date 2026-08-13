---
title: Vykreslení prezentací se záložními fonty na Androidu
linktitle: Vykreslení prezentací
type: docs
weight: 30
url: /cs/androidjava/render-presentation-with-fallback-font/
keywords:
- záložní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vykreslete prezentace se záložními fonty v Aspose.Slides pro Android – zachovejte konzistentní text napříč PPT, PPTX a ODP s podrobnými ukázkami kódu v Java."
---
## **Přehled**

Aspose.Slides umožňuje vykreslovat prezentace pomocí pravidel pro záložní fonty. Tento článek ukazuje, jak vytvořit kolekci pravidel pro záložní fonty, upravit její pravidla odebráním nebo přidáním záložních fontů a přiřadit kolekci pomocí metody `FontsManager.setFontFallBackRulesCollection`.

Po přiřazení kolekce pravidel pro záložní fonty do `FontsManager` prezentace jsou pravidla aplikována během operací, jako je ukládání, vykreslování a konverze prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako JPEG obrázek.

## **Vykreslení snímku pomocí pravidel pro záložní fonty**

Následující příklad zahrnuje tyto kroky:

1. [Vytvoříme kolekci pravidel pro záložní fonty](/slides/cs/androidjava/create-fallback-fonts-collection/).
1. [Odebereme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) pravidlo záložního fontu a [addFallBackFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) přidáme k jinému pravidlu.
1. Nastavíme kolekci pravidel pomocí [getFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metody.
1. Pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) můžeme prezentaci uložit ve stejném formátu nebo ji uložit v jiném. Po nastavení kolekce pravidel pro záložní fonty do [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager) jsou tato pravidla aplikována během všech operací s prezentací: uložení, vykreslení, konverze atd.

```java
import com.aspose.slides.*;

// Vytvořte novou instanci kolekce pravidel
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Pokoušíme se odebrat záložní font "Tahoma" z načtených pravidel
    fallBackRule.remove("Tahoma");

    // A aktualizovat pravidla pro zadaný rozsah
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Můžeme také odebrat všechna existující pravidla ze seznamu, přičemž ponecháme alespoň jedno pravidlo pro vykreslování
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // Přiřazení připraveného seznamu pravidel pro použití
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Vykreslení miniatury pomocí inicializované kolekce pravidel a uložení jako JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Uložte obrázek na disk ve formátu JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Přečtěte si více o [konverzi PPT a PPTX na JPG na Androidu](/slides/cs/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}