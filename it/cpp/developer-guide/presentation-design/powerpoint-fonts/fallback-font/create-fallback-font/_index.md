---
title: Specifica caratteri di fallback per le presentazioni in C++
linktitle: Carattere di fallback
type: docs
weight: 10
url: /it/cpp/create-fallback-font/
keywords:
- carattere di fallback
- regola di fallback
- applicare carattere
- sostituire carattere
- intervallo Unicode
- glifo mancante
- glifo corretto
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Domina Aspose.Slides per C++ per impostare caratteri di fallback nei file PPT, PPTX e ODP, garantendo una visualizzazione del testo coerente su qualsiasi dispositivo o sistema operativo."
---
## **Panoramica**

Aspose.Slides consente di specificare i caratteri di fallback per il rendering delle presentazioni e le operazioni di esportazione. I caratteri di fallback vengono utilizzati quando il carattere primario non contiene glifi per determinati caratteri.

Il comportamento di fallback viene configurato tramite regole di fallback. Cada regola associa un intervallo Unicode a uno o più caratteri che possono contenere i glifi richiesti. È possibile definire regole per diversi intervalli di caratteri, aggiungere o rimuovere caratteri di fallback da regole esistenti e organizzare più regole in una raccolta di regole di caratteri di fallback.

Le regole di fallback sono impostazioni di rendering a runtime. Non modificano il file della presentazione e non sono memorizzate all'interno del file PPTX.

## **Regole di fallback**

Aspose.Slides supporta l'interfaccia [IFontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontfallbackrule/) e la classe [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) per specificare le regole da applicare a un carattere di fallback. La classe [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) rappresenta un'associazione tra l'intervallo Unicode specificato, usato per cercare i glifi mancanti, e un elenco di caratteri che possono contenere i glifi appropriati:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Usando vari modi è possibile aggiungere l'elenco dei font:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



È anche possibile [Remove()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontfallbackrule/remove/) un carattere di fallback o [AddFallBackFonts()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) in un oggetto [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) esistente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrulescollection/) può essere usata per organizzare un elenco di oggetti [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) quando è necessario specificare regole di sostituzione dei caratteri di fallback per più intervalli Unicode.

{{% alert color="primary" title="Vedi anche" %}} 
- [Crea raccolta di caratteri di fallback](/slides/it/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra un carattere di fallback, la sostituzione del carattere e l'incorporamento del carattere?**

Un carattere di fallback viene utilizzato solo per i caratteri mancanti nel carattere primario. La [sostituzione del carattere](/slides/it/cpp/font-substitution/) sostituisce l'intero carattere specificato con un altro carattere. L'[incorporamento del carattere](/slides/it/cpp/embedded-font/) inserisce i caratteri all'interno del file di output in modo che i destinatari possano visualizzare il testo come previsto.

**I caratteri di fallback vengono applicati durante esportazioni come PDF, PNG o SVG, o solo durante il rendering a schermo?**

Sì. Il fallback influisce su tutte le [operazioni di rendering ed esportazione](/slides/it/cpp/convert-presentation/) in cui i caratteri devono essere disegnati ma sono assenti nel carattere di origine.

**La configurazione del fallback modifica il file della presentazione e l'impostazione persiste per aperture future?**

No. Le regole di fallback sono impostazioni di rendering a runtime nel tuo codice; non sono memorizzate all'interno del .pptx e non appariranno in PowerPoint.

**Il sistema operativo (Windows/Linux/macOS) e l'insieme delle cartelle dei caratteri influiscono sulla selezione del fallback?**

Sì. Il motore risolve i caratteri dalle cartelle di sistema disponibili e da eventuali [percorsi aggiuntivi](/slides/it/cpp/custom-font/) forniti. Se un carattere non è fisicamente disponibile, una regola che lo fa riferimento non può avere effetto.

**Il fallback funziona per WordArt, SmartArt e grafici?**

Sì. Quando questi oggetti contengono testo, si applica lo stesso meccanismo di sostituzione dei glifi per rendere i caratteri mancanti.