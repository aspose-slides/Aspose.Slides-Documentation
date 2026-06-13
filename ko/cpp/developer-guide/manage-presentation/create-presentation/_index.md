---
title: C++에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/cpp/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새로운 프레젠테이션
- PPT 만들기
- 새로운 PPT
- PPTX 만들기
- 새로운 PPTX
- ODP 만들기
- 새로운 ODP
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며, 오픈문서 지원을 활용하고 프로그래밍 방식으로 저장하여 안정적인 결과를 얻으세요."
---
## **Overview**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 만들고, 슬라이드에 간단한 내용을 추가한 뒤, 결과를 파일로 저장하는 방법을 보여줍니다.

## **Create a PowerPoint Presentation**
프레젠테이션의 선택된 슬라이드에 간단한 직선을 추가하려면 아래 단계에 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. Shapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 라인 유형의 AutoShape를 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 슬라이드에 직선을 추가했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?**

다음 링크에서 [PPTX, PPT, 그리고 ODP](/slides/ko/cpp/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/ko/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ko/cpp/convert-powerpoint-to-html/), [SVG](/slides/ko/cpp/convert-powerpoint-to-png/), 그리고 [images](/slides/ko/cpp/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

**템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?**

예. 템플릿을 로드한 후 원하는 형식으로 저장합니다; POTX/POTM/PPTM 및 유사한 형식이 [지원됩니다](/slides/ko/cpp/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?**

[slide size](/slides/ko/cpp/slide-size/)을 설정합니다(4:3 및 16:9와 같은 프리셋이나 사용자 지정 치수 포함) 그리고 콘텐츠가 어떻게 스케일링될지 선택합니다.

**크기 및 좌표는 어떤 단위로 측정되나요?**

포인트 단위이며, 1인치는 72포인트에 해당합니다.

**많은 미디어 파일이 포함된 대용량 프레젠테이션의 메모리 사용량을 줄이려면 어떻게 해야 하나요?**

[BLOB 관리 전략](/slides/ko/cpp/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

**프레젠테이션을 병렬로 생성/저장할 수 있나요?**

동일한 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/cpp/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하세요.

**체험版 워터마크와 제한을 제거하려면 어떻게 해야 하나요?**

프로세스당 한 번씩 [라이선스를 적용](/slides/ko/cpp/licensing/)합니다. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있나요?**

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/cpp/digital-signature-in-powerpoint/)(추가 및 검증)이 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)를 지원하나요?**

예. [VBA 프로젝트를 만들고/편집](/slides/ko/cpp/presentation-via-vba/)할 수 있으며 PPTM/PPSM과 같은 매크로 사용 파일을 저장할 수 있습니다.