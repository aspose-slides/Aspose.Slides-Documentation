---
title: Converter PPT para PPTX no Android
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/androidjava/convert-ppt-to-pptx/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- PPT para PPTX
- salvar PPT como PPTX
- exportar PPT para PPTX
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Converta arquivos PPT legados para PPTX no Android com Aspose.Slides. Inclui exemplos Java para conversão de arquivo único e em lote, tratamento de erros e observações de fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. Aspose.Slides for Android via Java pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um único arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e, em seguida, chame [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/#Pptx). O bloco `finally` descarta a apresentação e libera seus recursos.

```java
// Carregue a apresentação PPT legada.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Salve a apresentação no formato PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/#Pptx) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar reter o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte todos os arquivos `.ppt` de um diretório. Cada arquivo é processado independentemente, de modo que uma conversão falhada não interrompe o restante do lote.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e registre os nomes dos arquivos que falharam em uma fila de tentativa ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem causar falha na conversão. Consulte [Apresentações protegidas por senha](/androidjava/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. No entanto, PPT e PPTX não representam todos os recursos exatamente da mesma forma. Um recurso legado que não possui equivalente PPTX ou que não é suportado pela biblioteca pode ser normalizado, omitido ou exibido de forma diferente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não é um formato que aceita macros, portanto use um fluxo de trabalho adequado para arquivos com macro quando o VBA precisar permanecer disponível. Também verifique se as fontes necessárias e os recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione contagens e conteúdos chave dos slides, depois compare sua aparência e comportamento de apresentação no visualizador desejado. Não considere uma chamada bem‑sucedida a [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) como prova de que cada recurso legado tem uma representação PPTX exata.

## **Quando usar PPTX**

Use PPTX quando a apresentação for editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar do que o binário legado PPT. Mantenha o PPT original como cópia de arquivo ou backup até que a apresentação convertida passe nas suas verificações de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Converter apresentações para vários formatos](/androidjava/convert-presentation/) em vez de presumir que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [conversor online de PPT para PPTX](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetíveis, processamento em lote ou tratamento de erros em nível de aplicação, use a API Android via Java.

## **Artigos relacionados**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Salvar apresentações no Android](/androidjava/save-presentation/)
- [Formatos de arquivo suportados](/androidjava/supported-file-formats/)
- [Abrir apresentações no Android](/androidjava/open-presentation/)

## **Perguntas frequentes**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides for Android via Java carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ela preserva o conteúdo comum das apresentações, mas a fidelidade exata não é garantida para cada recurso legado ou não suportado. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz com que a operação de carregamento falhe.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até que você tenha verificado o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de backup caso um recurso legado seja convertido de forma diferente.