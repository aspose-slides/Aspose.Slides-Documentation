---
title: Vykreslení prezentací s záložními fonty v Javě
linktitle: Vykreslení prezentací
type: docs
weight: 30
url: /cs/java/render-presentation-with-fallback-font/
keywords:
- záložní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Vykreslete prezentace s záložními fonty v Aspose.Slides pro Javu – udržujte text konzistentní napříč PPT, PPTX a ODP pomocí krok za krokem ukázek kódu v Javě."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel pro záložní písma. Tento článek ukazuje, jak vytvořit kolekci pravidel záložních písem, upravit její pravidla odebráním nebo přidáním záložních písem a přiřadit kolekci pomocí metody `FontsManager.setFontFallBackRulesCollection`.

Jakmile je kolekce pravidel záložních písem přiřazena k `FontsManager` prezentace, jsou pravidla aplikována během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako obrázek JPEG.

## **Vykreslení snímku pomocí pravidel záložních písem**

1. Vytvoříme [kolekci pravidel záložních písem](/slides/cs/java/create-fallback-fonts-collection/).
2. [Odstranit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) pravidlo záložního písma a [addFallBackFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) k jinému pravidlu.
3. Nastavte kolekci pravidel pomocí [getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metody.
4. Pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-) můžeme prezentaci uložit ve stejném formátu nebo ji uložit v jiném. Po nastavení kolekce pravidel záložních písem na [FontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsManager) jsou tato pravidla aplikována během všech operací s prezentací: ukládání, vykreslování, převod atd.

```java
import com.aspose.slides.*;

// Create new instance of a rules collection
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Trying to remove FallBack font "Tahoma" from loaded rules
    fallBackRule.remove("Tahoma");

    //And to update of rules for specified range
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list, keeping at least one rule to render with
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Assigning a prepared rules list for using
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //Save the image to disk in JPEG format
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
Přečtěte si více o tom, jak [Převod PPT a PPTX na JPG v Javě](/slides/cs/java/convert-powerpoint-to-jpg/).
{{% /alert %}}