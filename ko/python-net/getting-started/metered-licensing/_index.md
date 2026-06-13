---
title: 미터링 라이선스
type: docs
weight: 90
url: /ko/python-net/metered-licensing/
keywords:
- 라이선스
- 계량식 라이선스
- 라이선스 키
- 공개 키
- 비공개 키
- 사용량
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET 계량식 라이선스를 사용하면 PowerPoint 및 OpenDocument 파일을 유연하게 처리하고, 사용한 만큼만 비용을 지불할 수 있는 방법을 배웁니다."
---
## **소개**

Metered 라이선스는 기존 라이선스 방식을 함께 사용할 수 있는 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 청구받고 싶다면 Metered 라이선스를 선택합니다.

## **Metered 키 적용**

{{% alert color="primary" %}} 

Metered 라이선스는 기존 라이선스 방식을 함께 사용할 수 있는 새로운 라이선스 메커니즘입니다. Aspose.Slides API 기능 사용량에 따라 청구받고 싶다면 Metered 라이선스를 선택합니다.

Metered 라이선스를 구매하면 파일 대신 키를 받게 됩니다. 이 Metered 키는 Aspose에서 제공하는 메터링 작업용 [Metered](https://reference.aspose.com/slides/ko/python-net/aspose.slides/metered/) 클래스를 사용해 적용할 수 있습니다. 자세한 내용은 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)를 참조하세요.

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/ko/python-net/aspose.slides/metered/) 클래스의 인스턴스를 생성합니다.
1. 공개 키와 비공개 키를 [set_metered_key](https://reference.aspose.com/slides/ko/python-net/aspose.slides/metered/set_metered_key/#str-str) 메서드에 전달합니다.
1. 일부 처리를 수행합니다(작업 수행).
1. `Metered` 클래스의 [get_consumption_quantity](https://reference.aspose.com/slides/ko/python-net/aspose.slides/metered/get_consumption_quantity/#) 메서드를 호출합니다.

지금까지 사용한 API 요청 수량을 확인할 수 있습니다.

다음 샘플 코드는 Metered 라이선스를 사용하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Metered 클래스의 인스턴스를 생성합니다
metered = slides.Metered()

# 공개 키와 비공개 키를 Metered 객체에 전달합니다
metered.set_metered_key("<valid public key>", "<valid private key>")

# API 호출 전 사용량 값을 가져옵니다
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# 여기에서 Aspose.Slides API를 사용하여 작업을 수행합니다
# ...

# API 호출 후 사용량 값을 가져옵니다
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Metered 라이선스를 사용하려면 안정적인 인터넷 연결이 필요합니다. 라이선스 메커니즘이 지속적으로 서비스와 통신하고 계산을 수행하기 때문입니다.

{{% /alert %}} 

## **FAQ**

**같은 애플리케이션에서 Metered 라이선스를 일반 라이선스(영구 또는 임시)와 함께 사용할 수 있나요?**

예. Metered는 기존 [licensing methods](/slides/ko/python-net/licensing/)와 함께 사용할 수 있는 추가 라이선스 메커니즘입니다. 애플리케이션 시작 시 적용할 메커니즘을 선택하면 됩니다.

**Metered 라이선스에서 실제로 소비로 판단되는 것은 무엇인가요: 작업인가 파일인가요?**

소비는 API 사용량으로 계산되며, 즉 요청 또는 작업 수를 의미합니다. 현재 소비량은 [consumption-tracking methods](https://reference.aspose.com/slides/ko/python-net/aspose.slides/metered/)를 통해 확인할 수 있습니다.

**인스턴스가 자주 재시작되는 마이크로서비스와 서버리스 환경에 Metered를 사용할 수 있나요?**

예. 청구가 API 호출 수준에서 이루어지기 때문에 빈번한 콜드 스타트가 발생하는 시나리오도 안정적인 네트워크 연결만 확보하면 호환됩니다.

**Metered 라이선스를 사용할 때와 영구 라이선스를 사용할 때 라이브러리 기능이 달라지나요?**

아니요. 이는 라이선스와 청구 메커니즘에만 해당되며, 제품 기능은 동일합니다.

**Metered는 체험판 및 임시 라이선스와 어떤 관계가 있나요?**

체험판은 제한 및 워터마크가 적용되며, [temporary license](https://purchase.aspose.com/temporary-license/)는 30일 동안 제한을 해제합니다. Metered는 제한을 없애고 실제 사용량에 따라 과금합니다.

**소비 임계값을 초과했을 때 자동으로 대응해 예산을 관리할 수 있나요?**

예. 일반적인 방법은 [tracking methods](https://reference.aspose.com/slides/ko/python-net/aspose.slides/metered/)를 통해 현재 소비량을 주기적으로 확인하고, 애플리케이션이나 모니터링 수준에서 자체 제한이나 알림을 구현하는 것입니다.