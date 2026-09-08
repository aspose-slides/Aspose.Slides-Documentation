---
title: Recuperar e Atualizar Informações da Apresentação em Python via Java
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/python-java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando Python via Java para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Aspose.Slides pode identificar o formato de uma apresentação e ler seus metadados de documento sem criar um modelo completo de objeto de apresentação. Isso é útil quando você precisa classificar arquivos, criar um inventário ou inspecionar propriedades antes de decidir se deve carregar e processar o conteúdo da apresentação.

Os exemplos requerem Aspose.Slides para Python via Java e um runtime Java compatível. Cada exemplo inicia a JVM se ela ainda não estiver em execução. Forneça arquivos de apresentação existentes nos caminhos usados nos exemplos.

Este artigo demonstra inspeção leve através de [PresentationFactory](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/), bem como atualizações direcionadas através de [DocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/).

## **Verificar o formato de uma apresentação**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) para inspecionar um arquivo sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). O método [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#getLoadFormat) relata o formato detectado, como PPTX, PPT ou ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Criar um inventário de apresentações leve**

Quando você processa muitos arquivos de apresentação, pode precisar de um inventário compacto para validação, indexação ou um sistema de gerenciamento de documentos. Nesse cenário, use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) para obter um objeto [PresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/), e então chame [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#readDocumentProperties) para ler os metadados do documento. Essa abordagem não cria uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) nem exige que você percorra o modelo completo de objeto de apresentação.

As propriedades estendidas expostas por [DocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/) fornecem os seguintes valores de inventário:

| Método | Valor de inventário |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getSlides) | Número total de slides. |
| [getHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Número de slides ocultos. |
| [getNotes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getNotes) | Número de slides que contêm notas. |
| [getParagraphs](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getParagraphs) | Número total de parágrafos, quando disponível. |
| [getWords](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getWords) | Número total de palavras. |
| [getMultimediaClips](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Número total de clipes de áudio e vídeo. |

O exemplo a seguir lê esses valores sem criar um objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e imprime um inventário compacto. Ele também combina [getHeadingPairs](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getHeadingPairs) com [getTitlesOfParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getTitlesOfParts) para exibir grupos de conteúdo como fontes, temas e títulos de slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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

Cada [HeadingPair](https://reference.aspose.com/slides/pt/python-java/aspose.slides/headingpair/) fornece um nome de grupo e o número de itens naquele grupo. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getTitlesOfParts) retorna uma matriz plana e ordenada, portanto, consuma o número de títulos consecutivos especificado por cada par de cabeçalho.

### **Metadados armazenados e limitações de formato**

As propriedades de inventário retornadas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#readDocumentProperties) refletem os metadados disponíveis no documento de origem. Aspose.Slides não carrega nem percorre o modelo de objeto da apresentação para recalcular esses valores nesta chamada. Propriedades ausentes são representadas por valores padrão, e valores armazenados podem estar desatualizados se a aplicação que salvou o arquivo pela última vez não atualizou suas propriedades de documento.

- **PPTX:** O formato fornece propriedades de documento estendidas para contagens de slides, notas, slides ocultos, parágrafos, palavras e multimídia, além de pares de cabeçalhos e títulos de partes. A disponibilidade depende de quais propriedades foram gravadas pelo produtor do documento.
- **PPT:** O formato binário pode armazenar propriedades resumidas de documento correspondentes. Se uma propriedade estiver ausente ou não for atualizada pelo produtor do documento, Aspose.Slides retorna seu valor armazenado ou padrão em vez de calculá‑lo a partir dos slides.
- **ODP:** Os metadados do OpenDocument fornecem estatísticas gerais de documento, como contagem de páginas, parágrafos e palavras, mas esses valores não mapeiam todas as propriedades estendidas específicas do PowerPoint. Metadados de slides ocultos, notas, multimídia, pares de cabeçalhos e títulos de partes podem estar indisponíveis, e as propriedades de inventário podem retornar valores padrão. Não trate um valor zero ou uma matriz vazia como prova autoritativa de que o conteúdo correspondente está ausente.

Use a abordagem de metadados leves para inventários e verificações preliminares. Carregue a apresentação e inspecione seu modelo de objeto em tempo real quando o resultado precisar refletir alterações em memória ou quando for necessário verificar o conteúdo real da apresentação.

## **Atualizar propriedades da apresentação**

As propriedades retornadas por [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#readDocumentProperties) também podem ser alteradas sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). Aplique as alterações com [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) e, em seguida, escreva a apresentação vinculada com [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

A imagem a seguir mostra as propriedades de documento originais da apresentação PowerPoint.

![Propriedades de documento originais da apresentação PowerPoint](input_properties.png)

O exemplo a seguir altera o título e a data da última gravação e grava o resultado em um novo arquivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

A imagem a seguir mostra as propriedades de documento atualizadas da apresentação PowerPoint.

![Propriedades de documento alteradas da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para verificações de segurança relacionadas e configurações de proteção, consulte os artigos seguintes:

- [Proteger apresentações com senha](/slides/pt/python-java/password-protected-presentation/)
- [Proteger apresentações contra gravação](/slides/pt/python-java/write-protected-presentation/)

## **FAQ**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Carregue a apresentação e use [Presentation.getFontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getFontsManager). Chame [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) para obter as fontes incorporadas e [FontsManager.getFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getFonts) para obter as fontes usadas pela apresentação. Compare os dois resultados para encontrar fontes necessárias para renderização que não estejam incorporadas.

**Como posso dizer rapidamente se o arquivo tem slides ocultos e quantos?**

Quando os metadados armazenados do documento são suficientes, leia [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#getHiddenSlides) através de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Isso é adequado para um inventário leve. Se a apresentação foi modificada em memória, os metadados armazenados podem estar ausentes ou desatualizados, ou se precisar verificar valores ao vivo, percorra [Presentation.getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides) e inspecione o método [Slide.getHidden](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getHidden) de cada slide.

**Posso detectar se um tamanho ou orientação de slide personalizado está sendo usado e se difere dos padrões?**

Sim. Carregue a apresentação e chame [Presentation.getSlideSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlideSize). Use [SlideSize.getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesize/#getSize) e [SlideSize.getOrientation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesize/#getOrientation) para comparar as configurações atuais com o preset e as dimensões esperadas.

**Existe uma forma rápida de ver se gráficos referenciam fontes de dados externas?**

Sim. Localize cada [Chart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/) e chame [ChartData.getDataSourceType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getDataSourceType). Para uma pasta de trabalho externa, chame [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). O tipo de fonte de dados e o caminho identificam uma referência externa, mas verificar se o alvo está disponível requer uma verificação de recurso separada.

**Como posso avaliar slides “pesados” que podem desacelerar a renderização ou a exportação para PDF?**

Não existe uma única propriedade de complexidade. Percorra [Presentation.getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides) e a coleção [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getShapes) de cada slide. Use contagens de formas e a presença de imagens grandes, efeitos, animações ou multimídia como sinais de triagem, e meça uma renderização ou exportação representativa antes de considerar um slide como um gargalo de desempenho confirmado.