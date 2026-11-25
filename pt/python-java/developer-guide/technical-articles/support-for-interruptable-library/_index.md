---
title: Interromper Operações de Apresentação de Longa Duração em Python
linktitle: Interromper Operações de Apresentação
type: docs
weight: 120
url: /pt/python-java/support-for-interruptable-library/
keywords:
- operações interrompíveis
- token de interrupção
- token de cancelamento
- tarefa de longa duração
- interromper tarefa
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Saiba como cancelar operações de apresentação de longa duração no Aspose.Slides para Python via Java e retornar um resultado parcial ao exportar slides em um loop."
---
## **Visão geral**

Aspose.Slides for Python via Java pode interromper operações de longa duração, como carregamento, salvamento e renderização de apresentações. Seu aplicativo pode usar o mesmo token de interrupção para parar um loop antes de iniciar o processamento do próximo slide.

## **Interromper uma operação de apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), obtenha seu token com [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) e passe o token para [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Passe as opções de carregamento para o [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Para solicitar cancelamento, chame [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) na fonte. Uma operação interrompível para quando observa a solicitação. Use `jpype.JClass` para capturar a exceção Java `com.aspose.slides.exceptions.OperationCanceledException` em Python.

O exemplo converte `sample.pptx` para `sample.ppt` em uma thread em segundo plano. A thread chamadora aguarda até 10 segundos para que a conversão termine. Se a conversão ainda estiver em execução, solicita cancelamento e aguarda o término do worker.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Conectar um tempo limite do Python ao Aspose.Slides**

Para definir um limite de tempo em uma operação de apresentação, use um [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) para chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) quando o tempo limite expirar. O exemplo permite 20 segundos para carregar `sample.pptx` e exportá-lo para `sample.pdf`. Se a exportação terminar antes, o aplicativo cancela a solicitação agendada.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Parar antes de processar o próximo slide**

Use o mesmo [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) para a apresentação e o loop que exporta seus slides. Verifique [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) antes de cada exportação. Se o chamador puder usar um resultado parcial, retorne os números dos slides das exportações que foram concluídas com sucesso.

Use uma apresentação chamada `sample.pptx` com pelo menos dois slides. A sobrecarga [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) que recebe um `int[]` Java usa números de slide iniciando em 1. Use `jpype.JArray(jpype.JInt)` para construir esse array em Python. O exemplo salva cada slide em um PDF separado e solicita cancelamento imediatamente após registrar a primeira exportação bem‑sucedida.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

O exemplo grava `slide-1.pdf` e imprime `Starting slide 1` seguido de `Completed: [1]`. O loop observa a solicitação antes de iniciar o slide 2. Se o cancelamento chegar durante uma gravação, o loop sai antes de registrar esse slide como concluído.

Se o chamador precisar lidar com cancelamento, substitua a verificação e seu `break` no início do loop por `token.throwIfInterruptionRequested()`. Remova o `try`/`except` ao redor da gravação para que o cancelamento durante uma exportação também chegue ao chamador. Com a mesma entrada, o exemplo imprime apenas `Starting slide 1` e grava `slide-1.pdf`. No início da segunda iteração, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) gera `com.aspose.slides.exceptions.OperationCanceledException` antes que a próxima exportação comece. A exceção propaga para o chamador antes que a função possa retornar a lista.

## **FAQ**

**Quando devo solicitar cancelamento?**

Solicite cancelamento quando uma operação exceder seu limite de tempo ou quando seu aplicativo não precisar mais do resultado.

**Qual é a diferença entre [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

A fonte permite que seu aplicativo solicite cancelamento. O token permite que o Aspose.Slides e seu aplicativo verifiquem essa solicitação.

**Posso cancelar uma operação a partir de um timer Python?**

Sim. Agende uma chamada para [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) na fonte associada à apresentação.

**Quais operações posso interromper?**

Você pode interromper carregamento, salvamento e renderização. Passe o token ao [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) através de [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). A apresentação pode então observar o cancelamento durante operações subsequentes, como salvar em PDF.

**A operação para imediatamente?**

O cancelamento é cooperativo. Uma operação verifica o token periodicamente e para quando observa a solicitação.

**O que acontece se eu chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) após uma operação terminar?**

A operação concluída mantém seu resultado.

**Várias operações podem compartilhar um [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Sim. Chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) solicita cancelamento para todas as operações que utilizam um token dessa fonte. Use uma fonte separada para cada operação que você deseja cancelar independentemente.