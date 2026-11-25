---
title: Interromper Operações de Apresentação de Longa Duração no Android
linktitle: Interromper Operações de Apresentação
type: docs
weight: 120
url: /pt/androidjava/support-for-interruptable-library/
keywords:
- operações interrompíveis
- token de interrupção
- token de cancelamento
- tarefa de longa duração
- interromper tarefa
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como cancelar operações de apresentação de longa duração no Aspose.Slides para Android via Java e retornar um resultado parcial ao exportar slides em um loop."
---
## **Visão geral**

Aspose.Slides for Android via Java pode interromper operações de longa duração, como carregamento, gravação e renderização de apresentações. Seu aplicativo pode usar o mesmo token de interrupção para parar um laço antes que ele comece a processar o próximo slide.

## **Interromper uma operação de apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), obtenha seu token com [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), e passe o token para [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Passe as opções de carregamento para o [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Para solicitar o cancelamento, chame [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) na fonte. Uma operação interrompível para quando observa a solicitação.

O exemplo converte `sample.pptx` para `sample.ppt` em uma thread em segundo plano. A thread chamadora aguarda até 10 segundos pela conclusão da conversão. Se a conversão ainda estiver em execução, solicita cancelamento e aguarda a finalização do trabalhador.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
        // Chame a partir de uma thread em segundo plano e passe context.getFilesDir(), que contém sample.pptx.
        public static void run(File directory) throws InterruptedException {
            File input = new File(directory, "sample.pptx");
            File output = new File(directory, "sample.ppt");
            InterruptionTokenSource source = new InterruptionTokenSource();
            Thread worker = new Thread(() -> {
                LoadOptions options = new LoadOptions();
                options.setInterruptionToken(source.getToken());
                try {
                    Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                    try {
                        presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
        }
}
```

## **Conectar um tempo limite Java ao Aspose.Slides**

Para definir um limite de tempo em uma operação de apresentação, use um [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) para chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) quando o tempo limite expirar. O exemplo permite 20 segundos para carregar `sample.pptx` e exportá‑lo para `sample.pdf`. Se a exportação terminar antes, o aplicativo cancela a solicitação agendada.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Chame a partir de uma thread em segundo plano e passe context.getFilesDir(), que contém sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **Parar antes de processar o próximo slide**

Use o mesmo [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) para a apresentação e para o laço que exporta seus slides. Verifique [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) antes de cada exportação. Se o chamador puder usar um resultado parcial, retorne os números dos slides cujas exportações foram concluídas com sucesso.

Use uma apresentação chamada `sample.pptx` com pelo menos dois slides. A sobrecarga [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) que aceita um array de números de slide conta a partir de 1. O exemplo salva cada slide em um PDF separado e solicita cancelamento imediatamente após registrar a primeira exportação bem‑sucedida.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // Chame a partir de uma thread em segundo plano e passe context.getFilesDir(), que contém sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

O exemplo grava `slide-1.pdf` e imprime `Starting slide 1` seguido de `Completed: [1]`. O laço observa a solicitação antes de iniciar o slide 2. Se o cancelamento chegar durante uma gravação, o laço sai antes de marcar esse slide como concluído.

Se o chamador precisar tratar o cancelamento, substitua a verificação e seu `break` no início do laço por `token.throwIfInterruptionRequested()`. Remova o `try`/`catch` ao redor da gravação para que o cancelamento durante uma exportação também chegue ao chamador. Com a mesma entrada, o exemplo imprime apenas `Starting slide 1` e grava `slide-1.pdf`. No início da segunda iteração, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) lança `com.aspose.slides.exceptions.OperationCanceledException` antes que a próxima exportação comece. O método não devolve lista.

## **Perguntas Frequentes**

**Quando devo solicitar cancelamento?**

Solicite cancelamento quando uma operação exceder seu limite de tempo ou quando seu aplicativo não precisar mais do resultado.

**Qual a diferença entre [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

A fonte permite que seu aplicativo solicite cancelamento. O token permite que Aspose.Slides e seu aplicativo verifiquem essa solicitação.

**Posso cancelar uma operação a partir de um timer Java?**

Sim. Agende uma chamada para [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) na fonte associada à apresentação.

**Quais operações posso interromper?**

Você pode interromper carregamento, gravação e renderização. Passe o token para o [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) através de [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). A apresentação poderá então observar o cancelamento durante operações subsequentes, como gravação em PDF.

**A operação para imediatamente?**

O cancelamento é cooperativo. Uma operação verifica o token periodicamente e para quando observa a solicitação.

**O que acontece se eu chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) após uma operação terminar?**

A operação concluída mantém seu resultado.

**Várias operações podem compartilhar um [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Sim. Chamar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) solicita cancelamento para toda operação que use um token dessa fonte. Use uma fonte separada para cada operação que deseje cancelar de forma independente.