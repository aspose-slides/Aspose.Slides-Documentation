---
title: Interromper Operações de Apresentação de Longa Duração em PHP
linktitle: Interromper Operações de Apresentação
type: docs
weight: 120
url: /pt/php-java/support-for-interruptable-library/
keywords:
- token de interrupção
- cancelamento
- tempo limite de conversão
- exportação de slide
- PowerPoint
- PHP
- Aspose.Slides
description: "Aprenda como cancelar a conversão de uma apresentação em um temporizador e retornar os slides exportados antes do cancelamento com Aspose.Slides for PHP via Java."
---
## **Visão geral**

Aspose.Slides for PHP via Java pode interromper operações de longa duração, como carregamento, gravação e renderização de apresentações. Em um loop que exporta um slide por vez, o mesmo token permite que sua aplicação pare antes do próximo slide e retorne uma lista de exportações concluídas.

Ambos os exemplos PHP assumem que seu bootstrap chama `define("JAVA_PREFER_VALUES", 1);` antes de carregar o `Java.inc` da ponte, e então carrega `aspose.slides.php`. Essa configuração permite que o PHP capture exceções Java durante a chamada. Os exemplos inspecionam a causa da exceção encapsulada para que outros erros de conversão cheguem ao chamador.

## **Interromper uma Operação de Apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), obtenha seu token com [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) e passe‑o para [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Forneça essas opções ao construir o [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Chamar [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) solicita cancelamento. Uma operação em execução para quando observa a solicitação.

### **Definir um Tempo Limite de Conversão**

Enquanto o PHP aguarda um carregamento ou gravação síncrono através da PHP/Java Bridge, um temporizador Java pode solicitar cancelamento em uma thread separada. Salve o seguinte auxílio como `ConversionTimeout.java`, compile‑o com o JAR do Aspose.Slides no classpath e torne a classe compilada disponível para a ponte sob seu nome de pacote, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Com a ponte e o wrapper PHP do Aspose.Slides carregados, execute o exemplo a seguir com `sample.pptx` no diretório de trabalho do processo Java, ou use caminhos absolutos acessíveis a esse processo. O limite de 20 segundos cobre tanto o carregamento quanto a exportação para PDF. Se a conversão terminar antes, o PHP cancela o temporizador. Para converter para o formato PowerPoint antigo com um limite de 10 segundos, use `sample.ppt`, `SaveFormat::Ppt` e `10000` milissegundos.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Parar Antes de Processar o Próximo Slide**

Verifique [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) antes de cada exportação. A sobrecarga [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) para slides selecionados aceita números de slides a partir de 1. Passe um array de um elemento para gravar um PDF separado para cada slide.

Use um `sample.pptx` com pelo menos dois slides. Para demonstrar cancelamento entre exportações, o exemplo solicita isso imediatamente após registrar o primeiro slide.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

O exemplo grava `slide-1.pdf` e imprime `Completed: [1]`. A segunda iteração vê a solicitação antes de iniciar outra exportação. Se o cancelamento ocorrer durante uma gravação, a lista conterá apenas as exportações confirmadas anteriormente. Uma gravação interrompida pode deixar um arquivo incompleto no disco.

Para propagar o cancelamento ao chamador, substitua a verificação no início do loop por `$token->throwIfInterruptionRequested();` e remova o `try`/`catch` interno, mantendo a gravação e a verificação que a segue. Com a mesma entrada, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) lança uma exceção antes do slide 2 e o chamador não recebe nenhuma lista.

## **Perguntas frequentes**

**Quando devo solicitar cancelamento?**

Solicite cancelamento quando um prazo expira ou o chamador não precisa mais do resultado. Uma solicitação feita após a conclusão de uma operação deixa seu resultado intacto.

**Como a fonte e o token diferem?**

A fonte permite que uma aplicação solicite cancelamento. O token permite que o Aspose.Slides e o código da aplicação observem essa solicitação.

**Várias operações podem compartilhar uma fonte?**

Sim. Uma solicitação se aplica a todas as operações que utilizam tokens dessa fonte. Crie fontes separadas para operações que precisam de cancelamento independente.