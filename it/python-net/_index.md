---
title: Aspose.Slides per Python via .NET
second_title: Aspose.Slides per Python
type: docs
weight: 35
url: /it/python-net/
is_root: true
keywords:
- Aspose.Slides per Python
- Automazione PowerPoint Python
- Libreria PPT Python
- Esporta PowerPoint in PDF Python
- Esporta PowerPoint in SVG Python
- Modifica PowerPoint in Python
- PowerPoint Python senza Microsoft Office
- Gestisci PPTX con Python
- Anteprima slide Python
- Aggiungi audio alle slide con Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per Python via .NET, crea una prima presentazione e trovi le guide per le attività comuni, il riferimento API e il supporto."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides per Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET è una libreria Python per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument, senza Microsoft PowerPoint o Microsoft Office.

Carica e salva PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e template, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIO</p>
<ul>
<li><a href="/slides/it/python-net/installation/">Installazione</a></li>
<li><a href="/slides/it/python-net/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/python-net/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTAZIONE</p>
<ul>
<li><a href="/slides/it/python-net/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/python-net/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/python-net/licensing/">Licenza</a></li>
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
<p>FLUSSI DI LAVORO SLIDES</p>
<ul>
<li><a href="/slides/it/python-net/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/python-net/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/python-net/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/python-net/presentation-design/">Design delle diapositive</a></li>
<li><a href="/slides/it/python-net/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/python-net/examples/">Esempi per elemento di diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Esempi su GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento &amp; Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/it/python-net/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/it/python-net/release-notes/">Note di rilascio</a></li>
<li><a href="https://releases.aspose.com/slides/it/python-net/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/it/11">Forum di supporto gratuito</a></li>
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

Il pacchetto include il runtime .NET che utilizza, quindi non è necessario installare .NET. Su Linux, installa anche le librerie libgdiplus e ICU, e con il Python di sistema di Debian o Ubuntu, esegui il comando in un ambiente virtuale. macOS ha ulteriori prerequisiti e non abbiamo verificato l'installazione su quella piattaforma. Vedi [Installazione](/slides/it/python-net/installation/) per i comandi, i prerequisiti di macOS e le versioni Python supportate.

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

Eseguilo con `python hello.py`. Lo script salva *new_presentation.pptx* nella cartella corrente, con una diapositiva contenente una forma nuvola che riporta "Hello, Aspose!". Senza licenza, il file salvato contiene una filigrana di valutazione — vedi [Licenza](/slides/it/python-net/licensing/). Per altri modi di creare e riempire una presentazione, vedi [Creare presentazioni](/slides/it/python-net/create-presentation/).