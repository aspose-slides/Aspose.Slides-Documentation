---
title: Giriş ve Ortam Kurulumu
type: docs
weight: 10
url: /tr/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}}

Geçmişte Aspose.Slides for Reporting Services'ın SharePoint ile entegrasyonu hakkında sorular geldi. Bu makalede SharePoint 2010 üzerine odaklanacağız. Bir SharePoint Farm ortamının zaten kurulu olduğu varsayılmaktadır. Bu makalede takip edeceğimiz örnekler tam bir SharePoint Bulutu içindir, ancak adımlar SharePoint Foundation Server için de benzerdir. İlerlemeye başlamadan önce, bu konuda referans olarak kullanabileceğiniz ana belgelerle başlayalım:

- [Overview of Reporting Services and SharePoint Technology Integration](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Configuring Reporting Services for SharePoint 2010 Integration](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **Ortam Kurulumu**
Kurulumumuz **4 sunucudan** oluşmaktadır. Bunlar bir **Domain Controller**, bir **SQL Server**, bir **SharePoint Server** ve **Reporting Services** için bir sunucu içerir. SharePoint ve Reporting Services'ı aynı sunucuda tutmayı da tercih edebilirsiniz.