---
title: Migliora le Presentazioni PowerPoint con Animazioni su Android
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/androidjava/powerpoint-animation/
keywords:
- aggiungi animazione
- aggiorna animazione
- modifica animazione
- rimuovi animazione
- gestisci animazione
- controlla animazione
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
description: "Esplora le capacità di Aspose.Slides per Android tramite Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le funzionalità chiave."
---
## **Introduzione**

Poiché le presentazioni sono destinate a presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre presi in considerazione durante la creazione.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides fornisce un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applicare vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Utilizzare più effetti di animazione PowerPoint su una singola forma.
- Utilizzare la timeline di animazione per controllare gli effetti di animazione.
- Creare animazioni personalizzate.

In Aspose.Slides, vari effetti di animazione possono essere applicati alle forme. Poiché ogni elemento su una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, ed effetti specifici come OLEObjectShow e OLEObjectOpen. È possibile trovare l'elenco completo nella classe [EffectType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttype/).

Additionally, questi effetti di animazione possono essere utilizzati in combinazione con i seguenti comportamenti:

- [ColorEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SetEffect)

## **Animazione personalizzata**
Per esempi Java completi che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, vedere [Animazione personalizzata](/slides/it/java/custom-animation/).

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Questo può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/behavior/) è un blocco costitutivo di un effetto di animazione PowerPoint. Combina i comportamenti per personalizzare un effetto, o aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di temporizzazione anziché un comportamento di ripetizione separato.

[Animation Point](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/point/) è un punto al quale deve essere applicato un comportamento.

## **Timeline animazione**
[Sequence](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/sequence/) è una raccolta di effetti di animazione che possono mirare a forme diverse.

[Timeline](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/animationtimeline/) è un insieme di sequenze utilizzate in una diapositiva specifica. È un motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alle presentazioni era difficile e poteva essere realizzato solo con vari workaround. La timeline fornisce un modello di oggetti più chiaro per le animazioni di PowerPoint. Una diapositiva può avere una sola timeline di animazione.

## **Animazione interattiva**
[Trigger](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttriggertype/) consente di definire azioni dell'utente, come un clic su un pulsante, che avviano una determinata animazione.

## **Animazione della forma**
Aspose.Slides consente di applicare animazioni alle forme, che possono includere testo, rettangoli, linee, cornici, oggetti OLE e molto altro.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sull'animazione della forma**](/slides/it/androidjava/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, dovresti utilizzare le stesse classi usate per le forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo a categorie di grafico o serie di grafico. È inoltre possibile applicare effetti di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sui grafici animati**](/slides/it/androidjava/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre ad animare il testo, è possibile applicare l'animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sul testo animato**](/slides/it/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni saranno conservate durante l'esportazione in PDF?**

No. PDF è un formato statico, quindi le animazioni e le [transizioni diapositive](/slides/it/androidjava/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta invece in [HTML5](/slides/it/androidjava/export-to-html5/), [GIF animato](/slides/it/androidjava/convert-powerpoint-to-animated-gif/), o [video](/slides/it/androidjava/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e le dimensioni del frame?**

Sì. È possibile [renderizzare la presentazione come fotogrammi](/slides/it/androidjava/convert-powerpoint-to-video/) e codificarli in un video (ad esempio tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/androidjava/open-presentation/) e la [scrittura](/slides/it/androidjava/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati di animazione personalizzata possono andare persi durante la conversione in ODP. Vedi [Animazione personalizzata per Java](/slides/it/java/custom-animation/) per esempi e indicazioni su come verificare la compatibilità del formato.