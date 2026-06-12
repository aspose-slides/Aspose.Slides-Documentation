---
title: Otevírání prezentace ve VSTO a Aspose.Slides
type: docs
weight: 120
url: /cs/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Níže je úryvek kódu pro otevření prezentace:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides pro .NET poskytuje třídu **Presentation**, která se používá k otevření existující prezentace. Nabízí několik přetížených konstruktorů a můžeme využít jeden z vhodných konstruktorů třídy **Presentation** k vytvoření jejího objektu na základě existující prezentace. V níže uvedeném příkladu jsme předali název souboru prezentace (který má být otevřen) konstruktoru třídy Presentation. Po otevření souboru získáme celkový počet snímků v prezentaci a vypíšeme jej na obrazovku.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Stáhnout spustitelný kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)