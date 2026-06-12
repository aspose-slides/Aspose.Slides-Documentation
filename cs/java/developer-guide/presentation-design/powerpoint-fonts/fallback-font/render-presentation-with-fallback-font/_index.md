---
title: Vykreslování prezentací s náhradními fonty v Javě
linktitle: Vykreslování prezentací
type: docs
weight: 30
url: /cs/java/render-presentation-with-fallback-font/
keywords:
- náhradní font
- vykreslovat PowerPoint
- vykreslovat prezentaci
- vykreslovat snímek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Vykreslete prezentace s náhradními fonty v Aspose.Slides pro Javu – zajistěte konzistentní text napříč PPT, PPTX a ODP pomocí podrobných ukázek kódu v Javě."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel pro náhradní písma. Tento článek ukazuje, jak vytvořit kolekci pravidel náhradních písem, upravit její pravidla odebráním nebo přidáním náhradních písem a přiřadit kolekci pomocí metody `FontsManager.setFontFallBackRulesCollection`.

Jakmile je kolekce pravidel náhradních písem přiřazena k `FontsManager` prezentace, jsou pravidla použita během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako PNG obrázek.

## **Vykreslit snímek pomocí pravidel náhradních písem**

1. [Vytvoříme kolekci pravidel náhradních písem](/slides/cs/java/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) pravidlo náhradního písma a [addFallBackFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do jiného pravidla.
3. Nastavíme kolekci pravidel pomocí [getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metody.
4. Pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-) můžeme uložit prezentaci ve stejném formátu nebo ji uložit v jiném. Po přiřazení kolekce pravidel náhradních písem k [FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager), jsou tato pravidla použita během všech operací nad prezentací: ukládání, vykreslování, převod atd.

```java
// Vytvořte novou instanci kolekce pravidel
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// vytvořte několik pravidel
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Pokus o odebrání náhradního fontu "Tahoma" z načtených pravidel
    fallBackRule.remove("Tahoma");

    // A aktualizovat pravidla pro zadaný rozsah
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Také můžeme odebrat jakákoli existující pravidla ze seznamu
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Přiřazení připraveného seznamu pravidel k použití
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Vykreslení miniatury s použitím inicializované kolekce pravidel a uložení do JPEG
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
Více informací o tom, jak [převést PPT a PPTX na JPG v Javě](/slides/cs/java/convert-powerpoint-to-jpg/).
{{% /alert %}}