---
title: Converter Apresentações PowerPoint para XML no Android
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/androidjava/convert-powerpoint-to-xml/
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
- Android
- Java
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para arquivos ou streams PowerPoint XML no Android com Aspose.Slides."
---
## **Visão geral**

Aspose.Slides for Android via Java pode converter apresentações PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas de documentos gerados, comparar resultados em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) com [SaveFormat.Xml](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/#Xml). Você pode gravar o resultado diretamente em um arquivo ou em um stream.

{{% alert color="info" title="Nota" %}}
`SaveFormat.Xml` cria uma PowerPoint XML Presentation. Não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slides individuais, examine o próprio pacote PPTX.
{{% /alert %}}

## **Converter uma Apresentação para um Arquivo XML**

Carregue uma apresentação de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e, em seguida, passe o caminho de saída e [SaveFormat.Xml](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/#Xml) para [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). A origem pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

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

## **Gravar a Saída XML em um Stream**

Use a sobrecarga de stream de [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) quando o XML precisar permanecer na memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) e obtém o XML gerado como um array de bytes:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Passe xmlData para o próximo componente no fluxo de trabalho.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Comparar XML com Formatos de Apresentação e Exportação**

Escolha o formato de saída de acordo com o uso previsto do resultado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Uma PowerPoint XML Presentation | Inspeção de estrutura, solução de problemas, comparação de saída gerada e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legado | Compatibilidade com fluxos de trabalho antigos do PowerPoint |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo várias partes | Edição regular de PowerPoint e troca de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou uma imagem multipágina | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Uma representação renderizada de um slide individual | Miniaturas, pré-visualizações e ativos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para web | Visualização em navegador e publicação na web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e a fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slide, ela representa os dados da apresentação em vez de renderizar os slides como páginas ou ativos visuais. A tabela [formatos de arquivo suportados](/slides/pt/androidjava/supported-file-formats/) lista PowerPoint XML Presentation como um formato apenas para salvar, portanto não o utilize quando um fluxo de trabalho precisar carregar o arquivo exportado novamente no Aspose.Slides para edição continuada.

## **FAQ**

**`SaveFormat.Xml` é o mesmo que salvar um arquivo PPTX?**

Não. PPTX é um pacote que contém várias partes do Office Open XML, enquanto `SaveFormat.Xml` cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um stream gravável para [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Por exemplo, use um [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) para processamento em memória.

**Aspose.Slides pode carregar novamente o arquivo XML exportado?**

Não. PowerPoint XML Presentation é atualmente suportado apenas para gravação, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessário um ciclo completo de edição.

**A conversão XML renderiza cada slide como uma página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas, ou PNG, JPEG e SVG para imagens individuais de slides.