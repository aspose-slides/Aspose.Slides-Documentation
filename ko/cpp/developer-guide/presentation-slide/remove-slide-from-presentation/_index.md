---
title: C++에서 프레젠테이션의 슬라이드 제거
linktitle: 슬라이드 제거
type: docs
weight: 30
url: /ko/cpp/remove-slide-from-presentation/
keywords:
- 슬라이드 제거
- 슬라이드 삭제
- 사용되지 않는 슬라이드 제거
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드를 손쉽게 제거하십시오. 명확한 코드 예제를 제공받아 워크플로우를 향상시킵니다."
---
## **소개**

슬라이드(또는 그 내용)가 중복되면 삭제할 수 있습니다. Aspose.Slides는 프레젠테이션의 모든 슬라이드를 저장하는 저장소인 [ISlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/)을 캡슐화하는 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 제공합니다. 알려진 [ISlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/) 객체에 대한 포인터(참조 또는 인덱스)를 사용하여 제거하려는 슬라이드를 지정할 수 있습니다.

## **참조로 슬라이드 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 통해 제거할 슬라이드의 참조를 가져옵니다.
1. 프레젠테이션에서 해당 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

이 C++ 코드는 참조를 사용해 슬라이드를 제거하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 슬라이드 컬렉션에서 인덱스를 통해 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 참조를 통해 슬라이드를 제거합니다
	pres->get_Slides()->Remove(slide);

	// 수정된 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **인덱스로 슬라이드 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스 위치를 통해 프레젠테이션에서 슬라이드를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

이 C++ 코드는 인덱스를 사용해 슬라이드를 제거하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 슬라이드 인덱스를 통해 슬라이드를 제거합니다
	pres->get_Slides()->RemoveAt(0);

	// 수정된 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **사용되지 않는 레이아웃 슬라이드 제거**

Aspose.Slides는 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스의 [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 메서드를 제공하여 필요 없고 사용되지 않은 레이아웃 슬라이드를 삭제할 수 있게 합니다. 이 C++ 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 제거하는 방법을 보여줍니다:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **사용되지 않는 마스터 슬라이드 제거**

Aspose.Slides는 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스의 [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 메서드를 제공하여 필요 없고 사용되지 않은 마스터 슬라이드를 삭제할 수 있게 합니다. 이 C++ 코드는 PowerPoint 프레젠테이션에서 마스터 슬라이드를 제거하는 방법을 보여줍니다:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**슬라이드를 삭제한 후 슬라이드 인덱스는 어떻게 됩니까?**

삭제 후 [collection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidecollection/)이 다시 인덱싱됩니다. 뒤에 있는 모든 슬라이드가 한 위치씩 왼쪽으로 이동하므로 이전 인덱스 번호는 더 이상 유효하지 않게 됩니다. 안정적인 참조가 필요하면 인덱스가 아니라 각 슬라이드의 지속 ID를 사용하십시오.

**슬라이드 ID와 인덱스는 다르며, 인접 슬라이드가 삭제될 때 변경됩니까?**

예. 인덱스는 슬라이드의 현재 위치이며 슬라이드가 추가되거나 삭제될 때 변경됩니다. 슬라이드 ID는 지속 식별자로, 다른 슬라이드가 삭제되어도 변경되지 않습니다.

**슬라이드를 삭제하면 슬라이드 섹션에 어떤 영향을 줍니까?**

슬라이드가 섹션에 속해 있었다면 해당 섹션의 슬라이드 수가 하나 줄어듭니다. 섹션 구조는 유지되며, 섹션이 비게 되면 [remove or reorganize sections](/slides/ko/cpp/slide-section/)할 수 있습니다.

**슬라이드가 삭제될 때 해당 슬라이드에 연결된 메모와 댓글은 어떻게 됩니까?**

[Notes](/slides/ko/cpp/presentation-notes/)와 [comments](/slides/ko/cpp/presentation-comments/)은 해당 슬라이드에 연결돼 있으므로 슬라이드와 함께 삭제됩니다. 다른 슬라이드의 내용은 영향을 받지 않습니다.

**슬라이드 삭제와 사용되지 않은 레이아웃/마스터 정리의 차이점은 무엇입니까?**

슬라이드 삭제는 실제 슬라이드 페이지를 제거합니다. 사용되지 않은 레이아웃/마스터 정리는 어떤 슬라이드에서도 참조되지 않는 레이아웃이나 마스터 슬라이드를 제거해 파일 크기를 줄이며 나머지 슬라이드 내용은 변경하지 않습니다. 일반적으로 먼저 슬라이드를 삭제하고, 그 다음에 레이아웃/마스터를 정리하는 것이 좋습니다.