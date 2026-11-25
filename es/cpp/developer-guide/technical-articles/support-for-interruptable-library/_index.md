---
title: Interrumpir operaciones de presentación de larga duración en C++
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 150
url: /es/cpp/support-for-interruptable-library/
keywords:
- operaciones interrumpibles
- token de interrupción
- token de cancelación
- tarea de larga duración
- interrumpir tarea
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo cancelar operaciones de presentación de larga duración en Aspose.Slides para C++ y devolver un resultado parcial al exportar diapositivas en un bucle."
---
## **Visión general**

Aspose.Slides for C++ puede interrumpir operaciones de larga duración, como la carga, el guardado y la representación de presentaciones. Su aplicación puede usar el mismo token de interrupción para detener un bucle antes de que empiece a procesar la diapositiva siguiente.

## **Interrumpir una operación de presentación**

Cree un [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), recupere su token con [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/), pase el token a [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/), y pase las opciones de carga al [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/). Para solicitar la cancelación, llame a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) en la fuente. Una operación interrumpible se detiene cuando observa la solicitud.

El ejemplo comienza a convertir `sample.pptx` a `sample.ppt` en una tarea en segundo plano y solicita la cancelación si la tarea sigue ejecutándose después de 10 segundos. Si la conversión termina antes, la salida ya está completa.

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

## **Conectar la cancelación de la aplicación a Aspose.Slides**

Si su aplicación usa un [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/), use [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) para reenviar solicitudes de cancelación a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/). El ejemplo exporta `sample.pptx` a `sample.pdf` en una tarea en segundo plano. Si la exportación sigue ejecutándose después de 20 segundos, la aplicación llama a [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/), lo que invoca la devolución de llamada registrada.

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

## **Detener antes de procesar la siguiente diapositiva**

Use el mismo [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) tanto para la presentación como para el bucle que exporta sus diapositivas. Compruebe [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) antes de iniciar cada exportación. Si el llamador puede usar un resultado parcial, devuelva los números de diapositiva de las exportaciones que se completaron correctamente.

Utilice una presentación llamada `sample.pptx` con al menos dos diapositivas. El ejemplo solicita la cancelación inmediatamente después de registrar la primera exportación exitosa.

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

El ejemplo escribe `slide-1.pdf` e imprime `Starting slide 1` seguido de `Completed: [1]`. El bucle ve la solicitud antes de iniciar la diapositiva 2. Si la cancelación interrumpe en su lugar a [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) durante una exportación, el bloque `catch` sale del bucle antes de que el código registre la diapositiva actual como completada.

Si el llamador necesita manejar la cancelación, reemplace la comprobación `if` y su `break` al comienzo del bucle por una llamada a [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) en el token. Elimine el `try`/`catch` alrededor de la exportación para que la cancelación durante un guardado también llegue al llamador. Con la misma entrada, el ejemplo solo imprime `Starting slide 1` y escribe `slide-1.pdf`. Al iniciar la segunda iteración, el llamador recibe una [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) antes de que comience la exportación. El llamador no recibe ninguna lista de diapositivas completadas.

## **Preguntas frecuentes**

**¿Cuándo debo solicitar la cancelación?**

Solicite la cancelación cuando una operación supera su límite de tiempo o cuando su aplicación ya no necesita el resultado.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

La fuente permite a su aplicación solicitar la cancelación. El token permite a Aspose.Slides y a su aplicación comprobar esa solicitud.

**¿Puedo usar un [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) con Aspose.Slides?**

Sí. Cuando el token de su aplicación indica cancelación, llame a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) en la fuente asociada a la presentación.

**¿Qué operaciones puedo interrumpir?**

Puede interrumpir la carga, el guardado y la representación. Pase el token al [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) mediante [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/). La presentación podrá entonces observar la cancelación durante operaciones posteriores como [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

**¿Se detiene una operación inmediatamente?**

La cancelación es cooperativa. Una operación verifica el token periódicamente y se detiene cuando observa la solicitud.

**¿Qué ocurre si llamo a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) después de que una operación termina?**

La operación completada conserva su resultado.

**¿Pueden varias operaciones compartir un [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/)?**

Sí. Llamar a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) solicita la cancelación para cada operación que utilice un token de esa fuente. Use una fuente separada para cada operación que desee cancelar de forma independiente.