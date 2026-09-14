---
title: Clonar Slides de Apresentação em Python
linktitle: Clonar Slides
type: docs
weight: 35
url: /pt/python-java/clone-slides/
keywords:
- clonar slide
- copiar slide
- salvar slide
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Duplique rapidamente slides do PowerPoint com Aspose.Slides for Python via Java. Siga nossos exemplos de código claros para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides for Python via Java também permite criar uma cópia ou clone de qualquer slide e, em seguida, inserir esse slide clonado na apresentação atual ou em qualquer outra apresentação aberta. O processo de clonagem de slides cria um novo slide que pode ser modificado por desenvolvedores sem alterar o slide original. Existem várias maneiras de clonar um slide:

- Clonar no final dentro de uma apresentação.
- Clonar em outra posição dentro de uma apresentação.
- Clonar no final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar juntamente com seu slide mestre em outra apresentação.

No Aspose.Slides for Python via Java, a coleção de slides (uma coleção de [Slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/) objects) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) fornece os métodos [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) e [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#insertClone) para executar os tipos de clonagem descritos acima.

## **Clonar um Slide no Final de uma Apresentação**

Se você quiser clonar um slide e usá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) conforme os passos listados a seguir:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) e passe o slide a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone).
1. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (localizado na primeira posição – índice zero – da apresentação) para o final da apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar a classe Presentation que representa um arquivo de apresentação
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Clonar o slide desejado para o final da coleção de slides na mesma apresentação
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Gravar a apresentação modificada no disco
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar um Slide para Outra Posição dentro de uma Apresentação**

Se você quiser clonar um slide e usá‑lo dentro do mesmo arquivo de apresentação, mas em outra posição, use o método [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#insertClone):

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha uma referência à coleção de slides retornada por [getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides) no objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#insertClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) e passe o slide a ser clonado junto com o índice da nova posição como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#insertClone).
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (localizado no índice 1 – posição 2 – da apresentação) para o índice 2 – posição 3 – da apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar a classe Presentation que representa um arquivo de apresentação
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Obter a coleção de slides na apresentação
    slides = presentation.getSlides()

    # Clonar o slide desejado para o índice especificado na mesma apresentação
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Gravar a apresentação modificada no disco
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar um Slide no Final de Outra Apresentação**

Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que contém a apresentação de onde o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que contém a apresentação de destino à qual o slide será adicionado.
1. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) referenciando a coleção de slides retornada por [getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides) no objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) e passe o slide da apresentação de origem como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do índice 0 da apresentação de origem) para o final da apresentação de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    destination_presentation = Presentation()
    try:
        # Clonar o slide desejado da apresentação fonte para o final da coleção de slides na apresentação de destino
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Gravar a apresentação de destino no disco
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clonar um Slide para Outra Posição em Outra Apresentação**

Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que contém a apresentação de origem da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que contém a apresentação na qual o slide será adicionado.
1. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) da apresentação de destino.
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#insertClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) e passe o slide da apresentação de origem junto com a posição desejada como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#insertClone).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    destination_presentation = Presentation()
    try:
        # Clonar o slide desejado da apresentação fonte para o índice especificado na apresentação de destino
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Gravar a apresentação de destino no disco
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clonar um Slide com seu Slide Mestre para Outra Apresentação**

Se precisar clonar um slide com um slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro clone o slide mestre desejado da apresentação de origem para a apresentação de destino. Em seguida, use o slide mestre clonado ao clonar o slide. O método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) espera um slide mestre da apresentação de destino, não da apresentação de origem. Para clonar o slide com seu mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que contém a apresentação de origem da qual o slide será clonado.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que contém a apresentação de destino para a qual o slide será clonado.
1. Acesse o slide a ser clonado juntamente com o slide mestre.
1. Obtenha o objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#addClone) exposto pelo objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/) e passe o mestre da apresentação PPTX de origem a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#addClone).
1. Obtenha o objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) exposto pelo objeto [SlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide com mestre (localizado no índice zero da apresentação de origem) para o final da apresentação de destino usando o mestre do slide de origem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
    destination_presentation = Presentation()
    try:
        # Instanciar o Slide a partir da coleção de slides na apresentação fonte juntamente com
        # Slide mestre
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Clonar o slide mestre desejado da apresentação fonte para a coleção de mestres na
        # apresentação de destino
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Clonar o slide desejado da apresentação fonte com o mestre desejado para o final da
        # coleção de slides na apresentação de destino
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Salvar a apresentação de destino no disco
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clonar um Slide no Final de uma Seção Específica**

Se você quiser clonar um slide e usá‑lo dentro do mesmo arquivo de apresentação, mas em uma seção diferente, use o método [**addClone**](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addClone) exposto pela classe [**SlideCollection**](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/). Aspose.Slides for Python via Java permite clonar um slide da primeira seção e inseri‑lo na segunda seção da mesma apresentação.

O trecho de código a seguir mostra como clonar um slide e inserir o slide clonado em uma seção especificada.

```python
import jpway
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Salvar a apresentação de destino no disco
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Garantir Tamanho de Slide Compatível**

Ao clonar slides para outra apresentação, certifique‑se de que a apresentação de destino possua o mesmo tamanho de slide da origem. Se os tamanhos divergirem, o Aspose.Slides não redimensiona automaticamente as formas clonadas — suas coordenadas e dimensões originais são preservadas, o que pode fazer com que o conteúdo fique desalinhado ou ultrapasse os limites do slide.

Você pode definir o tamanho de slide da apresentação de destino para coincidir com o da origem antes de clonar o mestre e o slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Faça isso antes de clonar o mestre e o slide.

## **FAQ**

**As anotações do apresentador e comentários de revisão são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos no clone. Se você não quiser mantê‑los, [remova‑os](/slides/pt/python-java/presentation-notes/) após a inserção.

**Como os gráficos e suas fontes de dados são tratados?**

O objeto de gráfico, sua formatação e os dados incorporados são copiados. Se o gráfico estiver vinculado a uma fonte externa (por exemplo, uma pasta de trabalho incorporada via OLE), essa vinculação é mantida como um [objeto OLE](/slides/pt/python-java/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções do clone?**

Sim. Você pode inserir o clone em um índice de slide específico e colocá‑lo em uma [seção](/slides/pt/python-java/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.