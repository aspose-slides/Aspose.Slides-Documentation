---
title: Java에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 정밀도에 대한 메모를 포함한 Java 예제가 제공됩니다."
---
## **개요**

PPT는 레거시 이진 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for Java는 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 파일 하나 또는 디렉터리의 파일들을 변환하는 방법을 보여주며 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX로 변환**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스와 함께 로드한 다음, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/#Pptx)와 함께 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 호출합니다. `finally` 블록은 프레젠테이션을 해제하고 리소스를 반환합니다.

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

파일 확장자는 자체적으로 출력 형식을 선택하지 않으며, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/#Pptx) 인수가 이를 결정합니다. 원본 PPT 파일을 보관해야 하는 경우 입력 및 출력 경로를 다르게 유지하십시오.

## **여러 PPT 파일 변환**

다음 예제는 하나의 디렉터리 내 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환 실패가 전체 배치를 중단하지 않습니다.

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

프로덕션 환경에서는 전체 예외를 로그에 기록하고, 기존 출력 파일을 덮어쓸지 여부를 판단하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 필수 비밀번호 없이 열려진 암호 보호 파일, 접근할 수 없는 경로, 지원되지 않는 콘텐츠 등은 변환 실패를 초래할 수 있습니다. 암호화된 파일을 로드하는 방법은 [Password-Protected Presentations](/java/password-protected-presentation/)를 참조하십시오.

## **정밀도 및 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 유지합니다. 그러나 PPT와 PPTX는 모든 기능을 정확히 동일하게 표현하지는 않습니다. PPTX에 해당하는 것이 없거나 라이브러리에서 지원되지 않는 레거시 기능은 정상화되거나, 생략되거나, 다르게 표시될 수 있습니다.

변환된 파일에 애니메이션, 전환 효과, 포함되거나 링크된 OLE 개체, ActiveX 컨트롤, 포함된 미디어, 일반적이지 않은 글꼴 또는 VBA 매크로가 포함된 경우 확인하십시오. 일반 PPTX 파일은 매크로 사용이 가능한 형식이 아니므로 VBA를 유지해야 할 경우 적절한 매크로 사용 워크플로를 사용하십시오. 또한 변환된 프레젠테이션이 열리거나 렌더링될 환경에 필요한 글꼴 및 외부 리소스가 존재하는지도 확인하십시오.

중요한 문서의 경우, 생성된 PPTX를 프로그래matically 다시 열어 핵심 슬라이드 수와 내용을 검사한 뒤, 의도한 뷰어에서 외관 및 슬라이드 쇼 동작을 비교하십시오. 성공적인 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 호출이 모든 레거시 기능이 정확히 PPTX로 변환되었다는 증거로 간주되지 않도록 하십시오.

## **PPTX를 사용해야 하는 경우**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나 Open XML 패키지를 사용하는 시스템과 교환하거나 레거시 이진 PPT보다 검사 및 복구가 쉬운 형식으로 저장하려는 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검사를 통과할 때까지 원본 PPT를 보관 및 롤백 사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요한 경우, 모든 대상이 편집 가능한 PowerPoint 기능을 유지한다는 가정 대신 [Convert Presentations to Multiple Formats](/java/convert-presentation/)에 있는 형식 별 가이드를 사용하십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하려면 [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)를 사용할 수 있습니다. 반복 가능한 변환, 배치 처리, 또는 애플리케이션 수준 오류 처리를 위해서는 Java API를 사용하십시오.

## **관련 기사**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Java에서 프레젠테이션 저장](/java/save-presentation/)
- [지원되는 파일 형식](/java/supported-file-formats/)
- [Java에서 프레젠테이션 열기](/java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint가 설치되지 않은 상태에서 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for Java는 Microsoft PowerPoint가 없어도 프레젠테이션 파일을 로드하고 저장합니다.

**PPT에서 PPTX로의 변환이 모든 콘텐츠를 정확히 보존합니까?**

일반적인 프레젠테이션 콘텐츠는 보존하지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 정밀도가 보장되는 것은 아닙니다. 매크로, OLE 또는 ActiveX 개체, 미디어, 특수 애니메이션 또는 일반적이지 않은 글꼴이 포함된 경우 생성된 파일을 검토하십시오.

**암호로 보호된 PPT 파일을 변환할 수 있나요?**

예, 파일을 로드할 때 올바른 비밀번호를 제공하면 가능합니다. 비밀번호가 없거나 올바르지 않으면 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 할까요?**

중요한 뷰어와 워크플로에서 PPTX를 검증할 때까지 원본을 유지하십시오. 레거시 기능이 다르게 변환될 경우 롤백 사본을 제공하기 위함입니다.