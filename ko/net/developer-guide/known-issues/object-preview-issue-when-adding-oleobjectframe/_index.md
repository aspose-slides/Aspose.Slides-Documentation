---
title: OleObjectFrame 추가 시 객체 미리 보기 자리 표시자
linktitle: OLE 미리 보기 자리 표시자
type: docs
weight: 10
url: /ko/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 미리 보기 문제
- 미리 보기 자리 표시자
- 설계 의도
- 삽입된 객체
- 삽입된 파일
- 객체 변경됨
- 객체 미리 보기
- 프레젠테이션
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET으로 추가된 OLE 객체가 미리 보기가 업데이트될 때까지 EMBEDDED OLE OBJECT 자리 표시자를 표시하는 이유와 자체 미리 보기 이미지를 설정하는 방법."
---
## **소개**

Aspose.Slides for .NET을 사용하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe/)을 추가하면 출력 슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 표시됩니다. 이 메시지는 의도된 것이며 버그가 아닙니다.

OLE 객체 작업에 대한 자세한 내용은 [Manage OLE](/slides/ko/net/manage-ole/)를 참조하십시오.

## **설명 및 솔루션**

Aspose.Slides는 OLE 객체가 변경되었으며 미리 보기 이미지가 업데이트되어야 함을 알리기 위해 "EMBEDDED OLE OBJECT" 메시지를 표시합니다.

예를 들어, Microsoft Excel 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/oleobjectframe/)으로 슬라이드에 추가하고(자세한 내용은 "Manage OLE" 기사 참조) Microsoft PowerPoint에서 프레젠테이션을 열면 슬라이드에 다음 이미지가 표시됩니다:

![OLE 객체 메시지](OLE_object_message.png)

OLE 객체가 슬라이드에 추가되었는지 확인하려면 "EMBEDDED OLE OBJECT" 메시지를 더블 클릭하거나 마우스 오른쪽 버튼을 클릭한 후 **Object > Edit** 옵션을 선택하면 됩니다.

![OLE 객체 > 편집](OLE_object_edit.png)

PowerPoint가 삽입된 OLE 객체를 엽니다.

![OLE 객체 데이터](OLE_object_data.png)

슬라이드에는 여전히 "EMBEDDED OLE OBJECT" 메시지가 남아 있을 수 있습니다. OLE 객체를 클릭하면 슬라이드 미리 보기가 업데이트되고 "EMBEDDED OLE OBJECT" 메시지가 OLE 객체의 실제 이미지로 교체됩니다.

![OLE 객체 미리 보기](OLE_object_preview.png)

이제 프레젠테이션을 저장하여 OLE 객체의 이미지가 올바르게 업데이트되도록 해야 합니다. 이렇게 하면 프레젠테이션을 다시 열었을 때 "EMBEDDED OLE OBJECT" 메시지를 보지 않게 됩니다.

## **기타 솔루션**

### **솔루션 1: "Embedded OLE Object" 메시지를 이미지로 교체**

PowerPoint에서 프레젠테이션을 열고 저장하여 "EMBEDDED OLE OBJECT" 메시지를 제거하고 싶지 않은 경우, 메시지를 원하는 미리 보기 이미지로 교체할 수 있습니다. 다음 코드 라인이 그 과정을 보여줍니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

`OleObjectFrame`이 포함된 슬라이드는 다음과 같이 변경됩니다:

![새 OLE 객체 이미지](OLE_object_new_image.png)

### **솔루션 2: PowerPoint용 애드온 만들기**

Microsoft PowerPoint용 애드온을 만들어 프레젠테이션을 열 때 모든 OLE 객체를 업데이트하도록 할 수도 있습니다.