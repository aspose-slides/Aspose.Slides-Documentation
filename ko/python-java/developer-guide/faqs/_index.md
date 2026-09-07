---
title: FAQ
type: docs
weight: 340
url: /ko/python-java/faqs/
keywords:
- FAQ
- 프레젠테이션 형식
- 메모리 부족 오류
- 슬라이드 크기
- 텍스트 추출
- 단락 크기
- 표 테두리
- 글꼴
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에 대한 일반적인 질문에 대한 답변을 찾아보세요. 파일 형식, 메모리 사용량, 슬라이드 크기, 텍스트, 표, 이미지 및 글꼴에 대해 포함합니다."
---
## **개요**

이 FAQ는 지원되는 파일 형식, 큰 프레젠테이션의 메모리 사용량, 슬라이드 크기 및 미리 보기, 텍스트 추출, 테이블 테두리, 그림 배치, 그리고 프레젠테이션을 PDF 또는 이미지로 변환할 때의 글꼴 차이점에 대해 다룹니다.

## **자주 묻는 질문**

### **지원되는 파일 형식**

**Aspose.Slides for Python via Java가 지원하는 파일 형식은 무엇입니까?**

지원되는 프레젠테이션, 문서 및 이미지 형식과 해당 가져오기 및 내보내기 기능에 대해서는 [지원되는 파일 형식](/slides/ko/python-java/supported-file-formats/)를 참조하십시오.

### **예외**

**이미지가 포함된 큰 프레젠테이션을 로드할 때 메모리 부족 오류가 발생하는 이유는 무엇입니까? 파일 크기 제한이 있습니까?**

단일 파일 크기 임계값은 프레젠테이션이 메모리에 적합한지 여부를 예측하지 못합니다. 메모리 요구량은 프레젠테이션 구조, 압축 해제된 이미지, 효과 및 수행하는 작업에 따라 다릅니다. 이미지는 디스크에 압축된 크기보다 훨씬 많은 메모리를 차지할 수 있습니다.

Aspose.Slides for Python via Java는 JPype를 통해 Java 엔진을 사용하므로 JVM 힙에 충분한 공간이 있어야 합니다. 시스템 RAM만으로는 JVM이 사용할 수 있는 메모리를 판단할 수 없습니다. 사용이 끝난 후에는 [Presentation.dispose](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#dispose)로 프레젠테이션을 해제하십시오. 환경 설정에 대해서는 [System Requirements](/slides/ko/python-java/system-requirements/)와 [Installation](/slides/ko/python-java/installation/)을 참조하십시오.

### **슬라이드 작업**

**프레젠테이션의 슬라이드 크기를 변경할 수 있습니까?**

예. [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getslidesize)으로 슬라이드 크기 설정에 접근한 다음, [SlideSize.setSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesize/#setsize)으로 차원을 지정하고 기존 콘텐츠가 어떻게 스케일링될지 선택할 수 있습니다.

**동일한 프레젠테이션의 슬라이드가 서로 다른 크기를 가질 수 있습니까?**

아니오. Microsoft PowerPoint 문서는 슬라이드 크기를 프레젠테이션 수준에서 정의하므로 모든 슬라이드가 동일한 차원을 공유합니다.

**프레젠테이션을 저장하기 전에 슬라이드를 미리 볼 수 있습니까?**

예. 슬라이드를 이미지로 렌더링하고 해당 이미지를 애플리케이션에 표시하면 됩니다. 프레젠테이션을 먼저 저장할 필요는 없습니다.

### **텍스트 작업**

**프레젠테이션에서 모든 텍스트를 가져올 수 있습니까?**

예. [SlideUtil](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideutil/) 클래스는 프레젠테이션 및 개별 슬라이드에서 텍스트를 추출하는 메서드를 제공합니다.

**Windows와 Linux에서 단락 크기가 다른 이유는 무엇입니까?**

단락 차원은 텍스트를 렌더링하는 글꼴의 메트릭에 따라 달라집니다. 글꼴이 없을 경우 대체 글꼴이 다른 문자 너비와 줄 높이를 가질 수 있어 줄 바꿈과 단락 차원이 변합니다. 두 시스템에 동일한 글꼴을 설치하거나 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadexternalfonts)로 동일한 글꼴 파일을 로드하십시오.

### **서식 및 이미지**

**테이블 테두리 색상을 어떻게 설정합니까?**

[Cell.getCellFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cell/#getcellformat)으로 각 셀의 테두리 서식을 접근하고 해당 테두리의 채우기 색을 설정합니다. 모든 테두리를 변경하려면 모든 셀을 처리하고, 테이블 외곽선만 변경하려면 가장자리 셀의 바깥쪽 테두리만 업데이트하십시오.

**그림의 위치와 크기를 지정할 때 사용하는 단위는 무엇입니까?**

도형의 좌표와 차원은 포인트 단위로 측정됩니다. 1인치는 72포인트이며, 이는 픽셀 좌표가 아닙니다.

### **글꼴 작업**

**프레젠테이션을 PDF 또는 이미지로 변환할 때 글꼴이 바뀌는 이유는 무엇입니까?**

변환을 수행하는 머신에 필요한 글꼴이 없을 수 있습니다. 원본 글꼴을 설치하거나 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/#loadexternalfonts)로 글꼴이 포함된 폴더를 추가하십시오. 프레젠테이션을 만들거나 열기 전에 외부 글꼴을 로드해야 합니다.

다음 예제는 글꼴 폴더를 등록합니다. 경로를 실제 글꼴 파일이 들어 있는 폴더로 바꾸십시오. 이 예제는 [Installation](/slides/ko/python-java/installation/)에 설명된 환경을 전제로 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

예제는 이후 프레젠테이션 작업을 위해 JVM을 계속 실행시킵니다. 노트북 사용 및 JVM 수명 주기 제한에 대해서는 [Limitations and API Differences](/slides/ko/python-java/limitations-and-api-differences/)를 참고하십시오.