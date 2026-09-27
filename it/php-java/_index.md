---
title: Aspose.Slides per PHP via Java
second_title: Aspose.Slides per PHP
type: docs
weight: 45
url: /it/php-java/
keywords:
- documentazione
- elaborazione delle presentazioni
- conversione delle presentazioni
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per PHP via Java, crea una prima presentazione e trova le guide per attività comuni, il riferimento API e il supporto."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides per PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides per PHP via Java è una libreria di classi per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument in applicazioni PHP, senza Microsoft PowerPoint o Office Automation.

Carica e salva PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e modello, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Per Iniziare</b></p>
<hr>
<p>INIZIARE</p>
<ul>
<li><a href="/slides/it/php-java/installation/">Installazione</a></li>
<li><a href="/slides/it/php-java/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/php-java/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTARE</p>
<ul>
<li><a href="/slides/it/php-java/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/php-java/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/php-java/licensing/">Licenze</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>COMPITI COMUNI</p>
<ul>
<li><a href="/slides/it/php-java/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/php-java/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/php-java/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/php-java/convert-slide/">Renderizza le diapositive come immagini</a></li>
<li><a href="/slides/it/php-java/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO DI SLIDES</p>
<ul>
<li><a href="/slides/it/php-java/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/php-java/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/php-java/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/php-java/presentation-design/">Progettazione di diapositive</a></li>
<li><a href="/slides/it/php-java/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/php-java/examples/">Esempi per elemento della diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento e Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/it/php-java/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/it/php-java/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/php-java/known-issues/">Problemi noti</a></li>
<li><a href="https://releases.aspose.com/slides/it/php-java/">Download</a></li>
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

Aspose.Slides per PHP via Java funziona su Java all'interno di Apache Tomcat, e i tuoi script PHP vi accedono tramite PHP/Java Bridge. [Installazione](/slides/it/php-java/installation/) configura PHP 8.3 o versioni precedenti, Java, Tomcat e il bridge, quindi installa il pacchetto da Packagist nella cartella del progetto:

```bash
composer require aspose/slides
```

Quindi copia il file JAR del pacchetto nel bridge e riavvia Tomcat, come nel passo 4 di [Install on Linux](/slides/it/php-java/installation/#install-on-linux) o nel passo 6 di [Install on Windows](/slides/it/php-java/installation/#install-on-windows). Con Tomcat in esecuzione, salva questo script come *hello.php* nella cartella del progetto ed esegui `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/it/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lo script salva *hello.pptx* accanto a sé, con una diapositiva che contiene una casella di testo. Senza licenza, il file salvato presenta una filigrana di valutazione — vedi [Licenze](/slides/it/php-java/licensing/). Per ulteriori modi di creare e compilare una presentazione, consulta [Create Presentations](/slides/it/php-java/create-presentation/).