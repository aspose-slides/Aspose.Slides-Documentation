---
title: Configura raccolte di font di fallback in Python
linktitle: Raccolta di Font di Fallback
type: docs
weight: 20
url: /it/python-net/create-fallback-fonts-collection/
keywords:
- font di fallback
- regola di fallback
- raccolta di font
- configura font
- imposta font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Configura una raccolta di font di fallback in Aspose.Slides per Python tramite .NET per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di font di fallback per una presentazione. Ogni regola di fallback è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`.

Dopo aver creato la raccolta, è possibile assegnarla alla proprietà `font_fall_back_rules_collection` del `fonts_manager` della presentazione. Il `fonts_manager` controlla i font dell'intera presentazione e ogni istanza di `Presentation` ha il proprio `FontsManager`.

Una volta che il `FontsManager` è inizializzato con la raccolta di font di fallback, i font di fallback specificati vengono applicati durante il rendering della presentazione.

## **Applica Regole di Fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/python-net/aspose.slides/FontFallBackRule/) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontfallbackrulescollection/). È possibile aggiungere o rimuovere regole dalla raccolta.

Questa raccolta può quindi essere assegnata alla proprietà [font_fall_back_rules_collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) della classe [FontsManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/). FontsManager controlla i font dell'intera presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) dispone di una proprietà [fonts_manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/fonts_manager/) con la propria istanza della classe FontsManager.

Ecco un esempio su come creare una raccolta di regole di font di fallback e assegnarla al FontsManager di una determinata presentazione:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Dopo che FontsManager è stato inizializzato con la raccolta di font di fallback, i font di fallback vengono applicati durante il rendering della presentazione.

{{% alert color="primary" %}} 
Leggi di più su come [Renderizzare la Presentazione con Font di Fallback](/slides/it/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Le mie regole di fallback verranno incorporate nel file PPTX e saranno visibili in PowerPoint dopo il salvataggio?**

No. Le regole di fallback sono impostazioni di rendering a runtime; non vengono serializzate nel PPTX e non appariranno nell'interfaccia di PowerPoint.

**Il fallback si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?**

Sì. Lo stesso meccanismo di sostituzione dei glifi viene utilizzato per qualsiasi testo in questi oggetti.

**Aspose distribuisce font con la libreria?**

No. Aggiungi e utilizzi i font da parte tua, sotto tua responsabilità.

**È possibile utilizzare insieme la sostituzione per i font mancanti e il fallback per i glifi mancanti?**

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei font: prima il motore verifica la disponibilità dei font ([replacement](/slides/it/python-net/font-replacement/)/[substitution](/slides/it/python-net/font-substitution/)), poi il fallback colma le lacune per i glifi mancanti nei font disponibili.