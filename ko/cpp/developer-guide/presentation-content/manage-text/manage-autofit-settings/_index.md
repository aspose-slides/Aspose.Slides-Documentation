---
title: C++에서 AutoFit으로 프레젠테이션을 향상시키세요
linktitle: AutoFit 설정
type: docs
weight: 30
url: /ko/cpp/manage-autofit-settings/
keywords:
- 텍스트 상자
- 자동 맞춤
- 자동 맞춤 사용 안 함
- 텍스트 맞춤
- 텍스트 축소
- 텍스트 래핑
- 도형 크기 조정
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 AutoFit 설정을 관리하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트 표시를 최적화하고 콘텐츠 가독성을 향상시키는 방법을 알아보세요."
---
## **소개**

기본적으로 텍스트 상자를 추가하면 Microsoft PowerPoint는 텍스트 상자에 대해 **Resize shape to fix text** 설정을 사용합니다—텍스트가 항상 상자에 맞도록 자동으로 크기를 조정합니다. 

![텍스트상자-파워포인트](textbox-in-powerpoint.png)

* 텍스트 상자의 내용이 길어지거나 커지면 PowerPoint가 텍스트 상자를 자동으로 확대합니다—높이를 증가시켜 더 많은 텍스트를 담을 수 있도록 합니다. 
* 텍스트 상자의 내용이 짧아지거나 작아지면 PowerPoint가 텍스트 상자를 자동으로 축소합니다—높이를 감소시켜 남는 공간을 없앱니다. 

PowerPoint에서 텍스트 상자의 자동 맞춤 동작을 제어하는 4가지 주요 매개변수 또는 옵션은 다음과 같습니다: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![자동맞춤-옵션-파워포인트](autofit-options-powerpoint.png)

Aspose.Slides for C++는 유사한 옵션을 제공합니다—[TextFrameFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format) 클래스의 일부 메서드를 통해 프레젠테이션의 텍스트 상자에 대한 자동 맞춤 동작을 제어할 수 있습니다. 

## **텍스트에 맞게 도형 크기 조정**

텍스트 상자의 내용이 변경된 후에도 텍스트가 항상 상자에 맞도록 하려면 **Resize shape to fix text** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [AutofitType](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 속성([TextFrameFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format) 클래스)을 `Shape`으로 설정합니다. 

![항상맞춤-설정-파워포인트](alwaysfit-setting-powerpoint.png)

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

텍스트가 길어지거나 커지면 텍스트 상자가 자동으로 크기가 조정(높이 증가)되어 모든 텍스트가 들어갑니다. 텍스트가 짧아지면 그 반대가 발생합니다. 

## **자동 맞춤 사용 안 함**

텍스트 상자나 도형이 포함된 텍스트와 무관하게 크기를 유지하도록 하려면 **Do not Autofit** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [AutofitType](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 속성([TextFrameFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format) 클래스)을 `None`으로 설정합니다. 

![자동맞춤사용안함-설정-파워포인트](donotautofit-setting-powerpoint.png)

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

텍스트가 상자보다 길어지면 텍스트가 밖으로 흘러나옵니다. 

## **오버플로 시 텍스트 축소**

텍스트가 상자보다 길어질 경우 **Shrink text on overflow** 옵션을 사용하여 텍스트 크기와 간격을 줄여 상자에 맞추도록 지정할 수 있습니다. 이 설정을 지정하려면 [AutofitType](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 속성([TextFrameFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format) 클래스)을 `Normal`으로 설정합니다. 

![텍스트축소-설정-파워포인트](shrinktextonoverflow-setting-powerpoint.png)

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** 옵션을 사용하면 텍스트가 상자보다 길어질 때만 해당 설정이 적용됩니다. 
{{% /alert %}}

## **텍스트 래핑**

텍스트가 도형의 경계(가로) 너머로 넘어갈 경우 텍스트를 해당 도형 안에서 자동으로 래핑하려면 **Wrap text in shape** 매개변수를 사용해야 합니다. 이 설정을 지정하려면 [WrapText](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) 속성([TextFrameFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.text_frame_format) 클래스)을 `true`로 설정합니다. 

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
도형에 대해 `WrapText` 속성을 `False`로 설정하면 텍스트가 도형 너비보다 길어질 때 텍스트가 단일 라인으로 도형 경계를 넘어 확장됩니다. 
{{% /alert %}}

## **FAQ**

**텍스트 프레임의 내부 여백이 AutoFit에 영향을 줍니까?**

예. Padding(내부 여백)은 텍스트 사용 가능한 영역을 줄이므로 AutoFit이 더 일찍 작동합니다—폰트를 축소하거나 도형 크기를 조기에 조정합니다. AutoFit을 조정하기 전에 여백을 확인하고 조정하십시오.

**AutoFit은 수동 및 소프트 라인 브레이크와 어떻게 상호 작용합니까?**

강제 브레이크는 그대로 유지되고, AutoFit은 그 주위의 폰트 크기와 간격을 조정합니다. 불필요한 브레이크를 제거하면 AutoFit이 텍스트를 축소해야 하는 정도가 줄어듭니다.

**테마 폰트를 변경하거나 폰트 대체를 트리거하면 AutoFit 결과에 영향을 줍니까?**

예. 다른 글리프 메트릭을 가진 폰트로 대체하면 텍스트 너비/높이가 바뀌어 최종 폰트 크기와 라인 래핑이 달라질 수 있습니다. 폰트를 변경하거나 대체한 후에는 슬라이드를 다시 확인하십시오.