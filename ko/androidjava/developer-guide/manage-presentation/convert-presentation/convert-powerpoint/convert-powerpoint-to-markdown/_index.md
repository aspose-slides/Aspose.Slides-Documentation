---
title: Android에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- Markdown 이미지 내보내기
- CDN 이미지 링크
- PowerPoint
- 프레젠테이션
- Markdown
- Android
- Java
- Aspose.Slides
description: "Java를 사용하여 Android에서 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하고, 내보낸 비트맵, 메타파일 및 SVG 이미지가 저장되고 참조되는 위치를 제어합니다."
---
## **개요**

Aspose.Slides for Android via Java는 문서화, 정적 사이트, 콘텐츠 마이그레이션 및 버전 제어 워크플로를 위해 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환할 수 있습니다. Markdown 변형을 선택하고, 슬라이드 콘텐츠가 렌더링되는 방식을 제어하며, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 이를 참조하는 방식을 결정할 수 있습니다.

기본적으로, Markdown 내보내기는 텍스트 전용 출력을 사용합니다. 시각적 콘텐츠를 내보내려면 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/) 메서드로 [MarkdownExportType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownexporttype/) 열거형의 `Sequential` 또는 `Visual` 값을 설정합니다. `Sequential`은 슬라이드 항목을 개별적으로 순서대로 렌더링하고, `Visual`은 그룹화된 항목을 함께 유지하여 시각적 관계를 보존합니다. `TextOnly` 값은 이미지 리소스를 내보내지 않으므로 해당 모드에서는 이미지 저장 콜백이 호출되지 않습니다.

## **프레젠테이션을 Markdown으로 변환**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스로 로드한 다음, [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 메서드를 호출하여 [SaveFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/) 열거형의 `Md` 값을 사용합니다.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown 변형 선택**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/) 메서드는 출력에 사용되는 Markdown 사양을 제어합니다. [Flavor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/flavor/) 열거형에는 CommonMark, GitHub Flavored Markdown 및 기타 지원되는 변형이 포함됩니다.

다음 예제는 프레젠테이션을 CommonMark 형식으로 내보냅니다:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **기본 로컬 저장 동작을 사용하여 이미지 내보내기**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/) 클래스는 로컬에 저장되는 이미지를 구성하기 위해 두 가지 메서드를 제공합니다:

- [setBasePath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)은 Markdown 문서와 해당 리소스의 기본 디렉터리를 지정합니다.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)은 이미지 하위 디렉터리를 지정합니다. 기본값은 `Images`입니다.

다음 예제는 시각적 콘텐츠를 렌더링하고, 이미지를 `output/assets`에 저장하며, Markdown 문서에 상대 이미지 참조를 생성합니다:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

이 동작은 사용자 지정 이미지 저장 핸들러가 `false`를 반환할 때 대체 동작으로도 사용됩니다.

## **이미지 저장 및 Markdown 링크 사용자 정의**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/) 메서드를 사용하여 Markdown 내보내기 중에 발생하는 SVG가 아닌 비트맵 및 메타파일 리소스에 대한 콜백을 등록합니다. `MarkdownImageSavingHandler` 콜백은 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 객체, 해당 [ImageFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imageformat/) 값 및 생성된 Markdown 링크를 한 요소의 `String[]` 매개변수로 받습니다. 제공된 형식으로 이미지를 저장하거나 업로드하고, `link[0]`을 Markdown 출력에 표시될 참조로 교체합니다.

SVG 형식으로 내보내지는 리소스는 별도로 처리됩니다. [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/) 메서드로 콜백을 등록합니다. `MarkdownSvgImageSavingHandler` 콜백은 [ISvgImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgimage/) 객체와 한 요소의 `String[] link` 매개변수를 받습니다. SVG에는 `ImageFormat` 인수가 없으므로 [ISvgImage.getSvgData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgimage/) 메서드에서 XML 데이터를 직접 쓰거나 업로드합니다. 내보내기 모드와 시각적 그룹화에 따라 소스 프레젠테이션의 SVG가 래스터화되거나 다른 콘텐츠와 결합될 수 있으며, 결과 비‑SVG 리소스는 이미지 저장 콜백으로 전달됩니다. 모든 내보낸 시각적 리소스가 사용자 지정 처리를 필요로 할 때 두 콜백을 모두 등록하십시오.

핸들러 반환 값은 이미지를 누가 처리할지 결정합니다:

- 핸들러가 이미지를 저장, 업로드, 변환하거나 기타 방식으로 처리하고 `link[0]`에 유효한 값을 할당한 후 `true`를 반환합니다. Aspose.Slides는 해당 값을 Markdown 문서에 기록하고 기본 로컬 저장을 수행하지 않습니다.
- `false`를 반환하면 Aspose.Slides가 이미지를 로컬에 저장하고 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)와 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)에 설정된 값에 따라 링크를 생성합니다.

