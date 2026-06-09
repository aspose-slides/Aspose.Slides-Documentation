---
title: Recuperar e Atualizar Informações da Apresentação em Python
linktitle: Informação da Apresentação
type: docs
weight: 30
url: /pt/python-net/examine-presentation/
keywords:
- formato de apresentação
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

Antes de trabalhar em uma apresentação, você pode querer descobrir em que formato (PPT, PPTX, ODP e outros) a apresentação está no momento.

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

Este código Python mostra como obter propriedades da apresentação (informações sobre a apresentação):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Você pode querer ver as [propriedades na classe DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/#properties).

## **Atualizar propriedades da apresentação**

Aspose.Slides fornece o método [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) que permite fazer alterações nas propriedades da apresentação.

Suponha que temos uma apresentação PowerPoint com as propriedades de documento mostradas abaixo.

![Propriedades de documento originais da apresentação PowerPoint](input_properties.png)

Este exemplo de código mostra como editar algumas propriedades da apresentação:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Os resultados da alteração das propriedades do documento são mostrados abaixo.

![Propriedades de documento alteradas da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para obter mais informações sobre uma apresentação e seus atributos de segurança, você pode achar estes links úteis:

- [Verificando se uma apresentação está criptografada](https://docs.aspose.com/slides/pt/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando se uma apresentação está protegida contra gravação (somente leitura)](https://docs.aspose.com/slides/pt/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando se uma apresentação está protegida por senha antes de carregá‑la](https://docs.aspose.com/slides/pt/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando a senha usada para proteger uma apresentação](https://docs.aspose.com/slides/pt/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Perguntas frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Procure as [informações de fontes incorporadas](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) no nível da apresentação, depois compare essas entradas com o conjunto de [fontes realmente usadas no conteúdo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_fonts/) para identificar quais fontes são críticas para a renderização.

**Como posso identificar rapidamente se o arquivo tem slides ocultos e quantos?**

Itere pela [coleção de slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/) e inspecione a [bandeira de visibilidade](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/hidden/) de cada slide.

**Posso detectar se um tamanho e orientação de slide personalizados estão sendo usados e se diferem dos padrões?**

Sim. Compare o [tamanho de slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slide_size/) e a orientação atuais com as predefinições padrão; isso ajuda a antecipar o comportamento para impressão e exportação.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Percorra todos os [gráficos](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/), verifique sua [fonte de dados](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/data_source_type/) e observe se os dados são internos ou baseados em links, incluindo quaisquer links quebrados.

**Como posso avaliar slides 'pesados' que podem desacelerar a renderização ou exportação para PDF?**

Para cada slide, contabilize a quantidade de objetos e procure por imagens grandes, transparência, sombras, animações e multimídia; atribua uma pontuação de complexidade aproximada para sinalizar possíveis gargalos de desempenho.