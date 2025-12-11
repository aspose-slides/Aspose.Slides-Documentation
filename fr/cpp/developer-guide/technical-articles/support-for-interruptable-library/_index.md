---
title: Support pour la bibliothèque interruptable
type: docs
weight: 150
url: /fr/cpp/support-for-interruptable-library/
keywords:
- bibliothèque interruptable
- jeton d'interruption
- jeton d'annulation
- tâche de longue durée
- interrompre la tâche
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Rendez les tâches de longue durée annulables avec Aspose.Slides pour C++. Interrompez le rendu et les conversions pour PowerPoint et OpenDocument en toute sécurité, avec des exemples."
---

## **Bibliothèque interruptable**

Dans [Aspose.Slides 18.4](https://releases.aspose.com/slides/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), nous avons introduit les classes [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/). Elles vous permettent d’interrompre les tâches de longue durée telles que la désérialisation, la sérialisation et le rendu.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) est la source des jetons transmis à [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Lorsque [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) est défini et que l’instance de [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) est passée au constructeur de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), appeler [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) interrompt toute tâche de longue durée associée à cette [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).

Le fragment de code suivant montre comment interrompre une tâche en cours :
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
    
    Run(action, tokenSource->get_Token()); // exécuter l'action dans un thread séparé
    Threading::Thread::Sleep(10000);       // délai d'attente
    tokenSource->Interrupt();              // arrêter la conversion
}
```


## **FAQ**

**Quel est le but de la bibliothèque d’interruption Aspose.Slides ?**

Elle fournit un mécanisme permettant d’interrompre les opérations de longue durée—telles que le chargement, l’enregistrement ou le rendu de présentations—avant qu’elles ne soient terminées. Cela est utile lorsque le temps de traitement doit être limité ou que la tâche n’est plus nécessaire.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) ?**

- `InterruptionToken` est transmis à l’API Aspose.Slides et vérifié pendant les opérations de longue durée.
- `InterruptionTokenSource` est utilisé dans votre code pour créer des jetons et déclencher des interruptions en appelant `Interrupt()`.

**Quelles tâches peuvent être interrompues ?**

Toute tâche Aspose.Slides qui accepte un [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/)—comme le chargement d’une présentation avec `Presentation(path, loadOptions)` ou l’enregistrement avec `Presentation::Save(...)`—peut être interrompue.

**L’interruption se produit‑elle immédiatement ?**

Non. L’interruption est collaborative : l’opération vérifie périodiquement le jeton et s’arrête dès qu’elle détecte que [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) a été appelé.

**Que se passe‑t‑il si j’appelle [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) après qu’une tâche soit déjà terminée ?**

Rien — l’appel n’a aucun effet si la tâche correspondante est déjà terminée.

**Puis‑je réutiliser le même [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) pour plusieurs tâches ?**

Oui — mais après avoir appelé [Interrupt()](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) sur cette source, toutes les tâches utilisant ses jetons seront interrompues. Utilisez des sources de jetons distinctes pour gérer les tâches de manière indépendante.