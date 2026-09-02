---
title: Converter apresentações PowerPoint para XML em C++
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/cpp/convert-powerpoint-to-xml/
keywords:
- converter PowerPoint para XML
- converter apresentação para XML
- PPT para XML
- PPTX para XML
- ODP para XML
- Apresentação XML PowerPoint
- SaveFormat::Xml
- salvar apresentação como XML
- exportar apresentação para XML
- stream XML
- C++
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para arquivos ou streams XML PowerPoint em C++ com Aspose.Slides for C++."
---
## **Visão geral**

Aspose.Slides for C++ pode converter apresentações do PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas em documentos gerados, comparar a saída em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) com o valor `Xml` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/). Você pode gravar o resultado diretamente em um arquivo ou em um stream.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` cria uma PowerPoint XML Presentation. Ele não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se você precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slides individuais, examine o próprio pacote PPTX.
{{% /alert %}}

## **Converter uma apresentação para um arquivo XML**

Carregue uma apresentação fonte com a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e, em seguida, passe o caminho de saída e `SaveFormat::Xml` para [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/). A fonte pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

O exemplo a seguir converte uma apresentação PPTX para um arquivo XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Gravar a saída XML em um stream**

Use a sobrecarga de stream de [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) quando o XML precisar permanecer na memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um [MemoryStream](https://reference.aspose.com/slides/pt/cpp/system.io/memorystream/) e o rebobina para leitura subsequente:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Passe o xmlStream para o próximo componente no fluxo de trabalho.
```

## **Comparar XML com formatos de apresentação e exportação**

Escolha o formato de saída de acordo com como o resultado será usado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Uma PowerPoint XML Presentation | Inspeção da estrutura, solução de problemas, comparação de saída gerada e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legado | Compatibilidade com fluxos de trabalho do PowerPoint mais antigos |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo múltiplas partes | Edição regular no PowerPoint e troca de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou uma imagem multipágina | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Uma representação renderizada de um slide individual | Miniaturas, pré‑visualizações e ativos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para web | Visualização em navegador e publicação na web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slides, ela representa os dados da apresentação em vez de renderizar slides como páginas ou ativos visuais. A tabela de [formatos de arquivo suportados](/slides/pt/cpp/supported-file-formats/) indica PowerPoint XML Presentation como um formato somente de gravação, portanto não o use quando um fluxo de trabalho precisar carregar o arquivo exportado novamente no Aspose.Slides para edição contínua.

## **Perguntas frequentes**

**É `SaveFormat::Xml` o mesmo que salvar um arquivo PPTX?**

Não. PPTX é um pacote que contém múltiplas partes do Office Open XML, enquanto `SaveFormat::Xml` cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um stream gravável para [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/). Por exemplo, use um [MemoryStream](https://reference.aspose.com/slides/pt/cpp/system.io/memorystream/) para processamento em memória.

**O Aspose.Slides pode carregar o arquivo XML exportado novamente?**

Não. PowerPoint XML Presentation atualmente é suportado apenas para gravação, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessária edição de ida e volta.

**A conversão XML renderiza cada slide como uma página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas, ou PNG, JPEG e SVG para imagens de slides individuais.