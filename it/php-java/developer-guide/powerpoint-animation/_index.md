---
title: Migliora le presentazioni PowerPoint con le animazioni in PHP
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/php-java/powerpoint-animation/
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
- PHP
- Aspose.Slides
description: "Esplora le funzionalità di Aspose.Slides per PHP via Java nella gestione delle animazioni PowerPoint. Caratteristiche chiave e approfondimenti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre considerati durante la creazione.

**PowerPoint animation** svolge un ruolo importante per rendere la presentazione accattivante e attraente per gli spettatori. Aspose.Slides for PHP via Java offre un'ampia gamma di opzioni per aggiungere animazioni a una presentazione PowerPoint:

- applicare vari tipi di effetti di animazione PowerPoint su forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- utilizzare più effetti di animazione PowerPoint su una forma.
- utilizzare la timeline di animazione per controllare gli effetti di animazione.
- creare animazioni personalizzate.

In Aspose.Slides for PHP via Java, è possibile applicare vari effetti di animazione sulle forme. Poiché ogni elemento della diapositiva, inclusi testo, immagini, oggetto OLE, tabella, ecc., è considerato una forma, significa che possiamo applicare effetti di animazione a ogni elemento di una diapositiva.

## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball, effetto Zoom e effetti di animazione specifici come OLEObjectShow, OLEObjectOpen. È possibile trovare l'elenco completo degli effetti di animazione nell'enumerazione [**EffectType**](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere combinati tra loro:

- [ColorEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/SetEffect)

## **Animazione personalizzata**
È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides.  
Ciò può essere ottenuto combinando più comportamenti insieme in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Behavior) è un'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in un'unica strategia. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, ne risulterà un'altra animazione personalizzata. Ad esempio, è possibile aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[**Animation Point**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Point) è un punto in cui il comportamento deve essere applicato.

## **Timeline dell'animazione**
[**Sequence**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Sequence) è una raccolta di effetti di animazione, applicata su una forma specifica.

[**Timeline**](https://reference.aspose.com/slides/it/php-java/aspose.slides/AnimationTimeLine) è un insieme di Sequence utilizzate in una diapositiva specifica. È un motore di animazione presente sin da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alla presentazione era difficile e poteva essere realizzato solo con diverse soluzioni alternative. La Timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione PowerPoint. Una diapositiva può contenere **solo una** timeline di animazione.

## **Animazione interattiva**
[**Trigger**](https://reference.aspose.com/slides/it/php-java/aspose.slides/EffectTriggerType) consente di definire azioni dell'utente (ad esempio clic su pulsante) che faranno avviare una determinata animazione. I trigger sono stati aggiunti solo nell'ultima versione di PowerPoint.

## **Animazione delle forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, oggetto OLE, ecc.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/php-java/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, è necessario utilizzare le stesse classi delle forme. Tuttavia, è possibile utilizzare l'animazione PowerPoint solo su categorie di grafico o serie di grafico. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sui grafici animati**](/slides/it/php-java/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre al testo animato, è possibile applicare animazioni a un paragrafo.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sul testo animato**](/slides/it/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/php-java/slide-transition/) non vengono riprodotte. Se è necessario il movimento, esporta invece in [HTML5](/slides/it/php-java/export-to-html5/), [GIF animato](/slides/it/php-java/convert-powerpoint-to-animated-gif/), o [video](/slides/it/php-java/convert-powerpoint-to-video/).

**Posso convertire una presentazione animata in un video e controllare il frame rate e la dimensione dei fotogrammi?**

Sì. È possibile [renderizzare la presentazione in fotogrammi](/slides/it/php-java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/php-java/open-presentation/) e la [scrittura](/slides/it/php-java/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalida i casi critici con campioni reali.