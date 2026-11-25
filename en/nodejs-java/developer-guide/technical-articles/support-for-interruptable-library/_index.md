---
title: Interrupt Long-Running Presentation Operations in Node.js
linktitle: Interrupt Presentation Operations
type: docs
weight: 120
url: /nodejs-java/support-for-interruptable-library/
keywords:
- interruptible operations
- interruption token
- cancellation token
- conversion timeout
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Cancel long-running presentation operations in Aspose.Slides for Node.js via Java, set a conversion timeout, and keep track of slides exported before cancellation."
---

## **Overview**

Aspose.Slides for Node.js via Java supports cancellation when loading, saving, or rendering a presentation. You can also check the same token in your own export loop to stop before the next slide and return the numbers of the slides already saved.

## **Interrupt a Presentation Operation**

Create an [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), obtain its token with [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken), and pass it to [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Use these options when constructing the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Calling [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) on the source requests cancellation of the current operation. Aspose.Slides stops when it next checks the token.

### **Set a Conversion Timeout**

The following example allows 20 seconds to open `sample.pptx` and save it as `sample.pdf`. Both the constructor and the save run asynchronously through the Java bridge so the Node.js timer can fire during either operation. The example checks the token after loading and again after saving, since a library call can return after a cancellation request. It releases the presentation when the operation settles and clears the timer if the conversion finishes early. If cancellation occurs during a save, the output file may already exist and may be incomplete.

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

To convert to the older PowerPoint format with a 10-second limit, pass `"sample.ppt"`, `slides.SaveFormat.Ppt`, and `10000` as the last three arguments.

## **Stop Before Processing the Next Slide**

Use [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) before each export when the caller can use a partial result. The [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) overload for selected slides takes a Java `int[]` of slide numbers starting at 1. Record each number only after its PDF has been saved successfully.

Run the example with a presentation named `sample.pptx` containing at least two slides. To demonstrate cancellation between exports, the example requests it immediately after saving the first slide.

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

The example writes `slide-1.pdf` and prints `Starting slide 1` followed by `Completed: [1]`. The loop observes cancellation before starting slide 2. If a save itself is interrupted, the returned list contains only the earlier successful exports.

To let the caller handle cancellation as an error, replace the check and its `break` at the top of the loop with [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), called as `token.throwIfInterruptionRequested()`. Use the same throwing check after the save and remove the `try`/`catch` around it. With the same input, the first PDF is still written, and the second iteration throws before the function can return a list.

## **FAQ**

**When should I request cancellation?**

Request cancellation when a deadline expires or the application no longer needs the result. Loading, saving, and rendering can all use the token passed to the presentation at construction.

**How do the source and the token differ?**

The source lets the application request cancellation. The token lets Aspose.Slides and your own code check for that request.

**Can a Node.js timer interrupt a synchronous save?**

A synchronous save blocks JavaScript on the calling thread. Use the asynchronous Java bridge calls shown in the timeout example so the timer can request cancellation while the save is running.

**Does cancellation take effect immediately?**

Cancellation is cooperative. A running operation stops when it observes the request. An operation that has already finished keeps its result.

**Can multiple operations share a source?**

Yes. Calling `interrupt()` requests cancellation for every operation using a token from that source. Use a separate source for each operation you want to cancel independently.
