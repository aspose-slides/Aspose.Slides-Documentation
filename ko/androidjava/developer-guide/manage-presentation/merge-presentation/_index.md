---
title: Android에서 프레젠테이션 효율적으로 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/androidjava/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- Android
- Java
- Aspose.Slides
description: "Android용 Java에서 Aspose.Slides를 사용하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 손쉽게 병합하고 워크플로를 간소화합니다."
---
## **개요**

PowerPoint와 OpenDocument 프레젠테이션을 병합하는 것은 많은 Android 애플리케이션에서 일반적인 작업이며, 특히 보고서를 생성하거나, 다양한 소스의 슬라이드를 모으거나, 프레젠테이션 워크플로를 자동화할 때 필요합니다. Aspose.Slides는 Microsoft PowerPoint, LibreOffice 또는 OpenOffice를 설치하지 않고도 여러 PPT, PPTX 또는 ODP 파일을 하나의 프레젠테이션으로 결합할 수 있는 강력하고 사용하기 쉬운 API를 제공합니다.

이 가이드에서는 몇 줄의 코드만으로 PowerPoint와 OpenDocument 프레젠테이션을 병합하는 방법을 배웁니다. 바로 사용할 수 있는 예제를 제공하고, 병합 과정에서 슬라이드 형식, 레이아웃 및 기타 프레젠테이션 요소를 유지하는 방법을 보여줍니다.

엔터프라이즈 급 애플리케이션을 구축하든 간단한 자동화 도구를 만들든, Aspose.Slides는 프레젠테이션 병합을 빠르고 신뢰할 수 있으며 확장 가능하게 합니다. Aspose.Slides는 다양한 방식으로 프레젠테이션을 병합할 수 있게 해 줍니다. 모든 도형, 스타일, 텍스트, 서식, 주석, 애니메이션 등을 품질이나 데이터 손실에 대한 걱정 없이 결합할 수 있습니다.

