---
title: Configuración de SharePoint en el Servidor RS
type: docs
weight: 40
url: /es/reportingservices/setting-up-sharepoint-on-the-rs-server/
---

{{% alert color="primary" %}} 

Entonces, necesitamos hacer lo que hicimos para el WFE de SharePoint. Lo primero es pasar por la instalación de los requisitos previos y después iniciar la configuración de SharePoint. 

Para la configuración, elegimos Granja de Servidores y una instalación completa para coincidir con mi Box de SharePoint, ya que no queremos una instalación independiente para SharePoint. 

{{% /alert %}} 
### **Configuración de SharePoint**
En el Asistente de Configuración de SharePoint, queremos conectarnos a una granja existente. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figura 13**: Asistente de Configuración de SharePoint 

Luego, lo señalaremos a la base de datos **SharePoint_Config** que está utilizando nuestra granja. Si no sabes dónde está, puedes averiguarlo a través de Central Admin en **Configuraciones del Sistema -> Administrar Servidores en esta granja.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figura 14**: Asistente de Configuración de SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figura 15**: Asistente de Configuración de SharePoint 

Una vez que el asistente haya terminado, eso es todo lo que necesitamos hacer en la Caja del Servidor de Informes por ahora. Al volver a la URL del ReportServer, veremos otro error, pero eso es porque no lo hemos configurado a través del Administrador Central. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figura 16**: Error del Servidor de Informes