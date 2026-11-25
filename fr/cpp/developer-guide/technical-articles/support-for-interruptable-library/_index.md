---
title: Interrompre les opérations de présentation de longue durée en C++
linktitle: Interrompre les opérations de présentation
type: docs
weight: 150
url: /fr/cpp/support-for-interruptable-library/
keywords:
- opérations interrompables
- jeton d'interruption
- jeton d'annulation
- tâche de longue durée
- interrompre la tâche
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment annuler les opérations de présentation de longue durée dans Aspose.Slides pour C++ et renvoyer un résultat partiel lors de l'exportation des diapositives dans une boucle."
---
## **Vue d'ensemble**

Aspose.Slides for C++ peut interrompre les opérations longues telles que le chargement, l’enregistrement et le rendu des présentations. Votre application peut utiliser le même jeton d’interruption pour arrêter une boucle avant qu’elle ne commence à traiter la diapositive suivante.

## **Interrompre une opération de présentation**

Créez un [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), récupérez son jeton avec [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), transmettez le jeton à [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), et transmettez les options de chargement au [constructeur Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Pour demander l’annulation, appelez [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) sur la source. Une opération interrompable s’arrête lorsqu’elle constate la demande.

L’exemple commence la conversion de `sample.pptx` en `sample.ppt` dans une tâche en arrière-plan et demande l’annulation si la tâche est toujours en cours après 10 secondes. Si la conversion se termine plus tôt, la sortie est déjà complète.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Connecter l’annulation d’application à Aspose.Slides**

Si votre application utilise un [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), utilisez [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) pour transférer les demandes d’annulation à [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). L’exemple exporte `sample.pptx` vers `sample.pdf` dans une tâche en arrière-plan. Si l’exportation est toujours en cours après 20 secondes, l’application appelle [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), ce qui invoque le rappel enregistré.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Arrêter avant de traiter la diapositive suivante**

Utilisez le même [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) pour la présentation et la boucle qui exporte ses diapositives. Vérifiez [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) avant de démarrer chaque exportation. Si l’appelant peut utiliser un résultat partiel, renvoyez les numéros de diapositives des exportations qui se sont terminées avec succès.

Utilisez une présentation nommée `sample.pptx` contenant au moins deux diapositives. L’exemple demande l’annulation immédiatement après avoir enregistré la première exportation réussie.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

L’exemple écrit `slide-1.pdf` et affiche `Starting slide 1` suivi de `Completed: [1]`. La boucle détecte la demande avant de démarrer la diapositive 2. Si l’annulation interrompt à la place [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) pendant une exportation, le bloc `catch` sort de la boucle avant que le code n’enregistre la diapositive en cours comme terminée.

Si l’appelant doit gérer l’annulation, remplacez la vérification `if` et son `break` au début de la boucle par un appel à [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) sur le jeton. Supprimez le bloc `try`/`catch` autour de l’exportation afin que l’annulation pendant un enregistrement atteigne également l’appelant. Avec la même entrée, l’exemple n’affiche que `Starting slide 1` et écrit `slide-1.pdf`. Au début de la deuxième itération, l’appelant reçoit une [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) avant que l’exportation ne commence. L’appelant ne reçoit aucune liste de diapositives terminées.

## **FAQ**

**Quand devrais-je demander l’annulation ?**

Demandez l’annulation lorsqu’une opération dépasse votre limite de temps ou lorsque votre application n’a plus besoin du résultat.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

La source permet à votre application de demander l’annulation. Le jeton permet à Aspose.Slides et à votre application de vérifier cette demande.

**Puis-je utiliser un [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) avec Aspose.Slides ?**

Oui. Lorsque le jeton de votre application signale une annulation, appelez [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) sur la source associée à la présentation.

**Quelles opérations puis-je interrompre ?**

Vous pouvez interrompre le chargement, l’enregistrement et le rendu. Transmettez le jeton au [constructeur Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) via [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). La présentation pourra alors détecter l’annulation lors des opérations suivantes telles que [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**Une opération s’arrête-t-elle immédiatement ?**

L’annulation est coopérative. Une opération vérifie périodiquement le jeton et s’arrête lorsqu’elle constate la demande.

**Que se passe-t-il si j’appelle [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) après qu’une opération se soit terminée ?**

L’opération terminée conserve son résultat.

**Puis-je partager un [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) entre plusieurs opérations ?**

Oui. Appeler [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) demande l’annulation pour chaque opération qui utilise un jeton de cette source. Utilisez une source distincte pour chaque opération que vous souhaitez annuler indépendamment.