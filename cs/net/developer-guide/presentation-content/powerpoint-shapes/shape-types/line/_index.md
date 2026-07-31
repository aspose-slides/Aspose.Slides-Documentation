---
title: Přidání tvarů čar do prezentací v .NET
linktitle: Čára
type: docs
weight: 50
url: /cs/net/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- prostá čára
- konfigurovat čáru
- přizpůsobit čáru
- styl čáry
- hlavice šipky
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides pro .NET. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat tvary čar do snímků PowerPoint. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji upravit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat tvar čáry do snímku, upravit jeho vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako jsou styl, šířka, vzor čerchování, možnosti šípek a barva výplně.

## **Vytvoření prosté čáry**
- Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) třídy.
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [AddAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/methods/addautoshape/index), která je vystavena objektem Shapes.
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```c#
 // Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
 using (Presentation pres = new Presentation())
 {
     // Získejte první snímek
     ISlide sld = pres.Slides[0];

     // Přidejte autoshape typu čára
     sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

     //Uložte soubor PPTX na disk
     pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
 }
```

## **Vytvoření čáry se šipkou**
Aspose.Slides pro .NET také umožňuje vývojářům nakonfigurovat některé vlastnosti čáry, aby vypadala přitažlivěji. Zkusme nakonfigurovat několik vlastností čáry, aby vypadala jako šipka. Postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/cs/aspose.slides/)[](http://www.aspose.com/api/net/slides/cs/aspose.slides/).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je vystavena objektem Shapes.
- Nastavte styl čáry na jeden ze stylů nabízených Aspose.Slides pro .NET.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/net/aspose.slides/linedashstyle) čáry na jeden ze stylů nabízených Aspose.Slides pro .NET.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/net/aspose.slides/linearrowheadstyle) a délku počátečního bodu čáry.
- Nastavte styl šipky a délku koncového bodu čáry.
- Zapište upravenou prezentaci jako soubor PPTX.

```c#
 // Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{

    // Získejte první snímek
    ISlide sld = pres.Slides[0];

    // Přidejte autoshape typu čára
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplikujte určité formátování na čáru
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Uložte soubor PPTX na disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu převést běžnou čáru na konektor, aby se "přichytával" k tvarům?**

Ne. Běžná čára ( [AutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/net/aspose.slides/shapetype/)) se automaticky nepřemění na konektor. Pro přichytávání k tvarům použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/net/aspose.slides/connector/) a [odpovídající API](/slides/cs/net/connector/) pro spojení.

**Co mám dělat, pokud jsou vlastnosti čáry děděny z motivu a je obtížné určit konečné hodnoty?**

[Přečtěte si efektivní vlastnosti](/slides/cs/net/shape-effective-properties/) pomocí rozhraní [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ilinefillformateffectivedata/) — tato již zohledňují dědičnost a styly motivu.

**Mohu zablokovat čáru proti úpravám (přesouvání, změna velikosti)?**

Ano. Tvary poskytují [objekty zamykání](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/autoshapelock/), které umožňují [zakázat editační operace](/slides/cs/net/applying-protection-to-presentation/).