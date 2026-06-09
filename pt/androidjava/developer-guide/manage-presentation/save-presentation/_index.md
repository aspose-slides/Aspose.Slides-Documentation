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
- atualizando miniatura
- progresso de salvamento
- Android
- Java
- Aspose.Slides
description: "Descubra como salvar apresentações em Java usando Aspose.Slides para Android—exporte para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Abrir apresentações no Android](/slides/pt/androidjava/open-presentation/) descreve como usar a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides for Android, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salvar uma apresentação em um arquivo chamando o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Execute alguma tarefa aqui...

    // Salve a apresentação em um arquivo.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações em fluxos**

Você pode salvar uma apresentação em um fluxo passando um fluxo de saída para o método `save` da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Uma apresentação pode ser gravada em diversos tipos de fluxo. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Salve a apresentação no fluxo.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações com um tipo de visualização predefinido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta através da classe [ViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/). Use o método [setLastView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/) e defina sua propriedade conformance ao salvar. Se você definir [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo a seguir cria uma apresentação e a salva no formato Strict Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Salve a apresentação no formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) no tamanho descompactado de qualquer arquivo, no tamanho compactado de qualquer arquivo e no tamanho total do arquivo, e também limita o arquivo a 65 535 (2^16‑1) arquivos. As extensões de formato ZIP64 aumentam esses limites para 2^64.

O método [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os seguintes modos:

- [IfNecessary](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#IfNecessary) usa extensões de formato ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Never) nunca usa extensões de formato ZIP64.
- [Always](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Always) sempre usa extensões de formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como PPTX com extensões de formato ZIP64 habilitadas:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTA" color="warning" %}}
Quando você salva com [Zip64Mode.Never](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Never), é lançada uma [PptxException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxexception/) se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações sem atualizar a miniatura**

O método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não possui miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```java
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

## **Atualizações de progresso ao salvar em porcentagem**

A interface [IProgressCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprogresscallback/) é usada através do método `setProgressCallback` exposto pela interface [ISaveOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isaveoptions/) e pela classe abstrata [SaveOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveoptions/). Atribua uma implementação de [IProgressCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprogresscallback/) com `setProgressCallback` para receber atualizações de progresso de salvamento em porcentagem.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```java
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
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Use o valor percentual de progresso aqui.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [app gratuito PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos salvando os slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **Perguntas frequentes**

**O "fast save" (salvamento incremental) é suportado para que apenas as mudanças sejam gravadas?**

Não. O salvamento cria o arquivo de destino completo a cada vez; o "fast save" incremental não é suportado.

**É seguro em múltiplas threads salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) [não é thread‑safe](/slides/pt/androidjava/multithreading/); salve‑a a partir de um único thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/androidjava/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos por caminhos relativos) não são copiados automaticamente — assegure que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As [propriedades de documento](/slides/pt/androidjava/presentation-properties/) padrão são suportadas e serão gravadas no arquivo ao salvar.