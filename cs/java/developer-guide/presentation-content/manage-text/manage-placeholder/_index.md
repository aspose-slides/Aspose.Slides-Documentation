---
title: Spravovat zástupné prvky prezentace v Javě
linktitle: Spravovat zástupné prvky
type: docs
weight: 10
url: /cs/java/manage-placeholder/
keywords:
- zástupný prvek
- textový zástupný prvek
- obrázkový zástupný prvek
- grafický zástupný prvek
- výzva text
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše spravujte zástupné prvky v Aspose.Slides pro Javu: nahraďte text, přizpůsobte výzvy a nastavte průhlednost obrázku v PowerPointu a OpenDocumentu."
---
## **Přehled**

Aspose.Slides vám umožňuje programově spravovat zástupné prvky prezentací. Tento článek vysvětluje, jak najít zástupné prvky na snímcích a změnit jejich text, nastavit vlastní výzvu pro rozvržení zástupných prvků a upravit průhlednost obrázku použitého jako pozadí zástupného prvku. Také obsahuje krátké FAQ, které objasňuje rozdíl mezi základními zástupnými prvky a lokálními tvary, vysvětluje, jak lze změny zástupných prvků aplikovat přes rozvržení nebo master a odkazuje na správu zástupných prvků záhlaví a zápatí.

## **Změna textu v zástupném prvku**
Pomocí [Aspose.Slides for Java](/slides/cs/java/) můžete ve snímcích prezentací najít a upravit zástupné prvky. Aspose.Slides vám umožňuje měnit text v zástupném prvku.

**Prerequisite**: Potřebujete prezentaci, která obsahuje zástupný prvek. Takovou prezentaci můžete vytvořit ve standardní aplikaci Microsoft PowerPoint.

Takto použijete Aspose.Slides k nahrazení textu v zástupném prvku v této prezentaci:

1. Vytvořte instanci třídy [`Presentation`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) a jako argument předávejte soubor prezentace.
2. Získejte odkaz na snímek podle jeho indexu.
3. Procházejte tvary a najděte zástupný prvek.
4. Přetypujte tvar zástupného prvku na [`AutoShape`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AutoShape) a změňte text pomocí [`TextFrame`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TextFrame) spojeného s tímto [`AutoShape`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/AutoShape).
5. Uložte upravenou prezentaci.

Tento Java kód ukazuje, jak změnit text v zástupném prvku:

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Prochází tvary a hledá zástupný prvek
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Mění text v každém zástupném prvku
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Ukládá prezentaci na disk
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení výzvy v zástupném prvku**
Standardní a předpřipravená rozvržení obsahují výzvy jako ***Click to add a title*** nebo ***Click to add a subtitle***. Pomocí Aspose.Slides můžete do rozvržení zástupných prvků vložit vlastní výzvy.

Tento Java kód ukazuje, jak nastavit výzvu v zástupném prvku:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Prochází snímek
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint zobrazuje "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Přidává podtitul
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení průhlednosti obrázku v zástupném prvku**

Aspose.Slides vám umožňuje nastavit průhlednost obrázku na pozadí textového zástupného prvku. Úpravou průhlednosti obrázku v takovém rámečku můžete zvýraznit text nebo obrázek (v závislosti na barvách textu a obrázku).

Tento Java kód ukazuje, jak nastavit průhlednost pozadí obrázku (uvnitř tvaru):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Co je základní zástupný prvek a jak se liší od lokálního tvaru na snímku?**

Základní zástupný prvek je původní tvar v rozvržení nebo masteru, ze kterého snímek dědí typ, umístění a část formátování. Lokální tvar je nezávislý; pokud neexistuje základní zástupný prvek, dědičnost se neuplatní.

**Jak mohu aktualizovat všechny názvy nebo popisky v celé prezentaci, aniž bych procházel každý snímek?**

Upravte odpovídající zástupný prvek v rozvržení nebo masteru. Snímky založené na těchto rozvrženích/masteru automaticky převzebou změnu.

**Jak mohu řídit standardní zástupné prvky záhlaví/zápatí – datum a čas, číslo snímku a text zápatí?**

Použijte správce HeaderFooter v odpovídajícím rozsahu (normální snímky, rozvržení, master, poznámky/letáky) pro zapnutí nebo vypnutí těchto zástupných prvků a pro nastavení jejich obsahu.