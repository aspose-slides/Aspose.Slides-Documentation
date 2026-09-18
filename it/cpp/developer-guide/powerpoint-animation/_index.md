---
title: "Migliora le presentazioni PowerPoint con animazioni in C++"
linktitle: "Animazione PowerPoint"
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
- C++
- Aspose.Slides
description: "Scopri come aggiungere e controllare effetti di animazione avanzati in Aspose.Slides per C++ per creare presentazioni PowerPoint e OpenDocument dinamiche."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre tenuti in considerazione durante la creazione.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applica vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Usa più effetti di animazione PowerPoint su una singola forma.
- Utilizza la timeline dell'animazione per controllare gli effetti di animazione.
- Crea animazioni personalizzate.

In Aspose.Slides, è possibile applicare vari effetti di animazione alle forme. Poiché ogni elemento di una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

Lo spazio dei nomi [Aspose::Slides::Animation](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/) fornisce classi per lavorare con le animazioni PowerPoint.

## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, includendo effetti di base come Bounce, PathFootball e Zoom, ed effetti specifici come OLEObjectShow e OLEObjectOpen. Puoi trovare l'elenco completo nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effecttype/).

Inoltre, questi effetti di animazione possono essere usati in combinazione con i seguenti comportamenti:

- [ColorEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/seteffect/)

## **Animazione personalizzata**

Per esempi completi in C++ che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, vedere [Animazione personalizzata](/slides/it/cpp/custom-animation/).

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Questo può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/behavior/) è un blocco costitutivo di un effetto di animazione PowerPoint. Combina i comportamenti per personalizzare un effetto, o aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di temporizzazione anziché mediante un comportamento di ripetizione separato.

[Animation Point](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/point/) è un punto in cui un comportamento dovrebbe essere applicato.

## **Timeline di animazione**
[Sequence](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/sequence/) è una raccolta di effetti di animazione che possono colpire forme diverse.

[IAnimationTimeLine](https://reference.aspose.com/slides/it/cpp/aspose.slides/ianimationtimeline/) è un insieme di sequenze usate in una diapositiva specifica. È un motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione alle presentazioni era difficile e poteva essere ottenuto solo con varie soluzioni alternative. La timeline fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Una diapositiva può avere solo una timeline di animazione.

## **Animazione interattiva**
[Trigger](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effecttriggertype/) consente di definire azioni dell'utente, come il clic di un pulsante, che avviano una determinata animazione.

## **Animazione delle forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono includere testo, rettangoli, linee, cornici, oggetti OLE e altro.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/cpp/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, dovresti utilizzare le stesse classi delle forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo a categorie di grafico o serie di grafico. È inoltre possibile applicare effetti di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sui grafici animati**](/slides/it/cpp/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre a animare il testo, è possibile applicare animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sul testo animato**](/slides/it/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni saranno conservate quando si esporta in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni diapositive](/slides/it/cpp/slide-transition/) non vengono riprodotte. Se ti serve il movimento, esporta invece in [HTML5](/slides/it/cpp/export-to-html5/), [GIF animato](/slides/it/cpp/convert-powerpoint-to-animated-gif/) o [video](/slides/it/cpp/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. È possibile [renderizzare la presentazione in fotogrammi](/slides/it/cpp/convert-powerpoint-to-video/) e codificarli in un video (ad esempio con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/cpp/open-presentation/) e la [scrittura](/slides/it/cpp/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati di animazione personalizzata possono andare persi durante la conversione in ODP. Vedi [Animazione personalizzata](/slides/it/cpp/custom-animation/) per esempi e indicazioni su come verificare la compatibilità del formato.