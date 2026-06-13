---
title: PHP를 사용하여 프레젠테이션에 글꼴 임베드
linktitle: 글꼴 임베드
type: docs
weight: 40
url: /ko/php-java/embedded-font/
keywords:
- 글꼴 추가
- 글꼴 임베드
- 글꼴 임베딩
- 임베드된 글꼴 가져오기
- 임베드된 글꼴 추가
- 임베드된 글꼴 제거
- 임베드된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint 및 OpenDocument 프레젠테이션에 TrueType 글꼴을 임베드하여 모든 플랫폼에서 정확한 렌더링을 보장합니다."
---
## **소개**

**PowerPoint의 임베디드 글꼴**은 프레젠테이션을 어떤 시스템이나 장치에서 열어도 올바르게 표시하고 싶을 때 유용합니다. 작업을 창의적으로 만들기 위해 서드파티 또는 비표준 글꼴을 사용했다면 글꼴을 임베드해야 할 이유가 더 많아집니다. 그렇지 않으면(임베디드 글꼴이 없을 경우) 슬라이드의 텍스트나 숫자, 레이아웃, 스타일 등이 변경되거나 혼란스러운 사각형으로 표시될 수 있습니다.  

[FontsManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontsManager) 클래스, [FontData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontdata/) 클래스 및 [Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) 클래스에는 PowerPoint 프레젠테이션에서 임베디드 글꼴을 작업하는 데 필요한 대부분의 메서드가 포함되어 있습니다.

## **임베디드 글꼴 가져오기 및 제거**

Aspose.Slides는 프레젠테이션에 임베디드된 글꼴을 가져오거나(확인) 할 수 있도록 [getEmbeddedFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 메서드([FontsManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FontsManager) 클래스에서 제공)를 제공합니다. 글꼴을 제거하려면 동일한 클래스의 [removeEmbeddedFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) 메서드를 사용합니다.

이 PHP 코드는 프레젠테이션에서 임베디드 글꼴을 가져오고 제거하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 임베드된 "FunSized"를 사용하는 텍스트 프레임이 포함된 슬라이드를 렌더링합니다
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 이미지를 JPEG 형식으로 디스크에 저장합니다
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # 모든 임베드된 글꼴을 가져옵니다
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # "Calibri" 글꼴을 찾습니다
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # "Calibri" 글꼴을 제거합니다
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # 프레젠테이션을 렌더링합니다; "Calibri" 글꼴이 기존 글꼴로 대체됩니다
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 이미지를 JPEG 형식으로 디스크에 저장합니다
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 임베드된 "Calibri" 글꼴 없이 프레젠테이션을 디스크에 저장합니다
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **임베디드 글꼴 추가**

[EmbedFontCharacters](https://reference.aspose.com/slides/ko/php-java/aspose.slides/embedfontcharacters/) 클래스와 [addEmbeddedFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) 메서드의 두 가지 오버로드를 사용하여 프레젠테이션에 글꼴을 임베드하기 위한 원하는(임베드) 규칙을 선택할 수 있습니다. 이 PHP 코드는 프레젠테이션에 글꼴을 임베드하고 추가하는 방법을 보여줍니다:

```php
  # 프레젠테이션을 로드합니다
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # 프레젠테이션을 디스크에 저장합니다
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **임베디드 글꼴 압축**

프레젠테이션에 임베디드된 글꼴을 압축하고 파일 크기를 줄일 수 있도록 Aspose.Slides는 [compressEmbeddedFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#compressEmbeddedFonts) 메서드([Compress](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/) 클래스에서 제공)를 제공합니다.

이 PHP 코드는 임베디드 PowerPoint 글꼴을 압축하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**임베드했음에도 불구하고 프레젠테이션의 특정 글꼴이 렌더링 중에 여전히 대체될 수 있는지 어떻게 확인할 수 있나요?**  
글꼴 관리자의 [substitution information](/slides/ko/php-java/font-substitution/)와 [fallback/substitution rules](/slides/ko/php-java/fallback-font/)를 확인하세요. 글꼴이 없거나 제한된 경우 대체 글꼴이 사용됩니다.

**Arial/Calibri와 같은 "시스템" 글꼴을 임베드할 가치가 있나요?**  
대부분의 경우 아니요—이러한 글꼴은 언제나 거의 제공됩니다. 그러나 Docker와 같이 폰트가 사전 설치되지 않은 리눅스 서버와 같은 "thin" 환경에서 완벽한 이식성을 위해 시스템 글꼴을 임베드하면 예상치 못한 대체 위험을 없앨 수 있습니다.