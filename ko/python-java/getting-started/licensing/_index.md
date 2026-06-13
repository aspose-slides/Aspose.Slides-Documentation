---
title: 라이선스
description: "Aspose.Slides for Python via Java는 구매를 위한 다양한 플랜을 제공하거나 라이선스 및 구독 정책을 사용한 평가를 위해 무료 체험 및 30일 임시 라이선스를 제공합니다."
type: docs
weight: 80
url: /ko/python-java/licensing/
---
때때로 최상의 평가 결과를 위해 직접적인 접근이 필요할 수 있습니다. 이러한 이유로 Aspose.Slides는 다양한 구매 플랜을 제공하고 평가를 위해 무료 평가판 및 30일 임시 라이선스를 제공합니다.

{{% alert color="primary" %}}
평가, 적절한 라이선스 적용 및 제품 구매 방법을 안내하는 일반 정책과 관행이 여러 가지 있습니다. 이들은 ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) 섹션에서 확인할 수 있습니다.
{{% /alert %}}

## **Evaluate Aspose.Slides**
평가용으로 Aspose.Slides를 쉽게 다운로드할 수 있습니다. 평가 패키지는 구매 패키지와 동일합니다. 평가 버전은 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용된 버전이 됩니다.

## **Evaluation Version Limitation**
Aspose.Slides의 평가 버전(라이선스가 지정되지 않음)은 전체 제품 기능을 제공하지만, 열기 및 저장 시 문서 상단에 평가 워터마크를 삽입합니다. 또한 프레젠테이션 슬라이드에서 텍스트를 추출할 때 슬라이드가 하나로 제한됩니다.

{{% alert color="primary" %}}
평가 버전 제한 없이 Aspose.Slides를 테스트하고 싶다면 **30 Day Temporary License**를 요청할 수 있습니다. 자세한 내용은 [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) 를 참고하십시오.
{{% /alert %}}

## **About the License**
Aspose.Slides for Python via Java의 평가 버전을 [download page](https://releases.aspose.com/slides/ko/python-java/)에서 쉽게 다운로드할 수 있습니다. 평가 버전은 라이선스가 적용된 Aspose.Slides와 **동일한 기능**을 제공합니다. 또한 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가하면 라이선스가 적용된 버전이 됩니다.

라이선스는 제품 이름, 라이선스 대상 개발자 수, 구독 만료일 등과 같은 세부 정보를 포함하는 일반 텍스트 XML 파일입니다. 파일은 디지털 서명되어 있으므로 수정하지 마십시오. 파일 내용에 불필요한 줄바꿈을 추가하는 것조차도 라이선스를 무효화합니다.

평가 버전의 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 각 애플리케이션 또는 프로세스당 라이선스는 한 번만 설정하면 됩니다.

## Purchased License
구매 후에는 라이선스 파일 또는 스트림을 적용해야 합니다.

{{% alert color="primary" %}}
라이선스를 설정해야 합니다:
* 애플리케이션 도메인당 한 번만
* 다른 Aspose.Slides 클래스를 사용하기 전에
{{% /alert %}}

{{% alert color="primary" %}}
가격 정보는 [“Pricing Information”](https://purchase.aspose.com/pricing/slides/ko/family) 페이지에서 확인할 수 있습니다.
{{% /alert %}}

### **Setting a License in Aspose.Slides for Python via Java**
라이선스는 다음 위치에서 적용할 수 있습니다:
* 명시적 경로
* 스트림
* Metered License로 – 새로운 라이선스 메커니즘

{{% alert color="primary" %}}
**setLicense** 메서드를 사용하여 구성 요소에 라이선스를 적용합니다.

**setLicense**를 여러 번 호출해도 문제가 되지는 않지만, 자원(프로세서)를 낭비하게 됩니다.
{{% /alert %}}

{{% alert color="warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이러한 라이선스를 인식하지 못합니다.
{{% /alert %}}

#### **Applying a License Using a File**
다음 코드 스니펫은 라이선스 파일을 설정하는 데 사용됩니다:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

setLicense 메서드를 호출할 때 라이선스 이름은 라이선스 파일명과 동일해야 합니다. 예를 들어 라이선스 파일명을 "Aspose.Slides.lic.xml"로 변경할 수 있습니다. 그런 다음 코드에서 새로운 라이선스 이름(Aspose.Slides.lic.xml)을 setLicense 메서드에 전달해야 합니다.

#### **Applying a License from a Bytes**
다음 코드 스니펫은 바이트 배열에서 라이선스를 적용하는 데 사용됩니다:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Apply Metered License
Aspose.Slides는 개발자가 Metered 키를 적용할 수 있도록 합니다. 이는 새로운 라이선스 메커니즘입니다.

새 라이선스 메커니즘은 기존 라이선스 방식과 함께 사용됩니다. API 기능 사용량에 따라 요금이 청구되는 고객은

이 유형의 라이선스를 얻기 위한 모든 절차를 완료하면 라이선스 파일이 아니라 키를 받게 됩니다. 이 Metered 키는 특별히 도입된 **Metered** 클래스를 사용하여 적용할 수 있습니다.

다음 코드 예제는 Metered 공개 키와 개인 키를 설정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# CAD Metered 클래스의 인스턴스를 생성합니다
metered = Metered();

# set_metered_key 속성에 접근하고 공개키와 개인키를 매개변수로 전달합니다
metered.setMeteredKey("*****", "*****");

# API 호출 전 측정된 데이터 양을 가져옵니다
amountbefore = Metered.getConsumptionQuantity()

# 정보를 출력합니다
print("Amount Consumed Before: \" + amountbefore + \"" )

# 디스크에서 문서를 로드합니다.
pres = Presentation();

# 문서의 페이지 수를 가져옵니다
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# PDF로 저장합니다
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# API 호출 후 측정된 데이터 양을 가져옵니다
amountafter = Metered.getConsumptionQuantity()

# 정보를 출력합니다
print("Amount Consumed After: \" + amountafter + "\"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Metered 라이선스를 올바르게 사용하려면 지속적인 인터넷 연결이 필요합니다. Metered 메커니즘은 정확한 계산을 위해 당사 서비스와 지속적으로 상호 작용해야 하기 때문입니다. 자세한 내용은 [“Metered Licensing FAQ”](https://purchase.aspose.com/faqs/licensing/metered) 섹션을 참고하십시오.
{{% /alert %}}