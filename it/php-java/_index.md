---
title: Aspose.Slides per PHP via Java
second_title: Aspose.Slides per PHP
type: docs
weight: 45
url: /it/php-java/
keywords:
- documentazione
- elaborazione di presentazioni
- conversione di presentazioni
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per PHP via Java, crea una prima presentazione e trova le guide per le attività comuni, il riferimento API e il supporto."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java è una libreria di classi per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument nelle applicazioni PHP, senza Microsoft PowerPoint o automazione di Office.

Carica e salva file PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e modelli, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Per iniziare</b></p>
<hr>
<p>GUIDA INTRODUTTIVA</p>
<ul>
<li><a href="/slides/it/php-java/installation/">Installazione</a></li>
<li><a href="/slides/it/php-java/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/php-java/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTARE</p>
<ul>
<li><a href="/slides/it/php-java/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/php-java/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/php-java/licensing/">Licenza</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>ATTIVITÀ COMUNI</p>
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
<li><a href="/slides/it/php-java/presentation-design/">Design delle diapositive</a></li>
<li><a href="/slides/it/php-java/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/php-java/examples/">Esempi per elemento della diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento e supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/php-java/known-issues/">Problemi noti</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Pagina del prodotto</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Help desk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima presentazione**

Aspose.Slides for PHP via Java funziona su Java all’interno di Apache Tomcat, e i tuoi script PHP vi accedono tramite PHP/Java Bridge. [Installazione](/slides/it/php-java/installation/) configura PHP 8.3 o versioni precedenti, Java, Tomcat e il bridge, quindi installa il pacchetto da Packagist nella cartella del progetto:

```bash
composer require aspose/slides
```

Quindi copia il file JAR del pacchetto nel bridge e riavvia Tomcat, come nel passo 4 di [Installa su Linux](/slides/it/php-java/installation/#install-on-linux) o nel passo 6 di [Installa su Windows](/slides/it/php-java/installation/#install-on-windows). Con Tomcat in esecuzione, salva questo script come *hello.php* nella cartella del progetto ed eseguilo con `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

Lo script salva *hello.pptx* nella stessa directory, con una diapositiva che contiene una casella di testo. Senza licenza, il file salvato riporta un marchio di valutazione — vedi [Licenza](/slides/it/php-java/licensing/). Per ulteriori metodi di creazione e popolamento di una presentazione, consulta [Crea presentazioni](/slides/it/php-java/create-presentation/).