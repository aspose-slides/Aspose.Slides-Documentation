---
title: .NET에서 프레젠테이션의 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/net/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 ActiveX를 활용하여 PowerPoint 프레젠테이션을 자동화하고 향상시키는 방법을 배우고, 개발자에게 슬라이드에 대한 강력한 제어 권한을 제공합니다."
---
## **소개**

ActiveX 컨트롤은 프레젠테이션에서 사용됩니다. Aspose.Slides for .NET을 사용하면 ActiveX 컨트롤을 관리할 수 있지만, 관리가 약간 까다롭고 일반 프레젠테이션 도형과 다릅니다. Aspose.Slides for .NET 6.9.0부터 이 구성 요소는 ActiveX 컨트롤 관리를 지원합니다. 현재는 프레젠테이션에 이미 추가된 ActiveX 컨트롤에 접근하여 다양한 속성을 사용해 수정하거나 삭제할 수 있습니다. ActiveX 컨트롤은 도형이 아니며 프레젠테이션의 IShapeCollection에 포함되지 않고 별도의 IControlCollection에 포함된다는 점을 기억하십시오. 이 문서에서는 해당 컨트롤을 사용하는 방법을 보여줍니다.

## **ActiveX 컨트롤 수정**
슬라이드에서 텍스트 상자와 간단한 명령 버튼과 같은 기본 ActiveX 컨트롤을 관리하려면:

1. Presentation 클래스를 인스턴스화하고 ActiveX 컨트롤이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 슬라이드 참조를 얻습니다.
1. IControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
1. ControlEx 객체를 사용하여 TextBox1 ActiveX 컨트롤에 접근합니다.
1. 텍스트, 글꼴, 글꼴 높이 및 프레임 위치 등을 포함하여 TextBox1 ActiveX 컨트롤의 다양한 속성을 변경합니다.
1. CommandButton1이라는 두 번째 액세스 컨트롤에 접근합니다.
1. 버튼 캡션, 글꼴 및 위치를 변경합니다.
1. ActiveX 컨트롤 프레임의 위치를 이동합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 코드 조각은 프레젠테이션 슬라이드의 ActiveX 컨트롤을 아래와 같이 업데이트합니다.

```c#
// ActiveX 컨트롤이 있는 프레젠테이션에 접근
Presentation presentation = new Presentation("ActiveX.pptm");

// 프레젠테이션의 첫 번째 슬라이드에 접근
ISlide slide = presentation.Slides[0];

// TextBox 텍스트 변경
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // 대체 이미지 변경. PowerPoint는 ActiveX 활성화 중 이 이미지를 교체하므로, 때때로 이미지를 변경하지 않은 상태로 두어도 괜찮습니다.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// 버튼 캡션 변경
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // 대체 이미지 변경
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// ActiveX 프레임을 100 포인트 아래로 이동
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// 편집된 ActiveX 컨트롤이 포함된 프레젠테이션 저장
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// 이제 컨트롤을 제거합니다
slide.Controls.Clear();

// 정리된 ActiveX 컨트롤이 포함된 프레젠테이션 저장
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **ActiveX 미디어 플레이어 컨트롤 추가**
ActiveX Media Player 컨트롤을 추가하려면 다음 단계를 수행하십시오:

1. Presentation 클래스를 인스턴스화하고 Media Player ActiveX 컨트롤이 포함된 샘플 프레젠테이션을 로드합니다.
1. 대상 Presentation 클래스를 인스턴스화하고 빈 프레젠테이션 인스턴스를 생성합니다.
1. 템플릿 프레젠테이션에서 Media Player ActiveX 컨트롤이 있는 슬라이드를 대상 Presentation에 복제합니다.
1. 대상 Presentation에서 복제된 슬라이드에 접근합니다.
1. IControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
1. Media Player ActiveX 컨트롤에 접근하고 해당 속성을 사용하여 비디오 경로를 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화
Presentation presentation = new Presentation("template.pptx");

// 빈 프레젠테이션 인스턴스를 생성
Presentation newPresentation = new Presentation();

// 기본 슬라이드 제거
newPresentation.Slides.RemoveAt(0);

// Media Player ActiveX 컨트롤이 있는 슬라이드 복제
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Media Player ActiveX 컨트롤에 접근하고 비디오 경로를 설정
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// 프레젠테이션 저장
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides가 .NET 런타임에서 실행될 수 없을 경우에도 읽고 다시 저장할 때 ActiveX 컨트롤을 보존합니까?**

예. Aspose.Slides는 이를 프레젠테이션의 일부로 취급하며 속성과 프레임을 읽고 수정할 수 있습니다; 컨트롤 자체를 실행할 필요는 없습니다.

**프레젠테이션에서 ActiveX 컨트롤은 OLE 객체와 어떻게 다릅니까?**

ActiveX 컨트롤은 인터랙티브한 관리형 컨트롤(버튼, 텍스트 상자, 미디어 플레이어)이며, [OLE](/slides/ko/net/manage-ole/)는 임베드된 애플리케이션 객체(예: Excel 워크시트)를 의미합니다. 이들은 저장 방식과 처리 방식이 다르고 속성 모델도 다릅니다.

**Aspose.Slides가 파일을 수정한 경우 ActiveX 이벤트와 VBA 매크로가 작동합니까?**

Aspose.Slides는 기존 마크업 및 메타데이터를 보존하지만, 이벤트와 매크로는 보안이 허용될 때 Windows의 PowerPoint 내부에서만 실행됩니다. 이 라이브러리는 VBA를 실행하지 않습니다.