---
title: Node.js에서 장기 실행 프레젠테이션 작업 중단
linktitle: 프레젠테이션 작업 중단
type: docs
weight: 120
url: /ko/nodejs-java/support-for-interruptable-library/
keywords:
- 중단 가능한 작업
- 인터럽션 토큰
- 취소 토큰
- 변환 제한 시간
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 장기 실행 프레젠테이션 작업을 취소하고, 변환 제한 시간을 설정하며, 취소 전 내보낸 슬라이드를 추적합니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 프레젠테이션을 로드, 저장 또는 렌더링할 때 취소를 지원합니다. 또한 자체 내보내기 루프에서 동일한 토큰을 확인하여 다음 슬라이드 전에 중지하고 이미 저장된 슬라이드 번호를 반환할 수 있습니다.

## **프레젠테이션 작업 중단**

InterruptionTokenSource를 생성하고([InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/)), [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken)으로 토큰을 얻은 후 이를 [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken)에 전달합니다. 이러한 옵션은 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성할 때 사용합니다. 소스에서 [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt)를 호출하면 현재 작업의 취소를 요청합니다. Aspose.Slides는 토큰을 다음에 확인할 때 중지합니다.

### **변환 제한 시간 설정**

다음 예제는 `sample.pptx`를 열고 `sample.pdf`로 저장하는 데 20초를 허용합니다. 생성자와 저장 모두 Java 브리지를 통해 비동기적으로 실행되므로 Node.js 타이머가 어느 작업 중에도 작동할 수 있습니다. 예제는 로드 후와 저장 후에 토큰을 확인하는데, 이는 라이브러리 호출이 취소 요청 후에도 반환될 수 있기 때문입니다. 작업이 끝나면 프레젠테이션을 해제하고 변환이 일찍 완료되면 타이머를 정리합니다. 저장 중에 취소가 발생하면 출력 파일이 이미 존재할 수 있으며 불완전할 수 있습니다.

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

10초 제한으로 이전 PowerPoint 형식으로 변환하려면 마지막 세 인수로 `"sample.ppt"`, `slides.SaveFormat.Ppt`, `10000`을 전달합니다.

## **다음 슬라이드 처리 전에 중지**

[isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested)를 각 내보내기 전에 호출하여 호출자가 부분 결과를 사용할 수 있는 경우에만 사용합니다. 선택된 슬라이드에 대한 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) 오버로드는 1부터 시작하는 슬라이드 번호의 Java `int[]`를 받습니다. 각 번호는 해당 PDF가 성공적으로 저장된 후에만 기록합니다.

`sample.pptx`라는 이름의 프레젠테이션을 최소 두 개의 슬라이드가 포함되도록 실행하십시오. 내보내기 사이에 취소를 데모하려면 첫 번째 슬라이드를 저장한 직후에 요청합니다.

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

예제는 `slide-1.pdf`를 작성하고 `Starting slide 1`을 출력한 뒤 `Completed: [1]`을 출력합니다. 루프는 슬라이드 2를 시작하기 전에 취소를 감지합니다. 저장 자체가 중단되면 반환된 목록에는 이전에 성공적으로 내보낸 결과만 포함됩니다.

취소를 오류로 처리하도록 호출자에게 허용하려면 루프 상단의 확인 및 `break`를 [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) 호출(`token.throwIfInterruptionRequested()`)로 교체하십시오. 저장 후에도 동일한 throw 검사를 사용하고 그 주위의 `try`/`catch`를 제거합니다. 동일한 입력으로 첫 번째 PDF는 여전히 작성되고, 두 번째 반복은 함수가 목록을 반환하기 전에 throw 됩니다.

## **자주 묻는 질문**

**취소를 언제 요청해야 합니까?**  
마감 시간이 지나거나 애플리케이션이 더 이상 결과가 필요하지 않을 때 취소를 요청합니다. 로드, 저장 및 렌더링 모두 생성 시 프레젠테이션에 전달된 토큰을 사용할 수 있습니다.

**소스와 토큰은 어떻게 다릅니까?**  
소스는 애플리케이션이 취소를 요청할 수 있게 해 주고, 토큰은 Aspose.Slides와 사용자의 코드가 해당 요청을 확인할 수 있게 해 줍니다.

**Node.js 타이머가 동기 저장을 중단시킬 수 있습니까?**  
동기 저장은 호출 스레드에서 JavaScript를 차단합니다. 타이머가 저장 중에 취소를 요청하려면 제한 시간 예제와 같이 비동기 Java 브리지 호출을 사용해야 합니다.

**취소가 즉시 적용됩니까?**  
취소는 협조적입니다. 실행 중인 작업은 요청을 감지했을 때 중단됩니다. 이미 완료된 작업은 그 결과를 유지합니다.

**여러 작업이 하나의 소스를 공유할 수 있습니까?**  
예. `interrupt()`를 호출하면 해당 소스에서 만든 토큰을 사용하는 모든 작업에 취소가 요청됩니다. 독립적으로 취소하려는 각 작업마다 별도의 소스를 사용하십시오.