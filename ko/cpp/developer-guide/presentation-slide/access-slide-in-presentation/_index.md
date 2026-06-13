---
title: C++에서 프레젠테이션 슬라이드에 액세스
linktitle: 슬라이드 액세스
type: docs
weight: 20
url: /ko/cpp/access-slide-in-presentation/
keywords:
- 슬라이드 액세스
- 슬라이드 인덱스
- 슬라이드 ID
- 슬라이드 위치
- 위치 변경
- 슬라이드 속성
- 슬라이드 번호
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드에 액세스하고 관리하는 방법을 학습하십시오. 코드 예제로 생산성을 높이세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드에 액세스하고 관리하는 방법을 설명합니다. 슬라이드 컬렉션에서 0부터 시작하는 인덱스로 슬라이드를 가져오는 방법과 `GetSlideById` 메서드를 사용하여 고유 ID로 슬라이드에 액세스하는 방법을 보여줍니다.

`set_SlideNumber` 메서드를 사용하여 슬라이드 위치를 변경하는 방법과 `set_FirstSlideNumber` 메서드로 프레젠테이션의 시작 슬라이드 번호를 정의하는 방법도 배울 수 있습니다. 예제에서는 프레젠테이션을 로드하고, 슬라이드 참조를 가져오며, 슬라이드 순서 또는 번호를 업데이트하고, 수정된 프레젠테이션을 저장하는 과정을 보여줍니다.

## **인덱스로 슬라이드에 액세스**

프레젠테이션의 모든 슬라이드는 슬라이드 위치를 기준으로 0부터 시작하는 숫자로 정렬됩니다. 첫 번째 슬라이드는 인덱스 0으로 접근할 수 있고, 두 번째 슬라이드는 인덱스 1으로 접근합니다; 등등.

프레젠테이션 파일을 나타내는 Presentation 클래스는 모든 슬라이드를 [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/) 컬렉션([ISlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/) 객체의 컬렉션)으로 노출합니다. 다음 C++ 코드는 인덱스로 슬라이드에 접근하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation 클래스를 인스턴스화합니다.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 인덱스를 통해 슬라이드 참조를 가져옵니다.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **ID로 슬라이드에 액세스**

프레젠테이션의 각 슬라이드에는 고유한 ID가 연결되어 있습니다. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스에서 노출되는 [GetSlideById()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/getslidebyid/) 메서드를 사용하여 해당 ID를 대상으로 할 수 있습니다. 다음 C++ 코드는 유효한 슬라이드 ID를 제공하고 [GetSlideById()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/getslidebyid/) 메서드로 해당 슬라이드에 접근하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 슬라이드 ID를 가져옵니다
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// ID를 통해 슬라이드에 액세스합니다
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **슬라이드 위치 변경**

Aspose.Slides에서는 슬라이드 위치를 변경할 수 있습니다. 예를 들어 첫 번째 슬라이드를 두 번째 슬라이드로 지정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 변경하려는 슬라이드의 참조를 가져옵니다.
1. [set_SlideNumber()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/set_slidenumber/) 속성을 사용하여 슬라이드의 새 위치를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 위치 1에 있는 슬라이드를 위치 2로 이동하는 작업을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 위치를 변경할 슬라이드를 가져옵니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 슬라이드의 새 위치를 설정합니다
	slide->set_SlideNumber(2);

	// 수정된 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

첫 번째 슬라이드가 두 번째가 되고, 두 번째 슬라이드가 첫 번째가 됩니다. 슬라이드 위치를 변경하면 다른 슬라이드가 자동으로 조정됩니다.

## **슬라이드 번호 설정**

[set_FirstSlideNumber()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/set_firstslidenumber/) 속성([Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스에 노출됨)을 사용하면 프레젠테이션의 첫 번째 슬라이드에 새 번호를 지정할 수 있습니다. 이 작업으로 다른 슬라이드 번호가 다시 계산됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 번호를 가져옵니다.
1. 슬라이드 번호를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 첫 번째 슬라이드 번호를 10으로 설정하는 작업을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 슬라이드 번호를 가져옵니다
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// 슬라이드 번호를 설정합니다
	pres->set_FirstSlideNumber(2);
	
	// 수정된 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

첫 번째 슬라이드를 건너뛰고 싶다면 두 번째 슬라이드부터 번호를 시작하고(첫 번째 슬라이드의 번호는 숨기는) 다음과 같이 할 수 있습니다:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**사용자가 보는 슬라이드 번호가 컬렉션의 0 기반 인덱스와 일치합니까?**

슬라이드에 표시되는 번호는 임의의 값(예: 10)부터 시작할 수 있으며 인덱스와 일치할 필요는 없습니다. 이 관계는 프레젠테이션의 [first slide number](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/set_firstslidenumber/) 설정에 의해 제어됩니다.

**숨긴 슬라이드가 인덱싱에 영향을 줍니까?**

예. 숨긴 슬라이드도 컬렉션에 남아있으며 인덱싱 시 포함됩니다. “숨김”은 표시 여부를 의미할 뿐, 컬렉션 내 위치에는 영향을 주지 않습니다.

**다른 슬라이드를 추가하거나 제거하면 해당 슬라이드의 인덱스가 변경됩니까?**

예. 인덱스는 항상 현재 슬라이드 순서를 반영하며, 삽입, 삭제, 이동 작업이 발생하면 재계산됩니다.