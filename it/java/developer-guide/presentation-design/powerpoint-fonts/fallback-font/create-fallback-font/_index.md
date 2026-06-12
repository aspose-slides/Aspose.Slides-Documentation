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
description: "Padroneggia Aspose.Slides per Java per impostare i font di fallback nei file PPT, PPTX e ODP, garantendo una visualizzazione coerente del testo su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i font di fallback per il rendering e le operazioni di esportazione delle presentazioni. I font di fallback vengono utilizzati quando il font principale non contiene glifi per caratteri particolari.

Il comportamento di fallback viene configurato tramite regole di fallback. Ogni regola associa un intervallo Unicode a uno o più font che possono contenere i glifi necessari. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere font di fallback dalle regole esistenti e organizzare più regole in una raccolta di regole di font di fallback.

Le regole di fallback sono impostazioni di rendering a runtime. Non modificano il file della presentazione stesso e non vengono memorizzate all'interno del file PPTX.

## **Regole di fallback**

Aspose.Slides supporta l'interfaccia [IFontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/IFontFallBackRule) e la classe [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) per specificare le regole da applicare a un font di fallback. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) rappresenta un'associazione tra l'intervallo Unicode specificato, utilizzato per cercare i glifi mancanti, e un elenco di font che possono contenere i glifi corretti:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Utilizzando diversi metodi è possibile aggiungere l'elenco dei font:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

È anche possibile [remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) il font di fallback o [addFallBackFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRulesCollection) può essere utilizzata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule), quando è necessario specificare regole di sostituzione dei font di fallback per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Crea raccolta di font di fallback](/slides/it/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un font di fallback, la sostituzione del font e l'incorporamento del font?**

Un font di fallback viene utilizzato solo per i caratteri mancanti nel font principale. La [sostituzione del font](/slides/it/java/font-substitution/) sostituisce l'intero font specificato con un altro font. L'[incorporamento del font](/slides/it/java/embedded-font/) inserisce i font all'interno del file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I font di fallback vengono applicati durante le esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. Il fallback influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/java/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel font di origine.

**La configurazione del fallback modifica il file della presentazione stesso e l'impostazione persisterà per le aperture future?**

No. Le regole di fallback sono impostazioni di rendering a runtime nel tuo codice; non vengono memorizzate all'interno del .pptx e non compariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l'insieme delle directory dei font influiscono sulla selezione del fallback?**

Sì. Il motore risolve i font dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/java/custom-font/) forniti. Se un font non è fisicamente disponibile, una regola che lo richiama non può avere effetto.

**Il fallback funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, lo stesso meccanismo di sostituzione dei glifi viene applicato per renderizzare i caratteri mancanti.