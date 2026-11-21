---
title: Android에서 노트 페이지 크기 및 방향 변경
linktitle: 노트 페이지 크기
type: docs
weight: 10
url: /ko/androidjava/notes-size/
keywords:
- 노트 페이지 크기
- 노트 방향
- 가로 노트
- 세로 노트
- 유인물 크기
- 파워포인트
- 프레젠테이션
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 노트 페이지 크기를 읽고 변경하며, 방향을 전환하고, 저장된 크기를 확인하고, 노트 또는 유인물을 PDF 및 이미지로 내보냅니다."
---
## **개요**

[Presentation.getNotesSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getNotesSize--)을 사용하여 프레젠테이션의 노트 페이지 설정에 액세스합니다. 이 메서드는 페이지 차원을 설정하는 [setSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) 메서드를 가진 [INotesSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/inotessize/) 개체를 반환합니다. 설정 개체 자체는 교체할 수 없지만, 이 메서드를 통해 새로운 차원을 지정할 수 있습니다.

너비와 높이는 **포인트** 단위이며, 인치당 72포인트입니다. 예를 들어, 900 × 600 포인트는 12.5 × 8⅓ 인치에 해당합니다. 이러한 설정은 프레젠테이션 전체에 적용되며 개별 슬라이드의 노트에는 적용되지 않습니다.

| 설정 | 용도 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getNotesSize--) | 노트 페이지 차원 및 유인물 내보내기에 사용되는 페이지 차원을 제어합니다. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSlideSize--) | [ISlideSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidesize/)를 통해 일반 프레젠테이션 슬라이드 차원을 제어합니다. |

두 설정 중 하나를 변경해도 다른 설정은 자동으로 변경되지 않습니다. 노트 페이지 방향을 바꾸어도 일반 슬라이드가 회전하지 않습니다. 일반 슬라이드 크기 조정은 [Slide Size](/slides/ko/androidjava/slide-size/)를 참고하십시오.

아래 예제는 기존 `sample.pptx` 파일을 사용합니다. 내보내기 예제의 경우 최소 하나 이상의 슬라이드에 발표자 노트가 포함된 프레젠테이션을 사용하십시오. 각 예제는 독립적으로 실행할 수 있습니다.

## **노트 페이지 크기 및 방향 읽기**

너비와 높이를 읽어 비교하여 방향을 판단합니다. 넓은 페이지는 가로 방향, 높은 페이지는 세로 방향이며, 차원이 같으면 정사각형 페이지입니다. 이 예제는 표준 용지 크기를 가정하지 않고 실제 포인트 단위 차원을 출력합니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **용지 크기 변경 없이 가로 방향으로 전환**

방향만 바꾸려면 기존 너비와 높이를 서로 교환합니다. 이렇게 하면 사용자 정의 용지 크기의 양쪽 길이가 보존됩니다. 아래 조건은 이미 가로 방향인 페이지가 세로 방향으로 전환되는 것을 방지하고, 정사각형 페이지는 변화시키지 않습니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

세로 방향의 경우 `size.getWidth() > size.getHeight()`일 때 동일한 할당을 사용합니다. 용지 크기도 함께 변경하고 싶지 않은 경우 A4 또는 Letter 차원을 대체하지 마십시오.

## **사용자 정의 노트 페이지 크기 설정 및 확인**

두 차원을 동시에 할당한 다음 [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)을 사용하여 프레젠테이션을 저장합니다. 이 예제는 900 × 600 포인트 가로 페이지를 설정하고 PPTX 형식으로 저장한 뒤, 저장된 파일을 다시 열어 지속된 값을 확인합니다. 비교 시 부동소수점 값에 대해 0.01 포인트 허용오차를 두지만, 모든 파일 형식에 대한 정확성을 보장하지는 않습니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

예상 결과는 `900.0 x 600.0 points`와 `Size preserved: true`입니다. 새로 연 프레젠테이션을 확인하면 메모리 상 설정이 아니라 실제 저장 파일을 검증하게 됩니다.

## **노트 및 유인물 내보내기**

페이지 차원은 노트 또는 유인물 레이아웃에 사용할 수 있는 영역을 정의합니다. 하지만 차원만으로 레이아웃이 활성화되는 것은 아니므로 내보내기 옵션도 별도로 구성해야 합니다. 일반 슬라이드 내보내기는 슬라이드 차원을 계속 사용합니다.

### **노트를 PDF 및 PNG로 내보내기**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/notescommentslayoutingoptions/)을 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)에 지정하면 PDF에 노트를 포함할 수 있습니다. 이 예제는 또한 [Slide.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)와 [RenderingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/renderingoptions/)를 사용해 첫 번째 슬라이드의 노트를 PNG로 렌더링합니다.

