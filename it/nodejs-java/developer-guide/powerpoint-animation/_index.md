---
title: Migliora le presentazioni PowerPoint con animazioni in JavaScript
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/nodejs-java/powerpoint-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilizza Aspose.Slides per Node.js via Java per gestire le animazioni PowerPoint. Questa panoramica evidenzia le funzionalità chiave e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre considerati durante la loro creazione.

**PowerPoint animation** svolge un ruolo importante per rendere la presentazione accattivante e attraente per gli spettatori. Aspose.Slides per Node.js via Java offre un'ampia gamma di opzioni per aggiungere animazioni a una presentazione PowerPoint:

- applicare vari tipi di effetti di animazione PowerPoint su forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- utilizzare più effetti di animazione PowerPoint su una forma.
- utilizzare la timeline dell'animazione per controllare gli effetti di animazione.
- creare animazioni personalizzate.

In Aspose.Slides per Node.js via Java, è possibile applicare vari effetti di animazione sulle forme. Poiché ogni elemento nella diapositiva, inclusi testo, immagini, OLE Object, tabella ecc., è considerato una forma, ciò significa che possiamo applicare effetti di animazione su ogni elemento di una diapositiva.

## **Effetti di animazione**

Aspose.Slides supporta **150+ effetti di animazione**, inclusi effetti di animazione di base come Bounce, PathFootball, effetto Zoom e effetti di animazione specifici come OLEObjectShow, OLEObjectOpen. È possibile trovare un elenco completo di effetti di animazione nell'enumerazione [**EffectType**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere usati in combinazione con essi:
- [ColorEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SetEffect)

## **Animazione personalizzata**

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Ciò può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Behavior) è un'unità costitutiva di qualsiasi effetto di animazione PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in una strategia unica. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se si aggiunge un nuovo comportamento a un effetto di animazione PowerPoint standard, si otterrà un'altra animazione personalizzata. Ad esempio, è possibile aggiungere il comportamento di ripetizione a un'animazione per farla ripetere alcune volte.

[**Animation Point**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Point) è un punto in cui deve essere applicato il comportamento.

## **Timeline di animazione**

[**Sequence**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Sequence) è una collezione di effetti di animazione, applicata su una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AnimationTimeLine) è un insieme di Sequence utilizzate in una diapositiva concreta. È un motore di animazione presente sin da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, era difficile aggiungere effetti di animazione alla presentazione, operazione possibile solo con varie soluzioni alternative. La Timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione PowerPoint. Una diapositiva può contenere solo una timeline di animazione.

## **Animazione interattiva**

[**Trigger**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/EffectTriggerType) consente di definire azioni dell'utente (ad es. click di un pulsante) che faranno avviare una determinata animazione. I trigger sono stati aggiunti solo nella versione più recente di PowerPoint.

## **Animazione delle forme**

Aspose.Slides consente di applicare animazioni a forme, che possono essere testo, rettangolo, linea, cornice, OLE Object, ecc.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/nodejs-java/shape-animation/).
{{% /alert %}}

## **Grafici animati**

Per creare grafici animati, è necessario utilizzare le stesse classi delle forme. Tuttavia, è possibile utilizzare l'animazione PowerPoint solo su categorie di grafico o serie di grafico. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sui grafici animati**](/slides/it/nodejs-java/animated-charts/).
{{% /alert %}}

## **Testo animato**

Oltre al testo animato, è anche possibile applicare animazioni a un paragrafo.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sul testo animato**](/slides/it/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate esportando in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/nodejs-java/slide-transition/) non vengono riprodotte. Se è necessario il movimento, esporta invece in [HTML5](/slides/it/nodejs-java/export-to-html5/), [GIF animato](/slides/it/nodejs-java/convert-powerpoint-to-animated-gif/) o [video](/slides/it/nodejs-java/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare la frequenza dei fotogrammi e le dimensioni del fotogramma?**

Sì. È possibile [rendere la presentazione come fotogrammi](/slides/it/nodejs-java/convert-powerpoint-to-video/) e codificarli in un video (ad es., tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte lavorando con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/nodejs-java/open-presentation/) e la [scrittura](/slides/it/nodejs-java/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalida i casi critici con campioni reali.