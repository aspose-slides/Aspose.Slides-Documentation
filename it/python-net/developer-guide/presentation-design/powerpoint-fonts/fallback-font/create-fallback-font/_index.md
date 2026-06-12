---
title: Specifica i caratteri di riserva per le presentazioni in Python
linktitle: Carattere di riserva
type: docs
weight: 10
url: /it/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Gestisci Aspose.Slides per Python tramite .NET per impostare i caratteri di riserva nei file PPT, PPTX e ODP, garantendo una visualizzazione del testo coerente su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri di riserva per il rendering e le operazioni di esportazione delle presentazioni. I caratteri di riserva vengono utilizzati quando il carattere principale non contiene glifi per determinati caratteri.

Il comportamento di riserva è configurato tramite regole di riserva. Ogni regola associa un intervallo Unicode a uno o più caratteri che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere caratteri di riserva dalle regole esistenti e organizzare più regole in una raccolta di regole di caratteri di riserva.

Le regole di riserva sono impostazioni di rendering in fase di esecuzione. Non modificano il file della presentazione stesso e non vengono memorizzate all'interno del file PPTX.

## **Specificare i caratteri di riserva**

Aspose.Slides supporta la classe [FontFallBackRule](https://reference.aspose.com/slides/it/python-net/aspose.slides/FontFallBackRule/) per specificare le regole da applicare a un carattere di riserva. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/python-net/aspose.slides/FontFallBackRule/) rappresenta un'associazione tra l'intervallo Unicode specificato, usato per cercare i glifi mancanti, e un elenco di caratteri che possono contenere i glifi appropriati:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Usando più modi è possibile aggiungere l'elenco dei caratteri:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

È anche possibile [remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontfallbackrule/remove/) il carattere di riserva o [add_fall_back_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/python-net/aspose.slides/FontFallBackRule/) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontfallbackrulescollection/) può essere usata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/python-net/aspose.slides/FontFallBackRule/), quando è necessario specificare regole di sostituzione dei caratteri di riserva per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Crea raccolta di caratteri di riserva](/slides/it/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un carattere di riserva, la sostituzione dei caratteri e l'incorporamento dei caratteri?**

Un carattere di riserva viene utilizzato solo per i caratteri mancanti nel carattere principale. [Font substitution](/slides/it/python-net/font-substitution/) sostituisce l'intero carattere specificato con un altro carattere. [Font embedding](/slides/it/python-net/embedded-font/) inserisce i caratteri all'interno del file di output affinché i destinatari possano visualizzare il testo come previsto.

**I caratteri di riserva vengono applicati durante le esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. La riserva influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/python-net/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel carattere di origine.

**La configurazione della riserva modifica il file della presentazione stesso e l'impostazione persisterà per aperture future?**

No. Le regole di riserva sono impostazioni di rendering in fase di esecuzione nel tuo codice; non vengono memorizzate all'interno del .pptx e non compariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l'insieme delle directory dei caratteri influenzano la selezione della riserva?**

Sì. Il motore risolve i caratteri dalle cartelle di sistema disponibili e da qualsiasi [percorsi aggiuntivi](/slides/it/python-net/custom-font/) forniti. Se un carattere non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

**La riserva funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, lo stesso meccanismo di sostituzione dei glifi viene applicato per renderizzare i caratteri mancanti.