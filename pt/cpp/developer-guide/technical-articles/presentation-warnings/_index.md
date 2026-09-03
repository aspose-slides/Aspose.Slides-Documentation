---
title: Lidar com Avisos de Apresentação em C++
type: docs
weight: 70
url: /pt/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de aviso
- política de aviso
- perda de dados
- corrupção da origem
- problema de compatibilidade
- substituição de fonte
- assinatura digital
- carregamento de apresentação
- renderização de apresentação
- conversão de apresentação
- salvamento de apresentação
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aprenda a coletar, classificar e agir sobre avisos ao carregar, renderizar, converter e salvar apresentações com Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides pode relatar problemas recuperáveis enquanto carrega, renderiza, converte ou salva uma apresentação. Exemplos incluem registros de origem danificados, conteúdo que não pode ser preservado, substituição de fontes e limitações de um formato de destino. Um callback de aviso permite que uma aplicação registre essas condições e decida se a operação atual pode continuar.

Implemente a interface [IWarningCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/iwarningcallback/) e examine os métodos [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) e [IWarningInfo::get_Description](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/iwarninginfo/get_description/) fornecidos por meio de [IWarningInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/iwarninginfo/). Retorne [ReturnAction::Continue](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/returnaction/) para aceitar o aviso ou `ReturnAction::Abort` para interromper a operação.

Use [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_warningcallback/) para avisos gerados ao abrir uma apresentação. As classes de opções de renderização e exportação herdam [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/set_warningcallback/), que recebe avisos da renderização de slides, conversão e gravação. Como o aviso em si não identifica a operação da aplicação, associe cada instância de callback a uma etapa da operação ao construir um relatório combinado.

## **Avisos e Exceções**

Um aviso descreve uma condição da qual o Aspose.Slides pode se recuperar se o callback retornar `ReturnAction::Continue`. Uma exceção significa que a operação solicitada não pode ser concluída normalmente; exceções não são convertidas em avisos e não podem ser tratadas por uma política de avisos.

Retornar `ReturnAction::Abort` solicita ao despachante de avisos que termine a operação atual lançando uma exceção. A exceção pública depende da operação e do formato da apresentação. Por exemplo, o carregamento pode gerar uma [PptxReadException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxreadexception/) ou [PptReadException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptreadexception/), enquanto salvar ou exportar pode gerar uma [PptxException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxexception/). Trate a exceção na fronteira da operação e use o relatório de avisos para determinar se a política da aplicação causou a interrupção, em vez de depender de um subtipo ou mensagem de exceção. O callback registra o aviso antes de retornar `ReturnAction::Abort`, garantindo que o motivo permaneça disponível para a aplicação.

## **Categorias de Aviso**

A enumeração [WarningType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/warningtype/) fornece as seguintes categorias:

| Tipo de aviso | Significado | Política típica |
| --- | --- | --- |
| `SourceFileCorruption` | A apresentação de origem contém corrupção que pode tornar um documento salvo em seu formato original inutilizável. | Abort​ar. |
| `DataLoss` | Texto, gráficos, imagens ou outros dados podem estar ausentes após o carregamento ou gravação. | Abort​ar. |
| `MajorFormattingLoss` | A apresentação pode perder formatação importante. | Abort​ar em modo de validação estrita; caso contrário, registrar e continuar. |
| `MinorFormattingLoss` | Pode ocorrer uma diferença de formatação limitada. | Registrar para diagnóstico e continuar. |
| `CompatibilityIssue` | O resultado pode não abrir ou se comportar corretamente em algumas aplicações ou versões mais antigas. | Registrar e continuar a menos que a compatibilidade seja obrigatória. |
| `UnexpectedContent` | A origem contém conteúdo não suportado ou não reconhecido cujo efeito ainda pode ser desconhecido. | Registrar e continuar, ou tratar como erro em uma política estrita. |

A categoria deve orientar a decisão de política. Armazene a descrição do aviso para diagnóstico, mas não dependa da sua redação para a lógica da aplicação, pois o texto da mensagem pode variar entre cenários de aviso e versões do produto.

## **Coletar e Classificar Avisos**

