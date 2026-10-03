---
title: Java에서 PowerPoint 프레젠테이션을 XML로 변환
linktitle: PowerPoint를 XML로
type: docs
weight: 145
url: /ko/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint를 XML로 변환
- 프레젠테이션을 XML로 변환
- PPT를 XML로
- PPTX를 XML로
- ODP를 XML로
- PowerPoint XML 프레젠테이션
- SaveFormat.Xml
- 프레젠테이션을 XML로 저장
- 프레젠테이션을 XML로 내보내기
- XML 스트림
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 Java에서 PowerPoint XML 파일 또는 스트림으로 변환합니다."
---
## **개요**

Aspose.Slides for Java는 PowerPoint 프레젠테이션을 PowerPoint XML Presentation 형식으로 변환할 수 있습니다. XML 출력은 프레젠테이션 구조를 검사하거나 생성된 문서를 문제 해결, 자동화된 테스트에서 출력 비교, 또는 프레젠테이션 패키지가 아닌 XML을 소비하는 워크플로와 통합해야 할 때 텍스트 기반 표현이 필요할 경우에 유용합니다.

[Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용하고, [SaveFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/) 클래스의 `Xml` 값을 전달합니다. 결과를 파일에 직접 쓰거나 스트림에 쓸 수 있습니다.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml`은 PowerPoint XML Presentation을 생성합니다. 이것은 PPTX 패키지 내부에 저장된 개별 Office Open XML 파트를 추출하지 않습니다. `ppt/presentation.xml`과 같은 정확한 PPTX 패키지 파트나 개별 슬라이드 XML 파일이 필요하면 PPTX 패키지를 직접 검사하십시오.
{{% /alert %}}

## **프레젠테이션을 XML 파일로 변환**

[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스로 소스 프레젠테이션을 로드한 다음, 출력 경로와 `SaveFormat.Xml`을 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-)에 전달합니다. 소스는 PPT, PPTX, ODP 등 로드가 지원되는 모든 프레젠테이션 형식일 수 있습니다.

다음 예제는 PPTX 프레젠테이션을 XML 파일로 변환합니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML 출력을 스트림에 기록**

XML을 메모리에 유지하거나 웹 서비스, 스토리지 제공자, XML 처리 파이프라인과 같은 다른 구성 요소에 전달해야 할 경우 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)의 스트림 오버로드를 사용합니다. 다음 예제는 결과를 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)으로 기록하고 XML을 바이트 배열로 얻습니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // xmlData를 워크플로의 다음 구성 요소에 전달합니다.
} finally {
    presentation.dispose();
}
```

## **XML을 프레젠테이션 및 내보내기 형식과 비교**

결과 활용 방식에 따라 출력 형식을 선택하십시오:

| 형식 | 출력 | 일반적인 사용 사례 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 프레젠테이션 | 구조 검사, 문제 해결, 생성된 출력 비교, XML 기반 통합 |
| PPT (`.ppt`) | 레거시 바이너리 프레젠테이션 파일 | 오래된 PowerPoint 워크플로와의 호환성 |
| PPTX (`.pptx`) | 여러 파트를 포함하는 Office Open XML 패키지 | 일반 PowerPoint 편집 및 프레젠테이션 교환 |
| PDF 또는 TIFF | 고정 레이아웃 페이지 또는 다중 페이지 이미지 | 보기, 인쇄 및 보관 |
| PNG, JPEG 또는 SVG | 개별 슬라이드의 렌더링된 표현 | 썸네일, 미리보기 및 이미지 자산 |
| HTML 또는 HTML5 | 웹 지향 프레젠테이션 출력 | 브라우저 보기 및 웹 게시 |

PPT 및 PPTX와 달리 XML 출력은 주로 검사 및 데이터 중심 워크플로를 위해 설계되었습니다. PDF, TIFF, HTML 및 슬라이드 이미지 형식과는 달리 슬라이드를 페이지나 시각적 자산으로 렌더링하지 않고 프레젠테이션 데이터를 나타냅니다. [지원 파일 형식](/slides/ko/java/supported-file-formats/) 표는 Aspose.Slides가 로드, 가져오기, 저장 또는 렌더링할 수 있는 모든 형식을 나열합니다.

## **FAQ**

**`SaveFormat.Xml`이 PPTX 파일 저장과 동일합니까?**  
아니요. PPTX는 여러 Office Open XML 파트를 포함하는 패키지이며, `SaveFormat.Xml`은 PowerPoint XML Presentation 파일을 생성합니다.

**디스크에 파일을 만들지 않고 XML 출력을 저장할 수 있나요?**  
예. writable 스트림을 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-)에 전달하십시오. 예를 들어, 메모리 내 처리를 위해 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)를 사용할 수 있습니다.

**Aspose.Slides가 내보낸 XML 파일을 다시 로드할 수 있나요?**  
예. XML 파일 또는 스트림을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 생성자에 전달하십시오. 그런 다음 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSourceFormat--)이 `SourceFormat.Xml`을 반환합니다. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)은 이 형식에 대해 `LoadFormat.Unknown`을 보고하므로, XML 파일을 열 수 있는지를 판단하는 기준으로 사용하지 마십시오.

**XML 변환이 각 슬라이드를 페이지나 이미지로 렌더링하나요?**  
아니요. XML 변환은 구조화된 프레젠테이션 데이터를 기록합니다. 페이지 지향 출력을 위해서는 PDF 또는 TIFF를, 개별 슬라이드 이미지를 위해서는 PNG, JPEG 및 SVG를 사용하십시오.