---
title: Aspose.Slides para PHP via Java
second_title: Aspose.Slides para PHP
type: docs
weight: 45
url: /pt/php-java/
keywords:
- documentação
- processamento de apresentações
- conversão de apresentações
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Comece aqui: instale o Aspose.Slides para PHP via Java, crie sua primeira apresentação e encontre os guias para tarefas comuns, a referência da API e o suporte."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides para PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java é uma biblioteca de classes para criar, ler, editar e converter apresentações PowerPoint e OpenDocument em aplicações PHP, sem necessidade de Microsoft PowerPoint ou automação do Office.

Ele carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes com macro e modelos, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comece</b></p>
<hr>
<p>INICIANDO</p>
<ul>
<li><a href="/slides/pt/php-java/installation/">Instalação</a></li>
<li><a href="/slides/pt/php-java/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/php-java/getting-started/">Guia de introdução</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/php-java/supported-file-formats/">Formatos de arquivo suportados</a></li>
<li><a href="/slides/pt/php-java/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/php-java/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crie com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/php-java/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/php-java/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/php-java/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/php-java/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/php-java/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE TRABALHO DO SLIDES</p>
<ul>
<li><a href="/slides/pt/php-java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/php-java/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/php-java/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/php-java/presentation-design/">Design de slides</a></li>
<li><a href="/slides/pt/php-java/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/php-java/examples/">Exemplos por elemento de slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/pt/php-java/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/pt/php-java/release-notes/">Notas de versão</a></li>
<li><a href="/slides/pt/php-java/known-issues/">Problemas conhecidos</a></li>
<li><a href="https://releases.aspose.com/slides/pt/php-java/">Download</a></li>
</ul>
<p>SUPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/pt/11">Fórum de suporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de suporte pago</a></li>
</ul>
</div>
</div>

------

## **Sua primeira apresentação**

Aspose.Slides for PHP via Java funciona em Java dentro do Apache Tomcat, e seus scripts PHP o acessam através do PHP/Java Bridge. [Instalação](/slides/pt/php-java/installation/) configura PHP 8.3 ou anterior, Java, Tomcat e a ponte, e então instala o pacote do Packagist na pasta do projeto:

```bash
composer require aspose/slides
```

Em seguida copie o arquivo JAR do pacote para a ponte e reinicie o Tomcat, como no passo 4 de [Instalar no Linux](/slides/pt/php-java/installation/#install-on-linux) ou passo 6 de [Instalar no Windows](/slides/pt/php-java/installation/#install-on-windows). Com o Tomcat em execução, salve este script como *hello.php* na pasta do projeto e execute `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pt/lib/aspose.slides.php");

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

O script salva *hello.pptx* ao lado dele, com um slide contendo uma caixa de texto. Sem uma licença, o arquivo salvo contém uma marca d'água de avaliação — veja [Licenciamento](/slides/pt/php-java/licensing/). Para mais maneiras de criar e preencher uma apresentação, veja [Criar Apresentações](/slides/pt/php-java/create-presentation/).