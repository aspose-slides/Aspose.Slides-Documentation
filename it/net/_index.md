---
title: Aspose.Slides per .NET
second_title: Aspose.Slides per .NET
type: docs
weight: 10
url: /it/net/
keywords:
- documentazione
- elaborazione di presentazioni
- conversione di presentazioni
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per .NET, crea una prima presentazione e trova le guide per le attività comuni, il deployment e il riferimento API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET è una libreria di classi per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument in applicazioni .NET, senza Microsoft PowerPoint o Office Automation.

Carica e salva PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e i modelli, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>PRIMI PASSI</p>
<ul>
<li><a href="/slides/it/net/installation/">Installazione</a></li>
<li><a href="/slides/it/net/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/net/system-requirements/">Requisiti di sistema</a></li>
<li><a href="/slides/it/net/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTARE</p>
<ul>
<li><a href="/slides/it/net/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/net/features-overview/">Panoramica delle funzionalità</a></li>
<li><a href="/slides/it/net/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/net/licensing/">Licenze</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Sviluppa con Slides</b></p>
<hr>
<p>OPERAZIONI COMUNI</p>
<ul>
<li><a href="/slides/it/net/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/net/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/net/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/net/convert-slide/">Rendi le diapositive come immagini</a></li>
<li><a href="/slides/it/net/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO DI SLIDES</p>
<ul>
<li><a href="/slides/it/net/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/net/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/net/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/net/presentation-design/">Design delle diapositive</a></li>
<li><a href="/slides/it/net/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/net/examples/">Esempi per elemento della diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Esempi su GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Distribuzione &amp; Supporto</b></p>
<hr>
<p>Distribuzione</p>
<ul>
<li><a href="/slides/it/net/net6/">Cross-platform (.NET 6+)</a></li>
<li><a href="/slides/it/net/how-to-run-aspose-slides-in-docker/">Esegui in Docker</a></li>
<li><a href="/slides/it/net/deploy-fonts/">Font</a></li>
<li><a href="/slides/it/net/security/">Sicurezza</a></li>
</ul>
<p>Riferimento</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/net/known-issues/">Problemi noti</a></li>
<li><a href="/slides/it/net/api-limitations/">Limitazioni dei metadati di output</a></li>
<li><a href="https://products.aspose.com/slides/net/">Pagina prodotto</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Download</a></li>
</ul>
<p>Supporto</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **La tua prima presentazione**

Crea un'applicazione console con .NET SDK 6 o successivo:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Quindi aggiungi un pacchetto per la tua piattaforma:

- Su Windows: `dotnet add package Aspose.Slides.NET`
- Su Linux e macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — vedi [Installazione](/slides/it/net/installation/) per il prerequisito Linux e per i sistemi che richiedono Aspose.Slides.NET invece.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Il programma salva *hello.pptx* con una diapositiva contenente una casella di testo. Senza licenza, il file salvato presenta una filigrana di valutazione — vedi [Licenze](/slides/it/net/licensing/). Per ulteriori modalità di creazione e compilazione di una presentazione, vedi [Crea presentazioni](/slides/it/net/create-presentation/).