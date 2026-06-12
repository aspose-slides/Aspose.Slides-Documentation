---
title: Specificare i font di riserva per le presentazioni in PHP
linktitle: Font di riserva
type: docs
weight: 10
url: /it/php-java/create-fallback-font/
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
- PHP
- Aspose.Slides
description: "Gestisci Aspose.Slides per PHP tramite Java per impostare i font di riserva nei file PPT, PPTX e ODP, garantendo una visualizzazione coerente del testo su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare font di riserva per il rendering e le operazioni di esportazione delle presentazioni. I font di riserva vengono utilizzati quando il font principale non contiene glifi per caratteri particolari.

Il comportamento di riserva è configurato tramite regole di riserva. Ogni regola associa un intervallo Unicode a uno o più font che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere font di riserva dalle regole esistenti e organizzare più regole in una raccolta di regole di font di riserva.

Le regole di riserva sono impostazioni di rendering a runtime. Non modificano il file della presentazione stesso e non vengono archiviate all’interno del file PPTX.

## **Regole di riserva**

Aspose.Slides supporta la classe [FontFallBackRule](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRule) per specificare le regole da applicare a un font di riserva. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRule) rappresenta un’associazione tra l’intervallo Unicode specificato, usato per cercare i glifi mancanti, e un elenco di font che possono contenere i glifi corretti:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Usando più modi è possibile aggiungere l'elenco dei font:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

È anche possibile [remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontfallbackrule/remove/) un font di riserva o [addFallBackFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRule) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRulesCollection) può essere usata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRule), quando è necessario specificare regole di sostituzione di font di riserva per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Create Fallback Fonts Collection](/slides/it/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un font di riserva, la sostituzione del font e l’incorporamento del font?**

Un font di riserva viene utilizzato solo per i caratteri mancanti nel font principale. La [sostituzione del font](/slides/it/php-java/font-substitution/) sostituisce l’intero font specificato con un altro font. L’[incorporamento del font](/slides/it/php-java/embedded-font/) inserisce i font nel file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I font di riserva vengono applicati durante le esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. La riserva influisce su tutte le [operazioni di rendering e esportazione](/slides/it/php-java/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel font di origine.

**La configurazione della riserva modifica il file della presentazione stesso e l’impostazione persiste per aperture future?**

No. Le regole di riserva sono impostazioni di rendering a runtime nel tuo codice; non sono archiviate all’interno del .pptx e non appariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e il set di cartelle dei font influiscono sulla selezione della riserva?**

Sì. Il motore risolve i font dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/php-java/custom-font/) forniti. Se un font non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

**La riserva funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, viene applicato lo stesso meccanismo di sostituzione dei glifi per rendere i caratteri mancanti.