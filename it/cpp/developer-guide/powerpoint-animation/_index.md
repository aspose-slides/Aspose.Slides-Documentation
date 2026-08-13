---
title: Migliora le presentazioni PowerPoint con le animazioni in C++
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/cpp/powerpoint-animation/
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
- animazione forma
- grafico animato
- testo animato
- forma animata
- oggetto OLE animato
- immagine animata
- tabella animata
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come aggiungere e controllare effetti di animazione avanzati in Aspose.Slides per C++ per creare presentazioni PowerPoint e OpenDocument dinamiche."
---
## **Introduzione**

Poiché le presentazioni sono destinate a presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre considerati durante la creazione.

**L'animazione PowerPoint** svolge un ruolo importante per rendere la presentazione accattivante e attraente per gli spettatori. Aspose.Slides per C++ offre un'ampia gamma di opzioni per aggiungere animazioni alla presentazione PowerPoint:

- applicare vari tipi di effetti di animazione PowerPoint su forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- utilizzare più effetti di animazione PowerPoint su una forma.
- utilizzare la timeline di animazione per controllare gli effetti di animazione.
- creare animazioni personalizzate.

In Aspose.Slides per C++, vari effetti di animazione possono essere applicati alle forme. Poiché ogni elemento nella diapositiva, includendo testo, immagini, oggetto OLE, tabella ecc., è considerato una forma, ciò significa che possiamo applicare effetti di animazione a ogni elemento di una diapositiva.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation) **namespace** fornisce classi per lavorare con le animazioni PowerPoint.

## **Effetti di Animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball, effetto Zoom e effetti specifici come OLEObjectShow, OLEObjectOpen. È possibile trovare un elenco completo degli effetti di animazione nell'enumerazione [**EffectType**](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Inoltre, questi effetti di animazione possono essere usati in combinazione con essi:

- [ColorEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.set_effect)

## **Animazione Personalizzata**
È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides.  
Ciò può essere ottenuto combinando diversi comportamenti insieme in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.behavior) è un'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in un'unica strategia. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, si otterrà un'altra animazione personalizzata. Ad esempio, è possibile aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[**Animation Point**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.point) è un punto in cui il comportamento deve essere applicato.

## **Timeline di Animazione**
[**Sequence**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.sequence) è una raccolta di effetti di animazione, applicati a una forma concreta.

[**AnimationTimeLine**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.animation_time_line) è un insieme di Sequence utilizzate in una diapositiva concreta. È un motore di animazione presente sin da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, era difficile aggiungere effetti di animazione alla presentazione, operazione possibile solo con vari workaround. La timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Una diapositiva può contenere solo una timeline di animazione.

## **Animazione Interattiva**
[**EffectTriggerType**](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) consente di definire azioni dell'utente (ad es. click su un pulsante) che avvieranno una determinata animazione. I trigger sono stati aggiunti solo nella versione più recente di PowerPoint.

## **Animazione delle Forme**
Aspose.Slides permette di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, oggetto OLE, ecc.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sull'Animazione delle Forme**](/slides/it/cpp/shape-animation/).
{{% /alert %}}

## **Grafici Animati**
Per creare grafici animati, è necessario utilizzare le stesse classi delle forme. Tuttavia, è possibile utilizzare l'animazione PowerPoint solo sulle categorie del grafico o sulle serie del grafico. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sui Grafici Animati**](/slides/it/cpp/animated-charts/).
{{% /alert %}}

## **Testo Animato**
Oltre al testo animato, è anche possibile applicare animazioni a un paragrafo.

{{% alert color="info" %}} 
Leggi di più [**Informazioni sul Testo Animato**](/slides/it/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Le animazioni verranno preservate durante l'esportazione in PDF?

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni della diapositiva](/slides/it/cpp/slide-transition/) non vengono riprodotte. Se è necessario movimento, esporta invece in [HTML5](/slides/it/cpp/export-to-html5/), [GIF animato](/slides/it/cpp/convert-powerpoint-to-animated-gif/), o [video](/slides/it/cpp/convert-powerpoint-to-video/).

### Posso trasformare una presentazione animata in un video e controllare il frame rate e le dimensioni del frame?

Sì. È possibile [eseguire il rendering della presentazione come fotogrammi](/slides/it/cpp/convert-powerpoint-to-video/) e codificarli in un video (ad es., tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

### Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/cpp/open-presentation/) e la [scrittura](/slides/it/cpp/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalidare i casi critici con campioni reali.