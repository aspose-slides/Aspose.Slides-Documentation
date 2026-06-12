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
description: "Prozkoumejte aktualizace veřejného API a narušující změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) nebo [odebrané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) třídy, metody, vlastnosti a tak dále a další změny zavedené v API Aspose.Slides pro .NET 16.2.0 API.

{{% /alert %}} 
## **Změny veřejného API**
#### **Vlastnosti UpdateDateTimeFields a UpdateSlideNumberFields byly odstraněny**
Vlastnosti UpdateDateTimeFields a UpdateSlideNumberFields byly odstraněny ze třídy Aspose.Slides.Presentation a z rozhraní Aspose.Slides.IPresentation.
Vlastnost Text tříd Aspose.Slides.TextFrame, Paragraph, Portion a rozhraní Aspose.Slides.ITextFrame, IParagraph, IPortion vrací text s aktualizovanými polemi „datetime“.
Také vlastnosti Presentation.DocumentProperties.CreatedTime, LastSavedTime a LastPrinted se staly jen pro čtení.
#### **Výčtový typ Slides.Charts.CategoryAxisType byl přepnut na veřejný**
Používá se ve vlastnostech IAxis.CategoryAxisType a Axis.CategoryAxisType k určení typu kategoriové osy.
CategoryAxisType.Auto – typ kategoriové osy bude určen automaticky během serializace (toto chování není nyní implementováno)
CategoryAxisType.Text – typ kategoriové osy je Text
CategoryAxisType.Date – typ kategoriové osy je DateTime
#### **Rychlé získávání textu**
The new static method GetPresentationText byl přidán do třídy Presentation. Existují dvě přetížení této metody:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Argument enum ExtractionMode určuje režim organizace výstupu textového výsledku a může být nastaven na následující hodnoty:
Unarranged – surový text bez ohledu na umístění na snímku
Arranged – text je uspořádán ve stejném pořadí jako na snímku

Režim Unarranged lze použít, když je rychlost kritická, je rychlejší než režim Arranged.

Třída PresentationText představuje surový text extrahovaný ze prezentace. Obsahuje vlastnost SlidesText ze jmenného prostoru Aspose.Slides.Util, která vrací pole objektů ISlideText. Každý objekt představuje text na odpovídajícím snímku. Objekt ISlideText má následující vlastnosti:
ISlideText.Text – text na tvarech snímku
ISlideText.MasterText – text na tvarech hlavního snímku pro tento snímek
ISlideText.LayoutText – text na tvarech rozložení pro tento snímek
ISlideText.NotesText – text na tvarech poznámkového listu pro tento snímek

Existuje také třída SlideText, která implementuje rozhraní ISlideText.

Nové API lze použít takto:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Rozhraní ILegacyDiagram a třída LegacyDiagram byly přidány**
Rozhraní Aspose.Slides.ILegacyDiagram a třída Aspose.Slides.LegacyDiagram byly přidány k reprezentaci objektu legacy diagramu. Objekt legacy diagramu je starý formát diagramů z PowerPointu 97–2003.
Nová třída poskytuje metody pro převod legacy diagramu na moderní editovatelný objekt SmartArt nebo na editovatelný GroupShape.
#### **Přidán nový člen enumu Aspose.Slides.TextAlignment (JustifyLow)**
Byl přidán nový člen enumu TextAlignment: JustifyLow – nízké zarovnání Kashida.
#### **Nové vlastnosti pro Aspose.Slides.IOleObjectFrame a OleObjectFrame**
Do rozhraní IOleObjectFrame a třídy OleObjectFrame, která toto rozhraní implementuje, byla přidána nová vlastnost. Tyto vlastnosti slouží k poskytování informací o objektu vloženém do prezentace:
EmbeddedFileExtension – vrací příponu souboru pro aktuální vložený objekt nebo prázdný řetězec, pokud objekt není odkazem
EmbeddedFileLabel – vrací název souboru vloženého OLE objektu
EmbeddedFileName – vrací cestu k vloženému OLE objektu
#### **Nová vlastnost CategoryAxisType byla přidána do tříd IAxis a Axis**
Vlastnost CategoryAxisType určuje typ kategoriové osy.

``` csharp

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
#### **Nová vlastnost ShowLabelAsDataCallout byla přidána do třídy DataLabelFormat a rozhraní IDataLabelFormat**
Vlastnost ShowLabelAsDataCallout určuje, zda bude datová popiska specifikovaného grafu zobrazena jako datový výkřik nebo jako datová popiska.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **Vlastnost DrawSlidesFrame byla přidána do PdfOptions a XpsOptions**
Byla přidána booleovská vlastnost DrawSlidesFrame do rozhraní Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions a souvisejících tříd Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions. Černý rámec kolem každého snímku bude vykreslen, pokud je tato vlastnost nastavena na 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```