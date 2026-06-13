---
title: Metered 라이선스
type: docs
weight: 90
url: /ko/net/metered-licensing/
keywords:
- 라이선스
- 계량형 라이선스
- 라이선스 키
- 공개 키
- 개인 키
- 사용량 수량
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 계량형 라이선스가 PowerPoint 및 OpenDocument 파일을 유연하게 처리하고, 사용한 만큼만 비용을 지불하도록 하는 방법을 알아보세요."
---
## **소개**

Metered 라이선스는 기존 라이선스 방식과 함께 사용할 수 있는 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 요금이 부과되도록 하려면 Metered 라이선스를 선택합니다.

## **Metered 키 적용**

Metered 라이선스를 구매하면 키를 받게 되며(라이선스 파일은 제공되지 않습니다). 이 Metered 키는 Aspose에서 메터링 작업을 위해 제공한 [Metered](https://reference.aspose.com/slides/ko/net/aspose.slides/metered/) 클래스를 사용하여 적용할 수 있습니다. 자세한 내용은 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) 를 참조하십시오.

1. [Metered](https://reference.aspose.com/slides/ko/net/aspose.slides/metered/) 클래스의 인스턴스를 생성합니다.
2. 공개 키와 개인 키를 [SetMeteredKey](https://reference.aspose.com/slides/ko/net/aspose.slides/metered/setmeteredkey/) 메서드에 전달합니다.
3. 일부 처리를 수행합니다(작업 수행).
4. `Metered` 클래스의 [GetConsumptionQuantity](https://reference.aspose.com/slides/ko/net/aspose.slides/metered/getconsumptionquantity/) 메서드를 호출합니다.

지금까지 사용한 API 요청의 양/수를 확인할 수 있습니다.

다음 샘플 코드는 Metered 라이선스 사용 방법을 보여줍니다:

```cs
// Metered 클래스의 인스턴스를 생성합니다
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// 공개 키와 개인 키를 Metered 객체에 전달합니다
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// API 호출 전에 계량 데이터 수량을 가져옵니다
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// 여기서 Aspose.Slides API를 사용해 무언가 수행합니다
// ...

// API 호출 후 계량 데이터 양을 가져옵니다
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 
Metered 라이선스를 사용하려면 라이선스 메커니즘이 지속적으로 서비스와 상호 작용하고 계산을 수행하기 위해 인터넷을 사용하므로 안정적인 인터넷 연결이 필요합니다.
{{% /alert %}} 

## **FAQ**

**같은 애플리케이션에서 Metered 라이선스를 일반 라이선스(영구 또는 임시)와 함께 사용할 수 있나요?**

예. Metered는 기존 [라이선스 방법](/slides/ko/net/licensing/)와 함께 사용할 수 있는 추가 라이선스 메커니즘입니다. 애플리케이션 시작 시 적용할 메커니즘을 선택하면 됩니다.

**Metered 라이선스에서 실제로 사용량으로 계산되는 것은 무엇인가요: 작업인지 파일인지?**

API 사용량이 계산됩니다. 즉, 요청 또는 작업 수가 기준이 됩니다. 현재 사용량은 [소비 추적 방법](https://reference.aspose.com/slides/ko/net/aspose.slides/metered/) 를 통해 확인할 수 있습니다.

**인스턴스가 자주 재시작되는 마이크로서비스 및 서버리스 환경에 Metered가 적합한가요?**

예. 회계가 API 호출 수준에서 이루어지므로, 자주 콜드 스타트가 발생하는 시나리오도 Metered 계산을 위한 안정적인 네트워크 접근만 보장된다면 호환됩니다.

**Metered 라이선스를 사용할 때와 영구 라이선스를 사용할 때 라이브러리 기능에 차이가 있나요?**

아니요. 이는 라이선스 및 청구 메커니즘에만 해당되며, 제품의 기능은 동일합니다.

**Metered는 체험 버전 및 임시 라이선스와 어떤 관계가 있나요?**

체험 버전은 제한 및 워터마크가 적용되며, [임시 라이선스](https://purchase.aspose.com/temporary-license/)는 30일 동안 제한을 해제합니다. Metered는 제한을 해제하고 실제 사용량에 따라 요금이 부과됩니다.

**소비 임계값을 초과했을 때 자동으로 대응하여 예산을 제어할 수 있나요?**

예. 일반적인 방법으로는 [추적 메서드](https://reference.aspose.com/slides/ko/net/aspose.slides/metered/) 를 사용해 현재 사용량을 주기적으로 읽고, 애플리케이션 또는 모니터링 수준에서 자체 제한이나 알림을 구현합니다.