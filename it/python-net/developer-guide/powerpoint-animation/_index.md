---
title: Migliora le presentazioni PowerPoint con animazioni in Python
linktitle: Animazione PowerPoint
type: docs
weight: 150
url: /it/python-net/powerpoint-animation/
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
- animazione di forma
- grafico animato
- testo animato
- forma animata
- oggetto OLE animato
- immagine animata
- tabella animata
- presentazione PowerPoint
- Python
- Aspose.Slides
description: "Esplora le funzionalità di Aspose.Slides per Python via .NET nella gestione delle animazioni PowerPoint. Questa panoramica generale evidenzia le caratteristiche chiave e offre approfondimenti per migliorare le tue presentazioni."
---
## **Introduzione**

Le presentazioni sono progettate per trasmettere informazioni, quindi il loro aspetto visivo e il comportamento interattivo sono considerazioni chiave durante la creazione.

**L'animazione di PowerPoint** svolge un ruolo importante nel rendere una presentazione accattivante e coinvolgente per gli spettatori. Aspose.Slides for Python via .NET offre un'ampia gamma di opzioni per aggiungere animazioni a una presentazione PowerPoint. È possibile:

- Applicare vari effetti di animazione a forme, grafici, tabelle, oggetti OLE e altri elementi.
- Utilizzare più effetti di animazione su una singola forma.
- Controllare gli effetti tramite la timeline di animazione.
- Creare animazioni personalizzate.

In Aspose.Slides for Python via .NET, gli effetti di animazione possono essere applicati alle forme. Poiché ogni elemento su una diapositiva—including testo, immagini, oggetti OLE e tabelle—è trattato come una forma, è possibile applicare effetti di animazione a qualsiasi elemento sulla diapositiva.

Il namespace [aspose.slides.animation](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/) fornisce le classi per lavorare con le animazioni PowerPoint.

## **Installazione**

```bash
pip install aspose.slides
```

## **Aggiungere un effetto di animazione a una forma in Python**

Gli effetti di animazione vivono nella sequenza principale di una diapositiva. Aggiungi una forma, quindi chiama `add_effect` su `slide.timeline.main_sequence`, passando il tipo di effetto, il suo sottotipo e il trigger che lo avvia.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Il file salvato contiene un effetto sulla prima diapositiva: il rettangolo entra in volo da sinistra in due secondi quando il presentatore fa clic. Riaprendolo e leggendo `slide.timeline.main_sequence` si ottiene quello stesso effetto, quindi l'animazione sopravvive al ciclo di salvataggio e caricamento invece di esistere solo in memoria.

## **Effetti di animazione**

Aspose.Slides supporta **oltre 150 effetti di animazione**, inclusi effetti di base come Bounce, PathFootball e Zoom, nonché effetti specializzati come OLEObjectShow e OLEObjectOpen. L'elenco completo è disponibile nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttype/).

Inoltre, questi effetti di animazione possono essere combinati con i seguenti effetti:

- [ColorEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/seteffect/)

## **Animazione personalizzata**

Per esempi Python completi che creano, ispezionano e modificano comportamenti e percorsi di movimento modificabili, vedere [Custom Animation](/slides/it/python-net/custom-animation/).

È possibile creare le proprie **animazioni personalizzate** in Aspose.Slides combinando più comportamenti in un unico effetto.

[Behavior](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/behavior/) è un blocco costitutivo di un effetto di animazione PowerPoint. Combina comportamenti per personalizzare un effetto, o aggiungi un comportamento per estendere un effetto predefinito. La ripetizione è configurata tramite le impostazioni di timing anziché tramite un comportamento di ripetizione separato.

[Animation Point](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/point/) indica il momento o la posizione in cui viene applicato un comportamento (un fotogramma chiave).

## **Timeline di animazione**

[Sequence](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/) è una raccolta di effetti di animazione che può riguardare forme diverse.

[Timeline](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/animationtimeline/) è l'insieme di sequenze utilizzate su una diapositiva specifica. È stata introdotta in PowerPoint 2002. Nelle versioni precedenti di PowerPoint, l'aggiunta di effetti di animazione era difficile e spesso richiedeva soluzioni alternative. La timeline sostituisce la vecchia classe `AnimationSettings` e fornisce un modello oggetto più chiaro per le animazioni PowerPoint. Ogni diapositiva può avere una sola timeline di animazione.

## **Animazione interattiva**

[Trigger](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttriggertype/) consente di definire azioni dell'utente (ad esempio, un clic su un pulsante) che avviano un'animazione specifica. I trigger sono stati aggiunti solo nelle versioni più recenti di PowerPoint.

## **Animazione di forme**

Aspose.Slides consente di applicare animazioni a forme—come testo, rettangoli, linee, cornici, oggetti OLE e altro ancora.

{{% alert color="info" title="Note" %}}
Leggi di più [**About Shape Animation**](/slides/it/python-net/shape-animation/).
{{% /alert %}}

## **Grafici animati**

Per creare grafici animati, utilizza le stesse classi usate per le forme. Tuttavia, le animazioni PowerPoint possono essere applicate solo a categorie di grafico o a serie di grafico. È inoltre possibile applicare un effetto di animazione a un singolo elemento di categoria o di serie.

{{% alert color="info" title="Note" %}}
Leggi di più [**About Animated Charts**](/slides/it/python-net/animated-charts/).
{{% /alert %}}

## **Testo animato**

Oltre all'animazione del testo, è possibile applicare l'animazione a un paragrafo.

{{% alert color="info" title="Note" %}}
Leggi di più [**About Animated Text**](/slides/it/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**Le animazioni verranno preservate durante l'esportazione in PDF?**

No. Il PDF è un formato statico, quindi le animazioni e le [transizioni diapositive](/slides/it/python-net/slide-transition/) non vengono riprodotte. Se ti serve il movimento, esporta invece in [HTML5](/slides/it/python-net/export-to-html5/), [GIF animato](/slides/it/python-net/convert-powerpoint-to-animated-gif/) o [video](/slides/it/python-net/convert-powerpoint-to-video/).

**Posso trasformare una presentazione animata in un video e controllare il frame rate e la dimensione del frame?**

Sì. Puoi [renderizzare la presentazione come fotogrammi](/slides/it/python-net/convert-powerpoint-to-video/) e codificarli in un video (ad esempio con ffmpeg), scegliendo FPS e risoluzione. Le animazioni e le transizioni delle diapositive vengono riprodotte durante il rendering.

**Le animazioni rimarranno intatte quando si lavora con ODP (non solo PPTX)?**

PPT, PPTX e ODP sono supportati per [la lettura](/slides/it/python-net/open-presentation/) e [la scrittura](/slides/it/python-net/save-presentation/), ma ciò non garantisce la conservazione delle animazioni. I dati di animazione personalizzata possono andare persi durante la conversione in ODP. Consulta [Custom Animation](/slides/it/python-net/custom-animation/) per esempi e indicazioni sul controllo della compatibilità del formato.