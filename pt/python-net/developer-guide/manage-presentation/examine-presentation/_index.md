---
title: Recuperar e Atualizar Informações da Apresentação em Python
linktitle: Informação da Apresentação
type: docs
weight: 30
url: /pt/python-net/examine-presentation/
keywords:
- formato da apresentação
- propriedades da apresentação
- propriedades do documento
- obter propriedades
- ler propriedades
- alterar propriedades
- modificar propriedades
- atualizar propriedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando Python para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Este artigo mostra como inspecionar informações de apresentação no Aspose.Slides. Explica como determinar o formato atual de uma apresentação sem carregar o arquivo completo, ler suas propriedades de documento e atualizar essas propriedades quando necessário.

Os exemplos são baseados nas APIs [PresentationInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/) e demonstram operações típicas para trabalhar com metadados de apresentação.

## **Verificar o formato de uma apresentação**

Antes de trabalhar em uma apresentação, pode ser útil descobrir em qual formato (PPT, PPTX, ODP etc.) a apresentação está no momento.

É possível verificar o formato de uma apresentação sem carregá‑la. Veja este código Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Obter propriedades da apresentação**

Este código Python mostra como obter as propriedades da apresentação (informações sobre a apresentação):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Você pode querer ver as [properties under the DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/#properties) da classe.

## **Atualizar propriedades da apresentação**

O Aspose.Slides fornece o método [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) que permite fazer alterações nas propriedades da apresentação.

Suponha que temos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades do documento original da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Os resultados da alteração das propriedades do documento são exibidos abaixo.

![Propriedades do documento alteradas da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, estes links podem ser úteis:

- [Password-Protect Presentations](/slides/pt/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pt/python-net/write-protected-presentation/)

## **Perguntas frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure por informações de [embedded-font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) no nível da apresentação e compare essas entradas com o conjunto de [fonts actually used across content](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_fonts/) para identificar quais fontes são críticas para a renderização.

**Como posso dizer rapidamente se o arquivo tem slides ocultos e quantos?**

Itere pela [slide collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/) e inspecione a [visibility flag](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/hidden/) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se diferem dos padrões?**

Sim. Compare o [slide size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slide_size/) e a orientação atuais com os presets padrão; isso ajuda a antecipar o comportamento para impressão e exportação.

**Existe uma forma rápida de ver se gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [charts](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/), verifique sua [data source](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/data_source_type/) e observe se os dados são internos ou baseados em links, incluindo links quebrados.

**Como posso avaliar slides “pesados” que podem desacelerar a renderização ou a exportação para PDF?**

Para cada slide, contabilize a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para identificar possíveis gargalos de desempenho.