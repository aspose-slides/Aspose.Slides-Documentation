---
title: Migliora le presentazioni PowerPoint con animazioni su Android
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/androidjava/powerpoint-animation/
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
- animazione delle forme
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
description: "Esplora le capacità di Aspose.Slides per Android via Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le funzionalità chiave."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre considerati durante la loro creazione.

**PowerPoint animation** svolge un ruolo importante per rendere la presentazione accattivante e attraente per gli spettatori. Aspose.Slides per Android via Java offre un'ampia gamma di opzioni per aggiungere animazioni a una presentazione PowerPoint:

- applicare vari tipi di effetti di animazione di PowerPoint su forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- utilizzare più effetti di animazione di PowerPoint su una forma.
- utilizzare la timeline di animazione per controllare gli effetti di animazione.
- creare animazioni personalizzate.

In Aspose.Slides per Android via Java, è possibile applicare vari effetti di animazione sulle forme. Poiché ogni elemento della diapositiva, inclusi testo, immagini, oggetti OLE, tabelle, ecc., è considerato una forma, ciò significa che possiamo applicare effetti di animazione su ogni elemento di una diapositiva.

## **Effetti di animazione**

Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball, effetto Zoom e effetti specifici come OLEObjectShow, OLEObjectOpen. Puoi trovare un elenco completo di effetti di animazione nell'enumerazione [**EffectType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttype/).

In aggiunta, questi effetti di animazione possono essere usati in combinazione tra loro:

- [ColorEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SetEffect)

## **Animazione personalizzata**

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. 
Questo può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[**Behavior**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Behavior) è l'unità costitutiva di qualsiasi effetto di animazione di PowerPoint. Tutti gli effetti di animazione sono in realtà un insieme di comportamenti composti in un'unica strategia. Puoi combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Se aggiungi un nuovo comportamento a un effetto di animazione standard di PowerPoint, otterrai un'altra animazione personalizzata. Ad esempio, puoi aggiungere un comportamento di ripetizione a un'animazione per farla ripetere più volte.

[**Animation Point**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Point) è un punto in cui deve essere applicato il comportamento.

## **Timeline di animazione**

[**Sequence**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Sequence) è una raccolta di effetti di animazione, applicati a una forma concreta.

[**Timeline**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AnimationTimeLine) è un insieme di Sequence utilizzate in una diapositiva concreta. È un motore di animazione presente fin da PowerPoint 2002. Nelle versioni precedenti di PowerPoint, era difficile aggiungere effetti di animazione alla presentazione, operazione possibile solo con vari workaround. Timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione di PowerPoint. Una diapositiva può avere solo una timeline di animazione.

## **Animazione interattiva**

[**Trigger**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/EffectTriggerType) consente di definire azioni dell'utente (ad es. clic su pulsante) che avviano una determinata animazione. I trigger sono stati aggiunti solo nella versione più recente di PowerPoint.

## **Animazione delle forme**

Aspose.Slides permette di applicare animazioni alle forme, che possono essere testo, rettangolo, linea, cornice, oggetto OLE, ecc.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/androidjava/shape-animation/).
{{% /alert %}}

## **Grafici animati**

Per creare grafici animati, è necessario utilizzare le stesse classi usate per le forme. Tuttavia, è possibile utilizzare l'animazione di PowerPoint solo su categorie di grafico o serie di grafico. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sui grafici animati**](/slides/it/androidjava/animated-charts/).
{{% /alert %}}

## **Testo animato**

Oltre al testo animato, è anche possibile applicare animazioni a un paragrafo.

{{% alert color="primary" %}} 
Leggi di più [**Informazioni sul testo animato**](/slides/it/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate quando si esporta in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/androidjava/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta invece in [HTML5](/slides/it/androidjava/export-to-html5/), [GIF animato](/slides/it/androidjava/convert-powerpoint-to-animated-gif/) o [video](/slides/it/androidjava/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e le dimensioni del frame?**

Sì. Puoi [rendere la presentazione come fotogrammi](/slides/it/androidjava/convert-powerpoint-to-video/) e codificarli in un video (ad es., con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/androidjava/open-presentation/) e la [scrittura](/slides/it/androidjava/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente diversamente. Convalida i casi critici con esempi reali.