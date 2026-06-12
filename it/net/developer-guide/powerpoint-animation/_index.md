---
title: Migliora le presentazioni PowerPoint con animazioni in .NET
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/net/powerpoint-animation/
keywords:
- aggiungere animazione
- aggiornare animazione
- cambiare animazione
- rimuovere animazione
- gestire animazione
- controllare animazione
- effetto animazione
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
description: "Scopri le funzionalità di Aspose.Slides per .NET nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le caratteristiche principali e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni sono pensate per presentare qualcosa, il loro aspetto visivo e il comportamento interattivo vengono sempre tenuti in considerazione durante la creazione.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides for .NET offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applica diversi tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Utilizza più effetti di animazione PowerPoint su una singola forma.
- Sfrutta la timeline delle animazioni per controllare gli effetti di animazione.
- Crea animazioni personalizzate.

In Aspose.Slides for .NET, è possibile applicare vari effetti di animazione alle forme. Poiché ogni elemento di una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

Il namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/it/net/aspose.slides.animation/) fornisce classi per lavorare con le animazioni PowerPoint.

## **Effetti di Animazione**

Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, nonché effetti specifici come OLEObjectShow e OLEObjectOpen. È possibile trovare un elenco completo di effetti di animazione nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttype).

Inoltre, questi effetti di animazione possono essere utilizzati in combinazione con i seguenti:

- [ColorEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/seteffect)

## **Animazione Personalizzata**

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Questo può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behaviour](https://reference.aspose.com/slides/it/net/aspose.slides.animation/behavior) è un blocco fondamentale di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono essenzialmente un insieme di comportamenti composti in un'unica strategia. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, diventerà un'altra animazione personalizzata. Ad esempio, è possibile aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[Animation Point](https://reference.aspose.com/slides/it/net/aspose.slides.animation/point) è un punto al quale deve essere applicato un comportamento.

## **Timeline dell'Animazione**

[Sequence](https://reference.aspose.com/slides/it/net/aspose.slides.animation/sequence) è una raccolta di effetti di animazione applicati a una forma specifica.

[Timeline](https://reference.aspose.com/slides/it/net/aspose.slides.animation/animationtimeline) è un insieme di sequenze utilizzate in una diapositiva specifica. È un motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alle presentazioni era difficile e poteva essere realizzato solo con varie soluzioni alternative. La timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Una diapositiva può avere una sola timeline di animazione.

## **Animazione Interattiva**

[Trigger](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttriggertype) consente di definire azioni dell'utente (ad esempio, un clic su un pulsante) che avvieranno una specifica animazione. I trigger sono stati introdotti nell'ultima versione di PowerPoint.

## **Animazione delle Forme**

Aspose.Slides consente di applicare animazioni alle forme, che possono includere testo, rettangoli, linee, cornici, oggetti OLE e altro.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sull'Animazione delle Forme**](/slides/it/net/shape-animation/).
{{% /alert %}}

## **Grafici Animati**

Per creare grafici animati, è necessario utilizzare le stesse classi delle forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo alle categorie di grafico o alle serie di grafico. È inoltre possibile applicare effetti di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sui Grafici Animati**](/slides/it/net/animated-charts/).
{{% /alert %}}

## **Testo Animato**

Oltre al testo animato, è anche possibile applicare animazione a un paragrafo.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sul Testo Animato**](/slides/it/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/net/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta invece in [HTML5](/slides/it/net/export-to-html5/), [GIF animato](/slides/it/net/convert-powerpoint-to-animated-gif/) o [video](/slides/it/net/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e le dimensioni del frame?**

Sì. È possibile [renderizzare la presentazione come fotogrammi](/slides/it/net/convert-powerpoint-to-video/) e codificarli in un video (ad esempio, tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/net/open-presentation/) e la [scrittura](/slides/it/net/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalida i casi critici con campioni reali.