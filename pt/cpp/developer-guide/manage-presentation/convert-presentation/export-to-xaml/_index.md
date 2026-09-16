---
title: Exportar apresentações para XAML em C++
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Converta slides PowerPoint e OpenDocument para XAML em C++ usando Aspose.Slides—solução rápida e livre de Office que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através do [XamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas frequentes relacionadas a fontes de fallback, compatibilidade com pilhas XAML e ao comportamento de exportação de slides ocultos.

## **Sobre XAML**

XAML é uma linguagem de marcação baseada em XML usada para descrever interfaces de usuário em estruturas como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

Você pode trabalhar com arquivos XAML em um designer visual ou escrever e editar a marcação diretamente.

## **Exportar apresentações para XAML com opções padrão**

O exemplo C++ a seguir mostra como exportar uma apresentação para XAML com as configurações padrão:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Por padrão, os slides exportados são salvos em uma subpasta `pres` do diretório de trabalho atual do processo, conforme retornado por [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/pt/cpp/system.io/directory/getcurrentdirectory/). A pasta é criada automaticamente, e quaisquer imagens necessárias são salvas lá também.

O nome da pasta de saída é derivado do nome do arquivo fonte sem sua extensão. Para `pres.pptx`, os arquivos de saída são nomeados `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e assim por diante. Mesmo que você passe um caminho absoluto para a apresentação de entrada, a pasta de saída é criada em relação ao diretório de trabalho atual, e não ao lado do arquivo de entrada.

## **Exportar apresentações para XAML com opções personalizadas**

Use a interface [IXamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/ixamloptions/) para controlar como Aspose.Slides exporta uma apresentação para XAML.

Para salvar a saída em um local personalizado, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/ixamloutputsaver/) e passe uma instância da sua implementação ao método [set_OutputSaver](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) de [XamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/).

Para incluir slides ocultos na saída XAML, passe `true` ao método [set_ExportHiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), como mostrado no exemplo C++ a seguir:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Capturar todos os artefatos XAML gerados**

Uma exportação XAML pode gerar um documento XAML para cada slide exportado, além de imagens e recursos de suporte separados. Passe um [IXamlOutputSaver](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/ixamloutputsaver/) personalizado para [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) a fim de receber esses artefatos em vez de usar o salvador padrão baseado em sistema de arquivos. Inicie a exportação com a sobrecarga específica de XAML de [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) que aceita opções XAML.

### **Entender o ciclo de vida da callback**

O exportador chama [IXamlOutputSaver::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) separadamente para cada artefato gerado:

- `path` identifica o artefato e pode incluir diretórios relativos. Mantenha essa informação porque o XAML pode referenciar recursos usando caminhos relativos.
- `data` contém os bytes do artefato. Imagens e outros recursos binários não devem ser decodificados como texto.
- O salvador é responsável por reter ou persistir os dados antes de retornar. Os exemplos copiam cada array de bytes para memória possuída pela aplicação.
- Considere a exportação bem‑sucedida apenas quando a operação de salvar a apresentação retornar e todas as callbacks tiverem sido concluídas com sucesso. Não ignore erros de armazenamento nem inicie gravações em segundo plano não observadas. Se a persistência ocorrer posteriormente, reporte o sucesso geral somente após essa etapa também ser bem‑sucedida.

[set_ExportHiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) também se aplica a um salvador personalizado. A configuração padrão, `false`, exclui documentos XAML de slides ocultos. Definir como `true` inclui-os e quaisquer recursos necessários para sua exportação. A quantidade de recursos depende da apresentação; não presuma uma callback por slide ou uma ordem fixa de callbacks.

### **Exportar para memória e inspecionar os artefatos**

Este exemplo completo carrega `pres.pptx`, coleta cada artefato em um [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/pt/cpp/system.collections.generic/dictionary/), e imprime seu nome, tipo e contagem de bytes. Ele preserva exatamente os nomes fornecidos. Nomes duplicados fazem a coleta falhar em vez de sobrescrever silenciosamente um artefato.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Decodificar apenas XAML, e somente quando a inspeção textual for necessária.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Chame `InMemoryXamlExample::Run` a partir da sua aplicação. Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recurso desconhecidos. Deixe os bytes inalterados ao armazená‑los ou transmiti‑los. Use [Encoding::GetString](https://reference.aspose.com/slides/pt/cpp/system.text/encoding/getstring/) com codificação UTF‑8 somente para XAML que precise de processamento textual.

### **Empacotar artefatos coletados em um arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP. Um nome de arquivo exclusivo separa jobs de exportação concorrentes. Entradas ZIP usam barras normais e mantêm diretórios relativos. Nomes inseguros ou que colidem após normalização rejeitam o pacote inteiro antes de ser escrito.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save finaliza o diretório ZIP; feche o arquivo antes de relatar o sucesso.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Chame `ZipXamlExample::Run` a partir da sua aplicação. O exemplo usa `Aspose::Zip::ZipFile` da runtime C++ para gravar um arquivo local; o exportador em si não grava arquivos XAML ou de imagem soltos. Para armazenamento remoto, substitua a fase de gravação do arquivo por uploads dos arrays de bytes coletados. Use um identificador de job de exportação mais o nome relativo completo do artefato como chave de blob, ou armazene o identificador do job, o nome relativo e os dados binários em uma linha de banco de dados. Publique o job somente após todos os uploads concluírem ou a transação do banco de dados for confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, um salvador personalizado pode persistir cada artefato diretamente no armazenamento da aplicação para evitar manter uma cópia adicional de toda a exportação na memória da aplicação. O exportador ainda coleta todos os artefatos gerados em memória antes de chamar o salvador. Mantenha cada callback síncrono do ponto de vista do exportador: retorne somente após o destino aceitar os bytes e permita que falhas cheguem ao chamador.

### **Preservar nomes de recursos e verificar referências**

- Normalize separadores de caminho quando o destino exigir, mas preserve diretórios relativos. Não use apenas [Path::GetFileName](https://reference.aspose.com/slides/pt/cpp/system.io/path/getfilename/) a menos que cada nome gerado seja conhecido como único e as referências de recurso permaneçam válidas.
- Aplique validação de nome específica do destino. Ao gravar arquivos soltos, rejeite caminhos raiz e segmentos de travessia, resolva o destino com [Path::GetFullPath](https://reference.aspose.com/slides/pt/cpp/system.io/path/getfullpath/), e verifique se ele permanece dentro do diretório de exportação pretendido, incluindo o separador de diretório na verificação de contenção. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um salvador e um namespace de armazenamento separados para cada job de exportação. Detecte colisões após normalização de separadores e de acordo com as regras de sensibilidade a maiúsculas/minúsculas do destino.
- Antes de publicar, analise cada documento XAML como XML e inspecione suas referências de recurso baseadas em arquivo, como atributos `Source` ou `ImageSource` de imagens. Resolva cada URI relativo em relação ao diretório do artefato XAML que o contém, normalize o nome de armazenamento resultante e confirme que a chave correspondente no dicionário, entrada ZIP ou objeto armazenado existe. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivo relativos.

Por exemplo, se `pres/Slide_1.xaml` referencia `images/image1.png`, o recurso armazenado deve estar disponível como `pres/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve a mesma estrutura sob o prefixo do job e torne essas URLs de recurso acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar nomes de entradas e bytes de recursos, e carregue slides representativos no ambiente XAML alvo para confirmar que as imagens são resolvidas corretamente.

## **Perguntas Frequentes**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**  
Use [set_DefaultRegularFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) em [XamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a original está ausente. Isso não garante que o XAML gerado referencie a fonte de fallback ou que a fonte esteja disponível na máquina de destino. Garanta que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele é exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**  
Aspose.Slides exporta XAML WPF por meio de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Slides ocultos são suportados e como impedir que eles sejam exportados por padrão?**  
Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [set_ExportHiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) em [XamlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export.xaml/xamloptions/) — mantenha‑a desativada se não precisar exportá‑los.