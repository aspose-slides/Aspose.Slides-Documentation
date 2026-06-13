---
title: Python에서 도형 잠금으로 프레젠테이션 편집 방지
linktitle: 프레젠테이션 편집 방지
type: docs
weight: 70
url: /ko/python-net/applying-protection-to-presentation/
keywords:
- 편집 방지
- 편집으로부터 보호
- 도형 잠금
- 위치 잠금
- 선택 잠금
- 크기 잠금
- 그룹화 잠금
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET가 PPT, PPTX 및 ODP 파일의 도형을 잠그거나 잠금 해제하는 방법을 확인하고, 프레젠테이션을 보호하면서 제어된 편집과 빠른 전달을 가능하게 합니다."
---
## **배경**

Aspose.Slides의 일반적인 사용 사례는 자동화된 워크플로의 일부로 Microsoft PowerPoint(PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 이러한 방식으로 Aspose.Slides를 사용하는 애플리케이션의 사용자는 생성된 프레젠테이션에 접근할 수 있으므로 편집으로부터 보호하는 것이 일반적인 고민입니다. 자동으로 생성된 프레젠테이션은 원본 서식과 내용을 유지하는 것이 중요합니다.

이 문서는 프레젠테이션 및 슬라이드가 어떻게 구성되는지와 Aspose.Slides for Python이 프레젠테이션에 보호를 적용하고 나중에 해제하는 방법을 설명합니다. 이를 통해 개발자는 애플리케이션이 생성한 프레젠테이션이 어떻게 사용되는지를 제어할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 커넥터 및 프레젠테이션을 구성하는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for Python에서는 슬라이드의 각 요소가 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 클래스를 상속하는 객체로 표현됩니다.

PPTX의 구조는 복잡하기 때문에 모든 종류의 도형에 대해 일반 잠금을 사용할 수 있는 PPT와 달리, 도형 유형마다 다른 잠금이 필요합니다. [BaseShapeLock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseshapelock/) 클래스는 PPTX용 일반 잠금 클래스입니다. Aspose.Slides for Python이 PPTX에서 지원하는 잠금 유형은 다음과 같습니다:

- [AutoShapeLock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshapelock/)는 자동 도형을 잠급니다.  
- [ConnectorLock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/connectorlock/)는 커넥터 도형을 잠급니다.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/graphicalobjectlock/)는 그래픽 개체를 잠급니다.  
- [GroupShapeLock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshapelock/)는 그룹 도형을 잠급니다.  
- [PictureFrameLock](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframelock/)는 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체 내 모든 도형 객체에 수행된 작업은 전체 프레젠테이션에 적용됩니다.

## **보호 적용 및 해제**

보호를 적용하면 프레젠테이션을 편집할 수 없게 됩니다. 이는 프레젠테이션 내용을 보호하는 유용한 기술입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Python은 슬라이드의 도형을 작업하기 위해 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 클래스를 제공합니다.

앞서 언급했듯이 각 도형 클래스에는 보호를 위한 해당 도형 잠금 클래스가 연결되어 있습니다. 이 문서에서는 NoSelect, NoMove, NoResize 잠금에 중점을 둡니다. 이러한 잠금은 도형을 마우스 클릭이나 기타 선택 방법으로 선택할 수 없으며, 이동하거나 크기를 변경할 수 없도록 보장합니다.

다음 코드 샘플은 프레젠테이션의 모든 도형 유형에 보호를 적용합니다.

```py
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("Sample.pptx") as presentation:
    # 프레젠테이션의 모든 슬라이드를 순회합니다.
    for slide in presentation.slides:
        # 슬라이드의 모든 도형을 순회합니다.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # 프레젠테이션 파일을 저장합니다.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **보호 해제**

도형의 잠금을 해제하려면 적용된 잠금 값을 `False` 로 설정합니다. 다음 코드 샘플은 잠긴 프레젠테이션에서 도형을 해제하는 방법을 보여줍니다.

```py
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # 프레젠테이션의 모든 슬라이드를 순회합니다.
    for slide in presentation.slides:
        # 슬라이드의 모든 도형을 순회합니다.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # 프레젠테이션 파일을 저장합니다.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **결론**

Aspose.Slides는 프레젠테이션의 도형을 보호할 수 있는 여러 옵션을 제공합니다. 개별 도형을 잠그거나 프레젠테이션의 모든 도형을 순회하면서 각각을 잠가 전체 파일을 효과적으로 보호할 수 있습니다. 잠금 값을 `False` 로 설정하면 보호를 해제할 수 있습니다.

## **FAQ**

**같은 프레젠테이션에서 도형 잠금과 비밀번호 보호를 결합할 수 있나요?**

예. 잠금은 파일 내부 개체의 편집을 제한하고, [password protection](/slides/ko/python-net/password-protected-presentation/)은 열기 및/또는 변경 사항 저장에 대한 접근을 제어합니다. 이러한 메커니즘은 서로 보완하며 함께 작동합니다.

**다른 슬라이드에 영향을 주지 않고 특정 슬라이드만 편집을 제한할 수 있나요?**

예. 선택한 슬라이드의 도형에 잠금을 적용하면, 나머지 슬라이드는 편집 가능 상태를 유지합니다.

**도형 잠금이 그룹화된 개체와 커넥터에도 적용되나요?**

예. 그룹, 커넥터, 그래픽 개체 및 기타 도형 유형에 대해 별도의 잠금 유형이 지원됩니다.