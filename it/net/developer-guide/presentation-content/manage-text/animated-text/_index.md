---
title: Animare il testo di PowerPoint in .NET
linktitle: Testo animato
type: docs
weight: 60
url: /it/net/animated-text/
keywords:
  - testo animato
  - animazione del testo
  - paragrafo animato
  - animazione del paragrafo
  - effetto di animazione
  - PowerPoint
  - presentazione
  - .NET
  - C#
  - Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET, con esempi di codice C# facili da seguire e ottimizzati."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione a singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in una cornice di testo. Si concentra sui metodi API utilizzati per aggiungere animazioni a livello di paragrafo e ispezionare gli effetti di animazione dei paragrafi esistenti in una presentazione.

## **Aggiungere effetti di animazione ai paragrafi**

Abbiamo aggiunto il metodo [**AddEffect()**](https://reference.aspose.com/slides/it/net/aspose.slides.animation/sequence/methods/addeffect/index) alle classi [**Sequence**](https://reference.aspose.com/slides/it/net/aspose.slides.animation/sequence) e [**ISequence**](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence). Questo metodo consente di aggiungere effetti di animazione a un singolo paragrafo. Questo esempio di codice mostra come aggiungere un effetto di animazione a un singolo paragrafo:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // seleziona il paragrafo a cui aggiungere l'effetto
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // aggiungi l'effetto di animazione Fly al paragrafo selezionato
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Ottenere effetti di animazione per i paragrafi**

Potrebbe essere necessario scoprire gli effetti di animazione aggiunti a un paragrafo — ad esempio, in un caso d'uso, si vuole ottenere gli effetti di animazione in un paragrafo perché si intende applicare tali effetti a un altro paragrafo o forma.

Aspose.Slides per .NET consente di ottenere tutti gli effetti di animazione applicati ai paragrafi contenuti in una cornice di testo (forma). Questo esempio di codice mostra come ottenere gli effetti di animazione in un paragrafo:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Qual è la differenza tra animazioni del testo e transizioni delle diapositive, e possono essere combinate?**

Le animazioni del testo controllano il comportamento di un oggetto nel tempo su una diapositiva, mentre [transitions](/slides/it/net/slide-transition/) controllano come cambiano le diapositive. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è regolato dalla timeline dell'animazione e dalle impostazioni di transizione.

**Le animazioni del testo vengono conservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/net/convert-powerpoint-to-video/) o [HTML](/slides/it/net/export-to-html5/).

**Le animazioni del testo funzionano nei layout e nel master della diapositiva?**

Gli effetti applicati a oggetti di layout/master sono ereditati dalle diapositive, ma la loro tempistica e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.