---
title: OleObjectFrame 추가 시 객체 미리 보기 문제
linktitle: OLE 객체 문제
type: docs
weight: 10
url: /ko/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 미리 보기 문제
- 임베드 객체
- 임베드 파일
- 객체 변경됨
- 객체 미리 보기
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 OleObjectFrame을 추가할 때 'EMBEDDED OLE OBJECT'가 나타나는 이유와 PPT, PPTX 및 ODP 프레젠테이션에서 미리 보기 문제를 해결하는 방법을 알아보세요."
---
## **소개**

Aspose.Slides for Java를 사용하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/oleobjectframe/)을 추가하면 출력 슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 표시됩니다. 이 메시지는 의도된 것이며 버그가 아닙니다.

OLE 개체 작업에 대한 자세한 내용은 [Manage OLE](/slides/ko/java/manage-ole/)를 참고하십시오.

## **설명 및 해결책**

Aspose.Slides는 OLE 개체가 변경되었으며 미리 보기 이미지가 업데이트되어야 함을 알리기 위해 "EMBEDDED OLE OBJECT" 메시지를 표시합니다.

예를 들어 Microsoft Excel 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/oleobjectframe/)으로 슬라이드에 추가하고(자세한 내용은 "Manage OLE" 문서 참조) Microsoft PowerPoint에서 프레젠테이션을 열면 슬라이드에 다음과 같은 이미지가 표시됩니다:

![OLE object message](OLE_object_message.png)

OLE 개체가 슬라이드에 추가되었는지 확인하려면 "EMBEDDED OLE OBJECT" 메시지를 더블 클릭하거나 마우스 오른쪽 버튼을 클릭한 뒤 **Object > Edit** 옵션을 선택하면 됩니다.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint가 임베드된 OLE 개체를 엽니다.

![OLE object data](OLE_object_data.png)

슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 남아 있을 수 있습니다. OLE 개체를 클릭하면 슬라이드 미리 보기가 업데이트되고 "EMBEDDED OLE OBJECT" 메시지가 실제 OLE 개체 이미지로 교체됩니다.

![OLE object preview](OLE_object_preview.png)

이제 프레젠테이션을 저장하여 OLE 개체 이미지가 올바르게 업데이트되도록 할 수 있습니다. 이렇게 하면 프레젠테이션을 저장한 후 다시 열었을 때 "EMBEDDED OLE OBJECT" 메시지가 표시되지 않습니다.

## **다른 해결책**

### **해결책 1: "Embedded OLE Object" 메시지를 이미지로 교체**

PowerPoint에서 프레젠테이션을 열고 저장하여 "EMBEDDED OLE OBJECT" 메시지를 제거하고 싶지 않은 경우, 메시지를 원하는 미리 보기 이미지로 교체할 수 있습니다. 아래 코드가 그 과정을 보여줍니다:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 프레젠테이션 리소스에 이미지를 추가합니다.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // OLE 객체 미리 보기에 대한 제목과 이미지를 설정합니다.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

`OleObjectFrame`이 포함된 슬라이드는 다음과 같이 변경됩니다:

![New OLE object image](OLE_object_new_image.png)

### **해결책 2: PowerPoint용 애드온 만들기**

Microsoft PowerPoint용 애드온을 만들어 프레젠테이션을 열 때 모든 OLE 개체를 업데이트하도록 할 수도 있습니다.