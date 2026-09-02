---
title: Converter apresentações PowerPoint para XML em JavaScript
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/nodejs-java/convert-powerpoint-to-xml/
keywords:
- converter PowerPoint para XML
- converter apresentação para XML
- PPT para XML
- PPTX para XML
- ODP para XML
- Apresentação XML do PowerPoint
- SaveFormat.Xml
- salvar apresentação como XML
- exportar apresentação para XML
- fluxo XML
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para arquivos ou fluxos PowerPoint XML em JavaScript com Aspose.Slides for Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java pode converter apresentações PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas de documentos gerados, comparar a saída em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) com o valor `Xml` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/). Você pode gravar o resultado diretamente em um arquivo ou em um fluxo.

{{% alert color="info" title="Nota" %}}

`SaveFormat.Xml` cria uma PowerPoint XML Presentation. Ele não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se você precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slides individuais, inspecione o próprio pacote PPTX.

{{% /alert %}}

## **Converter uma Apresentação para um Arquivo XML**

Carregue uma apresentação de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e, em seguida, passe o caminho de saída e `SaveFormat.Xml` para [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save). A origem pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

O exemplo a seguir converte uma apresentação PPTX para um arquivo XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Gravar a Saída XML em um Fluxo**

Use a sobrecarga de fluxo de [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) quando o XML precisar permanecer na memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um `ByteArrayOutputStream` Java e copia os dados gerados para um `Buffer` Node.js:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Passe xmlBuffer para o próximo componente no fluxo de trabalho.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Comparar XML com Formatos de Apresentação e Exportação**

Escolha o formato de saída de acordo com como o resultado será usado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Uma PowerPoint XML Presentation | Inspecionar a estrutura, solucionar problemas, comparar a saída gerada e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legado | Compatibilidade com fluxos de trabalho PowerPoint mais antigos |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo múltiplas partes | Edição normal no PowerPoint e troca de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou imagem multipágina | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Uma representação renderizada de um slide individual | Miniaturas, pré‑visualizações e recursos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para a web | Visualização em navegador e publicação na web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slides, ela representa os dados da apresentação em vez de renderizar os slides como páginas ou ativos visuais. A tabela [supported file formats](/slides/pt/nodejs-java/supported-file-formats/) lista PowerPoint XML Presentation como um formato apenas de gravação, portanto não o use quando um fluxo de trabalho precisar carregar o arquivo exportado de volta ao Aspose.Slides para edição continuada.

## **Perguntas frequentes**

**`SaveFormat.Xml` é o mesmo que salvar um arquivo PPTX?**

Não. PPTX é um pacote que contém múltiplas partes do Office Open XML, enquanto `SaveFormat.Xml` cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um fluxo gravável para [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save). Por exemplo, use um `ByteArrayOutputStream` Java e copie seus dados para um `Buffer` Node.js para processamento em memória.

**O Aspose.Slides pode carregar novamente o arquivo XML exportado?**

Não. PowerPoint XML Presentation atualmente é suportado apenas para gravação, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessário edição de ida e volta.

**A conversão XML renderiza cada slide como página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas, ou PNG, JPEG e SVG para imagens de slides individuais.