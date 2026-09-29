---
title: 자동화가 아닌 이유
type: docs
weight: 170
url: /ko/java/why-not-automation/
keywords:
- 자동화
- 마이크로소프트 오피스
- 비교
- 보안
- 안정성
- 확장성
- 기능
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "서버와 서비스에 Office 자동화가 위험한 이유를 알아보고, Aspose.Slides가 PowerPoint 및 OpenDocument에 대해 더 안전하고 빠른 프레젠테이션 처리를 제공하는 방식을 확인하세요."
---
## **소개**

자동화보다 Aspose 구성 요소가 더 나은 대안인 몇 가지 이유가 있습니다. 주요 이유는 다음과 같습니다:

- 보안
- 안정성
- 확장성/속도
- 가격
- 기능

아래는 각 핵심 포인트에 대한 자세한 설명입니다.

## **중요한 질문**

우리는 Aspose에서 자주 듣는 질문 두 가지가 있습니다:

- 당신의 제품은 실행하려면 Microsoft Office가 설치되어 있어야 합니까?

짧고 간단한 답은 **아니오**.

Aspose 구성 요소는 완전히 독립적이며 Microsoft Corporation과 제휴, 승인, 후원 혹은 기타 방식으로 승인되지 않았습니다.

- 왜 Microsoft Office 자동화 대신 Aspose 제품을 사용해야 합니까?

먼저, Aspose.Slides를 사용할 때 누릴 수 있는 이점이 많이 있습니다[Aspose.Slides를 사용할 때 누릴 수 있는 이점](/slides/ko/java/product-overview/).

둘째, Microsoft 자체가 소프트웨어 솔루션에서 Office 자동화를 **사용하지 말 것을 강력히 권고**합니다.

## **보안**

다음은 Microsoft 기사에서 직접 인용한 내용입니다:

> *"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Aspose 제품은 매우 안전합니다. Aspose 구성 요소는 중요한 시스템 리소스에 잠재적인 위험을 초래하지 않습니다. 또한, 문서가 Aspose 구성 요소에 의해 열릴 때 매크로가 자동으로 실행되지 않습니다. Aspose 구성 요소는 개발자가 Office 파일을 만들고, 조작하고, 저장할 수 있도록 설계되었습니다. Microsoft Office 패키지와 관련된 위험은 Aspose 구성 요소에 내재되어 있지 않습니다.

## **안정성**

다음은 Microsoft 기사에서 직접 인용한 내용입니다:

> *"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Aspose 구성 요소는 철저히 테스트되었으며 매우 안정적입니다. Aspose 구성 요소는 **Bank of America**와 같은 [기업](https://about.aspose.com/customers/)를 포함한 다수의 기업에서 사용됩니다.

## **확장성/속도**

다음은 Microsoft 기사에서 직접 인용한 내용입니다:

> *"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*"

Aspose 구성 요소는 높은 확장성을 가지고 번개처럼 빠릅니다. Office 애플리케이션은 수백·수천 명의 사용자가 동시에 사용하도록 설계되지 않았습니다. 그러나 Aspose 구성 요소는 바로 이를 위해 설계되었습니다. 우리의 구성 요소는 단일 서버에서 단일 애플리케이션을 구동하든, 로드 밸런싱된 웹 서버 팜에서 엔터프라이즈 전체 애플리케이션을 구동하든 완벽하게 작동합니다.

## **가격**

애플리케이션이 Microsoft Office 자동화를 이용하면, 해당 애플리케이션이 실행되는 각 컴퓨터에 Microsoft Office 사본을 구매해야 합니다. 종종 애플리케이션이 Office 파일을 생성하거나 조작해야 하지만 사용자가 Microsoft Office를 가지고 있을 필요는 없습니다. Aspose는 매우 [비용 효율적](https://purchase.aspose.com/)하고 로열티 없는 재배포 라이선스를 제공하여 라이선스 걱정 없이 무제한 사용자에게 배포할 수 있습니다.

웹 기반 애플리케이션을 만들 때 Microsoft Office 자동화 구성 요소는 서버 측 솔루션용으로 가격이 책정되거나 라이선스가 부여되지 않음을 아는 것이 중요합니다. 따라서 Microsoft Office 구성 요소를 이용하는 웹 애플리케이션을 배포하기 위한 적절한 라이선스 솔루션이 없습니다. Aspose는 서버 기반 애플리케이션을 위한 매우 비용 효율적인 솔루션도 제공합니다.

## **기능**

Aspose 구성 요소는 Office 파일 관리를 위한 모든 것과 그 이상을 제공합니다. 개발자가 최소한의 작업으로 최대의 결과를 얻을 수 있도록 설계되었습니다. Office 자동화와 달리 Aspose 구성 요소는 강력하고 시간을 절약해 주는 많은 기능을 제공합니다. 예를 들어, [Aspose.Cells](https://products.aspose.com/cells/java/)는 개발자가 **DataTable** 또는 **DataView**에서 데이터를 직접 Excel 파일로 가져올 수 있게 해줍니다. [Aspose.Words](https://products.aspose.com/words/java/)는 유사한 기능을 제공하여 개발자가 Word(메일 병합) 문서를 채울 수 있게 합니다. Aspose 제품군의 [Every Component](https://products.aspose.com/total/java/)는 각각 고유하고 강력한 기능 세트를 제공합니다.

Aspose 구성 요소(또는 [Aspose.Total](https://products.aspose.com/total/java/)과 같은 구성 요소 제품군)를 구매할 때 가장 좋은 점은 저희 개발 팀에 접근할 수 있다는 것입니다. 저희 개발 팀은 귀사가 필요로 하는 기능이 있다면, 다른 기업도 필요로 할 가능성이 높다는 것을 인식하고 있습니다. 모든 기능 요청을 추가할 수는 없지만, 저희 팀은 지원을 제공할 때 매우 개방적이고 유연하게 노력합니다. 이러한 사고방식이 Aspose 구성 요소를 현재와 같이 강력하게 만든 요인입니다. Office 자동화 객체에서 필요한 추가 기능이 있다면, 그것이 추가될 가능성은 매우 매우 낮습니다.

## **결론**
{{% alert color="info" title="Note" %}}

이 문서는 Aspose 구성 요소가 Office 자동화보다 더 나은 선택인 주요 이유들을 많이 다루었지만, 그 외에도 훨씬 많은 이유가 있습니다. 이 문서는 가장 핵심적인 포인트만을 다루고 있습니다. 모든 Aspose 구성 요소는 위험이 없고 의무가 없는 [평가 버전](https://releases.aspose.com/slides/ko/java/)을 제공합니다. 귀하의 애플리케이션에서 Aspose가 무엇을 할 수 있는지 더 잘 확인할 수 있도록 이 평가판을 활용하시기 바랍니다.

{{% /alert %}}