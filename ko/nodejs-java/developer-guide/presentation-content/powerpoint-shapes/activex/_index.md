---
title: JavaScript를 사용한 프레젠테이션의 ActiveX 컨트롤 관리
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
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 ActiveX 텍스트 상자와 버튼을 편집하고, 컨트롤 미리보기를 업데이트하며, Windows Media Player 컨트롤을 재사용합니다."
---
## **소개**

ActiveX 컨트롤은 텍스트 상자, 명령 단추 및 미디어 플레이어와 같은 대화형 요소를 PowerPoint 슬라이드에 제공합니다. Aspose.Slides for Node.js via Java는 슬라이드의 컨트롤을 [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) 를 통해 노출합니다. 이 컬렉션을 사용하여 컨트롤을 편집하고, 슬라이드에서 이동시키거나 제거할 수 있습니다.

## **ActiveX 컨트롤 및 해당 저장 속성 목록**

익숙하지 않은 템플릿을 검사하려면 템플릿을 읽기 모드로 열고 각 슬라이드의 컨트롤을 반복합니다. 예제는 슬라이드 번호, 컨트롤 이름, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), 그리고 [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) 에 있는 각 키-값 쌍을 보고합니다. 이 코드는 컨트롤을 활성화하거나 이벤트·매크로를 호출하지 않고, 값을 변경하거나 파일을 저장하지 않은 채 프레젠테이션을 읽습니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`ActiveX.pptm`의 선택된 출력은 텍스트 상자와 명령 단추를 보여줍니다.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

빈 속성 컬렉션은 `[]` 로 표시됩니다. 바이너리 저장소를 사용하는 컨트롤의 경우, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) 가 `null` 을 반환할 수 있으며, 이는 `Properties unavailable` 로 표시됩니다. 이름만 필요하면 null 확인 후 [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) 를 사용하십시오. 보고서는 프레젠테이션에서 사용할 수 있는 속성을 나열합니다. 컨트롤은 실행 시 추가 속성을 지원할 수 있습니다.

## **ActiveX 컨트롤 수정**

이 예제는 첫 번째 슬라이드에 `TextBox1` 이라는 이름의 텍스트 상자와 `CommandButton1` 이라는 이름의 명령 단추가 있는 매크로 사용 가능 프레젠테이션을 전제로 합니다. 텍스트 상자 값과 단추 캡션을 변경하기 위해 [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) 을 사용합니다. 각 컨트롤은 활성화 전에 PowerPoint이 표시할 수 있는 정적 미리보기를 갖습니다. 업데이트된 텍스트와 모양을 보여주는 PNG 파일을 각 컨트롤에 제공하십시오. 예제는 이러한 이미지를 [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) 을 통해 할당합니다.

예제는 [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) 으로 프레임을 설정하여 첫 번째 슬라이드의 모든 컨트롤을 100포인트 아래로 이동합니다. 편집된 프레젠테이션을 PPTM 형식으로 저장한 다음, [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) 을 사용하여 해당 슬라이드에서 모든 ActiveX 컨트롤이 제거된 두 번째 사본을 저장합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **ActiveX 미디어 플레이어 컨트롤 추가**

구성된 Windows Media Player 컨트롤을 재사용하려면 첫 번째 슬라이드에 `WindowsMediaPlayer1` 이라는 플레이어가 포함된 템플릿으로 시작합니다. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) 은 전체 슬라이드를 새로운 프레젠테이션으로 복사합니다. 예제는 플레이어의 `URL` 을 해당 [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) 에 설정하고, 복제된 슬라이드를 출력의 유일한 슬라이드로 저장합니다. 비디오는 외부에 유지되므로 재생 중에 플레이어가 접근할 수 있는 경로를 선택하십시오.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **자주 묻는 질문**

**Aspose.Slides가 ActiveX 컨트롤을 실행하지 않고 보존할 수 있나요?**

예. Aspose.Slides는 컨트롤을 활성화하지 않고도 해당 속성과 위치를 포함하여 읽고 저장할 수 있습니다.

**ActiveX 컨트롤은 OLE 개체와 어떻게 다릅니까?**

ActiveX 컨트롤은 사용자가 텍스트를 입력하거나 버튼을 클릭하는 등 슬라이드와 상호 작용할 수 있게 합니다. [OLE 개체](/slides/ko/nodejs-java/manage-ole/) 은 슬라이드에 다른 응용 프로그램이 관리하는 콘텐츠(예: Excel 워크시트)를 포함하거나 연결하도록 합니다.

**Aspose.Slides로 프레젠테이션을 저장한 후에도 ActiveX 이벤트가 VBA 매크로를 여전히 트리거합니까?**

프레젠테이션을 PPTM과 같은 매크로 사용 가능 형식으로 저장하면 VBA 프로젝트가 유지됩니다. PowerPoint for Windows는 보안 설정에서 ActiveX 컨트롤과 매크로 모두를 허용할 경우 기존 이벤트 핸들러를 실행할 수 있습니다.