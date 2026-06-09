---
title: Suporte para Biblioteca Interrompível
type: docs
weight: 120
url: /pt/java/support-for-interruptable-library/
keywords:
- biblioteca interrompível
- token de interrupção
- token de cancelamento
- tarefa de longa duração
- interromper tarefa
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Torne tarefas de longa duração canceláveis com Aspose.Slides para Java. Interrompa renderizações e conversões de PowerPoint e OpenDocument com segurança, com exemplos."
---
## **Visão geral**

Aspose.Slides fornece um mecanismo de processamento interrompível para tarefas de apresentação de longa duração, como desserialização, serialização e renderização. Esse mecanismo baseia‑se nas classes `InterruptionToken` e `InterruptionTokenSource`.

Um `InterruptionToken` pode ser atribuído ao `LoadOptions` e passado ao construtor `Presentation`. Quando `InterruptionTokenSource.interrupt()` é chamado, a tarefa de longa duração associada é interrompida.

## **Biblioteca interrompível**

Na versão [Aspose.Slides 18.4](https://releases.aspose.com/slides/pt/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), introduzimos as classes [InterruptionToken](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/). Elas permitem interromper tarefas de longa duração, como desserialização, serialização e renderização.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/) é a fonte do(s) token(s) passado(s) para [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Quando [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) está definido e a instância de [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/) é passada ao construtor de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/), a chamada a [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/#interrupt--) interrompe qualquer tarefa de longa duração associada a essa [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).

O trecho de código a seguir demonstra a interrupção de uma tarefa em execução:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // executar a ação em uma thread separada
Thread.sleep(10000);     // tempo limite
tokenSource.interrupt(); // parar a conversão
```

## **Perguntas frequentes**

**Qual é o objetivo da biblioteca de interrupção do Aspose.Slides?**

Ela fornece um mecanismo para interromper operações de longa duração — como carregar, salvar ou renderizar apresentações — antes que sejam concluídas. Isso é útil quando o tempo de processamento deve ser limitado ou a tarefa não é mais necessária.

**Qual a diferença entre [InterruptionToken](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` é passado para a API do Aspose.Slides e verificado durante operações demoradas.
- `InterruptionTokenSource` é usado no seu código para criar tokens e disparar interrupções chamando `Interrupt()`.

**Quais tarefas podem ser interrompidas?**

Qualquer tarefa do Aspose.Slides que aceite um [InterruptionToken](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontoken/) — como carregar uma apresentação com `Presentation(path, loadOptions)` ou salvar com `Presentation.save(...)` — pode ser interrompida.

**A interrupção ocorre imediatamente?**

Não. A interrupção é cooperativa: a operação verifica periodicamente o token e para assim que detecta que [Interrupt()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/#interrupt--) foi chamado.

**O que acontece se eu chamar [Interrupt()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/#interrupt--) depois que a tarefa já foi concluída?**

Nada — a chamada não tem efeito se a tarefa correspondente já foi concluída.

**Posso reutilizar o mesmo [InterruptionTokenSource](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/) para várias tarefas?**

Sim — mas depois de chamar [Interrupt()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/interruptiontokensource/#interrupt--) nesse source, todas as tarefas que utilizam seus tokens serão interrompidas. Use fontes de token separadas para gerenciar tarefas independentemente.