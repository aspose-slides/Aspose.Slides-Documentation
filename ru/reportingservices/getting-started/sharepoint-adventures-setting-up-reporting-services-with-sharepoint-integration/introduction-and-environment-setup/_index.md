---
title: Введение и настройка окружения
type: docs
weight: 10
url: /reportingservices/introduction-and-environment-setup/
---

{{% alert color="primary" %}} 

В прошлом были запросы относительно интеграции Aspose.Slides для Reporting Services с SharePoint. В этой статье мы сосредоточимся на SharePoint 2010. Предполагается, что у вас уже настроено окружение SharePoint Farm. Примеры, которые мы будем рассматривать в этой статье, будут основаны на полной облачной версии SharePoint, но шаги будут аналогичны для сервера SharePoint Foundation. Прежде чем мы продолжим, давайте начнем с нескольких ключевых документов, которые вы можете использовать в качестве справки, когда будете это делать: 

- [Обзор интеграции технологий Reporting Services и SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Настройка Reporting Services для интеграции с SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Настройка окружения**
Настройка, которую мы будем использовать, состоит из **4 серверов**. В неё входят **Контроллер домена**, **SQL Server**, **SharePoint Server** и сервер для **Reporting Services**. Вы можете выбрать размещение SharePoint и Reporting Services на одном сервере.