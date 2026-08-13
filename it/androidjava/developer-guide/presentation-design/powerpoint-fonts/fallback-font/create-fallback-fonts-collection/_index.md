---
title: Configura le collezioni di caratteri di fallback su Android
linktitle: Collezione di caratteri di fallback
type: docs
weight: 20
url: /it/androidjava/create-fallback-fonts-collection/
keywords:
- font di fallback
- regola di fallback
- collezione di font
- configurare il font
- impostare il font
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Configura una collezione di font di fallback in Aspose.Slides per Android tramite Java per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una collezione di regole di fallback dei caratteri per una presentazione. Ogni regola di fallback è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`, che implementa l'interfaccia `IFontFallBackRulesCollection`.

Dopo aver creato la collezione, è possibile assegnarla alla proprietà `FontFallBackRulesCollection` del `FontsManager` della presentazione. Il `FontsManager` controlla i caratteri in tutta la presentazione e ogni istanza di `Presentation` possiede il proprio `FontsManager`.

Una volta che il `FontsManager` è stato inizializzato con la collezione di caratteri di fallback, i caratteri di fallback specificati vengono applicati durante il rendering della presentazione.

## **Applicare le regole di fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRule) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRulesCollection) che implementa l'interfaccia [IFontFallBackRulesCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IFontFallBackRulesCollection). È possibile aggiungere o rimuovere regole dalla collezione.

Questa collezione può quindi essere assegnata al metodo [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontFallBackRulesCollection) della classe [FontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsManager). FontsManager controlla i caratteri in tutta la presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) ha un metodo [getFontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getFontsManager--) con la propria istanza della classe [FontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsManager).

Ecco un esempio su come creare una collezione di regole di fallback dei caratteri e assegnarla al [FontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getFontsManager--) di una determinata presentazione:   

```java
import com.aspose.slides.*;

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

Dopo che FontsManager è stato inizializzato con la collezione di caratteri di fallback, i caratteri di fallback vengono applicati durante il rendering della presentazione.

{{% alert color="info" %}} 
Leggi di più su come [Render Presentation with Fallback Font](/slides/it/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Le mie regole di fallback saranno incorporate nel file PPTX e visibili in PowerPoint dopo il salvataggio?

No. Le regole di fallback sono impostazioni di rendering a runtime; non vengono serializzate nel PPTX e non appariranno nell'interfaccia di PowerPoint.

### Il fallback si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?

Sì. Lo stesso meccanismo di sostituzione dei glifi è utilizzato per qualsiasi testo in questi oggetti.

### Aspose distribuisce caratteri con la libreria?

No. È necessario aggiungere e utilizzare i caratteri autonomamente, sotto la propria responsabilità.

### È possibile utilizzare contemporaneamente la sostituzione/rimpiazzo per caratteri mancanti e il fallback per glifi mancanti?

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei caratteri: prima il motore risolve la disponibilità dei caratteri ([replacement](/slides/it/androidjava/font-replacement/)/[substitution](/slides/it/androidjava/font-substitution/)), poi il fallback colma le lacune per i glifi mancanti nei caratteri disponibili.