---
title: Migliora le presentazioni PowerPoint con animazioni in Python tramite Java
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/python-java/powerpoint-animation/
keywords:
- aggiungere animazione
- aggiornare animazione
- cambiare animazione
- rimuovere animazione
- gestire animazione
- controllare animazione
- effetto di animazione
- animazione PowerPoint
- timeline dell'animazione
- animazione interattiva
- animazione personalizzata
- animazione della forma
- grafico animato
- testo animato
- forma animata
- oggetto OLE animato
- immagine animata
- tabella animata
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri le funzionalità di Aspose.Slides per Python tramite Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le caratteristiche principali e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di mostrare qualcosa, il loro aspetto visivo e il comportamento interattivo vengono sempre tenuti in considerazione durante la creazione.

**L'animazione PowerPoint** gioca un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applicare vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Utilizzare più effetti di animazione PowerPoint su una singola forma.
- Utilizzare la timeline delle animazioni per controllare gli effetti di animazione.
- Creare animazioni personalizzate.

## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, includendo effetti di base come Bounce, PathFootball, effetto Zoom e effetti specifici come OLEObjectShow, OLEObjectOpen. È possibile trovare l'elenco completo degli effetti di animazione nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere combinati tra loro:

- [ColorEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/seteffect/)

## **Animazione personalizzata**
È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Questo può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/python-java/aspose.slides/behavior/) è un'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in un'unica strategia. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, si otterrà un'altra animazione personalizzata. Ad esempio, è possibile aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[Point](https://reference.aspose.com/slides/it/python-java/aspose.slides/point/) è il punto in cui deve essere applicato il comportamento.

## **Timeline dell'animazione**
[Sequence](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/) è una raccolta di effetti di animazione, applicata a una forma concreta.

[AnimationTimeLine](https://reference.aspose.com/slides/it/python-java/aspose.slides/animationtimeline/) è un insieme di Sequence utilizzate in una slide concreta. È un motore di animazione presente sin da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, era difficile aggiungere effetti di animazione alla presentazione, operazione possibile solo con diversi workaround. La Timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione PowerPoint. Una slide può contenere **solo una** timeline di animazione.

## **Animazione interattiva**
[EffectTriggerType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttriggertype/) consente di definire azioni dell'utente (ad esempio click su un pulsante) che avviano una determinata animazione. I trigger sono stati aggiunti solo nell'ultima versione di PowerPoint.

## **Animazione delle forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, oggetto OLE, ecc.

{{% alert color="info" title="Nota" %}} 
Leggi di più [Informazioni sull'animazione delle forme](/slides/it/python-java/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, dovresti utilizzare le stesse classi usate per le forme. Tuttavia, è possibile applicare l'animazione PowerPoint solo alle categorie o alle serie dei grafici. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Nota" %}} 
Leggi di più [Informazioni sui grafici animati](/slides/it/python-java/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre al testo animato, è anche possibile applicare animazioni a un paragrafo.

{{% alert color="info" title="Nota" %}} 
Leggi di più [Informazioni sul testo animato](/slides/it/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno mantenute quando si esporta in PDF?**

No. PDF è un formato statico, quindi le animazioni e le [transizioni delle slide](/slides/it/python-java/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta invece in [HTML5](/slides/it/python-java/export-to-html5/), [GIF animato](/slides/it/python-java/convert-powerpoint-to-animated-gif/), o [video](/slides/it/python-java/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. È possibile [renderizzare la presentazione come fotogrammi](/slides/it/python-java/convert-powerpoint-to-video/) e codificarli in un video (ad es., tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle slide vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/python-java/open-presentation/) e la [scrittura](/slides/it/python-java/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalida i casi critici con campioni reali.