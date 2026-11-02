---
title: Android에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/androidjava/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 생성
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 변경 가능한 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java 예제를 사용하여 Android용 Aspose.Slides를 통해 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 콘텐츠를 웹사이트 또는 프레젠테이션 내부의 위치와 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 용도로 사용됩니다:

* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 목차와 같이 다른 슬라이드로 이동합니다.

Aspose.Slides for Android via Java를 사용하면 이러한 링크를 추가하고, 모양과 소리를 제어하며, 속성을 업데이트하고, 제거할 수 있습니다. 아래 예제에서는 개별 요소에 대한 하이퍼링크 작업 방법과 프레젠테이션, 슬라이드, 텍스트 프레임 수준에서 하이퍼링크에 접근하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
프레젠테이션을 [무료 온라인 Aspose PowerPoint 편집기](https://products.aspose.app/slides/editor)로 편집할 수도 있습니다.
{{% /alert %}} 

## **URL 하이퍼링크 추가**

텍스트, 도형 또는 미디어 프레임에 웹사이트 URL을 할당할 수 있습니다. 하이퍼링크를 할당하는 요소에 따라 클릭 가능한 영역이 결정됩니다: 텍스트 부분은 선택된 텍스트에만 링크가 적용되고, 도형이나 프레임은 슬라이드 개체 전체에 링크가 적용됩니다.

프레젠테이션에 상대 하이퍼링크가 포함된 경우, 문서 수준 기본값을 읽고, 변경하고, 지우려면 [하이퍼링크 기본값 관리](/slides/ko/androidjava/presentation-properties/#manage-the-hyperlink-base)를 참조하세요.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면, 아래와 같이 텍스트 부분의 [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) 메서드에 [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) 객체를 전달합니다. 해당 텍스트 부분만 클릭 가능해집니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **도형 및 미디어 프레임에 URL 하이퍼링크 추가**

도형이나 프레임을 클릭 가능하게 만들려면 해당 객체의 [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) 메서드를 호출합니다. 하이퍼링크는 텍스트 부분이 아니라 객체 자체에 속합니다.

그림, 오디오, 비디오 프레임에도 동일한 방법을 적용합니다: 프레임에 하이퍼링크를 할당하고 필요하면 [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-)을 호출합니다.

다음 예제는 사각형을 클릭 가능하게 만듭니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **목차 만들기에 하이퍼링크 사용**

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 아래 예제는 첫 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결하기 위해 [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-)을 사용합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **하이퍼링크 서식 지정**

### **색상**

[IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/)의 [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) 메서드는 하이퍼링크가 프레젠테이션 전체 하이퍼링크 색상을 사용할지 텍스트 부분의 서식을 사용할지 결정합니다. 사용자 지정 텍스트 색상을 적용하려면 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/)을 선택하고 부분의 채우기 색을 설정합니다. 이 기능은 PowerPoint 2019에서 도입되었으며 이전 버전에서는 적용되지 않습니다.

다음 예제는 같은 슬라이드에 두 개의 텍스트 하이퍼링크를 추가합니다. 첫 번째는 빨간색 텍스트 채우기를 사용하고, 두 번째는 기본 하이퍼링크 색상을 유지합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **소리**

하이퍼링크를 활성화할 때 소리를 재생하거나 이미 재생 중인 소리를 중지할 수 있습니다. 다음 메서드를 사용해 동작을 구성하세요:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-)은 하이퍼링크와 연결된 오디오를 지정합니다.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-)은 하이퍼링크를 활성화할 때 이전 소리를 중지할지 여부를 제어합니다.

#### **하이퍼링크 소리 추가**

다음 예제는 `sampleaudio.wav` 파일을 로드하고 첫 슬라이드의 버튼에 연결합니다. 버튼을 클릭하면 소리가 재생되고 다음 슬라이드로 이동합니다. 같은 슬라이드의 두 번째 도형은 클릭 시 이전 소리를 중지하지만 네비게이션 동작은 수행하지 않습니다.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **하이퍼링크 소리 추출**

다음 예제는 앞서 만든 프레젠테이션을 열고 첫 도형의 하이퍼링크 오디오를 [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) 및 [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--)을 통해 메모리로 읽어옵니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **툴팁 및 상호 작용 설정**

텍스트나 도형에 하이퍼링크를 할당한 후 다음 [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) 메서드를 호출할 수 있습니다:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-)은 사용자가 링크에 대한 힌트로 표시할 텍스트를 설정합니다.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-)은 적용 가능한 경우 상위 HTML 프레임셋 내 목표 프레임을 지정합니다.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-)은 링크를 활성화했을 때 대상이 본 하이퍼링크 목록에 추가될지 여부를 제어합니다.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-)은 클릭 시 하이퍼링크가 강조 표시될지 여부를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

[getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--)을 사용해 텍스트 부분 링크를 포함한 모든 하이퍼링크 컨테이너를 수집한 후 변경합니다. 다음 예제는 첫 슬라이드에서 두 가지 활성화 유형을 모두 제거합니다. 하나만 제거하려면 [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) 또는 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)만 호출하면 됩니다; 클릭 동작을 제거해도 마우스 오버 동작은 남습니다.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

조건 없이 모두 제거하려면 [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--)을 사용해 선택된 범위 내 두 활성화 유형을 한 번에 삭제합니다. 마스터, 레이아웃, 노트 등을 포함한 선택적 정리와 범위 적용 방법은 [하이퍼링크 보고, 정리 및 검증](#report-sanitize-and-verify-hyperlinks)을 참조하세요.

## **전체 하이퍼링크 인벤토리 작성**

프레젠테이션을 배포하기 전에 인터랙티브 동작과 웹 링크를 모두 조사하십시오. [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--)은 [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) 객체를 반환하며, 단순 URL 문자열 목록을 반환하지 않습니다. 각 컨테이너에서 [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--)과 [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--)을 모두 검사하세요. 두 메서드는 독립적이며, 하나의 컨테이너가 두 동작을 모두 가질 수 있기 때문에 완전한 보고서에는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 연결된 링크를 놓칠 수 있습니다. 적절한 범위에 대해 쿼리하고 반환된 컨테이너를 보관해 나중에 동작을 업데이트하거나 제거할 수 있도록 하세요.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) 인터페이스는 [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--)를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--)은 클릭 동작이 있는 컨테이너를 반환합니다.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--)은 마우스 오버 동작이 있는 컨테이너를 반환합니다.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--)은 어느 한쪽 또는 양쪽 동작이 있는 컨테이너를 반환합니다.

다음 예제는 외부 클릭 링크, 파일 마우스오버 링크, 내부 슬라이드 네비게이션, 텍스트 마우스오버 링크, 매크로 동작을 포함하는 `hyperlink-audit-input.pptx`를 생성합니다. 이 예제는 어떠한 동작도 실행하지 않습니다. 동일한 세 가지 쿼리는 모든 범위에서 작동하며, 반환값은 컨테이너 수를 나타내며 동작 총수를 나타내지는 않습니다. 텍스트 프레임 범위는 포함된 도형 자체의 링크를 제외합니다.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 예제에서는 프레젠테이션 및 슬라이드 쿼리가 각각 클릭 컨테이너 3개, 마우스오버 컨테이너 2개, 양쪽 동작을 가진 컨테이너 3개를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리당 하나의 컨테이너를 보고합니다.

### **동작 및 대상 분류**

동작을 해석하기 전에 [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--)을 사용해 동작 유형을 확인하십시오. [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) 값은 웹 네비게이션을 넘어 다양한 동작을 포함합니다:

| 값 | 감사 시 의미 |
| --- | --- |
| `Hyperlink` | 외부 하이퍼링크; URL과 스킴을 검사합니다. |
| `JumpSpecificSlide` | 특정 슬라이드로 내부 이동. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 슬라이드쇼 내 내장 네비게이션, 슬라이드쇼 컨텍스트에서 해석됩니다. |
| `JumpEndShow`, `StartCustomSlideShow` | 현재 쇼 종료 또는 사용자 정의 쇼 시작. |
| `StartMacro` | 매크로 실행. |
| `StartProgram` | 프로그램 실행. |
| `OpenFile`, `OpenPresentation` | 파일 또는 다른 프레젠테이션 열기; 웹 URL과는 별도로 검토합니다. |
| `StartStopMedia` | 미디어 재생 시작 또는 정지. |
| `NoAction`, `Unknown` | 네비게이션 동작 없음 또는 인식되지 않은 동작으로 검토 필요. |

외부 대상은 [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--)로, 특정 내부 대상은 [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--)으로 읽어옵니다. 내부 동작 및 내장 명령은 외부 URL이 없을 수 있으며, 빈 URL이 컨테이너에 동작이 없음을 의미하지는 않습니다. 정규화된 URL과 다를 경우 [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) 값을 보존하고, 가능한 경우 [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--)에서 반환된 툴팁도 포함하십시오.

### **하이퍼링크 보고, 정리 및 검증**

