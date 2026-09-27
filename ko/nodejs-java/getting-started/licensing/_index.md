---
title: 라이선스
type: docs
weight: 80
url: /ko/nodejs-java/licensing/
keywords:
- 라이선스
- 임시 라이선스
- 라이선스 설정
- 라이선스 사용
- 라이선스 검증
- 라이선스 파일
- 평가 버전
- PowerPoint
- OpenDocument
- 프리젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 라이선스를 적용하고 관리하며 문제를 해결합니다. 단계별 라이선스 가이드를 통해 전체 기능을 중단 없이 사용할 수 있습니다."
---
## **소개**

때때로 최상의 평가 결과를 얻기 위해서는 직접 체험하는 접근 방식이 필요할 수 있습니다. 이러한 이유로 Aspose.Slides는 다양한 구매 플랜을 제공하며 평가를 위해 무료 체험 및 30일 임시 라이선스를 제공합니다.

{{% alert color="info" title="Note" %}}
제품을 평가하고, 적절히 라이선스를 적용하며, 구매하는 방법을 안내하는 일반 정책 및 관행이 다수 있습니다. 해당 내용은 ["구매 정책 및 FAQ"](https://purchase.aspose.com/policies) 섹션에서 확인할 수 있습니다.
{{% /alert %}}

## **Aspose.Slides 평가**
Aspose.Slides를 쉽게 다운로드하여 평가할 수 있습니다. 평가용 패키지는 구매한 패키지와 동일합니다. 평가 버전은 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용된 상태가 됩니다.

## **평가 버전 제한**
Aspose.Slides의 평가 버전(라이선스 미지정)은 전체 제품 기능을 제공하지만 두 가지 제한이 있습니다:

* 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크 텍스트 상자를 추가합니다.
* 프레젠테이션에서 코드를 통해 읽어오는 텍스트가 다섯 글자를 초과하면 처음 다섯 글자만 반환되고 뒤에 `... text has been truncated due to evaluation version limitation.` 가 붙습니다. 다섯 글자 이하의 텍스트는 그대로 반환되며, 코드가 쓰는 텍스트는 전체가 저장됩니다.

{{% alert color="info" title="Note" %}}
평가 버전 제한 없이 Aspose.Slides를 테스트하려면 **30 Day Temporary License**를 요청할 수 있습니다. 자세한 내용은 [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) 를 참고하세요.
{{% /alert %}}

## **라이선스에 대하여**
Aspose.Slides for Node.js via Java의 [download page](https://releases.aspose.com/slides/nodejs-java/)에서 평가 버전을 쉽게 다운로드할 수 있습니다. 평가 버전은 라이선스된 버전과 동일한 기능을 제공하지만 위에서 설명한 제한이 있습니다. 또한 라이선스를 구매하고 몇 줄의 코드를 추가하면 평가 버전이 라이선스된 상태가 됩니다.

라이선스는 제품 이름, 라이선스를 부여받은 개발자 수, 구독 만료 날짜 등과 같은 세부 정보를 포함한 일반 텍스트 XML 파일입니다. 파일은 디지털 서명되어 있으므로 수정하면 안 됩니다. 파일 내용에 실수로 줄 바꿈을 추가하는 것만으로도 라이선스가 무효화됩니다.

평가 버전의 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 라이선스를 설정하면 됩니다.

{{% alert color="info" title="Note" %}}
다음의 [Metered Licensing](/slides/ko/nodejs-java/metered-licensing/)을 확인하고 싶을 수 있습니다.
{{% /alert %}}

## **구매한 라이선스**

구매 후에는 라이선스 파일이나 스트림을 적용해야 합니다.

{{% alert color="info" title="Note" %}}
라이선스를 설정해야 합니다:
* 프로세스당 한 번만
* 다른 Aspose.Slides 클래스를 사용하기 전에
{{% /alert %}}

{{% alert color="info" title="Note" %}}
가격 정보는 ["Pricing Information"](https://purchase.aspose.com/pricing/slides/family) 페이지에서 확인할 수 있습니다.
{{% /alert %}}

### **Node.js via Java에서 Aspose.Slides 라이선스 설정**

라이선스는 다음 위치에서 적용할 수 있습니다:

* 명시적인 경로
* 스트림
* Metered License로 – 새로운 라이선스 메커니즘

{{% alert color="info" title="Note" %}}
**setLicense** 메서드를 사용하여 구성 요소에 라이선스를 적용합니다.

**setLicense**를 여러 번 호출해도 문제가 되지는 않지만, 리소스(프로세서)를 낭비하게 됩니다.
{{% /alert %}}

#### **파일을 사용한 라이선스 적용**

이 코드 스니펫은 라이선스 파일을 설정하는 데 사용됩니다:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides는 Node.js를 계속 실행 상태로 유지하는 Java 가상 머신에서 동작하므로 프로세스를 명시적으로 종료하십시오.
process.exit(0);
```

setLicense 메서드를 호출할 때 라이선스 이름은 라이선스 파일 이름과 동일해야 합니다. 예를 들어 라이선스 파일 이름을 "Aspose.Slides.lic.xml"로 변경할 수 있습니다. 그런 다음 코드에서 새로운 라이선스 이름(Aspose.Slides.lic.xml)을 setLicense 메서드에 전달해야 합니다. 파일이 없거나 유효한 라이선스를 포함하지 않으면 [setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/)가 예외를 발생시켜 스크립트가 오류와 함께 종료됩니다.

#### **스트림에서 라이선스 적용**

스트림에서 라이선스를 적용하려면 [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/) 객체와 읽기 가능한 스트림을 정적 [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) 메서드에 전달합니다. 스트림은 비동기적으로 읽히며, 스트림에 유효한 라이선스가 없을 경우 콜백에 오류가 전달됩니다:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides는 Node.js를 계속 실행 상태로 유지하는 Java 가상 머신에서 동작하므로 프로세스를 명시적으로 종료하십시오.
    process.exit(0);
});
```

스트림 전체를 읽은 직후, 콜백이 실행되기 바로 전에 라이선스가 적용되므로 콜백 내에서 다른 Aspose.Slides 작업을 시작하십시오.

두 샘플 모두 작업이 끝나면 `process.exit(0)`을 호출합니다. 이는 Aspose.Slides를 실행하는 Java 가상 머신이 Node.js를 계속 실행 상태로 유지하기 때문입니다. 애플리케이션에서는 프로세스를 종료하지 말고 Aspose.Slides 코드를 계속 진행하십시오.

## **FAQ**

### 완전히 오프라인 환경(인터넷 연결 없음)에서도 라이선스를 적용할 수 있습니까?
예. 라이선스 검증은 라이선스 파일을 사용하여 로컬에서 수행되며, 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 됩니까? 라이브러리가 작동을 멈출까요?
아니오. 라이선스는 영구적이며, 구독 종료일 이전에 출시된 버전은 계속 사용할 수 있습니다. 다만 갱신하지 않는 한 최신 릴리스를 사용할 수 없습니다.