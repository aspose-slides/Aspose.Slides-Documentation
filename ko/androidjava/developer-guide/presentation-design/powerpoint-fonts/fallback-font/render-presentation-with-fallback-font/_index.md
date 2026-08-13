---
title: Android에서 대체 폰트를 사용한 프레젠테이션 렌더링
linktitle: 프레젠테이션 렌더링
type: docs
weight: 30
url: /ko/androidjava/render-presentation-with-fallback-font/
keywords:
- 대체 폰트
- PowerPoint 렌더링
- 프레젠테이션 렌더링
- 슬라이드 렌더링
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 대체 폰트를 사용해 프레젠테이션을 렌더링합니다 – PPT, PPTX 및 ODP에서 텍스트가 일관되게 유지되도록 단계별 Java 코드 샘플을 제공합니다."
---
## **개요**

Aspose.Slides는 대체 폰트 규칙을 사용하여 프레젠테이션을 렌더링할 수 있게 합니다. 이 문서에서는 대체 폰트 규칙 컬렉션을 생성하고, 대체 폰트를 제거하거나 추가하여 규칙을 수정하는 방법과 `FontsManager.setFontFallBackRulesCollection` 메서드를 사용하여 컬렉션을 할당하는 방법을 보여줍니다.

대체 폰트 규칙 컬렉션이 프레젠테이션의 `FontsManager`에 할당되면 저장, 렌더링 및 프레젠테이션 변환과 같은 작업 중에 규칙이 적용됩니다. 예제에서는 슬라이드 썸네일을 렌더링하고 JPEG 이미지로 저장할 때 구성된 규칙을 사용하는 방법을 보여줍니다.

## **대체 폰트 규칙을 사용하여 슬라이드 렌더링**

다음 예제는 다음 단계를 포함합니다:

1. 우리는 [대체 폰트 규칙 컬렉션 생성](/slides/ko/androidjava/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 대체 폰트 규칙을 제거하고 [addFallBackFonts](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)을 다른 규칙에 추가합니다.
1. 규칙 컬렉션을 [getFontsManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) 메서드에 설정합니다.
1. [Presentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 메서드를 사용하면 프레젠테이션을 동일한 형식으로 저장하거나 다른 형식으로 저장할 수 있습니다. 대체 폰트 규칙 컬렉션이 [FontsManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FontsManager)에 설정된 후에는 프레젠테이션에 대한 모든 작업(저장, 렌더링, 변환 등) 중에 이러한 규칙이 적용됩니다.

```java
import com.aspose.slides.*;

// 규칙 컬렉션의 새 인스턴스를 생성합니다
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // 로드된 규칙에서 대체 폰트 "Tahoma"를 제거합니다
    fallBackRule.remove("Tahoma");

    // 지정된 범위에 대한 규칙을 업데이트합니다
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// 또한 최소 하나의 규칙은 남겨두고 리스트에서 기존 규칙을 모두 제거할 수 있습니다
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    // 사용할 준비된 규칙 목록을 할당합니다
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // 초기화된 규칙 컬렉션을 사용하여 썸네일을 렌더링하고 JPEG로 저장합니다
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // 이미지를 JPEG 형식으로 디스크에 저장합니다
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Android에서 PPT 및 PPTX를 JPG로 변환에 대해 자세히 알아보세요. [Convert PPT and PPTX to JPG on Android](/slides/ko/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}