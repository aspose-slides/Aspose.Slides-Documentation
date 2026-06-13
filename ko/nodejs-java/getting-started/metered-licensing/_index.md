---
title: Metered 라이선스
type: docs
weight: 100
url: /ko/nodejs-java/metered-licensing/
keywords:
- 라이선스
- 계량 라이선스
- 라이선스 키
- 공개 키
- 비공개 키
- 소비량
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 Java 메터링 라이선스로 사용하여 PowerPoint 및 OpenDocument 파일을 유연하게 처리하고, 사용한 만큼만 비용을 지불하는 방법을 알아보세요."
---
## **소개**

Metered 라이선스는 기존 라이선스 방식과 함께 사용할 수 있는 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 과금받고 싶다면 Metered 라이선스를 선택하면 됩니다.

## **Metered 키 적용**

Metered 라이선스를 구매하면 라이선스 파일이 아니라 키를 받게 됩니다. 이 Metered 키는 Aspose에서 제공하는 메터링 작업용 [Metered](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/metered/) 클래스를 사용하여 적용할 수 있습니다. 자세한 내용은 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)를 참조하세요.

1. [Metered](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/metered/) 클래스의 인스턴스를 생성합니다.

1. 공개 키와 비공개 키를 [setMeteredKey](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/metered/#setMeteredKey) 메서드에 전달합니다.

1. 작업을 수행합니다(예: 작업 수행).

1. `Metered` 클래스의 [getConsumptionQuantity](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) 메서드를 호출합니다.

지금까지 사용한 API 요청 수량을 확인할 수 있습니다.

다음 샘플 코드는 Metered 라이선스를 사용하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creates an instance of the Metered class
// Metered 클래스의 인스턴스를 생성합니다
var metered = new aspose.slides.Metered();

// Passes the public and private keys to the Metered object
// 공개 키와 비공개 키를 Metered 객체에 전달합니다
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Gets the consumed quantity value before API calls
// API 호출 전에 소비된 양 값을 가져옵니다
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Do something with Aspose.Slides API here
// 여기서 Aspose.Slides API로 작업을 수행합니다
// ...

// Gets the consumed quantity value after API calls
// API 호출 후에 소비된 양 값을 가져옵니다
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
Metered 라이선스를 사용하려면 안정적인 인터넷 연결이 필요합니다. 라이선스 메커니즘이 인터넷을 통해 지속적으로 당사 서비스와 상호 작용하고 계산을 수행하기 때문입니다.
{{% /alert %}} 

## **FAQ**

**같은 애플리케이션에서 Metered 라이선스를 일반 라이선스(영구 라이선스 또는 임시 라이선스)와 함께 사용할 수 있나요?**

예. Metered는 기존 [licensing methods](/slides/ko/nodejs-java/licensing/)와 함께 사용할 수 있는 추가 라이선스 메커니즘입니다. 애플리케이션 시작 시 적용할 메커니즘을 선택하면 됩니다.

**Metered 라이선스에서 실제로 소비로 계산되는 항목은 무엇인가요: 작업인가요, 파일인가요?**

소비는 API 사용량으로 계산되며, 즉 요청 수 혹은 작업 수를 의미합니다. 현재 소비량은 [consumption-tracking methods](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/metered/)를 통해 확인할 수 있습니다.

**인스턴스가 자주 재시작되는 마이크로서비스 및 서버리스 환경에 Metered가 적합한가요?**

예. 회계가 API 호출 수준에서 이루어지기 때문에 빈번한 콜드 스타트가 발생하는 시나리오도 안정적인 네트워크 연결만 확보한다면 호환됩니다.

**Metered 라이선스를 사용할 때와 영구 라이선스를 사용할 때 라이브러리 기능에 차이가 있나요?**

아니요. 이는 라이선스 및 과금 메커니즘에만 해당되며, 제품 기능은 동일합니다.

**Metered가 체험판 및 임시 라이선스와는 어떻게 관련되나요?**

체험판은 제한 및 워터마크가 적용되고, [temporary license](https://purchase.aspose.com/temporary-license/)는 30일 동안 제한을 해제합니다. Metered는 제한을 없애고 실제 사용량에 따라 과금합니다.

**소비 임계값 초과 시 자동으로 반응하여 예산을 제어할 수 있나요?**

예. 일반적인 방법은 [tracking methods](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/metered/)를 통해 현재 소비량을 주기적으로 읽어 애플리케이션이나 모니터링 단계에서 자체 제한이나 경고를 구현하는 것입니다.