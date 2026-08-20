---
title: Converter PPT para PPTX em .NET
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Converter arquivos PPT legados para PPTX em .NET com Aspose.Slides. Inclui exemplos em C# para conversão de arquivo único e em lote, tratamento de erros e observações de fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. Aspose.Slides for .NET pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), em seguida chame [IPresentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/save/) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/). A declaração `using` descarta a apresentação e libera seus recursos quando o escopo termina.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Carregar a apresentação PPT legada.
using var presentation = new Presentation("presentation.ppt");

// Salvar a apresentação no formato PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar preservar o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte cada arquivo `.ppt` em um diretório. Cada arquivo é processado de forma independente, de modo que uma conversão falhada não interrompe o restante do lote.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e escreva os nomes dos arquivos que falharam em uma fila de reprocessamento ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem causar falha na conversão. Consulte [Password‑Protected Presentations](/slides/pt/net/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, masters, layouts, texto, formas, imagens, tabelas e gráficos. No entanto, PPT e PPTX não representam todos os recursos exatamente da mesma forma. Um recurso legado que não tem equivalente PPTX, ou que não é suportado pela biblioteca, pode ser normalizado, omitido ou exibido de forma diferente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes pouco comuns ou macros VBA. Um arquivo PPTX simples não é um formato habilitado para macros, portanto use um fluxo de trabalho adequado para macros quando o VBA precisar permanecer disponível. Também verifique se as fontes necessárias e os recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione contagens de slides e conteúdo‑chave, depois compare sua aparência e comportamento de apresentação no visualizador pretendido. Não trate uma chamada bem‑sucedida a [IPresentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/save/) como prova de que todo recurso legado tem uma representação PPTX exata.

## **Quando usar PPTX**

Use PPTX quando a apresentação for editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar que o binário legado PPT. Mantenha o PPT original como uma cópia de arquivamento ou de retorno até que a apresentação convertida tenha passado em seus testes de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Convert Presentations to Multiple Formats](/slides/pt/net/convert-presentation/) em vez de assumir que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [online PPT to PPTX converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetíveis, processamento em lote ou tratamento de erros em nível de aplicação, use a API .NET.

## **Artigos relacionados**

- [PPT vs PPTX](/slides/pt/net/ppt-vs-pptx/)
- [Save Presentations in .NET](/slides/pt/net/save-presentation/)
- [Supported File Formats](/slides/pt/net/supported-file-formats/)
- [Open Presentations in .NET](/slides/pt/net/open-presentation/)

## **FAQ**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides for .NET carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Preserva o conteúdo de apresentação comum, mas a fidelidade exata não é garantida para todos os recursos legados ou não suportados. Revise o arquivo gerado quando contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes pouco comuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz com que a operação de carregamento falhe.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até que você tenha verificado o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de retorno caso um recurso legado seja convertido de forma diferente.