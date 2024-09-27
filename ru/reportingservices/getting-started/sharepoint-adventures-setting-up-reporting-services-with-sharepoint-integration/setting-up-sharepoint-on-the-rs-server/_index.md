---  
title: Настройка SharePoint на сервере RS  
type: docs  
weight: 40  
url: /ru/reportingservices/setting-up-sharepoint-on-the-rs-server/  
---  

{{% alert color="primary" %}}  

Итак, нам нужно сделать то же, что мы сделали для SharePoint WFE. Первое, что нужно сделать, это пройти через установку предварительных условий, а после этого запустить установку SharePoint.  

Для установки мы выбираем Server Farm и полную установку, чтобы соответствовать моему SharePoint Box, так как мы не хотим установить SharePoint как отдельное приложение.  

{{% /alert %}}  
### **Конфигурация SharePoint**  
В мастере конфигурации SharePoint мы хотим подключиться к существующей ферме.  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)  

**Рисунок 13**: Мастер конфигурации SharePoint  

Затем мы укажем на базу данных **SharePoint_Config**, которую использует наша ферма. Если вы не знаете, где это, вы можете узнать через Центр администрирования через **Системные настройки -> Управление серверами в этой ферме.**  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)  

**Рисунок 14**: Мастер конфигурации SharePoint  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)  

**Рисунок 15**: Мастер конфигурации SharePoint  

Когда мастер завершит свою работу, это всё, что нам нужно сделать на сервере отчетов на данный момент. Вернувшись к URL-адресу ReportServer, мы увидим другую ошибку, но это связано с тем, что мы не настроили его через Центрального администратора.  

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)  

**Рисунок 16**: Ошибка сервера отчетов  