---
title: Java에서 프레젠테이션 정보 검색 및 업데이트
linktitle: 프레젠테이션 정보
type: docs
weight: 30
url: /ko/java/examine-presentation/
keywords:
- 프레젠테이션 형식
- 프레젠테이션 속성
- 문서 속성
- 속성 가져오기
- 속성 읽기
- 속성 변경
- 속성 수정
- 속성 업데이트
- PPTX 검사
- PPT 검사
- ODP 검사
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조 및 메타데이터를 탐색하고 더 빠른 인사이트와 보다 스마트한 콘텐츠 감사를 수행합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션 형식을 식별하고 전체 프레젠테이션 객체 모델을 생성하지 않고도 문서 메타데이터를 읽을 수 있습니다. 이는 파일을 분류하거나, 인벤토리를 작성하거나, 프레젠테이션 콘텐츠를 로드하고 처리하기 전에 속성을 검사해야 할 때 유용합니다.

이 문서에서는 [PresentationFactory](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/)와 [IPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/)를 사용한 경량 검사와 [IDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/)를 사용한 특정 업데이트 방법을 보여줍니다.

## **프레젠테이션 형식 확인**

이미 로드된 프레젠테이션이 있는 경우, 로드 후 형식을 감지하고 레거시 PPT, PPS 및 POT 스트림의 제한 사항을 확인하려면 [Determine the Original Presentation Format](/slides/ko/java/detect-presentation-source-format/)를 참조하십시오.

파일을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 만들지 않고 검사하려면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)를 사용합니다. [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) 메서드는 PPTX, PPT 또는 ODP와 같은 감지된 형식을 보고합니다.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **경량 프레젠테이션 인벤토리 구축**

많은 프레젠테이션 파일을 처리할 때 검증, 인덱싱 또는 문서 관리 시스템을 위한 간결한 인벤토리가 필요할 수 있습니다. 이 경우 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)를 사용하여 [IPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/) 객체를 얻은 다음 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)를 호출하여 문서 메타데이터를 읽습니다. 이 방법은 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 생성하거나 전체 프레젠테이션 객체 모델을 탐색할 필요가 없습니다.

IDocumentProperties가 제공하는 확장 속성은 다음 인벤토리 값을 제공합니다:

