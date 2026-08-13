---
title: Migliora le presentazioni PowerPoint con animazioni su Android
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/androidjava/powerpoint-animation/
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
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Esplora le funzionalità di Aspose.Slides per Android via Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le caratteristiche principali."
---
## **Introduzione**

Poiché le presentazioni sono destinate a presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre considerati durante la loro creazione.

**PowerPoint animation** svolge un ruolo importante per rendere la presentazione accattivante e attraente per gli spettatori. Aspose.Slides for Android via Java offre un'ampia gamma di opzioni per aggiungere animazioni a una presentazione PowerPoint:

- applicare vari tipi di effetti di animazione PowerPoint su forme, grafici, tabelle, Oggetti OLE e altri elementi della presentazione.
- utilizzare più effetti di animazione PowerPoint su una forma.
- utilizzare la timeline di animazione per controllare gli effetti di animazione.
- creare animazioni personalizzate.

In Aspose.Slides for Android via Java, vari effetti di animazione possono essere applicati alle forme. Poiché ogni elemento nella diapositiva, inclusi testo, immagini, Oggetto OLE, tabella, ecc., è considerato una forma, ciò significa che possiamo applicare effetti di animazione a ogni elemento di una diapositiva.

## **Effetti di animazione**

Aspose.Slides supporta **150+ effetti di animazione**, inclusi effetti di base come Bounce, PathFootball, effetto Zoom e effetti specifici come OLEObjectShow, OLEObjectOpen. È possibile trovare un elenco completo di effetti di animazione nell'enumerazione [**EffectType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere usati in combinazione con essi:

- [ColorEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SetEffect)

## **Animazione personalizzata**

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Ciò può essere ottenuto combinando diversi comportamenti insieme in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Behavior) è l'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in una singola strategia. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, si otterrà un'altra animazione personalizzata. Ad esempio, è possibile aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[**Animation Point**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Point) è un punto in cui il comportamento deve essere applicato.

## **Timeline dell'animazione**

[**Sequence**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Sequence) è una raccolta di effetti di animazione, applicati a una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AnimationTimeLine) è un insieme di Sequence utilizzate in una diapositiva concreta. È un motore di animazione presente sin da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, era difficile aggiungere effetti di animazione alla presentazione, operazione possibile solo tramite varie soluzioni alternative. La Timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione PowerPoint. Una diapositiva può contenere solo una timeline di animazione.

## **Animazione interattiva**

[**Trigger**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/EffectTriggerType) consente di definire azioni dell'utente (ad esempio il clic su un pulsante) che avviano una determinata animazione. I trigger sono stati aggiunti solo nella versione più recente di PowerPoint.

## **Animazione delle forme**

Aspose.Slides consente di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, Oggetto OLE, ecc.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/androidjava/shape-animation/).
{{% /alert %}}

## **Grafici animati**

Per creare grafici animati, è necessario utilizzare le stesse classi usate per le forme. Tuttavia, è possibile usare l'animazione PowerPoint solo su categorie di grafico o serie di grafico. È anche possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sui grafici animati**](/slides/it/androidjava/animated-charts/).
{{% /alert %}}

## **Testo animato**

Oltre al testo animato, è anche possibile applicare animazioni a un paragrafo.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sul testo animato**](/slides/it/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### Le animazioni saranno preservate durante l'esportazione in PDF?

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni diapositiva](/slides/it/androidjava/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta invece in [HTML5](/slides/it/androidjava/export-to-html5/), [GIF animato](/slides/it/androidjava/convert-powerpoint-to-animated-gif/) o [video](/slides/it/androidjava/convert-powerpoint-to-video/).

### Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?

Sì. È possibile [rendere la presentazione come fotogrammi](/slides/it/androidjava/convert-powerpoint-to-video/) e codificarli in un video (ad esempio tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

### Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/androidjava/open-presentation/) e la [scrittura](/slides/it/androidjava/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalida i casi critici con campioni reali.