---
title: Vykreslování prezentací s náhradními fonty na Androidu
linktitle: Vykreslování prezentací
type: docs
weight: 30
url: /cs/androidjava/render-presentation-with-fallback-font/
keywords:
- náhradní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vykreslete prezentace s náhradními fonty v Aspose.Slides pro Android – zachovejte konzistentní text napříč PPT, PPTX a ODP pomocí krok za krokem ukázek kódu v jazyce Java."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel záložních fontů. Tento článek ukazuje, jak vytvořit kolekci pravidel záložních fontů, upravit její pravidla odebráním nebo přidáním záložních fontů a přiřadit kolekci pomocí metody `FontsManager.setFontFallBackRulesCollection`.

Jakmile je kolekce pravidel záložních fontů přiřazena k `FontsManager` prezentace, pravidla jsou použita během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako PNG obrázek.

## **Vykreslit snímek pomocí pravidel záložních fontů**

Následující příklad obsahuje tyto kroky:

1. Vytvoříme [kolekci pravidel záložních fontů](/slides/cs/androidjava/create-fallback-fonts-collection/).
2. [Odstranit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) záložní pravidlo fontu a [addFallBackFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) k dalšímu pravidlu.
3. Nastavíme kolekci pravidel pomocí metody [getFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--).
4. Pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) můžeme prezentaci uložit ve stejném formátu nebo ji uložit v jiném. Poté, co je kolekce pravidel záložních fontů nastavena v [FontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsManager), jsou tato pravidla použita během všech operací s prezentací: ukládání, vykreslování, konverze atd.

```java
// Vytvořte novou instanci kolekce pravidel
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Pokus o odebrání záložního fontu "Tahoma" z načtených pravidel
    fallBackRule.remove("Tahoma");

    // A aktualizaci pravidel pro zadaný rozsah
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Also we can remove any existing rules from list
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Přiřazení připraveného seznamu pravidel pro použití
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Vykreslení miniatury pomocí inicializované kolekce pravidel a uložení do JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Uložte obrázek na disk ve formátu JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Přečtěte si více o [Převod PPT a PPTX na JPG na Androidu](/slides/cs/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}