---
title: Specificare i font di fallback per le presentazioni in C++
linktitle: Font di fallback
type: docs
weight: 10
url: /it/cpp/create-fallback-font/
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
- C++
- Aspose.Slides
description: "Gestisci Aspose.Slides per C++ per impostare i font di fallback nei file PPT, PPTX e ODP, garantendo una visualizzazione del testo coerente su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i font di fallback per il rendering e le operazioni di esportazione delle presentazioni. I font di fallback vengono utilizzati quando il font principale non contiene glifi per caratteri particolari.

Il comportamento di fallback è configurato tramite regole di fallback. Cada regola associa un intervallo Unicode a uno o più font che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere font di fallback dalle regole esistenti e organizzare più regole in una collezione di regole di font di fallback.

Le regole di fallback sono impostazioni di rendering a runtime. Non modificano il file della presentazione e non vengono memorizzate all'interno del file PPTX.

## **Regole di fallback**

Aspose.Slides supporta l'interfaccia [IFontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontfallbackrule/) e la classe [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) per specificare le regole da applicare a un font di fallback. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) rappresenta un'associazione tra l'intervallo Unicode specificato, usato per la ricerca dei glifi mancanti, e un elenco di font che possono contenere i glifi corretti:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Utilizzando più modi è possibile aggiungere l'elenco dei font:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



È inoltre possibile [Remove()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontfallbackrule/remove/) un font di fallback o [AddFallBackFonts()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrulescollection/) può essere usata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) quando è necessario specificare regole di sostituzione di font di fallback per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Create Fallback Fonts Collection](/slides/it/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Domande frequenti**

**Qual è la differenza tra un font di fallback, la sostituzione di font e l'incorporamento di font?**

Un font di fallback viene utilizzato solo per i caratteri mancanti nel font principale. La [sostituzione di font](/slides/it/cpp/font-substitution/) sostituisce l'intero font specificato con un altro font. L'[incorporamento di font](/slides/it/cpp/embedded-font/) inserisce i font all'interno del file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I font di fallback vengono applicati durante le esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. Il fallback influisce su tutte le [operazioni di rendering e esportazione](/slides/it/cpp/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel font di origine.

**La configurazione del fallback modifica il file della presentazione e l'impostazione persisterà per le aperture future?**

No. Le regole di fallback sono impostazioni di rendering a runtime nel tuo codice; non vengono salvate all'interno del .pptx e non appariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l'insieme delle directory dei font influenzano la selezione del fallback?**

Sì. Il motore risolve i font dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/cpp/custom-font/) forniti. Se un font non è fisicamente disponibile, una regola che lo cita non può avere effetto.

**Il fallback funziona per WordArt, SmartArt e diagrammi?**

Sì. Quando questi oggetti contengono testo, viene applicato lo stesso meccanismo di sostituzione dei glifi per renderizzare i caratteri mancanti.