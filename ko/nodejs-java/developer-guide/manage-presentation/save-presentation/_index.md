---
title: JavaScript에서 프레젠테이션 저장
linktitle: 프레젠테이션 저장
type: docs
weight: 80
url: /ko/nodejs-java/save-presentation/
keywords:
- PowerPoint 저장
- OpenDocument 저장
- 프레젠테이션 저장
- 슬라이드 저장
- PPT 저장
- PPTX 저장
- ODP 저장
- 파일로 프레젠테이션
- 스트림으로 프레젠테이션
- 사전 정의된 보기 유형
- Strict Office Open XML 형식
- Zip64 모드
- 섬네일 새로 고침
- 저장 진행률
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 Aspose.Slides를 사용해 PowerPoint 및 OpenDocument 프레젠테이션을 파일이나 스트림으로 저장하고, PPTX 출력 및 진행 상황 보고를 구성합니다."
---
## **개요**

프레젠테이션을 만들거나 [기존 프레젠테이션 열기](/slides/ko/nodejs-java/open-presentation/) 후, 결과를 기록하려면 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 메서드를 사용합니다. Aspose.Slides for Node.js via Java는 프레젠테이션을 PowerPoint, OpenDocument, PDF 및 기타 형식의 파일이나 스트림으로 저장할 수 있습니다. 다음 섹션에서는 표준 저장 작업과 PPTX 출력에 사용할 수 있는 옵션을 다룹니다.

## **파일에 프레젠테이션 저장**

프레젠테이션을 파일에 저장하려면 출력 경로와 [SaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/) 값을 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 메서드에 전달합니다. 포맷 값은 Aspose.Slides가 생성하는 파일 유형을 결정합니다.

다음 예제는 프레젠테이션을 생성하고 PPTX 파일로 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // 여기에 프레젠테이션 내용을 추가하거나 수정하세요.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **원본 형식으로 프레젠테이션 저장**

파일 및 스트림 감지 예제, 새로 만든 프레젠테이션의 동작, 소스와 출력 형식 간의 구분에 대해서는 [Determine the Original Presentation Format](/slides/ko/nodejs-java/detect-presentation-source-format/)를 참조하십시오.

