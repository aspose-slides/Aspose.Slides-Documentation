---
title: Configurare le collezioni di font di riserva in JavaScript
linktitle: Collezione di Font di Riserva
type: docs
weight: 20
url: /it/nodejs-java/create-fallback-fonts-collection/
keywords:
- font di riserva
- regola di riserva
- collezione di font
- configurare il font
- impostare il font
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Configura una collezione di font di riserva in JavaScript con Aspose.Slides per Node.js per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di font di ripiego per una presentazione. Ogni regola di ripiego è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`.

Dopo aver creato la raccolta, è possibile assegnarla utilizzando il metodo `setFontFallBackRulesCollection` del `FontsManager` della presentazione. Il `FontsManager` gestisce i font in tutta la presentazione, e ogni istanza di `Presentation` possiede il proprio `FontsManager`.

Una volta che il `FontsManager` è stato inizializzato con la raccolta di font di ripiego, i font di ripiego specificati vengono applicati durante il rendering della presentazione.

## **Applica Regole di Ripiego**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRule) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRulesCollection), che implementa la classe [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRulesCollection). È possibile aggiungere o rimuovere regole dalla raccolta.

Quindi questa raccolta può essere assegnata al metodo [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontFallBackRulesCollection) della classe [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontsManager). Il FontsManager controlla i font in tutta la presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) dispone di un metodo [getFontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getFontsManager--) con la propria istanza della classe [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FontsManager).

Ecco un esempio su come creare una raccolta di regole per i font di ripiego e assegnarla al [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getFontsManager--) di una determinata presentazione:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dopo che il FontsManager è stato inizializzato con la raccolta di font di ripiego, i font di ripiego vengono applicati durante il rendering della presentazione.

{{% alert color="primary" %}} 
Leggi di più su come [Render Presentation with Fallback Font](/slides/it/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Le mie regole di ripiego saranno incorporate nel file PPTX e visibili in PowerPoint dopo il salvataggio?**

No. Le regole di ripiego sono impostazioni di rendering a runtime; non vengono serializzate nel PPTX e non compariranno nell'interfaccia di PowerPoint.

**Il ripiego si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?**

Sì. Lo stesso meccanismo di sostituzione dei glifi viene utilizzato per qualsiasi testo in questi oggetti.

**Aspose distribuisce dei font con la libreria?**

No. I font vengono aggiunti e utilizzati dal proprio lato ed è sotto la propria responsabilità.

**È possibile utilizzare contemporaneamente la sostituzione per i font mancanti e il ripiego per i glifi mancanti?**

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei font: prima il motore risolve la disponibilità dei font ([replacement](/slides/it/nodejs-java/font-replacement/)/[substitution](/slides/it/nodejs-java/font-substitution/)), poi il ripiego colma le lacune per i glifi mancanti nei font disponibili.