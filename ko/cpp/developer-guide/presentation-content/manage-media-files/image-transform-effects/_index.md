---
title: C++를 사용한 프레젠테이션에서 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/cpp/image-transform-effects/
keywords:
- 이미지 변환
- 그림 효과
- 밝기
- 대비
- 그레이스케일
- 듀오톤
- 색조
- HSL
- 색상 교체
- 흐림
- 투명도
- 알파 효과
- 효과 체인
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 사진 프레임에 대한 이미지 변환 효과를 적용하고, 체인화하며, 검사하고, 제거하고, 검증합니다."
---
## **개요**

Aspose.Slides는 사진 조정을 이미지 변환 작업의 순서가 지정된 컬렉션으로 나타냅니다. 사진 프레임에서는 프레임의 [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/)를 시작으로 [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/)에 접근합니다. 반환된 [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/)를 사용하면 원본 이미지 바이트를 다시 쓰지 않고 효과를 추가, 열거, 검사, 제거 및 정리할 수 있습니다.

이 문서에서는 밝기와 대비, 색상 변환, 흐림, 투명도, 순서가 지정된 효과 체인, 실효값, 제거 및 PPTX 라운드 트립 검증 전체 워크플로우를 시연합니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 사진은 다른 객체입니다:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/)는 사진 채우기에 속하며 이미지 리소스를 가리키면서 이미지 변환 컬렉션을 저장합니다.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/)은 해당 사진 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 도형입니다.

따라서 이미지 변환 작업은 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)의 바이트를 수정하지 않습니다. 동일한 `IPPImage`가 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/)에 여러 번 전달될 때마다 각 새 사진 프레임은 자체 `ISlidesPicture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 회색조를 적용해도 다른 프레임은 회색조가 되지 않으며, 모두 동일한 임베드된 이미지 리소스를 재사용합니다.

같은 `ISlidesPicture::get_ImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 사진 채우기에서도 사용됩니다. 아래 예제는 사진 프레임에 초점을 맞춥니다.

## **유효 매개변수 범위 및 단위 사용**