[BottomTruncated](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/notespositions/) 모드는 노트를 한 페이지에 유지하고, 맞지 않는 부분은 잘라냅니다. PDF는 900 × 600 포인트 페이지를 사용합니다. 아래 예제에서 사용한 1 × 1 이미지 스케일에서는 PNG가 900 × 600 픽셀이 됩니다. 포인트는 페이지 기하학을 설명하고, 픽셀은 렌더링 스케일에 따라 결정되는 래스터 출력을 설명합니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

긴 노트를 포함한 PDF 내보내기의 경우 [BottomFull](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/notespositions/)을 사용하면 필요에 따라 추가 페이지가 생성됩니다. 단일 슬라이드 이미지 호출에서는 해당 모드를 사용할 수 없으니 주의하십시오. 크기를 조정한 뒤에는 잘린 노트와 기존 노트‑마스터 객체 배치를 확인하십시오. 페이지 차원만 변경한다고 모든 콘텐츠가 맞춰진다고 보장할 수 없습니다. 노트 내보내기 자세한 내용은 [Convert PowerPoint to PDF with Notes](/slides/ko/androidjava/convert-powerpoint-to-pdf-with-notes/)를 참고하십시오.

### **유인물을 PDF로 내보내기**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handoutlayoutingoptions/)을 사용하면 한 페이지에 여러 슬라이드 썸네일을 배치할 수 있습니다. 다음 예제는 900 × 600 포인트 페이지를 설정하고 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/handouttype/)을 이용해 페이지당 최대 4개의 슬라이드를 가로 방향으로 배치합니다. 가로 프리셋은 슬라이드 순서를 제어하고, 페이지 방향은 너비와 높이에서 파생됩니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

페이지 크기를 변경하면 유인물 그리드에 사용할 수 있는 영역이 바뀌지만 원본 슬라이드 차원은 변하지 않습니다. 유인물 이미지를 만들 때는 개별 슬라이드 이미지 메서드 대신 [Presentation.getImages](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)와 유인물 레이아웃을 사용하십시오. Aspose.Slides에서는 프레젠테이션 수준 유인물 렌더링이 노트 페이지 차원을 사용하고, 개별 슬라이드 이미지 호출은 유인물 페이지를 생성하지 않습니다. 레이아웃 옵션은 [Handout Mode](/slides/ko/androidjava/convert-powerpoint-in-handout-mode/)를 참고하십시오.

## **뷰어, 내보내기 및 인쇄 시 페이지 크기**

저장된 프레젠테이션 크기, 내보낸 페이지 크기, 인쇄된 용지 크기를 명확히 구분하십시오.

- **프레젠테이션 뷰어:** 뷰어는 자체 레이아웃 규칙에 따라 노트를 표시하거나 인쇄할 수 있습니다. 다른 애플리케이션이 파일을 저장하면 다시 열어 차원을 확인하십시오. 해당 애플리케이션의 형식 변환이 차원을 정규화할 수 있습니다.
- **내보내기 형식:** 위의 노트 및 유인물 PDF 예제는 구성된 페이지 차원을 사용합니다. 래스터 이미지의 경우 정수 픽셀 차원과 렌더링 스케일을 사용하므로 소수점 포인트 값이 이미지 출력에서 반올림될 수 있습니다. 일반 슬라이드 내보내기에는 노트 페이지 크기가 적용되지 않습니다.
- **프린터 드라이버:** 용지 선택, 자동 회전 및 페이지 맞춤 설정은 물리적 출력에 영향을 미칠 수 있지만 프레젠테이션이나 PDF에 저장된 차원은 변경되지 않습니다. 특정 용지 크기를 사용할 경우 프린터 설정을 일치시키고 인쇄 미리보기를 확인하십시오.

## **FAQ**

**노트 크기를 한 슬라이드에만 설정할 수 있나요?**

노트 페이지 크기는 프레젠테이션 수준 설정입니다. 개별 슬라이드마다 다른 노트 내용을 가질 수는 있지만, 이 속성으로 슬라이드별 별도 페이지 크기를 지정할 수는 없습니다.

**노트 방향을 바꿨는데 슬라이드가 변하지 않은 이유는?**

노트 페이지와 일반 슬라이드는 서로 독립된 차원을 갖습니다. 슬라이드 자체를 크기 조정하려면 일반 슬라이드 크기 설정을 사용하십시오.

**저장하거나 인쇄한 결과의 크기가 다르게 나오는 이유는?**

먼저 저장된 프레젠테이션을 다시 열어 노트 차원을 비교하십시오. 차원이 변경되었다면 다른 애플리케이션에서 파일을 저장하거나 변환하면서 페이지 설정이 바뀌었을 수 있습니다. 변경되지 않았다면 내보내기 레이아웃, 이미지 스케일, 뷰어 설정 및 프린터 용지 선택을 확인하십시오.