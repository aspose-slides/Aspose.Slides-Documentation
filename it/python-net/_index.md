---
title: Aspose.Slides per Python via .NET
second_title: Aspose.Slides per Python
type: docs
weight: 35
url: /it/python-net/
is_root: true
keywords:
- Aspose.Slides per Python
- automazione PowerPoint con Python
- libreria PPT per Python
- esportazione PowerPoint in PDF con Python
- esportazione PowerPoint in SVG con Python
- modifica PowerPoint con Python
- PowerPoint per Python senza Microsoft Office
- gestione PPTX con Python
- anteprima di diapositive con Python
- aggiungi audio alle diapositive con Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per Python via .NET, crea una prima presentazione e trova le guide per le attività comuni, il riferimento API e il supporto."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides per Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides per Python via .NET è una libreria Python per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument, senza Microsoft PowerPoint né Microsoft Office.

Carica e salva i formati PPT, PPTX, PPS, POT e ODP, inclusi le varianti con macro e i modelli, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIARE</p>
<ul>
<li><a href="/slides/it/python-net/installation/">Installazione</a></li>
<li><a href="/slides/it/python-net/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/python-net/getting-started/">Guida per iniziare</a></li>
</ul>
<p>VALUTAZIONE</p>
<ul>
<li><a href="/slides/it/python-net/supported-file-formats/">Formati file supportati</a></li>
<li><a href="/slides/it/python-net/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/python-net/licensing/">Licenze</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>ATTIVITÀ COMUNI</p>
<ul>
<li><a href="/slides/it/python-net/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/python-net/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/python-net/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/python-net/convert-slide/">Rendi le diapositive come immagini</a></li>
<li><a href="/slides/it/python-net/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO DI SLIDES</p>
<ul>
<li><a href="/slides/it/python-net/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/python-net/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/python-net/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/python-net/presentation-design/">Design della diapositiva</a></li>
<li><a href="/slides/it/python-net/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/python-net/examples/">Esempi per elemento della diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Esempi su GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento e Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Note di rilascio</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Pagina prodotto</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima presentazione**

Installa il pacchetto da PyPI:

```bash
pip install aspose.slides
```

Il pacchetto include il runtime .NET che utilizza, quindi non è necessario installare .NET. Su Linux, installa anche le librerie libgdiplus e ICU, e con il Python di sistema di Debian o Ubuntu, esegui il comando in un ambiente virtuale. macOS ha ulteriori prerequisiti e non abbiamo verificato l'installazione su di esso. Vedi [Installazione](/slides/it/python-net/installation/) per i comandi, i prerequisiti per macOS e le versioni di Python supportate.

Salva questo codice come *hello.py*:

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Salva la presentazione come file PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Eseguilo con `python hello.py`. Lo script salva *new_presentation.pptx* nella cartella corrente, con una diapositiva che contiene una forma a nuvola con il testo "Hello, Aspose!". Senza una licenza, il file salvato contiene un watermark di valutazione — vedi [Licenza](/slides/it/python-net/licensing/). Per ulteriori modalità di creare e riempire una presentazione, vedi [Crea presentazioni](/slides/it/python-net/create-presentation/).