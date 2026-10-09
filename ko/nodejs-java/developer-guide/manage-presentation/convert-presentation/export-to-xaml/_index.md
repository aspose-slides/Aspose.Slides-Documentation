---
title: JavaScript에서 프레젠테이션을 XAML으로 내보내기
linktitle: 프레젠테이션을 XAML으로
type: docs
weight: 30
url: /ko/nodejs-java/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML으로
- OpenDocument를 XAML으로
- 프레젠테이션을 XAML으로
- PPT를 XAML으로
- PPTX를 XAML으로
- ODP를 XAML으로
- PPT를 XAML으로 저장
- PPTX를 XAML으로 저장
- ODP를 XAML으로 저장
- PPT를 XAML으로 내보내기
- PPTX를 XAML으로 내보내기
- ODP를 XAML으로 내보내기
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 PowerPoint 및 OpenDocument 슬라이드를 XAML으로 변환합니다—빠르고 Office가 필요 없는 솔루션으로 레이아웃을 그대로 유지합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개를 포함하고, 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)를 통해 내보내기를 사용자 지정하는 방법을 시연합니다(숨겨진 슬라이드 내보내기 포함). 또한 대체 글꼴, XAML 스택 호환성 및 숨겨진 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에 답합니다.

## **XAML 소개**

XAML은 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 설명하는 데 사용되는 XML 기반 마크업 언어입니다.

시각 디자이너에서 XAML 파일을 작업하거나 마크업을 직접 작성·편집할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 JavaScript 예제는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

기본적으로 내보낸 슬라이드는 프로세스 현재 작업 디렉터리의 `input` 서브폴더에 저장됩니다. 폴더는 자동으로 생성되며 필요한 이미지도 그곳에 저장됩니다.

출력 폴더 이름은 확장자를 제외한 원본 파일 이름에서 가져옵니다. Aspose.Slides for Node.js via Java 26.8에서 `input.pptx`를 내보내면 `input/input/Slide_1.xaml`과 같은 중첩 경로가 생성됩니다. 출력물을 처리할 때 전체 생성된 경로를 보존하십시오. 기본 출력은 현재 작업 디렉터리를 기준으로 하며, 반드시 입력 파일과 같은 위치에 있을 필요는 없습니다.

## **맞춤 옵션으로 프레젠테이션을 XAML로 내보내기**

[IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) 인터페이스를 사용하여 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어합니다.

출력을 사용자 지정 위치에 저장하려면 [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/)를 구현하고 해당 구현 인스턴스를 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)의 [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) 메서드에 전달합니다.

숨겨진 슬라이드를 XAML 출력에 포함하려면, 아래 JavaScript 예제와 같이 `true`와 함께 [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)를 호출합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **생성된 모든 XAML 아티팩트 캡처**

XAML 내보내기는 내보낸 각 슬라이드에 대한 XAML 문서와 별도의 이미지 및 지원 리소스를 생성할 수 있습니다. 기본 파일 시스템 저장자를 대신하여 이러한 아티팩트를 받으려면 사용자 지정 [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/)를 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver)에 할당합니다. XAML 옵션을 허용하는 XAML 전용 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) 오버로드를 사용하여 내보내기를 시작합니다.

Node.js에서는 Aspose.Slides에서 사용하는 `java` 패키지의 `java.newProxy`를 사용하여 Java 인터페이스를 구현합니다. 내보내기가 완료될 때까지 프록시가 접근 가능하도록 유지하십시오.

### **콜백 수명 주기 이해**

내보내기 도구는 생성된 각 아티팩트에 대해 [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)를 개별적으로 호출합니다:

- `path`는 아티팩트를 식별하며 상대 디렉터리를 포함할 수 있습니다. XAML이 리소스를 상대 경로로 참조할 수 있으므로 이 정보를 유지하십시오.
- `data`는 아티팩트의 바이트 데이터를 포함합니다. 이미지 및 기타 이진 리소스는 텍스트로 디코딩해서는 안 됩니다.
- saver는 반환하기 전에 데이터를 보존하거나 지속시키는 책임이 있습니다. 예제에서는 각 Java 바이트 배열을 애플리케이션이 소유한 Node.js 버퍼로 복사합니다.
- 내보내기가 성공한 것으로 간주하려면 프레젠테이션 저장 작업이 반환되고 모든 콜백이 성공적으로 완료될 때만 처리합니다. 저장 오류를 무시하거나 관찰되지 않은 백그라운드 쓰기를 시작하지 마십시오. 지속성이 나중에 이루어지는 경우, 해당 단계가 성공한 후에 전체 성공을 보고하십시오.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)도 사용자 지정 saver에 적용됩니다. 기본값 `false`는 숨겨진 슬라이드 XAML 문서를 제외합니다. `true`를 전달하면 해당 슬라이드와 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 개수는 프레젠테이션에 따라 다르므로 슬라이드당 하나의 콜백이나 고정된 콜백 순서를 가정하지 마십시오.

### **메모리로 내보내고 아티팩트 검사**

이 완전한 예제는 `input.pptx`를 로드하고 이름을 키로, 버퍼를 값으로 하는 JavaScript 맵에 모든 아티팩트를 수집한 뒤 이름, 유형 및 바이트 수를 출력합니다. 제공된 이름은 정확히 보존됩니다. 중복된 이름은 아티팩트를 조용히 덮어쓰는 대신 컬렉션을 잘못된 것으로 표시합니다. 예제는 결과를 사용하기 전에 이를 확인합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // XAML만 디코딩하고, 텍스트 검사가 필요할 때만.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

