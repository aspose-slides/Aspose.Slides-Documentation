---
title: OleObjectFrame 추가 시 객체 미리보기 자리 표시자
linktitle: OLE 미리보기 자리 표시자
type: docs
weight: 10
url: /ko/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 미리보기 문제
- 미리보기 자리 표시자
- 설계상
- 임베드 객체
- 임베드 파일
- 객체 변경
- 객체 미리보기
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 추가된 OLE 객체가 미리보기가 업데이트될 때까지 'EMBEDDED OLE OBJECT' 자리 표시자를 표시하는 이유와 자체 미리보기 이미지를 설정하는 방법."
---
## **소개**

Aspose.Slides for Java를 사용하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/oleobjectframe/)을 추가하면 출력 슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 표시됩니다. 이 메시지는 의도된 것이며 버그가 아닙니다.

OLE 객체 작업에 대한 자세한 내용은 [Manage OLE](/slides/ko/java/manage-ole/)를 참조하십시오.

## **설명 및 해결책**

Aspose.Slides는 OLE 객체가 변경되었고 미리보기 이미지가 업데이트되어야 함을 알리기 위해 "EMBEDDED OLE OBJECT" 메시지를 표시합니다.

예를 들어 Microsoft Excel 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/oleobjectframe/)으로 슬라이드에 추가하고(자세한 내용은 "Manage OLE" 문서를 참고) Microsoft PowerPoint에서 프레젠테이션을 열면 슬라이드에 다음 이미지가 표시됩니다:

![OLE 객체 메시지](OLE_object_message.png)

슬라이드에 OLE 객체가 추가됐는지 확인하려면 "EMBEDDED OLE OBJECT" 메시지를 두 번 클릭하거나 마우스 오른쪽 버튼을 클릭한 후 **Object > Edit** 옵션을 선택하면 됩니다.

![OLE 객체 > 편집](OLE_object_edit.png)

PowerPoint가 임베드된 OLE 객체를 엽니다.

![OLE 객체 데이터](OLE_object_data.png)

슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 남아 있을 수 있습니다. OLE 객체를 클릭하면 슬라이드 미리보기가 업데이트되어 "EMBEDDED OLE OBJECT" 메시지가 실제 OLE 객체 이미지로 교체됩니다.

![OLE 객체 미리보기](OLE_object_preview.png)

이제 프레젠테이션을 저장하여 OLE 객체 이미지가 올바르게 업데이트되었는지 확인할 수 있습니다. 이렇게 하면 프레젠테이션을 다시 열었을 때 "EMBEDDED OLE OBJECT" 메시지를 보지 않게 됩니다.

## **다른 해결책**

PowerPoint에서 프레젠테이션을 열고 저장하여 "EMBEDDED OLE OBJECT" 메시지를 제거하고 싶지 않은 경우, 원하는 미리보기 이미지로 메시지를 교체할 수 있습니다. 아래 코드는 그 과정을 보여줍니다. 이 코드는 *embeddedOLE.pptx*의 첫 번째 슬라이드 첫 번째 도형이 OLE 객체 프레임이며 *myImage.png*에 표시할 이미지가 있다고 가정하고, 결과를 *embeddedOLE-newImage.pptx*로 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 프레젠테이션 리소스에 이미지를 추가합니다.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // OLE 객체 미리보기를 위한 이미지를 설정합니다.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`OleObjectFrame`이 포함된 슬라이드는 다음과 같이 변경됩니다:

![새 OLE 객체 이미지](OLE_object_new_image.png)