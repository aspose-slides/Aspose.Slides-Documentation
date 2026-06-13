---
title: 라이선스
description: "Aspose.Slides for Node.js via .NET는 구매를 위한 다양한 플랜을 제공하거나 평가를 위해 라이선스 및 구독 정책을 사용한 무료 체험 및 30일 임시 라이선스를 제공합니다."
type: docs
weight: 80
url: /ko/nodejs-net/licensing/
---
때때로 최고의 평가 결과를 얻기 위해서는 실습이 필요할 수 있습니다. 이러한 이유로 Aspose.Slides는 다양한 구매 플랜을 제공하며 평가를 위한 무료 체험 및 30일 임시 라이선스도 제공합니다.

{{% alert color="primary" %}}
제품을 평가하고, 적절히 라이선스를 적용하며, 구매하는 방법을 안내하는 여러 일반 정책 및 관행이 있습니다. 이 내용은 ["구매 정책 및 FAQ"](https://purchase.aspose.com/policies) 섹션에서 확인할 수 있습니다.
{{% /alert %}}

## **Aspose.Slides 평가**
쉽게 Aspose.Slides 평가용으로 다운로드할 수 있습니다. 평가 패키지는 구매 패키지와 동일합니다. 라이선스를 적용하기 위해 몇 줄의 코드를 추가하면 평가 버전은 자동으로 라이선스가 적용됩니다.

## **평가 버전 제한**
라이선스가 지정되지 않은 Aspose.Slides 평가 버전은 전체 제품 기능을 제공하지만, 문서를 열거나 저장할 때 문서 상단에 평가 워터마크를 삽입합니다. 또한 프레젠테이션 슬라이드에서 텍스트를 추출할 경우 슬라이드가 하나로 제한됩니다.

{{% alert color="primary" %}} 
평가 버전 제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스를 받는 방법?](https://purchase.aspose.com/temporary-license) 을 참고하십시오.
{{% /alert %}} 

## **라이선스 정보**
Aspose.Slides for Node.js via .NET의 [다운로드 페이지](https://releases.aspose.com/slides/ko/nodejs-net/)에서 평가 버전을 쉽게 다운로드할 수 있습니다. 평가 버전은 라이선스가 적용된 Aspose.Slides와 **동일한 기능**을 제공합니다. 또한 라이선스를 구매하고 몇 줄의 코드를 추가하면 평가 버전이 자동으로 라이선스가 적용됩니다.

라이선스는 제품명, 라이선스 대상 개발자 수, 구독 만료일 등과 같은 세부 정보를 포함하는 일반 텍스트 XML 파일입니다. 파일은 디지털 서명되어 있으므로 수정해서는 안 됩니다. 파일 내용에 불필요한 줄 바꿈을 추가하는 것만으로도 라이선스가 무효화됩니다.

평가 버전과 관련된 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션이나 프로세스당 한 번만 라이선스를 설정하면 됩니다.

## 구매 라이선스

구매 후에는 라이선스 파일이나 스트림을 적용해야 합니다.

{{% alert color="primary" %}}
라이선스를 설정해야 합니다:
* 애플리케이션 도메인당 한 번만
* 다른 Aspose.Slides 클래스를 사용하기 전에
{{% /alert %}}

{{% alert color="primary" %}}
가격 정보는 ["가격 정보"](https://purchase.aspose.com/pricing/slides/ko/family) 페이지에서 확인할 수 있습니다.
{{% /alert %}}

### **Aspose.Slides for Node.js via .NET에서 라이선스 설정**

다음 위치에서 라이선스를 적용할 수 있습니다:

* 명시적 경로
* 스트림
* Metered License – 새로운 라이선스 메커니즘

{{% alert color="primary" %}}
**setLicense** 메서드를 사용하여 구성 요소에 라이선스를 적용합니다.

**setLicense**를 여러 번 호출해도 문제가 되지는 않지만, 리소스(프로세서)를 낭비하게 됩니다.
{{% /alert %}}

{{% alert color="warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이러한 라이선스를 인식하지 못합니다.
{{% /alert %}}

#### **파일을 사용한 라이선스 적용**
다음 코드 스니펫은 라이선스 파일을 설정하는 데 사용됩니다:

**Node.js**

```javascript
// PowerPoint 파일 조작을 위해 Aspose.Slides 모듈을 가져옵니다
const asposeSlides = require('aspose.slides.via.net');

// 이 함수는 라이선스로 Aspose.Slides 라이브러리를 설정합니다
function setupAsposeSlidesLicense() {
	
    // Aspose.Slides 모듈의 License 클래스를 초기화합니다
    var license = new asposeSlides.License();
    
    // 파일에서 라이선스를 적용합니다
    // "your_license_file.lic"를 실제 라이선스 파일 경로로 교체합니다
    license.setLicense("your_license_file.lic");
}

// Aspose.Slides의 라이선스를 설정하기 위해 함수를 실행합니다
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
setLicense 메서드를 호출할 때 라이선스 이름은 라이선스 파일 이름과 동일해야 합니다. 예를 들어, 라이선스 파일 이름을 "Aspose.Slides.lic.xml"로 변경할 수 있습니다. 이후 코드에서 setLicense 메서드에 새 라이선스 이름(Aspose.Slides.lic.xml)을 전달해야 합니다.
{{% /alert %}}