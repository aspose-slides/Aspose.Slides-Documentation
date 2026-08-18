---
title: C++에서 프레젠테이션 슬라이드 복제
linktitle: 슬라이드 복제
type: docs
weight: 40
url: /ko/cpp/clone-slides/
keywords:
- 슬라이드 복제
- 슬라이드 복사
- 슬라이드 저장
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드를 빠르게 복제합니다. 명확한 코드 예제를 따라 몇 초 안에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

클론은 무언가를 정확히 복사하거나 복제하는 과정입니다. Aspose.Slides for C++는 슬라이드를 복제하거나 복사한 뒤 현재 프레젠테이션이나 다른 열려 있는 프레젠테이션에 삽입할 수 있게 해줍니다. 슬라이드 복제 과정은 원본 슬라이드를 변경하지 않고 개발자가 수정할 수 있는 새 슬라이드를 생성합니다. 슬라이드를 복제하는 방법은 여러 가지가 있습니다:

- 프레젠테이션 내에서 끝에 복제
- 프레젠테이션 내 다른 위치에 복제
- 다른 프레젠테이션의 끝에 복제
- 다른 프레젠테이션의 다른 위치에 복제
- 다른 프레젠테이션의 특정 위치에 복제

Aspose.Slides for C++에서는 (프레젠테이션 객체가 노출하는 [ISlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/) 컬렉션) [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 객체가 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)와 [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/insertclone/) 메서드를 제공하여 위와 같은 슬라이드 복제 유형을 수행합니다.

## **프레젠테이션 끝에 슬라이드 복제**
같은 프레젠테이션 파일 내 기존 슬라이드 끝에 슬라이드를 복제하여 사용하려면 아래 단계에 따라 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 사용합니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 ISlideCollection 클래스를 인스턴스화합니다.
1. ISlideCollection 객체가 제공하는 AddClone 메서드를 호출하고 복제할 슬라이드를 매개변수로 전달합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **프레젠테이션 내 다른 위치에 슬라이드 복제**
같은 프레젠테이션 파일 내 다른 위치에 슬라이드를 복제하려면 [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/insertclone/) 메서드를 사용합니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. Presentation 객체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화합니다.
1. ISlideCollection 객체가 제공하는 InsertClone 메서드를 호출하고 복제할 슬라이드와 새로운 위치의 인덱스를 매개변수로 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 인덱스 0(위치 1)에 있는 슬라이드를 인덱스 1(위치 2)으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **다른 프레젠테이션 끝에 슬라이드 복제**
한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 사용하려면:

1. 복제할 슬라이드가 포함된 프레젠테이션을 나타내는 Presentation 클래스의 인스턴스를 생성합니다.
1. 슬라이드가 추가될 대상 프레젠테이션을 나타내는 Presentation 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 **Slides** 컬렉션을 참조하여 ISlideCollection 클래스를 인스턴스화합니다.
1. ISlideCollection 객체가 제공하는 AddClone 메서드를 호출하고 소스 프레젠테이션의 슬라이드를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 소스 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션 끝으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **다른 프레젠테이션 내 다른 위치에 슬라이드 복제**
한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 특정 위치에 사용하려면:

1. 복제할 슬라이드가 포함된 소스 프레젠테이션을 나타내는 Presentation 클래스의 인스턴스를 생성합니다.
1. 슬라이드가 추가될 대상 프레젠테이션을 나타내는 Presentation 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 ISlideCollection 클래스를 인스턴스화합니다.
1. ISlideCollection 객체가 제공하는 InsertClone 메서드를 호출하고 소스 프레젠테이션의 슬라이드와 원하는 위치를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 소스 프레젠테이션의 인덱스 0에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **다른 프레젠테이션의 특정 위치에 슬라이드 복제**
마스터 슬라이드가 포함된 슬라이드를 복제하려면 먼저 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션으로 복제해야 합니다. 그런 다음 해당 마스터 슬라이드를 사용해 슬라이드를 복제합니다. **AddClone(ISlide, IMasterSlide)** 은 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 아래 단계에 따라 마스터 슬라이드와 함께 슬라이드를 복제하십시오:

1. 복제할 슬라이드가 포함된 소스 프레젠테이션을 나타내는 Presentation 클래스의 인스턴스를 생성합니다.
1. 슬라이드가 복제될 대상 프레젠테이션을 나타내는 Presentation 클래스의 인스턴스를 생성합니다.
1. 복제할 슬라이드와 마스터 슬라이드를 접근합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Masters 컬렉션을 참조하여 IMasterSlideCollection 클래스를 인스턴스화합니다.
1. IMasterSlideCollection 객체가 제공하는 AddClone 메서드를 호출하고 소스 PPTX의 마스터를 매개변수로 전달합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 ISlideCollection 클래스를 인스턴스화합니다.
1. ISlideCollection 객체가 제공하는 AddClone 메서드를 호출하고 소스 프레젠테이션의 슬라이드와 복제된 마스터 슬라이드를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 소스 프레젠테이션의 인덱스 0에 있는 마스터가 포함된 슬라이드를 소스 마스터를 사용해 대상 프레젠테이션 끝으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **지정된 섹션 끝에 슬라이드 복제**
같은 프레젠테이션 파일 내 다른 섹션에 슬라이드를 복제하려면 [AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 사용합니다. Aspose.Slides for C++는 첫 번째 섹션에서 슬라이드를 복제한 뒤 동일한 프레젠테이션의 두 번째 섹션에 삽입할 수 있게 해줍니다.

다음 코드 조각은 슬라이드를 복제하고 지정된 섹션에 삽입하는 방법을 보여줍니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **슬라이드 크기 일치 보장**

슬라이드를 다른 프레젠테이션으로 복제할 때 대상 프레젠테이션의 슬라이드 크기가 소스와 동일해야 합니다. 크기가 다르면 Aspose.Slides는 복제된 도형의 크기나 좌표를 자동으로 재조정하지 않으며, 원래 좌표와 크기가 유지되어 내용이 어긋나거나 슬라이드 경계를 넘어갈 수 있습니다.

복제하기 전에 대상 프레젠테이션의 슬라이드 크기를 소스와 일치하도록 설정할 수 있습니다:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

마스터와 슬라이드를 복제하기 전에 이 작업을 수행하십시오.

## **FAQ**

**스피커 노트와 검토자 의견도 복제되나요?**

예. 노트 페이지와 검토 의견이 복제에 포함됩니다. 원하지 않으면 삽입 후 [remove them](/slides/ko/cpp/presentation-notes/)을 제거하십시오.

**차트와 데이터 소스는 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE가 포함된 워크북)에 연결돼 있었다면 해당 연결이 OLE 객체로 유지됩니다. 파일 간 이동 후 데이터 가용성을 확인하고 새로 고침 동작을 확인하십시오.

**복제 삽입 위치와 섹션을 제어할 수 있나요?**

예. 특정 슬라이드 인덱스에 복제를 삽입하고 선택한 [section](/slides/ko/cpp/slide-section/)에 배치할 수 있습니다. 대상 섹션이 존재하지 않으면 먼저 섹션을 만든 뒤 슬라이드를 이동하십시오.