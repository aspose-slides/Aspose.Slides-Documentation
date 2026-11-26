---
title: Java 프레젠테이션에서 ActiveX 컨트롤 관리
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
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 ActiveX 텍스트 상자와 버튼을 편집하고, 컨트롤 미리보기를 업데이트하며, Windows Media Player 컨트롤을 재사용합니다."
---
## **소개**

ActiveX 컨트롤은 PowerPoint 슬라이드에 텍스트 상자, 명령 버튼, 미디어 플레이어와 같은 대화형 요소를 제공합니다. Aspose.Slides for Java는 슬라이드의 컨트롤을 [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--)을 통해 노출합니다. 이 컬렉션을 사용하여 컨트롤을 편집하거나 슬라이드에서 이동하거나 제거할 수 있습니다.

## **ActiveX 컨트롤 및 저장된 속성 목록**

익숙하지 않은 템플릿을 검사하려면 읽기 모드로 열고 각 슬라이드의 컨트롤을 반복합니다. 예제는 슬라이드 번호, 컨트롤 이름, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), 및 [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--)의 각 키-값 쌍을 보고합니다. 이 코드는 컨트롤을 활성화하거나 이벤트·매크로를 호출하지 않고, 값을 변경하거나 파일을 저장하지 않은 상태로 프레젠테이션을 읽습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`ActiveX.pptm`의 선택된 출력은 텍스트 상자와 명령 버튼을 보여줍니다.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

빈 속성 컬렉션은 `[]`로 표시됩니다. 이진 저장을 사용하는 컨트롤의 경우 [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--)는 `null`을 반환할 수 있으며, 이는 `Properties unavailable`으로 표시됩니다. 이름만 필요한 경우 null 확인 후 [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--)를 사용하십시오. 보고서는 프레젠테이션에서 사용할 수 있는 속성을 나열합니다. 컨트롤은 런타임에 추가 속성을 지원할 수도 있습니다.

## **ActiveX 컨트롤 수정**

예제는 첫 번째 슬라이드에 `TextBox1`이라는 텍스트 상자와 `CommandButton1`이라는 명령 버튼이 있는 매크로 사용 프레젠테이션을 기대합니다. [컨트롤 속성 컬렉션](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/)을 사용하여 텍스트 상자 값과 버튼 캡션을 변경합니다. 각 컨트롤에는 활성화 전에 PowerPoint가 표시할 수 있는 정적 미리보기가 있습니다. 업데이트된 텍스트와 모양을 보여주는 PNG를 각 컨트롤에 제공합니다. 예제는 이러한 이미지를 [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--)을 통해 할당합니다.

예제는 [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-)을 사용해 첫 번째 슬라이드의 모든 컨트롤을 100포인트 아래로 이동합니다. 편집된 프레젠테이션을 PPTM 형식으로 저장한 후, [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--)를 사용하여 해당 슬라이드에서 모든 ActiveX 컨트롤이 제거된 두 번째 복사본을 저장합니다.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **ActiveX 미디어 플레이어 컨트롤 추가**

구성된 Windows Media Player 컨트롤을 재사용하려면 첫 번째 슬라이드에 `WindowsMediaPlayer1`이라는 플레이어가 포함된 템플릿으로 시작합니다. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)은 전체 슬라이드를 새 프레젠테이션에 복사합니다. 예제는 플레이어의 `URL`을 [속성 컬렉션](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/)에 설정하고 복제된 슬라이드를 출력의 유일한 슬라이드로 저장합니다. 비디오는 외부에 남아 있으므로 재생 중에 플레이어가 접근할 수 있는 경로를 선택하십시오.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Aspose.Slides가 ActiveX 컨트롤을 실행하지 않고도 보존할 수 있나요?**

예. Aspose.Slides는 컨트롤을 활성화하지 않고도 해당 속성과 위치를 포함하여 읽고 저장할 수 있습니다.

**ActiveX 컨트롤은 OLE 객체와 어떻게 다릱니까?**

ActiveX 컨트롤은 사용자가 슬라이드와 상호작용하도록 하며, 예를 들어 텍스트 입력이나 버튼 클릭을 할 수 있게 합니다. [OLE 객체](/slides/ko/java/manage-ole/)는 슬라이드가 다른 애플리케이션에서 관리하는 콘텐츠(예: Excel 워크시트)를 포함하거나 연결하도록 합니다.

**Aspose.Slides로 프레젠테이션을 저장한 후에도 ActiveX 이벤트가 VBA 매크로를 트리거합니까?**

프레젠테이션을 PPTM과 같은 매크로 사용 형식으로 저장하면 VBA 프로젝트가 유지됩니다. PowerPoint for Windows는 보안 설정에서 ActiveX 컨트롤과 매크로 모두를 허용할 경우 기존 이벤트 처리기를 실행할 수 있습니다.