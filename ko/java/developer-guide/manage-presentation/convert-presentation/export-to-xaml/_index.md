---
title: Java에서 XAML로 프레젠테이션 내보내기
linktitle: 프레젠테이션을 XAML로
type: docs
weight: 30
url: /ko/java/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML로
- OpenDocument를 XAML로
- 프레젠테이션을 XAML로
- PPT를 XAML로
- PPTX를 XAML로
- ODP를 XAML로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML로 내보내기
- PPTX를 XAML로 내보내기
- ODP를 XAML로 내보내기
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환합니다—빠르고 Office 없이도 레이아웃을 그대로 유지하는 솔루션입니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개를 포함하고, 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/)을 통해 내보내기를 사용자 지정하는 방법(숨겨진 슬라이드 내보내기 포함)을 시연합니다. 또한 폰트 대체, XAML 스택 호환성, 숨겨진 슬라이드 내보내기 동작과 관련된 일반적인 질문에 대한 답변도 제공합니다.

## **XAML 소개**

XAML은 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 설명하는 데 사용되는 XML 기반 마크업 언어입니다.

시각 디자이너에서 XAML 파일을 작업하거나 마크업을 직접 작성·편집할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 Java 예제는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

기본적으로 내보낸 슬라이드는 프로세스 현재 작업 디렉터리의 `pres` 하위 폴더에 저장되며, 빈 경로는 [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-)으로 확인됩니다. 폴더는 자동으로 생성되고 필요한 이미지도 동일한 위치에 저장됩니다.

출력 폴더 이름은 확장자를 제외한 원본 파일 이름에서 가져옵니다. `pres.pptx`의 경우 출력 파일은 `pres/Slide_1.xaml`, `pres/Slide_2.xaml` 등으로 명명됩니다. 입력 프레젠테이션에 절대 경로를 전달하더라도 출력 폴더는 현재 작업 디렉터리를 기준으로 생성되며, 입력 파일 옆에 생성되지 않습니다.

## **맞춤 옵션으로 프레젠테이션을 XAML로 내보내기**

[XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/) 인터페이스를 사용하여 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어합니다.

출력을 사용자 지정 위치에 저장하려면 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/)를 구현하고 해당 구현 인스턴스를 [XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/)의 [setOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) 메서드에 전달합니다.

숨겨진 슬라이드를 XAML 출력에 포함하려면 `true`와 함께 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)를 호출하면 됩니다. 아래 Java 예제를 참고하십시오:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **생성된 모든 XAML 아티팩트 캡처**

XAML 내보내기는 각 내보낸 슬라이드마다 XAML 문서와 별도의 이미지·지원 리소스를 생성할 수 있습니다. 기본 파일 시스템 저장소 대신 이러한 아티팩트를 받으려면 사용자 지정 [IXamlOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/)를 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-)에 지정하십시오. XAML 옵션을 허용하는 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 오버로드를 사용하여 내보내기를 시작합니다.

### **콜백 수명주기 이해**

내보내기 프로그램은 생성된 각 아티팩트에 대해 [IXamlOutputSaver.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)를 별도로 호출합니다:

- `path`는 아티팩트를 식별하며 상대 디렉터리를 포함할 수 있습니다. XAML이 상대 경로를 사용해 리소스를 참조할 수 있으므로 이 정보를 유지하십시오.
- `data`는 아티팩트의 바이트를 포함합니다. 이미지·기타 바이너리 리소스는 텍스트로 디코딩해서는 안 됩니다.
- 저장소는 반환하기 전에 데이터를 보관하거나 영구 저장할 책임이 있습니다. 예제에서는 각 바이트 배열을 애플리케이션이 소유한 메모리로 복사합니다.
- 프레젠테이션 저장 작업이 반환되고 모든 콜백이 성공적으로 완료되었을 때만 내보내기를 성공으로 간주합니다. 저장 오류를 무시하거나 백그라운드 쓰기를 시작하지 마십시오. 영구 저장이 이후에 발생하면 해당 단계도 성공한 후에 전체 성공을 보고하십시오.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)은 사용자 지정 저장소에도 적용됩니다. 기본값 `false`는 숨겨진 슬라이드 XAML 문서를 제외합니다. `true`를 전달하면 숨겨진 슬라이드와 해당 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 수는 프레젠테이션에 따라 다르며 슬라이드당 콜백이 하나라고 가정하거나 고정된 콜백 순서를 가정하지 마십시오.

### **메모리 내보내기 및 아티팩트 검사**

이 완전한 예제는 `pres.pptx`를 로드하고, 모든 아티팩트를 [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html)에 수집한 뒤 이름, 유형 및 바이트 수를 출력합니다. 제공된 이름을 정확히 보존합니다. 중복 이름은 아티팩트를 조용히 덮어쓰는 대신 컬렉션을 잘못된 것으로 표시합니다. 예제는 결과를 사용하기 전에 이를 확인합니다.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // XAML만 디코드하고, 텍스트 검사가 필요할 경우에만 디코드합니다.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