배치 처리 애플리케이션에서는 입력 형식을 미리 알 수 없을 수 있습니다. 파일을 로드한 후 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getSourceFormat) 메서드로 원본 형식을 읽습니다. 결과 [SourceFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sourceformat/) 값을 [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/#toSaveFormat) 에 전달하여 해당 [SaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/) 값을 얻은 다음, [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 로 수정된 프레젠테이션을 기록합니다.

다음 전체 예제는 입력 디렉터리의 모든 파일을 처리하고, 제목을 업데이트한 뒤, 로드된 형식 그대로 출력 디렉터리에 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/#toSaveFormat) 은 PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP 및 PowerPoint XML을 해당 프레젠테이션 저장 형식에 매핑합니다. 이는 프레젠테이션 소스 형식만 매핑하며, PDF, HTML, TIFF 또는 이미지와 같은 내보내기 형식을 선택하기 위한 것이 아닙니다. 지원되지 않거나 잘못된 [SourceFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sourceformat/) 값을 전달하면 오류가 발생합니다.

레거시 PPT, PPS 및 POT 파일은 동일한 바이너리 컨테이너를 사용합니다. 파일 확장자 없이 스트림에서 이러한 프레젠테이션을 로드하면 PPS 또는 POT 파일이 PPT 로 식별될 수 있습니다. 이러한 레거시 하위 유형을 보존해야 하는 경우, 원본 파일 이름이나 형식 메타데이터를 별도로 유지하고 출력 파일 이름 및 형식을 선택할 때 사용하십시오.

## **스트림에 프레젠테이션 저장**

최종 파일 경로에 의존하지 않고 프레젠테이션을 기록하려면 쓰기 가능한 스트림과 [SaveFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveformat/) 값을 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 메서드에 전달합니다. 이 방법은 출력이 웹 서비스에서 반환되거나 데이터베이스에 저장되거나 메모리 내에서 처리되어야 할 때 유용합니다.

다음 예제는 새 프레젠테이션을 파일 스트림에 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **미리 정의된 보기 유형으로 프레젠테이션 저장**

PowerPoint가 저장된 프레젠테이션을 처음 열 때 표시할 보기를 지정할 수 있습니다. 저장하기 전에 [ViewProperties.setLastView](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewproperties/#setLastView) 메서드에 [ViewType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/viewtype/) 값을 사용합니다.

다음 예제는 슬라이드 마스터 보기를 초기 보기로 설정합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML 형식으로 프레젠테이션 저장**

Office Open XML의 Strict 프로파일에 부합하는 PPTX 파일을 만들려면 [PptxOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/) 인스턴스를 생성하고, 해당 인스턴스의 [setConformance](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/#setConformance) 메서드에 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) 을 지정합니다. 그런 다음 옵션을 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 메서드에 전달합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 모드에서 Office Open XML 형식으로 프레젠테이션 저장**

표준 ZIP 아카이브는 각 항목의 압축 및 비압축 크기, 전체 아카이브 크기 및 항목 수를 제한합니다. PPTX 파일은 ZIP 아카이브이므로 매우 큰 프레젠테이션은 이러한 제한을 초과할 수 있습니다. ZIP64 확장은 해당 크기 및 항목 수 제한을 확대합니다.

Aspose.Slides가 ZIP64 확장을 기록할지 여부를 제어하려면 [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) 메서드를 사용합니다:

- [IfNecessary](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#IfNecessary) 은 표준 ZIP 제한을 초과할 때만 ZIP64를 사용합니다. 기본 모드입니다.
- [Never](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#Never) 은 ZIP64 확장을 사용하지 않습니다.
- [Always](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#Always) 은 항상 ZIP64 확장을 기록합니다.

다음 예제는 출력 프레젠테이션에 대해 항상 ZIP64 확장을 활성화합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
만약 [Zip64Mode.Never](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zip64mode/#Never) 를 사용하고 프레젠테이션이 표준 ZIP 제한에 맞지 않을 경우, 저장 작업은 [PptxException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxexception/) 을 발생시킵니다.
{{% /alert %}}

## **압축 레벨로 Office Open XML 형식에 프레젠테이션 저장**

PPTX 출력의 경우, [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) 메서드를 사용하여 저장 속도와 파일 크기 사이의 균형을 맞출 수 있습니다. [CompressionLevel](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/) 클래스는 다음 값을 제공합니다:

- [None](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#None) 은 압축 없이 데이터를 저장합니다.
- [Level1](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#Level1) 은 가장 빠른 압축을 제공하며 압축된 결과가 가장 큽니다.
- [Level2](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#Level2)부터 [Level5](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#Level5)까지는 저장 속도보다 더 작은 출력 크기를 우선합니다.
- [Level6](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#Level6) 은 저장 속도와 파일 크기 사이의 균형을 맞춥니다. 기본 레벨입니다.
- [Level7](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#Level7) 및 [Level8](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#Level8) 은 저장 속도보다 더 작은 출력 크기를 더욱 우선합니다.
- [Level9](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/compressionlevel/#Level9) 은 가장 강력한 압축을 제공하며 가장 많은 처리 시간이 필요합니다.

다음 예제는 압축 없이 프레젠테이션을 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

다음 예제는 최대 압축 레벨을 사용합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **섬네일 새로 고침 없이 프레젠테이션 저장**

프레젠테이션을 PPTX 로 저장할 때, [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 메서드는 문서 섬네일을 제어합니다:

- `true` 은 저장 작업 중에 섬네일을 다시 생성합니다. 기본값입니다.
- `false` 은 기존 섬네일을 유지합니다. 프레젠테이션에 섬네일이 없으면 Aspose.Slides는 생성하지 않습니다.

다음 예제는 섬네일을 새로 고치지 않고 프레젠테이션을 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
섬네일 새로 고침을 비활성화하면 PPTX 파일 저장에 소요되는 시간을 줄일 수 있습니다.
{{% /alert %}}

## **진행률 업데이트를 백분율로 저장**

저장 작업을 모니터링하려면 Java 프록시와 함께 [IProgressCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprogresscallback/) 인터페이스를 구현하고 구현체를 [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) 메서드에 전달합니다. Aspose.Slides는 내보내기 중에 진행 값을 포함하여 [IProgressCallback.reporting](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprogresscallback/#reporting-double-) 메서드를 호출합니다.

다음 예제는 PDF 내보내기의 진행 상황을 콘솔에 출력합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose는 Aspose.Slides API를 사용해 만든 무료 [PowerPoint Splitter](https://products.aspose.app/slides/ko/splitter) 를 제공합니다. 이 도구는 프레젠테이션에서 선택한 슬라이드를 개별 PPT 또는 PPTX 파일로 저장합니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 증분 저장 또는 “빠른 저장”을 지원합니까?**

아니요. 각 저장 작업은 변경된 부분만 업데이트하는 대신 전체 출력 파일을 완전히 기록합니다.

**여러 스레드가 동일한 Presentation 인스턴스를 저장할 수 있나요?**

아니요. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스는 [is not thread-safe](/slides/ko/nodejs-java/multithreading/) 합니다. 각 인스턴스는 한 번에 하나의 스레드만 접근하고 저장해야 합니다.

**프레젠테이션을 저장할 때 하이퍼링크와 외부 링크 파일은 어떻게 되나요?**

[Hyperlinks](/slides/ko/nodejs-java/manage-hyperlinks/) 은 프레젠테이션에 그대로 남습니다. Aspose.Slides는 외부 링크된 파일을 복사하지 않으므로 저장된 프레젠테이션은 여전히 해당 위치에 접근할 수 있어야 합니다.

**작성자, 제목, 회사, 생성 날짜와 같은 문서 메타데이터를 저장할 수 있나요?**

예. 저장하기 전에 적절한 [document properties](/slides/ko/nodejs-java/presentation-properties/) 를 설정하면 Aspose.Slides가 이를 출력 파일에 기록합니다.