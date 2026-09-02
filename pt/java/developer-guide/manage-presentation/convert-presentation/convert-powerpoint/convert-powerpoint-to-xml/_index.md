---
title: Converter apresentações PowerPoint para XML em Java
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para arquivos ou fluxos XML do PowerPoint em Java com Aspose.Slides for Java."
---
## **Visão geral**

Aspose.Slides for Java pode converter apresentações PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas de documentos gerados, comparar a saída em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-) com o valor `Xml` da classe [SaveFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/) . Você pode gravar o resultado diretamente em um arquivo ou em um fluxo.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` cria uma PowerPoint XML Presentation. Ele não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se você precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slides individuais, inspecione o próprio pacote PPTX.

{{% /alert %}}

## **Converter uma Apresentação para um Arquivo XML**

Carregue uma apresentação de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) e, em seguida, passe o caminho de saída e `SaveFormat.Xml` para [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-). A origem pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

O exemplo a seguir converte uma apresentação PPTX para um arquivo XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Gravar a Saída XML em um Fluxo**

Use a sobrecarga de stream de [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) quando o XML deve permanecer em memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) e obtém o XML resultante como um array de bytes:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Passe xmlData para o próximo componente no fluxo de trabalho.
} finally {
    presentation.dispose();
}
```

## **Comparar XML com Formatos de Apresentação e Exportação**

Escolha o formato de saída de acordo com como o resultado será usado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Uma PowerPoint XML Presentation | Inspeção da estrutura, solução de problemas, comparação da saída gerada e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legada | Compatibilidade com fluxos de trabalho antigos do PowerPoint |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo múltiplas partes | Edição regular no PowerPoint e troca de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou uma imagem multipágina | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Uma representação renderizada de um slide individual | Miniaturas, pré‑visualizações e recursos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para web | Visualização em navegador e publicação web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slides, ela representa dados da apresentação em vez de renderizar slides como páginas ou ativos visuais. A tabela [formatos de arquivo suportados](/slides/pt/java/supported-file-formats/) lista PowerPoint XML Presentation como um formato somente de gravação, portanto não o use quando um fluxo de trabalho precisar carregar o arquivo exportado novamente no Aspose.Slides para edição contínua.

## **Perguntas Frequentes**

**O `SaveFormat.Xml` é o mesmo que salvar um arquivo PPTX?**

Não. PPTX é um pacote contendo múltiplas partes do Office Open XML, enquanto `SaveFormat.Xml` cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um fluxo gravável para [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Por exemplo, use um [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) para processamento em memória.

**O Aspose.Slides pode carregar novamente o arquivo XML exportado?**

Não. PowerPoint XML Presentation atualmente é suportado apenas para gravação, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessário edição de ida e volta.

**A conversão XML renderiza cada slide como uma página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas, ou PNG, JPEG e SVG para imagens de slides individuais.