확장자 검사는 검사를 용이하게 하며, 익숙하지 않은 리소스 유형도 모두 보존하십시오. 저장하거나 전송할 때 바이트를 변경하지 마십시오. 텍스트 처리가 필요한 XAML에만 UTF-8로 [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-)를 사용하십시오.

### **수집된 아티팩트를 ZIP 아카이브에 패키징**

이 독립 예제는 내보내기를 수집하고, 이름을 검증한 뒤 원본 바이트를 ZIP 아카이브에 씁니다. 고유한 아카이브 이름은 동시 내보내기 작업을 구분합니다. ZIP 항목은 슬래시(`/`)를 사용하고 상대 디렉터리를 유지합니다. 정규화 후 충돌하거나 위험한 이름은 쓰기 전에 전체 패키지를 거부합니다.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP 디렉터리는 성공을 보고하기 전에 닫힘으로써 최종화되었습니다.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

예제는 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html)를 사용해 로컬 아카이브 하나를 작성합니다; 내보내기 프로그램 자체는 느슨한 XAML·이미지 파일을 쓰지 않습니다. 원격 저장소의 경우 수집된 바이트 배열을 업로드하도록 아카이브 작성 단계를 교체하십시오. export-job 식별자와 전체 상대 아티팩트 이름을 블롭 키로 사용하거나, 작업 식별자·상대 이름·바이너리 데이터를 데이터베이스 행에 저장하십시오. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에만 작업을 게시하고, 영구 저장이 실패하면 부분 출력을 정리하십시오.

대용량 프레젠테이션의 경우 사용자 지정 저장소가 각 아티팩트를 직접 애플리케이션 저장소에 영구화하도록 하여 전체 내보내기를 메모리에 추가 복사하지 않도록 할 수 있습니다. 내보내기 프로그램 입장에서는 각 콜백을 동기식으로 유지하십시오: 대상이 바이트를 받아들인 후에만 반환하고, 오류가 호출자에게 전달되도록 허용하십시오.

### **리소스 이름 보존 및 참조 검증**

- 대상이 요구하는 경우 경로 구분자를 정규화하되 상대 디렉터리를 보존하십시오. 모든 생성된 이름이 고유하고 리소스 참조가 유효함이 확실한 경우가 아니라면 [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--)만 사용하지 마십시오.
- 대상별 이름 검증을 적용하십시오. 느슨한 파일을 쓸 때는 루트 경로나 경로 탐색 구문을 거부하고, [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--)로 목적지를 확인한 뒤 의도된 내보내기 디렉터리 하위에 머무는지 검증하십시오(포함 여부 검사에 디렉터리 구분자를 포함). 심볼릭 링크가 쓰기를 리다이렉트할 수 없는 애플리케이션 제어 디렉터리를 사용하십시오.
- 각 내보내기 작업마다 별도 저장소와 네임스페이스를 사용하십시오. 구분자 정규화 후와 대상의 대소문자 구분 규칙에 따라 충돌을 감지하십시오.
- 게시 전에 각 XAML 문서를 XML로 파싱하고 `Source` 또는 `ImageSource`와 같은 파일 기반 리소스 참조를 검사하십시오. 각 상대 URI를 포함하는 XAML 아티팩트 디렉터리 기준으로 해결하고, 결과 저장 이름을 정규화한 뒤 해당 map 키, ZIP 항목 또는 저장 객체가 존재하는지 확인하십시오. 외부 URI와 XAML 마크업 표현식은 상대 파일 이름과 별도로 취급하십시오.

예를 들어 `pres/Slide_1.xaml`이 `images/image1.png`를 참조한다면 저장된 리소스는 `pres/images/image1.png`에 있어야 합니다. `image1.png`만 보관하면 관계가 깨집니다. 객체 저장소의 경우 작업 접두사 아래에 동일한 레이아웃을 유지하고 해당 리소스 URL을 XAML 소비자가 접근할 수 있게 하십시오. 완료된 ZIP을 다시 열어 항목 이름과 리소스 바이트를 검증하고, 대상 XAML 환경에서 대표 슬라이드를 로드해 이미지가 올바르게 해석되는지 확인하십시오.

## **자주 묻는 질문**

**원본 폰트가 머신에 없을 경우 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/)에서 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-)을 호출하십시오—원본 폰트가 없을 때 내보내기 중 대체 폰트로 사용됩니다. 이것이 생성된 XAML이 대체 폰트를 참조하거나 해당 폰트가 대상 머신에 존재한다는 보장을 제공하지는 않습니다. XAML이 표시되는 환경에 XAML이 참조하는 폰트가 존재하도록 하십시오.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP, Xamarin.Forms와 같은 다른 XAML 스택과의 호환성은 보장되지 않으며, 대상 환경에서 생성된 마크업을 테스트해야 합니다.

**숨겨진 슬라이드가 지원되나요, 그리고 기본적으로 내보내지 않게 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. 필요하지 않다면 [XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/)의 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)를 비활성화하여 이 동작을 제어할 수 있습니다.