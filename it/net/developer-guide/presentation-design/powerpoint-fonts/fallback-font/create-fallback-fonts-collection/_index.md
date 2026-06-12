---
title: Configura le raccolte di font di fallback in .NET
linktitle: Raccolta di font di fallback
type: docs
weight: 20
url: /it/net/create-fallback-fonts-collection/
keywords:
- font di fallback
- regola di fallback
- raccolta di font
- configura font
- imposta font
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Imposta una raccolta di font di fallback in Aspose.Slides per .NET per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di font di fallback per una presentazione. Ogni regola di fallback è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`, che implementa l'interfaccia `IFontFallBackRulesCollection`.

Dopo aver creato la raccolta, è possibile assegnarla alla proprietà `FontFallBackRulesCollection` del `FontsManager` della presentazione. Il `FontsManager` controlla i font nell'intera presentazione e ogni istanza di `Presentation` ha il proprio `FontsManager`.

Una volta che il `FontsManager` è stato inizializzato con la raccolta di font di fallback, i font di fallback specificati vengono applicati durante il rendering della presentazione.

## **Applica Regole di Fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/net/aspose.slides/FontFallBackRule) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/fontfallbackrulescollection), che implementa l'interfaccia [IFontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/ifontfallbackrulescollection). È possibile aggiungere o rimuovere regole dalla raccolta.

Quindi questa raccolta può essere assegnata alla proprietà [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) della classe [FontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager). Il FontsManager controlla i font nell'intera presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) ha una proprietà [FontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/properties/fontsmanager) con la propria istanza della classe FontsManager.

Ecco un esempio su come creare una raccolta di regole dei font di fallback e assegnarla al FontsManager di una determinata presentazione:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Dopo che il FontsManager è stato inizializzato con la raccolta di font di fallback, i font di fallback vengono applicati durante il rendering della presentazione.

{{% alert color="primary" %}} 
Leggi di più su come [Eseguire il rendering di una presentazione con font di fallback](/slides/it/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Le mie regole di fallback saranno incorporate nel file PPTX e visibili in PowerPoint dopo il salvataggio?**

No. Le regole di fallback sono impostazioni di rendering a runtime; non vengono serializzate nel PPTX e non saranno visibili nell'interfaccia di PowerPoint.

**Il fallback si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?**

Sì. Lo stesso meccanismo di sostituzione dei glifi viene utilizzato per qualsiasi testo in questi oggetti.

**Aspose distribuisce qualche font con la libreria?**

No. È necessario aggiungere e utilizzare i font da sé, sotto la propria responsabilità.

**È possibile utilizzare contemporaneamente la sostituzione/substitution per font mancanti e il fallback per glifi mancanti?**

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei font: prima il motore risolve la disponibilità dei font ([replacement](/slides/it/net/font-replacement/)/[substitution](/slides/it/net/font-substitution/)), poi il fallback colma le lacune per i glifi mancanti nei font disponibili.