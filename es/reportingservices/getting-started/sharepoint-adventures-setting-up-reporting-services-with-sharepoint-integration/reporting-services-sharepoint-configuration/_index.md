---
title: Configuración de SharePoint de Reporting Services
type: docs
weight: 50
url: /es/reportingservices/reporting-services-sharepoint-configuration/
---

{{% alert color="primary" %}} 

Ahora que SharePoint está instalado y configurado en el servidor RS y RS está configurado a través del Administrador de Configuración de Reporting Services, podemos pasar a la configuración dentro de la Administración Central. RS 2008 R2 ha simplificado realmente este proceso. Solíamos tener un proceso de 3 pasos que tenías que realizar para que esto funcionara. Ahora solo tenemos un paso. 

Queremos ir al sitio web del Administrador Central y luego a la Configuración General de Aplicaciones. Hacia la parte inferior veremos Reporting Services. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)

**Figura 17**: Configuración de SharePoint 

{{% alert color="primary" %}} 

Haz clic en " **Integración de Reporting Services** ". 

{{% /alert %}} 
## **URL del Servicio Web**
Proporcionaremos la URL para el Servidor de Informes que encontramos en el Administrador de Configuración de Reporting Services. 
## **Modo de Autenticación**
También seleccionaremos un Modo de Autenticación. El siguiente enlace de MSDN detalla lo que son. 
[Descripción general de seguridad para Reporting Services en modo integrado de SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

En resumen, si tu sitio está utilizando **Autenticación de Claims**, siempre estarás utilizando Autenticación Confiable sin importar lo que elijas aquí. Si deseas pasar credenciales de Windows, querrás elegir Autenticación de Windows. Para la Autenticación Confiable, pasaremos el token de SPUser y no dependeremos de la credencial de Windows. 

También querrás usar Autenticación Confiable si has configurado tus sitios en Modo Clásico para NTLM y RS está configurado para NTLM. Se necesitaría Kerberos para usar Autenticación de Windows y pasar eso para tu fuente de datos. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)

**Figura 18**: Configuración de credenciales de Integración de Reporting Services
## **Activar Característica**
Esto te da la opción de activar Reporting Services en todas las colecciones de sitios, o puedes elegir en cuáles deseas activarlo. Esto realmente significa qué sitios podrán usar Reporting Services. 
Cuando se haya completado, deberías ver la siguiente figura. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)

**Figura 19**: Integración exitosa de Reporting Services con el entorno de SharePoint 

Regresando a la URL del Servidor de Informes como se indica en la Figura 14, deberíamos ver algo similar a la siguiente figura. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)

**Figura 20**: Verificación exitosa de Reporting Services con el entorno de SharePoint 

{{% alert color="primary" %}} 

Si tu sitio de SharePoint está configurado para SSL, no aparecerá en esta lista. Es un problema conocido y no significa que haya un problema. Tus informes aún deberían funcionar. 

{{% /alert %}} 

Ahora, estamos listos para usar Reporting Services en SharePoint 2010. Al igual que la versión anterior, tenemos una característica (activada cuando configuramos la Integración de Reporting Services) en la "Característica de Colección de Sitios". Además, la instalación agregó 3 tipos de contenido para agregar a nuestro sitio. En la Figura 21 podemos ver 2 de esos tipos de contenido añadidos en una biblioteca de documentos para crear un informe personalizado, como podemos ver en la Figura 21. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)

**Figura 21**: Report Builder 

El “ **Report Builder”** es un ActiveX que necesitamos descargar en el servidor, como podemos ver en la Figura 22. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)

**Figura 22**: Descargar e Instalar Report Builder 

Cuando finalice la descarga, ejecuta el **“Report Builder”**. Ahora, estamos listos para diseñar nuestro primer informe, como podemos ver en la Figura 23. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figura 23**: Asistente para la Generación de Nuevo Informe en Report Builder 

Después de crear nuestro informe, podríamos guardarlo en la biblioteca de documentos creada para poner los informes en nuestro SharePoint 2010. 

El otro tipo de contenido debe ser utilizado para crear una conexión compartida como fuente de datos y guardarlas en una biblioteca de documentos en SharePoint. Podemos crear una biblioteca de documentos, añadir este tipo de contenido y después tendremos nuestras conexiones disponibles para cambiar la fuente de datos de los informes. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)

**Figura 24**: Exportación exitosa del informe al Servidor de Informes 