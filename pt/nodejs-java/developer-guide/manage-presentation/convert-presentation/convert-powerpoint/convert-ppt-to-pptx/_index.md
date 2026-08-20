---
title: Converter PPT para PPTX em Node.js
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta arquivos PPT legados para PPTX no Node.js com Aspose.Slides. Inclui exemplos em JavaScript para conversão de arquivo único e em lote, tratamento de erros e notas de fidelidade."
---
## **Visão geral**

PPT é o formato binário antigo do PowerPoint, enquanto PPTX é o formato Open XML mais novo. Aspose.Slides para Node.js via Java pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) , depois chame [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/) . O bloco `finally` libera a apresentação e libera seus recursos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Carregar a apresentação PPT legada.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Salvar a apresentação no formato PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar manter o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte cada arquivo `.ppt` em um diretório. Cada arquivo é processado de forma independente, de modo que uma conversão falhada não interrompe o restante do lote.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Para cargas de trabalho de produção, registre o erro completo, decida se um arquivo de saída existente pode ser sobrescrito e grave os nomes dos arquivos que falharam em uma fila de tentativa ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem causar falha na conversão. Consulte [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. No entanto, PPT e PPTX não representam todos os recursos exatamente da mesma forma. Um recurso legado que não tem equivalente PPTX, ou que não é suportado pela biblioteca, pode ser normalizado, omitido ou exibido de maneira diferente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não é um formato habilitado para macros, portanto use um fluxo de trabalho apropriado habilitado para macros quando o VBA precisar permanecer disponível. Também verifique se as fontes necessárias e os recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione contagens e conteúdo de slides-chave, depois compare sua aparência e comportamento de apresentação no visualizador pretendido. Não trate uma chamada bem‑sucedida a [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) como prova de que cada recurso legado tem uma representação PPTX exata.

## **Quando usar PPTX**

Use PPTX quando a apresentação será editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar do que o binário legado PPT. Mantenha o PPT original como cópia de arquivo ou de rollback até que a apresentação convertida tenha passado por suas verificações de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) em vez de presumir que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [online PPT to PPTX converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx) . Para conversões repetíveis, processamento em lote ou tratamento de erros em nível de aplicação, use a API Node.js via Java.

## **Artigos relacionados**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Salvar apresentações no Node.js](/nodejs-java/save-presentation/)
- [Formatos de arquivo suportados](/nodejs-java/supported-file-formats/)
- [Abrir apresentações no Node.js](/nodejs-java/open-presentation/)

## **Perguntas frequentes**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides para Node.js via Java carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ela preserva o conteúdo comum da apresentação, mas a fidelidade exata não é garantida para cada recurso legado ou não suportado. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz com que a operação de carregamento falhe.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até que você tenha verificado o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de rollback caso um recurso legado seja convertido de forma diferente.