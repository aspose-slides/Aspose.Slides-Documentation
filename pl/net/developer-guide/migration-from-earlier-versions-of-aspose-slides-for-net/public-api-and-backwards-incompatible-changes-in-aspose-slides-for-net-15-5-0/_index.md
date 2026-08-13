---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 15.5.0
linktitle: Aspose.Slides dla .NET 15.5.0
type: docs
weight: 160
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API oraz zmian łamiących kompatybilność w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) klasy, metody, własności i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides dla .NET 15.5.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Dodano klasę CommonSlideViewProperties i interfejs ICommonSlideViewProperties**
Klasa Aspose.Slides.CommonSlideViewProperties oraz interfejs Aspose.Slides.ICommonSlideViewProperties reprezentują wspólne właściwości widoku slajdu (obecnie opcje skalowania widoku).
#### **Dodano własność IAxis.LabelOffset**
Właściwość IAxis.LabelOffset określa odległość etykiet od osi. Stosowana do osi kategorii lub daty.
#### **Dodano własność IChartTextBlockFormat.AutofitType**
Zmiana tej własności może wywołać pewien wpływ tylko na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2013; w PowerPoint 2007 nie ma efektu przy renderowaniu).
#### **Dodano własność IChartTextBlockFormat.WrapText**
Zmiana tej własności może wywołać pewien wpływ tylko na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2007/2013).
#### **Dodano właściwości marginesu do IChartTextBlockFormat**
Zmiana tych właściwości może wywołać pewien wpływ tylko na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2013; w PowerPoint 2007 nie ma efektu przy renderowaniu).
#### **Dodano własność ViewProperties.NotesViewProperties**
Właściwość Aspose.Slides.ViewProperties.NotesViewProperties została dodana. Określa ona wspólne właściwości widoku powiązane z trybem widoku notatek.
#### **Dodano własność ViewProperties.SlideViewProperties**
Właściwość Aspose.Slides.ViewProperties.SlideViewProperties została dodana. Określa ona wspólne właściwości widoku powiązane z trybem widoku slajdu.