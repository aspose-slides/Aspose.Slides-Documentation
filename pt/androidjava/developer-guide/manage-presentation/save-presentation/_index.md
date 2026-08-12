---
title: Salvar apresentações no Android
linktitle: Salvar apresentação
type: docs
weight: 80
url: /pt/androidjava/save-presentation/
keywords:
- salvar PowerPoint
- salvar OpenDocument
- salvar apresentação
- salvar slide
- salvar PPT
- salvar PPTX
- salvar ODP
- apresentação para arquivo
- apresentação para fluxo
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualização de miniatura
- progresso de salvamento
- Android
- Java
- Aspose.Slides
description: "Descubra como salvar apresentações em Java usando o Aspose.Slides para Android — exporte para PowerPoint ou OpenDocument preservando layouts, fontes e efeitos."
---
## **Visão geral**

[Apresentações abertas no Android](/slides/pt/androidjava/open-presentation/) descreve como usar a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides para Android, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento ao método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Faça algum trabalho aqui...

    // Salvar a apresentação em um arquivo.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações em fluxos**

Você pode salvar uma apresentação em um fluxo passando um *output stream* ao método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Uma apresentação pode ser escrita em vários tipos de fluxo. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Salvar a apresentação no fluxo.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações com um tipo de exibição predefinido**

Aspose.Slides permite definir a exibição inicial que o PowerPoint usa quando a apresentação gerada é aberta por meio da classe [ViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/). Use o método [setLastView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/) e defina sua propriedade *conformance* ao salvar. Se você definir [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Salvar a apresentação no formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) ao tamanho não compactado de qualquer arquivo, ao tamanho compactado de qualquer arquivo e ao tamanho total do arquivo, além de limitar o arquivo a 65 535 (2^16‑1) arquivos. As extensões do formato ZIP64 elevam esses limites para 2^64.

O método [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) permite escolher quando usar as extensões do formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os seguintes modos:

- [IfNecessary](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#IfNecessary) usa as extensões ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Never) nunca usa as extensões ZIP64.
- [Always](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Always) sempre usa as extensões ZIP64.

O código a seguir demonstra como salvar uma apresentação como um arquivo PPTX com as extensões ZIP64 habilitadas:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Ao salvar com [Zip64Mode.Never](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Never), uma [PptxException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Ao trabalhar com apresentações grandes, você pode ajustar o nível de compressão para equilibrar o tamanho do arquivo e o tempo de processamento. Dependendo dos requisitos, você pode preferir um processamento mais rápido ou arquivos de saída menores.

Aspose.Slides fornece o método [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), que permite especificar o nível de compressão usado ao salvar uma apresentação no formato Office Open XML.

Os seguintes níveis de compressão estão disponíveis:

- [**None**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#None): Nenhuma compressão é aplicada. Os arquivos são armazenados como estão.
- [**Level1**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level1): Compressão mais rápida com a menor taxa de compressão.
- [**Level2**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level2): Compressão mais rápida com uma taxa de compressão ligeiramente melhor que **Level1**.
- [**Level3**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level3): Proporciona melhor compressão que **Level2** com impacto moderado no tempo de processamento.
- [**Level4**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level4): Proporciona melhor compressão que **Level3**.
- [**Level5**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level5): Proporciona compressão aprimorada em relação a **Level4** com tempo de processamento adicional.
- [**Level6**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level6): Compressão padrão que oferece um bom equilíbrio entre velocidade de processamento e tamanho do arquivo. Este é o *nível de compressão padrão*.
- [**Level7**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level7): Proporciona melhor compressão que **Level6** com processamento mais lento.
- [**Level8**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level8): Proporciona melhor compressão que **Level7**.
- [**Level9**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level9): Compressão máxima. Produz o menor tamanho de arquivo ao custo do maior tempo de processamento.

O exemplo a seguir demonstra como salvar uma apresentação como um arquivo PPTX *sem compressão*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Este exemplo mostra como salvar uma apresentação como um arquivo PPTX com *compressão máxima*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações sem atualizar a miniatura**

O método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

## **Salvar atualizações de progresso em percentual**

A interface [IProgressCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprogresscallback/) é usada por meio do método `setProgressCallback` exposto pela interface [ISaveOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isaveoptions/) e pela classe abstrata [SaveOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveoptions/). Atribua uma implementação de [IProgressCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprogresscallback/) com `setProgressCallback` para receber atualizações de progresso de salvamento em percentual.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Use o valor percentual de progresso aqui.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [aplicativo gratuito PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O aplicativo permite dividir uma apresentação em vários arquivos ao salvar os slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**O “salvamento rápido” (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo de destino completo; o “salvamento rápido” incremental não é suportado.

**É thread‑safe salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) **não é thread‑safe** (/slides/pt/androidjava/multithreading/); salve-a a partir de uma única thread.

**O que acontece com hiperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/androidjava/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente – garanta que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As propriedades padrão do [documento](/slides/pt/androidjava/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.