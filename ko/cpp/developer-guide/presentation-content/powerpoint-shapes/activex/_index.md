---
title: C++를 사용하여 프레젠테이션에서 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/cpp/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++가 ActiveX를 활용하여 PowerPoint 프레젠테이션을 자동화하고 향상시키는 방법을 배우고, 개발자에게 슬라이드에 대한 강력한 제어 권한을 제공합니다."
---
## **소개**

ActiveX 컨트롤은 프레젠테이션에서 사용됩니다. Aspose.Slides for C++는 ActiveX 컨트롤을 관리할 수 있게 해주지만, 관리가 약간 더 까다롭고 일반 프레젠테이션 도형과는 다릅니다. Aspose.Slides for C++ 18.1부터 해당 컴포넌트는 ActiveX 컨트롤 관리 기능을 지원합니다. 현재는 프레젠테이션에 이미 추가된 ActiveX 컨트롤에 접근하여 다양한 속성을 사용해 수정하거나 삭제할 수 있습니다. 기억하십시오, ActiveX 컨트롤은 도형이 아니며 프레젠테이션의 IShapeCollection에 포함되지 않고 별도의 IControlCollection에 포함됩니다. 이 문서에서는 이를 사용하는 방법을 보여줍니다.

## **ActiveX 컨트롤 수정**
슬라이드에 있는 텍스트 상자와 간단한 커맨드 버튼과 같은 간단한 ActiveX 컨트롤을 관리하려면:

1. Presentation 클래스를 인스턴스화하고 ActiveX 컨트롤이 포함된 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드 참조를 가져옵니다.
3. IControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
4. ControlEx 객체를 사용해 TextBox1 ActiveX 컨트롤에 접근합니다.
5. 텍스트, 글꼴, 글꼴 높이 및 프레임 위치 등을 포함한 TextBox1 ActiveX 컨트롤의 다양한 속성을 변경합니다.
6. CommandButton1이라고 하는 두 번째 액세스 컨트롤에 접근합니다.
7. 버튼 캡션, 글꼴 및 위치를 변경합니다.
8. ActiveX 컨트롤 프레임의 위치를 이동합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 코드 스니펫은 프레젠테이션 슬라이드의 ActiveX 컨트롤을 아래와 같이 업데이트합니다.

``` cpp
// ActiveX 컨트롤이 있는 프레젠테이션에 접근
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// 프레젠테이션의 첫 번째 슬라이드에 접근
auto slide = presentation->get_Slides()->idx_get(0);

// changing TextBox text
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // 대체 이미지 변경. PowerPoint는 ActiveX 활성화 시 이 이미지를 교체하므로, 경우에 따라 이미지를 그대로 두어도 됩니다.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// 버튼 캡션 변경
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // 대체 이미지 변경
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// ActiveX 프레임을 100 포인트 아래로 이동
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// 편집된 ActiveX 컨트롤이 포함된 프레젠테이션 저장
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// 이제 컨트롤을 제거합니다
slide->get_Controls()->Clear();

// 정리된 ActiveX 컨트롤이 포함된 프레젠테이션 저장
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Media Player ActiveX 컨트롤 추가**
ActiveX 컨트롤은 프레젠테이션에서 사용됩니다. Aspose.Slides for C++는 ActiveX 컨트롤을 추가하고 관리할 수 있게 해주지만, 관리가 약간 더 까다롭고 일반 프레젠테이션 도형과는 다릅니다. Aspose.Slides for C++ 18.1부터 Media Player ActiveX 컨트롤 추가 지원이 Aspose.Slides에 추가되었습니다. 기억하십시오, ActiveX 컨트롤은 도형이 아니며 프레젠테이션의 IShapeCollection에 포함되지 않고 별도의 IControlExCollection에 포함됩니다. 이 문서에서는 이를 사용하는 방법을 보여줍니다. Media Player ActiveX 컨트롤을 관리하려면 다음 단계를 수행하십시오:

1. Presentation 클래스를 인스턴스화하고 Media Player ActiveX 컨트롤이 포함된 샘플 프레젠테이션을 로드합니다.
2. 대상 Presentation 클래스를 인스턴스화하고 빈 프레젠테이션 인스턴스를 생성합니다.
3. 템플릿 프레젠테이션의 Media Player ActiveX 컨트롤이 있는 슬라이드를 대상 Presentation에 복제합니다.
4. 대상 Presentation에서 복제된 슬라이드에 접근합니다.
5. IControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
6. Media Player ActiveX 컨트롤에 접근하고 해당 속성을 사용해 비디오 경로를 설정합니다.
7. 프레젠테이션을 PPTX 파일로 저장합니다.

``` cpp
// PPTX 파일을 나타내는 Presentation 클래스 인스턴스화
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// 빈 프레젠테이션 인스턴스 생성
auto newPresentation = System::MakeObject<Presentation>();

// 기본 슬라이드 제거
newPresentation->get_Slides()->RemoveAt(0);

// Media Player ActiveX 컨트롤이 있는 슬라이드 복제
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Media Player ActiveX 컨트롤에 접근하여 비디오 경로 설정
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// 프레젠테이션 저장
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**C++ 런타임에서 실행될 수 없을 경우에도 Aspose.Slides가 ActiveX 컨트롤을 읽고 다시 저장할 때 보존합니까?**

예. Aspose.Slides는 이를 프레젠테이션의 일부로 취급하며, 해당 속성과 프레임을 읽고 수정할 수 있습니다; 컨트롤 자체를 실행할 필요는 없습니다.

**ActiveX 컨트롤은 프레젠테이션의 OLE 객체와 어떻게 다릅니까?**

ActiveX 컨트롤은 인터랙티브하게 관리되는 컨트롤(버튼, 텍스트 상자, 미디어 플레이어)이며, 반면 [OLE](/slides/ko/cpp/manage-ole/)는 삽입된 애플리케이션 객체(예: Excel 워크시트)를 의미합니다. 두 경우는 저장 및 처리 방식이 다르고 속성 모델도 다릅니다.

**파일이 Aspose.Slides에 의해 수정된 경우에도 ActiveX 이벤트와 VBA 매크로가 작동합니까?**

Aspose.Slides는 기존 마크업과 메타데이터를 보존합니다; 그러나 이벤트와 매크로는 보안 설정이 허용되는 경우에만 Windows의 PowerPoint 내에서 실행됩니다. 이 라이브러리는 VBA를 실행하지 않습니다.