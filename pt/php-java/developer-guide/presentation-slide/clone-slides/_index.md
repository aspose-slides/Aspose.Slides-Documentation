---
title: Clonar slides de apresentação em PHP
linktitle: Clonar Slides
type: docs
weight: 35
url: /pt/php-java/clone-slides/
keywords:
- clonar slide
- copiar slide
- salvar slide
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Duplique rapidamente slides do PowerPoint com Aspose.Slides para PHP. Siga nossos exemplos de código claros para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides for PHP via Java também permite criar uma cópia ou clone de qualquer slide e inseri‑lo na apresentação atual ou em qualquer outra apresentação aberta. O processo de clonagem de slide cria um novo slide que pode ser modificado pelos desenvolvedores sem alterar o slide original. Existem diversas maneiras de clonar um slide:

- Clonar ao final dentro de uma apresentação.
- Clonar em outra posição dentro da mesma apresentação.
- Clonar ao final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em uma posição específica em outra apresentação.

Em Aspose.Slides for PHP via Java, (uma coleção de [Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Slide) objects) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) fornece os métodos [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) e [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone) para executar os tipos de clonagem acima descritos.

## **Clonar um slide ao final de uma apresentação**
Se quiser clonar um slide e utilizá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) conforme os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) referenciando a coleção de slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
1. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (localizado na primeira posição – índice zero – da apresentação) para o final da apresentação.

```php
  # Instanciar a classe Presentation que representa um arquivo de apresentação
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clonar o slide desejado para o final da coleção de slides na mesma apresentação
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Gravar a apresentação modificada no disco
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clonar um slide para outra posição dentro de uma apresentação**
Se quiser clonar um slide e utilizá‑lo dentro do mesmo arquivo de apresentação, porém em outra posição, use o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone):

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection) referenciando a coleção **[Slides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides)** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide a ser clonado juntamente com o índice da nova posição como parâmetros para o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone).
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (localizado no índice zero – posição 1 – da apresentação) para o índice 1 – Posição 2 – da apresentação.

```php
  # Instanciar a classe Presentation que representa um arquivo de apresentação
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Clonar o slide desejado para o final da coleção de slides na mesma apresentação
    $slds = $pres->getSlides();
    # Clonar o slide desejado para o índice especificado na mesma apresentação
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Gravar a apresentação modificada no disco
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clonar um slide ao final de outra apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de origem do slide.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de destino para a qual o slide será adicionado.
1. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection) referenciando a coleção **[Slides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides)** exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide da apresentação de origem como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
1. Grave o arquivo da apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação de origem) para o final da apresentação de destino.

```php
  # Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    $destPres = new Presentation();
    try {
      # Clonar o slide desejado da apresentação de origem para o final da coleção de slides na apresentação de destino
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Gravar a apresentação de destino no disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clonar um slide para outra posição em outra apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de origem do slide.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de destino à qual o slide será adicionado.
1. Obtenha a classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide da apresentação de origem juntamente com a posição desejada como parâmetros para o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone).
1. Grave o arquivo da apresentação de destino modificado.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

```php
  # Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    $destPres = new Presentation();
    try {
      # Clonar o slide desejado da apresentação de origem para o final da coleção de slides na apresentação de destino
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Gravar a apresentação de destino no disco
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clonar um slide em uma posição específica em outra apresentação**
Se precisar clonar um slide com um master slide de uma apresentação e usá‑lo em outra apresentação, primeiro clone o master slide desejado da apresentação de origem para a de destino. Em seguida, use esse master slide ao clonar o slide com master. O método [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) espera um master slide da apresentação de destino, e não da de origem. Para clonar o slide com master, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de origem do slide.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de destino para a qual o slide será clonado.
1. Acesse o slide a ser clonado juntamente com o master slide.
1. Instancie a classe [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterSlideCollection) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterSlideCollection) e passe o master da apresentação de origem a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
1. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) definindo a referência para a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide da apresentação de origem a ser clonado e o master slide como parâmetros para o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
1. Grave o arquivo da apresentação de destino modificado.

No exemplo abaixo, clonamos um slide com master (localizado no índice zero da apresentação de origem) para o final da apresentação de destino usando um master da apresentação de origem.

```php
  # Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
    $destPres = new Presentation();
    try {
      # Instanciar ISlide a partir da coleção de slides na apresentação de origem junto com
      # Slide mestre
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
      # apresentação de destino
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
      # apresentação de destino
      $iSlide = $masters->addClone($SourceMaster);
      # Clonar o slide desejado da apresentação de origem com o mestre desejado para o final da
      # coleção de slides na apresentação de destino
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Salvar a apresentação de destino no disco
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clonar um slide ao final de uma seção especificada**
Se quiser clonar um slide e utilizá‑lo dentro do mesmo arquivo de apresentação, porém em outra seção, use o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pela classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java permite clonar um slide da primeira seção e inseri‑lo na segunda seção da mesma apresentação.

O trecho de código a seguir demonstra como clonar um slide e inserir o slide clonado em uma seção especificada.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Salvar a apresentação de destino no disco
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Perguntas frequentes**

**As notas do apresentador e os comentários do revisor são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos no clone. Se não quiser mantê‑los, [remova‑os](/slides/pt/php-java/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto gráfico, sua formatação e os dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma planilha incorporada via OLE), esse vínculo é mantido como um [objeto OLE](/slides/pt/php-java/manage-ole/). Após a movimentação entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções do clone?**

Sim. Você pode inserir o clone em um índice de slide específico e colocá‑lo em uma [seção](/slides/pt/php-java/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.