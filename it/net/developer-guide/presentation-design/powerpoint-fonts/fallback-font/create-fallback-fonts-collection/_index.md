---
title: Configurare le collezioni di caratteri di fallback in .NET
linktitle: Collezione di caratteri di fallback
type: docs
weight: 20
url: /it/net/create-fallback-fonts-collection/
keywords:
- carattere di fallback
- regola di fallback
- collezione di caratteri
- configurare carattere
- impostare carattere
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Imposta una collezione di caratteri di fallback in Aspose.Slides per .NET per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di caratteri di riserva per una presentazione. Ogni regola di riserva è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`, che implementa l'interfaccia `IFontFallBackRulesCollection`.

Dopo aver creato la raccolta, è possibile assegnarla alla proprietà `FontFallBackRulesCollection` del `FontsManager` della presentazione. Il `FontsManager` controlla i caratteri in tutta la presentazione e ogni istanza di `Presentation` dispone del proprio `FontsManager`.

Una volta che il `FontsManager` è stato inizializzato con la raccolta di caratteri di riserva, i caratteri di riserva specificati vengono applicati durante il rendering della presentazione.

## **Applicare le regole di fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/net/aspose.slides/FontFallBackRule) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrulescollection), che implementa l'interfaccia [IFontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ifontfallbackrulescollection). È possibile aggiungere o rimuovere regole dalla raccolta.

Quindi questa raccolta può essere assegnata alla proprietà [FontFallBackRulesCollection ](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) della classe [FontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager). Il FontsManager controlla i caratteri in tutta la presentazione.

Ogni [Presentation ](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) dispone di una proprietà [FontsManager ](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/properties/fontsmanager) con la propria istanza della classe FontsManager.

Ecco un esempio su come creare una raccolta di regole di caratteri di riserva e assegnarla al FontsManager di una determinata presentazione:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Dopo che il FontsManager è stato inizializzato con la raccolta di caratteri di riserva, i caratteri di riserva vengono applicati durante il rendering della presentazione.

{{% alert color="info" %}} 
Leggi di più su come [Renderizzare la presentazione con carattere di fallback](/slides/it/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Le mie regole di fallback saranno incorporate nel file PPTX e visibili in PowerPoint dopo il salvataggio?

No. Le regole di fallback sono impostazioni di rendering in fase di esecuzione; non vengono serializzate nel PPTX e non appariranno nell'interfaccia di PowerPoint.

### Il fallback si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?

Sì. Lo stesso meccanismo di sostituzione dei glifi è utilizzato per qualsiasi testo in questi oggetti.

### Aspose distribuisce dei caratteri con la libreria?

No. È necessario aggiungere e utilizzare i caratteri da te, sotto la tua responsabilità.

### È possibile utilizzare insieme la sostituzione/sostituzione per i caratteri mancanti e il fallback per i glifi mancanti?

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei caratteri: prima il motore risolve la disponibilità dei caratteri ([replacement](/slides/it/net/font-replacement/)/[substitution](/slides/it/net/font-substitution/)), poi il fallback colma le lacune dei glifi mancanti nei caratteri disponibili.