확장자 검사는 검사에 유용합니다; 익숙하지 않은 리소스 유형을 포함한 모든 아티팩트를 보존하십시오. 저장하거나 전송할 때 바이트를 변경하지 마십시오. 텍스트 처리가 필요한 XAML에만 UTF-8 디코딩을 사용하십시오.

### **수집된 아티팩트를 ZIP 아카이브에 패키징**

이 독립적인 예제는 내보내기를 수집하고 이름을 검증한 뒤 Java 브리지를 사용하여 원본 바이트를 ZIP 아카이브에 씁니다. ZIP은 디스크에 저장되기 전에 메모리에서 조립됩니다. 고유한 아카이브 이름은 동시 내보내기 작업을 구분합니다. ZIP 항목은 슬래시('/')를 사용하고 상대 디렉터리를 유지합니다. 정규화 후 충돌하거나 안전하지 않은 이름은 기록되기 전에 전체 패키지를 거부합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // 닫기를 호출하면 아카이브가 저장되기 전에 ZIP 디렉터리가 최종화됩니다.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

예제는 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html)을 사용해 로컬 아카이브 하나를 작성합니다; 내보내기 도구 자체는 개별 XAML이나 이미지 파일을 쓰지 않습니다. 원격 저장소의 경우, 아카이브 작성 단계를 수집된 바이트 배열 업로드로 교체하십시오. export-job 식별자와 전체 상대 아티팩트 이름을 블랍 키로 사용하거나, 작업 식별자, 상대 이름 및 이진 데이터를 데이터베이스 행에 저장하십시오. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에 작업을 게시하십시오. 지속에 실패하면 부분 출력을 정리하십시오.

큰 프레젠테이션의 경우, 사용자 지정 saver를 사용해 각 아티팩트를 애플리케이션 저장소에 직접 지속시켜 전체 내보내기의 추가 복사본을 메모리에 보관하지 않을 수 있습니다. 내보내기 도구 입장에서 각 콜백을 동기식으로 유지하십시오: 대상이 바이트를 수락한 후에만 반환하고, 실패가 호출자에게 전달되도록 하십시오.

### **리소스 이름 보존 및 참조 검증**

- 대상이 요구하는 경우 경로 구분자를 정규화하되, 상대 디렉터리를 보존하십시오. 모든 생성된 이름이 고유하고 리소스 참조가 유효하다는 보장이 없는 한 베이스명만 사용하지 마십시오.
- 대상별 이름 검증을 적용하십시오. 개별 파일을 쓸 때는 루트 경로나 경로 탐색 세그먼트를 거부하고, 대상을 절대 경로로 해석한 뒤 의도된 내보내기 디렉터리 아래에 머무르는지 확인하십시오(포함 여부 확인 시 디렉터리 구분자 포함). 쓰기를 리디렉션할 수 있는 심볼릭 링크가 없는 애플리케이션 제어 디렉터리를 사용하십시오.
- 각 내보내기 작업마다 별도의 saver와 저장소 네임스페이스를 사용하십시오. 구분자 정규화 후와 대상의 대소문자 구분 규칙에 따라 충돌을 감지하십시오.
- 게시하기 전에 각 XAML 문서를 XML로 파싱하고 이미지 `Source` 또는 `ImageSource` 속성과 같은 파일 기반 리소스 참조를 검사하십시오. 각 상대 URI를 해당 XAML 아티팩트의 디렉터리를 기준으로 해석하고, 결과 저장 이름을 정규화한 뒤, 해당 맵 키, ZIP 항목 또는 저장된 객체가 존재하는지 확인하십시오. 외부 URI와 XAML 마크업 표현식은 상대 파일 이름과 별도로 처리하십시오.

예를 들어, `input/Slide_1.xaml`이 `images/image1.png`를 참조한다면, 저장된 리소스는 `input/images/image1.png`로 존재해야 합니다. `image1.png`만 유지하면 해당 관계가 깨집니다. 객체 저장소의 경우 작업 접두사 아래에 동일한 레이아웃을 유지하고, 해당 리소스 URL을 XAML 사용자가 접근 가능하도록 하십시오. 완성된 ZIP을 다시 열어 항목 이름과 리소스 바이트를 확인하고, 대상 XAML 환경에서 대표 슬라이드를 로드해 이미지가 올바르게 해석되는지 확인하십시오.

## **FAQ**

**원본 폰트가 머신에 없을 경우 어떻게 예측 가능한 폰트를 보장할 수 있나요?**

[XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)에서 [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont)를 호출하면 원본이 없을 때 내보내기 시 대체 폰트로 사용됩니다. 이는 생성된 XAML이 대체 폰트를 참조한다거나 대상 머신에 해당 폰트가 존재한다는 것을 보장하지 않으며, XAML이 참조하는 폰트가 표시되는 환경에 존재하도록 하십시오.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP 및 Xamarin.Forms와 같은 다른 XAML 스택과의 호환성은 보장되지 않으며, 목표 환경에서 생성된 마크업을 테스트하십시오.

**숨겨진 슬라이드가 지원되나요, 그리고 기본적으로 내보내지 않도록 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)의 [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)를 통해 이 동작을 제어할 수 있으며, 내보낼 필요가 없으면 비활성화 상태로 유지하십시오.