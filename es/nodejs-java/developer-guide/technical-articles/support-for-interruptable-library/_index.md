---
title: Interrumpir operaciones de presentación de larga duración en Node.js
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 120
url: /es/nodejs-java/support-for-interruptable-library/
keywords:
- operaciones interrumpibles
- token de interrupción
- token de cancelación
- tiempo de espera de conversión
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Cancelar operaciones de presentación de larga duración en Aspose.Slides para Node.js mediante Java, establecer un tiempo de espera de conversión y realizar un seguimiento de las diapositivas exportadas antes de la cancelación."
---
## **Descripción general**

Aspose.Slides for Node.js mediante Java admite la cancelación al cargar, guardar o renderizar una presentación. También puedes comprobar el mismo token en tu propio bucle de exportación para detenerte antes de la siguiente diapositiva y devolver los números de las diapositivas ya guardadas.

## **Interrumpir una operación de presentación**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), obtén su token con [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken), y pásalo a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Usa estas opciones al construir la [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Llamar a [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) en la fuente solicita la cancelación de la operación actual. Aspose.Slides se detiene cuando vuelve a comprobar el token.

### **Establecer un tiempo de espera de conversión**

El siguiente ejemplo permite 20 segundos para abrir `sample.pptx` y guardarlo como `sample.pdf`. Tanto el constructor como el guardado se ejecutan de forma asíncrona a través del puente Java, de modo que el temporizador de Node.js puede activarse durante cualquiera de las operaciones. El ejemplo comprueba el token después de cargar y nuevamente después de guardar, ya que una llamada a la biblioteca puede devolver el control tras una solicitud de cancelación. Libera la presentación cuando la operación se estabiliza y borra el temporizador si la conversión finaliza antes de tiempo. Si se produce una cancelación durante el guardado, el archivo de salida puede ya existir y estar incompleto.

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

Para convertir al formato PowerPoint más antiguo con un límite de 10 segundos, pasa `"sample.ppt"`, `slides.SaveFormat.Ppt` y `10000` como los tres últimos argumentos.

## **Detenerse antes de procesar la siguiente diapositiva**

Utiliza [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) antes de cada exportación cuando el llamador pueda usar un resultado parcial. La sobrecarga [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) para diapositivas seleccionadas recibe un `int[]` de Java con los números de diapositiva a partir de 1. Registra cada número solo después de que su PDF se haya guardado correctamente.

Ejecuta el ejemplo con una presentación llamada `sample.pptx` que contenga al menos dos diapositivas. Para demostrar la cancelación entre exportaciones, el ejemplo la solicita inmediatamente después de guardar la primera diapositiva.

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

El ejemplo escribe `slide-1.pdf` y muestra `Starting slide 1` seguido de `Completed: [1]`. El bucle detecta la cancelación antes de iniciar la diapositiva 2. Si el guardado mismo se interrumpe, la lista devuelta contiene solo las exportaciones exitosas anteriores.

Para que el llamador maneje la cancelación como un error, reemplaza la comprobación y su `break` al inicio del bucle por [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), llamado como `token.throwIfInterruptionRequested()`. Usa la misma comprobación que lanza la excepción después del guardado y elimina el `try`/`catch` que lo rodea. Con la misma entrada, el primer PDF sigue escribiéndose y la segunda iteración lanza una excepción antes de que la función pueda devolver una lista.

## **Preguntas frecuentes**

**¿Cuándo debería solicitar la cancelación?**

Solicita la cancelación cuando expira una fecha límite o la aplicación ya no necesita el resultado. Cargar, guardar y renderizar pueden usar el token pasado a la presentación en el momento de su creación.

**¿En qué se diferencian la fuente y el token?**

La fuente permite a la aplicación solicitar la cancelación. El token permite a Aspose.Slides y a tu propio código comprobar esa solicitud.

**¿Puede un temporizador de Node.js interrumpir una guardado sincrónico?**

Un guardado sincrónico bloquea JavaScript en el hilo que lo llama. Usa las llamadas asíncronas al puente Java mostradas en el ejemplo de tiempo de espera para que el temporizador pueda solicitar la cancelación mientras el guardado está en curso.

**¿La cancelación surte efecto inmediatamente?**

La cancelación es cooperativa. Una operación en curso se detiene cuando detecta la solicitud. Una operación que ya haya finalizado mantiene su resultado.

**¿Pueden varias operaciones compartir una fuente?**

Sí. Llamar a `interrupt()` solicita la cancelación de todas las operaciones que utilicen un token de esa fuente. Utiliza una fuente distinta para cada operación que desees cancelar de forma independiente.