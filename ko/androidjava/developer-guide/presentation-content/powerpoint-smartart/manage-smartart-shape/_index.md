---
title: Android에서 프레젠테이션의 SmartArt 그래픽 관리
linktitle: SmartArt 그래픽
type: docs
weight: 20
url: /ko/androidjava/manage-smartart-shape/
keywords:
- SmartArt 개체
- SmartArt 그래픽
- SmartArt 스타일
- SmartArt 색상
- SmartArt 생성
- SmartArt 추가
- SmartArt 편집
- SmartArt 변경
- SmartArt 접근
- SmartArt 레이아웃 유형
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 PowerPoint SmartArt 생성, 편집 및 스타일링을 자동화하고, 간결한 Java 코드 예제와 성능 중심 가이드를 제공합니다."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에서 SmartArt 그래픽을 만들고 관리할 수 있습니다. 이 문서에서는 슬라이드에 SmartArt 도형을 추가하고, 기존 SmartArt 도형에 접근하며, 특정 레이아웃 유형으로 SmartArt를 찾고, SmartArt 스타일 또는 색상 스타일을 변경하여 시각적 모양을 업데이트하는 방법을 설명합니다.

예제에서는 프레젠테이션 슬라이드의 도형 컬렉션을 통해 SmartArt 도형을 작업하는 방법, 도형이 SmartArt인지 확인하고 해당 속성을 수정하거나 확인하는 방법을 보여줍니다.

## **SmartArt 도형 만들기**
Aspose.Slides for Android via Java는 SmartArt 도형을 만들기 위한 API를 제공합니다. 슬라이드에 SmartArt 도형을 만들려면 아래 단계를 따르세요.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.  
3. [SmartArt 도형 추가](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)를 수행하고, [LayoutType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SmartArtLayoutType)을 설정합니다.  
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// 프레젠테이션 클래스 인스턴스화
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드 가져오기
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Smart Art 도형 추가
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // 프레젠테이션 저장
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 슬라이드에 추가된 SmartArt 도형**|

## **슬라이드에서 SmartArt 도형에 접근하기**
다음 코드는 프레젠테이션 슬라이드에 추가된 SmartArt 도형에 접근하는 방법을 보여줍니다. 샘플 코드에서는 슬라이드 내부의 모든 도형을 순회하면서 해당 도형이 [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SmartArt)인지 확인합니다. SmartArt 유형인 경우 이를 [**SmartArt**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SmartArt) 인스턴스로 형변환합니다.

```java
// 원하는 프레젠테이션을 로드합니다
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환합니다
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **특정 레이아웃 유형을 가진 SmartArt 도형에 접근하기**
다음 샘플 코드는 특정 LayoutType을 가진 [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SmartArt) 도형에 접근하는 방법을 보여줍니다. SmartArt는 읽기 전용인 LayoutType을 가지고 있으며, 이는 SmartArt 도형이 추가될 때만 설정됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.  
3. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SmartArt) 유형인지 확인하고, SmartArt인 경우 해당 도형을 SmartArt로 형변환합니다.  
5. 특정 LayoutType을 가진 SmartArt 도형을 확인하고, 이후 필요한 작업을 수행합니다.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환합니다
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt 레이아웃 확인
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 도형 스타일 변경**
이 예제에서는 任意의 SmartArt 도형에 대해 빠른 스타일을 변경하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.  
3. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SmartArt) 유형인지 확인하고, SmartArt인 경우 해당 도형을 SmartArt로 형변환합니다.  
5. 특정 스타일을 가진 SmartArt 도형을 찾습니다.  
6. SmartArt 도형에 새 스타일을 설정합니다.  
7. 프레젠테이션을 저장합니다.

```java
// 프레젠테이션 클래스 인스턴스화
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 첫 번째 슬라이드 가져오기
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : slide.getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt) 
        {
            // 도형을 SmartArtEx로 형변환합니다
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 스타일 확인
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt 스타일 변경
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // 프레젠테이션 저장
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 스타일이 변경된 SmartArt 도형**|

## **SmartArt 도형 색상 스타일 변경**
이 예제에서는 任意의 SmartArt 도형에 대해 색상 스타일을 변경하는 방법을 배웁니다. 다음 샘플 코드는 특정 색상 스타일을 가진 SmartArt 도형에 접근하고 해당 스타일을 변경합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.  
3. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
4. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SmartArt) 유형인지 확인하고, SmartArt인 경우 해당 도형을 SmartArt로 형변환합니다.  
5. 특정 색상 스타일을 가진 SmartArt 도형을 찾습니다.  
6. SmartArt 도형에 새 색상 스타일을 설정합니다.  
7. 프레젠테이션을 저장합니다.

```java
// 프레젠테이션 클래스 인스턴스화
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 첫 번째 슬라이드 가져오기
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : slide.getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt) 
        {
            // 도형을 SmartArtEx로 형변환합니다
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 색상 유형 확인
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt 색상 유형 변경
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // 프레젠테이션 저장
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**그림: 색상 스타일이 변경된 SmartArt 도형**|

## **FAQ**

**SmartArt를 단일 객체로 애니메이션할 수 있나요?**

예. SmartArt는 도형이므로 다른 도형과 마찬가지로 애니메이션 API(입장, 퇴장, 강조, 움직임 경로)를 통해 [표준 애니메이션](/slides/ko/androidjava/powerpoint-animation/)을 적용할 수 있습니다.

**슬라이드에서 내부 ID를 모를 때 특정 SmartArt를 어떻게 찾을 수 있나요?**

대체 텍스트(AltText)를 설정하고 해당 값을 기준으로 도형을 검색합니다—이는 대상 도형을 찾는 권장 방법입니다.

**SmartArt를 다른 도형과 그룹화할 수 있나요?**

예. SmartArt를 다른 도형(그림, 표 등)과 그룹화한 뒤 [그룹을 조작](/slides/ko/androidjava/group/)할 수 있습니다.

**특정 SmartArt(예: 미리보기 또는 보고서용)의 이미지를 얻으려면 어떻게 해야 하나요?**

도형의 썸네일/이미지를 내보냅니다; 라이브러리는 개별 도형을 래스터 파일(PNG/JPG/TIFF)로 [렌더링](/slides/ko/androidjava/create-shape-thumbnails/)할 수 있습니다.

**전체 프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. 렌더링 엔진은 [PDF 내보내기](/slides/ko/androidjava/convert-powerpoint-to-pdf/)에 대해 높은 충실도를 목표로 하며, 다양한 품질 및 호환성 옵션을 제공합니다.