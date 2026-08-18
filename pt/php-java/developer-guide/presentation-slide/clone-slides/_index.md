---
title: Clonar Slides de Apresentação em PHP
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
description: "Duplique rapidamente slides de PowerPoint com Aspose.Slides for PHP. Siga nossos claros exemplos de código para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonagem é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides for PHP via Java também possibilita fazer uma cópia ou clone de qualquer slide e então inserir esse slide clonado na apresentação atual ou em qualquer outra apresentação aberta. O processo de clonagem de slide cria um novo slide que pode ser modificado pelos desenvolvedores sem alterar o slide original. Existem várias maneiras possíveis de clonar um slide:

- Clonar no final dentro de uma apresentação.
- Clonar em outra posição dentro da apresentação.
- Clonar no final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em uma posição específica em outra apresentação.

No Aspose.Slides for PHP via Java, (uma coleção de [Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Slide) objetos) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) fornece os métodos [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) e [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone) para executar os tipos de clonagem de slide acima.

## **Clonar um slide no final de uma apresentação**
Se você deseja clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) de acordo com os passos listados abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) referenciando a coleção de slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
3. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide a ser clonado como parâmetro ao método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
4. Grave o arquivo de apresentação modificado.

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
Se você deseja clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em outra posição, use o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone):

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection) referenciando a coleção **Slides** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
3. Chame o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide a ser clonado junto com o índice da nova posição como parâmetro ao método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone).
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (localizado no índice zero – posição 1 – da apresentação) para o índice 1 – posição 2 – da apresentação.

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

## **Clonar um slide no final de outra apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, no final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de origem do slide.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de destino onde o slide será adicionado.
3. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection) referenciando a coleção **Slides** exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide da apresentação de origem como parâmetro ao método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
5. Grave o arquivo da apresentação de destino modificado.

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
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de destino onde o slide será adicionado.
3. Obtenha a classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
4. Chame o método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide da apresentação de origem juntamente com a posição desejada como parâmetro ao método [insertClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#insertClone).
5. Grave o arquivo da apresentação de destino modificado.

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
Se precisar clonar um slide com um slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro clone o slide mestre desejado da apresentação de origem para a de destino. Em seguida, use esse slide mestre ao clonar o slide com mestre. O método [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) espera um slide mestre da apresentação de destino, e não da apresentação de origem. Para clonar o slide com mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de origem do slide.
2. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que contém a apresentação de destino onde o slide será clonado.
3. Acesse o slide a ser clonado junto com seu slide mestre.
4. Instancie a classe [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterSlideCollection) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) da apresentação de destino.
5. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/MasterSlideCollection) e passe o mestre da apresentação de origem a ser clonado como parâmetro ao método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
6. Instancie a classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) definindo a referência para a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) da apresentação de destino.
7. Chame o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSlides) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetros ao método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone).
8. Grave o arquivo da apresentação de destino modificado.

No exemplo abaixo, clonamos um slide com mestre (localizado no índice zero da apresentação de origem) para o final da apresentação de destino usando o mestre do slide de origem.

```php
  # Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
    $destPres = new Presentation();
    try {
      # Instanciar ISlide a partir da coleção de slides da apresentação de origem juntamente com
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

## **Clonar um slide no final de uma seção especificada**
Se você deseja clonar um slide e então usá‑lo dentro do mesmo arquivo de apresentação, mas em outra seção, use o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection/#addClone) exposto pela classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java possibilita clonar um slide da primeira seção e inseri‑lo na segunda seção da mesma apresentação.

O trecho de código a seguir mostra como clonar um slide e inserir o slide clonado em uma seção especificada.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Salvar a apresentação de destino no disco
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Garantir correspondência de tamanho de slide**

Ao clonar slides para outra apresentação, certifique‑se de que a apresentação de destino possua o mesmo tamanho de slide da origem. Se os tamanhos forem diferentes, o Aspose.Slides não redimensiona automaticamente as formas clonadas – suas coordenadas e dimensões originais são preservadas, o que pode fazer com que o conteúdo fique desalinhado ou ultrapasse os limites do slide.

Você pode definir o tamanho do slide da apresentação de destino para corresponder ao da origem antes de clonar o mestre e o slide:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Faça isso antes de clonar o mestre e o slide.

## **FAQ**

**As notas do apresentador e os comentários dos revisores são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos no clone. Se não quiser mantê‑los, [removê‑los](/slides/pt/php-java/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto do gráfico, sua formatação e os dados incorporados são copiados. Se o gráfico estiver vinculado a uma fonte externa (por exemplo, uma pasta de trabalho incorporada via OLE), esse vínculo é preservado como um [OLE object](/slides/pt/php-java/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções do clone?**

Sim. Você pode inserir o clone em um índice de slide específico e colocá‑lo em uma [section](/slides/pt/php-java/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.