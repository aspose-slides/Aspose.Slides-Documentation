---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 15.1.0
linktitle: Aspose.Slides per .NET 15.1.0
type: docs
weight: 130
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Rivedi gli aggiornamenti delle API pubbliche e le modifiche breaking in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}}
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) o [rimosse](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/), e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.1.0.
{{% /alert %}}
## **Modifiche API Pubbliche**
#### **È stata aggiunta la funzionalità di sostituzione dei font**
È stata aggiunta la possibilità di sostituire i font a livello globale in tutta la presentazione e temporaneamente per il rendering.

È stata introdotta la nuova proprietà "FontsManager" della classe Presentation. La classe FontsManager ha i seguenti membri:

**IFontSubstRuleCollection FontSubstRuleList** Property

Questa raccolta di istanze IFontSubstRule viene utilizzata per sostituire i font durante il rendering. IFontSubstRule ha le proprietà SourceFont e DestFont che implementano l'interfaccia IFontData e la proprietà ReplaceFontCondition che consente di scegliere la condizione di sostituzione ("WhenInaccessible" o "Always").

**IFontData[] GetFonts()** Method

Utilizzato per recuperare tutti i font utilizzati nella presentazione corrente.

**ReplaceFont** Methods

Utilizzato per sostituire permanentemente il font nella presentazione.

Il seguente esempio mostra come sostituire il font nella presentazione:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


```

Un altro esempio dimostra la sostituzione dei font per il rendering quando non sono accessibili:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Il font Arial sarà usato al posto di SomeRareFont quando non è accessibile

            pres.Slides[0].GetThumbnail();

```