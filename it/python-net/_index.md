---
title: Aspose.Slides per Python tramite .NET
second_title: Aspose.Slides per Python
type: docs
weight: 35
url: /it/python-net/
is_root: true
keywords:
- Aspose.Slides per Python
- Automazione PowerPoint Python
- Libreria PPT Python
- Esporta PowerPoint in PDF con Python
- Esporta PowerPoint in SVG con Python
- Modifica PowerPoint con Python
- PowerPoint Python senza Microsoft Office
- Gestisci PPTX con Python
- Anteprima diapositive Python
- Python aggiunge audio alle diapositive
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides per Python tramite .NET offre un set completo di funzionalità, tra cui gestione di testo, forme, tabelle e animazioni, aggiunta di audio e video alle diapositive, anteprima delle diapositive e esportazione in SVG, PDF e altro."
---
{{% alert color="info" %}}

**Benvenuti in Aspose.Slides per Python tramite .NET**

![Logo del prodotto Aspose.Slides per Python tramite .NET](aspose_slides-for-python.png)

Aspose.Slides per Python tramite .NET è una robusta libreria di classi che consente alle tue applicazioni di leggere e scrivere presentazioni PowerPoint® senza richiedere Microsoft PowerPoint®.

È il primo e unico componente che fornisce una gestione completa dei documenti PowerPoint® per gli sviluppatori Python.

Aspose.Slides per Python tramite .NET include una vasta gamma di funzionalità come la gestione di testo, forme, tabelle e animazioni; l'aggiunta di audio e video; l'anteprima delle diapositive; e l'esportazione delle diapositive in formati come SVG, PDF e altro.

{{% /alert %}}

## Installa Aspose.Slides per Python tramite .NET

```bash
pip install aspose.slides
```

Il pacchetto include il runtime .NET necessario, quindi non è necessario installare altro e Microsoft PowerPoint non è richiesto. Python 3.7 o versioni successive su Windows, Linux o macOS.

## Crea una presentazione PowerPoint in Python

Questo esempio crea una presentazione, aggiunge una forma con testo alla prima diapositiva e salva il risultato sia in PPTX che in PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

L'esecuzione crea `presentation.pptx` (circa 34 KB) e `presentation.pdf` (circa 36 KB) nella directory di lavoro.

Senza licenza la libreria funziona in modalità di valutazione, che aggiunge una filigrana e limita il numero di diapositive. Vedi [Licensing](/slides/it/python-net/licensing/) per applicarne una.

## Risorse di Aspose.Slides per Python tramite .NET

Esplora queste risorse utili:

- [Documentazione online di Aspose.Slides per Python tramite .NET](/slides/it/python-net/)
- [Funzionalità di Aspose.Slides per Python tramite .NET](/slides/it/python-net/features-overview/)
- [Note di rilascio di Aspose.Slides per Python tramite .NET](https://releases.aspose.com/slides/it/python-net/release-notes/)
- [Pagina del prodotto Aspose.Slides per Python tramite .NET](https://products.aspose.com/slides/it/python-net/)
- [Download di Aspose.Slides per Python tramite .NET](https://releases.aspose.com/slides/it/python-net/)
- [Installa il pacchetto PyPi di Aspose.Slides per Python tramite .NET](https://pypi.org/project/aspose.slides/)
- [Guida di riferimento API di Aspose.Slides per Python tramite .NET](https://reference.aspose.com/slides/it/python-net/)
- [Forum di supporto gratuito di Aspose.Slides per Python tramite .NET](https://forum.aspose.com/c/slides/it/11)
- [Helpdesk di supporto a pagamento di Aspose.Slides per Python tramite .NET](https://helpdesk.aspose.com/)

## FAQ

### Cos'è Aspose.Slides per Python tramite .NET?

Aspose.Slides per Python tramite .NET è una potente libreria Python che consente di creare, modificare e convertire presentazioni PowerPoint (PPT, PPTX, ODP) in modo programmatico senza la necessità di Microsoft PowerPoint installato.

### Quali funzionalità di presentazione supporta Aspose.Slides?

La libreria supporta la gestione di testo, forme, tabelle, grafici, animazioni, diapositive master, audio, video e altro. Consente inoltre l'anteprima delle diapositive, il rendering e l'esportazione in formati come PDF, SVG, HTML e immagini.

### Posso convertire le presentazioni in altri formati usando Aspose.Slides?

Sì. Aspose.Slides consente la conversione dei file PowerPoint in PDF, SVG, HTML, JPG, PNG, TIFF e altri formati con alta fedeltà e prestazioni.

### È necessario Microsoft PowerPoint per utilizzare Aspose.Slides?

No. Aspose.Slides è un'API autonoma e non richiede Microsoft Office o alcun software di terze parti.

### Quali piattaforme supporta Aspose.Slides per Python tramite .NET?

È multipiattaforma e funziona su ambienti Windows, Linux e macOS.

### Come iniziare con Aspose.Slides per Python?

Puoi installarlo tramite PyPi ed esplorare la [Developer Guide](/slides/it/python-net/developer-guide/) per iniziare con esempi, riferimenti API e tutorial.