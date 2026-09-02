---
title: Recuperar e Atualizar Informações da Apresentação em Python
linktitle: Informações da Apresentação
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

Aspose.Slides pode identificar o formato de uma apresentação e ler seus metadados de documento sem criar um modelo completo de objeto de apresentação. Isso é útil quando você precisa classificar arquivos, construir um inventário ou inspecionar propriedades antes de decidir carregar e processar o conteúdo da apresentação.

Este artigo demonstra inspeção leve através de [PresentationFactory](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/), bem como atualizações direcionadas através de [DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/).

## **Verificar o formato de uma apresentação**

Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) para inspecionar um arquivo sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). A propriedade [PresentationInfo.load_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/load_format/) informa o formato detectado, como PPTX, PPT ou ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Construir um inventário leve de apresentações**

Ao processar muitos arquivos de apresentação, pode ser necessário um inventário compacto para validação, indexação ou um sistema de gerenciamento de documentos. Nesse cenário, use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) para obter um objeto [PresentationInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/) e, em seguida, chame [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/read_document_properties/) para ler os metadados do documento. Essa abordagem não cria uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) nem exige que você percorra o modelo completo de objeto da apresentação.

As propriedades estendidas expostas por [DocumentProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/) fornecem os seguintes valores de inventário:

| Propriedade | Valor do inventário |
| --- | --- |
| [slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/slides/pt/) | Número total de slides. |
| [hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/hidden_slides/) | Número de slides ocultos. |
| [notes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/notes/) | Número de slides que contêm notas. |
| [paragraphs](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/paragraphs/) | Número total de parágrafos, quando disponível. |
| [words](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/words/) | Número total de palavras. |
| [multimedia_clips](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/multimedia_clips/) | Número total de clipes de áudio e vídeo. |

O exemplo a seguir lê esses valores sem criar um objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e imprime um inventário compacto. Também combina [heading_pairs](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/heading_pairs/) com [titles_of_parts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/titles_of_parts/) para exibir grupos de conteúdo como fontes, temas e títulos de slides.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Cada [HeadingPair](https://reference.aspose.com/slides/pt/python-net/aspose.slides/headingpair/) fornece um nome de grupo e o número de itens nesse grupo. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/titles_of_parts/) é uma coleção plana e ordenada, portanto consuma o número de títulos consecutivos especificado por cada par de cabeçalho.

### **Metadados armazenados e limitações de formato**

As propriedades de inventário retornadas por [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/read_document_properties/) refletem os metadados disponíveis no documento de origem. Aspose.Slides não carrega e percorre o modelo de objeto da apresentação para recalcular esses valores nesta chamada. Propriedades ausentes são representadas por valores padrão, e os valores armazenados podem estar desatualizados se o aplicativo que salvou o arquivo pela última vez não atualizou suas propriedades de documento.

- **PPTX:** O formato fornece propriedades de documento estendidas para contagem de slides, notas, slides ocultos, parágrafos, palavras e multimídia, além de pares de cabeçalhos e títulos de partes. A disponibilidade depende de quais propriedades foram gravadas pelo produtor do documento.
- **PPT:** O formato binário pode armazenar propriedades de resumo de documento correspondentes. Se uma propriedade estiver ausente ou não for atualizada pelo produtor do documento, Aspose.Slides retorna seu valor armazenado ou padrão em vez de calculá‑lo a partir dos slides.
- **ODP:** Os metadados do OpenDocument fornecem estatísticas gerais de documento, como contagem de páginas, parágrafos e palavras, mas esses valores não correspondem a todas as propriedades estendidas específicas do PowerPoint. Metadados de slide oculto, slide de notas, multimídia, pares de cabeçalhos e títulos de partes podem estar indisponíveis, e as propriedades de inventário podem retornar valores padrão. Não trate um valor zero ou uma coleção vazia como prova autoritativa de que o conteúdo correspondente está ausente.

Use a abordagem de metadados leves para inventários e verificações preliminares. Carregue a apresentação e inspecione seu modelo de objeto ao vivo quando o resultado precisar refletir alterações em memória ou quando for necessário verificar o conteúdo real da apresentação.

## **Atualizar propriedades da apresentação**

As propriedades retornadas por [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/read_document_properties/) também podem ser alteradas sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Aplique as alterações com [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/update_document_properties/) e, em seguida, escreva a apresentação vinculada com [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

A imagem a seguir mostra as propriedades de documento originais.

![Original document properties of the PowerPoint presentation](input_properties.png)

O exemplo a seguir altera o título e a hora da última gravação e grava o resultado em um novo arquivo:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

A imagem a seguir mostra as propriedades de documento atualizadas.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Links úteis**

Para verificações de segurança relacionadas e configurações de proteção, veja os artigos a seguir:

- [Password-Protect Presentations](/slides/pt/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pt/python-net/write-protected-presentation/)

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Carregue a apresentação e use [Presentation.fonts_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/fonts_manager/). Chame [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) para obter as fontes incorporadas e [FontsManager.get_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_fonts/) para obter as fontes usadas pela apresentação. Compare os dois resultados para encontrar fontes que são necessárias para renderização mas não estão incorporadas.

**Como posso descobrir rapidamente se o arquivo tem slides ocultos e quantos?**

Quando os metadados armazenados do documento forem suficientes, leia [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/hidden_slides/) através de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) e [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/read_document_properties/). Isso é adequado para um inventário leve. Se a apresentação foi modificada em memória, os metadados armazenados podem estar ausentes ou desatualizados, ou se precisar verificar valores ao vivo, percorra [Presentation.slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slides/pt/) e inspecione a propriedade [Slide.hidden](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/hidden/) de cada slide.

**Posso detectar se um tamanho de slide personalizado e orientação são usados, e se diferem dos padrões?**

Sim. Carregue a apresentação e leia [Presentation.slide_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slide_size/). Inspecione [SlideSize.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidesize/size/) e [SlideSize.orientation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidesize/orientation/) para comparar as configurações atuais com o preset e as dimensões esperadas.

**Existe uma maneira rápida de ver se gráficos referenciam fontes de dados externas?**

Sim. Localize cada [Chart](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/) e inspecione [ChartData.data_source_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/data_source_type/). Para uma pasta de trabalho externa, leia [ChartData.external_workbook_path](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chartdata/external_workbook_path/). O tipo de fonte de dados e o caminho identificam uma referência externa, mas verificar se o alvo está disponível requer uma verificação de recurso separada.

**Como posso avaliar slides “pesados” que podem desacelerar a renderização ou a exportação para PDF?**

Não existe uma única propriedade de complexidade. Percorra [Presentation.slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slides/pt/) e a coleção [BaseSlide.shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/shapes/) de cada slide. Use contagens de formas e a presença de imagens grandes, efeitos, animações ou multimídia como sinais de triagem, e meça uma renderização ou exportação representativa antes de considerar um slide como gargalo de desempenho confirmado.