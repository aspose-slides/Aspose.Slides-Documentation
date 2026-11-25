---
title: Interromper Operações de Apresentação de Longa Duração em Python
linktitle: Interromper Operações de Apresentação
type: docs
weight: 150
url: /pt/python-net/support-for-interruptable-library/
keywords:
- operações interrompíveis
- token de interrupção
- cancelar exportação de PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Aprenda como cancelar a conversão de uma apresentação em Python e devolver a lista de slides que terminaram de exportar antes do cancelamento."
---
## **Visão geral**

O Aspose.Slides for Python via .NET oferece cancelamento cooperativo durante operações de longa duração, como carregar, salvar e renderizar apresentações. Ao exportar slides individualmente, você também pode verificar o cancelamento entre os slides e retornar os números dos slides que foram exportados.

## **Cancelar a conversão de apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), atribua seu [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) ao [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/) e passe as opções ao [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). O token se aplica à apresentação durante todo o seu ciclo de vida. Para solicitar o cancelamento a partir de sua aplicação, chame [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

O exemplo converte `sample.pptx` para `sample.pdf`. Um [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) chama `source.interrupt` após 20 segundos. Iniciar o timer antes de abrir o arquivo faz com que o tempo limite se aplique tanto ao carregamento quanto à gravação. Uma aplicação com um botão Cancelar pode chamar o mesmo método a partir de seu manipulador de eventos.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

A verificação explícita após o carregamento pula a exportação se o tempo limite já tiver decorrido. Se o carregamento ou a gravação observar a solicitação, a exceção de cancelamento chega ao chamador. Uma gravação também pode terminar antes de observar a solicitação, caso em que o PDF está completo.

## **Parar antes de processar o próximo slide**

Verifique [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) antes de cada exportação. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) aceita uma lista de números de slide começando em 1. Adicione um número à lista de concluídos somente após seu PDF ter sido salvo com sucesso.

Use um arquivo chamado `sample.pptx` com pelo menos dois slides. Para tornar o resultado reproduzível, o exemplo solicita o cancelamento assim que o slide 1 termina. Em uma aplicação, a solicitação pode vir de outra thread enquanto um slide está sendo salvo.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

O exemplo grava `slide-1.pdf` e imprime `Starting slide 1` seguido de `Completed: [1]`. A iteração seguinte vê a solicitação antes de iniciar o slide 2. Se o cancelamento interromper uma gravação, o manipulador de exceção retorna os números registrados nas iterações anteriores. Outros erros de exportação chegam ao chamador.

Se o chamador deve tratar o cancelamento como uma exceção, substitua a verificação e seu `break` no início do loop por [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Também remova o `try`/`except` ao redor da gravação. Com a mesma entrada, o slide 1 é salvo e a segunda iteração gera uma exceção de cancelamento antes de iniciar o slide 2.

## **FAQ**

**Quando a solicitação de cancelamento tem efeito?**

Uma operação interrompível verifica seu token periodicamente. Ela para quando observa a solicitação. Uma operação que já terminou mantém seu resultado.

**Qual é a diferença entre a fonte e o token?**

A fonte permite que sua aplicação solicite o cancelamento. O token permite que tanto a apresentação quanto seu próprio código verifiquem essa solicitação.

**Várias operações podem compartilhar uma fonte?**

Sim. Chamar `interrupt` solicita o cancelamento para todas as operações que utilizam um token dessa fonte. Forneça a cada operação sua própria fonte se precisar cancelá‑la de forma independente.