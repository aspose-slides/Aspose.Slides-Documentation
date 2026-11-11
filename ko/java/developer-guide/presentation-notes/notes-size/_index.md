---
title: Java에서 노트 페이지 크기 및 방향 변경
linktitle: 노트 페이지 크기
type: docs
weight: 10
url: /ko/java/notes-size/
keywords:
- 노트 페이지 크기
- 노트 방향
- 가로 노트
- 세로 노트
- 핸드아웃 크기
- PowerPoint
- 프레젠테이션
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 노트 페이지 크기를 읽고 변경하며, 방향을 전환하고, 저장된 크기를 확인하고, 노트 또는 핸드아웃을 PDF와 이미지로 내보냅니다."
---
## **개요**

프레젠테이션의 노트 페이지 설정에 액세스하려면 [Presentation.getNotesSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getNotesSize--)를 사용합니다. 이 메서드는 페이지 차원을 설정하는 [setSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) 메서드를 가진 [INotesSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/inotessize/) 객체를 반환합니다. 설정 객체 자체는 교체할 수 없지만 이 메서드를 통해 새 차원을 할당할 수 있습니다.

너비와 높이는 **포인트** 단위로 지정되며, 인치당 72 포인트입니다. 예를 들어 900 × 600 포인트는 12.5 × 8⅓ 인치에 해당합니다. 이 설정은 개별 슬라이드의 노트가 아니라 프레젠테이션 전체에 적용됩니다.

| 설정 | 목적 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getNotesSize--) | 노트 페이지 차원 및 핸드아웃 내보내기에 사용되는 페이지 차원을 제어합니다. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSlideSize--) | ISlideSize를 통해 일반 프레젠테이션 슬라이드 차원을 제어합니다. |

두 설정을 변경해도 서로 자동으로 변경되지 않습니다. 노트 페이지 방향을 바꿔도 일반 슬라이드는 회전되지 않습니다. 일반 슬라이드 크기 조정은 [Slide Size](/slides/ko/java/slide-size/)를 참고하십시오.

아래 예제는 기존 `sample.pptx` 파일을 사용합니다. 내보내기 예제의 경우 최소 하나 이상의 슬라이드에 스피커 노트가 포함된 프레젠테이션을 사용하십시오. 각 예제는 독립적으로 실행할 수 있습니다.

## **노트 페이지 크기 및 방향 읽기**

너비와 높이를 읽어 비교하여 방향을 판단합니다. 너비가 더 넓은 페이지는 가로, 높이가 더 높은 페이지는 세로, 크기가 동일하면 정사각형 페이지입니다. 이 예제는 표준 용지 크기를 가정하지 않고 포인트 단위의 실제 차원을 출력합니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **용지 크기를 변경하지 않고 가로 방향으로 전환**

방향만 변경하려면 기존 너비와 높이를 서로 교환합니다. 이렇게 하면 사용자 정의 용지 크기의 양쪽 길이가 그대로 유지됩니다. 아래 조건은 이미 가로 방향인 페이지가 세로로 전환되는 것을 방지하고, 정사각형 페이지는 그대로 유지합니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

세로 방향의 경우 `size.getWidth() > size.getHeight()` 일 때 동일한 할당을 사용합니다. 용지 크기도 변경하려는 경우가 아니라면 A4 또는 Letter 차원을 대체하지 마십시오.

## **사용자 지정 노트 페이지 크기 설정 및 확인**

두 차원을 동시에 할당한 뒤 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-)을 사용해 프레젠테이션을 저장합니다. 이 예제는 900 × 600 포인트 가로 페이지를 설정하고 PPTX 형식으로 저장한 뒤, 저장된 파일을 다시 열어 지속된 값을 확인합니다. 비교 시 부동 소수점 값에 대해 0.01 포인트 허용오차를 두지만, 모든 파일 형식에 대해 정확성을 보장하는 것은 아닙니다.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

예상 결과는 `900.0 x 600.0 points`와 `Size preserved: true`입니다. 새로 연 프레젠테이션을 확인하면 메모리 상 설정만이 아니라 저장된 파일 자체를 검증할 수 있습니다.

## **노트 및 핸드아웃 내보내기**

페이지 차원은 노트 또는 핸드아웃 레이아웃에 사용할 수 있는 영역을 정의합니다. 이들 레이아웃을 활성화하려면 내보내기 옵션도 별도로 구성해야 합니다. 일반 슬라이드 내보내기는 슬라이드 차원을 계속 사용합니다.

### **노트를 PDF 및 PNG로 내보내기**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notescommentslayoutingoptions/)을 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)에 할당하면 PDF에 노트를 포함할 수 있습니다. 이 예제는 또한 [Slide.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)와 [RenderingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/renderingoptions/)을 사용해 노트가 있는 첫 번째 슬라이드를 PNG로 렌더링합니다.

