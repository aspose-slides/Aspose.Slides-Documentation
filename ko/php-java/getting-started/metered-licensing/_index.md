---
title: Metered 라이선스
type: docs
weight: 100
url: /ko/php-java/metered-licensing/
keywords:
- 라이선스
- Metered 라이선스
- 라이선스 키
- 공개 키
- 비공개 키
- 소비량
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java Metered 라이선스를 사용하면 PowerPoint 및 OpenDocument 파일을 유연하게 처리하고, 사용량에 따라만 비용을 지불할 수 있는 방법을 배웁니다."
---
## **소개**

Metered 라이선스는 기존 라이선스 방식과 함께 사용할 수 있는 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 청구받고 싶다면 Metered 라이선스를 선택하면 됩니다.

## **Metered 키 적용**

Metered 라이선스를 구매하면 키(라이선스 파일이 아님)를 받게 됩니다. 이 Metered 키는 Aspose에서 제공하는 [Metered](https://reference.aspose.com/slides/ko/php-java/aspose.slides/metered/) 클래스를 사용해 적용할 수 있습니다. 자세한 내용은 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)를 참고하세요.

1. [Metered](https://reference.aspose.com/slides/ko/php-java/aspose.slides/metered/) 클래스의 인스턴스를 생성합니다.

1. 공개 키와 비공개 키를 [setMeteredKey](https://reference.aspose.com/slides/ko/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 메서드에 전달합니다.

1. 일부 처리를 수행합니다(작업 수행).

1. `Metered` 클래스의 [getConsumptionQuantity](https://reference.aspose.com/slides/ko/php-java/aspose.slides/metered/#getConsumptionQuantity--) 메서드를 호출합니다.

지금까지 사용한 API 요청량을 확인할 수 있습니다.

다음 샘플 코드는 Metered 라이선스를 사용하는 방법을 보여줍니다:

```php
// Metered 클래스의 인스턴스를 생성합니다
$metered = new Metered();

try {
    // 공개 키와 비공개 키를 Metered 객체에 전달합니다
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // API 호출 전 소비된 양 값을 가져옵니다
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // 여기에서 Aspose.Slides API를 사용해 작업을 수행합니다
    // ...

    // API 호출 후 소비된 양 값을 가져옵니다
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Metered 라이선스를 사용하려면 라이선스 메커니즘이 지속적으로 서비스와 통신하고 계산을 수행하므로 안정적인 인터넷 연결이 필요합니다.
{{% /alert %}} 

## **FAQ**

**일반 라이선스(영구 또는 임시)와 Metered 라이선스를 동일 애플리케이션에서 함께 사용할 수 있나요?**

예. Metered는 기존 [licensing methods](/slides/ko/php-java/licensing/)와 함께 사용할 수 있는 추가 라이선스 메커니즘입니다. 애플리케이션 시작 시 적용할 메커니즘을 선택하면 됩니다.

**Metered 라이선스에서 실제로 소비되는 것은 무엇인가요: 작업인가 파일인가요?**

API 사용량이 계산됩니다. 즉, 요청 수 또는 작업 수가 측정됩니다. 현재 소비량은 [consumption‑tracking methods](https://reference.aspose.com/slides/ko/php-java/aspose.slides/metered/)를 통해 확인할 수 있습니다.

**인스턴스가 자주 재시작되는 마이크로서비스 및 서버리스 환경에 Metered가 적합한가요?**

예. 회계가 API 호출 수준에서 이루어지므로 콜드 스타트가 빈번한 시나리오에서도 네트워크 연결만 안정적이면 호환됩니다.

**Metered 라이선스를 사용할 때 제품 기능이 영구 라이선스와 달라지나요?**

아니요. 라이선스 및 청구 메커니즘에만 차이가 있을 뿐, 제품 기능은 동일합니다.

**Metered는 평가판 및 임시 라이선스와 어떤 관계가 있나요?**

평가판은 제한 및 워터마크가 있으며, [temporary license](https://purchase.aspose.com/temporary-license/)는 30일 동안 제한을 해제합니다. Metered는 제한을 해제하고 실제 사용량에 따라 과금합니다.

**소비량 임계값 초과 시 자동으로 예산을 제어할 수 있나요?**

예. 일반적인 방법은 [tracking methods](https://reference.aspose.com/slides/ko/php-java/aspose.slides/metered/)를 사용해 현재 소비량을 주기적으로 읽고, 애플리케이션이나 모니터링 수준에서 자체 한도나 알림을 구현하는 것입니다.