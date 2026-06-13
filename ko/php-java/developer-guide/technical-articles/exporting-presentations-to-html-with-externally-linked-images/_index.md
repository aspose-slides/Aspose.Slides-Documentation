---
title: 외부에 링크된 이미지로 프레젠테이션을 HTML로 내보내기
type: docs
weight: 100
url: /ko/php-java/exporting-presentations-to-html-with-externally-linked-images/
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
- 연결된 이미지
- 외부에 링크된 이미지
- 연결된 리소스
- 외부 리소스
- PHP
- Aspose.Slides
description: "PHP에서 Java를 통해 Aspose.Slides를 사용하여 이미지 및 기타 리소스를 외부 링크 파일로 저장하면서 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보냅니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 자체 포함 HTML 파일로 내보냅니다. 이미지 및 기타 리소스는 일반적으로 Base64 데이터로 HTML에 직접 기록됩니다. 하나의 휴대용 파일이 필요할 때는 편리하지만 웹 사이트, CMS 또는 서버 측 변환 파이프라인에 항상 최적의 형식은 아닙니다.

외부에 링크된 리소스를 사용하려는 경우:

- HTML 문서 크기를 줄이기 위해;
- 이미지, 폰트, 오디오 또는 비디오를 브라우저나 CDN에 별도로 캐시하기 위해;
- 내보낸 후 생성된 리소스를 검사, 교체, 압축 또는 후처리하기 위해;
- 출력 구조를 웹 애플리케이션이 기대하는 형태에 가깝게 유지하기 위해.

전체 HTML 변환 워크플로우에 대해서는 [PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/php-java/convert-powerpoint-to-html/)를 참조하십시오. 이 문서는 내보내기의 리소스 연결 부분에 중점을 둡니다.

## **링크된 리소스 내보내기 작동 방식**

[HtmlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/htmloptions/)는 Aspose.Slides가 프레젠테이션을 HTML로 내보낼 때 사용자 지정 링크/임베드 컨트롤러를 사용할 수 있습니다. PHP에서 Java를 통해 이 시나리오는 일반적으로 작은 Java 헬퍼 클래스로 구현됩니다. 해당 헬퍼를 컴파일하고 PHP Java Bridge 클래스 경로에 추가한 다음 PHP에서 `new Java(...)`로 인스턴스화합니다.

헬퍼 클래스는 리소스별로 내보내기가 데이터를 HTML에 임베드할지 외부에 저장하고 링크를 작성할지 결정합니다. 세 개의 콜백 메서드가 필요합니다:

- `ExternalResourceController.getObjectStoringLocation` 은 리소스를 링크할지 임베드할지 결정합니다.
- `ExternalResourceController.getUrl` 은 생성된 HTML 또는 다른 링크된 리소스에 기록될 URL을 반환합니다.
- `ExternalResourceController.saveExternal` 은 링크된 리소스 데이터를 디스크 또는 다른 저장 대상에 기록합니다.

파일 시스템 경로와 브라우저 URL은 별개의 고려 사항입니다. 예를 들어 아래 샘플은 디스크에 `html-output/assets`에 리소스 파일을 쓰는 반면, HTML에는 `assets/resource-1.svg`와 같은 상대 URL을 포함합니다. 브라우저는 링크가 포함된 파일을 기준으로 해당 URL을 해석합니다. 따라서 `presentation.html`에서 SVG 파일로의 링크는 `assets/resource-1.svg`를 사용하고, 그 SVG 파일이 동일한 `assets` 폴더에 저장된 이미지를 참조할 때는 `resource-4.jpg`를 사용합니다.

## **Java 헬퍼 클래스 생성**

`com.example.slides.ExternalResourceController`와 같은 Java 클래스를 만들고, 클래스 경로에 Aspose.Slides for Java를 포함시켜 컴파일한 뒤 PHP Java Bridge에서 사용할 수 있도록 컴파일된 클래스 또는 JAR를 제공하십시오.

아래 헬퍼는 Aspose.Slides가 안전한 파일 확장자를 제공하거나 추론할 수 있는 경우 일반 이미지, 폰트, 오디오, 비디오 및 CSS 리소스를 연결합니다. 인식되지 않는 리소스는 계속 임베드됩니다.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **링크된 리소스로 HTML 내보내기**

