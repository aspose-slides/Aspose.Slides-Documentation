---
title: Python으로 프레젠테이션에서 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/python-net/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET가 ActiveX를 활용해 PowerPoint 프레젠테이션을 자동화 및 향상시키는 방법을 배우고, 개발자에게 슬라이드에 대한 강력한 제어 권한을 제공합니다."
---
## **Introduction**

ActiveX 컨트롤은 프레젠테이션에서 사용됩니다. Aspose.Slides for Python via .NET을 사용하면 ActiveX 컨트롤을 관리할 수 있지만, 관리가 약간 더 까다롭고 일반 프레젠테이션 셰이프와 다릅니다. Aspose.Slides for Python via .NET 6.9.0부터 이 컴포넌트는 ActiveX 컨트롤 관리 기능을 지원합니다. 현재 프레젠테이션에 이미 추가된 ActiveX 컨트롤에 접근하여 다양한 속성을 활용해 수정하거나 삭제할 수 있습니다. 참고로 ActiveX 컨트롤은 셰이프가 아니며 프레젠테이션의 IShapeCollection이 아닌 별도 IControlCollection에 포함됩니다. 이 문서에서는 해당 컨트롤을 다루는 방법을 보여줍니다.
## **Modify ActiveX Controls**
슬라이드에서 텍스트 박스와 간단한 커맨드 버튼 같은 ActiveX 컨트롤을 관리하려면:

1. Presentation 클래스를 인스턴스화하고 ActiveX 컨트롤이 포함된 프레젠테이션을 로드합니다.
1. 인덱스를 사용하여 슬라이드 참조를 얻습니다.
1. IControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
1. ControlEx 객체를 사용하여 TextBox1 ActiveX 컨트롤에 접근합니다.
1. 텍스트, 글꼴, 글꼴 높이 및 프레임 위치를 포함한 TextBox1 ActiveX 컨트롤의 다양한 속성을 변경합니다.
1. CommandButton1이라는 두 번째 액세스 컨트롤에 접근합니다.
1. 버튼 캡션, 글꼴 및 위치를 변경합니다.
1. ActiveX 컨트롤 프레임의 위치를 이동합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# ActiveX 컨트롤이 포함된 프레젠테이션에 접근
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # 프레젠테이션의 첫 번째 슬라이드에 접근
    slide = presentation.slides[0]

    # TextBox 텍스트 변경
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # 대체 이미지 변경. PowerPoint가 ActiveX 활성화 시 이 이미지를 교체하므로, 때때로 이미지를 그대로 두어도 됩니다.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # 버튼 캡션 변경
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # 대체 이미지 변경
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # ActiveX 프레임을 100포인트 아래로 이동
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # 편집된 ActiveX 컨트롤이 포함된 프레젠테이션 저장
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # 이제 컨트롤을 제거합니다
    slide.controls.clear()

    # 제거된 ActiveX 컨트롤이 포함된 프레젠테이션 저장
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Add ActiveX Media Player Control**
ActiveX Media Player 컨트롤을 추가하려면 다음 단계를 수행하십시오:

1. Presentation 클래스를 인스턴스화하고 Media Player ActiveX 컨트롤이 포함된 샘플 프레젠테이션을 로드합니다.
1. 대상 Presentation 클래스를 인스턴스화하고 빈 프레젠테이션 인스턴스를 생성합니다.
1. 템플릿 프레젠테이션에서 Media Player ActiveX 컨트롤이 포함된 슬라이드를 대상 Presentation에 복제합니다.
1. 대상 Presentation에서 복제된 슬라이드에 접근합니다.
1. IControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
1. Media Player ActiveX 컨트롤에 접근하고 해당 속성을 사용해 비디오 경로를 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화
with slides.Presentation(path + "template.pptx") as presentation:

    # 빈 프레젠테이션 인스턴스를 생성
    with slides.Presentation() as newPresentation:

        # 기본 슬라이드 제거
        newPresentation.slides.remove_at(0)

        # Media Player ActiveX 컨트롤이 있는 슬라이드 복제
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Media Player ActiveX 컨트롤에 접근하고 비디오 경로를 설정
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # 프레젠테이션 저장
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Python runtime?**

네. Aspose.Slides는 이를 프레젠테이션의 일부로 간주하며 속성과 프레임을 읽고 수정할 수 있습니다. 컨트롤 자체를 실행할 필요 없이도 보존됩니다.

**How do ActiveX controls differ from OLE objects in a presentation?**

ActiveX 컨트롤은 인터랙티브한 관리형 컨트롤(버튼, 텍스트 박스, 미디어 플레이어)이며, 반면 [OLE](/slides/ko/python-net/manage-ole/)는 삽입된 애플리케이션 객체(예: Excel 워크시트)를 의미합니다. 이들은 저장 방식과 처리 방식이 다르며 속성 모델도 다릅니다.

**Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?**

Aspose.Slides는 기존 마크업과 메타데이터를 보존합니다. 다만 이벤트와 매크로는 보안 설정이 허용되는 경우에만 Windows의 PowerPoint 내에서 실행됩니다. 이 라이브러리는 VBA를 실행하지 않습니다.