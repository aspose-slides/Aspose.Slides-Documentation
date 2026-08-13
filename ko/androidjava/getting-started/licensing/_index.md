---
title: 라이선스
type: docs
weight: 90
url: /ko/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 라이선스를 적용하고 관리하며 문제를 해결합니다. 라이선스 가이드를 통해 전체 기능에 대한 지속적인 액세스를 보장합니다."
---
## **개요**

Aspose.Slides는 평가 모드 또는 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스 버전과 동일한 기능을 제공하지만 프레젠테이션을 열거나 저장할 때 평가 워터마크가 추가되고 텍스트 추출이 한 슬라이드로 제한됩니다.

이 문서에서는 Aspose.Slides의 라이선스 작동 방식과 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. 라이선스는 `License` 클래스를 사용하여 파일, 스트림 또는 임베디드 리소스에서 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 검증하는 방법도 보여줍니다.

## **Aspose.Slides 평가**

{{% alert color="info" %}} 
Aspose.Slides for Android via Java의 평가 버전을 [download page](https://releases.aspose.com/slides/ko/androidjava/)에서 다운로드할 수 있습니다. 평가 버전은 제품의 라이선스 버전과 동일한 기능을 제공합니다. 평가 패키지는 구매한 패키지와 동일합니다. 평가 버전은 몇 줄의 코드를 추가하여 라이선스를 적용하면 정상적인 라이선스 버전이 됩니다(라이선스 적용).

**Aspose.Slides** 평가가 만족스럽다면 [purchase a license](https://purchase.aspose.com/buy) 페이지에서 라이선스를 구매할 수 있습니다. 다양한 구독 유형을 확인해 보시기 바랍니다. 문의 사항이 있으면 Aspose 영업 팀에 연락하십시오.

모든 Aspose 라이선스에는 구독 기간 동안 신규 버전 또는 패치에 대한 무료 업그레이드가 포함된 1년 구독이 제공됩니다. 라이선스 제품(또는 평가 버전) 사용자는 무료이며 무제한 기술 지원을 받을 수 있습니다.
{{% /alert %}} 

**평가 버전 제한 사항**

* Aspose.Slides 평가 버전(라이선스가 지정되지 않은 경우)은 전체 제품 기능을 제공하지만 문서를 열거나 저장할 때 문서 상단에 평가 워터마크를 삽입합니다. 
* 프레젠테이션 슬라이드에서 텍스트를 추출할 경우 한 슬라이드만 추출할 수 있습니다.

{{% alert color="info" %}} 
제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [How to get a Temporary License](https://purchase.aspose.com/temporary-license) 페이지를 확인하십시오.
{{% /alert %}}

## **Aspose.Slides 라이선스**

* 평가 버전은 라이선스를 구매하고 몇 줄의 코드를 추가하여 라이선스를 적용하면 정식 라이선스로 전환됩니다.
* 라이선스는 제품명, 라이선스 대상 개발자 수, 구독 만료일 등과 같은 세부 정보를 포함하는 일반 텍스트 XML 파일입니다. 
* 라이선스 파일은 디지털 서명되어 있으므로 파일을 수정해서는 안 됩니다. 파일 내용에 한 줄의 개행이라도 추가하면 무효화됩니다.
* Aspose.Slides for Android via Java은 일반적으로 다음 위치에서 라이선스를 찾습니다.
  * 명시적인 경로
  * Aspose.Slides.jar가 들어 있는 폴더
* 평가 버전과 관련된 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 라이선스를 설정하면 됩니다.

## **라이선스 적용**

라이선스는 **파일** 또는 **스트림**에서 로드할 수 있습니다.

{{% alert color="info" %}}
Aspose.Slides는 라이선스 작업을 위해 [License](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/license/) 클래스를 제공합니다.
{{% /alert %}} 

{{% alert color="warning" %}}
새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이러한 라이선스를 인식하지 못합니다.
{{% /alert %}}

### **파일**

가장 쉬운 라이선스 설정 방법은 라이선스 파일을 Aspose.Slides.jar가 들어 있는 폴더나 애플리케이션의 jar에 배치하는 것입니다.

다음 Java 코드가 라이선스 파일을 설정하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 라이선스 파일 경로를 설정합니다
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 
라이선스 파일을 다른 디렉터리에 배치한 경우, [SetLicense](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 메서드를 호출할 때 지정한 명시적인 경로 끝에 있는 라이선스 파일 이름이 실제 라이선스 파일 이름과 동일해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.Android.via.Java.lic.xml*로 바꿀 수 있습니다. 그런 다음 코드에서 [SetLicense](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 메서드에 *Aspose.Slides.Android.via.Java.lic.xml*로 끝나는 파일 경로를 전달해야 합니다.
{{% /alert %}}

### **스트림**

스트림에서 라이선스를 로드할 수도 있습니다. 다음 Java 코드가 스트림에서 라이선스를 적용하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 스트림을 통해 라이선스를 설정합니다
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **라이선스 검증**

라이선스가 올바르게 설정되었는지 확인하려면 검증할 수 있습니다. 다음 Java 코드가 라이선스를 검증하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **스레드 안전성**

{{% alert title="Note" color="warning" %}} 
[SetLicense](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 메서드는 스레드 안전하지 않습니다. 여러 스레드에서 동시에 호출해야 하는 경우 잠금과 같은 동기화 프리미티브를 사용하여 문제를 방지하는 것이 좋습니다. 
{{% /alert %}}

## **FAQ**

### 라이선스를 완전히 오프라인 환경(인터넷 접속 없음)에서 적용할 수 있나요?

예. 라이선스 검증은 로컬에서 라이선스 파일을 사용해 수행되므로 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아닙니다. 라이선스는 영구적이며 구독 종료일 이전에 릴리스된 버전은 계속 사용할 수 있습니다. 다만 구독을 갱신하지 않으면 최신 릴리스는 사용할 수 없습니다.