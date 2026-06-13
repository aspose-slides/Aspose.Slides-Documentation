---
title: JavaScript를 사용하여 프레젠테이션에서 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java가 ActiveX를 활용하여 PowerPoint 프레젠테이션을 자동화하고 향상시키는 방법을 배우고, 개발자에게 슬라이드에 대한 강력한 제어 기능을 제공합니다."
---
## **소개**

ActiveX 컨트롤은 프레젠테이션에서 사용됩니다. Aspose.Slides for Node.js via Java를 사용하면 ActiveX 컨트롤을 추가하고 관리할 수 있지만 일반 프레젠테이션 도형에 비해 관리가 다소 복잡합니다. 우리는 Aspose.Slides에 Media Player Active 컨트롤 추가 지원을 구현했습니다. ActiveX 컨트롤은 도형이 아니며 프레젠테이션의 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/)에 포함되지 않습니다. 대신 별도의 [ControlCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/controlcollection/)의 일부입니다. 이 항목에서는 해당 컨트롤을 사용하는 방법을 보여드립니다.

## **슬라이드에 Media Player ActiveX 컨트롤 추가**
ActiveX Media Player 컨트롤을 추가하려면 다음과 같이 수행합니다:

1. Presentation 클래스의 인스턴스를 생성하고 빈 프레젠테이션 인스턴스를 만듭니다.
1. Presentation에서 대상 슬라이드에 접근합니다.
1. ControlCollection에서 제공하는 [addControl](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) 메서드를 사용하여 Media Player ActiveX 컨트롤을 추가합니다.
1. Media Player ActiveX 컨트롤에 접근하고 해당 속성을 사용하여 비디오 경로를 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계에 기반한 샘플 코드는 슬라이드에 Media Player ActiveX 컨트롤을 추가하는 방법을 보여줍니다:

```javascript
// 빈 프레젠테이션 인스턴스 생성
var pres = new aspose.slides.Presentation();
try {
    // Media Player ActiveX 컨트롤 추가
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Media Player ActiveX 컨트롤에 접근하고 비디오 경로 설정
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // 프레젠테이션 저장
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ActiveX 컨트롤 수정**
슬라이드에서 텍스트 상자와 간단한 명령 버튼과 같은 간단한 ActiveX 컨트롤을 관리하려면 다음과 같이 수행합니다:

1. Presentation 클래스의 인스턴스를 생성하고 ActiveX 컨트롤이 포함된 프레젠테이션을 로드합니다.
1. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
1. ControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
1. Control 객체를 사용하여 TextBox1 ActiveX 컨트롤에 접근합니다.
1. 텍스트, 폰트, 폰트 높이 및 프레임 위치를 포함하는 TextBox1 ActiveX 컨트롤의 속성을 변경합니다.
1. CommandButton1이라고 하는 두 번째 액세스 컨트롤에 접근합니다.
1. 버튼 캡션, 폰트 및 위치를 변경합니다.
1. ActiveX 컨트롤 프레임의 위치를 이동합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 기록합니다.

위 단계에 기반한 샘플 코드는 간단한 ActiveX 컨트롤을 관리하는 방법을 보여줍니다:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// ActiveX 컨트롤이 포함된 프레젠테이션에 접근
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // 프레젠테이션의 첫 번째 슬라이드에 접근
    var slide = pres.getSlides().get_Item(0);
    // 텍스트 상자 텍스트 변경
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // 대체 이미지 변경. PowerPoint는 ActiveX 활성화 중에 이 이미지를 교체합니다,
        // 따라서 경우에 따라 이미지를 그대로 두어도 됩니다.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 버튼 캡션 변경
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 대체 이미지 변경
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 100 포인트 아래로 이동
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // 컨트롤 제거
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Aspose.Slides가 Python 런타임에서 실행될 수 없더라도 읽고 다시 저장할 때 ActiveX 컨트롤을 보존합니까?**

예. Aspose.Slides는 이를 프레젠테이션의 일부로 간주하며 해당 속성과 프레임을 읽고 수정할 수 있습니다. 컨트롤 자체를 실행할 필요 없이 보존됩니다.

**ActiveX 컨트롤은 프레젠테이션의 OLE 객체와 어떻게 다릅니까?**

ActiveX 컨트롤은 인터랙티브한 관리형 컨트롤(버튼, 텍스트 상자, 미디어 플레이어)이며, 반면 [OLE](/slides/ko/nodejs-java/manage-ole/)은 임베드된 애플리케이션 객체(예: Excel 워크시트)를 의미합니다. 이들은 저장 및 처리 방식이 다르며 속성 모델도 다릅니다.

**파일이 Aspose.Slides에 의해 수정된 경우 ActiveX 이벤트와 VBA 매크로가 작동합니까?**

Aspose.Slides는 기존 마크업과 메타데이터를 보존하지만, 이벤트와 매크로는 보안이 허용되는 Windows의 PowerPoint에서만 실행됩니다. 이 라이브러리는 VBA를 실행하지 않습니다.