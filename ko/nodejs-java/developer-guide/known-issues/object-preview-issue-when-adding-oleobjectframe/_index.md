---
title: OleObjectFrame 추가 시 객체 미리보기 문제
linktitle: OLE 객체 문제
type: docs
weight: 10
url: /ko/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 미리보기 문제
- 임베드 객체
- 임베드 파일
- 객체 변경
- 객체 미리보기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 OleObjectFrame을 추가할 때 EMBEDDED OLE OBJECT가 표시되는 이유와 PPT, PPTX, ODP 프레젠테이션의 미리보기 문제를 해결하는 방법을 배웁니다."
---
## **소개**

Aspose.Slides for Java를 사용할 때 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/oleobjectframe/)을 추가하면 출력 슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 표시됩니다. 이 메시지는 의도된 것이며 버그가 아닙니다.

OLE 개체 작업에 대한 자세한 내용은 [Manage OLE](/slides/ko/nodejs-java/manage-ole/)를 참조하십시오. 

## **설명 및 해결책**

Aspose.Slides는 OLE 개체가 변경되었으며 미리보기 이미지를 업데이트해야 함을 알리기 위해 "EMBEDDED OLE OBJECT" 메시지를 표시합니다. 

예를 들어, Microsoft Excel 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/oleobjectframe/)으로 슬라이드에 추가하고(자세한 내용은 "Manage OLE" 문서를 참조하십시오) Microsoft PowerPoint에서 프레젠테이션을 열면 슬라이드에 다음 이미지가 표시됩니다:

![OLE object message](OLE_object_message.png)

OLE 개체가 슬라이드에 추가되었는지 확인하려면 "EMBEDDED OLE OBJECT" 메시지를 더블 클릭하거나, 마우스 오른쪽 버튼을 클릭한 후 **Object > Edit** 옵션을 선택해야 합니다.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint가 내장된 OLE 개체를 엽니다.

![OLE object data](OLE_object_data.png)

슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 남아 있을 수 있습니다. OLE 개체를 클릭하면 슬라이드 미리보기가 업데이트되고 "EMBEDDED OLE OBJECT" 메시지가 OLE 개체의 실제 이미지로 교체됩니다. 

![OLE object preview](OLE_object_preview.png)

이제 프레젠테이션을 저장하여 OLE 개체의 이미지가 올바르게 업데이트되도록 할 수 있습니다. 이렇게 하면 프레젠테이션을 저장한 후 다시 열었을 때 "EMBEDDED OLE OBJECT" 메시지가 표시되지 않습니다. 

## **기타 솔루션**

### **솔루션 1: "Embedded OLE Object" 메시지를 이미지로 교체**

PowerPoint에서 프레젠테이션을 열고 저장하여 "EMBEDDED OLE OBJECT" 메시지를 제거하고 싶지 않은 경우, 원하는 미리보기 이미지로 메시지를 교체할 수 있습니다. 다음 코드 줄이 그 과정을 보여줍니다:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // 프레젠테이션 리소스에 이미지를 추가합니다.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // OLE 객체 미리보기를 위한 제목과 이미지를 설정합니다.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

`OleObjectFrame`을 포함한 슬라이드는 다음과 같이 변경됩니다:

![New OLE object image](OLE_object_new_image.png)

### **솔루션 2: PowerPoint용 추가 기능 만들기**

프로그램에서 프레젠테이션을 열 때 모든 OLE 개체를 업데이트하는 Microsoft PowerPoint용 추가 기능을 만들 수도 있습니다.