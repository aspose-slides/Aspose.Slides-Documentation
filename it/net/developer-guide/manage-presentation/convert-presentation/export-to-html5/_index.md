---
title: Converti le presentazioni in HTML5 con .NET
linktitle: Presentazione in HTML5
type: docs
weight: 40
url: /it/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 responsive con Aspose.Slides per .NET. Conserva formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 usando Aspose.Slides per .NET. Copre l'esportazione di base, il controllo delle animazioni delle forme e delle transizioni delle diapositive, e il layout dei commenti. Confronta inoltre l'output HTML5 con l'output basato su SVG dell'esportazione HTML standard.

## **Esporta PowerPoint in HTML5**

L'esempio seguente carica una presentazione dalla directory di lavoro e la salva in formato HTML5. Usa le impostazioni di esportazione predefinite; l'esempio successivo mostra come controllare esplicitamente la riproduzione delle animazioni. Sostituisci il percorso di input con quello della tua presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Accanto al documento HTML, l'esportazione scrive file CSS e JavaScript di supporto per lo stile delle diapositive, le animazioni, gli effetti e la navigazione. Mantieni questi file insieme al documento HTML quando sposti o pubblichi l'output. La pagina generata carica anche jQuery e Anime.js da CDN pubblici; senza di essi, la navigazione delle diapositive e le animazioni non funzionano.
{{% /alert %}}

Per esportare senza riprodurre le animazioni delle forme o le transizioni delle diapositive, imposta [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) e [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) su `false` in [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Queste impostazioni sono indipendenti, quindi è possibile abilitare una e disabilitare l'altra. L'esempio esporta la presentazione con entrambi i tipi di animazione disabilitati nella pagina generata.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Esporta PowerPoint in HTML**

L'esportazione HTML standard utilizza un approccio di rendering diverso: il contenuto della diapositiva è rappresentato da SVG all'interno di una pagina HTML. L'esempio seguente converte una presentazione in un documento HTML usando questo approccio di rendering.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Il markup semplificato di seguito illustra la struttura della pagina generata. L'elemento SVG contiene il contenuto della diapositiva renderizzato; il testo segnaposto rappresenta quel contenuto e non è l'output reale dell'esportazione.

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
L'esportazione basata su SVG non espone le forme PowerPoint come singoli elementi HTML. Usa l'esportazione HTML5 quando hai bisogno delle opzioni di animazione delle forme e di transizione delle diapositive dimostrate in questo articolo.
{{% /alert %}}

## **Esporta PowerPoint in Visualizzazione Diapositive HTML5**

L'esportazione HTML5 produce una pagina per visualizzare e navigare le diapositive della presentazione in un browser. Questo esempio abilita sia [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) sia [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) affinché la visualizzazione della diapositiva esportata possa riprodurre gli effetti della presentazione originale.

Usa una presentazione che contenga già animazioni delle forme e transizioni delle diapositive per vedere l'effetto di queste impostazioni. Abilitarle non aggiunge nuovi effetti a diapositive che non ne hanno. Dopo l'esportazione, apri il documento HTML5 generato in un browser con i file di supporto disponibili.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Converti una Presentazione in un Documento HTML5 con Commenti**

Puoi includere i commenti delle diapositive esistenti nell'output HTML5 in modo che i lettori possano vedere il feedback accanto al contenuto della diapositiva. L'esempio in questa sezione si aspetta che la presentazione sorgente contenga commenti, come illustrato di seguito. Esporta quei commenti; non ne crea di nuovi.

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Assegna un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) alla proprietà [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) di [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Imposta [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) su `Right` dall'enumerazione [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) per posizionare i commenti a destra di ogni diapositiva.

L'esempio seguente esporta la presentazione in HTML5 con questo layout dei commenti. Una presentazione senza commenti non avrà testo di commento da visualizzare.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

L'immagine qui sotto mostra il documento HTML5 esportato con i commenti visualizzati accanto alla diapositiva.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **Escludi i collegamenti ipertestuali JavaScript durante l'esportazione**

Supponi che `hyperlinks.pptx` contenga testo collegato con un target `javascript:alert('Hello')` e un normale collegamento `https://example.com/`. Per escludere il collegamento ipertestuale JavaScript durante l'esportazione, imposta [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) su `true`. Il valore predefinito è `false`, quindi questi collegamenti non vengono filtrati a meno che non abiliti l'opzione.

L'esempio seguente carica la presentazione dalla directory di lavoro ed esporta utilizzando [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Il file esportato omette il collegamento ipertestuale JavaScript mantenendo il suo testo e il normale collegamento HTTPS. La presentazione sorgente rimane invariata.

Questa opzione filtra i collegamenti ipertestuali JavaScript; non rimuove tutti gli script o altri contenuti attivi, né garantisce la conformità CSP. Ad esempio, l'output HTML5 include ancora script per la navigazione delle diapositive e le animazioni.

## **Domande frequenti**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, l'esportazione HTML5 fornisce opzioni separate per abilitare o disabilitare le [animazioni delle forme](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) e le [transizioni delle diapositive](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**I commenti sono supportati e dove possono essere posizionati rispetto alla diapositiva?**

Sì, i commenti esistenti possono essere inclusi nell'output HTML5 e posizionati (ad esempio, a destra della diapositiva) attraverso le [impostazioni di layout](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) per note e commenti.

**Posso saltare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, l'impostazione [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) consente di ignorare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Il valore predefinito è `false`. Vedi [Escludi i collegamenti ipertestuali JavaScript durante l'esportazione](/slides/it/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) per un semplice esempio di esportazione HTML, HTML5 e PDF e l'ambito del filtro. Questa impostazione non rimuove il JavaScript usato dal visualizzatore HTML5 per la navigazione e le animazioni.