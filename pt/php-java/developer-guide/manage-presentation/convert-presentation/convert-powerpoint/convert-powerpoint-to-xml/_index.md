---
title: Converter apresentações PowerPoint para XML em PHP
linktitle: PowerPoint para XML
type: docs
weight: 145
url: /pt/php-java/convert-powerpoint-to-xml/
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
- stream XML
- PHP
- Aspose.Slides
description: "Converta apresentações PowerPoint e OpenDocument para arquivos ou streams PowerPoint XML em PHP com Aspose.Slides for PHP via Java."
---
## **Visão geral**

Aspose.Slides for PHP via Java pode converter apresentações PowerPoint para o formato PowerPoint XML Presentation. A saída XML é útil quando você precisa de uma representação baseada em texto para inspecionar a estrutura da apresentação, solucionar problemas de documentos gerados, comparar a saída em testes automatizados ou integrar com um fluxo de trabalho que consome XML em vez de um pacote de apresentação.

Use o método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) com o valor `Xml` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/). Você pode gravar o resultado diretamente em um arquivo ou em um stream.

{{% alert color="info" title="Nota" %}}
`SaveFormat::Xml` cria um PowerPoint XML Presentation. Ele não extrai as partes individuais do Office Open XML armazenadas dentro de um pacote PPTX. Se precisar das partes exatas do pacote PPTX, como `ppt/presentation.xml` ou arquivos XML de slides individuais, inspecione o próprio pacote PPTX.
{{% /alert %}}

## **Converter uma apresentação para um arquivo XML**

Carregue uma apresentação de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e, em seguida, passe o caminho de saída e `SaveFormat::Xml` para [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). A origem pode ser qualquer formato de apresentação suportado para carregamento, como PPT, PPTX ou ODP.

O exemplo a seguir converte uma apresentação PPTX em um arquivo XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Gravar a saída XML em um stream**

Use a sobrecarga de stream de [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) quando o XML precisar permanecer na memória ou ser passado para outro componente, como um serviço web, provedor de armazenamento ou pipeline de processamento XML. O exemplo a seguir grava o resultado em um [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) e obtém o XML gerado como um array de bytes:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Passe $xmlBytes para o próximo componente no fluxo de trabalho.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Um `ByteArrayOutputStream` armazena todos os dados gerados na memória, portanto não é necessário redefinir a posição antes de chamar `toByteArray`.

## **Comparar XML com formatos de apresentação e exportação**

Escolha o formato de saída de acordo com o uso do resultado:

| Formato | Saída | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Um PowerPoint XML Presentation | Inspeção da estrutura, solução de problemas, comparação de saídas geradas e integração baseada em XML |
| PPT (`.ppt`) | Um arquivo de apresentação binário legado | Compatibilidade com fluxos de trabalho PowerPoint mais antigos |
| PPTX (`.pptx`) | Um pacote Office Open XML contendo várias partes | Edição regular no PowerPoint e troca de apresentações |
| PDF ou TIFF | Páginas de layout fixo ou uma imagem multipágina | Visualização, impressão e arquivamento |
| PNG, JPEG ou SVG | Representação renderizada de um slide individual | Miniaturas, pré‑visualizações e ativos de imagem |
| HTML ou HTML5 | Saída de apresentação orientada para web | Visualização em navegadores e publicação na web |

Ao contrário de PPT e PPTX, a saída XML destina‑se principalmente à inspeção e fluxos de trabalho orientados a dados. Ao contrário de PDF, TIFF, HTML e formatos de imagem de slides, ela representa dados da apresentação em vez de renderizar slides como páginas ou ativos visuais. A tabela [formatos de arquivo suportados](/slides/pt/php-java/supported-file-formats/) lista PowerPoint XML Presentation como um formato apenas de gravação, portanto não o utilize quando um fluxo de trabalho precisar carregar o arquivo exportado novamente no Aspose.Slides para edição contínua.

## **Perguntas frequentes**

**`SaveFormat::Xml` é o mesmo que salvar um arquivo PPTX?**

Não. PPTX é um pacote que contém múltiplas partes do Office Open XML, enquanto `SaveFormat::Xml` cria um arquivo PowerPoint XML Presentation.

**Posso salvar a saída XML sem criar um arquivo no disco?**

Sim. Passe um stream gravável para [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Por exemplo, use um [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) para processamento em memória.

**Aspose.Slides pode carregar novamente o arquivo XML exportado?**

Não. PowerPoint XML Presentation é atualmente suportado apenas para gravação, não para carregamento. Use PPTX ou outro formato de apresentação suportado quando for necessário editar em um ciclo completo.

**A conversão XML renderiza cada slide como página ou imagem?**

Não. A conversão XML grava dados estruturados da apresentação. Use PDF ou TIFF para saída orientada a páginas ou PNG, JPEG e SVG para imagens de slides individuais.