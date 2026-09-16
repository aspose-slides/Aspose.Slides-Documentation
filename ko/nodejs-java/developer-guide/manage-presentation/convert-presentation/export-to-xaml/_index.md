---
title: JavaScript에서 XAML으로 프레젠테이션 내보내기
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
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML으로 내보내기
- PPTX를 XAML으로 내보내기
- ODP를 XAML으로 내보내기
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환합니다—빠르고 Office가 필요 없는 솔루션으로 레이아웃을 그대로 유지합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/)을 통해 내보내기를 사용자 지정하는 방법(숨겨진 슬라이드 내보내기 포함)을 시연합니다. 또한 대체 글꼴, XAML 스택 호환성 및 숨겨진 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에 답합니다.

## **XAML 소개**

XAML은 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 설명하기 위해 사용되는 XML 기반 마크업 언어입니다.

시각 디자이너에서 XAML 파일을 작업하거나 직접 마크업을 작성·편집할 수 있습니다.

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

기본적으로 내보낸 슬라이드는 프로세스 현재 작업 디렉터리의 `input` 하위 폴더에 저장됩니다. 폴더는 자동으로 생성되며 필요한 이미지도 해당 폴더에 저장됩니다.

출력 폴더 이름은 확장자를 제외한 원본 파일 이름에서 가져옵니다. Aspose.Slides for Node.js via Java 26.8에서는 `input.pptx`를 내보낼 경우 `input/input/Slide_1.xaml`와 같은 중첩 경로가 생성됩니다. 출력 처리 시 전체 생성 경로를 유지하십시오. 기본 출력은 현재 작업 디렉터리를 기준으로 하며, 반드시 입력 파일과 동일한 위치에 있어야 하는 것은 아닙니다.

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

[IXamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloptions/) 인터페이스를 사용하여 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어할 수 있습니다.

출력을 사용자 지정 위치에 저장하려면 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/)를 구현하고 해당 구현 인스턴스를 [XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/)의 [setOutputSaver](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) 메서드에 전달하십시오.

숨겨진 슬라이드를 XAML 출력에 포함하려면 `true`와 함께 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)를 호출합니다. 다음 JavaScript 예제를 참고하십시오:

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

## **생성된 모든 XAML 아티팩트 캡처하기**

XAML 내보내기는 내보낸 각 슬라이드에 대한 XAML 문서와 별도의 이미지 및 지원 리소스를 생성할 수 있습니다. 기본 파일 시스템 저장소 대신 이러한 아티팩트를 받기 위해 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/)를 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/#setOutputSaver)에 할당하십시오. XAML 옵션을 받아들이는 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save) 오버로드를 사용해 내보내기를 시작합니다.

Node.js에서는 Aspose.Slides에서 사용하는 `java` 패키지의 `java.newProxy`를 사용해 Java 인터페이스를 구현합니다. 내보내기가 완료될 때까지 프록시를 유지하십시오.

### **콜백 수명 주기 이해하기**

내보내기 수행 시 [IXamlOutputSaver.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)가 생성된 각 아티팩트마다 별도로 호출됩니다.

- `path`는 아티팩트를 식별하며 상대 디렉터리를 포함할 수 있습니다. XAML이 상대 경로를 사용해 리소스를 참조할 수 있으므로 이 정보를 보존하십시오.
- `data`는 아티팩트의 바이트 배열을 포함합니다. 이미지 및 기타 바이너리 리소스는 텍스트로 디코딩해서는 안 됩니다.
- 저장자는 데이터를 반환하기 전에 보존하거나 영구 저장해야 합니다. 예제에서는 각 Java 바이트 배열을 애플리케이션이 소유하는 Node.js 버퍼로 복사합니다.
- 프레젠테이션 저장 작업이 반환되고 모든 콜백이 성공적으로 완료된 경우에만 내보내기를 성공으로 간주하십시오. 저장 오류를 무시하거나 백그라운드 쓰기를 관찰하지 말고, 영구 저장이 이후에 이루어지는 경우에도 전체 성공을 해당 단계가 성공한 뒤에만 보고하십시오.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)도 사용자 지정 저장자에 적용됩니다. 기본값인 `false`는 숨겨진 슬라이드 XAML 문서를 제외합니다. `true`를 전달하면 숨겨진 슬라이드와 해당 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 수는 프레젠테이션에 따라 다르므로 슬라이드당 콜백이 하나이거나 고정된 콜백 순서가 있다고 가정하지 마십시오.

### **메모리 내에서 내보내고 아티팩트 검사하기**

다음 완전한 예제는 `input.pptx`를 로드하고, 이름‑버퍼 맵에 모든 아티팩트를 수집한 뒤 이름, 형식 및 바이트 수를 출력합니다. 제공된 이름을 그대로 보존합니다. 이름이 중복될 경우 컬렉션을 무효로 처리하고 조용히 덮어쓰지 않습니다. 예제는 결과를 사용하기 전에 이를 확인합니다.

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

        // XAML만 디코드하고, 텍스트 검사가 필요할 때만 수행합니다.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

