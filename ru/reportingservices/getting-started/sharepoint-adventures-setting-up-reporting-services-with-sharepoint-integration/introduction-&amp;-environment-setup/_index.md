---
title: Введение и настройка окружения
type: docs
weight: 10
url: /ru/reportingservices/introduction-&amp;-environment-setup/
---

{{% alert color="primary" %}} 

В прошлом возникали вопросы по интеграции Aspose.Slides для Reporting Services с SharePoint. В этой статье мы будем сосредоточены на SharePoint 2010. Предполагается, что у вас уже настроено окружение SharePoint Farm. Примеры, которые мы будем рассматривать в этой статье, будут основывать на полном облаке SharePoint, но шаги будут схожи для сервера SharePoint Foundation. Прежде чем мы продолжим, давайте начнем с некоторых ключевых документов, которые вы можете использовать в качестве справки при выполнении этого: 

- [Обзор интеграции Reporting Services и технологий SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Настройка Reporting Services для интеграции с SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Настройка окружения**
Настройка, которую мы будем использовать, состоит из **4 серверов**. Это включает **Контроллер домена**, **Сервер SQL**, **Сервер SharePoint** и сервер для **Reporting Services**. Вы можете решить разместить SharePoint и Reporting Services на одном сервере.