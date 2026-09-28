---
title: 자동화가 아닌 이유
type: docs
weight: 170
url: /ko/net/why-not-automation/
keywords:
- 자동화
- 마이크로소프트 오피스
- 비교
- 보안
- 안정성
- 확장성
- 기능
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "서버와 서비스에서 Office 자동화가 위험한 이유를 알아보고, Aspose.Slides가 PowerPoint와 OpenDocument에 대해 더 안전하고 빠른 프레젠테이션 처리를 제공하는 방법을 확인하세요."
---
## **소개**

Aspose 구성 요소가 자동화보다 더 나은 대안인 몇 가지 이유가 있습니다. 주요 이유는 다음과 같습니다:

- 보안
- 안정성
- 확장성/속도
- 가격
- 기능

아래는 각 핵심 포인트에 대한 자세한 설명입니다.

## **중요한 질문들**

Aspose에서 자주 듣는 질문 두 가지가 있습니다:

- 제품을 실행하려면 Microsoft Office가 설치되어 있어야 합니까?

짧고 간단한 답은 **아니오**입니다.

Aspose 구성 요소는 완전히 독립적이며 Microsoft Corporation과 제휴, 인증, 후원 또는 기타 방식으로 승인되지 않았습니다.

- Microsoft Office 자동화 대신 Aspose 제품을 사용해야 하는 이유는 무엇입니까?

첫째, Aspose.Slides를 사용할 때 누리는 이점이 많이 있습니다. [Aspose.Slides를 사용할 때 누리는 이점](/slides/ko/net/product-overview/).

둘째, Microsoft 자체가 소프트웨어 솔루션에서 Office 자동화 사용을 강력히 **반대**합니다.

## **보안**
The following is a direct quote from a Microsoft Article:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Aspose 제품은 매우 **안전**합니다. Aspose 구성 요소는 모든 ASP.NET 애플리케이션과 동일한 사용자 컨텍스트(ASPNET 사용자)에서 실행됩니다. 따라서 Aspose 구성 요소는 **위험**을 초래하지 않으며, 중요한 시스템 리소스를 소비하지도 않습니다. 또한 Aspose 구성 요소가 문서를 열 때 매크로가 자동으로 실행되지 않습니다. Aspose 구성 요소는 개발자가 Office 파일을 생성, 조작 및 저장할 수 있도록 설계되었습니다.

{{% alert color="info" title="Note" %}}
Microsoft Office 패키지와 관련된 위험은 Aspose 구성 요소에는 적용되지 않습니다.
{{% /alert %}}

## **안정성**
This text is a direct quote from the previously referenced Microsoft Article:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Aspose 구성 요소는 단일 DLL로 패키징되므로 사용자는 기능을 사용하기 위해 추가 파트나 부품을 설치할 필요가 없습니다. Aspose 구성 요소는 .NET 애플리케이션에서만 사용되며, 인간의 응답을 기다리도록 설계된 코드 부분이 없습니다.

