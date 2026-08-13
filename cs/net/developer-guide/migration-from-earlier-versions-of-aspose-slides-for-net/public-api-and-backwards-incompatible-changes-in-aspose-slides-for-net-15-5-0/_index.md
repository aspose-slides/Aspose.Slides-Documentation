---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.5.0
linktitle: Aspose.Slides pro .NET 15.5.0
type: docs
weight: 160
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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
description: "Prohlédněte si aktualizace veřejného API a kritické změny v Aspose.Slides pro .NET a hladce migrujte svá řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) nebo [odstraněné](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 15.5.0.
{{% /alert %}} 
## **Veřejné změny API**
#### **CommonSlideViewProperties Class and ICommonSlideViewProperties Interface Have Been Added**
Třída Aspose.Slides.CommonSlideViewProperties a rozhraní Aspose.Slides.ICommonSlideViewProperties představují společné vlastnosti zobrazení snímku (v současnosti možnosti měřítka zobrazení).
#### **IAxis.LabelOffset Property Has Been Added**
Vlastnost IAxis.LabelOffset určuje vzdálenost popisků od osy. Používá se u kategoriální nebo datové osy.
#### **IChartTextBlockFormat.AutofitType Property Has Been Added**
Změna této vlastnosti může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslování).
#### **IChartTextBlockFormat.WrapText Property Has Been Added**
Změna této vlastnosti může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2007/2013).
#### **Margin Properties Have Been Added to IChartTextBlockFormat**
Změna těchto vlastností může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslování).
#### **ViewProperties.NotesViewProperties Property Has Been Added**
Byla přidána vlastnost Aspose.Slides.ViewProperties.NotesViewProperties. Určuje společné vlastnosti zobrazení související s režimem zobrazení poznámek.
#### **ViewProperties.SlideViewProperties Property Has Been Added**
Byla přidána vlastnost Aspose.Slides.ViewProperties.SlideViewProperties. Určuje společné vlastnosti zobrazení související s režimem zobrazení snímku.