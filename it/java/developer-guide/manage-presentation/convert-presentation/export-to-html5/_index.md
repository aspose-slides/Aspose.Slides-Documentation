---
title: Converti le presentazioni in HTML5 in Java
linktitle: Presentazione in HTML5
type: docs
weight: 40
url: /it/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Esporta le presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per Java. Conserva la formattazione, le animazioni e l'interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides per Java. Copre l'esportazione di base, il controllo delle animazioni delle forme e delle transizioni delle diapositive, e il layout dei commenti. Confronta inoltre l'output HTML5 con l'output basato su SVG dell'esportazione HTML standard.

## **Esporta PowerPoint in HTML5**

L'esempio seguente carica una presentazione dalla directory di lavoro e la salva in formato HTML5. Utilizza le impostazioni di esportazione predefinite; l'esempio successivo mostra come controllare esplicitamente la riproduzione delle animazioni. Sostituisci il percorso di input con il percorso della tua presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Oltre al documento HTML, l'esportazione scrive i file CSS e JavaScript di supporto per lo stile delle diapositive, le animazioni, gli effetti e la navigazione. Conserva questi file insieme al documento HTML quando sposti o pubblichi l'output. La pagina generata carica inoltre jQuery e Anime.js da CDN pubblici; senza di essi, la navigazione delle diapositive e le animazioni non funzionano.
{{% /alert %}}

Per esportare senza riprodurre le animazioni delle forme o le transizioni delle diapositive, passa `false` a [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Queste impostazioni sono indipendenti, quindi puoi abilitare una disabilitando l'altra. L'esempio esporta la presentazione con entrambi i tipi di animazione disabilitati nella pagina generata.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Esporta PowerPoint in HTML**

L'esportazione HTML standard utilizza un approccio di rendering differente: il contenuto della diapositiva è rappresentato da SVG all'interno di una pagina HTML. L'esempio seguente converte una presentazione in un documento HTML usando questo approccio di rendering.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Il markup semplificato qui sotto illustra la struttura della pagina generata. L'elemento SVG contiene il contenuto della diapositiva renderizzato; il testo segnaposto rappresenta quel contenuto e non è l'output effettivo dell'esportazione.

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
L'esportazione basata su SVG non espone le forme di PowerPoint come singoli elementi HTML. Usa l'esportazione HTML5 quando hai bisogno delle opzioni di animazione delle forme e di transizione delle diapositive dimostrate in questo articolo.
{{% /alert %}}

## **Esporta PowerPoint in visualizzazione diapositiva HTML5**

L'esportazione HTML5 produce una pagina per visualizzare e navigare le diapositive della presentazione in un browser. Questo esempio abilita sia [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in modo che la vista della diapositiva esportata possa riprodurre gli effetti dalla presentazione originale.

Usa una presentazione che contiene già animazioni di forme e transizioni di diapositive per vedere l'effetto di queste impostazioni. Abilitandole non aggiunge nuovi effetti alle diapositive che non ne hanno. Dopo l'esportazione, apri il documento HTML5 generato in un browser con i file di supporto disponibili.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Converti una presentazione in un documento HTML5 con commenti**

Puoi includere i commenti delle diapositive esistenti nell'output HTML5 affinché i lettori possano vedere il feedback accanto al contenuto della diapositiva. L'esempio in questa sezione presume che la presentazione di origine contenga commenti, come illustrato di seguito. Esporta quei commenti; non ne crea di nuovi.

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Passa un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) al metodo [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) di [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Usa [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) per selezionare `Right` dall'enumerazione [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) per posizionare i commenti a destra di ogni diapositiva.

L'esempio seguente esporta la presentazione in HTML5 con questo layout dei commenti. Una presentazione senza commenti non avrà testo di commento da visualizzare.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

L'immagine seguente mostra il documento HTML5 esportato con i commenti visualizzati accanto alla diapositiva.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **Escludi i collegamenti ipertestuali JavaScript durante l'esportazione**

Supponiamo che `hyperlinks.pptx` contenga testo collegato con un target `javascript:alert('Hello')` e un normale collegamento `https://example.com/`. Per escludere il collegamento ipertestuale JavaScript durante l'esportazione, passa `true` a [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Il valore predefinito è `false`, quindi questi collegamenti non vengono filtrati a meno che non abiliti l'opzione.

L'esempio seguente carica la presentazione dalla directory di lavoro e la esporta usando [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Il file esportato omette il collegamento ipertestuale JavaScript mantenendo il suo testo e il normale collegamento HTTPS. La presentazione di origine rimane invariata.

Questa opzione filtra i collegamenti ipertestuali JavaScript; non rimuove tutti gli script o altri contenuti attivi, né garantisce la conformità CSP. Ad esempio, l'output HTML5 include ancora script per la navigazione e le animazioni delle diapositive.

## **FAQ**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, l'esportazione HTML5 fornisce opzioni separate per abilitare o disabilitare le [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e le [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**I commenti sono supportati e dove possono essere posizionati rispetto alla diapositiva?**

Sì, i commenti esistenti possono essere inclusi nell'output HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) per note e commenti.

**Posso saltare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, l'impostazione [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) permette di saltare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Il valore predefinito è `false`. Vedi [Exclude JavaScript Hyperlinks During Export](/slides/it/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) per un esempio di esportazione HTML5 e la portata del filtro. Questa impostazione non rimuove il JavaScript usato dal visualizzatore HTML5 per la navigazione e le animazioni.