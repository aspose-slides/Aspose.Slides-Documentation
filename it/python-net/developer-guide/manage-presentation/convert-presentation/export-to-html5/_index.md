---
title: Converti presentazioni in HTML5 con Python
linktitle: Esporta in HTML5
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
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- converti diapositiva
- esportazione HTML5
- esporta presentazione
- esporta diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per Python su .NET. Mantieni la formattazione, le animazioni e l'interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides. Copre l’esportazione di base in HTML5 senza estensioni web o dipendenze aggiuntive, nonché le opzioni per controllare le animazioni delle forme e le transizioni delle diapositive. L’articolo mostra anche il processo standard di esportazione da PowerPoint a HTML, descrive come generare output HTML5 in modalità visualizzazione diapositiva e dimostra come includere i commenti nel documento esportato configurandone il layout.

## **Esporta PowerPoint in HTML5**

Questo codice Python mostra come esportare una presentazione in HTML5 senza estensioni web né dipendenze:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
In questo caso, ottieni HTML pulito. 
{{% /alert %}}

Potresti voler specificare le impostazioni per le animazioni delle forme e le transizioni delle diapositive in questo modo:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Esporta PowerPoint in HTML**

Questo codice Python dimostra il processo standard di esportazione da PowerPoint a HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

In questo caso, il contenuto della presentazione è renderizzato tramite SVG in una forma come questa:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Nota" color="warning" %}} 
Quando utilizzi questo metodo per esportare PowerPoint in HTML, a causa del rendering SVG, non potrai applicare stili o animare elementi specifici. 
{{% /alert %}}

## **Esporta PowerPoint in visualizzazione diapositiva HTML5**

**Aspose.Slides** consente di convertire una presentazione PowerPoint in un documento HTML5 in cui le diapositive sono presentate in modalità visualizzazione diapositiva. In questo caso, aprendo il file HTML5 risultante in un browser, si vede la presentazione in modalità visualizzazione diapositiva su una pagina web. 

Questo codice Python dimostra il processo di esportazione da PowerPoint a visualizzazione diapositiva HTML5:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Esporta una presentazione contenente transizioni delle diapositive, animazioni e animazioni delle forme in HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Salva la presentazione
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Converti una presentazione in un documento HTML5 con commenti**

I commenti in PowerPoint sono uno strumento che consente agli utenti di lasciare note o feedback sulle diapositive della presentazione. Sono particolarmente utili nei progetti collaborativi, dove più persone possono aggiungere suggerimenti o osservazioni a elementi specifici della diapositiva senza modificare il contenuto principale. Ogni commento mostra il nome dell’autore, facilitando l’individuazione di chi ha lasciato l’osservazione.

Supponiamo di avere la seguente presentazione PowerPoint salvata nel file "sample.pptx".

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Quando converti una presentazione PowerPoint in un documento HTML5, puoi facilmente specificare se includere i commenti della presentazione nel documento di output. Per farlo, devi impostare i parametri di visualizzazione dei commenti nella proprietà `notes_comments_layouting` della classe [Html5Options](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/).

Il seguente esempio di codice converte una presentazione in un documento HTML5 con i commenti visualizzati a destra delle diapositive.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Il documento "output.html" è mostrato nell’immagine seguente.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **FAQ**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, HTML5 fornisce opzioni separate per abilitare o disabilitare le [animazioni delle forme](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/animate_shapes/) e le [transizioni delle diapositive](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/animate_transitions/).

**Il supporto per i commenti è presente e dove possono essere posizionati rispetto alla diapositiva?**

Sì, i commenti possono essere aggiunti in HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/notes_comments_layouting/) per note e commenti.

**Posso omettere i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, esiste una [impostazione](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/skip_java_script_links/) che consente di saltare gli hyperlink con chiamate JavaScript durante il salvataggio. Questo aiuta a rispettare politiche di sicurezza rigorose.