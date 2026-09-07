---
title: Converter apresentações PowerPoint para XML em Python via Java
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/python-java/convert-powerpoint-to-xml/
keywords:
- converter PowerPoint para XML
- converter apresentação para XML
- PPT para XML
- PPTX para XML
- ODP para XML
- Apresentação PowerPoint XML
- SaveFormat.Xml
- salvar apresentação como XML
- exportar apresentação para XML
- fluxo XML
- Python
- Java
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para arquivos ou fluxos PowerPoint XML em Python via Java com Aspose.Slides for Python via Java."
---
## **Visão geral**

Aspose.Slides for Python via Java pode converter apresentações do PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas de documentos gerados, comparar a saída em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) com o valor [Xml](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Xml) da classe [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/). Você pode gravar o resultado diretamente em um arquivo ou em um stream.

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Xml) cria uma PowerPoint XML Presentation. Ele não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se você precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slide individuais, inspecione o próprio pacote PPTX.
{{% /alert %}}

## **Converter uma apresentação para um arquivo XML**

Carregue uma apresentação de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), e então passe o caminho de saída e [SaveFormat.Xml](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Xml) para [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save). A origem pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

O exemplo a seguir converte uma apresentação PPTX para um arquivo XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Gravar a saída XML em um stream**

Use a sobrecarga de stream de [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) quando o XML precisar permanecer na memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) e obtém o XML resultante como um objeto bytes do Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Passe xml_data para o próximo componente no fluxo de trabalho.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Comparar XML com formatos de apresentação e exportação**

Escolha o formato de saída de acordo com o uso do resultado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Uma apresentação PowerPoint XML | Inspeção da estrutura, solução de problemas, comparação da saída gerada e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legado | Compatibilidade com fluxos de trabalho do PowerPoint mais antigos |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo múltiplas partes | Edição regular no PowerPoint e intercâmbio de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou uma imagem multipágina | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Uma representação renderizada de um slide individual | Miniaturas, pré‑visualizações e recursos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para web | Visualização em navegador e publicação na web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slide, ela representa dados da apresentação em vez de renderizar slides como páginas ou ativos visuais. A tabela de [formatos de arquivo compatíveis](/slides/pt/python-java/supported-file-formats/) lista PowerPoint XML Presentation como um formato apenas de salvamento, portanto não o use quando um fluxo de trabalho precisar carregar o arquivo exportado de volta ao Aspose.Slides para edição contínua.

## **Perguntas frequentes**

**É a exportação XML a mesma coisa que salvar um arquivo PPTX?**

Não. PPTX é um pacote que contém múltiplas partes do Office Open XML, enquanto [SaveFormat.Xml](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Xml) cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um stream de saída Java gravável para [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save). Por exemplo, use um [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) para processamento em memória.

**O Aspose.Slides pode carregar novamente o arquivo XML exportado?**

Não. PowerPoint XML Presentation atualmente é suportado apenas para salvamento, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessário edição bidirecional.

**A conversão XML renderiza cada slide como página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas, ou PNG, JPEG e SVG para imagens de slides individuais.