---
title: 외부에 링크된 이미지로 프레젠테이션을 HTML로 내보내기
type: docs
weight: 100
url: /ko/androidjava/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- 슬라이드 내보내기
- PPT 내보내기
- PPTX 내보내기
- ODP 내보내기
- PowerPoint에서 HTML로
- OpenDocument에서 HTML로
- 프레젠테이션을 HTML로
- 슬라이드를 HTML로
- PPT를 HTML로
- PPTX를 HTML로
- ODP를 HTML로
- 링크된 이미지
- 외부에 링크된 이미지
- 링크된 리소스
- 외부 리소스
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Android에서 Java로 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보내고 이미지와 기타 리소스를 외부 링크 파일로 저장합니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 단일 HTML 파일로 내보냅니다. 이미지 및 기타 리소스는 일반적으로 Base64 데이터로 HTML에 직접 기록됩니다. 이는 하나의 휴대 가능한 파일이 필요할 때 편리하지만 웹 보기, CMS 또는 나중에 출력을 게시하는 서버 측 변환 파이프라인에 항상 최적의 형식은 아닙니다.

외부에 링크된 리소스를 사용하려는 경우:
- HTML 문서의 크기를 줄이기;
- 브라우저 또는 CDN에서 이미지, 폰트, 오디오 또는 비디오를 별도로 캐시하기;
- 내보낸 후 생성된 리소스를 검사, 교체, 압축 또는 후처리하기;
- 출력 구조를 웹 애플리케이션이 기대하는 형태에 가깝게 유지하기;

일반적인 HTML 변환 워크플로우에 대해서는 [PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/androidjava/convert-powerpoint-to-html/)를 참조하십시오. 이 문서는 내보내기의 리소스 연결 부분에 중점을 둡니다.

## **링크된 리소스 내보내기 작동 방식**

[ILinkEmbedController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)는 애플리케이션이 리소스별로 내보내기가 데이터를 HTML에 포함시킬지 외부에 저장하고 링크를 작성할지 결정하도록 해줍니다.

이 인터페이스에는 세 가지 메서드가 있습니다:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)은 리소스를 링크할지 포함시킬지 결정합니다.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)은 생성된 HTML 또는 다른 링크된 리소스에 기록될 URL을 반환합니다.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)은 링크된 리소스 데이터를 디스크 또는 다른 저장 대상에 기록합니다.

파일 시스템 경로와 브라우저 URL은 별개의 개념입니다. 예를 들어, 아래 샘플은 리소스 파일을 애플리케이션의 파일 저장소인 `html-output/assets`에 저장하고, HTML에는 `assets/resource-1.svg`와 같은 상대 URL이 포함됩니다. 브라우저는 링크가 포함된 파일을 기준으로 이러한 URL을 해석합니다. 따라서 `presentation.html`에서 SVG 파일로의 링크는 `assets/resource-1.svg`를 사용하고, 해당 SVG 파일이 동일한 `assets` 폴더에 저장된 이미지로 연결할 때는 `resource-4.jpg`를 사용합니다.

## **링크된 리소스로 HTML 내보내기**

다음 Android Java 예제는 출력 디렉터리를 생성하고 HTML 파일을 그곳에 저장하며, 링크된 리소스를 `assets` 하위 디렉터리에 저장합니다. `applicationFilesDirectory`로 `context.getFilesDir()`와 같은 앱 전용 디렉터리를 전달합니다. 이 코드는 `java.nio.file` API를 사용하지 않으므로 Android `minSdk` 19와 호환됩니다.

컨트롤러는 Aspose.Slides가 제공하거나 안전한 파일 확장자를 추론할 수 있는 경우 일반 이미지, 폰트, 오디오, 비디오 및 CSS 리소스를 링크합니다. 인식되지 않는 리소스는 포함된 상태로 남습니다.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
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

정확한 파일은 프레젠테이션 내용 및 내보내기 옵션에 따라 다릅니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG 형식으로 내보내집니다. Aspose.Slides는 더 작거나 적합한 파일을 생성할 경우 원본 프레젠테이션에서 사용된 것과 다른 이미지 코덱을 선택할 수 있습니다. 투명성을 포함한 이미지는 PNG로 내보내집니다.

