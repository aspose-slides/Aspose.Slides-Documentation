---
title: Wprowadzenie i konfiguracja środowiska
type: docs
weight: 10
url: /pl/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}}

W przeszłości pojawiały się zapytania dotyczące integracji Aspose.Slides dla Reporting Services z SharePoint. W tym artykule skupimy się na SharePoint 2010. Zakłada się, że środowisko SharePoint Farm jest już skonfigurowane. Przykłady, które będziemy omawiać w tym artykule, będą dotyczyć pełnej chmury SharePoint, ale kroki będą podobne dla serwera SharePoint Foundation. Zanim przejdziemy dalej, zacznijmy od kilku kluczowych dokumentów, które możesz wykorzystać jako odniesienie:

- [Przegląd integracji Reporting Services i technologii SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Konfigurowanie Reporting Services dla integracji z SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **Konfiguracja środowiska**
Konfiguracja będzie składała się z **4 serwerów**. Obejmuje to **kontroler domeny**, **SQL Server**, **serwer SharePoint** oraz serwer **Reporting Services**. Możesz zdecydować się na umieszczenie SharePoint i Reporting Services na tej samej maszynie.