---
title: Wprowadzenie &amp; konfiguracja środowiska
type: docs
weight: 10
url: /pl/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 

W przeszłości pojawiały się zapytania dotyczące integracji Aspose.Slides dla Reporting Services z SharePoint. W tym artykule skupimy się na SharePoint 2010. Zakłada się, że środowisko farmy SharePoint jest już skonfigurowane. Przykłady, które będziemy omawiać w tym artykule, dotyczą pełnej chmury SharePoint, ale kroki będą podobne w przypadku serwera SharePoint Foundation. Zanim przejdziemy dalej, rozpocznijmy od kluczowej dokumentacji, którą możesz wykorzystać jako odniesienie przy realizacji tego zadania:

- [Przegląd integracji Reporting Services i technologii SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Konfigurowanie Reporting Services dla integracji z SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Konfiguracja środowiska**
Konfiguracja, którą będziemy mieć, składa się z **4 serwerów**. Obejmuje to **Domain Controller**, **SQL Server**, **SharePoint Server** oraz serwer **Reporting Services**. Możesz zdecydować się na uruchomienie SharePoint i Reporting Services na tym samym serwerze.