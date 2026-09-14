---
title: Specifica i font di riserva per le presentazioni in Python tramite Java
linktitle: Font di riserva
type: docs
weight: 10
url: /it/python-java/create-fallback-font/
keywords:
- font di riserva
- regola di riserva
- applicare font
- sostituire font
- intervallo Unicode
- glifo mancante
- glifo corretto
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Domina Aspose.Slides per Python tramite Java per impostare i font di riserva nei file PPT, PPTX e ODP, garantendo una visualizzazione del testo coerente su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i font di riserva per il rendering e le operazioni di esportazione delle presentazioni. I font di riserva vengono utilizzati quando il font principale non contiene glifi per caratteri particolari.

Il comportamento di ripiego viene configurato tramite regole di ripiego. Ogni regola associa un intervallo Unicode a uno o più font che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere font di riserva dalle regole esistenti e organizzare più regole in una raccolta di regole dei font di riserva.

Le regole di ripiego sono impostazioni di rendering a runtime. Non modificano il file della presentazione stesso e non vengono memorizzate all’interno del file PPTX.

## **Regole di ripiego**

Aspose.Slides fornisce la classe [FontFallBackRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/) per specificare le regole di applicazione dei font di riserva. Questa classe rappresenta un'associazione tra un intervallo Unicode usato per cercare i glifi mancanti e un elenco di font che possono contenere i glifi richiesti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Usa più modi per specificare un elenco di font.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

È inoltre possibile rimuovere un font di riserva utilizzando [remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/#remove) o aggiungere font di riserva con [addFallBackFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrulescollection/) può organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/) quando è necessario specificare regole di sostituzione dei font di riserva per più intervalli Unicode.

{{% alert color="info" title="See also" %}} 
- [Crea raccolta di font di riserva](/slides/it/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un font di riserva, la sostituzione di font e l'incorporamento di font?**

Un font di riserva viene utilizzato solo per i caratteri mancanti nel font principale. [Font substitution](/slides/it/python-java/font-substitution/) sostituisce l'intero font specificato con un altro font. [Font embedding](/slides/it/python-java/embedded-font/) inserisce i font all'interno del file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I font di riserva vengono applicati durante le esportazioni come PDF, PNG o SVG, oppure solo durante il rendering a schermo?**

Sì. Il ripiego influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/python-java/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel font di origine.

**La configurazione del ripiego modifica il file della presentazione stesso e l'impostazione persisterà per le aperture future?**

No. Le regole di ripiego sono impostazioni di rendering a runtime nel tuo codice; non vengono memorizzate all'interno del .pptx e non compariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l'insieme delle directory dei font influenzano la selezione del ripiego?**

Sì. Il motore risolve i font dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/python-java/custom-font/) forniti. Se un font non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

**Il ripiego funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, viene applicato lo stesso meccanismo di sostituzione dei glifi per visualizzare i caratteri mancanti.