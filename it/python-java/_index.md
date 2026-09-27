---
title: Aspose.Slides per Python via Java
second_title: Aspose.Slides per Python
type: docs
weight: 47
url: /it/python-java/
is_root: true
keywords:
- Aspose.Slides per Python via Java
- libreria PowerPoint per Python
- gestire presentazioni PowerPoint in Python
- leggere e scrivere PowerPoint in Python
- modificare diapositive PowerPoint in Python
- esportare PowerPoint in PDF in Python
- esportare PowerPoint in SVG in Python
- anteprima diapositive in Python
- aggiungere audio e video alle diapositive in Python
- PowerPoint senza Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per Python via Java, crea una prima presentazione e trova le guide per le operazioni comuni, il riferimento API e il supporto."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides per Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides per Python via Java è una libreria per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument in applicazioni Python, senza Microsoft PowerPoint; esegue il motore Aspose.Slides Java nel tuo processo Python tramite JPype.

Carica e salva PPT, PPTX, PPS, POT e ODP, inclusi i formati abilitati alle macro e le varianti modello, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>PRIMI PASSI</p>
<ul>
<li><a href="/slides/it/python-java/installation/">Installazione</a></li>
<li><a href="/slides/it/python-java/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/python-java/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTA</p>
<ul>
<li><a href="/slides/it/python-java/supported-file-formats/">Formati file supportati</a></li>
<li><a href="/slides/it/python-java/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/python-java/licensing/">Licenze</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>ATTIVITÀ COMUNI</p>
<ul>
<li><a href="/slides/it/python-java/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/python-java/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/python-java/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/python-java/convert-slide/">Rendi le diapositive come immagini</a></li>
<li><a href="/slides/it/python-java/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO DI SLIDE</p>
<ul>
<li><a href="/slides/it/python-java/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/python-java/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/python-java/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/python-java/presentation-design/">Design delle diapositive</a></li>
<li><a href="/slides/it/python-java/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/python-java/examples/">Esempi per elemento della diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento &amp; Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/it/python-java/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/it/python-java/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/python-java/known-issues/">Problemi noti</a></li>
<li><a href="https://releases.aspose.com/slides/it/python-java/">Download</a></li>
</ul>
<p>ASSISTENZA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/it/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima presentazione**

Installa Python e un JDK, imposta `JAVA_HOME` e crea e attiva un ambiente virtuale come descritto nella [Installazione](/slides/it/python-java/installation/). Quindi installa JPype e Aspose.Slides da PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Salva questo codice come *hello.py*. Avvia la Java Virtual Machine, aggiunge una forma a nuvola con testo alla prima diapositiva di una nuova presentazione e salva la presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Crea una presentazione con una diapositiva vuota.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma a nuvola e imposta il suo testo.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Salva la presentazione come file PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eseguilo nello stesso ambiente virtuale:

```sh
python hello.py
```

Lo script salva *new_presentation.pptx* con una diapositiva contenente una forma a nuvola con il testo "Hello, Aspose!". Senza licenza, il file salvato presenta anche un watermark di valutazione — vedi la [Licenza](/slides/it/python-java/licensing/). Per ulteriori modalità di creazione e compilazione di una presentazione, vedi [Crea presentazioni](/slides/it/python-java/create-presentation/).