---
title: Java를 사용하여 프레젠테이션에서 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/java/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 ActiveX를 활용하여 PowerPoint 프레젠테이션을 자동화하고 향상시키는 방법을 배우고, 개발자에게 슬라이드에 대한 강력한 제어 권한을 제공합니다."
---
## **소개**

ActiveX 컨트롤은 프레젠테이션에서 사용됩니다. Aspose.Slides for Java를 사용하면 ActiveX 컨트롤을 추가하고 관리할 수 있지만 일반 프레젠테이션 도형에 비해 관리가 다소 까다롭습니다. Aspose.Slides에 Media Player Active 컨트롤 추가 지원을 구현했습니다. ActiveX 컨트롤은 도형이 아니며 프레젠테이션의[IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/)에 포함되지 않습니다. 대신 별도의[IControlCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icontrolcollection/)에 포함됩니다. 이 항목에서는 해당 컨트롤을 사용하는 방법을 보여드립니다. 

## **슬라이드에 Media Player ActiveX 컨트롤 추가**
ActiveX Media Player 컨트롤을 추가하려면 다음을 수행하십시오:

1. Presentation 클래스의 인스턴스를 생성하고 빈 프레젠테이션 인스턴스를 생성합니다.
2. Presentation에서 대상 슬라이드에 접근합니다.
3. IControlCollection에서 제공하는 addControl 메서드를 사용하여 Media Player ActiveX 컨트롤을 추가합니다.
4. Media Player ActiveX 컨트롤에 접근하고 해당 속성을 사용하여 비디오 경로를 설정합니다.
5. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 샘플 코드는 위 단계에 따라 슬라이드에 Media Player ActiveX 컨트롤을 추가하는 방법을 보여줍니다:

```java
// 빈 프레젠테이션 인스턴스 생성
Presentation pres = new Presentation();
try {
    // Media Player ActiveX 컨트롤 추가
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Media Player ActiveX 컨트롤에 접근하고 비디오 경로 설정
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // 프레젠테이션 저장
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ActiveX 컨트롤 수정**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 및 이후 버전에는 ActiveX 컨트롤을 관리하기 위한 구성 요소가 포함되어 있습니다. 프레젠테이션에 이미 추가된 ActiveX 컨트롤에 접근하여 속성을 통해 수정하거나 삭제할 수 있습니다.

{{% /alert %}} 

슬라이드에서 텍스트 상자 및 간단한 명령 버튼과 같은 단순한 ActiveX 컨트롤을 관리하려면 다음과 같이 수행합니다:

1. Presentation 클래스의 인스턴스를 생성하고 ActiveX 컨트롤이 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. IControlCollection에 접근하여 슬라이드의 ActiveX 컨트롤에 접근합니다.
4. IControl 객체를 사용하여 TextBox1 ActiveX 컨트롤에 접근합니다.
5. 텍스트, 글꼴, 글꼴 높이 및 프레임 위치를 포함하는 TextBox1 ActiveX 컨트롤의 속성을 변경합니다.
6. CommandButton1이라는 두 번째 액세스 컨트롤에 접근합니다.
7. 버튼 캡션, 글꼴 및 위치를 변경합니다.
8. ActiveX 컨트롤 프레임의 위치를 이동합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 기록합니다.

아래 샘플 코드는 위 단계에 따라 단순한 ActiveX 컨트롤을 관리하는 방법을 보여줍니다: 

```java
// ActiveX 컨트롤이 포함된 프레젠테이션에 접근
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // 프레젠테이션의 첫 번째 슬라이드에 접근
    ISlide slide = pres.getSlides().get_Item(0);

    // TextBox 텍스트 변경
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // 대체 이미지를 변경합니다. PowerPoint는 ActiveX 활성화 중에 이 이미지를 교체합니다,
        // 따라서 경우에 따라 이미지를 그대로 두어도 괜찮습니다.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // 버튼 캡션 변경
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 대체 이미지 변경
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // 100 포인트 아래로 이동
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // 컨트롤 제거
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

**Aspose.Slides는 Java 런타임에서 실행될 수 없더라도 읽고 다시 저장할 때 ActiveX 컨트롤을 보존합니까?**

예. Aspose.Slides는 이를 프레젠테이션의 일부로 간주하며 속성 및 프레임을 읽고 수정할 수 있습니다; 컨트롤 자체를 실행하지 않아도 보존됩니다.

**ActiveX 컨트롤은 프레젠테이션의 OLE 객체와 어떻게 다릅니까?**

ActiveX 컨트롤은 인터랙티브하게 관리되는 컨트롤(버튼, 텍스트 상자, 미디어 플레이어)이며, 반면 [OLE](/slides/ko/java/manage-ole/)는 삽입된 애플리케이션 객체(예: Excel 워크시트)를 의미합니다. 이들은 저장 및 처리 방식이 다르며 속성 모델도 다릅니다.

**파일이 Aspose.Slides에 의해 수정된 경우 ActiveX 이벤트와 VBA 매크로가 작동합니까?**

Aspose.Slides는 기존 마크업과 메타데이터를 보존하지만, 이벤트와 매크로는 보안이 허용되는 경우에만 Windows의 PowerPoint 내에서 실행됩니다. 이 라이브러리는 VBA를 실행하지 않습니다.