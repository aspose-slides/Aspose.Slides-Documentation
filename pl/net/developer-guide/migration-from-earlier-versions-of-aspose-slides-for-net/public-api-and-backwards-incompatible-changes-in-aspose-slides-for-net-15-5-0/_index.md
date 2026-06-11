---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 15.5.0
linktitle: Aspose.Slides dla .NET 15.5.0
type: docs
weight: 160
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- migracja
- kod przestarzały
- nowoczesny kod
- przestarzałe podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) klasy, metody, właściwości itp., oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.5.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Klasa CommonSlideViewProperties i interfejs ICommonSlideViewProperties zostały dodane**
Klasa Aspose.Slides.CommonSlideViewProperties oraz interfejs Aspose.Slides.ICommonSlideViewProperties reprezentują wspólne właściwości widoku slajdu (obecnie opcje skalowania widoku).
#### **Właściwość IAxis.LabelOffset została dodana**
Właściwość IAxis.LabelOffset określa odległość etykiet od osi. Stosowana do osi kategorialnej lub datowej.
#### **Właściwość IChartTextBlockFormat.AutofitType została dodana**
Zmiana tej właściwości może mieć wpływ tylko na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2013; w PowerPoint 2007 nie ma efektu przy renderowaniu).
#### **Właściwość IChartTextBlockFormat.WrapText została dodana**
Zmiana tej właściwości może mieć wpływ tylko na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2007/2013).
#### **Właściwości marginesu zostały dodane do IChartTextBlockFormat**
Zmiana tych właściwości może mieć wpływ tylko na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2013; w PowerPoint 2007 nie ma efektu przy renderowaniu).
#### **Właściwość ViewProperties.NotesViewProperties została dodana**
Dodano właściwość Aspose.Slides.ViewProperties.NotesViewProperties. Określa ona wspólne właściwości widoku powiązane z trybem widoku notatek.
#### **Właściwość ViewProperties.SlideViewProperties została dodana**
Dodano właściwość Aspose.Slides.ViewProperties.SlideViewProperties. Określa ona wspólne właściwości widoku powiązane z trybem widoku slajdu.