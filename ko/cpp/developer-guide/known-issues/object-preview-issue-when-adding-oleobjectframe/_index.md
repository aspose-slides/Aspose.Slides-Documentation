---
title: OleObjectFrame 추가 시 객체 미리 보기 문제
linktitle: OLE 객체 문제
type: docs
weight: 10
url: /ko/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 미리 보기 문제
- 삽입 객체
- 삽입 파일
- 객체 변경됨
- 객체 미리 보기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 OleObjectFrame을 추가할 때 EMBEDDED OLE OBJECT가 나타나는 이유와 PPT, PPTX 및 ODP 프레젠테이션의 미리 보기 문제를 해결하는 방법을 알아보세요."
---
## **소개**

Aspose.Slides for C++ 를 사용할 때 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 를 추가하면 출력 슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 표시됩니다. 이 메시지는 의도된 것이며 버그가 아닙니다.

OLE 개체 작업에 대한 자세한 내용은 [Manage OLE](/slides/ko/cpp/manage-ole/) 를 참조하십시오.

## **설명 및 해결 방법**

Aspose.Slides는 OLE 개체가 변경되었고 미리 보기 이미지가 업데이트되어야 함을 알리기 위해 "EMBEDDED OLE OBJECT" 메시지를 표시합니다.

예를 들어 Microsoft Excel 차트를 [OleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/oleobjectframe/) 로 슬라이드에 추가하고(자세한 내용은 "Manage OLE" 문서 참조) Microsoft PowerPoint에서 프레젠테이션을 열면 슬라이드에 다음과 같은 이미지가 표시됩니다:

![OLE 객체 메시지](OLE_object_message.png)

OLE 객체가 슬라이드에 추가되었는지 확인하려면 "EMBEDDED OLE OBJECT" 메시지를 더블 클릭하거나 마우스 오른쪽 버튼을 클릭한 후 **Object > Edit** 옵션을 선택해야 합니다.

![OLE 객체 > 편집](OLE_object_edit.png)

PowerPoint가 삽입된 OLE 객체를 엽니다.

![OLE 객체 데이터](OLE_object_data.png)

슬라이드에 "EMBEDDED OLE OBJECT" 메시지가 유지될 수 있습니다. OLE 객체를 클릭하면 슬라이드 미리 보기가 업데이트되고 "EMBEDDED OLE OBJECT" 메시지가 OLE 객체의 실제 이미지로 대체됩니다.

![OLE 객체 미리 보기](OLE_object_preview.png)

이제 프레젠테이션을 저장하여 OLE 객체 이미지가 올바르게 업데이트되었는지 확인하고 싶을 수 있습니다. 이렇게 하면 프레젠테이션을 저장한 후 다시 열었을 때 "EMBEDDED OLE OBJECT" 메시지를 보지 않게 됩니다.

## **다른 해결 방법**

### **해결 방법 1: "Embedded OLE Object" 메시지를 이미지로 교체**

PowerPoint에서 프레젠테이션을 열고 저장해서 "EMBEDDED OLE OBJECT" 메시지를 제거하고 싶지 않다면, 메시지를 원하는 미리 보기 이미지로 교체할 수 있습니다. 다음 코드가 과정을 보여 줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`OleObjectFrame` 이 포함된 슬라이드는 다음과 같이 변경됩니다:

![새 OLE 객체 이미지](OLE_object_new_image.png)

### **해결 방법 2: PowerPoint용 추가 기능 만들기**

Microsoft PowerPoint용 추가 기능을 만들어 프레젠테이션을 열 때 모든 OLE 객체를 업데이트하도록 할 수도 있습니다.