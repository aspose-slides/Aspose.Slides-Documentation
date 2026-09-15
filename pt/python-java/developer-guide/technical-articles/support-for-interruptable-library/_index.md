---
title: Suporte a uma Biblioteca Interrompível
type: docs
weight: 120
url: /pt/python-java/support-for-interruptable-library/
keywords:
- biblioteca interrompível
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
description: "Torne tarefas de longa duração canceláveis com Aspose.Slides for Python via Java. Interrompa a renderização e conversões para PowerPoint e OpenDocument com segurança, com exemplos."
---
## **Visão geral**

Aspose.Slides fornece um mecanismo de processamento interrompível para tarefas de apresentação de longa duração, como desserialização, serialização e renderização. Esse mecanismo baseia‑se nas classes [InterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/).

Um [InterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontoken/) pode ser atribuído a [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/) e passado ao construtor de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). Quando [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/#interrupt) é chamado, a tarefa de longa duração associada é interrompida.

## **Biblioteca interrompível**

Aspose.Slides for Python via Java fornece as classes [InterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/). Elas permitem interromper tarefas de longa duração, como desserialização, serialização e renderização.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/) é a origem do(s) token(s) passado(s) para [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Quando [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setInterruptionToken) é chamado e a instância de [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/) é passada ao construtor de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), invocar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/#interrupt) interrompe qualquer tarefa de longa duração associada a essa [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).

O trecho de código a seguir demonstra como interromper uma tarefa em execução:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Execute a ação em uma thread separada.
    time.sleep(10)  # Tempo limite.
    token_source.interrupt()  # Interrompa a conversão.
    conversion_task.result()
```

## **Perguntas frequentes**

**Qual é o objetivo da biblioteca de interrupção do Aspose.Slides?**

Ela fornece um mecanismo para interromper operações de longa duração — como carregar, salvar ou renderizar apresentações — antes que sejam concluídas. Isso é útil quando o tempo de processamento deve ser limitado ou a tarefa não é mais necessária.

**Qual a diferença entre [InterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontoken/) é passado para a API do Aspose.Slides e verificado durante operações de longa duração.
- [InterruptionTokenSource](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/) é usado no seu código para criar tokens e acionar interrupções chamando [interrupt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Quais tarefas podem ser interrompidas?**

Qualquer tarefa do Aspose.Slides que aceite um [InterruptionToken](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontoken/) — como carregar uma apresentação com [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) ou salvar com [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) — pode ser interrompida.

**A interrupção ocorre imediatamente?**

Não. A interrupção é cooperativa: a operação verifica periodicamente o token e para assim que detecta que [interrupt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/#interrupt) foi chamado.

**O que acontece se eu chamar [interrupt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/#interrupt) depois que a tarefa já foi concluída?**

Nada — a chamada não tem efeito se a tarefa correspondente já terminou.

**Posso reutilizar o mesmo [InterruptionTokenSource](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/) para várias tarefas?**

Sim — mas depois de chamar [interrupt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/interruptiontokensource/#interrupt) nesse source, todas as tarefas que usam seus tokens serão interrompidas. Use fontes de token separadas para gerenciar as tarefas de forma independente.