{{% alert color="info" title="Note" %}}
Aspose 구성 요소는 철저히 테스트되어 매우 안정적인 것으로 확인되었습니다. Aspose 구성 요소는 **Bank of America**와 같은 [회사](https://about.aspose.com/customers/) 및 여러 산업 분야의 많은 선도 조직에서 사용됩니다.
{{% /alert %}}

## **확장성/속도**
The following is a direct quote from a Microsoft Article:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose 구성 요소는 믿을 수 없을 정도로 확장성이 뛰어나며 번개처럼 빠릅니다. Office 애플리케이션은 수백 또는 수천 명이 동시에 사용하도록 설계되지 않았지만, Aspose 구성 요소는 정확히 그 목적을 위해 설계되었습니다. 우리의 구성 요소는 진정한 .NET 솔루션입니다.

{{% alert color="info" title="Note" %}}
Aspose 구성 요소의 성능은 단일 서버(단일 애플리케이션 구동)나 로드 밸런싱된 웹 폼(전체 기업 애플리케이션 구동)에서 완벽합니다.
{{% /alert %}}

## **가격**
애플리케이션이 Microsoft Office 자동화를 사용할 경우, 해당 앱을 실행하는 각 컴퓨터마다 Microsoft Office 사본을 구매해야 합니다. 애플리케이션이 Office 파일을 생성하거나 조작해야 하는 경우가 많지만, 이 과정에 Microsoft Office는 필요하지 않습니다.

{{% alert color="info" title="Note" %}}
Aspose는 매우 [비용 효율적인](https://purchase.aspose.com/) 무권리 재배포 라이선스를 제공하여 라이선스 걱정 없이 무제한 사용자에게 배포할 수 있게 합니다.
{{% /alert %}}

웹 기반 애플리케이션을 만들 때, Microsoft Office 자동화 구성 요소는 서버 측 솔루션에 대해 가격이 매겨지지도 라이선스가 부여되지도 않음을 기억하는 것이 중요합니다. 따라서 Microsoft Office 구성 요소를 활용하는 웹 애플리케이션 배포에 적합한 라이선스 솔루션이 없습니다. 반면 Aspose는 서버 기반 애플리케이션에 대해 매우 [비용 효율적인](https://purchase.aspose.com/) 솔루션을 제공합니다.

## **기능**
Aspose 구성 요소는 Office 파일 관리에 필요한 모든 것과 그 이상을 제공합니다. 우리는 최소한의 노력으로 개발자가 가능한 최고의 결과를 달성하도록 돕는 철학에 따라 이를 설계했습니다.

{{% alert color="info" title="Note" %}}
Office 자동화와 달리 Aspose 구성 요소는 많은 강력하고 시간을 절약해 주는 기능을 제공합니다.
{{% /alert %}}

예를 들어, [Aspose.Cells](https://products.aspose.com/cells/net/)를 사용하면 개발자가 **DataTable** 또는 **DataView**의 데이터를 직접 Excel 파일로 가져올 수 있습니다. [Aspose.Words](https://products.aspose.com/words/net/)는 .NET 데이터 객체에서 직접 Word(메일 머지) 문서를 채울 수 있는 유사한 기능을 제공합니다. Aspose 제품군의 [모든 구성 요소](https://products.aspose.com/total/net/)는 각각 고유하고 강력한 기능을 제공합니다.

Aspose 구성 요소를 구매할 때 가장 좋은 점은 우리 개발 팀에 접근할 수 있다는 것입니다. 예를 들어, Office 자동화 객체를 사용하면서 특정 기능이 필요하더라도 해당 기능이 추가될 가능성은 매우 낮습니다. 그러나 Aspose 구성 요소는 상황이 다릅니다.

{{% alert color="info" title="Note" %}}
우리 개발 팀은 귀사가 필요로 하는 기능이 있다면 다른 기업도 동일한 기능을 필요로 할 가능성이 높다는 것을 이해합니다. 모든 요청된 기능을 구현할 수는 없다는 것을 알지만, 고객 피드백을 기반으로 가능한 한 많은 기능을 추가하려고 노력합니다.
{{% /alert %}}

우리 팀은 지원을 제공할 때 항상 열린 마음과 유연성을 가지고 있으며, 이것이 Aspose 구성 요소가 현재와 같이 강력하게 성장한 이유입니다.

## **결론**
{{% alert color="info" title="Note" %}}
이 문서에서는 Aspose 구성 요소가 Office 자동화보다 더 나은 선택인 몇 가지 핵심 포인트만 다루었지만, 실제로는 훨씬 더 많은 이점이 있습니다. 우리는 주요 장점 중 일부만 소개했습니다.

또한 모든 Aspose 제품 및 구성 요소는 위험이 없고 의무가 없는 [평가 버전](https://releases.aspose.com/slides/net/)을 제공합니다. 평가판을 활용하여 Aspose가 귀하의 애플리케이션이나 비즈니스에 어떤 도움을 줄 수 있는지 확인해 보시기 바랍니다.
{{% /alert %}}