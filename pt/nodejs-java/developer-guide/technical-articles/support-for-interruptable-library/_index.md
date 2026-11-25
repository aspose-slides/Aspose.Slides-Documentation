---
title: Interromper Operações de Apresentação de Longa Duração no Node.js
linktitle: Interromper Operações de Apresentação
type: docs
weight: 120
url: /pt/nodejs-java/support-for-interruptable-library/
keywords:
- operações interrompíveis
- token de interrupção
- token de cancelamento
- tempo limite de conversão
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Cancele operações de apresentação de longa duração no Aspose.Slides para Node.js via Java, defina um tempo limite de conversão e acompanhe os slides exportados antes do cancelamento."
---
## **Visão geral**

Aspose.Slides for Node.js via Java oferece suporte ao cancelamento ao carregar, salvar ou renderizar uma apresentação. Você também pode verificar o mesmo token em seu próprio loop de exportação para interromper antes do próximo slide e retornar os números dos slides já salvos.

## **Interromper uma operação de apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), obtenha seu token com [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) e passe‑o para [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Use essas opções ao construir o [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Chamar [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) na origem solicita o cancelamento da operação atual. Aspose.Slides interrompe quando verifica o token novamente.

### **Definir um tempo limite de conversão**

O exemplo a seguir permite 20 segundos para abrir `sample.pptx` e salvá‑lo como `sample.pdf`. Tanto o construtor quanto a gravação são executados de forma assíncrona através da ponte Java, de modo que o temporizador do Node.js pode disparar durante qualquer operação. O exemplo verifica o token após o carregamento e novamente após a gravação, pois uma chamada da biblioteca pode retornar após uma solicitação de cancelamento. Ele libera a apresentação quando a operação termina e limpa o temporizador se a conversão terminar antecipadamente. Se o cancelamento ocorrer durante a gravação, o arquivo de saída pode já existir e pode estar incompleto.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

Para converter para o formato PowerPoint mais antigo com um limite de 10 segundos, passe `"sample.ppt"`, `slides.SaveFormat.Ppt` e `10000` como os três últimos argumentos.

## **Parar antes de processar o próximo slide**

Use [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) antes de cada exportação quando o chamador pode usar um resultado parcial. A sobrecarga [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) para slides selecionados aceita um `int[]` Java com números de slide começando em 1. Registre cada número somente após seu PDF ter sido salvo com sucesso.

Execute o exemplo com uma apresentação chamada `sample.pptx` contendo ao menos dois slides. Para demonstrar o cancelamento entre exportações, o exemplo solicita isso imediatamente após salvar o primeiro slide.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

O exemplo grava `slide-1.pdf` e imprime `Starting slide 1` seguido de `Completed: [1]`. O loop observa o cancelamento antes de iniciar o slide 2. Se uma gravação for interrompida, a lista retornada contém apenas as exportações bem‑sucedidas anteriores.

Para permitir que o chamador trate o cancelamento como um erro, substitua a verificação e seu `break` no início do loop por [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), chamado como `token.throwIfInterruptionRequested()`. Use a mesma verificação de lançamento após a gravação e remova o `try`/`catch` ao redor dela. Com a mesma entrada, o primeiro PDF ainda é gravado, e a segunda iteração lança uma exceção antes que a função possa retornar uma lista.

## **Perguntas Frequentes**

**Quando devo solicitar o cancelamento?**

Solicite o cancelamento quando um prazo expira ou a aplicação não precisa mais do resultado. Carregar, salvar e renderizar podem todos usar o token passado para a apresentação na construção.

**Como a origem e o token diferem?**

A origem permite que a aplicação solicite o cancelamento. O token permite que o Aspose.Slides e seu próprio código verifiquem essa solicitação.

**Um temporizador do Node.js pode interromper uma gravação síncrona?**

Uma gravação síncrona bloqueia o JavaScript na thread que fez a chamada. Use as chamadas assíncronas da ponte Java mostradas no exemplo de tempo limite para que o temporizador possa solicitar o cancelamento enquanto a gravação está em execução.

**O cancelamento tem efeito imediato?**

O cancelamento é cooperativo. Uma operação em andamento para quando observa a solicitação. Uma operação que já terminou mantém seu resultado.

**Várias operações podem compartilhar uma origem?**

Sim. Chamar `interrupt()` solicita o cancelamento para toda operação que usa um token dessa origem. Use uma origem separada para cada operação que você deseja cancelar independentemente.