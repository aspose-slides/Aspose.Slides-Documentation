---
title: Migliora le presentazioni PowerPoint con le animazioni in Java
linktitle: Animazione PowerPoint
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
description: "Esplora le capacità di Aspose.Slides per Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le funzionalità chiave e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di mostrare qualcosa, il loro aspetto visivo e il comportamento interattivo vengono sempre considerati durante la creazione.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applicare vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.  
- Utilizzare più effetti di animazione PowerPoint su una singola forma.  
- Sfruttare la timeline dell'animazione per controllare gli effetti di animazione.  
- Creare animazioni personalizzate.

In Aspose.Slides, è possibile applicare diversi effetti di animazione alle forme. Poiché ogni elemento di una diapositiva, compresi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, e effetti specifici come OLEObjectShow e OLEObjectOpen. È possibile trovare un elenco completo nella classe [EffectType](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere combinati con i seguenti comportamenti:

- [ColorEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ColorEffect)  
- [CommandEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/CommandEffect)  
- [FilterEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/FilterEffect)  
- [MotionEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/MotionEffect)  
- [PropertyEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/PropertyEffect)  
- [RotationEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/RotationEffect)  
- [ScaleEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ScaleEffect)  
- [SetEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/SetEffect)

## **Animazione personalizzata**

Per esempi Java completi che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, vedere [Custom Animation](/slides/it/java/custom-animation/).

È possibile creare **animazioni personalizzate** in Aspose.Slides. Ciò può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/java/com.aspose.slides/behavior/) è un blocco costitutivo di un effetto di animazione PowerPoint. Combina i comportamenti per personalizzare un effetto o aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di temporizzazione anziché mediante un comportamento di ripetizione separato.

[Animation Point](https://reference.aspose.com/slides/it/java/com.aspose.slides/point/) è un punto al quale deve essere applicato un comportamento.

## **Timeline dell'animazione**
[Sequence](https://reference.aspose.com/slides/it/java/com.aspose.slides/sequence/) è una raccolta di effetti di animazione che può interessare forme diverse.

[Timeline](https://reference.aspose.com/slides/it/java/com.aspose.slides/animationtimeline/) è un insieme di sequenze utilizzate in una diapositiva specifica. È un motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alle presentazioni era difficile e poteva essere realizzato solo con varie soluzioni alternative. La timeline fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Una diapositiva può avere una sola timeline di animazione.

## **Animazione interattiva**
[Trigger](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttriggertype/) consente di definire azioni dell'utente, come un clic su un pulsante, che avviano una determinata animazione.

## **Animazione delle forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono includere testo, rettangoli, linee, cornici, oggetti OLE e molto altro.

{{% alert color="info" title="Note" %}}
Leggi di più [**About Shape Animation**](/slides/it/java/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, è necessario utilizzare le stesse classi usate per le forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo a categorie di grafico o a serie di grafico. È inoltre possibile applicare effetti di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [**About Animated Charts**](/slides/it/java/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre ad animare il testo, è possibile applicare l'animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [**About Animated Text**](/slides/it/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate durante l'esportazione in PDF?**

No. PDF è un formato statico, quindi le animazioni e le [slide transitions](/slides/it/java/slide-transition/) non vengono riprodotte. Se è necessario il movimento, esporta in [HTML5](/slides/it/java/export-to-html5/), [animated GIF](/slides/it/java/convert-powerpoint-to-animated-gif/) o [video](/slides/it/java/convert-powerpoint-to-video/) invece.

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione dei frame?**

Sì. È possibile [renderizzare la presentazione come frame](/slides/it/java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio tramite ffmpeg), scegliendo FPS e risoluzione. Durante il rendering vengono riprodotte animazioni e transizioni delle diapositive.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/java/open-presentation/) e la [scrittura](/slides/it/java/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati di animazione personalizzata possono andare persi durante la conversione in ODP. Consulta [Custom Animation](/slides/it/java/custom-animation/) per esempi e indicazioni su come verificare la compatibilità del formato.