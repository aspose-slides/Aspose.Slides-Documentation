---
title: Správa textových částí v prezentacích pomocí C++
linktitle: Textová část
type: docs
weight: 70
url: /cs/cpp/portion/
keywords:
- textová část
- část textu
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se spravovat textové části v prezentacích PowerPoint pomocí Aspose.Slides pro C++, což zvyšuje výkon a možnosti přizpůsobení."
---
## **Úvod**

Textová část představuje konkrétní fragment textu v odstavci a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze části použít, když potřebujete zjistit pozici textového fragmentu, použít formátování jen na část odstavce nebo řídit chování textu na podrobnější úrovni.

## **Získání souřadnic textové části**
**GetCoordinates()** metoda byla přidána do IPortion a třídy Portion, což umožňuje získat souřadnice začátku části:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **Často kladené otázky**

**Mohu přiřadit hyperodkaz pouze k části textu v jednom odstavci?**

Ano, můžete [assign a hyperlink](/slides/cs/cpp/manage-hyperlinks/) k jednotlivé části; pouze tento fragment bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylů: co přebíjí Portion a co je převzato z Paragraph/TextFrame?**

Vlastnosti na úrovni Portion mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portion/), engine ji získá z [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/); pokud není nastavena ani tam, získá ji z [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) nebo ze [theme](https://reference.aspose.com/slides/cs/cpp/aspose.slides.theme/theme/) stylu.

**Co se stane, pokud je písmo definované pro Portion na cílovém počítači/serveru nedostupné?**

Použijí se [Font substitution rules](/slides/cs/cpp/font-selection-sequence/). Text se může přetvořit: mohou se změnit metriky, dělení slov a šířka, což má vliv na přesné umístění.

**Mohu nastavit transparentnost nebo přechod výplně textu specifické pro Portion nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a transparentnost na úrovni [Portion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portion/) se mohou lišit od sousedních fragmentů.