[BottomTruncated](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notespositions/) 모드는 노트를 한 페이지에 유지하고, 페이지에 맞지 않는 노트는 잘라냅니다. PDF는 900 × 600 포인트 페이지를 사용합니다. 아래에서 사용된 1 × 1 이미지 스케일에서는 PNG가 900 × 600 픽셀이 됩니다. 포인트는 페이지 기하학을, 픽셀은 렌더링 스케일에 따라 달라지는 래스터 출력 크기를 나타냅니다.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

긴 노트가 있는 PDF 내보내기의 경우, [BottomFull](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notespositions/)을 사용하면 필요에 따라 추가 페이지가 생성됩니다. 위의 단일 슬라이드 이미지 호출은 해당 모드를 지원하지 않으므로 사용하지 마십시오. 크기를 조정한 후에는 잘린 노트와 기존 notes‑master 객체의 배치를 확인하십시오. 페이지 차원만 변경한다고 해서 모든 콘텐츠가 맞게 들어간다고 보장할 수 없습니다. 노트 내보내기에 대한 자세한 내용은 [Convert PowerPoint to PDF with Notes](/slides/ko/java/convert-powerpoint-to-pdf-with-notes/)를 참조하십시오.

### **핸드아웃을 PDF로 내보내기**

여러 슬라이드 섬네일을 한 페이지에 배치하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/handoutlayoutingoptions/)를 사용합니다. 다음 예제는 900 × 600 포인트 페이지를 설정하고 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ko/java/com.aspose.slides/handouttype/)를 사용해 페이지당 최대 네 개의 슬라이드를 가로 방향으로 배열합니다. 가로 프리셋은 슬라이드 순서를 제어하고, 페이지 방향은 너비와 높이에서 결정됩니다.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

페이지 크기를 변경하면 핸드아웃 그리드에 사용할 수 있는 영역이 바뀌지만, 원본 슬라이드의 차원은 변하지 않습니다. 핸드아웃 이미지를 만들 때는 개별 슬라이드 이미지 메서드가 아닌 핸드아웃 레이아웃을 사용해 [Presentation.getImages](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)를 호출하십시오. Aspose.Slides에서는 프레젠테이션 수준의 핸드아웃 렌더링이 노트 페이지 차원을 사용하지만, 개별 슬라이드 이미지 호출은 핸드아웃 페이지를 생성하지 않습니다. 레이아웃 옵션에 대한 자세한 내용은 [Handout Mode](/slides/ko/java/convert-powerpoint-in-handout-mode/)를 확인하십시오.

## **뷰어, 내보내기 및 인쇄 시 페이지 크기**

저장된 프레젠테이션 크기, 내보낸 페이지 크기, 인쇄된 용지 크기를 명확히 구분하십시오:

- **Presentation viewers:** 뷰어는 자체 레이아웃 규칙을 사용해 노트를 표시하거나 인쇄할 수 있습니다. 다른 애플리케이션이 파일을 저장한 경우 파일을 다시 열어 차원을 확인하십시오. 해당 애플리케이션의 형식 변환이 차원을 정규화할 수 있습니다.
- **Export formats:** 위의 노트 및 핸드아웃 PDF 예제는 구성된 페이지 차원을 사용합니다. 래스터 이미지는 정수 픽셀 치수와 렌더링 스케일을 사용하므로, 소수점 포인트 값이 이미지 출력에서 반올림될 수 있습니다. 일반 슬라이드 내보내기에는 노트 페이지 크기가 적용되지 않습니다.
- **Printer drivers:** 용지 선택, 자동 회전 및 페이지 맞춤 설정은 프레젠테이션이나 PDF에 저장된 차원을 변경하지 않고 물리적 출력에 영향을 줄 수 있습니다. 특정 용지 크기를 사용하려면 프린터 설정을 일치시키고 인쇄 미리보기를 확인하십시오.

## **FAQ**

**한 슬라이드에만 노트 크기를 설정할 수 있나요?**

노트 페이지 크기는 프레젠테이션 수준의 설정입니다. 개별 슬라이드는 서로 다른 노트 내용을 가질 수 있지만, 이 속성으로 슬라이드마다 별도의 페이지 크기를 지정할 수는 없습니다.

**노트 방향을 변경했는데 슬라이드가 변하지 않은 이유는 무엇인가요?**

노트 페이지와 일반 슬라이드는 독립적인 차원을 가지고 있습니다. 슬라이드 자체의 크기를 변경하려면 일반 슬라이드 크기 설정을 사용하십시오.

**저장하거나 인쇄한 결과가 다른 크기를 갖는 이유는 무엇인가요?**

먼저 저장된 프레젠테이션을 다시 열어 노트 차원을 확인하십시오. 차이가 있다면 다른 애플리케이션에서 파일을 저장하거나 변환하면서 페이지 설정이 변경되었는지 확인해야 합니다. 변경되지 않았다면 내보내기 레이아웃, 이미지 스케일, 뷰어 설정 및 프린터 용지 선택을 점검하십시오.