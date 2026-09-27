---
title: Criar apresentações em PHP
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/php-java/create-presentation/
keywords:
- criar apresentação
- nova apresentação
- criar PPT
- novo PPT
- criar PPTX
- novo PPTX
- criar ODP
- novo ODP
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Crie apresentações com Aspose.Slides para PHP via Java — produza arquivos PPT, PPTX e ODP e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar uma caixa de texto ao seu primeiro slide e salvar o resultado como um arquivo. Também demonstra como criar e salvar uma apresentação vazia e como abrir uma apresentação existente em um formato suportado e salvá‑la em outro formato. Um breve FAQ ao final cobre perguntas comuns sobre formatos, modelos, dimensionamento de slides, unidades, uso de memória, multithreading, licenciamento, assinaturas digitais e suporte a VBA.

Antes de começar, instale o Aspose.Slides para PHP via Java com o Composer e inicie o PHP/Java Bridge no Apache Tomcat. Consulte [Instalação](/slides/pt/php-java/installation/) para a configuração completa. Os exemplos abaixo pressupõem que o Tomcat está em execução em `localhost:8080` e que a pasta `vendor` do Composer está ao lado do script.

## **Criar uma apresentação PowerPoint**

Para criar uma apresentação e colocar uma caixa de texto no seu primeiro slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.
1. Recupere esse slide da coleção retornada por [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/), pelo índice 0.
1. Adicione um retângulo com o método [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) e defina seu texto com [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).
1. Salve a apresentação como um arquivo PPTX com o método [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/).

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

As duas linhas `require_once` carregam o cliente PHP/Java Bridge do Tomcat e as classes Aspose.Slides do pacote Composer. O canto superior esquerdo do retângulo está a 50 pontos da borda esquerda e a 50 pontos da borda superior do slide, e o retângulo tem 400 pontos de largura e 100 pontos de altura. O arquivo salvo contém um slide com esse retângulo e seu texto. Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide salvo; veja [Licenciamento](/slides/pt/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides lê e grava arquivos dentro do Tomcat, não no seu processo PHP, portanto um caminho relativo como `"hello.pptx"` é resolvido em relação à pasta de trabalho do Tomcat. Os exemplos nesta página constroem caminhos absolutos com `__DIR__`, de modo que os arquivos são lidos e gravados ao lado do script.
{{% /alert %}}

## **Criar e salvar uma apresentação**

Para criar uma apresentação vazia e salvá‑la, crie uma instância da classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e salve‑a em qualquer formato da enumeração [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/). O resultado é uma apresentação com um slide vazio.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pt/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Abrir e salvar uma apresentação**

Para converter uma apresentação de um formato para outro, abra‑a passando seu caminho ao construtor [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), então salve‑a no formato de destino. O Aspose.Slides detecta o formato de entrada, como PPT, PPTX ou ODP, a partir do próprio arquivo.

O exemplo abaixo pressupõe uma apresentação OpenDocument chamada *Sample.odp* ao lado do script e a salva como PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pt/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### Em quais formatos posso salvar uma nova apresentação?

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/php-java/save-presentation/), e exportar para [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/php-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/php-java/convert-powerpoint-to-html/), [SVG](/slides/pt/php-java/render-a-slide-as-an-svg-image/) e [imagens](/slides/pt/php-java/convert-powerpoint-to-png/), entre outros.

### Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX normal?

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e similares [são suportados](/slides/pt/php-java/supported-file-formats/).

### Como controlo o tamanho/ proporção dos slides ao criar uma apresentação?

Defina o [tamanho do slide](/slides/pt/php-java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser escalado.

### Em quais unidades os tamanhos e coordenadas são medidos?

Em pontos: 1 polegada equivale a 72 unidades.

### Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?

Use [estratégias de gerenciamento de BLOB](/slides/pt/php-java/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos baseados em arquivo em vez de streams puramente em memória.

### Posso criar/salvar apresentações em paralelo?

Você não pode operar na mesma instância de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/php-java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

### Como remover a marca d'água de avaliação e as limitações?

[Aplicar uma licença](/slides/pt/php-java/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado e a configuração da licença deve ser sincronizada se múltiplas threads estiverem envolvidas.

### Posso assinar digitalmente o PPTX que crio?

Sim. [Assinaturas digitais](/slides/pt/php-java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

### Macros (VBA) são suportadas em apresentações criadas?

Sim. Você pode [criar/editar projetos VBA](/slides/pt/php-java/presentation-via-vba/) e salvar arquivos com macros habilitadas, como PPTM/PPSM.