---
title: Java를 사용한 프레젠테이션의 태그 및 사용자 정의 데이터 관리
linktitle: 태그 및 사용자 정의 데이터
type: docs
weight: 300
url: /ko/java/managing-tags-and-custom-data/
keywords:
- 문서 속성
- 태그
- 사용자 정의 데이터
- 태그 추가
- 쌍 값
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 PowerPoint 및 OpenDocument 프레젠테이션에 대한 예제와 함께 태그 및 사용자 정의 데이터를 추가, 읽기, 업데이트 및 제거하는 방법을 배웁니다."
---
## **개요**

이 문서에서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 정의 데이터를 어떻게 처리하는지 설명합니다. PPTX 파일에 데이터가 저장되는 방식을 간략히 설명하고, 프레젠테이션별 데이터가 태그 및 사용자 정의 XML 파트로 존재할 수 있음을 언급하며, 태그를 키‑값 문자열 쌍으로 설명합니다.

또한 태그 값을 읽는 방법과 프레젠테이션, 개별 슬라이드 또는 도형에 태그를 추가하는 방법을 보여줍니다. 추가로 모든 태그를 삭제하거나, 이름으로 태그를 제거하고, 태그 이름 목록을 가져오는 등 일반적인 태그 관리 작업을 다룹니다.

## **프레젠테이션 파일의 데이터 저장**

PPTX 파일—*.pptx* 확장자를 가진 항목—은 Office Open XML 사양의 일부인 PresentationML 형식으로 저장됩니다. Office Open XML 형식은 프레젠테이션에 포함된 데이터의 구조를 정의합니다.

*슬라이드*는 프레젠테이션 요소 중 하나이며, *슬라이드 파트*는 단일 슬라이드의 내용을 포함합니다. 슬라이드 파트는 ISO/IEC 29500에 정의된 사용자 정의 태그와 같은 다수의 파트와 명시적인 관계를 가질 수 있습니다.

프레젠테이션에 특정한 사용자 정의 데이터 또는 사용자는 태그([ITagCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITagCollection))와 CustomXmlParts([ICustomXmlPartCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ICustomXmlPartCollection))로 존재할 수 있습니다.

{{% alert color="primary" %}}
태그는 본질적으로 문자열‑키 쌍 값입니다.
{{% /alert %}}

## **태그 값 가져오기**

슬라이드에서 태그는 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IDocumentProperties#getKeywords--) 및 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 메서드에 해당합니다. 다음 샘플 코드는 Aspose.Slides for Java를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation)의 태그 값을 가져오는 방법을 보여줍니다.

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 가지 항목으로 구성됩니다.

- 사용자 정의 속성 이름 - `MyTag`
- 사용자 정의 속성 값 - `My Tag Value`

특정 규칙이나 속성을 기반으로 일부 프레젠테이션을 분류해야 하는 경우, 해당 프레젠테이션에 태그를 추가하면 도움이 됩니다. 예를 들어 북미 국가의 모든 프레젠테이션을 함께 묶고 싶다면 “North American”이라는 태그를 만들고 해당 국가(미국, 멕시코, 캐나다)를 값으로 지정할 수 있습니다.

다음 샘플 코드는 Aspose.Slides for Java를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation)에 태그를 추가하는 방법을 보여줍니다.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

태그는 또한 [Slide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlide)에 설정할 수 있습니다.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)에 적용할 수도 있습니다.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **제한 사항**

`getCustomData().getTags()`를 사용하여 사용자 정의 데이터 태그 컬렉션을 통해 추가된 태그는 PowerPoint 파일 내부에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 해당 태그는 PDF 태그 구조로 **전송되지 않으며**, 따라서 태그로 지정된 사용자 정의 식별자를 PDF에서 가져올 수 없습니다.

**우회 방법**: 객체의 **Alt Text**에 사용자 정의 식별자를 저장할 수 있습니다(예: `shape.setAlternativeText("MyId")`). PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있습니까?**

예. [tag collection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tagcollection/)은 모든 키‑값 쌍을 한 번에 삭제하는 [clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tagcollection/#clear--) 작업을 지원합니다.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 해야 합니까?**

[tag collection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tagcollection/)에서 [Remove(name)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 작업을 사용하여 키로 태그를 삭제합니다.

**분석이나 필터링을 위해 태그 이름 전체 목록을 가져오려면 어떻게 해야 합니까?**

[tag collection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tagcollection/)에서 [getNamesOfTags](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tagcollection/#getNamesOfTags--)을 사용하면 모든 태그 이름이 배열로 반환됩니다.