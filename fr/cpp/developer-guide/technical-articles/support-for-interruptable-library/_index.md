---
title: Prise en charge de la bibliothèque interrompable
type: docs
weight: 150
url: /cpp/support-for-interruptable-library/
---

## **Bibliothèque interrompable**
Les classes [InterruptionToken](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token) et [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) ont été ajoutées à Aspose.Slides pour C++. Ces types prennent en charge l'interruption de tâches de longue durée, telles que la désérialisation, la sérialisation ou le rendu. La classe [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source) représente la source du jeton ou des jetons multiples passés à la méthode [LoadOptions.set_InterruptionToken()](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options#a9caea79d46cd939505687fdf634530a5). Lorsque le jeton d'interruption est défini et que l'instance de [LoadOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.load_options) est passée au constructeur [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), toute tâche de longue durée liée à cette présentation sera interrompue lorsque la méthode [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cpp/class/aspose.slides.interruption_token_source#a98ba5fd8badce28a63b5d30a2cfa1e83) sera invoquée.

L'extrait de code ci-dessous démontre comment interrompre une tâche en cours.

``` cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto thread_function = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(thread_function);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        SharedPtr<LoadOptions> options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(dataDir + u"pres.pptx", options);
        presentation->Save(dataDir + u"pres.ppt", Export::SaveFormat::Ppt);
    });
    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);

    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    // exécuter l'action dans un fil séparé
    Run(action, tokenSource->get_Token());
    // délai d'expiration
    Threading::Thread::Sleep(5000);
    // arrêter la conversion
    tokenSource->Interrupt();
}
```