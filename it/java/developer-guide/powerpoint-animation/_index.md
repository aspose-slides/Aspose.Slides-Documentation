---
title: Migliora le presentazioni PowerPoint con animazioni in Java
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/java/powerpoint-animation/
keywords:
- aggiungi animazione
- aggiorna animazione
- cambia animazione
- rimuovi animazione
- gestisci animazione
- controlla animazione
- effetto di animazione
- animazione PowerPoint
- timeline di animazione
- animazione interattiva
- animazione personalizzata
- animazione forme
- grafico animato
- testo animato
- forma animata
- oggetto OLE animato
- immagine animata
- tabella animata
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Esplora le funzionalità di Aspose.Slides per Java nella gestione delle animazioni PowerPoint. Questa panoramica generale mette in evidenza le caratteristiche chiave e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre considerati durante la creazione.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applicare vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Utilizzare più effetti di animazione PowerPoint su una singola forma.
- Utilizzare la timeline di animazione per controllare gli effetti di animazione.
- Creare animazioni personalizzate.

In Aspose.Slides, è possibile applicare diversi effetti di animazione alle forme. Poiché ogni elemento di una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di animazione di base come Bounce, PathFootball, effetto Zoom e effetti di animazione specifici come OLEObjectShow, OLEObjectOpen. Puoi trovare un elenco completo degli effetti di animazione nell'enumerazione [**EffectType**](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere usati in combinazione con essi:

- [ColorEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/SetEffect)

## **Animazione personalizzata**
È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Ciò può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Behavior) è l'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in un'unica strategia. Puoi combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se aggiungi un nuovo comportamento a un effetto di animazione PowerPoint standard, otterrai un'altra animazione personalizzata. Ad esempio, puoi aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[**Animation Point**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Point) è un punto in cui il comportamento deve essere applicato.

## **Timeline di animazione**
[**Sequence**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Sequence) è una collezione di effetti di animazione, applicata a una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/it/java/com.aspose.slides/AnimationTimeLine) è un insieme di Sequence utilizzate in una diapositiva concreta. È un motore di animazione presente sin da PowerPoint 2002. Nelle versioni precedenti di PowerPoint era difficile aggiungere effetti di animazione a una presentazione, operazione possibile solo con diversi workaround. Timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione PowerPoint. Una diapositiva può avere **solo una** timeline di animazione.

## **Animazione interattiva**
[**Trigger**](https://reference.aspose.com/slides/it/java/com.aspose.slides/EffectTriggerType) consente di definire azioni dell'utente (ad esempio il click di un pulsante) che avviano una determinata animazione. I trigger sono stati aggiunti solo nella versione più recente di PowerPoint.

## **Animazione delle forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, oggetto OLE, ecc.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/java/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, dovresti utilizzare le stesse classi impiegate per le forme. Tuttavia, è possibile utilizzare l'animazione PowerPoint solo su categorie di grafico o serie di grafico. Puoi anche applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sui grafici animati**](/slides/it/java/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre al testo animato, è anche possibile applicare animazioni a un paragrafo.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sul testo animato**](/slides/it/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate quando si esporta in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/java/slide-transition/) non vengono riprodotte. Se ti serve il movimento, esporta invece in [HTML5](/slides/it/java/export-to-html5/), [GIF animato](/slides/it/java/convert-powerpoint-to-animated-gif/), o [video](/slides/it/java/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. È possibile [renderizzare la presentazione come fotogrammi](/slides/it/java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/java/open-presentation/) e la [scrittura](/slides/it/java/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalida i casi critici con esempi reali.