---
title: OleObjectFrame 추가 시 객체 미리보기 문제
linktitle: OLE 객체 문제
type: docs
weight: 10
url: /ko/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 미리보기 문제
- 임베드된 객체
- 임베드된 파일
- 객체 변경
- 객체 미리보기
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 OleObjectFrame을 추가할 때 EMBEDDED OLE OBJECT가 표시되는 이유와 PPT, PPTX 및 ODP 프레젠테이션에서 미리보기 문제를 해결하는 방법을 알아보세요."
---
## **소개**

Aspose.Slides for Python via Java를 사용하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)를 추가하면 출력 슬라이드에 “EMBEDDED OLE OBJECT” 메시지가 표시됩니다. 이 메시지는 의도된 것으로 버그가 아닙니다.

OLE 객체 작업에 대한 자세한 내용은 [OLE 관리](/slides/ko/python-java/manage-ole/)를 참고하십시오.

## **설명 및 해결 방법**

Aspose.Slides는 OLE 객체가 변경되었으며 미리보기 이미지가 업데이트되어야 함을 알리기 위해 “EMBEDDED OLE OBJECT” 메시지를 표시합니다.

예를 들어 Microsoft Excel 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)으로 슬라이드에 추가하고(자세한 내용은 “OLE 관리” 문서 참고) Microsoft PowerPoint에서 프레젠테이션을 열면 슬라이드에 다음과 같은 이미지가 표시됩니다:

![OLE 객체 메시지](OLE_object_message.png)

슬라이드에 OLE 객체가 추가되었는지 확인하려면 “EMBEDDED OLE OBJECT” 메시지를 더블 클릭하거나 마우스 오른쪽 버튼을 클릭하고 **Object > Edit**를 선택하십시오.

![OLE 객체 > 편집](OLE_object_edit.png)

PowerPoint가 임베드된 OLE 객체를 엽니다.

![OLE 객체 데이터](OLE_object_data.png)

슬라이드에 “EMBEDDED OLE OBJECT” 메시지가 계속 남아 있을 수 있습니다. OLE 객체를 클릭하면 슬라이드 미리보기가 업데이트되고 “EMBEDDED OLE OBJECT” 메시지가 OLE 객체의 실제 이미지로 교체됩니다.

![OLE 객체 미리보기](OLE_object_preview.png)

프레젠테이션을 저장하여 업데이트된 OLE 객체 미리보기 이미지를 보존하십시오. 프레젠테이션을 다시 열면 더 이상 “EMBEDDED OLE OBJECT” 메시지가 표시되지 않습니다.

## **다른 해결 방법**

PowerPoint에서 프레젠테이션을 열고 저장하여 “EMBEDDED OLE OBJECT” 메시지를 제거하고 싶지 않은 경우, 원하는 미리보기 이미지로 메시지를 교체할 수 있습니다. 다음 코드는 그 과정을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # 프레젠테이션 리소스에 이미지를 추가합니다.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # OLE 객체 미리보기를 위한 제목과 이미지를 설정합니다.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[OleObjectFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/oleobjectframe/)이 포함된 슬라이드는 다음과 같이 변경됩니다:

![새 OLE 객체 이미지](OLE_object_new_image.png)

## **FAQ**

**“EMBEDDED OLE OBJECT” 메시지는 왜 나타나나요?**

이 메시지는 OLE 객체가 변경되었으며 미리보기 이미지를 업데이트해야 함을 나타냅니다. 이 동작은 의도된 것입니다.

**PowerPoint에서 미리보기를 어떻게 업데이트하나요?**

메시지를 더블 클릭하거나 **Object > Edit**를 선택하여 임베드된 OLE 객체를 엽니다. OLE 객체를 클릭하면 미리보기가 업데이트되고, 그 후 프레젠테이션을 저장하십시오.

**PowerPoint를 열지 않고 메시지를 교체할 수 있나요?**

예. 위의 코드 예제와 같이 원하는 미리보기 이미지를 OLE 객체에 할당하면 됩니다.