{{% alert color="info" %}}
참고: [Clone Slides](https://docs.aspose.com/slides/ko/androidjava/clone-slides/)
{{% /alert %}}

### **병합할 수 있는 내용**

Aspose.Slides를 사용하면 다음을 병합할 수 있습니다

* 전체 프레젠테이션. 모든 프레젠테이션의 슬라이드가 하나의 프레젠테이션에 포함됩니다
* 특정 슬라이드. 선택된 슬라이드가 하나의 프레젠테이션에 포함됩니다
* 동일한 형식(PPT → PPT, PPTX → PPTX 등) 또는 서로 다른 형식(PPT → PPTX, PPTX → ODP 등)의 프레젠테이션을 서로 병합합니다. 

### **병합 옵션**

다음 옵션을 적용하여 결정할 수 있습니다

* 출력 프레젠테이션의 각 슬라이드가 고유한 스타일을 유지하도록 할지
* 출력 프레젠테이션의 모든 슬라이드에 동일한 스타일을 적용할지

프레젠테이션을 병합하려면 Aspose.Slides가 [AddClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드(아래의 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection) 인터페이스에 포함)를 제공합니다. `AddClone` 메서드에는 프레젠테이션 병합 프로세스 매개변수를 정의하는 여러 구현이 있습니다. 모든 Presentation 객체는 [Slides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 컬렉션을 갖고 있으므로, 슬라이드를 병합하려는 프레젠테이션에서 `AddClone` 메서드를 호출할 수 있습니다.

`AddClone` 메서드는 소스 슬라이드의 복제본인 `ISlide` 객체를 반환합니다. 출력 프레젠테이션의 슬라이드는 단순히 소스 슬라이드의 복사본이므로, 소스 프레젠테이션에 영향을 주지 않으면서 결과 슬라이드에 스타일이나 서식 옵션, 레이아웃 등을 적용하여 변경할 수 있습니다.

## **프레젠테이션 병합** 

Aspose.Slides는 슬라이드가 레이아웃과 스타일을 유지하면서 결합할 수 있도록 하는 기본 매개변수의 [**AddClone(ISlide)**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 제공합니다.

다음 Java 코드는 프레젠테이션을 병합하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **슬라이드 마스터를 사용한 프레젠테이션 병합**

Aspose.Slides는 슬라이드 마스터 프레젠테이션 템플릿을 적용하면서 슬라이드를 결합할 수 있는 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 메서드를 제공합니다. 이를 통해 필요에 따라 출력 프레젠테이션의 슬라이드 스타일을 변경할 수 있습니다.

다음 Java 코드는 설명된 작업을 시연합니다:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

슬라이드 마스터의 레이아웃은 자동으로 결정됩니다. 적절한 레이아웃을 결정할 수 없을 경우 `allowCloneMissingLayout` 부울 매개변수가 true로 설정되어 있으면 소스 슬라이드의 레이아웃이 사용됩니다. 그렇지 않으면 [PptxEditException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PptxEditException) 예외가 발생합니다.

{{% /alert %}}

출력 프레젠테이션의 슬라이드가 다른 레이아웃을 가져야 한다면 병합 시 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 메서드를 대신 사용하십시오.

## **프레젠테이션에서 특정 슬라이드 병합**

여러 프레젠테이션에서 특정 슬라이드를 병합하면 맞춤형 슬라이드 데크를 만들 때 유용합니다. Aspose.Slides for Android via Java를 사용하면 필요한 슬라이드만 선택하여 가져올 수 있습니다. API는 원본 슬라이드의 서식, 레이아웃 및 디자인을 보존합니다.

다음 Java 코드는 새 프레젠테이션을 만든 뒤 두 다른 프레젠테이션의 제목 슬라이드를 추가하고 결과를 파일에 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);

    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **슬라이드 레이아웃을 사용한 프레젠테이션 병합**

다음 Java 코드는 프레젠테이션의 슬라이드를 결합하면서 원하는 슬라이드 레이아웃을 적용해 하나의 출력 프레젠테이션을 만드는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

{{% alert title="Note" color="warning" %}} 

다른 슬라이드 크기를 가진 프레젠테이션은 병합할 수 없습니다. 

{{% /alert %}}

크기가 다른 두 프레젠테이션을 병합하려면 한 프레젠테이션의 크기를 다른 프레젠테이션에 맞게 조정해야 합니다.

다음 샘플 코드는 설명된 작업을 시연합니다:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **프레젠테이션 섹션에 슬라이드 병합**

다음 Java 코드는 특정 슬라이드를 프레젠테이션의 섹션에 병합하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

슬라이드는 섹션의 끝에 추가됩니다.

{{% alert title="Tip" color="info" %}}

Aspose는 [무료 콜라주 웹 앱](https://products.aspose.app/slides/ko/collage) 을 제공합니다. 이 온라인 서비스를 사용하면 [JPG를 JPG로](https://products.aspose.app/slides/ko/collage/jpg) 또는 [PNG를 PNG로](https://products.aspose.app/slides/ko/collage/png) 이미지를 병합하고, [사진 그리드](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다. 

{{% /alert %}}

## **FAQ**

### 프레젠테이션을 병합할 때 슬라이드 수에 제한이 있나요?

엄격한 제한은 없습니다. Aspose.Slides는 대용량 파일을 처리할 수 있지만 성능은 파일 크기와 시스템 리소스에 따라 달라집니다. 매우 큰 프레젠테이션의 경우 64비트 JVM을 사용하고 충분한 힙 메모리를 할당하는 것이 권장됩니다.

### 임베드된 비디오 또는 오디오가 포함된 프레젠테이션을 병합할 수 있나요?

예, Aspose.Slides는 슬라이드에 삽입된 멀티미디어 콘텐츠를 보존하지만 최종 프레젠테이션 크기가 크게 증가할 수 있습니다.

### 프레젠테이션을 병합할 때 글꼴이 유지되나요?

예. 소스 프레젠테이션에 사용된 글꼴은 시스템에 설치되어 있거나 [임베드된](/slides/ko/androidjava/embedded-font/) 경우 출력 파일에 그대로 유지됩니다.