시연된 메서드는 다음 의미적 범위와 단위를 사용합니다. 특정 라이브러리 버전이 모든 범위 초과 값을 즉시 거부하지 않더라도 이 범위 내에 값을 유지하십시오; 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint가 파일을 열 때 잘못된 데이터를 정규화, 생략 또는 거부할 수 있습니다.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100`부터 `100`까지, 퍼센트; `0`은 해당 요소를 변경하지 않음. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | 없음 | 숫자 매개변수 없음. 알파는 변경되지 않음. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. `System::Drawing::Color`의 RGB 및 알파 채널은 `0`부터 `255`까지 사용. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 색조는 `0` 포함부터 `360` 미만까지, 도 단위; 양은 `-100`부터 `100`까지, 퍼센트. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 색조는 `0` 포함부터 `360` 미만까지, 도 단위; 채도와 명도는 `-100`부터 `100`까지, 퍼센트. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 교체 색상은 `0`부터 `255`까지의 채널 값을 사용. 기존 알파 값은 변경되지 않음. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 반경은 음수일 수 없으며 포인트 단위; `grow`는 흐릿한 내용이 원래 경계를 넘어 확장될 수 있는지 제어. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 음수가 아닌 퍼센트. 일반적인 불투명도 스케일링에는 `0`부터 `100`까지 사용: `0`은 완전 투명, `100`은 기존 알파 유지. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`부터 `100`까지, 퍼센트 불투명도. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`부터 `100`까지, 퍼센트 알파 임계값. 임계값 이하인 값은 투명, 임계값 이상은 불투명. |

고정 알파 변조의 경우 투명도와 불투명도는 보완 관계입니다. 예를 들어 35% 투명도는 알파 변조 양이 65%에 해당합니다.

## **밝기와 대비 적용**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/)는 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. `IBrightnessContrast::GetEffective` 메서드는 검사하거나 기록할 수 있는 계산된 읽기 전용 값을 반환합니다.

다음 예제는 밝기를 15% 증가시키고 대비를 20% 증가시킨 뒤, 임베드된 이미지를 수정하지 않고 미리보기를 렌더링합니다:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/)는 Office 2010 사진 효과 확장으로, 표준 DrawingML 명도 효과보다 이동성이 떨어집니다. PPTX 라운드 트립 후에도 밝기와 대비를 편집 가능하게 유지하려면 [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)를 사용하고 파일을 다시 연 후 결과를 확인하십시오. 형식 제한 섹션에서 이 차이에 대해 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 사진 프레임에 독립적으로 적용할 수 있습니다. 다음 예제는 다섯 개 프레임을 만들고 회색조, 듀오톤, 색조, HSL 조정 및 색상 교체를 적용합니다.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/)는 두 개의 독립적으로 편집 가능한 색상 매개변수를 갖습니다: `get_Color1`은 어두운 픽셀을, `get_Color2`는 밝은 픽셀을 매핑합니다. 이는 단일 스칼라 값보다 설정이 복잡한 효과를 보여주는 유용한 예제입니다.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/)는 알파를 유지하면서 모든 픽셀의 색상을 하나의 고정 색상으로 교체합니다. 이는 [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)와 다르며, 후자는 한 소스 색상을 다른 색상으로 매핑하고 소스와 대상 색상 형식을 모두 노출합니다.

### **명도 임계값 적용**

명도 임계값은 스캔한 페이지의 흐린 자국을 배경과 구별하기 쉽게 합니다. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/)는 회색 중간 단계를 유지합니다. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/)는 명도를 검정 또는 백색으로 매핑하고, [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)는 불투명도에 임계값을 적용합니다.

명도 임계값은 0%에서 100%까지(포함)이며, 임계값 이하 픽셀은 검정이 되고, 임계값 이상 픽셀은 백색이 됩니다. 임계값을 높이면 더 많은 명도가 검정으로 변환됩니다.

[grayscale-swatches.png](grayscale-swatches.png)를 작업 디렉터리로 다운로드하십시오. 각 레이블은 0에서 255까지의 원래 회색 레벨을 나타냅니다. 예제는 원본을 두 개 복사본 옆에 배치하고 각 복사본의 임계값을 프레젠테이션에 저장합니다.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint에서 출력 프레젠테이션을 열어 세 프레임을 비교하십시오. 레이블이 96인 스와치는 약 38% 명도(255 중 96)이며, 20% 임계값에서는 백색, 60% 임계값에서는 검정으로 변합니다.

![원본 회색 스와치와 명도 임계값 20% 및 60%에서의 흑백 결과](luminance-threshold.png)

## **흐림, 투명도 및 알파 효과 추가**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/)는 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐릿한 가장자리가 원본 사진 경계를 넘어설 수 있는 경우 `grow`를 `true`로 설정하십시오.

균일한 투명도를 위해서는 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)를 사용합니다. 이는 기존 알파 값을 모두 곱하므로 부분적으로 투명한 픽셀도 비례적으로 차이를 유지합니다. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/)는 모든 픽셀에 하나의 알파 값을 할당하고, [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/)는 임계값에 따라 알파를 두 단계로 변환합니다.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

매개변수가 없는 기타 알파 작업에는 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)가 포함되며, 이는 모든 비영 알파를 완전 불투명하게 만들고, [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)는 100% 이하의 모든 알파를 완전 투명하게 만들며, [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)는 알파를 `100% - alpha`로 변경합니다.

## **순서가 지정된 효과 체인 구축**

각 `Add...Effect` 메서드는 컬렉션 끝에 새 작업을 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이와 같이 진행됩니다. 따라서 순서가 다른 동일 작업 집합은 다른 이미지를 생성할 수 있습니다.

예를 들어, 회색조 후 색조를 적용하면 색조 정보가 먼저 제거된 뒤 명도 결과에 색조가 입혀집니다. 색조 후 회색조를 적용하면 색조가 다시 제거됩니다. 마찬가지로 알파 교체는 이전 작업이 계산한 알파 값을 덮어쓸 수 있고, 알파 변조는 상대적 차이를 유지합니다.

다음 예제는 네 개 작업으로 구성된 체인을 구축하고 PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고, 다시 연 결과를 렌더링합니다:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

컬렉션은 색상, 알파 및 흐림 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들은 결합될 수 있지만 조합이 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 후 회색조는 두 선택 색상을 제거하며, 알파 천장, 바닥, 교체 또는 이중 레벨 작업은 이전에 만든 알파 세부 정보를 삭제할 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구축하고, 항목을 정렬되지 않은 서식 플래그처럼 취급하지 마십시오.


<!-- visual-explanation:image-transform-effects:start -->
[![동일 이미지가 회색조 → 색조, 색조 → 회색조 순으로 지나가며 두 최종 회색조 이미지가 서로 다른 색조를 가짐](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*이 그림은 Aspose.Slides for .NET 26.11 렌더링 예시이며, 220° 색조를 25% 적용하면 회색조 이미지가 변하지 않습니다. 동일 색조를 회색조 전에 적용하면 다른 색조가 나타납니다.*
<!-- visual-explanation:image-transform-effects:end -->

## **편집 가능한 값과 실효값 검사**

편집 가능한 작업은 `ISlidesPicture::get_ImageTransform`에 저장된 객체입니다. 효과에 따라 직접 쓸 수 있는 멤버를 노출할 수 있습니다. 예를 들어, [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/)는 `set_Radius`와 `set_Grow`를, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/)는 `set_Amount`를, [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/)는 `set_Threshold`를 노출합니다. [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/)과 같은 색상 효과는 변경 가능한 [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) 객체를 노출합니다.

[IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/)와 같은 일부 인터페이스는 생성 시 스칼라 값을 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 해당 작업을 제거하고 원하는 위치에 교체 작업을 추가하십시오.

`GetEffective()`이 반환하는 실효 데이터는 계산된 읽기 전용 값이며, 테마 종속 색상을 해결하고 렌더러가 사용하는 정규화된 값을 읽는 데 유용하지만 또 다른 편집 표면은 아닙니다. 다음 예제는 체인을 열거하고 여러 일반 작업에 대한 실효값을 검사합니다:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

그레이스케일, 알파 천장, 알파 역전과 같은 매개변수가 없는 효과도 실효 데이터 객체를 가지지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재 여부와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 정리**

[IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/)를 사용하여 인덱스로 하나의 작업을 제거합니다. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾고 열거 후 제거하십시오. `Clear()`를 사용하면 전체 체인을 제거합니다.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

변환을 제거하거나 정리해도 사진 서식만 변경됩니다. 재사용되는 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 리소스는 삭제, 재압축 또는 다른 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 시작되므로 효과 체인에 가장 적합한 편집 형식은 PPTX입니다. PPTX라도 모든 작업이 동일한 이동성을 갖는 것은 아닙니다:

- 명도, 회색조, 듀오톤, 색조, HSL, 흐림 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드 트립에서 가장 잘 보존됩니다. 보존이 요구되는 경우 항상 생성된 파일을 다시 열어 컬렉션을 확인하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/)는 표준 DrawingML 명도 작업이 아닌 Office 2010 확장입니다. 메모리 내 렌더링에는 사용할 수 있지만 저장·재열 때 편집 가능한 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)로 남을 보장은 없습니다. 지속적인 밝기·대비 조정에는 [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/)를 선호하십시오.
- 이진 PPT 형식은 완전한 DrawingML 효과 모델보다 오래되었습니다. PPT로 저장하면 지원되지 않는 작업이 누락되거나 체인이 지원 가능한 부분 집합으로 축소되거나 외형이 근사될 수 있습니다. 복잡한 편집 체인 검증 형식으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력 형식은 지원되는 체인을 렌더링된 모습에 적용합니다. 이러한 출력에는 편집 가능한 `IImageTransformOperationCollection`이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서·벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 사진을 렌더링하려면 프레젠테이션 로드 시 해당 연결 리소스가 사용 가능해야 합니다.

여러 알파 또는 색상 양자화 작업을 결합하면 가장자리 경우가 다르게 렌더링될 수 있습니다. 중요한 출력물의 경우 생산 환경에서 사용 중인 동일 Aspose.Slides 버전으로 편집 라운드 트립과 최종 내보내기 형식을 모두 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베드된 이미지 데이터를 수정합니까?**

아니오. 작업은 사진 채우기에 사용되는 `ISlidesPicture`에 속합니다. 기본 `IPPImage` 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 사진 프레임이 효과를 공유합니까?**

아니오. `IPPImage`를 재사용하면 이미지 데이터 중복을 피하지만 각 사진 프레임은 보통 별도의 `ISlidesPicture`와 이미지 변환 컬렉션을 가집니다.

**색상, 흐림 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 지정된 체인에 모두 포함할 수 있습니다. 교체 및 임계값 작업은 이전 색상이나 알파 세부 정보를 삭제할 수 있으므로 각 작업이 이전 작업 결과에 미치는 영향을 고려하십시오.

**왜 실효값은 읽기 전용입니까?**

실효 데이터는 렌더링에 사용되는 계산된 값(해결된 색상 포함)을 나타냅니다. 쓰기 가능한 멤버가 있는 변환 컬렉션에 저장된 작업을 편집하거나, 그렇지 않으면 작업을 제거하고 새 생성 매개변수로 교체하십시오.

**어떤 형식이 변환 체인을 보존하는 데 가장 적합합니까?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링 내보내기 형식은 편집 가능한 변환 작업이 아니라 외관만 보존합니다.