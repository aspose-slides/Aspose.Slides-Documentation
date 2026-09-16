---
title: Exportar apresentações para XAML em .NET
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/net/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar apresentação
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- PowerPoint para XAML
- OpenDocument para XAML
- apresentação para XAML
- PPT para XAML
- PPTX para XAML
- ODP para XAML
- salvar PPT como XAML
- salvar PPTX como XAML
- salvar ODP como XAML
- exportar PPT para XAML
- exportar PPTX para XAML
- exportar ODP para XAML
- .NET
- C#
- Aspose.Slides
description: "Converter slides de PowerPoint e OpenDocument para XAML em .NET usando Aspose.Slides—solução rápida, sem necessidade do Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação por meio de [XamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade com pilhas XAML e ao comportamento da exportação de slides ocultos.

## **Sobre o XAML**

XAML é uma linguagem de marcação baseada em XML usada para descrever interfaces de usuário em frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

Você pode trabalhar com arquivos XAML em um designer visual ou escrever e editar a marcação diretamente.

## **Exportar apresentações para XAML com opções padrão**

O exemplo C# a seguir mostra como exportar uma apresentação para XAML com as configurações padrão:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Por padrão, os slides exportados são salvos em uma subpasta `pres` do diretório de trabalho atual do processo, conforme retornado por [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). A pasta é criada automaticamente, e quaisquer imagens necessárias também são salvas lá.