다음 Java 예제는 기존 프레젠테이션을 읽고(위에서 만든 파일 사용), `hyperlink-audit.json`을 작성한 뒤 정책을 적용하고 `hyperlink-sanitized.pptx`로 저장한 후 다시 열어 두 활성화 유형을 다시 확인합니다. 컨테이너를 변경하기 전에 수집하고 동일한 컨테이너를 중복 처리하지 않도록 참조 동등성을 사용합니다. 프레젠테이션 쿼리는 일반 슬라이드를 다루며, 전체 패키지 인벤토리를 위해 마스터, 레이아웃, 노트 및 노트·핸드아웃 마스터도 명시적으로 쿼리합니다.

보고서는 1 기반 슬라이드 인덱스와 사용 가능한 경우 [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--)을 기록합니다. 지원되는 컨테이너에 대해서는 [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--)가 소유 슬라이드를 제공합니다. 마스터, 레이아웃, 노트는 일반 슬라이드 인덱스가 없으며 범위별로 식별됩니다. 도형 컨테이너와 텍스트 부분 포맷 컨테이너는 별도로 라벨링되고, 다른 컨테이너 유형은 런타임 타입 이름을 유지합니다. 각 컨테이너에는 보고서 내 로컬 ID가 부여되어 두 동작을 연계할 수 있습니다. 보고서는 동작 유형을 Java 열거형에 정의된 정수 상수로 저장합니다.

이 제한적인 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드쇼 동작, 알 수 없는 동작 및 기타 URL 스킴은 거부합니다. 이러한 거부는 정책 결정이며 Aspose.Slides의 안전 판정이 아닙니다. HTTPS만으로 신뢰가 확립되는 것은 아니므로 호스트 허용 목록 및 기타 검사를 추가하십시오. 원본 및 정규화된 외부 URL 모두 검증됩니다. 예제는 메타데이터만 감사하고 링크를 따라가거나 동작을 실행하지 않습니다.

복구를 위해 컨테이너의 [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--)는 [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--)를 지원합니다. 여기서는 금지된 외부 클릭 링크를 고정된 HTTPS 랜딩 페이지로 교체하고, 다른 금지된 클릭 및 마우스오버 동작은 독립적으로 제거합니다. `replaceExternalClicks`를 `false`로 설정하면 모든 정책 위반을 제거합니다. 배포 전 애플리케이션이 소유한 교체 페이지를 선택하십시오.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스오버 동작 및 외부 링크가 아닌 동작 또는 특정 슬라이드 점프는 잠재적으로 지원되지 않을 수 있다고 표시합니다. 이는 검토 힌트이며, 플래그가 없는 링크가 내보내기에서 살아남는다는 보장은 아닙니다. 지원되는 [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/androidjava/convert-powerpoint-to-html/) 내보내기는 동작, 옵션 및 뷰어에 따라 하이퍼링크를 유지할 수 있습니다. 래스터 [이미지](/slides/ko/androidjava/convert-powerpoint-to-png/)와 [비디오](/slides/ko/androidjava/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 유지할 수 없으며, 이러한 출력에 대한 감사 시 모든 동작을 플래그해야 합니다.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // 추가 JSON 의존성 없이 이 보고서의 평탄한 행들을 직렬화합니다.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

위에서 만든 입력을 사용하면 보고서에 다섯 개의 동작 행이 포함됩니다. 파일 마우스오버 링크와 매크로 클릭은 제거되고, HTTPS 링크와 내부 슬라이드 네비게이션은 유지됩니다. 검증 결과는 금지된 동작이 없음을 출력합니다. 금지된 외부 클릭 URL이 포함된 입력은 교체 분기를 실행합니다. 허용된 클릭과 금지된 마우스오버가 결합된 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 정책에 따라 동작을 제거하는 [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--)와 다릅니다. 여기서 검증은 하이퍼링크 동작만 확인하며, 내장 VBA 프로젝트, OLE 객체 또는 기타 활성 콘텐츠를 제거하지 않으며, 내보낸 PDF 또는 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션 또는 해당 첫 슬라이드에 어떻게 연결하나요?**

PowerPoint의 섹션은 슬라이드를 그룹화하지만 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 슬라이드에 연결하십시오.

**마스터 슬라이드 요소에 하이퍼링크를 연결하면 모든 슬라이드에서 작동하나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소에 대한 링크는 해당 마스터 또는 레이아웃을 사용하는 슬라이드 쇼 동안 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지되나요?**

지원되는 PDF 및 HTML 내보내기는 하이퍼링크를 유지할 수 있지만, 래스터 이미지와 비디오는 유지할 수 없습니다. 자세한 내용은 [하이퍼링크 보고, 정리 및 검증](#report-sanitize-and-verify-hyperlinks)에서 내보내기 고려 사항을 확인하십시오.