| 메서드 | 인벤토리 값 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getSlides--) | 전체 슬라이드 수. |
| [getHiddenSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | 숨겨진 슬라이드 수. |
| [getNotes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getNotes--) | 노트가 포함된 슬라이드 수. |
| [getParagraphs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | 가능한 경우 전체 단락 수. |
| [getWords](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getWords--) | 전체 단어 수. |
| [getMultimediaClips](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | 오디오 및 비디오 클립 총 수. |

다음 예제는 이러한 값을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 객체를 만들지 않고 읽어 간결한 인벤토리를 출력합니다. 또한 [getHeadingPairs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--)와 [getTitlesOfParts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--)를 결합하여 글꼴, 테마 및 슬라이드 제목과 같은 콘텐츠 그룹을 표시합니다.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

각 [IHeadingPair](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iheadingpair/)는 그룹 이름과 해당 그룹의 항목 수를 제공합니다. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--)는 평면, 정렬된 배열을 반환하므로 각 헤딩 페어가 지정한 연속 제목 수만큼 사용합니다.

### **저장된 메타데이터 및 형식 제한 사항**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)가 반환하는 인벤토리 속성은 원본 문서에 있는 메타데이터를 반영합니다. Aspose.Slides는 이 호출을 위해 프레젠테이션 객체 모델을 로드하고 탐색하지 않으며, 누락된 속성은 기본값으로 표시되고, 마지막 저장 시 문서 속성이 업데이트되지 않은 경우 저장된 값이 오래될 수 있습니다.

- **PPTX:** 형식은 슬라이드, 노트, 숨김 슬라이드, 단락, 단어 및 멀티미디어 개수와 헤딩 페어 및 파트 제목에 대한 확장 문서 속성을 제공합니다. 가용성은 문서 작성자가 어떤 속성을 기록했는지에 따라 다릅니다.
- **PPT:** 이진 형식은 해당 문서 요약 속성을 저장할 수 있습니다. 속성이 없거나 문서 작성자가 새로 고치지 않은 경우, Aspose.Slides는 슬라이드에서 계산하지 않고 저장된 값 또는 기본값을 반환합니다.
- **ODP:** OpenDocument 메타데이터는 페이지, 단락 및 단어 수와 같은 일반 문서 통계를 제공합니다. 그러나 이러한 값은 모든 PowerPoint 전용 확장 속성과 매핑되지 않을 수 있습니다. 숨김 슬라이드, 노트 슬라이드, 멀티미디어, 헤딩 페어 및 파트 제목 메타데이터는 없을 수 있으며, 인벤토리 속성은 기본값을 반환할 수 있습니다. 0값이나 빈 배열을 해당 콘텐츠가 없다는 절대적인 증거로 간주하지 마십시오.

경량 메타데이터 방식을 인벤토리 및 사전 검증에 사용하십시오. 결과가 메모리 내 변경을 반영해야 하거나 실제 프레젠테이션 콘텐츠를 확인해야 할 경우 프레젠테이션을 로드하고 실시간 객체 모델을 검사하십시오.

## **프레젠테이션 속성 업데이트**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)가 반환하는 속성은 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 만들지 않고도 변경할 수 있습니다. 변경 사항은 [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)를 사용해 적용하고, [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-)으로 바인딩된 프레젠테이션을 저장합니다.

다음 이미지는 원본 문서 속성을 보여줍니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

다음 예제는 제목과 마지막 저장 시간을 변경하고 결과를 새 파일에 씁니다:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

다음 이미지는 변경된 문서 속성을 보여줍니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

관련 보안 검사 및 보호 설정에 대해서는 다음 문서를 참조하십시오:

- [프레젠테이션 비밀번호 보호](/slides/ko/java/password-protected-presentation/)
- [프레젠테이션 쓰기 보호](/slides/ko/java/write-protected-presentation/)

## **FAQ**

**폰트가 포함되어 있는지 및 포함된 폰트 목록을 확인하려면 어떻게 해야 하나요?**

프레젠테이션을 로드하고 [Presentation.getFontsManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getFontsManager--)를 사용합니다. [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--)를 호출하여 포함된 폰트를 얻고, [IFontsManager.getFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getFonts--)를 호출하여 프레젠테이션에서 사용되는 폰트를 얻습니다. 두 결과를 비교하여 렌더링에 필요하지만 포함되지 않은 폰트를 찾습니다.

**파일에 숨겨진 슬라이드가 있는지 및 개수를 빠르게 확인하려면 어떻게 해야 하나요?**

저장된 문서 메타데이터가 충분하면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)와 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)를 통해 [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--)를 읽습니다. 이는 경량 인벤토리에 적합합니다. 프레젠테이션이 메모리에서 수정되었거나 실시간 값을 확인해야 하는 경우 [Presentation.getSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSlides--)를 반복하고 각 슬라이드의 [ISlide.getHidden](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#getHidden--) 메서드를 검사합니다.

**사용자 지정 슬라이드 크기와 방향이 사용되는지, 그리고 기본값과 다른지 감지할 수 있나요?**

예. 프레젠테이션을 로드하고 [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSlideSize--)를 호출합니다. [ISlideSize.getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidesize/#getSize--), [ISlideSize.getOrientation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidesize/#getOrientation--)을 사용하여 현재 설정을 예상 프리셋 및 차원과 비교합니다.

**차트가 외부 데이터 소스를 참조하는지 빠르게 확인하는 방법이 있나요?**

예. 각 [Chart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chart/)를 찾아 [IChartData.getDataSourceType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#getDataSourceType--)을 호출합니다. 외부 워크북인 경우 [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)를 호출합니다. 데이터 소스 유형과 경로가 외부 참조를 나타내지만, 대상이 사용 가능한지는 별도의 리소스 확인이 필요합니다.

**'무거운' 슬라이드가 렌더링 또는 PDF 내보내기를 느리게 할 수 있는지 평가하려면 어떻게 해야 하나요?**

단일 복잡성 속성은 없습니다. [Presentation.getSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSlides--)와 각 슬라이드의 [IBaseSlide.getShapes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseslide/#getShapes--) 컬렉션을 탐색합니다. 형태 수와 큰 이미지, 효과, 애니메이션 또는 멀티미디어 존재 여부를 신호로 사용하고, 대표적인 렌더링 또는 내보내기 성능을 측정한 후 슬라이드를 성능 병목으로 확인합니다.