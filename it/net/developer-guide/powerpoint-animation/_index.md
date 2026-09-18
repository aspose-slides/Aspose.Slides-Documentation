---
title: Migliora le presentazioni PowerPoint con animazioni in .NET
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/net/powerpoint-animation/
keywords:
- aggiungere animazione
- aggiornare animazione
- modificare animazione
- rimuovere animazione
- gestire animazione
- controllare animazione
- effetto di animazione
- animazione PowerPoint
- timeline animazione
- animazione interattiva
- animazione personalizzata
- animazione forma
- grafico animato
- testo animato
- forma animata
- oggetto OLE animato
- immagine animata
- tabella animata
- presentazione PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Esplora le capacità di Aspose.Slides per .NET nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le funzionalità chiave e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di mostrare qualcosa, il loro aspetto visivo e il comportamento interattivo vengono sempre considerati durante la creazione.

**L'animazione PowerPoint** svolge un ruolo importante per rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides per .NET offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applicare vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Utilizzare più effetti di animazione PowerPoint su una singola forma.
- Sfruttare la timeline dell'animazione per controllare gli effetti.
- Creare animazioni personalizzate.

In Aspose.Slides per .NET, è possibile applicare diversi effetti di animazione alle forme. Poiché ogni elemento su una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/it/net/aspose.slides.animation/) namespace fornisce classi per lavorare con le animazioni PowerPoint.

## **Effetti di animazione**

Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, nonché effetti specifici come OLEObjectShow e OLEObjectOpen. È possibile trovare l'elenco completo degli effetti di animazione nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttype).

Inoltre, questi effetti di animazione possono essere usati in combinazione con i seguenti:

- [ColorEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/seteffect)

## **Animazione personalizzata**

Per esempi completi in C# che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, vedere [Animazione personalizzata](/slides/it/net/custom-animation/).

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Ciò può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/net/aspose.slides.animation/behavior) è un blocco costitutivo di un effetto di animazione PowerPoint. Combina i comportamenti per personalizzare un effetto o aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di timing anziché tramite un comportamento di ripetizione separato.

[Animation Point](https://reference.aspose.com/slides/it/net/aspose.slides.animation/point) è il punto in cui dovrebbe essere applicato un comportamento.

## **Timeline dell'animazione**

[Sequence](https://reference.aspose.com/slides/it/net/aspose.slides.animation/sequence) è una raccolta di effetti di animazione che possono mirare a forme diverse.

[Timeline](https://reference.aspose.com/slides/it/net/aspose.slides.animation/animationtimeline) è un insieme di sequenze utilizzate in una diapositiva specifica. È un motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alle presentazioni era difficile e poteva essere realizzato solo con varie soluzioni alternative. La timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Una diapositiva può contenere una sola timeline di animazione.

## **Animazione interattiva**

[Trigger](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttriggertype) consente di definire azioni dell'utente (ad es. un clic su un pulsante) che avvieranno una specifica animazione. I trigger sono stati introdotti nell'ultima versione di PowerPoint.

## **Animazione delle forme**

Aspose.Slides consente di applicare animazioni a forme, che possono includere testo, rettangoli, linee, cornici, oggetti OLE e altro.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/net/shape-animation/).
{{% /alert %}}

## **Grafici animati**

Per creare grafici animati, dovresti usare le stesse classi delle forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo a categorie di grafico o a serie di grafico. È possibile applicare effetti di animazione anche a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sui grafici animati**](/slides/it/net/animated-charts/).
{{% /alert %}}

## **Testo animato**

Oltre ad animare il testo, è possibile applicare l'animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sul testo animato**](/slides/it/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/net/slide-transition/) non vengono riprodotte. Se ti serve il movimento, esporta in [HTML5](/slides/it/net/export-to-html5/), [GIF animato](/slides/it/net/convert-powerpoint-to-animated-gif/) o [video](/slides/it/net/convert-powerpoint-to-video/) invece.

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. Puoi [renderizzare la presentazione come fotogrammi](/slides/it/net/convert-powerpoint-to-video/) e codificarli in un video (ad es. con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/net/open-presentation/) e la [scrittura](/slides/it/net/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati di animazione personalizzati possono andare persi durante la conversione in ODP. Vedi [Animazione personalizzata](/slides/it/net/custom-animation/) per un esempio testato e le limitazioni del formato.