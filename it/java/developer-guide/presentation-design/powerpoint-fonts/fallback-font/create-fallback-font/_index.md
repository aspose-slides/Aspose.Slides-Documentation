---
title: Specificare i font di fallback per le presentazioni in Java
linktitle: Font di fallback
type: docs
weight: 10
url: /it/java/create-fallback-font/
keywords:
- font di fallback
- regola di fallback
- applicare font
- sostituire font
- intervallo Unicode
- glifo mancante
- glifo corretto
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Domina Aspose.Slides per Java per impostare i font di fallback nei file PPT, PPTX e ODP, garantendo una visualizzazione coerente del testo su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri di fallback per il rendering e le operazioni di esportazione delle presentazioni. I caratteri di fallback vengono utilizzati quando il carattere principale non contiene glifi per determinati caratteri.

Il comportamento di fallback è configurato tramite regole di fallback. Ogni regola associa un intervallo Unicode a uno o più caratteri che potrebbero contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere caratteri di fallback dalle regole esistenti e organizzare più regole in una raccolta di regole di caratteri di fallback.

Le regole di fallback sono impostazioni di rendering a runtime. Non modificano il file della presentazione stesso e non sono memorizzate all’interno del file PPTX.

## **Regole di fallback**

Aspose.Slides supporta l’interfaccia [IFontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/IFontFallBackRule) e la classe [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) per specificare le regole da applicare a un carattere di fallback. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) rappresenta un’associazione tra l’intervallo Unicode specificato, utilizzato per la ricerca dei glifi mancanti, e un elenco di caratteri che possono contenere i glifi corretti:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Utilizzando diversi modi è possibile aggiungere l'elenco dei font:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

È anche possibile [remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) un carattere di fallback o [addFallBackFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRulesCollection) può essere utilizzata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) quando è necessario specificare regole di sostituzione dei caratteri di fallback per più intervalli Unicode.

{{% alert color="info" title="Vedi anche" %}} 
- [Crea collezione di caratteri di fallback](/slides/it/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Qual è la differenza tra un carattere di fallback, la sostituzione del carattere e l'incorporamento del carattere?

Un carattere di fallback viene utilizzato solo per i caratteri mancanti nel carattere principale. [Sostituzione del carattere](/slides/it/java/font-substitution/) sostituisce l’intero carattere specificato con un altro carattere. [Incorporamento del carattere](/slides/it/java/embedded-font/) inserisce i caratteri nel file di output in modo che i destinatari possano visualizzare il testo come previsto.

### I caratteri di fallback vengono applicati durante esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?

Sì. Il fallback influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/java/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel carattere di origine.

### La configurazione del fallback modifica il file della presentazione stesso e l’impostazione persisterà per le aperture future?

No. Le regole di fallback sono impostazioni di rendering a runtime nel tuo codice; non sono memorizzate all’interno del .pptx e non compariranno in PowerPoint.

### Il sistema operativo (Windows/Linux/macOS) e l’insieme delle cartelle dei caratteri influenzano la selezione del fallback?

Sì. Il motore risolve i caratteri dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/java/custom-font/) forniti. Se un carattere non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

### Il fallback funziona per WordArt, SmartArt e grafici?

Sì. Quando questi oggetti contengono testo, si applica lo stesso meccanismo di sostituzione dei glifi per rendere i caratteri mancanti.