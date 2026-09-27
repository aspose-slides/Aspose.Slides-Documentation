---
title: Criar apresentações em Python via Java
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/python-java/create-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Criar apresentações em Python via Java com Aspose.Slides — produzir arquivos PPT, PPTX e ODP, aproveitar o suporte a OpenDocument e salvá‑los programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação com Aspose.Slides for Python via Java, adicionar uma forma com texto ao primeiro slide e salvar o resultado como um arquivo PPTX. O FAQ abrange formatos de saída, modelos, dimensionamento de slides, uso de memória, threading, licenciamento, assinaturas digitais e suporte a VBA.

Antes de começar, instale Python, um JDK, JPype e Aspose.Slides for Python via Java. Consulte [Instalação](/slides/pt/python-java/installation/) para os passos no Windows, Linux e macOS.

## **Criar uma Apresentação**

Criar um arquivo PowerPoint do zero em Aspose.Slides for Python via Java é tão simples quanto instanciar a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). O construtor fornece automaticamente um deck em branco com um único slide, oferecendo uma tela imediata para formas, texto, gráficos ou qualquer outro conteúdo que sua aplicação necessite. Depois de modificar esse slide — ou adicionar novos — você pode persistir o resultado em PPTX, PPT legado ou até formatos OpenDocument. O pequeno exemplo de código abaixo ilustra este fluxo adicionando uma forma simples ao primeiro slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Obtenha o primeiro slide pelo seu índice, 0.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) do tipo [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) usando [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Defina o texto da forma usando [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText).
1. Salve a apresentação usando [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx).

O exemplo a seguir inicia a Java Virtual Machine (JVM) se ainda não estiver em execução, adiciona uma forma de nuvem com texto ao primeiro slide e salva a apresentação. Salve-o como *create_presentation.py*:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Criar uma apresentação com um slide em branco.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma de nuvem e definir seu texto.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Execute o script no ambiente onde você instalou os pacotes:

```sh
python create_presentation.py
```

O canto superior esquerdo da nuvem está a 20 pontos da borda esquerda e superior do slide, e a nuvem tem 200 pontos de largura e 80 pontos de altura. O script salva *new_presentation.pptx* no diretório de trabalho atual, com um slide que contém a nuvem e seu texto. A JVM continua em execução até que o processo Python termine; veja [Limitações e Diferenças de API](/slides/pt/python-java/limitations-and-api-differences/#import-the-library). Sem uma licença, o Aspose.Slides também adiciona uma caixa de texto com marca d'água de avaliação a cada slide salvo; veja [Licenciamento](/slides/pt/python-java/licensing/).

O resultado:

![A nova apresentação](new_presentation.png)

## **Perguntas Frequentes**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/python-java/save-presentation/), e exportar para [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/python-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/python-java/convert-powerpoint-to-html/), [SVG](/slides/pt/python-java/render-a-slide-as-an-svg-image/) e [imagens](/slides/pt/python-java/convert-powerpoint-to-png/), entre outros.

**Posso começar a partir de um modelo (POTX/POTM) e salvar como um PPTX regular?**

Sim. Carregue o modelo e salve no formato desejado; formatos POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/python-java/supported-file-formats/).

**Como controlo o tamanho/razão de aspecto do slide ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/python-java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em quais unidades são medidos tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lido com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/python-java/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de streams puramente em memória.

**Posso criar/salvar apresentações em paralelo?**

Você não pode operar na mesma instância de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/python-java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como removo a marca d'água de avaliação e as limitações?**

[Aplique uma licença](/slides/pt/python-java/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se várias threads estiverem envolvidas.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/python-java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/python-java/presentation-via-vba/) e salvar arquivos com macro habilitada, como PPTM/PPSM.