---
title: Converter PPT para PPTX em C++
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/cpp/convert-ppt-to-pptx/
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
- C++
- Aspose.Slides
description: "Converter arquivos PPT legados para PPTX em C++ com Aspose.Slides. Inclui exemplos C++ para conversão de arquivo único e em lote, tratamento de erros e notas de fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. Aspose.Slides for C++ pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/), então chame [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) com [SaveFormat::Pptx](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/). Libere a apresentação quando ela não for mais necessária para liberar seus recursos.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat::Pptx](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar preservar o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte todos os arquivos `.ppt` em um diretório. Cada arquivo é processado de forma independente, de modo que uma conversão falhada não interrompe o restante do lote.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e escreva os nomes dos arquivos que falharam em uma fila de reprocessamento ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem causar falha na conversão. Consulte [Password-Protected Presentations](/cpp/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e Recursos Legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. No entanto, PPT e PPTX não representam todos os recursos exatamente da mesma maneira. Um recurso legado que não tem equivalente em PPTX, ou que não é suportado pela biblioteca, pode ser normalizado, omitido ou exibido de forma diferente.

Verifique o arquivo convertido quando ele contém animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não é um formato habilitado para macros, portanto use um fluxo de trabalho adequado para macros quando o VBA precisar permanecer disponível. Também verifique se as fontes necessárias e os recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra o PPTX gerado programaticamente e inspecione a contagem e o conteúdo dos slides principais, depois compare sua aparência e comportamento de apresentação no visualizador pretendido. Não trate uma chamada bem‑sucedida a [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) como prova de que todo recurso legado tem uma representação exata em PPTX.

## **Quando usar PPTX**

Use PPTX quando a apresentação for editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar do que o PPT binário legado. Mantenha o PPT original como uma cópia de arquivo ou de rollback até que a apresentação convertida tenha passado seus testes de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) em vez de presumir que todos os destinos preservam os recursos editáveis do PowerPoint.

## **Conversor Online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [online PPT to PPTX converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetíveis, processamento em lote ou tratamento de erros a nível de aplicação, use a API C++.

## **Artigos Relacionados**

- [Salvar Apresentações em C++](/cpp/save-presentation/)
- [Formatos de Arquivo Compatíveis](/cpp/supported-file-formats/)
- [Abrir Apresentações em C++](/cpp/open-presentation/)

## **Perguntas Frequentes**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides for C++ carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ele preserva o conteúdo comum da apresentação, mas a fidelidade exata não é garantida para cada recurso legado ou não suportado. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz com que a operação de carregamento falhe.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até que você tenha verificado o PPTX nos visualizadores e fluxos de trabalho que são importantes para você. Isso fornece uma cópia de rollback caso um recurso legado seja convertido de forma diferente.