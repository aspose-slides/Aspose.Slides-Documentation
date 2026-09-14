---
title: Configura collezioni di font di fallback in Python tramite Java
linktitle: Collezione di font di fallback
type: docs
weight: 20
url: /it/python-java/create-fallback-fonts-collection/
keywords:
- font di fallback
- regola di fallback
- collezione di font
- configura font
- imposta font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Configura una collezione di font di fallback in Aspose.Slides per Python tramite Java per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di fallback dei font per una presentazione. Ogni regola di fallback è rappresentata dalla classe [FontFallBackRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/) e può essere aggiunta a una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrulescollection/).

Dopo aver creato la raccolta, è possibile assegnarla utilizzando il metodo [setFontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) della [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) della presentazione. La [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) controlla i font nell’intera presentazione e ogni istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) ha la propria [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/).

Una volta che la [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) è inizializzata con la raccolta di font di fallback, i font di fallback specificati vengono applicati durante il rendering della presentazione.

## **Applicare le regole di fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrule/) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontfallbackrulescollection/). È possibile aggiungere o rimuovere regole dalla raccolta.

Questa raccolta può quindi essere assegnata utilizzando il metodo [setFontFallBackRulesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) della classe [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/), che controlla i font nell’intera presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) possiede un metodo [getFontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getFontsManager) che restituisce la propria istanza della classe [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/).

L’esempio seguente mostra come creare una raccolta di regole di fallback dei font e assegnarla alla [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) di una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Dopo che la [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) è stata inizializzata con la raccolta di font di fallback, i font di fallback vengono applicati durante il rendering della presentazione.

{{% alert color="info" title="Note" %}}
Leggi di più su come [renderizzare una presentazione con un font di fallback](/slides/it/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Le mie regole di fallback verranno incorporate nel file PPTX e saranno visibili in PowerPoint dopo il salvataggio?**

No. Le regole di fallback sono impostazioni di rendering a runtime; non vengono serializzate nel PPTX e non appariranno nell’interfaccia di PowerPoint.

**Il fallback si applica al testo all’interno di SmartArt, WordArt, grafici e tabelle?**

Sì. Lo stesso meccanismo di sostituzione dei glifi viene utilizzato per qualsiasi testo in questi oggetti.

**Aspose distribuisce dei font con la libreria?**

No. Aggiungi e utilizzi i font dal tuo lato e sotto tua responsabilità.

**È possibile utilizzare contemporaneamente la sostituzione/ripristino per i font mancanti e il fallback per i glifi mancanti?**

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei font: prima il motore risolve la disponibilità dei font ([replacement](/slides/it/python-java/font-replacement/)/[substitution](/slides/it/python-java/font-substitution/)), poi il fallback colma le lacune dei glifi mancanti nei font disponibili.