---
title: Migliora le presentazioni PowerPoint con animazioni in C++
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/cpp/powerpoint-animation/
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
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come aggiungere e controllare effetti di animazione avanzati in Aspose.Slides per C++ per creare presentazioni PowerPoint e OpenDocument dinamiche."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di mostrare qualcosa, il loro aspetto visivo e il comportamento interattivo vengono sempre considerati durante la creazione.

**PowerPoint animation** gioca un ruolo importante per rendere la presentazione accattivante e attraente per gli spettatori. Aspose.Slides for C++ offre un'ampia gamma di opzioni per aggiungere animazioni a una presentazione PowerPoint:

- applicare vari tipi di effetti di animazione PowerPoint su forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- usare più effetti di animazione PowerPoint su una forma.
- utilizzare la timeline dell'animazione per controllare gli effetti.
- creare animazioni personalizzate.

In Aspose.Slides for C++, è possibile applicare diversi effetti di animazione sulle forme. Poiché ogni elemento della diapositiva, inclusi testo, immagini, oggetto OLE, tabella ecc., è considerato una forma, ciò significa che possiamo applicare effetti di animazione a ogni elemento di una diapositiva.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation) **namespace** fornisce classi per lavorare con le animazioni PowerPoint.
## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball, effetto Zoom e effetti specifici come OLEObjectShow, OLEObjectOpen. È possibile trovare un elenco completo degli effetti di animazione nella enumerazione [**EffectType**](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Inoltre, questi effetti di animazione possono essere combinati con:

- [ColorEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.set_effect)

## **Animazione personalizzata**
È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides.  
Ciò può essere realizzato combinando diversi comportamenti in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.behavior) è l'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in un'unica strategia. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, si otterrà un'altra animazione personalizzata. Per esempio, è possibile aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[**Animation Point**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.point) è il punto in cui il comportamento deve essere applicato.

## **Linea temporale dell'animazione**
[**Sequence**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.sequence) è una raccolta di effetti di animazione, applicata su una forma concreta.

[**AnimationTimeLine**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.animation_time_line) è un insieme di Sequence utilizzato in una diapositiva concreta. È un motore di animazione presente da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alla presentazione era difficile e si dovevano ricorrere a diverse soluzioni alternative. La timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione PowerPoint. Una diapositiva può avere solo una timeline di animazione.

## **Animazione interattiva**
[**EffectTriggerType**](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) consente di definire azioni dell'utente (ad es. clic su un pulsante) che avvieranno una determinata animazione. I trigger sono stati introdotti solo nell'ultima versione di PowerPoint.

## **Animazione delle forme**
Aspose.Slides permette di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, oggetto OLE, ecc.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/cpp/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, è necessario utilizzare le stesse classi delle forme. Tuttavia, è possibile applicare l'animazione PowerPoint solo alle categorie del grafico o alle serie del grafico. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sui grafici animati**](/slides/it/cpp/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre al testo animato, è possibile applicare animazioni a un paragrafo.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sul testo animato**](/slides/it/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno preservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni tra le diapositive](/slides/it/cpp/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta in [HTML5](/slides/it/cpp/export-to-html5/), [GIF animato](/slides/it/cpp/convert-powerpoint-to-animated-gif/) o [video](/slides/it/cpp/convert-powerpoint-to-video/) invece.

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. Puoi [renderizzare la presentazione come fotogrammi](/slides/it/cpp/convert-powerpoint-to-video/) e codificarli in un video (ad es. con ffmpeg), scegliendo FPS e risoluzione. Animazioni e transizioni tra le diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per [la lettura](/slides/it/cpp/open-presentation/) e [la scrittura](/slides/it/cpp/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente in modo diverso. Convalida i casi critici con campioni reali.