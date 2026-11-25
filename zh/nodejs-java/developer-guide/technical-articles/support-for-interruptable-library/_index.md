---
title: 在 Node.js 中中断长时间运行的演示文稿操作
linktitle: 中断演示文稿操作
type: docs
weight: 120
url: /zh/nodejs-java/support-for-interruptable-library/
keywords:
- 可中断操作
- 中断令牌
- 取消令牌
- 转换超时
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中取消长时间运行的演示文稿操作，设置转换超时，并跟踪取消前已导出的幻灯片。"
---
## **概述**

Aspose.Slides for Node.js via Java 支持在加载、保存或呈现演示文稿时取消操作。您还可以在自己的导出循环中检查同一令牌，以在下一张幻灯片之前停止并返回已保存幻灯片的编号。

## **中断演示文稿操作**

创建一个[InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/)，使用[getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken)获取它的令牌，并将其传递给[LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken)。在构造[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)时使用这些选项。对源调用[interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt)会请求取消当前操作。Aspose.Slides 在下次检查令牌时停止。

### **设置转换超时**

以下示例允许 20 秒打开 `sample.pptx` 并将其保存为 `sample.pdf`。构造函数和保存操作均通过 Java 桥以异步方式运行，以便 Node.js 定时器可以在任一操作期间触发。示例在加载后以及保存后检查令牌，因为库调用可能在取消请求后才返回。操作完成后它会释放演示文稿，并在转换提前完成时清除定时器。如果在保存期间发生取消，输出文件可能已经存在且可能不完整。

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

要在 10 秒限制内转换为旧的 PowerPoint 格式，请将 `"sample.ppt"`、`slides.SaveFormat.Ppt` 和 `10000` 作为最后三个参数传入。

## **在处理下一张幻灯片前停止**

在每次导出之前使用[isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested)，当调用方可以使用部分结果时。针对选定幻灯片的[save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save)重载接受一个从 1 开始的 Java `int[]` 幻灯片编号。仅在其 PDF 成功保存后才记录每个编号。

使用名为 `sample.pptx`、至少包含两张幻灯片的演示文稿运行示例。为了演示导出之间的取消，示例在保存第一张幻灯片后立即请求取消。

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

示例写入 `slide-1.pdf` 并打印 `Starting slide 1`，随后是 `Completed: [1]`。循环在启动第 2 张幻灯片前观察到取消。如果保存本身被中断，返回的列表仅包含之前成功的导出。

若要让调用方将取消视为错误处理，请将循环顶部的检查及其 `break` 替换为[throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested)，调用方式为 `token.throwIfInterruptionRequested()`。在保存后使用相同的抛出检查并移除其周围的 `try`/`catch`。使用相同的输入时，仍会写入第一个 PDF，第二次迭代会在函数返回列表前抛出。

## **常见问题**

**何时应请求取消？**  
当截止时间到期或应用程序不再需要结果时请求取消。加载、保存和渲染均可使用在构造演示文稿时传入的令牌。

**源和令牌有何区别？**  
源允许应用程序请求取消。令牌则让 Aspose.Slides 及您的代码检查该请求。

**Node.js 定时器能中断同步保存吗？**  
同步保存会阻塞调用线程上的 JavaScript。请使用超时示例中展示的异步 Java 桥调用，以便在保存运行时定时器能够请求取消。

**取消会立即生效吗？**  
取消是协作式的。运行中的操作在检测到请求时停止。已完成的操作会保留其结果。

**多个操作可以共享同一源吗？**  
可以。调用 `interrupt()` 会请求取消所有使用该源的令牌的操作。对于希望独立取消的每个操作，请使用单独的源。