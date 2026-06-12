---
title: Configura le collezioni di font di fallback in C++
linktitle: Collezione di font di fallback
type: docs
weight: 20
url: /it/cpp/create-fallback-fonts-collection/
keywords:
- font di fallback
- regola di fallback
- collezione di font
- configurare font
- impostare font
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Configura una collezione di font di fallback in Aspose.Slides per C++ per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di font di fallback per una presentazione. Ogni regola di fallback è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`, che implementa l'interfaccia `IFontFallBackRulesCollection`.

Dopo aver creato la raccolta, è possibile assegnarla utilizzando il metodo `set_FontFallBackRulesCollection` del `FontsManager` della presentazione. Il `FontsManager` gestisce i font in tutta la presentazione e ogni istanza di `Presentation` ha il proprio `FontsManager`.

Una volta che il `FontsManager` è stato inizializzato con la raccolta di font di fallback, i font di fallback specificati vengono applicati durante il rendering della presentazione.

## **Applicare Regole di Fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrule/) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontfallbackrulescollection/), che implementa l'interfaccia [IFontFallBackRulesCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontfallbackrulescollection/). È possibile aggiungere o rimuovere regole dalla raccolta.

Questa raccolta può quindi essere passata al metodo [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) della classe [FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/). Il FontsManager controlla i font in tutta la presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) dispone di un metodo [get_FontsManager()](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_fontsmanager/) con la propria istanza della classe FontsManager.

Ecco un esempio su come creare una raccolta di regole di font di fallback e assegnarla al FontsManager di una determinata presentazione:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Dopo che il FontsManager è stato inizializzato con la raccolta di font di fallback, i font di fallback vengono applicati durante il rendering della presentazione.

{{% alert color="primary" %}} 
Leggi di più su come [Esegui il rendering della presentazione con font di fallback](/slides/it/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Domande frequenti**

**Le mie regole di fallback saranno incorporate nel file PPTX e visibili in PowerPoint dopo il salvataggio?**

No. Le regole di fallback sono impostazioni di rendering a runtime; non vengono serializzate nel PPTX e non appariranno nell'interfaccia di PowerPoint.

**Il fallback si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?**

Sì. Lo stesso meccanismo di sostituzione dei glifi viene utilizzato per qualsiasi testo in questi oggetti.

**Aspose distribuisce dei font con la libreria?**

No. Aggiungi e utilizzi i font dal tuo lato e sotto la tua responsabilità.

**È possibile utilizzare contemporaneamente la sostituzione/sostituzione di font mancanti e il fallback per glifi mancanti?**

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei font: prima il motore risolve la disponibilità dei font ([replacement](/slides/it/cpp/font-replacement/)/[substitution](/slides/it/cpp/font-substitution/)), poi il fallback colma le lacune per i glifi mancanti nei font disponibili.