---
title: Migliora le presentazioni PowerPoint con animazioni in Python tramite Java
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/python-java/powerpoint-animation/
keywords:
- aggiungere animazione
- aggiornare animazione
- modificare animazione
- rimuovere animazione
- gestire animazione
- controllare animazione
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
- Python
- Java
- Aspose.Slides
description: "Esplora le capacità di Aspose.Slides per Python tramite Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le funzionalità principali e offre spunti per migliorare le tue presentazioni."
---
## **Introduzione**

Sia l'aspetto visivo che il comportamento interattivo sono considerati quando le presentazioni vengono create.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applica vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Usa più effetti di animazione PowerPoint su una singola forma.
- Utilizza la timeline dell'animazione per controllare gli effetti di animazione.
- Crea animazioni personalizzate.

In Aspose.Slides, è possibile applicare vari effetti di animazione alle forme. Poiché ogni elemento su una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di animazione**

Aspose.Slides supporta **150+ effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, e effetti specifici come OLEObjectShow e OLEObjectOpen. Puoi trovare l'elenco completo nella classe [EffectType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere usati in combinazione con i seguenti comportamenti:

- [ColorEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/seteffect/)

## **Animazione personalizzata**

Per esempi completi di Python tramite Java che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, vedi [Custom Animation](/slides/it/python-java/custom-animation/).

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Questo può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/python-java/aspose.slides/behavior/) è un elemento costitutivo di un effetto di animazione PowerPoint. Combina comportamenti per personalizzare un effetto, o aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di temporizzazione piuttosto che tramite un comportamento di ripetizione separato.

[Point](https://reference.aspose.com/slides/it/python-java/aspose.slides/point/) è un punto al quale deve essere applicato un comportamento.

## **Timeline di animazione**
[Sequence](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/) è una raccolta di effetti di animazione che può riguardare forme diverse.

[AnimationTimeLine](https://reference.aspose.com/slides/it/python-java/aspose.slides/animationtimeline/) è un insieme di sequenze utilizzato in una diapositiva specifica. Rappresenta il motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione a una presentazione era complicato e richiedeva soluzioni alternative. La timeline fornisce un modello di oggetti più chiaro per le animazioni PowerPoint. Una diapositiva può avere una sola timeline di animazione.

## **Animazione interattiva**
[EffectTriggerType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttriggertype/) consente di definire azioni dell'utente, come un clic su un pulsante, che avviano una specifica animazione.

## **Animazione della forma**
Aspose.Slides consente di applicare animazioni alle forme, che possono rappresentare testo, rettangoli, linee, cornici, oggetti OLE e altri elementi.

{{% alert color="info" title="Note" %}}
Leggi di più [Informazioni sull'animazione delle forme](/slides/it/python-java/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, utilizza le stesse classi delle forme. Tuttavia, è possibile usare l'animazione PowerPoint solo sulle categorie o sulle serie del grafico. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [Informazioni sui grafici animati](/slides/it/python-java/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre ad animare il testo, è possibile applicare un'animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [Informazioni sul testo animato](/slides/it/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno preservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [slide transitions](/slides/it/python-java/slide-transition/) non vengono riprodotte. Se hai bisogno di movimento, esporta invece in [HTML5](/slides/it/python-java/export-to-html5/), [animated GIF](/slides/it/python-java/convert-powerpoint-to-animated-gif/), o [video](/slides/it/python-java/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. Puoi [render the presentation as frames](/slides/it/python-java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio tramite ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/python-java/open-presentation/) e la [scrittura](/slides/it/python-java/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati delle animazioni personalizzate possono andare persi durante la conversione in ODP. Vedi [Custom Animation](/slides/it/python-java/custom-animation/) per esempi e indicazioni su come verificare la compatibilità del formato.