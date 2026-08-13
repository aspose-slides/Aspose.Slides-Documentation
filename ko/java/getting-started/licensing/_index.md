---
title: 라이선스
type: docs
weight: 90
url: /ko/java/licensing/
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
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 라이선스를 적용하고 관리하며 문제를 해결합니다. 단계별 라이선스 가이드를 통해 전체 기능에 중단 없는 접근을 보장합니다."
---
## **개요**

Aspose.Slides는 평가 모드나 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스 버전과 동일한 기능을 제공하지만 프레젠테이션을 열거나 저장할 때 평가 워터마크가 삽입되고 텍스트 추출이 한 슬라이드로 제한됩니다.

이 문서에서는 Aspose.Slides에서 라이선스가 어떻게 작동하는지와 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. 라이선스는 `License` 클래스를 사용하여 파일, 스트림 또는 포함된 리소스에서 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 확인하는 방법도 보여줍니다.

## **Aspose.Slides 평가**

{{% alert color="info" %}} 

**Aspose.Slides for Java**의 평가 버전은 [다운로드 페이지](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)에서 내려받을 수 있습니다. 평가 버전은 제품의 라이선스 버전과 동일한 기능을 제공합니다. 평가 패키지는 구매한 패키지와 동일합니다. 코드 몇 줄을 추가하여 라이선스를 적용하면 평가 버전이 라이선스 버전으로 전환됩니다.

**Aspose.Slides** 평가가 만족스러우면 [라이선스 구매](https://purchase.aspose.com/buy)를 진행하십시오. 다양한 구독 유형을 확인해 보시기 바랍니다. 질문이 있으면 Aspose 영업팀에 문의하십시오.

모든 Aspose 라이선스에는 구독 기간 동안 새로운 버전이나 수정 사항에 대한 무료 업그레이드가 포함된 1년 구독이 제공됩니다. 라이선스 제품(또는 평가 버전) 사용자는 무료이면서 무제한 기술 지원을 받을 수 있습니다.

{{% /alert %}} 

**평가 버전 제한 사항**

* 라이선스가 지정되지 않은 Aspose.Slides 평가 버전은 전체 제품 기능을 제공하지만, 열기 및 저장 작업 시 문서 상단에 평가 워터마크가 삽입됩니다. 
* 프레젠테이션 슬라이드에서 텍스트를 추출할 경우 한 슬라이드로 제한됩니다.

{{% alert color="info" %}} 

제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스 받는 방법](https://purchase.aspose.com/temporary-license) 페이지를 참고하십시오.

{{% /alert %}}

## **Aspose.Slides 라이선싱**

* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가하면 라이선스가 적용됩니다.
* 라이선스는 제품명, 라이선스 대상 개발자 수, 구독 만료 날짜 등 세부 정보를 포함하는 일반 텍스트 XML 파일입니다. 
* 라이선스 파일은 디지털 서명되어 있으므로 파일을 수정해서는 안 됩니다. 파일 내용에 한 줄 공백이라도 추가하면 무효화됩니다.
* Aspose.Slides for Java는 일반적으로 다음 위치에서 라이선스를 검색합니다:
  * 명시적인 경로
  * Aspose.Slides.jar가 포함된 폴더
* 평가 버전의 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 라이선스를 설정하면 됩니다.

{{% alert color="info" %}} 

[Metered Licensing](/slides/ko/java/metered-licensing/)을 확인해 보십시오.

{{% /alert %}} 


## **라이선스 적용**

라이선스는 **파일** 또는 **스트림**에서 로드할 수 있습니다.

{{% alert color="info" %}}

Aspose.Slides는 라이선싱 작업을 위해 [License](https://reference.aspose.com/slides/ko/java/com.aspose.slides/License) 클래스를 제공합니다.

{{% /alert %}} 

{{% alert color="warning" %}}

새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하며 이 라이선스를 인식하지 못합니다.

{{% /alert %}}

### **파일**

라이선스 파일을 Aspose.Slides.jar가 포함된 폴더나 애플리케이션 jar에 두면 가장 간단하게 라이선스를 설정할 수 있습니다.

다음 Java 코드는 라이선스 파일을 설정하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 라이선스 파일 경로를 설정합니다
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

라이선스 파일을 다른 디렉터리에 두는 경우, [SetLicense](https://reference.aspose.com/slides/ko/java/com.aspose.slides/License#setLicense-java.lang.String-) 메서드를 호출할 때 지정한 명시적 경로 끝에 있는 라이선스 파일 이름이 실제 라이선스 파일 이름과 동일해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.Java.lic.xml* 로 변경할 수 있습니다. 이 경우 코드에서 [SetLicense](https://reference.aspose.com/slides/ko/java/com.aspose.slides/License#setLicense-java.lang.String-) 메서드에 *Aspose.Slides.Java.lic.xml* 로 끝나는 파일 경로를 전달해야 합니다.

{{% /alert %}}

### **스트림**

스트림에서 라이선스를 로드할 수 있습니다. 다음 Java 코드는 스트림에서 라이선스를 적용하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 스트림을 통해 라이선스를 설정합니다
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

PHP를 통해 Java의 Aspose.Slides를 사용하는 경우 PHP/Java 브리지를 통해 라이선스를 설정할 수 있습니다. 이 브리지는 PHP 구문에서 Java 클래스를 사용할 수 있게 해 줍니다. 자세한 내용은 [PHP의 라이선스](/slides/ko/php-java/licensing/)를 참고하십시오.

## **라이선스 검증**

라이선스가 정상적으로 설정되었는지 확인하려면 검증을 수행할 수 있습니다. 다음 Java 코드는 라이선스를 검증하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **스레드 안전성**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/ko/java/com.aspose.slides/License#setLicense-java.io.InputStream-) 메서드는 스레드 안전하지 않습니다. 여러 스레드에서 동시에 호출해야 하는 경우 동기화 프리미티브(예: lock)를 사용하여 문제를 방지하십시오. 

{{% /alert %}}

## **FAQ**

### 완전히 오프라인 환경(인터넷 접속 없음)에서도 라이선스를 적용할 수 있나요?

네. 라이선스 검증은 로컬 라이선스 파일을 사용해 수행되며 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아닙니다. 라이선스는 영구적이며, 구독 종료일 이전에 릴리스된 버전은 계속 사용할 수 있습니다. 다만 구독을 갱신하지 않으면 최신 릴리스를 사용할 수 없습니다.