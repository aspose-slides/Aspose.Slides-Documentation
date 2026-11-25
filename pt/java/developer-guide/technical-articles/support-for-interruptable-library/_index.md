---
title: Interromper Operações de Apresentação de Longa Duração em Java
linktitle: Interromper Operações de Apresentação
type: docs
weight: 120
url: /pt/java/support-for-interruptable-library/
keywords:
- operações interrompíveis
- token de interrupção
- token de cancelamento
- tarefa de longa duração
- tarefa de interrupção
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Saiba como cancelar operações de apresentação de longa duração no Aspose.Slides for Java e retornar um resultado parcial ao exportar slides em um loop."
---
## **Visão geral**

Aspose.Slides for Java pode interromper operações de longa duração, como carregamento, salvamento e renderização de apresentações. Seu aplicativo pode usar o mesmo token de interrupção para parar um loop antes que ele comece a processar o próximo slide.

## **Interromper uma operação de apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), obtenha seu token com [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), e passe o token para [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Passe as opções de carregamento para o [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Para solicitar cancelamento, chame [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) na fonte. Uma operação interrompível para quando observa a solicitação.

O exemplo converte `sample.pptx` para `sample.ppt` em uma thread em segundo plano. A thread chamadora aguarda até 10 segundos para que a conversão termine. Se a conversão ainda estiver em execução, solicita cancelamento e aguarda o encerramento do trabalhador.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Conectar um timeout Java ao Aspose.Slides**

Para definir um limite de tempo em uma operação de apresentação, use um [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) para chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) quando o timeout expirar. O exemplo permite 20 segundos para carregar `sample.pptx` e exportá‑lo para `sample.pdf`. Se a exportação terminar antes, o aplicativo cancela a solicitação agendada.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Parar antes de processar o próximo slide**

Use o mesmo [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) para a apresentação e o loop que exporta seus slides. Verifique [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) antes de cada exportação. Se o chamador puder usar um resultado parcial, retorne os números dos slides das exportações concluídas com sucesso.

Use uma apresentação chamada `sample.pptx` com ao menos dois slides. A sobrecarga [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) que aceita um array de números de slide conta a partir de 1. O exemplo salva cada slide em um PDF separado e solicita cancelamento imediatamente após registrar a primeira exportação bem‑sucedida.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

O exemplo grava `slide-1.pdf` e imprime `Starting slide 1` seguido de `Completed: [1]`. O loop observa a solicitação antes de iniciar o slide 2. Se o cancelamento chegar durante uma gravação, o loop sai antes de registrar aquele slide como concluído.

Se o chamador precisar tratar o cancelamento, substitua a verificação e seu `break` no início do loop por `token.throwIfInterruptionRequested()`. Remova o `try`/`catch` ao redor da gravação para que o cancelamento durante uma exportação também chegue ao chamador. Com a mesma entrada, o exemplo imprime apenas `Starting slide 1` e grava `slide-1.pdf`. No início da segunda iteração, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) lança `com.aspose.slides.exceptions.OperationCanceledException` antes que a próxima exportação comece. O método não devolve lista alguma.

## **FAQ**

**Quando devo solicitar cancelamento?**

Solicite cancelamento quando uma operação exceder seu limite de tempo ou quando seu aplicativo não precisar mais do resultado.

**Qual é a diferença entre [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

A fonte permite que seu aplicativo solicite cancelamento. O token permite que o Aspose.Slides e seu aplicativo verifiquem essa solicitação.

**Posso cancelar uma operação a partir de um timer Java?**

Sim. Agende uma chamada para [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) na fonte associada à apresentação.

**Quais operações posso interromper?**

Você pode interromper carregamento, salvamento e renderização. Passe o token para o [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) através de [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). A apresentação pode então observar o cancelamento durante operações subsequentes, como salvar em PDF.

**Uma operação para imediatamente?**

O cancelamento é cooperativo. Uma operação verifica o token periodicamente e para quando observa a solicitação.

**O que acontece se eu chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) após uma operação terminar?**

A operação concluída mantém seu resultado.

**Várias operações podem compartilhar um [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Sim. Chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) solicita cancelamento para toda operação que use um token dessa fonte. Use uma fonte separada para cada operação que deseje cancelar independentemente.