---
title: 왜 자동화가 안 되는가
type: docs
weight: 50
url: /ko/java/why-not-automation/
keywords:
- 자동화
- Microsoft Office
- 비교
- 보안
- 안정성
- 확장성
- 기능
- PowerPoint
- OpenDocument
- 프리젠테이션
- Java
- Aspose.Slides
description: "Office 자동화가 서버 및 서비스에 위험한 이유를 알아보고, Aspose.Slides가 PowerPoint와 OpenDocument에 대해 더 안전하고 빠른 프레젠테이션 처리를 제공하는 방법을 확인하십시오."
---
## **소개**

Aspose 구성 요소가 자동화에 비해 더 나은 대안인 몇 가지 이유가 있습니다. 주요 이유는 다음과 같습니다:

- 보안
- 안정성
- 확장성/속도
- 가격
- 기능

아래는 각 핵심 포인트에 대한 보다 자세한 설명입니다.

## **중요한 질문들**

Aspose에서 자주 듣는 질문이 두 가지 있습니다:

- 제품을 실행하려면 Microsoft Office가 설치되어 있어야 합니까?

짧고 간단한 대답은 **아니오**입니다.

Aspose 구성 요소는 완전히 독립적이며 Microsoft Corporation과 연관되거나, Microsoft의 허가를 받았거나, Microsoft의 후원을 받았거나, 기타 방식으로 승인된 것이 아닙니다.

- Microsoft Office Automation 대신 Aspose 제품을 사용해야 하는 이유는 무엇입니까?

먼저, Aspose.Slides를 사용할 때 누릴 수 있는 많은 [이점](/slides/ko/java/product-overview/)이 있습니다.

둘째, Microsoft 자체가 소프트웨어 솔루션에서 Office Automation 사용을 강력히 **권장하지** 않습니다.

## **보안**

다음은 Microsoft 기사에서 직접 인용한 내용입니다:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 

Aspose 제품은 매우 안전합니다. Aspose 구성 요소는 중요한 시스템 자원에 잠재적인 위험을 초래하지 않습니다. 또한, 문서를 Aspose 구성 요소가 열 때 매크로가 자동으로 실행되지 않습니다. Aspose 구성 요소는 개발자가 Office 파일을 생성, 조작 및 저장하도록 설계되었습니다. Microsoft Office 패키지와 관련된 위험은 Aspose 구성 요소에 내재되어 있지 않습니다.

## **안정성**

다음은 Microsoft 기사에서 직접 인용한 내용입니다:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 

Aspose 구성 요소는 철저히 테스트되었으며 매우 안정적입니다. Aspose 구성 요소는 [Companies](https://about.aspose.com/customers)와 같은 기업에서 사용됩니다: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** 등등.

## **확장성/속도**

다음은 Microsoft 기사에서 직접 인용한 내용입니다:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 

Aspose 구성 요소는 높은 확장성을 제공하며 번개처럼 빠릅니다. Office 응용 프로그램은 수백·수천 명의 사용자가 동시에 사용할 수 있도록 설계되지 않았습니다. 그러나 Aspose 구성 요소는 바로 그 목적을 위해 설계되었습니다. 우리 구성 요소는 단일 서버에서 단일 애플리케이션을 구동하든, 로드 밸런싱된 웹 폼을 통해 기업 전체 애플리케이션을 구동하든 언제나 완벽히 작동합니다.

## **가격**

Microsoft Office Automation을 사용하는 경우, 애플리케이션을 실행하는 각 머신마다 Microsoft Office 사본을 구매해야 합니다. 애플리케이션이 Office 파일을 생성하거나 조작해야 하지만 사용자가 Microsoft Office를 보유할 필요가 없는 경우가 많이 있습니다. Aspose는 무제한 사용자에게 배포할 수 있는 매우 [Cost Effective](https://purchase.aspose.com/)하고 로열티 없는 재배포 라이선스를 제공하여 라이선스 걱정 없이 사용할 수 있도록 합니다.

웹 기반 애플리케이션을 만들 때 Microsoft Office Automation 구성 요소는 서버 측 솔루션용으로 가격이 매겨지거나 라이선스가 부여되지 않으므로, Microsoft Office 구성 요소를 활용하는 웹 애플리케이션을 배포할 수 있는 적절한 라이선스 솔루션이 없습니다. Aspose는 서버 기반 애플리케이션을 위한 매우 비용 효율적인 솔루션도 제공합니다.

## **기능**

Aspose 구성 요소는 Office 파일 관리에 필요한 모든 것을 제공하며 그 이상을 제공합니다. 개발자가 최소한의 작업으로 최고의 결과를 달성하도록 설계되었습니다. Office Automation과 달리 Aspose 구성 요소는 많은 강력하고 시간 절약 기능을 제공합니다. 예를 들어, [Aspose.Cells](https://products.aspose.com/cells/java/)는 개발자가 **DataTable** 또는 **DataView**의 데이터를 직접 Excel 파일에 가져올 수 있게 합니다. [Aspose.Words](https://products.aspose.com/words/java/)는 메일 병합 문서를 채우는 유사한 기능을 제공합니다. Aspose 제품군의 모든 [Component](https://products.aspose.com/total/java/)는 고유하고 강력한 기능을 제공합니다.

Aspose 구성 요소(또는 [Aspose.Total](https://products.aspose.com/total/java/)와 같은 구성 요소 스위트)를 구매하면 개발 팀에 접근할 수 있다는 장점이 있습니다. 우리 개발 팀은 귀사의 필요가 다른 기업에도 적용될 가능성이 높다고 판단합니다. 모든 기능 요청을 수용할 수는 없지만, 팀은 지원을 제공할 때 매우 열린 마음과 융통성을 유지하려고 노력합니다. 이러한 마인드셋이 Aspose 구성 요소를 현재와 같이 강력하게 만든 원동력입니다. Office Automation 객체에서 추가 기능이 필요하다면, 해당 기능이 추가될 가능성은 매우 낮습니다.

## **결론**
{{% alert color="info" %}} 

이 문서는 Aspose 구성 요소가 Office Automation보다 더 나은 선택인 주요 이유들을 다루었지만, 실제로는 더 많은 이유가 존재합니다. 이 글은 핵심 포인트만을 중심으로 설명했습니다. 모든 Aspose 구성 요소는 위험이 없고 의무가 없는 [Evaluation Version](https://downloads.aspose.com/slides/ko/java)를 제공합니다. 평가판을 활용하여 Aspose가 귀하의 애플리케이션에 어떤 가치를 제공할 수 있는지 직접 확인해 보시기 바랍니다. 

{{% /alert %}}