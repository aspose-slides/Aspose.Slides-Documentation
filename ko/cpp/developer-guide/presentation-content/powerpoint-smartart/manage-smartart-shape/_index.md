---
title: C++를 사용하여 프레젠테이션에서 SmartArt 그래픽 관리
linktitle: SmartArt 그래픽
type: docs
weight: 20
url: /ko/cpp/manage-smartart-shape/
keywords:
- SmartArt 객체
- SmartArt 그래픽
- SmartArt 스타일
- SmartArt 색상
- SmartArt 만들기
- SmartArt 추가
- SmartArt 편집
- SmartArt 변경
- SmartArt 접근
- SmartArt 레이아웃 유형
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용한 C++에서 PowerPoint SmartArt를 자동으로 생성, 편집 및 스타일링하며, 간결한 코드 예제와 성능 중심 가이드를 제공합니다."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에서 SmartArt 그래픽을 생성하고 관리할 수 있습니다. 이 문서에서는 슬라이드에 SmartArt 도형을 추가하고, 기존 SmartArt 도형에 접근하고, 특정 레이아웃 유형으로 SmartArt를 찾으며, SmartArt 스타일 또는 색상 스타일을 변경하여 시각적 모양을 업데이트하는 방법을 설명합니다.

예제에서는 프레젠테이션 슬라이드의 도형 컬렉션을 통해 SmartArt 도형을 작업하고, 도형이 SmartArt인지 확인한 후 해당 속성을 수정하거나 검사하는 방법을 보여줍니다.

## **SmartArt 도형 만들기**
Aspose.Slides for C++는 이제 슬라이드에 처음부터 사용자 정의 SmartArt 도형을 추가할 수 있게 했습니다. Aspose.Slides for C++는 SmartArt 도형을 가장 간단하게 만들 수 있는 API를 제공합니다. 슬라이드에 SmartArt 도형을 만들려면 다음 단계를 따르세요.

- [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- LayoutType을 설정하여 SmartArt 도형을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **슬라이드에서 SmartArt 도형에 접근하기**
다음 코드는 프레젠테이션 슬라이드에 추가된 SmartArt 도형에 접근하는 방법을 보여줍니다. 샘플 코드에서는 슬라이드 내 모든 도형을 순회하면서 SmartArt 도형인지 확인하고, SmartArt 유형이면 SmartArt 인스턴스로 형변환합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **특정 레이아웃 유형을 가진 SmartArt 도형에 접근하기**
다음 샘플 코드는 특정 LayoutType을 가진 SmartArt 도형에 접근하는 방법을 보여줍니다. LayoutType은 읽기 전용이며 SmartArt 도형을 추가할 때만 설정된다는 점을 유의하세요.

- `Presentation` 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고 SmartArt라면 SmartArt로 형변환합니다.
- 특정 LayoutType을 가진 SmartArt 도형을 확인하고 이후 필요한 작업을 수행합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **SmartArt 도형 스타일 변경**
다음 샘플 코드는 특정 LayoutType을 가진 SmartArt 도형에 접근하는 방법을 보여줍니다.

- `Presentation` 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고 SmartArt라면 SmartArt로 형변환합니다.
- 특정 Style을 가진 SmartArt 도형을 찾습니다.
- SmartArt 도형에 새 Style을 적용합니다.
- 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **SmartArt 도형 색상 스타일 변경**
이 예제에서는任意의 SmartArt 도형에 대한 색상 스타일을 변경하는 방법을 배웁니다. 다음 샘플 코드는 특정 색상 스타일을 가진 SmartArt 도형에 접근하고 해당 스타일을 변경합니다.

- `Presentation` 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고 SmartArt라면 SmartArt로 형변환합니다.
- 특정 Color Style을 가진 SmartArt 도형을 찾습니다.
- SmartArt 도형에 새 Color Style을 적용합니다.
- 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Can I animate SmartArt as a single object?**

Yes. SmartArt is a shape, so you can apply [standard animations](/slides/ko/cpp/powerpoint-animation/) via the animations API (entrance, exit, emphasis, motion paths) just like for other shapes.

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**

Set and use the Alternative Text (AltText) and search for the shape by that value—this is a recommended way to locate the target shape.

**Can I group SmartArt with other shapes?**

Yes. You can group SmartArt with other shapes (pictures, tables, etc.) and then [manipulate the group](/slides/ko/cpp/group/).

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**

Export a thumbnail/image of the shape; the library can [render individual shapes](/slides/ko/cpp/create-shape-thumbnails/) to raster files (PNG/JPG/TIFF).

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**

Yes. The rendering engine targets high fidelity for [PDF export](/slides/ko/cpp/convert-powerpoint-to-pdf/), with a range of quality and compatibility options.