확장자 검사는 검토에 유용합니다; 익숙하지 않은 리소스 유형도 모두 보존하십시오. 저장하거나 전송할 때 바이트를 변경하지 마십시오. 텍스트 처리가 필요한 XAML에만 UTF‑8 디코딩을 사용하십시오.

### **수집된 아티팩트를 ZIP 아카이브에 패키징하기**

다음 독립 예제는 내보내기를 수집하고, 이름을 검증한 뒤 Java 브리지를 사용해 원본 바이트를 ZIP 아카이브에 기록합니다. ZIP은 메모리 내에서 조립된 후 디스크에 저장됩니다. 고유한 아카이브 이름은 동시 내보내기 작업을 구분합니다. ZIP 엔트리는 슬래시(`/`)를 사용하고 상대 디렉터리를 유지합니다. 정상화 후 충돌이 발생하거나 위험한 이름은 전체 패키지를 쓰기 전에 거부합니다.

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
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // 닫기를 수행하면 아카이브가 영구 저장되기 전에 ZIP 디렉터리가 최종화됩니다.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

예제는 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html)을 사용해 로컬 아카이브 하나를 기록합니다; 내보내기 자체는 개별 XAML 또는 이미지 파일을 쓰지 않습니다. 원격 저장소에 저장하려면 아카이브 작성 단계 대신 수집된 바이트 배열을 업로드하도록 교체하십시오. 내보내기 작업 식별자와 전체 상대 아티팩트 이름을 블롭 키로 사용하거나, 작업 식별자·상대 이름·바이너리 데이터를 데이터베이스 행에 저장하십시오. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에만 작업을 공개하고, 영구 저장에 실패할 경우 부분 출력을 정리하십시오.

큰 프레젠테이션의 경우, 사용자 지정 저장자를 사용해 각 아티팩트를 직접 애플리케이션 저장소에 영구 저장하면 전체 내보내기를 메모리에 복사해 두는 부담을 피할 수 있습니다. 내보내기 측면에서 각 콜백을 동기식으로 유지하고, 대상이 바이트를 수락한 후에만 반환하도록 하며, 실패가 호출자에게 전달되도록 하십시오.

### **리소스 이름 보존 및 참조 검증하기**

- 대상이 요구하는 경우 경로 구분자를 정규화하되, 상대 디렉터리는 유지하십시오. 모든 생성 이름이 고유하고 리소스 참조가 유효함을 보장할 때만 파일명만 사용하십시오.
- 대상별 이름 검증을 적용하십시오. 느슨한 파일을 쓸 때는 루트 경로나 경로 탐색 세그먼트를 거부하고, 대상 경로를 절대 경로로 해결한 뒤 내보내기 디렉터리 하위에 머무르는지 확인하십시오(포함 여부 확인에 디렉터리 구분자 포함). 심볼릭 링크가 없는 애플리케이션 제어 디렉터리를 사용하십시오.
- 각 내보내기 작업마다 별도 저장자와 저장소 네임스페이스를 사용하십시오. 구분자 정규화 및 대상 대소문자 구분 규칙에 따라 충돌을 감지하십시오.
- 공개하기 전에 각 XAML 문서를 XML로 파싱하고 `Source` 또는 `ImageSource`와 같은 파일 기반 리소스 참조를 검사하십시오. 해당 상대 URI를 포함 XAML 아티팩트 디렉터리 기준으로 해결하고, 결과 저장 이름을 정규화한 뒤 맵 키·ZIP 엔트리·저장 객체가 존재하는지 확인하십시오. 외부 URI와 XAML 마크업 표현식은 파일 이름과 별도로 처리하십시오.

예를 들어 `input/Slide_1.xaml`이 `images/image1.png`를 참조한다면, 저장된 리소스는 `input/images/image1.png` 위치에 있어야 합니다. `image1.png`만 보관하면 관계가 깨집니다. 객체 스토리지인 경우 작업 접두사 아래 동일 레이아웃을 유지하고 해당 리소스 URL을 XAML 소비자가 접근할 수 있도록 하십시오. 완료된 ZIP을 다시 열어 엔트리 이름과 리소스 바이트를 검증하고, 대상 XAML 환경에서 대표 슬라이드를 로드해 이미지가 정상적으로 해석되는지 확인하십시오.

## **FAQ**

**원본 폰트가 머신에 없을 때 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/)의 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont)를 호출하십시오. 이 폰트는 원본이 없을 경우 내보내기 중 대체 폰트로 사용됩니다. 그러나 생성된 XAML이 반드시 대체 폰트를 참조하거나 대상 머신에 해당 폰트가 존재한다는 것을 보장하지는 않습니다. XAML이 표시되는 환경에 필요한 폰트가 모두 존재하도록 확인하십시오.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP, Xamarin.Forms 등 다른 XAML 스택과의 호환성은 보장되지 않으며, 목표 환경에서 생성된 마크업을 테스트해야 합니다.

**숨겨진 슬라이드가 지원되나요? 기본적으로 숨겨진 슬라이드가 내보내지는 것을 방지하려면 어떻게 해야 하나요?**

기본값은 숨겨진 슬라이드가 포함되지 않습니다. [XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/)의 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)를 사용해 동작을 제어할 수 있습니다. 필요하지 않다면 해당 옵션을 비활성화하십시오.