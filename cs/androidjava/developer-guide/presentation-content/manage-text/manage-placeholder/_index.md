---
title: Správa zástupců prezentace na Androidu
linktitle: Správa zástupců
type: docs
weight: 10
url: /cs/androidjava/manage-placeholder/
keywords:
- zástupce
- textový zástupce
- obrázkový zástupce
- grafový zástupce
- výzva k zadání
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Jednoduše spravujte zástupce v Aspose.Slides pro Android pomocí Javy: nahraďte text, přizpůsobte výzvy a nastavte průhlednost obrázku v PowerPointu a OpenDocumentu."
---
## **Přehled**

Aspose.Slides vám umožňuje programově spravovat zástupce v prezentacích. Tento článek vysvětluje, jak najít zástupce na snímcích a změnit jejich text, nastavit vlastní výzvu k zadání pro rozvržení zástupců a upravit průhlednost obrázku použitého jako pozadí zástupce. Také obsahuje krátkou sekci FAQ, která objasňuje rozdíl mezi základními zástupci a místními tvary, vysvětluje, jak lze změny zástupců aplikovat prostřednictvím rozvržení nebo hlavních šablon, a odkazuje na správu zástupců záhlaví a zápatí.

## **Změna textu v zástupci**
Pomocí [Aspose.Slides for Android via Java](/slides/cs/androidjava/) můžete najít a upravit zástupce na snímcích v prezentacích. Aspose.Slides vám umožňuje provádět změny textu v zástupci.

**Prerequisite**: Potřebujete prezentaci, která obsahuje zástupce. Takovou prezentaci můžete vytvořit v standardní aplikaci Microsoft PowerPoint.

Takto použijete Aspose.Slides k nahrazení textu ve zástupci v této prezentaci:

1. Vytvořte instanci třídy [`Presentation`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) a předávejte prezentaci jako argument.
2. Získejte referenci na snímek pomocí jeho indexu.
3. Procházejte tvary a najděte zástupce.
4. Přetypujte tvar zástupce na [`AutoShape`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AutoShape) a změňte text pomocí [`TextFrame`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrame) přidruženého k [`AutoShape`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/AutoShape).
5. Uložte upravenou prezentaci.

Tento Java kód ukazuje, jak změnit text ve zástupci:

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Přistoupí k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Prochází tvary a hledá zástupce
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Změní text v každém zástupci
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Uloží prezentaci na disk
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení výzvy textu ve zástupci**
Standardní a předpřipravená rozvržení obsahují výzvy textu zástupce, např. ***Klikněte pro přidání nadpisu*** nebo ***Klikněte pro přidání podnadpisu***. Pomocí Aspose.Slides můžete vložit své vlastní výzvy textu do rozvržení zástupců.

Tento Java kód vám ukazuje, jak nastavit výzvu textu ve zástupci:

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
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Přidá podnadpis
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

## **Nastavení průhlednosti obrázku zástupce**
Aspose.Slides vám umožňuje nastavit průhlednost obrázku pozadí v textovém zástupci. Úpravou průhlednosti obrázku v takovém rámečku můžete zvýraznit text nebo obrázek (v závislosti na barvách textu a obrázku).

Tento Java kód vám ukazuje, jak nastavit průhlednost pozadí obrázku (uvnitř tvaru):

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

**Co je základní zástupce a jak se liší od místního tvaru na snímku?**

Základní zástupce je původní tvar v rozvržení nebo hlavní šabloně, ze kterého tvar snímku dědí – typ, umístění a některé formátování pocházejí z něj. Místní tvar je nezávislý; pokud neexistuje základní zástupce, dědičnost se neuplatní.

**Jak mohu aktualizovat všechny nadpisy nebo popisky v celé prezentaci bez iterace přes každý snímek?**

Upravte odpovídající zástupce v rozvržení nebo hlavní šabloně. Snímky založené na těchto rozvrženích/té hlavní šabloně automaticky zdědí změnu.

**Jak mohu řídit standardní zástupce záhlaví/zápatí – datum a čas, číslo snímku a text zápatí?**

Použijte správce HeaderFooter v příslušném rozsahu (normální snímky, rozvržení, hlavní šablona, poznámky/výlohy) k zapnutí nebo vypnutí těchto zástupců a k nastavení jejich obsahu.