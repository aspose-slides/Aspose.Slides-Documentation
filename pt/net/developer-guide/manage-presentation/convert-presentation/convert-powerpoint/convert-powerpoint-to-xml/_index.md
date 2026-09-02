---
title: Converter apresentações PowerPoint para XML em .NET
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/net/convert-powerpoint-to-xml/
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
- .NET
- C#
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para arquivos ou fluxos PowerPoint XML em C# com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides para .NET pode converter apresentações do PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas de documentos gerados, comparar a saída em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) com o valor `Xml` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/). Você pode gravar o resultado diretamente em um arquivo ou em um fluxo.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` cria uma PowerPoint XML Presentation. Ele não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se você precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slides individuais, inspecione o próprio pacote PPTX.
{{% /alert %}}

## **Converter uma apresentação para um arquivo XML**

Carregue uma apresentação fonte com a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e, em seguida, passe o caminho de saída e `SaveFormat.Xml` para [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/). A fonte pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

O exemplo a seguir converte uma apresentação PPTX em um arquivo XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Gravar a saída XML em um fluxo**

Use a sobrecarga de fluxo de [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) quando o XML precisar permanecer na memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) e o reinicia para leitura subsequente:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Passe xmlStream para o próximo componente no fluxo de trabalho.
```

## **Comparar XML com formatos de apresentação e exportação**

Escolha o formato de saída de acordo com a forma como o resultado será usado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Uma PowerPoint XML Presentation | Inspeção da estrutura, solução de problemas, comparação de saída gerada e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legado | Compatibilidade com fluxos de trabalho antigos do PowerPoint |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo várias partes | Edição regular no PowerPoint e intercâmbio de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou uma imagem multipágina | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Uma representação renderizada de um slide individual | Miniaturas, pré-visualizações e recursos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para web | Visualização em navegadores e publicação na web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e a fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slides, ela representa os dados da apresentação em vez de renderizar slides como páginas ou recursos visuais. A tabela [formatos de arquivo suportados](/slides/pt/net/supported-file-formats/) indica PowerPoint XML Presentation como um formato apenas para gravação, portanto não o use quando um fluxo de trabalho precisar carregar o arquivo exportado novamente no Aspose.Slides para edição contínua.

## **FAQ**

**`SaveFormat.Xml` é o mesmo que salvar um arquivo PPTX?**

Não. PPTX é um pacote que contém múltiplas partes do Office Open XML, enquanto `SaveFormat.Xml` cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um fluxo gravável para [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/). Por exemplo, use um [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) para processamento em memória.

**O Aspose.Slides pode carregar o arquivo XML exportado novamente?**

Não. PowerPoint XML Presentation atualmente é suportado apenas para gravação, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessário edição em ciclo completo.

**A conversão XML renderiza cada slide como uma página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas, ou PNG, JPEG e SVG para imagens de slides individuais.