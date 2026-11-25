---
title: Unterbrechen langlaufender Präsentationsvorgänge in C++
linktitle: Präsentationsvorgänge unterbrechen
type: docs
weight: 150
url: /de/cpp/support-for-interruptable-library/
keywords:
- unterbrechbare Vorgänge
- Unterbrechungs-Token
- Abbruch-Token
- lang andauernde Aufgabe
- Aufgabe unterbrechen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie langlaufende Präsentationsvorgänge in Aspose.Slides für C++ abbrechen und beim Exportieren von Folien in einer Schleife ein Teilergebnis zurückgeben."
---
## **Übersicht**

Aspose.Slides for C++ kann langlaufende Vorgänge wie das Laden, Speichern und Rendern von Präsentationen unterbrechen. Ihre Anwendung kann dasselbe Unterbrechungs‑Token verwenden, um eine Schleife zu stoppen, bevor sie mit der Verarbeitung der nächsten Folie beginnt.

## **Unterbrechen einer Präsentationsoperation**

Erstellen Sie eine [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), rufen Sie ihr Token mit [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) ab, übergeben Sie das Token an [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), und übergeben Sie die Ladeoptionen an den [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Um eine Abbruchanforderung zu stellen, rufen Sie [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) auf der Quelle auf. Ein unterbrechbarer Vorgang stoppt, wenn er die Anforderung erkennt.

Das Beispiel startet die Konvertierung von `sample.pptx` nach `sample.ppt` in einer Hintergrundaufgabe und fordert eine Abbruchanforderung an, wenn die Aufgabe nach 10 Sekunden noch läuft. Wird die Konvertierung früher fertig, ist die Ausgabe bereits komplett.

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

## **Anwendungsabbruch mit Aspose.Slides verbinden**

Wenn Ihre Anwendung ein [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) verwendet, nutzen Sie [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/), um Abbruchanforderungen an [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) weiterzuleiten. Das Beispiel exportiert `sample.pptx` nach `sample.pdf` in einer Hintergrundaufgabe. Läuft der Export nach 20 Sekunden noch, ruft die Anwendung [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), was den registrierten Callback auslöst.

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

## **Stoppen, bevor die nächste Folie verarbeitet wird**

Verwenden Sie dasselbe [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) sowohl für die Präsentation als auch für die Schleife, die ihre Folien exportiert. Prüfen Sie [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) bevor Sie jeden Export starten. Wenn der Aufrufer ein Teilergebnis nutzen kann, geben Sie die Foliennummern der erfolgreich abgeschlossenen Exporte zurück.

Verwenden Sie eine Präsentation mit dem Namen `sample.pptx`, die mindestens zwei Folien enthält. Das Beispiel fordert die Abbruchanforderung sofort an, nachdem der erste erfolgreiche Export protokolliert wurde.

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

Das Beispiel schreibt `slide-1.pdf` und gibt `Starting slide 1` gefolgt von `Completed: [1]` aus. Die Schleife sieht die Anforderung, bevor sie Folie 2 startet. Unterbricht die Abbruchanforderung stattdessen [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) während eines Exports, beendet der `catch`‑Block die Schleife, bevor der Code die aktuelle Folie als abgeschlossen verzeichnet.

Wenn der Aufrufer Abbrüche selbst behandeln muss, ersetzen Sie die `if`‑Prüfung und ihr `break` am Anfang der Schleife durch einen Aufruf von [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) auf dem Token. Entfernen Sie das `try`/`catch`‑Konstrukt um den Export, damit ein Abbruch während eines Speichervorgangs ebenfalls den Aufrufer erreicht. Mit denselben Eingaben gibt das Beispiel nur `Starting slide 1` aus und schreibt `slide-1.pdf`. Zu Beginn der zweiten Iteration erhält der Aufrufer eine [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) bevor der Export beginnt. Der Aufrufer erhält keine Liste abgeschlossener Folien.

## **FAQ**

**Wann sollte ich eine Abbruchanforderung stellen?**

Stellen Sie eine Abbruchanforderung, wenn ein Vorgang Ihr Zeitlimit überschreitet oder wenn Ihre Anwendung das Ergebnis nicht mehr benötigt.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Die Quelle ermöglicht Ihrer Anwendung, eine Abbruchanforderung zu stellen. Das Token ermöglicht Aspose.Slides und Ihrer Anwendung, diese Anforderung zu prüfen.

**Kann ich ein [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) mit Aspose.Slides verwenden?**

Ja. Wenn das Token Ihrer Anwendung eine Abbruchsignalisierung sendet, rufen Sie [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) auf der mit der Präsentation verknüpften Quelle auf.

**Welche Vorgänge kann ich unterbrechen?**

Sie können das Laden, Speichern und Rendern unterbrechen. Übergeben Sie das Token dem [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) über [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). Die Präsentation kann dann während nachfolgender Vorgänge, wie zum Beispiel [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), eine Abbruchanforderung erkennen.

**Stoppt ein Vorgang sofort?**

Abbruch ist kooperativ. Ein Vorgang prüft das Token periodisch und stoppt, sobald er die Anforderung erkennt.

**Was passiert, wenn ich [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) nach dem Abschluss eines Vorgangs aufrufe?**

Der abgeschlossene Vorgang behält sein Ergebnis bei.

**Können mehrere Vorgänge dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) teilen?**

Ja. Ein Aufruf von [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) fordert den Abbruch für jeden Vorgang an, der ein Token aus dieser Quelle verwendet. Verwenden Sie für jeden Vorgang, den Sie unabhängig abbrechen möchten, eine separate Quelle.