---
title: 설치 전제 조건
type: docs
weight: 20
url: /ko/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 
설치를 진행하기 전에 충족해야 할 전제 조건이 있습니다. 
{{% /alert %}} 
## **SharePoint용 Reporting Services Add-In**
**Reporting Services Add-In for SharePoint** 은 통합이 올바르게 작동하도록 하는 핵심 구성 요소 중 하나입니다. 이 추가 기능은 SharePoint 팜에 있는 **Web Front Ends (WFE)** 중 어느 서버든 중앙 관리 서버와 함께 설치해야 합니다. SQL 2008 R2 및 SharePoint 2010의 새로운 변경 사항 중 하나는 2008 R2 Add‑In이 이제 SharePoint 설치의 사전 요구 사항이 된다는 것입니다. 이는 SharePoint를 설치할 때 RS Add‑In이 자동으로 배포된다는 의미입니다. 아래 그림에 표시되고 강조된 바와 같습니다. 이는 실제로 SP 2007 및 RS 2008을 설치할 때 발생했던 많은 문제를 방지합니다. 

![todo:image_alt_text](installation-prerequisites_1.png)

**Figure 1**: SharePoint용 Reporting Services Add‑In 
## **SharePoint 인증**
RS 통합 부분으로 들어가기 전에 중요한 점은 SharePoint 팜에서 **Site** 를 어떻게 설정하느냐입니다. 보다 구체적으로는 사이트의 인증 방식을 **Classic** 혹은 **Claims** 로 구성하는 것입니다. 이 선택은 초기에 매우 중요합니다. 한 번 설정하면 **변경** **한 번** 할 수 없다고 생각합니다. 만약 변경이 가능하더라도 간단한 과정이 아닙니다. 

{{% alert color="primary" %}} 
Reporting Services 2008 R2는 Claims를 지원하지 않습니다. 
{{% /alert %}} 

SharePoint 사이트를 **Claims** 로 선택하더라도 Reporting Services 자체는 Claims를 지원하지 않습니다. 이는 Reporting Services의 인증 방식에 영향을 미칩니다. 그렇다면 Reporting Services 관점에서의 차이는 무엇일까요? 이는 **사용자 자격 증명 전달** 여부에 달려 있습니다. 

***Classic***  - Kerberos를 사용할 수 있으며 사용자의 자격 증명을 백엔드 데이터소스로 전달할 수 있습니다(이를 위해 Kerberos가 필요합니다). 

***Claims***  - Claims 토큰이 사용되며 윈도우 토큰이 아닙니다. 이 시나리오에서는 RS가 항상 Trusted Authentication을 사용하고 SPUser 토큰에만 접근할 수 있습니다. 데이터 소스 내에 자격 증명을 저장해야 합니다. 

현재는 RS 설정에 집중하고자 합니다. 이 시점에서 SharePoint는 SharePoint Box에 설치되어 **port 80** 에 **Classic Auth Site** 로 설정되어 있습니다. 또한 RS 서버에는 **just installed Reporting Services** 를 방금 설치했으며 그게 전부입니다.