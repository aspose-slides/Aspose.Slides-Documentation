---
title: Přidání čárových tvarů do prezentací v .NET
linktitle: Čára
type: docs
weight: 50
url: /cs/net/Line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- obyčejná čára
- nastavit čáru
- přizpůsobit čáru
- styl čerchování
- hlavice šipky
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v PowerPoint prezentacích pomocí Aspose.Slides pro .NET. Objevte vlastnosti, metody a příklady."
---
## **Overview**

Aspose.Slides umožňuje programově přidávat čárové tvary do snímků PowerPointu. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak přizpůsobit čáru tak, aby vypadala jako šipka.

Dozvíte se, jak přidat čárový tvar do snímku, upravit jeho vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako jsou styl, šířka, vzor čerchování, možnosti koncových šipek a barva výplně.

## **Create a Plain Line**
Chcete-li přidat jednoduchou rovnou čáru do vybraného snímku prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí [AddAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/methods/addautoshape/index) metody, kterou poskytuje objekt Shapes.
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```c#
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{
    // Získejte první snímek
    ISlide sld = pres.Slides[0];

    // Přidejte autoshape typu čára
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Uložte PPTX na disk
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Create an Arrow-Shaped Line**
Aspose.Slides for .NET také umožňuje vývojářům nastavit některé vlastnosti čáry, aby vypadala atraktivněji. Pojďme nakonfigurovat několik vlastností čáry, aby vypadala jako šipka. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/cs/aspose.slides/)[](http://www.aspose.com/api/net/slides/cs/aspose.slides/).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí AddAutoShape metody, kterou poskytuje objekt Shapes.
- Nastavte styl čáry na jeden ze stylů nabízených Aspose.Slides pro .NET.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/net/aspose.slides/linedashstyle) čáry na jeden ze stylů nabízených Aspose.Slides pro .NET.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/net/aspose.slides/linearrowheadstyle) a délku počátečního bodu čáry.
- Nastavte styl a délku šipky koncového bodu čáry.
- Uložte upravenou prezentaci jako soubor PPTX.

```c#
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{

    // Získejte první snímek
    ISlide sld = pres.Slides[0];

    // Přidejte autoshape typu čára
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Použijte nějaké formátování na čáru
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Uložte PPTX na disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

Ne. Běžná čára (AutoShape typu Line) se automaticky nestane spojkou. Pro přichycení k objektům použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/net/aspose.slides/connector/) a [corresponding APIs](/slides/cs/net/connector/) pro připojení.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/cs/net/shape-effective-properties/) prostřednictvím rozhraní [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ilinefillformateffectivedata/) — tato již zohledňují dědičnost a styly motivu.

**Can I lock a line against editing (moving, resizing)?**

Ano. Tvary poskytují [lock objects](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/autoshapelock/), které umožňují [disallow editing operations](/slides/cs/net/applying-protection-to-presentation/).