## **배포를 위한 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html`을 `html-output/presentation.html`에서 열면 브라우저는 `html-output/assets/resource-1.svg`를 로드합니다.

링크된 리소스가 다른 링크된 리소스를 참조할 때, 샘플은 [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)의 `referrer` 매개변수를 사용하고 파일 이름만 반환합니다. 예를 들어 `resource-1.svg`와 `resource-4.jpg`가 모두 `assets` 폴더에 있는 경우, SVG 파일은 `assets/resource-4.jpg`가 아니라 `resource-4.jpg`를 참조해야 합니다.

파일이 다른 위치에 배포될 때는 다른 URL 접두사를 사용하십시오:
- HTML 파일과 같은 위치에 에셋 디렉터리가 있을 경우 `assets/`를 사용합니다.
- 에셋 디렉터리가 HTML 파일 위 한 단계에 있을 경우 `../assets/`를 사용합니다.
- 파일이 CDN이나 정적 파일 서버에 업로드될 경우 `https://cdn.example.com/presentations/job-123/assets/`를 사용합니다.

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)이 반환하는 URL은 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)가 파일을 기록한 최종 배포 위치와 일치해야 합니다. Android 애플리케이션에서는 게시 워크플로에 따라 앱 전용 저장소, 캐시 디렉터리 또는 Storage Access Framework를 통해 얻은 디렉터리를 사용하십시오. 서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리 또는 객체 저장소 접두사를 사용하여 다른 내보내기의 파일이 덮어쓰이는 것을 방지합니다.

## **대신 포함해야 할 경우**

Base64로 포함된 HTML은 이메일 첨부 파일, 오프라인 미리 보기 또는 지원 에셋 폴더 없이 이동되는 문서와 같이 출력이 단일 파일이어야 할 때 여전히 유용합니다. HTML이 웹 애플리케이션을 통해 제공되거나 CMS에 저장되고, 빌드 파이프라인에 의해 최적화되거나 브라우저가 HTML과 별도로 캐시할 경우에는 링크된 리소스가 더 적합합니다.

## **FAQ**

**이미지만 외부화하고 다른 리소스는 포함된 상태로 유지할 수 있나요?**

예. [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilinkembedcontroller/)에서 별도의 파일로 저장하고자 하는 콘텐츠 유형에 대해서만 [LinkEmbedDecision](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/linkembeddecision/)의 `Link`를 반환하고, 그 외에는 `Embed`를 반환하면 됩니다.

**왜 내보낸 이미지 확장자가 원본 프레젠테이션과 다릅니까?**

Aspose.Slides는 크기 감소 또는 브라우저 호환성을 위해 HTML 내보내기 중에 래스터 이미지를 다시 인코딩할 수 있습니다. 예를 들어 원본 파일의 이미지는 렌더링 결과에 따라 JPEG 또는 PNG로 기록될 수 있습니다.

**HTML 파일을 이동한 후에도 상대 URL이 작동합니까?**

상대 URL은 동일한 상대 폴더 구조가 유지될 때만 작동합니다. HTML이 `assets/resource-1.png`를 참조한다면, `assets` 폴더는 다른 URL 접두사를 생성하지 않는 한 HTML 파일 옆에 있어야 합니다.

**Android에서 리소스를 공용 외부 저장소에 쓸 수 있나요?**

예, 애플리케이션이 대상 Android 버전에 맞는 유효한 저장 위치와 권한 모델을 가지고 있다면 가능합니다. 앱에서만 사용하는 생성된 HTML의 경우 앱 전용 파일이나 캐시 디렉터리가 보통 더 간단합니다. 사용자에게 보이는 출력의 경우 사용자가 선택한 위치나 앱에 맞는 다른 저장 방식을 사용하십시오.

**서버 애플리케이션이 동일한 출력 폴더를 재사용해야 하나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리나 저장 접두사를 사용하십시오. 이렇게 하면 파일명 충돌을 방지하고 한 내보내기가 다른 내보내기의 리소스를 덮어쓰는 것을 막을 수 있습니다.