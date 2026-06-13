---
title: FAQ
type: docs
weight: 340
url: /ko/java/faqs/
keywords:
- FAQ
- 프레젠테이션 형식
- 메모리 부족 오류
- 슬라이드 크기
- 텍스트 추출
- 텍스트 검색
- 단락 크기
- 표 서식 지정
- 글꼴
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에 대한 FAQ 답변을 제공하며, PowerPoint 및 OpenDocument 지원, 설치 안내, 라이선스, 문제 해결을 다룹니다."
---
## **개요**

이 FAQ는 Aspose.Slides에 대한 일반적인 질문에 대한 답변을 제공합니다. 지원되는 파일 형식, 대형 프레젠테이션 작업 시 예외 처리, 슬라이드 크기 변경, 슬라이드 미리 보기, 프레젠테이션에서 텍스트 검색, 표 테두리 서식 지정, 이미지 배치, 그리고 프레젠테이션을 PDF 또는 이미지로 변환할 때 발생하는 글꼴 관련 문제 해결 등에 대해 다룹니다.

## **지원 파일 형식**

**Q: Aspose.Slides for Java가 지원하는 파일 형식은 무엇입니까?**

**A**: Aspose.Slides for Java는 [Supported File Formats](/slides/ko/java/supported-file-formats/)에 설명된 파일 형식을 지원합니다.

## **예외**

**Q: 이미지가 포함된 큰 PPT 파일을 로드하는 중에 메모리 부족 예외가 발생합니다. Aspose.Slides에 파일 크기 제한이 있습니까?**

**A**: Aspose.Slides에서 지원하는 프레젠테이션 크기를 계산하는 특정 공식은 없습니다. 전체 프레젠테이션 구조와 이미지를 메모리에 담을 수 있을 만큼 충분한 공간이 있어야 합니다. 일반적으로 메모리상의 이미지는 하드 디스크보다 더 많은 공간을 차지하며, 특히 이미지에 추가 효과가 있는 경우에는 더 그렇습니다.

일반적으로 Aspose.Slides for Java는 4 GB RAM을 가진 서버에서 약 300 MB 크기의 프레젠테이션 파일을 손쉽게 처리할 수 있습니다.

## **슬라이드 작업**

**Q: 프레젠테이션의 슬라이드 크기를 변경할 수 있습니까?**

**A**: [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스가 제공하는 `getSlideSize` 메서드를 사용하여 프레젠테이션의 슬라이드 크기를 정의할 수 있습니다.

**Q: 프레젠테이션에서 서로 다른 크기의 슬라이드를 정의할 수 있는 방법이 있습니까?**

**A**: Microsoft PowerPoint 문서에서는 슬라이드 크기가 프레젠테이션 수준에서 정의되므로 이를 달리 할 방법이 없습니다.

**Q: Aspose.Slides for Java는 저장하기 전에 슬라이드를 미리 보기 하는 것을 지원합니까?**

**A**: 프레젠테이션 슬라이드를 이미지로 렌더링한 후, 해당 이미지를 슬라이드 미리 보기용으로 사용할 수 있습니다.

## **텍스트 작업**

**Q: 프레젠테이션에서 모든 텍스트를 검색할 수 있습니까?**

**A**: Aspose.Slides for Java는 프레젠테이션의 전체 텍스트를 검색하기 위한 다양한 메서드를 제공하는 [SlideUtil](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slideutil/) 클래스를 제공합니다.

**Q: Windows와 Linux 운영 체제에서 단락 크기가 다른 이유는 무엇입니까?**

**A**: 단락 크기 계산은 해당 단락을 나타내는 텍스트 크기 계산에 기반합니다. 텍스트 크기 계산은 PowerPoint 프레젠테이션에 지정된 글꼴의 메트릭을 기준으로 합니다. 지정된 글꼴이 없을 경우 가장 유사한 글꼴로 대체되지만, 이 글꼴은 원본과 메트릭이 다릅니다. 따라서 설치된 글꼴 집합에 따라 다른 시스템에서 단락 크기 계산 결과가 달라집니다. 서로 다른 운영 체제에서 동일한 결과를 얻으려면 시스템에 동일한 글꼴을 설치하거나 런타임에 [external fonts](/slides/ko/java/custom-font/)를 로드해야 합니다.

## **서식 및 이미지**

**Q: 표 테두리 색을 어떻게 설정합니까?**

**A**: 표 전체 테두리 색 또는 개별 셀 테두리 색을 변경할 수 있습니다. 모든 테두리를 변경하려면 [ICell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icell/) 인터페이스의 `getCellFormat` 메서드를 사용하십시오. 전체 표의 외곽 테두리를 변경하려면 셀을 순회하면서 외부 테두리 색을 바꾸어야 합니다.

**Q: Aspose.Slides for Java는 그림을 배치할 때 어떤 측정 단위를 사용합니까?**

**A**: 슬라이드에 있는 모든 도형의 좌표와 크기는 포인트(72 dpi) 단위로 측정됩니다.

## **글꼴 작업**

**Q: PPT를 PDF 또는 이미지로 변환할 때 출력 문서의 글꼴이 다른 이유는 무엇입니까?**

**A**: 이 문제는 프레젠테이션에 사용된 글꼴이 코드를 실행한 운영 체제에 없음을 나타낼 수 있습니다. 운영 체제에 해당 글꼴을 설치하거나 아래와 같이 [FontsLoader](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/) 클래스를 사용하여 외부 글꼴로 로드해야 합니다:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```