O exemplo a seguir usa um relatório a nível de aplicação para todo o pipeline de processamento. Uma instância de callback separada rotula avisos de carregamento, renderização, conversão para PDF e gravação de PPTX. A política aborta em caso de corrupção da origem ou perda de dados, opcionalmente aborta em perda de formatação importante e continua para outros avisos.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Defina `abortOnMajorFormattingLoss` como `false` quando diferenças de formatação importantes forem aceitáveis. Problemas de compatibilidade, perda de formatação menor e conteúdo inesperado ainda são mantidos no relatório mesmo quando a operação continua. Estenda `WarningPolicy::GetAction` se a aplicação precisar rejeitar qualquer uma dessas categorias.

## **Cenários Comuns de Aviso**

Avisos podem aparecer em diferentes etapas de um fluxo de trabalho:

- **Assinaturas digitais:** Uma apresentação assinada pode gerar um aviso durante o carregamento de que sua assinatura será perdida durante o processamento. Aspose.Slides relata essa condição `DataLoss` por meio de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Um callback na fase de carregamento permite que a aplicação rejeite o arquivo ou aceite explicitamente a perda relatada.
- **Substituição de fontes:** Uma fonte indisponível pode ser substituída enquanto um slide é renderizado ou exportado. Avisos de substituição de fontes são relatados como `DataLoss`, portanto a política estrita acima aborta mesmo que a aplicação considerasse uma substituição específica visualmente aceitável. Para observar esse comportamento, use uma apresentação de entrada contendo texto em uma fonte indisponível para o runtime. A descrição do aviso identifica a substituição; configure as fontes necessárias ou as [regras de substituição de fontes](/slides/pt/cpp/font-substitution/) antes de tentar novamente.
- **Conteúdo não suportado ou inesperado:** Um carregador pode encontrar registros ou recursos da apresentação que não reconhece. Esses avisos podem usar `UnexpectedContent`, ou uma categoria mais severa quando se sabe que dados ou formatação são afetados.
- **Compatibilidade de formato:** Salvar em outro formato de apresentação pode omitir recursos ou produzir um resultado que se comporta de forma diferente em algumas aplicações. Por exemplo, salvar uma apresentação com mais de oito guias de desenho horizontais ou verticais em um PPT legado gera um `CompatibilityIssue`. O callback na fase de gravação pode registrar a perda e continuar, ou rejeitá-la se for necessário preservar todos os guias.
- **Comportamento de carregamento:** Opções de carregamento e comportamentos legados também podem gerar avisos. Por exemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifica o uso de um comportamento de bloqueio de apresentação obsoleto como um `CompatibilityIssue`.

Avisos dependem do documento de origem, do formato de destino, da operação e da versão do Aspose.Slides. Não presuma que todo arquivo gera um aviso ou que um cenário sempre se mapeia para apenas uma categoria.

## **Manipular Operações Abortadas com Segurança**

Quando um callback retorna `ReturnAction::Abort`, não use um objeto que falhou ao ser carregado e não presuma que uma saída de renderização ou gravação esteja completa. A operação pode ser terminada após a criação de um arquivo de saída, mas antes de finalizá‑lo.

Salve os resultados validados em um caminho separado, como `validated-output.pptx`. Substitua uma apresentação existente somente após a operação terminar com sucesso, o relatório de avisos atender à política da aplicação e a saída puder ser aberta e verificada. Isso evita sobrescrever um arquivo de origem válido com um resultado parcial ou rejeitado.

Um relatório de avisos vazio não garante que todos os recursos da origem foram preservados. Aplique quaisquer verificações de conteúdo e visuais adicionais exigidas pela aplicação. Veja também [Open Presentations](/slides/pt/cpp/open-presentation/) e [Save Presentations](/slides/pt/cpp/save-presentation/).

## **FAQ**

**Um callback de aviso pode lidar com todos os erros do Aspose.Slides?**

Não. Ele trata condições recuperáveis relatadas como avisos. Exceções que ocorrem independentemente do callback devem ser tratadas pela aplicação ao redor da chamada de carregamento, renderização, conversão ou gravação.

**Retornar `ReturnAction::Continue` garante saída idêntica?**

Não. Ele apenas permite que o processamento continue. A condição relatada ainda pode causar diferenças de dados, formatação ou compatibilidade, portanto revise os tipos e descrições de avisos coletados.

**Como a aplicação pode identificar a operação que gerou um aviso?**

Crie uma instância de callback para cada operação e armazene uma etapa definida pela aplicação junto com o tipo e a descrição do aviso, conforme mostrado no exemplo.