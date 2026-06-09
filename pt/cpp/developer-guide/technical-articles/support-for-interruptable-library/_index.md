---
title: Suporte para Biblioteca Interrompível
type: docs
weight: 150
url: /pt/cpp/support-for-interruptable-library/
keywords:
- biblioteca interrompível
- token de interrupção
- token de cancelamento
- tarefa de longa duração
- interromper tarefa
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Torne tarefas de longa duração canceláveis com Aspose.Slides para C++. Interrompa a renderização e conversões de PowerPoint e OpenDocument com segurança, com exemplos."
---
## **Visão geral**

Aspose.Slides fornece um mecanismo de processamento interrompível para tarefas de apresentação de longa duração, como desserialização, serialização e renderização. Esse mecanismo baseia‑se nas classes `InterruptionToken` e `InterruptionTokenSource`.

`InterruptionToken` pode ser atribuído a `LoadOptions` e passado ao construtor `Presentation`. Quando `InterruptionTokenSource::Interrupt()` é chamado, a tarefa de longa duração associada é interrompida.

## **Biblioteca Interrompível**

No [Aspose.Slides 18.4](https://releases.aspose.com/slides/pt/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), introduzimos as classes [InterruptionToken](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/). Elas permitem interromper tarefas de longa duração, como desserialização, serialização e renderização.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/) é a fonte do(s) token(s) passado(s) para [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Quando [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_interruptiontoken/) está definido e a instância [LoadOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/) é passada ao construtor [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/), invocar [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/interrupt/) interrompe qualquer tarefa de longa duração associada a essa [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).

```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // executa a ação em uma thread separada
    Threading::Thread::Sleep(10000);       // tempo limite
    tokenSource->Interrupt();              // interrompe a conversão
}
```

## **Perguntas Frequentes**

**Qual é o objetivo da biblioteca de interrupção do Aspose.Slides?**

Ela fornece um mecanismo para interromper operações de longa duração — como carregar, salvar ou renderizar apresentações — antes que sejam concluídas. Isso é útil quando o tempo de processamento deve ser limitado ou a tarefa não é mais necessária.

**Qual é a diferença entre [InterruptionToken](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` é passado para a API Aspose.Slides e verificado durante operações de longa duração.
- `InterruptionTokenSource` é usado no seu código para criar tokens e disparar interrupções chamando `Interrupt()`.

**Quais tarefas podem ser interrompidas?**

Qualquer tarefa do Aspose.Slides que aceita um [InterruptionToken](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontoken/) — como carregar uma apresentação com `Presentation(path, loadOptions)` ou salvar com `Presentation::Save(...)` — pode ser interrompida.

**A interrupção ocorre imediatamente?**

Não. A interrupção é cooperativa: a operação verifica periodicamente o token e para assim que detecta que [Interrupt()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/interrupt/) foi chamado.

**O que acontece se eu chamar [Interrupt()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/interrupt/) depois que uma tarefa já foi concluída?**

Nada — a chamada não tem efeito se a tarefa correspondente já foi concluída.

**Posso reutilizar o mesmo [InterruptionTokenSource](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/) para várias tarefas?**

Sim — mas depois de chamar [Interrupt()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/interruptiontokensource/interrupt/) nessa fonte, todas as tarefas que utilizam seus tokens serão interrompidas. Use fontes de token separadas para gerenciar as tarefas de forma independente.