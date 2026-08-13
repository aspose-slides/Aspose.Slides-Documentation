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
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per .NET. Conserva formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides. Copre l'esportazione di base in HTML5, nonché le opzioni per controllare le animazioni delle forme e le transizioni delle diapositive. L'articolo mostra anche il processo standard di esportazione da PowerPoint a HTML, spiega come generare l'output HTML5 in modalità visualizzazione diapositiva e dimostra come includere i commenti nel documento esportato configurandone il layout.

## **Esporta PowerPoint in HTML5**

Questo codice C# mostra come esportare una presentazione in HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
Oltre al documento HTML, l'esportazione scrive i file di supporto a cui fa riferimento: `pres.css`, `master.css`, `animation.js`, `effects.js` e `navigation.js`. La pagina generata carica anche jQuery e Anime.js da CDN pubblici; senza di essi la navigazione delle diapositive e le animazioni non funzionano. 
{{% /alert %}}

È possibile specificare le impostazioni per le animazioni delle forme e le transizioni delle diapositive in questo modo:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Esporta PowerPoint in HTML**

Questo C# dimostra il processo standard di esportazione da PowerPoint a HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

In questo caso, il contenuto della presentazione viene renderizzato tramite SVG in una forma come questa:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Quando utilizzi questo metodo per esportare PowerPoint in HTML, a causa del rendering SVG, non potrai applicare stili o animare elementi specifici. 
{{% /alert %}}

## **Esporta PowerPoint in visualizzazione diapositiva HTML5**

**Aspose.Slides** consente di convertire una presentazione PowerPoint in un documento HTML5 in cui le diapositive sono presentate in modalità visualizzazione diapositiva. In questo caso, quando apri il file HTML5 risultante in un browser, vedi la presentazione in modalità visualizzazione diapositiva su una pagina web. 

Questo codice C# dimostra il processo di esportazione da PowerPoint a HTML5 in modalità visualizzazione diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Converti una presentazione in un documento HTML5 con commenti**

I commenti in PowerPoint sono uno strumento che consente agli utenti di lasciare note o feedback sulle diapositive della presentazione. Sono particolarmente utili nei progetti collaborativi, in cui più persone possono aggiungere suggerimenti o osservazioni a elementi specifici della diapositiva senza modificare il contenuto principale. Ogni commento mostra il nome dell'autore, facilitando l'individuazione di chi ha lasciato l'osservazione.

Supponiamo di avere la seguente presentazione PowerPoint salvata nel file "sample.pptx".

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Quando converti una presentazione PowerPoint in un documento HTML5, puoi facilmente specificare se includere i commenti della presentazione nel documento di output. Per fare ciò, è necessario specificare i parametri di visualizzazione dei commenti nella proprietà `NotesCommentsLayouting` della classe [Html5Options](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/).

Il seguente esempio di codice converte una presentazione in un documento HTML5 con i commenti visualizzati a destra delle diapositive.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Il documento "output.html" è mostrato nell'immagine sottostante.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **FAQ**

### Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?

Sì, HTML5 offre opzioni separate per abilitare o disabilitare le [animazioni delle forme](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/animateshapes/) e le [transizioni delle diapositive](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/animatetransitions/).

### È supportata l'esportazione dei commenti e dove possono essere posizionati rispetto alla diapositiva?

Sì, i commenti possono essere aggiunti in HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/notescommentslayouting/) per note e commenti.

### Posso ignorare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?

Sì, esiste un [impostazione](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) che consente di ignorare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Questo aiuta a rispettare politiche di sicurezza rigorose.