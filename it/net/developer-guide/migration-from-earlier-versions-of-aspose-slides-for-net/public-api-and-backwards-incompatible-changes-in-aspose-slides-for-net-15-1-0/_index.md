---
title: API pubbliche e modifiche incompatibili in retrocompatibilità in Aspose.Slides per .NET 15.1.0
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) o [rimosso](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/), nonché le altre modifiche introdotte con l'API Aspose.Slides per .NET 15.1.0.

{{% /alert %}} 
## **Modifiche API pubbliche**
#### **È stata aggiunta la funzionalità di sostituzione dei font**
È stata aggiunta la possibilità di sostituire i font a livello globale nella presentazione e temporaneamente durante il rendering.

È stata introdotta la nuova proprietà "FontsManager" della classe Presentation. La classe FontsManager dispone dei seguenti membri:

**IFontSubstRuleCollection FontSubstRuleList** Property

Questa collezione di istanze IFontSubstRule viene utilizzata per sostituire i font durante il rendering. IFontSubstRule possiede le proprietà SourceFont e DestFont che implementano l'interfaccia IFontData e la proprietà ReplaceFontCondition che consente di scegliere la condizione di sostituzione ("WhenInaccessible" o "Always").

**IFontData[] GetFonts()** Method

Utilizzato per recuperare tutti i font utilizzati nella presentazione corrente.

**ReplaceFont** Methods

Utilizzati per sostituire in modo permanente un font nella presentazione.

L'esempio seguente mostra come sostituire un font nella presentazione:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Un altro esempio dimostra la sostituzione dei font per il rendering quando il font è inaccessibile:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Il font Arial sarà usato al posto di SomeRareFont quando è inaccessibile

            pres.Slides[0].GetImage();

```