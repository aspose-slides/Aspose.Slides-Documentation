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
description: "Esplora le funzionalità di Aspose.Slides per Python tramite Java nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le funzionalità chiave e offre approfondimenti per migliorare le tue presentazioni."
---
## **Introduzione**

Sia l'aspetto visivo sia il comportamento interattivo vengono considerati durante la creazione delle presentazioni.

**L'animazione PowerPoint** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides offre un'ampia gamma di opzioni per aggiungere animazioni alle presentazioni PowerPoint:

- Applicare vari tipi di effetti di animazione PowerPoint a forme, grafici, tabelle, oggetti OLE e altri elementi della presentazione.
- Utilizzare più effetti di animazione PowerPoint su una singola forma.
- Utilizzare la timeline dell'animazione per controllare gli effetti di animazione.
- Creare animazioni personalizzate.

In Aspose.Slides, è possibile applicare vari effetti di animazione alle forme. Poiché ogni elemento di una diapositiva, inclusi testo, immagini, oggetti OLE e tabelle, è considerato una forma, gli effetti di animazione possono essere applicati a qualsiasi elemento della diapositiva.

## **Effetti di animazione**
Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di animazione di base come Bounce, PathFootball e Zoom, nonché effetti specializzati come OLEObjectShow e OLEObjectOpen. È possibile trovare un elenco completo degli effetti di animazione nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttype/).

Inoltre, i seguenti effetti di animazione possono essere utilizzati in combinazione con quelli elencati sopra:

- [ColorEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/seteffect/)

## **Animazione personalizzata**
È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides.  
È possibile farlo combinando diversi comportamenti in una nuova animazione personalizzata.

[Behavior](https://reference.aspose.com/slides/it/python-java/aspose.slides/behavior/) è un elemento costitutivo di qualsiasi effetto di animazione PowerPoint. Ogni effetto di animazione è costituito da un insieme di comportamenti combinati in un'unica strategia. È possibile combinare i comportamenti in un'animazione personalizzata una volta e riutilizzarla in altre presentazioni. Aggiungere un nuovo comportamento a un effetto di animazione PowerPoint standard crea un'altra animazione personalizzata. Ad esempio, è possibile aggiungere un comportamento di ripetizione per far ripetere un'animazione più volte.

[Point](https://reference.aspose.com/slides/it/python-java/aspose.slides/point/) è un punto al quale deve essere applicato un comportamento.

## **Timeline dell'animazione**
[Sequence](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/) è una raccolta di effetti di animazione applicati a una forma specifica.

[AnimationTimeLine](https://reference.aspose.com/slides/it/python-java/aspose.slides/animationtimeline/) è un insieme di sequenze utilizzate su una diapositiva specifica. Rappresenta il motore di animazione introdotto in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, aggiungere effetti di animazione a una presentazione era difficile e richiedeva soluzioni alternative. La timeline sostituisce la vecchia classe AnimationSettings e fornisce un modello di oggetti più chiaro per l'animazione PowerPoint. Una diapositiva può contenere una sola timeline di animazione.

## **Animazione interattiva**
[EffectTriggerType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttriggertype/) consente di definire azioni dell'utente (ad esempio, un clic su un pulsante) che avviano una specifica animazione. I trigger sono stati aggiunti solo nell'ultima versione di PowerPoint.

## **Animazione delle forme**
Aspose.Slides consente di applicare animazioni alle forme, che possono rappresentare testo, rettangoli, linee, cornici, oggetti OLE e altri elementi.

{{% alert color="info" title="Note" %}}
Leggi di più [Informazioni sull'animazione delle forme](/slides/it/python-java/shape-animation/).
{{% /alert %}}

## **Grafici animati**
Per creare grafici animati, utilizzare le stesse classi delle forme. Tuttavia, è possibile utilizzare l'animazione PowerPoint solo su categorie di grafico o serie di grafico. È inoltre possibile applicare un effetto di animazione a un elemento di categoria o a un elemento di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [Informazioni sui grafici animati](/slides/it/python-java/animated-charts/).
{{% /alert %}}

## **Testo animato**
Oltre a animare il testo, è possibile applicare l'animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [Informazioni sul testo animato](/slides/it/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni saranno preservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni delle diapositive](/slides/it/python-java/slide-transition/) non vengono riprodotte. Se è necessario il movimento, esporta invece in [HTML5](/slides/it/python-java/export-to-html5/), [GIF animato](/slides/it/python-java/convert-powerpoint-to-animated-gif/) o [video](/slides/it/python-java/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare la frequenza dei fotogrammi e la dimensione dei fotogrammi?**

Sì. È possibile [eseguire il rendering della presentazione come fotogrammi](/slides/it/python-java/convert-powerpoint-to-video/) e codificarli in un video (ad esempio, con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per la [lettura](/slides/it/python-java/open-presentation/) e la [scrittura](/slides/it/python-java/save-presentation/), ma le differenze di formato possono far sì che alcuni effetti appaiano o si comportino leggermente in modo diverso. Convalida i casi critici con campioni reali.