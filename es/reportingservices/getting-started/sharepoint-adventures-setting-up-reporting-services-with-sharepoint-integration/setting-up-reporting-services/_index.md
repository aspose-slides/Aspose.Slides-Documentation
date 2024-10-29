---
title: Configuración de Reporting Services
type: docs
weight: 30
url: /es/reportingservices/setting-up-reporting-services/
---

{{% alert color="primary" %}} 

Nuestra primera parada en el servidor RS es el Administrador de Configuración de Reporting Services. 

{{% /alert %}} 
## **Cuenta de Servicio**
Asegúrate de entender qué cuenta de servicio estás usando para Reporting Services. Si encontramos problemas, puede estar relacionado con la cuenta de servicio que estás utilizando. La predeterminada es Network Service. Siempre que despliego nuevas versiones, siempre uso Cuentas de Dominio, porque es ahí donde probablemente tendré problemas. Para esta configuración en mi servidor, he utilizado una Cuenta de Dominio llamada **RSService**. 
## **URL del Servicio Web**
Necesitamos configurar la URL del Servicio Web. Este es el directorio virtual (vdir) **ReportServer** que aloja los Servicios Web que utiliza Reporting Services y con el que se comunicará SharePoint. A menos que desees personalizar las propiedades del vdir (es decir, SSL, puertos, encabezados de host, etc.), deberías poder hacer clic en Aplicar aquí y estar listo para continuar. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)

**Figura 3**: Configuración de URL del Servicio Web 

Cuando eso esté hecho, deberías ver la siguiente figura. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figura 4**: Configuración exitosa de la URL del Servicio Web 
## **Base de Datos**
Necesitamos crear la Base de Datos del Catálogo de Reporting Services. Esta puede colocarse en cualquier Motor de Base de Datos SQL 2008 o SQL 2008 R2. SQL11 también funcionaría bien, pero aún está en BETA. Esta acción creará dos bases de datos, **ReportServer** y **ReportServerTempDB**, por defecto. 
El otro paso importante con esto es asegurarte de que elijas SharePoint Integrado para el tipo de base de datos. Una vez que se haga esta elección, no se puede cambiar. Por favor, observa las Figuras 5, 6 y 7 como referencia. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figura 5**: Creando la Base de Datos del Servidor de Informes 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figura 6**: Configuración del Servidor de Bases de Datos y Tipo de Autenticación 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figura 7**: Configuración del Nombre de la Base de Datos y Modo 

Para las credenciales, así es como el Servidor de Informes se comunicará con el SQL Server. Cualquier cuenta que selecciones, se le otorgarán ciertos derechos dentro de la base de datos Catalog y algunas de las bases de datos del sistema a través del RSExecRole. MSDB es una de estas bases de datos para uso de Suscripción, ya que utilizamos SQL Agent. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figura 8**: Configuración de Credenciales de la Base de Datos del Servidor de Informes 

Una vez que eso esté hecho, debería verse como la siguiente figura. 

![todo:image_alt_text](setting-up-reporting-services_8.png)

**Figura 9**: Progreso para finalizar la configuración de la Base de Datos del Servidor de Informes 
## **URL del Administrador de Informes**
Podemos omitir la URL del Administrador de Informes, ya que no se utiliza cuando estamos en modo SharePoint Integrado. SharePoint es nuestro frontend. El Administrador de Informes no funciona. 
## **Claves de Encriptación**
Haz una copia de seguridad de tus Claves de Encriptación y asegúrate de saber dónde las guardas. Si te encuentras en una situación en la que necesitas migrar la Base de Datos o restaurarla, necesitarás estas claves. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

Eso es todo para el Administrador de Configuración de Reporting Services. Si navegas a la URL en la pestaña de URL del Servicio Web, debería mostrar algo similar a la siguiente figura. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figura 12**: Acceso al Servidor de Informes después de la instalación 

¿Qué sucedió? SharePoint está instalado en mi WFE y terminé de configurar Reporting Services. En este ejemplo, Reporting Services y SharePoint están en máquinas diferentes. Si hubieran estado en la misma máquina, no habrías visto este error. Técnicamente necesitamos instalar SharePoint en la Caja RS. Eso significa que IIS también estará habilitado.