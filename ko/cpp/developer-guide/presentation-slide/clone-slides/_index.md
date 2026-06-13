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
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드를 빠르게 복제하십시오. 명확한 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수작업을 없애세요."
---
## **소개**

복제는 어떤 항목을 정확하게 복사하거나 복제하는 과정입니다. Aspose.Slides for C++는 슬라이드를 복제하거나 복사한 뒤 현재 프레젠테이션이나 다른 열려 있는 프레젠테이션에 삽입할 수 있게 합니다. 슬라이드 복제 과정은 원본 슬라이드를 변경하지 않고 개발자가 수정할 수 있는 새로운 슬라이드를 생성합니다. 슬라이드를 복제하는 몇 가지 가능한 방법이 있습니다:

- 프레젠테이션 내에서 끝에 복제.
- 프레젠테이션 내 다른 위치에 복제.
- 다른 프레젠테이션의 끝에 복제.
- 다른 프레젠테이션의 다른 위치에 복제.
- 다른 프레젠테이션의 특정 위치에 복제.

Aspose.Slides for C++에서 ([ISlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/) 객체의 컬렉션)은 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 객체에 의해 노출되며, 위에서 언급한 슬라이드 복제 유형을 수행하기 위해 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 및 [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/insertclone/) 메서드를 제공합니다.

## **프레젠테이션 끝에 슬라이드 복제**
같은 프레젠테이션 파일에서 기존 슬라이드 끝에 슬라이드를 복제하고 사용하려면 아래 단계에 따라 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 클래스를 인스턴스화합니다.
3. [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 호출하고 복제할 슬라이드를 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드의 매개변수로 전달합니다.
4. 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(0 인덱스)에 있는 슬라이드를 프레젠테이션 끝으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **프레젠테이션 내 다른 위치에 슬라이드 복제**
같은 프레젠테이션 파일 내에서 다른 위치에 슬라이드를 복제하고 사용하려면 [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/insertclone/) 메서드를 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 객체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화합니다.
3. [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 객체가 제공하는 [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/insertclone/) 메서드를 호출하고 복제할 슬라이드와 새 위치의 인덱스를 매개변수로 전달합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 0 인덱스(위치 1)에 있는 슬라이드를 인덱스 1(위치 2)으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **다른 프레젠테이션 끝에 슬라이드 복제**
하나의 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 사용하려면:

1. 복제할 슬라이드가 있는 소스 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
2. 슬라이드가 추가될 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
3. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 **Slides** 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 클래스를 인스턴스화합니다.
4. [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 호출하고 소스 프레젠테이션의 슬라이드를 매개변수로 전달합니다.
5. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 소스 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션의 끝으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **다른 프레젠테이션 내 다른 위치에 슬라이드 복제**
소스 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 특정 위치에 사용하려면:

1. 복제할 슬라이드가 있는 소스 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
2. 슬라이드가 추가될 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
3. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 클래스를 인스턴스화합니다.
4. [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 객체가 제공하는 [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/insertclone/) 메서드를 호출하고 소스 프레젠테이션의 슬라이드와 원하는 위치를 매개변수로 전달합니다.
5. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 소스 프레젠테이션의 0 인덱스에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **다른 프레젠테이션의 특정 위치에 슬라이드 복제**
하나의 프레젠테이션에서 마스터 슬라이드와 함께 슬라이드를 복제하여 다른 프레젠테이션에 사용하려면 먼저 원하는 마스터 슬라이드를 소스 프레젠테이션에서 대상 프레젠테이션으로 복제해야 합니다. 그런 다음 해당 마스터 슬라이드를 사용해 마스터가 포함된 슬라이드를 복제합니다. **AddClone(ISlide, IMasterSlide)** 은 소스가 아닌 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 마스터가 포함된 슬라이드를 복제하려면 아래 단계에 따라 진행하십시오:

1. 복제할 슬라이드가 있는 소스 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
2. 슬라이드가 복제될 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
3. 복제할 슬라이드와 마스터 슬라이드에 접근합니다.
4. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Masters 컬렉션을 참조하여 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslidecollection/) 클래스를 인스턴스화합니다.
5. [IMasterSlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslidecollection/) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 호출하고 소스 PPTX의 마스터를 매개변수로 전달합니다.
6. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 클래스를 인스턴스화합니다.
7. [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 호출하고 소스 프레젠테이션의 슬라이드와 마스터 슬라이드를 매개변수로 전달합니다.
8. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 소스 프레젠테이션의 0 인덱스에 있는 마스터가 포함된 슬라이드를 소스 슬라이드의 마스터를 사용해 대상 프레젠테이션 끝으로 복제했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **지정된 섹션 끝에 슬라이드 복제**
같은 프레젠테이션 파일 내에서 다른 섹션에 슬라이드를 복제하여 사용하려면 [**AddClone()**](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 메서드를 사용합니다. Aspose.Slides for C++는 첫 번째 섹션에서 슬라이드를 복제한 뒤 동일한 프레젠테이션의 두 번째 섹션에 삽입할 수 있게 합니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**발표자 메모와 검토자 의견도 복제되나요?**

예. 노트 페이지와 검토 댓글이 복제에 포함됩니다. 필요하지 않다면 삽입 후 [제거하세요](/slides/ko/cpp/presentation-notes/).

**차트와 데이터 원본은 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)에 연결되어 있으면 해당 연결이 [OLE 객체](/slides/ko/cpp/manage-ole/) 형태로 보존됩니다. 파일 간 이동 후 데이터 가용성과 새로 고침 동작을 확인하세요.

**복제의 삽입 위치와 섹션을 제어할 수 있나요?**

예. 특정 슬라이드 인덱스에 복제를 삽입하고 선택한 [섹션](/slides/ko/cpp/slide-section/)에 배치할 수 있습니다. 대상 섹션이 없으면 먼저 섹션을 만든 뒤 슬라이드를 이동시키십시오.