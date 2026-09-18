---
title: Migliora le presentazioni PowerPoint con animazioni in JavaScript
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/nodejs-java/powerpoint-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilizza Aspose.Slides per Node.js via Java per gestire le animazioni PowerPoint. Questa panoramica evidenzia le funzionalità principali e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di presentare qualcosa, il loro aspetto visivo e il comportamento interattivo vengono sempre considerati durante la creazione.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides for Node.js via Java offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applicare vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.  
- Utilizzare più effetti di animazione PowerPoint su una singola forma.  
- Sfruttare la timeline di animazione per controllare gli effetti di animazione.  
- Creare animazioni personalizzate.

In Aspose.Slides for Node.js via Java, è possibile applicare diversi effetti di animazione alle forme. Poiché ogni elemento di una diapositiva, compresi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di Animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, ed effetti specifici come OLEObjectShow e OLEObjectOpen. È possibile trovare un elenco completo nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere usati in combinazione con i seguenti comportamenti:

- [ColorEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SetEffect)

## **Animazione Personalizzata**

Per esempi JavaScript completi che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, vedere [Animazione Personalizzata](/slides/it/nodejs-java/custom-animation/).

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Questo può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/behavior/) è un elemento costitutivo di un effetto di animazione PowerPoint. Combina i comportamenti per personalizzare un effetto, oppure aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di temporizzazione anziché con un comportamento di ripetizione separato.

[Animation Point](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/point/) è un punto al quale deve essere applicato un comportamento.

## **Timeline dell'Animazione**
[Sequence](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/) è una raccolta di effetti di animazione che possono riguardare forme diverse.

[Timeline](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/animationtimeline/) è un insieme di sequenze usate in una diapositiva specifica. È un motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alle presentazioni era difficile e poteva essere realizzato solo con vari workaround. La timeline fornisce un modello di oggetti più chiaro per le animazioni di PowerPoint. Una diapositiva può avere una sola timeline di animazione.

## **Animazione Interattiva**
[Trigger](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttriggertype/) consente di definire azioni dell'utente, come il clic di un pulsante, che avviano una particolare animazione.

## **Animazione delle Forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono includere testo, rettangoli, linee, cornici, oggetti OLE e altro ancora.

{{% alert color="info" title="Note" %}}
Read more [**About Shape Animation**](/slides/it/nodejs-java/shape-animation/).
{{% /alert %}}

## **Grafici Animati**
Per creare grafici animati, dovresti usare le stesse classi utilizzate per le forme. Tuttavia, le animazioni di PowerPoint possono essere applicate solo a categorie di grafico o a serie di grafico. È inoltre possibile applicare effetti di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Charts**](/slides/it/nodejs-java/animated-charts/).
{{% /alert %}}

## **Testo Animato**
Oltre ad animare il testo, è possibile applicare l'animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Text**](/slides/it/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni saranno conservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [slide transitions](/slides/it/nodejs-java/slide-transition/) non vengono riprodotte. Se ti serve il movimento, esporta invece in [HTML5](/slides/it/nodejs-java/export-to-html5/), [animated GIF](/slides/it/nodejs-java/convert-powerpoint-to-animated-gif/) o [video](/slides/it/nodejs-java/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. Puoi [render the presentation as frames](/slides/it/nodejs-java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per [reading](/slides/it/nodejs-java/open-presentation/) e [writing](/slides/it/nodejs-java/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati di animazione personalizzata possono andare persi durante la conversione in ODP. Vedi [Custom Animation](/slides/it/nodejs-java/custom-animation/) per esempi e indicazioni su come verificare la compatibilità del formato.