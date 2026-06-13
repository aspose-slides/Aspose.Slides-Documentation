---
title: 외부에 링크된 이미지를 사용한 프레젠테이션 HTML 내보내기
type: docs
weight: 100
url: /ko/java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보내며, 이미지와 기타 리소스를 외부 링크 파일로 저장합니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 자체 포함된 HTML 파일로 내보냅니다. 이미지와 기타 리소스는 일반적으로 Base64 데이터 형태로 HTML에 직접 기록됩니다. 하나의 휴대 가능한 파일이 필요할 때는 편리하지만, 웹사이트, CMS 또는 서버 측 변환 파이프라인에 항상 최적의 형식은 아닙니다.

다음과 같은 경우 외부에 연결된 리소스를 사용하십시오:

- HTML 문서 크기를 줄이려는 경우;
- 브라우저나 CDN에서 이미지, 글꼴, 오디오 또는 비디오를 별도로 캐시하려는 경우;
- 내보낸 후에 생성된 리소스를 검사, 교체, 압축 또는 후처리하려는 경우;
- 출력 구조를 웹 애플리케이션이 기대하는 형태에 가깝게 유지하려는 경우.

일반적인 HTML 변환 워크플로에 대해서는 [PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/java/convert-powerpoint-to-html/)을 참고하십시오. 이 문서는 내보내기에서 리소스 연결 부분에 초점을 맞춥니다.

## **링크된 리소스 내보내기 작동 방식**

[ILinkEmbedController](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)는 애플리케이션이 리소스별로 데이터를 HTML에 삽입할지 외부에 저장하고 링크를 작성할지를 결정하도록 합니다.

이 인터페이스에는 세 가지 메서드가 있습니다:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)은 리소스를 링크할지 삽입할지를 결정합니다.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)은 생성된 HTML이나 다른 연결된 리소스에 기록될 URL을 반환합니다.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)은 연결된 리소스 데이터를 디스크나 다른 저장 대상에 씁니다.

파일 시스템 경로와 브라우저 URL은 별개의 개념입니다. 예를 들어 아래 샘플은 리소스 파일을 디스크의 `html-output/assets`에 저장하고, HTML에는 `assets/resource-1.svg`와 같은 상대 URL을 포함합니다. 브라우저는 링크를 포함하는 파일을 기준으로 해당 URL을 해석합니다. 따라서 `presentation.html`에서 SVG 파일로의 링크는 `assets/resource-1.svg`를 사용하고, 그 SVG 파일이 동일한 `assets` 폴더에 저장된 이미지로 연결될 때는 `resource-4.jpg`를 사용합니다.

## **링크된 리소스로 HTML 내보내기**

다음 Java 예제는 출력 디렉터리를 만들고, HTML 파일을 그곳에 저장하며, 연결된 리소스를 `assets` 하위 디렉터리에 보관합니다. Aspose.Slides가 안전한 파일 확장자를 제공하거나 추론할 수 있는 경우, 컨트롤러는 일반적인 이미지, 글꼴, 오디오, 비디오 및 CSS 리소스를 연결합니다. 인식되지 않은 리소스는 그대로 삽입됩니다.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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
}
```

내보낸 후 출력 폴더는 다음과 같은 구조를 가집니다:

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

구체적인 파일은 프레젠테이션 내용과 내보내기 옵션에 따라 달라집니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG로 내보내집니다. Aspose.Slides는 소스 프레젠테이션보다 파일 크기가 작거나 더 적합한 경우 다른 이미지 코덱을 선택할 수 있습니다. 투명도가 있는 이미지는 PNG로 내보내집니다.

## **배포를 위한 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html`이 `html-output/presentation.html`에서 열리면 브라우저는 `html-output/assets/resource-1.svg`를 로드합니다.

한 연결된 리소스가 다른 연결된 리소스를 참조할 때, 샘플은 [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)의 `referrer` 매개변수를 사용하고 파일 이름만 반환합니다. 예를 들어 `resource-1.svg`와 `resource-4.jpg`가 모두 `assets` 폴더에 있다면 SVG 파일은 `assets/resource-4.jpg`가 아니라 `resource-4.jpg`를 참조해야 합니다.

파일을 다른 위치에 배포할 경우에는 다른 URL 접두사를 사용하십시오:

- HTML 파일 옆에 자산 디렉터리가 있을 때는 `assets/`를 사용합니다.
- 자산 디렉터리가 HTML 파일보다 한 단계 위에 있을 때는 `../assets/`를 사용합니다.
- 파일이 CDN이나 정적 파일 서버에 업로드될 때는 `https://cdn.example.com/presentations/job-123/assets/`를 사용합니다.

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)이 반환하는 URL은 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)이 파일을 기록하는 최종 배포 위치와 일치해야 합니다. 서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리나 객체 저장소 접두사를 사용하여 다른 내보내기의 파일이 덮어쓰기 되지 않도록 합니다.

## **내장 대신 사용해야 할 경우**

단일 파일이어야 하는 경우(예: 이메일 첨부 파일, 오프라인 미리 보기, 별도의 자산 폴더 없이 이동되는 문서)에는 Base64로 삽입된 HTML이 여전히 유용합니다. HTML이 웹 애플리케이션에 의해 제공되거나 CMS에 저장되고, 빌드 파이프라인에서 최적화되며, 브라우저가 HTML과 독립적으로 캐시할 경우에는 연결된 리소스가 더 적합합니다.

## **FAQ**

**이미지만 외부에 저장하고 다른 리소스는 삽입된 상태로 유지할 수 있나요?**

예. [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinkembedcontroller/)에서 별도 파일로 저장하려는 콘텐츠 유형에 대해 `LinkEmbedDecision.Link`를 반환하고, 나머지에 대해서는 `LinkEmbedDecision.Embed`를 반환하면 됩니다.

**내보낸 이미지 확장자가 원본 프레젠테이션과 다른 이유는 무엇인가요?**

Aspose.Slides는 HTML 내보내기 과정에서 래스터 이미지를 다시 인코딩하여 크기를 줄이거나 브라우저 호환성을 높일 수 있습니다. 예를 들어 원본 파일의 이미지는 렌더링 결과에 따라 JPEG 또는 PNG로 저장될 수 있습니다.

**HTML 파일을 이동한 후에도 상대 URL이 작동하나요?**

상대 URL은 동일한 상대 폴더 구조가 유지될 때만 작동합니다. HTML이 `assets/resource-1.png`를 참조한다면 `assets` 폴더는 HTML 파일 옆에 그대로 존재해야 하며, 다른 URL 접두사를 사용하지 않는 한 폴더 구조를 변경하면 링크가 깨집니다.

**서버 애플리케이션에서 동일한 출력 폴더를 재사용해야 하나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리나 저장 접두사를 사용하십시오. 이렇게 하면 파일 이름 충돌을 방지하고 한 내보내기가 다른 내보내기의 리소스를 덮어쓰는 일을 막을 수 있습니다.