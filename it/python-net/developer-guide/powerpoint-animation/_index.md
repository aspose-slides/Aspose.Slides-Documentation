---
title: "Migliora le presentazioni PowerPoint con animazioni in Python"
linktitle: "Animazione PowerPoint"
type: docs
weight: 150
url: /it/python-net/powerpoint-animation/
keywords:
- "aggiungere animazione"
- "aggiornare animazione"
- "cambiare animazione"
- "rimuovere animazione"
- "gestire animazione"
- "controllare animazione"
- "effetto di animazione"
- "animazione PowerPoint"
- "timeline dell'animazione"
- "animazione interattiva"
- "animazione personalizzata"
- "animazione di forma"
- "grafico animato"
- "testo animato"
- "forma animata"
- "oggetto OLE animato"
- "immagine animata"
- "tabella animata"
- "presentazione PowerPoint"
- "Python"
- "Aspose.Slides"
description: "Esplora le funzionalità di Aspose.Slides per Python via .NET nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le caratteristiche principali e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Le presentazioni sono progettate per trasmettere informazioni, quindi il loro aspetto visivo e il comportamento interattivo sono considerazioni chiave durante la creazione.

**Animazione PowerPoint** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides for Python via .NET fornisce un'ampia gamma di opzioni per aggiungere animazioni a una presentazione PowerPoint. È possibile:

- Applicare vari effetti di animazione a forme, grafici, tabelle, oggetti OLE e altri elementi.
- Utilizzare più effetti di animazione su una singola forma.
- Controllare gli effetti tramite la timeline dell'animazione.
- Creare animazioni personalizzate.

In Aspose.Slides for Python via .NET, gli effetti di animazione possono essere applicati alle forme. Poiché ogni elemento su una diapositiva — inclusi testo, immagini, oggetti OLE e tabelle — è trattato come una forma, è possibile applicare effetti di animazione a qualsiasi elemento della diapositiva.

Lo spazio dei nomi [aspose.slides.animation](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/) fornisce le classi per lavorare con le animazioni PowerPoint.

## **Effetti di animazione**

Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, nonché effetti specializzati come OLEObjectShow e OLEObjectOpen. È possibile trovare l'elenco completo nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttype/).

Inoltre, questi effetti di animazione possono essere combinati con i seguenti effetti:

- [ColorEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/seteffect/)

## **Animazione personalizzata**

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides combinando più comportamenti in un unico effetto.

[Behavior](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/behavior/) è l'elemento costitutivo di base di qualsiasi effetto di animazione PowerPoint. Ogni effetto di animazione è essenzialmente un insieme di comportamenti organizzati in una strategia o timeline. È possibile assemblare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, diventa un'animazione personalizzata — ad esempio, aggiungendo un comportamento di ripetizione per far riprodurre l'animazione più volte.

[Animation Point](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/point/) indica il momento o la posizione in cui un comportamento viene applicato (un fotogramma chiave).

## **Timeline dell'animazione**

[Sequence](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/) è una collezione di effetti di animazione applicati a una forma specifica.

[Timeline](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/animationtimeline/) è l'insieme di sequenze utilizzate su una diapositiva specifica. È stata introdotta in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, l'aggiunta di effetti di animazione era difficile e spesso richiedeva soluzioni alternative. La Timeline sostituisce la vecchia classe `AnimationSettings` e fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Ogni diapositiva può avere una sola timeline di animazione.

## **Animazione interattiva**

[Trigger](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttriggertype/) consente di definire azioni dell'utente (ad es., un clic su un pulsante) che avviano una specifica animazione. I trigger sono stati aggiunti solo nelle versioni più recenti di PowerPoint.

## **Animazione delle forme**

Aspose.Slides consente di applicare animazioni alle forme — come testo, rettangoli, linee, cornici, oggetti OLE e altro.

{{% alert color="primary" %}}
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/python-net/shape-animation/).
{{% /alert %}}

## **Grafici animati**

Per creare grafici animati, utilizzare le stesse classi usate per le forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo a categorie di grafico o serie di grafico. È inoltre possibile applicare un effetto di animazione a un singolo elemento di categoria o a un elemento di serie.

{{% alert color="primary" %}}
Leggi di più [**Informazioni sui grafici animati**](/slides/it/python-net/animated-charts/).
{{% /alert %}}

## **Testo animato**

Oltre ad animare il testo, è possibile applicare animazione a un paragrafo.

{{% alert color="primary" %}}
Leggi di più [**Informazioni sul testo animato**](/slides/it/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni saranno conservate quando si esporta in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/python-net/slide-transition/) non vengono riprodotte. Se è necessario il movimento, esportare invece in [HTML5](/slides/it/python-net/export-to-html5/), [GIF animato](/slides/it/python-net/convert-powerpoint-to-animated-gif/) o [video](/slides/it/python-net/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. È possibile [renderizzare la presentazione come fotogrammi](/slides/it/python-net/convert-powerpoint-to-video/) e codificarli in un video (ad es., con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/python-net/open-presentation/) e la [scrittura](/slides/it/python-net/save-presentation/), ma le differenze di formato significano che alcuni effetti potrebbero apparire o comportarsi leggermente diversamente. Verificare i casi critici con esempi reali.