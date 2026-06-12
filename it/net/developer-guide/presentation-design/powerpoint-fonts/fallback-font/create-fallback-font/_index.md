---
title: Specificare i caratteri di riserva per le presentazioni in .NET
linktitle: Carattere di riserva
type: docs
weight: 10
url: /it/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "Usa al meglio Aspose.Slides per .NET per impostare caratteri di riserva nei file PPT, PPTX e ODP, garantendo una visualizzazione coerente del testo su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri di riserva per il rendering delle presentazioni e le operazioni di esportazione. I caratteri di riserva vengono utilizzati quando il carattere principale non contiene glifi per caratteri particolari.

Il comportamento di riserva viene configurato tramite regole di riserva. Ogni regola associa un intervallo Unicode a uno o più caratteri che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere caratteri di riserva dalle regole esistenti e organizzare più regole in una raccolta di regole di caratteri di riserva.

Le regole di riserva sono impostazioni di rendering in fase di esecuzione. Non modificano il file della presentazione stesso e non sono memorizzate all’interno del file PPTX.

## **Regole di riserva**

Aspose.Slides supporta l’interfaccia [IFontFallBackRule](https://reference.aspose.com/slides/it/net/aspose.slides/iFontFallBackRule) e la classe [FontFallBackRule](https://reference.aspose.com/slides/it/net/aspose.slides/FontFallBackRule) per specificare le regole da applicare a un carattere di riserva. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/net/aspose.slides/FontFallBackRule) rappresenta un’associazione tra l’intervallo Unicode specificato, utilizzato per la ricerca dei glifi mancanti, e un elenco di caratteri che possono contenere i glifi corretti:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Utilizzando diversi modi è possibile aggiungere l'elenco dei font:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

È anche possibile [Remove()](https://reference.aspose.com/slides/it/net/aspose.slides/ifontfallbackrule/methods/remove) un carattere di riserva o [AddFallBackFonts()](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) all’interno di un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/net/aspose.slides/FontFallBackRule) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrulescollection) può essere usata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/net/aspose.slides/FontFallBackRule), quando è necessario specificare regole di sostituzione dei caratteri di riserva per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Crea collezione di caratteri di riserva](/slides/it/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un carattere di riserva, la sostituzione dei caratteri e l'incorporamento dei caratteri?**

Un carattere di riserva viene utilizzato solo per i caratteri mancanti nel carattere principale. La [sostituzione dei caratteri](/slides/it/net/font-substitution/) sostituisce l’intero carattere specificato con un altro carattere. L'[incorporamento dei caratteri](/slides/it/net/embedded-font/) inserisce i caratteri nel file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I caratteri di riserva vengono applicati durante le esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. La riserva influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/net/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel carattere di origine.

**La configurazione della riserva modifica il file della presentazione stesso e l’impostazione persisterà per le future aperture?**

No. Le regole di riserva sono impostazioni di rendering in fase di esecuzione nel tuo codice; non vengono memorizzate all’interno del .pptx e non appariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l’insieme delle cartelle dei caratteri influenzano la selezione della riserva?**

Sì. Il motore risolve i caratteri dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/net/custom-font/) forniti. Se un carattere non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

**La riserva funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, lo stesso meccanismo di sostituzione dei glifi viene applicato per renderizzare i caratteri mancanti.