다음 PHP 코드는 출력 디렉터리를 만들고 HTML 파일을 해당 위치에 저장하며, 링크된 리소스를 `assets` 하위 디렉터리에 저장합니다. 내보내기에는 [HtmlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideimageformat/), 및 [SaveFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveformat/)을 결합합니다.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

내보낸 후, 출력 폴더는 다음과 같은 구조를 가집니다:

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

정확한 파일은 프레젠테이션 내용과 내보내기 옵션에 따라 달라집니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG로 내보내집니다. Aspose.Slides는 파일 크기 감소 또는 브라우저 호환성을 위해 원본 프레젠테이션과 다른 이미지 코덱을 선택할 수 있습니다. 투명도가 포함된 이미지는 PNG로 내보내집니다.

## **배포를 위한 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html`을 `html-output/presentation.html`에서 열면 브라우저는 `html-output/assets/resource-1.svg`를 로드합니다.

하나의 링크된 리소스가 다른 링크된 리소스를 참조할 때, 샘플은 `ExternalResourceController.getUrl`의 `referrer` 매개변수를 사용하고 파일 이름만 반환합니다. 예를 들어 `resource-1.svg`와 `resource-4.jpg`가 모두 `assets` 폴더에 있다면 SVG 파일은 `assets/resource-4.jpg`가 아니라 `resource-4.jpg`를 참조해야 합니다.

파일이 다른 위치에 배포될 경우 다른 URL 접두사를 사용하십시오:

- 자산 디렉터리가 HTML 파일 옆에 있을 때 `assets/`를 사용합니다.
- 자산 디렉터리가 HTML 파일보다 한 단계 위에 있을 때 `../assets/`를 사용합니다.
- 파일이 CDN 또는 정적 파일 서버에 업로드될 때 `https://cdn.example.com/presentations/job-123/assets/`를 사용합니다.

`ExternalResourceController.getUrl`이 반환하는 URL은 `ExternalResourceController.saveExternal`이 기록한 파일의 최종 배포 위치와 일치해야 합니다. 서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리 또는 객체 저장소 접두사를 사용하여 다른 내보내기의 파일이 덮어쓰기되지 않도록 하십시오.

## **대신 임베드해야 할 경우**

임베드된 Base64 HTML은 출력이 이메일 첨부 파일, 오프라인 미리 보기 또는 지원 자산 폴더 없이 이동될 문서와 같이 단일 파일이어야 할 때 여전히 유용합니다. HTML이 웹 애플리케이션에 의해 제공되거나, CMS에 저장되거나, 빌드 파이프라인에서 최적화되거나, 브라우저가 HTML과 독립적으로 캐시할 경우 링크된 리소스가 더 적합합니다.

## **FAQ**

**이미지만 외부화하고 다른 리소스는 임베드된 상태로 유지할 수 있나요?**

네. `ExternalResourceController.getObjectStoringLocation`에서 별도 파일로 저장하려는 콘텐츠 유형에 대해서만 [LinkEmbedDecision](https://reference.aspose.com/slides/ko/php-java/aspose.slides/linkembeddecision/)의 `Link` 값을 반환하고, 나머지는 `Embed` 값을 반환하십시오.

**내보낸 이미지 확장자가 원본 프레젠테이션과 다른 이유는 무엇인가요?**

Aspose.Slides는 HTML 내보내기 중에 파일 크기 감소 또는 브라우저 호환성을 위해 래스터 이미지를 다시 인코딩할 수 있습니다. 예를 들어 원본 파일의 이미지는 렌더링 결과에 따라 JPEG 또는 PNG로 기록될 수 있습니다.

**HTML 파일을 이동한 후에도 상대 URL이 작동하나요?**

상대 URL은 동일한 상대 폴더 구조가 유지될 때만 작동합니다. HTML이 `assets/resource-1.png`를 참조한다면 `assets` 폴더는 HTML 파일 옆에 있어야 하며, 다른 URL 접두사를 생성하지 않은 경우에는 이동 시 문제가 발생합니다.

**서버 애플리케이션에서 같은 출력 폴더를 재사용해야 하나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리 또는 저장 접두사를 사용하십시오. 이렇게 하면 파일 이름 충돌을 방지하고 한 내보내기가 다른 내보내기의 리소스를 덮어쓰는 상황을 피할 수 있습니다.