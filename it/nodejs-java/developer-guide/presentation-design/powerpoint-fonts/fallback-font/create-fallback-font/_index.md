---
title: Specifica caratteri di riserva per le presentazioni in JavaScript
linktitle: Carattere di riserva
type: docs
weight: 10
url: /it/nodejs-java/create-fallback-font/
keywords:
- carattere di riserva
- regola di riserva
- applicare carattere
- sostituire carattere
- intervallo Unicode
- glifo mancante
- glifo corretto
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Guida completa a Aspose.Slides per Node.js per impostare i caratteri di riserva nei file PPT, PPTX e ODP in JavaScript, garantendo la visualizzazione coerente del testo su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri di riserva per il rendering delle presentazioni e le operazioni di esportazione. I caratteri di riserva vengono utilizzati quando il carattere principale non contiene glifi per determinati caratteri.

Il comportamento di riserva è configurato tramite regole di riserva. Ogni regola associa un intervallo Unicode a uno o più caratteri che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere caratteri di riserva dalle regole esistenti e organizzare più regole in una raccolta di regole per i caratteri di riserva.

Le regole di riserva sono impostazioni di rendering a runtime. Non modificano il file della presentazione e non vengono memorizzate all'interno del file PPTX.

## **Regole di riserva**

Aspose.Slides supporta la classe [FontFallBackRule](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule) e la classe [FontFallBackRule](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule) per specificare le regole da applicare a un carattere di riserva. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule) rappresenta un'associazione tra l'intervallo Unicode specificato, utilizzato per cercare i glifi mancanti, e un elenco di caratteri che possono contenere i glifi corretti:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Utilizzando più modi è possibile aggiungere l'elenco dei caratteri:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

È inoltre possibile [rimuovere](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) il carattere di riserva o [addFallBackFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule) esistente.

La classe [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRulesCollection) può essere utilizzata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule), quando è necessario specificare regole di sostituzione dei caratteri di riserva per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Crea una collezione di caratteri di riserva](/slides/it/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un carattere di riserva, la sostituzione del carattere e l'incorporamento del carattere?**

Un carattere di riserva viene utilizzato solo per i caratteri mancanti nel carattere principale. La [Sostituzione del carattere](/slides/it/nodejs-java/font-substitution/) sostituisce l'intero carattere specificato con un altro carattere. L’[Incorporamento del carattere](/slides/it/nodejs-java/embedded-font/) incorpora i caratteri all'interno del file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I caratteri di riserva vengono applicati durante le esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. La riserva influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/nodejs-java/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel carattere di origine.

**La configurazione della riserva modifica il file della presentazione stesso e l'impostazione persisterà per le aperture future?**

No. Le regole di riserva sono impostazioni di rendering a runtime nel tuo codice; non vengono memorizzate all'interno del .pptx e non appariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l'insieme delle cartelle dei caratteri influiscono sulla selezione della riserva?**

Sì. Il motore risolve i caratteri dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/nodejs-java/custom-font/) forniti. Se un carattere non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

**La riserva funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, lo stesso meccanismo di sostituzione dei glifi viene applicato per rendere i caratteri mancanti.