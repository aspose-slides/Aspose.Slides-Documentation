---
title: 사용량 기반 라이선스
type: docs
weight: 100
url: /ko/java/metered-licensing/
keywords:
- 라이선스
- 사용량 기반 라이선스
- 라이선스 키
- 공개 키
- 비공개 키
- 사용량
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 사용량 기반 라이선스를 사용하면 PowerPoint 및 OpenDocument 파일을 유연하게 처리하고, 사용한 만큼만 비용을 지불할 수 있음을 배웁니다."
---
## **소개**

Metered 라이선스는 기존 라이선스 방식과 함께 사용할 수 있는 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 요금이 청구되길 원한다면 Metered 라이선스를 선택하세요.

## **Metered 키 적용**

{{% alert color="info" %}} 

Metered 라이선스는 기존 라이선스 방식과 함께 사용할 수 있는 새로운 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 요금이 청구되길 원한다면 Metered 라이선스를 선택하세요.

Metered 라이선스를 구매하면 라이선스 파일이 아닌 키를 받게 됩니다. 이 Metered 키는 Aspose에서 제공하는 [Metered](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/) 클래스를 사용하여 적용할 수 있습니다. 자세한 내용은 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)를 참조하세요.

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/) 클래스의 인스턴스를 생성합니다.

1. 공개 키와 비공개 키를 [setMeteredKey](https://reference.aspose.com/slides/ko/java/com.aspose.slides.metered/#setMeteredKey-java.lang.String-java.lang.String-) 메서드에 전달합니다.

1. 작업을 수행합니다.

1. `Metered` 클래스의 [getConsumptionQuantity](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/#getConsumptionQuantity--) 메서드를 호출합니다.

지금까지 사용한 API 요청 수량을 확인할 수 있습니다.

다음 샘플 코드는 Metered 라이선스를 사용하는 방법을 보여줍니다:

```java
// Metered 클래스의 인스턴스를 생성합니다
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // 공개 키와 비공개 키를 Metered 객체에 전달합니다
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // API 호출 전에 사용된 양 값을 가져옵니다
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // 여기서 Aspose.Slides API를 사용하여 작업을 수행합니다
    // ...
    // API 호출 후 사용된 양 값을 가져옵니다
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Metered 라이선스를 사용하려면 안정적인 인터넷 연결이 필요합니다. 라이선스 메커니즘이 지속적으로 우리 서비스와 통신하고 계산을 수행하기 때문입니다.

{{% /alert %}} 

## **FAQ**

### 동일한 애플리케이션에서 Metered 라이선스를 영구 또는 임시 라이선스와 함께 사용할 수 있나요?

예. Metered는 기존 [licensing methods](/slides/ko/java/licensing/)와 함께 사용할 수 있는 추가 라이선스 메커니즘입니다. 애플리케이션 시작 시 적용할 메커니즘을 선택하면 됩니다.

### Metered 라이선스에서 실제 사용량으로 간주되는 것은 무엇인가요: 작업인가 파일인가요?

API 사용량이 카운트됩니다. 즉 요청 수 또는 작업 수를 의미합니다. 현재 사용량은 [consumption-tracking methods](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/)를 통해 확인할 수 있습니다.

### 인스턴스가 자주 재시작되는 마이크로서비스 및 서버리스 환경에 Metered가 적합한가요?

예. 사용량 계산이 API 호출 수준에서 이루어지기 때문에 잦은 콜드 스타트가 있는 시나리오도 안정적인 네트워크 연결만 확보하면 호환됩니다.

### Metered 라이선스를 사용할 때와 영구 라이선스를 사용할 때 라이브러리 기능에 차이가 있나요?

아니오. 이는 라이선스 및 청구 메커니즘에만 해당되며, 제품 기능은 동일합니다.

### Metered 라이선스는 체험판 및 임시 라이선스와 어떻게 연관되나요?

체험판은 제한 및 워터마크가 적용되고, [temporary license](https://purchase.aspose.com/temporary-license/)는 30일 동안 제한을 해제하며, Metered는 제한을 해제하고 실제 사용량에 따라 과금됩니다.

### 소비량 임계값을 초과했을 때 자동으로 반응하여 예산을 통제할 수 있나요?

예. 일반적인 방법은 [tracking methods](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/)를 통해 현재 사용량을 정기적으로 읽어 애플리케이션 또는 모니터링 수준에서 자체 제한이나 알림을 구현하는 것입니다.