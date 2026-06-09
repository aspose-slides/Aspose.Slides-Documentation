---
title: Giriş &amp; Ortam Kurulumu
type: docs
weight: 10
url: /tr/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}}

Geçmişte Aspose.Slides for Reporting Services'in SharePoint ile entegrasyonu hakkında sorgular geldi. Bu makalede SharePoint 2010 üzerine odaklanacağız. Bir SharePoint Farm ortamının zaten kurulmuş olduğu varsayılmaktadır. Bu makalede izleyeceğimiz örnekler tam bir SharePoint Cloud içerecek, ancak adımlar SharePoint Foundation Server için de benzer olacaktır. Devam etmeden önce, bu işlemi yaparken referans alabileceğiniz bazı temel belgelerle başlayalım:

- [Reporting Services ve SharePoint Teknolojisi Entegrasyonu Genel Bakışı](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Reporting Services'ı SharePoint 2010 Entegrasyonu için yapılandırma](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **Ortam Kurulumu**
Kurulumumuz **4 sunucudan** oluşmaktadır. Bunlar bir **Domain Controller**, bir **SQL Server**, bir **SharePoint Server** ve **Reporting Services** için bir sunucuyu içerir. SharePoint ve Reporting Services'ı aynı kutuda tutmayı da tercih edebilirsiniz.