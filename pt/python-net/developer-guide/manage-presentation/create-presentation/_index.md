---
title: Criar apresentações em Python
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Crie apresentações PowerPoint em Python com Aspose.Slides—produza arquivos PPT, PPTX e ODP, aproveite o suporte OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Aspose.Slides for Python permite criar um novo arquivo de apresentação inteiramente em código. Este artigo mostra o fluxo de trabalho principal—criar um objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) , obter o primeiro slide, inserir uma forma simples e persistir o resultado—para que você veja quão pouca configuração é necessária para gerar uma apresentação sem o Microsoft Office. Como a mesma API grava arquivos PPT, PPTX e ODP, você pode direcionar tanto os formatos tradicionais do PowerPoint quanto os formatos OpenDocument a partir de uma única base de código. Aspose.Slides é adequado para ambientes desktop, web ou servidor, oferecendo à sua aplicação Python um ponto de partida eficiente para adicionar conteúdo mais rico, como texto, imagens ou gráficos, depois que o deck inicial de slides estiver pronto.

## **Criar uma Apresentação**

Criar um arquivo PowerPoint do zero no Aspose.Slides for Python é tão direto quanto instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). O construtor fornece automaticamente um deck em branco com um único slide, dando a você uma tela imediata para formas, texto, gráficos ou qualquer outro conteúdo que sua aplicação precise. Depois de modificar esse slide—ou adicionar novos—você pode persistir o resultado em PPTX, PPT legado ou até mesmo formatos OpenDocument. O curto exemplo de código abaixo ilustra esse fluxo adicionando uma forma simples ao primeiro slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo seu índice.
1. Adicione um objeto [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) do tipo `CLOUD` usando o método `add_auto_shape` exposto pela coleção `shapes`.
1. Adicione texto à autoforma.
1. Salve a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, uma forma de nuvem é adicionada ao primeiro slide da apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma autoforma do tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A nova apresentação](new_presentation.png)

## **Perguntas Frequentes**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/python-net/save-presentation/), e exportar para [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/pt/python-net/convert-powerpoint-to-xps/), [HTML](/slides/pt/python-net/convert-powerpoint-to-html/), [SVG](/slides/pt/python-net/convert-powerpoint-to-png/), e [imagens](/slides/pt/python-net/convert-powerpoint-to-png/), entre outros.

**Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX padrão?**

Sim. Carregue o modelo e salve no formato desejado; POTX/POTM/PPTM e formatos semelhantes [são suportados](/slides/pt/python-net/supported-file-formats/).

**Como controlo o tamanho ou a proporção dos slides ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/python-net/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em quais unidades são medidos os tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/python-net/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de streams puramente em memória.

**Posso criar/salvar apresentações em paralelo?**

Você não pode operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/python-net/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como remover a marca d'água de avaliação e as limitações?**

[Aplique uma licença](/slides/pt/python-net/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se houver várias threads.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/python-net/digital-signature-in-powerpoint/) (adicionar e verificar) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/python-net/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.