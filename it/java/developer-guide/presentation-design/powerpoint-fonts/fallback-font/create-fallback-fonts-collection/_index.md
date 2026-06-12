---
title: Configurare le collezioni di font di fallback in Java
linktitle: Collezione di font di fallback
type: docs
weight: 20
url: /it/java/create-fallback-fonts-collection/
keywords:
- font di fallback
- regola di fallback
- collezione di font
- configurare il font
- impostare il font
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Configura una collezione di font di fallback in Aspose.Slides per Java per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di font di fallback per una presentazione. Ogni regola di fallback è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`, che implementa l'interfaccia `IFontFallBackRulesCollection`.

Dopo aver creato la raccolta, è possibile assegnarla alla proprietà `FontFallBackRulesCollection` del `FontsManager` della presentazione. Il `FontsManager` gestisce i font in tutta la presentazione e ogni istanza di `Presentation` dispone del proprio `FontsManager`.

Una volta che il `FontsManager` è stato inizializzato con la raccolta di font di fallback, i font di fallback specificati vengono applicati durante il rendering della presentazione.

## **Applica Regole di Fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRule) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRulesCollection), che implementa l'interfaccia [IFontFallBackRulesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IFontFallBackRulesCollection). È possibile aggiungere o rimuovere regole dalla raccolta.

Quindi questa raccolta può essere assegnata al metodo [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontFallBackRulesCollection) della classe [FontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager). Il FontsManager controlla i font in tutta la presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) dispone di un metodo [getFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getFontsManager--) con la propria istanza della classe [FontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsManager).

Ecco un esempio su come creare una raccolta di regole di font di fallback e assegnarla al [FontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation#getFontsManager--) di una determinata presentazione:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Dopo che il FontsManager è stato inizializzato con la raccolta di font di fallback, i font di fallback vengono applicati durante il rendering della presentazione.

{{% alert color="primary" %}} 
Scopri di più su come [Renderizza la presentazione con font di fallback](/slides/it/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Le mie regole di fallback verranno incorporate nel file PPTX e saranno visibili in PowerPoint dopo il salvataggio?**

No. Le regole di fallback sono impostazioni di rendering a runtime; non vengono serializzate nel PPTX e non appariranno nell'interfaccia di PowerPoint.

**Il fallback si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?**

Sì. Lo stesso meccanismo di sostituzione dei glifi viene utilizzato per qualsiasi testo in questi oggetti.

**Aspose distribuisce dei font con la libreria?**

No. È necessario aggiungere e utilizzare i font da parte tua e sotto tua responsabilità.

**È possibile utilizzare insieme la sostituzione per font mancanti e il fallback per glifi mancanti?**

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei font: prima il motore risolve la disponibilità dei font ([replacement](/slides/it/java/font-replacement/)/[substitution](/slides/it/java/font-substitution/)), poi il fallback colma le lacune per i glifi mancanti nei font disponibili.