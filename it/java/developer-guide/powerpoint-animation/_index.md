---
title: "Migliora le presentazioni PowerPoint con animazioni in Java"
linktitle: "Animazione PowerPoint"
type: docs
weight: 150
url: /it/java/powerpoint-animation/
keywords:
- aggiungere animazione
- aggiornare animazione
- modificare animazione
- rimuovere animazione
- gestire animazione
- controllare animazione
- effetto di animazione
- animazione PowerPoint
- timeline di animazione
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
- Java
- Aspose.Slides
description: "Scopri le capacità di Aspose.Slides per Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le funzionalità chiave e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni sono pensate per presentare qualcosa, il loro aspetto visivo e il comportamento interattivo vengono sempre tenuti in considerazione durante la creazione.

**PowerPoint animation** gioca un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides fornisce una vasta gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applica vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Usa più effetti di animazione PowerPoint su una singola forma.
- Utilizza la timeline dell'animazione per controllare gli effetti di animazione.
- Crea animazioni personalizzate.

In Aspose.Slides, vari effetti di animazione possono essere applicati alle forme. Poiché ogni elemento su una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di animazione**
Aspose.Slides supporta **150+ effetti di animazione**, inclusi effetti di animazione di base come Bounce, PathFootball, effetto Zoom e effetti di animazione specifici come OLEObjectShow, OLEObjectOpen. Puoi trovare un elenco completo di effetti di animazione nell'enumerazione [**EffectType**](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere utilizzati in combinazione con essi:

- [ColorEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/SetEffect)

## **Animazione personalizzata**
È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. 
Ciò può essere ottenuto combinando diversi comportamenti insieme in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Behavior) è un'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in una strategia. Puoi combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se aggiungi un nuovo comportamento a un effetto di animazione PowerPoint standard, sarà un'altra animazione personalizzata. Ad esempio, puoi aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[**Animation Point**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Point) è un punto in cui il comportamento dovrebbe essere applicato.

## **Timeline di animazione**
[**Sequence**](https://reference.aspose.com/slides/it/java/com.aspose.slides/Sequence) è una collezione di effetti di animazione, applicata a una forma specifica.

[**Timeline**](https://reference.aspose.com/slides/it/java/com.aspose.slides/AnimationTimeLine) è un insieme di Sequence utilizzate in una diapositiva concreta. È un motore di animazione rappresentato a partire da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, era difficile aggiungere effetti di animazione alla presentazione, cosa che poteva essere realizzata solo con diversi workaround. Timeline viene a sostituire la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Una diapositiva può avere solo una timeline di animazione.

## **Animazione interattiva**
[**Trigger**](https://reference.aspose.com/slides/it/java/com.aspose.slides/EffectTriggerType) consente di definire azioni dell'utente (ad esempio clic su pulsante) che avvieranno una determinata animazione. I trigger sono stati aggiunti solo nell'ultima versione di PowerPoint.

## **Animazione delle forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, oggetto OLE, ecc.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/java/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, dovresti utilizzare tutte le stesse classi usate per le forme. Tuttavia, è possibile utilizzare l'animazione PowerPoint solo su categorie o serie di grafici. Puoi anche applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sui grafici animati**](/slides/it/java/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre al testo animato, è anche possibile applicare animazioni a un paragrafo.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sul testo animato**](/slides/it/java/animated-text/).
{{% /alert %}}

## **FAQ**

### Le animazioni saranno preservate durante l'esportazione in PDF?
No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/java/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta invece in [HTML5](/slides/it/java/export-to-html5/), [GIF animato](/slides/it/java/convert-powerpoint-to-animated-gif/) o [video](/slides/it/java/convert-powerpoint-to-video/).

### Posso trasformare una presentazione animata in un video e controllare la frequenza dei fotogrammi e la dimensione del fotogramma?
Sì. Puoi [renderizzare la presentazione in fotogrammi](/slides/it/java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio, tramite ffmpeg), scegliendo gli FPS e la risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

### Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?
PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/java/open-presentation/) e la [scrittura](/slides/it/java/save-presentation/), ma le differenze di formato significano che alcuni effetti possono apparire o comportarsi leggermente diversi. Convalida i casi critici con campioni reali.