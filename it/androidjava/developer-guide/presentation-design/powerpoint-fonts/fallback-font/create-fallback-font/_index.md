---
title: Specifica i font di fallback per le presentazioni su Android
linktitle: Font di fallback
type: docs
weight: 10
url: /it/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "Gestisci Aspose.Slides per Android tramite Java per impostare i font di fallback nei file PPT, PPTX e ODP, garantendo una visualizzazione coerente del testo su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i font di fallback per la rendering e le operazioni di esportazione delle presentazioni. I font di fallback vengono utilizzati quando il font principale non contiene i glifi per caratteri particolari.

Il comportamento di fallback è configurato tramite regole di fallback. Cada regola associa un intervallo Unicode a uno o più font che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere font di fallback dalle regole esistenti e organizzare più regole in una raccolta di regole di font di fallback.

Le regole di fallback sono impostazioni di rendering a runtime. Non modificano il file della presentazione stesso e non vengono memorizzate all’interno del file PPTX.

## **Regole di fallback**

Aspose.Slides supporta l’interfaccia [IFontFallBackRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IFontFallBackRule) e la classe [FontFallBackRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule) per specificare le regole da applicare a un font di fallback. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule) rappresenta un’associazione tra l’intervallo Unicode specificato, usato per cercare i glifi mancanti, e un elenco di font che possono contenere i glifi corretti:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Utilizzando diversi modi è possibile aggiungere un elenco di font:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

È inoltre possibile [remove](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) un font di fallback o [addFallBackFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRulesCollection) può essere utilizzata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule) quando è necessario specificare regole di sostituzione dei font di fallback per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Create Fallback Fonts Collection](/slides/it/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un font di fallback, la sostituzione dei font e l’incorporamento dei font?**

Un font di fallback viene utilizzato solo per i caratteri mancanti nel font principale. La [sostituzione dei font](/slides/it/androidjava/font-substitution/) sostituisce l’intero font specificato con un altro font. L’[incorporamento dei font](/slides/it/androidjava/embedded-font/) inserisce i font all’interno del file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I font di fallback vengono applicati durante esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. Il fallback influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/androidjava/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel font di origine.

**La configurazione del fallback modifica il file della presentazione e la impostazione persiste per le aperture future?**

No. Le regole di fallback sono impostazioni di rendering a runtime nel codice; non vengono memorizzate all’interno del .pptx e non compaiono in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l’insieme delle cartelle dei font influenzano la selezione del fallback?**

Sì. Il motore risolve i font dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/androidjava/custom-font/) forniti. Se un font non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

**Il fallback funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, si applica lo stesso meccanismo di sostituzione dei glifi per renderizzare i caratteri mancanti.