---
title: Migliora le presentazioni PowerPoint con animazioni in PHP
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/php-java/powerpoint-animation/
keywords:
- aggiungere animazione
- aggiornare animazione
- cambiare animazione
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
- PHP
- Aspose.Slides
description: "Esplora le capacità di Aspose.Slides per PHP via Java nella gestione delle animazioni PowerPoint. Caratteristiche chiave e approfondimenti per migliorare le tue presentazioni."
---
## **Introduzione**

Poiché le presentazioni hanno lo scopo di presentare qualcosa, il loro aspetto visivo e il comportamento interattivo sono sempre considerati durante la creazione.

**PowerPoint animation** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides for PHP via Java offre una vasta gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applica vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Usa più effetti di animazione PowerPoint su una singola forma.
- Utilizza la timeline di animazione per controllare gli effetti di animazione.
- Crea animazioni personalizzate.

In Aspose.Slides for PHP via Java, è possibile applicare diversi effetti di animazione alle forme. Poiché ogni elemento di una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di animazione**

Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, e effetti specifici come OLEObjectShow e OLEObjectOpen. È possibile trovare l'elenco completo nella classe [EffectType](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttype/).

Inoltre, questi effetti di animazione possono essere utilizzati in combinazione con i seguenti comportamenti:

- [ColorEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/SetEffect)

## **Animazione personalizzata**

Per esempi PHP completi che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, see [Animazione personalizzata](/slides/it/php-java/custom-animation/).

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides. Ciò può essere ottenuto combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/php-java/aspose.slides/behavior/) è un elemento costitutivo di un effetto di animazione PowerPoint. Combina i comportamenti per personalizzare un effetto, o aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di temporizzazione anziché tramite un comportamento di ripetizione separato.

[Animation Point](https://reference.aspose.com/slides/it/php-java/aspose.slides/point/) è un punto al quale deve essere applicato un comportamento.

## **Timeline di animazione**

[Sequence](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/) è una raccolta di effetti di animazione che possono mirare a forme diverse.

[Timeline](https://reference.aspose.com/slides/it/php-java/aspose.slides/animationtimeline/) è un insieme di sequenze utilizzate in una diapositiva specifica. È un motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, l'aggiunta di effetti di animazione alle presentazioni era difficile e poteva essere realizzata solo con varie soluzioni alternative. La timeline fornisce un modello di oggetto più chiaro per le animazioni PowerPoint. Una diapositiva può avere una sola timeline di animazione.

## **Animazione interattiva**

[Trigger](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttriggertype/) consente di definire azioni dell'utente, come il clic di un pulsante, che avviano una determinata animazione.

## **Animazione delle forme**

Aspose.Slides consente di applicare animazioni alle forme, che possono includere testo, rettangoli, linee, cornici, oggetti OLE e altro.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sull'animazione delle forme**](/slides/it/php-java/shape-animation/).
{{% /alert %}}

## **Grafici animati**

Per creare grafici animati, è necessario utilizzare le stesse classi delle forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo alle categorie di grafico o alle serie di grafico. È inoltre possibile applicare effetti di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sui grafici animati**](/slides/it/php-java/animated-charts/).
{{% /alert %}}

## **Testo animato**

Oltre ad animare il testo, è possibile applicare animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [**Informazioni sul testo animato**](/slides/it/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno conservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni diapositiva](/slides/it/php-java/slide-transition/) non vengono riprodotte. Se è necessario del movimento, esporta invece in [HTML5](/slides/it/php-java/export-to-html5/), [GIF animato](/slides/it/php-java/convert-powerpoint-to-animated-gif/), o [video](/slides/it/php-java/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare la frequenza dei fotogrammi e la dimensione dei fotogrammi?**

Sì. È possibile [renderizzare la presentazione in fotogrammi](/slides/it/php-java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio, con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/php-java/open-presentation/) e la [scrittura](/slides/it/php-java/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati di animazione personalizzata possono andare persi durante la conversione in ODP. Consulta [Animazione personalizzata](/slides/it/php-java/custom-animation/) per esempi e indicazioni su come verificare la compatibilità del formato.