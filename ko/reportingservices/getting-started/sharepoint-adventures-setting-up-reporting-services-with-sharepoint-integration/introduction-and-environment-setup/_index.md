---
title: 소개 및 환경 설정
type: docs
weight: 10
url: /ko/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

과거에 Aspose.Slides를 Reporting Services와 SharePoint에 통합하는 것에 대한 문의가 있었습니다. 이 문서에서는 SharePoint 2010에 초점을 맞춥니다. 이미 SharePoint Farm 환경이 설정되어 있다고 가정합니다. 이 문서에서 따라 할 예제는 전체 SharePoint Cloud를 기반으로 하지만, 단계는 SharePoint Foundation Server에서도 유사합니다. 진행하기 전에 참고할 수 있는 주요 문서를 살펴보겠습니다:

- [Reporting Services와 SharePoint 기술 통합 개요](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [SharePoint 2010 통합을 위한 Reporting Services 구성](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **환경 설정**
구성은 **4대 서버**로 이루어집니다. 여기에는 **Domain Controller**, **SQL Server**, **SharePoint Server**, 그리고 **Reporting Services**용 서버가 포함됩니다. SharePoint와 Reporting Services를 동일한 서버에 배치할 수도 있습니다.