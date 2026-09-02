---
title: Converter PPT para PPTX em PHP
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "Converta arquivos PPT legados para PPTX em PHP com Aspose.Slides. Inclui exemplos PHP para conversão de arquivo único e em lote, tratamento de erros e notas de fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. Aspose.Slides for PHP via Java pode carregar um arquivo PPT e salvá-lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/), então chame [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) com [SaveFormat::Pptx](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/#Pptx). O bloco `finally` descarta a apresentação e libera seus recursos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Carregar a apresentação PPT legada.
$presentation = new Presentation("presentation.ppt");
try {
    // Salvar a apresentação no formato PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat::Pptx](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/#Pptx) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar preservar o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte cada arquivo `.ppt` em um diretório. Cada arquivo é processado de forma independente, portanto uma conversão falhada não interrompe o restante do lote.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e escreva os nomes dos arquivos que falharam em uma fila de reprocessamento ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem causar falha na conversão. Consulte [Password-Protected Presentations](/php-java/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. Contudo, PPT e PPTX não representam todos os recursos exatamente da mesma forma. Um recurso legado que não possui equivalente em PPTX, ou que não é suportado pela biblioteca, pode ser normalizado, omitido ou exibido de maneira diferente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não é um formato habilitado para macros, portanto use um fluxo de trabalho adequado para macros quando o VBA precisar permanecer disponível. Também verifique se as fontes necessárias e recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione contagens e conteúdo de slides chave, depois compare sua aparência e comportamento de apresentação no visualizador pretendido. Não trate uma chamada bem‑sucedida a [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) como prova de que todo recurso legado tem uma representação PPTX exata.

## **Quando usar PPTX**

Use PPTX quando a apresentação será editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar que o PPT binário legado. Mantenha o PPT original como uma cópia de arquivamento ou rollback até que a apresentação convertida tenha passado em suas verificações de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) em vez de assumir que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [online PPT to PPTX converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetíveis, processamento em lote ou tratamento de erros em nível de aplicação, use a API PHP.

## **Artigos relacionados**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Salvar apresentações em PHP](/php-java/save-presentation/)
- [Formatos de arquivo suportados](/php-java/supported-file-formats/)
- [Abrir apresentações em PHP](/php-java/open-presentation/)

## **Perguntas frequentes**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides for PHP via Java carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ele preserva o conteúdo comum de apresentações, mas a fidelidade exata não é garantida para cada recurso legado ou não suportado. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz com que a operação de carregamento falhe.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até verificar o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de rollback caso um recurso legado seja convertido de forma diferente.