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
description: "Crie apresentações em Python via Java com Aspose.Slides—produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve‑os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação com Aspose.Slides for Python via Java, adicionar uma forma com texto ao primeiro slide e salvar o resultado como um arquivo PPTX. O FAQ aborda formatos de saída, modelos, dimensionamento de slides, uso de memória, threading, licenciamento, assinaturas digitais e suporte a VBA.

## **Criar uma apresentação**

Criar um arquivo PowerPoint do zero no Aspose.Slides for Python via Java é tão simples quanto instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). O construtor fornece automaticamente um deck em branco com um único slide, oferecendo uma tela imediata para formas, texto, gráficos ou qualquer outro conteúdo que sua aplicação precise. Depois de modificar esse slide — ou adicionar novos — você pode persistir o resultado em PPTX, PPT legado ou até mesmo formatos OpenDocument. O pequeno exemplo de código abaixo ilustra esse fluxo ao adicionar uma forma simples ao primeiro slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha o primeiro slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) do tipo [ShapeType.Cloud](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapetype/#Cloud) usando [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Defina o texto da forma usando [TextFrame.setText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#setText).
1. Salve a apresentação usando [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Pptx).

O exemplo a seguir requer Aspose.Slides for Python via Java e um runtime Java compatível. Ele inicia a JVM caso ainda não esteja em execução, adiciona uma forma de nuvem ao primeiro slide e salva a apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Crie uma apresentação com um slide em branco.
presentation = Presentation()
try:
    # Obtenha o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicione uma forma de nuvem e defina seu texto.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A nova apresentação](new_presentation.png)

## **FAQ**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/python-java/save-presentation/) e exportar para [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/python-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/python-java/convert-powerpoint-to-html/), [SVG](/slides/pt/python-java/render-slide-as-svg/) e [imagens](/slides/pt/python-java/convert-powerpoint-to-png/), entre outros.

**Posso iniciar a partir de um modelo (POTX/POTM) e salvar como PPTX comum?**

Sim. Carregue o modelo e salve no formato desejado; POTX/POTM/PPTM e formatos semelhantes [são suportados](/slides/pt/python-java/supported-file-formats/).

**Como controlo o tamanho/razão de aspecto do slide ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/python-java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em quais unidades são medidos tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/python-java/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivo em vez de streams puramente em memória.

**Posso criar/salvar apresentações em paralelo?**

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) a partir de [vários threads](/slides/pt/python-java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como removo a marca d'água de avaliação e as limitações?**

[Aplicar uma licença](/slides/pt/python-java/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se houver múltiplos threads.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/python-java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/python-java/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.