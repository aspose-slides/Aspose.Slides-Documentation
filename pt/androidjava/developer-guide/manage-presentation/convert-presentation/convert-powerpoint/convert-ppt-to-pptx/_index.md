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
description: "Converta arquivos PPT legados para PPTX no Android com Aspose.Slides. Inclui exemplos em Java para conversão de arquivo único e em lote, tratamento de erros e notas de fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. O Aspose.Slides para Android via Java pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/), depois chame [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/#Pptx). O bloco `finally` libera a apresentação e seus recursos.

```java
// Carregar a apresentação PPT legada.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Salvar a apresentação no formato PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/#Pptx) o faz. Mantenha os caminhos de entrada e saída diferentes se precisar manter o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte todos os arquivos `.ppt` em um diretório. Cada arquivo é processado de forma independente, de modo que uma falha na conversão não interrompe o restante do lote.

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

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e grave os nomes dos arquivos que falharam em uma fila de nova tentativa ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem fazer a conversão falhar. Consulte [Password-Protected Presentations](/androidjava/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. Contudo, PPT e PPTX não representam todos os recursos da mesma forma. Um recurso legado que não tem equivalente PPTX, ou que não é suportado pela biblioteca, pode ser normalizado, omitido ou exibido diferentemente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não é um formato habilitado para macros, portanto use um fluxo de trabalho adequado para macros quando o VBA precisar permanecer disponível. Também confirme que as fontes necessárias e os recursos externos estejam presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione contagens chave de slides e conteúdo, depois compare sua aparência e comportamento de apresentação no visualizador pretendido. Não considere que uma chamada bem‑sucedida a [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) seja prova de que todo recurso legado tem uma representação PPTX exata.

## **Quando usar PPTX**

Use PPTX quando a apresentação será editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar do que o binário legado PPT. Mantenha o PPT original como cópia de arquivamento ou de reversão até que a apresentação convertida tenha passado seus testes de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Convert Presentations to Multiple Formats](/slides/pt/androidjava/convert-presentation/) em vez de presumir que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [online PPT to PPTX converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetidas, processamento em lote ou tratamento de erros ao nível da aplicação, use a API Android via Java.

## **Artigos relacionados**

- [PPT vs PPTX](/slides/pt/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/pt/androidjava/save-presentation/)
- [Supported File Formats](/slides/pt/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/pt/androidjava/open-presentation/)

## **FAQ**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. O Aspose.Slides para Android via Java carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ela preserva o conteúdo comum das apresentações, mas a fidelidade exata não é garantida para todos os recursos legados ou não suportados. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz a operação de carregamento falhar.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até que você tenha verificado o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de reversão caso um recurso legado seja convertido de forma diferente.