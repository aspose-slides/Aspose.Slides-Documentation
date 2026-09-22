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
- apresentação para stream
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualizando miniatura
- progresso de salvamento
- Android
- Java
- Aspose.Slides
description: "Salvar apresentações PowerPoint e OpenDocument em arquivos ou streams no Android com Aspose.Slides, e configurar a saída PPTX e o relatório de progresso."
---
## **Visão geral**

Depois de criar uma apresentação ou [abrir uma existente](/slides/pt/androidjava/open-presentation/), use o método [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para gravar o resultado. Aspose.Slides for Android via Java pode salvar uma apresentação em um arquivo ou stream nos formatos PowerPoint, OpenDocument, PDF e outros. As seções a seguir cobrem as operações padrão de salvamento e as opções disponíveis para saída PPTX.

## **Salvar apresentações em arquivos**

Para salvar uma apresentação em um arquivo, passe o caminho de saída e um valor [SaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/) ao método [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). O valor de formato determina o tipo de arquivo que o Aspose.Slides cria.

O exemplo a seguir cria uma apresentação e a salva como um arquivo PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Adicione ou modifique o conteúdo da apresentação aqui.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato original**

Para exemplos de detecção de arquivos e streams, o comportamento de apresentações recém‑criadas e a distinção entre formatos de origem e de saída, veja [Determine the Original Presentation Format](/slides/pt/androidjava/detect-presentation-source-format/).

Em um aplicativo de processamento em lote, o formato de entrada pode não ser conhecido antecipadamente. Depois de carregar um arquivo, leia seu formato original usando o método [IPresentation.getSourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) . Passe o valor resultante de [SourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/sourceformat/) para [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) para obter o valor correspondente de [SaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/), e então use [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para gravar a apresentação modificada.

O exemplo completo a seguir processa cada arquivo em um diretório de entrada, atualiza seu título e o salva em um diretório de saída no formato em que foi carregado:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) mapeia PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML para seus respectivos formatos de salvamento de apresentação. Ele mapeia apenas formatos de origem de apresentações; não serve para selecionar formatos de exportação como PDF, HTML, TIFF ou imagens. Passar um valor [SourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/sourceformat/) não suportado ou inválido gera uma [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Arquivos legados PPT, PPS e POT usam o mesmo contêiner binário. Quando tal apresentação é carregada de um stream sem extensão de arquivo, um arquivo PPS ou POT pode ser identificado como PPT. Se for necessário preservar esses subtipos legados, mantenha o nome original do arquivo ou os metadados de formato separadamente e use‑os ao escolher o nome e o formato de saída.

## **Salvar apresentações em streams**

Para gravar uma apresentação sem depender de um caminho de arquivo final, passe um stream gravável e um valor [SaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/) ao método [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Essa abordagem é útil quando a saída deve ser retornada de um serviço web, armazenada em um banco de dados ou processada em memória.

O exemplo a seguir salva uma nova apresentação em um stream de arquivo:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações com um tipo de visualização predefinido**

Você pode especificar a visualização na qual o PowerPoint abre inicialmente uma apresentação salva. Use o método [ViewProperties.setLastView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) com um valor [ViewType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewtype/) antes de salvar.

O exemplo a seguir configura a visualização Mestre de Slides como visualização inicial:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Strict Office Open XML**

Para criar um arquivo PPTX que esteja em conformidade com o perfil Strict do Office Open XML, crie uma instância de [PptxOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/) e use seu método [setConformance](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) com [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Em seguida, passe as opções ao método [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo ZIP padrão limita o tamanho compactado e descompactado de cada entrada, o tamanho total do arquivo e o número de entradas. Como um arquivo PPTX é um arquivo ZIP, uma apresentação muito grande pode exceder esses limites. As extensões ZIP64 aumentam os limites de tamanho e contagem de entradas aplicáveis.

Use o método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) para controlar se o Aspose.Slides grava extensões ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#IfNecessary) usa ZIP64 somente quando a apresentação excede os limites padrão de ZIP. Este é o modo padrão.
- [Never](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Never) desabilita as extensões ZIP64.
- [Always](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Always) grava sempre as extensões ZIP64.

O exemplo a seguir sempre habilita extensões ZIP64 para a apresentação de saída:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Se [Zip64Mode.Never](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/zip64mode/#Never) for usado e a apresentação não couber nos limites padrão de ZIP, a operação de salvamento lançará uma [PptxException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Para saída PPTX, você pode equilibrar a velocidade de salvamento em relação ao tamanho do arquivo usando o método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). A classe [CompressionLevel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/) fornece esses valores:

- [None](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#None) armazena dados sem compressão.
- [Level1](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level1) oferece a compressão mais rápida e a maior saída compactada.
- [Level2](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level2) até [Level5](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level5) favorecem progressivamente uma saída menor em detrimento da velocidade de salvamento.
- [Level6](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level6) equilibra velocidade de salvamento e tamanho do arquivo. Este é o nível padrão.
- [Level7](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level8) favorecem ainda mais uma saída menor em detrimento da velocidade.
- [Level9](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compressionlevel/#Level9) fornece a compressão mais forte e requer mais tempo de processamento.

O exemplo a seguir salva uma apresentação sem compressão:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

O exemplo a seguir usa o nível máximo de compressão:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvar apresentações sem atualizar a miniatura**

Quando uma apresentação é salva como PPTX, o método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controla sua miniatura de documento:

- `true` regenera a miniatura durante a operação de salvamento. Este é o valor padrão.
- `false` preserva a miniatura existente. Se a apresentação não possuir miniatura, o Aspose.Slides não gera uma.

O exemplo a seguir salva uma apresentação sem atualizar sua miniatura:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Desabilitar a atualização da miniatura pode reduzir o tempo necessário para salvar um arquivo PPTX.
{{% /alert %}}

## **Atualizações de progresso de salvamento em porcentagem**

Para monitorar uma operação de salvamento, implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprogresscallback/) e passe a implementação ao método [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). O Aspose.Slides então chama o método [IProgressCallback.reporting](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) com valores de progresso durante a exportação.

O exemplo a seguir relata o progresso de uma exportação PDF no console:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A Aspose oferece um [PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) gratuito, construído com a API Aspose.Slides. Ele salva slides selecionados de uma apresentação como arquivos PPT ou PPTX separados.
{{% /alert %}}

## **Perguntas frequentes**

**O Aspose.Slides oferece suporte a salvamento incremental ou “salvamento rápido”?**

Não. Cada operação de salvamento grava um arquivo de saída completo, em vez de atualizar apenas as partes alteradas.

**Várias threads podem salvar a mesma instância de Presentation?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) **não é thread‑safe** (/slides/pt/androidjava/multithreading/). Acesse e salve cada instância apenas de uma thread por vez.

**O que acontece com hyperlinks e arquivos vinculados externamente quando salvo uma apresentação?**

[Hyperlinks](/slides/pt/androidjava/manage-hyperlinks/) permanecem na apresentação. O Aspose.Slides não copia arquivos vinculados externamente, portanto a apresentação salva ainda deve ser capaz de acessar suas localizações.

**Posso salvar metadados do documento, como autor, título, empresa e data de criação?**

Sim. Defina as [propriedades do documento](/slides/pt/androidjava/presentation-properties/) apropriadas antes de salvar, e o Aspose.Slides as grava no arquivo de saída.