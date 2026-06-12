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
description: "Prohlédněte si aktualizace veřejného API a breaking changes v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) nebo [odebráno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) třídy, metody, vlastnosti a další, a další změny zavedené v API Aspose.Slides pro .NET 15.5.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Třída CommonSlideViewProperties a rozhraní ICommonSlideViewProperties byly přidány**
Třída Aspose.Slides.CommonSlideViewProperties a rozhraní Aspose.Slides.ICommonSlideViewProperties představují společné vlastnosti zobrazení snímku (v současnosti možnosti měřítka zobrazení).
#### **Vlastnost IAxis.LabelOffset byla přidána**
Vlastnost IAxis.LabelOffset určuje vzdálenost popisků od osy. Používá se pro kategorické nebo časové osy.
#### **Vlastnost IChartTextBlockFormat.AutofitType byla přidána**
Změna této vlastnosti může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslování).
#### **Vlastnost IChartTextBlockFormat.WrapText byla přidána**
Změna této vlastnosti může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2007/2013).
#### **K vlastnostem IChartTextBlockFormat byly přidány vlastnosti okrajů**
Změna těchto vlastností může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslování).
#### **Vlastnost ViewProperties.NotesViewProperties byla přidána**
Byla přidána vlastnost Aspose.Slides.ViewProperties.NotesViewProperties. Udává společné vlastnosti zobrazení související s režimem zobrazení poznámek.
#### **Vlastnost ViewProperties.SlideViewProperties byla přidána**
Byla přidána vlastnost Aspose.Slides.ViewProperties.SlideViewProperties. Udává společné vlastnosti zobrazení související s režimem zobrazení snímku.