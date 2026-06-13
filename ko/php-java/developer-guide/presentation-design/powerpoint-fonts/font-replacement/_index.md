---
title: PHP를 사용한 프레젠테이션에서 글꼴 교체 간소화
linktitle: 글꼴 교체
type: docs
weight: 60
url: /ko/php-java/font-replacement/
keywords:
- 글꼴
- 글꼴 교체
- 글꼴 교체
- 글꼴 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides에서 글꼴을 원활하게 교체하여 PowerPoint 및 OpenDocument 프레젠테이션에서 일관된 타이포그래피를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 전체에서 한 글꼴을 다른 글꼴로 교체할 수 있습니다. 글꼴이 교체되면 원래 글꼴의 모든 인스턴스가 새 글꼴로 변경됩니다.

글꼴 교체를 수행하려면 프레젠테이션을 로드하고, 원본 글꼴과 교체할 글꼴을 정의한 다음, 글꼴 교체 메서드를 호출하고 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 이 방법은 프레젠테이션 전체에서 의도적으로 한 글꼴 패밀리를 다른 패밀리로 전환하려는 경우에 유용합니다.

## **글꼴 교체**

글꼴 사용에 대한 생각이 바뀐 경우, 해당 글꼴을 다른 글꼴로 교체할 수 있습니다. 이전 글꼴의 모든 인스턴스가 새 글꼴로 교체됩니다.

Aspose.Slides는 다음과 같이 글꼴을 교체할 수 있습니다:

1. 관련 프레젠테이션을 로드합니다.
2. 교체될 글꼴을 로드합니다.
3. 새 글꼴을 로드합니다.
4. 글꼴을 교체합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 PHP 코드는 글꼴 교체를 보여줍니다:

```php
  # 프레젠테이션을 로드합니다
  $pres = new Presentation("Fonts.pptx");
  try {
    # 교체될 원본 글꼴을 로드합니다
    $sourceFont = new FontData("Arial");
    # 새 글꼴을 로드합니다
    $destFont = new FontData("Times New Roman");
    # 글꼴을 교체합니다
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # 프레젠테이션을 저장합니다
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="참고" color="warning" %}} 
특정 조건(예: 글꼴에 접근할 수 없는 경우)에서 발생하는 동작을 결정하는 규칙을 설정하려면 [**글꼴 대체**](/slides/ko/php-java/font-substitution/)를 참조하세요.
{{% /alert %}}

## **FAQ**

**"글꼴 교체", "글꼴 대체", 그리고 "대체 글꼴"의 차이점은 무엇인가요?**

교체는 전체 문서에서 한 패밀리를 다른 패밀리로 의도적으로 전환하는 것입니다. [**글꼴 대체**](/slides/ko/php-java/font-substitution/)는 "글꼴을 사용할 수 없을 경우 X를 사용한다"와 같은 규칙입니다. [**대체 글꼴**](/slides/ko/php-java/fallback-font/)은 기본 글꼴이 설치되어 있지만 필요한 문자를 포함하지 않을 때 개별 누락 글리프에 대해 선택적으로 적용됩니다.

**교체가 마스터 슬라이드, 레이아웃, 노트 및 댓글에도 적용되나요?**

예. 교체는 원본 글꼴을 사용하는 모든 프레젠테이션 객체에 영향을 미치며, 여기에는 마스터 슬라이드와 노트가 포함됩니다; 댓글도 문서의 일부이며 글꼴 엔진이 고려합니다.

**내장된 OLE 객체(예: Excel) 내부의 글꼴도 변경되나요?**

아니오. [OLE 콘텐츠](/slides/ko/php-java/manage-ole/)는 해당 애플리케이션이 제어합니다. 프레젠테이션에서의 교체는 내부 OLE 데이터의 형식을 변경하지 않으며, 이미지로나 외부에서 편집 가능한 콘텐츠로 표시될 수 있습니다.

**프레젠테이션의 일부(슬라이드 또는 영역)만 글꼴을 교체할 수 있나요?**

대상 지정 교체는 전체 문서에 전역 교체를 적용하는 대신 필요 객체/범위 수준에서 글꼴을 변경하면 가능합니다. 렌더링 중 전체 글꼴 선택 로직은 동일하게 유지됩니다.

**프레젠테이션이 사용하는 모든 글꼴을 미리 어떻게 확인할 수 있나요?**

프레젠테이션의 [폰트 관리자](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/)를 사용하십시오: 여기에는 사용 중인 [패밀리](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/getfonts/) 목록과 [대체/"알 수 없음" 글꼴](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/getsubstitutions/) 정보가 포함되어 있어 교체 계획에 도움이 됩니다.

**PDF/이미지로 변환할 때 글꼴 교체가 작동하나요?**

예. 내보내기 시 Aspose.Slides는 동일한 [글꼴 선택/대체 순서](/slides/ko/php-java/font-selection-sequence/)를 적용하므로 사전에 수행된 교체가 변환 중에도 적용됩니다.

**시스템에 대상 글꼴을 설치해야 하나요, 아니면 폰트 폴더를 첨부할 수 있나요?**

설치가 필요하지 않습니다. 라이브러리는 사용자 폴더에서 [외부 글꼴 로드](/slides/ko/php-java/custom-font/)를 허용하며, 이는 [렌더링 및 내보내기](/slides/ko/php-java/convert-powerpoint/) 중에 사용됩니다.

**교체가 문자 대신 “토푸”(사각형) 표시를 해결해 주나요?**

대상 글꼴에 실제로 필요한 글리프가 포함된 경우에만 해결됩니다. 포함되지 않은 경우 [대체 글꼴 구성](/slides/ko/php-java/fallback-font/)을 설정하여 누락된 문자를 보완하십시오.