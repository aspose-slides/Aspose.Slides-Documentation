---
title: Converter apresentações do PowerPoint para XML em Python
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/python-net/convert-powerpoint-to-xml/
keywords:
- converter PowerPoint para XML
- converter apresentação para XML
- PPT para XML
- PPTX para XML
- ODP para XML
- Apresentação PowerPoint XML
- SaveFormat.XML
- salvar apresentação como XML
- exportar apresentação para XML
- fluxo XML
- Python
- Aspose.Slides
description: "Converter apresentações do PowerPoint e OpenDocument para arquivos ou fluxos PowerPoint XML em Python com Aspose.Slides."
---
## **Visão geral**

Aspose.Slides for Python via .NET pode converter apresentações do PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas de documentos gerados, comparar a saída em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) com o valor `XML` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/). Você pode gravar o resultado diretamente em um arquivo ou em um fluxo.

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` cria uma PowerPoint XML Presentation. Ele não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se você precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slides individuais, inspecione o próprio pacote PPTX.
{{% /alert %}}

## **Converter uma apresentação para um arquivo XML**

Carregue uma apresentação de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Em seguida, passe o caminho de saída e `SaveFormat.XML` para [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/). A origem pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

O exemplo a seguir converte uma apresentação PPTX para um arquivo XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Gravar a saída XML em um fluxo**

Use a sobrecarga de fluxo do [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) quando o XML precisar permanecer na memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um fluxo [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) e o reposiciona para leitura subsequente:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Passe xml_stream para o próximo componente no fluxo de trabalho.
```

## **Comparar XML com formatos de apresentação e exportação**

Escolha o formato de saída de acordo com o uso esperado do resultado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Uma apresentação PowerPoint XML | Inspeção da estrutura, solução de problemas, comparação da saída gerada e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legado | Compatibilidade com fluxos de trabalho do PowerPoint mais antigos |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo múltiplas partes | Edição regular no PowerPoint e troca de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou uma imagem multipáginas | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Uma representação renderizada de um slide individual | Miniaturas, pré‑visualizações e ativos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para a web | Visualização em navegadores e publicação na web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slides, ela representa os dados da apresentação em vez de renderizar os slides como páginas ou ativos visuais. A tabela de [formatos de arquivo suportados](/slides/pt/python-net/supported-file-formats/) lista PowerPoint XML Presentation como um formato somente de gravação, portanto não o use quando um fluxo de trabalho precisar carregar o arquivo exportado de volta ao Aspose.Slides para edição continuada.

## **FAQ**

**O `SaveFormat.XML` é o mesmo que salvar um arquivo PPTX?**

Não. PPTX é um pacote que contém múltiplas partes Office Open XML, enquanto `SaveFormat.XML` cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um fluxo gravável para [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/). Por exemplo, use um fluxo [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) para processamento em memória.

**O Aspose.Slides pode carregar o arquivo XML exportado novamente?**

Não. PowerPoint XML Presentation é suportado atualmente apenas para gravação, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessário edição de ida e volta.

**A conversão XML renderiza cada slide como uma página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas, ou PNG, JPEG e SVG para imagens de slides individuais.