{{% alert color="warning" title="Important" %}}
`true`를 반환하는 핸들러는 이미지에 대한 책임을 집니다. 유효하고 비어 있지 않은 링크를 할당하지 않고 `true`를 반환하면 `InvalidOperationException`이 발생하여 내보내기가 실패합니다.
{{% /alert %}}

### **이미지를 CDN 원본 디렉터리에 저장하고 외부 URL 사용**

다음 예제는 `cdn-origin/presentations/quarterly-report`를 마운트되었거나 동기화된 CDN 원본 디렉터리로 취급합니다. 각 핸들러는 생성된 파일 이름을 추출하고 이미지를 해당 사용자 지정 디렉터리에 저장한 뒤, 생성된 로컬 참조를 공개 CDN URL로 교체합니다. 샘플 자체는 네트워크 업로드를 수행하지 않으며, 디렉터리가 CDN 원본으로 마운트되거나 파일이 CDN에 게시된 후에야 URL이 유효해집니다. 객체 스토리지를 사용할 경우 파일 시스템 쓰기를 스토리지 SDK의 업로드 작업으로 대체하고, 업로드가 성공한 이후에만 `link[0]`을 할당합니다.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

비트맵 핸들러는 128 × 128 픽셀보다 작은 이미지는 의도적으로 `false`를 반환하므로 Aspose.Slides는 기본 동작을 사용해 해당 이미지를 `output/fallback-images`에 저장합니다. 더 큰 비트맵 및 메타파일 리소스와 SVG 리소스는 사용자 지정 코드로 처리됩니다. 예를 들어 `fallback-images/image1.png`와 같은 로컬 참조는 `https://cdn.example.com/presentations/quarterly-report/image1.png`가 됩니다. 핸들러는 파일을 쓸 때만 운영 체제 경로를 사용하고, Markdown에 기록되는 링크는 슬래시(`/`)와 URL‑인코딩된 파일 이름을 사용합니다. 상대 링크를 만들 때도 동일한 규칙을 적용하십시오: 플랫폼별 디렉터리 구분자가 아니라 `/`를 사용합니다.

## **FAQ**

**하나의 핸들러가 래스터 이미지와 SVG 이미지를 모두 처리할 수 있나요?**

아니요. SVG가 아닌 비트맵 및 메타파일 리소스에는 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)을, SVG로 내보내지는 리소스에는 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)을 사용하십시오. 전자는 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 객체와 [ImageFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imageformat/) 값을 제공하고, 후자는 [ISvgImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgimage/) 객체와 해당 SVG 데이터를 읽을 수 있는 [ISvgImage.getSvgData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgimage/) 메서드를 제공합니다. 내보내기 중에 래스터화된 소스 SVG는 이미지 저장 콜백으로 처리됩니다.

**이미지 저장 핸들러가 `false`를 반환하면 어떻게 되나요?**

Aspose.Slides는 기본 로컬 저장 동작을 사용합니다. 이미지 위치와 생성된 참조는 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)와 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/markdownsaveoptions/)에 설정된 값에 따라 제어됩니다.

**핸들러가 이미지를 로컬에 저장하지 않고 URL만 제공할 수 있나요?**

네. 핸들러가 이미지를 객체 스토리지 등에 업로드하고 결과 URL을 `link[0]`에 할당한 뒤 `true`를 반환하면 됩니다. 핸들러가 자체적으로 처리를 완료해야 하며, `true`를 반환하면 기본 로컬 저장이 방지됩니다.

**핸들러에서 `InvalidOperationException`이 발생하는 이유는 무엇인가요?**

핸들러가 `true`를 반환했지만 유효한 링크를 제공하지 않았을 때 이 예외가 발생합니다. `true`를 반환하기 전에 Markdown에 기록될 상대 경로나 외부 URL을 `link[0]`에 할당하십시오.

**이미지 링크에 어떤 경로 구분자를 사용해야 하나요?**

Markdown 링크와 URL에서는 슬래시(`/`)를 사용하십시오. 파일 시스템 경로를 구성할 때는 `Path.resolve` 등을 사용하고, Markdown 참조는 별도로 정규화합니다.

**Markdown 내보내기 시 하이퍼링크가 보존되나요?**

네. 텍스트 [hyperlinks](/slides/ko/androidjava/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/androidjava/slide-transition/)와 [animations](/slides/ko/androidjava/powerpoint-animation/)는 변환되지 않습니다.

**프레젠테이션을 병렬로 Markdown으로 변환할 수 있나요?**

다른 프레젠테이션 파일을 병렬로 처리할 수 있지만, 동일한 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스를 여러 스레드가 공유하면 안 됩니다. [멀티스레딩 지침](/slides/ko/androidjava/multithreading/)을 따르고 파일당 별도 인스턴스를 사용하십시오.