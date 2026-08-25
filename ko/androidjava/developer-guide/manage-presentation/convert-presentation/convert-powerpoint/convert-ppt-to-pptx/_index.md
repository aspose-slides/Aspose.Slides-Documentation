---
title: Android에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPT를 PPTX로
- PPT를 PPTX로 저장
- PPT를 PPTX로 내보내기
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Android에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 정밀도에 대한 메모를 포함한 Java 예제가 제공됩니다."
---
## **개요**

PPT는 레거시 바이너리 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for Android via Java는 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 단일 파일 또는 파일 디렉터리를 변환하는 방법과 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX 로 변환하기**

[Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스로 원본 파일을 로드한 다음, [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)에 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/#Pptx) 옵션을 전달하여 저장합니다. `finally` 블록에서 프레젠테이션을 해제하고 리소스를 반환합니다.

```java
// 레거시 PPT 프레젠테이션을 로드합니다.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // 프레젠테이션을 PPTX 형식으로 저장합니다.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

파일 확장자만으로 출력 형식이 결정되지 않으며, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/#Pptx) 인수가 그 역할을 합니다. 원본 PPT 파일을 보존해야 한다면 입력 경로와 출력 경로를 다르게 지정하십시오.

## **여러 PPT 파일 변환하기**

다음 예제는 특정 디렉터리의 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환이 실패해도 나머지 배치는 계속 진행됩니다.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

프로덕션 환경에서는 전체 예외 정보를 기록하고, 기존 출력 파일을 덮어쓸지 여부를 판단하며, 실패한 파일명을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 비밀번호가 필요한 암호 보호 파일을 비밀번호 없이 열려는 경우, 접근 불가능한 경로, 지원되지 않는 콘텐츠 등은 변환 오류를 일으킬 수 있습니다. 암호화된 파일 로드에 대한 내용은 [Password-Protected Presentations](/androidjava/password-protected-presentation/)를 참고하십시오.

## **정밀도와 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표, 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 동일하게 표현하지 않으며, PPTX에 해당하지 않거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화, 생략 또는 다른 방식으로 표시될 수 있습니다.

아래와 같은 요소가 포함된 경우 변환된 파일을 확인하십시오: 애니메이션, 전환 효과, 내장 또는 연결된 OLE 개체, ActiveX 컨트롤, 내장 미디어, 비표준 글꼴, VBA 매크로. 일반 PPTX 파일은 매크로를 지원하지 않으므로 VBA가 필요할 경우 매크로 지원 워크플로를 사용하십시오. 또한 변환된 프레젠테이션이 열리거나 렌더링될 환경에 필요한 글꼴 및 외부 리소스가 존재하는지도 확인하십시오.

중요 문서의 경우, 생성된 PPTX를 프로그램matically 다시 열어 주요 슬라이드 수와 내용을 검사하고, 의도한 뷰어에서 외观 및 슬라이드쇼 동작을 비교하십시오. 성공적인 [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 호출이 모든 레거시 기능이 정확히 PPTX로 변환되었다는 증거가 되지 않음을 유념하십시오.

## **PPTX를 사용해야 하는 경우**

현재 버전 PowerPoint에서 편집하거나 Open XML 패키지를 지원하는 시스템과 교환하거나, 레거시 바이너리 PPT보다 검토 및 복구가 쉬운 형식으로 저장하려는 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검증을 통과할 때까지 원본 PPT를 보관하거나 롤백 사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 등 다른 출력 형식이 필요하다면 [Convert Presentations to Multiple Formats](/slides/ko/androidjava/convert-presentation/)에 있는 형식별 가이드를 참고하고, 모든 대상이 편집 가능한 PowerPoint 기능을 유지한다는 가정은 하지 마십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하고 싶을 때는 [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 를 사용할 수 있습니다. 반복 변환, 배치 처리 또는 애플리케이션 수준 오류 처리가 필요하다면 Android via Java API를 사용하십시오.

## **관련 문서**

- [PPT vs PPTX](/slides/ko/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/slides/ko/androidjava/save-presentation/)
- [Supported File Formats](/slides/ko/androidjava/supported-file-formats/)
- [Open Presentations on Android](/slides/ko/androidjava/open-presentation/)

## **FAQ**

**Microsoft PowerPoint가 설치되지 않은 상태에서 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for Android via Java는 Microsoft PowerPoint 없이 프레젠테이션 파일을 로드하고 저장합니다.

**PPT를 PPTX로 변환하면 모든 콘텐츠가 정확히 보존되나요?**

일반적인 프레젠테이션 콘텐츠는 보존되지만, 모든 레거시 또는 지원되지 않는 기능이 정확히 변환된다고 보장할 수 없습니다. 매크로, OLE 또는 ActiveX 개체, 미디어, 특수 애니메이션, 비표준 글꼴이 포함된 경우 변환된 파일을 검토하십시오.

**암호 보호된 PPT 파일을 변환할 수 있나요?**

예. 파일을 로드할 때 올바른 비밀번호를 제공하면 변환이 가능합니다. 비밀번호가 없거나 잘못된 경우 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 하나요?**

원본 PPT 파일은 변환된 PPTX를 뷰어와 워크플로에서 확인하고 검증할 때까지 보관하십시오. 이렇게 하면 레거시 기능이 다르게 변환될 경우 롤백 사본으로 사용할 수 있습니다.