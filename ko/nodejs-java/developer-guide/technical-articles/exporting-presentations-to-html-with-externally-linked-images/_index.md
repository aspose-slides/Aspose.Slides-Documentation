---
title: 외부 링크된 이미지와 함께 프레젠테이션을 HTML로 내보내기
type: docs
weight: 100
url: /ko/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- 슬라이드 내보내기
- PPT 내보내기
- PPTX 내보내기
- ODP 내보내기
- PowerPoint를 HTML로
- OpenDocument를 HTML로
- 프레젠테이션을 HTML로
- 슬라이드를 HTML로
- PPT를 HTML로
- PPTX를 HTML로
- ODP를 HTML로
- 링크된 이미지
- 외부에 링크된 이미지
- 링크된 리소스
- 외부 리소스
- JavaScript
- Node.js
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides를 사용하여 JavaScript에서 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보내며, 이미지 및 기타 리소스를 외부 링크 파일로 저장합니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 독립형 HTML 파일로 내보냅니다. 이미지 및 기타 리소스는 일반적으로 Base64 데이터로 HTML에 직접 기록됩니다. 하나의 휴대용 파일이 필요할 때는 편리하지만, 웹사이트, CMS 또는 서버 측 변환 파이프라인에 항상 최적의 형식은 아닙니다.

다음과 같은 경우 외부 링크 리소스를 사용하십시오:

- HTML 문서 크기 감소
- 브라우저 또는 CDN에서 이미지, 글꼴, 오디오, 비디오를 별도로 캐시
- 내보낸 후 리소스를 검사, 교체, 압축 또는 후처리
- 웹 애플리케이션이 기대하는 구조에 더 가깝게 출력 유지

일반 HTML 변환 워크플로에 대해서는 [Convert PowerPoint Presentations to HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/)를 참조하십시오. 이 문서는 내보내기의 리소스 연결 부분에 초점을 맞춥니다.

## **링크된 리소스 내보내기 작동 방식**

[ILinkEmbedController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)에 대한 Java 프록시는 애플리케이션이 리소스 별로 데이터를 HTML에 포함시킬지 외부에 저장하고 링크를 작성할지를 결정할 수 있게 합니다.

컨트롤러에는 세 가지 메서드가 있습니다:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)은 리소스를 링크할지 포함시킬지를 결정합니다.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)은 생성된 HTML이나 다른 링크된 리소스에 기록될 URL을 반환합니다.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)은 링크된 리소스 데이터를 디스크 또는 다른 저장 대상에 씁니다.

파일 시스템 경로와 브라우저 URL은 별개의 문제입니다. 예를 들어 아래 샘플은 리소스 파일을 디스크의 `html-output/assets`에 기록하고, HTML에는 `assets/resource-1.svg`와 같은 상대 URL을 포함합니다. 브라우저는 링크가 포함된 파일을 기준으로 이러한 URL을 해석합니다. 따라서 `presentation.html`에서 SVG 파일로의 링크는 `assets/resource-1.svg`를 사용하고, 해당 SVG 파일이 같은 `assets` 폴더에 저장된 이미지를 가리킬 때는 `resource-4.jpg`를 사용합니다.

## **링크된 리소스로 HTML 내보내기**

다음 JavaScript 예제는 출력 디렉터리를 생성하고, HTML 파일을 그곳에 저장하며, `assets` 하위 디렉터리에 링크된 리소스를 보관합니다. 컨트롤러는 Aspose.Slides가 제공하거나 안전한 파일 확장자를 추론할 수 있을 때 일반 이미지, 글꼴, 오디오, 비디오 및 CSS 리소스를 링크합니다. 인식되지 않은 리소스는 계속 포함됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

내보내기 후 출력 폴더 구조는 다음과 같습니다:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

정확한 파일은 프레젠테이션 내용 및 내보내기 옵션에 따라 달라집니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG 형식으로 내보내집니다. Aspose.Slides는 더 작거나 적합한 파일을 제공할 경우 원본 프레젠테이션과 다른 이미지 코덱을 선택할 수 있습니다. 투명도가 있는 이미지는 PNG로 내보내집니다.

## **배포용 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html`을 `html-output/presentation.html`에서 열면 브라우저는 `html-output/assets/resource-1.svg`를 로드합니다.

하나의 링크된 리소스가 다른 링크된 리소스를 참조할 때, 샘플은 [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)의 `referrer` 매개변수를 사용하고 파일 이름만 반환합니다. 예를 들어 `resource-1.svg`와 `resource-4.jpg`가 모두 `assets` 폴더에 있으면 SVG 파일은 `assets/resource-4.jpg`가 아니라 `resource-4.jpg`를 참조해야 합니다.

파일을 다른 위치에 배포할 경우 다른 URL 접두사를 사용하십시오:

- HTML 파일 옆에 에셋 디렉터리가 있을 때는 `assets/` 사용
- 에셋 디렉터리가 HTML 파일보다 한 단계 위에 있을 때는 `../assets/` 사용
- 파일을 CDN 또는 정적 파일 서버에 업로드할 때는 `https://cdn.example.com/presentations/job-123/assets/` 사용

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)이 반환하는 URL은 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)이 기록한 파일의 최종 배포 위치와 일치해야 합니다. 서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리 또는 객체 저장소 접두사를 사용해 다른 내보내기의 파일이 덮어쓰이지 않도록 해야 합니다.

## **대신 포함해야 할 경우**

단일 파일이어야 하는 경우(예: 이메일 첨부 파일, 오프라인 미리 보기, 별도 에셋 폴더 없이 이동되는 문서)에는 Base64로 포함된 HTML이 여전히 유용합니다. HTML이 웹 애플리케이션에 의해 제공되거나 CMS에 저장되고, 빌드 파이프라인에서 최적화되거나 브라우저에서 HTML과 독립적으로 캐시될 경우에는 링크된 리소스가 더 적합합니다.

## **FAQ**

**이미지만 외부화하고 다른 리소스는 포함할 수 있나요?**

네. [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)에서 별도 파일로 저장하고 싶은 콘텐츠 유형에 대해서만 `LinkEmbedDecision.Link`를 반환하고, 나머지는 `LinkEmbedDecision.Embed`를 반환하면 됩니다.

**내보낸 이미지 확장자가 원본 프레젠테이션과 다른 이유는 무엇인가요?**

Aspose.Slides는 HTML 내보내기 중에 크기나 브라우저 호환성을 개선하기 위해 래스터 이미지를 재인코딩할 수 있습니다. 예를 들어 원본 파일의 이미지가 렌더링 결과에 따라 JPEG 또는 PNG로 기록될 수 있습니다.

**HTML 파일을 이동한 후에도 상대 URL이 작동하나요?**

상대 URL은 동일한 상대 폴더 구조가 유지되는 경우에만 작동합니다. HTML이 `assets/resource-1.png`를 참조한다면 `assets` 폴더는 HTML 파일 옆에 그대로 있어야 합니다. 다른 URL 접두사를 생성하지 않는 한 말이죠.

**서버 애플리케이션에서 동일한 출력 폴더를 재사용해야 하나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리 또는 저장 접두사를 사용하십시오. 이렇게 하면 파일 이름 충돌을 방지하고 한 내보내기가 다른 내보내기의 리소스를 덮어쓰는 상황을 피할 수 있습니다.