O nome da pasta de saída é obtido a partir do nome do arquivo de origem sem sua extensão. Para `pres.pptx`, os arquivos de saída são nomeados `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e assim por diante. Mesmo que você forneça um caminho absoluto para a apresentação de entrada, a pasta de saída é criada em relação ao diretório de trabalho atual, e não ao lado do arquivo de entrada.

## **Exportar apresentações para XAML com opções personalizadas**

Use a interface [IXamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/ixamloptions/) para controlar como o Aspose.Slides exporta uma apresentação para XAML.

Para salvar a saída em um local personalizado, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/ixamloutputsaver/) e atribua uma instância de sua implementação à propriedade [OutputSaver](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/outputsaver/) de [XamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/).

Para incluir slides ocultos na saída XAML, defina a propriedade [ExportHiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) como `true`, conforme mostrado no exemplo C# a seguir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Capturar todos os artefatos XAML gerados**

Uma exportação XAML pode gerar um documento XAML para cada slide exportado, além de imagens separadas e recursos de apoio. Atribua um [IXamlOutputSaver](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/ixamloutputsaver/) customizado a [XamlOptions.OutputSaver](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/outputsaver/) para receber esses artefatos em vez de usar o salvador padrão do sistema de arquivos. Inicie a exportação com a sobrecarga XAML‑específica de [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) que aceita opções XAML.

### **Entender o ciclo de vida do retorno de chamada**

O exportador chama [IXamlOutputSaver.Save](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/ixamloutputsaver/save/) separadamente para cada artefato gerado:

- `path` identifica o artefato e pode incluir diretórios relativos. Preserve esta informação porque o XAML pode referenciar recursos usando caminhos relativos.
- `data` contém os bytes do artefato. Imagens e outros recursos binários não devem ser decodificados como texto.
- O salvador é responsável por reter ou persistir os dados antes de retornar. Os exemplos copiam cada array de bytes para a memória da aplicação.
- Considere a exportação como bem‑sucedida somente quando a operação de salvamento da apresentação retorna e todas as chamadas de retorno são concluídas com sucesso. Não sufoque erros de armazenamento nem inicie gravações em segundo plano não observadas. Se a persistência ocorrer posteriormente, reporte o sucesso geral somente após essa etapa também ter sido concluída com êxito.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) também se aplica a um salvador customizado. Seu valor padrão, `false`, exclui documentos XAML de slides ocultos. Definir como `true` inclui-os e quaisquer recursos necessários para sua exportação. A contagem de recursos depende da apresentação; não presuma um retorno de chamada por slide ou uma ordem fixa de callbacks.

### **Exportar para memória e inspecionar os artefatos**

Este exemplo completo carrega `pres.pptx`, coleta cada artefato em um [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) e imprime seu nome, tipo e contagem de bytes. Ele preserva exatamente os nomes fornecidos. Nomes duplicados fazem a coleta falhar em vez de sobrescrever silenciosamente um artefato.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Decodifique apenas XAML e somente quando for necessária a inspeção textual.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Chame `InMemoryXamlExample.Run` a partir da sua aplicação. Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recursos desconhecidos. Deixe os bytes inalterados ao armazená‑los ou transmiti‑los. Use [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) somente para XAML que precise de processamento textual.

### **Empacotar artefatos coletados em um arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP. Um nome de arquivo único separa trabalhos de exportação concorrentes. As entradas ZIP usam barras normais e preservam diretórios relativos. Nomes inseguros ou nomes que colidem após a normalização rejeitam todo o pacote antes de ser gravado.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // O diretório ZIP foi finalizado na desalocação antes de relatar o sucesso.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Chame `ZipXamlExample.Run` a partir da sua aplicação. O exemplo usa [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) para gravar um arquivo local; o exportador em si não grava arquivos XAML ou de imagem soltos. Para armazenamento remoto, substitua a fase de gravação do arquivo por uploads dos arrays de bytes coletados. Use um identificador de trabalho de exportação mais o nome relativo completo do artefato como chave de blob, ou armazene o identificador do trabalho, o nome relativo e os dados binários em uma linha de banco de dados. Publique o trabalho somente após todos os uploads concluírem ou a transação de banco de dados for confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, um salvador customizado pode persistir cada artefato diretamente no armazenamento da aplicação para evitar manter uma cópia adicional de toda a exportação na memória da aplicação. O exportador ainda coleta todos os artefatos gerados em memória antes de chamar o salvador. Mantenha cada callback síncrono do ponto de vista do exportador: retorne somente depois que o destino aceitar os bytes e permita que falhas alcancem o chamador.

### **Preservar nomes de recursos e verificar referências**

- Normalize separadores de caminho quando o destino exigir, mas preserve diretórios relativos. Não use somente [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) a menos que cada nome gerado seja conhecido por ser único e as referências a recursos permaneçam válidas.
- Aplique validação de nomes específica ao destino. Ao gravar arquivos soltos, rejeite caminhos raiz e segmentos de travessia, resolva o destino com [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) e verifique se ele permanece dentro do diretório de exportação pretendido, incluindo o separador de diretório na verificação de contenção. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um salvador e um namespace de armazenamento separados para cada trabalho de exportação. Detecte colisões após a normalização de separadores e de acordo com as regras de sensibilidade a maiúsculas/minúsculas do destino.
- Antes de publicar, analise cada documento XAML como XML e inspecione suas referências de recursos baseadas em arquivos, como atributos de imagem `Source` ou `ImageSource`. Resolva cada URI relativa em relação ao diretório do artefato XAML que a contém, normalize o nome de armazenamento resultante e confirme que a chave correspondente no dicionário, a entrada ZIP ou o objeto armazenado existe. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivos relativos.

Por exemplo, se `pres/Slide_1.xaml` referenciar `images/image1.png`, o recurso armazenado deve estar disponível como `pres/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve a mesma estrutura sob o prefixo do trabalho e torne essas URLs de recursos acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar nomes de entradas e bytes de recursos, e carregue slides representativos no ambiente XAML de destino para confirmar que as imagens são resolvidas corretamente.

## **Perguntas frequentes**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Defina [DefaultRegularFont](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/defaultregularfont/) em [XamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a original está ausente. Isso não garante que o XAML gerado referencie a fonte de fallback ou que a fonte esteja disponível na máquina de destino. Certifique‑se de que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele será exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

Aspose.Slides exporta XAML WPF por meio de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Os slides ocultos são suportados e como posso impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [ExportHiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) em [XamlOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export.xaml/xamloptions/) — mantenha‑a desativada se não precisar exportá‑los.