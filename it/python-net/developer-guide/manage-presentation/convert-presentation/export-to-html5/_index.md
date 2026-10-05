---
title: Converti le presentazioni in HTML5 in Python
linktitle: Presentazione in HTML5
type: docs
weight: 40
url: /it/python-net/export-to-html5/
keywords:
- PowerPoint in HTML5
- OpenDocument in HTML5
- presentazione in HTML5
- diapositiva in HTML5
- PPT in HTML5
- PPTX in HTML5
- ODP in HTML5
- salva PPT come HTML5
- salva PPTX come HTML5
- salva ODP come HTML5
- esporta PPT in HTML5
- esporta PPTX in HTML5
- esporta ODP in HTML5
- Python
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per Python via .NET. Conserva la formattazione, le animazioni e l'interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 usando Aspose.Slides per Python via .NET. Copre l'esportazione di base, il controllo delle animazioni delle forme e delle transizioni delle diapositive, e il layout dei commenti. Confronta inoltre l'output HTML5 con l'output basato su SVG della normale esportazione HTML.

## **Esporta PowerPoint in HTML5**

L'esempio seguente carica una presentazione dalla directory di lavoro e la salva in formato HTML5. Usa le impostazioni di esportazione predefinite; l'esempio successivo mostra come controllare esplicitamente la riproduzione dell'animazione. Sostituisci il percorso di input con quello della tua presentazione.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}

Besides the HTML document, the export writes supporting CSS and JavaScript files for slide styling, animations, effects, and navigation. Keep these files with the HTML document when moving or publishing the output. The generated page also loads jQuery and Anime.js from public CDNs; without them, slide navigation and animations do not run.

{{% /alert %}}

Per esportare senza riprodurre le animazioni delle forme o le transizioni delle diapositive, impostare [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) e [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) su `False` in [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Queste impostazioni sono indipendenti, quindi è possibile abilitare una e disabilitare l'altra. L'esempio esporta la presentazione con entrambi i tipi di animazione disabilitati nella pagina generata.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Esporta PowerPoint in HTML**

L'esportazione HTML standard utilizza un approccio di rendering diverso: il contenuto della diapositiva è rappresentato da SVG all'interno di una pagina HTML. L'esempio seguente converte una presentazione in un documento HTML usando questo approccio di rendering.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Il markup semplificato sotto illustra la struttura della pagina generata. L'elemento SVG contiene il contenuto della diapositiva renderizzato; il testo segnaposto rappresenta quel contenuto e non è l'output letterale dell'esportazione.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}

The SVG-based export does not expose PowerPoint shapes as individual HTML elements. Use HTML5 export when you need the shape-animation and slide-transition options demonstrated in this article.

{{% /alert %}}

## **Esporta PowerPoint in Visualizzazione Diapositiva HTML5**

L'esportazione HTML5 produce una pagina per visualizzare e navigare le diapositive della presentazione in un browser. Questo esempio abilita sia [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) sia [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) in modo che la visualizzazione della diapositiva esportata possa riprodurre gli effetti dalla presentazione originale.

Usa una presentazione che contiene già animazioni delle forme e transizioni delle diapositive per vedere l'effetto di queste impostazioni. L'abilitazione non aggiunge nuovi effetti a diapositive che non ne hanno. Dopo l'esportazione, apri il documento HTML5 generato in un browser con i file di supporto disponibili.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Converti una Presentazione in un Documento HTML5 con Commenti**

È possibile includere i commenti delle diapositive esistenti nell'output HTML5 in modo che i lettori possano vedere il feedback accanto al contenuto della diapositiva. L'esempio in questa sezione si aspetta che la presentazione di origine contenga commenti, come illustrato sotto. Esporta quei commenti; non crea nuovi commenti.

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Assegna un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) alla proprietà [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) di [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Imposta [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) su `RIGHT` dall'enumerazione [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) per posizionare i commenti a destra di ogni diapositiva.

L'esempio seguente esporta la presentazione in HTML5 con questo layout dei commenti. Una presentazione senza commenti non avrà testo di commento da visualizzare.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

L'immagine sotto mostra il documento HTML5 esportato con i commenti visualizzati accanto alla diapositiva.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **Escludi i collegamenti ipertestuali JavaScript durante l'esportazione**

Supponiamo che `hyperlinks.pptx` contenga del testo collegato con un target `javascript:alert('Hello')` e un normale collegamento `https://example.com/`. Per escludere il collegamento ipertestuale JavaScript durante l'esportazione, imposta [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) su `True`. Il valore predefinito è `False`, quindi questi collegamenti non vengono filtrati a meno che non si abiliti l'opzione.

L'esempio seguente carica la presentazione dalla directory di lavoro e la esporta usando [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Il file esportato omette il collegamento ipertestuale JavaScript mantenendone il testo e il normale collegamento HTTPS. La presentazione di origine rimane invariata.

Questa opzione filtra i collegamenti ipertestuali JavaScript; non rimuove tutti gli script o altri contenuti attivi, né garantisce la conformità CSP. Per esempio, l'output HTML5 include ancora script per la navigazione e le animazioni delle diapositive.

## **FAQ**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, l'esportazione HTML5 fornisce opzioni separate per abilitare o disabilitare le [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) e le [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**I commenti sono supportati e dove possono essere posizionati rispetto alla diapositiva?**

Sì, i commenti esistenti possono essere inclusi nell'output HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) per note e commenti.

**Posso saltare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, l'impostazione [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) consente di saltare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Il valore predefinito è `False`. Vedi [Exclude JavaScript Hyperlinks During Export](/slides/it/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) per un esempio di esportazione HTML5 e l'ambito del filtro. Questa impostazione non rimuove lo JavaScript usato dal visualizzatore HTML5 per la navigazione e le animazioni.