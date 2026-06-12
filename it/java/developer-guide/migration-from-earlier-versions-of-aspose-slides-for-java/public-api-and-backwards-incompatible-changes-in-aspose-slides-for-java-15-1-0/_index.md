---
title: API pubbliche e modifiche retroattive incompatibili in Aspose.Slides per Java 15.1.0
linktitle: Aspose.Slides per Java 15.1.0
type: docs
weight: 100
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [added](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), eventuali nuove restrizioni e altre [changes](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introdotte con l'API Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Sono noti problemi con alcuni punti elenco immagine e oggetti WordArt che saranno corretti in Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **È stata aggiunta la funzionalità di sostituzione dei font**
È stata aggiunta la possibilità di sostituire i font a livello globale nella presentazione e temporaneamente durante il rendering.

È stato introdotto il nuovo metodo getFontsManager() della classe Presentation. La classe FontsManager ha i seguenti membri:

**IFontSubstRuleCollection getFontSubstRuleList**() method

Questa è la raccolta di istanze IFontSubstRule utilizzate per sostituire i font durante il rendering. IFontSubstRule dispone dei metodi getSourceFont() e getDestFont() che implementano l'interfaccia IFontData e del metodo getReplaceFontCondition() che consente di scegliere la condizione di sostituzione (“WhenInaccessible” o “Always”).

**IFontData[] getFonts()** method può essere usato per recuperare tutti i font utilizzati nella presentazione corrente.

**replaceFont(...)** methods possono essere usati per sostituire in modo persistente un font in una presentazione. 

Il seguente esempio mostra come sostituire un font in una presentazione:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Un altro esempio mostra la sostituzione dei font per il rendering quando il font non è accessibile:

``` java


Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Il font Arial verrà utilizzato al posto di SomeRareFont quando non è accessibile

pres.getSlides().get_Item(0).getThumbnail(1, 1);
```