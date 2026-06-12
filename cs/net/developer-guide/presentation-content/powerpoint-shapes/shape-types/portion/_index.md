---
title: Správa textových úseků v prezentacích v .NET
linktitle: Textový úsek
type: docs
weight: 70
url: /cs/net/portion/
keywords:
- textový úsek
- textová část
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak spravovat textové úseky v prezentacích PowerPoint pomocí Aspose.Slides pro .NET, což zvyšuje výkon a možnosti přizpůsobení."
---
## **Přehled**

Textový úsek představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete zjistit polohu textového fragmentu, použít formátování jen na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat souřadnice začátku úseku pomocí metody `GetCoordinates()`. Také zdůrazňuje běžné scénáře související s úseky, jako je přiřazení hypertextového odkazu k jednotlivému textovému fragmentu, pochopení, jak se formátování řeší skrze úsek, odstavec, textový rámec a dědictví motivu, a jak se zachovat, když je požadované písmo nedostupné. Navíc uvádí, že výplň textu, barva a průhlednost mohou být nastaveny odlišně pro jednotlivé úseky ve stejném odstavci.

## **Získání souřadnic úseku textu**
Metoda **GetCoordinates()** byla přidána do rozhraní IPortion a třídy Portion, což umožňuje získat souřadnice začátku úseku:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **Časté dotazy**

**Mohu přiřadit hypertextový odkaz jen k části textu v jednom odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/net/manage-hyperlinks/) k jednotlivému úseku; pouze tento fragment bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylů: co přepisuje úsek a co je převzato z odstavce/textového rámce?**

Vlastnosti na úrovni úseku mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Úseku](https://reference.aspose.com/slides/cs/net/aspose.slides/portion/), engine ji převezme z [Odstavce](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/); pokud není nastavena ani tam, převzala se z [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) nebo ze [stylu motivu](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/theme/).

**Co se stane, když je písmo určené pro úsek na cílovém počítači/serveru nedostupné?**

Použijí se [pravidla nahrazování písem](/slides/cs/net/font-selection-sequence/). Text se může přeformátovat: mohou se změnit metriky, dělení slov a šířka, což má význam pro přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo gradient specifický pro úsek nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Úseku](https://reference.aspose.com/slides/cs/net/aspose.slides/portion/) mohou být odlišné od sousedních fragmentů.