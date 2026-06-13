---
title: Metered 라이선스
type: docs
weight: 100
url: /ko/java/metered-licensing/
keywords:
- 라이선스
- 계량 라이선스
- 라이선스 키
- 공개 키
- 개인 키
- 소비량
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 Metered 라이선스를 통해 PowerPoint 및 OpenDocument 파일을 유연하게 처리하고, 사용한 만큼만 비용을 지불하는 방법을 알아보세요."
---
## **소개**

Metered 라이선스는 기존 라이선스 방식과 함께 사용할 수 있는 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 비용이 청구되기를 원한다면 Metered 라이선스를 선택합니다.

## **Metered 키 적용**

{{% alert color="primary" %}} 

Metered 라이선스는 기존 라이선스 방식과 함께 사용할 수 있는 새로운 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 비용이 청구되기를 원한다면 Metered 라이선스를 선택합니다.

Metered 라이선스를 구매하면 키를 받게 되며(라이선스 파일은 제공되지 않습니다). 이 Metered 키는 Aspose에서 메터링 작업을 위해 제공한 [Metered](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/) 클래스를 사용하여 적용할 수 있습니다. 자세한 내용은 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)를 참조하십시오.

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/) 클래스의 인스턴스를 생성합니다.

1. 공개 키와 비공개 키를 [setMeteredKey](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 메서드에 전달합니다.

1. 몇 가지 처리를 수행합니다(작업 수행).

1. `Metered` 클래스의 [getConsumptionQuantity](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/#getConsumptionQuantity--) 메서드를 호출합니다.

지금까지 사용한 API 요청의 수량/양을 확인할 수 있습니다.

다음 샘플 코드는 Metered 라이선스 사용 방법을 보여줍니다:

```java
// Metered 클래스의 인스턴스를 생성합니다
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // 공개 키와 비공개 키를 Metered 객체에 전달합니다
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // API 호출 이전에 사용된 수량 값을 가져옵니다
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // 여기서 Aspose.Slides API를 사용하여 작업을 수행합니다
    // ...

    // API 호출 이후에 사용된 수량 값을 가져옵니다
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Metered 라이선스를 사용하려면 라이선스 메커니즘이 인터넷을 통해 우리 서비스와 지속적으로 상호 작용하고 계산을 수행하기 때문에 안정적인 인터넷 연결이 필요합니다.

{{% /alert %}} 

## **FAQ**

**같은 애플리케이션에서 일반 라이선스(영구 또는 임시)와 Metered 라이선스를 함께 사용할 수 있나요?**

예. Metered는 기존 [licensing methods](/slides/ko/java/licensing/)와 함께 사용할 수 있는 추가 라이선스 메커니즘입니다. 애플리케이션 시작 시 어떤 메커니즘을 적용할지 선택합니다.

**Metered 라이선스에서 실제로 소비로 간주되는 항목은 무엇인가요: 작업인지 파일인지?**

소비량은 API 사용량으로, 요청 횟수 또는 작업 수를 의미합니다. 현재 소비량은 [consumption-tracking methods](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/)를 통해 확인할 수 있습니다.

**인스턴스가 자주 재시작되는 마이크로서비스 및 서버리스 환경에 Metered가 적합한가요?**

예. 회계가 API 호출 수준에서 이루어지므로, 빈번한 콜드 스타트가 발생하는 시나리오도 Metered 계산을 위한 안정적인 네트워크 연결만 있다면 호환됩니다.

**영구 라이선스와 비교했을 때 Metered 라이선스를 사용할 때 라이브러리 기능에 차이가 있나요?**

아니요. 이는 라이선스 및 청구 메커니즘에 관한 것이며, 제품 기능은 동일합니다.

**Metered는 평가판 및 임시 라이선스와 어떤 관계가 있나요?**

평가판은 제한 및 워터마크가 적용되고, [temporary license](https://purchase.aspose.com/temporary-license/)는 30일 동안 제한을 해제하며, Metered는 제한을 없애고 실제 사용량에 따라 비용을 청구합니다.

**소비량 임계값을 초과했을 때 자동으로 반응하여 예산을 제어할 수 있나요?**

예. 일반적인 방법은 [tracking methods](https://reference.aspose.com/slides/ko/java/com.aspose.slides/metered/)를 사용해 현재 소비량을 주기적으로 읽어 애플리케이션이나 모니터링 수준에서 자체 제한이나 알림을 구현하는 것입니다.