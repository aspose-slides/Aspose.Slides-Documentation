---
title: 소개 및 환경 설정
type: docs
weight: 10
url: /ko/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}}

과거에 Aspose.Slides와 Reporting Services를 SharePoint와 통합하는 것에 대한 문의가 있었습니다. 이 문서에서는 SharePoint 2010에 초점을 맞춥니다. 이미 SharePoint Farm 환경이 설정되어 있다고 가정합니다. 이 문서에서 따라 할 예제는 완전한 SharePoint 클라우드이지만, 단계는 SharePoint Foundation Server에서도 유사합니다. 진행하기 전에, 참고할 수 있는 주요 문서를 살펴보겠습니다:

- [Reporting Services 및 SharePoint 기술 통합 개요](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [SharePoint 2010 통합을 위한 Reporting Services 구성](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **환경 설정**
우리가 구성할 환경은 **4대 서버**로 이루어집니다. 여기에는 **도메인 컨트롤러**, **SQL Server**, **SharePoint Server** 및 **Reporting Services**용 서버가 포함됩니다. SharePoint와 Reporting Services를 같은 서버에 배치할 수도 있습니다.