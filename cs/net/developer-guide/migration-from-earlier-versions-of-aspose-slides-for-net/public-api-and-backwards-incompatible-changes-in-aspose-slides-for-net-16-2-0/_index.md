---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 16.2.0
linktitle: Aspose.Slides pro .NET 16.2.0
type: docs
weight: 230
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a rozbití změny v Aspose.Slides pro .NET, abyste hladce migrovali řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [added](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) nebo [removed](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) třídy, metody, vlastnosti a podobně, a další změny zavedené v API Aspose.Slides pro .NET 16.2.0.

{{% /alert %}} 
## **Veřejné změny API**
#### **Vlastnosti UpdateDateTimeFields a UpdateSlideNumberFields byly odstraněny**
Vlastnosti UpdateDateTimeFields a UpdateSlideNumberFields byly odstraněny ze třídy Aspose.Slides.Presentation a z rozhraní Aspose.Slides.IPresentation.
Vlastnost Text tříd Aspose.Slides.TextFrame, Paragraph, Portion a rozhraní Aspose.Slides.ITextFrame, IParagraph, IPortion vrací text s aktualizovanými poli „datetime“.
Také vlastnosti Presentation.DocumentProperties.CreatedTime, LastSavedTime a LastPrinted se staly jen pro čtení.
#### **Výčet Slides.Charts.CategoryAxisType byl zpřístupněn veřejně**
Používá se ve vlastnostech IAxis.CategoryAxisType a Axis.CategoryAxisType k určení typu osy kategorie.
CategoryAxisType.Auto – typ osy kategorie bude určen automaticky během serializace (tento režim zatím není implementován)
CategoryAxisType.Text – typ osy kategorie je Text
CategoryAxisType.Date – typ osy kategorie je DateTime
#### **Rychlé získávání textu**
Do třídy Presentation byla přidána nová statická metoda GetPresentationText. Pro tuto metodu existují dvě přetížení:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Argument výčtu ExtractionMode určuje režim uspořádání výstupu textového výsledku a může nabývat následujících hodnot:
Unarranged – surový text bez ohledu na pozici na snímku
Arranged – text je uspořádán ve stejném pořadí jako na snímku

Režim Unarranged lze použít, když je rychlost kritická, je rychlejší než režim Arranged.

PresentationText představuje surový text extrahovaný z prezentace. Obsahuje vlastnost SlidesText z jmenného prostoru Aspose.Slides.Util, která vrací pole objektů ISlideText. Každý objekt představuje text na odpovídajícím snímku. Objekt ISlideText má následující vlastnosti:
ISlideText.Text – text na tvarech snímku
ISlideText.MasterText – text na tvarech hlavní stránky pro tento snímek
ISlideText.LayoutText – text na tvarech rozložení stránky pro tento snímek
ISlideText.NotesText – text na tvarech poznámkové stránky pro tento snímek

K dispozici je také třída SlideText, která implementuje rozhraní ISlideText.

Nové API lze použít takto:

``` csharp
using System;
using Aspose.Slides;

// Extrahujte text bez ohledu na jeho pozici na snímku (nejrychlejší režim).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Extrahujte text uspořádaný ve stejném pořadí jako na snímku.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **Rozhraní ILegacyDiagram a třída LegacyDiagram byly přidány**
Rozhraní Aspose.Slides.ILegacyDiagram a třída Aspose.Slides.LegacyDiagram byly přidány pro reprezentaci objektu legacy diagramu. Objekt legacy diagramu je starý formát diagramů z PowerPointu 97‑2003.
Nová třída poskytuje metody pro převod legacy diagramu na moderní editovatelný objekt SmartArt nebo na editovatelný GroupShape.
#### **Nový člen výčtu Aspose.Slides.TextAlignment přidán (JustifyLow)**
Byl přidán nový člen výčtu TextAlignment:
JustifyLow – nízké zarovnání Kashida.
#### **Nové vlastnosti pro Aspose.Slides.IOleObjectFrame a OleObjectFrame**
Do rozhraní IOleObjectFrame a třídy OleObjectFrame implementující toto rozhraní byly přidány nové vlastnosti. Tyto vlastnosti slouží k poskytování informací o objektu vloženém do prezentace:
EmbeddedFileExtension – vrací příponu souboru aktuálního vloženého objektu nebo prázdný řetězec, pokud objekt není odkazem
EmbeddedFileLabel – vrací název souboru vloženého OLE objektu
EmbeddedFileName – vrací cestu k vloženému OLE objektu
#### **Do tříd IAxis a Axis byla přidána nová vlastnost CategoryAxisType**
Vlastnost CategoryAxisType určuje typ osy kategorie.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **Do třídy DataLabelFormat a rozhraní IDataLabelFormat byla přidána nová vlastnost ShowLabelAsDataCallout**
Vlastnost ShowLabelAsDataCallout určuje, zda bude datový popisek grafu zobrazen jako výzva na data nebo jako datový popisek.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **Do PdfOptions a XpsOptions byla přidána vlastnost DrawSlidesFrame**
K rozhraním Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions a souvisejícím třídám Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions byla přidána boolovská vlastnost DrawSlidesFrame.
Černý rámec kolem každého snímku bude vykreslen, pokud je tato vlastnost nastavena na hodnotu true.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```