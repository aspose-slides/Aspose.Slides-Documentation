---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 15.1.0
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
description: "Revisiona gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [added](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), eventuali nuove restrizioni e altre [changes](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introdotte con l'API Aspose.Slides for Java 15.1.0.
{{% /alert %}} {{% alert color="info" %}} 
Sono noti problemi con alcuni punti elenco immagine e oggetti WordArt che saranno corretti in Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Modifiche API pubbliche**
### **È stata aggiunta la funzionalità di sostituzione dei caratteri**
È stata aggiunta la possibilità di sostituire i caratteri globalmente in tutta la presentazione e temporaneamente durante il rendering.

È stato introdotto il nuovo metodo getFontsManager() della classe Presentation. La classe FontsManager dispone dei seguenti membri:

**IFontSubstRuleCollection getFontSubstRuleList**() method  
Questo è la raccolta di istanze IFontSubstRule utilizzate per sostituire i caratteri durante il rendering. IFontSubstRule dispone dei metodi getSourceFont() e getDestFont() che implementano l'interfaccia IFontData e del metodo getReplaceFontCondition() che consente di scegliere la condizione di sostituzione ("WhenInaccessible" o "Always").

**IFontData[] getFonts**() method can be used to retrieve all fonts used in the current presentation.

**replaceFont(...)** methods can be used to persistently replace a font in a presentation.  

The following example shows how to replace a font in a presentation:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Another example, shows font substitution for rendering when it is inaccessible:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Il font Arial verrà usato al posto di SomeRareFont quando è inaccessibile.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```